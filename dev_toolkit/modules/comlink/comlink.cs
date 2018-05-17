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
        public enum connect_state_t
        {
            CONNECT_STATE_UNINIT = 0,
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

        public class comlink_connect_t
        {
            // 初始化标志
            public bool _init = false;

            // 初始计数
            public int _time_out = 0;

            // 连接状态
            public bool _connect = false;

            // 设备id
            public byte _slave_id = 0;

            // 软件版本
            string _software_version;

            // 硬件版本
            string _hardware_version;

            // 首次心跳包信息
            public msg_heartbeat_s heartbeat_info;

            // 连接初始化状态
            public bool _connect_init = false;

            // 消息信息表
            public Dictionary<int, MsgInfo> _msg_infomap;

            // 消息信息表偏移
            public int _msg_infomap_ind = 0;

            // 消息信息表数量
            public byte _msg_infomap_number = 0;

            // 传输事件
            public event Action<byte[], int> Trans;

            public comlink_connect_t()
            {
                _msg_infomap = new Dictionary<int, MsgInfo>();
            }

            /// <summary>
            /// 解析包信息，并添加到消息表 string msg = "41attitude:11=pitch:9,roll:9,yaw:4,speed:93";
            /// </summary>
            /// <param name="info"></param>
            /// <returns></returns>
            public void decode_msg_info(string info)
            {
                string[] str_array = info.Split('=');
                string[] str_part = str_array[1].Split(',');

                MsgInfo msg_info = new MsgInfo(str_part.Length);

                string msg_name = str_array[0].Split(':')[0];
                byte msg_id = Convert.ToByte(str_array[0].Split(':')[1]);

                int msg_ind = comlink_msgmap_ind();
                byte msg_size = 0;

                foreach (string str_now in str_part)
                {
                    string[] part = str_now.Split(':');
                    string part_name = part[0];
                    int str_size = part[1].Length;
                    byte part_type = Convert.ToByte(part[1].Substring(0, 1));
                    byte part_number;

                    if (str_size > 1)
                    {
                        part_number = Convert.ToByte(part[1].Substring(1));
                    }
                    else
                    {
                        part_number = 1;
                    }

                    msg_size += (byte)(part_number * commlink_get_typesize(part_type));

                    // 消息成员信息
                    msg_info.add_part(part_name, part_type, part_number);

                    // 添加消息成员到comlink 消息表
                    comlink_add_msgpart(part_name, part_type, part_number);
                }

                // 消息信息
                msg_info.info(msg_name, msg_ind, msg_size);

                // 添加信息表到本地
                _msg_infomap.Add(_msg_infomap_ind++, msg_info);

                // 添加消息信息到comlink 信息表
                comlink_add_msginfo(msg_id, msg_name, msg_ind, msg_size, (byte)str_part.Length);
            }

            /// <summary>
            /// 解析系统版本号相关信息 string msg = "verion_1.01,version1.02";
            /// </summary>
            /// <param name="version"></param>
            /// <returns></returns>
            public void decode_msg_version(string version)
            {
                _software_version = version.Split(',')[0];
                _hardware_version = version.Split(':')[1];
            }

            // 上一次连接状态
            bool last_connect = false;
            byte connect_sign = 0;

            public void connect_step()
            {
                // 首次连接
                if ((last_connect == false) && (_connect == true))
                {
                    switch (connect_sign)
                    {
                        case 0:
                            message_t msg = new message_t();
                            msg_control_s control = new msg_control_s();
                            control.ctl_msg_info.flag = 1;

                            byte[] pkg = struct_to_byte<msg_control_s>(control);
                            byte pkg_length = (byte)Marshal.SizeOf(typeof(msg_control_s));
                            int msg_length = pkg_length + 8;

                            // 封包
                            comlink_encode(ref msg, ref pkg[0], _slave_id, MSG_ID_CONTROL, pkg_length);
                            byte[] send_buffer = struct_to_byte<message_t>(msg);

                            Trans(send_buffer, msg_length);                        
                            connect_sign = 1;
                            break;

                        case 1:

                            break;
                    }
                }

                if (_connect == false)
                {
                    connect_sign = 0;
                }
                last_connect = _connect;
            }

            // 上一次时间戳
            public UInt64 last_timestamp = 0;

            // 循环调用
            public void task(UInt64 timestamp)
            {
                if (_init != true)
                {
                    last_timestamp = timestamp;
                    _init = true;
                }

                if ((timestamp - last_timestamp) > 1000)
                {
                    if (_time_out++ > 2)
                    {
                        _connect = false;
                    }
                }

                connect_step();
            }

            // 心跳包处理
            public void heart_beat(message_t msg)
            {           
                if (_connect_init != true)
                {
                    msg_heartbeat_s msg_heartbeat = byte_to_struct<msg_heartbeat_s>(msg.payload);

                    heartbeat_info.type = msg_heartbeat.type;
                    heartbeat_info.flag = msg_heartbeat.flag;
                    heartbeat_info.system_status = msg_heartbeat.system_status;
                    heartbeat_info.comlink_version = msg_heartbeat.comlink_version;
                    _slave_id = msg.sysid;

                    _time_out = 0;
                    _connect = true;
                    _connect_init = true;
                }
                else
                {
                    _time_out = 0;
                }
            }
        }
 
        public comlink_connect_t comlink_connect = new comlink_connect_t();

        /// <summary>
        /// 解析特殊消息包
        /// </summary>
        /// <param name="msg_cnt"></param>
        /// <returns></returns>
        public void decode_special_msg(message_t msg)
        {
            switch (msg.msgid)
            {
                case MSG_ID_HEARTBEAT:
                    comlink_connect.heart_beat(msg);
                    break;

                case MSG_ID_ACK:
                    break;

                case MSG_ID_INFO:
                    string info = System.Text.Encoding.Default.GetString(msg.payload);
                    comlink_connect._msg_infomap_number = msg.payload[0];
                    info = info.Substring(2);
                    comlink_connect.decode_msg_info(info);
                    break;

                case MSG_ID_VERSION:
                    string version = System.Text.Encoding.Default.GetString(msg.payload);
                    comlink_connect.decode_msg_version(version);
                    break;
            }
        }

        /// <summary>
        /// 消息拆包
        /// </summary>
        /// <param name="msg_cnt"></param>
        /// <returns></returns>
        public void pkg_decode(byte msg_cnt)
        {
            rx_msg = new message_t[MAX_MSG_IND];
            for (int i = 0; i < msg_cnt; i++)
            {
                // 拆包
                comlink_get_msg(ref rx_msg[i], (byte)i);

                if (rx_msg[i].msgid > 10)
                {
                    comlink_up_msgmap(msg_cnt);
                }
                else
                {
                    decode_special_msg(rx_msg[i]);
                }
            }
        }

        public void comlink_task(UInt64 timestamp)
        {
            comlink_connect.task(timestamp);
        }

        public byte parse(byte[] buffer, int size)
        {
            byte msg_cnt = comlink_parse(ref buffer[0], size);

            if (msg_cnt > 0)
            {
                pkg_decode(msg_cnt);
            }

            return msg_cnt;
        }
    }
}
