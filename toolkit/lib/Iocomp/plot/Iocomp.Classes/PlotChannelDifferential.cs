using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Channel Differential")]
	public class PlotChannelDifferential : PlotChannelConsecutive
	{
		private PlotPen m_Trace;

		private IPlotPen I_Trace;

		private PlotFill m_Fill;

		private IPlotFill I_Fill;

		private PlotMarker m_Markers;

		private IPlotMarker I_Markers;

		private double m_Reference;

		private bool m_Terminated;

		private bool m_UserCanMoveDataPoints;

		private PlotDataMoveStyle m_DataPointsMoveStyle;

		private int m_MarkersTurnOffLimit;

		private PlotTraceFastDraw m_TraceFastDraw;

		private int m_MouseDownDataPointIndex;

		private PlotDataPointDifferential m_MouseDownDataPoint;

		private double m_MouseDownDataPointX;

		private double m_MouseDownDataPointY;

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
		public PlotFill Fill
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

		public PlotDataPointDifferential this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointDifferential;
			}
		}

		public event PlotChannelDataPointMovedEventHandler DataPointMoved;

		public event PlotChannelDataPointClickEventHandler DataPointClick;

		public event PlotChannelDataPointClickEventHandler DataPointDoubleClick;

		protected override string GetPlugInTitle()
		{
			return "Channel Differential";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelDifferentialEditorPlugIn";
		}

		public PlotChannelDifferential()
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
			this.m_TraceFastDraw = new PlotTraceFastDraw();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Differential";
			this.UserCanMoveDataPoints = false;
			this.DataPointsMoveStyle = PlotDataMoveStyle.XandY;
			this.Trace.Color = Color.Empty;
			this.Trace.Thickness = 1.0;
			this.Trace.Style = PlotPenStyle.Solid;
			this.Trace.Visible = true;
			this.Terminated = false;
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

		private bool ShouldSerializeTerminated()
		{
			return base.PropertyShouldSerialize("Terminated");
		}

		private void ResetTerminated()
		{
			base.PropertyReset("Terminated");
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
			return new PlotDataPointDifferential(this);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue)
		{
			base.CheckForValidNextX(x);
			PlotDataPointDifferential plotDataPointDifferential = (PlotDataPointDifferential)base.m_Data.AddNew();
			base.DataPointInitializing = true;
			try
			{
				plotDataPointDifferential.X = x;
				plotDataPointDifferential.Y = y;
				plotDataPointDifferential.Null = nullValue;
				plotDataPointDifferential.Empty = emptyValue;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			base.m_Data.UpdateMinMaxMean(plotDataPointDifferential);
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
						PlotDataPointDifferential plotDataPointDifferential = this[num];
						Point point = base.GetPoint(plotDataPointDifferential.X, plotDataPointDifferential.Y);
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

		protected override void DrawLegendMarker(PaintArgs p, Rectangle r)
		{
			this.I_Fill.Draw(p, r);
			this.I_Trace.DrawLine(p, r.Left, (r.Top + r.Bottom) / 2, r.Right, (r.Top + r.Bottom) / 2);
			this.I_Markers.DrawLegend(p, r);
		}

		private void DrawTrace(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			if (this.Count >= 2)
			{
				PlotDataPointDifferential plotDataPointDifferential = new PlotDataPointDifferential(this);
				((IPlotBrush)this.Fill.Brush).GetBrush(p, base.BoundsClip);
				this.m_TraceFastDraw.P = p;
				this.m_TraceFastDraw.XAxis = xAxis;
				this.m_TraceFastDraw.YAxis = yAxis;
				this.m_TraceFastDraw.Pen = ((IPlotPen)this.Trace).GetPen(p);
				this.m_TraceFastDraw.TraceVisible = this.Trace.Visible;
				this.m_TraceFastDraw.XYSwapped = base.XYSwapped;
				this.m_TraceFastDraw.FillVisible = (this.Fill.Visible && this.Fill.Brush.Visible);
				this.m_TraceFastDraw.FillBrush = ((IPlotBrush)this.Fill.Brush).GetBrush(p, base.BoundsClip);
				this.m_TraceFastDraw.FillRefPixel = yAxis.ValueToPixels(this.Reference);
				this.m_TraceFastDraw.Reset();
				this.m_TraceFastDraw.Reset();
				int num = -1;
				for (int i = this.IndexDrawStart; i <= this.IndexDrawStop; i++)
				{
					if (base.GetValid(i))
					{
						if (num == -1)
						{
							this.m_TraceFastDraw.AddDataPoint(this[i]);
							num = i;
						}
						else if (this[num].Y != this[i].Y)
						{
							base.DataPointInitializing = true;
							plotDataPointDifferential.X = this[i].X;
							plotDataPointDifferential.Y = this[num].Y;
							base.DataPointInitializing = false;
							this.m_TraceFastDraw.AddDataPoint(plotDataPointDifferential);
							this.m_TraceFastDraw.AddDataPoint(this[i]);
						}
						else
						{
							this.m_TraceFastDraw.AddDataPoint(this[i]);
						}
						num = i;
					}
					else if (!this.GetEmpty(i) && this.GetNull(i))
					{
						this.m_TraceFastDraw.AddDataPoint(this[i]);
						num = -1;
					}
				}
				if (num != -1 && !this.Terminated)
				{
					base.DataPointInitializing = true;
					if (base.DataDirection == DataDirection.Increasing)
					{
						plotDataPointDifferential.X = base.XAxis.Max;
					}
					else
					{
						plotDataPointDifferential.X = base.XAxis.Min;
					}
					plotDataPointDifferential.Y = this[num].Y;
					base.DataPointInitializing = false;
					this.m_TraceFastDraw.AddDataPoint(plotDataPointDifferential);
				}
				this.m_TraceFastDraw.DrawFlush();
			}
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			bool flag = true;
			if (!this.Markers.Visible)
			{
				flag = false;
			}
			if (this.IndexDrawStart == -1)
			{
				flag = false;
			}
			if (this.IndexDrawStop == -1)
			{
				flag = false;
			}
			if (this.MarkersTurnOffLimit > 0)
			{
				int num = Math.Abs(this.IndexDrawStop - this.IndexDrawStart) + 1;
				if (num >= this.MarkersTurnOffLimit)
				{
					flag = false;
				}
			}
			this.DrawTrace(p, xAxis, yAxis);
			if (flag)
			{
				this.DrawMarkers(p, xAxis, yAxis, this.Markers);
			}
		}
	}
}
