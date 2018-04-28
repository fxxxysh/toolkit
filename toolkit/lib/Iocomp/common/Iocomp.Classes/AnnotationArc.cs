using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public sealed class AnnotationArc : AnnotationOutline
	{
		private double m_StartAngle;

		private double m_SweepAngle;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
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

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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
			return "Annotation Arc";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnnotationArcEditorPlugIn";
		}

		public AnnotationArc()
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
			p.Graphics.DrawArc(p.Graphics.Pen(base.OutlineColor, base.DashStyle), rect, (float)this.StartAngle, (float)this.SweepAngle);
		}

		public override string ToString()
		{
			return "Annotation Arc";
		}
	}
}
