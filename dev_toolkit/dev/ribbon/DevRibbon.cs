using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;

namespace dev_toolkit.dev
{
    public class DevRibbon
    {
        dev_toolkit _hander;

        public DevRibbon(object sender)
        {
            _hander = (dev_toolkit)sender;

            _hander.ribbon.Minimized = true;
            _hander.ribbon.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
            _hander.ribbon_hide.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Hide_ItemClick);
        }

        // 菜单隐藏事件
        private void Hide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_hander.ribbon.ShowPageHeadersMode != ShowPageHeadersMode.Hide)
            {
                _hander.ribbon.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
            }
            else
            {
                _hander.ribbon.ShowPageHeadersMode = ShowPageHeadersMode.Show;
            }
        }
    }
}
