using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotDataCursorWindowEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SizeNumericUpDown;

		private FocusLabel label1;

		private Container components;

		public PlotDataCursorWindowEditorPlugIn()
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
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.SizeNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(120, 56);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(152, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.SizeNumericUpDown.Location = new Point(120, 88);
			this.SizeNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			this.SizeNumericUpDown.Name = "SizeNumericUpDown";
			this.SizeNumericUpDown.PropertyName = "Size";
			this.SizeNumericUpDown.Size = new Size(56, 20);
			this.SizeNumericUpDown.TabIndex = 1;
			this.SizeNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.SizeNumericUpDown;
			this.label1.Location = new Point(91, 89);
			this.label1.Name = "label1";
			this.label1.Size = new Size(29, 15);
			this.label1.Text = "Size";
			this.label1.LoadingEnd();
			base.Controls.Add(this.SizeNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.VisibleCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotDataCursorWindowEditorPlugIn";
			base.Size = new Size(504, 336);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Line", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotDataCursorWindow).Line;
		}
	}
}
