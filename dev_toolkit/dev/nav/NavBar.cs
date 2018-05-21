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
        private NavigationFrame _nav_frame;
        private nav_page_s[] _page_list;

        private dev_toolkit _hander;
        private NavBarControl _nav;

        public NavBar(object sender)
        {
            _hander = (dev_toolkit)sender;
            _nav = _hander._nav;
            _page_list = _hander._page_list;
            _nav_frame = _hander._nav_frame;
            _nav_msg = new NavMsg(_hander);

            init();
        }

        public void init()
        {
            // 设置页面索引
            _hander.Invoke(new Action(() => 
            {
                _page_list[0].ind.TopVisibleLinkIndex = 0;
                _page_list[1].ind.TopVisibleLinkIndex = 1;
                _page_list[2].ind.TopVisibleLinkIndex = 2;
                _page_list[3].ind.TopVisibleLinkIndex = 3;
            }));

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

        public void nav_page_change(object sender, NavBarGroupEventArgs e)
        {
            _nav_frame.SelectedPage = _page_list[e.Group.TopVisibleLinkIndex].page;
        }
    }
}
