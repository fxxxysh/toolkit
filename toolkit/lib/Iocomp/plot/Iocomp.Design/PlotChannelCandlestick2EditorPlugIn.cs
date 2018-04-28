using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelCandlestick2EditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleInLegendCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel2;

		private EditBox CapacityTextBox;

		private FocusLabel focusLabel3;

		private EditBox XAxisNameTextBox;

		private FocusLabel focusLabel4;

		private EditBox YAxisNameTextBox;

		private FocusLabel focusLabel5;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox SendXAxisTrackingDataCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox SendYAxisTrackingDataCheckBox;

		private EditBox LegendNameTextBox;

		private FocusLabel focusLabel8;

		private EditMultiLine TitleTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private EditBox RingBufferCountEditBox;

		private FocusLabel focusLabel9;

		private FocusLabel focusLabel7;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ClippingStyleComboBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotChannelCandlestick2EditorPlugIn()
		{
			this.InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.VisibleInLegendCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.NameTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.focusLabel2 = new FocusLabel();
			this.TitleTextBox = new EditMultiLine();
			this.CapacityTextBox = new EditBox();
			this.focusLabel3 = new FocusLabel();
			this.XAxisNameTextBox = new EditBox();
			this.focusLabel4 = new FocusLabel();
			this.YAxisNameTextBox = new EditBox();
			this.focusLabel5 = new FocusLabel();
			this.ColorPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.SendXAxisTrackingDataCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.SendYAxisTrackingDataCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LegendNameTextBox = new EditBox();
			this.focusLabel8 = new FocusLabel();
			this.ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			this.UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.RingBufferCountEditBox = new EditBox();
			this.focusLabel9 = new FocusLabel();
			this.ClippingStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel7 = new FocusLabel();
			this.CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			((ISupportInitialize)this.LayerNumericUpDown).BeginInit();
			base.SuspendLayout();
			this.VisibleInLegendCheckBox.Location = new Point(368, 3);
			this.VisibleInLegendCheckBox.Name = "VisibleInLegendCheckBox";
			this.VisibleInLegendCheckBox.PropertyName = "VisibleInLegend";
			this.VisibleInLegendCheckBox.Size = new Size(112, 24);
			this.VisibleInLegendCheckBox.TabIndex = 15;
			this.VisibleInLegendCheckBox.Text = "Visible In Legend";
			this.VisibleCheckBox.Location = new Point(264, 3);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 12;
			this.VisibleCheckBox.Text = "Visible";
			this.EnabledCheckBox.Location = new Point(264, 27);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(80, 24);
			this.EnabledCheckBox.TabIndex = 13;
			this.EnabledCheckBox.Text = "Enabled";
			this.NameTextBox.LoadingBegin();
			this.NameTextBox.Location = new Point(96, 8);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.PropertyName = "Name";
			this.NameTextBox.Size = new Size(144, 20);
			this.NameTextBox.TabIndex = 0;
			this.NameTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.NameTextBox;
			this.focusLabel1.Location = new Point(59, 10);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(37, 15);
			this.focusLabel1.Text = "Name";
			this.focusLabel1.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.TitleTextBox;
			this.focusLabel2.Location = new Point(43, 43);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(53, 15);
			this.focusLabel2.Text = "Title Text";
			this.focusLabel2.LoadingEnd();
			this.TitleTextBox.EditFont = null;
			this.TitleTextBox.Location = new Point(96, 40);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.PropertyName = "TitleText";
			this.TitleTextBox.Size = new Size(144, 20);
			this.TitleTextBox.TabIndex = 1;
			this.CapacityTextBox.LoadingBegin();
			this.CapacityTextBox.Location = new Point(96, 100);
			this.CapacityTextBox.Name = "CapacityTextBox";
			this.CapacityTextBox.PropertyName = "Capacity";
			this.CapacityTextBox.Size = new Size(144, 20);
			this.CapacityTextBox.TabIndex = 3;
			this.CapacityTextBox.LoadingEnd();
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.CapacityTextBox;
			this.focusLabel3.Location = new Point(46, 102);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(50, 15);
			this.focusLabel3.Text = "Capacity";
			this.focusLabel3.LoadingEnd();
			this.XAxisNameTextBox.LoadingBegin();
			this.XAxisNameTextBox.Location = new Point(96, 136);
			this.XAxisNameTextBox.Name = "XAxisNameTextBox";
			this.XAxisNameTextBox.PropertyName = "XAxisName";
			this.XAxisNameTextBox.Size = new Size(144, 20);
			this.XAxisNameTextBox.TabIndex = 4;
			this.XAxisNameTextBox.LoadingEnd();
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.XAxisNameTextBox;
			this.focusLabel4.Location = new Point(24, 138);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(72, 15);
			this.focusLabel4.Text = "X-Axis Name";
			this.focusLabel4.LoadingEnd();
			this.YAxisNameTextBox.LoadingBegin();
			this.YAxisNameTextBox.Location = new Point(96, 160);
			this.YAxisNameTextBox.Name = "YAxisNameTextBox";
			this.YAxisNameTextBox.PropertyName = "YAxisName";
			this.YAxisNameTextBox.Size = new Size(144, 20);
			this.YAxisNameTextBox.TabIndex = 6;
			this.YAxisNameTextBox.LoadingEnd();
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.YAxisNameTextBox;
			this.focusLabel5.Location = new Point(24, 162);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(72, 15);
			this.focusLabel5.Text = "Y-Axis Name";
			this.focusLabel5.LoadingEnd();
			this.ColorPicker.Location = new Point(96, 224);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(48, 21);
			this.ColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorPicker.TabIndex = 9;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorPicker;
			this.label8.Location = new Point(62, 227);
			this.label8.Name = "label8";
			this.label8.Size = new Size(34, 15);
			this.label8.Text = "Color";
			this.label8.LoadingEnd();
			this.SendXAxisTrackingDataCheckBox.Location = new Point(248, 136);
			this.SendXAxisTrackingDataCheckBox.Name = "SendXAxisTrackingDataCheckBox";
			this.SendXAxisTrackingDataCheckBox.PropertyName = "SendXAxisTrackingData";
			this.SendXAxisTrackingDataCheckBox.Size = new Size(160, 24);
			this.SendXAxisTrackingDataCheckBox.TabIndex = 5;
			this.SendXAxisTrackingDataCheckBox.Text = "Send X-Axis Tracking Data";
			this.SendYAxisTrackingDataCheckBox.Location = new Point(248, 160);
			this.SendYAxisTrackingDataCheckBox.Name = "SendYAxisTrackingDataCheckBox";
			this.SendYAxisTrackingDataCheckBox.PropertyName = "SendYAxisTrackingData";
			this.SendYAxisTrackingDataCheckBox.Size = new Size(160, 24);
			this.SendYAxisTrackingDataCheckBox.TabIndex = 7;
			this.SendYAxisTrackingDataCheckBox.Text = "Send Y-Axis Tracking Data";
			this.LegendNameTextBox.LoadingBegin();
			this.LegendNameTextBox.Location = new Point(96, 192);
			this.LegendNameTextBox.Name = "LegendNameTextBox";
			this.LegendNameTextBox.PropertyName = "LegendName";
			this.LegendNameTextBox.Size = new Size(144, 20);
			this.LegendNameTextBox.TabIndex = 8;
			this.LegendNameTextBox.LoadingEnd();
			this.focusLabel8.LoadingBegin();
			this.focusLabel8.FocusControl = this.LegendNameTextBox;
			this.focusLabel8.Location = new Point(20, 194);
			this.focusLabel8.Name = "focusLabel8";
			this.focusLabel8.Size = new Size(76, 15);
			this.focusLabel8.Text = "Legend Name";
			this.focusLabel8.LoadingEnd();
			this.ContextMenuEnabledCheckBox.Location = new Point(368, 27);
			this.ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			this.ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			this.ContextMenuEnabledCheckBox.Size = new Size(144, 24);
			this.ContextMenuEnabledCheckBox.TabIndex = 16;
			this.ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			this.LayerNumericUpDown.Location = new Point(184, 224);
			this.LayerNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			this.LayerNumericUpDown.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			this.LayerNumericUpDown.Name = "LayerNumericUpDown";
			this.LayerNumericUpDown.PropertyName = "Layer";
			this.LayerNumericUpDown.Size = new Size(56, 20);
			this.LayerNumericUpDown.TabIndex = 10;
			this.LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.LayerNumericUpDown;
			this.label1.Location = new Point(149, 225);
			this.label1.Name = "label1";
			this.label1.Size = new Size(35, 15);
			this.label1.Text = "Layer";
			this.label1.LoadingEnd();
			this.UserCanEditCheckBox.Location = new Point(264, 51);
			this.UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			this.UserCanEditCheckBox.PropertyName = "UserCanEdit";
			this.UserCanEditCheckBox.Size = new Size(96, 24);
			this.UserCanEditCheckBox.TabIndex = 14;
			this.UserCanEditCheckBox.Text = "User Can Edit";
			this.RingBufferCountEditBox.LoadingBegin();
			this.RingBufferCountEditBox.Location = new Point(96, 76);
			this.RingBufferCountEditBox.Name = "RingBufferCountEditBox";
			this.RingBufferCountEditBox.PropertyName = "RingBufferCount";
			this.RingBufferCountEditBox.Size = new Size(144, 20);
			this.RingBufferCountEditBox.TabIndex = 2;
			this.RingBufferCountEditBox.LoadingEnd();
			this.focusLabel9.LoadingBegin();
			this.focusLabel9.FocusControl = this.RingBufferCountEditBox;
			this.focusLabel9.Location = new Point(1, 78);
			this.focusLabel9.Name = "focusLabel9";
			this.focusLabel9.Size = new Size(95, 15);
			this.focusLabel9.Text = "Ring Buffer Count";
			this.focusLabel9.LoadingEnd();
			this.ClippingStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ClippingStyleComboBox.Location = new Point(328, 224);
			this.ClippingStyleComboBox.MaxDropDownItems = 20;
			this.ClippingStyleComboBox.Name = "ClippingStyleComboBox";
			this.ClippingStyleComboBox.PropertyName = "ClippingStyle";
			this.ClippingStyleComboBox.Size = new Size(80, 21);
			this.ClippingStyleComboBox.TabIndex = 11;
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.ClippingStyleComboBox;
			this.focusLabel7.Location = new Point(253, 226);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(75, 15);
			this.focusLabel7.Text = "Clipping Style";
			this.focusLabel7.LoadingEnd();
			this.CanFocusCheckBox.Location = new Point(368, 51);
			this.CanFocusCheckBox.Name = "CanFocusCheckBox";
			this.CanFocusCheckBox.PropertyName = "CanFocus";
			this.CanFocusCheckBox.Size = new Size(144, 24);
			this.CanFocusCheckBox.TabIndex = 17;
			this.CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(this.CanFocusCheckBox);
			base.Controls.Add(this.ClippingStyleComboBox);
			base.Controls.Add(this.focusLabel7);
			base.Controls.Add(this.RingBufferCountEditBox);
			base.Controls.Add(this.focusLabel9);
			base.Controls.Add(this.UserCanEditCheckBox);
			base.Controls.Add(this.LayerNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ContextMenuEnabledCheckBox);
			base.Controls.Add(this.TitleTextBox);
			base.Controls.Add(this.LegendNameTextBox);
			base.Controls.Add(this.focusLabel8);
			base.Controls.Add(this.SendYAxisTrackingDataCheckBox);
			base.Controls.Add(this.SendXAxisTrackingDataCheckBox);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.YAxisNameTextBox);
			base.Controls.Add(this.focusLabel5);
			base.Controls.Add(this.XAxisNameTextBox);
			base.Controls.Add(this.focusLabel4);
			base.Controls.Add(this.CapacityTextBox);
			base.Controls.Add(this.focusLabel3);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.NameTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.VisibleInLegendCheckBox);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelCandlestick3EditorPlugIn";
			base.Size = new Size(584, 280);
			((ISupportInitialize)this.LayerNumericUpDown).EndInit();
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotChannelCandlestick2SpecificEditorPlugIn(), "Candlestick-2", false);
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill Body", false);
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill Open", false);
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill Close", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = base.Value;
			base.SubPlugIns[1].Value = (base.Value as PlotChannelCandlestick2).FillBody;
			base.SubPlugIns[2].Value = (base.Value as PlotChannelCandlestick2).FillOpen;
			base.SubPlugIns[3].Value = (base.Value as PlotChannelCandlestick2).FillClose;
		}
	}
}
