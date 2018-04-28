using Iocomp.Classes;
using System;
using System.ComponentModel;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("code")]
	public class PercentItemCollectionEditorPlugIn : PlugInCollection
	{
		protected override Type[] Types => new Type[1]
		{
			typeof(PercentItem)
		};

		public PercentItemCollectionEditorPlugIn()
		{
			base.Title = "Item Collection Editor";
		}

		protected override PlugInStandard[] CreatePlugInPool()
		{
			return new PlugInStandard[1]
			{
				new PercentItemEditorPlugIn()
			};
		}

		protected override PlugInStandard GetClassPlugIn(object value)
		{
			if (value is PercentItem)
			{
				return base.PlugInPool[0];
			}
			return null;
		}

		protected override int GetPlugInIndex(object value)
		{
			if (value is PercentItem)
			{
				return 0;
			}
			return 0;
		}
	}
}
