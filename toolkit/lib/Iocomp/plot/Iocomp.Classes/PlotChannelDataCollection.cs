using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotChannelDataCollection
	{
		private IPlotChannelBase I_Channel;

		private ArrayList m_Data;

		private bool m_XValueNotValidWhenEmptyOrNull;

		private int m_XMeanCount;

		private int m_YMeanCount;

		private double m_XMeanSum;

		private double m_YMeanSum;

		private double m_XMin;

		private double m_XMax;

		private double m_XMean;

		private double m_XStandardDeviation;

		private double m_YMin;

		private double m_YMax;

		private double m_YMean;

		private double m_YStandardDeviation;

		private int m_RingBufferCount;

		private bool m_RingBufferEnabled;

		private int m_RingHeadIndex;

		private int m_RingTailIndex;

		private int m_LastNewDataPointIndex;

		public bool XValueNotValidWhenEmptyOrNull
		{
			get
			{
				return this.m_XValueNotValidWhenEmptyOrNull;
			}
			set
			{
				this.m_XValueNotValidWhenEmptyOrNull = value;
			}
		}

		public double XMin => this.m_XMin;

		public double XMax => this.m_XMax;

		public double XMean => this.m_XMean;

		public double XStandardDeviation => this.m_XStandardDeviation;

		public double YMin => this.m_YMin;

		public double YMax => this.m_YMax;

		public double YMean => this.m_YMean;

		public double YStandardDeviation => this.m_YStandardDeviation;

		public int RingBufferCount
		{
			get
			{
				return this.m_RingBufferCount;
			}
			set
			{
				if (this.RingBufferCount != value)
				{
					this.m_RingBufferCount = value;
					if (this.m_RingBufferCount != 0)
					{
						if (this.m_Data.Count > this.m_RingBufferCount)
						{
							this.m_Data.RemoveRange(this.m_RingBufferCount, this.m_Data.Count - this.m_RingBufferCount);
						}
						if (this.m_RingTailIndex == -1)
						{
							if (this.m_RingHeadIndex > this.m_Data.Count - 1)
							{
								this.m_RingHeadIndex = this.m_Data.Count - 1;
							}
						}
						else
						{
							this.m_RingHeadIndex = -1;
							this.m_RingTailIndex = -1;
						}
					}
					else if (this.m_RingTailIndex != -1)
					{
						this.m_Data.Clear();
					}
					if (this.I_Channel != null)
					{
						this.I_Channel.DoDataChange();
					}
				}
				this.m_RingBufferEnabled = (this.RingBufferCount != 0);
			}
		}

		private bool RingBufferEnabled => this.m_RingBufferEnabled;

		private bool RingBufferFull => this.RingBufferCount == this.m_Data.Count;

		public int Capacity
		{
			get
			{
				return this.m_Data.Capacity;
			}
			set
			{
				this.m_Data.Capacity = value;
			}
		}

		public int LastNewDataPointIndex => this.m_LastNewDataPointIndex;

		public int Count
		{
			get
			{
				if (this.RingBufferEnabled && this.m_RingTailIndex == -1)
				{
					return this.m_RingHeadIndex - this.m_RingTailIndex;
				}
				return this.m_Data.Count;
			}
		}

		public PlotDataPointBase this[int index]
		{
			get
			{
				if (this.RingBufferEnabled)
				{
					if (this.m_RingTailIndex == -1)
					{
						return (PlotDataPointBase)this.m_Data[index];
					}
					int num = index + this.m_RingTailIndex;
					if (num > this.m_Data.Count - 1)
					{
						num -= this.m_Data.Count;
					}
					return (PlotDataPointBase)this.m_Data[num];
				}
				return (PlotDataPointBase)this.m_Data[index];
			}
		}

		public PlotChannelDataCollection(PlotChannelBase value)
		{
			this.I_Channel = value;
			this.m_Data = new ArrayList();
			this.m_RingHeadIndex = -1;
			this.m_RingTailIndex = -1;
		}

		public void Clear()
		{
			if (this.RingBufferEnabled)
			{
				this.m_RingHeadIndex = -1;
				this.m_RingTailIndex = -1;
			}
			else
			{
				this.m_Data.Clear();
			}
			if (this.I_Channel != null)
			{
				this.I_Channel.DoDataChange();
			}
		}

		public void RemoveAt(int index)
		{
			if (!this.RingBufferEnabled)
			{
				this.m_Data.RemoveAt(index);
			}
		}

		public void RemoveRange(int index, int count)
		{
			if (!this.RingBufferEnabled)
			{
				this.m_Data.RemoveRange(index, count);
			}
		}

		public void ClearMinMeanMax()
		{
			this.m_XMeanCount = 0;
			this.m_XMeanSum = 0.0;
			this.m_YMeanCount = 0;
			this.m_YMeanSum = 0.0;
			this.m_XMin = double.PositiveInfinity;
			this.m_XMax = double.NegativeInfinity;
			this.m_YMin = double.PositiveInfinity;
			this.m_YMax = double.NegativeInfinity;
			this.m_XMean = 0.0;
			this.m_YMean = 0.0;
			this.m_XStandardDeviation = 0.0;
			this.m_YStandardDeviation = 0.0;
		}

		public void UpdateMinMaxMean(PlotDataPointYDouble dataPoint)
		{
			if ((dataPoint.Empty || dataPoint.Null) && this.XValueNotValidWhenEmptyOrNull)
			{
				return;
			}
			this.m_XMeanCount++;
			this.m_XMeanSum += dataPoint.X;
			this.m_XMean = this.m_XMeanSum / (double)this.m_XMeanCount;
			this.m_XMin = Math.Min(this.m_XMin, dataPoint.X);
			this.m_XMax = Math.Max(this.m_XMax, dataPoint.X);
			if (!dataPoint.Empty && !dataPoint.Null)
			{
				this.m_YMeanCount++;
				this.m_YMeanSum += dataPoint.Y;
				this.m_YMean = this.m_YMeanSum / (double)this.m_YMeanCount;
				this.m_YMin = Math.Min(this.m_YMin, dataPoint.Y);
				this.m_YMax = Math.Max(this.m_YMax, dataPoint.Y);
			}
		}

		public void UpdateMinMaxMean(double x, double y, bool isNull, bool isEmpty)
		{
			if ((isEmpty || isNull) && this.XValueNotValidWhenEmptyOrNull)
			{
				return;
			}
			this.m_XMeanCount++;
			this.m_XMeanSum += x;
			this.m_XMean = this.m_XMeanSum / (double)this.m_XMeanCount;
			this.m_XMin = Math.Min(this.m_XMin, x);
			this.m_XMax = Math.Max(this.m_XMax, x);
			if (!isEmpty && !isNull)
			{
				this.m_YMeanCount++;
				this.m_YMeanSum += y;
				this.m_YMean = this.m_YMeanSum / (double)this.m_YMeanCount;
				this.m_YMin = Math.Min(this.m_YMin, y);
				this.m_YMax = Math.Max(this.m_YMax, y);
			}
		}

		public void UpdateStandardDeviations()
		{
			this.m_XStandardDeviation = 0.0;
			this.m_YStandardDeviation = 0.0;
			if (this.Count != 0)
			{
				PlotDataPointYDouble plotDataPointYDouble = this[0] as PlotDataPointYDouble;
				if (plotDataPointYDouble != null)
				{
					double num = 0.0;
					double num2 = 0.0;
					int num3 = 0;
					int num4 = 0;
					for (int i = 0; i < this.Count; i++)
					{
						plotDataPointYDouble = (this[i] as PlotDataPointYDouble);
						if (!plotDataPointYDouble.Empty && !plotDataPointYDouble.Null)
						{
							goto IL_0083;
						}
						if (!this.XValueNotValidWhenEmptyOrNull)
						{
							goto IL_0083;
						}
						continue;
						IL_0083:
						num += (this.XMean - plotDataPointYDouble.X) * (this.XMean - plotDataPointYDouble.X);
						num3++;
						if (!plotDataPointYDouble.Empty && !plotDataPointYDouble.Null)
						{
							num2 += (this.YMean - plotDataPointYDouble.Y) * (this.YMean - plotDataPointYDouble.Y);
							num4++;
						}
					}
					num /= (double)num3;
					num2 /= (double)num4;
					this.m_XStandardDeviation = Math.Sqrt(num);
					this.m_YStandardDeviation = Math.Sqrt(num2);
				}
			}
		}

		public PlotDataPointBase AddNew()
		{
			if (this.I_Channel == null)
			{
				return null;
			}
			PlotDataPointBase plotDataPointBase;
			if (this.RingBufferEnabled)
			{
				if (!this.RingBufferFull && this.Count >= this.m_Data.Count)
				{
					plotDataPointBase = this.I_Channel.CreateDataPoint();
					this.m_LastNewDataPointIndex = this.m_Data.Add(plotDataPointBase);
					this.m_RingHeadIndex = this.m_LastNewDataPointIndex;
				}
				else
				{
					this.m_RingHeadIndex++;
					if (this.m_RingHeadIndex > this.m_Data.Count - 1)
					{
						this.m_RingHeadIndex = 0;
						this.m_RingTailIndex = 0;
					}
					if (this.m_RingTailIndex != -1)
					{
						this.m_RingTailIndex = this.m_RingHeadIndex + 1;
						if (this.m_RingTailIndex > this.m_Data.Count - 1)
						{
							this.m_RingTailIndex = 0;
						}
					}
					plotDataPointBase = (PlotDataPointBase)this.m_Data[this.m_RingHeadIndex];
					this.m_LastNewDataPointIndex = this.m_RingHeadIndex;
				}
			}
			else
			{
				plotDataPointBase = this.I_Channel.CreateDataPoint();
				this.m_LastNewDataPointIndex = this.m_Data.Add(plotDataPointBase);
			}
			return plotDataPointBase;
		}

		public PlotDataPointBase AddNew(int Index)
		{
			if (this.I_Channel == null)
			{
				return null;
			}
			if (this.RingBufferEnabled)
			{
				throw new Exception("Calling AddNew and specifying the Index is not allowed when the ring-buffer is enabled.");
			}
			PlotDataPointBase plotDataPointBase = this.I_Channel.CreateDataPoint();
			this.m_Data.Insert(Index, plotDataPointBase);
			this.m_LastNewDataPointIndex = this.m_Data.Count - 1;
			return plotDataPointBase;
		}
	}
}
