using Iocomp.Types;
using System;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Channel Consecutive")]
	public abstract class PlotChannelConsecutive : PlotChannelBase
	{
		private int m_IndexDrawStart;

		private int m_IndexDrawStop;

		private DateTime m_ElapsedStartTime;

		private bool m_RequireConsecutiveData;

		private OPCXValueType m_OPCXValueSource;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public DateTime ElapsedStartTime
		{
			get
			{
				return this.m_ElapsedStartTime;
			}
			set
			{
				base.PropertyUpdateDefault("ElapsedStartTime", value);
				if (this.ElapsedStartTime != value)
				{
					this.m_ElapsedStartTime = value;
					base.DoPropertyChange(this, "ElapsedStartTime");
				}
			}
		}

		protected bool RequireConsecutiveData
		{
			get
			{
				return this.m_RequireConsecutiveData;
			}
			set
			{
				base.PropertyUpdateDefault("RequireConsecutiveData", value);
				if (this.RequireConsecutiveData != value)
				{
					this.m_RequireConsecutiveData = value;
					base.DoPropertyChange(this, "RequireConsecutiveData");
				}
			}
		}

		[Description("")]
		public DataDirection DataDirection
		{
			get
			{
				if (this.Count < 2)
				{
					return DataDirection.Increasing;
				}
				if (this.GetX(1) > this.GetX(0))
				{
					return DataDirection.Increasing;
				}
				return DataDirection.Decreasing;
			}
		}

		[Description("")]
		public int DrawPointCount
		{
			get
			{
				if (this.IndexDrawStop != -1 && this.IndexDrawStart != -1)
				{
					return Math.Abs(this.IndexDrawStop - this.IndexDrawStart + 1);
				}
				return 0;
			}
		}

		public override int IndexDrawStart
		{
			get
			{
				if (this.RequireConsecutiveData)
				{
					if (this.DataDirection == DataDirection.Increasing)
					{
						return this.m_IndexDrawStart;
					}
					return this.m_IndexDrawStop;
				}
				return base.IndexDrawStart;
			}
		}

		public override int IndexDrawStop
		{
			get
			{
				if (this.RequireConsecutiveData)
				{
					if (this.DataDirection == DataDirection.Increasing)
					{
						return this.m_IndexDrawStop;
					}
					return this.m_IndexDrawStart;
				}
				return base.IndexDrawStop;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public OPCXValueType OPCXValueSource
		{
			get
			{
				return this.m_OPCXValueSource;
			}
			set
			{
				base.PropertyUpdateDefault("OPCXValueSource", value);
				if (this.OPCXValueSource != value)
				{
					this.m_OPCXValueSource = value;
					base.DoPropertyChange(this, "OPCXValueSource");
				}
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.m_IndexDrawStart = -1;
			this.m_IndexDrawStop = -1;
			this.RequireConsecutiveData = true;
			this.OPCXValueSource = OPCXValueType.OPCServerTimeStamp;
			this.ElapsedStartTime = DateTime.Now;
		}

		private bool ShouldSerializeOPCXValueSource()
		{
			return base.PropertyShouldSerialize("OPCXValueSource");
		}

		private void ResetOPCXValueSource()
		{
			base.PropertyReset("OPCXValueSource");
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override void NewOPCData(double data, DateTime timeStamp)
		{
			if (this.OPCXValueSource == OPCXValueType.OPCServerTimeStamp)
			{
				this.AddXY(timeStamp.ToOADate(), data);
			}
			else if (this.OPCXValueSource == OPCXValueType.SystemClock)
			{
				this.AddYNow(data);
			}
			else if (this.OPCXValueSource == OPCXValueType.SystemClockUTC)
			{
				this.AddYUTC(data);
			}
			else if (this.OPCXValueSource == OPCXValueType.ElapsedSeconds)
			{
				this.AddYElapsedSeconds(data);
			}
			else if (this.OPCXValueSource == OPCXValueType.ElapsedTime)
			{
				this.AddYElapsedTime(data);
			}
		}

		public int AddYNow(double y)
		{
			return this.AddXY(Math2.DateTimeToDouble(DateTime.Now), y);
		}

		public int AddYUTC(double y)
		{
			return this.AddXY(Math2.DateTimeToDouble(DateTime.UtcNow), y);
		}

		public int AddYElapsedTime(double y)
		{
			return this.AddXY(Math2.DateTimeToDouble(DateTime.Now) - Math2.DateTimeToDouble(this.ElapsedStartTime), y);
		}

		public int AddYElapsedSeconds(double y)
		{
			return this.AddXY((Math2.DateTimeToDouble(DateTime.Now) - Math2.DateTimeToDouble(this.ElapsedStartTime)) * 24.0 * 60.0 * 60.0, y);
		}

		public void ElapsedStartTimeReset()
		{
			this.ElapsedStartTime = DateTime.Now;
		}

		public DateTime GetXInDateTime(int index)
		{
			return Math2.DoubleToDateTime(this.GetX(index));
		}

		public bool ValidNextX(double nextX)
		{
			if (this.Count == 0)
			{
				return true;
			}
			if (this.Count == 1 && nextX == this.GetX(base.IndexLast))
			{
				return false;
			}
			if (this.Count == 1)
			{
				return true;
			}
			if (this.DataDirection == DataDirection.Increasing)
			{
				if (nextX > this.GetX(base.IndexLast))
				{
					return true;
				}
				return false;
			}
			if (nextX < this.GetX(base.IndexLast))
			{
				return true;
			}
			return false;
		}

		protected void CheckForValidNextX(double nextX)
		{
			if (this.ValidNextX(nextX))
			{
				return;
			}
			throw new Exception("X-Value is not continuous (Must be continuously increasing or decreasing).");
		}

		public virtual void UpdateDrawIndexes()
		{
			PlotXAxis xAxis = base.XAxis;
			this.m_IndexDrawStart = -1;
			this.m_IndexDrawStop = -1;
			if (xAxis != null && this.Count != 0 && !(base.XMax < xAxis.Min) && base.XMin <= xAxis.Max)
			{
				double max = xAxis.ScaleRange.Max;
				double min = xAxis.ScaleRange.Min;
				if (this.Count == 1)
				{
					this.m_IndexDrawStart = 0;
					this.m_IndexDrawStop = 0;
				}
				else
				{
					if (this.DataDirection == DataDirection.Increasing)
					{
						this.m_IndexDrawStart = this.CalcIndexesIncrementing(min);
						this.m_IndexDrawStop = this.CalcIndexesIncrementing(max);
						if (this.GetX(this.m_IndexDrawStart) > min)
						{
							this.m_IndexDrawStart--;
						}
						if (this.GetX(this.m_IndexDrawStop) < max)
						{
							this.m_IndexDrawStop++;
						}
					}
					else
					{
						this.m_IndexDrawStop = this.CalcIndexesDecrementing(max);
						this.m_IndexDrawStart = this.CalcIndexesDecrementing(min);
						if (this.GetX(this.m_IndexDrawStart) > min)
						{
							this.m_IndexDrawStart++;
						}
						if (this.GetX(this.m_IndexDrawStop) < max)
						{
							this.m_IndexDrawStop--;
						}
					}
					if (this.m_IndexDrawStart < base.IndexFirst)
					{
						this.m_IndexDrawStart = base.IndexFirst;
					}
					if (this.m_IndexDrawStop < base.IndexFirst)
					{
						this.m_IndexDrawStop = base.IndexFirst;
					}
					if (this.m_IndexDrawStart > base.IndexLast)
					{
						this.m_IndexDrawStart = base.IndexLast;
					}
					if (this.m_IndexDrawStop > base.IndexLast)
					{
						this.m_IndexDrawStop = base.IndexLast;
					}
				}
			}
		}

		public override PlotChannelInterpolationResult GetYInterpolated(double targetX, out double yValue)
		{
			yValue = 0.0;
			if (this.Count == 0)
			{
				return PlotChannelInterpolationResult.NoData;
			}
			if (targetX < base.XMin)
			{
				return PlotChannelInterpolationResult.NoData;
			}
			if (targetX > base.XMax)
			{
				return PlotChannelInterpolationResult.NoData;
			}
			if (this.Count == 1 && this.GetX(0) != targetX)
			{
				return PlotChannelInterpolationResult.Void;
			}
			if (targetX < base.XFirst)
			{
				return PlotChannelInterpolationResult.Void;
			}
			if (targetX > base.XLast)
			{
				return PlotChannelInterpolationResult.Void;
			}
			if (this.Count == 1 && this.GetX(0) == targetX)
			{
				if (this.GetNull(0))
				{
					return PlotChannelInterpolationResult.Null;
				}
				if (this.GetEmpty(0))
				{
					return PlotChannelInterpolationResult.NoData;
				}
				yValue = this.GetY(0);
				return PlotChannelInterpolationResult.Valid;
			}
			int num = this.CalculateXValueNearestIndex(targetX);
			double x = this.GetX(num);
			if (num == -1)
			{
				return PlotChannelInterpolationResult.Invalid;
			}
			if (x == targetX)
			{
				if (this.GetNull(num))
				{
					return PlotChannelInterpolationResult.Null;
				}
				if (!this.GetEmpty(num))
				{
					yValue = this.GetY(num);
					return PlotChannelInterpolationResult.Valid;
				}
			}
			int num2;
			int num3;
			if (x <= targetX)
			{
				if (num >= base.IndexLast)
				{
					return PlotChannelInterpolationResult.Invalid;
				}
				num2 = num;
				num3 = num + 1;
				while (this.GetEmpty(num2))
				{
					num2--;
					if (num2 < base.IndexFirst)
					{
						return PlotChannelInterpolationResult.Void;
					}
				}
				if (this.GetNull(num2))
				{
					return PlotChannelInterpolationResult.Null;
				}
				while (this.GetEmpty(num3))
				{
					num3++;
					if (num3 > base.IndexLast)
					{
						return PlotChannelInterpolationResult.Void;
					}
				}
				if (this.GetNull(num3))
				{
					return PlotChannelInterpolationResult.Null;
				}
			}
			else
			{
				if (num == base.IndexFirst)
				{
					return PlotChannelInterpolationResult.Invalid;
				}
				num2 = num - 1;
				num3 = num;
				while (this.GetEmpty(num2))
				{
					num2--;
					if (num2 < base.IndexFirst)
					{
						return PlotChannelInterpolationResult.Void;
					}
				}
				if (this.GetNull(num2))
				{
					return PlotChannelInterpolationResult.Null;
				}
				while (this.GetEmpty(num3))
				{
					num3++;
					if (num3 > base.IndexLast)
					{
						return PlotChannelInterpolationResult.Void;
					}
				}
				if (this.GetNull(num3))
				{
					return PlotChannelInterpolationResult.Null;
				}
			}
			double x2 = this.GetX(num2);
			double y = this.GetY(num2);
			double x3 = this.GetX(num3);
			double y2 = this.GetY(num3);
			yValue = (targetX - x2) / (x3 - x2) * (y2 - y) + y;
			return PlotChannelInterpolationResult.Valid;
		}

		public override int CalculateXValueNearestIndex(double value)
		{
			int num = (this.DataDirection != 0) ? this.CalcIndexesDecrementing(value) : this.CalcIndexesIncrementing(value);
			double num2 = Math.Abs(value - this.GetX(num));
			if (num > 0)
			{
				double num3 = Math.Abs(value - this.GetX(num - 1));
				if (num3 < num2)
				{
					return num - 1;
				}
			}
			if (num < base.IndexLast)
			{
				double num3 = Math.Abs(value - this.GetX(num + 1));
				if (num3 < num2)
				{
					return num + 1;
				}
			}
			return num;
		}

		private int CalcIndexesIncrementing(double targetValue)
		{
			int num = -1;
			int num2 = base.IndexFirst;
			int num3 = base.IndexLast;
			if (this.GetX(base.IndexFirst) == targetValue)
			{
				return base.IndexFirst;
			}
			if (this.GetX(base.IndexLast) == targetValue)
			{
				return base.IndexLast;
			}
			while (num2 <= num3)
			{
				int num4 = (num2 + num3) / 2;
				double x = this.GetX(num4);
				num = num4;
				if (x == targetValue)
				{
					break;
				}
				if (x > targetValue)
				{
					num3 = num4 - 1;
				}
				else
				{
					num2 = num4 + 1;
				}
			}
			if (num < base.IndexFirst)
			{
				num = base.IndexFirst;
			}
			if (num > base.IndexLast)
			{
				num = base.IndexLast;
			}
			return num;
		}

		private int CalcIndexesDecrementing(double targetValue)
		{
			int num = -1;
			int num2 = base.IndexFirst;
			int num3 = base.IndexLast;
			if (this.GetX(base.IndexFirst) == targetValue)
			{
				return base.IndexFirst;
			}
			if (this.GetX(base.IndexLast) == targetValue)
			{
				return base.IndexLast;
			}
			while (num2 <= num3)
			{
				int num4 = (num2 + num3) / 2;
				double x = this.GetX(num4);
				num = num4;
				if (x == targetValue)
				{
					break;
				}
				if (x > targetValue)
				{
					num2 = num4 + 1;
				}
				else
				{
					num3 = num4 - 1;
				}
			}
			if (num < base.IndexFirst)
			{
				num = base.IndexFirst;
			}
			if (num > base.IndexLast)
			{
				num = base.IndexLast;
			}
			return num;
		}

		protected override void LoadDesignTimeData(PlotXAxis xAxis, PlotYAxis yAxis, Random random, double yMin, double ySpan)
		{
			for (double num = xAxis.Min; num < xAxis.Max; num += xAxis.Span / 20.0)
			{
				this.AddXY(num, yMin + random.NextDouble() * ySpan);
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (this.RequireConsecutiveData)
			{
				this.UpdateDrawIndexes();
				if (this.DrawPointCount == 0)
				{
					base.CanDraw = false;
				}
			}
		}
	}
}
