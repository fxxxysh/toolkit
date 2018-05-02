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
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct __mavlink_attitude_t
    {
        public byte tt;
        public UInt32 time_boot_ms; /*< Timestamp (milliseconds since system boot)*/
        public float roll; /*< Roll angle (rad, -pi..+pi)*/
        public float pitch; /*< Pitch angle (rad, -pi..+pi)*/
        public float yaw; /*< Yaw angle (rad, -pi..+pi)*/
        public float rollspeed; /*< Roll angular speed (rad/s)*/
        public float pitchspeed; /*< Pitch angular speed (rad/s)*/
        public float yawspeed; /*< Yaw angular speed (rad/s)*/
    };

    struct message_t
    {
        public byte magic; //帧头
        public byte len; //负载长度
        public byte seq; //序列码
                         //uint8_t flags; //标志位
        public byte sysid; //系统ID
        public byte compid; //组件ID
        public byte msgid; //消息ID

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 258, ArraySubType = UnmanagedType.U1)]
        public byte[] payload;

        UInt16 checksum; //实时校验

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U1)]
        public byte[] ck; //接收校验
    };

    public partial class s_comlink
    {
        [DllImport("../../../Debug/comlink.dll", EntryPoint = "comlink_parse", CallingConvention = CallingConvention.Cdecl)]
        extern static byte comlink_parse(ref byte buffer, int buffer_size, byte[] msg);

        [DllImport("../../../Debug/comlink.dll", EntryPoint = "comlink_encode", CallingConvention = CallingConvention.Cdecl)]
        extern static byte comlink_encode(ref byte msg, byte[] packet, byte compid, byte msg_id, byte length);

        public s_comlink()
        {

        }

        public bool parse(byte[] buffer, int size)
        {
            byte[] buff123 = new byte[10];

            __mavlink_attitude_t mavlink_attitude;
            message_t[] receive_msg = new message_t[64];

            mavlink_attitude.pitch = 89.12f;
            mavlink_attitude.pitchspeed = 0.12f;
            mavlink_attitude.roll = 178.23f;
            mavlink_attitude.rollspeed = 1.21f;
            mavlink_attitude.time_boot_ms = 12345678;
            mavlink_attitude.yaw = 272.78f;
            mavlink_attitude.yawspeed = 2.65f;

            string arr = "23r";
            //fixed (int* p = arr) ;

                byte pkg_length = (byte)Marshal.SizeOf(typeof(__mavlink_attitude_t));

            Byte[] bPara = new Byte[100];    //新建字节数组 
            comlink_encode(ref bPara[0], (byte[])buff123, 1, 2, pkg_length);

           // byte m = comlink_parse(buffer, size, buff123);

            //comlink_test();

            //_comlink->packet_send

            //int msg_length = HEADER_LEN + pkg_length + 3;
            //if (_comlink->parse_char((uint8_t*)&test_trans_msg, msg_length) == FRAMING_OK)
            //{
            //    memcpy(&rx_mavlink_attitude, _MSG_PAYLOAD(&test_trans_msg), pkg_length);
            //}

            return true;
        }
    }
}
