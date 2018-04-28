using Iocomp.Interfaces;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Controls the scale's major tick properties.")]
	public sealed class ScaleTickMajor : ScaleTickLabel, IScaleTickBase, IScaleTickLabel, IScaleTickMajor
	{
		protected override string GetPlugInTitle()
		{
			return "Scale Tick Major";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleTickMajorEditorPlugIn";
		}

		public ScaleTickMajor()
		{
			base.DoCreate();
		}
	}
}
