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

using dev_toolkit.dev;
using dev_toolkit.modules;
using static dev_toolkit.modules.s_comlink;

namespace dev_toolkit.frame
{
    public partial class serial_port
    {
        public s_comlink _link = null;
        public ParseSign _parse_sign = new ParseSign();
        byte last_slave_id = 0;

        public Dictionary<string, ParamsInfo> _params_info
        {
            get { return _hander._nav_bar._params_info; }
            set { _hander._nav_bar._params_info = value; }
        }

        public class ParseSign
        {
            public byte _msg_cnt = 0;
            public int _wave_channel;
            public byte _channel_ind = 0;

            public class plot_s
            {
                public string plot_name = "CH";

                public int plot_id = 0;
                public byte msg_id = 0;
            }

            public int[] _plot_x;
            public double[] _plot_y;

            public plot_s[] _plot;

            public void init()
            {
                _plot = new plot_s[_wave_channel];
                _plot_x = new int[_wave_channel];
                _plot_y = new double[_wave_channel];

                for (int i = 0; i < _wave_channel; i++)
                {
                    _plot[i] = new plot_s();
                }
            }
        }

        // 指令传输
        public bool command_trans(msg_control_s structure)
        {
            return _link.command_trans(structure);
        }

        // 与plot打印相关
        public void parse_init()
        {
            _parse_sign._wave_channel = _hander._wave.channel_max;
            _parse_sign.init();
        }

        // 初始化连接，更新连接状态
        public void link_connect()
        {
            if((_link == null) || ((last_slave_id != _link._slave_id) && (last_slave_id != 0)))
            {
                _link = new s_comlink();

                _link.Trans += serial_trans;  // 添加串口传输事件
                _link.refreshVersion += _hander.refresh_version;
                _link.refreshDevid += _hander.refresh_devid;

                _link.refreshMsgList += _hander._nav_bar.creat_msg;
                _link.refreshParamsList += _hander._nav_bar.creat_params;

                _link.clearMsglist += _hander._nav_bar.clear_msglist;

                _link.refreshParamsTable += params_refresh;

                _link.Cout += _hander._dev_gnss.info;

                _link.clear_map();
            }

            last_slave_id = _link._slave_id;

            // 更新连接状态
            _hander._connect_status = _link._connect;
        }

        // 消息解析主任务
        public void parse_task()
        {       
            while (true)
            {             
                if (_serialPort.IsOpen && serial_var.receive)
                {
                    //test_add_data();       
                    if (serial_data_read())
                    {
                        _parse_sign._msg_cnt = _link.parse(serial_var.receive_cache, serial_var.receive_byte);
                        serial_var.receive_byte = 0;
                        plot_refresh();
                    }
                }

                link_connect();
                _link.task((ulong)absolute_time());

                Thread.Sleep(30);
            }
        }
        
        // 刷新参数表
        public void params_refresh(byte msg_id)
        {
            //if (link._msg_infomap.ContainsKey("pACC"))
            {
                _hander.Invoke(new Action(() =>
                {
                    // 由消息id获取消息名
                    byte[] name = new byte[20];
                    s_comlink.comlink_get_msgname(msg_id, name);

                    string msg_name = System.Text.Encoding.UTF8.GetString(name);
                    msg_name = msg_name.Replace("\0", "");

                    // 消息偏移
                    int now_map_id = _link._msg_infomap[msg_name]._map_ind;

                    // 消息成员个数
                    int part_number = _link._msg_infomap[msg_name]._number;

                    // 获取缓存数据个数
                    int val_number = s_comlink.comlink_msgpart_value_cnt(now_map_id);

                    for (int val_ind = 0; val_ind < val_number; val_ind++)
                    {
                        for (int table_ind = 0; table_ind < part_number; table_ind++)
                        {
                            // 获取消息解析表数据
                            double channel_val = s_comlink.comlink_msgpart_value(now_map_id + table_ind);

                            // 更新表格
                            _params_info[msg_name].set_value(table_ind, (float)channel_val);
                        }
                    }
                }));
            }
        }

        // 刷新波形通道
        public void plot_refresh()
        {
            // 波形输出，遍历通道
            for (int channel = 0; channel < _parse_sign._wave_channel; channel++)
            {
                if (_parse_sign._plot[channel].msg_id >= s_comlink.MSG_ID_FIX_CNT)
                {
                    // 获取缓存数据个数
                    int val_number = s_comlink.comlink_msgpart_value_cnt(_parse_sign._plot[channel].plot_id);
                
                    for (int val_ind = 0; val_ind < val_number; val_ind++)
                    {
                        double channel_val = s_comlink.comlink_msgpart_value(_parse_sign._plot[channel].plot_id);
                        _parse_sign._plot_y[channel] = channel_val;

                        // plot输出
                        _plot.Channels[channel].AddXY(_parse_sign._plot_x[channel]++, channel_val);
                    }
                }
            }
        }

        // plot处理集合
        public void plot_task()
        {
            Thread.Sleep(1000);
            while (true)
            {
                //250ms时间戳 x轴对齐
                int plot_x_max = _parse_sign._plot_x.Max();

                for (int i = 0; i < _parse_sign._channel_ind; i++)
                {
                    // x轴误差超过20个点则进行对齐
                    if ((plot_x_max - _parse_sign._plot_x[i]) > 10)
                    {
                        _parse_sign._plot_x[i] = plot_x_max;
                    }
                }

                if (_parse_sign._channel_ind > 0)
                {
                    for (int i = 0; i < _parse_sign._channel_ind; i++)
                    {
                        int val = Convert.ToInt32(_parse_sign._plot_y[i]);

                        if (_hander._wave.cursor_pushed == false)
                        {
                            _plot.Channels[i].TitleText = _parse_sign._plot[i].plot_name + "  " + val.ToString();
                        }
                    }
                    if (_hander._wave.cursor_pushed == false)
                    {
                        for (int i = _parse_sign._channel_ind; i < _parse_sign._wave_channel; i++)
                        {
                            int val = 0;
                            _plot.Channels[i].TitleText = _parse_sign._plot[i].plot_name + "  " + val.ToString();
                        }
                    }
                }              
                Thread.Sleep(200);
            }
        }

        // 列表事件，更新打印通道
        public void check_list_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {
            CheckedListBoxControl check_list = (CheckedListBoxControl)sender;
            int list_index = e.Index;
            byte msg_id = _link._msg_infomap[check_list.Name]._msg_id;

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
            if (item_count > _parse_sign._wave_channel)
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

            // 消息表和plot绑定
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
                            byte now_msg_id = _link._msg_infomap[msg_list[i].Name]._msg_id;

                            // 消息偏移
                            int now_map_id = _link._msg_infomap[msg_list[i].Name]._map_ind;

                            // 修改通道名
                            _parse_sign._plot[channel_ind].plot_name = msg_list[i].Name + "." + _link._msg_infomap[msg_list[i].Name]._part[j - 1].part_name;
                            _plot.Channels[channel_ind].TitleText = _parse_sign._plot[channel_ind].plot_name;

                            _parse_sign._plot[channel_ind].msg_id = now_msg_id;
                            _parse_sign._plot[channel_ind].plot_id = now_map_id + j - 1;

                            // 清空缓存数据
                            s_comlink.comlink_msgpart_value_clear(_parse_sign._plot[channel_ind].plot_id);

                            channel_ind++;
                        }
                    }
                }
            }
            _parse_sign._channel_ind = channel_ind;

            for (int i = channel_ind; i < _parse_sign._wave_channel; i++)
            {
                _parse_sign._plot[i].msg_id = 0;
               _parse_sign._plot[i].plot_name = "CH" + (i + 1).ToString();
                _plot.Channels[i].TitleText = _parse_sign._plot[i].plot_name;
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
            _link.pkg_trans_select(s_comlink.MSG_SIGN_ENABLE, msg_id, trans_sign);
        }

        // 获取绝对时间ms
        public long absolute_time()
        {
           return DateTime.Now.Ticks / 10000; //ms
        }

        // 更新串口列表
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

        // 串口读
        public bool serial_data_read()  //public bool serial_data_read(object sender, SerialDataReceivedEventArgs e)
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
    }
}
