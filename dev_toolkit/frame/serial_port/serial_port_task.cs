using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraNavBar;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

using dev_toolkit.modules;

namespace dev_toolkit.frame
{
    public partial class serial_port
    {
        s_comlink link = null;

        byte slave_id = 0;

        public int plot_axis_x = 0;
        public byte msg_cnt = 0;

        long time_now = 0;
        long time_error = 0;
        long time_last = 0;

        long time_error2 = 0;

        long time_now1 = 0;
        long time_error1 = 0;
        long time_last1= 0;

        public void link_connect()
        {
            if(((slave_id != 0) && (slave_id != link.comlink_connect._slave_id)) || (link == null))
            {       
                link = new s_comlink();

                link.comlink_connect.Trans += serial_trans;  // 添加串口传输事件
                link.comlink_connect.refreshVersion += _hander.refresh_version;
                link.comlink_connect.refreshDevid += _hander.refresh_devid;

                link.comlink_connect.refreshMsglist += _hander._nav_bar._nav_msg.nav_creat_msg;
                link.comlink_connect.clearMsglist += _hander._nav_bar._nav_msg.nav_clear_msglist;

                link.clear_map();
            }

            slave_id = link.comlink_connect._slave_id;

            // 更新连接状态
            _hander._connect_status = link.comlink_connect._link_status;
        }

        public void parse_task()
        {
            while (true)
            {             
                if (_serialPort.IsOpen && serial_var.receive)
                {
                    //test_add_data();       

                    if (serial_data_read())
                    {
                        time_now = absolute_time();
                        msg_cnt = link.parse(serial_var.receive_cache, serial_var.receive_byte);
                        serial_var.receive_byte = 0;
                        time_error2 = absolute_time() - time_now;
                    }
                    //serial_trans(test_send_buffer, test_send_buffer_size); 
                }
                time_now = absolute_time();
                time_error = time_now - time_last;
                time_last = time_now;

                link_connect();
                link.comlink_task((ulong)time_now);

                Thread.Sleep(30);
            }
        }

        public Dictionary<int, object> Fields;

        int[] name_ind = new int[10];
        public void port_refresh_task()
        {
            Fields = new Dictionary<int, object>();
            for (int i = 0; i < 10; i++)
            {
                name_ind[i] = i;
            }

            Fields.Add(name_ind[0], 100);
            Fields.Add(name_ind[1], -100.12);
            Fields.Add(name_ind[2], -1000);
            Fields.Add(name_ind[3], 1000);
            Fields.Add(name_ind[4], 100);
            Fields.Add(name_ind[5], 200);
            Fields.Add(name_ind[6], 38000);
            Fields.Add(name_ind[7], -100);
            Fields.Add(name_ind[8], -200);
            Fields.Add(name_ind[9], -38000);

            //Array.Copy((Array)(Fields[1]), 0, name_ind, 1, 2);
            //int tt = Convert.ToInt16(Fields[1]);
            //Fields[1] = Convert.ToDouble(Fields[1]) * 100;

            while (true)
            {
                if (_serialPort.IsOpen == false)
                {
                    com_port_DropDown(null, null);
                }
                Thread.Sleep(100);
            }
        }

    
        public void plot_task()
        {
            //__attitude_t _attitude;
            while (true)
            {
                for (int i = 0; i < msg_cnt; i++)
                {
                   // _attitude = attitude[i];

                    //_plot.Channels[0].AddXY(plot_axis_x, _attitude.pitch);
                    //_plot.Channels[1].AddXY(plot_axis_x, 0);
                    //_plot.Channels[2].AddXY(plot_axis_x, _attitude.roll);
                    //_plot.Channels[3].AddXY(plot_axis_x, 0);
                    //_plot.Channels[4].AddXY(plot_axis_x, _attitude.yaw);
                    //_plot.Channels[5].AddXY(plot_axis_x, _attitude.time_boot_ms / 1000);
                    //_plot.Channels[6].AddXY(plot_axis_x, msg_cnt * 10);
                    //_plot.Channels[7].AddXY(plot_axis_x, time_error * 10);
                    //_plot.Channels[8].AddXY(plot_axis_x, time_error1 * 10);
                    //_plot.Channels[9].AddXY(plot_axis_x, time_error2 * 10);

                    _plot.Channels[0].AddXY(plot_axis_x, Convert.ToDouble(Fields[0]));
                    _plot.Channels[1].AddXY(plot_axis_x, Convert.ToDouble(Fields[1]));
                    _plot.Channels[2].AddXY(plot_axis_x, Convert.ToDouble(Fields[2]));
                    _plot.Channels[3].AddXY(plot_axis_x, Convert.ToDouble(Fields[3]));
                    _plot.Channels[4].AddXY(plot_axis_x, Convert.ToDouble(Fields[4]));
                    _plot.Channels[5].AddXY(plot_axis_x, Convert.ToDouble(Fields[5]));
                    _plot.Channels[6].AddXY(plot_axis_x, Convert.ToDouble(Fields[6]));
                    _plot.Channels[7].AddXY(plot_axis_x, Convert.ToDouble(Fields[7]));
                    _plot.Channels[8].AddXY(plot_axis_x, Convert.ToDouble(Fields[8]));
                    _plot.Channels[9].AddXY(plot_axis_x, Convert.ToDouble(Fields[9]));
                    plot_axis_x++;
                }
                msg_cnt = 0;

                time_now1 = DateTime.Now.Ticks / 1000;
                time_error1 = time_now1 - time_last1;
                time_last1 = time_now1;

                Thread.Sleep(25);
            }
        }

        string list_name;
        int list_index;
        public void check_list_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            CheckedListBoxControl check_list = (CheckedListBoxControl)sender;
            list_name = check_list.Name;
            list_index = e.Index;
            byte msg_id = link.comlink_connect._msg_infomap[list_name]._msg_id;

            byte trans_cnt = s_comlink.MSG_TRANS_OFF;

            if (e.State == CheckState.Checked)
            {
                trans_cnt = s_comlink.MSG_TRANS_ON;
            }
            
            link.comlink_connect.pkg_trans_select(s_comlink.MSG_SIGN_ENABLE, msg_id, trans_cnt);
        }

        // 获取绝对时间ms
        public long absolute_time()
        {
           return DateTime.Now.Ticks / 10000; //ms
        }

        // 串口读
        public bool serial_data_read()
        {
            bool status = false;

            serial_var.receiving = true;
            serial_var.receive_cache_size = _serialPort.BytesToRead;
            if (serial_var.receive_cache_size != 0)
            {
                _serialPort.Read(serial_var.receive_cache, 0, serial_var.receive_cache_size);
                serial_var.receive_byte += serial_var.receive_cache_size;

                if (serial_var.receive_byte > SERAL_BUFFER_SIZE)
                {
                    serial_var.receive_byte = SERAL_BUFFER_SIZE;
                }
                status =  true;
            }
            serial_var.receiving = false;

            return status;
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

        async void test_add_attitude(int msg_cnt)
        {
            await Task.Run(() =>
            {

            });               
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
