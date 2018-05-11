using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	public class BevelThick : SubClassBase, IBevelThick
	{
		private int m_Thickness;

		private BevelStyle m_Style;

		[RefreshProperties(RefreshProperties.All)]
		[Description("The Thickness property specifies the size or thickness of the beveled border.")]
		public int Thickness
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public BevelStyle Style
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int ActualThickness
		{
			get
			{
				if (this.Style == BevelStyle.None)
				{
					return 0;
				}
				return this.Thickness;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Bevel";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.BevelThickEditorPlugIn";
		}

		void IBevelThick.Draw(PaintArgs p, Rectangle r, ShapeBasic type, Color color)
		{
			this.Draw(p, r, type, color);
		}

		void IBevelThick.Draw(PaintArgs p, Rectangle r, ShapeBasic type, BevelStyle style, int thickness, Color color)
		{
			this.Draw(p, r, type, style, thickness, color);
		}

		public BevelThick()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Style = BevelStyle.None;
			this.Color = Color.Empty;
			this.Thickness = 4;
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

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		protected void Draw(PaintArgs p, Rectangle r, ShapeBasic type, Color color)
		{
			this.Draw(p, r, type, this.Style, this.Thickness, color);
		}

		protected void Draw(PaintArgs p, Rectangle r, ShapeBasic type, BevelStyle style, int thickness, Color color)
		{
			switch (type)
			{
			case ShapeBasic.Rectangle:
				BorderSpecial.DrawRectangle(p, r, style, thickness, color);
				break;
			case ShapeBasic.Ellipse:
				BorderSpecial.DrawEllipse(p, r, style, (float)thickness, color);
				break;
			case ShapeBasic.Diamond:
				BorderSpecial.DrawDiamond(p, r, style, thickness, color);
				break;
			}
		}
	}
}
