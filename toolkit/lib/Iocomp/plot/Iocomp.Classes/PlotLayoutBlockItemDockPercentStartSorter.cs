using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLayoutBlockItemDockPercentStartSorter : IComparer
	{
		int IComparer.Compare(object x, object y)
		{
			if (!(x is PlotLayoutBlockItem))
			{
				throw new Exception("x is not a PlotLayoutBlockItem object");
			}
			if (!(y is PlotLayoutBlockItem))
			{
				throw new Exception("y is not a PlotLayoutBlockItem object");
			}
			PlotLayoutDockableDataView plotLayoutDockableDataView = (x as PlotLayoutBlockItem).Object as PlotLayoutDockableDataView;
			PlotLayoutDockableDataView plotLayoutDockableDataView2 = (y as PlotLayoutBlockItem).Object as PlotLayoutDockableDataView;
			if (plotLayoutDockableDataView == null)
			{
				throw new Exception("x's PlotLayoutBlockItem Object is not of type PlotLayoutDockableDataView");
			}
			if (plotLayoutDockableDataView2 == null)
			{
				throw new Exception("y's PlotLayoutBlockItem Object is not of type PlotLayoutDockableDataView");
			}
			return plotLayoutDockableDataView.DockPercentStart.CompareTo(plotLayoutDockableDataView2.DockPercentStart);
		}
	}
}
