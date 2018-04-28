using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IPlotMarker
	{
		void Draw(PaintArgs p, int x, int y, Brush brush, Pen pen);

		void Draw(PaintArgs p, int x, int y);

		void DrawLegend(PaintArgs p, Rectangle r);
	}
}
