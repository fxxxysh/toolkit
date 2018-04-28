using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor Pointer")]
	public class PlotLegendWrapping : SubClassBase
	{
		private bool m_Enabled;

		private double m_Margin;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool Enabled
		{
			get
			{
				return this.m_Enabled;
			}
			set
			{
				base.PropertyUpdateDefault("Enabled", value);
				if (this.Enabled != value)
				{
					this.m_Enabled = value;
					base.DoPropertyChange(this, "Enabled");
				}
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

		public PlotLegendWrapping()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Enabled = true;
			this.Margin = 2.0;
		}

		private bool ShouldSerializeEnabled()
		{
			return base.PropertyShouldSerialize("Enabled");
		}

		private void ResetEnabled()
		{
			base.PropertyReset("Enabled");
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
