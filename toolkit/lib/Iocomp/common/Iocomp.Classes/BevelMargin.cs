using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Controls the border layout properties.")]
	public class BevelMargin : Bevel
	{
		private int m_Margin;

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the bevel margin.")]
		public int Margin
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

		protected override int InternalMargin => this.Margin;

		protected override string GetPlugInTitle()
		{
			return "Bevel";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.BevelMarginEditorPlugIn";
		}

		public BevelMargin()
		{
			base.DoCreate();
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
