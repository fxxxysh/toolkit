using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotChannelSweepIntervalEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleInLegendCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private EditBox XAxisNameTextBox;

		private FocusLabel focusLabel4;

		private EditBox YAxisNameTextBox;

		private FocusLabel focusLabel5;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox SendXAxisTrackingDataCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox SendYAxisTrackingDataCheckBox;

		private EditBox LegendNameTextBox;

		private FocusLabel focusLabel6;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ClippingStyleComboBox;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private EditBox MarkersTurnOffLimitTextBox;

		private FocusLabel focusLabel11;

		private Container components;

		public PlotChannelSweepIntervalEditorPlugIn()
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
			this.XAxisNameTextBox = new EditBox();
			this.focusLabel4 = new FocusLabel();
			this.YAxisNameTextBox = new EditBox();
			this.focusLabel5 = new FocusLabel();
			this.ColorPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.SendXAxisTrackingDataCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.SendYAxisTrackingDataCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LegendNameTextBox = new EditBox();
			this.focusLabel6 = new FocusLabel();
			this.TitleTextBox = new EditMultiLine();
			this.focusLabel2 = new FocusLabel();
			this.ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			this.UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ClippingStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel3 = new FocusLabel();
			this.CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.MarkersTurnOffLimitTextBox = new EditBox();
			this.focusLabel11 = new FocusLabel();
			((ISupportInitialize)this.LayerNumericUpDown).BeginInit();
			base.SuspendLayout();
			this.VisibleInLegendCheckBox.Location = new Point(368, 3);
			this.VisibleInLegendCheckBox.Name = "VisibleInLegendCheckBox";
			this.VisibleInLegendCheckBox.PropertyName = "VisibleInLegend";
			this.VisibleInLegendCheckBox.Size = new Size(112, 24);
			this.VisibleInLegendCheckBox.TabIndex = 14;
			this.VisibleInLegendCheckBox.Text = "Visible In Legend";
			this.VisibleCheckBox.Location = new Point(264, 3);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 11;
			this.VisibleCheckBox.Text = "Visible";
			this.EnabledCheckBox.Location = new Point(264, 27);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(80, 24);
			this.EnabledCheckBox.TabIndex = 12;
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
			this.XAxisNameTextBox.LoadingBegin();
			this.XAxisNameTextBox.Location = new Point(96, 136);
			this.XAxisNameTextBox.Name = "XAxisNameTextBox";
			this.XAxisNameTextBox.PropertyName = "XAxisName";
			this.XAxisNameTextBox.Size = new Size(144, 20);
			this.XAxisNameTextBox.TabIndex = 2;
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
			this.YAxisNameTextBox.TabIndex = 4;
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
			this.ColorPicker.TabIndex = 7;
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
			this.SendXAxisTrackingDataCheckBox.Size = new Size(168, 24);
			this.SendXAxisTrackingDataCheckBox.TabIndex = 3;
			this.SendXAxisTrackingDataCheckBox.Text = "Send X-Axis Tracking Data";
			this.SendYAxisTrackingDataCheckBox.Location = new Point(248, 160);
			this.SendYAxisTrackingDataCheckBox.Name = "SendYAxisTrackingDataCheckBox";
			this.SendYAxisTrackingDataCheckBox.PropertyName = "SendYAxisTrackingData";
			this.SendYAxisTrackingDataCheckBox.Size = new Size(168, 24);
			this.SendYAxisTrackingDataCheckBox.TabIndex = 5;
			this.SendYAxisTrackingDataCheckBox.Text = "Send Y-Axis Tracking Data";
			this.LegendNameTextBox.LoadingBegin();
			this.LegendNameTextBox.Location = new Point(96, 192);
			this.LegendNameTextBox.Name = "LegendNameTextBox";
			this.LegendNameTextBox.PropertyName = "LegendName";
			this.LegendNameTextBox.Size = new Size(144, 20);
			this.LegendNameTextBox.TabIndex = 6;
			this.LegendNameTextBox.LoadingEnd();
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.LegendNameTextBox;
			this.focusLabel6.Location = new Point(20, 194);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(76, 15);
			this.focusLabel6.Text = "Legend Name";
			this.focusLabel6.LoadingEnd();
			this.TitleTextBox.EditFont = null;
			this.TitleTextBox.Location = new Point(96, 40);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.PropertyName = "TitleText";
			this.TitleTextBox.Size = new Size(144, 20);
			this.TitleTextBox.TabIndex = 1;
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.TitleTextBox;
			this.focusLabel2.Location = new Point(43, 43);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(53, 15);
			this.focusLabel2.Text = "Title Text";
			this.focusLabel2.LoadingEnd();
			this.ContextMenuEnabledCheckBox.Location = new Point(368, 27);
			this.ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			this.ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			this.ContextMenuEnabledCheckBox.Size = new Size(144, 24);
			this.ContextMenuEnabledCheckBox.TabIndex = 15;
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
			this.LayerNumericUpDown.TabIndex = 8;
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
			this.UserCanEditCheckBox.TabIndex = 13;
			this.UserCanEditCheckBox.Text = "User Can Edit";
			this.ClippingStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ClippingStyleComboBox.Location = new Point(328, 224);
			this.ClippingStyleComboBox.MaxDropDownItems = 20;
			this.ClippingStyleComboBox.Name = "ClippingStyleComboBox";
			this.ClippingStyleComboBox.PropertyName = "ClippingStyle";
			this.ClippingStyleComboBox.Size = new Size(80, 21);
			this.ClippingStyleComboBox.TabIndex = 9;
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.ClippingStyleComboBox;
			this.focusLabel3.Location = new Point(253, 226);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(75, 15);
			this.focusLabel3.Text = "Clipping Style";
			this.focusLabel3.LoadingEnd();
			this.CanFocusCheckBox.Location = new Point(368, 51);
			this.CanFocusCheckBox.Name = "CanFocusCheckBox";
			this.CanFocusCheckBox.PropertyName = "CanFocus";
			this.CanFocusCheckBox.Size = new Size(144, 24);
			this.CanFocusCheckBox.TabIndex = 16;
			this.CanFocusCheckBox.Text = "Can Focus";
			this.MarkersTurnOffLimitTextBox.LoadingBegin();
			this.MarkersTurnOffLimitTextBox.Location = new Point(544, 224);
			this.MarkersTurnOffLimitTextBox.Name = "MarkersTurnOffLimitTextBox";
			this.MarkersTurnOffLimitTextBox.PropertyName = "MarkersTurnOffLimit";
			this.MarkersTurnOffLimitTextBox.Size = new Size(64, 20);
			this.MarkersTurnOffLimitTextBox.TabIndex = 10;
			this.MarkersTurnOffLimitTextBox.LoadingEnd();
			this.focusLabel11.LoadingBegin();
			this.focusLabel11.FocusControl = this.MarkersTurnOffLimitTextBox;
			this.focusLabel11.Location = new Point(428, 226);
			this.focusLabel11.Name = "focusLabel11";
			this.focusLabel11.Size = new Size(116, 15);
			this.focusLabel11.Text = "Markers Turn-Off Limit";
			this.focusLabel11.LoadingEnd();
			base.Controls.Add(this.MarkersTurnOffLimitTextBox);
			base.Controls.Add(this.focusLabel11);
			base.Controls.Add(this.CanFocusCheckBox);
			base.Controls.Add(this.ClippingStyleComboBox);
			base.Controls.Add(this.focusLabel3);
			base.Controls.Add(this.UserCanEditCheckBox);
			base.Controls.Add(this.LayerNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ContextMenuEnabledCheckBox);
			base.Controls.Add(this.TitleTextBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.LegendNameTextBox);
			base.Controls.Add(this.focusLabel6);
			base.Controls.Add(this.SendYAxisTrackingDataCheckBox);
			base.Controls.Add(this.SendXAxisTrackingDataCheckBox);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.YAxisNameTextBox);
			base.Controls.Add(this.focusLabel5);
			base.Controls.Add(this.XAxisNameTextBox);
			base.Controls.Add(this.focusLabel4);
			base.Controls.Add(this.NameTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.VisibleInLegendCheckBox);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelSweepIntervalEditorPlugIn";
			base.Size = new Size(664, 272);
			((ISupportInitialize)this.LayerNumericUpDown).EndInit();
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotChannelSweepIntervalDataPointsEditorPlugIn(), "Data-Points", false);
			base.AddSubPlugIn(new PlotChannelSweepIntervalSpecificEditorPlugIn(), "Sweep", false);
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Trace", false);
			base.AddSubPlugIn(new PlotMarkerEditorPlugIn(), "Markers", false);
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Retrace Line", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = base.Value;
			base.SubPlugIns[1].Value = base.Value;
			base.SubPlugIns[2].Value = (base.Value as PlotChannelSweepInterval).Trace;
			base.SubPlugIns[3].Value = (base.Value as PlotChannelSweepInterval).Markers;
			base.SubPlugIns[4].Value = (base.Value as PlotChannelSweepInterval).RetraceLine;
		}
	}
}
