using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Plot Pen.")]
	public class PlotPen : SubClassBase, IPlotPen
	{
		private double m_Thickness;

		private PlotPenStyle m_Style;

		private DashStyle m_StyleGDI;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public new Color Color
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.Color = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("The Thickness property specifies the size or thickness of the trace line.")]
		public double Thickness
		{
			get
			{
				return this.m_Thickness;
			}
			set
			{
				base.PropertyUpdateDefault("Thickness", value);
				if (this.Thickness != value)
				{
					this.m_Thickness = value;
					base.DoPropertyChange(this, "Thickness");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotPenStyle Style
		{
			get
			{
				return this.m_Style;
			}
			set
			{
				base.PropertyUpdateDefault("Style", value);
				if (this.Style != value)
				{
					this.m_Style = value;
					if (this.m_Style == PlotPenStyle.Solid)
					{
						this.m_StyleGDI = DashStyle.Solid;
					}
					else if (this.m_Style == PlotPenStyle.Dash)
					{
						this.m_StyleGDI = DashStyle.Dash;
					}
					else if (this.m_Style == PlotPenStyle.DashDot)
					{
						this.m_StyleGDI = DashStyle.DashDot;
					}
					else if (this.m_Style == PlotPenStyle.DashDotDot)
					{
						this.m_StyleGDI = DashStyle.DashDotDot;
					}
					else if (this.m_Style == PlotPenStyle.Dot)
					{
						this.m_StyleGDI = DashStyle.Dot;
					}
					base.DoPropertyChange(this, "Style");
				}
			}
		}

		[Description("")]
		public DashStyle StyleGDI
		{
			get
			{
				return this.m_StyleGDI;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Plot Pen";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotPenEditorPlugIn";
		}

		Pen IPlotPen.GetPen(PaintArgs p)
		{
			return this.GetPen(p);
		}

		void IPlotPen.DrawLine(PaintArgs p, int x1, int y1, int x2, int y2)
		{
			this.DrawLine(p, x1, y1, x2, y2);
		}

		void IPlotPen.DrawLine(PaintArgs p, Point pt1, Point pt2)
		{
			this.DrawLine(p, pt1, pt2);
		}

		void IPlotPen.DrawArc(PaintArgs p, Rectangle r, double startAngle, double sweepAngle)
		{
			this.DrawArc(p, r, startAngle, sweepAngle);
		}

		public PlotPen()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.ColorAmbientSource = AmbientColorSouce.ForeColor;
			this.Visible = true;
			this.Color = Color.Empty;
			this.Thickness = 1.0;
			this.Style = PlotPenStyle.Solid;
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeThickness()
		{
			return base.PropertyShouldSerialize("Thickness");
		}

		private void ResetThickness()
		{
			base.PropertyReset("Thickness");
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private Pen GetPen(PaintArgs p)
		{
			return p.Graphics.Pen(this.Color, this.StyleGDI, (float)this.Thickness);
		}

		private void DrawLine(PaintArgs p, int x1, int y1, int x2, int y2)
		{
			if (this.Visible)
			{
				p.Graphics.DrawLine(this.GetPen(p), x1, y1, x2, y2);
			}
		}

		private void DrawLine(PaintArgs p, Point pt1, Point pt2)
		{
			if (this.Visible)
			{
				p.Graphics.DrawLine(this.GetPen(p), pt1, pt2);
			}
		}

		private void DrawArc(PaintArgs p, Rectangle r, double startAngle, double sweepAngle)
		{
			if (this.Visible)
			{
				p.Graphics.DrawArc(this.GetPen(p), r, (float)startAngle, (float)sweepAngle);
			}
		}
	}
}
