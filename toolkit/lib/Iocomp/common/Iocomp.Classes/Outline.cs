using Iocomp.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Controls the outline properties.")]
	public class Outline : SubClassBase, IOutline
	{
		private int m_Thickness;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int Thickness
		{
			get
			{
				return this.m_Thickness;
			}
			set
			{
				base.PropertyUpdateDefault("Thickness", value);
				if (value < 0)
				{
					base.ThrowStreamingSafeException("Thickness value must be 0 or greater.");
				}
				if (value < 0)
				{
					value = 0;
				}
				if (this.Thickness != value)
				{
					int thickness = this.m_Thickness;
					this.m_Thickness = value;
					base.DoAutoSizeSpecialOffset(this.m_Thickness - thickness);
					base.DoPropertyChange(this, "Thickness");
				}
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

		protected override string GetPlugInTitle()
		{
			return "Outline";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.OutlineEditorPlugIn";
		}

		void IOutline.Draw(PaintArgs p, Rectangle r)
		{
			this.Draw(p, r);
		}

		public Outline()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeThickness()
		{
			return base.PropertyShouldSerialize("Thickness");
		}

		private void ResetThickness()
		{
			base.PropertyReset("Thickness");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		protected void Draw(PaintArgs p, Rectangle r)
		{
			r.Inflate(this.Thickness, this.Thickness);
			p.Graphics.FillRectangle(p.Graphics.Brush(this.Color), r);
		}
	}
}
