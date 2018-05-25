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
        // 传输次数
        public const byte MSG_TRANS_OFF = 0;
        public const byte MSG_TRANS_ONCE = 1;
        public const byte MSG_TRANS_ON = 0XFF;

        // 使能标志
        public const byte MSG_SIGN_ENABLE = 1;
        public const byte MSG_SIGN_DISABLE = 0;

        public const byte MSG_ID_FIX_CNT = 20;

        // 用于更新消息包信息, string结构
        const byte MSG_ID_INFO = 10;

        // 设备版本号 
        const byte MSG_ID_VERSION = 11;

        // 参数
        const byte MSG_ID_PARAMS = 12;

        // 控制基类结构体
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct link_command_s
        {
            public byte flag; // 控制标志，0禁用，1使能
            public byte id;

            public byte trans_cnt; //传输次数, OXFF为连续发送
            public byte idle; 
        };

        // 心跳包，1hz
        const int MSG_ID_HEARTBEAT = 0;
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct msg_heartbeat_s
        {
            public byte type; // 类型
            public byte flag; // 标志，自定义

            public byte system_status; // 系统状态
            public byte comlink_version; // 协议版本
        };

        // 应答包
        const int MSG_ID_ACK = 1;
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct msg_ack_s
        {
            public byte msg_id; //应答消息id
            public byte msg_status; //应答状态
        }

        // 控制包
        const int MSG_ID_CONTROL = 2;
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct msg_control_s
        {
            public link_command_s ctl_msg_trans; // 消息包发送控制 code1:消息id, id < 20 则 code2:传输次数 255一直发送
        }
    }
}