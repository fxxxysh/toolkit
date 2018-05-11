using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class AnnotationTextEditorPlugIn : PlugInStandard
	{
		private FocusLabel label1;

		private CheckBox CanMoveCheckBox;

		private CheckBox CanSizeCheckBox;

		private FocusLabel label7;

		private EditBox WidthTextBox;

		private EditBox HeightTextBox;

		private EditBox XTextBox;

		private FocusLabel label8;

		private EditBox YTextBox;

		private FocusLabel label9;

		private CheckBox EnabledCheckBox;

		private CheckBox VisibleCheckBox;

		private EditBox RotationTextBox;

		private FocusLabel focusLabel1;

		private CheckBox FixedSizeCheckBox;

		private FocusLabel focusLabel2;

		private EditMultiLine TextEditMultiLine;

		private FontButton FontButton;

		private FocusLabel focusLabel11;

		private ColorPicker ForeColorPicker;

		private Container components;

		public AnnotationTextEditorPlugIn()
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
			this.CanMoveCheckBox = new CheckBox();
			this.CanSizeCheckBox = new CheckBox();
			this.label7 = new FocusLabel();
			this.WidthTextBox = new EditBox();
			this.XTextBox = new EditBox();
			this.label8 = new FocusLabel();
			this.YTextBox = new EditBox();
			this.label9 = new FocusLabel();
			this.EnabledCheckBox = new CheckBox();
			this.VisibleCheckBox = new CheckBox();
			this.RotationTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.FixedSizeCheckBox = new CheckBox();
			this.focusLabel2 = new FocusLabel();
			this.TextEditMultiLine = new EditMultiLine();
			this.FontButton = new FontButton();
			this.focusLabel11 = new FocusLabel();
			this.ForeColorPicker = new ColorPicker();
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
			this.FixedSizeCheckBox.Location = new Point(432, 8);
			this.FixedSizeCheckBox.Name = "FixedSizeCheckBox";
			this.FixedSizeCheckBox.PropertyName = "FixedSize";
			this.FixedSizeCheckBox.Size = new Size(80, 24);
			this.FixedSizeCheckBox.TabIndex = 4;
			this.FixedSizeCheckBox.Text = "Fixed Size";
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.TextEditMultiLine;
			this.focusLabel2.Location = new Point(147, 51);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(29, 15);
			this.focusLabel2.Text = "Text";
			this.focusLabel2.LoadingEnd();
			this.TextEditMultiLine.EditFont = null;
			this.TextEditMultiLine.Location = new Point(176, 48);
			this.TextEditMultiLine.Name = "TextEditMultiLine";
			this.TextEditMultiLine.PropertyName = "Text";
			this.TextEditMultiLine.Size = new Size(320, 20);
			this.TextEditMultiLine.TabIndex = 10;
			this.FontButton.Location = new Point(176, 80);
			this.FontButton.Name = "FontButton";
			this.FontButton.PropertyName = "Font";
			this.FontButton.Size = new Size(72, 23);
			this.FontButton.TabIndex = 11;
			this.focusLabel11.LoadingBegin();
			this.focusLabel11.FocusControl = this.ForeColorPicker;
			this.focusLabel11.Location = new Point(261, 83);
			this.focusLabel11.Name = "focusLabel11";
			this.focusLabel11.Size = new Size(59, 15);
			this.focusLabel11.Text = "Fore Color";
			this.focusLabel11.LoadingEnd();
			this.ForeColorPicker.Location = new Point(320, 80);
			this.ForeColorPicker.Name = "ForeColorPicker";
			this.ForeColorPicker.PropertyName = "ForeColor";
			this.ForeColorPicker.Size = new Size(49, 21);
			this.ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ForeColorPicker.TabIndex = 12;
			base.Controls.Add(this.FontButton);
			base.Controls.Add(this.focusLabel11);
			base.Controls.Add(this.ForeColorPicker);
			base.Controls.Add(this.TextEditMultiLine);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.FixedSizeCheckBox);
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
			base.Name = "AnnotationTextEditorPlugIn";
			base.Size = new Size(528, 272);
			base.ResumeLayout(false);
		}
	}
}
