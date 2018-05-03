using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Iocomp.Instrumentation.Plotting;
using System.Runtime.InteropServices;
using toolkit;


namespace toolkit.modules
{
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
        PARSE_STATE_GOT_BAD_CRC1,
    };

    public enum framing_t
    {
        FRAMING_INCOMPLETE = 0,
        FRAMING_OK = 1,
        FRAMING_BAD_CRC = 2,
        FRAMING_BAD_SIGNATURE = 3
    };


    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct __attitude_t
    {
        public UInt32 time_boot_ms; /*< Timestamp (milliseconds since system boot)*/
        public float roll; /*< Roll angle (rad, -pi..+pi)*/
        public float pitch; /*< Pitch angle (rad, -pi..+pi)*/
        public float yaw; /*< Yaw angle (rad, -pi..+pi)*/
        public float rollspeed; /*< Roll angular speed (rad/s)*/
        public float pitchspeed; /*< Pitch angular speed (rad/s)*/
        public float yawspeed; /*< Yaw angular speed (rad/s)*/
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

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255, ArraySubType = UnmanagedType.U1)]
        public byte[] payload;

        UInt16 checksum; //实时校验

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U1)]
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

    public static class PtrConver
    {
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

    public partial class s_comlink
    {
        [DllImport("../../../Debug/comlink.dll", EntryPoint = "comlink_parse", CallingConvention = CallingConvention.Cdecl)]
        extern static byte comlink_parse(ref byte buffer, int buffer_size);

        [DllImport("../../../Debug/comlink.dll", EntryPoint = "comlink_encode", CallingConvention = CallingConvention.Cdecl)]
        extern static byte comlink_encode(ref message_t msg, ref byte packet, byte compid, byte msg_id, byte length);

        [DllImport("../../../Debug/comlink.dll", EntryPoint = "comlink_get_status", CallingConvention = CallingConvention.Cdecl)]
        extern static void comlink_get_status(ref parse_status_t m_status);

        [DllImport("../../../Debug/comlink.dll", EntryPoint = "comlink_get_msg", CallingConvention = CallingConvention.Cdecl)]
        extern static void comlink_get_msg(ref message_t msg, byte number);

        [DllImport("../../../Debug/comlink.dll", EntryPoint = "comlink_test", CallingConvention = CallingConvention.Cdecl)]
        extern static ref byte[] comlink_test();

        public void test_parse()
        {
            // 封包
            __attitude_t attitude;
            message_t tx_msg = new message_t();

            attitude.pitch = 89.12f;
            attitude.pitchspeed = 0.12f;
            attitude.roll = 178.23f;
            attitude.rollspeed = 1.21f;
            attitude.time_boot_ms = 12345678;
            attitude.yaw = 272.78f;
            attitude.yawspeed = 2.65f;

            byte pkg_length = (byte)Marshal.SizeOf(typeof(__attitude_t));
            byte[] pkg = PtrConver.struct_to_byte<__attitude_t>(attitude);
            comlink_encode(ref tx_msg, ref pkg[0], 1, 2, pkg_length);

             // 拆包
            __attitude_t attitude1 = PtrConver.byte_to_struct<__attitude_t>(tx_msg.payload);

            // 模拟解析数据
            int msg_number = 10;
            int msg_length = pkg_length + 8;         
            byte[] msg_buffer = new byte[msg_length * msg_number];

            for (int i = 0; i < msg_number; i++)
            {
                tx_msg.compid = (byte)(i + 10);
                byte[] buffer = PtrConver.struct_to_byte<message_t>(tx_msg);
                comlink_encode(ref tx_msg, ref pkg[0], 1, 2, pkg_length);

                Array.Copy(buffer, 0, msg_buffer, i * msg_length, msg_length);
            }

            // 消息和数据包缓存
            message_t[] rx_msg = new message_t[64];
            __attitude_t[] attitude2 = new __attitude_t[64];

            // 解析
            byte msg_cnt = comlink_parse(ref msg_buffer[0], msg_length * msg_number);

            for (int i = 0; i < msg_cnt; i++)
            {
                // 拆包
                comlink_get_msg(ref rx_msg[i], (byte)i);
                attitude2[i] = PtrConver.byte_to_struct<__attitude_t>(rx_msg[i].payload);
            }     
        }

        public bool parse(byte[] buffer, int size)
        {
            test_parse();

            // byte m = comlink_parse(buffer, size, buff123);

            //comlink_test();

            //_comlink->packet_send

            //int msg_length = HEADER_LEN + pkg_length + 3;
            //if (_comlink->parse_char((uint8_t*)&test_trans_msg, msg_length) == FRAMING_OK)
            //{
            //    memcpy(&rx_attitude, _MSG_PAYLOAD(&test_trans_msg), pkg_length);
            //}

            return true;
        }
    }
}
