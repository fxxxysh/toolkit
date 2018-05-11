using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IPlotDataCursorHint
	{
		Region HitRegion
		{
			get;
			set;
		}

		bool MouseActive
		{
			get;
			set;
		}

		double MouseDownPosition
		{
			get;
			set;
		}

		double MouseDownActual
		{
			get;
			set;
		}

		PlotAxis AxisPosition
		{
			get;
			set;
		}

		void Draw(PaintArgs p, PlotDataCursorDisplay display);
	}
}
