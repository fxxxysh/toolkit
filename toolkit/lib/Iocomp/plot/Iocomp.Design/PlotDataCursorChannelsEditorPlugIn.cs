using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotDataCursorChannelsEditorPlugIn : PlugInStandard
	{
		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private FocusLabel XReferenceLabel;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel2;

		private EditBox PositionXTextBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private EditBox YAxisNameTextBox;

		private FocusLabel focusLabel5;

		private EditBox XAxisNameTextBox;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown HitRegionSizeUpDown;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ClippingStyleComboBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox MasterControlCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox SnapToPointCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotDataCursorChannelsEditorPlugIn()
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
			this.NameTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.ColorPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.PositionXTextBox = new EditBox();
			this.XReferenceLabel = new FocusLabel();
			this.TitleTextBox = new EditMultiLine();
			this.focusLabel2 = new FocusLabel();
			this.LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			this.YAxisNameTextBox = new EditBox();
			this.focusLabel5 = new FocusLabel();
			this.XAxisNameTextBox = new EditBox();
			this.focusLabel4 = new FocusLabel();
			this.HitRegionSizeUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.focusLabel6 = new FocusLabel();
			this.ClippingStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel8 = new FocusLabel();
			this.MasterControlCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.SnapToPointCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			this.NameTextBox.LoadingBegin();
			this.NameTextBox.Location = new Point(104, 8);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.PropertyName = "Name";
			this.NameTextBox.Size = new Size(144, 20);
			this.NameTextBox.TabIndex = 0;
			this.NameTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.NameTextBox;
			this.focusLabel1.Location = new Point(67, 10);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(37, 15);
			this.focusLabel1.Text = "Name";
			this.focusLabel1.LoadingEnd();
			this.ColorPicker.Location = new Point(104, 200);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(48, 21);
			this.ColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorPicker.TabIndex = 5;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorPicker;
			this.label8.Location = new Point(70, 203);
			this.label8.Name = "label8";
			this.label8.Size = new Size(34, 15);
			this.label8.Text = "Color";
			this.label8.LoadingEnd();
			this.PositionXTextBox.LoadingBegin();
			this.PositionXTextBox.Location = new Point(104, 80);
			this.PositionXTextBox.Name = "PositionXTextBox";
			this.PositionXTextBox.PropertyName = "PositionX";
			this.PositionXTextBox.Size = new Size(144, 20);
			this.PositionXTextBox.TabIndex = 2;
			this.PositionXTextBox.LoadingEnd();
			this.XReferenceLabel.LoadingBegin();
			this.XReferenceLabel.FocusControl = this.PositionXTextBox;
			this.XReferenceLabel.Location = new Point(46, 82);
			this.XReferenceLabel.Name = "XReferenceLabel";
			this.XReferenceLabel.Size = new Size(58, 15);
			this.XReferenceLabel.Text = "Position-X";
			this.XReferenceLabel.LoadingEnd();
			this.TitleTextBox.EditFont = null;
			this.TitleTextBox.Location = new Point(104, 40);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.PropertyName = "TitleText";
			this.TitleTextBox.Size = new Size(144, 20);
			this.TitleTextBox.TabIndex = 1;
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.TitleTextBox;
			this.focusLabel2.Location = new Point(51, 43);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(53, 15);
			this.focusLabel2.Text = "Title Text";
			this.focusLabel2.LoadingEnd();
			this.LayerNumericUpDown.Location = new Point(192, 200);
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
			this.LayerNumericUpDown.TabIndex = 6;
			this.LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.LayerNumericUpDown;
			this.label1.Location = new Point(157, 201);
			this.label1.Name = "label1";
			this.label1.Size = new Size(35, 15);
			this.label1.Text = "Layer";
			this.label1.LoadingEnd();
			this.YAxisNameTextBox.LoadingBegin();
			this.YAxisNameTextBox.Location = new Point(104, 160);
			this.YAxisNameTextBox.Name = "YAxisNameTextBox";
			this.YAxisNameTextBox.PropertyName = "YAxisName";
			this.YAxisNameTextBox.Size = new Size(144, 20);
			this.YAxisNameTextBox.TabIndex = 4;
			this.YAxisNameTextBox.LoadingEnd();
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.YAxisNameTextBox;
			this.focusLabel5.Location = new Point(32, 162);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(72, 15);
			this.focusLabel5.Text = "Y-Axis Name";
			this.focusLabel5.LoadingEnd();
			this.XAxisNameTextBox.LoadingBegin();
			this.XAxisNameTextBox.Location = new Point(104, 136);
			this.XAxisNameTextBox.Name = "XAxisNameTextBox";
			this.XAxisNameTextBox.PropertyName = "XAxisName";
			this.XAxisNameTextBox.Size = new Size(144, 20);
			this.XAxisNameTextBox.TabIndex = 3;
			this.XAxisNameTextBox.LoadingEnd();
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.XAxisNameTextBox;
			this.focusLabel4.Location = new Point(32, 138);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(72, 15);
			this.focusLabel4.Text = "X-Axis Name";
			this.focusLabel4.LoadingEnd();
			this.HitRegionSizeUpDown.Location = new Point(352, 200);
			this.HitRegionSizeUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			this.HitRegionSizeUpDown.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			this.HitRegionSizeUpDown.Name = "HitRegionSizeUpDown";
			this.HitRegionSizeUpDown.PropertyName = "HitRegionSize";
			this.HitRegionSizeUpDown.Size = new Size(56, 20);
			this.HitRegionSizeUpDown.TabIndex = 15;
			this.HitRegionSizeUpDown.TextAlign = HorizontalAlignment.Center;
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.HitRegionSizeUpDown;
			this.focusLabel6.Location = new Point(269, 201);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(83, 15);
			this.focusLabel6.Text = "Hit Region Size";
			this.focusLabel6.LoadingEnd();
			this.ClippingStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ClippingStyleComboBox.Location = new Point(328, 160);
			this.ClippingStyleComboBox.MaxDropDownItems = 20;
			this.ClippingStyleComboBox.Name = "ClippingStyleComboBox";
			this.ClippingStyleComboBox.PropertyName = "ClippingStyle";
			this.ClippingStyleComboBox.Size = new Size(80, 21);
			this.ClippingStyleComboBox.TabIndex = 14;
			this.focusLabel8.LoadingBegin();
			this.focusLabel8.FocusControl = this.ClippingStyleComboBox;
			this.focusLabel8.Location = new Point(253, 162);
			this.focusLabel8.Name = "focusLabel8";
			this.focusLabel8.Size = new Size(75, 15);
			this.focusLabel8.Text = "Clipping Style";
			this.focusLabel8.LoadingEnd();
			this.MasterControlCheckBox.Location = new Point(272, 103);
			this.MasterControlCheckBox.Name = "MasterControlCheckBox";
			this.MasterControlCheckBox.PropertyName = "MasterControl";
			this.MasterControlCheckBox.Size = new Size(136, 24);
			this.MasterControlCheckBox.TabIndex = 13;
			this.MasterControlCheckBox.Text = "Master Control";
			this.SnapToPointCheckBox.Location = new Point(272, 79);
			this.SnapToPointCheckBox.Name = "SnapToPointCheckBox";
			this.SnapToPointCheckBox.PropertyName = "SnapToPoint";
			this.SnapToPointCheckBox.Size = new Size(96, 24);
			this.SnapToPointCheckBox.TabIndex = 12;
			this.SnapToPointCheckBox.Text = "Snap To Point";
			this.UserCanEditCheckBox.Location = new Point(272, 51);
			this.UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			this.UserCanEditCheckBox.PropertyName = "UserCanEdit";
			this.UserCanEditCheckBox.Size = new Size(96, 24);
			this.UserCanEditCheckBox.TabIndex = 10;
			this.UserCanEditCheckBox.Text = "User Can Edit";
			this.ContextMenuEnabledCheckBox.Location = new Point(384, 27);
			this.ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			this.ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			this.ContextMenuEnabledCheckBox.Size = new Size(152, 24);
			this.ContextMenuEnabledCheckBox.TabIndex = 9;
			this.ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			this.EnabledCheckBox.Location = new Point(272, 27);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(80, 24);
			this.EnabledCheckBox.TabIndex = 8;
			this.EnabledCheckBox.Text = "Enabled";
			this.VisibleCheckBox.Location = new Point(272, 3);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 7;
			this.VisibleCheckBox.Text = "Visible";
			this.CanFocusCheckBox.Location = new Point(384, 51);
			this.CanFocusCheckBox.Name = "CanFocusCheckBox";
			this.CanFocusCheckBox.PropertyName = "CanFocus";
			this.CanFocusCheckBox.Size = new Size(144, 24);
			this.CanFocusCheckBox.TabIndex = 11;
			this.CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(this.CanFocusCheckBox);
			base.Controls.Add(this.MasterControlCheckBox);
			base.Controls.Add(this.SnapToPointCheckBox);
			base.Controls.Add(this.UserCanEditCheckBox);
			base.Controls.Add(this.ContextMenuEnabledCheckBox);
			base.Controls.Add(this.EnabledCheckBox);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.ClippingStyleComboBox);
			base.Controls.Add(this.focusLabel8);
			base.Controls.Add(this.HitRegionSizeUpDown);
			base.Controls.Add(this.focusLabel6);
			base.Controls.Add(this.YAxisNameTextBox);
			base.Controls.Add(this.focusLabel5);
			base.Controls.Add(this.XAxisNameTextBox);
			base.Controls.Add(this.focusLabel4);
			base.Controls.Add(this.LayerNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.TitleTextBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.PositionXTextBox);
			base.Controls.Add(this.XReferenceLabel);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.NameTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Location = new Point(10, 20);
			base.Name = "PlotDataCursorChannelsEditorPlugIn";
			base.Size = new Size(600, 256);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Line", false);
			base.AddSubPlugIn(new PlotDataCursorHintEditorPlugIn(), "Hint", false);
			base.AddSubPlugIn(new PlotDataCursorWindowEditorPlugIn(), "Window", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotDataCursorChannels).Line;
			base.SubPlugIns[1].Value = (base.Value as PlotDataCursorChannels).Hint;
			base.SubPlugIns[2].Value = (base.Value as PlotDataCursorChannels).Window;
		}
	}
}
