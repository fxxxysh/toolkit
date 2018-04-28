using Iocomp.Interfaces;
using System.Drawing;

namespace Iocomp.Classes
{
	public sealed class ScaleDrawFill
	{
		private Rectangle m_Rectangle;

		private ScaleRangeLinear m_Range;

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

		public ScaleRangeLinear Range
		{
			get
			{
				return this.m_Range;
			}
			set
			{
				this.m_Range = value;
			}
		}

		public void OffsetEnds(int value)
		{
			this.m_Rectangle.Inflate(0, -value);
		}

		public Rectangle GetFillRectangle(double position)
		{
			((IScaleRangeLinear)this.Range).SetBounds(this.m_Rectangle.Bottom, this.m_Rectangle.Top);
			int num = ((IScaleRangeLinear)this.Range).ValueToPixels(position, false);
			if (!this.Range.Reverse)
			{
				return iRectangle.FromLTRB(this.m_Rectangle.Left, num, this.m_Rectangle.Right, this.m_Rectangle.Bottom);
			}
			return iRectangle.FromLTRB(this.m_Rectangle.Left, this.m_Rectangle.Top, this.m_Rectangle.Right, num);
		}

		public Rectangle GetNonFillRectangle(double position)
		{
			((IScaleRangeLinear)this.Range).SetBounds(this.m_Rectangle.Bottom, this.m_Rectangle.Top);
			int num = ((IScaleRangeLinear)this.Range).ValueToPixels(position, false);
			if (!this.Range.Reverse)
			{
				return iRectangle.FromLTRB(this.m_Rectangle.Left, this.m_Rectangle.Top, this.m_Rectangle.Right, num);
			}
			return iRectangle.FromLTRB(this.m_Rectangle.Left, num, this.m_Rectangle.Right, this.m_Rectangle.Bottom);
		}
	}
}
