using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Basic legend used to display a list of channels")]
	public class PlotLegendBasic : PlotLegendBase
	{
		private double m_TitleMargin;

		private LegendTitleColorStyle m_TitleColorStyle;

		private double m_Spacing;

		private PlotLegendWrapping m_Wrapping;

		private iRectangle m_Rect;

		private int m_MarginOuterPixels;

		private int m_MarkerSize;

		private int m_MarkerWidthPixels;

		private int m_TitleMarginPixels;

		private int m_LengthPixels;

		private int m_SpacingPixels;

		private int m_MaxElementCount;

		private int m_MaxElementWidth;

		private int m_WrapCount;

		private int m_WrapMarginPixels;

		[Category("Iocomp")]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotLegendWrapping Wrapping
		{
			get
			{
				return this.m_Wrapping;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double TitleMargin
		{
			get
			{
				return this.m_TitleMargin;
			}
			set
			{
				base.PropertyUpdateDefault("TitleMargin", value);
				if (this.TitleMargin != value)
				{
					this.m_TitleMargin = value;
					base.DoPropertyChange(this, "TitleMargin");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public LegendTitleColorStyle TitleColorStyle
		{
			get
			{
				return this.m_TitleColorStyle;
			}
			set
			{
				base.PropertyUpdateDefault("TitleColorStyle", value);
				if (this.TitleColorStyle != value)
				{
					this.m_TitleColorStyle = value;
					base.DoPropertyChange(this, "TitleColorStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double Spacing
		{
			get
			{
				return this.m_Spacing;
			}
			set
			{
				base.PropertyUpdateDefault("Spacing", value);
				if (this.Spacing != value)
				{
					this.m_Spacing = value;
					base.DoPropertyChange(this, "Spacing");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Legend Basic";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLegendBasicEditorPlugIn";
		}

		public PlotLegendBasic()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Wrapping = new PlotLegendWrapping();
			base.AddSubClass(this.Wrapping);
			this.m_Rect = new iRectangle();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Basic";
			this.TitleMargin = 1.0;
			this.TitleColorStyle = LegendTitleColorStyle.ForeColor;
			this.Spacing = 0.5;
		}

		private bool ShouldSerializeTracking()
		{
			return ((ISubClassBase)this.Wrapping).ShouldSerialize();
		}

		private void ResetTracking()
		{
			((ISubClassBase)this.Wrapping).ResetToDefault();
		}

		private bool ShouldSerializeTitleMargin()
		{
			return base.PropertyShouldSerialize("TitleMargin");
		}

		private void ResetTitleMargin()
		{
			base.PropertyReset("TitleMargin");
		}

		private bool ShouldSerializeTitleColorStyle()
		{
			return base.PropertyShouldSerialize("TitleColorStyle");
		}

		private void ResetTitleColorStyle()
		{
			base.PropertyReset("TitleColorStyle");
		}

		private bool ShouldSerializeSpacing()
		{
			return base.PropertyShouldSerialize("Spacing");
		}

		private void ResetSpacing()
		{
			base.PropertyReset("Spacing");
		}

		protected override void CalculateDepthPixels(PaintArgs p)
		{
			base.UpdateChannelList();
			this.m_MarginOuterPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(base.Font).Height * base.MarginOuter);
			this.m_MarkerSize = p.Graphics.MeasureString(base.Font).Height;
			this.m_TitleMarginPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(base.Font).Width * this.TitleMargin);
			this.m_WrapMarginPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(base.Font).Width * this.Wrapping.Margin);
			this.m_MarkerWidthPixels = this.m_MarkerSize;
			int num = 0;
			foreach (PlotChannelBase channel in base.Channels)
			{
				num = (int)Math.Ceiling((double)Math.Max(num, p.Graphics.MeasureString(channel.DisplayDescription, base.Font).Width));
			}
			this.m_SpacingPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(base.Font).Width * this.Spacing);
			this.m_MaxElementWidth = this.m_MarkerWidthPixels + this.m_TitleMarginPixels + num;
			if (base.DockHorizontal)
			{
				this.m_MaxElementCount = (base.Bounds.Height + this.m_SpacingPixels - this.m_MarginOuterPixels) / (this.m_MarkerSize + this.m_SpacingPixels);
				if (this.m_MaxElementCount == 0)
				{
					this.m_MaxElementCount = 1;
				}
				if (this.m_MaxElementCount > base.Channels.Count)
				{
					this.m_MaxElementCount = base.Channels.Count;
				}
				if (this.Wrapping.Enabled)
				{
					this.m_WrapCount = (int)Math.Ceiling((double)base.Channels.Count / (double)this.m_MaxElementCount);
				}
				else
				{
					this.m_WrapCount = 1;
				}
				this.m_LengthPixels = this.m_MaxElementCount * this.m_MarkerSize + (this.m_MaxElementCount - 1) * this.m_SpacingPixels;
				base.DockDepthPixels = this.m_MaxElementWidth * this.m_WrapCount + (this.m_WrapCount - 1) * this.m_WrapMarginPixels;
			}
			else
			{
				this.m_MaxElementCount = (base.Bounds.Width + this.m_SpacingPixels - this.m_MarginOuterPixels) / (this.m_MaxElementWidth + this.m_SpacingPixels);
				if (this.m_MaxElementCount == 0)
				{
					this.m_MaxElementCount = 1;
				}
				if (this.m_MaxElementCount > base.Channels.Count)
				{
					this.m_MaxElementCount = base.Channels.Count;
				}
				if (this.Wrapping.Enabled)
				{
					this.m_WrapCount = (int)Math.Ceiling((double)base.Channels.Count / (double)this.m_MaxElementCount);
				}
				else
				{
					this.m_WrapCount = 1;
				}
				this.m_LengthPixels = this.m_MaxElementWidth + (this.m_MaxElementCount - 1) * (this.m_MaxElementWidth + this.m_SpacingPixels);
				base.DockDepthPixels = this.m_MarkerSize + (this.m_WrapCount - 1) * (this.m_MarkerSize + this.m_WrapMarginPixels);
			}
			this.m_LengthPixels += 2 * this.m_MarginOuterPixels;
			base.DockDepthPixels += 2 * this.m_MarginOuterPixels;
		}

		protected override void DrawCalculations(PaintArgs p)
		{
			base.CalculateBoundsAlignment(this.m_LengthPixels);
		}

		private Brush GetTitleBrush(PaintArgs p, PlotChannelBase ch)
		{
			if (this.TitleColorStyle == LegendTitleColorStyle.ForeColor)
			{
				return p.Graphics.Brush(base.ForeColor);
			}
			if (this.TitleColorStyle == LegendTitleColorStyle.ChannelColor)
			{
				return p.Graphics.Brush(ch.Color);
			}
			if (this.TitleColorStyle == LegendTitleColorStyle.XAxisColor && ch.XAxis != null)
			{
				return p.Graphics.Brush(ch.XAxis.Color);
			}
			if (this.TitleColorStyle == LegendTitleColorStyle.YAxisColor && ch.YAxis != null)
			{
				return p.Graphics.Brush(ch.YAxis.Color);
			}
			return p.Graphics.Brush(base.ForeColor);
		}

		protected override void Draw(PaintArgs p)
		{
			base.I_Fill.Draw(p, base.BoundsAlignment);
			DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
			genericTypographic.Alignment = StringAlignment.Near;
			genericTypographic.LineAlignment = StringAlignment.Near;
			this.m_Rect.Rectangle = base.BoundsAlignment;
			Size size;
			Rectangle rectangle;
			if (base.DockHorizontal)
			{
				int num = base.BoundsAlignment.Top + this.m_MarginOuterPixels;
				int num2 = base.BoundsAlignment.Left + this.m_MarginOuterPixels;
				this.m_Rect.Top = num;
				this.m_Rect.Height = this.m_MarkerSize;
				this.m_Rect.Width = this.m_MarkerWidthPixels;
				for (int i = 0; i < base.Channels.Count; i++)
				{
					PlotChannelBase plotChannelBase = base.Channels[i] as PlotChannelBase;
					if (plotChannelBase != null)
					{
						Brush titleBrush = this.GetTitleBrush(p, plotChannelBase);
						string displayDescription = plotChannelBase.DisplayDescription;
						size = p.Graphics.MeasureString(displayDescription, base.Font);
						int num3 = i / this.m_MaxElementCount;
						int num4 = i % this.m_MaxElementCount;
						this.m_Rect.Top = num + num4 * (this.m_SpacingPixels + this.m_MarkerSize);
						this.m_Rect.Left = num2 + num3 * (this.m_MaxElementWidth + this.m_WrapMarginPixels);
						rectangle = new Rectangle(this.m_Rect.Left - this.m_MarginOuterPixels, this.m_Rect.Top, this.m_MarginOuterPixels + this.m_MarkerWidthPixels + this.m_TitleMarginPixels + size.Width, size.Height);
						rectangle.Inflate(1, 1);
						plotChannelBase.LegendRectangle = rectangle;
						if (plotChannelBase.Focused && !rectangle.IsEmpty)
						{
							p.Graphics.DrawFocusRectangle(rectangle, base.BackColor);
						}
						((IPlotChannelBase)plotChannelBase).DrawLegendMarker(p, this.m_Rect.Rectangle);
						this.m_Rect.Left = num2 + num3 * (this.m_MaxElementWidth + this.m_WrapMarginPixels) + this.m_MarkerWidthPixels + this.m_TitleMarginPixels;
						p.Graphics.DrawString(displayDescription, base.Font, titleBrush, (float)this.m_Rect.Left, (float)this.m_Rect.Top, genericTypographic);
					}
				}
			}
			else
			{
				int num = base.BoundsAlignment.Top + this.m_MarginOuterPixels;
				int num2 = base.BoundsAlignment.Left + this.m_MarginOuterPixels;
				this.m_Rect.Top = num;
				this.m_Rect.Left = num2;
				this.m_Rect.Height = this.m_MarkerSize;
				this.m_Rect.Width = this.m_MarkerWidthPixels;
				for (int j = 0; j < base.Channels.Count; j++)
				{
					PlotChannelBase plotChannelBase = base.Channels[j] as PlotChannelBase;
					Brush titleBrush = this.GetTitleBrush(p, plotChannelBase);
					string displayDescription = plotChannelBase.DisplayDescription;
					size = p.Graphics.MeasureString(displayDescription, base.Font);
					int num3 = j / this.m_MaxElementCount;
					int num4 = j % this.m_MaxElementCount;
					this.m_Rect.Top = num + num3 * (this.m_WrapMarginPixels + this.m_MarkerSize);
					this.m_Rect.Left = num2 + num4 * (this.m_MaxElementWidth + this.m_SpacingPixels);
					rectangle = new Rectangle(this.m_Rect.Left - this.m_MarginOuterPixels, this.m_Rect.Top, this.m_MarginOuterPixels + this.m_MarkerWidthPixels + this.m_TitleMarginPixels + size.Width, size.Height);
					rectangle.Inflate(1, 1);
					plotChannelBase.LegendRectangle = rectangle;
					if (plotChannelBase.Focused && !rectangle.IsEmpty)
					{
						p.Graphics.DrawFocusRectangle(rectangle, base.BackColor);
					}
					((IPlotChannelBase)plotChannelBase).DrawLegendMarker(p, this.m_Rect.Rectangle);
					this.m_Rect.Left = num2 + num4 * (this.m_MaxElementWidth + this.m_SpacingPixels) + this.m_MarkerWidthPixels + this.m_TitleMarginPixels;
					p.Graphics.DrawString(displayDescription, base.Font, titleBrush, (float)this.m_Rect.Left, (float)this.m_Rect.Top, genericTypographic);
				}
			}
		}
	}
}
