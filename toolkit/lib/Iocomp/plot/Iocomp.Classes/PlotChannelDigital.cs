using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Channel Digital")]
	public class PlotChannelDigital : PlotChannelConsecutive
	{
		private PlotPen m_Trace;

		private IPlotPen I_Trace;

		private PlotMarker m_Markers;

		private IPlotMarker I_Markers;

		private PlotBrush m_Fill;

		private IPlotBrush I_Fill;

		private PlotDigitalReferenceStyle m_ReferenceStyle;

		private double m_ReferenceHigh;

		private double m_ReferenceLow;

		private bool m_Terminated;

		private bool m_UserCanMoveDataPoints;

		private PlotDataMoveStyle m_DataPointsMoveStyle;

		private int m_MarkersTurnOffLimit;

		private int m_MouseDownDataPointIndex;

		private PlotDataPointDigital m_MouseDownDataPoint;

		private double m_MouseDownDataPointX;

		private bool m_MouseDownDataPointY;

		private double m_MouseDownPosX;

		private double m_MouseDownPosY;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotPen Trace
		{
			get
			{
				return this.m_Trace;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotBrush Fill
		{
			get
			{
				return this.m_Fill;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotMarker Markers
		{
			get
			{
				return this.m_Markers;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool Terminated
		{
			get
			{
				return this.m_Terminated;
			}
			set
			{
				base.PropertyUpdateDefault("Terminated", value);
				if (this.Terminated != value)
				{
					this.m_Terminated = value;
					base.DoPropertyChange(this, "Terminated");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotDigitalReferenceStyle ReferenceStyle
		{
			get
			{
				return this.m_ReferenceStyle;
			}
			set
			{
				base.PropertyUpdateDefault("ReferenceStyle", value);
				if (this.ReferenceStyle != value)
				{
					this.m_ReferenceStyle = value;
					base.DoPropertyChange(this, "ReferenceStyle");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double ReferenceHigh
		{
			get
			{
				return this.m_ReferenceHigh;
			}
			set
			{
				base.PropertyUpdateDefault("ReferenceHigh", value);
				if (this.ReferenceHigh != value)
				{
					this.m_ReferenceHigh = value;
					base.DoPropertyChange(this, "ReferenceHigh");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double ReferenceLow
		{
			get
			{
				return this.m_ReferenceLow;
			}
			set
			{
				base.PropertyUpdateDefault("ReferenceLow", value);
				if (this.ReferenceLow != value)
				{
					this.m_ReferenceLow = value;
					base.DoPropertyChange(this, "ReferenceLow");
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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

		public PlotDataPointDigital this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointDigital;
			}
		}

		public override double YMinScale => this.GetYValueAxisValue(base.YMin);

		public override double YMaxScale => this.GetYValueAxisValue(base.YMax);

		public event PlotChannelDataPointMovedEventHandler DataPointMoved;

		public event PlotChannelDataPointClickEventHandler DataPointClick;

		public event PlotChannelDataPointClickEventHandler DataPointDoubleClick;

		protected override string GetPlugInTitle()
		{
			return "Channel Digital";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelDigitalEditorPlugIn";
		}

		public PlotChannelDigital()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Trace = new PlotPen();
			base.AddSubClass(this.Trace);
			this.I_Trace = this.Trace;
			this.m_Fill = new PlotBrush();
			base.AddSubClass(this.Fill);
			this.I_Fill = this.Fill;
			this.m_Markers = new PlotMarker();
			base.AddSubClass(this.Markers);
			this.I_Markers = this.Markers;
			((ISubClassBase)this.Trace).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.Fill).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.Markers.Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.Markers.Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Digital";
			this.UserCanMoveDataPoints = false;
			this.DataPointsMoveStyle = PlotDataMoveStyle.XandY;
			this.ReferenceStyle = PlotDigitalReferenceStyle.Units;
			this.ReferenceHigh = 90.0;
			this.ReferenceLow = 10.0;
			this.Terminated = true;
			this.Trace.Color = Color.Empty;
			this.Trace.Thickness = 1.0;
			this.Trace.Style = PlotPenStyle.Solid;
			this.Trace.Visible = true;
			this.Fill.Visible = false;
			this.Fill.Style = PlotBrushStyle.Solid;
			this.Fill.SolidColor = Color.Empty;
			this.Fill.GradientStartColor = Color.Blue;
			this.Fill.GradientStopColor = Color.Aqua;
			this.Fill.HatchForeColor = Color.Empty;
			this.Fill.HatchBackColor = Color.Empty;
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

		private bool ShouldSerializeTerminated()
		{
			return base.PropertyShouldSerialize("Terminated");
		}

		private void ResetTerminated()
		{
			base.PropertyReset("Terminated");
		}

		private bool ShouldSerializeReferenceStyle()
		{
			return base.PropertyShouldSerialize("ReferenceStyle");
		}

		private void ResetReferenceStyle()
		{
			base.PropertyReset("ReferenceStyle");
		}

		private bool ShouldSerializeReferenceHigh()
		{
			return base.PropertyShouldSerialize("ReferenceHigh");
		}

		private void ResetReferenceHigh()
		{
			base.PropertyReset("ReferenceHigh");
		}

		private bool ShouldSerializeReferenceLow()
		{
			return base.PropertyShouldSerialize("ReferenceLow");
		}

		private void ResetReferenceLow()
		{
			base.PropertyReset("ReferenceLow");
		}

		private bool ShouldSerializeUserCanMoveDataPoints()
		{
			return base.PropertyShouldSerialize("UserCanMoveDataPoints");
		}

		private void ResetUserCanMoveDataPoints()
		{
			base.PropertyReset("UserCanMoveDataPoints");
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
			return new PlotDataPointDigital(this);
		}

		public int AddXY(double x, bool y)
		{
			if (y)
			{
				return this.AddXY(x, 1.0);
			}
			return this.AddXY(x, 0.0);
		}

		public int AddXY(DateTime x, bool y)
		{
			if (y)
			{
				return this.AddXY(Math2.DateTimeToDouble(x), 1.0);
			}
			return this.AddXY(Math2.DateTimeToDouble(x), 0.0);
		}

		private int AddXY(double x, bool y, bool nullValue, bool emptyValue)
		{
			base.CheckForValidNextX(x);
			double value = (!y) ? this.ReferenceLow : this.ReferenceHigh;
			PlotDataPointDigital plotDataPointDigital = (PlotDataPointDigital)base.m_Data.AddNew();
			base.DataPointInitializing = true;
			try
			{
				plotDataPointDigital.X = x;
				plotDataPointDigital.Y = y;
				plotDataPointDigital.Null = nullValue;
				plotDataPointDigital.Empty = emptyValue;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			if (y)
			{
				base.m_Data.UpdateMinMaxMean(x, 1.0, emptyValue, nullValue);
			}
			else
			{
				base.m_Data.UpdateMinMaxMean(x, 0.0, emptyValue, nullValue);
			}
			if (base.SendXAxisTrackingData)
			{
				PlotXAxis xAxis = base.XAxis;
				xAxis?.Tracking.NewData(x);
			}
			if (!nullValue && !emptyValue && base.SendYAxisTrackingData)
			{
				PlotYAxis yAxis = base.YAxis;
				yAxis?.Tracking.NewData(value);
			}
			this.DoDataChange();
			return base.m_Data.LastNewDataPointIndex;
		}

		public override int AddXY(double x, double y)
		{
			return this.AddXY(x, y != 0.0, false, false);
		}

		public override int AddEmpty(double x)
		{
			return this.AddXY(x, false, false, true);
		}

		public override int AddNull(double x)
		{
			return this.AddXY(x, false, true, false);
		}

		public override double GetX(int index)
		{
			return this[index].X;
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

		public override void SetNull(int index, bool value)
		{
			this[index].Null = value;
		}

		public override void SetEmpty(int index, bool value)
		{
			this[index].Empty = value;
		}

		public override double GetY(int index)
		{
			if ((base.m_Data[index] as PlotDataPointDigital).Y)
			{
				return 1.0;
			}
			return 0.0;
		}

		public double GetY(bool value)
		{
			if (value)
			{
				return this.ReferenceHigh;
			}
			return this.ReferenceLow;
		}

		public override void SetY(int index, double value)
		{
			if (value != 0.0)
			{
				(base.m_Data[index] as PlotDataPointDigital).Y = true;
			}
			else
			{
				(base.m_Data[index] as PlotDataPointDigital).Y = false;
			}
			this.DoDataChange();
		}

		public override double GetYValueAxisValue(double yValue)
		{
			if (yValue == 0.0)
			{
				return this.ReferenceLow;
			}
			return this.ReferenceHigh;
		}

		public override string GetYValueText(double value)
		{
			if (value == 0.0)
			{
				return "Low";
			}
			return "High";
		}

		public override PlotChannelInterpolationResult GetYInterpolated(double targetX, out double yValue)
		{
			yValue = 0.0;
			if (this.Count == 0)
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
			if (x <= targetX)
			{
				if (num >= base.IndexLast)
				{
					return PlotChannelInterpolationResult.Invalid;
				}
				num2 = num;
				int num3 = num + 1;
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
				int num3 = num;
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
			yValue = this.GetY(num2);
			return PlotChannelInterpolationResult.Valid;
		}

		protected override void LoadDesignTimeData(PlotXAxis xAxis, PlotYAxis yAxis, Random random, double yMin, double ySpan)
		{
			for (double num = xAxis.Min; num < xAxis.Max; num += xAxis.Span / 100.0)
			{
				this.AddXY(num, random.NextDouble() > 0.5);
			}
		}

		[Description("")]
		public Point GetPoint(double x, bool y)
		{
			if (y)
			{
				return base.GetPoint(x, this.ReferenceHigh);
			}
			return base.GetPoint(x, this.ReferenceLow);
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
						PlotDataPointDigital plotDataPointDigital = this[num];
						Point point = this.GetPoint(plotDataPointDigital.X, plotDataPointDigital.Y);
						if (!new Rectangle(point.X - this.Markers.Size, point.Y - this.Markers.Size, this.Markers.Size * 2, this.Markers.Size * 2).Contains(e.X, e.Y))
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
				bool y = base.YAxis.PixelsToValue(e) > (this.ReferenceHigh + this.ReferenceLow) / 2.0 && true;
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
				bool y = this[this.m_MouseDownDataPointIndex].Y;
				if (this.m_MouseDownDataPointX != x || this.m_MouseDownDataPointY != y)
				{
					PlotChannelDataPointMovedEventArgs e2 = new PlotChannelDataPointMovedEventArgs(this, this.m_MouseDownDataPointIndex, this.m_MouseDownDataPointX, this.GetY(this.m_MouseDownDataPointY), x, this.GetY(y));
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

		protected override void DrawLegendMarker(PaintArgs p, Rectangle r)
		{
			if (this.Fill.Visible)
			{
				p.Graphics.FillRectangle(this.I_Fill.GetBrush(p, r), r);
			}
			this.I_Trace.DrawLine(p, r.Left, (r.Top + r.Bottom) / 2, r.Right, (r.Top + r.Bottom) / 2);
			this.I_Markers.DrawLegend(p, r);
		}

		protected void DrawTrace(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			int num = -1;
			int num2 = 0;
			int num3 = 0;
			int[] array = new int[2];
			Pen pen = ((IPlotPen)this.Trace).GetPen(p);
			if (this.ReferenceStyle == PlotDigitalReferenceStyle.Units)
			{
				array[1] = base.YAxis.ScaleDisplay.ValueToPixels(this.ReferenceHigh);
				array[0] = base.YAxis.ScaleDisplay.ValueToPixels(this.ReferenceLow);
			}
			else
			{
				array[1] = base.YAxis.ScaleDisplay.PercentToPixels(this.ReferenceHigh);
				array[0] = base.YAxis.ScaleDisplay.PercentToPixels(this.ReferenceLow);
			}
			for (int i = this.IndexDrawStart; i <= this.IndexDrawStop; i++)
			{
				if (base.GetValid(i))
				{
					if (num != -1)
					{
						int num4 = xAxis.ScaleDisplay.ValueToPixels(this.GetX(num));
						num2 = xAxis.ScaleDisplay.ValueToPixels(this.GetX(i));
						int num5 = (!this[num].Y) ? array[0] : array[1];
						num3 = ((!this[i].Y) ? array[0] : array[1]);
						if (num5 == num3)
						{
							if (base.XYSwapped)
							{
								p.Graphics.DrawLine(pen, num5, num4, num3, num2);
							}
							else
							{
								p.Graphics.DrawLine(pen, num4, num5, num2, num3);
							}
						}
						else if (base.XYSwapped)
						{
							p.Graphics.DrawLine(pen, num5, num4, num5, num2);
							p.Graphics.DrawLine(pen, num5, num2, num3, num2);
						}
						else
						{
							p.Graphics.DrawLine(pen, num4, num5, num2, num5);
							p.Graphics.DrawLine(pen, num2, num5, num2, num3);
						}
						num = i;
						if (this.Fill.Visible && num5 != array[0])
						{
							Rectangle rectangle = Rectangle.FromLTRB(num4, num5, num2, array[0]);
							p.Graphics.FillRectangle(this.I_Fill.GetBrush(p, rectangle), rectangle);
						}
					}
					else
					{
						num = i;
					}
				}
				else if (!this.GetEmpty(i) && this.GetNull(i))
				{
					num = -1;
				}
			}
			if (num != -1 && !this.Terminated)
			{
				if (base.XYSwapped)
				{
					p.Graphics.DrawLine(pen, num3, num2, num3, xAxis.ScaleDisplay.PixelsMax);
				}
				else
				{
					p.Graphics.DrawLine(pen, num2, num3, xAxis.ScaleDisplay.PixelsMax, num3);
				}
			}
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
				Brush brush = ((IPlotBrush)markers.Fill.Brush).GetBrush(p, Rectangle.Empty);
				Pen pen = ((IPlotPen)markers.Fill.Pen).GetPen(p);
				for (int i = this.IndexDrawStart; i <= this.IndexDrawStop; i++)
				{
					if (!this.GetNull(i) && !this.GetEmpty(i))
					{
						int num2 = xAxis.ScaleDisplay.ValueToPixels(this.GetX(i));
						int num3 = (this.GetY(i) != 0.0) ? yAxis.ScaleDisplay.ValueToPixels(this.ReferenceHigh) : yAxis.ScaleDisplay.ValueToPixels(this.ReferenceLow);
						if (base.XYSwapped)
						{
							((IPlotMarker)markers).Draw(p, num3, num2, brush, pen);
						}
						else
						{
							((IPlotMarker)markers).Draw(p, num2, num3, brush, pen);
						}
					}
				}
			}
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			if (this.Trace.Visible && this.Count > 1)
			{
				this.DrawTrace(p, xAxis, yAxis);
			}
			this.DrawMarkers(p, xAxis, yAxis, this.Markers);
		}
	}
}
