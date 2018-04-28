using Iocomp.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Controls the percent legend column layout properties.")]
	public sealed class PercentLegendColumn : SubClassBase, IPercentLegendColumn
	{
		private double m_Margin;

		private TextFormatDouble m_Format;

		private double m_WidthMin;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public TextFormatDouble Format
		{
			get
			{
				return this.m_Format;
			}
		}

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
		public double WidthMin
		{
			get
			{
				return this.m_WidthMin;
			}
			set
			{
				base.PropertyUpdateDefault("WidthMin", value);
				if (this.WidthMin != value)
				{
					this.m_WidthMin = value;
					base.DoPropertyChange(this, "WidthMin");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Legend Column";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PercentLegendColumnEditorPlugIn";
		}

		int IPercentLegendColumn.GetRequiredWidth(PaintArgs p, Font font, PercentItemCollection items, bool isValue)
		{
			return this.GetRequiredWidth(p, font, items, isValue);
		}

		public PercentLegendColumn()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Format = new TextFormatDouble();
			base.AddSubClass(this.Format);
		}

		private bool ShouldSerializeFormat()
		{
			return ((ISubClassBase)this.Format).ShouldSerialize();
		}

		private void ResetFormat()
		{
			((ISubClassBase)this.Format).ResetToDefault();
		}

		private bool ShouldSerializeMargin()
		{
			return base.PropertyShouldSerialize("Margin");
		}

		private void ResetMargin()
		{
			base.PropertyReset("Margin");
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeWidthMin()
		{
			return base.PropertyShouldSerialize("WidthMin");
		}

		private void ResetWidthMin()
		{
			base.PropertyReset("WidthMin");
		}

		private int GetRequiredWidth(PaintArgs p, Font font, PercentItemCollection items, bool isValue)
		{
			if (!this.Visible)
			{
				return 0;
			}
			int num = (int)((double)p.Graphics.MeasureString("0", font, true).Width * this.WidthMin);
			int num2 = (int)((double)p.Graphics.MeasureString("0", font, true).Width * this.Margin);
			foreach (PercentItem item in items)
			{
				string text = (!isValue) ? this.Format.GetText(items.GetItemPercent(item) * 100.0) : this.Format.GetText(item.Value);
				int width = p.Graphics.MeasureString(text, font, true).Width;
				if (width > num)
				{
					num = width;
				}
			}
			return num + num2;
		}
	}
}
