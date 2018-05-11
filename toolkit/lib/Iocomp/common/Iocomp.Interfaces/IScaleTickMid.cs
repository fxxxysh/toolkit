using Iocomp.Types;

namespace Iocomp.Interfaces
{
	public interface IScaleTickMid : IScaleTickBase, IScaleTickLabel
	{
		AlignmentStyle Alignment
		{
			get;
			set;
		}
	}
}
