using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IPlotFill
	{
		bool NotDrawVisible
		{
			get;
		}

		bool DrawVisible
		{
			get;
		}

		void DrawEllipse(PaintArgs p, Rectangle r);

		void DrawPie(PaintArgs p, Rectangle r, double startAngle, double sweepAngle);

		void Draw(PaintArgs p, Rectangle r);

		void Draw(PaintArgs p, Point[] points);

		void Draw(PaintArgs p, Point[] points, Rectangle boundRect);

		void DrawBiFill(PaintArgs p, Point[] points, Rectangle boundRect);
	}
}
