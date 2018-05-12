using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using Iocomp.Instrumentation.Plotting;
using dev_toolkit.modules;

namespace dev_toolkit.frame
{
    public partial class serial_port : s_comlink
    {
        private SerialPort _serialPort; //串口控件
        private Plot _plot; //示波器控件

        private Panel _lost_focus;
        public dev_toolkit _hander;

        private serial_connect_s serial_connect;

        public DevExpress.XtraBars.BarEditItem _com_port
        {
            get { return serial_connect.com_port; }
            set { serial_connect.com_port = value; }
        }

        public DevExpress.XtraBars.BarEditItem _com_baudrate
        {
            get { return serial_connect.com_baudrate; }
            set { serial_connect.com_baudrate = value; }
        }

        public string _com_port_val
        {
            get { return (string)_com_port.EditValue; }
            set { _com_port.EditValue = value; }
        }

        public string _com_baudrate_val
        {
            get { return (string)_com_baudrate.EditValue; }
            set { _com_baudrate.EditValue = value; }
        }

        public RepositoryItemComboBox _com_port_edit
        {
            get { return serial_connect.com_port_eidt; }
            set { serial_connect.com_port_eidt = value; }
        }

        public RepositoryItemComboBox _com_baudrate_edit
        {
            get { return serial_connect.com_baudrate_eidt; }
            set { serial_connect.com_baudrate_eidt = value; }
        }

        public Image _com_connect
        {
            set { serial_connect.com_connect.ImageOptions.Image = value; }
        }

        public Image _com_connect_start
        {
            get { return serial_connect.image_start; }
        }

        public Image _com_connect_stop
        {
            get { return serial_connect.image_stop; }
        }

        struct serial_var_s
        {
            public bool receiving;
            public bool receive;

            public int receive_byte;
            public int send_byte;

            public Byte[] receive_cache;
            public int receive_cache_size;

            public serial_var_s(bool status)
            {
                receiving = false;
                receive = false;
                receive_byte = 0;
                send_byte = 0;
                receive_cache_size = 0;

                receive_cache = new Byte[4096];
            }
        };
        serial_var_s serial_var = new serial_var_s(false);

        public serial_port(object sender) : base()
        {
            _hander = (dev_toolkit)sender;
            _plot = _hander._plot;

            serial_connect = _hander._serial_connect;

            mode_init();
            event_init();
            serial_init();
        }

        void mode_init()
        {
            _lost_focus = new Panel();
            _hander.Invoke(new Action(() => { _hander.Controls.Add(_lost_focus); }));

            _serialPort = new SerialPort();

            //串口解析任务
            Thread th = new Thread(parse_task)
            { Priority = ThreadPriority.Highest, IsBackground = true };
            th.Start();

            //串口刷新任务
            Thread th1 = new Thread(port_refresh_task)
            { Priority = ThreadPriority.BelowNormal, IsBackground = true };
            th1.Start();
        }

        void event_init()
        {
            //_serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_read);

            serial_connect.com_connect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(com_connect_Click);
            //_com_port.DropDownClosed += new System.EventHandler(com_port_DropDownClosed);
        }

        void serial_init()
        {
            _serialPort.Encoding = Encoding.Default; //能够发送中文
            _serialPort.DataBits = 8; //数据位
            _serialPort.Parity = Parity.None; //无校验
            _serialPort.StopBits = StopBits.One; //停止位
        }

        // 串口发送
        public void serial_trans(byte[] buffer, int size)
        {
            _serialPort.Write(buffer, 0, size);
        }

        // 设置串口端口列表
        public void set_serial_port(string[] device_ports)
        {
            bool current_port_sign = false;
            string current_port = _com_port_val;

            if (device_ports.Length != 0)
            {
                _com_port_edit.Items .Clear();
                _com_port_edit.Items.Add("AUTO");

                foreach (string ports in device_ports)
                {
                    _com_port_edit.Items.Add(ports);

                    if (current_port == ports)
                    {
                        current_port_sign = true;
                    }
                    _com_port_val = device_ports[0];
                }

                if (current_port_sign)
                {
                    _com_port_val = current_port;
                }
            }
        }

        // 设置串口状态
        public void set_serial_status(bool sw)
        {
            if (sw)
            {
                _com_connect = _com_connect_start;
                _com_port.Enabled = false;
                _com_baudrate.Enabled = false;
            }
            else
            {
                _com_connect = _com_connect_stop;
                _com_port.Enabled = true;
                _com_baudrate.Enabled = true;
            }
        }

        // 串口开关操作
        public bool operate_port(string port, string baudrate)
        {
            bool status = false;
            if (_serialPort.IsOpen != true)
            {
                try
                {
                    _serialPort.PortName = port;
                    _serialPort.BaudRate = int.Parse(baudrate);
                    _serialPort.Open();
                    status = true;
                    serial_var.receive = true;
                }
                catch
                {
                    MessageBox.Show(_serialPort.PortName + "被占用！");
                    status = false;
                    serial_var.receive = false;
                }
            }
            else
            {
                serial_var.receive = false;
                while (serial_var.receiving)
                {
                    Application.DoEvents();
                }
                _serialPort.Close();
                status = false;
            }
            return status;
        }

        // 更新串口端口列表
        int last_prot_size = 0;
        string[] last_device_ports;
        public string[] get_port_list()
        {
            string[] device_ports = SerialPort.GetPortNames();
            int now_port_size = device_ports.Length;

            if (last_prot_size != now_port_size)
            {
                last_prot_size = now_port_size;

                device_ports = WMI.MulGetHardwareInfo(WMI.HardwareEnum.Win32_PnPEntity, "Name");
                int cnt = 0;
                foreach (string ports in device_ports)
                {
                    Regex regex = new Regex(@"\(.*?\)", RegexOptions.IgnoreCase);
                    MatchCollection matches = regex.Matches(ports);

                    string name = ports.Split('(')[0];
                    string com = matches[0].Value.Trim('(', ')').Split('-')[0];

                    device_ports[cnt++] = com + " " + name;//.Substring(0, 4) + "...";
                }

                last_device_ports = device_ports;
                return device_ports;
            }
            return null;
        }
    }
}
