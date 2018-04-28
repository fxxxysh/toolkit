using Iocomp.Classes;

namespace Iocomp.Interfaces
{
	public interface IPointerSlidingScale
	{
		int SpaceLeft
		{
			get;
		}

		int SpaceRight
		{
			get;
		}

		void Draw(PaintArgs p, int referenceY);
	}
}
