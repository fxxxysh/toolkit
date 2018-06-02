using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraNavBar;
using DevExpress.XtraBars.Navigation;
using DevExpress.Utils;
using dev_toolkit;

namespace dev_toolkit.dev
{
    public class NavBar
    {
        public NavMsg _nav_msg;
        public NavParams _nav_params;

        private NavigationFrame _nav_frame;
        private Dictionary<string, NavigationPage> _page_list;

        private dev_toolkit _hander;
        private NavBarControl _nav;

        public Dictionary<string, ParamsInfo> _params_info
        {
            get { return _nav_params._params_info; }
            set { _nav_params._params_info = value; }
        }

        public NavBar(object sender)
        {
            _hander = (dev_toolkit)sender;
            _nav = _hander._nav;
            _page_list = _hander._page_list;
            _nav_frame = _hander._nav_frame;

            _nav_msg = new NavMsg(_hander);
            _nav_params = new NavParams(_hander);

            init();
        }

        public void init()
        {
            // 禁止页面过渡效果
            _nav_frame.Invoke(new Action(() =>
            {
                _nav_frame.AllowTransitionAnimation = DefaultBoolean.False;

            }));

            // 折叠nav菜单栏
            _nav.Invoke(new Action(() => 
            {
                _nav.NavigationPaneMaxVisibleGroups = 0;// 4;
            }));

            // nav菜单切换页面
            _nav.ActiveGroupChanged += new NavBarGroupEventHandler(nav_page_change);
        }

        // 切换页面
        public void nav_page_change(object sender, NavBarGroupEventArgs e)
        {
            _nav_frame.SelectedPage = _page_list[e.Group.Caption];
        }

        // 创建参数列表
        public void creat_params(string name, string[] item)
        {
            _nav_params.nav_creat_msg(name, item);
        }

        // 创建消息列表
        public void creat_msg(string name, string[] item)
        {
            _nav_msg.nav_creat_msg(name, item);
        }

        // 清除消息列表
        public void clear_msglist()
        {
            _nav_msg.nav_clear_msglist();
        }
    }
}
