using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface ITextLayoutBase
	{
		DrawStringFormat StringFormat
		{
			get;
		}

		Size GetRequiredSize(string s, Font font, GraphicsAPI graphics);

		Size GetRequiredSize(string s, Font font, int width, GraphicsAPI graphics);

		Rectangle GetRectangle(Rectangle bounds, Font font, GraphicsAPI graphics);

		Rectangle GetRectangle(string s, Point pt, Font font, GraphicsAPI graphics);

		void Draw(GraphicsAPI graphics, Font font, Brush brush, string s, Rectangle r);

		Point GetMarginsAlignment(Font font, GraphicsAPI graphics);
	}
}
