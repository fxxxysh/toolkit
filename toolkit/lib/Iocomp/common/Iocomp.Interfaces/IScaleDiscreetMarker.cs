using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IScaleDiscreetMarker
	{
		void Draw(PaintArgs p, Point centerPoint, Color backColor);
	}
}
