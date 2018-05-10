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
        public RibbonControl ribbon
        {
            get { return kit_ribbon; }
            set { kit_ribbon = value; }
        }

        public BarButtonItem ribbon_hide
        {
            get { return kit_hide; }
            set { kit_hide = value; }
        }

        public dev_toolkit()
        {
            InitializeComponent();

            Thread th_start = new Thread(start)
            { Priority = ThreadPriority.BelowNormal, IsBackground = true };
            th_start.Start();
        }

        // 主函数
        public void start()
        {
            while (this.IsHandleCreated != true)
            {
                Thread.Sleep(10);
            }

            DevRibbon _dev_ribbon = new DevRibbon(this);

            Thread.CurrentThread.Abort();
        }
    }
}
