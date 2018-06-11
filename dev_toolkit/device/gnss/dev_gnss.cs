using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dev_toolkit.device
{
    public class dev_gnss
    {
        private dev_toolkit _hander;
        public gyro_calib _gyro_calib;
        public gl_flush _gl;

        public dev_gnss()
        {

        }

        public void info(string str)
        {
            _gyro_calib.info(str);
        }

        public void init(object sender)
        {
            _hander = (dev_toolkit)sender;
            _gl = new gl_flush(_hander._openGLControl.OpenGL);

            _gyro_calib = new gyro_calib(
            _hander._gyro_calib_page,
            _hander._gyro_calib_groupControl,
            _hander._gyro_data_groupControl,
            _gl);

            _hander._openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(_gl.OpenGL_Draw);

            // 命令传输
            _gyro_calib.trans_command += _hander._serial.command_trans;
        }
    }
}
