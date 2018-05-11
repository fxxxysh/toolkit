using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class AnnotationImageEditorPlugIn : PlugInStandard
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

		private FocusLabel focusLabel5;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown ImageIndexUpDown;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.CheckBox FixedSizeCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ImageListStyleComboBox;

		private Container components;

		public AnnotationImageEditorPlugIn()
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
			this.ImageIndexUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.focusLabel4 = new FocusLabel();
			this.ImageListStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel5 = new FocusLabel();
			this.FixedSizeCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.HeightTextBox;
			this.label1.Location = new Point(25, 122);
			this.label1.Name = "label1";
			this.label1.Size = new Size(39, 15);
			this.label1.Text = "Height";
			this.label1.LoadingEnd();
			this.HeightTextBox.LoadingBegin();
			this.HeightTextBox.Location = new Point(64, 120);
			this.HeightTextBox.Name = "HeightTextBox";
			this.HeightTextBox.PropertyName = "Height";
			this.HeightTextBox.Size = new Size(48, 20);
			this.HeightTextBox.TabIndex = 8;
			this.HeightTextBox.LoadingEnd();
			this.CanMoveCheckBox.Location = new Point(248, 8);
			this.CanMoveCheckBox.Name = "CanMoveCheckBox";
			this.CanMoveCheckBox.PropertyName = "CanMove";
			this.CanMoveCheckBox.Size = new Size(80, 24);
			this.CanMoveCheckBox.TabIndex = 2;
			this.CanMoveCheckBox.Text = "Can Move";
			this.CanSizeCheckBox.Location = new Point(344, 8);
			this.CanSizeCheckBox.Name = "CanSizeCheckBox";
			this.CanSizeCheckBox.PropertyName = "CanSize";
			this.CanSizeCheckBox.Size = new Size(72, 24);
			this.CanSizeCheckBox.TabIndex = 3;
			this.CanSizeCheckBox.Text = "Can Size";
			this.label7.LoadingBegin();
			this.label7.FocusControl = this.WidthTextBox;
			this.label7.Location = new Point(28, 98);
			this.label7.Name = "label7";
			this.label7.Size = new Size(36, 15);
			this.label7.Text = "Width";
			this.label7.LoadingEnd();
			this.WidthTextBox.LoadingBegin();
			this.WidthTextBox.Location = new Point(64, 96);
			this.WidthTextBox.Name = "WidthTextBox";
			this.WidthTextBox.PropertyName = "Width";
			this.WidthTextBox.Size = new Size(48, 20);
			this.WidthTextBox.TabIndex = 7;
			this.WidthTextBox.LoadingEnd();
			this.XTextBox.LoadingBegin();
			this.XTextBox.Location = new Point(64, 48);
			this.XTextBox.Name = "XTextBox";
			this.XTextBox.PropertyName = "X";
			this.XTextBox.Size = new Size(48, 20);
			this.XTextBox.TabIndex = 5;
			this.XTextBox.LoadingEnd();
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.XTextBox;
			this.label8.Location = new Point(49, 50);
			this.label8.Name = "label8";
			this.label8.Size = new Size(15, 15);
			this.label8.Text = "X";
			this.label8.LoadingEnd();
			this.YTextBox.LoadingBegin();
			this.YTextBox.Location = new Point(64, 72);
			this.YTextBox.Name = "YTextBox";
			this.YTextBox.PropertyName = "Y";
			this.YTextBox.Size = new Size(48, 20);
			this.YTextBox.TabIndex = 6;
			this.YTextBox.LoadingEnd();
			this.label9.LoadingBegin();
			this.label9.FocusControl = this.YTextBox;
			this.label9.Location = new Point(49, 74);
			this.label9.Name = "label9";
			this.label9.Size = new Size(15, 15);
			this.label9.Text = "Y";
			this.label9.LoadingEnd();
			this.EnabledCheckBox.Location = new Point(152, 8);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(72, 24);
			this.EnabledCheckBox.TabIndex = 1;
			this.EnabledCheckBox.Text = "Enabled";
			this.VisibleCheckBox.Location = new Point(64, 8);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.RotationTextBox.LoadingBegin();
			this.RotationTextBox.Location = new Point(64, 144);
			this.RotationTextBox.Name = "RotationTextBox";
			this.RotationTextBox.PropertyName = "Rotation";
			this.RotationTextBox.Size = new Size(48, 20);
			this.RotationTextBox.TabIndex = 9;
			this.RotationTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.RotationTextBox;
			this.focusLabel1.Location = new Point(15, 146);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(49, 15);
			this.focusLabel1.Text = "Rotation";
			this.focusLabel1.LoadingEnd();
			this.groupBox2.Controls.Add(this.ImageIndexUpDown);
			this.groupBox2.Controls.Add(this.focusLabel4);
			this.groupBox2.Controls.Add(this.ImageListStyleComboBox);
			this.groupBox2.Controls.Add(this.focusLabel5);
			this.groupBox2.Location = new Point(128, 42);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(264, 88);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Image";
			this.ImageIndexUpDown.Location = new Point(64, 56);
			this.ImageIndexUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			this.ImageIndexUpDown.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				-2147483648
			});
			this.ImageIndexUpDown.Name = "ImageIndexUpDown";
			this.ImageIndexUpDown.PropertyName = "ImageIndex";
			this.ImageIndexUpDown.Size = new Size(56, 20);
			this.ImageIndexUpDown.TabIndex = 1;
			this.ImageIndexUpDown.TextAlign = HorizontalAlignment.Center;
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.ImageIndexUpDown;
			this.focusLabel4.Location = new Point(30, 57);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(34, 15);
			this.focusLabel4.Text = "Index";
			this.focusLabel4.LoadingEnd();
			this.ImageListStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ImageListStyleComboBox.Location = new Point(64, 24);
			this.ImageListStyleComboBox.Name = "ImageListStyleComboBox";
			this.ImageListStyleComboBox.PropertyName = "ImageListStyle";
			this.ImageListStyleComboBox.Size = new Size(144, 21);
			this.ImageListStyleComboBox.TabIndex = 0;
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.ImageListStyleComboBox;
			this.focusLabel5.Location = new Point(12, 26);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(52, 15);
			this.focusLabel5.Text = "List Style";
			this.focusLabel5.LoadingEnd();
			this.FixedSizeCheckBox.Location = new Point(432, 8);
			this.FixedSizeCheckBox.Name = "FixedSizeCheckBox";
			this.FixedSizeCheckBox.PropertyName = "FixedSize";
			this.FixedSizeCheckBox.Size = new Size(96, 24);
			this.FixedSizeCheckBox.TabIndex = 4;
			this.FixedSizeCheckBox.Text = "Fixed Size";
			base.Controls.Add(this.FixedSizeCheckBox);
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
			base.Name = "AnnotationImageEditorPlugIn";
			base.Size = new Size(528, 272);
			this.groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
