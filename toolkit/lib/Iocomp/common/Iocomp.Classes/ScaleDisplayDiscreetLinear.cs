using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Controls the scale display layout properties.")]
	public sealed class ScaleDisplayDiscreetLinear : ScaleDisplayDiscreet
	{
		private SideDirection m_Direction;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public SideDirection Direction
		{
			get
			{
				return this.m_Direction;
			}
			set
			{
				base.PropertyUpdateDefault("Direction", value);
				if (this.Direction != value)
				{
					this.m_Direction = value;
					base.DoPropertyChange(this, "Direction");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Scale Display";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleDisplayDiscreetLinearEditorPlugIn";
		}

		public ScaleDisplayDiscreetLinear()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeDirection()
		{
			return base.PropertyShouldSerialize("Direction");
		}

		private void ResetDirection()
		{
			base.PropertyReset("Direction");
		}

		protected override void Calculate(PaintArgs p, ScaleDiscreetItemCollection items, Point centerPoint, int activeIndex, int pointerExtent)
		{
		}

		protected override void Draw(PaintArgs p, ScaleDiscreetItemCollection items, Point centerPoint, int activeIndex, Color backColor)
		{
		}
	}
}
