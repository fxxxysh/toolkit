namespace dev_toolkit
{
    partial class dev_toolkit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.kit_ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.kit_com_port = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.kit_com_baudrate = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.kit_com_connect = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.kit_theme = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPage2 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.kit_hide = new DevExpress.XtraBars.BarButtonItem();
            this.kit_com_connect_dis = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.kit_sys_id = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.kit_dev_id = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            ((System.ComponentModel.ISupportInitialize)(this.kit_ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // kit_ribbon
            // 
            this.kit_ribbon.ExpandCollapseItem.Id = 0;
            this.kit_ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.kit_ribbon.ExpandCollapseItem,
            this.kit_com_port,
            this.kit_com_baudrate,
            this.kit_com_connect,
            this.kit_hide,
            this.kit_com_connect_dis,
            this.kit_sys_id,
            this.kit_dev_id});
            this.kit_ribbon.Location = new System.Drawing.Point(0, 0);
            this.kit_ribbon.MaxItemId = 8;
            this.kit_ribbon.Name = "kit_ribbon";
            this.kit_ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.kit_ribbon.QuickToolbarItemLinks.Add(this.kit_hide);
            this.kit_ribbon.QuickToolbarItemLinks.Add(this.kit_com_connect_dis);
            this.kit_ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemComboBox2,
            this.repositoryItemSpinEdit1,
            this.repositoryItemSpinEdit2});
            this.kit_ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.kit_ribbon.ShowToolbarCustomizeItem = false;
            this.kit_ribbon.Size = new System.Drawing.Size(1022, 150);
            this.kit_ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // kit_com_port
            // 
            this.kit_com_port.Caption = "串口   ";
            this.kit_com_port.Edit = this.repositoryItemComboBox1;
            this.kit_com_port.EditWidth = 100;
            this.kit_com_port.Id = 1;
            this.kit_com_port.Name = "kit_com_port";
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // kit_com_baudrate
            // 
            this.kit_com_baudrate.Caption = "波特率";
            this.kit_com_baudrate.Edit = this.repositoryItemComboBox2;
            this.kit_com_baudrate.EditWidth = 100;
            this.kit_com_baudrate.Id = 2;
            this.kit_com_baudrate.Name = "kit_com_baudrate";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // kit_com_connect
            // 
            this.kit_com_connect.Caption = "连接";
            this.kit_com_connect.Id = 3;
            this.kit_com_connect.ImageOptions.LargeImage = global::dev_toolkit.Properties.Resources.play_32x32;
            this.kit_com_connect.Name = "kit_com_connect";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "连接";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.kit_com_port);
            this.ribbonPageGroup1.ItemLinks.Add(this.kit_com_baudrate);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "连接";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.kit_com_connect);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // kit_theme
            // 
            this.kit_theme.LookAndFeel.SkinName = "Office 2016 Dark";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Location = new System.Drawing.Point(0, 150);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 169;
            this.navBarControl1.Size = new System.Drawing.Size(169, 449);
            this.navBarControl1.TabIndex = 1;
            this.navBarControl1.Text = "navBarControl1";
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "navBarGroup1";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Controls.Add(this.navigationPage1);
            this.navigationFrame1.Controls.Add(this.navigationPage2);
            this.navigationFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationFrame1.Location = new System.Drawing.Point(169, 150);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage1,
            this.navigationPage2});
            this.navigationFrame1.SelectedPage = this.navigationPage2;
            this.navigationFrame1.Size = new System.Drawing.Size(853, 449);
            this.navigationFrame1.TabIndex = 2;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPage1
            // 
            this.navigationPage1.Name = "navigationPage1";
            this.navigationPage1.Size = new System.Drawing.Size(853, 449);
            // 
            // navigationPage2
            // 
            this.navigationPage2.Name = "navigationPage2";
            this.navigationPage2.Size = new System.Drawing.Size(853, 449);
            // 
            // kit_hide
            // 
            this.kit_hide.Caption = "kit_hide";
            this.kit_hide.Id = 4;
            this.kit_hide.ImageOptions.Image = global::dev_toolkit.Properties.Resources.group2_32x32;
            this.kit_hide.ImageOptions.LargeImage = global::dev_toolkit.Properties.Resources.group2_32x32;
            this.kit_hide.Name = "kit_hide";
            toolTipItem1.Text = "隐藏菜单";
            superToolTip1.Items.Add(toolTipItem1);
            this.kit_hide.SuperTip = superToolTip1;
            // 
            // kit_com_connect_dis
            // 
            this.kit_com_connect_dis.Caption = "连接";
            this.kit_com_connect_dis.Id = 5;
            this.kit_com_connect_dis.ImageOptions.Image = global::dev_toolkit.Properties.Resources.play_16x16;
            this.kit_com_connect_dis.ImageOptions.LargeImage = global::dev_toolkit.Properties.Resources.stop_32x32;
            this.kit_com_connect_dis.Name = "kit_com_connect_dis";
            toolTipItem2.Text = "连接";
            superToolTip2.Items.Add(toolTipItem2);
            this.kit_com_connect_dis.SuperTip = superToolTip2;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.kit_sys_id);
            this.ribbonPageGroup3.ItemLinks.Add(this.kit_dev_id);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ID配置";
            // 
            // kit_sys_id
            // 
            this.kit_sys_id.Caption = "系统ID";
            this.kit_sys_id.Edit = this.repositoryItemSpinEdit1;
            this.kit_sys_id.EditWidth = 80;
            this.kit_sys_id.Id = 6;
            this.kit_sys_id.Name = "kit_sys_id";
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // kit_dev_id
            // 
            this.kit_dev_id.Caption = "设备ID";
            this.kit_dev_id.Edit = this.repositoryItemSpinEdit2;
            this.kit_dev_id.EditWidth = 80;
            this.kit_dev_id.Id = 7;
            this.kit_dev_id.Name = "kit_dev_id";
            // 
            // repositoryItemSpinEdit2
            // 
            this.repositoryItemSpinEdit2.AutoHeight = false;
            this.repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            // 
            // dev_toolkit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 599);
            this.Controls.Add(this.navigationFrame1);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.kit_ribbon);
            this.Name = "dev_toolkit";
            this.Ribbon = this.kit_ribbon;
            this.Text = "dev_toolkit";
            ((System.ComponentModel.ISupportInitialize)(this.kit_ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl kit_ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel kit_theme;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage2;
        private DevExpress.XtraBars.BarEditItem kit_com_port;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.BarEditItem kit_com_baudrate;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraBars.BarButtonItem kit_com_connect;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem kit_hide;
        private DevExpress.XtraBars.BarButtonItem kit_com_connect_dis;
        private DevExpress.XtraBars.BarEditItem kit_sys_id;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraBars.BarEditItem kit_dev_id;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}