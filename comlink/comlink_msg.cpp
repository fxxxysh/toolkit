
#include "comlink_ex.h"
#include "comlink.h"

extern int msg_ind;
extern unordered_map<int, TypeBase*> msg_map;
extern unordered_map<string, int> key_map;

// test
int plot_list[10];

double test_plot[10];

#pragma pack(push,1)
struct MyStruct
{
	double _double;
	uint64_t _u64;
	int64_t _i64;

	float _float;
	uint32_t _u32[4];
	int32_t _i32;

	uint16_t _u16;
	int16_t _i16;

	uint8_t _u8;
	int8_t _i8;
};
#pragma pack(pop)

void msg_list_init()
{
	for (int i = 0; i < 10; i++)
	{
		plot_list[i] = i;
	}

	comlink_add_msg("1", TYPE_DOUBLE, 1);
	comlink_add_msg("2", TYPE_U64, 1);
	comlink_add_msg("3", TYPE_I64, 1);
	comlink_add_msg("4", TYPE_FLOAT, 1);
	comlink_add_msg("5", TYPE_U32, 4);
	comlink_add_msg("6", TYPE_I32, 1);
	comlink_add_msg("7", TYPE_U16, 1);
	comlink_add_msg("8", TYPE_I16, 1);
	comlink_add_msg("9", TYPE_U8, 1);
	comlink_add_msg("10", TYPE_I8, 1);

	MyStruct tt;
	tt._double = 123456.789123;
	tt._float = 123456.123;
	tt._i16 = -12345;
	tt._u16 = 12345;
	tt._i32 = -123450;

	tt._u32[0] = 1112345;
	tt._u32[1] = 2212345;
	tt._u32[2] = 3312345;
	tt._u32[3] = 4412345;

	tt._i64 = -123456789;
	tt._u64 = 123456789;
	tt._i8 = -123;
	tt._u8 = 123;
	uint8_t tt_arry[100];
	memcpy(tt_arry, (uint8_t *)&tt, sizeof(MyStruct));

	uint8_t *str_ind = tt_arry;
	for (int i = 0; i < 10; i++)
	{
		str_ind = msg_map[plot_list[i]]->copy(str_ind);

		test_plot[i] = msg_map[plot_list[i]]->get();
	}

	double tt1 = msg_map[key_map["9"]]->get();
}