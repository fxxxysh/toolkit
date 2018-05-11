using Iocomp.Types;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot X-Axis")]
	public class PlotXAxis : PlotAxis
	{
		public PlotXAxis()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.Tracking.Style = PlotTrackingStyle.ScrollSmooth;
			base.Tracking.AlignFirstStyle = PlotTrackingAlignFirstStyle.Min;
			this.DockSide = AlignmentQuadSide.Bottom;
		}

		public override double PixelsToValue(MouseEventArgs e)
		{
			if (base.DockVertical)
			{
				return base.ScaleDisplay.PixelsToValue(e.X);
			}
			return base.ScaleDisplay.PixelsToValue(e.Y);
		}
	}
}
