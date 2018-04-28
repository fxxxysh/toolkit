using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotColorLookupGradientEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel1;

		private EditBox MinTextBox;

		private EditBox MaxTextBox;

		private FocusLabel focusLabel2;

		private GroupBox StepsGroupBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown StepsCountNumericUpDown;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.CheckBox StepsEnabledCheckBox;

		private FocusLabel label8;

		private ColorPicker ColorStartPicker;

		private ColorPicker ColorStopPicker;

		private FocusLabel focusLabel4;

		private Label label1;

		private Container components;

		public PlotColorLookupGradientEditorPlugIn()
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
			this.MinTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.MaxTextBox = new EditBox();
			this.focusLabel2 = new FocusLabel();
			this.StepsGroupBox = new GroupBox();
			this.StepsEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.StepsCountNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.focusLabel3 = new FocusLabel();
			this.ColorStartPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.ColorStopPicker = new ColorPicker();
			this.focusLabel4 = new FocusLabel();
			this.label1 = new Label();
			this.StepsGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.MinTextBox.LoadingBegin();
			this.MinTextBox.Location = new Point(104, 8);
			this.MinTextBox.Name = "MinTextBox";
			this.MinTextBox.PropertyName = "Min";
			this.MinTextBox.Size = new Size(96, 20);
			this.MinTextBox.TabIndex = 0;
			this.MinTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.MinTextBox;
			this.focusLabel1.Location = new Point(79, 10);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(25, 15);
			this.focusLabel1.Text = "Min";
			this.focusLabel1.LoadingEnd();
			this.MaxTextBox.LoadingBegin();
			this.MaxTextBox.Location = new Point(104, 32);
			this.MaxTextBox.Name = "MaxTextBox";
			this.MaxTextBox.PropertyName = "Max";
			this.MaxTextBox.Size = new Size(96, 20);
			this.MaxTextBox.TabIndex = 1;
			this.MaxTextBox.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.MaxTextBox;
			this.focusLabel2.Location = new Point(76, 34);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(28, 15);
			this.focusLabel2.Text = "Max";
			this.focusLabel2.LoadingEnd();
			this.StepsGroupBox.Controls.Add(this.StepsEnabledCheckBox);
			this.StepsGroupBox.Controls.Add(this.StepsCountNumericUpDown);
			this.StepsGroupBox.Controls.Add(this.focusLabel3);
			this.StepsGroupBox.Location = new Point(104, 136);
			this.StepsGroupBox.Name = "StepsGroupBox";
			this.StepsGroupBox.Size = new Size(216, 64);
			this.StepsGroupBox.TabIndex = 5;
			this.StepsGroupBox.TabStop = false;
			this.StepsGroupBox.Text = "Steps";
			this.StepsEnabledCheckBox.Location = new Point(128, 24);
			this.StepsEnabledCheckBox.Name = "StepsEnabledCheckBox";
			this.StepsEnabledCheckBox.PropertyName = "StepsEnabled";
			this.StepsEnabledCheckBox.Size = new Size(80, 24);
			this.StepsEnabledCheckBox.TabIndex = 1;
			this.StepsEnabledCheckBox.Text = "Enabled";
			this.StepsCountNumericUpDown.Location = new Point(56, 26);
			this.StepsCountNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			this.StepsCountNumericUpDown.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			this.StepsCountNumericUpDown.Name = "StepsCountNumericUpDown";
			this.StepsCountNumericUpDown.PropertyName = "StepsCount";
			this.StepsCountNumericUpDown.Size = new Size(56, 20);
			this.StepsCountNumericUpDown.TabIndex = 0;
			this.StepsCountNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.StepsCountNumericUpDown;
			this.focusLabel3.Location = new Point(19, 27);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(37, 15);
			this.focusLabel3.Text = "Count";
			this.focusLabel3.LoadingEnd();
			this.ColorStartPicker.Location = new Point(104, 72);
			this.ColorStartPicker.Name = "ColorStartPicker";
			this.ColorStartPicker.PropertyName = "ColorStart";
			this.ColorStartPicker.Size = new Size(48, 21);
			this.ColorStartPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorStartPicker.TabIndex = 2;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorStartPicker;
			this.label8.Location = new Point(44, 75);
			this.label8.Name = "label8";
			this.label8.Size = new Size(60, 15);
			this.label8.Text = "Color Start";
			this.label8.LoadingEnd();
			this.ColorStopPicker.Location = new Point(104, 96);
			this.ColorStopPicker.Name = "ColorStopPicker";
			this.ColorStopPicker.PropertyName = "ColorStop";
			this.ColorStopPicker.Size = new Size(48, 21);
			this.ColorStopPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorStopPicker.TabIndex = 4;
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.ColorStopPicker;
			this.focusLabel4.Location = new Point(45, 99);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(59, 15);
			this.focusLabel4.Text = "Color Stop";
			this.focusLabel4.LoadingEnd();
			this.label1.Location = new Point(160, 72);
			this.label1.Name = "label1";
			this.label1.Size = new Size(312, 40);
			this.label1.TabIndex = 3;
			this.label1.Text = "These Colors are ignored if 2 or more colors are added to the Gradient Colors collection. (See Gradient Colors Tab)";
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ColorStopPicker);
			base.Controls.Add(this.focusLabel4);
			base.Controls.Add(this.ColorStartPicker);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.StepsGroupBox);
			base.Controls.Add(this.MaxTextBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.MinTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Location = new Point(10, 20);
			base.Name = "PlotColorLookupGradientEditorPlugIn";
			base.Size = new Size(496, 272);
			base.Tag = "";
			base.Title = "Plot Axis Editor";
			this.StepsGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new GradientColorCollectionEditorPlugIn(), "Gradient Colors", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotColorLookupGradient).GradientColors;
		}
	}
}
