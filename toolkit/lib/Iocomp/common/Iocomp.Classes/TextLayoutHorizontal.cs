using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Contains the horizontal and vertical layout properties for text.")]
	public sealed class TextLayoutHorizontal : SubClassBase, ITextLayoutHorizontal
	{
		private AlignmentText m_Alignment;

		private StringTrimming m_Trimming;

		private bool m_LineLimit;

		private bool m_MeasureTrailingSpaces;

		private bool m_NoWrap;

		private bool m_NoClip;

		private bool m_Flipped;

		[ParenthesizePropertyName(true)]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public AlignmentText Alignment
		{
			get
			{
				return this.m_Alignment;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool Flipped
		{
			get
			{
				return this.m_Flipped;
			}
			set
			{
				base.PropertyUpdateDefault("Flipped", value);
				if (this.Flipped != value)
				{
					this.m_Flipped = value;
					base.DoPropertyChange(this, "Flipped");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the line boundary measurement spaceIf true, the boundary will include the space at the end of each lineIf false, the boundary will exclude the space at the end of each line.")]
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

		private DrawStringFormat StringFormat
		{
			get
			{
				StringFormatFlags stringFormatFlags = (StringFormatFlags)0;
				if (this.m_LineLimit)
				{
					stringFormatFlags |= StringFormatFlags.LineLimit;
				}
				if (this.m_MeasureTrailingSpaces)
				{
					stringFormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
				}
				if (this.m_NoWrap)
				{
					stringFormatFlags |= StringFormatFlags.NoWrap;
				}
				if (this.m_NoClip)
				{
					stringFormatFlags |= StringFormatFlags.NoClip;
				}
				DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
				genericTypographic.Alignment = this.Alignment.Style;
				genericTypographic.Trimming = this.m_Trimming;
				genericTypographic.FormatFlags = stringFormatFlags;
				return genericTypographic;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Text Layout";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.TextLayoutHorizontalEditorPlugIn";
		}

		void ITextLayoutHorizontal.Draw(GraphicsAPI graphics, Font font, Brush brush, string s, Rectangle r)
		{
			this.Draw(graphics, font, brush, s, r);
		}

		Point ITextLayoutHorizontal.GetMarginOffsets(Font font, GraphicsAPI graphics)
		{
			return this.GetMarginOffsets(font, graphics);
		}

		Size ITextLayoutHorizontal.GetRequiredSize(string s, Font font, GraphicsAPI graphics)
		{
			return this.GetRequiredSize(s, font, graphics);
		}

		public TextLayoutHorizontal()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Alignment = new AlignmentText();
			base.AddSubClass(this.Alignment);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Trimming = StringTrimming.Character;
			this.LineLimit = false;
			this.MeasureTrailingSpaces = false;
			this.NoWrap = false;
			this.NoClip = false;
			this.Flipped = false;
		}

		private bool ShouldSerializeAlignment()
		{
			return ((ISubClassBase)this.Alignment).ShouldSerialize();
		}

		private void ResetAlignment()
		{
			((ISubClassBase)this.Alignment).ResetToDefault();
		}

		private bool ShouldSerializeFlipped()
		{
			return base.PropertyShouldSerialize("Flipped");
		}

		private void ResetFlipped()
		{
			base.PropertyReset("Flipped");
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

		private Point GetMarginOffsets(Font font, GraphicsAPI graphics)
		{
			int x = (int)Math.Ceiling((double)graphics.MeasureString("0", font, true).Width * this.Alignment.Margin);
			return new Point(x, 0);
		}

		private Size GetRequiredSize(string s, Font font, GraphicsAPI graphics)
		{
			Point marginOffsets = this.GetMarginOffsets(font, graphics);
			Size size = graphics.MeasureString(s, font, true);
			return new Size(size.Width + marginOffsets.X, size.Height + marginOffsets.Y);
		}

		private void Draw(GraphicsAPI graphics, Font font, Brush brush, string s, Rectangle r)
		{
			Point point = new Point((r.Left + r.Right) / 2, (r.Top + r.Bottom) / 2);
			DrawStringFormat stringFormat = this.StringFormat;
			Point marginOffsets = this.GetMarginOffsets(font, graphics);
			if (this.Alignment.Style == StringAlignment.Near)
			{
				r.Offset(marginOffsets.X, 0);
			}
			else if (this.Alignment.Style == StringAlignment.Far)
			{
				r.Offset(-marginOffsets.X, 0);
			}
			GraphicsState gstate = graphics.Save();
			graphics.TranslateTransform((float)point.X, (float)point.Y);
			if (this.Flipped)
			{
				graphics.ScaleTransform(-1f, -1f);
			}
			graphics.TranslateTransform((float)(-point.X), (float)(-point.Y));
			graphics.DrawString(s, font, brush, r, stringFormat);
			graphics.Restore(gstate);
		}
	}
}
