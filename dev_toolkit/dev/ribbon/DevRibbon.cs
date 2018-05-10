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
        RibbonControl _hander;
        private BarEditItem kit_com_port;

        public DevRibbon(object sender)
        {
            _hander = (RibbonControl)sender;

            _hander.Minimized = true;
            _hander.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
            _hander.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Hide_ItemClick);
        }

        // 菜单隐藏事件
        private void Hide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_hander.ShowPageHeadersMode != ShowPageHeadersMode.Hide)
            {
                _hander.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
            }
            else
            {
                _hander.ShowPageHeadersMode = ShowPageHeadersMode.Show;
            }
        }
    }
}
