using Iocomp.Classes;

namespace Iocomp.Interfaces
{
	public interface IScaleGeneratorBase
	{
		double MinorStepSize
		{
			get;
		}

		IScaleDisplay Display
		{
			get;
			set;
		}

		void Generate(PaintArgs p, ScaleTickInfo tickInfo);

		void InitializeTickInfo(ScaleTickInfo tickInfo);
	}
}
