using Iocomp.Classes;
using System;
using System.ComponentModel;

namespace Iocomp.Design
{
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	public class PlotChannelBaseCollectionEditorPlugIn : PlugInCollection
	{
		protected override Type[] Types => new Type[16]
		{
			typeof(PlotChannelBar),
			typeof(PlotChannelBiFill),
			typeof(PlotChannelBubble),
			typeof(PlotChannelCandlestick1),
			typeof(PlotChannelCandlestick2),
			typeof(PlotChannelCandlestick3),
			typeof(PlotChannelCubicSpline),
			typeof(PlotChannelDifferential),
			typeof(PlotChannelDigital),
			typeof(PlotChannelFill),
			typeof(PlotChannelImage),
			typeof(PlotChannelPolynomial),
			typeof(PlotChannelRational),
			typeof(PlotChannelSweepInterval),
			typeof(PlotChannelTrace),
			typeof(PlotChannelTraceXY)
		};

		public PlotChannelBaseCollectionEditorPlugIn()
		{
			base.Title = "Plot Channel Collection Editor";
		}

		protected override PlugInStandard[] CreatePlugInPool()
		{
			return new PlugInStandard[16]
			{
				new PlotChannelBarEditorPlugIn(),
				new PlotChannelBiFillEditorPlugIn(),
				new PlotChannelBubbleEditorPlugIn(),
				new PlotChannelCandlestick1EditorPlugIn(),
				new PlotChannelCandlestick2EditorPlugIn(),
				new PlotChannelCandlestick3EditorPlugIn(),
				new PlotChannelCubicSplineEditorPlugIn(),
				new PlotChannelDifferentialEditorPlugIn(),
				new PlotChannelDigitalEditorPlugIn(),
				new PlotChannelFillEditorPlugIn(),
				new PlotChannelImageEditorPlugIn(),
				new PlotChannelPolynomialEditorPlugIn(),
				new PlotChannelRationalEditorPlugIn(),
				new PlotChannelSweepIntervalEditorPlugIn(),
				new PlotChannelTraceEditorPlugIn(),
				new PlotChannelTraceXYEditorPlugIn()
			};
		}

		protected override PlugInStandard GetClassPlugIn(object value)
		{
			if (value is PlotChannelBar)
			{
				return base.PlugInPool[0];
			}
			if (value is PlotChannelBiFill)
			{
				return base.PlugInPool[1];
			}
			if (value is PlotChannelBubble)
			{
				return base.PlugInPool[2];
			}
			if (value is PlotChannelCandlestick1)
			{
				return base.PlugInPool[3];
			}
			if (value is PlotChannelCandlestick2)
			{
				return base.PlugInPool[4];
			}
			if (value is PlotChannelCandlestick3)
			{
				return base.PlugInPool[5];
			}
			if (value is PlotChannelCubicSpline)
			{
				return base.PlugInPool[6];
			}
			if (value is PlotChannelDifferential)
			{
				return base.PlugInPool[7];
			}
			if (value is PlotChannelDigital)
			{
				return base.PlugInPool[8];
			}
			if (value is PlotChannelFill)
			{
				return base.PlugInPool[9];
			}
			if (value is PlotChannelImage)
			{
				return base.PlugInPool[10];
			}
			if (value is PlotChannelPolynomial)
			{
				return base.PlugInPool[11];
			}
			if (value is PlotChannelRational)
			{
				return base.PlugInPool[12];
			}
			if (value is PlotChannelSweepInterval)
			{
				return base.PlugInPool[13];
			}
			if (value is PlotChannelTrace)
			{
				return base.PlugInPool[14];
			}
			if (value is PlotChannelTraceXY)
			{
				return base.PlugInPool[15];
			}
			return null;
		}

		protected override int GetPlugInIndex(object value)
		{
			if (value is PlotChannelBar)
			{
				return 0;
			}
			if (value is PlotChannelBiFill)
			{
				return 1;
			}
			if (value is PlotChannelBubble)
			{
				return 2;
			}
			if (value is PlotChannelCandlestick1)
			{
				return 3;
			}
			if (value is PlotChannelCandlestick2)
			{
				return 4;
			}
			if (value is PlotChannelCandlestick3)
			{
				return 5;
			}
			if (value is PlotChannelCubicSpline)
			{
				return 6;
			}
			if (value is PlotChannelDifferential)
			{
				return 7;
			}
			if (value is PlotChannelDigital)
			{
				return 8;
			}
			if (value is PlotChannelFill)
			{
				return 9;
			}
			if (value is PlotChannelImage)
			{
				return 10;
			}
			if (value is PlotChannelPolynomial)
			{
				return 11;
			}
			if (value is PlotChannelRational)
			{
				return 12;
			}
			if (value is PlotChannelSweepInterval)
			{
				return 13;
			}
			if (value is PlotChannelTrace)
			{
				return 14;
			}
			if (value is PlotChannelTraceXY)
			{
				return 15;
			}
			return 0;
		}
	}
}
