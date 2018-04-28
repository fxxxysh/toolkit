using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Controls the border layout properties.")]
	public class BorderControl : SubClassBase, IBorderControl
	{
		private BorderStyleControl m_Style;

		private int m_Margin;

		private int m_MarginLeft;

		private int m_MarginRight;

		private int m_MarginTop;

		private int m_MarginBottom;

		private int m_ThicknessDesired;

		private Color m_Color;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int Offset
		{
			get
			{
				return this.Margin + this.ThicknessActual;
			}
		}

		[Description("Represents the actual thickness of the border.\n\nNote: If the style is None, 0 is returned. If the style is Raised or Sunken, ThicknessDesired is returned          All remaining styles will return 2.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int ThicknessActual
		{
			get
			{
				if (this.m_Style == BorderStyleControl.None)
				{
					return 0;
				}
				if (this.m_Style == BorderStyleControl.Raised)
				{
					return this.m_ThicknessDesired;
				}
				if (this.m_Style == BorderStyleControl.Sunken)
				{
					return this.m_ThicknessDesired;
				}
				if (this.m_Style == BorderStyleControl.RoundedSides)
				{
					return this.m_ThicknessDesired;
				}
				return 2;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the border style.")]
		public BorderStyleControl Style
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
					int thicknessActual = this.ThicknessActual;
					this.m_Style = value;
					base.DoAutoSizeSpecialOffset(this.ThicknessActual - thicknessActual);
					base.DoPropertyChange(this, "Style");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the border's desired thickness.")]
		public int ThicknessDesired
		{
			get
			{
				return this.m_ThicknessDesired;
			}
			set
			{
				base.PropertyUpdateDefault("ThicknessDesired", value);
				if (value < 2)
				{
					base.ThrowStreamingSafeException("ThicknessDesired value must be 2 or greater.");
				}
				if (value < 2)
				{
					value = 2;
				}
				if (this.ThicknessDesired != value)
				{
					int thicknessActual = this.ThicknessActual;
					this.m_ThicknessDesired = value;
					base.DoAutoSizeSpecialOffset(this.ThicknessActual - thicknessActual);
					base.DoPropertyChange(this, "ThicknessDesired");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the size of the border margin in pixels around the control.")]
		public int Margin
		{
			get
			{
				return this.m_Margin;
			}
			set
			{
				base.PropertyUpdateDefault("Margin", value);
				if (value < 0)
				{
					base.ThrowStreamingSafeException("Margin value must be 0 or greater.");
				}
				if (value < 0)
				{
					value = 0;
				}
				if (this.Margin != value)
				{
					int margin = this.m_Margin;
					this.m_Margin = value;
					base.DoAutoSizeSpecialOffset(this.m_Margin - margin);
					base.DoPropertyChange(this, "Margin");
				}
			}
		}

		[Description("Specifies the size of the margin-left in pixels.")]
		[RefreshProperties(RefreshProperties.All)]
		public int MarginLeft
		{
			get
			{
				return this.m_MarginLeft;
			}
			set
			{
				base.PropertyUpdateDefault("MarginLeft", value);
				if (this.MarginLeft != value)
				{
					this.m_MarginLeft = value;
					base.DoPropertyChange(this, "MarginLeft");
				}
			}
		}

		[Description("Specifies the size of the margin-right in pixels.")]
		[RefreshProperties(RefreshProperties.All)]
		public int MarginRight
		{
			get
			{
				return this.m_MarginRight;
			}
			set
			{
				base.PropertyUpdateDefault("MarginRight", value);
				if (this.MarginRight != value)
				{
					this.m_MarginRight = value;
					base.DoPropertyChange(this, "MarginRight");
				}
			}
		}

		[Description("Specifies the size of the margin-top in pixels.")]
		[RefreshProperties(RefreshProperties.All)]
		public int MarginTop
		{
			get
			{
				return this.m_MarginTop;
			}
			set
			{
				base.PropertyUpdateDefault("MarginTop", value);
				if (this.MarginTop != value)
				{
					this.m_MarginTop = value;
					base.DoPropertyChange(this, "MarginTop");
				}
			}
		}

		[Description("Specifies the size of the margin-bottom in pixels.")]
		[RefreshProperties(RefreshProperties.All)]
		public int MarginBottom
		{
			get
			{
				return this.m_MarginBottom;
			}
			set
			{
				base.PropertyUpdateDefault("MarginBottom", value);
				if (this.MarginBottom != value)
				{
					this.m_MarginBottom = value;
					base.DoPropertyChange(this, "MarginBottom");
				}
			}
		}

		[Description("Specifies the color of the border.")]
		[RefreshProperties(RefreshProperties.All)]
		public new Color Color
		{
			get
			{
				if (base.GettingDefault)
				{
					return this.m_Color;
				}
				if (this.m_Color == Color.Empty && this.ControlBase != null && this.ControlBase._Parent != null)
				{
					return this.ControlBase._Parent.BackColor;
				}
				return this.m_Color;
			}
			set
			{
				base.PropertyUpdateDefault("Color", value);
				if (this.Color != value)
				{
					this.m_Color = value;
					base.DoPropertyChange(this, "Color");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Border";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.BorderControlEditorPlugIn";
		}

		void IBorderControl.Draw(PaintArgs p, Rectangle r)
		{
			this.Draw(p, r);
		}

		void IBorderControl.Draw(PaintArgs p, Rectangle r, BorderStyleControl style, int thicknessDesired, Color color)
		{
			this.Draw(p, r, style, thicknessDesired, color);
		}

		public BorderControl()
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

		private bool ShouldSerializeThicknessDesired()
		{
			return base.PropertyShouldSerialize("ThicknessDesired");
		}

		private void ResetThicknessDesired()
		{
			base.PropertyReset("ThicknessDesired");
		}

		private bool ShouldSerializeMargin()
		{
			return base.PropertyShouldSerialize("Margin");
		}

		private void ResetMargin()
		{
			base.PropertyReset("Margin");
		}

		private bool ShouldSerializeMarginLeft()
		{
			return base.PropertyShouldSerialize("MarginLeft");
		}

		private void ResetMarginLeft()
		{
			base.PropertyReset("MarginLeft");
		}

		private bool ShouldSerializeMarginRight()
		{
			return base.PropertyShouldSerialize("MarginRight");
		}

		private void ResetMarginRight()
		{
			base.PropertyReset("MarginRight");
		}

		private bool ShouldSerializeMarginTop()
		{
			return base.PropertyShouldSerialize("MarginTop");
		}

		private void ResetMarginTop()
		{
			base.PropertyReset("MarginTop");
		}

		private bool ShouldSerializeMarginBottom()
		{
			return base.PropertyShouldSerialize("MarginBottom");
		}

		private void ResetMarginBottom()
		{
			base.PropertyReset("MarginBottom");
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
			this.Draw(p, r, this.Style, this.ThicknessDesired, this.Color);
		}

		protected void Draw(PaintArgs p, Rectangle r, BorderStyleControl style, int thickness, Color color)
		{
			switch (style)
			{
			case BorderStyleControl.None:
				return;
			case BorderStyleControl.RoundedSides:
				BorderSpecial.DrawRoundedSides(p, r, BevelStyle.Raised, thickness, color);
				return;
			case BorderStyleControl.Raised:
				if (thickness <= 2)
				{
					break;
				}
				BorderSpecial.DrawRectangle(p, r, BevelStyle.Raised, thickness, color);
				return;
			}
			if (style == BorderStyleControl.Sunken && thickness > 2)
			{
				BorderSpecial.DrawRectangle(p, r, BevelStyle.Sunken, thickness, color);
			}
			else
			{
				switch (style)
				{
				case BorderStyleControl.Raised:
					BorderSimple.Draw(p, r, BorderStyleSimple.Raised, color);
					break;
				case BorderStyleControl.Sunken:
					BorderSimple.Draw(p, r, BorderStyleSimple.Sunken, color);
					break;
				case BorderStyleControl.Bump:
					BorderSimple.Draw(p, r, BorderStyleSimple.Bump, color);
					break;
				case BorderStyleControl.Etched:
					BorderSimple.Draw(p, r, BorderStyleSimple.Etched, color);
					break;
				case BorderStyleControl.Flat:
					BorderSimple.Draw(p, r, BorderStyleSimple.Flat, color);
					break;
				case BorderStyleControl.RaisedInner:
					BorderSimple.Draw(p, r, BorderStyleSimple.RaisedInner, color);
					break;
				case BorderStyleControl.RaisedOuter:
					BorderSimple.Draw(p, r, BorderStyleSimple.RaisedOuter, color);
					break;
				case BorderStyleControl.SunkenInner:
					BorderSimple.Draw(p, r, BorderStyleSimple.SunkenInner, color);
					break;
				case BorderStyleControl.SunkenOuter:
					BorderSimple.Draw(p, r, BorderStyleSimple.SunkenOuter, color);
					break;
				}
			}
		}
	}
}
