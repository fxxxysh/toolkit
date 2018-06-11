using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DevExpress.XtraNavBar;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using dev_toolkit;

namespace dev_toolkit
{
    class PageParams
    {
        private NavigationPage _page;
        public DataTable[] _dt_list = new DataTable[50];
        public byte _list_cnt = 0;

        public void creat_grid(string name, DataTable dt)
        {
            _page.Invoke(new Action(() =>
            {
                GridControl gridControl = new GridControl();
                BandedGridView bandedGridView = new BandedGridView();
                GridBand gridBand = new GridBand();

                _dt_list[_list_cnt++] = dt;

                //int grid_width = 240;
                //int grid_height = 200;
                //int idel_width = 20;
                //int idel_height = 20;
                //int row_number = 3;

                int grid_width = 192;
                int grid_height = 270 * 2;
                int idel_width = 5;
                int idel_height = 20;
                int row_number = 4;

                int ind = _list_cnt - 1;
                int loction_x = (grid_width + idel_width) * (ind % row_number) + idel_width;
                int loction_y = (idel_height + grid_height) * (ind / row_number) + idel_height;

                _page.Controls.Add(gridControl);

                gridControl.Anchor = System.Windows.Forms.AnchorStyles.None;// (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top);

                gridControl.Location = new System.Drawing.Point(loction_x, loction_y);
                gridControl.MainView = bandedGridView;
                gridControl.Name = "gridControl";
                gridControl.Size = new System.Drawing.Size(grid_width, grid_height);
                gridControl.TabIndex = 0;
                gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                bandedGridView});

                bandedGridView.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
                gridBand});
                bandedGridView.GridControl = gridControl;
                bandedGridView.Name = "bandedGridView";
                bandedGridView.OptionsView.ShowGroupPanel = false;

                bandedGridView.OptionsView.ShowIndicator = false; //取消小三角形
                bandedGridView.OptionsSelection.EnableAppearanceFocusedCell = false; //去掉选中
                bandedGridView.OptionsSelection.EnableAppearanceFocusedRow = false;
                bandedGridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None; //去掉光标

                gridBand.Caption = name;
                gridBand.Name = "gridBand";
                gridBand.VisibleIndex = 0;

                gridControl.DataSource = dt;

                bandedGridView.Columns[0].MinWidth = 40;
                bandedGridView.Columns[0].OptionsColumn.AllowEdit = false; //禁止修改第一列

                for (int i = 1; i < bandedGridView.Columns.Count; i++)
                {
                    bandedGridView.Columns[i].MinWidth = 110;
                }
            }));
        }          

        void test_grid()
        {
            for (int i = 0; i < 6; i++)
            {
                DataTable dt = new DataTable();

                dt.Columns.Add("ITEM", typeof(string));
                dt.Columns.Add("VALUE", typeof(int));

                dt.Rows.Add(new object[] { "ax", (i + 1) * 1 });
                dt.Rows.Add(new object[] { "bx", (i + 1) * 2 });
                dt.Rows.Add(new object[] { "cx", (i + 1) * 3 });

                creat_grid("params_" + i.ToString(), dt);
            }
        }

        public PageParams(object sender)
        {
            _page = (NavigationPage)sender;

            //test_grid();
        }
    }
}
