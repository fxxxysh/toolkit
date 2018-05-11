using Iocomp.Instrumentation.Plotting;

namespace Iocomp.Interfaces
{
	public interface IPlotObject
	{
		bool Visible
		{
			get;
			set;
		}

		bool Enabled
		{
			get;
			set;
		}

		string Name
		{
			get;
			set;
		}

		Plot Plot
		{
			get;
			set;
		}
	}
}
