using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Classes;
using System.Windows.Forms;

namespace dev_toolkit.frame
{
    public class wave_form
    {
        public dev_toolkit _hander;
        private Plot _plot;
        private int channel_max;

        wave_axes_s axes = new wave_axes_s();
        bool axes_sign = false;
        bool track_sign = false;
        bool plot_active_sign = false;

        struct wave_axes_s
        {
            public double x_min;
            public double y_min;
            public double x_max;
            public double y_max;
            public double x_span;
            public double y_span;

            //public double width;
            //public double height; 
        };

        bool[] legend_sign = new bool[] { true, true, true, true, true, true, true, true, true, true };

        public wave_form(object sender)
        {
            _hander = (dev_toolkit)sender;
            channel_max = 10;

            mode_init();
            event_init();
        }

        void mode_init()
        {
            _plot = _hander._plot;

            Thread th = new Thread(task)
            { Priority = ThreadPriority.AboveNormal, IsBackground = true };
            th.Start();
        }

        void event_init()
        {
            _hander._plotTool.MouseUp += new MouseEventHandler(plotTool_MouseUp);
            _hander._plotTool.ButtonClick += new ToolBarButtonClickEventHandler(plotTool_ButtonClick);
            _hander._plot.MouseEnter += new EventHandler(wave_plot_MouseEnter);
            _hander._plot.MouseLeave += new EventHandler(wave_plot_MouseLeave);
            _hander._plot.Click += new EventHandler(wave_plot_Click);
        }

        public void task()
        {
            int loop = 0;
            Thread.Sleep(1000);

            while (true)
            {
                loop = (loop + 1) % 100;

                if (loop % 5 == 0)
                {
                    get_wave_axes();
                    plot_zoom();
                }

                plot_track();

                //test_set_label();

                Thread.Sleep(20);
            }
        }

        public PlotChannelTrace plot_channels(int channel)
        {
            return (PlotChannelTrace)_plot.Channels[channel];
        }

        // plot 显示type设置
        public void plot_markers(bool state)
        {
            for (int channel = 0; channel < 10; channel++)
            {
                plot_channels(channel).Markers.Visible = state;
            }
        }
       
        void plot_zoom()
        {
            if ((_plot.XAxes[0].Span < 350) || (_plot.YAxes[0].Span < 350))
            {
                plot_markers(true);
            }
            else
            {
                plot_markers(false);
            }
        }

        // 光标跟踪
        void plot_track()
        {
            bool pushed = false;
            try {
                _hander.Invoke(new Action(() => pushed = _hander._click_cursor.Pushed));
            } catch { };

            if ((pushed) && (plot_active_sign))
            {
                int width_l = 50;
                int width_r = 17;

                double width = (_plot.Width - (width_l + width_r)); //L 46, R123

                if (width < 1)
                {
                    width = 1; 
                }

                _hander.Invoke(new Action(() => 
                {
                    _plot.DataCursors.Channels[0].PositionX = (_plot.PointToClient(Control.MousePosition).X - width_l) / width;
                }));
            }
        }

        // test
        void test_set_label() 
        {
            Action<int, String> write = (ind, str) => { _hander._label[ind].Text = str; };
            Action<int, int> lable_lock = (x, y) => { _hander._label[0].Location = new System.Drawing.Point(x, y); };
            string[] lab_str = new string[10];
            
            try
            {
                _hander.Invoke(new Action(() => lab_str[1] = _plot.PointToClient(Control.MousePosition).X.ToString()));
            }
            catch { };

            lab_str[0] = _hander._plot.Channels[0].LegendRectangle.Width.ToString();
            lab_str[2] = _hander._plot.Channels[0].LegendRectangle.Height.ToString();
            lab_str[3] = _hander._click_cursor.Enabled.ToString();
            lab_str[4] = _hander._plot.Channels[0].LegendRectangle.X.ToString();
            lab_str[5] = _hander._plot.Channels[0].LegendRectangle.Y.ToString();
            lab_str[6] = _hander._plot.Width.ToString();
            lab_str[7] = _hander._plot.Height.ToString();

            for (int ind = 0; ind < 8; ind++)
            {
                try
                {
                    _hander.Invoke(write, ind, lab_str[ind]);
                }
                catch { };
            }
        }

        // legend 点击处理
        public void legend_click(int x, int y)
        {
            for (int ch = 0; ch < channel_max; ch++)
            {
                if ((x >= plot_channels(ch).LegendRectangle.X) &&
                    (y >= plot_channels(ch).LegendRectangle.Y) &&
                    (x <= plot_channels(ch).LegendRectangle.X + plot_channels(ch).LegendRectangle.Width) &&
                    (y <= plot_channels(ch).LegendRectangle.Y + plot_channels(ch).LegendRectangle.Height))
                {
                    plot_channels(ch).Trace.Visible = !plot_channels(ch).Trace.Visible;
                    legend_sign[ch] = plot_channels(ch).Trace.Visible;
                    return;
                }
            }
        }

        // 获取缩放轴
        void get_wave_axes()
        {
            if (axes_sign == false)
            {
                axes.x_min = _plot.XAxes[0].Min;
                axes.y_min = _plot.YAxes[0].Min;
                axes.x_max = _plot.XAxes[0].Max;
                axes.y_max = _plot.YAxes[0].Max;
                axes.x_span = _plot.XAxes[0].Span;
                axes.y_span = _plot.YAxes[0].Span;
            }
        }

        // 设置缩放轴
        void set_wave_axes()
        {
            _plot.XAxes[0].Min = axes.x_min;
            _plot.YAxes[0].Min = axes.y_min;
            _plot.XAxes[0].Span = axes.x_span;
            _plot.YAxes[0].Span = axes.y_span;
        }

        private void plotTool_MouseUp(object sender, MouseEventArgs e)
        {
            if (track_sign == true)
            {
                track_sign = false;
                set_wave_axes();
            }
        }

        private void plotTool_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            ToolBarButton button = e.Button;
            if (e.Button == _hander._click_start_track)
            {
                track_sign = true;
            }    
        }
        
        private void wave_plot_MouseEnter(object sender, EventArgs e)
        {
            plot_active_sign = true;
        }

        private void wave_plot_MouseLeave(object sender, EventArgs e)
        {
            plot_active_sign = false;
        }
        
        private void wave_plot_Click(object sender, EventArgs e)
        {
            MouseEventArgs args = (MouseEventArgs)e;

            int height = plot_channels(0).LegendRectangle.Y;
            if (args.Y >= height)
            {
                legend_click(args.X, args.Y);
            }
        }
    }
}
