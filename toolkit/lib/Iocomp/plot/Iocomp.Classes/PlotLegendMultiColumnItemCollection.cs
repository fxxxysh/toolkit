using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLegendMultiColumnItemCollection : CollectionBase
	{
		public PlotLegendMultiColumnItem this[int index]
		{
			get
			{
				return base.List[index] as PlotLegendMultiColumnItem;
			}
			set
			{
				base.List[index] = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Gradient Color Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.GradientColorCollectionEditorPlugIn";
		}

		public PlotLegendMultiColumnItemCollection()
			: base(null)
		{
		}

		public PlotLegendMultiColumnItemCollection(IComponentBase componentBase)
			: base(componentBase)
		{
		}

		public void CopyTo(PlotLegendMultiColumnItem[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PlotLegendMultiColumnItem value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PlotLegendMultiColumnItem value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(PlotLegendMultiColumnItem value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PlotLegendMultiColumnItem value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PlotLegendMultiColumnItem value)
		{
			return base.List.Contains(value);
		}
	}
}
