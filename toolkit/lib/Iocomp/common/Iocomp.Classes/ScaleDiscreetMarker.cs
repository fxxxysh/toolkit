using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Contains the properties that control the text's shadow.")]
	public sealed class ScaleDiscreetMarker : SubClassBase, IScaleDiscreetMarker
	{
		private int m_Size;

		private MarkerStyleLabel m_Style;

		private BevelStyle m_BevelStyle;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public MarkerStyleLabel Style
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public BevelStyle BevelStyle
		{
			get
			{
				return this.m_BevelStyle;
			}
			set
			{
				base.PropertyUpdateDefault("BevelStyle", value);
				if (this.BevelStyle != value)
				{
					this.m_BevelStyle = value;
					base.DoPropertyChange(this, "BevelStyle");
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int Size
		{
			get
			{
				return this.m_Size;
			}
			set
			{
				base.PropertyUpdateDefault("Size", value);
				if (this.Size != value)
				{
					this.m_Size = value;
					base.DoPropertyChange(this, "Size");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Scale Marker";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleDiscreetMarkerEditorPlugIn";
		}

		void IScaleDiscreetMarker.Draw(PaintArgs p, Point centerPoint, Color backColor)
		{
			this.Draw(p, centerPoint, backColor);
		}

		public ScaleDiscreetMarker()
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

		private bool ShouldSerializeBevelStyle()
		{
			return base.PropertyShouldSerialize("BevelStyle");
		}

		private void ResetBevelStyle()
		{
			base.PropertyReset("BevelStyle");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeSize()
		{
			return base.PropertyShouldSerialize("Size");
		}

		private void ResetSize()
		{
			base.PropertyReset("Size");
		}

		private void Draw(PaintArgs p, Point centerPoint, Color backColor)
		{
			if (this.Style != MarkerStyleLabel.None)
			{
				Rectangle rectangle;
				if (this.Style == MarkerStyleLabel.Circle)
				{
					p.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
					rectangle = new Rectangle(centerPoint.X - this.Size, centerPoint.Y - this.Size, 2 * this.Size, 2 * this.Size);
					BorderSpecial.DrawEllipse(p, rectangle, this.BevelStyle, 1f, backColor);
					rectangle.Inflate(-2, -2);
					p.Graphics.FillEllipse(p.Graphics.Brush(this.Color), rectangle);
					rectangle.Inflate(2, 2);
					p.Graphics.SmoothingMode = SmoothingMode.Default;
				}
				else if (this.Style == MarkerStyleLabel.Square)
				{
					rectangle = new Rectangle(centerPoint.X - this.Size, centerPoint.Y - this.Size, 2 * this.Size, 2 * this.Size);
					p.Graphics.FillRectangle(p.Graphics.Brush(this.Color), rectangle);
					BorderSpecial.DrawRectangle(p, rectangle, this.BevelStyle, 2, backColor);
				}
				else if (this.Style == MarkerStyleLabel.Line)
				{
					rectangle = new Rectangle(centerPoint.X - this.Size, centerPoint.Y - 1, 2 * this.Size, 2);
					if (this.BevelStyle == BevelStyle.Raised)
					{
						BorderSimple.Draw(p, rectangle, BorderStyleSimple.RaisedInner, backColor);
					}
					else if (this.BevelStyle == BevelStyle.Sunken)
					{
						BorderSimple.Draw(p, rectangle, BorderStyleSimple.SunkenInner, backColor);
					}
				}
			}
		}
	}
}
