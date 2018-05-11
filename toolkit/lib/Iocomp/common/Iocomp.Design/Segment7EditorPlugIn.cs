using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class Segment7EditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SeperationNumericUpDown;

		private FocusLabel label6;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SizeNumericUpDown;

		private GroupBox groupBox1;

		private ColorPicker ColorOnColorPicker;

		private FocusLabel label7;

		private ColorPicker ColorOffColorPicker;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ColorOffAutoCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ShowOffSegmentsCheckBox;

		private Container components;

		public Segment7EditorPlugIn()
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
			this.SeperationNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label6 = new FocusLabel();
			this.SizeNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label8 = new FocusLabel();
			this.groupBox1 = new GroupBox();
			this.ColorOffAutoCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ColorOffColorPicker = new ColorPicker();
			this.label1 = new FocusLabel();
			this.ColorOnColorPicker = new ColorPicker();
			this.label7 = new FocusLabel();
			this.ShowOffSegmentsCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.SeperationNumericUpDown.Location = new Point(72, 64);
			this.SeperationNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			this.SeperationNumericUpDown.Name = "SeperationNumericUpDown";
			this.SeperationNumericUpDown.PropertyName = "Separation";
			this.SeperationNumericUpDown.Size = new Size(40, 20);
			this.SeperationNumericUpDown.TabIndex = 2;
			this.SeperationNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label6.LoadingBegin();
			this.label6.FocusControl = this.SeperationNumericUpDown;
			this.label6.Location = new Point(11, 65);
			this.label6.Name = "label6";
			this.label6.Size = new Size(61, 15);
			this.label6.Text = "Separation";
			this.label6.LoadingEnd();
			this.SizeNumericUpDown.Location = new Point(72, 40);
			this.SizeNumericUpDown.Name = "SizeNumericUpDown";
			this.SizeNumericUpDown.PropertyName = "Size";
			this.SizeNumericUpDown.Size = new Size(40, 20);
			this.SizeNumericUpDown.TabIndex = 1;
			this.SizeNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.SizeNumericUpDown;
			this.label8.Location = new Point(43, 41);
			this.label8.Name = "label8";
			this.label8.Size = new Size(29, 15);
			this.label8.Text = "Size";
			this.label8.LoadingEnd();
			this.groupBox1.Controls.Add(this.ColorOffAutoCheckBox);
			this.groupBox1.Controls.Add(this.ColorOffColorPicker);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.ColorOnColorPicker);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Location = new Point(168, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(200, 104);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Color";
			this.ColorOffAutoCheckBox.Location = new Point(32, 72);
			this.ColorOffAutoCheckBox.Name = "ColorOffAutoCheckBox";
			this.ColorOffAutoCheckBox.PropertyName = "ColorOffAuto";
			this.ColorOffAutoCheckBox.Size = new Size(80, 24);
			this.ColorOffAutoCheckBox.TabIndex = 2;
			this.ColorOffAutoCheckBox.Text = "Off Auto";
			this.ColorOffColorPicker.Location = new Point(32, 48);
			this.ColorOffColorPicker.Name = "ColorOffColorPicker";
			this.ColorOffColorPicker.PropertyName = "ColorOff";
			this.ColorOffColorPicker.Size = new Size(144, 21);
			this.ColorOffColorPicker.TabIndex = 1;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.ColorOffColorPicker;
			this.label1.Location = new Point(10, 51);
			this.label1.Name = "label1";
			this.label1.Size = new Size(22, 15);
			this.label1.Text = "Off";
			this.label1.LoadingEnd();
			this.ColorOnColorPicker.Location = new Point(32, 24);
			this.ColorOnColorPicker.Name = "ColorOnColorPicker";
			this.ColorOnColorPicker.PropertyName = "ColorOn";
			this.ColorOnColorPicker.Size = new Size(144, 21);
			this.ColorOnColorPicker.TabIndex = 0;
			this.label7.LoadingBegin();
			this.label7.FocusControl = this.ColorOnColorPicker;
			this.label7.Location = new Point(10, 27);
			this.label7.Name = "label7";
			this.label7.Size = new Size(22, 15);
			this.label7.Text = "On";
			this.label7.LoadingEnd();
			this.ShowOffSegmentsCheckBox.Location = new Point(16, 8);
			this.ShowOffSegmentsCheckBox.Name = "ShowOffSegmentsCheckBox";
			this.ShowOffSegmentsCheckBox.PropertyName = "ShowOffSegments";
			this.ShowOffSegmentsCheckBox.Size = new Size(128, 24);
			this.ShowOffSegmentsCheckBox.TabIndex = 0;
			this.ShowOffSegmentsCheckBox.Text = "Show Off Segments";
			base.Controls.Add(this.ShowOffSegmentsCheckBox);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.SizeNumericUpDown);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.SeperationNumericUpDown);
			base.Controls.Add(this.label6);
			base.Location = new Point(10, 20);
			base.Name = "Segment7EditorPlugIn";
			base.Size = new Size(416, 208);
			base.Title = "Segments Editor";
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
