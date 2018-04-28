using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IPlotPen
	{
		Pen GetPen(PaintArgs p);

		void DrawLine(PaintArgs p, int x1, int y1, int x2, int y2);

		void DrawLine(PaintArgs p, Point pt1, Point pt2);

		void DrawArc(PaintArgs p, Rectangle r, double startAngle, double sweepAngle);
	}
}
