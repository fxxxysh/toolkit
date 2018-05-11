using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraNavBar;
using DevExpress.XtraBars.Navigation;

namespace dev_toolkit.dev
{
    class NavPage
    {
        private NavigationFrame _nav_page;
        private NavigationPage[] _page_list;

        public NavPage(object sender, object page)
        {
            _nav_page = (NavigationFrame)sender;
            _page_list = (NavigationPage[])page;

            _nav_page.Invoke(new Action(() => { _nav_page.SelectedPage = _page_list[3]; }));
        }
    }
}
