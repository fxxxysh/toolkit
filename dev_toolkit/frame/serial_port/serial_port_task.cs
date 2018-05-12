using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace dev_toolkit.frame
{
    public partial class serial_port
    {
        public int plot_axis_x = 0;

        public void parse_task()
        {
            test_add_data();
            while (true)
            {
                if (_serialPort.IsOpen && serial_var.receive)
                {
                    //test_add_data();
                    serial_var.receiving = true;
                    serial_data_read();
                    serial_var.receiving = false;
                    parse(serial_var.receive_cache, serial_var.receive_byte);
                }
                Thread.Sleep(40);
            }
        }

        public void port_refresh_task()
        {
            while (true)
            {
                com_port_DropDown(null, null);
                Thread.Sleep(100);
            }
        }

        public void serial_data_read()
        {
            serial_var.receive_cache_size = _serialPort.BytesToRead;
            if (serial_var.receive_cache_size != 0)
            {
                if (serial_var.receive_cache_size > 4096)
                {
                    serial_var.receive_cache_size = 4096;
                }
                _serialPort.Read(serial_var.receive_cache, 0, serial_var.receive_cache_size);
                serial_var.receive_byte += serial_var.receive_cache_size;
            }
        }

        //测试波形
        int test_cnt = 0;
        void test_add_data()
        {
            test_cnt++;
            for (int x = 0; x < 10; x++)
            {
                _plot.Channels[x].AddXY(plot_axis_x, 100 * Math.Sin((test_cnt % 360) * 6.28 / 360) + x * 100);
            }
            plot_axis_x++;
        }

        // 串口开关
        //private void com_connect_Click(object sender, EventArgs e)
        private void com_connect_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool status;
            string port_name = _com_port_val;

            string port = port_name.Split(' ')[0];
            status = operate_port(_com_port_val, _com_baudrate_val);
            set_serial_status(status);
        }

        // 串口端口列表更新
        private void com_port_DropDown(object sender, EventArgs e)
        {
            string[] device_ports = get_port_list();

            if (device_ports != null)
            {
                _hander.Invoke(new Action(() => { set_serial_port(device_ports); }));
                //set_serial_port(device_ports);
            }
        }

        private void com_port_DropDownClosed(object sender, EventArgs e)
        {
            _lost_focus.Focus();
        }
    }
}
