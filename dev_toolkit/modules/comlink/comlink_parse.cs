using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Iocomp.Instrumentation.Plotting;
using System.Runtime.InteropServices;
using dev_toolkit;

namespace dev_toolkit.modules
{
    public partial class s_comlink
    {
        const string dll_path = "../../../Debug/comlink.dll";

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SerialTrans(byte[] buffer, int size);

        [DllImport(dll_path, EntryPoint = "comlink_test", CallingConvention = CallingConvention.Cdecl)]
        public static extern void comlink_test(SerialTrans trans);

        [DllImport(dll_path, EntryPoint = "comlink_parse", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte comlink_parse(ref byte buffer, int buffer_size);

        [DllImport(dll_path, EntryPoint = "comlink_encode", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte comlink_encode(ref message_t msg, ref byte packet, byte compid, byte msg_id, byte length);

        [DllImport(dll_path, EntryPoint = "comlink_get_status", CallingConvention = CallingConvention.Cdecl)]
        public static extern void comlink_get_status(ref parse_status_t m_status);

        [DllImport(dll_path, EntryPoint = "comlink_get_msg", CallingConvention = CallingConvention.Cdecl)]
        public static extern void comlink_get_msg(ref message_t msg, byte number);

        [DllImport(dll_path, EntryPoint = "comlink_add_msgpart", CallingConvention = CallingConvention.Cdecl)]
        public static extern void comlink_add_msgpart(string name, byte type_sign, byte number);

        [DllImport(dll_path, EntryPoint = "comlink_add_msginfo", CallingConvention = CallingConvention.Cdecl)]
        public static extern void comlink_add_msginfo(byte msg_id, string name, int map_ind, byte size, byte number);

        [DllImport(dll_path, EntryPoint = "comlink_msgmap_ind", CallingConvention = CallingConvention.Cdecl)]
        public static extern int comlink_msgmap_ind();

        [DllImport(dll_path, EntryPoint = "comlink_up_msgmap", CallingConvention = CallingConvention.Cdecl)]
        public static extern int comlink_refresh_msgmap(byte cnt);

        [DllImport(dll_path, EntryPoint = "comlink_clear_map", CallingConvention = CallingConvention.Cdecl)]
        public static extern void comlink_clear_map();

        // 帧头
        const int STX = 0xFE;

        // 系统ID
        const int SYS_ID = 10;

        //消息包头长度，不含帧头
        const int HEADER_LEN = 5;

        // 最大载荷长度
        const int MAX_PAYLOAD_LEN = 255;

        // 校验和长度
        const int NUM_CHECKSUM = 2;

        // 单次解析包个数
        const int MAX_MSG_IND = 128;

        // 消息包数据类型
        const byte TYPE_U8 = 1;
        const byte TYPE_I8 = 2;
        const byte TYPE_U16 = 3;
        const byte TYPE_I16 = 4;
        const byte TYPE_U32 = 5;
        const byte TYPE_I32 = 6;
        const byte TYPE_U64 = 7;
        const byte TYPE_I64 = 8;
        const byte TYPE_FLOAT = 9;
        const byte TYPE_DOUBLE = 10;

        static public byte commlink_get_typesize(byte type_sign)
        {
            byte size = 0;
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

        public enum parse_state_t
        {
            PARSE_STATE_UNINIT = 0,
            PARSE_STATE_IDLE,
            PARSE_STATE_GOT_STX,
            PARSE_STATE_GOT_LENGTH,
            PARSE_STATE_GOT_COMPAT_FLAGS,
            PARSE_STATE_GOT_SEQ,
            PARSE_STATE_GOT_SYSID,
            PARSE_STATE_GOT_COMPID,
            PARSE_STATE_GOT_MSGID,
            PARSE_STATE_GOT_PAYLOAD,
            PARSE_STATE_GOT_CRC1,
            PARSE_STATE_GOT_BAD_CRC1
        };

        public enum framing_t
        {
            FRAMING_INCOMPLETE = 0,
            FRAMING_OK = 1,
            FRAMING_BAD_CRC = 2,
            FRAMING_BAD_SIGNATURE = 3
        };

        public struct message_t
        {
            public byte magic; //帧头
            public byte len; //负载长度
            public byte seq; //序列码
                             //uint8_t flags; //标志位
            public byte sysid; //系统ID
            public byte compid; //组件ID
            public byte msgid; //消息ID

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_PAYLOAD_LEN, ArraySubType = UnmanagedType.U1)]
            public byte[] payload;

            UInt16 checksum; //实时校验

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NUM_CHECKSUM, ArraySubType = UnmanagedType.U1)]
            public byte[] ck; //接收校验
        };

        public struct parse_status_t
        {
            public byte msg_received; //包接收标志
            public byte buffer_overrun; // 消息包长度溢出
            public byte parse_error; //解析失败计数
            public parse_state_t parse_state; //当前解析状态
            public byte packet_idx; // 当前包接收计数
            public byte current_rx_seq; //接收消息包序列码
            public byte current_tx_seq; //发送消息包序列码
        };

        public class MsgInfo
        {
            public string _name;
            public byte _msg_id;
            public int _map_ind;
            public int _size;
            public int _number;
            public part_t[] _part;
            int _part_ind = 0;

            public struct part_t
            {
                public string part_name;
                public byte part_type;
                public byte part_number;
            }

            public MsgInfo(int number)
            {
                _number = number;
                _part = new part_t[number];
            }

            public void info(string name, byte msg_id, int map_ind, int size)
            {
                _name = name;
                _msg_id = msg_id;
                _map_ind = map_ind;
                _size = size;
            }

            public void add_part(string part_name, byte part_type, byte part_number)
            {
                _part[_part_ind].part_name = part_name;
                _part[_part_ind].part_type = part_type;
                _part[_part_ind].part_number = part_number;
                _part_ind++;
            }
        };

        public static byte[] struct_to_byte<T>(T structure)
        {
            int size = Marshal.SizeOf(typeof(T));
            byte[] buffer = new byte[size];
            IntPtr bufferIntPtr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.StructureToPtr(structure, bufferIntPtr, true);
                Marshal.Copy(bufferIntPtr, buffer, 0, size);
            }
            finally
            {
                Marshal.FreeHGlobal(bufferIntPtr);
            }
            return buffer;
        }

        public static T byte_to_struct<T>(byte[] dataBuffer)
        {
            object structure = null;
            int size = Marshal.SizeOf(typeof(T));
            IntPtr allocIntPtr = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(dataBuffer, 0, allocIntPtr, size);
                structure = Marshal.PtrToStructure(allocIntPtr, typeof(T));
            }
            finally
            {
                Marshal.FreeHGlobal(allocIntPtr);
            }
            return (T)structure;
        }
    }
}
