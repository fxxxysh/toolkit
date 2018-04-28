using Iocomp.Types;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Y-Axis")]
	public class PlotYAxis : PlotAxis
	{
		public PlotYAxis()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.Tracking.Style = PlotTrackingStyle.ExpandMinMax;
			base.Tracking.AlignFirstStyle = PlotTrackingAlignFirstStyle.None;
			this.DockSide = AlignmentQuadSide.Left;
		}

		public override double PixelsToValue(MouseEventArgs e)
		{
			if (base.DockHorizontal)
			{
				return base.ScaleDisplay.PixelsToValue(e.Y);
			}
			return base.ScaleDisplay.PixelsToValue(e.X);
		}
	}
}
