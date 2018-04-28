using Iocomp.Classes;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Interfaces
{
	public interface IScaleDisplayLinear : IScaleDisplay
	{
		Orientation Orientation
		{
			get;
			set;
		}

		int ClipHigh
		{
			get;
		}

		int ClipLow
		{
			get;
		}

		int PixelsHigh
		{
			get;
		}

		int PixelsLow
		{
			get;
		}

		int PixelsMin
		{
			get;
		}

		int PixelsMax
		{
			get;
		}

		int MaxDepth
		{
			get;
		}

		void DrawColorBar(PaintArgs p, double start, double stop, Color color);

		void SetClipEnds(int value1, int value2);

		void SetBoundsEnds(int value1, int value2);

		void UpdateScaleBounds();
	}
}
