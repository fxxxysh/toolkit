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
        public static void serial_trans(ref message_t msg, int msg_size)
        {
            test_send_buffer = struct_to_byte<message_t>(msg);
            test_send_buffer_size = msg_size;
            //trans(buffer, pkg_size);
        }

        class MSG_TypeBase
        {
            public Dictionary<string, object> Fields;

            public MSG_TypeBase()
            {
                Fields = new Dictionary<string, object>();
            }
        }

        class msg_type
        {
            List<int> _msg;

            public msg_type(string type)
            {
                type = "byte";
                type = "name1:I8[3],nma2:1,name3:2";
            }
        }

        public static byte[] test_send_buffer;
        public static int test_send_buffer_size;

        public static message_t[] rx_msg = new message_t[MAX_MSG_IND];
        public static __attitude_t[] attitude = new __attitude_t[MAX_MSG_IND];


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

        public void test_pkg_decode(byte msg_cnt)
        {
            rx_msg = new message_t[MAX_MSG_IND];
            for (int i = 0; i < msg_cnt; i++)
            {
                // 拆包
                comlink_get_msg(ref rx_msg[i], (byte)i);
                attitude[i] = byte_to_struct<__attitude_t>(rx_msg[i].payload);

                Array.Copy(rx_msg[i].payload, 0, rx_msg[i].payload, 0, 6);

                MSG_TypeBase TEST = new MSG_TypeBase();

                TEST.Fields.Add("1", 12);
                TEST.Fields.Add("2", 23);
                TEST.Fields.Add("3", 45);

                int x1 = (int)TEST.Fields["1"];

                comlink_add_msgpart("1", TYPE_U16, 1);
                comlink_add_msgpart("2", TYPE_U16, 1);
                comlink_add_msgpart("3", TYPE_U16, 1);
                comlink_add_msgpart("4", TYPE_U16, 1);
            }
        }
    }
}
