using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface ITextLayoutHorizontal
	{
		Size GetRequiredSize(string s, Font font, GraphicsAPI graphics);

		void Draw(GraphicsAPI graphics, Font font, Brush brush, string s, Rectangle r);

		Point GetMarginOffsets(Font font, GraphicsAPI graphics);
	}
}
