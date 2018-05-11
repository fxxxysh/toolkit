using System;

namespace Iocomp.Interfaces
{
	public interface IUpdateRate
	{
		DateTime LastRepaintTime
		{
			get;
			set;
		}

		double FrameRate
		{
			get;
			set;
		}

		bool Active
		{
			get;
			set;
		}

		bool Needed
		{
			get;
			set;
		}

		void InvalidateControl();
	}
}
