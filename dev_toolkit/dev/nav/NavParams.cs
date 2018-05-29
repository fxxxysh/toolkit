using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DevExpress.XtraNavBar;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace dev_toolkit.dev
{
    public class ParamsInfo
    {
        public string name; // 消息名
        public List<string> item; //成员名
        public int item_cnt; //成员数
        public DataTable dt; // 表

        public ParamsInfo(string name, DataTable dt)
        {
            item = new List<string>();
            this.name = name;
            this.dt = dt;
        }

        public void add(string item)
        {
            this.item.Add(item);
            this.item_cnt++;
        }

        public float get_value(int ind)
        {
            return (float)dt.Rows[ind][1];
        }

        public void set_value(int ind, float value)
        {
            dt.Rows[ind][1] = value;
        }
    }

    public class NavParams
    {
        PageParams _page_params;
        public ListBoxControl[] _list = new ListBoxControl[50];
        public Dictionary<string, ParamsInfo> _params_info = new Dictionary<string, ParamsInfo>();
        public byte _list_cnt = 0;

        //public DataTable[] _dt_list
        //{
        //    get { return _page_params._dt_list; }
        //    set { _page_params._dt_list = value; }
        //}

        public struct nav_msg_s
        {
            public string _name;
            public int _item_number;
            public CheckedListBoxItem[] _item;

            public nav_msg_s(string name, int item_number)
            {
                _item_number = item_number;
                _name = name;

                _item = new CheckedListBoxItem[_item_number];

                for (int i = 0; i < _item_number; i++)
                {
                    _item[i] = new CheckedListBoxItem("null");
                }
                //_item[0].Description = "ENABLE";
            }
        }

        private NavBarControl _nav_msg;
        private dev_toolkit _hander;

        public NavParams(object sender)
        {
            _hander = (dev_toolkit)sender;
            _nav_msg = _hander._nav_params;
            _page_params = new PageParams(_hander._nav_params_page);
        }

        int table_ind = 0;
        public void nav_creat_msg(string name, string[] item)
        {
            int msg_size = item.Length;
            nav_msg_s msg = new nav_msg_s(name, msg_size);

            DataTable dt = new DataTable();
            dt.Columns.Add("ITEM", typeof(string));
            dt.Columns.Add("VALUE", typeof(float));

            ParamsInfo p_info = new ParamsInfo(name, dt);

            for (int i = 0; i < msg_size; i++)
            {
                msg._item[i].Description = item[i];
                dt.Rows.Add(new object[] { item[i], 0 });

                // 添加成员
                p_info.add(item[i]);
            }

            // 导航栏添加参数消息
            creat_msg(name, msg);

            // 添加表格
            _page_params.creat_grid(name, dt);

            // 表指示器累加
            table_ind++;
            _params_info.Add(name, p_info);
        }

        public void creat_msg(string name, nav_msg_s msg_list)
        {
            _nav_msg.Invoke(new Action(() =>
            {
                int group_item = msg_list._item_number;
                if (group_item > 9)
                {
                    group_item = 9;
                }

                int group_hight = 10 + 18 * group_item;
                int container_hight = 208;
                int container_width = group_hight;

                NavBarGroup bar_group = new NavBarGroup();
                NavBarGroupControlContainer bar_container = new NavBarGroupControlContainer();

                _list[_list_cnt] = new ListBoxControl();
                ListBoxControl check_list = _list[_list_cnt];
                _list_cnt++;

                //_nav_msg.ActiveGroup = bar_group;
                _nav_msg.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] { bar_group });
                _nav_msg.Controls.Add(bar_container);

                bar_group.Caption = msg_list._name;
                bar_group.ControlContainer = bar_container;
                bar_group.Expanded = false;
                bar_group.GroupClientHeight = group_hight;
                bar_group.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.ControlContainer;
                bar_group.Name = "bar_group";

                bar_container.Appearance.BackColor = System.Drawing.SystemColors.Control;
                bar_container.Appearance.Options.UseBackColor = true;
                bar_container.Controls.Add(check_list);
                bar_container.Name = "bar_container";
                bar_container.Size = new System.Drawing.Size(container_hight, container_width);
                bar_container.TabIndex = 0;

                check_list.Cursor = System.Windows.Forms.Cursors.Default;
                check_list.Dock = System.Windows.Forms.DockStyle.Fill;
                check_list.Items.AddRange(msg_list._item);
                check_list.Location = new System.Drawing.Point(0, 0);
                check_list.Name = name;
                check_list.Size = new System.Drawing.Size(container_hight, container_width);
                check_list.TabIndex = 0;
            }));
        }
    }
}
