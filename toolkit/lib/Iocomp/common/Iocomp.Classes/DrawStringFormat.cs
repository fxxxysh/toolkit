using System.Drawing;

namespace Iocomp.Classes
{
	public sealed class DrawStringFormat
	{
		private StringTrimming m_Trimming;

		private StringAlignment m_LineAlignment;

		private StringAlignment m_Alignment;

		private StringFormatFlags m_FormatFlags;

		private bool m_Typographic;

		public StringFormat StringFormat
		{
			get
			{
				StringFormat stringFormat = (!this.Typographic) ? new StringFormat(StringFormat.GenericDefault) : new StringFormat(StringFormat.GenericTypographic);
				stringFormat.FormatFlags = this.FormatFlags;
				stringFormat.Alignment = this.Alignment;
				stringFormat.LineAlignment = this.LineAlignment;
				stringFormat.Trimming = this.Trimming;
				return stringFormat;
			}
		}

		public static DrawStringFormat GenericDefault
		{
			get
			{
				DrawStringFormat drawStringFormat = new DrawStringFormat();
				drawStringFormat.Typographic = false;
				return drawStringFormat;
			}
		}

		public static DrawStringFormat GenericTypographic
		{
			get
			{
				DrawStringFormat drawStringFormat = new DrawStringFormat();
				drawStringFormat.Typographic = true;
				return drawStringFormat;
			}
		}

		public StringTrimming Trimming
		{
			get
			{
				return this.m_Trimming;
			}
			set
			{
				this.m_Trimming = value;
			}
		}

		public StringAlignment LineAlignment
		{
			get
			{
				return this.m_LineAlignment;
			}
			set
			{
				this.m_LineAlignment = value;
			}
		}

		public StringAlignment Alignment
		{
			get
			{
				return this.m_Alignment;
			}
			set
			{
				this.m_Alignment = value;
			}
		}

		public StringFormatFlags FormatFlags
		{
			get
			{
				return this.m_FormatFlags;
			}
			set
			{
				this.m_FormatFlags = value;
			}
		}

		public bool Typographic
		{
			get
			{
				return this.m_Typographic;
			}
			set
			{
				this.m_Typographic = value;
			}
		}
	}
}
