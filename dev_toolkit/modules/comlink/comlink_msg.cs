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
        // 用于更新消息包信息,不定结构消息包
        const byte MSG_ID_INFO = 5;

        // 心跳包，1hz
        const int MSG_ID_HEARTBEAT = 0;
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct msg_heartbeat_t
        {
            public byte type; // 类型
            public byte flag; // 标志，自定义

            public byte system_status; // 系统状态
            public byte comlink_version; // 协议版本
        };

        const int MSG_ID_ACK = 1;
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct msg_ack_t
        {
            public byte msg_id; //应答消息id
            public byte msg_status; //应答状态
        }
    }
}