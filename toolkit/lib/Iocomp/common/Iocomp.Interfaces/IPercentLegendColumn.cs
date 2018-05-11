using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IPercentLegendColumn
	{
		int GetRequiredWidth(PaintArgs p, Font font, PercentItemCollection items, bool isValue);
	}
}
