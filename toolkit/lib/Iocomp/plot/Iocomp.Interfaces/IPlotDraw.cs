using Iocomp.Classes;

namespace Iocomp.Interfaces
{
	public interface IPlotDraw
	{
		bool CanDraw
		{
			get;
		}

		void DrawSetup(PaintArgs p);

		void DrawCalculations(PaintArgs p);

		void Draw(PaintArgs p);

		void DrawBackgroundLayer1(PaintArgs p);

		void DrawBackgroundLayer2(PaintArgs p);

		void DrawForegroundLayer1(PaintArgs p);

		void DrawForegroundLayer2(PaintArgs p);

		void DrawFocusRectangles(PaintArgs p);

		void UpdateCanDraw(PaintArgs p);

		void UpdateBoundsClip(PaintArgs p);
	}
}
