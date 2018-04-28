using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLayoutBlockItemDockOrderSorter : IComparer
	{
		int IComparer.Compare(object x, object y)
		{
			PlotLayoutBlockBase plotLayoutBlockBase = x as PlotLayoutBlockBase;
			PlotLayoutBlockBase plotLayoutBlockBase2 = y as PlotLayoutBlockBase;
			if (plotLayoutBlockBase == null)
			{
				throw new Exception("x is not a PlotLayoutBlockBase object");
			}
			if (plotLayoutBlockBase2 == null)
			{
				throw new Exception("y is not a PlotLayoutBlockBase object");
			}
			return plotLayoutBlockBase.Object.DockOrder.CompareTo(plotLayoutBlockBase2.Object.DockOrder);
		}
	}
}
