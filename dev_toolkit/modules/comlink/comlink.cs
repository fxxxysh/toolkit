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
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SerialTrans(byte[] buffer, int size);

        [DllImport("../../../Debug/comlink.dll", EntryPoint = "comlink_parse", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte comlink_parse(ref byte buffer, int buffer_size);

        [DllImport("../../../Debug/comlink.dll", EntryPoint = "comlink_encode", CallingConvention = CallingConvention.Cdecl)]
        public static extern byte comlink_encode(ref message_t msg, ref byte packet, byte compid, byte msg_id, byte length);

        [DllImport("../../../Debug/comlink.dll", EntryPoint = "comlink_get_status", CallingConvention = CallingConvention.Cdecl)]
        public static extern void comlink_get_status(ref parse_status_t m_status);

        [DllImport("../../../Debug/comlink.dll", EntryPoint = "comlink_get_msg", CallingConvention = CallingConvention.Cdecl)]
        public static extern void comlink_get_msg(ref message_t msg, byte number);

        //[DllImport("../../../Debug/comlink.dll", EntryPoint = "comlink_trans", CallingConvention = CallingConvention.Cdecl)]
        //public static extern byte comlink_trans(SerialTrans trans, ref message_t msg, ref byte packet, byte compid, byte msg_id, byte length);

        [DllImport("../../../Debug/comlink.dll", EntryPoint = "comlink_test", CallingConvention = CallingConvention.Cdecl)]
        public static extern void comlink_test(SerialTrans trans);

        const int STX = 0xFE;
        const int SYS_ID = 10;

        const int HEADER_LEN = 5;
        const int MAX_PAYLOAD_LEN = 255;
        const int NUM_CHECKSUM = 2;

        const int MSG_ID_HEARTBEAT = 0;

        const int MAX_MSG_IND = 128;

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

        public static void serial_trans(ref message_t msg, int msg_size)
        {
            test_send_buffer = struct_to_byte<message_t>(msg);
            test_send_buffer_size = msg_size;
            //trans(buffer, pkg_size);
        }

        public static byte[] test_send_buffer;
        public static int test_send_buffer_size;

        public static message_t[] rx_msg = new message_t[MAX_MSG_IND];
        public static __attitude_t[] attitude = new __attitude_t[MAX_MSG_IND];

        public void test_parse()
        {
            // 封包    
            message_t tx_msg = new message_t();
            __attitude_t attitude;

            attitude.pitch = 89.12f;
            attitude.pitchspeed = 0.12f;
            attitude.roll = 178.23f;
            attitude.rollspeed = 1.21f;
            attitude.time_boot_ms = 12345678;
            attitude.yaw = 272.78f;
            attitude.yawspeed = 2.65f;

            byte pkg_length = (byte)Marshal.SizeOf(typeof(__attitude_t));
            int msg_length = pkg_length + 8;

            byte[] pkg = struct_to_byte<__attitude_t>(attitude);
            comlink_encode(ref tx_msg, ref pkg[0], 1, 2, pkg_length);
            serial_trans(ref tx_msg, msg_length);

            // 拆包
            __attitude_t attitude1 = byte_to_struct<__attitude_t>(tx_msg.payload);

            // 模拟解析数据
            int msg_number = 10;      
            byte[] msg_buffer = new byte[msg_length * msg_number];

            for (int i = 0; i < msg_number; i++)
            {
                attitude.pitch = 10 + i;
                byte[] buffer = struct_to_byte<__attitude_t>(attitude);
                comlink_encode(ref tx_msg, ref buffer[0], 1, 2, pkg_length);

                byte[] buffer1 = struct_to_byte<message_t>(tx_msg);
                Array.Copy(buffer1, 0, msg_buffer, i * msg_length, msg_length);
            }

            // 消息和数据包缓存
            message_t[] rx_msg = new message_t[MAX_MSG_IND];
            __attitude_t[] attitude2 = new __attitude_t[MAX_MSG_IND];

            // 解析
            byte msg_cnt = comlink_parse(ref msg_buffer[0], msg_length * msg_number);

            for (int i = 0; i < msg_cnt; i++)
            {
                // 拆包
                comlink_get_msg(ref rx_msg[i], (byte)i);
                attitude2[i] = byte_to_struct<__attitude_t>(rx_msg[i].payload);
            }
        }
        public void pkg_decode(byte msg_cnt)
        {
            rx_msg = new message_t[MAX_MSG_IND];

            for (int i = 0; i < msg_cnt; i++)
            {
                // 拆包
                comlink_get_msg(ref rx_msg[i], (byte)i);
                attitude[i] = byte_to_struct<__attitude_t>(rx_msg[i].payload);

                //switch (rx_msg[i].msgid)
                //   {
                //       case 0:
                //           break;
                //       case 1:
                //           //attitude2[i] = byte_to_struct<__attitude_t>(rx_msg[i].payload);
                //           break;
                //       case 2:
                //           break;
                //       case 3:
                //           break;
                //       case 4:
                //           break;
                //   }
            }
        }

        public byte parse(byte[] buffer, int size)
        {
            //test_parse();
     
            byte msg_cnt = comlink_parse(ref buffer[0], size);

            if (msg_cnt > 0)
            {
                pkg_decode(msg_cnt);
            }

            return msg_cnt;
        }
    }
}
