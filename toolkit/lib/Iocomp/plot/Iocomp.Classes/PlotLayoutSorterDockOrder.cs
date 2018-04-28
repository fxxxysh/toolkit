using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLayoutSorterDockOrder : IComparer
	{
		int IComparer.Compare(object x, object y)
		{
			PlotLayoutBase plotLayoutBase = x as PlotLayoutBase;
			PlotLayoutBase plotLayoutBase2 = y as PlotLayoutBase;
			if (plotLayoutBase == null)
			{
				throw new Exception("x is not a PlotLayoutBase object");
			}
			if (plotLayoutBase2 == null)
			{
				throw new Exception("y is not a PlotLayoutBase object");
			}
			return plotLayoutBase.DockOrder.CompareTo(plotLayoutBase2.DockOrder);
		}
	}
}
