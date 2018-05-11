using Iocomp.Interfaces;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Plot Fill.")]
	public class PlotFill : SubClassBase, IPlotFill
	{
		private PlotBrush m_Brush;

		protected IPlotBrush I_Brush;

		private PlotPen m_Pen;

		protected IPlotPen I_Pen;

		public bool Visible
		{
			get
			{
				return this.VisibleInternal;
			}
			set
			{
				this.VisibleInternal = value;
			}
		}

		[Browsable(false)]
		public bool NotDrawVisible
		{
			get
			{
				if (!this.Visible)
				{
					return true;
				}
				if (!this.Brush.Visible && !this.Pen.Visible)
				{
					return true;
				}
				return false;
			}
		}

		[Browsable(false)]
		public bool DrawVisible
		{
			get
			{
				return !this.NotDrawVisible;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotBrush Brush
		{
			get
			{
				return this.m_Brush;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotPen Pen
		{
			get
			{
				return this.m_Pen;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Plot Fill";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotFillEditorPlugIn";
		}

		void IPlotFill.DrawEllipse(PaintArgs p, Rectangle r)
		{
			this.DrawEllipse(p, r);
		}

		void IPlotFill.DrawPie(PaintArgs p, Rectangle r, double startAngle, double sweepAngle)
		{
			this.DrawPie(p, r, startAngle, sweepAngle);
		}

		void IPlotFill.Draw(PaintArgs p, Rectangle r)
		{
			this.Draw(p, r);
		}

		void IPlotFill.Draw(PaintArgs p, Point[] points)
		{
			this.Draw(p, points);
		}

		void IPlotFill.Draw(PaintArgs p, Point[] points, Rectangle boundsRect)
		{
			this.Draw(p, points, boundsRect);
		}

		void IPlotFill.DrawBiFill(PaintArgs p, Point[] points, Rectangle boundsRect)
		{
			this.DrawBiFill(p, points, boundsRect);
		}

		public PlotFill()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Brush = new PlotBrush();
			base.AddSubClass(this.Brush);
			this.I_Brush = this.Brush;
			this.m_Pen = new PlotPen();
			base.AddSubClass(this.Pen);
			this.I_Pen = this.Pen;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Visible = true;
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeBrush()
		{
			return ((ISubClassBase)this.Brush).ShouldSerialize();
		}

		private void ResetBrush()
		{
			((ISubClassBase)this.Brush).ResetToDefault();
		}

		private bool ShouldSerializePen()
		{
			return ((ISubClassBase)this.Pen).ShouldSerialize();
		}

		private void ResetPen()
		{
			((ISubClassBase)this.Pen).ResetToDefault();
		}

		private void DrawEllipse(PaintArgs p, Rectangle r)
		{
			if (this.Visible)
			{
				GraphicsState gstate = p.Graphics.Save();
				p.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				if (this.Brush.Visible)
				{
					p.Graphics.FillEllipse(this.I_Brush.GetBrush(p, r), r);
				}
				if (this.Pen.Visible)
				{
					p.Graphics.DrawEllipse(this.I_Pen.GetPen(p), r);
				}
				p.Graphics.Restore(gstate);
			}
		}

		private void DrawPie(PaintArgs p, Rectangle r, double startAngle, double sweepAngle)
		{
			if (this.Visible)
			{
				GraphicsState gstate = p.Graphics.Save();
				p.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				if (this.Brush.Visible)
				{
					p.Graphics.FillPie(this.I_Brush.GetBrush(p, r), r, (float)startAngle, (float)sweepAngle);
				}
				if (this.Pen.Visible)
				{
					p.Graphics.DrawPie(this.I_Pen.GetPen(p), r, (float)startAngle, (float)sweepAngle);
				}
				p.Graphics.Restore(gstate);
			}
		}

		protected virtual void Draw(PaintArgs p, Rectangle r)
		{
			if (this.Visible && r.Height > 0 && r.Width > 0)
			{
				GraphicsState gstate = p.Graphics.Save();
				p.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				if (this.Brush.Visible)
				{
					p.Graphics.FillRectangle(this.I_Brush.GetBrush(p, r), r);
				}
				if (this.Pen.Visible)
				{
					p.Graphics.DrawRectangle(this.I_Pen.GetPen(p), r);
				}
				p.Graphics.Restore(gstate);
			}
		}

		private void Draw(PaintArgs p, Point[] points)
		{
			if (this.Visible)
			{
				GraphicsState gstate = p.Graphics.Save();
				p.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				if (this.Brush.Visible)
				{
					p.Graphics.FillPolygon(this.I_Brush.GetBrush(p, points), points);
				}
				if (this.Pen.Visible)
				{
					p.Graphics.DrawPolygon(this.I_Pen.GetPen(p), points);
				}
				p.Graphics.Restore(gstate);
			}
		}

		private void Draw(PaintArgs p, Point[] points, Rectangle boundRect)
		{
			if (this.Visible && boundRect.Height > 0 && boundRect.Width > 0)
			{
				GraphicsState gstate = p.Graphics.Save();
				p.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				if (this.Brush.Visible)
				{
					p.Graphics.FillPolygon(this.I_Brush.GetBrush(p, boundRect), points);
				}
				if (this.Pen.Visible)
				{
					p.Graphics.DrawPolygon(this.I_Pen.GetPen(p), points);
				}
				p.Graphics.Restore(gstate);
			}
		}

		private void DrawBiFill(PaintArgs p, Point[] points, Rectangle boundRect)
		{
			if (this.Visible && boundRect.Height > 0 && boundRect.Width > 0)
			{
				GraphicsState gstate = p.Graphics.Save();
				p.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				if (this.Brush.Visible)
				{
					p.Graphics.FillPolygon(this.I_Brush.GetBrush(p, boundRect), points);
				}
				if (this.Pen.Visible)
				{
					p.Graphics.DrawLines(this.I_Pen.GetPen(p), points);
				}
				p.Graphics.Restore(gstate);
			}
		}
	}
}
