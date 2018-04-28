using System.Drawing;

namespace Iocomp.Classes
{
	public sealed class ScaleDrawSegments
	{
		private Rectangle m_Rectangle;

		private int m_Size;

		private int m_Spacing;

		public Rectangle Rectangle
		{
			get
			{
				return this.m_Rectangle;
			}
			set
			{
				this.m_Rectangle = value;
			}
		}

		public int Size
		{
			get
			{
				return this.m_Size;
			}
			set
			{
				this.m_Size = value;
			}
		}

		public int Spacing
		{
			get
			{
				return this.m_Spacing;
			}
			set
			{
				this.m_Spacing = value;
			}
		}

		public int SpanPixels => this.Rectangle.Height;

		public void OffsetEnds(int value)
		{
			this.Rectangle.Inflate(0, -value);
		}

		public void SetStartRectangle(iRectangle r, int width, int height, bool reverse)
		{
			if (!reverse)
			{
				r.Rectangle = new Rectangle(r.Left, r.Bottom - height, width, height);
			}
			else
			{
				r.Rectangle = new Rectangle(r.Left, r.Top, width, height);
			}
		}

		public void ShiftRectangle(iRectangle r, int shift, bool reverse)
		{
			if (!reverse)
			{
				r.OffsetY(-shift);
			}
			else
			{
				r.OffsetY(shift);
			}
		}
	}
}
