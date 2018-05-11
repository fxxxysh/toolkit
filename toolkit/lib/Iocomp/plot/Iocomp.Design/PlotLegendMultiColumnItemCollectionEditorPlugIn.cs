using Iocomp.Classes;
using System;
using System.ComponentModel;

namespace Iocomp.Design
{
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	public class PlotLegendMultiColumnItemCollectionEditorPlugIn : PlugInCollection
	{
		protected override Type[] Types => new Type[1]
		{
			typeof(PlotLegendMultiColumnItem)
		};

		public PlotLegendMultiColumnItemCollectionEditorPlugIn()
		{
			base.Title = "Plot Legend Multi-Column Item Collection Editor";
		}

		protected override PlugInStandard[] CreatePlugInPool()
		{
			return new PlugInStandard[1]
			{
				new PlotLegendMultiColumnItemPlugIn()
			};
		}

		protected override PlugInStandard GetClassPlugIn(object value)
		{
			if (value is PlotLegendMultiColumnItem)
			{
				return base.PlugInPool[0];
			}
			return null;
		}

		protected override int GetPlugInIndex(object value)
		{
			if (value is PlotLegendMultiColumnItem)
			{
				return 0;
			}
			return 0;
		}
	}
}
