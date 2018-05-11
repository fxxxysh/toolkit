using System;

namespace Iocomp.Classes
{
	public class TypeEventArgs : EventArgs
	{
		private Type m_Type;

		public Type Type => this.m_Type;

		public TypeEventArgs(Type value)
		{
			this.m_Type = value;
		}
	}
}
