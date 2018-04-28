using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class AnnotationLineEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanSizeCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanMoveCheckBox;

		private GroupBox groupBox2;

		private ColorPicker OutlineColorPicker;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox OutlineStyleComboBox;

		private FocusLabel focusLabel5;

		private GroupBox Point1GroupBox;

		private EditBox Point1YTextBox;

		private FocusLabel label12;

		private EditBox Point1XTextBox;

		private FocusLabel label11;

		private GroupBox groupBox1;

		private EditBox Point2YTextBox;

		private FocusLabel focusLabel2;

		private EditBox Point2XTextBox;

		private FocusLabel focusLabel3;

		private EditBox RotationTextBox;

		private FocusLabel focusLabel1;

		private EditBox YTextBox;

		private FocusLabel label9;

		private EditBox XTextBox;

		private FocusLabel label8;

		private EditBox HeightTextBox;

		private EditBox WidthTextBox;

		private FocusLabel label7;

		private FocusLabel label1;

		private Container components;

		public AnnotationLineEditorPlugIn()
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
			this.EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.CanSizeCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.CanMoveCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.groupBox2 = new GroupBox();
			this.OutlineColorPicker = new ColorPicker();
			this.focusLabel4 = new FocusLabel();
			this.OutlineStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel5 = new FocusLabel();
			this.Point1GroupBox = new GroupBox();
			this.Point1YTextBox = new EditBox();
			this.label12 = new FocusLabel();
			this.Point1XTextBox = new EditBox();
			this.label11 = new FocusLabel();
			this.groupBox1 = new GroupBox();
			this.Point2YTextBox = new EditBox();
			this.focusLabel2 = new FocusLabel();
			this.Point2XTextBox = new EditBox();
			this.focusLabel3 = new FocusLabel();
			this.RotationTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.YTextBox = new EditBox();
			this.label9 = new FocusLabel();
			this.XTextBox = new EditBox();
			this.label8 = new FocusLabel();
			this.HeightTextBox = new EditBox();
			this.WidthTextBox = new EditBox();
			this.label7 = new FocusLabel();
			this.label1 = new FocusLabel();
			this.groupBox2.SuspendLayout();
			this.Point1GroupBox.SuspendLayout();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.EnabledCheckBox.Location = new Point(144, 16);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(72, 24);
			this.EnabledCheckBox.TabIndex = 1;
			this.EnabledCheckBox.Text = "Enabled";
			this.VisibleCheckBox.Location = new Point(56, 16);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.CanSizeCheckBox.Location = new Point(328, 16);
			this.CanSizeCheckBox.Name = "CanSizeCheckBox";
			this.CanSizeCheckBox.PropertyName = "CanSize";
			this.CanSizeCheckBox.Size = new Size(72, 24);
			this.CanSizeCheckBox.TabIndex = 3;
			this.CanSizeCheckBox.Text = "Can Size";
			this.CanMoveCheckBox.Location = new Point(240, 16);
			this.CanMoveCheckBox.Name = "CanMoveCheckBox";
			this.CanMoveCheckBox.PropertyName = "CanMove";
			this.CanMoveCheckBox.Size = new Size(80, 24);
			this.CanMoveCheckBox.TabIndex = 2;
			this.CanMoveCheckBox.Text = "Can Move";
			this.groupBox2.Controls.Add(this.OutlineColorPicker);
			this.groupBox2.Controls.Add(this.focusLabel4);
			this.groupBox2.Controls.Add(this.OutlineStyleComboBox);
			this.groupBox2.Controls.Add(this.focusLabel5);
			this.groupBox2.Location = new Point(296, 50);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(208, 124);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Outline";
			this.OutlineColorPicker.Location = new Point(48, 72);
			this.OutlineColorPicker.Name = "OutlineColorPicker";
			this.OutlineColorPicker.PropertyName = "OutlineColor";
			this.OutlineColorPicker.Size = new Size(144, 21);
			this.OutlineColorPicker.TabIndex = 1;
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.OutlineColorPicker;
			this.focusLabel4.Location = new Point(14, 75);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(34, 15);
			this.focusLabel4.Text = "Color";
			this.focusLabel4.LoadingEnd();
			this.OutlineStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.OutlineStyleComboBox.Location = new Point(48, 40);
			this.OutlineStyleComboBox.Name = "OutlineStyleComboBox";
			this.OutlineStyleComboBox.PropertyName = "OutlineStyle";
			this.OutlineStyleComboBox.Size = new Size(144, 21);
			this.OutlineStyleComboBox.TabIndex = 0;
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.OutlineStyleComboBox;
			this.focusLabel5.Location = new Point(16, 42);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(32, 15);
			this.focusLabel5.Text = "Style";
			this.focusLabel5.LoadingEnd();
			this.Point1GroupBox.Controls.Add(this.Point1YTextBox);
			this.Point1GroupBox.Controls.Add(this.label12);
			this.Point1GroupBox.Controls.Add(this.Point1XTextBox);
			this.Point1GroupBox.Controls.Add(this.label11);
			this.Point1GroupBox.Location = new Point(120, 50);
			this.Point1GroupBox.Name = "Point1GroupBox";
			this.Point1GroupBox.Size = new Size(168, 56);
			this.Point1GroupBox.TabIndex = 9;
			this.Point1GroupBox.TabStop = false;
			this.Point1GroupBox.Text = "Point 1";
			this.Point1YTextBox.LoadingBegin();
			this.Point1YTextBox.Location = new Point(104, 24);
			this.Point1YTextBox.Name = "Point1YTextBox";
			this.Point1YTextBox.PropertyName = "Point1Y";
			this.Point1YTextBox.Size = new Size(48, 20);
			this.Point1YTextBox.TabIndex = 1;
			this.Point1YTextBox.LoadingEnd();
			this.label12.LoadingBegin();
			this.label12.FocusControl = this.Point1YTextBox;
			this.label12.Location = new Point(89, 26);
			this.label12.Name = "label12";
			this.label12.Size = new Size(15, 15);
			this.label12.Text = "Y";
			this.label12.LoadingEnd();
			this.Point1XTextBox.LoadingBegin();
			this.Point1XTextBox.Location = new Point(32, 24);
			this.Point1XTextBox.Name = "Point1XTextBox";
			this.Point1XTextBox.PropertyName = "Point1X";
			this.Point1XTextBox.Size = new Size(48, 20);
			this.Point1XTextBox.TabIndex = 0;
			this.Point1XTextBox.LoadingEnd();
			this.label11.LoadingBegin();
			this.label11.FocusControl = this.Point1XTextBox;
			this.label11.Location = new Point(17, 26);
			this.label11.Name = "label11";
			this.label11.Size = new Size(15, 15);
			this.label11.Text = "X";
			this.label11.LoadingEnd();
			this.groupBox1.Controls.Add(this.Point2YTextBox);
			this.groupBox1.Controls.Add(this.focusLabel2);
			this.groupBox1.Controls.Add(this.Point2XTextBox);
			this.groupBox1.Controls.Add(this.focusLabel3);
			this.groupBox1.Location = new Point(120, 118);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(168, 56);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Point 2";
			this.Point2YTextBox.LoadingBegin();
			this.Point2YTextBox.Location = new Point(104, 24);
			this.Point2YTextBox.Name = "Point2YTextBox";
			this.Point2YTextBox.PropertyName = "Point2Y";
			this.Point2YTextBox.Size = new Size(48, 20);
			this.Point2YTextBox.TabIndex = 1;
			this.Point2YTextBox.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.Point2YTextBox;
			this.focusLabel2.Location = new Point(89, 26);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(15, 15);
			this.focusLabel2.Text = "Y";
			this.focusLabel2.LoadingEnd();
			this.Point2XTextBox.LoadingBegin();
			this.Point2XTextBox.Location = new Point(32, 24);
			this.Point2XTextBox.Name = "Point2XTextBox";
			this.Point2XTextBox.PropertyName = "Point2X";
			this.Point2XTextBox.Size = new Size(48, 20);
			this.Point2XTextBox.TabIndex = 0;
			this.Point2XTextBox.LoadingEnd();
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.Point2XTextBox;
			this.focusLabel3.Location = new Point(17, 26);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(15, 15);
			this.focusLabel3.Text = "X";
			this.focusLabel3.LoadingEnd();
			this.RotationTextBox.LoadingBegin();
			this.RotationTextBox.Location = new Point(56, 152);
			this.RotationTextBox.Name = "RotationTextBox";
			this.RotationTextBox.PropertyName = "Rotation";
			this.RotationTextBox.Size = new Size(48, 20);
			this.RotationTextBox.TabIndex = 8;
			this.RotationTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.RotationTextBox;
			this.focusLabel1.Location = new Point(7, 154);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(49, 15);
			this.focusLabel1.Text = "Rotation";
			this.focusLabel1.LoadingEnd();
			this.YTextBox.LoadingBegin();
			this.YTextBox.Location = new Point(56, 80);
			this.YTextBox.Name = "YTextBox";
			this.YTextBox.PropertyName = "Y";
			this.YTextBox.Size = new Size(48, 20);
			this.YTextBox.TabIndex = 5;
			this.YTextBox.LoadingEnd();
			this.label9.LoadingBegin();
			this.label9.FocusControl = this.YTextBox;
			this.label9.Location = new Point(41, 82);
			this.label9.Name = "label9";
			this.label9.Size = new Size(15, 15);
			this.label9.Text = "Y";
			this.label9.LoadingEnd();
			this.XTextBox.LoadingBegin();
			this.XTextBox.Location = new Point(56, 56);
			this.XTextBox.Name = "XTextBox";
			this.XTextBox.PropertyName = "X";
			this.XTextBox.Size = new Size(48, 20);
			this.XTextBox.TabIndex = 4;
			this.XTextBox.LoadingEnd();
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.XTextBox;
			this.label8.Location = new Point(41, 58);
			this.label8.Name = "label8";
			this.label8.Size = new Size(15, 15);
			this.label8.Text = "X";
			this.label8.LoadingEnd();
			this.HeightTextBox.LoadingBegin();
			this.HeightTextBox.Location = new Point(56, 128);
			this.HeightTextBox.Name = "HeightTextBox";
			this.HeightTextBox.PropertyName = "Height";
			this.HeightTextBox.Size = new Size(48, 20);
			this.HeightTextBox.TabIndex = 7;
			this.HeightTextBox.LoadingEnd();
			this.WidthTextBox.LoadingBegin();
			this.WidthTextBox.Location = new Point(56, 104);
			this.WidthTextBox.Name = "WidthTextBox";
			this.WidthTextBox.PropertyName = "Width";
			this.WidthTextBox.Size = new Size(48, 20);
			this.WidthTextBox.TabIndex = 6;
			this.WidthTextBox.LoadingEnd();
			this.label7.LoadingBegin();
			this.label7.FocusControl = this.WidthTextBox;
			this.label7.Location = new Point(20, 106);
			this.label7.Name = "label7";
			this.label7.Size = new Size(36, 15);
			this.label7.Text = "Width";
			this.label7.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.HeightTextBox;
			this.label1.Location = new Point(17, 130);
			this.label1.Name = "label1";
			this.label1.Size = new Size(39, 15);
			this.label1.Text = "Height";
			this.label1.LoadingEnd();
			base.Controls.Add(this.RotationTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.YTextBox);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.XTextBox);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.HeightTextBox);
			base.Controls.Add(this.WidthTextBox);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.Point1GroupBox);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.EnabledCheckBox);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.CanSizeCheckBox);
			base.Controls.Add(this.CanMoveCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "AnnotationLineEditorPlugIn";
			base.Size = new Size(536, 208);
			this.groupBox2.ResumeLayout(false);
			this.Point1GroupBox.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
