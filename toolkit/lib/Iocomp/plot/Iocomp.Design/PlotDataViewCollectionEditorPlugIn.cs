using Iocomp.Classes;
using System;
using System.ComponentModel;

namespace Iocomp.Design
{
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	public class PlotDataViewCollectionEditorPlugIn : PlugInCollection
	{
		protected override Type[] Types => new Type[1]
		{
			typeof(PlotDataView)
		};

		public PlotDataViewCollectionEditorPlugIn()
		{
			base.Title = "Data-View Collection Editor";
		}

		protected override PlugInStandard[] CreatePlugInPool()
		{
			return new PlugInStandard[1]
			{
				new PlotDataViewEditorPlugIn()
			};
		}

		protected override PlugInStandard GetClassPlugIn(object value)
		{
			if (value is PlotDataView)
			{
				return base.PlugInPool[0];
			}
			return null;
		}

		protected override int GetPlugInIndex(object value)
		{
			if (value is PlotDataView)
			{
				return 0;
			}
			return 0;
		}
	}
}
