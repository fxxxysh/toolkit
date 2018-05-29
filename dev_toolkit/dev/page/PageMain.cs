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
    public class PageMain
    {
        private dev_toolkit _hander;
        PageData _page_data;
        PageParams _page_params;

        public PageMain(object sender)
        {
            _hander = (dev_toolkit)sender;

            //_page_params = new PageParams(_hander._nav_params_page);
            _page_data = new PageData(_hander._nav_data_page);
        }
    }
}
