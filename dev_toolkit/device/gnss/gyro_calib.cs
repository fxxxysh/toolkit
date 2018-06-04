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
using System.Threading.Tasks;
using System.Windows.Forms;
using static dev_toolkit.modules.s_comlink;

namespace dev_toolkit.device
{
    public class gyro_calib
    {
        private XtraTabPage _page;
        private GroupControl _gyrop;

        private GridControl gridControl;
        private DataTable _gyro_offset_dt;

        LabelControl info_label;
        private bool info_sign = false;

        // 发送指令
        public event Action<msg_control_s> trans_command;

        public void info(string str)
        {
            if (info_sign == true)
            {
                _page.Invoke(new Action(() =>
                {
                    info_label.Text = str;
                }));
            }
        }

        private void gyro_calib_Click(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;
            msg_control_s control = new msg_control_s();

            control.calib.flag = 1; // 使能
            control.calib.module = 0; // 陀螺
            control.calib.command = (byte)button.TabIndex;
            info_sign = true;

            switch (button.TabIndex)
            {
                case 0: new_offset_grid(); break;
                case 1: new_rotate_grid(); break;
                case 2:break;
            }
            trans_command(control);
        }

        public void offset_grid_value(int ind, float x, float y, float z)
        {
            _gyro_offset_dt.Rows[ind][1] = x;
        }

        public void new_rotate_grid()
        {
            _page.Controls.Remove(gridControl);
        }

        public void new_offset_grid()
        {
            int margin = 3;

            // 陀螺零偏补偿表
            int grid_width = _gyrop.Width;
            int grid_height = 80;

            int grid_loction_x = margin;
            int grid_loction_y = _gyrop.Location.Y - grid_height - 5;

            _gyro_offset_dt = new DataTable();
            _gyro_offset_dt.Columns.Add("陀螺零偏", typeof(string));
            _gyro_offset_dt.Columns.Add("X轴", typeof(float));
            _gyro_offset_dt.Columns.Add("Y轴", typeof(float));
            _gyro_offset_dt.Columns.Add("Z轴", typeof(float));

            _gyro_offset_dt.Rows.Add(new object[] { "陀螺1", 1, 2, 4 });
            _gyro_offset_dt.Rows.Add(new object[] { "陀螺2", 1, 2, 4 });
            _gyro_offset_dt.Rows.Add(new object[] { "陀螺3", 1, 2, 4 });
            new_grid("陀螺零偏", _gyro_offset_dt, grid_loction_x, grid_loction_y, grid_width, grid_height);
        }

        public void new_grid(string name, DataTable dt, int x, int y, int width, int height)
        {
            _page.Invoke(new Action(() =>
            {
                gridControl = new GridControl();
                GridView gridView = new GridView();

                _page.Controls.Add(gridControl);

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
                //bandedGridView.OptionsBehavior.Editable = false; //禁止修改表格

                // 去掉焦点选中
                gridView.OptionsView.ShowIndicator = false;
                gridView.OptionsSelection.EnableAppearanceFocusedCell = false;
                gridView.OptionsSelection.EnableAppearanceFocusedRow = false;
                gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;

                gridControl.DataSource = dt;
                gridView.Columns[0].OptionsColumn.AllowEdit = false;
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
                _gyrop.Controls.Add(button);

                switch (i)
                {
                    case 0: button.Text = "零偏校准"; break;
                    case 1: button.Text = "正交校准"; break;
                    case 2: button.Text = "温度校准"; break;
                }
            }

            // 进度条
            ProgressBarControl progress = new ProgressBarControl();
            progress.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            progress.EditValue = 30;
            progress.Location = new Point(loction_x, _gyrop.Height - 30);
            progress.Name = "progressBarControl1";
            progress.Size = new Size(_gyrop.Width - 2 * loction_x, 18);
            _gyrop.Controls.Add(progress);

            // 信息显示
            info_label = new LabelControl();
            info_label.Location = new Point(loction_x + 40 + button_item * loction_width, loction_y + 5);
            info_label.Name = "label";
            info_label.Size = new Size(63, 14);
            info_label.TabIndex = 0;
            info_label.Text = " ";
            _gyrop.Controls.Add(info_label);
        }

        public gyro_calib(object page, object gyrop)
        {
            _page = (XtraTabPage)page;
            _gyrop = (GroupControl)gyrop;

            Initialize();
        }
    }
}
