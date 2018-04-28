using Iocomp.Types;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	public sealed class BorderSpecial
	{
		private BorderSpecial()
		{
		}

		public static void DrawRectangle(PaintArgs p, Rectangle r, BevelStyle style, int thickness, Color color)
		{
			try
			{
				thickness = checked(thickness - 1);
			}
			catch (OverflowException)
			{
				thickness = -2147483648;
			}
			if (style != 0)
			{
				iColors.FaceColorLight = iColors.Lighten3(color);
				iColors.FaceColorDark = iColors.Darken1(color);
				bool invert = style == BevelStyle.Sunken && true;
				Point[] array = new Point[4]
				{
					new Point(r.Left, r.Top),
					new Point(r.Left + thickness, r.Top + thickness),
					new Point(r.Left + thickness, r.Bottom - thickness),
					new Point(r.Left, r.Bottom)
				};
				p.Graphics.FillPolygon(p.Graphics.Brush(iColors.ToFaceColor(FaceReference.Left, p.Rotation, invert)), array);
				p.Graphics.DrawPolygon(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Left, p.Rotation, invert)), array);
				array[0] = new Point(r.Left, r.Top);
				array[1] = new Point(r.Right, r.Top);
				array[2] = new Point(r.Right - thickness, r.Top + thickness);
				array[3] = new Point(r.Left + thickness, r.Top + thickness);
				p.Graphics.FillPolygon(p.Graphics.Brush(iColors.ToFaceColor(FaceReference.Top, p.Rotation, invert)), array);
				p.Graphics.DrawPolygon(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Top, p.Rotation, invert)), array);
				array[0] = new Point(r.Right, r.Top);
				array[1] = new Point(r.Right - thickness, r.Top + thickness);
				array[2] = new Point(r.Right - thickness, r.Bottom - thickness);
				array[3] = new Point(r.Right, r.Bottom);
				p.Graphics.FillPolygon(p.Graphics.Brush(iColors.ToFaceColor(FaceReference.Right, p.Rotation, invert)), array);
				p.Graphics.DrawPolygon(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Right, p.Rotation, invert)), array);
				array[0] = new Point(r.Right, r.Bottom);
				array[1] = new Point(r.Left, r.Bottom);
				array[2] = new Point(r.Left + thickness, r.Bottom - thickness);
				array[3] = new Point(r.Right - thickness, r.Bottom - thickness);
				p.Graphics.FillPolygon(p.Graphics.Brush(iColors.ToFaceColor(FaceReference.Bottom, p.Rotation, invert)), array);
				p.Graphics.DrawPolygon(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Bottom, p.Rotation, invert)), array);
			}
		}

		public static void DrawDiamond(PaintArgs p, Rectangle r, BevelStyle style, int thickness, Color color)
		{
			if (style != 0)
			{
				try
				{
					thickness = checked(thickness - 1);
				}
				catch (OverflowException)
				{
					thickness = -2147483648;
				}
				iColors.FaceColorLight = iColors.Lighten3(color);
				iColors.FaceColorDark = iColors.Darken1(color);
				bool invert = style == BevelStyle.Sunken && true;
				int x = (r.Left + r.Right) / 2;
				int y = (r.Top + r.Bottom) / 2;
				Point[] array = new Point[4]
				{
					new Point(r.Left, y),
					new Point(r.Left + thickness, y),
					new Point(x, r.Top + thickness),
					new Point(x, r.Top)
				};
				p.Graphics.FillPolygon(p.Graphics.Brush(iColors.ToFaceColor(FaceReference.Top, p.Rotation, invert)), array);
				p.Graphics.DrawPolygon(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Top, p.Rotation, invert)), array);
				array[0] = new Point(x, r.Top);
				array[1] = new Point(x, r.Top + thickness);
				array[2] = new Point(r.Right - thickness, y);
				array[3] = new Point(r.Right, y);
				p.Graphics.FillPolygon(p.Graphics.Brush(iColors.ToFaceColor(FaceReference.Right, p.Rotation, invert)), array);
				p.Graphics.DrawPolygon(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Right, p.Rotation, invert)), array);
				array[0] = new Point(x, r.Bottom);
				array[1] = new Point(x, r.Bottom - thickness);
				array[2] = new Point(r.Right - thickness, y);
				array[3] = new Point(r.Right, y);
				p.Graphics.FillPolygon(p.Graphics.Brush(iColors.ToFaceColor(FaceReference.Bottom, p.Rotation, invert)), array);
				p.Graphics.DrawPolygon(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Bottom, p.Rotation, invert)), array);
				array[0] = new Point(x, r.Bottom);
				array[1] = new Point(x, r.Bottom - thickness);
				array[2] = new Point(r.Left + thickness, y);
				array[3] = new Point(r.Left, y);
				p.Graphics.FillPolygon(p.Graphics.Brush(iColors.ToFaceColor(FaceReference.Left, p.Rotation, invert)), array);
				p.Graphics.DrawPolygon(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Left, p.Rotation, invert)), array);
			}
		}

		public static void DrawEllipse(PaintArgs p, Rectangle r, BevelStyle style, float thickness, Color color)
		{
			if (style != 0)
			{
				Rectangle rect = new Rectangle(r.Left, r.Top, r.Width - 1, r.Height - 1);
				if (style == BevelStyle.Sunken)
				{
					iColors.FaceColorLight = iColors.Darken2(color);
					iColors.FaceColorDark = Color.White;
				}
				else
				{
					iColors.FaceColorLight = Color.White;
					iColors.FaceColorDark = iColors.Darken2(color);
				}
				float angle = (p.Rotation != 0) ? ((p.Rotation != RotationQuad.X090) ? ((p.Rotation != RotationQuad.X180) ? 135f : 225f) : 315f) : 45f;
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddEllipse(rect);
				LinearGradientBrush linearGradientBrush = new LinearGradientBrush(r, iColors.FaceColorLight, iColors.FaceColorDark, angle);
				p.Graphics.FillPath(linearGradientBrush, graphicsPath);
				linearGradientBrush.Dispose();
				graphicsPath.Dispose();
			}
		}

		public static void DrawRoundedSides(PaintArgs p, Rectangle r, BevelStyle style, int thickness, Color color)
		{
			Point[] array = new Point[4];
			Color color2 = iColors.Darken1(color);
			array[0] = new Point(r.Left, r.Top);
			array[1] = new Point(r.Left, r.Bottom);
			array[2] = new Point(thickness, r.Bottom - thickness);
			array[3] = new Point(thickness, r.Top + thickness);
			GraphicsPath graphicsPath = Shapes.CreatePointsPath(array);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(graphicsPath.GetBounds(), color2, color, 0f);
			linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
			p.Graphics.FillPath(linearGradientBrush, graphicsPath);
			linearGradientBrush.Dispose();
			array[0] = new Point(r.Left, r.Top);
			array[1] = new Point(thickness, thickness);
			array[2] = new Point(r.Right - thickness, thickness);
			array[3] = new Point(r.Right, r.Top);
			graphicsPath = Shapes.CreatePointsPath(array);
			linearGradientBrush = new LinearGradientBrush(graphicsPath.GetBounds(), color2, color, 90f);
			linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
			p.Graphics.FillPath(linearGradientBrush, graphicsPath);
			linearGradientBrush.Dispose();
			array[0] = new Point(r.Right, r.Top);
			array[1] = new Point(r.Right - thickness, r.Top + thickness);
			array[2] = new Point(r.Right - thickness, r.Bottom - thickness);
			array[3] = new Point(r.Right, r.Bottom);
			graphicsPath = Shapes.CreatePointsPath(array);
			linearGradientBrush = new LinearGradientBrush(graphicsPath.GetBounds(), color2, color, 180f);
			linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
			p.Graphics.FillPath(linearGradientBrush, graphicsPath);
			linearGradientBrush.Dispose();
			array[0] = new Point(r.Left, r.Bottom);
			array[1] = new Point(r.Left + thickness, r.Bottom - thickness);
			array[2] = new Point(r.Right - thickness, r.Bottom - thickness);
			array[3] = new Point(r.Right, r.Bottom);
			graphicsPath = Shapes.CreatePointsPath(array);
			linearGradientBrush = new LinearGradientBrush(graphicsPath.GetBounds(), color2, color, 270f);
			linearGradientBrush.WrapMode = WrapMode.TileFlipXY;
			p.Graphics.FillPath(linearGradientBrush, graphicsPath);
			linearGradientBrush.Dispose();
		}
	}
}
