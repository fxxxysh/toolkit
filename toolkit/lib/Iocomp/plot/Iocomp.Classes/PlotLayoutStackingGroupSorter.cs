using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLayoutStackingGroupSorter : IComparer
	{
		int IComparer.Compare(object x, object y)
		{
			PlotLayoutStackingGroup plotLayoutStackingGroup = x as PlotLayoutStackingGroup;
			PlotLayoutStackingGroup plotLayoutStackingGroup2 = y as PlotLayoutStackingGroup;
			if (plotLayoutStackingGroup == null)
			{
				throw new Exception("x is not a PlotLayoutStackingGroup object");
			}
			if (plotLayoutStackingGroup2 == null)
			{
				throw new Exception("y is not a PlotLayoutStackingGroup object");
			}
			return plotLayoutStackingGroup.Index.CompareTo(plotLayoutStackingGroup2.Index);
		}
	}
}
