// comlink.cpp: 定义 DLL 应用程序的导出函数。
//

#include "stdafx.h"
#include "string.h"
#include "stdint.h"
#include <stdio.h>
#include "comlink.h"
#include "comlink_ex.h"

using namespace std;

#define _MSG_PAYLOAD(msg) ((uint8_t *)(&((msg)->payload[0])))

class comlink
{
public:

	virtual ~comlink() {};
	comlink() 
	{
		memset(&m_status, 0, sizeof(m_status));
		memset(&parse_msg, 0, sizeof(parse_msg));
	}

public:
	parse_status_t m_status;
	message_t parse_msg[64];
	message_t receive_msg;

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

	static void crc_init(uint16_t *crcAccum)
	{
		*crcAccum = 0xffff;
	}

	static void start_checksum(message_t *msg)
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

	static uint16_t crc_calculate(const uint8_t *pBuffer, uint16_t length)
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

	static void update_checksum(message_t *msg, uint8_t c)
	{
		crc_accumulate(c, &msg->checksum);
	}

	void message_encode(message_t *msg, uint8_t compid, uint8_t msg_id, uint8_t length)
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

		*((msg)->len + (uint8_t *)_MSG_PAYLOAD(msg))  = (uint8_t)(msg->checksum & 0xFF);
		*(((msg)->len+(uint16_t)1) + (uint8_t *)_MSG_PAYLOAD(msg))  = (uint8_t)(msg->checksum >> 8);
	}

	status_t packet_encode(message_t *msg, const uint8_t *packet, uint8_t compid, uint8_t msg_id, uint8_t length)
	{
		memcpy(_MSG_PAYLOAD(msg), packet, length);
		message_encode(msg, compid, msg_id, length);
		return _OK;
	}

	status_t packet_send(message_t *msg, const uint8_t *packet, uint8_t compid, uint8_t msg_id, uint8_t length)
	{
		packet_encode(msg, packet, compid, msg_id, length);
		 return message_hander_send(msg, msg->len + HEADER_LEN + 3);
	}

	status_t message_hander_send(const message_t *msg, uint8_t length)
	{
		return send_uart((uint8_t*)msg, length);
	}

	 static uint8_t frame_char(message_t *rxmsg, parse_status_t *status, uint8_t c)
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

	 uint8_t parse_char(uint8_t *ch, int length)
	 {
		 uint8_t msg_cnt = 0;
		 uint8_t c;
		 uint8_t msg_received = FRAMING_BAD_SIGNATURE;

		 for (int i = 0; i < length; i++)
		 {
			  c = *(ch + i);
			  msg_received = frame_char(&receive_msg, &m_status, c);

			 if (msg_received == FRAMING_BAD_CRC || msg_received == FRAMING_BAD_SIGNATURE)
			 {
				 message_t *rxmsg = &receive_msg;
				 parse_status_t *status = &m_status;

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
			 else if(msg_received == FRAMING_OK)
			 {			
				 memcpy(&parse_msg[msg_cnt], &receive_msg, sizeof(message_t));
				 msg_cnt++;
			 }
		 }
		 return msg_cnt;
	 }

	 status_t send_uart(const uint8_t *buf, uint16_t len)
	 {
		 for (int i = 0; i < len; i++)
		 {
			 printf("%02X ", buf[i]);
		 }

		 return _OK;
	 }
};

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


comlink _comlink;

void comlink_get_msg(message_t *msg, uint8_t cnt)
{
	static int size = sizeof(message_t);
	memcpy(msg, &_comlink.parse_msg[cnt], size);
}

void comlink_get_status(parse_status_t *m_status)
{
	memcpy(m_status, &_comlink.m_status, sizeof(parse_status_t));
}

uint8_t comlink_parse(uint8_t *buffer, int buffer_size)
{
	return _comlink.parse_char(buffer, buffer_size);
}

uint8_t comlink_encode(message_t *msg, const uint8_t *packet, uint8_t compid, uint8_t msg_id, uint8_t length)
{
	return _comlink.packet_encode(msg, packet, compid, msg_id, length);
}

uint8_t comlink_trans(Trans trans, message_t *msg, const uint8_t *packet, uint8_t compid, uint8_t msg_id, uint8_t length)
{
	_comlink.packet_encode(msg, packet, compid, msg_id, length);
	 trans((uint8_t *)msg, msg->len + HEADER_LEN + 3);

	 return _OK;
}

void comlink_test(void(*trans)(uint8_t*, int))
{
	uint8_t buff[2] = { 1,2 };
	trans(buff, 2);
}
