using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Controls the scale's mid tick properties.")]
	public sealed class ScaleTickMid : ScaleTickLabel, IScaleTickBase, IScaleTickLabel, IScaleTickMid
	{
		private AlignmentStyle m_Alignment;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public AlignmentStyle Alignment
		{
			get
			{
				return this.m_Alignment;
			}
			set
			{
				base.PropertyUpdateDefault("Alignment", value);
				if (this.Alignment != value)
				{
					this.m_Alignment = value;
					base.DoPropertyChange(this, "Alignment");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Scale Tick Mid";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleTickMidEditorPlugIn";
		}

		public ScaleTickMid()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeAlignment()
		{
			return base.PropertyShouldSerialize("Alignment");
		}

		private void ResetAlignment()
		{
			base.PropertyReset("Alignment");
		}
	}
}
