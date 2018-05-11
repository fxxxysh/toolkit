using Iocomp.Classes;
using System;
using System.ComponentModel;

namespace Iocomp.Design
{
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	public class PlotYAxisCollectionEditorPlugIn : PlugInCollection
	{
		protected override Type[] Types => new Type[1]
		{
			typeof(PlotYAxis)
		};

		public PlotYAxisCollectionEditorPlugIn()
		{
			base.Title = "Plot Y-Axis Collection Editor";
		}

		protected override PlugInStandard[] CreatePlugInPool()
		{
			return new PlugInStandard[1]
			{
				new PlotAxisEditorPlugIn()
			};
		}

		protected override PlugInStandard GetClassPlugIn(object value)
		{
			if (value is PlotAxis)
			{
				return base.PlugInPool[0];
			}
			return null;
		}

		protected override int GetPlugInIndex(object value)
		{
			if (value is PlotAxis)
			{
				return 0;
			}
			return 0;
		}
	}
}
