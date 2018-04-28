using Iocomp.Classes;
using System;
using System.ComponentModel;

namespace Iocomp.Design
{
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	public class PlotLimitBaseCollectionEditorPlugIn : PlugInCollection
	{
		protected override Type[] Types => new Type[5]
		{
			typeof(PlotLimitBandX),
			typeof(PlotLimitBandY),
			typeof(PlotLimitLineX),
			typeof(PlotLimitLineY),
			typeof(PlotLimitPolyBand)
		};

		public PlotLimitBaseCollectionEditorPlugIn()
		{
			base.Title = "Plot Limit Collection Editor";
		}

		protected override PlugInStandard[] CreatePlugInPool()
		{
			return new PlugInStandard[5]
			{
				new PlotLimitBandXEditorPlugIn(),
				new PlotLimitBandYEditorPlugIn(),
				new PlotLimitLineXEditorPlugIn(),
				new PlotLimitLineYEditorPlugIn(),
				new PlotLimitPolyBandEditorPlugIn()
			};
		}

		protected override PlugInStandard GetClassPlugIn(object value)
		{
			if (value is PlotLimitBandX)
			{
				return base.PlugInPool[0];
			}
			if (value is PlotLimitBandY)
			{
				return base.PlugInPool[1];
			}
			if (value is PlotLimitLineX)
			{
				return base.PlugInPool[2];
			}
			if (value is PlotLimitLineY)
			{
				return base.PlugInPool[3];
			}
			if (value is PlotLimitPolyBand)
			{
				return base.PlugInPool[4];
			}
			return null;
		}

		protected override int GetPlugInIndex(object value)
		{
			if (value is PlotLimitBandX)
			{
				return 0;
			}
			if (value is PlotLimitBandY)
			{
				return 1;
			}
			if (value is PlotLimitLineX)
			{
				return 2;
			}
			if (value is PlotLimitLineY)
			{
				return 3;
			}
			if (value is PlotLimitPolyBand)
			{
				return 4;
			}
			return 0;
		}
	}
}
