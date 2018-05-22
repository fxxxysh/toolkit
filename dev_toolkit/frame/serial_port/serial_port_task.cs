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
        ParseSign parse_sign = new ParseSign();

        byte slave_id = 0;

        public class ParseSign
        {
            public byte msg_cnt = 0;
            public int wave_channel;

            public class plot_s
            {
                public int plot_id = 0;
                public byte msg_id = 0;
                public int plot_x = 0;
            }

            public plot_s[] _plot;

            public void init()
            {
                _plot = new plot_s[wave_channel];
            }
        }

        public void parse_init()
        {
            parse_sign.wave_channel = _hander._wave.channel_max;
            parse_sign.init();
        }

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
                        parse_sign.msg_cnt = link.parse(serial_var.receive_cache, serial_var.receive_byte);
                        serial_var.receive_byte = 0;
                    }
                    //serial_trans(test_send_buffer, test_send_buffer_size); 
                }

                link_connect();
                link.comlink_task((ulong)absolute_time());

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
            while (true)
            {
                for (int i = 0; i < parse_sign.msg_cnt; i++)
                {
                    byte msg_id = link.rx_msg[i].msgid;

                    if (msg_id > s_comlink.MSG_ID_FIX_CNT)
                    {
                        for (int channel = 0; channel < parse_sign.wave_channel; channel++)
                        {
                            if (msg_id == parse_sign._plot[channel].msg_id)
                            {
                                _plot.Channels[channel].AddXY(parse_sign._plot[channel].plot_x++, s_comlink.comlink_msgpart_value(parse_sign._plot[channel].plot_id, 0));
                            }
                        }
                    }
                }
                parse_sign.msg_cnt = 0;

                Thread.Sleep(25);
            }
        }

        public void check_list_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            CheckedListBoxControl check_list = (CheckedListBoxControl)sender;
            int list_index = e.Index;
            byte msg_id = link.comlink_connect._msg_infomap[check_list.Name]._msg_id;

            // 消息句柄
            CheckedListBoxControl[] msg_list = _hander._nav_bar._nav_msg._list;

            // 消息数量
            byte list_cnt = _hander._nav_bar._nav_msg._list_cnt;

            // 读取总通道数
            int item_count = 0;
            for (int i = 0; i < list_cnt; i++)
            {
                // 已使能
                if (msg_list[i].Items[0].CheckState == CheckState.Checked)
                {
                    item_count += (msg_list[i].CheckedItemsCount - 1);
                }
            }

            // 数据通道限制10个
            if (item_count > 10)
            {
                check_list.Items[check_list.HotItemIndex].CheckState = CheckState.Unchecked;
            }

            // 当前通道数量
            int curr_item_count = 0;
            if (check_list.Items[0].CheckState == CheckState.Checked)
            {
                curr_item_count = (check_list.CheckedItemsCount - 1);
            }

            // 选择ALL
            //if (check_list.HotItemIndex == 0)
            //{
            //    int item_cnt = check_list.ItemCount;
            //    for (int j = 0; j < item_cnt; j++)
            //    {
            //        check_list.Items[j].CheckState = e.State;
            //    }
            //}

            // 检测消息表状态
            byte channel_ind = 0;
            for (int i = 0; i < list_cnt; i++)
            {
                // 已使能
                if (msg_list[i].Items[0].CheckState == CheckState.Checked)
                {
                    // 消息条目数
                    int item_cnt = msg_list[i].ItemCount;
                    for (int j = 1; j < item_cnt; j++)
                    {
                        if (msg_list[i].Items[j].CheckState == CheckState.Checked)
                        {
                            // 消息id
                            byte now_msg_id = link.comlink_connect._msg_infomap[msg_list[i].Name]._msg_id;

                            // 消息偏移
                            int now_map_id = link.comlink_connect._msg_infomap[msg_list[i].Name]._map_ind;

                            parse_sign._plot[channel_ind].msg_id = now_msg_id;
                            parse_sign._plot[channel_ind].plot_id = now_map_id + j - 1;
                        }
                    }
                }
            }

            // 检测消息表状态
            for (int i= 0; i < list_cnt; i++)
            {             
                if (check_list.Items[0].CheckState == CheckState.Checked)
                {
                    int item_cnt = msg_list[i].ItemCount;

                }
            }

            // 传输使能控制
            byte trans_sign = s_comlink.MSG_TRANS_OFF;
            if (curr_item_count > 0)
            {
                trans_sign = s_comlink.MSG_TRANS_ON;
            }

            link.comlink_connect.pkg_trans_select(s_comlink.MSG_SIGN_ENABLE, msg_id, trans_sign);
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
        int plot_axis_x = 0;
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
