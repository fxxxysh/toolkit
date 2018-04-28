using Iocomp.Interfaces;
using Iocomp.Types;
using System.Collections;

namespace Iocomp.Classes
{
	public class ScaleTickInfo
	{
		public PaintArgs Painter;

		public int MaxTicks;

		public int MajorCount;

		public int MinorCount;

		public bool MidIncluded;

		public double MajorStepSize;

		public double MinorStepSize;

		public double MinTextSpacing;

		public double StartStandard;

		public double DesiredIncrement;

		public TextFormatDoubleAll TextFormatting;

		public ScaleType ScaleType;

		public int PixelSpanTotal;

		public int PixelSpanCalculation;

		public double Span;

		public double Min;

		public double Max;

		public bool PadMin;

		public bool PadMax;

		public StackingDimension StackingDimension;

		public int LabelMaxWidth;

		private ArrayList m_TickList;

		private IScaleDisplay m_Display;

		public ArrayList TickList => this.m_TickList;

		public IScaleDisplay Display => this.m_Display;

		public ScaleTickInfo(ScaleDisplay display)
		{
			this.m_TickList = new ArrayList();
			this.m_Display = display;
		}

		public bool LabelsFit(double span, double increment)
		{
			double num = span / increment;
			if (num > 1000.0)
			{
				return false;
			}
			this.MajorStepSize = increment;
			this.MajorCount = (int)num;
			if (this.MidIncluded && 2 * this.MajorCount - 1 <= this.MaxTicks)
			{
				return true;
			}
			if (this.MajorCount <= this.MaxTicks)
			{
				return true;
			}
			return false;
		}
	}
}
