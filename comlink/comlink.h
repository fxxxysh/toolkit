#pragma once

#define DLL_EXPORTS

#ifdef DLL_EXPORTS
#define DLL_API __declspec(dllexport)
#else
//#define DLL_API __declspec(dllimport)
#define DLL_API extern
#endif

#include "stdint.h"

DLL_API uint8_t comlink_parse(uint8_t *buffer, int buffer_size, uint8_t* msg);

DLL_API uint8_t comlink_encode(uint8_t* msg, const uint8_t *packet, uint8_t compid, uint8_t msg_id, uint8_t length);