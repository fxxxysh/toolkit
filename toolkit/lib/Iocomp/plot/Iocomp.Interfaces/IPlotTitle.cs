using Iocomp.Classes;
using Iocomp.Types;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IPlotTitle
	{
		AlignmentQuadSide DockSide
		{
			get;
			set;
		}

		int RequiredDepthPixels
		{
			get;
		}

		int TitleDepthPixels
		{
			get;
		}

		int SpacingPixels
		{
			get;
		}

		void Draw(PaintArgs p, Rectangle bounds);

		void CalculateDrawingData(PaintArgs p, int spanPixels);
	}
}
