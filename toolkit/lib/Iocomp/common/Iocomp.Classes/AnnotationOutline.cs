using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Serializable]
	public abstract class AnnotationOutline : AnnotationBase
	{
		private Color m_OutlineColor;

		private AnnotationOutlineStyle m_OutlineStyle;

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color OutlineColor
		{
			get
			{
				return this.m_OutlineColor;
			}
			set
			{
				base.PropertyUpdateDefault("OutlineColor", value);
				if (this.OutlineColor != value)
				{
					this.m_OutlineColor = value;
					base.DoPropertyChange(this, "OutlineColor");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public AnnotationOutlineStyle OutlineStyle
		{
			get
			{
				return this.m_OutlineStyle;
			}
			set
			{
				base.PropertyUpdateDefault("OutlineStyle", value);
				if (this.OutlineStyle != value)
				{
					this.m_OutlineStyle = value;
					base.DoPropertyChange(this, "OutlineStyle");
				}
			}
		}

		protected DashStyle DashStyle
		{
			get
			{
				if (this.OutlineStyle == AnnotationOutlineStyle.Solid)
				{
					return DashStyle.Solid;
				}
				if (this.OutlineStyle == AnnotationOutlineStyle.Dash)
				{
					return DashStyle.Dash;
				}
				if (this.OutlineStyle == AnnotationOutlineStyle.DashDot)
				{
					return DashStyle.DashDot;
				}
				if (this.OutlineStyle == AnnotationOutlineStyle.DashDotDot)
				{
					return DashStyle.DashDotDot;
				}
				if (this.OutlineStyle == AnnotationOutlineStyle.Dot)
				{
					return DashStyle.Dot;
				}
				return DashStyle.Solid;
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.OutlineColor = Color.Black;
			this.OutlineStyle = AnnotationOutlineStyle.Solid;
		}

		private bool ShouldSerializeOutlineColor()
		{
			return base.PropertyShouldSerialize("OutlineColor");
		}

		private void ResetOutlineColor()
		{
			base.PropertyReset("OutlineColor");
		}

		private bool ShouldSerializeOutlineStyle()
		{
			return base.PropertyShouldSerialize("OutlineStyle");
		}

		private void ResetOutlineStyle()
		{
			base.PropertyReset("OutlineStyle");
		}

		protected abstract void DrawOutline(PaintArgs p, Rectangle r, Point[] points);

		protected override void DrawCustom(PaintArgs p)
		{
			Rectangle r = new Rectangle(this.Scale.ConvertUnitsToPixelsX(base.Left), this.Scale.ConvertUnitsToPixelsY(base.Top), this.Scale.ConvertWidthUnitsToPixels(this.Width), this.Scale.ConvertHeightUnitsToPixels(this.Height));
			base.ClickRegion = this.ToClickRegion(r);
			base.UpdateGrabHandles(r);
			if (r.Height != 0 && r.Width != 0 && this.OutlineStyle != AnnotationOutlineStyle.Clear)
			{
				this.DrawOutline(p, r, null);
			}
		}
	}
}
