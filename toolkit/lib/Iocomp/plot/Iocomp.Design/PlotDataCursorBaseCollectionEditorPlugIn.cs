using Iocomp.Classes;
using System;
using System.ComponentModel;

namespace Iocomp.Design
{
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	public class PlotDataCursorBaseCollectionEditorPlugIn : PlugInCollection
	{
		protected override Type[] Types => new Type[3]
		{
			typeof(PlotDataCursorChannel),
			typeof(PlotDataCursorChannels),
			typeof(PlotDataCursorXY)
		};

		public PlotDataCursorBaseCollectionEditorPlugIn()
		{
			base.Title = "Plot Data Cursor Collection Editor";
		}

		protected override PlugInStandard[] CreatePlugInPool()
		{
			return new PlugInStandard[3]
			{
				new PlotDataCursorChannelEditorPlugIn(),
				new PlotDataCursorChannelsEditorPlugIn(),
				new PlotDataCursorXYEditorPlugIn()
			};
		}

		protected override PlugInStandard GetClassPlugIn(object value)
		{
			if (value is PlotDataCursorChannel)
			{
				return base.PlugInPool[0];
			}
			if (value is PlotDataCursorChannels)
			{
				return base.PlugInPool[1];
			}
			if (value is PlotDataCursorXY)
			{
				return base.PlugInPool[2];
			}
			return null;
		}

		protected override int GetPlugInIndex(object value)
		{
			if (value is PlotDataCursorChannel)
			{
				return 0;
			}
			if (value is PlotDataCursorChannels)
			{
				return 1;
			}
			if (value is PlotDataCursorXY)
			{
				return 2;
			}
			return 0;
		}
	}
}
