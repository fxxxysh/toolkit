using Iocomp.Classes;
using Iocomp.Types;

namespace Iocomp.Interfaces
{
	public interface IScaleDisplay
	{
		ScaleGeneratorStyle GeneratorStyle
		{
			get;
			set;
		}

		double StartRefValue
		{
			get;
			set;
		}

		bool StartRefEnabled
		{
			get;
			set;
		}

		double TextWidthMinValue
		{
			get;
			set;
		}

		bool TextWidthMinAuto
		{
			get;
			set;
		}

		bool SlidingScale
		{
			get;
			set;
		}

		bool DegreeModeEnabled
		{
			get;
			set;
		}

		int EdgeRef
		{
			get;
			set;
		}

		int PixelsSpan
		{
			get;
		}

		ScaleRange Range
		{
			get;
			set;
		}

		double MajorIncrement
		{
			get;
			set;
		}

		double MinorIncrement
		{
			get;
			set;
		}

		void Generate(PaintArgs p);

		void Draw(PaintArgs p);

		void DrawTickLabel(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format);

		void DrawTickLine(PaintArgs p, IScaleTickBase tick);

		void ClearAllNonPermanentTicks();

		bool GetValueOnScale(double value);

		ScaleTickMajor AddTickMajor(double value, bool permanent);

		ScaleTickMid AddTickMid(double value, bool permanent);

		ScaleTickMinor AddTickMinor(double value, bool permanent);
	}
}
