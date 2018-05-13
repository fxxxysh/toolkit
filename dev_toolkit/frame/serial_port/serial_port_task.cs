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
            while (true)
            {
                if (_serialPort.IsOpen && serial_var.receive)
                {
                    //test_add_data();
                    serial_var.receiving = true;
                    bool parse_sign = serial_data_read();
                    serial_var.receiving = false;

                    byte msg_cnt = 0;
                    if (parse_sign)
                    {
                        msg_cnt = parse(serial_var.receive_cache, serial_var.receive_byte);
                        serial_var.receive_byte = 0;
                    }

                    for (int i = 0; i < msg_cnt; i++)
                    {
                        test_add_attitude(attitude[i]);
                    }
                    //serial_trans(test_send_buffer, test_send_buffer_size); 
                }
                Thread.Sleep(25);
            }
        }

        public void port_refresh_task()
        {
            while (true)
            {
                if (_serialPort.IsOpen == false)
                {
                    com_port_DropDown(null, null);
                }
                Thread.Sleep(100);
            }
        }

        public bool serial_data_read()
        {
            serial_var.receive_cache_size = _serialPort.BytesToRead;
            if (serial_var.receive_cache_size != 0)
            {
                _serialPort.Read(serial_var.receive_cache, 0, serial_var.receive_cache_size);
                serial_var.receive_byte += serial_var.receive_cache_size;

                if (serial_var.receive_byte > SERAL_BUFFER_SIZE)
                {
                    serial_var.receive_byte = SERAL_BUFFER_SIZE;
                }
                return true;
            }
            return false;
        }

        // 测试波形
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

        void test_add_attitude(__attitude_t attitude)
        {
            _plot.Channels[0].AddXY(plot_axis_x, attitude.pitch);
            _plot.Channels[1].AddXY(plot_axis_x, 0);
            _plot.Channels[2].AddXY(plot_axis_x, attitude.roll);
            _plot.Channels[3].AddXY(plot_axis_x, 0);
            _plot.Channels[4].AddXY(plot_axis_x, attitude.yaw);
            _plot.Channels[5].AddXY(plot_axis_x, 0);
            _plot.Channels[6].AddXY(plot_axis_x, attitude.time_boot_ms / 1000);
            _plot.Channels[7].AddXY(plot_axis_x, 0);
            _plot.Channels[8].AddXY(plot_axis_x, 0);
            _plot.Channels[9].AddXY(plot_axis_x, 0);
            plot_axis_x++;
        }

        // 串口开关
        //private void com_connect_Click(object sender, EventArgs e)
        private void com_connect_Click(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bool status;
            string port_name = _com_port_val;

            string port = port_name.Split(' ')[0];
            status = operate_port(port, _com_baudrate_val);
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
    }
}
