using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	public sealed class HitTest
	{
		private HitTest()
		{
		}

		public static bool Contains(Point point, Point[] pointArray)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			try
			{
				graphicsPath.AddPolygon(pointArray);
				return graphicsPath.IsVisible(point);
			}
			finally
			{
				graphicsPath.Dispose();
			}
		}

		public static bool Contains(int x, int y, Point[] pointArray)
		{
			return HitTest.Contains(new Point(x, y), pointArray);
		}
	}
}
