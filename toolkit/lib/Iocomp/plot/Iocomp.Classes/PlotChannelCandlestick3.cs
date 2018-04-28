using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Channel Candlestick-3")]
	public class PlotChannelCandlestick3 : PlotChannelConsecutive
	{
		private double m_WidthMinMax;

		private double m_WidthStdDev;

		private double m_WidthMean;

		private double m_ThicknessMean;

		private MagnitudeStyle m_WidthStyleMinMax;

		private MagnitudeStyle m_WidthStyleStdDev;

		private MagnitudeStyle m_WidthStyleMean;

		private MagnitudeStyle m_ThicknessStyleMean;

		private bool m_ShowMean;

		private bool m_DrawCustomDataPointAttributes;

		private PlotFill m_FillMinMax;

		protected IPlotFill I_FillMinMax;

		private PlotFill m_FillStdDev;

		protected IPlotFill I_FillStdDev;

		private PlotFill m_FillMean;

		protected IPlotFill I_FillMean;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double WidthMinMax
		{
			get
			{
				return this.m_WidthMinMax;
			}
			set
			{
				base.PropertyUpdateDefault("WidthMinMax", value);
				if (this.WidthMinMax != value)
				{
					this.m_WidthMinMax = value;
					base.DoPropertyChange(this, "WidthMinMax");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double WidthStdDev
		{
			get
			{
				return this.m_WidthStdDev;
			}
			set
			{
				base.PropertyUpdateDefault("WidthStdDev", value);
				if (this.WidthStdDev != value)
				{
					this.m_WidthStdDev = value;
					base.DoPropertyChange(this, "WidthStdDev");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double WidthMean
		{
			get
			{
				return this.m_WidthMean;
			}
			set
			{
				base.PropertyUpdateDefault("WidthMean", value);
				if (this.WidthMean != value)
				{
					this.m_WidthMean = value;
					base.DoPropertyChange(this, "WidthMean");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double ThicknessMean
		{
			get
			{
				return this.m_ThicknessMean;
			}
			set
			{
				base.PropertyUpdateDefault("ThicknessMean", value);
				if (this.ThicknessMean != value)
				{
					this.m_ThicknessMean = value;
					base.DoPropertyChange(this, "ThicknessMean");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public MagnitudeStyle WidthStyleMinMax
		{
			get
			{
				return this.m_WidthStyleMinMax;
			}
			set
			{
				base.PropertyUpdateDefault("WidthStyleMinMax", value);
				if (this.WidthStyleMinMax != value)
				{
					this.m_WidthStyleMinMax = value;
					base.DoPropertyChange(this, "WidthStyleMinMax");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public MagnitudeStyle WidthStyleStdDev
		{
			get
			{
				return this.m_WidthStyleStdDev;
			}
			set
			{
				base.PropertyUpdateDefault("WidthStyleStdDev", value);
				if (this.WidthStyleStdDev != value)
				{
					this.m_WidthStyleStdDev = value;
					base.DoPropertyChange(this, "WidthStyleStdDev");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public MagnitudeStyle WidthStyleMean
		{
			get
			{
				return this.m_WidthStyleMean;
			}
			set
			{
				base.PropertyUpdateDefault("WidthStyleMean", value);
				if (this.WidthStyleMean != value)
				{
					this.m_WidthStyleMean = value;
					base.DoPropertyChange(this, "WidthStyleMean");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public MagnitudeStyle ThicknessStyleMean
		{
			get
			{
				return this.m_ThicknessStyleMean;
			}
			set
			{
				base.PropertyUpdateDefault("ThicknessStyleMean", value);
				if (this.ThicknessStyleMean != value)
				{
					this.m_ThicknessStyleMean = value;
					base.DoPropertyChange(this, "ThicknessStyleMean");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool DrawCustomDataPointAttributes
		{
			get
			{
				return this.m_DrawCustomDataPointAttributes;
			}
			set
			{
				base.PropertyUpdateDefault("DrawCustomDataPointAttributes", value);
				if (this.DrawCustomDataPointAttributes != value)
				{
					this.m_DrawCustomDataPointAttributes = value;
					base.DoPropertyChange(this, "DrawCustomDataPointAttributes");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ShowMean
		{
			get
			{
				return this.m_ShowMean;
			}
			set
			{
				base.PropertyUpdateDefault("ShowMean", value);
				if (this.ShowMean != value)
				{
					this.m_ShowMean = value;
					base.DoPropertyChange(this, "ShowMean");
				}
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill FillMinMax
		{
			get
			{
				return this.m_FillMinMax;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill FillStdDev
		{
			get
			{
				return this.m_FillStdDev;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotFill FillMean
		{
			get
			{
				return this.m_FillMean;
			}
		}

		public PlotDataPointCandlestick3 this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointCandlestick3;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Channel Candlestick-3";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelCandlestick3EditorPlugIn";
		}

		public PlotChannelCandlestick3()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_FillMinMax = new PlotFill();
			base.AddSubClass(this.FillMinMax);
			this.I_FillMinMax = this.FillMinMax;
			this.m_FillStdDev = new PlotFill();
			base.AddSubClass(this.FillStdDev);
			this.I_FillStdDev = this.FillStdDev;
			this.m_FillMean = new PlotFill();
			base.AddSubClass(this.FillMean);
			this.I_FillMean = this.FillMean;
			((ISubClassBase)this.FillMinMax.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillMinMax.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillStdDev.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillStdDev.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillMean.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillMean.Brush).ColorAmbientSource = AmbientColorSouce.Color;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Candlestick-3";
			this.WidthMinMax = 1.0;
			this.WidthStdDev = 3.0;
			this.WidthMean = 4.0;
			this.ThicknessMean = 0.5;
			this.WidthStyleMinMax = MagnitudeStyle.Value;
			this.WidthStyleStdDev = MagnitudeStyle.Value;
			this.WidthStyleMean = MagnitudeStyle.Value;
			this.ThicknessStyleMean = MagnitudeStyle.Value;
			this.DrawCustomDataPointAttributes = false;
			this.ShowMean = true;
			this.FillMinMax.Visible = true;
			this.FillMinMax.Brush.Visible = true;
			this.FillMinMax.Pen.Visible = true;
			this.FillMinMax.Brush.Style = PlotBrushStyle.Solid;
			this.FillMinMax.Brush.SolidColor = Color.Red;
			this.FillMinMax.Brush.GradientStartColor = Color.Blue;
			this.FillMinMax.Brush.GradientStopColor = Color.Aqua;
			this.FillMinMax.Brush.HatchForeColor = Color.Empty;
			this.FillMinMax.Brush.HatchBackColor = Color.Empty;
			this.FillMinMax.Pen.Color = Color.Red;
			this.FillMinMax.Pen.Thickness = 1.0;
			this.FillMinMax.Pen.Style = PlotPenStyle.Solid;
			this.FillStdDev.Visible = true;
			this.FillStdDev.Brush.Visible = true;
			this.FillStdDev.Pen.Visible = true;
			this.FillStdDev.Brush.Style = PlotBrushStyle.Solid;
			this.FillStdDev.Brush.SolidColor = Color.Silver;
			this.FillStdDev.Brush.GradientStartColor = Color.Blue;
			this.FillStdDev.Brush.GradientStopColor = Color.Aqua;
			this.FillStdDev.Brush.HatchForeColor = Color.Empty;
			this.FillStdDev.Brush.HatchBackColor = Color.Empty;
			this.FillStdDev.Pen.Color = Color.Silver;
			this.FillStdDev.Pen.Thickness = 1.0;
			this.FillStdDev.Pen.Style = PlotPenStyle.Solid;
			this.FillMean.Visible = true;
			this.FillMean.Brush.Visible = true;
			this.FillMean.Pen.Visible = true;
			this.FillMean.Brush.Style = PlotBrushStyle.Solid;
			this.FillMean.Brush.SolidColor = Color.Red;
			this.FillMean.Brush.GradientStartColor = Color.Blue;
			this.FillMean.Brush.GradientStopColor = Color.Aqua;
			this.FillMean.Brush.HatchForeColor = Color.Empty;
			this.FillMean.Brush.HatchBackColor = Color.Empty;
			this.FillMean.Pen.Color = Color.Red;
			this.FillMean.Pen.Thickness = 1.0;
			this.FillMean.Pen.Style = PlotPenStyle.Solid;
		}

		private bool ShouldSerializeWidthMinMax()
		{
			return base.PropertyShouldSerialize("WidthMinMax");
		}

		private void ResetWidthMinMax()
		{
			base.PropertyReset("WidthMinMax");
		}

		private bool ShouldSerializeWidthStdDev()
		{
			return base.PropertyShouldSerialize("WidthStdDev");
		}

		private void ResetWidthStdDev()
		{
			base.PropertyReset("WidthStdDev");
		}

		private bool ShouldSerializeWidthMean()
		{
			return base.PropertyShouldSerialize("WidthMean");
		}

		private void ResetWidthMean()
		{
			base.PropertyReset("WidthMean");
		}

		private bool ShouldSerializeThicknessMean()
		{
			return base.PropertyShouldSerialize("ThicknessMean");
		}

		private void ResetThicknessMean()
		{
			base.PropertyReset("ThicknessMean");
		}

		private bool ShouldSerializeWidthStyleMinMax()
		{
			return base.PropertyShouldSerialize("WidthStyleMinMax");
		}

		private void ResetWidthStyleMinMax()
		{
			base.PropertyReset("WidthStyleMinMax");
		}

		private bool ShouldSerializeWidthStyleStdDev()
		{
			return base.PropertyShouldSerialize("WidthStyleStdDev");
		}

		private void ResetWidthStyleStdDev()
		{
			base.PropertyReset("WidthStyleStdDev");
		}

		private bool ShouldSerializeWidthStyleMean()
		{
			return base.PropertyShouldSerialize("WidthStyleMean");
		}

		private void ResetWidthStyleMean()
		{
			base.PropertyReset("WidthStyleMean");
		}

		private bool ShouldSerializeThicknessStyleMean()
		{
			return base.PropertyShouldSerialize("ThicknessStyleMean");
		}

		private void ResetThicknessStyleMean()
		{
			base.PropertyReset("ThicknessStyleMean");
		}

		private bool ShouldSerializeDrawCustomDataPointAttributes()
		{
			return base.PropertyShouldSerialize("DrawCustomDataPointAttributes");
		}

		private void ResetDrawCustomDataPointAttributes()
		{
			base.PropertyReset("DrawCustomDataPointAttributes");
		}

		private bool ShouldSerializeShowMean()
		{
			return base.PropertyShouldSerialize("ShowMean");
		}

		private void ResetShowMean()
		{
			base.PropertyReset("ShowMean");
		}

		private bool ShouldSerializeFillMinMax()
		{
			return ((ISubClassBase)this.FillMinMax).ShouldSerialize();
		}

		private void ResetFillMinMax()
		{
			((ISubClassBase)this.FillMinMax).ResetToDefault();
		}

		private bool ShouldSerializeFillStdDev()
		{
			return ((ISubClassBase)this.FillStdDev).ShouldSerialize();
		}

		private void ResetFillStdDev()
		{
			((ISubClassBase)this.FillStdDev).ResetToDefault();
		}

		private bool ShouldSerializeFillMean()
		{
			return ((ISubClassBase)this.FillMean).ShouldSerialize();
		}

		private void ResetFillMean()
		{
			((ISubClassBase)this.FillMean).ResetToDefault();
		}

		protected override PlotDataPointBase CreateDataPoint()
		{
			return new PlotDataPointCandlestick3(this);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue, double max, double min, double stdDevPos, double stdDevNeg)
		{
			base.CheckForValidNextX(x);
			PlotDataPointCandlestick3 plotDataPointCandlestick = (PlotDataPointCandlestick3)base.m_Data.AddNew();
			base.DataPointInitializing = true;
			try
			{
				plotDataPointCandlestick.X = x;
				plotDataPointCandlestick.Y = y;
				plotDataPointCandlestick.Null = nullValue;
				plotDataPointCandlestick.Empty = emptyValue;
				plotDataPointCandlestick.Max = max;
				plotDataPointCandlestick.Min = min;
				plotDataPointCandlestick.StdDevPos = stdDevPos;
				plotDataPointCandlestick.StdDevNeg = stdDevNeg;
				plotDataPointCandlestick.WidthMinMax = this.WidthMinMax;
				plotDataPointCandlestick.WidthStdDev = this.WidthStdDev;
				plotDataPointCandlestick.WidthMean = this.WidthMean;
				plotDataPointCandlestick.ThicknessMean = this.ThicknessMean;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			base.m_Data.UpdateMinMaxMean(plotDataPointCandlestick);
			if (base.SendXAxisTrackingData)
			{
				PlotXAxis xAxis = base.XAxis;
				if (xAxis != null)
				{
					double num = 0.0;
					double normalizedWidth = base.GetNormalizedWidth(xAxis, this.WidthMinMax, this.WidthStyleMinMax);
					if (normalizedWidth > num)
					{
						num = normalizedWidth;
					}
					normalizedWidth = base.GetNormalizedWidth(xAxis, this.WidthStdDev, this.WidthStyleStdDev);
					if (normalizedWidth > num)
					{
						num = normalizedWidth;
					}
					if (this.ShowMean)
					{
						normalizedWidth = base.GetNormalizedWidth(xAxis, this.WidthMean, this.WidthStyleMean);
						if (normalizedWidth > num)
						{
							num = normalizedWidth;
						}
					}
					base.XAxis.Tracking.NewData(x - num / 2.0);
					base.XAxis.Tracking.NewData(x + num / 2.0);
				}
			}
			if (!nullValue && !emptyValue && base.SendYAxisTrackingData)
			{
				PlotYAxis yAxis = base.YAxis;
				if (yAxis != null)
				{
					base.YAxis.Tracking.NewData(max);
					base.YAxis.Tracking.NewData(min);
				}
			}
			this.DoDataChange();
			return base.m_Data.LastNewDataPointIndex;
		}

		public int AddXY(double x, double y, double max, double min, double stdDevPos, double stdDevNeg)
		{
			return this.AddXY(x, y, false, false, max, min, stdDevPos, stdDevNeg);
		}

		public override int AddXY(double x, double y)
		{
			return this.AddXY(x, y, false, false, 0.0, 0.0, 0.0, 0.0);
		}

		public override int AddEmpty(double x)
		{
			return this.AddXY(x, 0.0, false, true, 0.0, 0.0, 0.0, 0.0);
		}

		public override int AddNull(double x)
		{
			return this.AddXY(x, 0.0, true, false, 0.0, 0.0, 0.0, 0.0);
		}

		public override double GetX(int index)
		{
			return this[index].X;
		}

		public override double GetY(int index)
		{
			return this[index].Y;
		}

		public override bool GetNull(int index)
		{
			return this[index].Null;
		}

		public override bool GetEmpty(int index)
		{
			return this[index].Empty;
		}

		public override void SetX(int index, double value)
		{
			this[index].X = value;
		}

		public override void SetY(int index, double value)
		{
			this[index].Y = value;
		}

		public override void SetNull(int index, bool value)
		{
			this[index].Null = value;
		}

		public override void SetEmpty(int index, bool value)
		{
			this[index].Empty = value;
		}

		protected override void LoadDesignTimeData(PlotXAxis xAxis, PlotYAxis yAxis, Random random, double yMin, double ySpan)
		{
			double num = 0.0;
			if (this.WidthMinMax > num)
			{
				num = this.WidthMinMax;
			}
			if (this.WidthStdDev > num)
			{
				num = this.WidthStdDev;
			}
			if (this.ShowMean && this.WidthMean > num)
			{
				num = this.WidthMean;
			}
			for (double num2 = xAxis.Min; num2 < xAxis.Max; num2 += num * 3.0)
			{
				double num3 = yMin + random.NextDouble() * ySpan;
				this.AddXY(num2, num3, false, false, num3 + ySpan * 0.4, num3 - ySpan * 0.4, num3 + ySpan * 0.15, num3 - ySpan * 0.15);
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			bool flag = false;
			if (this.FillMinMax.DrawVisible)
			{
				flag = true;
			}
			if (this.FillStdDev.DrawVisible)
			{
				flag = true;
			}
			if (this.FillMean.DrawVisible)
			{
				flag = true;
			}
			if (!flag)
			{
				base.CanDraw = false;
			}
		}

		protected override void DrawLegendMarker(PaintArgs p, Rectangle r)
		{
			Point point = iRectangle.CenterPoint2(r);
			int num = (int)Math.Round((double)r.Width * 0.6);
			double num2 = 0.0;
			if (this.WidthMinMax > num2)
			{
				num2 = this.WidthMinMax;
			}
			if (this.WidthStdDev > num2)
			{
				num2 = this.WidthStdDev;
			}
			if (this.ShowMean && this.WidthMean > num2)
			{
				num2 = this.WidthMean;
			}
			int width = (int)Math.Round((double)num * this.WidthMinMax / num2);
			int height = r.Height;
			Size size = new Size(width, height);
			Point location = new Point(point.X - size.Width / 2, point.Y - size.Height / 2);
			this.I_FillMinMax.Draw(p, new Rectangle(location, size));
			width = (int)Math.Round((double)num * this.WidthStdDev / num2);
			height = r.Height / 2;
			height = height / 2 * 2;
			size = new Size(width, height);
			location = new Point(point.X - size.Width / 2, point.Y - size.Height / 2);
			this.I_FillStdDev.Draw(p, new Rectangle(location, size));
			if (this.ShowMean)
			{
				width = (int)Math.Round((double)num * this.WidthMean / num2);
				height = r.Height / 10;
				height = height / 2 * 2;
				if (height < 2)
				{
					height = 2;
				}
				size = new Size(width, height);
				location = new Point(point.X - size.Width / 2, point.Y - size.Height / 2);
				this.I_FillMean.Draw(p, new Rectangle(location, size));
			}
		}

		protected void DrawBlock(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis, IPlotFill fill, double centerX, double max, double min, MagnitudeStyle widthStyle, double width)
		{
			if (!fill.NotDrawVisible)
			{
				double normalizedWidth = base.GetNormalizedWidth(xAxis, width, widthStyle);
				int num = xAxis.ScaleDisplay.ValueToPixels(centerX - normalizedWidth / 2.0);
				int num2 = xAxis.ScaleDisplay.ValueToPixels(centerX + normalizedWidth / 2.0);
				int top = yAxis.ScaleDisplay.ValueToPixels(max);
				int bottom = yAxis.ScaleDisplay.ValueToPixels(min);
				if (num == num2)
				{
					num2++;
				}
				Rectangle r = iRectangle.FromLTRB(base.XYSwapped, num, top, num2, bottom);
				fill.Draw(p, r);
			}
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			for (int i = this.IndexDrawStart; i <= this.IndexDrawStop; i++)
			{
				PlotDataPointCandlestick3 plotDataPointCandlestick = this[i];
				if (!plotDataPointCandlestick.Empty && !plotDataPointCandlestick.Null)
				{
					double x = plotDataPointCandlestick.X;
					double widthMinMax;
					PlotFill fillMinMax;
					if (this.DrawCustomDataPointAttributes)
					{
						widthMinMax = plotDataPointCandlestick.WidthMinMax;
						fillMinMax = plotDataPointCandlestick.FillMinMax;
					}
					else
					{
						widthMinMax = this.WidthMinMax;
						fillMinMax = this.FillMinMax;
					}
					this.DrawBlock(p, xAxis, yAxis, fillMinMax, x, plotDataPointCandlestick.Max, plotDataPointCandlestick.Min, this.WidthStyleMinMax, widthMinMax);
					if (this.DrawCustomDataPointAttributes)
					{
						widthMinMax = plotDataPointCandlestick.WidthStdDev;
						fillMinMax = plotDataPointCandlestick.FillStdDev;
					}
					else
					{
						widthMinMax = this.WidthStdDev;
						fillMinMax = this.FillStdDev;
					}
					this.DrawBlock(p, xAxis, yAxis, fillMinMax, x, plotDataPointCandlestick.StdDevPos, plotDataPointCandlestick.StdDevNeg, this.WidthStyleStdDev, widthMinMax);
					if (this.ShowMean)
					{
						if (this.DrawCustomDataPointAttributes)
						{
							widthMinMax = plotDataPointCandlestick.WidthMean;
							fillMinMax = plotDataPointCandlestick.FillMean;
						}
						else
						{
							widthMinMax = this.WidthMean;
							fillMinMax = this.FillMean;
						}
						double height = (!this.DrawCustomDataPointAttributes) ? this.ThicknessMean : plotDataPointCandlestick.ThicknessMean;
						double normalizedHeight = base.GetNormalizedHeight(yAxis, height, this.ThicknessStyleMean);
						this.DrawBlock(p, xAxis, yAxis, fillMinMax, x, plotDataPointCandlestick.Y + normalizedHeight / 2.0, plotDataPointCandlestick.Y - normalizedHeight / 2.0, this.WidthStyleMean, widthMinMax);
					}
				}
			}
		}
	}
}
