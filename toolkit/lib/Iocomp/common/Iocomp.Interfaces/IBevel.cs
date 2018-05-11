using Iocomp.Classes;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Interfaces
{
	public interface IBevel
	{
		void DrawRange(PaintArgs p, Rectangle r, Color backColor, Orientation orientation);

		void Draw(PaintArgs p, Rectangle r, Color backColor, Orientation orientation);
	}
}
