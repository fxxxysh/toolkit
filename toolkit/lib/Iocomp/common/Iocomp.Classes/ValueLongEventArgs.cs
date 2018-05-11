using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class ValueLongEventArgs : EventArgs
	{
		private long m_ValueOld;

		private long m_ValueNew;

		private bool m_Cancel;

		private EventSource m_Source;

		public long ValueOld => this.m_ValueOld;

		public long ValueNew
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

		public ValueLongEventArgs(long valueOld, long valueNew, bool cancel, EventSource source)
		{
			this.m_ValueOld = valueOld;
			this.m_ValueNew = valueNew;
			this.m_Cancel = cancel;
			this.m_Source = source;
		}
	}
}
