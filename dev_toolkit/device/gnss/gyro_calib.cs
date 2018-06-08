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

        private bool info_sign = false;
        private bool strt_sign = false;

        // 发送指令
        public event Func<msg_control_s, bool> trans_command;

        public void info(string str)
        {
            if (info_sign == true)
            {
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
                            case "START":
                                strt_sign = true;
                                info_label.Text = "";
                                break;

                            case "END":
                                info_sign = false;
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
                                }
                                break;

                            case "PROGRESS":
                                progress.EditValue = int.Parse(str_list[1].Replace(" ", "")); //去除空格
                                break;
                            default: break;
                        }
                    }
                }));
            }
        }

        private void gyro_calib_Click(object sender, EventArgs e)
        {
            if (info_sign == false)
            {
                SimpleButton button = (SimpleButton)sender;
                msg_control_s control = new msg_control_s();

                control.calib.flag = 1; // 使能
                control.calib.module = 0; // 陀螺
                control.calib.command = (byte)button.TabIndex;

                switch (button.TabIndex)
                {
                    case 0: new_offset_grid(); break;
                    case 1: new_rotate_grid(); break;
                    case 2: break;
                }

                strt_sign = false;
                info_sign = trans_command(control);
                if (info_sign == true)
                {
                    Thread th = new Thread(msg_ack);
                    th.Start();
                }
            }
        }

        public void msg_ack()
        {    
            Thread.Sleep(2000); //500ms内必须有反馈
            info_sign = strt_sign;
            strt_sign = false;
            Thread.CurrentThread.Abort();
        }

        public void new_rotate_grid()
        {
            gyro_offset_dt.Rows.Clear();
            gyro_offset_dt.Rows.Add(new object[] { " " });
            gyro_offset_dt.Rows.Add(new object[] { " " });
            gyro_offset_dt.Rows.Add(new object[] { " " });
        }

        public void new_offset_grid()
        {
            gyro_offset_dt.Rows.Clear();
            gyro_offset_dt.Rows.Add(new object[] { " " });
            gyro_offset_dt.Rows.Add(new object[] { " " });
            gyro_offset_dt.Rows.Add(new object[] { " " });
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

                gridControl.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
                gridControl.Location = new Point(x, y);
                gridControl.MainView = gridView;
                gridControl.Name = "gridControl";
                gridControl.Size = new System.Drawing.Size(width, height);
                gridControl.TabIndex = 0;
                gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView });

                gridView.GridControl = gridControl;
                gridView.Name = "bandedGridView";
                gridView.OptionsView.ShowGroupPanel = false;

                gridView.FixedLineWidth = 100;
                gridView.IndicatorWidth = 100;
                //gridControl.colu fixedWidth 
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
            //int margin = 3;

            //int group_height = 100;
            //int gyoup_width = _hander.Width - margin * 2;

            //int group_loction_x = margin;
            //int group_loction_y = _hander.Height - group_height - margin;

            //// 功能操作
            //GroupControl groupControl = new GroupControl();
            //groupControl.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right);
            //groupControl.Location = new Point(group_loction_x, group_loction_y);
            //groupControl.Name = "gyro_calib_groupControl";
            //groupControl.Size = new Size(gyoup_width, group_height);
            //groupControl.TabIndex = 0;
            //groupControl.Text = "控制";
            //_hander.Controls.Add(groupControl);

            // 功能按钮
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
                _gyrop_ctl.Controls.Add(button);

                switch (i)
                {
                    case 0: button.Text = "零偏校准"; break;
                    case 1: button.Text = "正交校准"; break;
                    case 2: button.Text = "温度校准"; break;
                }
            }

            // 进度条
            progress = new ProgressBarControl();
            progress.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            progress.EditValue = 0;
            progress.Location = new Point(loction_x, _gyrop_ctl.Height - 30);
            progress.Name = "progressBarControl1";
            progress.Size = new Size(_gyrop_ctl.Width - 2 * loction_x, 18);
            _gyrop_ctl.Controls.Add(progress);

            // 信息显示
            info_label = new LabelControl();
            info_label.Location = new Point(loction_x + 40 + button_item * loction_width, loction_y + 5);
            info_label.Name = "label";
            info_label.Size = new Size(63, 14);
            info_label.TabIndex = 0;
            info_label.Text = " ";
            _gyrop_ctl.Controls.Add(info_label);

            int Columns_max = 10;
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

        public gyro_calib(object page, object gyrop_ctl, object gyrop_grid)
        {
            _page = (XtraTabPage)page;
            _gyrop_ctl = (GroupControl)gyrop_ctl;
            _gyrop_grid = (GroupControl)gyrop_grid;

            Initialize();
        }
    }
}
