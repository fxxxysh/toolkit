using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotLayoutViewerEditorPlugIn : PlugInStandard
	{
		private PlotLayoutViewer plotLayoutViewer;

		private Container components;

		public PlotLayoutViewerEditorPlugIn()
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
			this.plotLayoutViewer = new PlotLayoutViewer();
			base.SuspendLayout();
			this.plotLayoutViewer.LoadingBegin();
			this.plotLayoutViewer.BackColor = Color.Black;
			this.plotLayoutViewer.Border.Margin = 7;
			this.plotLayoutViewer.Dock = DockStyle.Fill;
			this.plotLayoutViewer.Location = new Point(0, 0);
			this.plotLayoutViewer.Name = "plotLayoutViewer";
			this.plotLayoutViewer.Size = new Size(600, 272);
			this.plotLayoutViewer.TabIndex = 393;
			this.plotLayoutViewer.LoadingEnd();
			base.Controls.Add(this.plotLayoutViewer);
			base.Location = new Point(10, 20);
			base.Name = "PlotLayoutViewerEditorPlugIn";
			base.Size = new Size(600, 272);
			base.ResumeLayout(false);
		}
	}
}
