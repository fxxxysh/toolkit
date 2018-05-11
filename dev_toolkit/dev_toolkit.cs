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

        public NavigationFrame nav_frame
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

        public NavigationPage[] _page_list;

        void add_page()
        {
            // 添加页面
            _page_list = new NavigationPage[4];
            _page_list[0] = nav_wave_page;
            _page_list[1] = nav_data_page;
            _page_list[2] = nav_params_page;
            _page_list[3] = nav_control_page;
        }

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
            while (this.IsHandleCreated != true)
            {
                Thread.Sleep(10);
            }

            add_page();

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
}