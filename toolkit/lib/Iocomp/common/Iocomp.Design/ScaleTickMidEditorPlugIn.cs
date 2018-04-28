using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class ScaleTickMidEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.NumericUpDown ThicknessNumericUpDown;

		private FocusLabel label10;

		private FocusLabel label7;

		private GroupBox groupBox1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox TextVisibleCheckBox;

		private FocusLabel label6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox AlignmentComboBox;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LengthNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown TextMarginNumericUpDown;

		private FocusLabel label9;

		private FocusLabel label8;

		private FontButton FontButton;

		private ColorPicker ForeColorPicker;

		private ColorPicker ColorPicker;

		private Container components;

		public ScaleTickMidEditorPlugIn()
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
			this.ThicknessNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label10 = new FocusLabel();
			this.label7 = new FocusLabel();
			this.LengthNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.groupBox1 = new GroupBox();
			this.TextMarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.TextVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.label6 = new FocusLabel();
			this.AlignmentComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label1 = new FocusLabel();
			this.FontButton = new FontButton();
			this.ForeColorPicker = new ColorPicker();
			this.ColorPicker = new ColorPicker();
			this.label9 = new FocusLabel();
			this.label8 = new FocusLabel();
			((ISupportInitialize)this.ThicknessNumericUpDown).BeginInit();
			((ISupportInitialize)this.LengthNumericUpDown).BeginInit();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.TextMarginNumericUpDown).BeginInit();
			base.SuspendLayout();
			this.ThicknessNumericUpDown.Location = new Point(88, 88);
			this.ThicknessNumericUpDown.Name = "ThicknessNumericUpDown";
			this.ThicknessNumericUpDown.PropertyName = "Thickness";
			this.ThicknessNumericUpDown.Size = new Size(57, 20);
			this.ThicknessNumericUpDown.TabIndex = 2;
			this.ThicknessNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label10.LoadingBegin();
			this.label10.FocusControl = this.ThicknessNumericUpDown;
			this.label10.Location = new Point(31, 89);
			this.label10.Name = "label10";
			this.label10.Size = new Size(57, 15);
			this.label10.Text = "Thickness";
			this.label10.LoadingEnd();
			this.label7.LoadingBegin();
			this.label7.FocusControl = this.LengthNumericUpDown;
			this.label7.Location = new Point(47, 65);
			this.label7.Name = "label7";
			this.label7.Size = new Size(41, 15);
			this.label7.Text = "Length";
			this.label7.LoadingEnd();
			this.LengthNumericUpDown.Location = new Point(88, 64);
			this.LengthNumericUpDown.Name = "LengthNumericUpDown";
			this.LengthNumericUpDown.PropertyName = "Length";
			this.LengthNumericUpDown.Size = new Size(57, 20);
			this.LengthNumericUpDown.TabIndex = 1;
			this.LengthNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.groupBox1.Controls.Add(this.TextMarginNumericUpDown);
			this.groupBox1.Controls.Add(this.TextVisibleCheckBox);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox1.Location = new Point(248, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(120, 72);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Text";
			this.TextMarginNumericUpDown.Location = new Point(64, 16);
			this.TextMarginNumericUpDown.Name = "TextMarginNumericUpDown";
			this.TextMarginNumericUpDown.PropertyName = "TextMargin";
			this.TextMarginNumericUpDown.Size = new Size(48, 20);
			this.TextMarginNumericUpDown.TabIndex = 0;
			this.TextMarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.TextVisibleCheckBox.Location = new Point(24, 40);
			this.TextVisibleCheckBox.Name = "TextVisibleCheckBox";
			this.TextVisibleCheckBox.PropertyName = "TextVisible";
			this.TextVisibleCheckBox.Size = new Size(62, 24);
			this.TextVisibleCheckBox.TabIndex = 1;
			this.TextVisibleCheckBox.Text = "Visible";
			this.label6.LoadingBegin();
			this.label6.FocusControl = this.TextMarginNumericUpDown;
			this.label6.Location = new Point(23, 17);
			this.label6.Name = "label6";
			this.label6.Size = new Size(41, 15);
			this.label6.Text = "Margin";
			this.label6.LoadingEnd();
			this.AlignmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.AlignmentComboBox.Location = new Point(88, 32);
			this.AlignmentComboBox.Name = "AlignmentComboBox";
			this.AlignmentComboBox.PropertyName = "Alignment";
			this.AlignmentComboBox.Size = new Size(144, 21);
			this.AlignmentComboBox.TabIndex = 0;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.AlignmentComboBox;
			this.label1.Location = new Point(31, 34);
			this.label1.Name = "label1";
			this.label1.Size = new Size(57, 15);
			this.label1.Text = "Alignment";
			this.label1.LoadingEnd();
			this.FontButton.Location = new Point(272, 112);
			this.FontButton.Name = "FontButton";
			this.FontButton.PropertyName = "Font";
			this.FontButton.TabIndex = 6;
			this.ForeColorPicker.Location = new Point(88, 152);
			this.ForeColorPicker.Name = "ForeColorPicker";
			this.ForeColorPicker.PropertyName = "ForeColor";
			this.ForeColorPicker.Size = new Size(144, 21);
			this.ForeColorPicker.TabIndex = 4;
			this.ColorPicker.Location = new Point(88, 128);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(144, 21);
			this.ColorPicker.TabIndex = 3;
			this.label9.LoadingBegin();
			this.label9.FocusControl = this.ColorPicker;
			this.label9.Location = new Point(54, 131);
			this.label9.Name = "label9";
			this.label9.Size = new Size(34, 15);
			this.label9.Text = "Color";
			this.label9.LoadingEnd();
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ForeColorPicker;
			this.label8.Location = new Point(29, 155);
			this.label8.Name = "label8";
			this.label8.Size = new Size(59, 15);
			this.label8.Text = "Fore Color";
			this.label8.LoadingEnd();
			base.Controls.Add(this.ForeColorPicker);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.FontButton);
			base.Controls.Add(this.LengthNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.AlignmentComboBox);
			base.Controls.Add(this.ThicknessNumericUpDown);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.groupBox1);
			base.Name = "ScaleTickMidEditorPlugIn";
			base.Size = new Size(600, 304);
			base.Title = "Tick-Mid Editor";
			((ISupportInitialize)this.ThicknessNumericUpDown).EndInit();
			((ISupportInitialize)this.LengthNumericUpDown).EndInit();
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.TextMarginNumericUpDown).EndInit();
			base.ResumeLayout(false);
		}
	}
}
