namespace Iocomp.Interfaces
{
	public interface IScaleRangeLinear
	{
		int ValueToPixels(double value);

		int ValueToPixels(double value, bool clamped);

		double ValueToPercent(double value, bool clamped);

		double ValueSpanToPercent(double value);

		int PercentToPixels(double value, bool clamped);

		double PercentToValue(double value, bool clamped);

		double PercentSpanToValue(double value);

		double PixelsToValue(int value);

		double PixelSpanToValue(int value);

		double PixelSpanToPercent(int value);

		double PixelsToPercent(int value);

		int ValueToSpanPixels(double value);

		int PercentToSpanPixels(double value);

		void SetBounds(int pixelsMin, int pixelsMax);
	}
}
