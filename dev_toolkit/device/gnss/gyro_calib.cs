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
    public class gyro_calib
    {
        private XtraTabPage _page;
        private GroupControl _gyrop_ctl;
        private GroupControl _gyrop_grid;

        private GridControl gridControl;
        private DataTable gyro_offset_dt = new DataTable();

        ProgressBarControl progress;
        LabelControl info_label;

        public Dictionary<int, SimpleButton> _button = new Dictionary<int, SimpleButton>();
        public Dictionary<int, SimpleButton> _func_button = new Dictionary<int, SimpleButton>();
        public Dictionary<int, SimpleButton> _rotate_button = new Dictionary<int, SimpleButton>();
        public Dictionary<int, gyro_integral_s> _rotate_buffer = new Dictionary<int, gyro_integral_s>();

        private int start_timeout = 0;
        private int button_index = 0;
        private bool start_sign = false;

        private int dev_orientation = 0;
        private bool[] dev_orientation_sign;

        public gl_flush _gl;

        // 发送指令
        public event Func<msg_control_s, bool> trans_command;

        public struct gyro_integral_s
        {
            public float x;
            public float y;
            public float z;
        }

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
                            //case "START":
                            //    strt_sign = true;
                            //    info_label.Text = "";
                            //    break;

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

                                string str_index = null;
                                foreach (Match match in Regex.Matches(name, @"[0-9]+")) //name index
                                {
                                    str_index = match.Groups[0].Value;
                                }

                                if (str_index != null)
                                {
                                    int index = int.Parse(str_index);
                                    gyro_offset_dt.Rows[index][0] = name; // 添加name

                                    for (int i = 0; i < str_value.Count(); i++)
                                    {
                                        gyro_offset_dt.Rows[index][i + 1] = str_value[i];// float.Parse(str_value[i]); //添加值
                                    }

                                    // 三维显示
                                    if ((index == 0) && (button_index == 1))
                                    {
                                        gyro_integral_s gyro_integral;
                                        gyro_integral.x = float.Parse(str_value[0]);
                                        gyro_integral.y = float.Parse(str_value[1]);
                                        gyro_integral.z = float.Parse(str_value[2]);
                                        _rotate_buffer[dev_orientation] = gyro_integral;

                                        _gl.rotate(gyro_integral.y / 100, -gyro_integral.z / 100, -gyro_integral.x / 100);
                                    }
                                }
                                break;

                            case "CALIB":
                                string calib_name = null;
                                foreach (Match match in Regex.Matches(str, @"(?<=\]).*?(?=\[)"))//提取][内部字符串
                                {
                                    calib_name = match.Groups[0].Value;
                                }
                                string[] val = str_list[1].Replace(" ", "").Split(','); //去除空格,逗号分割
                                gyro_offset_dt.Rows.Add(new object[] { calib_name, val[0], val[1], val[1] });
                                break;

                            case "PROGRESS":
                                progress.EditValue = int.Parse(str_list[1].Replace(" ", "")); //去除空格
                                break;

                            case "ORIENTATION":
                                dev_orientation = int.Parse(str_list[1].Replace(" ", "")); //去除空格

                                if (dev_orientation < 6)
                                {
                                    switch (dev_orientation)
                                    {
                                        case 5:
                                            _rotate_button[1].Enabled = true;
                                            _rotate_button[0].Enabled = false;
                                            _rotate_button[2].Enabled = false;
                                            break;

                                        case 2:
                                            _rotate_button[2].Enabled = true;
                                            _rotate_button[0].Enabled = false;
                                            _rotate_button[1].Enabled = false;
                                            break;

                                        case 0:
                                            _rotate_button[0].Enabled = true;
                                            _rotate_button[1].Enabled = false;
                                            _rotate_button[2].Enabled = false;
                                            break;

                                        default:
                                            _rotate_button[0].Enabled = false;
                                            _rotate_button[1].Enabled = false;
                                            _rotate_button[2].Enabled = false;
                                            break;
                                    }
                                }
                                break;

                            default: break;
                        }
                    }
                }));
            }
        }

        private bool gyro_calib_command(byte command)
        {
            msg_control_s control = new msg_control_s();
            control.calib.flag = 1; // 使能
            control.calib.module = 0; // 陀螺
            control.calib.command = command;
            return trans_command(control);
        }

        private bool gyro_calib_ctl_command(byte command)
        {
            msg_control_s control = new msg_control_s();
            control.calib_ctl.flag = 1; // 使能
            control.calib_ctl.module = 0; // 陀螺
            control.calib_ctl.command = command;
            return trans_command(control);
        }

        // 功能操作
        private void gyro_calib_func_Click(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;

            if (start_sign == false)
            {         
                if (button.TabIndex == 10)
                {
                    start_sign = gyro_calib_command((byte)button.TabIndex);
                    if (start_sign == true)
                    {
                        Thread th = new Thread(gyro_calib_ack1);
                        th.Start();
                    }
                }
            }

            if (button.TabIndex == 9)
            {
                if ((button.Text == "正交测试") && (start_sign))
                {
                    start_sign = gyro_calib_command((byte)button.TabIndex);
                }
                else if (button.Text == "取消测试")
                {
                    start_sign = gyro_calib_ctl_command((byte)2); //退出     
                }
                Thread th = new Thread(gyro_calib_ack2);
                th.Start();
            }
        }

        public void gyro_calib_ack2()
        {
            bool loop = true;

            _page.Invoke(new Action(() =>
            {
                _func_button[9].Text = "取消测试";
            }));

            while (loop)
            {
                if (start_timeout++ > 20)
                {
                    loop = false;
                    start_sign = false;
                    _func_button[9].Text = "正交测试";
                }
                Thread.Sleep(100);
            }
            Thread.CurrentThread.Abort();
        }

        public void gyro_calib_ack1()
        {
            bool loop = true;
            while (loop)
            {
                if (start_timeout++ > 20)
                {
                    loop = false;
                    start_sign = false;
                }
                Thread.Sleep(100);
            }
            Thread.CurrentThread.Abort();
        }

        public void gyro_calib_ack()
        {
            bool loop = true;
            start_timeout = 0;

            //start
            _page.Invoke(new Action(() =>
            {
                _button[button_index].Enabled = false;

                if (button_index == 1)
                {
                    _rotate_button[3].Enabled = true;
                    _rotate_button[3].Text = "取消";
                }
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
                        if (button_index == 1)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                string text = _rotate_button[i].Text.Remove(0, 4);
                                _rotate_button[i].Text = "获取旋转" + text;
                                _rotate_button[i].Enabled = false;
                            }
                            _rotate_button[3].Enabled = false;
                            _rotate_button[3].Text = "取消";
                        }
                        _button[button_index].Enabled = true;
                    }));
                }
                Thread.Sleep(100);
            }
            Thread.CurrentThread.Abort();
        }

        private void gyro_calib_Click(object sender, EventArgs e)
        {
            if (start_sign == false)
            {
                SimpleButton button = (SimpleButton)sender;
                button_index = button.TabIndex;

                new_offset_grid();
                start_sign = gyro_calib_command((byte)button.TabIndex);

                if (start_sign == true)
                {
                    switch (button.TabIndex)
                    {
                        case 0: new_offset_grid(); break;
                        case 1: new_rotate_grid(); break;
                        case 2: break;
                    }

                    Thread th = new Thread(gyro_calib_ack);
                    th.Start();
                }
            }
        }

        private void gyro_func_Click(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;
            string text = button.Text;
            string part = text.Substring(0, 4);

            if (part == "获取旋转")
            {
                if (gyro_calib_ctl_command(0) == true)
                {
                    text = text.Remove(0, 4);
                    _rotate_button[button.TabIndex].Text = "停止获取" + text;
                }
            }
            else
            {
                string rotate_str = "";
                switch (dev_orientation)
                {
                    case 5:
                        rotate_str = "Y+";
                        dev_orientation_sign[5] = true;
                        break;

                    case 2:
                        rotate_str = "Z+";
                        dev_orientation_sign[2] = true;
                        break;

                    case 0:
                        rotate_str = "X+";
                        dev_orientation_sign[0] = true;
                        break;
                }

                if ((dev_orientation_sign[0]) && (dev_orientation_sign[2]) && (dev_orientation_sign[5]))
                {
                    _rotate_button[3].Text = "完成";
                }

                gyro_offset_dt.Rows.Add(new object[] { rotate_str, _rotate_buffer[dev_orientation].x, _rotate_buffer[dev_orientation].y, _rotate_buffer[dev_orientation].z });
                gyro_calib_ctl_command(1);

                text = text.Remove(0, 4);
                _rotate_button[button.TabIndex].Text = "获取旋转" + text;
            }
        }

        private void gyro_func_cancel_Click(object sender, EventArgs e)
        {
            gyro_calib_ctl_command(2);//退出校准
        }

        public void new_rotate_grid()
        {
            gyro_offset_dt.Rows.Clear();

            for (int i = 0; i < 3; i++)
            {
                gyro_offset_dt.Rows.Add(new object[] { " " });
            }

            dev_orientation_sign = new bool[6];
        }

        public void new_offset_grid()
        {
            gyro_offset_dt.Rows.Clear();
            for (int i = 0; i < 3; i++)
            {
                gyro_offset_dt.Rows.Add(new object[] { " " });
            }
        }

        public void new_grid(DataTable dt)
        {
            _page.Invoke(new Action(() =>
            {
                int margin = 1;

                // 陀螺零偏补偿表
                int x = margin;
                int y = 25; // _gyrop_grid.Location.Y - grid_height - 5;

                int width = _gyrop_grid.Width - 2 * margin;
                int height = _gyrop_grid.Height - y;

                gridControl = new GridControl();
                GridView gridView = new GridView();

                _gyrop_grid.Controls.Add(gridControl);

                gridControl.Anchor = (AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
                gridControl.Location = new Point(x, y);
                gridControl.MainView = gridView;
                gridControl.Name = "gridControl";
                gridControl.Size = new System.Drawing.Size(width, height);
                gridControl.TabIndex = 0;
                gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });

                gridView.GridControl = gridControl;
                gridView.Name = "bandedGridView";
                gridView.OptionsView.ShowGroupPanel = false;
                //bandedGridView.OptionsBehavior.Editable = false; //禁止修改表格

                // 去掉焦点选中
                gridView.OptionsView.ShowIndicator = false;
                gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
                gridView.OptionsSelection.EnableAppearanceFocusedRow = false;
                gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;

                gridControl.DataSource = dt;
                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    gridView.Columns[i].MinWidth = 85;
                    gridView.Columns[0].OptionsColumn.AllowEdit = false;
                }
            }));
        }

        public void Initialize()
        {
            // 功能按钮
            int button_item = 2;
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
                    case 0: lable.Text = "零偏校准: "; break;
                    case 1: lable.Text = "正交校准: "; break;
                    case 2: lable.Text = "温度校准: "; break;
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
                button.Click += new System.EventHandler(gyro_calib_Click);
                _gyrop_ctl.Controls.Add(button);
                _button[button.TabIndex] = button;
            }

            // 校准操作
            for (int i = 0; i < 4; i++)
            {
                SimpleButton button = new SimpleButton();
                button.AllowFocus = false;
                button.Location = new Point(10 + loction_x + (loction_width + 30) * (i), loction_y + 10 + 2 * loction_height);
                button.Size = new Size(80, 25);
                button.TabIndex = i;
                button.Enabled = false;

                string rotate_str = "";
                switch (i)
                {
                    case 0: rotate_str = "X+"; break;
                    case 1: rotate_str = "Y+"; break;
                    case 2: rotate_str = "Z+"; break;
                }

                if (i == 3)
                {
                    button.Text = "取消";
                    button.Click += new System.EventHandler(gyro_func_cancel_Click);
                }
                else
                {
                    button.Text = "获取旋转" + rotate_str;
                    button.Click += new System.EventHandler(gyro_func_Click);
                }
                _gyrop_ctl.Controls.Add(button);
                _rotate_button[button.TabIndex] = button;
            }

            // 默认配置
            SimpleButton bt1 = new SimpleButton();
            bt1.AllowFocus = false;
            bt1.Location = new Point(loction_x + _gyrop_ctl.Width - 2 * loction_x - 80, _gyrop_ctl.Height - 30 - 35);
            bt1.Size = new Size(80, 25);
            bt1.TabIndex = 10;
            bt1.Text = "参数初始化";
            bt1.Click += new System.EventHandler(gyro_calib_func_Click);
            _gyrop_ctl.Controls.Add(bt1);
            _func_button[bt1.TabIndex] = bt1;

            // 测试
            SimpleButton bt2 = new SimpleButton();
            bt2.AllowFocus = false;
            bt2.Location = new Point(loction_x + _gyrop_ctl.Width - 2 * loction_x - 160 - loction_x, _gyrop_ctl.Height - 30 - 35);
            bt2.Size = new Size(80, 25);
            bt2.TabIndex = 9;
            bt2.Text = "正交测试";
            bt2.Click += new System.EventHandler(gyro_calib_func_Click);
            _gyrop_ctl.Controls.Add(bt2);
            _func_button[bt2.TabIndex] = bt2;

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

            int Columns_max = 15;
            for (int i = 0; i < Columns_max; i++)
            {
                byte[] ind = { (byte)(65 + i) };
                gyro_offset_dt.Columns.Add(System.Text.Encoding.ASCII.GetString(ind), typeof(string));
            }

            for (int i = 0; i < 3; i++)
            {
                gyro_offset_dt.Rows.Add(new object[] { " " });
            }
            new_grid(gyro_offset_dt);
        }

        public gyro_calib(object page, object gyrop_ctl, object gyrop_grid, object gl)
        {
            _page = (XtraTabPage)page;
            _gyrop_ctl = (GroupControl)gyrop_ctl;
            _gyrop_grid = (GroupControl)gyrop_grid;
            _gl = (gl_flush)gl;

            Initialize();
        }
    }
}
