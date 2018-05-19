
#ifdef DLL_EXPORTS
#include "comlink_ex.h"
#include "comlink_msg.h"
#include <stdio.h>
#else
#include "platforms/platforms.h"
#endif

#include <string>
#include "comlink.h"

using namespace std;

void comlink::parse_error(parse_status_t *status)
{
	status->parse_error++;
}

// tcp/ip 校验和算法
uint16_t comlink::checksum(uint16_t *buffer, uint16_t size)
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

void comlink::crc_init(uint16_t *crcAccum)
{
	*crcAccum = 0xffff;
}

void comlink::start_checksum(message_t *msg)
{
	crc_init(&msg->checksum);
}

void comlink::crc_accumulate(uint8_t data, uint16_t *crcAccum)
{
	//将一个字节的数据累加到CRC
	uint8_t tmp;

	tmp = data ^ (uint8_t)(*crcAccum & 0xff);
	tmp ^= (tmp << 4);
	*crcAccum = (*crcAccum >> 8) ^ (tmp << 8) ^ (tmp << 3) ^ (tmp >> 4);
}

uint16_t comlink::crc_calculate(const uint8_t *pBuffer, uint16_t length)
{
	uint16_t crcTmp;
	crc_init(&crcTmp);

	while (length--)
	{
		crc_accumulate(*pBuffer++, &crcTmp);
	}
	return crcTmp;
}

void comlink::crc_accumulate_buffer(uint16_t *crcAccum, const uint8_t *pBuffer, uint16_t length)
{
	const uint8_t *p = (const uint8_t *)pBuffer;
	while (length--)
	{
		crc_accumulate(*p++, crcAccum);
	}
}

void comlink::update_checksum(message_t *msg, uint8_t c)
{
	crc_accumulate(c, &msg->checksum);
}

void comlink::message_encode(message_t *msg, uint8_t compid, uint8_t msg_id, uint8_t length)
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

void comlink::packet_encode(message_t *msg, const uint8_t *packet, uint8_t compid, uint8_t msg_id, uint8_t length)
{
	memcpy(_MSG_PAYLOAD(msg), packet, length);
	message_encode(msg, compid, msg_id, length);
}

status_t comlink::packet_hander_trans(Trans trans, message_t *msg, const uint8_t *packet, uint8_t compid, uint8_t msg_id, uint8_t length)
{
	packet_encode(msg, packet, compid, msg_id, length);
	return message_hander_trans(trans, msg);
}

status_t comlink::message_hander_trans(Trans trans, const message_t *msg)
{
	return trans((uint8_t*)msg, msg->len + HEADER_LEN + 3);
}

uint8_t comlink::frame_char(message_t *rxmsg, parse_status_t *status, uint8_t c)
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
		if ((c != 0) && (c != SYS_ID))
		{
			status->msg_received = 0;
			status->parse_state = PARSE_STATE_IDLE;
		}
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

uint8_t comlink::parse_char(uint8_t *ch, int length)
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
		else if (msg_received == FRAMING_OK)
		{
			memcpy(&parse_msg[msg_cnt], &receive_msg, sizeof(message_t));
			if (msg_cnt >= MAX_MSG_IND)
			{
				return msg_cnt;
			}
			msg_cnt++;
		}
	}
	return msg_cnt;
}

comlink * comlink::_this = nullptr;
comlink _comlink;

#ifdef DLL_EXPORTS

class ComlinkMap
{
public:
	ComlinkMap() {}
	~ComlinkMap() {}

	// 消息表长度
	int _ind = 0;

	// 消息表
	unordered_map<int, TypeBase*> _msg;

	// 消息信息表
	MsgInfo _info[255];

	// 消息键值表，通过消息名获取消息值表
	unordered_map<string, int> _key;

private:

};

ComlinkMap comlink_map;
/**
  * @brief  重置消息信息表
  * @retval void
  */
void comlink_clear_map()
{
	comlink_map._msg.clear();
	comlink_map._key.clear();

	comlink_map._ind = 0;

	for (int i = 0; i < 255; i++)
	{
		comlink_map._info[i]._init = false;
	}
}

/**
  * @brief  消息表中添加一条消息成员
  * @param  string name 消息成员名
  * @param  uint8_t type_sign 数据类型
  * @param  uint8_t number 数组成员数量
  * @retval void
  */
void comlink_add_msgpart(char *name, uint8_t type_sign, uint8_t number)
{
	comlink_map._msg.insert(make_pair(comlink_map._ind, new TypeBase(name, type_sign, number)));
	comlink_map._key.insert(make_pair(name, comlink_map._ind));
	comlink_map._ind++;
}

/**
  * @brief  消息信息表中添加相关信息
  * @param  uint8_t msg_id 消息id
  * @param  string name 消息名
  * @param  int map_ind 消息在map中的偏移
  * @param  uint8_t size 消息包大小byte
  * @param  uint8_t number 消息包成员数量
  * @retval void
  */
void comlink_add_msginfo(uint8_t msg_id, char *name, int map_ind, uint8_t size, uint8_t number)
{
	comlink_map._info[msg_id].init(name, map_ind, size, number);
}

/**
  * @brief  解析消息包，更新map表, 针对同时解析出多个消息包
  * @param  uint8_t cnt 
  * @retval void
  */
void comlink_refresh_msgmap(uint8_t cnt)
{
	// 获取消息id
	uint8_t msg_id = _comlink.parse_msg[cnt].msgid;

	// 获取消息id成员数量
	uint8_t msg_number = comlink_map._info[msg_id]._number;

	// 获取消息id在map中的偏移
	int map_ind = comlink_map._info[msg_id]._map_ind;

	// 获取消息包载荷
	uint8_t *src = _MSG_PAYLOAD(&_comlink.parse_msg[cnt]);

	// 更新map
	for (int i = 0; i < msg_number; i++)
	{
		src = comlink_map._msg[map_ind++]->copy(src);
	}
}

/**
  * @brief  通过消息表id，指定数组地址，获取值(double)
  * @param  int v_ind 消息表索引地址
  * @param  uint8_t a_ind 非数组为0
  * @retval double
  */
double comlink_msgpart_value(int v_ind, uint8_t a_ind)
{
	return comlink_map._msg[v_ind]->get(a_ind);
}

/**
  * @brief  获取消息表总偏移
  * @retval int
  */
int comlink_msgmap_ind()
{
	return comlink_map._ind;
}

/**
* @brief  在消息列表中获取指定消息包
* @param  message_t * msg
* @param  uint8_t cnt
* @retval void
*/
void comlink_get_msg(message_t *msg, uint8_t cnt)
{
	static int size = sizeof(message_t);

	if (_comlink.parse_msg[cnt].msgid < MSG_ID_FIX_CNT)
	{
		memcpy(msg, &_comlink.parse_msg[cnt], size);
	}
	else
	{
		memcpy(msg, &_comlink.parse_msg[cnt], 6);	
	}
}

/**
  * @brief  获取当前消息包解析状态
  * @param  parse_status_t * m_status 
  * @retval void
  */
void comlink_get_status(parse_status_t *m_status)
{
	memcpy(m_status, &_comlink.m_status, sizeof(parse_status_t));
}

/**
  * @brief  消息解析函数，消息包更新到parse_msg列表
  * @param  uint8_t * buffer 
  * @param  int buffer_size 
  * @retval uint8_t
  */
uint8_t comlink_parse(uint8_t *buffer, int buffer_size)
{
	return _comlink.parse_char(buffer, buffer_size);
}

/**
  * @brief  消息封包函数
  * @param  message_t * msg 
  * @param  const uint8_t * packet 
  * @param  uint8_t compid 
  * @param  uint8_t msg_id 
  * @param  uint8_t length 
  * @retval uint8_t
  */
uint8_t comlink_encode(message_t *msg, const uint8_t *packet, uint8_t compid, uint8_t msg_id, uint8_t length)
{
	_comlink.packet_encode(msg, packet, compid, msg_id, length);

	return _OK;
}

/**
  * @brief  传输消息包
  * @param  Trans trans 传输回调
  * @param  message_t * msg pkg编码后的消息包
  * @param  const uint8_t * packet pkg包
  * @param  uint8_t compid 组件id
  * @param  uint8_t msg_id 消息id
  * @param  uint8_t length 数据长度
  * @retval uint8_t 返回状态
  */
uint8_t comlink_trans(Trans trans, message_t *msg, const uint8_t *packet, uint8_t compid, uint8_t msg_id, uint8_t length)
{
	_comlink.packet_encode(msg, packet, compid, msg_id, length);
	return trans((uint8_t *)msg, msg->len + HEADER_LEN + 3);
}

uint8_t test_uart_send(const uint8_t *buf, int len)
{
	for (int i = 0; i < len; i++)
	{
		printf("%02X ", buf[i]);
	}

	return _OK;
}

uint8_t *comlink_msg_copye(int v_ind, uint8_t *str_ind)
{
	str_ind = comlink_map._msg[v_ind]->copy(str_ind);
	return 0;
}
#endif