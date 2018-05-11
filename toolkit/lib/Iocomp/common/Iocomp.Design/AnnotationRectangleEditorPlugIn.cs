using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class AnnotationRectangleEditorPlugIn : PlugInStandard
	{
		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanMoveCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanSizeCheckBox;

		private FocusLabel label7;

		private EditBox WidthTextBox;

		private EditBox HeightTextBox;

		private EditBox XTextBox;

		private FocusLabel label8;

		private EditBox YTextBox;

		private FocusLabel label9;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private EditBox RotationTextBox;

		private FocusLabel focusLabel1;

		private GroupBox groupBox1;

		private Iocomp.Design.Plugin.EditorControls.ComboBox FillStyleComboBox;

		private FocusLabel focusLabel2;

		private ColorPicker FillColorPicker;

		private FocusLabel focusLabel3;

		private GroupBox groupBox2;

		private ColorPicker OutlineColorPicker;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox OutlineStyleComboBox;

		private FocusLabel focusLabel5;

		private GroupBox groupBox3;

		private ColorPicker HatchBackColorPicker;

		private FocusLabel focusLabel6;

		private ColorPicker HatchForeColorPicker;

		private FocusLabel focusLabel7;

		private GroupBox groupBox4;

		private ColorPicker GradientStartColorPicker;

		private FocusLabel focusLabel8;

		private ColorPicker GradientStopColorPicker;

		private FocusLabel focusLabel9;

		private Container components;

		public AnnotationRectangleEditorPlugIn()
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
			this.label1 = new FocusLabel();
			this.HeightTextBox = new EditBox();
			this.CanMoveCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.CanSizeCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.label7 = new FocusLabel();
			this.WidthTextBox = new EditBox();
			this.XTextBox = new EditBox();
			this.label8 = new FocusLabel();
			this.YTextBox = new EditBox();
			this.label9 = new FocusLabel();
			this.EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.RotationTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.groupBox1 = new GroupBox();
			this.FillColorPicker = new ColorPicker();
			this.focusLabel3 = new FocusLabel();
			this.FillStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel2 = new FocusLabel();
			this.groupBox2 = new GroupBox();
			this.OutlineColorPicker = new ColorPicker();
			this.focusLabel4 = new FocusLabel();
			this.OutlineStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel5 = new FocusLabel();
			this.groupBox3 = new GroupBox();
			this.HatchForeColorPicker = new ColorPicker();
			this.focusLabel7 = new FocusLabel();
			this.HatchBackColorPicker = new ColorPicker();
			this.focusLabel6 = new FocusLabel();
			this.groupBox4 = new GroupBox();
			this.GradientStartColorPicker = new ColorPicker();
			this.focusLabel8 = new FocusLabel();
			this.GradientStopColorPicker = new ColorPicker();
			this.focusLabel9 = new FocusLabel();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			base.SuspendLayout();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.HeightTextBox;
			this.label1.Location = new Point(9, 122);
			this.label1.Name = "label1";
			this.label1.Size = new Size(39, 15);
			this.label1.Text = "Height";
			this.label1.LoadingEnd();
			this.HeightTextBox.LoadingBegin();
			this.HeightTextBox.Location = new Point(48, 120);
			this.HeightTextBox.Name = "HeightTextBox";
			this.HeightTextBox.PropertyName = "Height";
			this.HeightTextBox.Size = new Size(48, 20);
			this.HeightTextBox.TabIndex = 7;
			this.HeightTextBox.LoadingEnd();
			this.CanMoveCheckBox.Location = new Point(232, 8);
			this.CanMoveCheckBox.Name = "CanMoveCheckBox";
			this.CanMoveCheckBox.PropertyName = "CanMove";
			this.CanMoveCheckBox.Size = new Size(80, 24);
			this.CanMoveCheckBox.TabIndex = 2;
			this.CanMoveCheckBox.Text = "Can Move";
			this.CanSizeCheckBox.Location = new Point(328, 8);
			this.CanSizeCheckBox.Name = "CanSizeCheckBox";
			this.CanSizeCheckBox.PropertyName = "CanSize";
			this.CanSizeCheckBox.Size = new Size(72, 24);
			this.CanSizeCheckBox.TabIndex = 3;
			this.CanSizeCheckBox.Text = "Can Size";
			this.label7.LoadingBegin();
			this.label7.FocusControl = this.WidthTextBox;
			this.label7.Location = new Point(12, 98);
			this.label7.Name = "label7";
			this.label7.Size = new Size(36, 15);
			this.label7.Text = "Width";
			this.label7.LoadingEnd();
			this.WidthTextBox.LoadingBegin();
			this.WidthTextBox.Location = new Point(48, 96);
			this.WidthTextBox.Name = "WidthTextBox";
			this.WidthTextBox.PropertyName = "Width";
			this.WidthTextBox.Size = new Size(48, 20);
			this.WidthTextBox.TabIndex = 6;
			this.WidthTextBox.LoadingEnd();
			this.XTextBox.LoadingBegin();
			this.XTextBox.Location = new Point(48, 48);
			this.XTextBox.Name = "XTextBox";
			this.XTextBox.PropertyName = "X";
			this.XTextBox.Size = new Size(48, 20);
			this.XTextBox.TabIndex = 4;
			this.XTextBox.LoadingEnd();
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.XTextBox;
			this.label8.Location = new Point(33, 50);
			this.label8.Name = "label8";
			this.label8.Size = new Size(15, 15);
			this.label8.Text = "X";
			this.label8.LoadingEnd();
			this.YTextBox.LoadingBegin();
			this.YTextBox.Location = new Point(48, 72);
			this.YTextBox.Name = "YTextBox";
			this.YTextBox.PropertyName = "Y";
			this.YTextBox.Size = new Size(48, 20);
			this.YTextBox.TabIndex = 5;
			this.YTextBox.LoadingEnd();
			this.label9.LoadingBegin();
			this.label9.FocusControl = this.YTextBox;
			this.label9.Location = new Point(33, 74);
			this.label9.Name = "label9";
			this.label9.Size = new Size(15, 15);
			this.label9.Text = "Y";
			this.label9.LoadingEnd();
			this.EnabledCheckBox.Location = new Point(136, 8);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(72, 24);
			this.EnabledCheckBox.TabIndex = 1;
			this.EnabledCheckBox.Text = "Enabled";
			this.VisibleCheckBox.Location = new Point(48, 8);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.RotationTextBox.LoadingBegin();
			this.RotationTextBox.Location = new Point(48, 144);
			this.RotationTextBox.Name = "RotationTextBox";
			this.RotationTextBox.PropertyName = "Rotation";
			this.RotationTextBox.Size = new Size(48, 20);
			this.RotationTextBox.TabIndex = 8;
			this.RotationTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.RotationTextBox;
			this.focusLabel1.Location = new Point(-1, 146);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(49, 15);
			this.focusLabel1.Text = "Rotation";
			this.focusLabel1.LoadingEnd();
			this.groupBox1.Controls.Add(this.FillColorPicker);
			this.groupBox1.Controls.Add(this.focusLabel3);
			this.groupBox1.Controls.Add(this.FillStyleComboBox);
			this.groupBox1.Controls.Add(this.focusLabel2);
			this.groupBox1.Location = new Point(112, 139);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(224, 88);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Fill";
			this.FillColorPicker.Location = new Point(48, 56);
			this.FillColorPicker.Name = "FillColorPicker";
			this.FillColorPicker.PropertyName = "FillColor";
			this.FillColorPicker.Size = new Size(48, 21);
			this.FillColorPicker.Style = ColorPickerStyle.ColorBox;
			this.FillColorPicker.TabIndex = 1;
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.FillColorPicker;
			this.focusLabel3.Location = new Point(14, 59);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(34, 15);
			this.focusLabel3.Text = "Color";
			this.focusLabel3.LoadingEnd();
			this.FillStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.FillStyleComboBox.Location = new Point(48, 24);
			this.FillStyleComboBox.Name = "FillStyleComboBox";
			this.FillStyleComboBox.PropertyName = "FillStyle";
			this.FillStyleComboBox.Size = new Size(168, 21);
			this.FillStyleComboBox.TabIndex = 0;
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.FillStyleComboBox;
			this.focusLabel2.Location = new Point(16, 26);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(32, 15);
			this.focusLabel2.Text = "Style";
			this.focusLabel2.LoadingEnd();
			this.groupBox2.Controls.Add(this.OutlineColorPicker);
			this.groupBox2.Controls.Add(this.focusLabel4);
			this.groupBox2.Controls.Add(this.OutlineStyleComboBox);
			this.groupBox2.Controls.Add(this.focusLabel5);
			this.groupBox2.Location = new Point(112, 43);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(224, 88);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Outline";
			this.OutlineColorPicker.Location = new Point(48, 56);
			this.OutlineColorPicker.Name = "OutlineColorPicker";
			this.OutlineColorPicker.PropertyName = "OutlineColor";
			this.OutlineColorPicker.Size = new Size(48, 21);
			this.OutlineColorPicker.Style = ColorPickerStyle.ColorBox;
			this.OutlineColorPicker.TabIndex = 1;
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.OutlineColorPicker;
			this.focusLabel4.Location = new Point(14, 59);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(34, 15);
			this.focusLabel4.Text = "Color";
			this.focusLabel4.LoadingEnd();
			this.OutlineStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.OutlineStyleComboBox.Location = new Point(48, 24);
			this.OutlineStyleComboBox.Name = "OutlineStyleComboBox";
			this.OutlineStyleComboBox.PropertyName = "OutlineStyle";
			this.OutlineStyleComboBox.Size = new Size(168, 21);
			this.OutlineStyleComboBox.TabIndex = 0;
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.OutlineStyleComboBox;
			this.focusLabel5.Location = new Point(16, 26);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(32, 15);
			this.focusLabel5.Text = "Style";
			this.focusLabel5.LoadingEnd();
			this.groupBox3.Controls.Add(this.HatchForeColorPicker);
			this.groupBox3.Controls.Add(this.focusLabel7);
			this.groupBox3.Controls.Add(this.HatchBackColorPicker);
			this.groupBox3.Controls.Add(this.focusLabel6);
			this.groupBox3.Location = new Point(344, 139);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(136, 88);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Hatch";
			this.HatchForeColorPicker.Location = new Point(72, 24);
			this.HatchForeColorPicker.Name = "HatchForeColorPicker";
			this.HatchForeColorPicker.PropertyName = "HatchForeColor";
			this.HatchForeColorPicker.Size = new Size(48, 21);
			this.HatchForeColorPicker.Style = ColorPickerStyle.ColorBox;
			this.HatchForeColorPicker.TabIndex = 0;
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.HatchForeColorPicker;
			this.focusLabel7.Location = new Point(13, 27);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(59, 15);
			this.focusLabel7.Text = "Fore Color";
			this.focusLabel7.LoadingEnd();
			this.HatchBackColorPicker.Location = new Point(72, 56);
			this.HatchBackColorPicker.Name = "HatchBackColorPicker";
			this.HatchBackColorPicker.PropertyName = "HatchBackColor";
			this.HatchBackColorPicker.Size = new Size(48, 21);
			this.HatchBackColorPicker.Style = ColorPickerStyle.ColorBox;
			this.HatchBackColorPicker.TabIndex = 1;
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.HatchBackColorPicker;
			this.focusLabel6.Location = new Point(11, 59);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(61, 15);
			this.focusLabel6.Text = "Back Color";
			this.focusLabel6.LoadingEnd();
			this.groupBox4.Controls.Add(this.GradientStartColorPicker);
			this.groupBox4.Controls.Add(this.focusLabel8);
			this.groupBox4.Controls.Add(this.GradientStopColorPicker);
			this.groupBox4.Controls.Add(this.focusLabel9);
			this.groupBox4.Location = new Point(344, 43);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new Size(136, 88);
			this.groupBox4.TabIndex = 11;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Gradient";
			this.GradientStartColorPicker.Location = new Point(72, 24);
			this.GradientStartColorPicker.Name = "GradientStartColorPicker";
			this.GradientStartColorPicker.PropertyName = "GradientStartColor";
			this.GradientStartColorPicker.Size = new Size(48, 21);
			this.GradientStartColorPicker.Style = ColorPickerStyle.ColorBox;
			this.GradientStartColorPicker.TabIndex = 0;
			this.focusLabel8.LoadingBegin();
			this.focusLabel8.FocusControl = this.GradientStartColorPicker;
			this.focusLabel8.Location = new Point(12, 27);
			this.focusLabel8.Name = "focusLabel8";
			this.focusLabel8.Size = new Size(60, 15);
			this.focusLabel8.Text = "Start Color";
			this.focusLabel8.LoadingEnd();
			this.GradientStopColorPicker.Location = new Point(72, 56);
			this.GradientStopColorPicker.Name = "GradientStopColorPicker";
			this.GradientStopColorPicker.PropertyName = "GradientStopColor";
			this.GradientStopColorPicker.Size = new Size(48, 21);
			this.GradientStopColorPicker.Style = ColorPickerStyle.ColorBox;
			this.GradientStopColorPicker.TabIndex = 1;
			this.focusLabel9.LoadingBegin();
			this.focusLabel9.FocusControl = this.GradientStopColorPicker;
			this.focusLabel9.Location = new Point(13, 59);
			this.focusLabel9.Name = "focusLabel9";
			this.focusLabel9.Size = new Size(59, 15);
			this.focusLabel9.Text = "Stop Color";
			this.focusLabel9.LoadingEnd();
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.RotationTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.EnabledCheckBox);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.YTextBox);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.XTextBox);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.HeightTextBox);
			base.Controls.Add(this.WidthTextBox);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.CanSizeCheckBox);
			base.Controls.Add(this.CanMoveCheckBox);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.groupBox4);
			base.Location = new Point(10, 20);
			base.Name = "AnnotationRectangleEditorPlugIn";
			base.Size = new Size(528, 272);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
