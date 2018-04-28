using Iocomp.Classes;
using System;
using System.ComponentModel;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("code")]
	public class PlotLegendBaseCollectionEditorPlugIn : PlugInCollection
	{
		protected override Type[] Types => new Type[3]
		{
			typeof(PlotLegendBasic),
			typeof(PlotLegendMultiColumn),
			typeof(PlotLegendChannelImage)
		};

		public PlotLegendBaseCollectionEditorPlugIn()
		{
			base.Title = "Plot Legend Collection Editor";
		}

		protected override PlugInStandard[] CreatePlugInPool()
		{
			return new PlugInStandard[3]
			{
				new PlotLegendBasicEditorPlugIn(),
				new PlotLegendMultiColumnEditorPlugIn(),
				new PlotLegendChannelImageEditorPlugIn()
			};
		}

		protected override PlugInStandard GetClassPlugIn(object value)
		{
			if (value is PlotLegendBasic)
			{
				return base.PlugInPool[0];
			}
			if (value is PlotLegendMultiColumn)
			{
				return base.PlugInPool[1];
			}
			if (value is PlotLegendChannelImage)
			{
				return base.PlugInPool[2];
			}
			return null;
		}

		protected override int GetPlugInIndex(object value)
		{
			if (value is PlotLegendBasic)
			{
				return 0;
			}
			if (value is PlotLegendMultiColumn)
			{
				return 1;
			}
			if (value is PlotLegendChannelImage)
			{
				return 2;
			}
			return 3;
		}
	}
}
