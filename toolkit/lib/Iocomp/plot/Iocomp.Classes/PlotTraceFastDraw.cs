using System;
using System.Drawing;

namespace Iocomp.Classes
{
	public class PlotTraceFastDraw
	{
		private PlotXAxis m_XAxis;

		private PlotYAxis m_YAxis;

		private PaintArgs m_P;

		private Pen m_Pen;

		private int m_PixelXLast;

		private int m_PixelXNext;

		private int m_PixelYMin;

		private int m_PixelYMax;

		private int m_PixelYLast;

		private bool m_Empty;

		private bool m_HighLowCached;

		private bool m_HorizontalCached;

		private bool m_TraceVisible;

		private bool m_XYSwapped;

		private bool m_FillVisible;

		private Brush m_FillBrush;

		private int m_FillRefPixel;

		private Point[] m_Points;

		public PlotXAxis XAxis
		{
			get
			{
				return this.m_XAxis;
			}
			set
			{
				this.m_XAxis = value;
			}
		}

		public PlotYAxis YAxis
		{
			get
			{
				return this.m_YAxis;
			}
			set
			{
				this.m_YAxis = value;
			}
		}

		public PaintArgs P
		{
			get
			{
				return this.m_P;
			}
			set
			{
				this.m_P = value;
			}
		}

		public Pen Pen
		{
			get
			{
				return this.m_Pen;
			}
			set
			{
				this.m_Pen = value;
			}
		}

		public bool TraceVisible
		{
			get
			{
				return this.m_TraceVisible;
			}
			set
			{
				this.m_TraceVisible = value;
			}
		}

		public bool XYSwapped
		{
			get
			{
				return this.m_XYSwapped;
			}
			set
			{
				this.m_XYSwapped = value;
			}
		}

		public bool FillVisible
		{
			get
			{
				return this.m_FillVisible;
			}
			set
			{
				this.m_FillVisible = value;
			}
		}

		public Brush FillBrush
		{
			get
			{
				return this.m_FillBrush;
			}
			set
			{
				this.m_FillBrush = value;
			}
		}

		public int FillRefPixel
		{
			get
			{
				return this.m_FillRefPixel;
			}
			set
			{
				this.m_FillRefPixel = value;
			}
		}

		public void CleanupHighLowCached()
		{
			if (this.TraceVisible)
			{
				if (this.m_PixelYMax != this.m_PixelYMin)
				{
					if (this.XYSwapped)
					{
						this.P.Graphics.DrawLine(this.m_Pen, this.m_PixelYMin, this.m_PixelXLast, this.m_PixelYMax, this.m_PixelXLast);
					}
					else
					{
						this.P.Graphics.DrawLine(this.m_Pen, this.m_PixelXLast, this.m_PixelYMin, this.m_PixelXLast, this.m_PixelYMax);
					}
				}
				this.m_HighLowCached = false;
			}
		}

		public void CleanupHorizontalCached()
		{
			if (this.TraceVisible)
			{
				if (this.XYSwapped)
				{
					this.P.Graphics.DrawLine(this.m_Pen, this.m_PixelYLast, this.m_PixelXLast, this.m_PixelYLast, this.m_PixelXNext);
				}
				else
				{
					this.P.Graphics.DrawLine(this.m_Pen, this.m_PixelXLast, this.m_PixelYLast, this.m_PixelXNext, this.m_PixelYLast);
				}
				if (this.FillVisible)
				{
					if (this.m_Points == null)
					{
						this.m_Points = new Point[4];
					}
					if (this.XYSwapped)
					{
						this.m_Points[0].X = this.m_FillRefPixel;
						this.m_Points[0].Y = this.m_PixelXLast;
					}
					else
					{
						this.m_Points[0].X = this.m_PixelXLast;
						this.m_Points[0].Y = this.m_FillRefPixel;
					}
					if (this.XYSwapped)
					{
						this.m_Points[1].X = this.m_PixelYLast;
						this.m_Points[1].Y = this.m_PixelXLast;
					}
					else
					{
						this.m_Points[1].X = this.m_PixelXLast;
						this.m_Points[1].Y = this.m_PixelYLast;
					}
					if (this.XYSwapped)
					{
						this.m_Points[2].X = this.m_PixelYLast;
						this.m_Points[2].Y = this.m_PixelXNext;
					}
					else
					{
						this.m_Points[2].X = this.m_PixelXNext;
						this.m_Points[2].Y = this.m_PixelYLast;
					}
					if (this.XYSwapped)
					{
						this.m_Points[3].X = this.m_FillRefPixel;
						this.m_Points[3].Y = this.m_PixelXNext;
					}
					else
					{
						this.m_Points[3].X = this.m_PixelXNext;
						this.m_Points[3].Y = this.m_FillRefPixel;
					}
					this.P.Graphics.FillPolygon(this.FillBrush, this.m_Points);
				}
				this.m_PixelXLast = this.m_PixelXNext;
				this.m_HorizontalCached = false;
			}
		}

		public void AddDataPoint(PlotDataPointYDouble dataPoint)
		{
			if (!dataPoint.Empty)
			{
				if (dataPoint.Null)
				{
					this.DrawFlush();
				}
				else
				{
					int num = this.m_XAxis.ScaleDisplay.ValueToPixels(dataPoint.X);
					int num2 = this.m_YAxis.ScaleDisplay.ValueToPixels(dataPoint.Y);
					if (this.m_Empty)
					{
						this.m_PixelXLast = num;
						this.m_PixelYMin = num2;
						this.m_PixelYMax = num2;
						this.m_PixelYLast = num2;
						this.m_Empty = false;
					}
					else if (num == this.m_PixelXLast && num2 != this.m_PixelYLast)
					{
						this.m_PixelYMin = Math.Min(this.m_PixelYMin, num2);
						this.m_PixelYMax = Math.Max(this.m_PixelYMax, num2);
						this.m_PixelYLast = num2;
						this.m_HighLowCached = true;
					}
					else
					{
						if (this.m_HighLowCached)
						{
							this.CleanupHighLowCached();
						}
						if (this.m_PixelYLast == num2)
						{
							this.m_PixelXNext = num;
							this.m_HorizontalCached = true;
						}
						else
						{
							if (this.m_HorizontalCached)
							{
								this.CleanupHorizontalCached();
							}
							if (this.TraceVisible)
							{
								if (this.XYSwapped)
								{
									this.P.Graphics.DrawLine(this.m_Pen, this.m_PixelYLast, this.m_PixelXLast, num2, num);
								}
								else
								{
									this.P.Graphics.DrawLine(this.m_Pen, this.m_PixelXLast, this.m_PixelYLast, num, num2);
								}
							}
							if (this.FillVisible)
							{
								if (this.m_Points == null)
								{
									this.m_Points = new Point[4];
								}
								if (this.XYSwapped)
								{
									this.m_Points[0].X = this.m_FillRefPixel;
									this.m_Points[0].Y = this.m_PixelXLast;
									this.m_Points[1].X = this.m_PixelYLast;
									this.m_Points[1].Y = this.m_PixelXLast;
									this.m_Points[2].X = num2;
									this.m_Points[2].Y = num;
									this.m_Points[3].X = this.m_FillRefPixel;
									this.m_Points[3].Y = num;
								}
								else
								{
									this.m_Points[0].X = this.m_PixelXLast;
									this.m_Points[0].Y = this.m_FillRefPixel;
									this.m_Points[1].X = this.m_PixelXLast;
									this.m_Points[1].Y = this.m_PixelYLast;
									this.m_Points[2].X = num;
									this.m_Points[2].Y = num2;
									this.m_Points[3].X = num;
									this.m_Points[3].Y = this.m_FillRefPixel;
								}
								this.P.Graphics.FillPolygon(this.FillBrush, this.m_Points);
							}
							this.m_PixelXLast = num;
							this.m_PixelYMin = num2;
							this.m_PixelYMax = num2;
							this.m_PixelYLast = num2;
						}
					}
				}
			}
		}

		public void Reset()
		{
			this.m_Empty = true;
			this.m_HighLowCached = false;
			this.m_HorizontalCached = false;
		}

		public void DrawFlush()
		{
			if (this.m_HighLowCached)
			{
				this.CleanupHighLowCached();
			}
			if (this.m_HorizontalCached)
			{
				this.CleanupHorizontalCached();
			}
			this.m_Empty = true;
		}
	}
}
