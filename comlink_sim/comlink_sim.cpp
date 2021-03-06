// comlink_simulator.cpp: 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include "stdint.h"

void comlink_test(void(*trans)(uint8_t*, int));
uint8_t comlink_parse(uint8_t *buffer, int buffer_size, uint8_t* msg);

void SerialTrans(uint8_t* buffer, int buffer_size)
{
	printf("%d  %d", buffer[0], buffer[1]);
}

uint8_t msg_buffer[4096];
int main()
{
	uint8_t test_cache[100];
	for (int i = 0; i < 100; i++)
	{
		test_cache[i] = i;
	}
	comlink_test(SerialTrans);

	//comlink_parse(test_cache, 100, msg_buffer);
	while (1);
}

