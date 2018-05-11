using System;
using System.Drawing.Printing;

namespace Iocomp.Classes
{
	public class PrintEventArgs : EventArgs
	{
		private PrintDocument m_PrintDocument;

		public PrintDocument PrintDocument => this.m_PrintDocument;

		public PrintEventArgs(PrintDocument value)
		{
			this.m_PrintDocument = value;
		}
	}
}
