using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Contains the properties that control the appearance for the indicator.")]
	public class Indicator : SubClassBase
	{
		private Color m_ColorActive;

		private Color m_ColorInactive;

		private bool m_ColorInactiveAuto;

		[Description("Specifies the indicator color when the switch value is true.")]
		[RefreshProperties(RefreshProperties.All)]
		public Color ColorActive
		{
			get
			{
				return this.m_ColorActive;
			}
			set
			{
				base.PropertyUpdateDefault("ColorActive", value);
				if (this.ColorActive != value)
				{
					this.m_ColorActive = value;
					base.DoPropertyChange(this, "ColorActive");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the indicator color when the switch value is false.")]
		public Color ColorInactive
		{
			get
			{
				return this.m_ColorInactive;
			}
			set
			{
				base.PropertyUpdateDefault("ColorInactive", value);
				if (this.ColorInactive != value)
				{
					this.m_ColorInactive = value;
					base.DoPropertyChange(this, "ColorInactive");
				}
			}
		}

		[Description("Indicates if the inactive color is automatically calculated.")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ColorInactiveAuto
		{
			get
			{
				return this.m_ColorInactiveAuto;
			}
			set
			{
				base.PropertyUpdateDefault("ColorInactiveAuto", value);
				if (this.ColorInactiveAuto != value)
				{
					this.m_ColorInactiveAuto = value;
					base.DoPropertyChange(this, "ColorInactiveAuto");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Indicator";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.IndicatorEditorPlugIn";
		}

		public Indicator()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeColorActive()
		{
			return base.PropertyShouldSerialize("ColorActive");
		}

		private void ResetColorActive()
		{
			base.PropertyReset("ColorActive");
		}

		private bool ShouldSerializeColorInactive()
		{
			return base.PropertyShouldSerialize("ColorInactive");
		}

		private void ResetColorInactive()
		{
			base.PropertyReset("ColorInactive");
		}

		private bool ShouldSerializeColorInactiveAuto()
		{
			return base.PropertyShouldSerialize("ColorInactiveAuto");
		}

		private void ResetColorInactiveAuto()
		{
			base.PropertyReset("ColorInactiveAuto");
		}

		public Color GetStateColor(bool value)
		{
			if (value)
			{
				return this.ColorActive;
			}
			if (this.ColorInactiveAuto)
			{
				return iColors.ToOffColor(this.ColorActive);
			}
			return this.ColorInactive;
		}
	}
}
