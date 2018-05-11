using System;

namespace Iocomp.Classes
{
	public class ObjectEventArgs : EventArgs
	{
		private object m_Object;

		public object Object => this.m_Object;

		public ObjectEventArgs(object value)
		{
			this.m_Object = value;
		}
	}
}
