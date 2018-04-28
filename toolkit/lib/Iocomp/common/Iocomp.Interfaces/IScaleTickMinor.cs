using Iocomp.Types;

namespace Iocomp.Interfaces
{
	public interface IScaleTickMinor : IScaleTickBase
	{
		AlignmentStyle Alignment
		{
			get;
			set;
		}
	}
}
