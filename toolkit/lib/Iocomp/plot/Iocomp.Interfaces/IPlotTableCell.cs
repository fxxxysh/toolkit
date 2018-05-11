using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IPlotTableCell
	{
		void Draw(PaintArgs p, bool showGrid, Pen gridPen);

		void UpdateRequiredSize(PaintArgs p, bool visible, Size outerMargin, int fixedWidth, int fixedHeight);
	}
}
