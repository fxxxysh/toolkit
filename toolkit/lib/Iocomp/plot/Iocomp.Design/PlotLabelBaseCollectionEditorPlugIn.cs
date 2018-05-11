using Iocomp.Classes;
using System;
using System.ComponentModel;

namespace Iocomp.Design
{
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	public class PlotLabelBaseCollectionEditorPlugIn : PlugInCollection
	{
		protected override Type[] Types => new Type[1]
		{
			typeof(PlotLabelBasic)
		};

		public PlotLabelBaseCollectionEditorPlugIn()
		{
			base.Title = "Plot Label Collection Editor";
		}

		protected override PlugInStandard[] CreatePlugInPool()
		{
			return new PlugInStandard[1]
			{
				new PlotLabelBasicEditorPlugIn()
			};
		}

		protected override PlugInStandard GetClassPlugIn(object value)
		{
			if (value is PlotLabelBasic)
			{
				return base.PlugInPool[0];
			}
			return null;
		}

		protected override int GetPlugInIndex(object value)
		{
			if (value is PlotLabelBasic)
			{
				return 0;
			}
			return 0;
		}
	}
}
