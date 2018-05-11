using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Channel Sweep Interval")]
	public class PlotChannelSweepInterval : PlotChannelConsecutive
	{
		private PlotPen m_Trace;

		private IPlotPen I_Trace;

		private PlotMarker m_Markers;

		private IPlotMarker I_Markers;

		private PlotPen m_RetraceLine;

		private IPlotPen I_RetraceLine;

		private bool m_UserCanMoveDataPoints;

		private PlotDataMoveStyle m_DataPointsMoveStyle;

		private int m_MarkersTurnOffLimit;

		private int m_SweepCount;

		private double m_SweepXStart;

		private double m_SweepXInterval;

		private int m_SweepLeadingBreakCount;

		private int m_SweepIndex;

		private double m_SweepYDefaultValue;

		private bool m_SweepYDefaultNull;

		private int m_LastAddIndex;

		private bool m_ClearOnRetrace;

		private PlotTraceFastDraw m_TraceFastDraw;

		private int m_MouseDownDataPointIndex;

		private PlotDataPointSweepInterval m_MouseDownDataPoint;

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
		public PlotPen RetraceLine
		{
			get
			{
				return this.m_RetraceLine;
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int SweepCount
		{
			get
			{
				return this.m_SweepCount;
			}
			set
			{
				base.PropertyUpdateDefault("SweepCount", value);
				if (this.SweepCount != value)
				{
					this.m_SweepCount = value;
					this.ResetDataArray();
					base.DoPropertyChange(this, "SweepCount");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double SweepXStart
		{
			get
			{
				return this.m_SweepXStart;
			}
			set
			{
				base.PropertyUpdateDefault("SweepXStart", value);
				if (this.SweepXStart != value)
				{
					this.m_SweepXStart = value;
					this.ResetDataArray();
					base.DoPropertyChange(this, "SweepXStart");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double SweepXInterval
		{
			get
			{
				return this.m_SweepXInterval;
			}
			set
			{
				base.PropertyUpdateDefault("SweepXInterval", value);
				if (this.SweepXInterval != value)
				{
					this.m_SweepXInterval = value;
					this.ResetDataArray();
					base.DoPropertyChange(this, "SweepXInterval");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double SweepYDefaultValue
		{
			get
			{
				return this.m_SweepYDefaultValue;
			}
			set
			{
				base.PropertyUpdateDefault("SweepYDefaultValue", value);
				if (this.SweepYDefaultValue != value)
				{
					this.m_SweepYDefaultValue = value;
					this.ResetDataArray();
					base.DoPropertyChange(this, "SweepYDefaultValue");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool SweepYDefaultNull
		{
			get
			{
				return this.m_SweepYDefaultNull;
			}
			set
			{
				base.PropertyUpdateDefault("SweepYDefaultNull", value);
				if (this.SweepYDefaultNull != value)
				{
					this.m_SweepYDefaultNull = value;
					this.ResetDataArray();
					base.DoPropertyChange(this, "SweepYDefaultNull");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int SweepLeadingBreakCount
		{
			get
			{
				return this.m_SweepLeadingBreakCount;
			}
			set
			{
				base.PropertyUpdateDefault("SweepLeadingBreakCount", value);
				if (this.SweepLeadingBreakCount != value)
				{
					this.m_SweepLeadingBreakCount = value;
					base.DoPropertyChange(this, "SweepLeadingBreakCount");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ClearOnRetrace
		{
			get
			{
				return this.m_ClearOnRetrace;
			}
			set
			{
				base.PropertyUpdateDefault("ClearOnRetrace", value);
				if (this.ClearOnRetrace != value)
				{
					this.m_ClearOnRetrace = value;
					base.DoPropertyChange(this, "ClearOnRetrace");
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		public PlotDataPointSweepInterval this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointSweepInterval;
			}
		}

		public int SweepIndex => this.m_SweepIndex;

		public override int Capacity
		{
			get
			{
				return base.m_Data.Capacity;
			}
			set
			{
			}
		}

		public event PlotChannelDataPointMovedEventHandler DataPointMoved;

		public event PlotChannelDataPointClickEventHandler DataPointClick;

		public event PlotChannelDataPointClickEventHandler DataPointDoubleClick;

		protected override string GetPlugInTitle()
		{
			return "Channel Sweep Interval";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelSweepIntervalEditorPlugIn";
		}

		public PlotChannelSweepInterval()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Trace = new PlotPen();
			base.AddSubClass(this.Trace);
			this.I_Trace = this.Trace;
			this.m_RetraceLine = new PlotPen();
			base.AddSubClass(this.RetraceLine);
			this.I_RetraceLine = this.Trace;
			this.m_Markers = new PlotMarker();
			base.AddSubClass(this.Markers);
			this.I_Markers = this.Markers;
			((ISubClassBase)this.Trace).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.RetraceLine).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.Markers.Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.Markers.Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			this.m_TraceFastDraw = new PlotTraceFastDraw();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Sweep-Interval";
			this.UserCanMoveDataPoints = false;
			this.DataPointsMoveStyle = PlotDataMoveStyle.XandY;
			this.SweepCount = 100;
			this.SweepXStart = 0.0;
			this.SweepXInterval = 1.0;
			this.SweepYDefaultValue = 50.0;
			this.SweepYDefaultNull = false;
			this.ResetDataArray();
			this.SweepLeadingBreakCount = 0;
			this.Trace.Visible = true;
			this.Trace.Color = Color.Empty;
			this.Trace.Thickness = 1.0;
			this.Trace.Style = PlotPenStyle.Solid;
			this.RetraceLine.Visible = true;
			this.RetraceLine.Color = Color.Yellow;
			this.RetraceLine.Thickness = 1.0;
			this.RetraceLine.Style = PlotPenStyle.Solid;
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

		private bool ShouldSerializeRetraceLine()
		{
			return ((ISubClassBase)this.RetraceLine).ShouldSerialize();
		}

		private void ResetRetraceLine()
		{
			((ISubClassBase)this.RetraceLine).ResetToDefault();
		}

		private bool ShouldSerializeMarkers()
		{
			return ((ISubClassBase)this.Markers).ShouldSerialize();
		}

		private void ResetMarkers()
		{
			((ISubClassBase)this.Markers).ResetToDefault();
		}

		private bool ShouldSerializeSweepCount()
		{
			return base.PropertyShouldSerialize("SweepCount");
		}

		private void ResetSweepCount()
		{
			base.PropertyReset("SweepCount");
		}

		private bool ShouldSerializeSweepXStart()
		{
			return base.PropertyShouldSerialize("SweepXStart");
		}

		private void ResetSweepXStart()
		{
			base.PropertyReset("SweepXStart");
		}

		private bool ShouldSerializeSweepXInterval()
		{
			return base.PropertyShouldSerialize("SweepXInterval");
		}

		private void ResetSweepXInterval()
		{
			base.PropertyReset("SweepXInterval");
		}

		private bool ShouldSerializeSweepYDefaultValue()
		{
			return base.PropertyShouldSerialize("SweepYDefaultValue");
		}

		private void ResetSweepYDefaultValue()
		{
			base.PropertyReset("SweepYDefaultValue");
		}

		private bool ShouldSerializeSweepYDefaultNull()
		{
			return base.PropertyShouldSerialize("SweepYDefaultNull");
		}

		private void ResetSweepYDefaultNull()
		{
			base.PropertyReset("SweepYDefaultNull");
		}

		private bool ShouldSerializeSweepLeadingBreakCount()
		{
			return base.PropertyShouldSerialize("SweepLeadingBreakCount");
		}

		private void ResetSweepLeadingBreakCount()
		{
			base.PropertyReset("SweepLeadingBreakCount");
		}

		private bool ShouldSerializeClearOnRetrace()
		{
			return base.PropertyShouldSerialize("ClearOnRetrace");
		}

		private void ResetClearOnRetrace()
		{
			base.PropertyReset("ClearOnRetrace");
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

		private void ResetDataArray()
		{
			base.m_Data.Clear();
			base.m_Data.ClearMinMeanMax();
			this.m_SweepIndex = -1;
			this.m_LastAddIndex = -1;
			for (int i = 0; i < this.SweepCount; i++)
			{
				PlotDataPointSweepInterval plotDataPointSweepInterval = (PlotDataPointSweepInterval)base.m_Data.AddNew();
				plotDataPointSweepInterval.X = this.SweepXStart + (double)i * this.SweepXInterval;
				plotDataPointSweepInterval.Y = this.SweepYDefaultValue;
				plotDataPointSweepInterval.Null = this.SweepYDefaultNull;
				plotDataPointSweepInterval.Empty = this.SweepYDefaultNull;
			}
			this.DoDataChange();
		}

		public void ClearDisplay()
		{
			this.m_SweepIndex = -1;
			this.m_LastAddIndex = -1;
			for (int i = 0; i < this.SweepCount; i++)
			{
				PlotDataPointSweepInterval plotDataPointSweepInterval = base.m_Data[i] as PlotDataPointSweepInterval;
				plotDataPointSweepInterval.X = this.SweepXStart + (double)i * this.SweepXInterval;
				plotDataPointSweepInterval.Y = this.SweepYDefaultValue;
				plotDataPointSweepInterval.Null = this.SweepYDefaultNull;
				plotDataPointSweepInterval.Empty = this.SweepYDefaultNull;
			}
			this.DoDataChange();
		}

		protected override PlotDataPointBase CreateDataPoint()
		{
			return new PlotDataPointSweepInterval(this);
		}

		private bool ShouldSerializeCapacity()
		{
			return false;
		}

		private void ResetCapacity()
		{
		}

		public override void Clear()
		{
			this.ResetDataArray();
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override void NewOPCData(double data, DateTime timeStamp)
		{
			this.Add(data);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue)
		{
			this.m_SweepIndex++;
			if (this.m_SweepIndex >= this.SweepCount)
			{
				this.m_SweepIndex = 0;
				if (this.ClearOnRetrace)
				{
					this.ClearDisplay();
				}
			}
			int sweepIndex = this.m_SweepIndex;
			this.m_LastAddIndex = this.m_SweepIndex;
			PlotDataPointSweepInterval plotDataPointSweepInterval = this[sweepIndex];
			base.DataPointInitializing = true;
			try
			{
				plotDataPointSweepInterval.Y = y;
				plotDataPointSweepInterval.Null = nullValue;
				plotDataPointSweepInterval.Empty = emptyValue;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			if (this.SweepLeadingBreakCount != 0)
			{
				for (int i = 0; i < this.SweepLeadingBreakCount; i++)
				{
					int num = sweepIndex + i + 1;
					if (num > this.SweepCount - 1)
					{
						num -= this.SweepCount;
					}
					this[num].Null = true;
				}
			}
			base.m_Data.UpdateMinMaxMean(plotDataPointSweepInterval);
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
			return sweepIndex;
		}

		public int Add(double y)
		{
			return this.AddXY(0.0, y, false, false);
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
						PlotDataPointSweepInterval plotDataPointSweepInterval = this[num];
						Point point = base.GetPoint(plotDataPointSweepInterval.X, plotDataPointSweepInterval.Y);
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
			this.I_Trace.DrawLine(p, r.Left, (r.Top + r.Bottom) / 2, r.Right, (r.Top + r.Bottom) / 2);
			this.I_Markers.DrawLegend(p, r);
		}

		private void DrawRetraceLine(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			if (this.RetraceLine.Visible && this.Count >= 1 && this.m_LastAddIndex != -1)
			{
				PlotDataPointSweepInterval plotDataPointSweepInterval = this[this.m_LastAddIndex];
				Pen pen = ((IPlotPen)this.RetraceLine).GetPen(p);
				int num = xAxis.ScaleDisplay.ValueToPixels(plotDataPointSweepInterval.X);
				int pixelsMin = yAxis.ScaleDisplay.PixelsMin;
				int num2 = xAxis.ScaleDisplay.ValueToPixels(plotDataPointSweepInterval.X);
				int pixelsMax = yAxis.ScaleDisplay.PixelsMax;
				if (base.XYSwapped)
				{
					p.Graphics.DrawLine(pen, pixelsMin, num, pixelsMax, num2);
				}
				else
				{
					p.Graphics.DrawLine(pen, num, pixelsMin, num2, pixelsMax);
				}
			}
		}

		private void DrawTrace(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			this.m_TraceFastDraw.P = p;
			this.m_TraceFastDraw.XAxis = xAxis;
			this.m_TraceFastDraw.YAxis = yAxis;
			this.m_TraceFastDraw.Pen = ((IPlotPen)this.Trace).GetPen(p);
			this.m_TraceFastDraw.TraceVisible = this.Trace.Visible;
			this.m_TraceFastDraw.XYSwapped = base.XYSwapped;
			this.m_TraceFastDraw.Reset();
			for (int i = this.IndexDrawStart; i <= this.IndexDrawStop; i++)
			{
				this.m_TraceFastDraw.AddDataPoint(this[i]);
			}
			this.m_TraceFastDraw.DrawFlush();
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
			if (this.Trace.Visible && this.Count > 1)
			{
				this.DrawTrace(p, xAxis, yAxis);
			}
			if (flag)
			{
				this.DrawMarkers(p, xAxis, yAxis, this.Markers);
			}
			this.DrawRetraceLine(p, xAxis, yAxis);
		}
	}
}
