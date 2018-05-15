#pragma once

#include "stdint.h"
#include <string>
#include <map>
#include <unordered_map>

using namespace std;

#define TYPE_U8 1
#define TYPE_I8 2
#define TYPE_U16 3
#define TYPE_I16 4
#define TYPE_U32 5
#define TYPE_I32 6
#define TYPE_U64 7
#define TYPE_I64 8
#define TYPE_FLOAT 9
#define TYPE_DOUBLE 10

typedef union
{
	double _double;
	uint64_t _u64;
	int64_t _i64;

	float _float;
	uint32_t _u32;
	int32_t _i32;

	uint16_t _u16;
	int16_t _i16;

	uint8_t _u8;
	int8_t _i8;

}union_type;


class MsgInfo
{
public:
	string _name;
	int _map_ind;
	int _size;
	int _number;
	bool _init = false;

	void init(string name, int map_ind, uint8_t size, uint8_t number)
	{
		this->_name = name;
		this->_map_ind = map_ind;
		this->_size = size;
		this->_number = number;
		this->_init = true;
	}
};

class TypeBase
{
public:

	string name;
	uint8_t type_sign;
	uint8_t type_size;
	union_type *_type;

	TypeBase(string name, uint8_t type_sign, uint8_t number = 1)
	{
		this->name = name;
		this->type_sign = type_sign;
		this->type_size = get_size() * number;
		_type = new union_type[number];
	}

	uint8_t get_size()
	{
		uint8_t size = 0;
		switch (type_sign)
		{
		case TYPE_U8:
		case TYPE_I8: size = 1; break;

		case TYPE_U16:
		case TYPE_I16: size = 2; break;

		case TYPE_U32:
		case TYPE_I32:
		case TYPE_FLOAT: size = 4; break;

		case TYPE_U64:
		case TYPE_I64:
		case TYPE_DOUBLE: size = 8; break;
		}
		return size;
	}

	// set
	void set(uint8_t data, uint8_t ind = 0) { _type[ind]._u8 = data; }

	void set(int8_t data, uint8_t ind = 0) { _type[ind]._i8 = data; }

	void set(uint16_t data, uint8_t ind = 0) { _type[ind]._u16 = data; }

	void set(int16_t data, uint8_t ind = 0) { _type[ind]._i16 = data; }

	void set(uint32_t data, uint8_t ind = 0) { _type[ind]._u32 = data; }

	void set(int32_t data, uint8_t ind = 0) { _type[ind]._i32 = data; }

	void set(uint64_t data, uint8_t ind = 0) { _type[ind]._u64 = data; }

	void set(int64_t data, uint8_t ind = 0) { _type[ind]._i64 = data; }

	void set(float data, uint8_t ind = 0) { _type[ind]._float = data; }

	void set(double data, uint8_t ind = 0) { _type[ind]._double = data; }

	uint8_t *copy(uint8_t* data)
	{
		memcpy((uint8_t *)_type, data, type_size);;
		return (data + type_size);
	}

	// get
	double get(uint8_t ind = 0)
	{
		double val = 0;
		switch (type_sign)
		{
		case TYPE_U8:val = (double)_type[ind]._u8; break;
		case TYPE_I8:val = (double)_type[ind]._i8; break;
		case TYPE_U16:val = (double)_type[ind]._u16; break;
		case TYPE_I16:val = (double)_type[ind]._i16; break;
		case TYPE_U32:val = (double)_type[ind]._u32; break;
		case TYPE_I32:val = (double)_type[ind]._i32; break;
		case TYPE_U64:val = (double)_type[ind]._u64; break;
		case TYPE_I64:val = (double)_type[ind]._i64; break;
		case TYPE_FLOAT:val = (double)_type[ind]._float; break;
		case TYPE_DOUBLE:val = (double)_type[ind]._double; break;
		}
		return val;
	}
};

#pragma pack(push,1)
typedef struct __mavlink_attitude_t {
	uint32_t time_boot_ms; /*< Timestamp (milliseconds since system boot)*/
	float roll; /*< Roll angle (rad, -pi..+pi)*/
	float pitch; /*< Pitch angle (rad, -pi..+pi)*/
	float yaw; /*< Yaw angle (rad, -pi..+pi)*/
	float rollspeed; /*< Roll angular speed (rad/s)*/
	float pitchspeed; /*< Pitch angular speed (rad/s)*/
	float yawspeed; /*< Yaw angular speed (rad/s)*/
} mavlink_attitude_t;
#pragma pack(pop) 