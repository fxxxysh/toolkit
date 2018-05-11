using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IPercentLegend
	{
		void Draw(PaintArgs p, PercentItemCollection items, Rectangle r);

		Size GetRequiredSize(PaintArgs p, PercentItemCollection items);
	}
}
