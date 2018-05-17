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
        // 用于更新消息包信息, string结构
        const byte MSG_ID_INFO = 5;

        //设备版本号 
        const byte MSG_ID_VERSION = 6;

        // 控制基类结构体
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct link_command_s
        {
            public byte flag; // 控制标志，0禁用，1使能

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U1)]
            public byte[] code; // 控制码, 自定义
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

        // 包控制
        const int MSG_ID_CONTROL = 2;
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct msg_control_s
        {
            public link_command_s ctl_msg_trans; // 消息包发送控制 code1:消息id,code2:使能控制
            public link_command_s ctl_msg_info; // 消息包信息反馈
        }

        // 消息包信息
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct msg_info_s
        {
            public byte msg_number; // 消息数量
            public byte msg_ind; // 当前消息序列号

            // 消息包信息
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255, ArraySubType = UnmanagedType.U1)]
            public byte[] info;
        }
    }
}