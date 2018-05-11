using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraNavBar;

namespace dev_toolkit.dev
{
    class NavBar
    {
        private NavMsg _nav_msg;
        private NavPage _nav_page;

        private dev_toolkit _hander;
        private NavBarControl _nav;

        public void navBarControl2_ActiveGroupChanged(object sender, DevExpress.XtraNavBar.NavBarGroupEventArgs e)
        {

        }

        public NavBar(object sender)
        {
            _hander = (dev_toolkit)sender;
            _nav = _hander._nav;

            _nav_msg = new NavMsg(_hander._nav_msg);
            _nav_page = new NavPage(_hander.nav_frame, _hander._page_list);

            _nav.Invoke(new Action(() => { _nav.NavigationPaneMaxVisibleGroups = 4; }));

            _nav.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(navBarControl2_ActiveGroupChanged);
        }      
    }
}
