using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Channel Trace XY")]
	public class PlotChannelTraceXY : PlotChannelXYBase
	{
		private PlotPen m_Trace;

		private IPlotPen I_Trace;

		private PlotMarker m_Markers;

		private IPlotMarker I_Markers;

		private bool m_UserCanMoveDataPoints;

		private bool m_DrawCustomDataPointAttributes;

		private PlotDataMoveStyle m_DataPointsMoveStyle;

		private int m_MarkersTurnOffLimit;

		private int m_MouseDownDataPointIndex;

		private PlotDataPointTraceXY m_MouseDownDataPoint;

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
		public PlotMarker Markers
		{
			get
			{
				return this.m_Markers;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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

		public PlotDataPointTraceXY this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointTraceXY;
			}
		}

		public event PlotChannelDataPointMovedEventHandler DataPointMoved;

		public event PlotChannelDataPointClickEventHandler DataPointClick;

		public event PlotChannelDataPointClickEventHandler DataPointDoubleClick;

		protected override string GetPlugInTitle()
		{
			return "Channel Trace XY";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelTraceXYEditorPlugIn";
		}

		public PlotChannelTraceXY()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Trace = new PlotPen();
			base.AddSubClass(this.Trace);
			this.I_Trace = this.Trace;
			this.m_Markers = new PlotMarker();
			base.AddSubClass(this.Markers);
			this.I_Markers = this.Markers;
			((ISubClassBase)this.Trace).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.Markers.Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.Markers.Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "TraceXY";
			base.DataCollection.XValueNotValidWhenEmptyOrNull = true;
			this.UserCanMoveDataPoints = false;
			this.DrawCustomDataPointAttributes = false;
			this.DataPointsMoveStyle = PlotDataMoveStyle.XandY;
			this.Trace.Color = Color.Empty;
			this.Trace.Thickness = 1.0;
			this.Trace.Style = PlotPenStyle.Solid;
			this.Trace.Visible = false;
			this.Markers.Visible = true;
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

		private bool ShouldSerializeMarkers()
		{
			return ((ISubClassBase)this.Markers).ShouldSerialize();
		}

		private void ResetMarkers()
		{
			((ISubClassBase)this.Markers).ResetToDefault();
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
			return new PlotDataPointTraceXY(this);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue)
		{
			PlotDataPointTraceXY plotDataPointTraceXY = (PlotDataPointTraceXY)base.m_Data.AddNew();
			base.DataPointInitializing = true;
			try
			{
				plotDataPointTraceXY.X = x;
				plotDataPointTraceXY.Y = y;
				plotDataPointTraceXY.Null = nullValue;
				plotDataPointTraceXY.Empty = emptyValue;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			base.m_Data.UpdateMinMaxMean(plotDataPointTraceXY);
			if (!nullValue && !emptyValue && base.SendXAxisTrackingData)
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
						PlotDataPointTraceXY plotDataPointTraceXY = this[num];
						Point point = base.GetPoint(plotDataPointTraceXY.X, plotDataPointTraceXY.Y);
						int num2 = (!this.DrawCustomDataPointAttributes) ? this.Markers.Size : plotDataPointTraceXY.Marker.Size;
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
				double x = this.m_MouseDownDataPointX + (base.XAxis.PixelsToValue(e) - this.m_MouseDownPosX);
				double y = this.m_MouseDownDataPointY + (base.YAxis.PixelsToValue(e) - this.m_MouseDownPosY);
				if (this.DataPointsMoveStyle == PlotDataMoveStyle.XandY || this.DataPointsMoveStyle == PlotDataMoveStyle.XOnly)
				{
					this.m_MouseDownDataPoint.X = x;
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

		private void DrawLine(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis, Pen pen, PlotDataPointTraceXY point1, PlotDataPointTraceXY point2)
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
		}

		private void DrawTrace(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			PlotDataPointTraceXY plotDataPointTraceXY = null;
			PlotDataPointTraceXY plotDataPointTraceXY2 = null;
			((IPlotPen)this.Trace).GetPen(p);
			for (int i = this.IndexDrawStart; i <= this.IndexDrawStop; i++)
			{
				PlotDataPointTraceXY plotDataPointTraceXY3 = this[i];
				if (plotDataPointTraceXY3.Null)
				{
					plotDataPointTraceXY = null;
					plotDataPointTraceXY2 = null;
				}
				else if (!plotDataPointTraceXY3.Empty)
				{
					if (plotDataPointTraceXY == null)
					{
						plotDataPointTraceXY = plotDataPointTraceXY3;
					}
					else
					{
						plotDataPointTraceXY2 = plotDataPointTraceXY3;
						if (plotDataPointTraceXY2.Trace.Visible)
						{
							this.DrawLine(p, xAxis, yAxis, ((IPlotPen)plotDataPointTraceXY2.Trace).GetPen(p), plotDataPointTraceXY, plotDataPointTraceXY2);
						}
						plotDataPointTraceXY = plotDataPointTraceXY2;
					}
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
				for (int i = this.IndexDrawStart; i <= this.IndexDrawStop; i++)
				{
					PlotDataPointTraceXY plotDataPointTraceXY = this[i];
					if (!plotDataPointTraceXY.Null && !plotDataPointTraceXY.Empty)
					{
						int num2 = xAxis.ScaleDisplay.ValueToPixels(plotDataPointTraceXY.X);
						int num3 = yAxis.ScaleDisplay.ValueToPixels(plotDataPointTraceXY.Y);
						if (base.XYSwapped)
						{
							((IPlotMarker)plotDataPointTraceXY.Marker).Draw(p, num3, num2);
						}
						else
						{
							((IPlotMarker)plotDataPointTraceXY.Marker).Draw(p, num2, num3);
						}
					}
				}
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (this.Count == 0)
			{
				base.CanDraw = false;
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
