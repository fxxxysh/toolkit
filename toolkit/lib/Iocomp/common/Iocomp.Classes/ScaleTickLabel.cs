using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	public abstract class ScaleTickLabel : ScaleTickBase, IScaleTickBase, IScaleTickLabel
	{
		private string m_Text;

		private bool m_TextVisible;

		private int m_TextMargin;

		private Size m_TextSize;

		private Size m_TextMaxSize;

		private Size m_TextAlignmentSize;

		private StackingDimension m_StackingDimension;

		Size IScaleTickLabel.TextSize
		{
			get
			{
				return this.TextSize;
			}
			set
			{
				this.TextSize = value;
			}
		}

		Size IScaleTickLabel.TextMaxSize
		{
			get
			{
				return this.TextMaxSize;
			}
			set
			{
				this.TextMaxSize = value;
			}
		}

		Size IScaleTickLabel.TextAlignmentSize
		{
			get
			{
				return this.TextAlignmentSize;
			}
			set
			{
				this.TextAlignmentSize = value;
			}
		}

		StackingDimension IScaleTickLabel.StackingDimension
		{
			get
			{
				return this.StackingDimension;
			}
			set
			{
				this.StackingDimension = value;
			}
		}

		protected Size TextSize
		{
			get
			{
				if (!this.TextVisible)
				{
					return Size.Empty;
				}
				return this.m_TextSize;
			}
			set
			{
				this.m_TextSize = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public new Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		[Description("")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		public string Text
		{
			get
			{
				return this.m_Text;
			}
			set
			{
				base.PropertyUpdateDefault("Text", value);
				if (this.Text != value)
				{
					this.m_Text = value;
					base.DoPropertyChange(this, "Text");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool TextVisible
		{
			get
			{
				return this.m_TextVisible;
			}
			set
			{
				base.PropertyUpdateDefault("TextVisible", value);
				if (this.TextVisible != value)
				{
					this.m_TextVisible = value;
					base.DoPropertyChange(this, "TextVisible");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		protected Size TextMaxSize
		{
			get
			{
				return this.m_TextMaxSize;
			}
			set
			{
				this.m_TextMaxSize = value;
			}
		}

		protected Size TextAlignmentSize
		{
			get
			{
				return this.m_TextAlignmentSize;
			}
			set
			{
				this.m_TextAlignmentSize = value;
			}
		}

		protected StackingDimension StackingDimension
		{
			get
			{
				return this.m_StackingDimension;
			}
			set
			{
				this.m_StackingDimension = value;
			}
		}

		private bool ShouldSerializeFont()
		{
			return base.PropertyShouldSerialize("Font");
		}

		private void ResetFont()
		{
			base.PropertyReset("Font");
		}

		private bool ShouldSerializeForeColor()
		{
			return base.PropertyShouldSerialize("ForeColor");
		}

		private void ResetForeColor()
		{
			base.PropertyReset("ForeColor");
		}

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeTextVisible()
		{
			return base.PropertyShouldSerialize("TextVisible");
		}

		private void ResetTextVisible()
		{
			base.PropertyReset("TextVisible");
		}

		private bool ShouldSerializeTextMargin()
		{
			return base.PropertyShouldSerialize("TextMargin");
		}

		private void ResetTextMargin()
		{
			base.PropertyReset("TextMargin");
		}

		protected override int GetScaleWidth()
		{
			int num = base.Length;
			if (this.TextVisible)
			{
				num += this.TextMargin;
				num = ((this.StackingDimension != 0) ? (num + this.TextAlignmentSize.Height) : (num + this.TextAlignmentSize.Width));
			}
			return num;
		}

		protected override void Draw(PaintArgs p, DrawStringFormat format, int majorLength)
		{
			if (base.Value <= base.Display.Range.Max && base.Value >= base.Display.Range.Min)
			{
				base.Display.DrawTickLine(p, this);
			}
			if (this.TextVisible && this.Font != null)
			{
				base.Display.DrawTickLabel(p, this, format);
			}
		}
	}
}
