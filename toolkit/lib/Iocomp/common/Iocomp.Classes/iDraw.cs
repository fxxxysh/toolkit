using System.Drawing;

namespace Iocomp.Classes
{
	public class iDraw
	{
		public static Point Point(bool swap, int x, int y)
		{
			if (swap)
			{
				return new Point(y, x);
			}
			return new Point(x, y);
		}

		public static Rectangle GetRadiusRectangle(Point centerPoint, int radius)
		{
			return new Rectangle(centerPoint.X - radius, centerPoint.Y - radius, 2 * radius, 2 * radius);
		}
	}
}
