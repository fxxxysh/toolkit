#pragma once

#include "stdint.h"
#include "string.h"
#include "comlink_msg.h"

#define STX 0xFE
#define SYS_ID 10

#define HEADER_LEN  5
#define MAX_PAYLOAD_LEN  255
#define NUM_CHECKSUM  2

#define MSG_ID_HEARTBEAT  0

#define status_t uint8_t
#define _OK 0
#define _ERROR 1

#define _MSG_PAYLOAD(msg) ((uint8_t *)(&((msg)->payload[0])))

#ifdef USE_HAL_DRIVER
#define MAX_MSG_IND 1
#else
#define MAX_MSG_IND 128
#endif

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
	uint8_t magic; //֡ͷ
	uint8_t len; //���س���
	uint8_t seq; //������
				 //uint8_t flags; //��־λ
	uint8_t sysid; //ϵͳID
	uint8_t compid; //���ID
	uint8_t msgid; //��ϢID
	uint8_t payload[MAX_PAYLOAD_LEN + NUM_CHECKSUM];
	uint16_t checksum; //ʵʱУ��
	uint8_t ck[2]; //����У��
}message_t;

typedef struct
{
	uint8_t msg_received; //�����ձ�־
	uint8_t buffer_overrun; // ��Ϣ���������
	uint8_t parse_error; //����ʧ�ܼ���
	parse_state_t parse_state; //��ǰ����״̬
	uint8_t packet_idx; // ��ǰ�����ռ���
	uint8_t current_rx_seq; //������Ϣ��������
	uint8_t current_tx_seq; //������Ϣ��������
}parse_status_t;

typedef uint8_t(*Trans)(uint8_t *, int);

class comlink
{
public:
	virtual ~comlink() {};
	comlink()
	{
		memset(&m_status, 0, sizeof(m_status));
		//memset(&parse_msg, 0, sizeof(parse_msg));
		memset(&receive_msg, 0, sizeof(receive_msg));
		_this = this;
	}

public:
	static comlink *_this;

	queue <message_t> parse_msg;
	//uint8_t parse_msg_cnt = 0;
	//message_t parse_msg[MAX_MSG_IND];

	parse_status_t m_status;
	message_t receive_msg;

	static void parse_error(parse_status_t *status);

	//crc
	uint16_t checksum(uint16_t *buffer, uint16_t size);

	static void crc_init(uint16_t *crcAccum);

	static void start_checksum(message_t *msg);

	static void crc_accumulate(uint8_t data, uint16_t *crcAccum);

	static uint16_t crc_calculate(const uint8_t *pBuffer, uint16_t length);

	static void crc_accumulate_buffer(uint16_t *crcAccum, const uint8_t *pBuffer, uint16_t length);

	static void update_checksum(message_t *msg, uint8_t c);

	// message ��װ
	void message_encode(message_t *msg, uint8_t compid, uint8_t msg_id, uint8_t length);

	// packet ��װ
	void packet_encode(message_t *msg, const uint8_t *packet, uint8_t compid, uint8_t msg_id, uint8_t length);

	// packet ����
	status_t packet_hander_trans(Trans trans, message_t *msg, const uint8_t *packet, uint8_t compid, uint8_t msg_id, uint8_t length);

	// message ����
	status_t message_hander_trans(Trans trans, const message_t *msg);

	static uint8_t frame_char(message_t *rxmsg, parse_status_t *status, uint8_t c);

	// ��������
	int parse_char(uint8_t *ch, int length);

	status_t send_uart(const uint8_t *buf, uint16_t len);
};