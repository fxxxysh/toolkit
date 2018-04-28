using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotSorterLayer : IComparer
	{
		int IComparer.Compare(object x, object y)
		{
			PlotObject plotObject = x as PlotObject;
			PlotObject plotObject2 = y as PlotObject;
			if (plotObject == null)
			{
				throw new Exception("x is not a PlotObject object");
			}
			if (plotObject2 == null)
			{
				throw new Exception("y is not a PlotObject object");
			}
			return plotObject.LayerWithSubLevel.CompareTo(plotObject2.LayerWithSubLevel);
		}
	}
}
