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
using System.IO.Ports;
using System.Text.RegularExpressions;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Classes;
using dev_toolkit.frame;

namespace dev_toolkit
{
    public partial class tool_form : Form
    {
        public int wave_channel_max = 10;

        public serial_port _serial; //串口
        public wave_form _wave; //波形窗口
        public List<Label> _list;
        //public bool system_free = false;

        public List<Label> _label
        {
            get { return _list; }
        }

        public Plot _plot
        {
            get { return wave_plot; }
            set { wave_plot = value; }
        }

        public PlotToolBarStandard _plotTool
        {
            get { return plotToolBar; }
            set { plotToolBar = value; }
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

        public ToolStripComboBox _com_port
        {
            get { return com_port; }
            set { com_port = value; }
        }

        public ToolStripComboBox _com_baudrate
        {
            get { return com_baudrate; }
            set { com_baudrate = value; }
        }

        public ToolStripButton _com_switch
        {
            get { return com_switch; }
            set { com_switch = value; }
        }

        public static void set_double_cache(Control control)
        {
            control.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance |
            System.Reflection.BindingFlags.NonPublic).SetValue(control, true, null);
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

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == 0x0014) // 禁掉清除背景消息
        //        return;
        //    base.WndProc(ref m);
        //}

        public tool_form()
        {
            InitializeComponent();

            Thread th_start = new Thread(start)
            { Priority = ThreadPriority.BelowNormal, IsBackground = true };
            th_start.Start();
        }

        // 挂载
        private void mount()
        {
            _serial = new serial_port(this);
            _wave = new wave_form(this);

            // test
            //_list = new List<Label>();
            //_list.Add(label1);

            set_double_cache(wave_plot);
            set_double_cache(plotToolBar);
        }

        // 主函数
        public void start()
        {
            while (this.IsHandleCreated != true)
            {
                Thread.Sleep(10);
            }
            mount();
            Thread.CurrentThread.Abort();
        }

        // 窗口关闭
        private void ah_tool_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose(true);
            this.Close();
            Application.Exit();
            //System.Environment.Exit(0);
        }
    }
}
