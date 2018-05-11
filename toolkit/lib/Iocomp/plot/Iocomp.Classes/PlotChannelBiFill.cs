using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Channel Bi-Fill")]
	public class PlotChannelBiFill : PlotChannelConsecutive
	{
		private double m_Reference;

		private bool m_UserCanMoveDataPoints;

		private PlotDataMoveStyle m_DataPointsMoveStyle;

		private int m_MarkersTurnOffLimit;

		private PlotFill m_FillHigh;

		private IPlotFill I_FillHigh;

		private PlotFill m_FillLow;

		private IPlotFill I_FillLow;

		private PlotMarker m_Markers;

		private IPlotMarker I_Markers;

		private PlotPen m_Trace;

		private IPlotPen I_Trace;

		private PlotTraceFastDraw m_TraceFastDraw;

		private int m_MouseDownDataPointIndex;

		private PlotDataPointBiFill m_MouseDownDataPoint;

		private double m_MouseDownDataPointX;

		private double m_MouseDownDataPointY;

		private double m_MouseDownPosX;

		private double m_MouseDownPosY;

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

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[RefreshProperties(RefreshProperties.All)]
		public PlotFill FillLow
		{
			get
			{
				return this.m_FillLow;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill FillHigh
		{
			get
			{
				return this.m_FillHigh;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotPen Trace
		{
			get
			{
				return this.m_Trace;
			}
		}

		public PlotDataPointBiFill this[int index]
		{
			get
			{
				return base.m_Data[index] as PlotDataPointBiFill;
			}
		}

		public event PlotChannelDataPointMovedEventHandler DataPointMoved;

		public event PlotChannelDataPointClickEventHandler DataPointClick;

		public event PlotChannelDataPointClickEventHandler DataPointDoubleClick;

		protected override string GetPlugInTitle()
		{
			return "Channel Bi-Fill";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelBiFillEditorPlugIn";
		}

		public PlotChannelBiFill()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_FillHigh = new PlotFill();
			base.AddSubClass(this.FillHigh);
			this.I_FillHigh = this.FillHigh;
			this.m_FillLow = new PlotFill();
			base.AddSubClass(this.FillLow);
			this.I_FillLow = this.FillLow;
			this.m_Markers = new PlotMarker();
			base.AddSubClass(this.Markers);
			this.I_Markers = this.Markers;
			this.m_Trace = new PlotPen();
			base.AddSubClass(this.Trace);
			this.I_Trace = this.Trace;
			((ISubClassBase)this.Trace).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillHigh.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillHigh.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillLow.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.FillLow.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.Markers.Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.Markers.Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
			this.m_TraceFastDraw = new PlotTraceFastDraw();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "BiFill";
			this.UserCanMoveDataPoints = false;
			this.DataPointsMoveStyle = PlotDataMoveStyle.XandY;
			this.Reference = 0.0;
			this.FillHigh.Visible = true;
			this.FillHigh.Brush.Visible = true;
			this.FillHigh.Brush.Style = PlotBrushStyle.Solid;
			this.FillHigh.Brush.SolidColor = Color.Empty;
			this.FillHigh.Brush.GradientStartColor = Color.Blue;
			this.FillHigh.Brush.GradientStopColor = Color.Aqua;
			this.FillHigh.Brush.HatchForeColor = Color.Empty;
			this.FillHigh.Brush.HatchBackColor = Color.Empty;
			this.FillHigh.Pen.Visible = true;
			this.FillHigh.Pen.Color = Color.Empty;
			this.FillHigh.Pen.Thickness = 1.0;
			this.FillHigh.Pen.Style = PlotPenStyle.Solid;
			this.FillLow.Visible = true;
			this.FillLow.Brush.Visible = true;
			this.FillLow.Brush.Style = PlotBrushStyle.Solid;
			this.FillLow.Brush.SolidColor = Color.Empty;
			this.FillLow.Brush.GradientStartColor = Color.Blue;
			this.FillLow.Brush.GradientStopColor = Color.Aqua;
			this.FillLow.Brush.HatchForeColor = Color.Empty;
			this.FillLow.Brush.HatchBackColor = Color.Empty;
			this.FillLow.Pen.Visible = true;
			this.FillLow.Pen.Color = Color.Empty;
			this.FillLow.Pen.Thickness = 1.0;
			this.FillLow.Pen.Style = PlotPenStyle.Solid;
			this.Markers.Visible = false;
			this.Markers.Style = PlotMarkerStyle.Circle;
			this.Markers.Size = 3;
			this.Markers.Fill.Pen.Visible = true;
			this.Markers.Fill.Pen.Style = PlotPenStyle.Solid;
			this.Markers.Fill.Pen.Color = Color.Empty;
			this.Markers.Fill.Pen.Thickness = 1.0;
			this.Markers.Font = null;
			this.Markers.ForeColor = Color.Empty;
			this.Markers.Text = "";
			this.Markers.Fill.Brush.Visible = true;
			this.Markers.Fill.Brush.Style = PlotBrushStyle.Solid;
			this.Markers.Fill.Brush.SolidColor = Color.Empty;
			this.Markers.Fill.Brush.GradientStartColor = Color.Blue;
			this.Markers.Fill.Brush.GradientStopColor = Color.Aqua;
			this.Markers.Fill.Brush.HatchForeColor = Color.Empty;
			this.Markers.Fill.Brush.HatchBackColor = Color.Empty;
			this.MarkersTurnOffLimit = 0;
			this.Trace.Visible = false;
			this.Trace.Color = Color.Empty;
			this.Trace.Thickness = 1.0;
			this.Trace.Style = PlotPenStyle.Solid;
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

		private bool ShouldSerializeFillLow()
		{
			return ((ISubClassBase)this.FillLow).ShouldSerialize();
		}

		private void ResetFillLow()
		{
			((ISubClassBase)this.FillLow).ResetToDefault();
		}

		private bool ShouldSerializeFillHigh()
		{
			return ((ISubClassBase)this.FillHigh).ShouldSerialize();
		}

		private void ResetFillHigh()
		{
			((ISubClassBase)this.FillHigh).ResetToDefault();
		}

		private bool ShouldSerializeTrace()
		{
			return ((ISubClassBase)this.Trace).ShouldSerialize();
		}

		private void ResetTrace()
		{
			((ISubClassBase)this.Trace).ResetToDefault();
		}

		protected override PlotDataPointBase CreateDataPoint()
		{
			return new PlotDataPointBiFill(this);
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue)
		{
			base.CheckForValidNextX(x);
			PlotDataPointBiFill plotDataPointBiFill = (PlotDataPointBiFill)base.m_Data.AddNew();
			base.DataPointInitializing = true;
			try
			{
				plotDataPointBiFill.X = x;
				plotDataPointBiFill.Y = y;
				plotDataPointBiFill.Null = nullValue;
				plotDataPointBiFill.Empty = emptyValue;
			}
			finally
			{
				base.DataPointInitializing = false;
			}
			base.m_Data.UpdateMinMaxMean(plotDataPointBiFill);
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
						PlotDataPointBiFill plotDataPointBiFill = this[num];
						Point point = base.GetPoint(plotDataPointBiFill.X, plotDataPointBiFill.Y);
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

		protected override void LoadDesignTimeData(PlotXAxis xAxis, PlotYAxis yAxis, Random random, double yMin, double ySpan)
		{
			for (double num = xAxis.Min; num < xAxis.Max; num += ySpan / 5.0)
			{
				this.AddXY(num, this.Reference - ySpan / 2.0 + random.NextDouble() * ySpan);
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (this.Markers.Visible && this.Markers.Fill.Pen.Visible)
			{
				return;
			}
			if (this.Markers.Visible && this.Markers.Fill.Brush.Visible)
			{
				return;
			}
			if (this.FillLow.Visible && this.FillLow.Pen.Visible)
			{
				return;
			}
			if (this.FillLow.Visible && this.FillLow.Brush.Visible)
			{
				return;
			}
			if (this.FillHigh.Visible && this.FillHigh.Pen.Visible)
			{
				return;
			}
			if (this.FillHigh.Visible && this.FillHigh.Brush.Visible)
			{
				return;
			}
			base.CanDraw = false;
		}

		protected override void DrawLegendMarker(PaintArgs p, Rectangle r)
		{
			Rectangle r2 = new Rectangle(r.Left, r.Top, r.Width, r.Height / 2);
			this.I_FillHigh.Draw(p, r2);
			r2 = new Rectangle(r.Left, r.Top + r.Height / 2, r.Width, r.Height - r.Height / 2);
			this.I_FillLow.Draw(p, r2);
			p.Graphics.DrawRectangle(p.Graphics.Pen(Color.Silver), r);
		}

		protected void DrawFill(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			if (!this.FillHigh.Visible && !this.FillLow.Visible)
			{
				return;
			}
			if (this.Count >= 2)
			{
				Point[] array = new Point[base.DrawPointCount + 2];
				int num = base.YAxis.ScaleDisplay.ValueToPixels(this.Reference);
				int num2 = num;
				int num3 = num;
				int num4 = xAxis.ScaleDisplay.ValueToPixels(this.GetX(this.IndexDrawStart));
				int num5 = xAxis.ScaleDisplay.ValueToPixels(this.GetX(this.IndexDrawStop));
				if (base.XYSwapped)
				{
					array[0] = new Point(num, num4);
				}
				else
				{
					array[0] = new Point(num4, num);
				}
				for (int i = this.IndexDrawStart; i <= this.IndexDrawStop; i++)
				{
					int num6 = xAxis.ScaleDisplay.ValueToPixels(this.GetX(i));
					int num7 = yAxis.ScaleDisplay.ValueToPixels(this.GetY(i));
					num2 = Math.Min(num2, num7);
					num3 = Math.Max(num3, num7);
					if (base.XYSwapped)
					{
						array[i - this.IndexDrawStart + 1] = new Point(num7, num6);
					}
					else
					{
						array[i - this.IndexDrawStart + 1] = new Point(num6, num7);
					}
				}
				if (base.XYSwapped)
				{
					array[array.Length - 1] = new Point(num, num5);
				}
				else
				{
					array[array.Length - 1] = new Point(num5, num);
				}
				Rectangle boundRect = iRectangle.FromLTRB(base.XYSwapped, num4, num2, num5, num3);
				Rectangle rect = iRectangle.FromLTRB(base.XYSwapped, xAxis.ScaleDisplay.PixelsMin, yAxis.ScaleDisplay.PixelsMax, base.XAxis.ScaleDisplay.PixelsMax, num);
				Region clip = new Region(rect);
				p.Graphics.Clip = clip;
				this.I_FillHigh.DrawBiFill(p, array, boundRect);
				rect = iRectangle.FromLTRB(base.XYSwapped, xAxis.ScaleDisplay.PixelsMin, yAxis.ScaleDisplay.PixelsMin, base.XAxis.ScaleDisplay.PixelsMax, num);
				clip = new Region(rect);
				p.Graphics.Clip = clip;
				this.I_FillLow.DrawBiFill(p, array, boundRect);
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
			this.DrawFill(p, xAxis, yAxis);
			base.SetClipRect(p);
			if (this.Trace.Visible)
			{
				this.DrawTrace(p, xAxis, yAxis);
			}
			if (flag)
			{
				this.DrawMarkers(p, xAxis, yAxis, this.Markers);
			}
		}
	}
}
