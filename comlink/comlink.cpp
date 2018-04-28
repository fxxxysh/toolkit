// comlink.cpp: 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "string.h"
#include "stdint.h"
#include <stdio.h>

#ifndef COMLINKL_DEBUG
#include "comlink.h"
#endif // COMLINKL_DEBUG

using namespace std;

#define _MSG_PAYLOAD(msg) ((uint8_t *)(&((msg)->payload[0])))

#define STX 0xFE
#define SYS_ID 10

#define HEADER_LEN  5
#define MAX_PAYLOAD_LEN  255
#define NUM_CHECKSUM  2

#define MSG_ID_HEARTBEAT  0

#define status_t uint8_t
#define _OK 0
#define _ERROR 1

class comlink
{
public:

	comlink() {};
	virtual ~comlink() {};

	enum parse_state_t
	{
		PARSE_STATE_UNINIT = 0,
		PARSE_STATE_IDLE,
		PARSE_STATE_GOT_STX,
		PARSE_STATE_GOT_LENGTH,
		PARSE_STATE_GOT_COMPAT_FLAGS,
		PARSE_STATE_GOT_SEQ,
		PARSE_STATE_GOT_SYSID,
		PARSE_STATE_GOT_COMPID,
		PARSE_STATE_GOT_MSGID,
		PARSE_STATE_GOT_PAYLOAD,
		PARSE_STATE_GOT_CRC1,
		PARSE_STATE_GOT_BAD_CRC1,
	};

	typedef enum {
		FRAMING_INCOMPLETE = 0,
		FRAMING_OK = 1,
		FRAMING_BAD_CRC = 2,
		FRAMING_BAD_SIGNATURE = 3
	} framing_t;

	typedef struct
	{
		uint32_t custom_mode;
		uint8_t type; //设备类型
		uint8_t version; //设备型号
		uint8_t base_mode;
		uint8_t system_status;
		uint8_t comversion;
	}heartbeat_t;

	typedef struct
	{
		uint8_t magic; //枕头
		uint8_t len; //负载长度
		uint8_t seq; //序列码
		uint8_t flags; //标志位
		uint8_t sysid; //系统ID
		uint8_t compid; //组件ID
		uint8_t msgid; //消息ID
		uint8_t payload[(MAX_PAYLOAD_LEN + NUM_CHECKSUM + 1) / 2 * 2];
		uint16_t checksum; //实时校验
		uint8_t ck[2]; //接收校验
	}message_t;

	typedef struct
	{
		uint8_t msg_received; //包接收标志
		uint8_t buffer_overrun; // 消息包长度溢出
		uint8_t parse_error; //解析失败计数
		parse_state_t parse_state; //当前解析状态
		uint8_t packet_idx; // 当前包接收计数
		uint8_t current_rx_seq; //接收消息包序列码
		uint8_t current_tx_seq; //发送消息包序列码
	}parse_status_t;

	parse_status_t m_status;
	message_t m_buffer;

	static void parse_error(parse_status_t *status)
	{
		status->parse_error++;
	}

	//crc
	uint16_t checksum(uint16_t *buffer, uint16_t size)
	{
		uint32_t cksum = 0;

		while (size > 1)
		{
			cksum += *buffer++;
			size -= 2;
		}

		if (size)
		{
			cksum += *(uint8_t *)buffer;
		}

		while (cksum >> 16)
		{
			cksum = (cksum >> 16) + (cksum & 0xffff);
		}
		return (uint16_t)(~cksum);
	}

	static void crc_init(uint16_t* crcAccum)
	{
		*crcAccum = 0xffff;
	}

	static void start_checksum(message_t* msg)
	{
		crc_init(&msg->checksum);
	}

	static void crc_accumulate(uint8_t data, uint16_t *crcAccum)
	{
		//将一个字节的数据累加到CRC
		uint8_t tmp;

		tmp = data ^ (uint8_t)(*crcAccum & 0xff);
		tmp ^= (tmp << 4);
		*crcAccum = (*crcAccum >> 8) ^ (tmp << 8) ^ (tmp << 3) ^ (tmp >> 4);
	}

	static uint16_t crc_calculate(const uint8_t* pBuffer, uint16_t length)
	{
		uint16_t crcTmp;
		crc_init(&crcTmp);

		while (length--)
		{
			crc_accumulate(*pBuffer++, &crcTmp);
		}
		return crcTmp;
	}

	static void crc_accumulate_buffer(uint16_t *crcAccum, const uint8_t *pBuffer, uint16_t length)
	{
		const uint8_t *p = (const uint8_t *)pBuffer;
		while (length--)
		{
			crc_accumulate(*p++, crcAccum);
		}
	}

	static void update_checksum(message_t* msg, uint8_t c)
	{
		crc_accumulate(c, &msg->checksum);
	}

	//meseage send
	status_t message_send(message_t* msg, uint8_t compid, uint8_t msg_id, uint8_t length)
	{
		msg->magic = STX;
		msg->len = length;
		msg->seq = m_status.current_tx_seq;
		msg->sysid = SYS_ID;
		msg->compid = compid;
		msg->msgid = msg_id;;

		m_status.current_tx_seq = (m_status.current_tx_seq + 1) % 0xf0;
		msg->checksum = crc_calculate((uint8_t *)msg + 1, HEADER_LEN);
		crc_accumulate_buffer(&msg->checksum, _MSG_PAYLOAD(msg), msg->len);

		*((msg)->len + (uint8_t *)_MSG_PAYLOAD(msg))  = (uint8_t)(msg->checksum & 0xFF);
		*(((msg)->len+(uint16_t)1) + (uint8_t *)_MSG_PAYLOAD(msg))  = (uint8_t)(msg->checksum >> 8);

		return message_hander_send(msg);
	}

	//pkg send
	status_t packet_send(message_t* msg, const uint8_t *packet, uint8_t compid, uint8_t msg_id, uint8_t length)
	{
		memcpy(_MSG_PAYLOAD(msg), packet, length);
		return message_send(msg, compid, msg_id, length);
	}

	 //hander send
	status_t message_hander_send(const message_t *msg)
	{
		return send_uart((uint8_t*)msg, msg->len + HEADER_LEN + 3);
	}

	// parse
	 static uint8_t frame_char(message_t* rxmsg,
		 parse_status_t* status,
		 uint8_t c)
	 {
		 status->msg_received = FRAMING_INCOMPLETE;

		 switch (status->parse_state)
		 {
		 case PARSE_STATE_UNINIT:
		 case PARSE_STATE_IDLE:

			 if (c == STX)
			 {
				 status->parse_state = PARSE_STATE_GOT_STX;
				 rxmsg->len = 0;
				 rxmsg->magic = c;
				 start_checksum(rxmsg);
			 }
			 break;

		 case PARSE_STATE_GOT_STX:
			 // NOT counting STX, LENGTH, SEQ, SYSID, COMPID, MSGID, CRC1 and CRC2
			 if (c > MAX_PAYLOAD_LEN)
			 {
				 status->buffer_overrun++;
				 parse_error(status);
				 status->msg_received = 0;
				 status->parse_state = PARSE_STATE_IDLE;
			 }
			 else
			 {
				 rxmsg->len = c;
				 status->packet_idx = 0;
				 update_checksum(rxmsg, c);
				 status->parse_state = PARSE_STATE_GOT_COMPAT_FLAGS;
			 }
			 break;

		 case PARSE_STATE_GOT_COMPAT_FLAGS:
			 rxmsg->seq = c;
			 update_checksum(rxmsg, c);
			 status->parse_state = PARSE_STATE_GOT_SEQ;
			 break;

		 case PARSE_STATE_GOT_SEQ:
			 rxmsg->sysid = c;
			 update_checksum(rxmsg, c);
			 status->parse_state = PARSE_STATE_GOT_SYSID;
			 break;

		 case PARSE_STATE_GOT_SYSID:
			 rxmsg->compid = c;
			 update_checksum(rxmsg, c);
			 status->parse_state = PARSE_STATE_GOT_COMPID;
			 break;

		 case PARSE_STATE_GOT_COMPID:
			 rxmsg->msgid = c;
			 update_checksum(rxmsg, c);
			 status->parse_state = PARSE_STATE_GOT_MSGID;
			 break;

		 case PARSE_STATE_GOT_MSGID:
			 _MSG_PAYLOAD(rxmsg)[status->packet_idx++] = (char)c;
			 update_checksum(rxmsg, c);
			 if (status->packet_idx == rxmsg->len)
			 {
				 status->parse_state = PARSE_STATE_GOT_PAYLOAD;
			 }
			 break;

		 case PARSE_STATE_GOT_PAYLOAD: {
			 if (c != (rxmsg->checksum & 0xFF)) {
				 status->parse_state = PARSE_STATE_GOT_BAD_CRC1;
			 }
			 else {
				 status->parse_state = PARSE_STATE_GOT_CRC1;
			 }
			 rxmsg->ck[0] = c;
			 break;
		 }

		 case PARSE_STATE_GOT_CRC1:
		 case PARSE_STATE_GOT_BAD_CRC1:
			 if (status->parse_state == PARSE_STATE_GOT_BAD_CRC1 || c != (rxmsg->checksum >> 8)) {
				 status->msg_received = FRAMING_BAD_CRC;
			 }
			 else {
				 status->msg_received = FRAMING_OK;		
				 status->parse_error = 0;
			 }
			 rxmsg->ck[1] = c;

			 status->current_rx_seq = rxmsg->seq;
			 status->parse_state = PARSE_STATE_IDLE;		 
		 }

		 return status->msg_received;
	 }

	 uint8_t parse_char(uint8_t c)
	 {
		 uint8_t msg_received = frame_char(&m_buffer, &m_status, c);

		 if (msg_received == FRAMING_BAD_CRC ||
			 msg_received == FRAMING_BAD_SIGNATURE) {

			 //解析失败
			 message_t* rxmsg = &m_buffer;
			 parse_status_t* status = &m_status;

			 parse_error(status);
			 status->msg_received = FRAMING_INCOMPLETE;
			 status->parse_state = PARSE_STATE_IDLE;
			 if (c == STX)
			 {
				 status->parse_state = PARSE_STATE_GOT_STX;
				 rxmsg->len = 0;
				 start_checksum(rxmsg);
			 }
			 return 0;
		 }
		 return msg_received;
	 }

	 void read_byte()
	 {
		 int bytesAvailable = 0;

		 int chan = 0;
		 while (bytesAvailable > 0)
		 {
			 uint8_t byte = 0;
			 if (parse_char(byte))
			 {
				 //解析成功后调用不同的拆包函数		
				 //memcpy(r_message, rxmsg, sizeof(message_t));
			 }
		 }
	 }

	status_t send_uart(const uint8_t *buf, uint16_t len)
	{
		for (int i = 0; i < len; i++)
		{
			printf("%02X ", buf[i]);
		}

		return _OK;
	}

	void commsg_test()
	{
		heartbeat_t packet;

		packet.custom_mode = 0;
		packet.type = 17;
		packet.version = 84;
		packet.base_mode = 151;
		packet.system_status = 218;
		packet.comversion = 3;

		//message_chan_send(COMM_1,
		//	MSG_ID_HEARTBEAT,
		//	(uint8_t*)&packet,
		//	MSG_ID_HEARTBEAT_MIN_LEN,
		//	MSG_ID_HEARTBEAT_LEN,
		//	50);
	}
};

uint8_t data_cache[4096];
bool comlink_parse(uint8_t *buffer, int buffer_size)
{
	comlink *_comlink = new comlink();
	memcpy(data_cache, buffer, buffer_size);

	_comlink->commsg_test();

	delete _comlink;
	return true;
}

bool comlink_get_msg(uint8_t* msg_number, uint8_t* now_msg,
	uint16_t* len, uint8_t* payload, uint8_t* seq, uint8_t* sysid, uint8_t* compid, uint8_t* msgid)
{
	return true;
}