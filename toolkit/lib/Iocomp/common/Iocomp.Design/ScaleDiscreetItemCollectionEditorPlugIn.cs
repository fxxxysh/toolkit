using Iocomp.Classes;
using System;
using System.ComponentModel;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("code")]
	public class ScaleDiscreetItemCollectionEditorPlugIn : PlugInCollection
	{
		protected override Type[] Types => new Type[1]
		{
			typeof(ScaleDiscreetItem)
		};

		public ScaleDiscreetItemCollectionEditorPlugIn()
		{
			base.Title = "Item Collection Editor";
		}

		protected override PlugInStandard[] CreatePlugInPool()
		{
			return new PlugInStandard[1]
			{
				new ScaleDiscreetItemEditorPlugIn()
			};
		}

		protected override PlugInStandard GetClassPlugIn(object value)
		{
			if (value is ScaleDiscreetItem)
			{
				return base.PlugInPool[0];
			}
			return null;
		}

		protected override int GetPlugInIndex(object value)
		{
			if (value is ScaleDiscreetItem)
			{
				return 0;
			}
			return 0;
		}
	}
}
