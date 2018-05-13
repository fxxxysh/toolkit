﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraNavBar;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace dev_toolkit.dev
{
    class NavMsg
    {
        public struct nav_msg_s 
        {
            public string _name;
            public int _item_number;
            public CheckedListBoxItem[] _item;

            public nav_msg_s(string name, int item_number)
            {
                _item_number = item_number + 1;
                _name = name;
                _item = new CheckedListBoxItem[_item_number];

                for (int i = 0; i < _item_number; i++)
                {
                    _item[i] = new CheckedListBoxItem("null");
                }

                _item[0].Description = "ALL";
            }
        }

        private NavBarControl _nav_msg;

        public NavMsg(object sender)
        {
            _nav_msg = (NavBarControl)sender;

            test_creat_msg();
        }

        public void test_creat_msg()
        {
            nav_msg_s msg1 = new nav_msg_s("MSG1", 18);

            msg1._item[1].Description = "2";
            msg1._item[2].Description = "3";
            msg1._item[3].Description = "4";
            msg1._item[4].Description = "5";
            msg1._item[5].Description = "6";

            creat_msg(msg1);
            creat_msg(msg1);
            creat_msg(msg1);
            creat_msg(msg1);
        }

        public void creat_msg(nav_msg_s msg_list)
        {
            int group_item = msg_list._item_number;
            if (group_item > 9)
            {
                group_item = 9;
            }

            int group_hight = 15 + 17 * group_item;
            int container_hight = 208;
            int container_width = group_hight;

            NavBarGroup bar_group = new NavBarGroup();
            NavBarGroupControlContainer bar_container = new NavBarGroupControlContainer();
            CheckedListBoxControl check_list = new CheckedListBoxControl();

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
            check_list.CheckOnClick = true;
            check_list.Dock = System.Windows.Forms.DockStyle.Fill;
            check_list.Items.AddRange(msg_list._item);
            check_list.Location = new System.Drawing.Point(0, 0);
            check_list.Name = "check_list";
            check_list.Size = new System.Drawing.Size(container_hight, container_width);
            check_list.TabIndex = 0;
        }
    }
}