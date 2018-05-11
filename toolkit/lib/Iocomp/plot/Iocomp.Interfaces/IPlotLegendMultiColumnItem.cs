using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IPlotLegendMultiColumnItem
	{
		Font DrawTitleFont
		{
			get;
			set;
		}

		Font DrawDataFont
		{
			get;
			set;
		}

		int DrawPixelsMarginOuter
		{
			get;
			set;
		}

		int DrawPixelsMarkerMinWidth
		{
			get;
			set;
		}

		int DrawPixelsTextWidth
		{
			get;
			set;
		}

		int DrawPixelsHeightTitle
		{
			get;
			set;
		}

		int DrawPixelsHeightData
		{
			get;
			set;
		}

		void Calculate(PaintArgs p, PlotObjectCollection channels);

		void Draw(PaintArgs p, PlotObjectCollection channels, Rectangle r);
	}
}
