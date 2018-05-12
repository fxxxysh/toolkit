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
using dev_toolkit.dev;

namespace dev_toolkit
{
    public partial class dev_toolkit1 : DevExpress.XtraBars.Ribbon.RibbonForm
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

        public BarEditItem _soft_ver
        {
            get { return software_version; }
            set { software_version = value; }
        }

        public BarEditItem _hard_ver
        {
            get { return hardware_version; }
            set { hardware_version = value; }
        }

        // 控件集合
        public nav_page_s[] _page_list;
        public ribbom_connect_s ribbom_connect;

        public dev_toolkit1()
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

            //初始化ribbon connect
            ribbom_connect = new ribbom_connect_s(kit_com_port,
                                 kit_com_baudrate,
                                 com_connect,
                                 sys_id,
                                 dev_id,
                                 software_version,
                                 hardware_version);

            DevRibbon dev_ribbon = new DevRibbon(this);
            NavBar nav_bar = new NavBar(this);

            Thread.CurrentThread.Abort();             
        }

        // 空闲任务
        public void idle_task()
        {
            while(true)
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

    public class ribbom_connect_s
    {
        BarEditItem com_port;
        BarEditItem com_baudrate;
        BarButtonItem com_connect;

        BarEditItem sys_id;
        BarEditItem dev_id;

        BarEditItem software_version;
        BarEditItem hardware_version;

        public ribbom_connect_s(BarEditItem com_port,
                                BarEditItem com_baudrate,
                                BarButtonItem com_connect,
                                BarEditItem sys_id,
                                BarEditItem dev_id,
                                BarEditItem software_version,
                                BarEditItem hardware_version)
        {
            this.com_port = com_port;
            this.com_baudrate = com_baudrate;
            this.com_connect = com_connect;

            this.sys_id = sys_id;
            this.dev_id = dev_id;

            this.software_version = software_version;
            this.hardware_version = hardware_version;
        }

        Image image_start = global::dev_toolkit.Properties.Resources.play_32x32;
        Image image_stop = global::dev_toolkit.Properties.Resources.stop_32x32;
    }
}