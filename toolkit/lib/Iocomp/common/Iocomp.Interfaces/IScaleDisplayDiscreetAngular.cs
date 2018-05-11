using Iocomp.Classes;

namespace Iocomp.Interfaces
{
	public interface IScaleDisplayDiscreetAngular : IScaleDisplayDiscreet
	{
		ScaleRangeDiscreetAngular ScaleRange
		{
			get;
			set;
		}
	}
}
