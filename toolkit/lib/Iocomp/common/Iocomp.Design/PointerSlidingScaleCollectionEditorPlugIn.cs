using Iocomp.Classes;
using System;
using System.ComponentModel;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("code")]
	public class PointerSlidingScaleCollectionEditorPlugIn : PlugInCollection
	{
		protected override Type[] Types => new Type[1]
		{
			typeof(PointerSlidingScale)
		};

		public PointerSlidingScaleCollectionEditorPlugIn()
		{
			base.Title = "Pointer Collection Editor";
		}

		protected override PlugInStandard[] CreatePlugInPool()
		{
			return new PlugInStandard[1]
			{
				new PointerSlidingScaleEditorPlugIn()
			};
		}

		protected override PlugInStandard GetClassPlugIn(object value)
		{
			if (value is PointerSlidingScale)
			{
				return base.PlugInPool[0];
			}
			return null;
		}

		protected override int GetPlugInIndex(object value)
		{
			if (value is PointerSlidingScale)
			{
				return 0;
			}
			return 0;
		}
	}
}
