using System;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public class SaveDialogEventArgs : EventArgs
	{
		private SaveFileDialog m_SaveDialog;

		public SaveFileDialog SaveDialog => this.m_SaveDialog;

		public SaveDialogEventArgs(SaveFileDialog value)
		{
			this.m_SaveDialog = value;
		}
	}
}
