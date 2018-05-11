using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class ValueBooleanEventArgs : EventArgs
	{
		private bool m_ValueOld;

		private bool m_ValueNew;

		private bool m_Cancel;

		private EventSource m_Source;

		public bool ValueOld => this.m_ValueOld;

		public bool ValueNew
		{
			get
			{
				return this.m_ValueNew;
			}
			set
			{
				this.m_ValueNew = value;
			}
		}

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

		public EventSource Source => this.m_Source;

		public ValueBooleanEventArgs(bool valueOld, bool valueNew, bool cancel, EventSource source)
		{
			this.m_ValueOld = valueOld;
			this.m_ValueNew = valueNew;
			this.m_Cancel = cancel;
			this.m_Source = source;
		}
	}
}
