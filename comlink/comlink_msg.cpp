
#ifdef DLL_EXPORTS
#include "comlink_ex.h"
#include <stdio.h>
#else
#include "platforms/platforms.h"
#endif

#include "string.h"
#include "comlink.h"
#include <map>

using namespace std;

class TypeBase
{
public:

	string name;
	uint8_t type_sign = 0;

	TypeBase(string name, uint8_t type_sign)
	{
		this->name = name;
		this->type_sign = type_sign;

		memcpy((uint8_t *)&_type, 0, sizeof(_type));
	}

	union
	{
		uint8_t _u8;
		int8_t _i8;

		uint16_t _u16;
		int16_t _i16;

		uint32_t _u32;
		int32_t _i32;

		uint64_t _u64;
		int64_t _i64;

		float _float;
		double _double;
	}_type;

	// set
	void value(uint8_t data) { _type._u8 = data; }

	void value(int8_t data) { _type._i8 = data; }

	void value(uint16_t data) { _type._u16 = data; }

	void value(int16_t data) { _type._i16 = data; }

	void value(uint32_t data) { _type._u32 = data; }

	void value(int32_t data) { _type._i32 = data; }

	void value(uint64_t data) { _type._u64 = data; }

	void value(int64_t data) { _type._i64 = data; }

	void value(float data) { _type._float = data; }

	void value(double data) { _type._double = data; }

	// get
	double value()
	{
		double val = 0;
		switch (type_sign)
		{
		case 1:val = (double)_type._u8; break;
		case 2:val = (double)_type._i8; break;
		case 3:val = (double)_type._u16; break;
		case 4:val = (double)_type._i16; break;
		case 5:val = (double)_type._u32; break;
		case 6:val = (double)_type._i32; break;
		case 7:val = (double)_type._u64; break;
		case 8:val = (double)_type._i64; break;
		case 9:val = (double)_type._float; break;
		case 10:val = (double)_type._double; break;
		}
		return val;
	}
};

map<int, TypeBase*> msg_map;
map<int, double> msg_val_list;

int plot_list[10];

double test_plot[10];
void msg_list_init()
{
	for (int i = 0; i < 10; i++)
	{
		//string name = 
		plot_list[i] = i;
		msg_map.insert(make_pair(1, new TypeBase("1",1)));
	}

	for(int i = 0;i<10;i++)
	{ 
		test_plot[i] = msg_map[plot_list[i]]->value();
	}
}