using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleTickMinorEditorPlugIn : PlugInStandard
	{
		private FocusLabel label9;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LengthNumericUpDown;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.ComboBox AlignmentComboBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown ThicknessNumericUpDown;

		private FocusLabel label10;

		private FocusLabel label7;

		private ColorPicker ColorPicker;

		private Container components;

		public ScaleTickMinorEditorPlugIn()
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
			this.label9 = new FocusLabel();
			this.ColorPicker = new ColorPicker();
			this.LengthNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			this.AlignmentComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.ThicknessNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label10 = new FocusLabel();
			this.label7 = new FocusLabel();
			base.SuspendLayout();
			this.label9.LoadingBegin();
			this.label9.FocusControl = this.ColorPicker;
			this.label9.Location = new Point(30, 99);
			this.label9.Name = "label9";
			this.label9.Size = new Size(34, 15);
			this.label9.Text = "Color";
			this.label9.LoadingEnd();
			this.ColorPicker.Location = new Point(64, 96);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(144, 21);
			this.ColorPicker.TabIndex = 3;
			this.LengthNumericUpDown.Location = new Point(64, 40);
			this.LengthNumericUpDown.Name = "LengthNumericUpDown";
			this.LengthNumericUpDown.PropertyName = "Length";
			this.LengthNumericUpDown.Size = new Size(57, 20);
			this.LengthNumericUpDown.TabIndex = 1;
			this.LengthNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.AlignmentComboBox;
			this.label1.Location = new Point(7, 10);
			this.label1.Name = "label1";
			this.label1.Size = new Size(57, 15);
			this.label1.Text = "Alignment";
			this.label1.LoadingEnd();
			this.AlignmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.AlignmentComboBox.Location = new Point(64, 8);
			this.AlignmentComboBox.Name = "AlignmentComboBox";
			this.AlignmentComboBox.PropertyName = "Alignment";
			this.AlignmentComboBox.Size = new Size(144, 21);
			this.AlignmentComboBox.TabIndex = 0;
			this.ThicknessNumericUpDown.Location = new Point(64, 64);
			this.ThicknessNumericUpDown.Name = "ThicknessNumericUpDown";
			this.ThicknessNumericUpDown.PropertyName = "Thickness";
			this.ThicknessNumericUpDown.Size = new Size(57, 20);
			this.ThicknessNumericUpDown.TabIndex = 2;
			this.ThicknessNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label10.LoadingBegin();
			this.label10.FocusControl = this.ThicknessNumericUpDown;
			this.label10.Location = new Point(7, 65);
			this.label10.Name = "label10";
			this.label10.Size = new Size(57, 15);
			this.label10.Text = "Thickness";
			this.label10.LoadingEnd();
			this.label7.LoadingBegin();
			this.label7.FocusControl = this.LengthNumericUpDown;
			this.label7.Location = new Point(23, 41);
			this.label7.Name = "label7";
			this.label7.Size = new Size(41, 15);
			this.label7.Text = "Length";
			this.label7.LoadingEnd();
			base.Controls.Add(this.LengthNumericUpDown);
			base.Controls.Add(this.AlignmentComboBox);
			base.Controls.Add(this.ThicknessNumericUpDown);
			base.Controls.Add(this.label10);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label9);
			base.Name = "ScaleTickMinorEditorPlugIn";
			base.Size = new Size(584, 232);
			base.Title = "Tick-Minor Editor";
			base.ResumeLayout(false);
		}
	}
}
