using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IScaleTickBase
	{
		IScaleDisplay Display
		{
			get;
			set;
		}

		double Value
		{
			get;
			set;
		}

		Color Color
		{
			get;
			set;
		}

		int Thickness
		{
			get;
			set;
		}

		int Length
		{
			get;
			set;
		}

		void Draw(PaintArgs p, DrawStringFormat format, int majorLength);

		int GetScaleWidth();
	}
}
