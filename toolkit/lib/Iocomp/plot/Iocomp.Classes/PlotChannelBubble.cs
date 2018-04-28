using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;

namespace Iocomp.Classes
{
	[Description("Plot Channel Bubble")]
	public class PlotChannelBubble : PlotChannelConsecutive
	{
		private double m_Radius;

		private PlotChannelBubbleRadiusStyle m_RadiusStyle;

		private PlotFill m_Fill;

		protected IPlotFill I_Fill;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Radius
		{
			get
			{
				return this.m_Radius;
			}
			set
			{
				base.PropertyUpdateDefault("Radius", value);
				if (this.Radius != value)
				{
					this.m_Radius = value;
					base.DoPropertyChange(this, "Radius");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotChannelBubbleRadiusStyle RadiusStyle
		{
			get
			{
				return this.m_RadiusStyle;
			}
			set
			{
				base.PropertyUpdateDefault("RadiusStyle", value);
				if (this.RadiusStyle != value)
				{
					this.m_RadiusStyle = value;
					base.DoPropertyChange(this, "RadiusStyle");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public new bool RequireConsecutiveData
		{
			get
			{
				return base.RequireConsecutiveData;
			}
			set
			{
				base.RequireConsecutiveData = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill Fill
		{
			get
			{
				return this.m_Fill;
			}
		}

		public PlotDataPointBubble this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointBubble;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Channel Bubble";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelBubbleEditorPlugIn";
		}

		public PlotChannelBubble()
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
			base.NameShort = "Bubble";
			this.Radius = 5.0;
			this.RadiusStyle = PlotChannelBubbleRadiusStyle.SizeY;
			this.Fill.Visible = true;
			this.Fill.Brush.Visible = true;
			this.Fill.Brush.Style = PlotBrushStyle.GradientHorizontal;
			this.Fill.Brush.SolidColor = Color.Empty;
			this.Fill.Brush.GradientStartColor = Color.Blue;
			this.Fill.Brush.GradientStopColor = Color.Aqua;
			this.Fill.Brush.HatchForeColor = Color.Empty;
			this.Fill.Brush.HatchBackColor = Color.Empty;
			this.Fill.Pen.Visible = false;
			this.Fill.Pen.Color = Color.Empty;
			this.Fill.Pen.Thickness = 1.0;
			this.Fill.Pen.Style = PlotPenStyle.Solid;
		}

		private bool ShouldSerializeRadius()
		{
			return base.PropertyShouldSerialize("Radius");
		}

		private void ResetRadius()
		{
			base.PropertyReset("Radius");
		}

		private bool ShouldSerializeRadiusStyle()
		{
			return base.PropertyShouldSerialize("RadiusStyle");
		}

		private void ResetRadiusStyle()
		{
			base.PropertyReset("RadiusStyle");
		}

		private bool ShouldSerializeRequireConsecutiveData()
		{
			return base.PropertyShouldSerialize("RequireConsecutiveData");
		}

		private void ResetRequireConsecutiveData()
		{
			base.PropertyReset("RequireConsecutiveData");
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
			return new PlotDataPointBubble(this);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue, double radius)
		{
			if (this.RequireConsecutiveData)
			{
				base.CheckForValidNextX(x);
			}
			PlotDataPointBubble plotDataPointBubble = (PlotDataPointBubble)base.m_Data.AddNew();
			base.DataPointInitializing = true;
			try
			{
				plotDataPointBubble.X = x;
				plotDataPointBubble.Y = y;
				plotDataPointBubble.Null = nullValue;
				plotDataPointBubble.Empty = emptyValue;
				plotDataPointBubble.Radius = radius;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			base.m_Data.UpdateMinMaxMean(plotDataPointBubble);
			if (base.SendXAxisTrackingData)
			{
				PlotAxis xAxis = base.XAxis;
				if (xAxis != null)
				{
					xAxis.Tracking.NewData(x - radius);
					xAxis.Tracking.NewData(x + radius);
				}
			}
			if (!nullValue && !emptyValue && base.SendYAxisTrackingData)
			{
				PlotAxis yAxis = base.YAxis;
				if (yAxis != null)
				{
					yAxis.Tracking.NewData(y + radius);
					yAxis.Tracking.NewData(y - radius);
				}
			}
			this.DoDataChange();
			return base.m_Data.LastNewDataPointIndex;
		}

		public int AddXY(double x, double y, double radius)
		{
			return this.AddXY(x, y, false, false, radius);
		}

		public int AddXY(DateTime x, double y, double radius)
		{
			return this.AddXY(Math2.DateTimeToDouble(x), y, false, false, radius);
		}

		public override int AddXY(double x, double y)
		{
			return this.AddXY(x, y, false, false, this.Radius);
		}

		public override int AddEmpty(double x)
		{
			return this.AddXY(x, 0.0, false, true, this.Radius);
		}

		public override int AddNull(double x)
		{
			return this.AddXY(x, 0.0, true, false, this.Radius);
		}

		public override double GetX(int index)
		{
			return this[index].X;
		}

		public override double GetY(int index)
		{
			return this[index].Y;
		}

		public double GetRadius(int index)
		{
			return this[index].Radius;
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

		public void SetRadius(int index, double value)
		{
			this[index].Radius = value;
		}

		public override void SetNull(int index, bool value)
		{
			this[index].Null = value;
		}

		public override void SetEmpty(int index, bool value)
		{
			this[index].Empty = value;
		}

		protected override void WriteDataPointToStreamWriter(StreamWriter streamWriter, int index)
		{
			if (this.GetNull(index))
			{
				streamWriter.WriteLine(this.GetX(index) + base.m_DeliminatorChar + "null" + base.m_DeliminatorChar + "null");
			}
			else
			{
				streamWriter.WriteLine(this.GetX(index) + base.m_DeliminatorChar + this.GetY(index) + base.m_DeliminatorChar + this.GetRadius(index));
			}
		}

		protected override void ReadDataPointFromStreamReader(StreamReader streamReader, string stringline)
		{
			string[] array = stringline.Split(base.m_DeliminatorChar.ToCharArray());
			if (array.Length != 3)
			{
				throw new Exception("Invalid File Format");
			}
			double num;
			double x = (!double.TryParse(array[0], NumberStyles.Any, (IFormatProvider)null, out num)) ? Convert.ToDateTime(array[0]).ToOADate() : num;
			if (array[1].ToUpper().CompareTo("NULL") == 0)
			{
				this.AddNull(x);
			}
			else
			{
				this.AddXY(x, Convert.ToDouble(array[1]), Convert.ToDouble(array[2]));
			}
		}

		public override int CalculateXValueNearestIndex(double value)
		{
			if (this.RequireConsecutiveData)
			{
				return base.CalculateXValueNearestIndex(value);
			}
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
			if (this.RequireConsecutiveData)
			{
				return base.GetYInterpolated(xValue, out yValue);
			}
			yValue = 0.0;
			return PlotChannelInterpolationResult.Invalid;
		}

		protected override void LoadDesignTimeData(PlotXAxis xAxis, PlotYAxis yAxis, Random random, double yMin, double ySpan)
		{
			for (double num = xAxis.Min; num < xAxis.Max; num += this.Radius * 3.0)
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
			if (r.Width == r.Height)
			{
				this.I_Fill.DrawEllipse(p, r);
			}
			else if (r.Width > r.Height)
			{
				this.I_Fill.DrawEllipse(p, new Rectangle((r.Left + r.Right) / 2 - r.Height / 2, (r.Top + r.Bottom) / 2 - r.Height / 2, r.Height, r.Height));
			}
			else
			{
				this.I_Fill.DrawEllipse(p, new Rectangle((r.Left + r.Right) / 2 - r.Height / 2, (r.Top + r.Bottom) / 2 - r.Width / 2, r.Width, r.Width));
			}
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			for (int i = this.IndexDrawStart; i <= this.IndexDrawStop; i++)
			{
				PlotDataPointBubble plotDataPointBubble = this[i];
				if (!plotDataPointBubble.Empty && !plotDataPointBubble.Null)
				{
					int left;
					int right;
					int top;
					int bottom;
					if (this.RadiusStyle == PlotChannelBubbleRadiusStyle.SizeY)
					{
						int num = yAxis.ScaleDisplay.ValueToSpanPixels(plotDataPointBubble.Radius);
						left = xAxis.ScaleDisplay.ValueToPixels(plotDataPointBubble.X) - num;
						right = xAxis.ScaleDisplay.ValueToPixels(plotDataPointBubble.X) + num;
						top = yAxis.ScaleDisplay.ValueToPixels(plotDataPointBubble.Y) - num;
						bottom = yAxis.ScaleDisplay.ValueToPixels(plotDataPointBubble.Y) + num;
					}
					else if (this.RadiusStyle == PlotChannelBubbleRadiusStyle.SizeX)
					{
						int num = xAxis.ScaleDisplay.ValueToSpanPixels(plotDataPointBubble.Radius);
						left = xAxis.ScaleDisplay.ValueToPixels(plotDataPointBubble.X) - num;
						right = xAxis.ScaleDisplay.ValueToPixels(plotDataPointBubble.X) + num;
						top = yAxis.ScaleDisplay.ValueToPixels(plotDataPointBubble.Y) - num;
						bottom = yAxis.ScaleDisplay.ValueToPixels(plotDataPointBubble.Y) + num;
					}
					else
					{
						left = xAxis.ScaleDisplay.ValueToPixels(plotDataPointBubble.X - plotDataPointBubble.Radius);
						right = xAxis.ScaleDisplay.ValueToPixels(plotDataPointBubble.X + plotDataPointBubble.Radius);
						top = yAxis.ScaleDisplay.ValueToPixels(plotDataPointBubble.Y - plotDataPointBubble.Radius);
						bottom = yAxis.ScaleDisplay.ValueToPixels(plotDataPointBubble.Y + plotDataPointBubble.Radius);
					}
					Rectangle rectangle = iRectangle.FromLTRB(base.XYSwapped, left, top, right, bottom);
					if (base.BoundsClip.IntersectsWith(rectangle))
					{
						this.I_Fill.DrawEllipse(p, rectangle);
					}
				}
			}
		}
	}
}
