namespace Iocomp.Interfaces
{
	public interface IComponentBase
	{
		bool Loading
		{
			get;
		}

		bool Creating
		{
			get;
		}

		bool SettingDefaults
		{
			get;
		}

		bool Designing
		{
			get;
		}

		void DoPropertyChange(object sender, string propertyName);

		void LoadingBegin();

		void LoadingEnd();

		void SetComponentDefaults();

		void ForceDesignerChange();

		void ShowEditorCustom(bool designTimeStyle, bool modal);
	}
}
