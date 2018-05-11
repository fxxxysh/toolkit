using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor Multiple Style Menu Items")]
	public class PlotDataCursorMultipleStyleMenuItems : SubClassBase
	{
		private bool m_ShowValueXY;

		private bool m_ShowValueX;

		private bool m_ShowValueY;

		private bool m_ShowDeltaX;

		private bool m_ShowDeltaY;

		private bool m_ShowInverseDeltaX;

		private bool m_ShowInverseDeltaY;

		private string m_CaptionValueXY;

		private string m_CaptionValueX;

		private string m_CaptionValueY;

		private string m_CaptionDeltaX;

		private string m_CaptionDeltaY;

		private string m_CaptionInverseDeltaX;

		private string m_CaptionInverseDeltaY;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ShowValueXY
		{
			get
			{
				return this.m_ShowValueXY;
			}
			set
			{
				base.PropertyUpdateDefault("ShowValueXY", value);
				if (this.ShowValueXY != value)
				{
					this.m_ShowValueXY = value;
					base.DoPropertyChange(this, "ShowValueXY");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ShowValueX
		{
			get
			{
				return this.m_ShowValueX;
			}
			set
			{
				base.PropertyUpdateDefault("ShowValueX", value);
				if (this.ShowValueX != value)
				{
					this.m_ShowValueX = value;
					base.DoPropertyChange(this, "ShowValueX");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ShowValueY
		{
			get
			{
				return this.m_ShowValueY;
			}
			set
			{
				base.PropertyUpdateDefault("ShowValueY", value);
				if (this.ShowValueY != value)
				{
					this.m_ShowValueY = value;
					base.DoPropertyChange(this, "ShowValueY");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ShowDeltaX
		{
			get
			{
				return this.m_ShowDeltaX;
			}
			set
			{
				base.PropertyUpdateDefault("ShowDeltaX", value);
				if (this.ShowDeltaX != value)
				{
					this.m_ShowDeltaX = value;
					base.DoPropertyChange(this, "ShowDeltaX");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ShowDeltaY
		{
			get
			{
				return this.m_ShowDeltaY;
			}
			set
			{
				base.PropertyUpdateDefault("ShowDeltaY", value);
				if (this.ShowDeltaY != value)
				{
					this.m_ShowDeltaY = value;
					base.DoPropertyChange(this, "ShowDeltaY");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ShowInverseDeltaX
		{
			get
			{
				return this.m_ShowInverseDeltaX;
			}
			set
			{
				base.PropertyUpdateDefault("ShowInverseDeltaX", value);
				if (this.ShowInverseDeltaX != value)
				{
					this.m_ShowInverseDeltaX = value;
					base.DoPropertyChange(this, "ShowInverseDeltaX");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ShowInverseDeltaY
		{
			get
			{
				return this.m_ShowInverseDeltaY;
			}
			set
			{
				base.PropertyUpdateDefault("ShowInverseDeltaY", value);
				if (this.ShowInverseDeltaY != value)
				{
					this.m_ShowInverseDeltaY = value;
					base.DoPropertyChange(this, "ShowInverseDeltaY");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string CaptionValueXY
		{
			get
			{
				return this.m_CaptionValueXY;
			}
			set
			{
				base.PropertyUpdateDefault("CaptionValueXY", value);
				if (this.CaptionValueXY != value)
				{
					this.m_CaptionValueXY = value;
					base.DoPropertyChange(this, "CaptionValueXY");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string CaptionValueX
		{
			get
			{
				return this.m_CaptionValueX;
			}
			set
			{
				base.PropertyUpdateDefault("CaptionValueX", value);
				if (this.CaptionValueX != value)
				{
					this.m_CaptionValueX = value;
					base.DoPropertyChange(this, "CaptionValueX");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string CaptionValueY
		{
			get
			{
				return this.m_CaptionValueY;
			}
			set
			{
				base.PropertyUpdateDefault("CaptionValueY", value);
				if (this.CaptionValueY != value)
				{
					this.m_CaptionValueY = value;
					base.DoPropertyChange(this, "CaptionValueY");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string CaptionDeltaX
		{
			get
			{
				return this.m_CaptionDeltaX;
			}
			set
			{
				base.PropertyUpdateDefault("CaptionDeltaX", value);
				if (this.CaptionDeltaX != value)
				{
					this.m_CaptionDeltaX = value;
					base.DoPropertyChange(this, "CaptionDeltaX");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string CaptionDeltaY
		{
			get
			{
				return this.m_CaptionDeltaY;
			}
			set
			{
				base.PropertyUpdateDefault("CaptionDeltaY", value);
				if (this.CaptionDeltaY != value)
				{
					this.m_CaptionDeltaY = value;
					base.DoPropertyChange(this, "CaptionDeltaY");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string CaptionInverseDeltaX
		{
			get
			{
				return this.m_CaptionInverseDeltaX;
			}
			set
			{
				base.PropertyUpdateDefault("CaptionInverseDeltaX", value);
				if (this.CaptionInverseDeltaX != value)
				{
					this.m_CaptionInverseDeltaX = value;
					base.DoPropertyChange(this, "CaptionInverseDeltaX");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string CaptionInverseDeltaY
		{
			get
			{
				return this.m_CaptionInverseDeltaY;
			}
			set
			{
				base.PropertyUpdateDefault("CaptionInverseDeltaY", value);
				if (this.CaptionInverseDeltaY != value)
				{
					this.m_CaptionInverseDeltaY = value;
					base.DoPropertyChange(this, "CaptionInverseDeltaY");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Data-Cursor Style Menu Items";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotDataCursorMultipleStyleMenuItemsEditorPlugIn";
		}

		public PlotDataCursorMultipleStyleMenuItems()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.ShowValueXY = true;
			this.ShowValueX = true;
			this.ShowValueY = true;
			this.ShowDeltaX = true;
			this.ShowDeltaY = true;
			this.ShowInverseDeltaX = true;
			this.ShowInverseDeltaY = false;
			this.CaptionValueXY = "Value-XY";
			this.CaptionValueX = "Value-X";
			this.CaptionValueY = "Value-Y";
			this.CaptionDeltaX = "Period";
			this.CaptionDeltaY = "Peak-Peak";
			this.CaptionInverseDeltaX = "Frequency";
			this.CaptionInverseDeltaY = "Inverse Delta-Y";
		}

		private bool ShouldSerializeShowValueXY()
		{
			return base.PropertyShouldSerialize("ShowValueXY");
		}

		private void ResetShowValueXY()
		{
			base.PropertyReset("ShowValueXY");
		}

		private bool ShouldSerializeShowValueX()
		{
			return base.PropertyShouldSerialize("ShowValueX");
		}

		private void ResetShowValueX()
		{
			base.PropertyReset("ShowValueX");
		}

		private bool ShouldSerializeShowValueY()
		{
			return base.PropertyShouldSerialize("ShowValueY");
		}

		private void ResetShowValueY()
		{
			base.PropertyReset("ShowValueY");
		}

		private bool ShouldSerializeShowDeltaX()
		{
			return base.PropertyShouldSerialize("ShowDeltaX");
		}

		private void ResetShowDeltaX()
		{
			base.PropertyReset("ShowDeltaX");
		}

		private bool ShouldSerializeShowDeltaY()
		{
			return base.PropertyShouldSerialize("ShowDeltaY");
		}

		private void ResetShowDeltaY()
		{
			base.PropertyReset("ShowDeltaY");
		}

		private bool ShouldSerializeShowInverseDeltaX()
		{
			return base.PropertyShouldSerialize("ShowInverseDeltaX");
		}

		private void ResetShowInverseDeltaX()
		{
			base.PropertyReset("ShowInverseDeltaX");
		}

		private bool ShouldSerializeShowInverseDeltaY()
		{
			return base.PropertyShouldSerialize("ShowInverseDeltaY");
		}

		private void ResetShowInverseDeltaY()
		{
			base.PropertyReset("ShowInverseDeltaY");
		}

		private bool ShouldSerializeCaptionValueXY()
		{
			return base.PropertyShouldSerialize("CaptionValueXY");
		}

		private void ResetCaptionValueXY()
		{
			base.PropertyReset("CaptionValueXY");
		}

		private bool ShouldSerializeCaptionValueX()
		{
			return base.PropertyShouldSerialize("CaptionValueX");
		}

		private void ResetCaptionValueX()
		{
			base.PropertyReset("CaptionValueX");
		}

		private bool ShouldSerializeCaptionValueY()
		{
			return base.PropertyShouldSerialize("CaptionValueY");
		}

		private void ResetCaptionValueY()
		{
			base.PropertyReset("CaptionValueY");
		}

		private bool ShouldSerializeCaptionDeltaX()
		{
			return base.PropertyShouldSerialize("CaptionDeltaX");
		}

		private void ResetCaptionDeltaX()
		{
			base.PropertyReset("CaptionDeltaX");
		}

		private bool ShouldSerializeCaptionDeltaY()
		{
			return base.PropertyShouldSerialize("CaptionDeltaY");
		}

		private void ResetCaptionDeltaY()
		{
			base.PropertyReset("CaptionDeltaY");
		}

		private bool ShouldSerializeCaptionInverseDeltaX()
		{
			return base.PropertyShouldSerialize("CaptionInverseDeltaX");
		}

		private void ResetCaptionInverseDeltaX()
		{
			base.PropertyReset("CaptionInverseDeltaX");
		}

		private bool ShouldSerializeCaptionInverseDeltaY()
		{
			return base.PropertyShouldSerialize("CaptionInverseDeltaY");
		}

		private void ResetCaptionInverseDeltaY()
		{
			base.PropertyReset("CaptionInverseDeltaY");
		}
	}
}
