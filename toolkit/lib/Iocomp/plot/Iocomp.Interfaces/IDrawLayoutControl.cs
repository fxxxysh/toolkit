using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IDrawLayoutControl
	{
		void Draw(PaintArgs p, Font font, Color foreColor, Color backColor);
	}
}
