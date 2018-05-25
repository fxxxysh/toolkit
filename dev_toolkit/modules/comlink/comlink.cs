using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Iocomp.Instrumentation.Plotting;
using System.Runtime.InteropServices;
using dev_toolkit;
using System.Windows.Forms;

namespace dev_toolkit.modules
{
    public partial class s_comlink
    {
        public comlink_connect_t comlink_connect = new comlink_connect_t();
        //public message_t[] rx_msg = new message_t[MAX_MSG_IND];
        message_t rx_msg_buffer = new message_t();

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
            private bool _connect = false;

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
            public Dictionary<string, MsgInfo> _msg_infomap;

            // 消息信息表偏移
            //public int _msg_infomap_ind = 0;

            // 消息信息表数量
            public byte _msg_infomap_number = 0;

            // 传输事件
            public event Action<byte[], int> Trans;

            // 更新版本信息
            public event Action<string, string> refreshVersion;

            // 更新ID信息
            public event Action<string, string> refreshDevid;

            // 更新消息
            public event Action<string, string[]> refreshMsglist;
            
            // 清除消息
            public event Action clearMsglist;

            public bool _link_status
            {
                get { return _connect; }
                set { _connect = value; }
            }

            public comlink_connect_t()
            {
                _msg_infomap = new Dictionary<string, MsgInfo>();
            }

            /// <summary>
            /// pkg发送函数
            /// </summary>
            /// <param name="msg"></param>
            /// <param name="structure"></param>
            /// <returns></returns>
            public void pkg_trans<T>(ref message_t msg, T structure, byte slave_id, byte msg_id)
            {
                byte[] pkg = struct_to_byte<T>(structure);
                byte pkg_length = (byte)Marshal.SizeOf(typeof(T));
                int msg_length = pkg_length + 8;

                // 封包
                comlink_encode(ref msg, ref pkg[0], slave_id, msg_id, pkg_length);
                byte[] send_buffer = struct_to_byte<message_t>(msg);

                Trans(send_buffer, msg_length);
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
                string msg_name = str_array[0].Split(':')[0];
                byte msg_id = Convert.ToByte(str_array[0].Split(':')[1]);

                // 上一个消息偏移
                int msg_ind = comlink_msgmap_ind();

                // 消息字节大小
                byte msg_size = 0;

                // 消息成员数量，初始
                int part_number = str_part.Length;

                // 获取消息包的成员数量，包含数组
                foreach (string str_now in str_part)
                {
                    string[] part = str_now.Split(':');
                    string part_name = part[0];
                    int str_size = part[1].Length;

                    if (str_size > 1)
                    {
                        part_number += (Convert.ToByte(part[1].Substring(1)) - 1);
                    }
                }

                MsgInfo msg_info = new MsgInfo(part_number);

                foreach (string str_now in str_part)
                {
                    string[] part = str_now.Split(':');
                    string part_name = part[0];
                    int str_size = part[1].Length;
                    byte part_type = Convert.ToByte(part[1].Substring(0, 1));
                    byte part_number1 = 1;

                    string name = part_name;
                    if (str_size > 1)
                    {
                        part_number1 = Convert.ToByte(part[1].Substring(1));
                        name = part_name + ":" + 1.ToString();
                    }
                    
                    for (int i = 0; i < part_number1; i++)
                    {                     
                        if (i > 0)
                        {
                            name = part_name + ":" + (i + 1).ToString();
                        }                  

                        // 消息成员信息
                        msg_info.add_part(name, part_type);

                        // 添加消息成员到comlink 消息表
                        comlink_add_msgpart(name, part_type);
                    }

                    msg_size += (byte)(part_number1 * commlink_get_typesize(part_type));
                }

                // 消息信息
                msg_info.info(msg_name, msg_id, msg_ind, msg_size);

                // 添加信息表到本地,键值为消息名
                _msg_infomap.Add(msg_name, msg_info);

                // 添加消息信息到comlink 信息表,键值为消息id
                comlink_add_msginfo(msg_id, msg_name, msg_ind, msg_size, (byte)part_number);

                // 更新消息表
                string[] msg_list = new string[part_number];

                for (int i = 0; i < part_number; i++)
                {
                    msg_list[i] = msg_info._part[i].part_name;
                }

                refreshMsglist(msg_name, msg_list);
            }

            /// <summary>
            /// 解析系统版本号相关信息 string msg = "verion_1.01,version1.02";
            /// </summary>
            /// <param name="version"></param>
            /// <returns></returns>
            public void decode_msg_version(string version)
            {
                _software_version = version.Split(',')[0];
                _hardware_version = version.Split(',')[1];

                // 更新版本信息
                refreshVersion(_software_version, _hardware_version);
            }

            bool last_connect = false; // 上一次连接状态
            byte connect_sign = 0; // 连接标识          
            public UInt64 last_timestamp = 0; // 上一次时间戳
            public UInt64 last_connect_timestamp = 0; // 上一次时间戳

            public void pkg_trans_select(byte flag, byte msg_id, byte trans_cnt)
            {
                message_t msg = new message_t();
                msg_control_s control = new msg_control_s();

                control.ctl_msg_trans.flag = 1;
                control.ctl_msg_trans.id = msg_id;
                control.ctl_msg_trans.trans_cnt = trans_cnt;

                pkg_trans(ref msg, control, _slave_id, MSG_ID_CONTROL);
            }

            // 连接后读取设备信息
            public void connect_step(UInt64 timestamp)
            {
                // 首次连接
                if ((last_connect == false) && (_connect == true))
                {
                    connect_sign = 1;
                }
                last_connect = _connect;
                
                // 获取相关消息包
                if (connect_sign > 0)
                {
                    switch (connect_sign)
                    {
                        // 获取消息包信息
                        case 1:
                            pkg_trans_select(MSG_SIGN_ENABLE, MSG_ID_INFO, MSG_TRANS_ONCE);
                            if (connect_sign == 0)
                            {
                                last_connect_timestamp = timestamp;
                            }
                            connect_sign = 1;
                            break;

                        case 2:
                            pkg_trans_select(MSG_SIGN_DISABLE, MSG_ID_VERSION, MSG_TRANS_ONCE);
                            connect_sign = 3;
                            break;
                    }
                }

                // 已经连接完成
                if (connect_sign == 1)
                {
                    if ((timestamp - last_connect_timestamp) > 1000) {
                        connect_sign = 2;
                    }
                }
            }

            // 循环调用
            public void task(UInt64 timestamp)
            {
                if (_init != true)
                {
                    refreshVersion("v1.0", "v1.0");
                    refreshDevid(SYS_ID.ToString(),"");

                    last_timestamp = timestamp;
                    _init = true;
                }

                if ((timestamp - last_timestamp) > 1000)
                {
                    if (_time_out++ > 1)
                    {
                        _connect = false;
                    }
                    last_timestamp = timestamp;
                }
                connect_step(timestamp);
            }

            // 心跳包处理
            public void heart_beat(message_t msg)
            {
                _time_out = 0;
                _connect = true;

                // 两次连接的id相同则掉过初始化步骤
                if (_slave_id == msg.sysid)
                {
                    last_connect = _connect;
                }
                else if(_slave_id != 0)
                {
                    _connect_init = false; // 重新初始化心跳包
                }

                if (_connect_init != true)
                {
                    msg_heartbeat_s msg_heartbeat = byte_to_struct<msg_heartbeat_s>(msg.payload);

                    heartbeat_info.type = msg_heartbeat.type;
                    heartbeat_info.flag = msg_heartbeat.flag;
                    heartbeat_info.system_status = msg_heartbeat.system_status;
                    heartbeat_info.comlink_version = msg_heartbeat.comlink_version;
                    _slave_id = msg.sysid;

                    refreshDevid(SYS_ID.ToString(), _slave_id.ToString());
                    _connect_init = true;
                }
            }
        }
 
        /// <summary>
        /// 解析特殊消息包
        /// </summary>
        /// <param name="msg_cnt"></param>
        /// <returns></returns>
        public void decode_special_msg(ref message_t msg)
        {
            switch (msg.msgid)
            {
                case MSG_ID_HEARTBEAT:
                    comlink_connect.heart_beat(msg);
                    break;

                case MSG_ID_ACK:
                    break;

                case MSG_ID_INFO:
                    byte[] info_str = new byte[msg.len];
                    Array.Copy(msg.payload, info_str, msg.len);

                    string info = System.Text.Encoding.Default.GetString(info_str);
                    comlink_connect._msg_infomap_number ++;
                    //info = info.Substring(2);
                    comlink_connect.decode_msg_info(info);
                    break;

                case MSG_ID_VERSION:
                    byte[] version_str = new byte[msg.len];
                    Array.Copy(msg.payload, version_str, msg.len);

                    string version = System.Text.Encoding.Default.GetString(version_str);
                    comlink_connect.decode_msg_version(version);
                    break;
            }
        }

        /// <summary>
        /// 固定消息拆包
        /// </summary>
        /// <param name="msg_cnt"></param>
        /// <returns></returns>
        public void pkg_decode(byte msg_cnt)
        {    
            for (byte i = 0; i < msg_cnt; i++)
            {         
                // 小于MSG_ID_FIX_CNT保留尾部数据
                comlink_get_msg(ref rx_msg_buffer);

                // fifo拆包
                decode_special_msg(ref rx_msg_buffer);             
            }
        }

        public void comlink_task(UInt64 timestamp)
        {
            comlink_connect.task(timestamp);
        }

        public void clear_map()
        {
            comlink_clear_map();
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
