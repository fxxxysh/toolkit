using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IPlotChannelBase
	{
		void DrawLegendMarker(PaintArgs p, Rectangle r);

		void DoDataChange();

		PlotDataPointBase CreateDataPoint();
	}
}
