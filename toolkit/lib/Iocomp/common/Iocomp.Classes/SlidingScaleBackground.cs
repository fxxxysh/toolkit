using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Controls the sliding scale background properties.")]
	public sealed class SlidingScaleBackground : SubClassBase, ISlidingScaleBackground
	{
		private SlidingScaleBackgroundStyle m_Style;

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public SlidingScaleBackgroundStyle Style
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
					base.DoPropertyChange(this, "Style");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		protected override string GetPlugInTitle()
		{
			return "Sliding Scale Background";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.SlidingScaleBackgroundEditorPlugIn";
		}

		void ISlidingScaleBackground.Draw(PaintArgs p, Rectangle r)
		{
			this.Draw(p, r);
		}

		public SlidingScaleBackground()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private void Draw(PaintArgs p, Rectangle r)
		{
			if (this.Style != SlidingScaleBackgroundStyle.Clear)
			{
				if (this.Style == SlidingScaleBackgroundStyle.Gradient)
				{
					p.Graphics.SetClip(r);
					r.Inflate(0, (int)((double)p.Height * 0.2));
					p.Graphics.DrawGradientRect(iColors.Lighten4(this.Color), Color.Black, r, true, true, true);
				}
				else
				{
					p.Graphics.FillRectangle(p.Graphics.Brush(this.Color), p.DrawRectangle);
				}
			}
		}
	}
}
