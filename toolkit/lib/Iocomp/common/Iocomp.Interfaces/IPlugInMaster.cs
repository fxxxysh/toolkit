using Iocomp.Design;

namespace Iocomp.Interfaces
{
	public interface IPlugInMaster
	{
		int TabPageBorderSize
		{
			get;
		}

		int TabPageDockMargin
		{
			get;
		}

		int TabHeight
		{
			get;
		}

		object OriginalInstance
		{
			get;
		}

		void ForceDirtyUpdate(PlugInStandard value);

		void ForceApplyButtonEnabled(PlugInStandard value);

		void UpdateExtents(PlugInStandard plugIn);

		void UpdateExtents(int width, int height);
	}
}
