#pragma once

#include "comlink.h"

#ifdef DLL_EXPORTS
#define DLL_API __declspec(dllexport)
#else
//#define DLL_API __declspec(dllimport)
#define DLL_API extern
#endif

#include "stdint.h"

DLL_API uint8_t comlink_parse(uint8_t *buffer, int buffer_size);

DLL_API uint8_t comlink_encode(message_t *msg, const uint8_t *packet, uint8_t compid, uint8_t msg_id, uint8_t length);

DLL_API void comlink_get_status(parse_status_t *status);

DLL_API void comlink_get_msg(message_t *msg, uint8_t cnt);

DLL_API void comlink_test(Trans trans);