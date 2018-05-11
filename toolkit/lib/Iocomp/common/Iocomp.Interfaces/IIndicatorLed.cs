using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IIndicatorLed
	{
		void Draw(PaintArgs p, Rectangle r, bool value);

		void Draw(PaintArgs p, Rectangle r, bool value, Color color, string s, Color textColorActive, Color textColorInactive);
	}
}
