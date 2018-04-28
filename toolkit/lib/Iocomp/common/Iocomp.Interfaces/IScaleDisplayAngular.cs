using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IScaleDisplayAngular : IScaleDisplay
	{
		int Radius
		{
			get;
			set;
		}

		int HubRadius
		{
			get;
			set;
		}

		Point CenterPoint
		{
			get;
			set;
		}

		Size RequiredSize
		{
			get;
		}

		Point GetScalePoint(double value, float radius);
	}
}
