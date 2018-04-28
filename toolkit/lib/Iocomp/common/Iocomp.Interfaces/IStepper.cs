using Iocomp.Types;

namespace Iocomp.Interfaces
{
	public interface IStepper
	{
		void StopStep(DirectionState stepState);

		void StartStep(DirectionState stepState);
	}
}
