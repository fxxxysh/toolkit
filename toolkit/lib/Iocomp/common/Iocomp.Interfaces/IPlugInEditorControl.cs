namespace Iocomp.Interfaces
{
	public interface IPlugInEditorControl
	{
		string PropertyName
		{
			get;
			set;
		}

		IPlugInStandard PlugInForm
		{
			get;
			set;
		}

		bool IsReadOnly
		{
			get;
		}

		bool IsValid
		{
			get;
		}

		void UploadDisplay(object value);

		void TransferAmbient(object source, object destination);

		bool GetIsDisplayDirty(object original);
	}
}
