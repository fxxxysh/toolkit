// comlink.cpp: 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "string.h"
#include "stdint.h"
#include <stdio.h>
#include "comlink.h"

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
				 //uint8_t flags; //标志位
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

class comlink
{
public:

	virtual ~comlink() {};
	comlink()
	{
		memset(&m_status, 0, sizeof(m_status));
		memset(&receive_msg, 0, sizeof(receive_msg));
		memset(&trans_msg, 0, sizeof(trans_msg));
	}

public:
	parse_status_t m_status;
	message_t receive_msg;
	message_t trans_msg;

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

	//meseage encode
	void message_encode(message_t* msg, uint8_t compid, uint8_t msg_id, uint8_t length)
	{
		msg->magic = STX;
		msg->len = length;
		msg->seq = m_status.current_tx_seq;
		msg->sysid = SYS_ID;
		msg->compid = compid;
		msg->msgid = msg_id;;

		m_status.current_tx_seq = m_status.current_tx_seq + 1;
		msg->checksum = crc_calculate((uint8_t *)msg + 1, HEADER_LEN);
		crc_accumulate_buffer(&msg->checksum, _MSG_PAYLOAD(msg), msg->len);

		*((msg)->len + (uint8_t *)_MSG_PAYLOAD(msg)) = (uint8_t)(msg->checksum & 0xFF);
		*(((msg)->len + (uint16_t)1) + (uint8_t *)_MSG_PAYLOAD(msg)) = (uint8_t)(msg->checksum >> 8);
	}

	//pkg send
	status_t packet_send(message_t* msg, const uint8_t *packet, uint8_t compid, uint8_t msg_id, uint8_t length)
	{
		memcpy(_MSG_PAYLOAD(msg), packet, length);
		message_encode(msg, compid, msg_id, length);
		return message_hander_send(msg, msg->len + HEADER_LEN + 3);
	}

	//hander send
	status_t message_hander_send(const message_t *msg, uint8_t length)
	{
		return send_uart((uint8_t*)msg, length);
	}

	// parse
	static uint8_t frame_char(message_t* rxmsg, parse_status_t* status, uint8_t* ch, uint8_t length)
	{
		status->msg_received = FRAMING_INCOMPLETE;

		for (int i = 0; i < length; i++)
		{
			uint8_t c = *(ch + i);
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
		}
		return status->msg_received;
	}

	uint8_t parse_char(uint8_t* ch, uint8_t length)
	{
		uint8_t msg_received = frame_char(&receive_msg, &m_status, ch, length);

		if (msg_received == FRAMING_BAD_CRC || msg_received == FRAMING_BAD_SIGNATURE)
		{
			message_t* rxmsg = &receive_msg;
			parse_status_t* status = &m_status;

			parse_error(status);
			status->msg_received = FRAMING_INCOMPLETE;
			status->parse_state = PARSE_STATE_IDLE;

			if (*(ch + length - 1) == STX)
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
			if (parse_char(&byte, 1))
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
comlink *_comlink;

#define COMPACKED( __Declaration__ ) __pragma( pack(push, 1) ) __Declaration__ __pragma( pack(pop) )

COMPACKED(
	typedef struct __mavlink_attitude_t {
	uint32_t time_boot_ms; /*< Timestamp (milliseconds since system boot)*/
	float roll; /*< Roll angle (rad, -pi..+pi)*/
	float pitch; /*< Pitch angle (rad, -pi..+pi)*/
	float yaw; /*< Yaw angle (rad, -pi..+pi)*/
	float rollspeed; /*< Roll angular speed (rad/s)*/
	float pitchspeed; /*< Pitch angular speed (rad/s)*/
	float yawspeed; /*< Yaw angular speed (rad/s)*/
}) mavlink_attitude_t;


message_t test_trans_msg;

bool test_comlink_parse(uint8_t *buffer, int buffer_size)
{
	memcpy(data_cache, buffer, buffer_size);

	mavlink_attitude_t mavlink_attitude;
	mavlink_attitude_t rx_mavlink_attitude;

	mavlink_attitude.pitch = 89.12;
	mavlink_attitude.pitchspeed = 0.12;
	mavlink_attitude.roll = 178.23;
	mavlink_attitude.rollspeed = 1.21;
	mavlink_attitude.time_boot_ms = 12345678;
	mavlink_attitude.yaw = 272.78;
	mavlink_attitude.yawspeed = 2.65;

	uint8_t pkg_length = sizeof(mavlink_attitude);
	_comlink.packet_send(&test_trans_msg, (uint8_t *)&mavlink_attitude, 1, 2, pkg_length);

	int msg_length = HEADER_LEN + pkg_length + 3;
	if (_comlink.parse_char((uint8_t *)&test_trans_msg, msg_length))
	{
		memcpy(&rx_mavlink_attitude, _MSG_PAYLOAD(&test_trans_msg), pkg_length);
	}
	return true;
}

bool comlink_parse(uint8_t *buffer, int buffer_size)
{
	_comlink = new comlink();
	memcpy(data_cache, buffer, buffer_size);

	mavlink_attitude_t mavlink_attitude;
	mavlink_attitude_t rx_mavlink_attitude;

	mavlink_attitude.pitch = 89.12;
	mavlink_attitude.pitchspeed = 0.12;
	mavlink_attitude.roll = 178.23;
	mavlink_attitude.rollspeed = 1.21;
	mavlink_attitude.time_boot_ms = 12345678;
	mavlink_attitude.yaw = 272.78;
	mavlink_attitude.yawspeed = 2.65;

	uint8_t pkg_length = sizeof(mavlink_attitude);
	_comlink->packet_send(&test_trans_msg, (uint8_t *)&mavlink_attitude, 1, 2, pkg_length);

	int msg_length = HEADER_LEN + pkg_length + 3;
	if (_comlink->parse_char((uint8_t *)&test_trans_msg, msg_length) == FRAMING_OK)
	{
		memcpy(&rx_mavlink_attitude, _MSG_PAYLOAD(&test_trans_msg), pkg_length);
	}

	delete _comlink;
	return true;
}

bool comlink_get_msg(uint8_t* msg_number, uint8_t* now_msg,
	uint16_t* len, uint8_t* payload, uint8_t* seq, uint8_t* sysid, uint8_t* compid, uint8_t* msgid)
{
	return true;
}

void comlink_test(void)
{

}



#include "comlink_ex.h"
#include "comlink.h"

int msg_ind;
unordered_map<int, TypeBase*> msg_map;
unordered_map<string, int> key_map;

// test
int plot_list[10];

double test_plot[10];

#pragma pack(push,1)
struct MyStruct
{
	double _double;
	uint64_t _u64;
	int64_t _i64;

	float _float;
	uint32_t _u32[4];
	int32_t _i32;

	uint16_t _u16;
	int16_t _i16;

	uint8_t _u8;
	int8_t _i8;
};
#pragma pack(pop)

#pragma pack(push,1)
typedef struct __mavlink_attitude_t {
	uint32_t time_boot_ms; /*< Timestamp (milliseconds since system boot)*/
	float roll; /*< Roll angle (rad, -pi..+pi)*/
	float pitch; /*< Pitch angle (rad, -pi..+pi)*/
	float yaw; /*< Yaw angle (rad, -pi..+pi)*/
	float rollspeed; /*< Roll angular speed (rad/s)*/
	float pitchspeed; /*< Pitch angular speed (rad/s)*/
	float yawspeed; /*< Yaw angular speed (rad/s)*/
} mavlink_attitude_t;
#pragma pack(pop) 

void msg_list_init()
{
	for (int i = 0; i < 10; i++)
	{
		plot_list[i] = i;
	}

	//comlink_add_msg("1", TYPE_DOUBLE, 1);
	//comlink_add_msg("2", TYPE_U64, 1);
	//comlink_add_msg("3", TYPE_I64, 1);
	//comlink_add_msg("4", TYPE_FLOAT, 1);
	//comlink_add_msg("5", TYPE_U32, 4);
	//comlink_add_msg("6", TYPE_I32, 1);
	//comlink_add_msg("7", TYPE_U16, 1);
	//comlink_add_msg("8", TYPE_I16, 1);
	//comlink_add_msg("9", TYPE_U8, 1);
	//comlink_add_msg("10", TYPE_I8, 1);

	MyStruct tt;
	tt._double = 123456.789123;
	tt._float = 123456.123;
	tt._i16 = -12345;
	tt._u16 = 12345;
	tt._i32 = -123450;

	tt._u32[0] = 1112345;
	tt._u32[1] = 2212345;
	tt._u32[2] = 3312345;
	tt._u32[3] = 4412345;

	tt._i64 = -123456789;
	tt._u64 = 123456789;
	tt._i8 = -123;
	tt._u8 = 123;
	uint8_t tt_arry[100];
	memcpy(tt_arry, (uint8_t *)&tt, sizeof(MyStruct));

	uint8_t *str_ind = tt_arry;
	for (int i = 0; i < 10; i++)
	{
		str_ind = msg_map[plot_list[i]]->copy(str_ind);

		//test_plot[i] = msg_map[plot_list[i]]->pop();
	}

	//double tt1 = msg_map[key_map["9"]]->pop();
}