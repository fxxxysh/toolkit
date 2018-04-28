using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotLimitBandXEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private EditBox XAxisNameTextBox;

		private FocusLabel focusLabel4;

		private EditBox YAxisNameTextBox;

		private FocusLabel focusLabel5;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private FocusLabel XReferenceLabel;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private FocusLabel focusLabel3;

		private EditBox XStartTextBox;

		private EditBox XStopTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ClippingStyleComboBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanMoveCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown HitRegionSizeUpDown;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotLimitBandXEditorPlugIn()
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
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.NameTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.XAxisNameTextBox = new EditBox();
			this.focusLabel4 = new FocusLabel();
			this.YAxisNameTextBox = new EditBox();
			this.focusLabel5 = new FocusLabel();
			this.ColorPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.XStartTextBox = new EditBox();
			this.XReferenceLabel = new FocusLabel();
			this.TitleTextBox = new EditMultiLine();
			this.focusLabel2 = new FocusLabel();
			this.EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.XStopTextBox = new EditBox();
			this.focusLabel3 = new FocusLabel();
			this.ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			this.UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ClippingStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel8 = new FocusLabel();
			this.UserCanMoveCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.HitRegionSizeUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.focusLabel6 = new FocusLabel();
			this.CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(248, 3);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 6;
			this.VisibleCheckBox.Text = "Visible";
			this.NameTextBox.LoadingBegin();
			this.NameTextBox.Location = new Point(80, 8);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.PropertyName = "Name";
			this.NameTextBox.Size = new Size(144, 20);
			this.NameTextBox.TabIndex = 0;
			this.NameTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.NameTextBox;
			this.focusLabel1.Location = new Point(43, 10);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(37, 15);
			this.focusLabel1.Text = "Name";
			this.focusLabel1.LoadingEnd();
			this.XAxisNameTextBox.LoadingBegin();
			this.XAxisNameTextBox.Location = new Point(80, 136);
			this.XAxisNameTextBox.Name = "XAxisNameTextBox";
			this.XAxisNameTextBox.PropertyName = "XAxisName";
			this.XAxisNameTextBox.Size = new Size(144, 20);
			this.XAxisNameTextBox.TabIndex = 4;
			this.XAxisNameTextBox.LoadingEnd();
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.XAxisNameTextBox;
			this.focusLabel4.Location = new Point(8, 138);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(72, 15);
			this.focusLabel4.Text = "X-Axis Name";
			this.focusLabel4.LoadingEnd();
			this.YAxisNameTextBox.LoadingBegin();
			this.YAxisNameTextBox.Location = new Point(80, 160);
			this.YAxisNameTextBox.Name = "YAxisNameTextBox";
			this.YAxisNameTextBox.PropertyName = "YAxisName";
			this.YAxisNameTextBox.Size = new Size(144, 20);
			this.YAxisNameTextBox.TabIndex = 5;
			this.YAxisNameTextBox.LoadingEnd();
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.YAxisNameTextBox;
			this.focusLabel5.Location = new Point(8, 162);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(72, 15);
			this.focusLabel5.Text = "Y-Axis Name";
			this.focusLabel5.LoadingEnd();
			this.ColorPicker.Location = new Point(80, 200);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(48, 21);
			this.ColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorPicker.TabIndex = 13;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorPicker;
			this.label8.Location = new Point(46, 203);
			this.label8.Name = "label8";
			this.label8.Size = new Size(34, 15);
			this.label8.Text = "Color";
			this.label8.LoadingEnd();
			this.XStartTextBox.LoadingBegin();
			this.XStartTextBox.Location = new Point(80, 72);
			this.XStartTextBox.Name = "XStartTextBox";
			this.XStartTextBox.PropertyName = "XStart";
			this.XStartTextBox.Size = new Size(144, 20);
			this.XStartTextBox.TabIndex = 2;
			this.XStartTextBox.LoadingEnd();
			this.XReferenceLabel.LoadingBegin();
			this.XReferenceLabel.FocusControl = this.XStartTextBox;
			this.XReferenceLabel.Location = new Point(38, 74);
			this.XReferenceLabel.Name = "XReferenceLabel";
			this.XReferenceLabel.Size = new Size(42, 15);
			this.XReferenceLabel.Text = "X-Start";
			this.XReferenceLabel.LoadingEnd();
			this.TitleTextBox.EditFont = null;
			this.TitleTextBox.Location = new Point(80, 40);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.PropertyName = "TitleText";
			this.TitleTextBox.Size = new Size(144, 20);
			this.TitleTextBox.TabIndex = 1;
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.TitleTextBox;
			this.focusLabel2.Location = new Point(27, 43);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(53, 15);
			this.focusLabel2.Text = "Title Text";
			this.focusLabel2.LoadingEnd();
			this.EnabledCheckBox.Location = new Point(248, 27);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(80, 24);
			this.EnabledCheckBox.TabIndex = 7;
			this.EnabledCheckBox.Text = "Enabled";
			this.XStopTextBox.LoadingBegin();
			this.XStopTextBox.Location = new Point(80, 96);
			this.XStopTextBox.Name = "XStopTextBox";
			this.XStopTextBox.PropertyName = "XStop";
			this.XStopTextBox.Size = new Size(144, 20);
			this.XStopTextBox.TabIndex = 3;
			this.XStopTextBox.LoadingEnd();
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.XStopTextBox;
			this.focusLabel3.Location = new Point(39, 98);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(41, 15);
			this.focusLabel3.Text = "X-Stop";
			this.focusLabel3.LoadingEnd();
			this.ContextMenuEnabledCheckBox.Location = new Point(248, 51);
			this.ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			this.ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			this.ContextMenuEnabledCheckBox.Size = new Size(152, 24);
			this.ContextMenuEnabledCheckBox.TabIndex = 8;
			this.ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			this.LayerNumericUpDown.Location = new Point(168, 200);
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
			this.LayerNumericUpDown.TabIndex = 14;
			this.LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.LayerNumericUpDown;
			this.label1.Location = new Point(133, 201);
			this.label1.Name = "label1";
			this.label1.Size = new Size(35, 15);
			this.label1.Text = "Layer";
			this.label1.LoadingEnd();
			this.UserCanEditCheckBox.Location = new Point(248, 76);
			this.UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			this.UserCanEditCheckBox.PropertyName = "UserCanEdit";
			this.UserCanEditCheckBox.Size = new Size(96, 24);
			this.UserCanEditCheckBox.TabIndex = 9;
			this.UserCanEditCheckBox.Text = "User Can Edit";
			this.ClippingStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ClippingStyleComboBox.Location = new Point(312, 200);
			this.ClippingStyleComboBox.MaxDropDownItems = 20;
			this.ClippingStyleComboBox.Name = "ClippingStyleComboBox";
			this.ClippingStyleComboBox.PropertyName = "ClippingStyle";
			this.ClippingStyleComboBox.Size = new Size(80, 21);
			this.ClippingStyleComboBox.TabIndex = 15;
			this.focusLabel8.LoadingBegin();
			this.focusLabel8.FocusControl = this.ClippingStyleComboBox;
			this.focusLabel8.Location = new Point(237, 202);
			this.focusLabel8.Name = "focusLabel8";
			this.focusLabel8.Size = new Size(75, 15);
			this.focusLabel8.Text = "Clipping Style";
			this.focusLabel8.LoadingEnd();
			this.UserCanMoveCheckBox.Location = new Point(248, 100);
			this.UserCanMoveCheckBox.Name = "UserCanMoveCheckBox";
			this.UserCanMoveCheckBox.PropertyName = "UserCanMove";
			this.UserCanMoveCheckBox.Size = new Size(120, 24);
			this.UserCanMoveCheckBox.TabIndex = 10;
			this.UserCanMoveCheckBox.Text = "User Can Move";
			this.HitRegionSizeUpDown.Location = new Point(336, 160);
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
			this.HitRegionSizeUpDown.TabIndex = 12;
			this.HitRegionSizeUpDown.TextAlign = HorizontalAlignment.Center;
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.HitRegionSizeUpDown;
			this.focusLabel6.Location = new Point(253, 161);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(83, 15);
			this.focusLabel6.Text = "Hit Region Size";
			this.focusLabel6.LoadingEnd();
			this.CanFocusCheckBox.Location = new Point(248, 124);
			this.CanFocusCheckBox.Name = "CanFocusCheckBox";
			this.CanFocusCheckBox.PropertyName = "CanFocus";
			this.CanFocusCheckBox.Size = new Size(80, 24);
			this.CanFocusCheckBox.TabIndex = 11;
			this.CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(this.CanFocusCheckBox);
			base.Controls.Add(this.HitRegionSizeUpDown);
			base.Controls.Add(this.focusLabel6);
			base.Controls.Add(this.UserCanMoveCheckBox);
			base.Controls.Add(this.ClippingStyleComboBox);
			base.Controls.Add(this.focusLabel8);
			base.Controls.Add(this.UserCanEditCheckBox);
			base.Controls.Add(this.LayerNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ContextMenuEnabledCheckBox);
			base.Controls.Add(this.XStopTextBox);
			base.Controls.Add(this.focusLabel3);
			base.Controls.Add(this.TitleTextBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.EnabledCheckBox);
			base.Controls.Add(this.XStartTextBox);
			base.Controls.Add(this.XReferenceLabel);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.YAxisNameTextBox);
			base.Controls.Add(this.focusLabel5);
			base.Controls.Add(this.XAxisNameTextBox);
			base.Controls.Add(this.focusLabel4);
			base.Controls.Add(this.NameTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.VisibleCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotLimitBandXEditorPlugIn";
			base.Size = new Size(456, 240);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotLimitBandX).Fill;
		}
	}
}
