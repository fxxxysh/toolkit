using Iocomp.Types;
using System.Drawing;

namespace Iocomp.Classes
{
	public sealed class BorderSimple
	{
		private BorderSimple()
		{
		}

		private static Point[] GetBorderUpperLeftPoints(PaintArgs p, Rectangle r)
		{
			Point[] array = new Point[3];
			if (p.Rotation == RotationQuad.X000)
			{
				array[0] = new Point(r.Left, r.Bottom - 1);
				array[1] = new Point(r.Left, r.Top);
				array[2] = new Point(r.Right - 1, r.Top);
			}
			else if (p.Rotation == RotationQuad.X090)
			{
				array[0] = new Point(r.Left, r.Top + 1);
				array[1] = new Point(r.Left, r.Bottom);
				array[2] = new Point(r.Right - 1, r.Bottom);
			}
			else if (p.Rotation == RotationQuad.X180)
			{
				array[0] = new Point(r.Left + 1, r.Bottom);
				array[1] = new Point(r.Right, r.Bottom);
				array[2] = new Point(r.Right, r.Top + 1);
			}
			else
			{
				array[0] = new Point(r.Right, r.Bottom - 1);
				array[1] = new Point(r.Right, r.Top);
				array[2] = new Point(r.Left + 1, r.Top);
			}
			return array;
		}

		private static Point[] GetBorderLowerRightPoints(PaintArgs p, Rectangle r)
		{
			Point[] array = new Point[3];
			if (p.Rotation == RotationQuad.X000)
			{
				array[0] = new Point(r.Left, r.Bottom - 1);
				array[1] = new Point(r.Right - 1, r.Bottom - 1);
				array[2] = new Point(r.Right - 1, r.Top);
			}
			else if (p.Rotation == RotationQuad.X090)
			{
				array[0] = new Point(r.Left, r.Top - 1);
				array[1] = new Point(r.Right - 1, r.Top - 1);
				array[2] = new Point(r.Right - 1, r.Bottom);
			}
			else if (p.Rotation == RotationQuad.X180)
			{
				array[0] = new Point(r.Left - 1, r.Bottom);
				array[1] = new Point(r.Left - 1, r.Top - 1);
				array[2] = new Point(r.Right, r.Top - 1);
			}
			else
			{
				array[0] = new Point(r.Right, r.Bottom - 1);
				array[1] = new Point(r.Left - 1, r.Bottom - 1);
				array[2] = new Point(r.Left - 1, r.Top);
			}
			return array;
		}

		public static void Draw(PaintArgs p, Rectangle r, BorderStyleSimple style, Color color)
		{
			Color color2;
			Color color3;
			Color color4;
			Color color5;
			if (color != SystemColors.Control)
			{
				color2 = iColors.Lighten2(color);
				color3 = iColors.Darken4(color);
				color4 = iColors.Lighten4(color);
				color5 = iColors.Darken2(color);
			}
			else
			{
				color2 = SystemColors.ControlLight;
				color3 = SystemColors.ControlDarkDark;
				color4 = SystemColors.ControlLightLight;
				color5 = SystemColors.ControlDark;
			}
			Color[] array = new Color[4];
			switch (style)
			{
			case BorderStyleSimple.Raised:
				array[0] = color2;
				array[1] = color3;
				array[2] = color4;
				array[3] = color5;
				break;
			case BorderStyleSimple.Sunken:
				array[0] = color5;
				array[1] = color4;
				array[2] = color3;
				array[3] = color2;
				break;
			case BorderStyleSimple.Bump:
				array[0] = color2;
				array[1] = color3;
				array[2] = color3;
				array[3] = color2;
				break;
			case BorderStyleSimple.Etched:
				array[0] = color5;
				array[1] = color4;
				array[2] = color4;
				array[3] = color5;
				break;
			case BorderStyleSimple.RaisedInner:
				array[0] = color4;
				array[1] = color5;
				break;
			case BorderStyleSimple.RaisedOuter:
				array[0] = color2;
				array[1] = color3;
				break;
			case BorderStyleSimple.SunkenInner:
				array[0] = color3;
				array[1] = color2;
				break;
			case BorderStyleSimple.SunkenOuter:
				array[0] = color5;
				array[1] = color4;
				break;
			case BorderStyleSimple.Flat:
				array[0] = Color.Black;
				array[1] = Color.Black;
				break;
			}
			Point[] borderUpperLeftPoints = BorderSimple.GetBorderUpperLeftPoints(p, r);
			p.Graphics.DrawLines(p.Graphics.Pen(array[0]), borderUpperLeftPoints);
			borderUpperLeftPoints = BorderSimple.GetBorderLowerRightPoints(p, r);
			p.Graphics.DrawLines(p.Graphics.Pen(array[1]), borderUpperLeftPoints);
			if (style != BorderStyleSimple.Raised && style != BorderStyleSimple.Sunken && style != BorderStyleSimple.Bump && style != BorderStyleSimple.Etched)
			{
				return;
			}
			r.Inflate(-1, -1);
			borderUpperLeftPoints = BorderSimple.GetBorderUpperLeftPoints(p, r);
			p.Graphics.DrawLines(p.Graphics.Pen(array[2]), borderUpperLeftPoints);
			borderUpperLeftPoints = BorderSimple.GetBorderLowerRightPoints(p, r);
			p.Graphics.DrawLines(p.Graphics.Pen(array[3]), borderUpperLeftPoints);
		}
	}
}
