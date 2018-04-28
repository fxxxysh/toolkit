using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleTickMajorEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.NumericUpDown ThicknessNumericUpDown;

		private FocusLabel label10;

		private FocusLabel label7;

		private FocusLabel label6;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown TextMarginNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.CheckBox TextVisibleCheckBox;

		private GroupBox groupBox1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LengthNumericUpDown;

		private FocusLabel label9;

		private FocusLabel label8;

		private FontButton FontButton;

		private ColorPicker ForeColorPicker;

		private ColorPicker ColorPicker;

		private Container components;

		public ScaleTickMajorEditorPlugIn()
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
			this.groupBox1 = new GroupBox();
			this.TextVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.TextMarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label6 = new FocusLabel();
			this.ThicknessNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label10 = new FocusLabel();
			this.label7 = new FocusLabel();
			this.LengthNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.FontButton = new FontButton();
			this.ForeColorPicker = new ColorPicker();
			this.ColorPicker = new ColorPicker();
			this.label9 = new FocusLabel();
			this.label8 = new FocusLabel();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.TextMarginNumericUpDown).BeginInit();
			((ISupportInitialize)this.ThicknessNumericUpDown).BeginInit();
			((ISupportInitialize)this.LengthNumericUpDown).BeginInit();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.TextVisibleCheckBox);
			this.groupBox1.Controls.Add(this.TextMarginNumericUpDown);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox1.Location = new Point(232, 24);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(120, 72);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Text";
			this.TextVisibleCheckBox.Location = new Point(24, 40);
			this.TextVisibleCheckBox.Name = "TextVisibleCheckBox";
			this.TextVisibleCheckBox.PropertyName = "TextVisible";
			this.TextVisibleCheckBox.Size = new Size(62, 24);
			this.TextVisibleCheckBox.TabIndex = 1;
			this.TextVisibleCheckBox.Text = "Visible";
			this.TextMarginNumericUpDown.Location = new Point(64, 16);
			this.TextMarginNumericUpDown.Maximum = new decimal(new int[4]
			{
				0,
				0,
				-2147483648,
				0
			});
			this.TextMarginNumericUpDown.Name = "TextMarginNumericUpDown";
			this.TextMarginNumericUpDown.PropertyName = "TextMargin";
			this.TextMarginNumericUpDown.Size = new Size(48, 20);
			this.TextMarginNumericUpDown.TabIndex = 0;
			this.TextMarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label6.LoadingBegin();
			this.label6.FocusControl = this.TextMarginNumericUpDown;
			this.label6.Location = new Point(23, 17);
			this.label6.Name = "label6";
			this.label6.Size = new Size(41, 15);
			this.label6.Text = "Margin";
			this.label6.LoadingEnd();
			this.ThicknessNumericUpDown.Location = new Point(72, 56);
			this.ThicknessNumericUpDown.Name = "ThicknessNumericUpDown";
			this.ThicknessNumericUpDown.PropertyName = "Thickness";
			this.ThicknessNumericUpDown.Size = new Size(57, 20);
			this.ThicknessNumericUpDown.TabIndex = 1;
			this.ThicknessNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label10.LoadingBegin();
			this.label10.FocusControl = this.ThicknessNumericUpDown;
			this.label10.Location = new Point(15, 57);
			this.label10.Name = "label10";
			this.label10.Size = new Size(57, 15);
			this.label10.Text = "Thickness";
			this.label10.LoadingEnd();
			this.label7.LoadingBegin();
			this.label7.FocusControl = this.LengthNumericUpDown;
			this.label7.Location = new Point(31, 33);
			this.label7.Name = "label7";
			this.label7.Size = new Size(41, 15);
			this.label7.Text = "Length";
			this.label7.LoadingEnd();
			this.LengthNumericUpDown.Location = new Point(72, 32);
			this.LengthNumericUpDown.Name = "LengthNumericUpDown";
			this.LengthNumericUpDown.PropertyName = "Length";
			this.LengthNumericUpDown.Size = new Size(57, 20);
			this.LengthNumericUpDown.TabIndex = 0;
			this.LengthNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.FontButton.Location = new Point(256, 112);
			this.FontButton.Name = "FontButton";
			this.FontButton.PropertyName = "Font";
			this.FontButton.TabIndex = 5;
			this.ForeColorPicker.Location = new Point(72, 136);
			this.ForeColorPicker.Name = "ForeColorPicker";
			this.ForeColorPicker.PropertyName = "ForeColor";
			this.ForeColorPicker.Size = new Size(144, 21);
			this.ForeColorPicker.TabIndex = 3;
			this.ColorPicker.Location = new Point(72, 112);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(144, 21);
			this.ColorPicker.TabIndex = 2;
			this.label9.LoadingBegin();
			this.label9.FocusControl = this.ColorPicker;
			this.label9.Location = new Point(38, 115);
			this.label9.Name = "label9";
			this.label9.Size = new Size(34, 15);
			this.label9.Text = "Color";
			this.label9.LoadingEnd();
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ForeColorPicker;
			this.label8.Location = new Point(13, 139);
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
			base.Controls.Add(this.ThicknessNumericUpDown);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.groupBox1);
			base.Name = "ScaleTickMajorEditorPlugIn";
			base.Size = new Size(544, 232);
			base.Title = "Tick-Major Editor";
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.TextMarginNumericUpDown).EndInit();
			((ISupportInitialize)this.ThicknessNumericUpDown).EndInit();
			((ISupportInitialize)this.LengthNumericUpDown).EndInit();
			base.ResumeLayout(false);
		}
	}
}
