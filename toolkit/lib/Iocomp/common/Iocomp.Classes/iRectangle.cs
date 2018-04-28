using System;
using System.Drawing;

namespace Iocomp.Classes
{
	public class iRectangle
	{
		private int m_Left;

		private int m_Top;

		private int m_Width;

		private int m_Height;

		public int Left
		{
			get
			{
				return this.m_Left;
			}
			set
			{
				this.m_Left = value;
			}
		}

		public int Top
		{
			get
			{
				return this.m_Top;
			}
			set
			{
				this.m_Top = value;
			}
		}

		public int Width
		{
			get
			{
				return this.m_Width;
			}
			set
			{
				this.m_Width = value;
			}
		}

		public int Height
		{
			get
			{
				return this.m_Height;
			}
			set
			{
				this.m_Height = value;
			}
		}

		public int WidthHalf => this.m_Width / 2;

		public int HeightHalf => this.m_Height / 2;

		public int Right
		{
			get
			{
				return this.m_Left + this.m_Width;
			}
			set
			{
				this.m_Width = value - this.m_Left;
			}
		}

		public int Bottom
		{
			get
			{
				return this.m_Top + this.m_Height;
			}
			set
			{
				this.m_Height = value - this.m_Top;
			}
		}

		public Point TopLeft => new Point(this.Left, this.Top);

		public Point BottomLeft => new Point(this.Left, this.Bottom);

		public Point TopRight => new Point(this.Right, this.Top);

		public Point BottomRight => new Point(this.Right, this.Bottom);

		public Point CenterPoint => new Point(this.m_Left + this.m_Width / 2, this.m_Top + this.m_Height / 2);

		public int CenterX => this.m_Left + this.m_Width / 2;

		public int CenterY => this.m_Top + this.m_Height / 2;

		public Size Size
		{
			get
			{
				return new Size(this.m_Width, this.m_Height);
			}
			set
			{
				this.m_Width = value.Width;
				this.m_Height = value.Height;
			}
		}

		public Rectangle Rectangle
		{
			get
			{
				return new Rectangle(this.m_Left, this.m_Top, this.m_Width, this.m_Height);
			}
			set
			{
				this.m_Left = value.Left;
				this.m_Top = value.Top;
				this.m_Width = value.Width;
				this.m_Height = value.Height;
			}
		}

		public Rectangle PenRectangle => new Rectangle(this.m_Left, this.m_Top, this.m_Width - 1, this.m_Height - 1);

		public iRectangle()
		{
		}

		public iRectangle(Rectangle r)
		{
			this.m_Left = r.Left;
			this.m_Top = r.Top;
			this.m_Width = r.Width;
			this.m_Height = r.Height;
		}

		public iRectangle(int left, int top, int width, int height)
		{
			this.m_Left = left;
			this.m_Top = top;
			this.m_Width = width;
			this.m_Height = height;
		}

		public void Offset(int x, int y)
		{
			this.m_Left += x;
			this.m_Top += y;
		}

		public void OffsetX(int x)
		{
			this.m_Left += x;
		}

		public void OffsetY(int y)
		{
			this.m_Top += y;
		}

		public void Inflate(int x, int y)
		{
			this.m_Left -= x;
			this.m_Width += 2 * x;
			this.m_Top -= y;
			this.m_Height += 2 * y;
		}

		public void InflateX(int x)
		{
			this.m_Left -= x;
			this.m_Width += 2 * x;
		}

		public void InflateY(int y)
		{
			this.m_Top -= y;
			this.m_Height += 2 * y;
		}

		public void MoveLeft(int x)
		{
			this.m_Left += x;
			this.m_Width -= x;
		}

		public void MoveRight(int x)
		{
			this.m_Width += x;
		}

		public void MoveTop(int y)
		{
			this.m_Top += y;
			this.m_Height -= y;
		}

		public void MoveBottom(int y)
		{
			this.m_Height += y;
		}

		public static Rectangle FromLTWH(int left, int top, int width, int height)
		{
			return new Rectangle(left, top, width, height);
		}

		public static Rectangle FromLTWH(bool swap, int left, int top, int width, int height)
		{
			if (swap)
			{
				int num = left;
				left = top;
				top = num;
				num = width;
				width = height;
				height = num;
			}
			return iRectangle.FromLTWH(left, top, width, height);
		}

		public static Rectangle FromLTRB(int left, int top, int right, int bottom)
		{
			if (left > right)
			{
				int num = left;
				left = right;
				right = num;
			}
			if (top > bottom)
			{
				int num = top;
				top = bottom;
				bottom = num;
			}
			return Rectangle.FromLTRB(left, top, right, bottom);
		}

		public static Rectangle FromLTRB(bool swap, int left, int top, int right, int bottom)
		{
			if (swap)
			{
				int num = left;
				left = top;
				top = num;
				num = right;
				right = bottom;
				bottom = num;
			}
			return iRectangle.FromLTRB(left, top, right, bottom);
		}

		public static Rectangle FromLTRB(bool swap, double left, double top, double right, double bottom)
		{
			if (swap)
			{
				double num = left;
				left = top;
				top = num;
				num = right;
				right = bottom;
				bottom = num;
			}
			return iRectangle.FromLTRB((int)left, (int)top, (int)right, (int)bottom);
		}

		public static Rectangle FromLTRB(double left, double top, double right, double bottom)
		{
			if (left > right)
			{
				double num = left;
				left = right;
				right = num;
			}
			if (top > bottom)
			{
				double num = top;
				top = bottom;
				bottom = num;
			}
			return Rectangle.FromLTRB((int)Math.Round(left), (int)Math.Round(top), (int)Math.Round(right), (int)Math.Round(bottom));
		}

		public static Rectangle ToPenRectangle(Rectangle r)
		{
			return new Rectangle(r.Left, r.Top, r.Width - 1, r.Height - 1);
		}

		public static Point CenterPoint2(Rectangle r)
		{
			return new Point((r.Left + r.Right) / 2, (r.Top + r.Bottom) / 2);
		}

		public static int Radius(Rectangle r)
		{
			return (r.Right - r.Left) / 2;
		}
	}
}
