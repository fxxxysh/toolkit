using Iocomp.Classes;
using Iocomp.Delegates;
using Iocomp.Types;

namespace Iocomp.Interfaces
{
	public interface ISubClassBase
	{
		bool Creating
		{
			get;
		}

		IControlBase ControlBase
		{
			get;
			set;
		}

		IComponentBase ComponentBase
		{
			get;
			set;
		}

		SubClassBaseCollection SubClassList
		{
			get;
		}

		bool SettingDefaults
		{
			get;
			set;
		}

		bool FreezePropertyChange
		{
			get;
			set;
		}

		IAmbientOwner AmbientOwner
		{
			get;
			set;
		}

		AmbientColorSouce ColorAmbientSource
		{
			get;
			set;
		}

		CollectionBase Collection
		{
			get;
			set;
		}

		event PropertyChangeEventHandler PropertyChanged;

		bool ShouldSerialize();

		void ResetToDefault();

		void ResetClone(ISubClassBase clone);
	}
}
