using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("")]
	public sealed class ScaleGeneratorFixed : ScaleGeneratorBase
	{
		private int m_MajorCount;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int MajorCount
		{
			get
			{
				return this.m_MajorCount;
			}
			set
			{
				base.PropertyUpdateDefault("MajorCount", value);
				if (value < 2)
				{
					base.ThrowStreamingSafeException("MajorCount value must be 2 or greater.");
				}
				if (value < 2)
				{
					value = 2;
				}
				if (this.MajorCount != value)
				{
					this.m_MajorCount = value;
					base.DoPropertyChange(this, "MajorCount");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Scale Generator Fixed";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleGeneratorFixedEditorPlugIn";
		}

		public ScaleGeneratorFixed()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeMajorCount()
		{
			return base.PropertyShouldSerialize("MajorCount");
		}

		private void ResetMajorCount()
		{
			base.PropertyReset("MajorCount");
		}

		protected override void InitializeTickInfo(ScaleTickInfo tickInfo)
		{
			base.InitializeTickInfo(tickInfo);
			tickInfo.MajorCount = this.MajorCount;
			tickInfo.MajorStepSize = tickInfo.Span / (double)(this.MajorCount - 1);
			tickInfo.MinorStepSize = tickInfo.MajorStepSize / (double)(base.MinorCount + 1);
			tickInfo.StartStandard = tickInfo.Min;
			tickInfo.MinTextSpacing = 0.0;
		}
	}
}
