using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Contains properties to control the user interface characteristics.")]
	public class UIControl : SubClassBase
	{
		private bool m_KeyboardEnabled;

		private bool m_MouseWheelEnabled;

		private bool m_FocusRectangleShow;

		[Description("Determines if user keyboard control is enabled.")]
		[RefreshProperties(RefreshProperties.All)]
		public bool KeyboardEnabled
		{
			get
			{
				return this.m_KeyboardEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("KeyboardEnabled", value);
				if (this.KeyboardEnabled != value)
				{
					this.m_KeyboardEnabled = value;
					base.DoPropertyChange(this, "KeyboardEnabled");
				}
			}
		}

		[Description("Determines if the user can manipulate the control with the mouse wheel.")]
		[RefreshProperties(RefreshProperties.All)]
		public bool MouseWheelEnabled
		{
			get
			{
				return this.m_MouseWheelEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("MouseWheelEnabled", value);
				if (this.MouseWheelEnabled != value)
				{
					this.m_MouseWheelEnabled = value;
					base.DoPropertyChange(this, "MouseWheelEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Determines if the focus rectangle is drawn when the control has the keyboard focus.")]
		public bool FocusRectangleShow
		{
			get
			{
				return this.m_FocusRectangleShow;
			}
			set
			{
				base.PropertyUpdateDefault("FocusRectangleShow", value);
				if (this.FocusRectangleShow != value)
				{
					this.m_FocusRectangleShow = value;
					base.DoPropertyChange(this, "FocusRectangleShow");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "UI Control";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.UIControlEditorPlugIn";
		}

		public UIControl()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeKeyboardEnabled()
		{
			return base.PropertyShouldSerialize("KeyboardEnabled");
		}

		private void ResetKeyboardEnabled()
		{
			base.PropertyReset("KeyboardEnabled");
		}

		private bool ShouldSerializeMouseWheelEnabled()
		{
			return base.PropertyShouldSerialize("MouseWheelEnabled");
		}

		private void ResetMouseWheelEnabled()
		{
			base.PropertyReset("MouseWheelEnabled");
		}

		private bool ShouldSerializeFocusRectangleShow()
		{
			return base.PropertyShouldSerialize("FocusRectangleShow");
		}

		private void ResetFocusRectangleShow()
		{
			base.PropertyReset("FocusRectangleShow");
		}
	}
}
