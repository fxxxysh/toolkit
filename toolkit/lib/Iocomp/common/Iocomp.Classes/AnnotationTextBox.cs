using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace Iocomp.Classes
{
	[Serializable]
	public sealed class AnnotationTextBox : AnnotationShape
	{
		private string m_Text;

		private bool m_FixedSize;

		private Font m_DrawFont;

		private TextLayoutBase m_TextLayout;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Iocomp")]
		[Description("")]
		public TextLayoutBase TextLayout
		{
			get
			{
				return this.m_TextLayout;
			}
		}

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

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Editor("System.Windows.Forms.Design.StringArrayEditor,System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
		[Description("")]
		public string[] TextLines
		{
			get
			{
				return this.Text.Split('\n');
			}
			set
			{
				base.PropertyUpdateDefault("TextLines", value);
				StringBuilder stringBuilder = new StringBuilder(value.Length);
				for (int i = 0; i < value.Length; i++)
				{
					if (i < value.Length - 1)
					{
						stringBuilder.Append(value[i] + "\n");
					}
					else
					{
						stringBuilder.Append(value[i]);
					}
				}
				this.Text = stringBuilder.ToString();
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation TextBox";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnnotationTextBoxEditorPlugIn";
		}

		public AnnotationTextBox()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_TextLayout = new TextLayoutBase();
			base.AddSubClass(this.TextLayout);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.GrabHandle0.Enabled = false;
			base.GrabHandle1.Enabled = false;
			base.GrabHandle2.Enabled = false;
			base.GrabHandle3.Enabled = false;
			base.GrabHandle4.Enabled = false;
			base.GrabHandle5.Enabled = false;
			base.GrabHandle6.Enabled = false;
			base.GrabHandle7.Enabled = false;
			this.ForeColor = Color.Empty;
			this.Font = null;
			this.Text = "Text Box";
			this.FixedSize = false;
			this.TextLines = new string[1]
			{
				"Text Box"
			};
			this.TextLines[0] = this.Text;
			this.TextLayout.AlignmentHorizontal.Style = StringAlignment.Center;
			this.TextLayout.AlignmentHorizontal.Margin = 0.5;
			this.TextLayout.AlignmentVertical.Style = StringAlignment.Center;
			this.TextLayout.AlignmentVertical.Margin = 0.5;
		}

		private bool ShouldSerializeTextLayout()
		{
			return ((ISubClassBase)this.TextLayout).ShouldSerialize();
		}

		private void ResetTextLayout()
		{
			((ISubClassBase)this.TextLayout).ResetToDefault();
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

		private bool ShouldSerializeTextLines()
		{
			return base.PropertyShouldSerialize("TextLines");
		}

		private void ResetTextLines()
		{
			base.PropertyReset("TextLines");
		}

		protected override void DrawOutline(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.DrawRectangle(p.Graphics.Pen(base.OutlineColor, base.DashStyle), rect);
		}

		protected override void DrawFillHatch(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.FillRectangle(p.Graphics.Brush(base.HatchStyle, base.HatchForeColor, base.HatchBackColor), rect);
		}

		protected override void DrawFillGradient(PaintArgs p, Rectangle rect, Point[] points)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(rect);
			p.Graphics.FillGradientPath(rect, graphicsPath, base.GradientStartColor, base.GradientStopColor, base.ModeAngle, 1f, false);
		}

		protected override void DrawFillSolid(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.FillRectangle(p.Graphics.Brush(base.FillColor), rect);
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
				Size requiredSize = ((ITextLayoutBase)this.TextLayout).GetRequiredSize(this.Text, font, p.Graphics);
				Rectangle r = new Rectangle(this.Scale.ConvertUnitsToPixelsX(this.X) - requiredSize.Width / 2, this.Scale.ConvertUnitsToPixelsY(this.Y) - requiredSize.Height / 2, requiredSize.Width + 1, requiredSize.Height + 1);
				base.ClickRegion = this.ToClickRegion(r);
				base.UpdateGrabHandles(r);
				if (r.Height != 0 && r.Width != 0)
				{
					if (base.FillStyle != AnnotationFillStyle.Clear)
					{
						base.DrawFill(p, r, null);
					}
					Rectangle r2 = new Rectangle(r.Left, r.Top, r.Width - 1, r.Height - 1);
					if (r2.Height != 0 && r2.Width != 0)
					{
						if (base.OutlineStyle != AnnotationOutlineStyle.Clear)
						{
							this.DrawOutline(p, r2, null);
						}
						((ITextLayoutBase)this.TextLayout).Draw(p.Graphics, font, p.Graphics.Brush(this.ForeColor), this.Text, r);
					}
				}
			}
		}

		public override string ToString()
		{
			return "Annotation TextBox";
		}
	}
}
