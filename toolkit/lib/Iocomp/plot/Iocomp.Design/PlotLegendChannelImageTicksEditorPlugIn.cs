using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotLegendChannelImageTicksEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel1;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox TicksVisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown TicksLengthNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown TicksMarginNumericUpDown;

		private FocusLabel focusLabel2;

		private EditBox TicksLabelMarginTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox TicksShowFirstAndLastOnlyCheckBox;

		private Container components;

		public PlotLegendChannelImageTicksEditorPlugIn()
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
			this.TicksVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.TicksLabelMarginTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.TicksLengthNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			this.TicksMarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.focusLabel2 = new FocusLabel();
			this.TicksShowFirstAndLastOnlyCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			this.TicksVisibleCheckBox.Location = new Point(192, 32);
			this.TicksVisibleCheckBox.Name = "TicksVisibleCheckBox";
			this.TicksVisibleCheckBox.PropertyName = "TicksVisible";
			this.TicksVisibleCheckBox.Size = new Size(72, 24);
			this.TicksVisibleCheckBox.TabIndex = 0;
			this.TicksVisibleCheckBox.Text = "Visible";
			this.TicksLabelMarginTextBox.LoadingBegin();
			this.TicksLabelMarginTextBox.Location = new Point(192, 136);
			this.TicksLabelMarginTextBox.Name = "TicksLabelMarginTextBox";
			this.TicksLabelMarginTextBox.PropertyName = "TicksLabelMargin";
			this.TicksLabelMarginTextBox.Size = new Size(56, 20);
			this.TicksLabelMarginTextBox.TabIndex = 4;
			this.TicksLabelMarginTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.TicksLabelMarginTextBox;
			this.focusLabel1.Location = new Point(121, 138);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(71, 15);
			this.focusLabel1.Text = "Label Margin";
			this.focusLabel1.LoadingEnd();
			this.TicksLengthNumericUpDown.Location = new Point(192, 112);
			this.TicksLengthNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			this.TicksLengthNumericUpDown.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			this.TicksLengthNumericUpDown.Name = "TicksLengthNumericUpDown";
			this.TicksLengthNumericUpDown.PropertyName = "TicksLength";
			this.TicksLengthNumericUpDown.Size = new Size(56, 20);
			this.TicksLengthNumericUpDown.TabIndex = 3;
			this.TicksLengthNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.TicksLengthNumericUpDown;
			this.label1.Location = new Point(151, 113);
			this.label1.Name = "label1";
			this.label1.Size = new Size(41, 15);
			this.label1.Text = "Length";
			this.label1.LoadingEnd();
			this.TicksMarginNumericUpDown.Location = new Point(192, 88);
			this.TicksMarginNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			this.TicksMarginNumericUpDown.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			this.TicksMarginNumericUpDown.Name = "TicksMarginNumericUpDown";
			this.TicksMarginNumericUpDown.PropertyName = "TicksMargin";
			this.TicksMarginNumericUpDown.Size = new Size(56, 20);
			this.TicksMarginNumericUpDown.TabIndex = 2;
			this.TicksMarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.TicksMarginNumericUpDown;
			this.focusLabel2.Location = new Point(151, 89);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(41, 15);
			this.focusLabel2.Text = "Margin";
			this.focusLabel2.LoadingEnd();
			this.TicksShowFirstAndLastOnlyCheckBox.Location = new Point(192, 56);
			this.TicksShowFirstAndLastOnlyCheckBox.Name = "TicksShowFirstAndLastOnlyCheckBox";
			this.TicksShowFirstAndLastOnlyCheckBox.PropertyName = "TicksShowFirstAndLastOnly";
			this.TicksShowFirstAndLastOnlyCheckBox.Size = new Size(160, 24);
			this.TicksShowFirstAndLastOnlyCheckBox.TabIndex = 1;
			this.TicksShowFirstAndLastOnlyCheckBox.Text = "Show First && Last Only";
			base.Controls.Add(this.TicksShowFirstAndLastOnlyCheckBox);
			base.Controls.Add(this.TicksMarginNumericUpDown);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.TicksLengthNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.TicksLabelMarginTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.TicksVisibleCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotLegendChannelImageTicksEditorPlugIn";
			base.Size = new Size(456, 208);
			base.ResumeLayout(false);
		}
	}
}
