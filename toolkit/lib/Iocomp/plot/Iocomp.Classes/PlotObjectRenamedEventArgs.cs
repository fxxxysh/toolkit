using System;

namespace Iocomp.Classes
{
	public class PlotObjectRenamedEventArgs : EventArgs
	{
		private PlotObject m_Object;

		private string m_OldName;

		public PlotObject Object => this.m_Object;

		public string OldName => this.m_OldName;

		public PlotObjectRenamedEventArgs(PlotObject value, string oldName)
		{
			this.m_Object = value;
			this.m_OldName = oldName;
		}
	}
}
