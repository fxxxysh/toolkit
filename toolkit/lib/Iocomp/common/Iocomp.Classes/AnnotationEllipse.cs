using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Serializable]
	public sealed class AnnotationEllipse : AnnotationShape
	{
		protected override string GetPlugInTitle()
		{
			return "Annotation Ellipse";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnnotationEllipseEditorPlugIn";
		}

		public AnnotationEllipse()
		{
			base.DoCreate();
		}

		protected override void DrawFillSolid(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.FillEllipse(p.Graphics.Brush(base.FillColor), rect);
		}

		protected override void DrawFillGradient(PaintArgs p, Rectangle rect, Point[] points)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddEllipse(rect);
			p.Graphics.FillGradientPath(rect, graphicsPath, base.GradientStartColor, base.GradientStopColor, base.ModeAngle, 1f, false);
		}

		protected override void DrawFillHatch(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.FillEllipse(p.Graphics.Brush(base.HatchStyle, base.HatchForeColor, base.HatchBackColor), rect);
		}

		protected override void DrawOutline(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.DrawEllipse(p.Graphics.Pen(base.OutlineColor, base.DashStyle), rect);
		}

		protected override Region ToClickRegion(Rectangle rect)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			try
			{
				graphicsPath.AddEllipse(rect);
				return new Region(graphicsPath);
			}
			finally
			{
				graphicsPath.Dispose();
			}
		}

		public override string ToString()
		{
			return "Annotation Ellipse";
		}
	}
}
