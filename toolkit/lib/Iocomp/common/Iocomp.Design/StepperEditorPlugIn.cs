using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class StepperEditorPlugIn : PlugInStandard
	{
		private GroupBox groupBox2;

		private FocusLabel label10;

		private FocusLabel label12;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown RepeaterInitialDelayNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown RepeaterIntervalNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.CheckBox RepeaterEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ReversedCheckBox;

		private FocusLabel label1;

		private EditBox StepSizeTextBox;

		private Container components;

		public StepperEditorPlugIn()
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
			this.groupBox2 = new GroupBox();
			this.RepeaterEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.label10 = new FocusLabel();
			this.RepeaterIntervalNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.RepeaterInitialDelayNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label12 = new FocusLabel();
			this.ReversedCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.label1 = new FocusLabel();
			this.StepSizeTextBox = new EditBox();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.groupBox2.Controls.Add(this.RepeaterEnabledCheckBox);
			this.groupBox2.Controls.Add(this.label10);
			this.groupBox2.Controls.Add(this.RepeaterInitialDelayNumericUpDown);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.RepeaterIntervalNumericUpDown);
			this.groupBox2.Location = new Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(136, 104);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Repeater";
			this.RepeaterEnabledCheckBox.Location = new Point(16, 16);
			this.RepeaterEnabledCheckBox.Name = "RepeaterEnabledCheckBox";
			this.RepeaterEnabledCheckBox.PropertyName = "RepeaterEnabled";
			this.RepeaterEnabledCheckBox.Size = new Size(80, 24);
			this.RepeaterEnabledCheckBox.TabIndex = 0;
			this.RepeaterEnabledCheckBox.Text = "Enabled";
			this.label10.LoadingBegin();
			this.label10.FocusControl = this.RepeaterIntervalNumericUpDown;
			this.label10.Location = new Point(36, 73);
			this.label10.Name = "label10";
			this.label10.Size = new Size(44, 15);
			this.label10.Text = "Interval";
			this.label10.LoadingEnd();
			this.RepeaterIntervalNumericUpDown.Increment = new decimal(new int[4]
			{
				50,
				0,
				0,
				0
			});
			this.RepeaterIntervalNumericUpDown.Location = new Point(80, 72);
			this.RepeaterIntervalNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000000,
				0,
				0,
				0
			});
			this.RepeaterIntervalNumericUpDown.Name = "RepeaterIntervalNumericUpDown";
			this.RepeaterIntervalNumericUpDown.PropertyName = "RepeaterInterval";
			this.RepeaterIntervalNumericUpDown.Size = new Size(48, 20);
			this.RepeaterIntervalNumericUpDown.TabIndex = 2;
			this.RepeaterIntervalNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.RepeaterInitialDelayNumericUpDown.Increment = new decimal(new int[4]
			{
				100,
				0,
				0,
				0
			});
			this.RepeaterInitialDelayNumericUpDown.Location = new Point(80, 48);
			this.RepeaterInitialDelayNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000000,
				0,
				0,
				0
			});
			this.RepeaterInitialDelayNumericUpDown.Name = "RepeaterInitialDelayNumericUpDown";
			this.RepeaterInitialDelayNumericUpDown.PropertyName = "RepeaterInitialDelay";
			this.RepeaterInitialDelayNumericUpDown.Size = new Size(48, 20);
			this.RepeaterInitialDelayNumericUpDown.TabIndex = 1;
			this.RepeaterInitialDelayNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label12.LoadingBegin();
			this.label12.FocusControl = this.RepeaterInitialDelayNumericUpDown;
			this.label12.Location = new Point(16, 49);
			this.label12.Name = "label12";
			this.label12.Size = new Size(64, 15);
			this.label12.Text = "Initial Delay";
			this.label12.LoadingEnd();
			this.ReversedCheckBox.Location = new Point(208, 40);
			this.ReversedCheckBox.Name = "ReversedCheckBox";
			this.ReversedCheckBox.PropertyName = "Reversed";
			this.ReversedCheckBox.Size = new Size(72, 24);
			this.ReversedCheckBox.TabIndex = 2;
			this.ReversedCheckBox.Text = "Reversed";
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.StepSizeTextBox;
			this.label1.Location = new Point(153, 18);
			this.label1.Name = "label1";
			this.label1.Size = new Size(55, 15);
			this.label1.Text = "Step Size";
			this.label1.LoadingEnd();
			this.StepSizeTextBox.LoadingBegin();
			this.StepSizeTextBox.Location = new Point(208, 16);
			this.StepSizeTextBox.Name = "StepSizeTextBox";
			this.StepSizeTextBox.PropertyName = "StepSize";
			this.StepSizeTextBox.Size = new Size(48, 20);
			this.StepSizeTextBox.TabIndex = 1;
			this.StepSizeTextBox.TextAlign = HorizontalAlignment.Center;
			this.StepSizeTextBox.LoadingEnd();
			base.Controls.Add(this.label1);
			base.Controls.Add(this.StepSizeTextBox);
			base.Controls.Add(this.ReversedCheckBox);
			base.Controls.Add(this.groupBox2);
			base.Name = "StepperEditorPlugIn";
			base.Size = new Size(304, 120);
			base.Title = "Stepper Editor";
			this.groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new ValueDoubleEditorPlugIn(), "Value", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as Stepper).Value;
		}
	}
}
