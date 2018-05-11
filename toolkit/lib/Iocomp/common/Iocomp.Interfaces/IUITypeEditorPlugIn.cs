using System.ComponentModel;

namespace Iocomp.Interfaces
{
	public interface IUITypeEditorPlugIn
	{
		ComponentCollection Components
		{
			get;
		}

		void Upload(object value);

		void Download(object value);
	}
}
