using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotFillGridEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private GroupBox GridShowGroupBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox GridShowLeftCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox GridShowRightCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox GridShowTopCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox GridShowBottomCheckBox;

		private Container components;

		public PlotFillGridEditorPlugIn()
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
			this.GridShowGroupBox = new GroupBox();
			this.GridShowBottomCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.GridShowTopCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.GridShowRightCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.GridShowLeftCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.GridShowGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(80, 32);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.GridShowGroupBox.Controls.Add(this.GridShowBottomCheckBox);
			this.GridShowGroupBox.Controls.Add(this.GridShowTopCheckBox);
			this.GridShowGroupBox.Controls.Add(this.GridShowRightCheckBox);
			this.GridShowGroupBox.Controls.Add(this.GridShowLeftCheckBox);
			this.GridShowGroupBox.Location = new Point(112, 72);
			this.GridShowGroupBox.Name = "GridShowGroupBox";
			this.GridShowGroupBox.Size = new Size(96, 128);
			this.GridShowGroupBox.TabIndex = 1;
			this.GridShowGroupBox.TabStop = false;
			this.GridShowGroupBox.Text = "Grid Show";
			this.GridShowBottomCheckBox.Location = new Point(16, 96);
			this.GridShowBottomCheckBox.Name = "GridShowBottomCheckBox";
			this.GridShowBottomCheckBox.PropertyName = "GridShowBottom";
			this.GridShowBottomCheckBox.Size = new Size(72, 24);
			this.GridShowBottomCheckBox.TabIndex = 3;
			this.GridShowBottomCheckBox.Text = "Bottom";
			this.GridShowTopCheckBox.Location = new Point(16, 72);
			this.GridShowTopCheckBox.Name = "GridShowTopCheckBox";
			this.GridShowTopCheckBox.PropertyName = "GridShowTop";
			this.GridShowTopCheckBox.Size = new Size(72, 24);
			this.GridShowTopCheckBox.TabIndex = 2;
			this.GridShowTopCheckBox.Text = "Top";
			this.GridShowRightCheckBox.Location = new Point(16, 48);
			this.GridShowRightCheckBox.Name = "GridShowRightCheckBox";
			this.GridShowRightCheckBox.PropertyName = "GridShowRight";
			this.GridShowRightCheckBox.Size = new Size(72, 24);
			this.GridShowRightCheckBox.TabIndex = 1;
			this.GridShowRightCheckBox.Text = "Right";
			this.GridShowLeftCheckBox.Location = new Point(16, 24);
			this.GridShowLeftCheckBox.Name = "GridShowLeftCheckBox";
			this.GridShowLeftCheckBox.PropertyName = "GridShowLeft";
			this.GridShowLeftCheckBox.Size = new Size(72, 24);
			this.GridShowLeftCheckBox.TabIndex = 0;
			this.GridShowLeftCheckBox.Text = "Left";
			base.Controls.Add(this.GridShowGroupBox);
			base.Controls.Add(this.VisibleCheckBox);
			base.Name = "PlotFillGridEditorPlugIn";
			base.Size = new Size(424, 288);
			this.GridShowGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Pen", false);
			base.AddSubPlugIn(new PlotBrushEditorPlugIn(), "Brush", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotFill).Pen;
			base.SubPlugIns[1].Value = (base.Value as PlotFill).Brush;
		}
	}
}
