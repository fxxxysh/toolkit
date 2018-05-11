using Iocomp.Classes;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IAnnotationBase
	{
		double Rotation
		{
			get;
			set;
		}

		bool CanMove
		{
			get;
			set;
		}

		bool CanSize
		{
			get;
			set;
		}

		ScaleAnnotation Scale
		{
			get;
			set;
		}

		void Draw(PaintArgs p, Color grabHandleDisabledColor);
	}
}
