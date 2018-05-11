using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IPlotTableCellFormat
	{
		void Draw(PaintArgs p, Rectangle r);
	}
}
