using Iocomp.Classes;
using Iocomp.Types;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IBevelThick
	{
		void Draw(PaintArgs p, Rectangle r, ShapeBasic type, Color color);

		void Draw(PaintArgs p, Rectangle r, ShapeBasic type, BevelStyle style, int thickness, Color color);
	}
}
