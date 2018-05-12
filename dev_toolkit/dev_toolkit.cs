using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using DevExpress.XtraNavBar;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors.Repository;

using dev_toolkit.dev;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Classes;
using dev_toolkit.frame;

namespace dev_toolkit
{
    public partial class dev_toolkit : DevExpress.XtraBars.Ribbon.RibbonForm
    {
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

        // 控件集合
        public nav_page_s[] _page_list;
        public ribbom_connect_s _ribbom_connect;
        public serial_connect_s _serial_connect;

        public dev_toolkit()
        {
            InitializeComponent();

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
            _page_list = new nav_page_s[]
            {
                new nav_page_s(nav_wave_page, nav_wave),
                new nav_page_s(nav_data_page, nav_data),
                new nav_page_s(nav_params_page, nav_params),
                new nav_page_s(nav_control_page, nav_control)
            };

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
            DevRibbon dev_ribbon = new DevRibbon(this);

            // 导航栏
            NavBar nav_bar = new NavBar(this);

            // 串口操作
            serial_port serial = new serial_port(this);

            // 曲线
            wave_form wave = new wave_form(this);

            Thread.CurrentThread.Abort();
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

        public Image image_start = global::dev_toolkit.Properties.Resources.play_32x32;
        public Image image_stop = global::dev_toolkit.Properties.Resources.stop_32x32;

        public Image min_image_start = global::dev_toolkit.Properties.Resources.play_16x16;
        public Image min_image_stop = global::dev_toolkit.Properties.Resources.stop_16x16;

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