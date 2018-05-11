using Iocomp.Interfaces;
using System;

namespace Iocomp.Classes
{
	public class LostFocusEventArgs : EventArgs
	{
		private IUIInput m_NewFocusObject;

		private bool m_Cancel;

		public object NewFocusObject => this.m_NewFocusObject;

		public bool Cancel
		{
			get
			{
				return this.m_Cancel;
			}
			set
			{
				this.m_Cancel = value;
			}
		}

		public LostFocusEventArgs(IUIInput newFocusObject)
		{
			this.m_NewFocusObject = newFocusObject;
		}
	}
}
