// comlink_simulator.cpp: 定义控制台应用程序的入口点。
//

#define COMLINKL_DEBUG

#include "stdafx.h"
#include "stdint.h"

bool comlink_parse(uint8_t *buffer, int buffer_size);

bool comlink_get_msg(uint8_t* msg_number, uint8_t* now_msg,
	uint16_t* len, uint8_t* payload, uint8_t* seq, uint8_t* sysid, uint8_t* compid, uint8_t* msgid);


int main()
{
	uint8_t test_cache[100];
	for (int i = 0; i < 100; i++)
	{
		test_cache[i] = i;
	}

	comlink_parse(test_cache, 100);
	while (1);
}

