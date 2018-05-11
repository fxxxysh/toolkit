using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Serializable]
	public sealed class AnnotationRectangle : AnnotationShape
	{
		protected override string GetPlugInTitle()
		{
			return "Annotation Rectangle";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnnotationRectangleEditorPlugIn";
		}

		public AnnotationRectangle()
		{
			base.DoCreate();
		}

		protected override void DrawOutline(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.DrawRectangle(p.Graphics.Pen(base.OutlineColor, base.DashStyle, 1f), rect);
		}

		protected override void DrawFillHatch(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.FillRectangle(p.Graphics.Brush(base.HatchStyle, base.HatchForeColor, base.HatchBackColor), rect);
		}

		protected override void DrawFillGradient(PaintArgs p, Rectangle rect, Point[] points)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(rect);
			p.Graphics.FillGradientPath(rect, graphicsPath, base.GradientStartColor, base.GradientStopColor, base.ModeAngle, 1f, false);
		}

		protected override void DrawFillSolid(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.FillRectangle(p.Graphics.Brush(base.FillColor), rect);
		}

		public override string ToString()
		{
			return "Annotation Rectangle";
		}
	}
}
