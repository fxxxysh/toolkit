using Iocomp.Types;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	public sealed class Shapes
	{
		private Shapes()
		{
		}

		public static Point[] GetTrianglePoints(Rectangle r, Direction direction)
		{
			switch (direction)
			{
			case Direction.Up:
				return new Point[3]
				{
					new Point(r.Left, r.Bottom),
					new Point((r.Left + r.Right) / 2, r.Top),
					new Point(r.Right, r.Bottom)
				};
			case Direction.Down:
				return new Point[3]
				{
					new Point(r.Left, r.Top),
					new Point((r.Left + r.Right) / 2, r.Bottom),
					new Point(r.Right, r.Top)
				};
			case Direction.Left:
				return new Point[3]
				{
					new Point(r.Right, r.Top),
					new Point(r.Right, r.Bottom),
					new Point(r.Left, (r.Top + r.Bottom) / 2)
				};
			default:
				return new Point[3]
				{
					new Point(r.Left, r.Top),
					new Point(r.Left, r.Bottom),
					new Point(r.Right, (r.Top + r.Bottom) / 2)
				};
			}
		}

		public static Point[] GetPointerPoints(Rectangle r, Direction direction)
		{
			switch (direction)
			{
			case Direction.Up:
				return new Point[5]
				{
					new Point(r.Left, r.Bottom),
					new Point(r.Right, r.Bottom),
					new Point(r.Right, r.Top + r.Width / 2),
					new Point((r.Left + r.Right) / 2, r.Top),
					new Point(r.Left, r.Top + r.Width / 2)
				};
			case Direction.Down:
				return new Point[5]
				{
					new Point(r.Left, r.Top),
					new Point(r.Right, r.Top),
					new Point(r.Right, r.Bottom - r.Width / 2),
					new Point((r.Left + r.Right) / 2, r.Bottom),
					new Point(r.Left, r.Bottom - r.Width / 2)
				};
			case Direction.Left:
				return new Point[5]
				{
					new Point(r.Right, r.Top),
					new Point(r.Right, r.Bottom),
					new Point(r.Left + r.Height / 2, r.Bottom),
					new Point(r.Left, (r.Top + r.Bottom) / 2),
					new Point(r.Left + r.Height / 2, r.Top)
				};
			default:
				return new Point[5]
				{
					new Point(r.Left, r.Top),
					new Point(r.Left, r.Bottom),
					new Point(r.Right - r.Height / 2, r.Bottom),
					new Point(r.Right, (r.Top + r.Bottom) / 2),
					new Point(r.Right - r.Height / 2, r.Top)
				};
			}
		}

		public static Point[] GetDiamondPoints(Rectangle r, Direction direction)
		{
			return new Point[4]
			{
				new Point(r.Left, (r.Top + r.Bottom) / 2),
				new Point((r.Left + r.Right) / 2, r.Top),
				new Point(r.Right, (r.Top + r.Bottom) / 2),
				new Point((r.Left + r.Right) / 2, r.Bottom)
			};
		}

		public static Point[] Triangle(Rectangle r, AlignmentQuadSide side)
		{
			switch (side)
			{
			case AlignmentQuadSide.Left:
				return new Point[3]
				{
					new Point(r.Left, r.Top),
					new Point(r.Left + r.Width / 2, r.Top + r.Height / 2),
					new Point(r.Left, r.Bottom + 1)
				};
			case AlignmentQuadSide.Right:
				return new Point[3]
				{
					new Point(r.Right + 1, r.Top),
					new Point(r.Left + r.Width / 2, r.Top + r.Height / 2),
					new Point(r.Right + 1, r.Bottom + 1)
				};
			case AlignmentQuadSide.Top:
				return new Point[3]
				{
					new Point(r.Left, r.Top),
					new Point(r.Left + r.Width / 2, r.Top + r.Height / 2),
					new Point(r.Right + 1, r.Top)
				};
			default:
				return new Point[3]
				{
					new Point(r.Left, r.Bottom + 1),
					new Point(r.Left + r.Width / 2, r.Top + r.Height / 2),
					new Point(r.Right + 1, r.Bottom + 1)
				};
			}
		}

		public static GraphicsPath CreatePointsPath(Point[] points)
		{
			if (points.Length < 2)
			{
				throw new Exception("Must Contain at least 2 points");
			}
			PointF pointF = points[0];
			GraphicsPath graphicsPath = new GraphicsPath();
			for (int i = 1; i < points.Length; i++)
			{
				graphicsPath.AddLine(pointF.X, pointF.Y, (float)points[i].X, (float)points[i].Y);
				pointF = points[i];
			}
			return graphicsPath;
		}
	}
}
