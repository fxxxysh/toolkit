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
    public partial class s_comlink
    {
        [DllImport("../../../Debug/comlink.dll", EntryPoint = "comlink_parse", CallingConvention = CallingConvention.Cdecl)]
        extern static bool comlink_parse(byte[] buffer, int buffer_size);

        [DllImport("../../../Debug/comlink.dll", EntryPoint = "comlink_get_msg", CallingConvention = CallingConvention.Cdecl)]
        extern static bool comlink_get_msg(byte[] msg_number, byte[] now_msg,
            UInt16[] len, byte[] payload, byte[] seq, byte[] sysid, byte[] compid, byte[] msgid);

        public s_comlink()
        {

        }

        public bool parse(byte[] buffer, int size)
        {
            //byte[] buff123 = new byte[10];

            bool m = comlink_parse(buffer, size);

            return true;
        }
    }
}
