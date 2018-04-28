using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Limit Band X.")]
	public class PlotLimitBandX : PlotLimitBandBase
	{
		private double m_XStart;

		private double m_XStop;

		private Rectangle m_HitRectStart;

		private Rectangle m_HitRectStop;

		private Rectangle m_HitRectInner;

		private double m_MouseDownPos;

		private double m_MouseDownStart;

		private double m_MouseDownStop;

		private PlotLimitBandHitArea m_MouseDownHitArea;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double XStart
		{
			get
			{
				return this.m_XStart;
			}
			set
			{
				base.PropertyUpdateDefault("XStart", value);
				if (this.XStart != value)
				{
					this.m_XStart = value;
					base.DoPropertyChange(this, "XStart");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double XStop
		{
			get
			{
				return this.m_XStop;
			}
			set
			{
				base.PropertyUpdateDefault("XStop", value);
				if (this.XStop != value)
				{
					this.m_XStop = value;
					base.DoPropertyChange(this, "XStop");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Limit Band-X";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLimitBandXEditorPlugIn";
		}

		public PlotLimitBandX()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "BandX";
			this.XStart = 40.0;
			this.XStop = 60.0;
		}

		private bool ShouldSerializeXStart()
		{
			return base.PropertyShouldSerialize("XStart");
		}

		private void ResetXStart()
		{
			base.PropertyReset("XStart");
		}

		private bool ShouldSerializeXStop()
		{
			return base.PropertyShouldSerialize("XStop");
		}

		private void ResetXStop()
		{
			base.PropertyReset("XStop");
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
				this.m_MouseDownStart = this.XStart;
				this.m_MouseDownStop = this.XStop;
				this.m_MouseDownPos = base.XAxis.PixelsToValue(e);
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			if (base.IsMouseActive)
			{
				if (this.m_MouseDownHitArea == PlotLimitBandHitArea.Start)
				{
					if (base.XAxis.ScaleType == ScaleType.Log10)
					{
						this.XStart = base.XAxis.PixelsToValue(e);
					}
					else
					{
						this.XStart = this.m_MouseDownStart + (base.XAxis.PixelsToValue(e) - this.m_MouseDownPos);
					}
				}
				else if (this.m_MouseDownHitArea == PlotLimitBandHitArea.Stop)
				{
					if (base.XAxis.ScaleType == ScaleType.Log10)
					{
						this.XStop = base.XAxis.PixelsToValue(e);
					}
					else
					{
						this.XStop = this.m_MouseDownStop + (base.XAxis.PixelsToValue(e) - this.m_MouseDownPos);
					}
				}
				else if (this.m_MouseDownHitArea == PlotLimitBandHitArea.Band)
				{
					if (base.XAxis.ScaleType == ScaleType.Log10)
					{
						this.XStart = base.XAxis.PixelsToValue(e);
					}
					else
					{
						this.XStart = this.m_MouseDownStart + (base.XAxis.PixelsToValue(e) - this.m_MouseDownPos);
					}
					if (base.XAxis.ScaleType == ScaleType.Log10)
					{
						this.XStop = base.XAxis.PixelsToValue(e);
					}
					else
					{
						this.XStop = this.m_MouseDownStop + (base.XAxis.PixelsToValue(e) - this.m_MouseDownPos);
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
					this.XStop -= base.XAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Down)
				{
					this.XStop -= base.XAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Right)
				{
					this.XStop += base.XAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Up)
				{
					this.XStop += base.XAxis.Span * 0.001;
				}
				else if (e.KeyCode == Keys.Prior)
				{
					this.XStop += base.XAxis.ScaleDisplay.MajorIncrement;
				}
				else if (e.KeyCode == Keys.Next)
				{
					this.XStop -= base.XAxis.ScaleDisplay.MajorIncrement;
				}
				else if (e.KeyCode == Keys.Home)
				{
					this.XStop = base.XAxis.Min;
				}
				else if (e.KeyCode == Keys.End)
				{
					this.XStop = base.XAxis.Max;
				}
			}
			else if (e.KeyCode == Keys.Left)
			{
				this.XStart -= base.XAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Down)
			{
				this.XStart -= base.XAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Right)
			{
				this.XStart += base.XAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Up)
			{
				this.XStart += base.XAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Prior)
			{
				this.XStart += base.XAxis.ScaleDisplay.MajorIncrement;
			}
			else if (e.KeyCode == Keys.Next)
			{
				this.XStart -= base.XAxis.ScaleDisplay.MajorIncrement;
			}
			else if (e.KeyCode == Keys.Home)
			{
				this.XStart = base.XAxis.Min;
			}
			else if (e.KeyCode == Keys.End)
			{
				this.XStart = base.XAxis.Max;
			}
		}

		protected override void InternalOnMouseWheel(MouseEventArgs e)
		{
			if (Control.ModifierKeys == Keys.Control)
			{
				this.XStop += base.XAxis.ScaleRange.Span * 0.001 * (double)e.Delta / (double)Math.Abs(e.Delta);
			}
			else
			{
				this.XStart += base.XAxis.ScaleRange.Span * 0.001 * (double)e.Delta / (double)Math.Abs(e.Delta);
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
				return Cursors.SizeNS;
			}
			return Cursors.SizeWE;
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			Pen pen = ((IPlotPen)base.Fill.Pen).GetPen(p);
			int dataViewYPixelsMin = base.GetDataViewYPixelsMin();
			int dataViewYPixelsMax = base.GetDataViewYPixelsMax();
			int num = xAxis.ValueToPixels(this.XStart);
			int num2 = dataViewYPixelsMax;
			int num3 = num;
			int num4 = dataViewYPixelsMin;
			int num5 = xAxis.ValueToPixels(this.XStop);
			int num6 = dataViewYPixelsMax;
			int num7 = num5;
			int num8 = dataViewYPixelsMin;
			Rectangle rectangle = iRectangle.FromLTRB(base.XYSwapped, num, num4, num5, num2);
			this.m_HitRectStart = iRectangle.FromLTRB(base.XYSwapped, num - base.HitRegionSize, num2, num + base.HitRegionSize, num4);
			this.m_HitRectStop = iRectangle.FromLTRB(base.XYSwapped, num5 - base.HitRegionSize, num6, num5 + base.HitRegionSize, num8);
			this.m_HitRectInner = rectangle;
			this.m_HitRectInner.Inflate(-base.HitRegionSize, 0);
			if (base.Fill.Brush.Visible)
			{
				Brush brush = ((IPlotBrush)base.Fill.Brush).GetBrush(p, rectangle);
				p.Graphics.FillRectangle(brush, rectangle);
			}
			if (base.Fill.Pen.Visible)
			{
				if (base.XYSwapped)
				{
					p.Graphics.DrawLine(pen, num2, num, num4, num3);
					p.Graphics.DrawLine(pen, num6, num5, num8, num7);
				}
				else
				{
					p.Graphics.DrawLine(pen, num, num2, num3, num4);
					p.Graphics.DrawLine(pen, num5, num6, num7, num8);
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
