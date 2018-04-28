using Iocomp.Types;
using System.Drawing;

namespace Iocomp.Interfaces
{
	public interface IScaleTickLabel : IScaleTickBase
	{
		Font Font
		{
			get;
			set;
		}

		Color ForeColor
		{
			get;
			set;
		}

		string Text
		{
			get;
			set;
		}

		bool TextVisible
		{
			get;
			set;
		}

		int TextMargin
		{
			get;
			set;
		}

		Size TextSize
		{
			get;
			set;
		}

		Size TextMaxSize
		{
			get;
			set;
		}

		Size TextAlignmentSize
		{
			get;
			set;
		}

		StackingDimension StackingDimension
		{
			get;
			set;
		}
	}
}
