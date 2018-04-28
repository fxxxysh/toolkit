using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IScaleDisplayDiscreet
	{
		void Calculate(PaintArgs p, ScaleDiscreetItemCollection items, Point centerPoint, int activeIndex, int pointerExtent);

		void Draw(PaintArgs p, ScaleDiscreetItemCollection items, Point centerPoint, int activeIndex, Color backColor);
	}
}
