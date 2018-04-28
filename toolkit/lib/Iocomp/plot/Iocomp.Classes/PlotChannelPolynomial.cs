using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Channel Trace")]
	public class PlotChannelPolynomial : PlotChannelConsecutive
	{
		private enum FastDrawStatus
		{
			None,
			Min,
			Max
		}

		private PlotPen m_Trace;

		private IPlotPen I_Trace;

		private PlotMarker m_Markers;

		private IPlotMarker I_Markers;

		private PlotFill m_Fill;

		private IPlotFill I_Fill;

		private double m_Reference;

		private bool m_UserCanMoveDataPoints;

		private bool m_DrawCustomDataPointAttributes;

		private PlotDataMoveStyle m_DataPointsMoveStyle;

		private int m_MarkersTurnOffLimit;

		private int m_FillRefPixel;

		private Point[] m_FillPoints;

		private double[] m_PixelYValues;

		private int m_XPixelMin;

		private int m_XPixelMax;

		private int m_MouseDownDataPointIndex;

		private PlotDataPointPolynomial m_MouseDownDataPoint;

		private double m_MouseDownDataPointX;

		private double m_MouseDownDataPointY;

		private double m_MouseDownPosX;

		private double m_MouseDownPosY;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotPen Trace
		{
			get
			{
				return this.m_Trace;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill Fill
		{
			get
			{
				return this.m_Fill;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotMarker Markers
		{
			get
			{
				return this.m_Markers;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool UserCanMoveDataPoints
		{
			get
			{
				return this.m_UserCanMoveDataPoints;
			}
			set
			{
				base.PropertyUpdateDefault("UserCanMoveDataPoints", value);
				if (this.UserCanMoveDataPoints != value)
				{
					this.m_UserCanMoveDataPoints = value;
					base.DoPropertyChange(this, "UserCanMoveDataPoints");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotDataMoveStyle DataPointsMoveStyle
		{
			get
			{
				return this.m_DataPointsMoveStyle;
			}
			set
			{
				base.PropertyUpdateDefault("DataPointsMoveStyle", value);
				if (this.DataPointsMoveStyle != value)
				{
					this.m_DataPointsMoveStyle = value;
					base.DoPropertyChange(this, "DataPointsMoveStyle");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int MarkersTurnOffLimit
		{
			get
			{
				return this.m_MarkersTurnOffLimit;
			}
			set
			{
				base.PropertyUpdateDefault("MarkersTurnOffLimit", value);
				if (this.MarkersTurnOffLimit != value)
				{
					this.m_MarkersTurnOffLimit = value;
					base.DoPropertyChange(this, "MarkersTurnOffLimit");
				}
			}
		}

		public PlotDataPointPolynomial this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointPolynomial;
			}
		}

		public event PlotChannelDataPointMovedEventHandler DataPointMoved;

		public event PlotChannelDataPointClickEventHandler DataPointClick;

		public event PlotChannelDataPointClickEventHandler DataPointDoubleClick;

		protected override string GetPlugInTitle()
		{
			return "Channel Polynomial";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelPolynomialEditorPlugIn";
		}

		public PlotChannelPolynomial()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Trace = new PlotPen();
			base.AddSubClass(this.Trace);
			this.I_Trace = this.Trace;
			this.m_Fill = new PlotFill();
			base.AddSubClass(this.Fill);
			this.I_Fill = this.Fill;
			this.m_Markers = new PlotMarker();
			base.AddSubClass(this.Markers);
			this.I_Markers = this.Markers;
			((ISubClassBase)this.Trace).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.Markers.Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.Markers.Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Polynomial";
			this.UserCanMoveDataPoints = false;
			this.DrawCustomDataPointAttributes = false;
			this.DataPointsMoveStyle = PlotDataMoveStyle.XandY;
			this.Trace.Color = Color.Empty;
			this.Trace.Thickness = 1.0;
			this.Trace.Style = PlotPenStyle.Solid;
			this.Trace.Visible = true;
			this.Reference = 0.0;
			this.Fill.Visible = false;
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
			this.Markers.Visible = false;
			this.Markers.Style = PlotMarkerStyle.Circle;
			this.Markers.Size = 3;
			this.Markers.Font = null;
			this.Markers.ForeColor = Color.Empty;
			this.Markers.Text = "";
			this.Markers.Fill.Pen.Visible = true;
			this.Markers.Fill.Pen.Style = PlotPenStyle.Solid;
			this.Markers.Fill.Pen.Color = Color.Empty;
			this.Markers.Fill.Pen.Thickness = 1.0;
			this.Markers.Fill.Brush.Visible = true;
			this.Markers.Fill.Brush.Style = PlotBrushStyle.Solid;
			this.Markers.Fill.Brush.SolidColor = Color.Empty;
			this.Markers.Fill.Brush.GradientStartColor = Color.Blue;
			this.Markers.Fill.Brush.GradientStopColor = Color.Aqua;
			this.Markers.Fill.Brush.HatchForeColor = Color.Empty;
			this.Markers.Fill.Brush.HatchBackColor = Color.Empty;
			this.MarkersTurnOffLimit = 0;
		}

		private bool ShouldSerializeTrace()
		{
			return ((ISubClassBase)this.Trace).ShouldSerialize();
		}

		private void ResetTrace()
		{
			((ISubClassBase)this.Trace).ResetToDefault();
		}

		private bool ShouldSerializeFill()
		{
			return ((ISubClassBase)this.Fill).ShouldSerialize();
		}

		private void ResetFill()
		{
			((ISubClassBase)this.Fill).ResetToDefault();
		}

		private bool ShouldSerializeMarkers()
		{
			return ((ISubClassBase)this.Markers).ShouldSerialize();
		}

		private void ResetMarkers()
		{
			((ISubClassBase)this.Markers).ResetToDefault();
		}

		private bool ShouldSerializeReference()
		{
			return base.PropertyShouldSerialize("Reference");
		}

		private void ResetReference()
		{
			base.PropertyReset("Reference");
		}

		private bool ShouldSerializeUserCanMoveDataPoints()
		{
			return base.PropertyShouldSerialize("UserCanMoveDataPoints");
		}

		private void ResetUserCanMoveDataPoints()
		{
			base.PropertyReset("UserCanMoveDataPoints");
		}

		private bool ShouldSerializeDrawCustomDataPointAttributes()
		{
			return base.PropertyShouldSerialize("DrawCustomDataPointAttributes");
		}

		private void ResetDrawCustomDataPointAttributes()
		{
			base.PropertyReset("DrawCustomDataPointAttributes");
		}

		private bool ShouldSerializeDataPointsMoveStyle()
		{
			return base.PropertyShouldSerialize("DataPointsMoveStyle");
		}

		private void ResetDataPointsMoveStyle()
		{
			base.PropertyReset("DataPointsMoveStyle");
		}

		private bool ShouldSerializeMarkerTurnOffLimit()
		{
			return base.PropertyShouldSerialize("MarkerTurnOffLimit");
		}

		private void ResetMarkerTurnOffLimit()
		{
			base.PropertyReset("MarkerTurnOffLimit");
		}

		protected override PlotDataPointBase CreateDataPoint()
		{
			return new PlotDataPointPolynomial(this);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue)
		{
			base.CheckForValidNextX(x);
			PlotDataPointPolynomial plotDataPointPolynomial = base.m_Data.AddNew() as PlotDataPointPolynomial;
			base.DataPointInitializing = true;
			try
			{
				plotDataPointPolynomial.X = x;
				plotDataPointPolynomial.Y = y;
				plotDataPointPolynomial.Null = nullValue;
				plotDataPointPolynomial.Empty = emptyValue;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			base.m_Data.UpdateMinMaxMean(plotDataPointPolynomial);
			if (base.SendXAxisTrackingData)
			{
				PlotXAxis xAxis = base.XAxis;
				xAxis?.Tracking.NewData(x);
			}
			if (!nullValue && !emptyValue && base.SendYAxisTrackingData)
			{
				PlotYAxis yAxis = base.YAxis;
				yAxis?.Tracking.NewData(y);
			}
			this.DoDataChange();
			return base.m_Data.LastNewDataPointIndex;
		}

		public override int AddXY(double x, double y)
		{
			return this.AddXY(x, y, false, false);
		}

		public override int AddEmpty(double x)
		{
			return this.AddXY(x, 0.0, false, true);
		}

		public override int AddNull(double x)
		{
			return this.AddXY(x, 0.0, true, false);
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

		private double GetC(int index)
		{
			return this[index].C;
		}

		private double GetD(int index)
		{
			return this[index].D;
		}

		private void SetC(int index, double value)
		{
			this[index].C = value;
		}

		private void SetD(int index, double value)
		{
			this[index].D = value;
		}

		protected override bool InternalHitTest(MouseEventArgs e)
		{
			if (base.LegendRectangle.Contains(e.X, e.Y))
			{
				return true;
			}
			this.m_MouseDownDataPointIndex = -1;
			if (this.IndexDrawStart == -1)
			{
				return false;
			}
			if (this.IndexDrawStop == -1)
			{
				return false;
			}
			if (this.Markers.Visible)
			{
				PlotXAxis xAxis = base.XAxis;
				PlotYAxis yAxis = base.YAxis;
				if (xAxis != null && yAxis != null)
				{
					int num = this.IndexDrawStart;
					while (num <= this.IndexDrawStop)
					{
						PlotDataPointPolynomial plotDataPointPolynomial = this[num];
						Point point = base.GetPoint(plotDataPointPolynomial.X, plotDataPointPolynomial.Y);
						int num2 = (!this.DrawCustomDataPointAttributes) ? this.Markers.Size : plotDataPointPolynomial.Marker.Size;
						if (!new Rectangle(point.X - num2, point.Y - num2, num2 * 2, num2 * 2).Contains(e.X, e.Y))
						{
							num++;
							continue;
						}
						this.m_MouseDownDataPointIndex = num;
						return true;
					}
				}
			}
			return false;
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
			int num = base.XAxis.ValueToPixels(targetX);
			yValue = this.m_PixelYValues[num - this.m_XPixelMin];
			if (yValue <= 1E+300)
			{
				return PlotChannelInterpolationResult.Valid;
			}
			return PlotChannelInterpolationResult.Null;
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			if (this.m_MouseDownDataPointIndex == -1)
			{
				return Cursors.Default;
			}
			return Cursors.Hand;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (shouldFocus)
			{
				base.Focus();
			}
			if (this.UserCanMoveDataPoints && this.m_MouseDownDataPointIndex != -1)
			{
				base.IsMouseActive = true;
				this.m_MouseDownDataPoint = this[this.m_MouseDownDataPointIndex];
				this.m_MouseDownDataPointX = this.m_MouseDownDataPoint.X;
				this.m_MouseDownDataPointY = this.m_MouseDownDataPoint.Y;
				this.m_MouseDownPosX = base.XAxis.PixelsToValue(e);
				this.m_MouseDownPosY = base.YAxis.PixelsToValue(e);
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			if (base.IsMouseActive)
			{
				double num = this.m_MouseDownDataPointX + (base.XAxis.PixelsToValue(e) - this.m_MouseDownPosX);
				double y = this.m_MouseDownDataPointY + (base.YAxis.PixelsToValue(e) - this.m_MouseDownPosY);
				double num2 = -1E+300;
				double num3 = 1E+300;
				if (base.DataDirection == DataDirection.Increasing)
				{
					if (this.m_MouseDownDataPointIndex > 0)
					{
						num2 = this[this.m_MouseDownDataPointIndex - 1].X * 1.00000000000001;
					}
					if (this.m_MouseDownDataPointIndex < this.Count - 1)
					{
						num3 = this[this.m_MouseDownDataPointIndex + 1].X * 0.99999999999999;
					}
				}
				else
				{
					if (this.m_MouseDownDataPointIndex > 0)
					{
						num3 = this[this.m_MouseDownDataPointIndex - 1].X * 0.99999999999999;
					}
					if (this.m_MouseDownDataPointIndex < this.Count - 1)
					{
						num2 = this[this.m_MouseDownDataPointIndex + 1].X * 1.00000000000001;
					}
				}
				if (num > num3)
				{
					num = num3;
				}
				if (num < num2)
				{
					num = num2;
				}
				if (this.DataPointsMoveStyle == PlotDataMoveStyle.XandY || this.DataPointsMoveStyle == PlotDataMoveStyle.XOnly)
				{
					this.m_MouseDownDataPoint.X = num;
				}
				if (this.DataPointsMoveStyle != 0 && this.DataPointsMoveStyle != PlotDataMoveStyle.YOnly)
				{
					return;
				}
				this.m_MouseDownDataPoint.Y = y;
			}
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			base.IsMouseActive = false;
			if (this.UserCanMoveDataPoints && this.DataPointMoved != null && this.m_MouseDownDataPointIndex != -1)
			{
				double x = this[this.m_MouseDownDataPointIndex].X;
				double y = this[this.m_MouseDownDataPointIndex].Y;
				if (this.m_MouseDownDataPointX != x || this.m_MouseDownDataPointY != y)
				{
					PlotChannelDataPointMovedEventArgs e2 = new PlotChannelDataPointMovedEventArgs(this, this.m_MouseDownDataPointIndex, this.m_MouseDownDataPointX, this.m_MouseDownDataPointY, x, y);
					this.DataPointMoved(this, e2);
				}
			}
			if (this.DataPointClick != null)
			{
				PlotChannelDataPointClickEventArgs e3 = new PlotChannelDataPointClickEventArgs(this, e.Button, this.m_MouseDownDataPointIndex);
				this.DataPointClick(this, e3);
			}
		}

		protected override void InternalOnDoubleClick(MouseEventArgs e)
		{
			if (this.DataPointDoubleClick != null)
			{
				PlotChannelDataPointClickEventArgs e2 = new PlotChannelDataPointClickEventArgs(this, e.Button, this.m_MouseDownDataPointIndex);
				this.DataPointDoubleClick(this, e2);
			}
		}

		private void PolynomialInterpolation(int n, double x, out double y, out double dy)
		{
			dy = 0.0;
			int num = 0;
			double num2 = Math.Abs(x - this.GetX(0));
			for (int i = 0; i < n; i++)
			{
				double num3 = Math.Abs(x - this.GetX(i));
				if (num3 < num2)
				{
					num = i;
					num2 = num3;
				}
				this.SetC(i, this.GetY(i));
				this.SetD(i, this.GetY(i));
			}
			y = this.GetY(num);
			num--;
			for (int j = 1; j < n; j++)
			{
				int num4 = 0;
				while (num4 < n - j)
				{
					double num5 = this.GetX(num4) - x;
					double num6 = this.GetX(num4 + j) - x;
					double num7 = this.GetC(num4 + 1) - this.GetD(num4);
					double num8 = num5 - num6;
					if (num8 != 0.0)
					{
						num8 = num7 / num8;
						this.SetD(num4, num6 * num8);
						this.SetC(num4, num5 * num8);
						num4++;
						continue;
					}
					throw new Exception("Polynomial Interpolation Error - Pause in Routine Data");
				}
				if (2 * num < n - j - 1)
				{
					dy = this.GetC(num + 1);
				}
				else
				{
					dy = this.GetD(num);
					num--;
				}
				y += dy;
			}
		}

		protected override void DrawLegendMarker(PaintArgs p, Rectangle r)
		{
			this.I_Fill.Draw(p, r);
			this.I_Trace.DrawLine(p, r.Left, (r.Top + r.Bottom) / 2, r.Right, (r.Top + r.Bottom) / 2);
			this.I_Markers.DrawLegend(p, r);
		}

		protected override void DrawMarkers(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis, PlotMarker markers)
		{
			if (markers.Visible && this.IndexDrawStart != -1 && this.IndexDrawStop != -1)
			{
				if (this.MarkersTurnOffLimit > 0)
				{
					int num = Math.Abs(this.IndexDrawStop - this.IndexDrawStart) + 1;
					if (num >= this.MarkersTurnOffLimit)
					{
						return;
					}
				}
				for (int i = this.IndexDrawStart; i <= this.IndexDrawStop; i++)
				{
					PlotDataPointPolynomial plotDataPointPolynomial = this[i];
					if (!plotDataPointPolynomial.Null && !plotDataPointPolynomial.Empty)
					{
						int num2 = xAxis.ScaleDisplay.ValueToPixels(plotDataPointPolynomial.X);
						int num3 = yAxis.ScaleDisplay.ValueToPixels(plotDataPointPolynomial.Y);
						if (this.DrawCustomDataPointAttributes)
						{
							if (base.XYSwapped)
							{
								((IPlotMarker)plotDataPointPolynomial.Marker).Draw(p, num3, num2);
							}
							else
							{
								((IPlotMarker)plotDataPointPolynomial.Marker).Draw(p, num2, num3);
							}
						}
						else if (base.XYSwapped)
						{
							this.I_Markers.Draw(p, num3, num2);
						}
						else
						{
							this.I_Markers.Draw(p, num2, num3);
						}
					}
				}
			}
		}

		protected void DrawLine(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis, Pen pen, PlotDataPointYDouble point1, PlotDataPointYDouble point2, Brush fillBrush)
		{
			int num = xAxis.ScaleDisplay.ValueToPixels(point1.X);
			int num2 = yAxis.ScaleDisplay.ValueToPixels(point1.Y);
			int num3 = xAxis.ScaleDisplay.ValueToPixels(point2.X);
			int num4 = yAxis.ScaleDisplay.ValueToPixels(point2.Y);
			if (base.XYSwapped)
			{
				p.Graphics.DrawLine(pen, num2, num, num4, num3);
			}
			else
			{
				p.Graphics.DrawLine(pen, num, num2, num3, num4);
			}
			if (this.Fill.Visible && this.Fill.Brush.Visible)
			{
				if (this.m_FillPoints == null)
				{
					this.m_FillPoints = new Point[4];
				}
				if (base.XYSwapped)
				{
					this.m_FillPoints[0].X = this.m_FillRefPixel;
					this.m_FillPoints[0].Y = num;
				}
				else
				{
					this.m_FillPoints[0].X = num;
					this.m_FillPoints[0].Y = this.m_FillRefPixel;
				}
				if (base.XYSwapped)
				{
					this.m_FillPoints[1].X = num2;
					this.m_FillPoints[1].Y = num;
				}
				else
				{
					this.m_FillPoints[1].X = num;
					this.m_FillPoints[1].Y = num2;
				}
				if (base.XYSwapped)
				{
					this.m_FillPoints[2].X = num4;
					this.m_FillPoints[2].Y = num3;
				}
				else
				{
					this.m_FillPoints[2].X = num3;
					this.m_FillPoints[2].Y = num4;
				}
				if (base.XYSwapped)
				{
					this.m_FillPoints[3].X = this.m_FillRefPixel;
					this.m_FillPoints[3].Y = num3;
				}
				else
				{
					this.m_FillPoints[3].X = num3;
					this.m_FillPoints[3].Y = this.m_FillRefPixel;
				}
				p.Graphics.FillPolygon(fillBrush, this.m_FillPoints);
			}
		}

		protected void DrawTraceCustomAttributes(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			PlotDataPointPolynomial plotDataPointPolynomial = new PlotDataPointPolynomial(this);
			PlotDataPointPolynomial plotDataPointPolynomial2 = new PlotDataPointPolynomial(this);
			double num = this.GetX(0);
			double num2 = this.GetX(this.Count - 1);
			if (num < xAxis.Min)
			{
				num = base.XAxis.Min;
			}
			if (num2 > xAxis.Max)
			{
				num2 = base.XAxis.Max;
			}
			int num3 = xAxis.ValueToPixels(num);
			int num4 = xAxis.ValueToPixels(num2);
			if (num3 > num4)
			{
				Math2.Switch(ref num3, ref num4);
			}
			Brush brush = ((IPlotBrush)this.Fill.Brush).GetBrush(p, base.BoundsClip);
			double num5 = xAxis.PixelsToValue(num3);
			this.PolynomialInterpolation(this.Count, num5, out double num6, out double num7);
			double x = num5;
			double y = num6;
			for (int i = num3; i <= num4; i++)
			{
				num5 = base.XAxis.PixelsToValue(i);
				this.PolynomialInterpolation(this.Count, num5, out num6, out num7);
				int num8 = i - this.m_XPixelMin;
				if (num8 >= 0 && num8 < this.m_PixelYValues.Length)
				{
					this.m_PixelYValues[i - this.m_XPixelMin] = num6;
				}
				double num9 = num5;
				double num10 = num6;
				base.DataPointInitializing = true;
				plotDataPointPolynomial.X = x;
				plotDataPointPolynomial.Y = y;
				plotDataPointPolynomial2.X = num9;
				plotDataPointPolynomial2.Y = num10;
				base.DataPointInitializing = false;
				this.DrawLine(p, xAxis, yAxis, this.I_Trace.GetPen(p), plotDataPointPolynomial, plotDataPointPolynomial2, brush);
				x = num9;
				y = num10;
			}
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			this.m_FillRefPixel = yAxis.ValueToPixels(this.Reference);
			this.m_XPixelMin = xAxis.ValueToPixels(xAxis.Min);
			this.m_XPixelMax = xAxis.ValueToPixels(xAxis.Max);
			if (this.m_XPixelMax < this.m_XPixelMin)
			{
				Math2.Switch(ref this.m_XPixelMax, ref this.m_XPixelMin);
			}
			int num = this.m_XPixelMax - this.m_XPixelMin;
			if (num < 1)
			{
				this.m_PixelYValues = null;
			}
			else
			{
				if (this.m_PixelYValues == null)
				{
					this.m_PixelYValues = new double[num];
				}
				if (this.m_PixelYValues.Length != num)
				{
					this.m_PixelYValues = new double[num];
				}
			}
			if (this.m_PixelYValues != null)
			{
				for (int i = 0; i < this.m_PixelYValues.Length; i++)
				{
					this.m_PixelYValues[i] = 1E+305;
				}
			}
			if (this.Trace.Visible && this.Count > 1)
			{
				this.DrawTraceCustomAttributes(p, xAxis, yAxis);
			}
			this.DrawMarkers(p, xAxis, yAxis, this.Markers);
		}
	}
}
