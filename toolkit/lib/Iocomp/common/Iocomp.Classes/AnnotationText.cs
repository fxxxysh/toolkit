using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public class AnnotationText : AnnotationBase
	{
		private string m_Text;

		private bool m_FixedSize;

		private Font m_DrawFont;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
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

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool FixedSize
		{
			get
			{
				return this.m_FixedSize;
			}
			set
			{
				base.PropertyUpdateDefault("FixedSize", value);
				if (this.FixedSize != value)
				{
					this.m_FixedSize = value;
					base.DoPropertyChange(this, "FixedSize");
				}
				if (this.m_FixedSize)
				{
					base.GrabHandle1.Enabled = false;
					base.GrabHandle5.Enabled = false;
				}
				else
				{
					base.GrabHandle1.Enabled = true;
					base.GrabHandle5.Enabled = true;
				}
			}
		}

		[Category("Iocomp")]
		[Description("")]
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

		protected override string GetPlugInTitle()
		{
			return "Annotation Text";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnnotationTextEditorPlugIn";
		}

		public AnnotationText()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.GrabHandle0.Enabled = true;
			base.GrabHandle1.Enabled = true;
			base.GrabHandle2.Enabled = true;
			base.GrabHandle3.Enabled = true;
			base.GrabHandle4.Enabled = true;
			base.GrabHandle5.Enabled = true;
			base.GrabHandle6.Enabled = true;
			base.GrabHandle7.Enabled = true;
			this.ForeColor = Color.Empty;
			this.Font = null;
			this.Text = "Text";
			this.FixedSize = false;
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

		private bool ShouldSerializeFixedSize()
		{
			return base.PropertyShouldSerialize("FixedSize");
		}

		private void ResetFixedSize()
		{
			base.PropertyReset("FixedSize");
		}

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}

		protected override void DrawCustom(PaintArgs p)
		{
			int num = this.Scale.ConvertHeightUnitsToPixels(this.Height);
			int height = this.Font.Height;
			float num2 = this.FixedSize ? this.Font.Size : ((float)num / (float)height * this.Font.Size);
			if (!(num2 <= 0f))
			{
				Font font;
				if (this.Font.Size != num2)
				{
					if (this.m_DrawFont == null || this.m_DrawFont.Size != num2)
					{
						this.m_DrawFont = new Font(this.Font.Name, num2, this.Font.Style);
					}
					font = this.m_DrawFont;
				}
				else
				{
					font = this.Font;
				}
				Size size = p.Graphics.MeasureString(this.Text, font, false);
				Rectangle r = new Rectangle(this.Scale.ConvertUnitsToPixelsX(this.X) - size.Width / 2, this.Scale.ConvertUnitsToPixelsY(this.Y) - size.Height / 2, size.Width + 1, size.Height + 1);
				base.ClickRegion = this.ToClickRegion(r);
				base.UpdateGrabHandles(r);
				if (this.Text.Length != 0)
				{
					p.Graphics.DrawString(this.Text, font, p.Graphics.Brush(this.ForeColor), r);
				}
			}
		}

		public override string ToString()
		{
			return "Annotation Text";
		}
	}
}
