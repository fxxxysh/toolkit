using Iocomp.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Contains the horizontal and vertical layout properties for text.")]
	public class TextLayoutFull : TextLayoutBase, ITextLayoutBase, ITextLayoutFull
	{
		private StringTrimming m_Trimming;

		private bool m_LineLimit;

		private bool m_MeasureTrailingSpaces;

		private bool m_NoWrap;

		private bool m_NoClip;

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public StringTrimming Trimming
		{
			get
			{
				return this.m_Trimming;
			}
			set
			{
				base.PropertyUpdateDefault("Trimming", value);
				if (this.Trimming != value)
				{
					this.m_Trimming = value;
					base.DoPropertyChange(this, "Trimming");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public bool LineLimit
		{
			get
			{
				return this.m_LineLimit;
			}
			set
			{
				base.PropertyUpdateDefault("LineLimit", value);
				if (this.LineLimit != value)
				{
					this.m_LineLimit = value;
					base.DoPropertyChange(this, "LineLimit");
				}
			}
		}

		[Description("Specifies the line boundary measurement spaceIf true, the boundary will include the space at the end of each lineIf false, the boundary will exclude the space at the end of each line.")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public bool MeasureTrailingSpaces
		{
			get
			{
				return this.m_MeasureTrailingSpaces;
			}
			set
			{
				base.PropertyUpdateDefault("MeasureTrailingSpaces", value);
				if (this.MeasureTrailingSpaces != value)
				{
					this.m_MeasureTrailingSpaces = value;
					base.DoPropertyChange(this, "MeasureTrailingSpaces");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("Disables wrapping of text.")]
		public bool NoWrap
		{
			get
			{
				return this.m_NoWrap;
			}
			set
			{
				base.PropertyUpdateDefault("NoWrap", value);
				if (this.NoWrap != value)
				{
					this.m_NoWrap = value;
					base.DoPropertyChange(this, "NoWrap");
				}
			}
		}

		[Description("Specifies the text clipping behavior.If true, the overhanging unwrapped text reaching outside the formatting rectangle are allowed to show.If false, the overhanging text will be clipped.")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public bool NoClip
		{
			get
			{
				return this.m_NoClip;
			}
			set
			{
				base.PropertyUpdateDefault("NoClip", value);
				if (this.NoClip != value)
				{
					this.m_NoClip = value;
					base.DoPropertyChange(this, "NoClip");
				}
			}
		}

		protected override DrawStringFormat StringFormat
		{
			get
			{
				DrawStringFormat stringFormat = base.StringFormat;
				StringFormatFlags stringFormatFlags = (StringFormatFlags)0;
				if (this.LineLimit)
				{
					stringFormatFlags |= StringFormatFlags.LineLimit;
				}
				if (this.MeasureTrailingSpaces)
				{
					stringFormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
				}
				if (this.NoWrap)
				{
					stringFormatFlags |= StringFormatFlags.NoWrap;
				}
				if (this.NoClip)
				{
					stringFormatFlags |= StringFormatFlags.NoClip;
				}
				stringFormat.Trimming = this.Trimming;
				stringFormat.FormatFlags = stringFormatFlags;
				return stringFormat;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Text Layout";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.TextLayoutFullEditorPlugin";
		}

		public TextLayoutFull()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeTrimming()
		{
			return base.PropertyShouldSerialize("Trimming");
		}

		private void ResetTrimming()
		{
			base.PropertyReset("Trimming");
		}

		private bool ShouldSerializeLineLimit()
		{
			return base.PropertyShouldSerialize("LineLimit");
		}

		private void ResetLineLimit()
		{
			base.PropertyReset("LineLimit");
		}

		private bool ShouldSerializeMeasureTrailingSpaces()
		{
			return base.PropertyShouldSerialize("MeasureTrailingSpaces");
		}

		private void ResetMeasureTrailingSpaces()
		{
			base.PropertyReset("MeasureTrailingSpaces");
		}

		private bool ShouldSerializeNoWrap()
		{
			return base.PropertyShouldSerialize("NoWrap");
		}

		private void ResetNoWrap()
		{
			base.PropertyReset("NoWrap");
		}

		private bool ShouldSerializeNoClip()
		{
			return base.PropertyShouldSerialize("NoClip");
		}

		private void ResetNoClip()
		{
			base.PropertyReset("NoClip");
		}

		protected override Size GetRequiredSize(string s, Font font, int width, GraphicsAPI graphics)
		{
			Point marginsAlignment = base.GetMarginsAlignment(font, graphics);
			Size size = (!this.NoClip) ? graphics.MeasureString(s, font, true, width) : graphics.MeasureString(s, font, true, 0);
			return new Size(size.Width + marginsAlignment.X + 1, size.Height + marginsAlignment.Y + 1);
		}
	}
}
