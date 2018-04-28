using System.Drawing;

namespace Iocomp.Classes
{
	public sealed class DrawFunctions
	{
		private DrawFunctions()
		{
		}

		public static void Grid(PaintArgs p, Pen pen, Rectangle r, int colCount, int rowCount, bool drawUpperLeft)
		{
			if (colCount >= 1 && rowCount >= 1)
			{
				int num = r.Width / colCount;
				int num2 = r.Height / rowCount;
				if (drawUpperLeft)
				{
					p.Graphics.DrawRectangle(pen, r);
				}
				else
				{
					p.Graphics.DrawPolygon(pen, new Point[7]
					{
						new Point(r.Left, r.Top + num2),
						new Point(r.Left + num, r.Top + num2),
						new Point(r.Left + num, r.Top),
						new Point(r.Right, r.Top),
						new Point(r.Right, r.Bottom),
						new Point(r.Left, r.Bottom),
						new Point(r.Left, r.Top + num2)
					});
				}
				Point pt = new Point(r.Left, r.Top);
				Point pt2 = new Point(r.Left, r.Bottom);
				for (int i = 1; i < colCount; i++)
				{
					pt.Offset(num, 0);
					pt2.Offset(num, 0);
					p.Graphics.DrawLine(pen, pt, pt2);
				}
				pt = new Point(r.Left, r.Top);
				pt2 = new Point(r.Right, r.Top);
				for (int j = 1; j < rowCount; j++)
				{
					pt.Offset(0, num2);
					pt2.Offset(0, num2);
					p.Graphics.DrawLine(pen, pt, pt2);
				}
			}
		}
	}
}
