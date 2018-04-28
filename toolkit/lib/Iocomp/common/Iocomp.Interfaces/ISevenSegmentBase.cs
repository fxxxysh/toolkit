namespace Iocomp.Interfaces
{
	public interface ISevenSegmentBase
	{
		ISegment7 Segment
		{
			get;
		}

		int DigitSpacing
		{
			get;
			set;
		}

		IOutline Outline
		{
			get;
		}
	}
}
