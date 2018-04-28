using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface ITextLayoutFull : ITextLayoutBase
	{
		StringTrimming Trimming
		{
			get;
			set;
		}

		bool LineLimit
		{
			get;
			set;
		}

		bool MeasureTrailingSpaces
		{
			get;
			set;
		}

		bool NoWrap
		{
			get;
			set;
		}

		bool NoClip
		{
			get;
			set;
		}
	}
}
