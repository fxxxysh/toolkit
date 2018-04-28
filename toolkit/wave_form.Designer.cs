namespace toolkit
{
    partial class wave_form
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Iocomp.Classes.PlotChannelTrace plotChannelTrace1 = new Iocomp.Classes.PlotChannelTrace();
            Iocomp.Classes.PlotDataCursorXY plotDataCursorXY1 = new Iocomp.Classes.PlotDataCursorXY();
            Iocomp.Classes.PlotDataView plotDataView1 = new Iocomp.Classes.PlotDataView();
            Iocomp.Classes.PlotLabelBasic plotLabelBasic1 = new Iocomp.Classes.PlotLabelBasic();
            Iocomp.Classes.PlotLegendBasic plotLegendBasic1 = new Iocomp.Classes.PlotLegendBasic();
            Iocomp.Classes.PlotXAxis plotXAxis1 = new Iocomp.Classes.PlotXAxis();
            Iocomp.Classes.PlotYAxis plotYAxis1 = new Iocomp.Classes.PlotYAxis();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wave_form));
            this.plot1 = new Iocomp.Instrumentation.Plotting.Plot();
            this.plotToolBarStandard1 = new Iocomp.Instrumentation.Plotting.PlotToolBarStandard();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.plotToolBarButton1 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton2 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton3 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton4 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton5 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton6 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton7 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton8 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton9 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton10 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton11 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton12 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton13 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton14 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton15 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton16 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton17 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton18 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton19 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton20 = new Iocomp.Classes.PlotToolBarButton();
            this.plotToolBarButton21 = new Iocomp.Classes.PlotToolBarButton();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // plot1
            // 
            this.plot1.LoadingBegin();
            plotChannelTrace1.Color = System.Drawing.Color.Red;
            plotChannelTrace1.MarkersTurnOffLimit = 0;
            plotChannelTrace1.Name = "Channel 1";
            plotChannelTrace1.TitleText = "Channel 1";
            this.plot1.Channels.Add(plotChannelTrace1);
            plotDataCursorXY1.Hint.Fill.Pen.Color = System.Drawing.SystemColors.InfoText;
            plotDataCursorXY1.Name = "Data-Cursor 1";
            plotDataCursorXY1.TitleText = "Data-Cursor 1";
            this.plot1.DataCursors.Add(plotDataCursorXY1);
            plotDataView1.Name = "Data-View 1";
            plotDataView1.TitleText = "Data-View 1";
            this.plot1.DataViews.Add(plotDataView1);
            plotLabelBasic1.DockOrder = 0;
            plotLabelBasic1.Name = "Label 1";
            this.plot1.Labels.Add(plotLabelBasic1);
            plotLegendBasic1.DockOrder = 0;
            plotLegendBasic1.Name = "Legend 1";
            plotLegendBasic1.TitleText = "Legend 1";
            this.plot1.Legends.Add(plotLegendBasic1);
            this.plot1.Location = new System.Drawing.Point(46, 156);
            this.plot1.Name = "plot1";
            this.plot1.Size = new System.Drawing.Size(500, 250);
            this.plot1.TabIndex = 0;
            plotXAxis1.DockOrder = 0;
            plotXAxis1.Name = "X-Axis 1";
            plotXAxis1.Title.Text = "X-Axis 1";
            this.plot1.XAxes.Add(plotXAxis1);
            plotYAxis1.DockOrder = 0;
            plotYAxis1.Name = "Y-Axis 1";
            plotYAxis1.Title.Text = "Y-Axis 1";
            this.plot1.YAxes.Add(plotYAxis1);
            this.plot1.LoadingEnd();
            // 
            // plotToolBarStandard1
            // 
            this.plotToolBarStandard1.LoadingBegin();
            this.plotToolBarStandard1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.plotToolBarStandard1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.plotToolBarButton1,
            this.plotToolBarButton2,
            this.plotToolBarButton3,
            this.plotToolBarButton4,
            this.plotToolBarButton5,
            this.plotToolBarButton6,
            this.plotToolBarButton7,
            this.plotToolBarButton8,
            this.plotToolBarButton9,
            this.plotToolBarButton10,
            this.plotToolBarButton11,
            this.plotToolBarButton12,
            this.plotToolBarButton13,
            this.plotToolBarButton14,
            this.plotToolBarButton15,
            this.plotToolBarButton16,
            this.plotToolBarButton17,
            this.plotToolBarButton18,
            this.plotToolBarButton19,
            this.plotToolBarButton20,
            this.plotToolBarButton21});
            this.plotToolBarStandard1.DropDownArrows = true;
            this.plotToolBarStandard1.ImageList = this.imageList3;
            this.plotToolBarStandard1.Location = new System.Drawing.Point(0, 0);
            this.plotToolBarStandard1.Name = "plotToolBarStandard1";
            this.plotToolBarStandard1.Plot = this.plot1;
            this.plotToolBarStandard1.ShowToolTips = true;
            this.plotToolBarStandard1.Size = new System.Drawing.Size(738, 28);
            this.plotToolBarStandard1.TabIndex = 1;
            this.plotToolBarStandard1.LoadingEnd();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            // 
            // plotToolBarButton1
            // 
            this.plotToolBarButton1.LoadingBegin();
            this.plotToolBarButton1.ImageIndex = 0;
            this.plotToolBarButton1.Name = "plotToolBarButton1";
            this.plotToolBarButton1.ToolTipText = "Tracking Resume";
            this.plotToolBarButton1.LoadingEnd();
            // 
            // plotToolBarButton2
            // 
            this.plotToolBarButton2.LoadingBegin();
            this.plotToolBarButton2.Command = Iocomp.Types.PlotToolBarCommandStyle.TrackingPause;
            this.plotToolBarButton2.ImageIndex = 1;
            this.plotToolBarButton2.Name = "plotToolBarButton2";
            this.plotToolBarButton2.ToolTipText = "Tracking Pause";
            this.plotToolBarButton2.LoadingEnd();
            // 
            // plotToolBarButton3
            // 
            this.plotToolBarButton3.LoadingBegin();
            this.plotToolBarButton3.Command = Iocomp.Types.PlotToolBarCommandStyle.Separator;
            this.plotToolBarButton3.Enabled = false;
            this.plotToolBarButton3.Name = "plotToolBarButton3";
            this.plotToolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.plotToolBarButton3.LoadingEnd();
            // 
            // plotToolBarButton4
            // 
            this.plotToolBarButton4.LoadingBegin();
            this.plotToolBarButton4.Command = Iocomp.Types.PlotToolBarCommandStyle.AxesScroll;
            this.plotToolBarButton4.ImageIndex = 2;
            this.plotToolBarButton4.Name = "plotToolBarButton4";
            this.plotToolBarButton4.ToolTipText = "Axes Scroll";
            this.plotToolBarButton4.LoadingEnd();
            // 
            // plotToolBarButton5
            // 
            this.plotToolBarButton5.LoadingBegin();
            this.plotToolBarButton5.Command = Iocomp.Types.PlotToolBarCommandStyle.AxesZoom;
            this.plotToolBarButton5.ImageIndex = 3;
            this.plotToolBarButton5.Name = "plotToolBarButton5";
            this.plotToolBarButton5.ToolTipText = "Axes Zoom";
            this.plotToolBarButton5.LoadingEnd();
            // 
            // plotToolBarButton6
            // 
            this.plotToolBarButton6.LoadingBegin();
            this.plotToolBarButton6.Command = Iocomp.Types.PlotToolBarCommandStyle.Separator;
            this.plotToolBarButton6.Enabled = false;
            this.plotToolBarButton6.Name = "plotToolBarButton6";
            this.plotToolBarButton6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.plotToolBarButton6.LoadingEnd();
            // 
            // plotToolBarButton7
            // 
            this.plotToolBarButton7.LoadingBegin();
            this.plotToolBarButton7.Command = Iocomp.Types.PlotToolBarCommandStyle.ZoomOut;
            this.plotToolBarButton7.ImageIndex = 4;
            this.plotToolBarButton7.Name = "plotToolBarButton7";
            this.plotToolBarButton7.ToolTipText = "Zoom-Out";
            this.plotToolBarButton7.LoadingEnd();
            // 
            // plotToolBarButton8
            // 
            this.plotToolBarButton8.LoadingBegin();
            this.plotToolBarButton8.Command = Iocomp.Types.PlotToolBarCommandStyle.ZoomIn;
            this.plotToolBarButton8.ImageIndex = 5;
            this.plotToolBarButton8.Name = "plotToolBarButton8";
            this.plotToolBarButton8.ToolTipText = "Zoom-In";
            this.plotToolBarButton8.LoadingEnd();
            // 
            // plotToolBarButton9
            // 
            this.plotToolBarButton9.LoadingBegin();
            this.plotToolBarButton9.Command = Iocomp.Types.PlotToolBarCommandStyle.Separator;
            this.plotToolBarButton9.Enabled = false;
            this.plotToolBarButton9.Name = "plotToolBarButton9";
            this.plotToolBarButton9.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.plotToolBarButton9.LoadingEnd();
            // 
            // plotToolBarButton10
            // 
            this.plotToolBarButton10.LoadingBegin();
            this.plotToolBarButton10.Command = Iocomp.Types.PlotToolBarCommandStyle.Select;
            this.plotToolBarButton10.ImageIndex = 6;
            this.plotToolBarButton10.Name = "plotToolBarButton10";
            this.plotToolBarButton10.ToolTipText = "Select";
            this.plotToolBarButton10.LoadingEnd();
            // 
            // plotToolBarButton11
            // 
            this.plotToolBarButton11.LoadingBegin();
            this.plotToolBarButton11.Command = Iocomp.Types.PlotToolBarCommandStyle.ZoomBox;
            this.plotToolBarButton11.ImageIndex = 7;
            this.plotToolBarButton11.Name = "plotToolBarButton11";
            this.plotToolBarButton11.ToolTipText = "Zoom-Box";
            this.plotToolBarButton11.LoadingEnd();
            // 
            // plotToolBarButton12
            // 
            this.plotToolBarButton12.LoadingBegin();
            this.plotToolBarButton12.Command = Iocomp.Types.PlotToolBarCommandStyle.DataCursor;
            this.plotToolBarButton12.ImageIndex = 8;
            this.plotToolBarButton12.Name = "plotToolBarButton12";
            this.plotToolBarButton12.ToolTipText = "Data-Cursor";
            this.plotToolBarButton12.LoadingEnd();
            // 
            // plotToolBarButton13
            // 
            this.plotToolBarButton13.LoadingBegin();
            this.plotToolBarButton13.Command = Iocomp.Types.PlotToolBarCommandStyle.Separator;
            this.plotToolBarButton13.Enabled = false;
            this.plotToolBarButton13.Name = "plotToolBarButton13";
            this.plotToolBarButton13.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.plotToolBarButton13.LoadingEnd();
            // 
            // plotToolBarButton14
            // 
            this.plotToolBarButton14.LoadingBegin();
            this.plotToolBarButton14.Command = Iocomp.Types.PlotToolBarCommandStyle.Edit;
            this.plotToolBarButton14.ImageIndex = 9;
            this.plotToolBarButton14.Name = "plotToolBarButton14";
            this.plotToolBarButton14.ToolTipText = "Edit";
            this.plotToolBarButton14.LoadingEnd();
            // 
            // plotToolBarButton15
            // 
            this.plotToolBarButton15.LoadingBegin();
            this.plotToolBarButton15.Command = Iocomp.Types.PlotToolBarCommandStyle.Separator;
            this.plotToolBarButton15.Enabled = false;
            this.plotToolBarButton15.Name = "plotToolBarButton15";
            this.plotToolBarButton15.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.plotToolBarButton15.LoadingEnd();
            // 
            // plotToolBarButton16
            // 
            this.plotToolBarButton16.LoadingBegin();
            this.plotToolBarButton16.Command = Iocomp.Types.PlotToolBarCommandStyle.Copy;
            this.plotToolBarButton16.ImageIndex = 10;
            this.plotToolBarButton16.Name = "plotToolBarButton16";
            this.plotToolBarButton16.ToolTipText = "Copy to Clipboard";
            this.plotToolBarButton16.LoadingEnd();
            // 
            // plotToolBarButton17
            // 
            this.plotToolBarButton17.LoadingBegin();
            this.plotToolBarButton17.Command = Iocomp.Types.PlotToolBarCommandStyle.Save;
            this.plotToolBarButton17.ImageIndex = 11;
            this.plotToolBarButton17.Name = "plotToolBarButton17";
            this.plotToolBarButton17.ToolTipText = "Save";
            this.plotToolBarButton17.LoadingEnd();
            // 
            // plotToolBarButton18
            // 
            this.plotToolBarButton18.LoadingBegin();
            this.plotToolBarButton18.Command = Iocomp.Types.PlotToolBarCommandStyle.Separator;
            this.plotToolBarButton18.Enabled = false;
            this.plotToolBarButton18.Name = "plotToolBarButton18";
            this.plotToolBarButton18.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            this.plotToolBarButton18.LoadingEnd();
            // 
            // plotToolBarButton19
            // 
            this.plotToolBarButton19.LoadingBegin();
            this.plotToolBarButton19.Command = Iocomp.Types.PlotToolBarCommandStyle.Print;
            this.plotToolBarButton19.ImageIndex = 12;
            this.plotToolBarButton19.Name = "plotToolBarButton19";
            this.plotToolBarButton19.ToolTipText = "Print";
            this.plotToolBarButton19.LoadingEnd();
            // 
            // plotToolBarButton20
            // 
            this.plotToolBarButton20.LoadingBegin();
            this.plotToolBarButton20.Command = Iocomp.Types.PlotToolBarCommandStyle.Preview;
            this.plotToolBarButton20.ImageIndex = 13;
            this.plotToolBarButton20.Name = "plotToolBarButton20";
            this.plotToolBarButton20.ToolTipText = "Preview";
            this.plotToolBarButton20.LoadingEnd();
            // 
            // plotToolBarButton21
            // 
            this.plotToolBarButton21.LoadingBegin();
            this.plotToolBarButton21.Command = Iocomp.Types.PlotToolBarCommandStyle.PageSetup;
            this.plotToolBarButton21.ImageIndex = 14;
            this.plotToolBarButton21.Name = "plotToolBarButton21";
            this.plotToolBarButton21.ToolTipText = "Page Setup";
            this.plotToolBarButton21.LoadingEnd();
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            this.imageList2.Images.SetKeyName(6, "");
            this.imageList2.Images.SetKeyName(7, "");
            this.imageList2.Images.SetKeyName(8, "");
            this.imageList2.Images.SetKeyName(9, "");
            this.imageList2.Images.SetKeyName(10, "");
            this.imageList2.Images.SetKeyName(11, "");
            this.imageList2.Images.SetKeyName(12, "");
            this.imageList2.Images.SetKeyName(13, "");
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList3.Images.SetKeyName(0, "");
            this.imageList3.Images.SetKeyName(1, "");
            this.imageList3.Images.SetKeyName(2, "");
            this.imageList3.Images.SetKeyName(3, "");
            this.imageList3.Images.SetKeyName(4, "");
            this.imageList3.Images.SetKeyName(5, "");
            this.imageList3.Images.SetKeyName(6, "");
            this.imageList3.Images.SetKeyName(7, "");
            this.imageList3.Images.SetKeyName(8, "");
            this.imageList3.Images.SetKeyName(9, "");
            this.imageList3.Images.SetKeyName(10, "");
            this.imageList3.Images.SetKeyName(11, "");
            this.imageList3.Images.SetKeyName(12, "");
            this.imageList3.Images.SetKeyName(13, "");
            // 
            // wave_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 465);
            this.Controls.Add(this.plot1);
            this.Controls.Add(this.plotToolBarStandard1);
            this.Name = "wave_form";
            this.Text = "wave_form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Iocomp.Instrumentation.Plotting.Plot plot1;
        private Iocomp.Instrumentation.Plotting.PlotToolBarStandard plotToolBarStandard1;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton1;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton2;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton3;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton4;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton5;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton6;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton7;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton8;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton9;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton10;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton11;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton12;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton13;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton14;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton15;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton16;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton17;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton18;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton19;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton20;
        private Iocomp.Classes.PlotToolBarButton plotToolBarButton21;
        private System.Windows.Forms.ImageList imageList3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ImageList imageList2;
    }
}

