using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Controls the scale's minor tick properties.")]
	public sealed class ScaleTickMinor : ScaleTickBase, IScaleTickBase, IScaleTickMinor
	{
		private AlignmentStyle m_Alignment;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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
			return "Scale Tick Minor";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleTickMinorEditorPlugIn";
		}

		public ScaleTickMinor()
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

		protected override int GetScaleWidth()
		{
			return base.Length;
		}

		protected override void Draw(PaintArgs p, DrawStringFormat format, int majorLength)
		{
			base.Display.DrawTickLine(p, this);
		}
	}
}
