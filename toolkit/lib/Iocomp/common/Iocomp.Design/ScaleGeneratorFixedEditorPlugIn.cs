using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleGeneratorFixedEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox MidIncludedCheckBox;

		private FocusLabel label3;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MinorCountNumericUpDown;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MajorCountNumericUpDown;

		private Container components;

		public ScaleGeneratorFixedEditorPlugIn()
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
			this.MidIncludedCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.MinorCountNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label3 = new FocusLabel();
			this.label1 = new FocusLabel();
			this.MajorCountNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			base.SuspendLayout();
			this.MidIncludedCheckBox.Location = new Point(88, 8);
			this.MidIncludedCheckBox.Name = "MidIncludedCheckBox";
			this.MidIncludedCheckBox.PropertyName = "MidIncluded";
			this.MidIncludedCheckBox.Size = new Size(92, 24);
			this.MidIncludedCheckBox.TabIndex = 0;
			this.MidIncludedCheckBox.Text = "Mid Included";
			this.MinorCountNumericUpDown.Location = new Point(88, 48);
			this.MinorCountNumericUpDown.Name = "MinorCountNumericUpDown";
			this.MinorCountNumericUpDown.PropertyName = "MinorCount";
			this.MinorCountNumericUpDown.Size = new Size(56, 20);
			this.MinorCountNumericUpDown.TabIndex = 1;
			this.MinorCountNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.MinorCountNumericUpDown;
			this.label3.Location = new Point(21, 49);
			this.label3.Name = "label3";
			this.label3.Size = new Size(67, 15);
			this.label3.Text = "Minor Count";
			this.label3.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.MajorCountNumericUpDown;
			this.label1.Location = new Point(21, 73);
			this.label1.Name = "label1";
			this.label1.Size = new Size(67, 15);
			this.label1.Text = "Major Count";
			this.label1.LoadingEnd();
			this.MajorCountNumericUpDown.Location = new Point(88, 72);
			this.MajorCountNumericUpDown.Minimum = new decimal(new int[4]
			{
				2,
				0,
				0,
				0
			});
			this.MajorCountNumericUpDown.Name = "MajorCountNumericUpDown";
			this.MajorCountNumericUpDown.PropertyName = "MajorCount";
			this.MajorCountNumericUpDown.Size = new Size(56, 20);
			this.MajorCountNumericUpDown.TabIndex = 2;
			this.MajorCountNumericUpDown.TextAlign = HorizontalAlignment.Center;
			base.Controls.Add(this.MajorCountNumericUpDown);
			base.Controls.Add(this.MinorCountNumericUpDown);
			base.Controls.Add(this.MidIncludedCheckBox);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label3);
			base.Name = "ScaleGeneratorFixedEditorPlugIn";
			base.Size = new Size(536, 296);
			base.Title = "Generator Fixed Editor";
			base.ResumeLayout(false);
		}
	}
}
