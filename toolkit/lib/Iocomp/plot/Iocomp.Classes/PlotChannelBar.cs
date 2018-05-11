using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Channel Bar")]
	public class PlotChannelBar : PlotChannelConsecutive
	{
		private double m_Reference;

		private double m_Width;

		private MagnitudeStyle m_WidthStyle;

		private bool m_DrawCustomDataPointAttributes;

		private PlotFill m_Fill;

		protected IPlotFill I_Fill;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Width
		{
			get
			{
				return this.m_Width;
			}
			set
			{
				base.PropertyUpdateDefault("Width", value);
				if (this.Width != value)
				{
					this.m_Width = value;
					base.DoPropertyChange(this, "Width");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public MagnitudeStyle WidthStyle
		{
			get
			{
				return this.m_WidthStyle;
			}
			set
			{
				base.PropertyUpdateDefault("WidthStyle", value);
				if (this.WidthStyle != value)
				{
					this.m_WidthStyle = value;
					base.DoPropertyChange(this, "WidthStyle");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Reference
		{
			get
			{
				return this.m_Reference;
			}
			set
			{
				base.PropertyUpdateDefault("Reference", value);
				if (this.Reference != value)
				{
					this.m_Reference = value;
					base.DoPropertyChange(this, "Reference");
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotFill Fill
		{
			get
			{
				return this.m_Fill;
			}
		}

		public PlotDataPointBar this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointBar;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Channel Bar";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelBarEditorPlugIn";
		}

		public PlotChannelBar()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Fill = new PlotFill();
			base.AddSubClass(this.Fill);
			this.I_Fill = this.Fill;
			((ISubClassBase)this.Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Bar";
			this.Width = 5.0;
			this.WidthStyle = MagnitudeStyle.Value;
			this.Reference = 0.0;
			this.DrawCustomDataPointAttributes = false;
			this.Fill.Visible = true;
			this.Fill.Brush.Visible = true;
			this.Fill.Brush.Style = PlotBrushStyle.Solid;
			this.Fill.Brush.SolidColor = Color.Empty;
			this.Fill.Brush.GradientStartColor = Color.Blue;
			this.Fill.Brush.GradientStopColor = Color.Aqua;
			this.Fill.Brush.HatchForeColor = Color.Empty;
			this.Fill.Brush.HatchBackColor = Color.Empty;
			this.Fill.Pen.Visible = true;
			this.Fill.Pen.Color = Color.Empty;
			this.Fill.Pen.Thickness = 1.0;
			this.Fill.Pen.Style = PlotPenStyle.Solid;
		}

		private bool ShouldSerializeWidth()
		{
			return base.PropertyShouldSerialize("Width");
		}

		private void ResetWidth()
		{
			base.PropertyReset("Width");
		}

		private bool ShouldSerializeWidthStyle()
		{
			return base.PropertyShouldSerialize("WidthStyle");
		}

		private void ResetWidthStyle()
		{
			base.PropertyReset("WidthStyle");
		}

		private bool ShouldSerializeReference()
		{
			return base.PropertyShouldSerialize("Reference");
		}

		private void ResetReference()
		{
			base.PropertyReset("Reference");
		}

		private bool ShouldSerializeDrawCustomDataPointAttributes()
		{
			return base.PropertyShouldSerialize("DrawCustomDataPointAttributes");
		}

		private void ResetDrawCustomDataPointAttributes()
		{
			base.PropertyReset("DrawCustomDataPointAttributes");
		}

		private bool ShouldSerializeFill()
		{
			return ((ISubClassBase)this.Fill).ShouldSerialize();
		}

		private void ResetFill()
		{
			((ISubClassBase)this.Fill).ResetToDefault();
		}

		protected override PlotDataPointBase CreateDataPoint()
		{
			return new PlotDataPointBar(this);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue, double width)
		{
			base.CheckForValidNextX(x);
			PlotDataPointBar plotDataPointBar = (PlotDataPointBar)base.m_Data.AddNew();
			base.DataPointInitializing = true;
			try
			{
				plotDataPointBar.X = x;
				plotDataPointBar.Y = y;
				plotDataPointBar.Null = nullValue;
				plotDataPointBar.Empty = emptyValue;
				plotDataPointBar.Width = width;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			base.m_Data.UpdateMinMaxMean(plotDataPointBar);
			if (base.SendXAxisTrackingData)
			{
				PlotAxis xAxis = base.XAxis;
				if (xAxis != null)
				{
					base.XAxis.Tracking.NewData(x - this.Width / 2.0);
					base.XAxis.Tracking.NewData(x + this.Width / 2.0);
				}
			}
			if (!nullValue && !emptyValue && base.SendYAxisTrackingData)
			{
				PlotAxis yAxis = base.YAxis;
				if (yAxis != null)
				{
					base.YAxis.Tracking.NewData(y);
					base.YAxis.Tracking.NewData(this.Reference);
				}
			}
			this.DoDataChange();
			return base.m_Data.LastNewDataPointIndex;
		}

		public int AddXY(double x, double y, double width)
		{
			return this.AddXY(x, y, false, false, width);
		}

		public int AddXY(DateTime x, double y, double width)
		{
			return this.AddXY(Math2.DateTimeToDouble(x), y, false, false, width);
		}

		public override int AddXY(double x, double y)
		{
			return this.AddXY(x, y, false, false, this.Width);
		}

		public override int AddEmpty(double x)
		{
			return this.AddXY(x, 0.0, false, true, this.Width);
		}

		public override int AddNull(double x)
		{
			return this.AddXY(x, 0.0, true, false, this.Width);
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
			for (double num = xAxis.Min; num < xAxis.Max; num += this.Width * 3.0)
			{
				this.AddXY(num, yMin + random.NextDouble() * ySpan);
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (this.Fill.NotDrawVisible)
			{
				base.CanDraw = false;
			}
		}

		protected override void DrawLegendMarker(PaintArgs p, Rectangle r)
		{
			int width = (int)Math.Round((double)r.Width * 0.6);
			Size size = new Size(width, r.Height);
			Point point = iRectangle.CenterPoint2(r);
			Point location = new Point(point.X - size.Width / 2, point.Y - size.Height / 2);
			this.I_Fill.Draw(p, new Rectangle(location, size));
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			for (int i = this.IndexDrawStart; i <= this.IndexDrawStop; i++)
			{
				PlotDataPointBar plotDataPointBar = this[i];
				if (!plotDataPointBar.Empty && !plotDataPointBar.Null)
				{
					Rectangle r;
					Point point;
					if (this.WidthStyle == MagnitudeStyle.Value)
					{
						int num;
						int num2;
						if (this.DrawCustomDataPointAttributes)
						{
							num = xAxis.ScaleDisplay.ValueToPixels(plotDataPointBar.X - plotDataPointBar.Width / 2.0);
							num2 = xAxis.ScaleDisplay.ValueToPixels(plotDataPointBar.X + plotDataPointBar.Width / 2.0);
						}
						else
						{
							num = xAxis.ScaleDisplay.ValueToPixels(plotDataPointBar.X - this.Width / 2.0);
							num2 = xAxis.ScaleDisplay.ValueToPixels(plotDataPointBar.X + this.Width / 2.0);
						}
						int top = yAxis.ScaleDisplay.ValueToPixels(plotDataPointBar.Y);
						int bottom = yAxis.ScaleDisplay.ValueToPixels(this.Reference);
						if (num == num2)
						{
							num2++;
						}
						r = iRectangle.FromLTRB(base.XYSwapped, num, top, num2, bottom);
					}
					else if (this.WidthStyle == MagnitudeStyle.Pixel)
					{
						point = base.GetPoint(plotDataPointBar.X, plotDataPointBar.Y);
						int num3 = (int)(this.Width / 2.0);
						int bottom2 = yAxis.ScaleDisplay.ValueToPixels(this.Reference);
						r = iRectangle.FromLTRB(base.XYSwapped, point.X - num3, point.Y, point.X + num3, bottom2);
					}
					else
					{
						point = base.GetPoint(plotDataPointBar.X, plotDataPointBar.Y);
						int num3 = xAxis.ScaleDisplay.PercentToSpanPixels(this.Width) / 2;
						int bottom2 = yAxis.ScaleDisplay.ValueToPixels(this.Reference);
						int num = point.X - num3;
						int num2 = point.X + num3;
						if (num == num2)
						{
							num2++;
						}
						r = iRectangle.FromLTRB(base.XYSwapped, num, point.Y, num2, bottom2);
					}
					if (this.DrawCustomDataPointAttributes)
					{
						((IPlotFill)plotDataPointBar.Fill).Draw(p, r);
					}
					else
					{
						this.I_Fill.Draw(p, r);
					}
				}
			}
		}
	}
}
