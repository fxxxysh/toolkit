using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Base Class for all Plot Layout objects.")]
	public class PlotLayoutBlockItem : PlotLayoutBlockBase
	{
		public PlotLayoutBlockGroup Group;

		public void TransferBoundsToLayoutObjects()
		{
			PlotLayoutBase @object = base.Object;
			@object.Bounds = base.BoundsScreen;
			@object.BoundsClip = base.BoundsClip;
		}
	}
}
