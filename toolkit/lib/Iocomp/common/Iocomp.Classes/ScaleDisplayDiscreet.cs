using Iocomp.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Controls the scale display layout properties.")]
	public abstract class ScaleDisplayDiscreet : SubClassBase, IScaleDisplayDiscreet
	{
		private Font m_TextActiveFont;

		private Font m_TextInactiveFont;

		private Color m_TextActiveForeColor;

		private Color m_TextInactiveForeColor;

		private int m_TextMargin;

		private ScaleDiscreetMarker m_Markers;

		private int m_Margin;

		[Description("Markers properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ScaleDiscreetMarker Markers
		{
			get
			{
				return this.m_Markers;
			}
		}

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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int Margin
		{
			get
			{
				return this.m_Margin;
			}
			set
			{
				base.PropertyUpdateDefault("Margin", value);
				if (this.Margin != value)
				{
					this.m_Margin = value;
					base.DoPropertyChange(this, "Margin");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int TextMargin
		{
			get
			{
				return this.m_TextMargin;
			}
			set
			{
				base.PropertyUpdateDefault("TextMargin", value);
				if (this.TextMargin != value)
				{
					this.m_TextMargin = value;
					base.DoPropertyChange(this, "TextMargin");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Font TextActiveFont
		{
			get
			{
				if (base.GettingDefault)
				{
					return this.m_TextActiveFont;
				}
				if (this.m_TextActiveFont == null && this.ControlBase != null)
				{
					return this.ControlBase.Font;
				}
				return this.m_TextActiveFont;
			}
			set
			{
				base.PropertyUpdateDefault("TextActiveFont", value);
				if (!GPFunctions.Equals(this.TextActiveFont, value))
				{
					this.m_TextActiveFont = value;
					base.DoPropertyChange(this, "TextActiveFont");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public Font TextInactiveFont
		{
			get
			{
				if (base.GettingDefault)
				{
					return this.m_TextInactiveFont;
				}
				if (this.m_TextInactiveFont == null && this.ControlBase != null)
				{
					return this.ControlBase.Font;
				}
				return this.m_TextInactiveFont;
			}
			set
			{
				base.PropertyUpdateDefault("TextInactiveFont", value);
				if (!GPFunctions.Equals(this.TextInactiveFont, value))
				{
					this.m_TextInactiveFont = value;
					base.DoPropertyChange(this, "TextInactiveFont");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color TextActiveForeColor
		{
			get
			{
				if (base.GettingDefault)
				{
					return this.m_TextActiveForeColor;
				}
				if (this.m_TextActiveForeColor == Color.Empty && this.ControlBase != null)
				{
					return this.ControlBase.ForeColor;
				}
				return this.m_TextActiveForeColor;
			}
			set
			{
				base.PropertyUpdateDefault("TextActiveForeColor", value);
				if (this.TextActiveForeColor != value)
				{
					this.m_TextActiveForeColor = value;
					base.DoPropertyChange(this, "TextActiveForeColor");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color TextInactiveForeColor
		{
			get
			{
				if (base.GettingDefault)
				{
					return this.m_TextInactiveForeColor;
				}
				if (this.m_TextInactiveForeColor == Color.Empty && this.ControlBase != null)
				{
					return this.ControlBase.ForeColor;
				}
				return this.m_TextInactiveForeColor;
			}
			set
			{
				base.PropertyUpdateDefault("TextInactiveForeColor", value);
				if (this.TextInactiveForeColor != value)
				{
					this.m_TextInactiveForeColor = value;
					base.DoPropertyChange(this, "TextInactiveForeColor");
				}
			}
		}

		void IScaleDisplayDiscreet.Calculate(PaintArgs p, ScaleDiscreetItemCollection items, Point centerPoint, int activeIndex, int pointerExtent)
		{
			this.Calculate(p, items, centerPoint, activeIndex, pointerExtent);
		}

		void IScaleDisplayDiscreet.Draw(PaintArgs p, ScaleDiscreetItemCollection items, Point centerPoint, int activeIndex, Color backColor)
		{
			this.Draw(p, items, centerPoint, activeIndex, backColor);
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Markers = new ScaleDiscreetMarker();
			base.AddSubClass(this.Markers);
		}

		private bool ShouldSerializeMarkers()
		{
			return ((ISubClassBase)this.Markers).ShouldSerialize();
		}

		private void ResetMarkers()
		{
			((ISubClassBase)this.Markers).ResetToDefault();
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeMargin()
		{
			return base.PropertyShouldSerialize("Margin");
		}

		private void ResetMargin()
		{
			base.PropertyReset("Margin");
		}

		private bool ShouldSerializeTextMargin()
		{
			return base.PropertyShouldSerialize("TextMargin");
		}

		private void ResetTextMargin()
		{
			base.PropertyReset("TextMargin");
		}

		private bool ShouldSerializeTextActiveFont()
		{
			return base.PropertyShouldSerialize("TextActiveFont");
		}

		private void ResetTextActiveFont()
		{
			base.PropertyReset("TextActiveFont");
		}

		private bool ShouldSerializeTextInactiveFont()
		{
			return base.PropertyShouldSerialize("TextInactiveFont");
		}

		private void ResetTextInactiveFont()
		{
			base.PropertyReset("TextInactiveFont");
		}

		private bool ShouldSerializeTextActiveForeColor()
		{
			return base.PropertyShouldSerialize("TextActiveForeColor");
		}

		private void ResetTextActiveForeColor()
		{
			base.PropertyReset("TextActiveForeColor");
		}

		private bool ShouldSerializeTextInactiveForeColor()
		{
			return base.PropertyShouldSerialize("TextInactiveForeColor");
		}

		private void ResetTextInactiveForeColor()
		{
			base.PropertyReset("TextInactiveForeColor");
		}

		protected abstract void Calculate(PaintArgs p, ScaleDiscreetItemCollection items, Point centerPoint, int activeIndex, int pointerExtent);

		protected abstract void Draw(PaintArgs p, ScaleDiscreetItemCollection items, Point centerPoint, int activeIndex, Color backColor);
	}
}
