using Iocomp.Classes;
using System;
using System.ComponentModel;

namespace Iocomp.Design
{
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	public class PlotTableBaseCollectionEditorPlugIn : PlugInCollection
	{
		protected override Type[] Types => new Type[2]
		{
			typeof(PlotTableGrid),
			typeof(PlotTableChannel)
		};

		public PlotTableBaseCollectionEditorPlugIn()
		{
			base.Title = "Plot Table Collection Editor";
		}

		protected override PlugInStandard[] CreatePlugInPool()
		{
			return new PlugInStandard[2]
			{
				new PlotTableGridEditorPlugIn(),
				new PlotTableChannelEditorPlugIn()
			};
		}

		protected override PlugInStandard GetClassPlugIn(object value)
		{
			if (value is PlotTableGrid)
			{
				return base.PlugInPool[0];
			}
			if (value is PlotTableChannel)
			{
				return base.PlugInPool[1];
			}
			return null;
		}

		protected override int GetPlugInIndex(object value)
		{
			if (value is PlotTableGrid)
			{
				return 0;
			}
			if (value is PlotTableChannel)
			{
				return 1;
			}
			return 0;
		}
	}
}
