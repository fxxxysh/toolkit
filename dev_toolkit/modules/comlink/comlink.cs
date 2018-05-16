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
        public Dictionary<int, MsgInfo> msg_infomap = new Dictionary<int, MsgInfo>();
        int msg_infomap_ind = 0;

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

                    break;
                case MSG_ID_ACK:

                    break;
                case MSG_ID_INFO:

                    string info = System.Text.Encoding.Default.GetString(msg.payload);
                    decode_msg_info(info);
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

                }
                else
                {
                    decode_special_msg(rx_msg[i]);
                }
            }
        }

        public void find_device()
        {

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
