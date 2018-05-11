using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Limit Band Y.")]
	public class PlotLimitBandY : PlotLimitBandBase
	{
		private double m_YStart;

		private double m_YStop;

		private Rectangle m_HitRectStart;

		private Rectangle m_HitRectStop;

		private Rectangle m_HitRectInner;

		private double m_MouseDownPos;

		private double m_MouseDownStart;

		private double m_MouseDownStop;

		private PlotLimitBandHitArea m_MouseDownHitArea;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double YStart
		{
			get
			{
				return this.m_YStart;
			}
			set
			{
				base.PropertyUpdateDefault("YStart", value);
				if (this.YStart != value)
				{
					this.m_YStart = value;
					base.DoPropertyChange(this, "YStart");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double YStop
		{
			get
			{
				return this.m_YStop;
			}
			set
			{
				base.PropertyUpdateDefault("YStop", value);
				if (this.YStop != value)
				{
					this.m_YStop = value;
					base.DoPropertyChange(this, "YStop");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Limit Band-Y";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLimitBandYEditorPlugIn";
		}

		public PlotLimitBandY()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "BandY";
			this.YStart = 40.0;
			this.YStop = 60.0;
		}

		private bool ShouldSerializeYStart()
		{
			return base.PropertyShouldSerialize("YStart");
		}

		private void ResetYStart()
		{
			base.PropertyReset("YStart");
		}

		private bool ShouldSerializeYStop()
		{
			return base.PropertyShouldSerialize("YStop");
		}

		private void ResetYStop()
		{
			base.PropertyReset("YStop");
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (shouldFocus)
			{
				base.Focus();
			}
			if (base.UserCanMove)
			{
				if (this.m_HitRectStart.Contains(e.X, e.Y))
				{
					this.m_MouseDownHitArea = PlotLimitBandHitArea.Start;
				}
				else if (this.m_HitRectStop.Contains(e.X, e.Y))
				{
					this.m_MouseDownHitArea = PlotLimitBandHitArea.Stop;
				}
				else
				{
					this.m_MouseDownHitArea = PlotLimitBandHitArea.Band;
				}
				base.IsMouseActive = true;
				this.m_MouseDownStart = this.YStart;
				this.m_MouseDownStop = this.YStop;
				this.m_MouseDownPos = base.YAxis.PixelsToValue(e);
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			if (base.IsMouseActive)
			{
				if (this.m_MouseDownHitArea == PlotLimitBandHitArea.Start)
				{
					if (base.YAxis.ScaleType == ScaleType.Log10)
					{
						this.YStart = base.YAxis.PixelsToValue(e);
					}
					else
					{
						this.YStart = this.m_MouseDownStart + (base.YAxis.PixelsToValue(e) - this.m_MouseDownPos);
					}
				}
				else if (this.m_MouseDownHitArea == PlotLimitBandHitArea.Stop)
				{
					if (base.YAxis.ScaleType == ScaleType.Log10)
					{
						this.YStop = base.YAxis.PixelsToValue(e);
					}
					else
					{
						this.YStop = this.m_MouseDownStop + (base.YAxis.PixelsToValue(e) - this.m_MouseDownPos);
					}
				}
				else if (this.m_MouseDownHitArea == PlotLimitBandHitArea.Band)
				{
					if (base.YAxis.ScaleType == ScaleType.Log10)
					{
						this.YStart = base.YAxis.PixelsToValue(e);
					}
					else
					{
						this.YStart = this.m_MouseDownStart + (base.YAxis.PixelsToValue(e) - this.m_MouseDownPos);
					}
					if (base.YAxis.ScaleType == ScaleType.Log10)
					{
						this.YStop = base.YAxis.PixelsToValue(e);
					}
					else
					{
						this.YStop = this.m_MouseDownStop + (base.YAxis.PixelsToValue(e) - this.m_MouseDownPos);
					}
				}
			}
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			base.IsMouseActive = false;
		}

		protected override void InternalOnKeyDown(KeyEventArgs e)
		{
			if (e.Control)
			{
				if (e.KeyCode == Keys.Left)
				{
					this.YStop -= base.YAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Down)
				{
					this.YStop -= base.YAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Right)
				{
					this.YStop += base.YAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Up)
				{
					this.YStop += base.YAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Prior)
				{
					this.YStop += base.YAxis.ScaleDisplay.MajorIncrement;
				}
				else if (e.KeyCode == Keys.Next)
				{
					this.YStop -= base.YAxis.ScaleDisplay.MajorIncrement;
				}
				else if (e.KeyCode == Keys.Home)
				{
					this.YStop = base.YAxis.Min;
				}
				else if (e.KeyCode == Keys.End)
				{
					this.YStop = base.YAxis.Max;
				}
			}
			else if (e.KeyCode == Keys.Left)
			{
				this.YStart -= base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Down)
			{
				this.YStart -= base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Right)
			{
				this.YStart += base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Up)
			{
				this.YStart += base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Prior)
			{
				this.YStart += base.YAxis.ScaleDisplay.MajorIncrement;
			}
			else if (e.KeyCode == Keys.Next)
			{
				this.YStart -= base.YAxis.ScaleDisplay.MajorIncrement;
			}
			else if (e.KeyCode == Keys.Home)
			{
				this.YStart = base.YAxis.Min;
			}
			else if (e.KeyCode == Keys.End)
			{
				this.YStart = base.YAxis.Max;
			}
		}

		protected override void InternalOnMouseWheel(MouseEventArgs e)
		{
			if (Control.ModifierKeys == Keys.Control)
			{
				this.YStop += base.YAxis.ScaleRange.Span * 0.001 * (double)e.Delta / (double)Math.Abs(e.Delta);
			}
			else
			{
				this.YStart += base.YAxis.ScaleRange.Span * 0.001 * (double)e.Delta / (double)Math.Abs(e.Delta);
			}
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			if (!base.UserCanMove)
			{
				return Cursors.Default;
			}
			if (!this.m_HitRectStart.Contains(e.X, e.Y) && !this.m_HitRectStop.Contains(e.X, e.Y))
			{
				return Cursors.Hand;
			}
			if (base.XYSwapped)
			{
				return Cursors.SizeWE;
			}
			return Cursors.SizeNS;
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			Pen pen = ((IPlotPen)base.Fill.Pen).GetPen(p);
			int dataViewXPixelsMin = base.GetDataViewXPixelsMin();
			int dataViewXPixelsMax = base.GetDataViewXPixelsMax();
			int num = yAxis.ValueToPixels(this.YStart);
			int num2 = dataViewXPixelsMax;
			int num3 = num;
			int num4 = dataViewXPixelsMin;
			int num5 = yAxis.ValueToPixels(this.YStop);
			int num6 = dataViewXPixelsMax;
			int num7 = num5;
			int num8 = dataViewXPixelsMin;
			Rectangle rectangle = iRectangle.FromLTRB(base.XYSwapped, num2, num5, num8, num);
			this.m_HitRectStart = iRectangle.FromLTRB(base.XYSwapped, num2, num - base.HitRegionSize, num4, num3 + base.HitRegionSize);
			this.m_HitRectStop = iRectangle.FromLTRB(base.XYSwapped, num6, num5 - base.HitRegionSize, num8, num7 + base.HitRegionSize);
			this.m_HitRectInner = rectangle;
			this.m_HitRectInner.Inflate(0, -base.HitRegionSize);
			if (base.Fill.Brush.Visible)
			{
				Brush brush = ((IPlotBrush)base.Fill.Brush).GetBrush(p, rectangle);
				p.Graphics.FillRectangle(brush, rectangle);
			}
			if (base.Fill.Pen.Visible)
			{
				if (base.XYSwapped)
				{
					p.Graphics.DrawLine(pen, num, num2, num3, num4);
					p.Graphics.DrawLine(pen, num5, num6, num7, num8);
				}
				else
				{
					p.Graphics.DrawLine(pen, num2, num, num4, num3);
					p.Graphics.DrawLine(pen, num6, num5, num8, num7);
				}
			}
			base.Bounds = Rectangle.Union(this.m_HitRectStart, this.m_HitRectStop);
		}

		protected override void DrawFocusRectangles(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			if (base.Focused)
			{
				p.Graphics.DrawFocusRectangle(base.Bounds, base.BackColor);
			}
		}
	}
}
