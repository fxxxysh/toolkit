using System;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public class GetMouseCursorEventArgs : EventArgs
	{
		private Cursor m_Cursor;

		public Cursor Cursor
		{
			get
			{
				return this.m_Cursor;
			}
			set
			{
				this.m_Cursor = value;
			}
		}

		public GetMouseCursorEventArgs(Cursor cursor)
		{
			this.m_Cursor = cursor;
		}
	}
}
