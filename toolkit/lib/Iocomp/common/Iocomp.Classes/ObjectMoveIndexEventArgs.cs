using System;

namespace Iocomp.Classes
{
	public class ObjectMoveIndexEventArgs : EventArgs
	{
		private object m_Instance;

		private int m_OldIndex;

		private int m_NewIndex;

		public object Instance => this.m_Instance;

		public int OldIndex => this.m_OldIndex;

		public int NewIndex => this.m_NewIndex;

		public ObjectMoveIndexEventArgs(object instance, int oldIndex, int newIndex)
		{
			this.m_Instance = instance;
			this.m_OldIndex = oldIndex;
			this.m_NewIndex = newIndex;
		}
	}
}
