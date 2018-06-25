#pragma once

#include "comlink.h"

#ifdef DLL_EXPORTS
#define DLL_API __declspec(dllexport)
#else
//#define DLL_API __declspec(dllimport)
#define DLL_API extern
#endif

#include "stdint.h"
#include <string>

using namespace std;

DLL_API int comlink_parse(uint8_t *buffer, int buffer_size);

DLL_API uint8_t comlink_encode(message_t *msg, const uint8_t *packet, uint8_t compid, uint8_t msg_id, uint8_t length);

DLL_API void comlink_get_status(parse_status_t *m_status);

DLL_API void comlink_get_msg(message_t *msg);

DLL_API void comlink_add_msgpart(char *name, uint8_t type_sign);

DLL_API void comlink_add_msginfo(uint8_t msg_id, char *name, int map_ind, uint8_t size, uint8_t number);

DLL_API int comlink_msgmap_ind();

DLL_API void comlink_refresh_msgmap(message_t *msg);

DLL_API void comlink_clear_map();

DLL_API double comlink_msgpart_value(int msg_ind);

DLL_API int comlink_msgpart_value_cnt(int msg_ind);

DLL_API void comlink_msgpart_value_clear(int msg_ind);

DLL_API void comlink_pop_msg();

DLL_API uint8_t comlink_get_msgid();

DLL_API void comlink_get_msgname(uint8_t msg_id, char *name);