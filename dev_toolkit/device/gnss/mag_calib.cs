using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static dev_toolkit.modules.s_comlink;

namespace dev_toolkit.device
{
    public class mag_calib
    {
        private XtraTabPage _page;
        private GroupControl _gyrop_ctl;

        ProgressBarControl progress;
        LabelControl info_label;
        LabelControl calib_label;

        public struct mag_func_s
        {
            public SimpleButton button;
            public ProgressBarControl progress;
        }

        public Dictionary<int, SimpleButton> _button = new Dictionary<int, SimpleButton>();
        public Dictionary<int, mag_func_s> _rotate_button = new Dictionary<int, mag_func_s>();

        private int start_timeout = 0;
        private bool start_sign = false;

        private int orientation = 0;
        private bool[] orientation_sign;

        // 发送指令
        public event Func<msg_control_s, bool> trans_command;

        public void info(string str)
        {
            if (start_sign == true)
            {
                start_timeout = 0;
                _page.Invoke(new Action(() =>
                {
                    List<string> str_list = new List<string>();
                    string pattern = @"(?<=\[).*?(?=\])"; //提取[]内部字符串

                    foreach (Match match in Regex.Matches(str, pattern))
                    {
                        str_list.Add(match.Value);
                    }

                    if (str_list.Count != 0)
                    {
                        switch (str_list[0])
                        {
                            case "END":
                                start_timeout = 50; //退出
                                break;

                            case "INFO":
                                info_label.Text = str.Split(']')[1];
                                break;

                            case "VALUE":
                                string name = null;
                                foreach (Match match in Regex.Matches(str, @"(?<=\]).*?(?=\[)"))//提取][内部字符串
                                {
                                    name = match.Groups[0].Value;
                                }
                                string[] str_value = str_list[1].Replace(" ", "").Split(','); //去除空格,逗号分割

                                //string str_index = null;
                                //foreach (Match match in Regex.Matches(name, @"[0-9]+")) //name index
                                //{
                                //    str_index = match.Groups[0].Value;
                                //}

                                //if (str_index != null)
                                {
                                    //int index = int.Parse(str_index);
                                    int side_cnt = 0;
                                    orientation_sign[orientation] = true;
                                    for (int i = 0; i < 6; i++)
                                    {
                                        if (orientation_sign[i] == true)
                                        {
                                            if (++side_cnt == 6)
                                            {
                                                _button[0].Text = "完成";
                                            }
                                        }
                                    }

                                   // _rotate_button[dev_orientation].text.Text = str_value[0] + " " + str_value[1] + " " + str_value[2];
                                }
                                break;

                            case "CALIB":
                                calib_label.Text = str.Split(']')[1];
                                break;

                            case "PROGRESS":
                                progress.EditValue = int.Parse(str_list[1].Replace(" ", "")); //去除空格
                                break;

                            case "PROGRESS1":
                                _rotate_button[orientation].progress.EditValue = int.Parse(str_list[1].Replace(" ", "")); //去除空格
                                break;

                            case "ORIENTATION":
                                orientation = int.Parse(str_list[1].Replace(" ", "")); //去除空格
                                if (orientation < 6)
                                {
                                    for (int i = 0; i < 6; i++)
                                    {
                                        if (i == orientation)
                                        {
                                            _rotate_button[i].button.Enabled = true;
                                        }
                                        else
                                        {
                                            _rotate_button[i].button.Enabled = false;
                                        }
                                    }
                                }
                                break;

                            default: break;
                        }
                    }
                }));
            }
        }

        public void mag_calib_ack()
        {
            bool loop = true;
            start_timeout = 0;

            //start
            _page.Invoke(new Action(() =>
            {

            }));

            while (loop)
            {
                if (start_timeout++ > 20)
                {
                    loop = false;
                    start_sign = false;

                    // end
                    _page.Invoke(new Action(() =>
                    {
                        _button[0].Text = "开始";
                    }));
                }
                Thread.Sleep(100);
            }
            Thread.CurrentThread.Abort();
        }

        private bool mag_calib_command(byte command)
        {
            msg_control_s control = new msg_control_s();
            control.calib.flag = 1; // 使能
            control.calib.module = 2; // 地磁
            control.calib.command = command;
            return trans_command(control);
        }

        private bool gyro_calib_ctl_command(byte command)
        {
            msg_control_s control = new msg_control_s();
            control.calib_ctl.flag = 1; // 使能
            control.calib_ctl.module = 2; // 地磁
            control.calib_ctl.command = command;
            return trans_command(control);
        }

        private void mag_calib_Click(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;

            switch (button.Text)
            {
                case "开始":
                    orientation_sign = new bool[6];
                    progress.EditValue = 0;
                    for (int i = 0; i < 6; i++)
                    {
                        //_rotate_button[i].text.Text = "";
                    }

                    start_sign = mag_calib_command((byte)0); //06面校准
                    if (start_sign == true)
                    {
                        button.Text = "取消";
                        Thread th = new Thread(mag_calib_ack);
                        th.Start();
                    }
                    break;

                case "取消":
                    //start_sign = false;
                    button.Text = "开始";
                    gyro_calib_ctl_command((byte)1);
                    break;

                case "完成":
                    //start_sign = false;
                    button.Text = "开始";
                    gyro_calib_ctl_command((byte)1);
                    break;
            }
        }

        private void mag_func_Click(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;
            gyro_calib_ctl_command((byte)0);
        }

        public void Initialize()
        {
            // 功能按钮
            int button_item = 1;
            int loction_x = 10;
            int loction_y = 35;
            int loction_width = 70;
            int loction_height = 28;

            for (int i = 0; i < button_item; i++)
            {
                LabelControl lable = new LabelControl();
                lable.Location = new Point(loction_x, loction_y + i * loction_height + 5);
                lable.Size = new Size(60, 14);
                lable.TabIndex = i;
                _gyrop_ctl.Controls.Add(lable);

                switch (i)
                {
                    case 0: lable.Text = "椭圆校准: "; break;
                }
            }

            for (int i = 0; i < button_item; i++)
            {
                SimpleButton button = new SimpleButton();
                button.AllowFocus = false;
                button.Location = new Point(loction_x + loction_width, loction_y + i * loction_height);
                button.Size = new Size(80, 25);
                button.TabIndex = i;
                button.Text = "开始";
                button.Click += new System.EventHandler(mag_calib_Click);
                _gyrop_ctl.Controls.Add(button);
                _button[button.TabIndex] = button;
            }

            // 校准操作
            for (int i = 0; i < 6; i++)
            {
                progress = new ProgressBarControl();
                progress.EditValue = 0;
                progress.Location = new Point(20 + loction_x + ((loction_width + 15) * 3) * (i % 3), 22 + 2 * loction_height + i / 3 * loction_height);
                progress.Name = "progressBarControl1";
                progress.Size = new Size(130, 18);

                SimpleButton button = new SimpleButton();
                button.AllowFocus = false;
                button.Location = new Point(160 + loction_x + ((loction_width + 15) * 3) * (i % 3), 20 + 2 * loction_height + i / 3 * loction_height);
                button.Size = new Size(80, 25);
                //button.TabIndex = i;
                button.Enabled = false;

                int index = 0;
                string rotate_str = "";
                switch (i)
                {
                    case 0: rotate_str = "X+"; index = 0; break;
                    case 1: rotate_str = "Y+"; index = 2; break;
                    case 2: rotate_str = "Z+"; index = 4; break;
                    case 3: rotate_str = "X-"; index = 1; break;
                    case 4: rotate_str = "Y-"; index = 3; break;
                    case 5: rotate_str = "Z-"; index = 5; break;
                }
                progress.TabIndex = index;
                button.TabIndex = index;

                button.Text = "旋转" + rotate_str;
                //button.Click += new System.EventHandler(mag_func_Click);

                _gyrop_ctl.Controls.Add(progress);
                _gyrop_ctl.Controls.Add(button);

                mag_func_s mag_func = new mag_func_s();
                mag_func.button = button;
                mag_func.progress = progress;
                _rotate_button[button.TabIndex] = mag_func;
            }

            // 进度条
            progress = new ProgressBarControl();
            progress.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            progress.EditValue = 0;
            progress.Location = new Point(loction_x, _gyrop_ctl.Height - 30);
            progress.Name = "progressBarControl1";
            progress.Size = new Size(_gyrop_ctl.Width - 2 * loction_x, 18);
            _gyrop_ctl.Controls.Add(progress);

            // 信息显示
            info_label = new LabelControl();
            info_label.Location = new Point(loction_x + 2, _gyrop_ctl.Height - 50);
            info_label.Name = "label";
            info_label.Size = new Size(63, 14);
            info_label.TabIndex = 0;
            info_label.Text = " ";
            _gyrop_ctl.Controls.Add(info_label);

            // 信息显示
            calib_label = new LabelControl();
            calib_label.Location = new Point(loction_x + 2, _gyrop_ctl.Height - 70);
            calib_label.Name = "label";
            calib_label.Size = new Size(63, 14);
            calib_label.TabIndex = 0;
            calib_label.Text = "";
            _gyrop_ctl.Controls.Add(calib_label);
        }

        public mag_calib(object page, object gyrop_ctl)
        {
            _page = (XtraTabPage)page;
            _gyrop_ctl = (GroupControl)gyrop_ctl;

            Initialize();
        }
    }
}
