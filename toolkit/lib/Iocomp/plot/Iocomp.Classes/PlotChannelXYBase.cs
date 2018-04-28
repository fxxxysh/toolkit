using Iocomp.Types;
using System;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Channel XY Base")]
	public abstract class PlotChannelXYBase : PlotChannelBase
	{
		public override int CalculateXValueNearestIndex(double value)
		{
			if (base.Empty)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				if (num < this.Count)
				{
					if (this.GetX(num) != value)
					{
						num++;
						continue;
					}
					break;
				}
				return -1;
			}
			return num;
		}

		public override PlotChannelInterpolationResult GetYInterpolated(double xValue, out double yValue)
		{
			yValue = 0.0;
			return PlotChannelInterpolationResult.Invalid;
		}

		protected override void LoadDesignTimeData(PlotXAxis xAxis, PlotYAxis yAxis, Random random, double yMin, double ySpan)
		{
			for (int i = 0; i < 101; i++)
			{
				double num = (double)i * 0.062209755516629564 * 2.0;
				this.AddXY(Math.Cos(num) * xAxis.Span * (0.35 + random.NextDouble() * 0.05) + xAxis.Mid, Math.Sin(num) * yAxis.Span * (0.35 + random.NextDouble() * 0.05) + yAxis.Mid);
			}
		}
	}
}
