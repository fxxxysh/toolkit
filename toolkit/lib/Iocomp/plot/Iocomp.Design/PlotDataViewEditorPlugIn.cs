using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotDataViewEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private GroupBox groupBox1;

		private FocusLabel focusLabel2;

		private FocusLabel focusLabel3;

		private EditBox GridLinesMirrorHorizontalTextBox;

		private EditBox GridLinesMirrorVerticalTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private GroupBox groupBox2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox AxesControlMouseStyleComboBox;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.CheckBox AxesControlEnabledCheckBox;

		private FocusLabel focusLabel5;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox AxesControlWheelStyleComboBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox AxesControlKeyboardStyleComboBox;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel15;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotDataViewEditorPlugIn()
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
			this.EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.NameTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.ColorPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.groupBox1 = new GroupBox();
			this.GridLinesMirrorHorizontalTextBox = new EditBox();
			this.focusLabel3 = new FocusLabel();
			this.GridLinesMirrorVerticalTextBox = new EditBox();
			this.focusLabel2 = new FocusLabel();
			this.ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			this.UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.groupBox2 = new GroupBox();
			this.focusLabel6 = new FocusLabel();
			this.AxesControlKeyboardStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel5 = new FocusLabel();
			this.AxesControlWheelStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel4 = new FocusLabel();
			this.AxesControlMouseStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.AxesControlEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.TitleTextBox = new EditMultiLine();
			this.focusLabel15 = new FocusLabel();
			this.CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(248, 3);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 4;
			this.VisibleCheckBox.Text = "Visible";
			this.EnabledCheckBox.Location = new Point(248, 27);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(80, 24);
			this.EnabledCheckBox.TabIndex = 5;
			this.EnabledCheckBox.Text = "Enabled";
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
			this.ColorPicker.Location = new Point(80, 72);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(48, 21);
			this.ColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorPicker.TabIndex = 2;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorPicker;
			this.label8.Location = new Point(46, 75);
			this.label8.Name = "label8";
			this.label8.Size = new Size(34, 15);
			this.label8.Text = "Color";
			this.label8.LoadingEnd();
			this.groupBox1.Controls.Add(this.GridLinesMirrorHorizontalTextBox);
			this.groupBox1.Controls.Add(this.focusLabel3);
			this.groupBox1.Controls.Add(this.GridLinesMirrorVerticalTextBox);
			this.groupBox1.Controls.Add(this.focusLabel2);
			this.groupBox1.Location = new Point(16, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(200, 136);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Grid-Lines Mirror (DataView-Name)";
			this.GridLinesMirrorHorizontalTextBox.LoadingBegin();
			this.GridLinesMirrorHorizontalTextBox.Location = new Point(72, 56);
			this.GridLinesMirrorHorizontalTextBox.Name = "GridLinesMirrorHorizontalTextBox";
			this.GridLinesMirrorHorizontalTextBox.PropertyName = "GridLinesMirrorHorizontal";
			this.GridLinesMirrorHorizontalTextBox.Size = new Size(112, 20);
			this.GridLinesMirrorHorizontalTextBox.TabIndex = 1;
			this.GridLinesMirrorHorizontalTextBox.LoadingEnd();
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.GridLinesMirrorHorizontalTextBox;
			this.focusLabel3.Location = new Point(15, 58);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(57, 15);
			this.focusLabel3.Text = "Horizontal";
			this.focusLabel3.LoadingEnd();
			this.GridLinesMirrorVerticalTextBox.LoadingBegin();
			this.GridLinesMirrorVerticalTextBox.Location = new Point(72, 32);
			this.GridLinesMirrorVerticalTextBox.Name = "GridLinesMirrorVerticalTextBox";
			this.GridLinesMirrorVerticalTextBox.PropertyName = "GridLinesMirrorVertical";
			this.GridLinesMirrorVerticalTextBox.Size = new Size(112, 20);
			this.GridLinesMirrorVerticalTextBox.TabIndex = 0;
			this.GridLinesMirrorVerticalTextBox.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.GridLinesMirrorVerticalTextBox;
			this.focusLabel2.Location = new Point(28, 34);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(44, 15);
			this.focusLabel2.Text = "Vertical";
			this.focusLabel2.LoadingEnd();
			this.ContextMenuEnabledCheckBox.Location = new Point(352, 27);
			this.ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			this.ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			this.ContextMenuEnabledCheckBox.Size = new Size(152, 24);
			this.ContextMenuEnabledCheckBox.TabIndex = 7;
			this.ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			this.LayerNumericUpDown.Location = new Point(168, 72);
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
			this.LayerNumericUpDown.TabIndex = 3;
			this.LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.LayerNumericUpDown;
			this.label1.Location = new Point(133, 73);
			this.label1.Name = "label1";
			this.label1.Size = new Size(35, 15);
			this.label1.Text = "Layer";
			this.label1.LoadingEnd();
			this.UserCanEditCheckBox.Location = new Point(248, 51);
			this.UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			this.UserCanEditCheckBox.PropertyName = "UserCanEdit";
			this.UserCanEditCheckBox.Size = new Size(96, 24);
			this.UserCanEditCheckBox.TabIndex = 6;
			this.UserCanEditCheckBox.Text = "User Can Edit";
			this.groupBox2.Controls.Add(this.focusLabel6);
			this.groupBox2.Controls.Add(this.AxesControlKeyboardStyleComboBox);
			this.groupBox2.Controls.Add(this.focusLabel5);
			this.groupBox2.Controls.Add(this.AxesControlWheelStyleComboBox);
			this.groupBox2.Controls.Add(this.focusLabel4);
			this.groupBox2.Controls.Add(this.AxesControlMouseStyleComboBox);
			this.groupBox2.Controls.Add(this.AxesControlEnabledCheckBox);
			this.groupBox2.Location = new Point(232, 112);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(200, 136);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Axes Control";
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.AxesControlKeyboardStyleComboBox;
			this.focusLabel6.Location = new Point(6, 106);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(82, 15);
			this.focusLabel6.Text = "Keyboard Style";
			this.focusLabel6.LoadingEnd();
			this.AxesControlKeyboardStyleComboBox.Location = new Point(88, 104);
			this.AxesControlKeyboardStyleComboBox.Name = "AxesControlKeyboardStyleComboBox";
			this.AxesControlKeyboardStyleComboBox.PropertyName = "AxesControlKeyboardStyle";
			this.AxesControlKeyboardStyleComboBox.Size = new Size(96, 21);
			this.AxesControlKeyboardStyleComboBox.TabIndex = 3;
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.AxesControlWheelStyleComboBox;
			this.focusLabel5.Location = new Point(22, 82);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(66, 15);
			this.focusLabel5.Text = "Wheel Style";
			this.focusLabel5.LoadingEnd();
			this.AxesControlWheelStyleComboBox.Location = new Point(88, 80);
			this.AxesControlWheelStyleComboBox.Name = "AxesControlWheelStyleComboBox";
			this.AxesControlWheelStyleComboBox.PropertyName = "AxesControlWheelStyle";
			this.AxesControlWheelStyleComboBox.Size = new Size(96, 21);
			this.AxesControlWheelStyleComboBox.TabIndex = 2;
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.AxesControlMouseStyleComboBox;
			this.focusLabel4.Location = new Point(20, 58);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(68, 15);
			this.focusLabel4.Text = "Mouse Style";
			this.focusLabel4.LoadingEnd();
			this.AxesControlMouseStyleComboBox.Location = new Point(88, 56);
			this.AxesControlMouseStyleComboBox.Name = "AxesControlMouseStyleComboBox";
			this.AxesControlMouseStyleComboBox.PropertyName = "AxesControlMouseStyle";
			this.AxesControlMouseStyleComboBox.Size = new Size(96, 21);
			this.AxesControlMouseStyleComboBox.TabIndex = 1;
			this.AxesControlEnabledCheckBox.Location = new Point(16, 24);
			this.AxesControlEnabledCheckBox.Name = "AxesControlEnabledCheckBox";
			this.AxesControlEnabledCheckBox.PropertyName = "AxesControlEnabled";
			this.AxesControlEnabledCheckBox.TabIndex = 0;
			this.AxesControlEnabledCheckBox.Text = "Enabled";
			this.TitleTextBox.EditFont = null;
			this.TitleTextBox.Location = new Point(80, 40);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.PropertyName = "TitleText";
			this.TitleTextBox.Size = new Size(144, 20);
			this.TitleTextBox.TabIndex = 1;
			this.focusLabel15.LoadingBegin();
			this.focusLabel15.FocusControl = this.TitleTextBox;
			this.focusLabel15.Location = new Point(27, 43);
			this.focusLabel15.Name = "focusLabel15";
			this.focusLabel15.Size = new Size(53, 15);
			this.focusLabel15.Text = "Title Text";
			this.focusLabel15.LoadingEnd();
			this.CanFocusCheckBox.Location = new Point(352, 51);
			this.CanFocusCheckBox.Name = "CanFocusCheckBox";
			this.CanFocusCheckBox.PropertyName = "CanFocus";
			this.CanFocusCheckBox.Size = new Size(144, 24);
			this.CanFocusCheckBox.TabIndex = 8;
			this.CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(this.CanFocusCheckBox);
			base.Controls.Add(this.TitleTextBox);
			base.Controls.Add(this.focusLabel15);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.UserCanEditCheckBox);
			base.Controls.Add(this.LayerNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ContextMenuEnabledCheckBox);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.NameTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotDataViewEditorPlugIn";
			base.Size = new Size(656, 280);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotFillGridEditorPlugIn(), "Fill-Inside", false);
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill-Outside", false);
			base.AddSubPlugIn(new PlotLayoutDataViewEditorPlugIn(), "Dock", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotDataView).FillInside;
			base.SubPlugIns[1].Value = (base.Value as PlotDataView).FillOutside;
			base.SubPlugIns[2].Value = base.Value;
		}
	}
}
