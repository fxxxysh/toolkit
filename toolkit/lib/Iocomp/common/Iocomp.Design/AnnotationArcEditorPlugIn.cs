using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class AnnotationArcEditorPlugIn : PlugInStandard
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

		private GroupBox groupBox2;

		private ColorPicker OutlineColorPicker;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox OutlineStyleComboBox;

		private FocusLabel focusLabel5;

		private EditBox StartAngleTextBox;

		private FocusLabel focusLabel2;

		private EditBox SweepAngleTextBox;

		private FocusLabel focusLabel3;

		private Container components;

		public AnnotationArcEditorPlugIn()
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
			this.groupBox2 = new GroupBox();
			this.OutlineColorPicker = new ColorPicker();
			this.focusLabel4 = new FocusLabel();
			this.OutlineStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel5 = new FocusLabel();
			this.StartAngleTextBox = new EditBox();
			this.focusLabel2 = new FocusLabel();
			this.SweepAngleTextBox = new EditBox();
			this.focusLabel3 = new FocusLabel();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.HeightTextBox;
			this.label1.Location = new Point(49, 122);
			this.label1.Name = "label1";
			this.label1.Size = new Size(39, 15);
			this.label1.Text = "Height";
			this.label1.LoadingEnd();
			this.HeightTextBox.LoadingBegin();
			this.HeightTextBox.Location = new Point(88, 120);
			this.HeightTextBox.Name = "HeightTextBox";
			this.HeightTextBox.PropertyName = "Height";
			this.HeightTextBox.Size = new Size(48, 20);
			this.HeightTextBox.TabIndex = 7;
			this.HeightTextBox.LoadingEnd();
			this.CanMoveCheckBox.Location = new Point(272, 8);
			this.CanMoveCheckBox.Name = "CanMoveCheckBox";
			this.CanMoveCheckBox.PropertyName = "CanMove";
			this.CanMoveCheckBox.Size = new Size(80, 24);
			this.CanMoveCheckBox.TabIndex = 2;
			this.CanMoveCheckBox.Text = "Can Move";
			this.CanSizeCheckBox.Location = new Point(368, 8);
			this.CanSizeCheckBox.Name = "CanSizeCheckBox";
			this.CanSizeCheckBox.PropertyName = "CanSize";
			this.CanSizeCheckBox.Size = new Size(72, 24);
			this.CanSizeCheckBox.TabIndex = 3;
			this.CanSizeCheckBox.Text = "Can Size";
			this.label7.LoadingBegin();
			this.label7.FocusControl = this.WidthTextBox;
			this.label7.Location = new Point(52, 98);
			this.label7.Name = "label7";
			this.label7.Size = new Size(36, 15);
			this.label7.Text = "Width";
			this.label7.LoadingEnd();
			this.WidthTextBox.LoadingBegin();
			this.WidthTextBox.Location = new Point(88, 96);
			this.WidthTextBox.Name = "WidthTextBox";
			this.WidthTextBox.PropertyName = "Width";
			this.WidthTextBox.Size = new Size(48, 20);
			this.WidthTextBox.TabIndex = 6;
			this.WidthTextBox.LoadingEnd();
			this.XTextBox.LoadingBegin();
			this.XTextBox.Location = new Point(88, 48);
			this.XTextBox.Name = "XTextBox";
			this.XTextBox.PropertyName = "X";
			this.XTextBox.Size = new Size(48, 20);
			this.XTextBox.TabIndex = 4;
			this.XTextBox.LoadingEnd();
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.XTextBox;
			this.label8.Location = new Point(73, 50);
			this.label8.Name = "label8";
			this.label8.Size = new Size(15, 15);
			this.label8.Text = "X";
			this.label8.LoadingEnd();
			this.YTextBox.LoadingBegin();
			this.YTextBox.Location = new Point(88, 72);
			this.YTextBox.Name = "YTextBox";
			this.YTextBox.PropertyName = "Y";
			this.YTextBox.Size = new Size(48, 20);
			this.YTextBox.TabIndex = 5;
			this.YTextBox.LoadingEnd();
			this.label9.LoadingBegin();
			this.label9.FocusControl = this.YTextBox;
			this.label9.Location = new Point(73, 74);
			this.label9.Name = "label9";
			this.label9.Size = new Size(15, 15);
			this.label9.Text = "Y";
			this.label9.LoadingEnd();
			this.EnabledCheckBox.Location = new Point(176, 8);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(72, 24);
			this.EnabledCheckBox.TabIndex = 1;
			this.EnabledCheckBox.Text = "Enabled";
			this.VisibleCheckBox.Location = new Point(88, 8);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.RotationTextBox.LoadingBegin();
			this.RotationTextBox.Location = new Point(88, 144);
			this.RotationTextBox.Name = "RotationTextBox";
			this.RotationTextBox.PropertyName = "Rotation";
			this.RotationTextBox.Size = new Size(48, 20);
			this.RotationTextBox.TabIndex = 8;
			this.RotationTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.RotationTextBox;
			this.focusLabel1.Location = new Point(39, 146);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(49, 15);
			this.focusLabel1.Text = "Rotation";
			this.focusLabel1.LoadingEnd();
			this.groupBox2.Controls.Add(this.OutlineColorPicker);
			this.groupBox2.Controls.Add(this.focusLabel4);
			this.groupBox2.Controls.Add(this.OutlineStyleComboBox);
			this.groupBox2.Controls.Add(this.focusLabel5);
			this.groupBox2.Location = new Point(152, 42);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(224, 88);
			this.groupBox2.TabIndex = 11;
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
			this.StartAngleTextBox.LoadingBegin();
			this.StartAngleTextBox.Location = new Point(88, 168);
			this.StartAngleTextBox.Name = "StartAngleTextBox";
			this.StartAngleTextBox.PropertyName = "StartAngle";
			this.StartAngleTextBox.Size = new Size(48, 20);
			this.StartAngleTextBox.TabIndex = 9;
			this.StartAngleTextBox.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.StartAngleTextBox;
			this.focusLabel2.Location = new Point(26, 170);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(62, 15);
			this.focusLabel2.Text = "Start Angle";
			this.focusLabel2.LoadingEnd();
			this.SweepAngleTextBox.LoadingBegin();
			this.SweepAngleTextBox.Location = new Point(88, 192);
			this.SweepAngleTextBox.Name = "SweepAngleTextBox";
			this.SweepAngleTextBox.PropertyName = "SweepAngle";
			this.SweepAngleTextBox.Size = new Size(48, 20);
			this.SweepAngleTextBox.TabIndex = 10;
			this.SweepAngleTextBox.LoadingEnd();
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.SweepAngleTextBox;
			this.focusLabel3.Location = new Point(16, 194);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(72, 15);
			this.focusLabel3.Text = "Sweep Angle";
			this.focusLabel3.LoadingEnd();
			base.Controls.Add(this.SweepAngleTextBox);
			base.Controls.Add(this.focusLabel3);
			base.Controls.Add(this.StartAngleTextBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.groupBox2);
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
			base.Location = new Point(10, 20);
			base.Name = "AnnotationArcEditorPlugIn";
			base.Size = new Size(528, 272);
			this.groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
