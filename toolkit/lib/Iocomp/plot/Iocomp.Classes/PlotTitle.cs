using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Iocomp.Classes
{
	[Description("Plot Title.")]
	public class PlotTitle : SubClassBase, IPlotTitle
	{
		private string m_Text;

		private PlotAutoRotation m_TextRotation;

		private double m_MarginSpacing;

		private double m_MarginOuter;

		private AlignmentQuadSide m_DockSide;

		private int m_MarginOuterPixels;

		private int m_RequiredDepthPixels;

		private int m_TitleDepthPixels;

		private int m_SpacingPixels;

		private TextLayoutFull m_TextLayout;

		private ITextLayoutFull I_TextLayout;

		private PlotFill m_Fill;

		private IPlotFill I_Fill;

		AlignmentQuadSide IPlotTitle.DockSide
		{
			get
			{
				return this.DockSide;
			}
			set
			{
				this.DockSide = value;
			}
		}

		int IPlotTitle.RequiredDepthPixels
		{
			get
			{
				return this.RequiredDepthPixels;
			}
		}

		int IPlotTitle.TitleDepthPixels
		{
			get
			{
				return this.TitleDepthPixels;
			}
		}

		int IPlotTitle.SpacingPixels
		{
			get
			{
				return this.SpacingPixels;
			}
		}

		protected Color SolidColor => this.Color;

		protected Color HatchForeColor => this.Color;

		protected Color HatchBackColor => this.Color;

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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public TextLayoutFull TextLayout
		{
			get
			{
				return this.m_TextLayout;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotFill Fill
		{
			get
			{
				return this.m_Fill;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Editor("System.Windows.Forms.Design.StringArrayEditor,System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string[] TextLines
		{
			get
			{
				return this.Text.Split('\n');
			}
			set
			{
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

		[Description("Specifies the text for the label.")]
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
		public PlotAutoRotation TextRotation
		{
			get
			{
				return this.m_TextRotation;
			}
			set
			{
				base.PropertyUpdateDefault("TextRotation", value);
				if (this.TextRotation != value)
				{
					this.m_TextRotation = value;
					base.DoPropertyChange(this, "TextRotation");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("")]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double MarginOuter
		{
			get
			{
				return this.m_MarginOuter;
			}
			set
			{
				base.PropertyUpdateDefault("MarginOuter", value);
				if (this.MarginOuter != value)
				{
					this.m_MarginOuter = value;
					base.DoPropertyChange(this, "MarginOuter");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double MarginSpacing
		{
			get
			{
				return this.m_MarginSpacing;
			}
			set
			{
				base.PropertyUpdateDefault("MarginSpacing", value);
				if (this.MarginSpacing != value)
				{
					this.m_MarginSpacing = value;
					base.DoPropertyChange(this, "MarginSpacing");
				}
			}
		}

		private AlignmentQuadSide DockSide
		{
			get
			{
				return this.m_DockSide;
			}
			set
			{
				this.m_DockSide = value;
			}
		}

		private int RequiredDepthPixels => this.m_RequiredDepthPixels;

		private int TitleDepthPixels => this.m_TitleDepthPixels;

		private int SpacingPixels => this.m_SpacingPixels;

		private bool DockLeft => this.m_DockSide == AlignmentQuadSide.Left;

		private bool DockRight => this.m_DockSide == AlignmentQuadSide.Right;

		private bool DockTop => this.m_DockSide == AlignmentQuadSide.Top;

		private bool DockBottom => this.m_DockSide == AlignmentQuadSide.Bottom;

		private bool DockVertical
		{
			get
			{
				if (!this.DockTop)
				{
					return this.DockBottom;
				}
				return true;
			}
		}

		private bool DockHorizontal
		{
			get
			{
				if (!this.DockLeft)
				{
					return this.DockRight;
				}
				return true;
			}
		}

		private TextRotation ActualTextRotation
		{
			get
			{
				if (this.TextRotation == PlotAutoRotation.Auto)
				{
					if (this.DockVertical)
					{
						return Iocomp.Types.TextRotation.X000;
					}
					if (this.DockLeft)
					{
						return Iocomp.Types.TextRotation.X270;
					}
					return Iocomp.Types.TextRotation.X090;
				}
				if (this.TextRotation == PlotAutoRotation.X000)
				{
					return Iocomp.Types.TextRotation.X000;
				}
				if (this.TextRotation == PlotAutoRotation.X090)
				{
					return Iocomp.Types.TextRotation.X090;
				}
				if (this.TextRotation == PlotAutoRotation.X180)
				{
					return Iocomp.Types.TextRotation.X180;
				}
				return Iocomp.Types.TextRotation.X270;
			}
		}

		private bool TextHorizontal
		{
			get
			{
				if (this.ActualTextRotation != 0)
				{
					return this.ActualTextRotation == Iocomp.Types.TextRotation.X180;
				}
				return true;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Title";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotTitleEditorPlugIn";
		}

		void IPlotTitle.Draw(PaintArgs p, Rectangle bounds)
		{
			this.Draw(p, bounds);
		}

		void IPlotTitle.CalculateDrawingData(PaintArgs p, int spanPixels)
		{
			this.CalculateDrawingData(p, spanPixels);
		}

		public PlotTitle()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_TextLayout = new TextLayoutFull();
			base.AddSubClass(this.TextLayout);
			this.I_TextLayout = this.TextLayout;
			this.m_Fill = new PlotFill();
			base.AddSubClass(this.Fill);
			this.I_Fill = this.Fill;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Text = "Title";
			this.TextRotation = PlotAutoRotation.Auto;
			this.MarginSpacing = 0.0;
			this.MarginOuter = 0.5;
			this.Color = Color.Empty;
			this.ForeColor = Color.Empty;
			this.Fill.Visible = false;
			this.Fill.Brush.Visible = true;
			this.Fill.Brush.Style = PlotBrushStyle.Solid;
			this.Fill.Brush.SolidColor = Color.Empty;
			this.Fill.Brush.GradientStartColor = Color.Blue;
			this.Fill.Brush.GradientStopColor = Color.Aqua;
			this.Fill.Brush.HatchForeColor = Color.Empty;
			this.Fill.Brush.HatchBackColor = Color.Empty;
			this.Fill.Pen.Visible = true;
			this.Fill.Pen.Color = Color.Empty;
			this.Fill.Pen.Thickness = 1.0;
			this.Fill.Pen.Style = PlotPenStyle.Solid;
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeTextLayout()
		{
			return ((ISubClassBase)this.TextLayout).ShouldSerialize();
		}

		private void ResetTextLayout()
		{
			((ISubClassBase)this.TextLayout).ResetToDefault();
		}

		private bool ShouldSerializeFill()
		{
			return ((ISubClassBase)this.Fill).ShouldSerialize();
		}

		private void ResetFill()
		{
			((ISubClassBase)this.Fill).ResetToDefault();
		}

		private bool ShouldSerializeTextLines()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetTextLines()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeTextRotation()
		{
			return base.PropertyShouldSerialize("TextRotation");
		}

		private void ResetTextRotation()
		{
			base.PropertyReset("TextRotation");
		}

		private bool ShouldSerializeForeColor()
		{
			return base.PropertyShouldSerialize("ForeColor");
		}

		private void ResetForeColor()
		{
			base.PropertyReset("ForeColor");
		}

		private bool ShouldSerializeFont()
		{
			return base.PropertyShouldSerialize("Font");
		}

		private void ResetFont()
		{
			base.PropertyReset("Font");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeMarginOuter()
		{
			return base.PropertyShouldSerialize("MarginOuter");
		}

		private void ResetMarginOuter()
		{
			base.PropertyReset("MarginOuter");
		}

		private bool ShouldSerializeMarginSpacing()
		{
			return base.PropertyShouldSerialize("MarginSpacing");
		}

		private void ResetMarginSpacing()
		{
			base.PropertyReset("MarginSpacing");
		}

		private void CalculateDrawingData(PaintArgs p, int spanPixels)
		{
			this.m_MarginOuterPixels = 0;
			this.m_SpacingPixels = 0;
			this.m_RequiredDepthPixels = 0;
			this.m_TitleDepthPixels = 0;
			if (this.Visible)
			{
				this.m_MarginOuterPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(this.Font).Height * this.MarginOuter);
				this.m_SpacingPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(this.Font).Height * this.MarginSpacing);
				Size size = (!this.DockVertical) ? ((!this.TextHorizontal) ? ((ITextLayoutBase)this.TextLayout).GetRequiredSize(this.Text, this.Font, spanPixels - 2 * this.m_MarginOuterPixels, p.Graphics) : ((ITextLayoutBase)this.TextLayout).GetRequiredSize(this.Text, this.Font, 0, p.Graphics)) : ((!this.TextHorizontal) ? ((ITextLayoutBase)this.TextLayout).GetRequiredSize(this.Text, this.Font, 0, p.Graphics) : ((ITextLayoutBase)this.TextLayout).GetRequiredSize(this.Text, this.Font, spanPixels - 2 * this.m_MarginOuterPixels, p.Graphics));
				if (!((!this.DockVertical) ? this.TextHorizontal : (!this.TextHorizontal)))
				{
					this.m_RequiredDepthPixels = size.Height + 2 * this.m_MarginOuterPixels;
				}
				else
				{
					this.m_RequiredDepthPixels = size.Width + 2 * this.m_MarginOuterPixels;
				}
				this.m_TitleDepthPixels = this.m_RequiredDepthPixels;
			}
		}

		private void Draw(PaintArgs p, Rectangle bounds)
		{
			if (this.Visible)
			{
				this.I_Fill.Draw(p, bounds);
				Rectangle rectangle = ((ITextLayoutBase)this.TextLayout).GetRectangle(bounds, this.Font, p.Graphics);
				rectangle.Inflate(-this.m_MarginOuterPixels, -this.m_MarginOuterPixels);
				p.Graphics.DrawRotatedText(this.Text, this.Font, this.ForeColor, rectangle, this.ActualTextRotation, ((ITextLayoutBase)this.TextLayout).StringFormat);
			}
		}
	}
}
