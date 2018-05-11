namespace Iocomp.Interfaces
{
	public interface IScaleRangeAngular
	{
		double AngleMin
		{
			get;
			set;
		}

		double AngleSpan
		{
			get;
			set;
		}

		double AngleMax
		{
			get;
		}

		double ValueToAngle(double value);

		double PercentToAngle(double value);

		double ValueToSpanAngle(double value);

		double PercentToSpanAngle(double value);

		double AngleToValue(double value);
	}
}
