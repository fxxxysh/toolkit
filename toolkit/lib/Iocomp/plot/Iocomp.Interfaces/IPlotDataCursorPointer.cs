using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IPlotDataCursorPointer
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

		void Draw(PaintArgs p, Pen pen, PlotDataCursorDisplayCollection displays);
	}
}
