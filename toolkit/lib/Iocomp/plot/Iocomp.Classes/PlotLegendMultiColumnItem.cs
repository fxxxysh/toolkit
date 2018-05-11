using Iocomp.Design;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(CollectionItemConverter))]
	public sealed class PlotLegendMultiColumnItem : SubClassBase, IPlotLegendMultiColumnItem
	{
		private string m_TitleText;

		private bool m_TitleVisible;

		private Color m_TitleForeColor;

		private PlotFill m_TitleFill;

		private IPlotFill I_TitleFill;

		private TextLayoutHorizontal m_TitleLayout;

		private ITextLayoutHorizontal I_TitleLayout;

		private PlotLegendMultiColumnItemType m_DataType;

		private Color m_DataForeColor;

		private PlotFill m_DataFill;

		private IPlotFill I_DataFill;

		private TextLayoutHorizontal m_DataLayout;

		private ITextLayoutHorizontal I_DataLayout;

		private SizeStyle m_WidthStyle;

		private double m_Width;

		public Font m_DrawTitleFont;

		public Font m_DrawDataFont;

		public int m_DrawPixelsMarginOuter;

		public int m_DrawPixelsMarkerMinWidth;

		public int m_DrawPixelsTextWidth;

		public int m_DrawPixelsHeightTitle;

		public int m_DrawPixelsHeightData;

		public int m_DrawPixelsMargin;

		Font IPlotLegendMultiColumnItem.DrawTitleFont
		{
			get
			{
				return this.m_DrawTitleFont;
			}
			set
			{
				this.m_DrawTitleFont = value;
			}
		}

		Font IPlotLegendMultiColumnItem.DrawDataFont
		{
			get
			{
				return this.m_DrawDataFont;
			}
			set
			{
				this.m_DrawDataFont = value;
			}
		}

		int IPlotLegendMultiColumnItem.DrawPixelsMarginOuter
		{
			get
			{
				return this.m_DrawPixelsMarginOuter;
			}
			set
			{
				this.m_DrawPixelsMarginOuter = value;
			}
		}

		int IPlotLegendMultiColumnItem.DrawPixelsMarkerMinWidth
		{
			get
			{
				return this.m_DrawPixelsMarkerMinWidth;
			}
			set
			{
				this.m_DrawPixelsMarkerMinWidth = value;
			}
		}

		int IPlotLegendMultiColumnItem.DrawPixelsTextWidth
		{
			get
			{
				return this.m_DrawPixelsTextWidth;
			}
			set
			{
				this.m_DrawPixelsTextWidth = value;
			}
		}

		int IPlotLegendMultiColumnItem.DrawPixelsHeightTitle
		{
			get
			{
				return this.m_DrawPixelsHeightTitle;
			}
			set
			{
				this.m_DrawPixelsHeightTitle = value;
			}
		}

		int IPlotLegendMultiColumnItem.DrawPixelsHeightData
		{
			get
			{
				return this.m_DrawPixelsHeightData;
			}
			set
			{
				this.m_DrawPixelsHeightData = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotFill DataFill
		{
			get
			{
				return this.m_DataFill;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill TitleFill
		{
			get
			{
				return this.m_TitleFill;
			}
		}

		[Description("Controls the layout attrbitutes for the column title.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TextLayoutHorizontal TitleLayout
		{
			get
			{
				return this.m_TitleLayout;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Controls the layout attrbitutes for the column data.")]
		public TextLayoutHorizontal DataLayout
		{
			get
			{
				return this.m_DataLayout;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotLegendMultiColumnItemType DataType
		{
			get
			{
				return this.m_DataType;
			}
			set
			{
				base.PropertyUpdateDefault("DataType", value);
				if (this.DataType != value)
				{
					this.m_DataType = value;
					base.DoPropertyChange(this, "DataType");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Category("Iocomp")]
		public string TitleText
		{
			get
			{
				return this.m_TitleText;
			}
			set
			{
				base.PropertyUpdateDefault("TitleText", value);
				if (this.TitleText != value)
				{
					this.m_TitleText = value;
					base.DoPropertyChange(this, "TitleText");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Category("Iocomp")]
		public bool TitleVisible
		{
			get
			{
				return this.m_TitleVisible;
			}
			set
			{
				base.PropertyUpdateDefault("TitleVisible", value);
				if (this.TitleVisible != value)
				{
					this.m_TitleVisible = value;
					base.DoPropertyChange(this, "TitleVisible");
				}
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public SizeStyle WidthStyle
		{
			get
			{
				return this.m_WidthStyle;
			}
			set
			{
				base.PropertyUpdateDefault("WidthStyle", value);
				if (this.WidthStyle != value)
				{
					this.m_WidthStyle = value;
					base.DoPropertyChange(this, "WidthStyle");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public double Width
		{
			get
			{
				return this.m_Width;
			}
			set
			{
				base.PropertyUpdateDefault("Width", value);
				if (this.Width != value)
				{
					this.m_Width = value;
					base.DoPropertyChange(this, "Width");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public Color TitleForeColor
		{
			get
			{
				if (this.m_TitleForeColor == Color.Empty && base.AmbientOwner != null)
				{
					return base.AmbientOwner.ForeColor;
				}
				return this.m_TitleForeColor;
			}
			set
			{
				base.PropertyUpdateDefault("TitleForeColor", value);
				if (this.TitleForeColor != value)
				{
					this.m_TitleForeColor = value;
					base.DoPropertyChange(this, "TitleForeColor");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public Color DataForeColor
		{
			get
			{
				if (this.m_DataForeColor == Color.Empty && base.AmbientOwner != null)
				{
					return base.AmbientOwner.ForeColor;
				}
				return this.m_DataForeColor;
			}
			set
			{
				base.PropertyUpdateDefault("DataForeColor", value);
				if (this.DataForeColor != value)
				{
					this.m_DataForeColor = value;
					base.DoPropertyChange(this, "DataForeColor");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Plot Legend Multi-Column Item";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLegendMultiColumnEditorPlugIn";
		}

		void IPlotLegendMultiColumnItem.Calculate(PaintArgs p, PlotObjectCollection channels)
		{
			this.Calculate(p, channels);
		}

		void IPlotLegendMultiColumnItem.Draw(PaintArgs p, PlotObjectCollection channels, Rectangle r)
		{
			this.Draw(p, channels, r);
		}

		public PlotLegendMultiColumnItem()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_DataFill = new PlotFill();
			base.AddSubClass(this.DataFill);
			this.I_DataFill = this.DataFill;
			this.m_TitleFill = new PlotFill();
			base.AddSubClass(this.TitleFill);
			this.I_TitleFill = this.TitleFill;
			this.m_DataLayout = new TextLayoutHorizontal();
			base.AddSubClass(this.DataLayout);
			this.I_DataLayout = this.DataLayout;
			this.m_TitleLayout = new TextLayoutHorizontal();
			base.AddSubClass(this.TitleLayout);
			this.I_TitleLayout = this.TitleLayout;
		}

		protected override void SetDefaults()
		{
			this.DataType = PlotLegendMultiColumnItemType.XLast;
			this.TitleText = "Untitled";
			this.TitleVisible = true;
			this.TitleForeColor = Color.Empty;
			this.WidthStyle = SizeStyle.Auto;
			this.Width = 3.0;
			this.DataForeColor = Color.Empty;
			this.DataFill.Visible = false;
			this.TitleFill.Visible = false;
		}

		private bool ShouldSerializeDataFill()
		{
			return ((ISubClassBase)this.DataFill).ShouldSerialize();
		}

		private void ResetDataFill()
		{
			((ISubClassBase)this.DataFill).ResetToDefault();
		}

		private bool ShouldSerializeTitleFill()
		{
			return ((ISubClassBase)this.TitleFill).ShouldSerialize();
		}

		private void ResetTitleFill()
		{
			((ISubClassBase)this.TitleFill).ResetToDefault();
		}

		private bool ShouldSerializeTitleLayout()
		{
			return ((ISubClassBase)this.TitleLayout).ShouldSerialize();
		}

		private void ResetTitleLayout()
		{
			((ISubClassBase)this.TitleLayout).ResetToDefault();
		}

		private bool ShouldSerializeDataLayout()
		{
			return ((ISubClassBase)this.DataLayout).ShouldSerialize();
		}

		private void ResetDataLayout()
		{
			((ISubClassBase)this.DataLayout).ResetToDefault();
		}

		private bool ShouldSerializeDataType()
		{
			return base.PropertyShouldSerialize("DataType");
		}

		private void ResetDataType()
		{
			base.PropertyReset("DataType");
		}

		private bool ShouldSerializeTitleText()
		{
			return base.PropertyShouldSerialize("TitleText");
		}

		private void ResetTitleText()
		{
			base.PropertyReset("TitleText");
		}

		private bool ShouldSerializeTitleVisible()
		{
			return base.PropertyShouldSerialize("TitleVisible");
		}

		private void ResetTitleVisible()
		{
			base.PropertyReset("TitleVisible");
		}

		private bool ShouldSerializeWidthStyle()
		{
			return base.PropertyShouldSerialize("WidthStyle");
		}

		private void ResetWidthStyle()
		{
			base.PropertyReset("WidthStyle");
		}

		private bool ShouldSerializeWidth()
		{
			return base.PropertyShouldSerialize("Width");
		}

		private void ResetWidth()
		{
			base.PropertyReset("Width");
		}

		private bool ShouldSerializeTitleForeColor()
		{
			return base.PropertyShouldSerialize("TitleForeColor");
		}

		private void ResetTitleForeColor()
		{
			base.PropertyReset("TitleForeColor");
		}

		private bool ShouldSerializeDataForeColor()
		{
			return base.PropertyShouldSerialize("DataForeColor");
		}

		private void ResetDataForeColor()
		{
			base.PropertyReset("DataForeColor");
		}

		public override string ToString()
		{
			return this.TitleText;
		}

		private void Calculate(PaintArgs p, PlotObjectCollection channels)
		{
			this.m_DrawPixelsTextWidth = 0;
			this.m_DrawPixelsHeightTitle = 0;
			this.m_DrawPixelsHeightData = 0;
			if (this.TitleVisible)
			{
				this.m_DrawPixelsHeightTitle = p.Graphics.MeasureString(this.TitleText, this.m_DrawDataFont).Height;
			}
			if (this.m_WidthStyle == SizeStyle.FixedCharacters)
			{
				this.m_DrawPixelsTextWidth = (int)Math.Ceiling((double)p.Graphics.MeasureString(this.m_DrawTitleFont).Width * this.Width);
			}
			else if (this.m_WidthStyle == SizeStyle.FixedPixels)
			{
				this.m_DrawPixelsTextWidth = (int)Math.Ceiling(this.Width);
			}
			else if (this.m_WidthStyle == SizeStyle.Auto)
			{
				this.m_DrawPixelsTextWidth = (int)Math.Ceiling((double)p.Graphics.MeasureString(this.m_DrawTitleFont).Width * this.Width);
				if (this.TitleVisible)
				{
					this.m_DrawPixelsTextWidth = Math.Max(this.m_DrawPixelsTextWidth, this.I_TitleLayout.GetRequiredSize(this.TitleText, this.m_DrawTitleFont, p.Graphics).Width);
				}
			}
			string s = "";
			foreach (PlotChannelBase channel in channels)
			{
				if (this.DataType != 0)
				{
					if (this.DataType == PlotLegendMultiColumnItemType.ChannelTitle)
					{
						s = channel.DisplayDescription;
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.DataPointCount)
					{
						s = channel.Count.ToString();
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.DataCursorX)
					{
						s = channel.GetXValueText(channel.DataCursorX);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.DataCursorY)
					{
						s = channel.GetYValueText(channel.DataCursorY);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.XFirst)
					{
						s = channel.GetXValueText(channel.XFirst);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.XLast)
					{
						s = channel.GetXValueText(channel.XLast);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.XMax)
					{
						s = channel.GetXValueText(channel.XMax);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.XMean)
					{
						s = channel.GetXValueText(channel.XMean);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.XMin)
					{
						s = channel.GetXValueText(channel.XMin);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.XStandardDeviation)
					{
						s = channel.GetXValueText(channel.XStandardDeviation);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.YFirst)
					{
						s = channel.GetYValueText(channel.YFirst);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.YLast)
					{
						s = channel.GetYValueText(channel.YLast);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.YMax)
					{
						s = channel.GetYValueText(channel.YMax);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.YMean)
					{
						s = channel.GetYValueText(channel.YMean);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.YMin)
					{
						s = channel.GetYValueText(channel.YMin);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.YStandardDeviation)
					{
						s = channel.GetYValueText(channel.YStandardDeviation);
					}
					Size requiredSize = this.I_DataLayout.GetRequiredSize(s, this.m_DrawDataFont, p.Graphics);
					if (this.m_WidthStyle == SizeStyle.Auto)
					{
						this.m_DrawPixelsTextWidth = Math.Max(this.m_DrawPixelsTextWidth, requiredSize.Width);
					}
					this.m_DrawPixelsHeightData = requiredSize.Height;
					continue;
				}
				this.m_DrawPixelsTextWidth = Math.Max(this.m_DrawPixelsTextWidth, this.m_DrawPixelsMarkerMinWidth);
				this.m_DrawPixelsHeightData = this.m_DrawPixelsMarkerMinWidth;
				break;
			}
		}

		private void Draw(PaintArgs p, PlotObjectCollection channels, Rectangle r)
		{
			Rectangle r2 = new Rectangle(r.Left, r.Top, r.Width, this.m_DrawPixelsHeightTitle + 2 * this.m_DrawPixelsMarginOuter);
			Rectangle r3 = new Rectangle(r.Left, r2.Bottom, r.Width, r.Height - r2.Height);
			this.I_TitleFill.Draw(p, r2);
			this.I_DataFill.Draw(p, r3);
			string s = "";
			int num = 0;
			int x = r3.Left + this.m_DrawPixelsMarginOuter;
			int num2 = this.m_DrawPixelsHeightData + 2 * this.m_DrawPixelsMarginOuter;
			int width = r3.Width - 2 * this.m_DrawPixelsMarginOuter;
			if (this.TitleVisible)
			{
				Rectangle r4 = new Rectangle(x, r2.Top + this.m_DrawPixelsMarginOuter, width, this.m_DrawPixelsHeightTitle);
				this.I_TitleLayout.Draw(p.Graphics, this.m_DrawTitleFont, p.Graphics.Brush(this.TitleForeColor), this.TitleText, r4);
			}
			foreach (PlotChannelBase channel in channels)
			{
				Rectangle r4 = new Rectangle(x, r3.Top + num * num2 + this.m_DrawPixelsMarginOuter, width, this.m_DrawPixelsHeightData);
				if (this.DataType == PlotLegendMultiColumnItemType.Marker)
				{
					((IPlotChannelBase)channel).DrawLegendMarker(p, r4);
					num++;
				}
				else
				{
					if (this.DataType == PlotLegendMultiColumnItemType.ChannelTitle)
					{
						s = channel.DisplayDescription;
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.DataPointCount)
					{
						s = channel.Count.ToString();
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.DataCursorX)
					{
						s = channel.GetXValueText(channel.DataCursorX);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.DataCursorY)
					{
						s = channel.GetYValueText(channel.DataCursorY);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.XFirst)
					{
						s = channel.GetXValueText(channel.XFirst);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.XLast)
					{
						s = channel.GetXValueText(channel.XLast);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.XMax)
					{
						s = channel.GetXValueText(channel.XMax);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.XMean)
					{
						s = channel.GetXValueText(channel.XMean);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.XMin)
					{
						s = channel.GetXValueText(channel.XMin);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.XStandardDeviation)
					{
						s = channel.GetXValueText(channel.XStandardDeviation);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.YFirst)
					{
						s = channel.GetYValueText(channel.YFirst);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.YLast)
					{
						s = channel.GetYValueText(channel.YLast);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.YMax)
					{
						s = channel.GetYValueText(channel.YMax);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.YMean)
					{
						s = channel.GetYValueText(channel.YMean);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.YMin)
					{
						s = channel.GetYValueText(channel.YMin);
					}
					else if (this.DataType == PlotLegendMultiColumnItemType.YStandardDeviation)
					{
						s = channel.GetYValueText(channel.YStandardDeviation);
					}
					this.I_DataLayout.Draw(p.Graphics, this.m_DrawDataFont, p.Graphics.Brush(this.DataForeColor), s, r4);
					if (this.DataType == PlotLegendMultiColumnItemType.ChannelTitle)
					{
						channel.LegendRectangle = r4;
						if (channel.Focused && !channel.LegendRectangle.IsEmpty)
						{
							p.Graphics.DrawFocusRectangle(r4, base.BackColor);
						}
					}
					num++;
				}
			}
		}
	}
}
