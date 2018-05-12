using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev_toolkit.modules
{
    public partial class s_comlink
    {
        static byte MAVLINK_STX_MAVLINK1 = 0xFE;
        static byte MAVLINK_MAX_PAYLOAD_LEN = 255;
        static byte MAVLINK_NUM_CHECKSUM_BYTES = 2;
        static byte MAVLINK_CORE_HEADER_LEN = 9;
        static byte MAVLINK_NUM_HEADER_BYTES = (byte)(MAVLINK_CORE_HEADER_LEN + 1);

        static byte MAVLINK_MSG_ID_HEARTBEAT_LEN  = 9;
        static byte MAVLINK_MSG_ID_HEARTBEAT_MIN_LEN = 9;

        static byte MAVLINK_COMM_NUM_BUFFERS = 16;
        static byte MAVLINK_CORE_HEADER_MAVLINK1_LEN = 5;
        static byte MAVLINK_MSG_ID_HEARTBEAT = 0;

        public class mavlink_heartbeat_t
        {
            public UInt32 custom_mode;
            public byte type; //设备类型
            public byte version; //设备型号
            public byte base_mode;
            public byte system_status;
            public byte comlink_version;
        }


        public class mavlink_message_t
        {
            public byte magic;
            public byte len; //负载长度
            public byte seq; //序列码
            public byte sysid; //系统ID
            public byte compid; //组件ID
            public byte msgid; //消息ID
            public UInt64[] payload64;
            public byte[] ck;  

            mavlink_message_t()
            {
                payload64 = new UInt64[(MAVLINK_MAX_PAYLOAD_LEN + MAVLINK_NUM_CHECKSUM_BYTES + 7) / 8];
                ck = new byte[2];
            }
        }

        public enum mavlink_parse_state_t
        {
            MAVLINK_PARSE_STATE_UNINIT = 0,
            MAVLINK_PARSE_STATE_IDLE,
            MAVLINK_PARSE_STATE_GOT_STX,
            MAVLINK_PARSE_STATE_GOT_LENGTH,
            MAVLINK_PARSE_STATE_GOT_INCOMPAT_FLAGS,
            MAVLINK_PARSE_STATE_GOT_COMPAT_FLAGS,
            MAVLINK_PARSE_STATE_GOT_SEQ,
            MAVLINK_PARSE_STATE_GOT_SYSID,
            MAVLINK_PARSE_STATE_GOT_COMPID,
            MAVLINK_PARSE_STATE_GOT_MSGID1,
            MAVLINK_PARSE_STATE_GOT_MSGID2,
            MAVLINK_PARSE_STATE_GOT_MSGID3,
            MAVLINK_PARSE_STATE_GOT_PAYLOAD,
            MAVLINK_PARSE_STATE_GOT_CRC1,
            MAVLINK_PARSE_STATE_GOT_BAD_CRC1,
            MAVLINK_PARSE_STATE_SIGNATURE_WAIT
        }

        public enum mavlink_channel_t
        {
            MAVLINK_COMM_0,
            MAVLINK_COMM_1,
            MAVLINK_COMM_2,
            MAVLINK_COMM_3
        }

        public struct mavlink_system_t
        {
            public byte sysid;
            public byte compid;

            public mavlink_system_t(byte sysid, byte compid)
            {
                this.sysid = sysid;
                this.compid = compid;
            }
        }

        public class mavlink_status_t
        {
            public byte msg_received;
            public byte buffer_overrun;
            public byte parse_error;
            public mavlink_parse_state_t parse_state;
            public byte packet_idx;
            public byte current_rx_seq;
            public byte current_tx_seq;
            public UInt16 packet_rx_success_count;
            public UInt16 packet_rx_drop_count;
            public byte flags;
            public byte signature_wait;
        }
        mavlink_status_t[] m_mavlink_status = new mavlink_status_t[MAVLINK_COMM_NUM_BUFFERS];
        mavlink_system_t mavlink_system = new mavlink_system_t(12,13);

        mavlink_heartbeat_t packet1;
        public void comlink_msg_test()
        {
            //packet1.custom_mode = 0;
            //packet1.type = 17;
            //packet1.version = 84;
            //packet1.base_mode = 151;
            //packet1.system_status = 218;
            //packet1.comlink_version = 3;

            //message_chan_send(mavlink_channel_t.MAVLINK_COMM_1, 
            //    MAVLINK_MSG_ID_HEARTBEAT,
            //    (byte[])packet1, 
            //MAVLINK_MSG_ID_HEARTBEAT_MIN_LEN, 
            //MAVLINK_MSG_ID_HEARTBEAT_LEN, 
            //0);
        }

        mavlink_status_t mavlink_get_channel_status(byte chan)
        {
            return m_mavlink_status[chan];
        }

        static UInt16 X25_INIT_CRC = 0xffff;
        static void crc_accumulate(byte data, UInt16 crcAccum)
        {
            /*Accumulate one byte of data into the CRC*/
            byte tmp;
            tmp = (byte)(data ^ (byte)(crcAccum & 0xff));
            tmp ^= (byte)(tmp << 4);
            crcAccum = (UInt16)((crcAccum >> 8) ^ (tmp << 8) ^ (tmp << 3) ^ (tmp >> 4));
        }

        static UInt16 crc_calculate(byte[] pBuffer, UInt16 length)
        {
            UInt16 crcTmp = X25_INIT_CRC;
            UInt16 cnt = 0;
 
            while (length-- == 0)
            {
                crc_accumulate(pBuffer[cnt++], crcTmp);
            }
            return crcTmp;
        }

        void message_chan_send(mavlink_channel_t chan, byte msgid,
                    byte[] packet, byte min_length, byte length, byte crc_extra)
        {
            //byte[] buf = new byte[MAVLINK_NUM_HEADER_BYTES];
            List<Byte> buf = new List<byte>();

            mavlink_status_t status = mavlink_get_channel_status((byte)chan);

            byte header_len = MAVLINK_CORE_HEADER_MAVLINK1_LEN;
            UInt16 checksum;

            buf[0] = MAVLINK_STX_MAVLINK1;
            buf[1] = min_length;
            buf[2] = status.current_tx_seq;
            buf[3] = mavlink_system.sysid;
            buf[4] = mavlink_system.compid;
            buf[5] = msgid;

            status.current_tx_seq++;
            checksum = crc_calculate(buf.GetRange(1,5).ToArray(), header_len);
        }
    }
}
