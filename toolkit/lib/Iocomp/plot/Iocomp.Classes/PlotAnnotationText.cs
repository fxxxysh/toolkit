using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public class PlotAnnotationText : PlotAnnotationBase
	{
		private string m_Text;

		private bool m_FixedSize;

		private Font m_DrawFont;

		private TextLayoutFull m_TextLayout;

		private ITextLayoutFull I_TextLayout;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public TextLayoutFull TextLayout
		{
			get
			{
				return this.m_TextLayout;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation Text";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotAnnotationTextEditorPlugIn";
		}

		public PlotAnnotationText()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_TextLayout = new TextLayoutFull();
			base.AddSubClass(this.TextLayout);
			this.I_TextLayout = this.TextLayout;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Text";
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
			this.TextLayout.Trimming = StringTrimming.None;
			this.TextLayout.LineLimit = false;
			this.TextLayout.MeasureTrailingSpaces = false;
			this.TextLayout.NoWrap = false;
			this.TextLayout.NoClip = false;
			this.TextLayout.AlignmentHorizontal.Style = StringAlignment.Center;
			this.TextLayout.AlignmentHorizontal.Margin = 0.0;
			this.TextLayout.AlignmentVertical.Style = StringAlignment.Center;
			this.TextLayout.AlignmentVertical.Margin = 0.0;
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

		private bool ShouldSerializeTextLayout()
		{
			return ((ISubClassBase)this.TextLayout).ShouldSerialize();
		}

		private void ResetTextLayout()
		{
			((ISubClassBase)this.TextLayout).ResetToDefault();
		}

		protected override void DrawCustom(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			float num7;
			if (!this.FixedSize)
			{
				float num;
				float num2;
				if (!base.XYSwapped)
				{
					num = (float)base.WidthPixels;
					num2 = (float)base.HeightPixels;
				}
				else
				{
					num = (float)base.HeightPixels;
					num2 = (float)base.WidthPixels;
				}
				float num3 = (float)p.Graphics.MeasureString(this.Text, this.Font).Width;
				float num4 = (float)this.Font.Height;
				float num5 = num / num3;
				float num6 = num2 / num4;
				num7 = ((!(num6 < num5)) ? (num / num3 * this.Font.Size) : (num2 / num4 * this.Font.Size));
			}
			else
			{
				num7 = this.Font.Size;
			}
			if (!(num7 <= 0f))
			{
				Font font;
				if (this.Font.Size != num7)
				{
					if (this.m_DrawFont == null || this.m_DrawFont.Size != num7)
					{
						this.m_DrawFont = new Font(this.Font.Name, num7, this.Font.Style);
					}
					font = this.m_DrawFont;
				}
				else
				{
					font = this.Font;
				}
				Point pt = base.XYSwapped ? new Point(base.YPixels, base.XPixels) : new Point(base.XPixels, base.YPixels);
				Rectangle rectangle = this.I_TextLayout.GetRectangle(this.Text, pt, font, p.Graphics);
				if (!base.BoundsClip.IntersectsWith(rectangle))
				{
					base.ClickRegion = null;
				}
				else
				{
					DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
					genericTypographic.Alignment = this.TextLayout.AlignmentHorizontal.Style;
					genericTypographic.LineAlignment = this.TextLayout.AlignmentVertical.Style;
					p.Graphics.DrawString(this.Text, font, p.Graphics.Brush(this.ForeColor), rectangle, genericTypographic);
					base.ClickRegion = this.ToClickRegion(rectangle);
					base.UpdateGrabHandles(rectangle);
				}
			}
		}
	}
}
