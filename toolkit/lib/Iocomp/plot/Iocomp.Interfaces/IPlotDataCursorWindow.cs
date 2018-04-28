using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IPlotDataCursorWindow
	{
		Region HitRegion
		{
			get;
			set;
		}

		void Draw(PaintArgs p, Point centerPoint);
	}
}
