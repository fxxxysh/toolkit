using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public sealed class ScaleGeneratorAutoEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox MidIncludedCheckBox;

		private FocusLabel label3;

		private EditBox DesiredIncrementTextBox;

		private EditBox MinTextSpacingTextBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MinorCountNumericUpDown;

		private DoubleEditButton DesiredIncrementDoubleEditButton;

		private Iocomp.Design.Plugin.EditorControls.CheckBox FixedMinMaxMajorsCheckBox;

		private Container components;

		public ScaleGeneratorAutoEditorPlugIn()
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
			this.DesiredIncrementTextBox = new EditBox();
			this.label2 = new FocusLabel();
			this.MinTextSpacingTextBox = new EditBox();
			this.label1 = new FocusLabel();
			this.MidIncludedCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.MinorCountNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label3 = new FocusLabel();
			this.DesiredIncrementDoubleEditButton = new DoubleEditButton();
			this.FixedMinMaxMajorsCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			((ISupportInitialize)this.MinorCountNumericUpDown).BeginInit();
			base.SuspendLayout();
			this.DesiredIncrementTextBox.LoadingBegin();
			this.DesiredIncrementTextBox.Location = new Point(120, 104);
			this.DesiredIncrementTextBox.Name = "DesiredIncrementTextBox";
			this.DesiredIncrementTextBox.PropertyName = "DesiredIncrement";
			this.DesiredIncrementTextBox.Size = new Size(104, 20);
			this.DesiredIncrementTextBox.TabIndex = 4;
			this.DesiredIncrementTextBox.TextAlign = HorizontalAlignment.Center;
			this.DesiredIncrementTextBox.LoadingEnd();
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.DesiredIncrementTextBox;
			this.label2.Location = new Point(23, 106);
			this.label2.Name = "label2";
			this.label2.Size = new Size(97, 15);
			this.label2.Text = "Desired Increment";
			this.label2.LoadingEnd();
			this.MinTextSpacingTextBox.LoadingBegin();
			this.MinTextSpacingTextBox.Location = new Point(120, 80);
			this.MinTextSpacingTextBox.Name = "MinTextSpacingTextBox";
			this.MinTextSpacingTextBox.PropertyName = "MinTextSpacing";
			this.MinTextSpacingTextBox.Size = new Size(56, 20);
			this.MinTextSpacingTextBox.TabIndex = 3;
			this.MinTextSpacingTextBox.TextAlign = HorizontalAlignment.Center;
			this.MinTextSpacingTextBox.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.MinTextSpacingTextBox;
			this.label1.Location = new Point(28, 82);
			this.label1.Name = "label1";
			this.label1.Size = new Size(92, 15);
			this.label1.Text = "Min Text Spacing";
			this.label1.LoadingEnd();
			this.MidIncludedCheckBox.Location = new Point(120, 0);
			this.MidIncludedCheckBox.Name = "MidIncludedCheckBox";
			this.MidIncludedCheckBox.PropertyName = "MidIncluded";
			this.MidIncludedCheckBox.Size = new Size(92, 24);
			this.MidIncludedCheckBox.TabIndex = 0;
			this.MidIncludedCheckBox.Text = "Mid Included";
			this.MinorCountNumericUpDown.Location = new Point(120, 56);
			this.MinorCountNumericUpDown.Name = "MinorCountNumericUpDown";
			this.MinorCountNumericUpDown.PropertyName = "MinorCount";
			this.MinorCountNumericUpDown.Size = new Size(56, 20);
			this.MinorCountNumericUpDown.TabIndex = 2;
			this.MinorCountNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.MinorCountNumericUpDown;
			this.label3.Location = new Point(53, 57);
			this.label3.Name = "label3";
			this.label3.Size = new Size(67, 15);
			this.label3.Text = "Minor Count";
			this.label3.LoadingEnd();
			this.DesiredIncrementDoubleEditButton.EditBox = this.DesiredIncrementTextBox;
			this.DesiredIncrementDoubleEditButton.Location = new Point(224, 102);
			this.DesiredIncrementDoubleEditButton.Name = "DesiredIncrementDoubleEditButton";
			this.DesiredIncrementDoubleEditButton.TabIndex = 5;
			this.FixedMinMaxMajorsCheckBox.Location = new Point(120, 24);
			this.FixedMinMaxMajorsCheckBox.Name = "FixedMinMaxMajorsCheckBox";
			this.FixedMinMaxMajorsCheckBox.PropertyName = "FixedMinMaxMajors";
			this.FixedMinMaxMajorsCheckBox.Size = new Size(144, 24);
			this.FixedMinMaxMajorsCheckBox.TabIndex = 0;
			this.FixedMinMaxMajorsCheckBox.Text = "Fixed Min/Max Majors";
			base.Controls.Add(this.FixedMinMaxMajorsCheckBox);
			base.Controls.Add(this.DesiredIncrementDoubleEditButton);
			base.Controls.Add(this.MinorCountNumericUpDown);
			base.Controls.Add(this.MidIncludedCheckBox);
			base.Controls.Add(this.MinTextSpacingTextBox);
			base.Controls.Add(this.DesiredIncrementTextBox);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label2);
			base.Name = "ScaleGeneratorAutoEditorPlugIn";
			base.Size = new Size(496, 160);
			base.Title = "Generator Auto Editor";
			((ISupportInitialize)this.MinorCountNumericUpDown).EndInit();
			base.ResumeLayout(false);
		}
	}
}
