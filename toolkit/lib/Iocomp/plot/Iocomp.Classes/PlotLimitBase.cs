using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Limit Base.")]
	public abstract class PlotLimitBase : PlotXYAxisReferenceBase
	{
		private bool m_UserCanMove;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public new Color Color
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.Color = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool UserCanMove
		{
			get
			{
				return this.m_UserCanMove;
			}
			set
			{
				base.PropertyUpdateDefault("UserCanMove", value);
				if (this.UserCanMove != value)
				{
					this.m_UserCanMove = value;
					base.DoPropertyChange(this, "UserCanMove");
				}
			}
		}

		private Color SolidColor => this.Color;

		private Color HatchForeColor => this.Color;

		private Color HatchBackColor
		{
			get
			{
				if (this.ControlBase != null)
				{
					return this.ControlBase.BackColor;
				}
				return Color.Empty;
			}
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.Color = Color.Red;
			this.UserCanMove = false;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.ClippingStyle = PlotClippingStyle.DataView;
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeUserCanMove()
		{
			return base.PropertyShouldSerialize("UserCanMove");
		}

		private void ResetUserCanMove()
		{
			base.PropertyReset("UserCanMove");
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (shouldFocus)
			{
				base.Focus();
			}
		}
	}
}
