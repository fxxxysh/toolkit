#pragma once

#define DLL_EXPORTS

#ifdef DLL_EXPORTS
#define DLL_API __declspec(dllexport)
#else
#define DLL_API __declspec(dllimport)
#endif

#include "stdint.h"

DLL_API bool comlink_parse(uint8_t *buffer, int buffer_size);

DLL_API bool comlink_get_msg(uint8_t* msg_number, uint8_t* now_msg,
	uint16_t* len, uint8_t* payload, uint8_t* seq, uint8_t* sysid, uint8_t* compid, uint8_t* msgid);