using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Controls the text alignment and positioning.")]
	public class AlignmentText : SubClassBase
	{
		private StringAlignment m_Style;

		private double m_Margin;

		[RefreshProperties(RefreshProperties.All)]
		[Description("Controls the style of the text alignment and positioning.")]
		public StringAlignment Style
		{
			get
			{
				return this.m_Style;
			}
			set
			{
				base.PropertyUpdateDefault("Style", value);
				if (this.Style != value)
				{
					this.m_Style = value;
					base.DoPropertyChange(this, "Style");
				}
			}
		}

		[Description("Controls the margin spacing of the text.")]
		[RefreshProperties(RefreshProperties.All)]
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

		protected override string GetPlugInTitle()
		{
			return "Alignment Text";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AlignmentTextEditorPlugIn";
		}

		public AlignmentText()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Style = StringAlignment.Center;
			this.Margin = 0.0;
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private bool ShouldSerializeMargin()
		{
			return base.PropertyShouldSerialize("Margin");
		}

		private void ResetMargin()
		{
			base.PropertyReset("Margin");
		}
	}
}
