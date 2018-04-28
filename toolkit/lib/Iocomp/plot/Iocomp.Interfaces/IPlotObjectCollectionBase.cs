using Iocomp.Classes;

namespace Iocomp.Interfaces
{
	public interface IPlotObjectCollectionBase
	{
		void HandleObjectRenamed(PlotObject value, string oldName);

		void NotifyAllObjectRenamed(PlotObject value, string oldName);

		void NotifyAllObjectRemoved(PlotObject value);

		void NotifyAllObjectAdded(PlotObject value);
	}
}
