using Iocomp.Classes;
using Iocomp.Types;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface ISegment7
	{
		Segment7Character ConvertChar(char value);

		Size GetRequiredSize(Segment7Character character);

		void Draw(PaintArgs p, iRectangle r, Segment7Character character);
	}
}
