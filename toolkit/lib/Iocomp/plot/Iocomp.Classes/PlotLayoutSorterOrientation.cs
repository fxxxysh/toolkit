using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLayoutSorterOrientation : IComparer
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
			int num = (plotLayoutBase.DockRight || plotLayoutBase.DockTop) ? (1000000 + plotLayoutBase.DockOrder) : (-plotLayoutBase.DockOrder);
			int value = (plotLayoutBase2.DockRight || plotLayoutBase2.DockTop) ? (1000000 + plotLayoutBase2.DockOrder) : (-plotLayoutBase2.DockOrder);
			if (plotLayoutBase.DockOrientation != plotLayoutBase2.DockOrientation)
			{
				return 0;
			}
			return num.CompareTo(value);
		}
	}
}
