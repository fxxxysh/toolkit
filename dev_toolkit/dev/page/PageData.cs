using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraNavBar;
using DevExpress.XtraBars.Navigation;
using DevExpress.Utils;
using dev_toolkit;

namespace dev_toolkit
{
    class PageData
    {
        NavigationPage _page;
        public PageData(object sender)
        {
            _page = (NavigationPage)sender;
        }
    }
}
