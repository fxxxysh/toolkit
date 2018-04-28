using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Limit Line Y.")]
	public class PlotLimitLineY : PlotLimitLineBase
	{
		private double m_YReference;

		private double m_MouseDownPos;

		private double m_MouseDownReference;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double YReference
		{
			get
			{
				return this.m_YReference;
			}
			set
			{
				base.PropertyUpdateDefault("YReference", value);
				if (this.YReference != value)
				{
					this.m_YReference = value;
					base.DoPropertyChange(this, "YReference");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Limit Line-Y";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLimitLineYEditorPlugIn";
		}

		public PlotLimitLineY()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "LineY";
			this.YReference = 50.0;
		}

		private bool ShouldSerializeYReference()
		{
			return base.PropertyShouldSerialize("YReference");
		}

		private void ResetYReference()
		{
			base.PropertyReset("YReference");
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (shouldFocus)
			{
				base.Focus();
			}
			if (base.UserCanMove)
			{
				base.IsMouseActive = true;
				int value = (!base.XYSwapped) ? e.Y : e.X;
				this.m_MouseDownReference = this.YReference;
				this.m_MouseDownPos = base.YAxis.PixelsToValue(value);
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			if (base.IsMouseActive)
			{
				if (base.YAxis.ScaleType == ScaleType.Log10)
				{
					this.YReference = base.YAxis.PixelsToValue(e);
				}
				else
				{
					this.YReference = this.m_MouseDownReference + (base.YAxis.PixelsToValue(e) - this.m_MouseDownPos);
				}
			}
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			base.IsMouseActive = false;
		}

		protected override void InternalOnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left)
			{
				this.YReference -= base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Down)
			{
				this.YReference -= base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Right)
			{
				this.YReference += base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Up)
			{
				this.YReference += base.YAxis.Span * 0.001;
			}
			else if (e.KeyCode == Keys.Prior)
			{
				this.YReference += base.YAxis.ScaleDisplay.MajorIncrement;
			}
			else if (e.KeyCode == Keys.Next)
			{
				this.YReference -= base.YAxis.ScaleDisplay.MajorIncrement;
			}
			else if (e.KeyCode == Keys.Home)
			{
				this.YReference = base.YAxis.Min;
			}
			else if (e.KeyCode == Keys.End)
			{
				this.YReference = base.YAxis.Max;
			}
		}

		protected override void InternalOnMouseWheel(MouseEventArgs e)
		{
			this.YReference += base.YAxis.ScaleRange.Span * 0.001 * (double)e.Delta / (double)Math.Abs(e.Delta);
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			if (!base.UserCanMove)
			{
				return Cursors.Default;
			}
			return Cursors.Hand;
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			Pen pen = ((IPlotPen)base.Line).GetPen(p);
			int num = yAxis.ValueToPixels(this.YReference);
			int dataViewXPixelsMin = base.GetDataViewXPixelsMin();
			int dataViewXPixelsMax = base.GetDataViewXPixelsMax();
			if (base.XYSwapped)
			{
				p.Graphics.DrawLine(pen, num, dataViewXPixelsMin, num, dataViewXPixelsMax);
			}
			else
			{
				p.Graphics.DrawLine(pen, dataViewXPixelsMin, num, dataViewXPixelsMax, num);
			}
			base.Bounds = iRectangle.FromLTRB(base.XYSwapped, dataViewXPixelsMin, num - base.HitRegionSize, dataViewXPixelsMax, num + base.HitRegionSize);
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
