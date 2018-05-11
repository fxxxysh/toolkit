using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IPlotBrush
	{
		Brush GetBrush(PaintArgs p, Rectangle rectangle);

		Brush GetBrush(PaintArgs p, Point[] points);
	}
}
