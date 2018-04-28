using System;

namespace Iocomp.Classes
{
	public class PropertyChangedEventArgs : EventArgs
	{
		private string m_Name;

		public string Name => this.m_Name;

		public PropertyChangedEventArgs(string name)
		{
			this.m_Name = name;
		}
	}
}
