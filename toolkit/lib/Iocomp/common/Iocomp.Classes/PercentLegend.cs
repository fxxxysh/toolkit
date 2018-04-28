using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	public sealed class PercentLegend : SubClassBase, IPercentLegend
	{
		private const int m_ColorBarWidth = 15;

		private double m_Margin;

		private double m_TitleMargin;

		private double m_RowSpacing;

		private PercentLegendColumn m_ColumnValue;

		private PercentLegendColumn m_ColumnPercent;

		private Rectangle m_RectColorBar;

		private Rectangle m_RectTitle;

		private Rectangle m_RectValue;

		private Rectangle m_RectPercent;

		private int m_MarginPixels;

		private int m_RowHeightPixels;

		private int m_RowSpacingPixels;

		private int m_RowTotalHeightPixels;

		private int m_TotalHeight;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PercentLegendColumn ColumnValue
		{
			get
			{
				return this.m_ColumnValue;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PercentLegendColumn ColumnPercent
		{
			get
			{
				return this.m_ColumnPercent;
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
		[Description("")]
		public double Margin
		{
			get
			{
				return this.m_Margin;
			}
			set
			{
				base.PropertyUpdateDefault("Margin", value);
				if (this.Margin != value)
				{
					this.m_Margin = value;
					base.DoPropertyChange(this, "Margin");
				}
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double RowSpacing
		{
			get
			{
				return this.m_RowSpacing;
			}
			set
			{
				base.PropertyUpdateDefault("RowSpacing", value);
				if (this.RowSpacing != value)
				{
					this.m_RowSpacing = value;
					base.DoPropertyChange(this, "RowSpacing");
				}
			}
		}

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

		[Description("")]
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

		protected override string GetPlugInTitle()
		{
			return "Legend";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PercentLegendEditorPlugIn";
		}

		Size IPercentLegend.GetRequiredSize(PaintArgs p, PercentItemCollection items)
		{
			return this.GetRequiredSize(p, items);
		}

		void IPercentLegend.Draw(PaintArgs p, PercentItemCollection items, Rectangle r)
		{
			this.Draw(p, items, r);
		}

		public PercentLegend()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_ColumnValue = new PercentLegendColumn();
			base.AddSubClass(this.ColumnValue);
			this.m_ColumnPercent = new PercentLegendColumn();
			base.AddSubClass(this.ColumnPercent);
		}

		private bool ShouldSerializeColumnValue()
		{
			return ((ISubClassBase)this.ColumnValue).ShouldSerialize();
		}

		private void ResetColumnValue()
		{
			((ISubClassBase)this.ColumnValue).ResetToDefault();
		}

		private bool ShouldSerializeColumnPercent()
		{
			return ((ISubClassBase)this.ColumnPercent).ShouldSerialize();
		}

		private void ResetColumnPercent()
		{
			((ISubClassBase)this.ColumnPercent).ResetToDefault();
		}

		private bool ShouldSerializeFont()
		{
			return base.PropertyShouldSerialize("Font");
		}

		private void ResetFont()
		{
			base.PropertyReset("Font");
		}

		private bool ShouldSerializeMargin()
		{
			return base.PropertyShouldSerialize("Margin");
		}

		private void ResetMargin()
		{
			base.PropertyReset("Margin");
		}

		private bool ShouldSerializeTitleMargin()
		{
			return base.PropertyShouldSerialize("TitleMargin");
		}

		private void ResetTitleMargin()
		{
			base.PropertyReset("TitleMargin");
		}

		private bool ShouldSerializeRowSpacing()
		{
			return base.PropertyShouldSerialize("RowSpacing");
		}

		private void ResetRowSpacing()
		{
			base.PropertyReset("RowSpacing");
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeForeColor()
		{
			return base.PropertyShouldSerialize("ForeColor");
		}

		private void ResetForeColor()
		{
			base.PropertyReset("ForeColor");
		}

		private void CalcRects(PaintArgs p, PercentItemCollection items)
		{
			int height = p.Graphics.MeasureString("0", this.Font).Height;
			int width = p.Graphics.MeasureString("0", this.Font, true).Width;
			this.m_MarginPixels = (int)((double)p.Graphics.MeasureString("0", this.Font, true).Width * this.Margin);
			this.m_RowHeightPixels = height;
			this.m_RowSpacingPixels = (int)((double)height * this.RowSpacing);
			this.m_RowTotalHeightPixels = this.m_RowHeightPixels + this.m_RowSpacingPixels;
			int num = (int)(this.TitleMargin * (double)width);
			int num2 = (int)(this.ColumnPercent.Margin * (double)width);
			int num3 = (int)(this.ColumnValue.Margin * (double)width);
			this.m_TotalHeight = this.m_RowHeightPixels * items.Count + this.m_RowSpacingPixels * (items.Count - 1);
			int width2 = 15;
			int requiredWidth = ((IPercentLegendColumn)this.ColumnValue).GetRequiredWidth(p, this.Font, items, true);
			int requiredWidth2 = ((IPercentLegendColumn)this.ColumnPercent).GetRequiredWidth(p, this.Font, items, false);
			int num4 = 0;
			foreach (PercentItem item in items)
			{
				num4 = Math.Max(p.Graphics.MeasureString(item.Title, this.Font, true).Width, num4);
			}
			this.m_RectColorBar = new Rectangle(this.m_MarginPixels, 0, width2, height);
			this.m_RectTitle = new Rectangle(this.m_RectColorBar.Right + num, 0, num4, height);
			this.m_RectValue = new Rectangle(this.m_RectTitle.Right + num3, 0, requiredWidth - num3, height);
			this.m_RectPercent = new Rectangle(this.m_RectValue.Right + num2, 0, requiredWidth2 - num2, height);
		}

		private Size GetRequiredSize(PaintArgs p, PercentItemCollection items)
		{
			if (!this.Visible)
			{
				return Size.Empty;
			}
			this.CalcRects(p, items);
			return new Size(this.m_RectPercent.Right, this.m_TotalHeight);
		}

		private void Draw(PaintArgs p, PercentItemCollection items, Rectangle r)
		{
			if (this.Visible)
			{
				this.CalcRects(p, items);
				int num = r.Top + (r.Height - this.m_TotalHeight) / 2;
				Brush brush = p.Graphics.Brush(this.ForeColor);
				DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
				genericTypographic.Alignment = StringAlignment.Near;
				DrawStringFormat genericTypographic2 = DrawStringFormat.GenericTypographic;
				genericTypographic2.Alignment = StringAlignment.Far;
				DrawStringFormat genericTypographic3 = DrawStringFormat.GenericTypographic;
				genericTypographic3.Alignment = StringAlignment.Far;
				this.m_RectColorBar.X = r.Left + this.m_RectColorBar.Left;
				this.m_RectTitle.X = r.Left + this.m_RectTitle.Left;
				this.m_RectValue.X = r.Left + this.m_RectValue.Left;
				this.m_RectPercent.X = r.Left + this.m_RectPercent.Left;
				foreach (PercentItem item in items)
				{
					this.m_RectColorBar.Y = num;
					this.m_RectTitle.Y = num;
					this.m_RectValue.Y = num;
					this.m_RectPercent.Y = num;
					string text = this.ColumnValue.Format.GetText(item.Value);
					string text2 = this.ColumnPercent.Format.GetText(items.GetItemPercent(item) * 100.0);
					p.Graphics.FillRectangle(new SolidBrush(item.Color), this.m_RectColorBar);
					p.Graphics.DrawString(item.Title, this.Font, brush, this.m_RectTitle, genericTypographic);
					if (this.ColumnValue.Visible)
					{
						p.Graphics.DrawString(text, this.Font, brush, this.m_RectValue, genericTypographic2);
					}
					if (this.ColumnPercent.Visible)
					{
						p.Graphics.DrawString(text2, this.Font, brush, this.m_RectPercent, genericTypographic3);
					}
					num += this.m_RowTotalHeightPixels;
				}
			}
		}
	}
}
