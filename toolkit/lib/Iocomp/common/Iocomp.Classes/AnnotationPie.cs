using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Serializable]
	public sealed class AnnotationPie : AnnotationShape
	{
		private double m_StartAngle;

		private double m_SweepAngle;

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double StartAngle
		{
			get
			{
				return this.m_StartAngle;
			}
			set
			{
				base.PropertyUpdateDefault("StartAngle", value);
				if (this.StartAngle != value)
				{
					this.m_StartAngle = value;
					base.DoPropertyChange(this, "StartAngle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public double SweepAngle
		{
			get
			{
				return this.m_SweepAngle;
			}
			set
			{
				base.PropertyUpdateDefault("SweepAngle", value);
				if (this.SweepAngle != value)
				{
					this.m_SweepAngle = value;
					base.DoPropertyChange(this, "SweepAngle");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation Pie";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnnotationPieEditorPlugIn";
		}

		public AnnotationPie()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.StartAngle = 0.0;
			this.SweepAngle = 90.0;
		}

		private bool ShouldSerializeStartAngle()
		{
			return base.PropertyShouldSerialize("StartAngle");
		}

		private void ResetStartAngle()
		{
			base.PropertyReset("StartAngle");
		}

		private bool ShouldSerializeSweepAngle()
		{
			return base.PropertyShouldSerialize("SweepAngle");
		}

		private void ResetSweepAngle()
		{
			base.PropertyReset("SweepAngle");
		}

		protected override void DrawOutline(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.DrawPie(p.Graphics.Pen(base.OutlineColor), rect, (float)this.StartAngle, (float)this.SweepAngle);
		}

		protected override void DrawFillHatch(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.FillPie(p.Graphics.Brush(base.HatchStyle, base.HatchForeColor, base.HatchBackColor), rect, (float)this.StartAngle, (float)this.SweepAngle);
		}

		protected override void DrawFillGradient(PaintArgs p, Rectangle rect, Point[] points)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPie(rect, (float)this.StartAngle, (float)this.SweepAngle);
			p.Graphics.FillGradientPath(rect, graphicsPath, base.GradientStartColor, base.GradientStopColor, base.ModeAngle, 1f, false);
		}

		protected override void DrawFillSolid(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.FillPie(p.Graphics.Brush(base.FillColor), rect, (float)this.StartAngle, (float)this.SweepAngle);
		}

		public override string ToString()
		{
			return "Annotation Pie";
		}
	}
}
