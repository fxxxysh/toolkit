using Iocomp.Classes;
using System;
using System.ComponentModel;

namespace Iocomp.Design
{
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	public class ColorSectionCollectionEditorPlugIn : PlugInCollection
	{
		protected override Type[] Types => new Type[1]
		{
			typeof(ColorSection)
		};

		public ColorSectionCollectionEditorPlugIn()
		{
			base.Title = "Color Section Collection Editor";
		}

		protected override PlugInStandard[] CreatePlugInPool()
		{
			return new PlugInStandard[1]
			{
				new ColorSectionEditorPlugIn()
			};
		}

		protected override PlugInStandard GetClassPlugIn(object value)
		{
			if (value is ColorSection)
			{
				return base.PlugInPool[0];
			}
			return null;
		}

		protected override int GetPlugInIndex(object value)
		{
			if (value is ColorSection)
			{
				return 0;
			}
			return 0;
		}
	}
}
