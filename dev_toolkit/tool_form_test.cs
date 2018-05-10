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
using dev_toolkit.dev;

namespace dev_toolkit
{
    public partial class tool_form_test : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonControl ribbon
        {
            get { return kit_ribbon; }
            set { kit_ribbon = value; }
        }

        public tool_form_test()
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

            DevRibbon _dev_ribbon = new DevRibbon(ribbon);

            Thread.CurrentThread.Abort();
        }

        private void barEditItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
