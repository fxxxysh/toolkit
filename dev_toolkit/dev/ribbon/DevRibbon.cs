using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;

namespace dev_toolkit.dev
{
    public class DevRibbon
    {
        private dev_toolkit _hander;
        private RibbonControl _ribbon;
        private BarButtonItem _ribbon_hide;

        public DevRibbon(object sender)
        {
            _hander = (dev_toolkit)sender;
            _ribbon = _hander._ribbon;
            _ribbon_hide = _hander._ribbon_hide;

           _ribbon.Minimized = true;
           _ribbon.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
           _ribbon_hide.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Hide_ItemClick);
        }

        // 串口连接触发刷新
        public void refresh_ribbon(bool status)
        {
            hide_item(status);
        }

        void hide_item(bool sign)
        {
            if (sign == true)
            {
                _ribbon.ShowPageHeadersMode = ShowPageHeadersMode.Hide;
                _ribbon.Minimized = true;
                _ribbon_hide.Caption = "显示菜单";
            }
            else
            {
                _ribbon.ShowPageHeadersMode = ShowPageHeadersMode.Show;
                _ribbon.Minimized = false;
                _ribbon_hide.Caption = "隐藏菜单";
            }
        }

        // 菜单隐藏事件
        private void Hide_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            hide_item(_ribbon.ShowPageHeadersMode != ShowPageHeadersMode.Hide);
        }
    }
}
