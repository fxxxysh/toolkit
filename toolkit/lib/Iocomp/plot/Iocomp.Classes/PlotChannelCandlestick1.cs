using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Channel Candlestick-1")]
	public class PlotChannelCandlestick1 : PlotChannelConsecutive
	{
		private double m_WidthBody;

		private double m_WidthShadow;

		private MagnitudeStyle m_WidthStyleBody;

		private MagnitudeStyle m_WidthStyleShadow;

		private PlotFill m_FillBodyBullish;

		protected IPlotFill I_FillBodyBullish;

		private PlotFill m_FillBodyBearish;

		protected IPlotFill I_FillBodyBearish;

		private PlotFill m_FillShadow;

		protected IPlotFill I_FillShadow;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double WidthBody
		{
			get
			{
				return this.m_WidthBody;
			}
			set
			{
				base.PropertyUpdateDefault("WidthBody", value);
				if (this.WidthBody != value)
				{
					this.m_WidthBody = value;
					base.DoPropertyChange(this, "WidthBody");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double WidthShadow
		{
			get
			{
				return this.m_WidthShadow;
			}
			set
			{
				base.PropertyUpdateDefault("WidthShadow", value);
				if (this.WidthShadow != value)
				{
					this.m_WidthShadow = value;
					base.DoPropertyChange(this, "WidthShadow");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public MagnitudeStyle WidthStyleBody
		{
			get
			{
				return this.m_WidthStyleBody;
			}
			set
			{
				base.PropertyUpdateDefault("WidthStyleBody", value);
				if (this.WidthStyleBody != value)
				{
					this.m_WidthStyleBody = value;
					base.DoPropertyChange(this, "WidthStyleBody");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public MagnitudeStyle WidthStyleShadow
		{
			get
			{
				return this.m_WidthStyleShadow;
			}
			set
			{
				base.PropertyUpdateDefault("WidthStyleShadow", value);
				if (this.WidthStyleShadow != value)
				{
					this.m_WidthStyleShadow = value;
					base.DoPropertyChange(this, "WidthStyleShadow");
				}
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill FillBodyBullish
		{
			get
			{
				return this.m_FillBodyBullish;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotFill FillBodyBearish
		{
			get
			{
				return this.m_FillBodyBearish;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill FillShadow
		{
			get
			{
				return this.m_FillShadow;
			}
		}

		public PlotDataPointCandlestick1 this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointCandlestick1;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Channel Candlestick-1";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelCandlestick1EditorPlugIn";
		}

		public PlotChannelCandlestick1()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_FillBodyBullish = new PlotFill();
			base.AddSubClass(this.FillBodyBullish);
			this.I_FillBodyBullish = this.FillBodyBullish;
			this.m_FillBodyBearish = new PlotFill();
			base.AddSubClass(this.FillBodyBearish);
			this.I_FillBodyBearish = this.FillBodyBearish;
			this.m_FillShadow = new PlotFill();
			base.AddSubClass(this.FillShadow);
			this.I_FillShadow = this.FillShadow;
			((ISubClassBase)this.FillBodyBullish.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillBodyBullish.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillBodyBearish.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillBodyBearish.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillShadow.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillShadow.Brush).ColorAmbientSource = AmbientColorSouce.Color;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Candlestick-1";
			this.WidthBody = 1.0;
			this.WidthShadow = 1.0;
			this.WidthStyleBody = MagnitudeStyle.Value;
			this.WidthStyleShadow = MagnitudeStyle.Pixel;
			this.FillBodyBullish.Visible = true;
			this.FillBodyBullish.Brush.Visible = true;
			this.FillBodyBullish.Pen.Visible = true;
			this.FillBodyBullish.Brush.Style = PlotBrushStyle.Solid;
			this.FillBodyBullish.Brush.SolidColor = Color.Green;
			this.FillBodyBullish.Brush.GradientStartColor = Color.Blue;
			this.FillBodyBullish.Brush.GradientStopColor = Color.Aqua;
			this.FillBodyBullish.Brush.HatchForeColor = Color.Empty;
			this.FillBodyBullish.Brush.HatchBackColor = Color.Empty;
			this.FillBodyBullish.Pen.Color = Color.Black;
			this.FillBodyBullish.Pen.Thickness = 1.0;
			this.FillBodyBullish.Pen.Style = PlotPenStyle.Solid;
			this.FillBodyBearish.Visible = true;
			this.FillBodyBearish.Brush.Visible = true;
			this.FillBodyBearish.Pen.Visible = true;
			this.FillBodyBearish.Brush.Style = PlotBrushStyle.Solid;
			this.FillBodyBearish.Brush.SolidColor = Color.Red;
			this.FillBodyBearish.Brush.GradientStartColor = Color.Blue;
			this.FillBodyBearish.Brush.GradientStopColor = Color.Aqua;
			this.FillBodyBearish.Brush.HatchForeColor = Color.Empty;
			this.FillBodyBearish.Brush.HatchBackColor = Color.Empty;
			this.FillBodyBearish.Pen.Color = Color.Black;
			this.FillBodyBearish.Pen.Thickness = 1.0;
			this.FillBodyBearish.Pen.Style = PlotPenStyle.Solid;
			this.FillShadow.Visible = true;
			this.FillShadow.Brush.Visible = true;
			this.FillShadow.Pen.Visible = true;
			this.FillShadow.Brush.Style = PlotBrushStyle.Solid;
			this.FillShadow.Brush.SolidColor = Color.Silver;
			this.FillShadow.Brush.GradientStartColor = Color.Blue;
			this.FillShadow.Brush.GradientStopColor = Color.Aqua;
			this.FillShadow.Brush.HatchForeColor = Color.Empty;
			this.FillShadow.Brush.HatchBackColor = Color.Empty;
			this.FillShadow.Pen.Color = Color.Silver;
			this.FillShadow.Pen.Thickness = 1.0;
			this.FillShadow.Pen.Style = PlotPenStyle.Solid;
		}

		private bool ShouldSerializeWidthBody()
		{
			return base.PropertyShouldSerialize("WidthBody");
		}

		private void ResetWidthBody()
		{
			base.PropertyReset("WidthBody");
		}

		private bool ShouldSerializeWidthShadow()
		{
			return base.PropertyShouldSerialize("WidthShadow");
		}

		private void ResetWidthShadow()
		{
			base.PropertyReset("WidthShadow");
		}

		private bool ShouldSerializeWidthStyleBody()
		{
			return base.PropertyShouldSerialize("WidthStyleBody");
		}

		private void ResetWidthStyleBody()
		{
			base.PropertyReset("WidthStyleBody");
		}

		private bool ShouldSerializeWidthStyleShadow()
		{
			return base.PropertyShouldSerialize("WidthStyleShadow");
		}

		private void ResetWidthStyleShadow()
		{
			base.PropertyReset("WidthStyleShadow");
		}

		private bool ShouldSerializeFillBodyBullish()
		{
			return ((ISubClassBase)this.FillBodyBullish).ShouldSerialize();
		}

		private void ResetFillBodBullishy()
		{
			((ISubClassBase)this.FillBodyBullish).ResetToDefault();
		}

		private bool ShouldSerializeFillBodyBearish()
		{
			return ((ISubClassBase)this.FillBodyBearish).ShouldSerialize();
		}

		private void ResetFillBodyBearish()
		{
			((ISubClassBase)this.FillBodyBearish).ResetToDefault();
		}

		private bool ShouldSerializeFillShadow()
		{
			return ((ISubClassBase)this.FillShadow).ShouldSerialize();
		}

		private void ResetFillShadow()
		{
			((ISubClassBase)this.FillShadow).ResetToDefault();
		}

		protected override PlotDataPointBase CreateDataPoint()
		{
			return new PlotDataPointCandlestick1(this);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue, double high, double low, double open, double close)
		{
			base.CheckForValidNextX(x);
			PlotDataPointCandlestick1 plotDataPointCandlestick = (PlotDataPointCandlestick1)base.m_Data.AddNew();
			base.DataPointInitializing = true;
			try
			{
				plotDataPointCandlestick.X = x;
				plotDataPointCandlestick.Y = y;
				plotDataPointCandlestick.Null = nullValue;
				plotDataPointCandlestick.Empty = emptyValue;
				plotDataPointCandlestick.High = high;
				plotDataPointCandlestick.Low = low;
				plotDataPointCandlestick.Open = open;
				plotDataPointCandlestick.Close = close;
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
					double normalizedWidth = base.GetNormalizedWidth(xAxis, this.WidthBody, this.WidthStyleBody);
					if (normalizedWidth > num)
					{
						num = normalizedWidth;
					}
					normalizedWidth = base.GetNormalizedWidth(xAxis, this.WidthShadow, this.WidthStyleShadow);
					if (normalizedWidth > num)
					{
						num = normalizedWidth;
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
					base.YAxis.Tracking.NewData(high);
					base.YAxis.Tracking.NewData(low);
				}
			}
			this.DoDataChange();
			return base.m_Data.LastNewDataPointIndex;
		}

		public int AddXY(double x, double y, double high, double low, double open, double close)
		{
			return this.AddXY(x, y, false, false, high, low, open, close);
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
			double widthBody = this.WidthBody;
			for (double num = xAxis.Min; num < xAxis.Max; num += widthBody * 3.0)
			{
				double num2 = yMin + random.NextDouble() * ySpan;
				this.AddXY(num, num2, false, false, num2 + ySpan * 0.4, num2 - ySpan * 0.4, num2 + ySpan * 0.15, num2 - ySpan * 0.15);
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			bool flag = false;
			if (this.FillBodyBullish.DrawVisible)
			{
				flag = true;
			}
			if (this.FillBodyBearish.DrawVisible)
			{
				flag = true;
			}
			if (this.FillShadow.DrawVisible)
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
			if (base.XAxis != null)
			{
				Point point = iRectangle.CenterPoint2(r);
				int num = (int)Math.Round((double)r.Width * 0.6);
				double normalizedWidth = base.GetNormalizedWidth(base.XAxis, this.WidthBody, this.WidthStyleBody);
				double normalizedWidth2 = base.GetNormalizedWidth(base.XAxis, this.WidthShadow, this.WidthStyleShadow);
				double num2 = 0.0;
				if (normalizedWidth > num2)
				{
					num2 = normalizedWidth;
				}
				if (normalizedWidth2 > num2)
				{
					num2 = normalizedWidth2;
				}
				int width = (int)Math.Round((double)num * normalizedWidth2 / num2);
				int height = r.Height;
				Size size = new Size(width, height);
				Point location = new Point(point.X - (size.Width + 1) / 2, point.Y - size.Height / 2);
				this.I_FillShadow.Draw(p, new Rectangle(location, size));
				width = (int)Math.Round((double)num * normalizedWidth / num2);
				height = r.Height / 2;
				height = height / 2 * 2;
				size = new Size(width, height);
				location = new Point(point.X - (size.Width + 1) / 2, point.Y - size.Height / 2);
				this.I_FillBodyBullish.Draw(p, new Rectangle(location, size));
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
				PlotDataPointCandlestick1 plotDataPointCandlestick = this[i];
				if (!plotDataPointCandlestick.Empty && !plotDataPointCandlestick.Null)
				{
					double x = plotDataPointCandlestick.X;
					this.DrawBlock(p, xAxis, yAxis, this.FillShadow, x, plotDataPointCandlestick.High, plotDataPointCandlestick.Low, this.WidthStyleShadow, this.WidthShadow);
					PlotFill fill = (!(plotDataPointCandlestick.Close >= plotDataPointCandlestick.Open)) ? this.FillBodyBearish : this.FillBodyBullish;
					this.DrawBlock(p, xAxis, yAxis, fill, x, plotDataPointCandlestick.Open, plotDataPointCandlestick.Close, this.WidthStyleBody, this.WidthBody);
				}
			}
		}
	}
}
