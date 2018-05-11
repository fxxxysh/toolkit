using Iocomp.Classes;
using Iocomp.Instrumentation.Plotting;

namespace Iocomp.Interfaces
{
	public interface IPlotAxisGridLines
	{
		void DrawMajors(PaintArgs p, Plot plot, PlotAxis axis);

		void DrawMinors(PaintArgs p, Plot plot, PlotAxis axis);
	}
}
