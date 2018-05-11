using System.Drawing;

namespace Iocomp.Classes
{
	public class DrawExtent
	{
		private int m_MinX;

		private int m_MinY;

		private int m_MaxX;

		private int m_MaxY;

		private bool m_IsResetX;

		private bool m_IsResetY;

		public int MaxWidth
		{
			get
			{
				if (this.m_IsResetX)
				{
					return 0;
				}
				return this.m_MaxX - this.m_MinX;
			}
		}

		public int MaxHeight
		{
			get
			{
				if (this.m_IsResetY)
				{
					return 0;
				}
				return this.m_MaxY - this.m_MinY;
			}
		}

		public Rectangle Rectangle => Rectangle.FromLTRB(this.m_MinX, this.m_MinY, this.m_MaxX, this.m_MaxY);

		public DrawExtent()
		{
			this.Reset();
		}

		public void Reset()
		{
			this.m_IsResetX = true;
			this.m_IsResetY = true;
		}

		public void AddX(int value)
		{
			if (this.m_IsResetX)
			{
				this.m_MinX = value;
				this.m_MaxX = value;
				this.m_IsResetX = false;
			}
			if (value < this.m_MinX)
			{
				this.m_MinX = value;
			}
			if (value > this.m_MaxX)
			{
				this.m_MaxX = value;
			}
		}

		public void AddY(int value)
		{
			if (this.m_IsResetY)
			{
				this.m_MinY = value;
				this.m_MaxY = value;
				this.m_IsResetY = false;
			}
			if (value < this.m_MinY)
			{
				this.m_MinY = value;
			}
			if (value > this.m_MaxY)
			{
				this.m_MaxY = value;
			}
		}

		public void Add(Rectangle value)
		{
			this.AddX(value.Left);
			this.AddX(value.Right);
			this.AddY(value.Top);
			this.AddY(value.Bottom);
		}

		public void Add(Point value)
		{
			this.AddX(value.X);
			this.AddY(value.Y);
		}

		public void Add(Point point1, Point point2)
		{
			this.AddX(point1.X);
			this.AddY(point1.Y);
			this.AddX(point2.X);
			this.AddY(point2.Y);
		}

		public void Add(Point[] value)
		{
			for (int i = 0; i < value.Length; i++)
			{
				this.AddX(value[i].X);
				this.AddY(value[i].Y);
			}
		}

		public Point GetNewCenterPoint(Point centerPoint, Rectangle r)
		{
			int num = this.m_MinX - r.Left;
			int num2 = r.Right - this.m_MaxX;
			int num3 = this.m_MinY - r.Top;
			int num4 = r.Bottom - this.m_MaxY;
			int num5 = (num2 - num) / 2;
			int num6 = (num4 - num3) / 2;
			return new Point(centerPoint.X + num5, centerPoint.Y + num6);
		}
	}
}
