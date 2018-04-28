using Iocomp.Classes;
using Iocomp.Types;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IBorderControl
	{
		void Draw(PaintArgs p, Rectangle r);

		void Draw(PaintArgs p, Rectangle r, BorderStyleControl style, int thicknessDesired, Color color);
	}
}
