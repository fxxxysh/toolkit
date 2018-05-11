#pragma once

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
	uint8_t type; //�豸����
	uint8_t version; //�豸�ͺ�
	uint8_t base_mode;
	uint8_t system_status;
	uint8_t comversion;
}heartbeat_t;

typedef struct
{
	uint8_t magic; //֡ͷ
	uint8_t len; //���س���
	uint8_t seq; //������
	//uint8_t flags; //��־λ
	uint8_t sysid; //ϵͳID
	uint8_t compid; //���ID
	uint8_t msgid; //��ϢID
	uint8_t payload[MAX_PAYLOAD_LEN];
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