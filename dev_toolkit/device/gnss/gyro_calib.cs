using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static dev_toolkit.modules.s_comlink;

namespace dev_toolkit.device
{
    public class gyro_calib
    {
        private GroupControl _hander;

        // 发送指令
        public event Action<msg_control_s> trans_command;

        public void info(string str)
        {
            string tt = "234";
        }

        private void gyro_calib_Click(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;
            msg_control_s control = new msg_control_s();

            control.calib.flag = 1; // 使能
            control.calib.module = 0; // 陀螺
            control.calib.command = (byte)button.TabIndex;
            trans_command(control);
        }

        public void Initialize()
        {
            int button_item = 3;
            int loction_x = 10;
            int loction_y = 35;
            int loction_width = 115;

            for (int i = 0; i < button_item; i++)
            {
                SimpleButton button = new SimpleButton();
                button.AllowFocus = false;
                button.Location = new Point(loction_x + i * loction_width, loction_y);
                button.Size = new Size(80, 25);
                button.TabIndex = i;
                button.Click += new System.EventHandler(gyro_calib_Click);
                _hander.Controls.Add(button);

                switch (i)
                {
                    case 0: button.Text = "零偏校准"; break;
                    case 1: button.Text = "正交校准"; break;
                    case 2: button.Text = "温度校准"; break;
                }
            }

            ProgressBarControl progress = new ProgressBarControl();
            progress.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            progress.EditValue = 30;
            progress.Location = new Point(loction_x, _hander.Height - 30);
            progress.Name = "progressBarControl1";
            progress.Size = new Size(_hander.Width - 2 * loction_x, 18);
            _hander.Controls.Add(progress);
        }

        public gyro_calib(object sender)
        {
            _hander = (GroupControl)sender;

            Initialize();
        }
    }
}
