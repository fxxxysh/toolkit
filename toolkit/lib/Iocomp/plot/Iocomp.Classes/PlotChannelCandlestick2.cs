using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Channel Candlestick-2")]
	public class PlotChannelCandlestick2 : PlotChannelConsecutive
	{
		private double m_WidthBody;

		private double m_WidthOpen;

		private double m_WidthClose;

		private double m_HeightOpen;

		private double m_HeightClose;

		private MagnitudeStyle m_WidthStyleBody;

		private MagnitudeStyle m_WidthStyleOpen;

		private MagnitudeStyle m_WidthStyleClose;

		private MagnitudeStyle m_HeightStyleOpen;

		private MagnitudeStyle m_HeightStyleClose;

		private bool m_ShowOpen;

		private bool m_ShowClose;

		private PlotFill m_FillBody;

		protected IPlotFill I_FillBody;

		private PlotFill m_FillOpen;

		protected IPlotFill I_FillOpen;

		private PlotFill m_FillClose;

		protected IPlotFill I_FillClose;

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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double WidthOpen
		{
			get
			{
				return this.m_WidthOpen;
			}
			set
			{
				base.PropertyUpdateDefault("WidthOpen", value);
				if (this.WidthOpen != value)
				{
					this.m_WidthOpen = value;
					base.DoPropertyChange(this, "WidthOpen");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double WidthClose
		{
			get
			{
				return this.m_WidthClose;
			}
			set
			{
				base.PropertyUpdateDefault("WidthClose", value);
				if (this.WidthClose != value)
				{
					this.m_WidthClose = value;
					base.DoPropertyChange(this, "WidthClose");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double HeightOpen
		{
			get
			{
				return this.m_HeightOpen;
			}
			set
			{
				base.PropertyUpdateDefault("HeightOpen", value);
				if (this.HeightOpen != value)
				{
					this.m_HeightOpen = value;
					base.DoPropertyChange(this, "HeightOpen");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double HeightClose
		{
			get
			{
				return this.m_HeightClose;
			}
			set
			{
				base.PropertyUpdateDefault("HeightClose", value);
				if (this.HeightClose != value)
				{
					this.m_HeightClose = value;
					base.DoPropertyChange(this, "HeightClose");
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
		public MagnitudeStyle WidthStyleOpen
		{
			get
			{
				return this.m_WidthStyleOpen;
			}
			set
			{
				base.PropertyUpdateDefault("WidthStyleOpen", value);
				if (this.WidthStyleOpen != value)
				{
					this.m_WidthStyleOpen = value;
					base.DoPropertyChange(this, "WidthStyleOpen");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public MagnitudeStyle WidthStyleClose
		{
			get
			{
				return this.m_WidthStyleClose;
			}
			set
			{
				base.PropertyUpdateDefault("WidthStyleClose", value);
				if (this.WidthStyleClose != value)
				{
					this.m_WidthStyleClose = value;
					base.DoPropertyChange(this, "WidthStyleClose");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public MagnitudeStyle HeightStyleOpen
		{
			get
			{
				return this.m_HeightStyleOpen;
			}
			set
			{
				base.PropertyUpdateDefault("HeightStyleOpen", value);
				if (this.HeightStyleOpen != value)
				{
					this.m_HeightStyleOpen = value;
					base.DoPropertyChange(this, "HeightStyleOpen");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public MagnitudeStyle HeightStyleClose
		{
			get
			{
				return this.m_HeightStyleClose;
			}
			set
			{
				base.PropertyUpdateDefault("HeightStyleClose", value);
				if (this.HeightStyleClose != value)
				{
					this.m_HeightStyleClose = value;
					base.DoPropertyChange(this, "HeightStyleClose");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ShowOpen
		{
			get
			{
				return this.m_ShowOpen;
			}
			set
			{
				base.PropertyUpdateDefault("ShowOpen", value);
				if (this.ShowOpen != value)
				{
					this.m_ShowOpen = value;
					base.DoPropertyChange(this, "ShowOpen");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ShowClose
		{
			get
			{
				return this.m_ShowClose;
			}
			set
			{
				base.PropertyUpdateDefault("ShowClose", value);
				if (this.ShowClose != value)
				{
					this.m_ShowClose = value;
					base.DoPropertyChange(this, "ShowClose");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotFill FillBody
		{
			get
			{
				return this.m_FillBody;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill FillOpen
		{
			get
			{
				return this.m_FillOpen;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill FillClose
		{
			get
			{
				return this.m_FillClose;
			}
		}

		public PlotDataPointCandlestick2 this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointCandlestick2;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Channel Candlestick-2";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelCandlestick2EditorPlugIn";
		}

		public PlotChannelCandlestick2()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_FillBody = new PlotFill();
			base.AddSubClass(this.FillBody);
			this.I_FillBody = this.FillBody;
			this.m_FillOpen = new PlotFill();
			base.AddSubClass(this.FillOpen);
			this.I_FillOpen = this.FillOpen;
			this.m_FillClose = new PlotFill();
			base.AddSubClass(this.FillClose);
			this.I_FillClose = this.FillClose;
			((ISubClassBase)this.FillBody.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillBody.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillOpen.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillOpen.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillClose.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillClose.Brush).ColorAmbientSource = AmbientColorSouce.Color;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Candlestick-2";
			this.WidthBody = 0.5;
			this.WidthOpen = 1.0;
			this.WidthClose = 1.0;
			this.HeightOpen = 0.2;
			this.HeightClose = 0.2;
			this.WidthStyleBody = MagnitudeStyle.Value;
			this.WidthStyleOpen = MagnitudeStyle.Value;
			this.WidthStyleClose = MagnitudeStyle.Value;
			this.HeightStyleOpen = MagnitudeStyle.Value;
			this.HeightStyleClose = MagnitudeStyle.Value;
			this.ShowOpen = true;
			this.ShowClose = true;
			this.FillBody.Visible = true;
			this.FillBody.Brush.Visible = true;
			this.FillBody.Pen.Visible = true;
			this.FillBody.Brush.Style = PlotBrushStyle.Solid;
			this.FillBody.Brush.SolidColor = Color.Aqua;
			this.FillBody.Brush.GradientStartColor = Color.Blue;
			this.FillBody.Brush.GradientStopColor = Color.Aqua;
			this.FillBody.Brush.HatchForeColor = Color.Empty;
			this.FillBody.Brush.HatchBackColor = Color.Empty;
			this.FillBody.Pen.Color = Color.Aqua;
			this.FillBody.Pen.Thickness = 1.0;
			this.FillBody.Pen.Style = PlotPenStyle.Solid;
			this.FillOpen.Visible = true;
			this.FillOpen.Brush.Visible = true;
			this.FillOpen.Pen.Visible = true;
			this.FillOpen.Brush.Style = PlotBrushStyle.Solid;
			this.FillOpen.Brush.SolidColor = Color.Lime;
			this.FillOpen.Brush.GradientStartColor = Color.Blue;
			this.FillOpen.Brush.GradientStopColor = Color.Aqua;
			this.FillOpen.Brush.HatchForeColor = Color.Empty;
			this.FillOpen.Brush.HatchBackColor = Color.Empty;
			this.FillOpen.Pen.Color = Color.Lime;
			this.FillOpen.Pen.Thickness = 1.0;
			this.FillOpen.Pen.Style = PlotPenStyle.Solid;
			this.FillClose.Visible = true;
			this.FillClose.Brush.Visible = true;
			this.FillClose.Pen.Visible = true;
			this.FillClose.Brush.Style = PlotBrushStyle.Solid;
			this.FillClose.Brush.SolidColor = Color.Red;
			this.FillClose.Brush.GradientStartColor = Color.Blue;
			this.FillClose.Brush.GradientStopColor = Color.Aqua;
			this.FillClose.Brush.HatchForeColor = Color.Empty;
			this.FillClose.Brush.HatchBackColor = Color.Empty;
			this.FillClose.Pen.Color = Color.Red;
			this.FillClose.Pen.Thickness = 1.0;
			this.FillClose.Pen.Style = PlotPenStyle.Solid;
		}

		private bool ShouldSerializeWidthBody()
		{
			return base.PropertyShouldSerialize("WidthBody");
		}

		private void ResetWidthBody()
		{
			base.PropertyReset("WidthBody");
		}

		private bool ShouldSerializeWidthOpen()
		{
			return base.PropertyShouldSerialize("WidthOpen");
		}

		private void ResetWidthOpen()
		{
			base.PropertyReset("WidthOpen");
		}

		private bool ShouldSerializeWidthClose()
		{
			return base.PropertyShouldSerialize("WidthClose");
		}

		private void ResetWidthClose()
		{
			base.PropertyReset("WidthClose");
		}

		private bool ShouldSerializeHeightOpen()
		{
			return base.PropertyShouldSerialize("HeightOpen");
		}

		private void ResetHeightOpen()
		{
			base.PropertyReset("HeightOpen");
		}

		private bool ShouldSerializeHeightClose()
		{
			return base.PropertyShouldSerialize("HeightClose");
		}

		private void ResetHeightClose()
		{
			base.PropertyReset("HeightClose");
		}

		private bool ShouldSerializeWidthStyleBody()
		{
			return base.PropertyShouldSerialize("WidthStyleBody");
		}

		private void ResetWidthStyleBody()
		{
			base.PropertyReset("WidthStyleBody");
		}

		private bool ShouldSerializeWidthStyleOpen()
		{
			return base.PropertyShouldSerialize("WidthStyleOpen");
		}

		private void ResetWidthStyleOpen()
		{
			base.PropertyReset("WidthStyleOpen");
		}

		private bool ShouldSerializeWidthStyleClose()
		{
			return base.PropertyShouldSerialize("WidthStyleClose");
		}

		private void ResetWidthStyleClose()
		{
			base.PropertyReset("WidthStyleClose");
		}

		private bool ShouldSerializeHeightStyleOpen()
		{
			return base.PropertyShouldSerialize("HeightStyleOpen");
		}

		private void ResetHeightStyleOpen()
		{
			base.PropertyReset("HeightStyleOpen");
		}

		private bool ShouldSerializeHeightStyleClose()
		{
			return base.PropertyShouldSerialize("HeightStyleClose");
		}

		private void ResetHeightStyleClose()
		{
			base.PropertyReset("HeightStyleClose");
		}

		private bool ShouldSerializeShowOpen()
		{
			return base.PropertyShouldSerialize("ShowOpen");
		}

		private void ResetShowOpen()
		{
			base.PropertyReset("ShowOpen");
		}

		private bool ShouldSerializeShowClose()
		{
			return base.PropertyShouldSerialize("ShowClose");
		}

		private void ResetShowClose()
		{
			base.PropertyReset("ShowClose");
		}

		private bool ShouldSerializeFillBody()
		{
			return ((ISubClassBase)this.FillBody).ShouldSerialize();
		}

		private void ResetFillBody()
		{
			((ISubClassBase)this.FillBody).ResetToDefault();
		}

		private bool ShouldSerializeFillOpen()
		{
			return ((ISubClassBase)this.FillOpen).ShouldSerialize();
		}

		private void ResetFillOpen()
		{
			((ISubClassBase)this.FillOpen).ResetToDefault();
		}

		private bool ShouldSerializeFillClose()
		{
			return ((ISubClassBase)this.FillClose).ShouldSerialize();
		}

		private void ResetFillClose()
		{
			((ISubClassBase)this.FillClose).ResetToDefault();
		}

		protected override PlotDataPointBase CreateDataPoint()
		{
			return new PlotDataPointCandlestick2(this);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue, double high, double low, double open, double close)
		{
			base.CheckForValidNextX(x);
			PlotDataPointCandlestick2 plotDataPointCandlestick = (PlotDataPointCandlestick2)base.m_Data.AddNew();
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
					double normalizedWidth = base.GetNormalizedWidth(xAxis, this.WidthBody, this.WidthStyleBody);
					base.XAxis.Tracking.NewData(x - normalizedWidth / 2.0);
					base.XAxis.Tracking.NewData(x + normalizedWidth / 2.0);
					if (this.ShowOpen)
					{
						normalizedWidth = base.GetNormalizedWidth(xAxis, this.WidthOpen, this.WidthStyleOpen);
						base.XAxis.Tracking.NewData(x - normalizedWidth);
					}
					if (this.ShowClose)
					{
						normalizedWidth = base.GetNormalizedWidth(xAxis, this.WidthClose, this.WidthStyleClose);
						base.XAxis.Tracking.NewData(x + normalizedWidth);
					}
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
			if (this.FillBody.DrawVisible)
			{
				flag = true;
			}
			if (this.ShowOpen && this.FillOpen.DrawVisible)
			{
				flag = true;
			}
			if (this.ShowClose && this.FillClose.DrawVisible)
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
				int num2;
				int num3;
				Size size;
				Point location;
				if (this.ShowOpen)
				{
					num2 = num / 2;
					num3 = r.Height / 5;
					size = new Size(num2, num3);
					location = new Point(point.X - num2, r.Top + num3);
					this.I_FillOpen.Draw(p, new Rectangle(location, size));
				}
				if (this.ShowClose)
				{
					num2 = num / 2;
					num3 = r.Height / 5;
					size = new Size(num2, num3);
					location = new Point(point.X, r.Bottom - 2 * num3);
					this.I_FillClose.Draw(p, new Rectangle(location, size));
				}
				num2 = num / 3;
				num3 = r.Height;
				size = new Size(num2, num3);
				location = new Point(point.X - (num2 + 1) / 2, r.Top);
				this.I_FillBody.Draw(p, new Rectangle(location, size));
			}
		}

		protected void DrawBody(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis, PlotDataPointCandlestick2 dataPoint)
		{
			if (!this.FillBody.NotDrawVisible)
			{
				double normalizedWidth = base.GetNormalizedWidth(xAxis, this.WidthBody, this.WidthStyleBody);
				int num = xAxis.ScaleDisplay.ValueToPixels(dataPoint.X - normalizedWidth / 2.0);
				int num2 = xAxis.ScaleDisplay.ValueToPixels(dataPoint.X + normalizedWidth / 2.0);
				int top = yAxis.ScaleDisplay.ValueToPixels(dataPoint.High);
				int bottom = yAxis.ScaleDisplay.ValueToPixels(dataPoint.Low);
				if (num == num2)
				{
					num2++;
				}
				Rectangle r = iRectangle.FromLTRB(base.XYSwapped, num, top, num2, bottom);
				this.I_FillBody.Draw(p, r);
			}
		}

		protected void DrawOpenClose(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis, PlotDataPointCandlestick2 dataPoint)
		{
			if (this.ShowOpen)
			{
				double normalizedWidth = base.GetNormalizedWidth(xAxis, this.WidthOpen, this.WidthStyleOpen);
				double normalizedHeight = base.GetNormalizedHeight(yAxis, this.HeightOpen, this.HeightStyleOpen);
				int num = xAxis.ScaleDisplay.ValueToPixels(dataPoint.X - normalizedWidth);
				int num2 = xAxis.ScaleDisplay.ValueToPixels(dataPoint.X);
				int num3 = yAxis.ScaleDisplay.ValueToPixels(dataPoint.Open - normalizedHeight / 2.0);
				int num4 = yAxis.ScaleDisplay.ValueToPixels(dataPoint.Open + normalizedHeight / 2.0);
				if (num == num2)
				{
					num2++;
				}
				if (num3 == num4)
				{
					num4++;
				}
				Rectangle r = iRectangle.FromLTRB(base.XYSwapped, num, num3, num2, num4);
				this.I_FillOpen.Draw(p, r);
			}
			if (this.ShowClose)
			{
				double normalizedWidth = base.GetNormalizedWidth(xAxis, this.WidthClose, this.WidthStyleClose);
				double normalizedHeight = base.GetNormalizedHeight(yAxis, this.HeightClose, this.HeightStyleClose);
				int num = xAxis.ScaleDisplay.ValueToPixels(dataPoint.X);
				int num2 = xAxis.ScaleDisplay.ValueToPixels(dataPoint.X + normalizedWidth);
				int num3 = yAxis.ScaleDisplay.ValueToPixels(dataPoint.Close - normalizedHeight / 2.0);
				int num4 = yAxis.ScaleDisplay.ValueToPixels(dataPoint.Close + normalizedHeight / 2.0);
				if (num == num2)
				{
					num2++;
				}
				if (num3 == num4)
				{
					num4++;
				}
				Rectangle r = iRectangle.FromLTRB(base.XYSwapped, num, num3, num2, num4);
				this.I_FillClose.Draw(p, r);
			}
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			for (int i = this.IndexDrawStart; i <= this.IndexDrawStop; i++)
			{
				PlotDataPointCandlestick2 plotDataPointCandlestick = this[i];
				if (!plotDataPointCandlestick.Empty && !plotDataPointCandlestick.Null)
				{
					this.DrawOpenClose(p, xAxis, yAxis, plotDataPointCandlestick);
					this.DrawBody(p, xAxis, yAxis, plotDataPointCandlestick);
				}
			}
		}
	}
}
