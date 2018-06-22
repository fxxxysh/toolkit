﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using dev_toolkit.dev;
using dev_toolkit.device;
using dev_toolkit.frame;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraNavBar;
using DevExpress.XtraTab;
using Iocomp.Classes;
using Iocomp.Instrumentation.Plotting;

namespace dev_toolkit
{
    public partial class dev_toolkit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public void Initialize()
        {

        }
        // 防止界面切换闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0014) // 禁掉清除背景消息
                return;
            base.WndProc(ref m);
        }

        // 属性导出
        public Plot _plot
        {
            get { return wave_plot; }
            set { wave_plot = value; }
        }

        public PlotToolBarStandard _plotTool
        {
            get { return plotTool; }
            set { plotTool = value; }
        }

        public PlotToolBarButton _click_start_track
        {
            get { return plotToolBarButton1; }
            set { plotToolBarButton1 = value; }
        }

        public PlotToolBarButton _click_stop_track
        {
            get { return plotToolBarButton2; }
            set { plotToolBarButton2 = value; }
        }

        public PlotToolBarButton _click_cursor
        {
            get { return plotToolBarButton12; }
            set { plotToolBarButton12 = value; }
        }

        public RibbonControl _ribbon
        {
            get { return kit_ribbon; }
            set { kit_ribbon = value; }
        }

        public BarButtonItem _ribbon_hide
        {
            get { return kit_hide; }
            set { kit_hide = value; }
        }

        public NavigationFrame _nav_frame
        {
            get { return kit_nav_frame; }
            set { kit_nav_frame = value; }
        }

        public NavBarControl _nav
        {
            get { return kit_nav_bar; }
            set { kit_nav_bar = value; }
        }

        public NavBarControl _nav_msg
        {
            get { return in_nav_msg; }
            set { in_nav_msg = value; }
        }

        public NavBarControl _nav_params
        {
            get { return in_nav_params; }
            set { in_nav_params = value; }
        }

        public NavigationPage _nav_params_page
        {
            get { return nav_params_page; }
            set { nav_params_page = value; }
        }

        public NavigationPage _nav_data_page
        {
            get { return nav_data_page; }
            set { nav_data_page = value; }
        }

        public bool _connect_status
        {
            get { return connect_status.ShowImageInToolbar; }
            set { connect_status.ShowImageInToolbar = value; }
        }

        public BarStaticItem _connect_bar
        {
            get { return connect_status; }
            set { connect_status = value; }
        }

        // 陀螺校准页面相关
        public XtraTabPage _gyro_calib_page
        {
            get { return xtraTabPage1; }
            set { xtraTabPage1 = value; }
        }

        // 陀螺校准控制组
        public GroupControl _gyro_calib_groupControl
        {
            get { return gyro_calib_groupControl; }
            set { gyro_calib_groupControl = value; }
        }

        // 陀螺校准参数组
        public GroupControl _gyro_data_groupControl
        {
            get { return gyro_data_groupControl; }
            set { gyro_data_groupControl = value; }
        }

        public SharpGL.OpenGLControl _openGLControl
        {
            get { return openGLControl1; }
            set { openGLControl1 = value; }
        }

        // 加计校准页面相关
        public XtraTabPage _acc_calib_page
        {
            get { return xtraTabPage2; }
            set { xtraTabPage2 = value; }
        }

        // 加计校准控制
        public GroupControl _acc_calib_groupControl
        {
            get { return acc_calib_groupControl; }
            set { acc_calib_groupControl = value; }
        }

        // 地磁校准页面相关
        public XtraTabPage _mag_calib_page
        {
            get { return xtraTabPage3; }
            set { xtraTabPage3 = value; }
        }

        // 地磁校准控制
        public GroupControl _mag_calib_groupControl
        {
            get { return mag_calib_groupControl; }
            set { mag_calib_groupControl = value; }
        }

        // 页面切换 
        public Dictionary<string, NavigationPage> _page_list = new Dictionary<string, NavigationPage>();

        // 控件集合
        public ribbom_connect_s _ribbom_connect;
        public serial_connect_s _serial_connect;

        public DevRibbon _dev_ribbon;
        public NavBar _nav_bar;
        public PageMain _page_main;
        public serial_port _serial;
        public wave_form _wave;
        public dev_gnss _dev_gnss = new dev_gnss();

        public dev_toolkit()
        {            
            InitializeComponent();
            //Initialize();

            Thread th_start = new Thread(start)
            { Priority = ThreadPriority.BelowNormal, IsBackground = true };
            th_start.Start();

            Thread th_test = new Thread(idle_task)
            { Priority = ThreadPriority.Lowest, IsBackground = true };
            th_test.Start();
        }

        // 主函数
        public void start()
        {
            // 等待窗口启动完成
            while (this.IsHandleCreated != true)
            {
                Thread.Sleep(10);
            }

            // 添加页面
            _page_list["波形"] = nav_wave_page;
            _page_list["数据"] = nav_data_page;
            _page_list["参数"] = nav_params_page;
            _page_list["控制"] = nav_control_page;

            // 串口操作相关控件
            _serial_connect = new serial_connect_s(
                kit_com_port_edit,
                kit_com_baudrate_edit,
                kit_com_port,
                kit_com_baudrate,
                kit_com_connect,
                kit_com_connect_dis);

            // 初始化ribbon connect
            _ribbom_connect = new ribbom_connect_s(
                _serial_connect,
                kit_sys_id,
                kit_dev_id,
                software_version,
                hardware_version);

            // 菜单栏
            _dev_ribbon = new DevRibbon(this);

            // 导航栏
            _nav_bar = new NavBar(this);

            // navframe
            _page_main = new PageMain(this);

            // 曲线
            _wave = new wave_form(this);

            // 串口操作
            _serial = new serial_port(this);

            _dev_gnss.init(this);

            Thread.CurrentThread.Abort();
        }

        public void refresh_version(string s_ver, string h_ver)
        {
            this.Invoke(new Action(() =>
            {
                this.software_version.EditValue = s_ver;
                this.hardware_version.EditValue = h_ver;
            }));
        }

        public void refresh_devid(string sysid, string comid)
        {
            this.Invoke(new Action(() =>
            {
                this.kit_sys_id.EditValue = sysid;
                this.kit_dev_id.EditValue = comid;
            }));
        }

        public string connect_binding
        {
            get { return this.kit_com_connect_dis.Caption; }
            set { this.kit_com_connect_dis.Caption = value; }
        }

        // 空闲任务
        public void idle_task()
        {
            //Binding binding = new Binding("Caption", this, "connect_binding");
            //this.kit_com_connect.DataBindings.Add(binding);

            while (true)
            {
                Thread.Sleep(4000);
            }
        }
    }

    public class nav_page_s
    {
        public NavigationPage page;
        public NavBarGroup ind;

        public nav_page_s(NavigationPage page, NavBarGroup ind)
        {
            this.page = page;
            this.ind = ind;
        }
    }

    public class serial_connect_s
    {
        public RepositoryItemComboBox com_port_eidt;
        public RepositoryItemComboBox com_baudrate_eidt;

        public BarEditItem com_port;
        public BarEditItem com_baudrate;
        public BarButtonItem com_connect;
        public BarButtonItem com_connect_dis;

        public Image image_start = global::dev_toolkit.Properties.Resources.apply_32x32;
        public Image image_stop = global::dev_toolkit.Properties.Resources.delete_32x32;

        public Image min_image_start = global::dev_toolkit.Properties.Resources.apply_32x32;
        public Image min_image_stop = global::dev_toolkit.Properties.Resources.delete_32x32;

        public serial_connect_s(
            RepositoryItemComboBox com_port_eidt,
            RepositoryItemComboBox com_baudrate_eidt,
            BarEditItem com_port,
            BarEditItem com_baudrate,
            BarButtonItem com_connect,
            BarButtonItem com_connect_dis)
        {
            this.com_port_eidt = com_port_eidt;
            this.com_baudrate_eidt = com_baudrate_eidt;

            this.com_port = com_port;
            this.com_baudrate = com_baudrate;
            this.com_connect = com_connect;
            this.com_connect_dis = com_connect_dis;
        }
    }

    public class test_DataBindings
    {
        public BarButtonItem com_connect;

        public test_DataBindings()
        {
            com_connect = new BarButtonItem();
        }
    }

    public class ribbom_connect_s
    {
        public serial_connect_s serial;

        public BarEditItem sys_id;
        public BarEditItem dev_id;

        public BarEditItem software_version;
        public BarEditItem hardware_version;

        public ribbom_connect_s(
            serial_connect_s serial,
            BarEditItem sys_id,
            BarEditItem dev_id,
            BarEditItem software_version,
            BarEditItem hardware_version)
        {
            this.serial = serial;

            this.sys_id = sys_id;
            this.dev_id = dev_id;

            this.software_version = software_version;
            this.hardware_version = hardware_version;
        }
    }
}