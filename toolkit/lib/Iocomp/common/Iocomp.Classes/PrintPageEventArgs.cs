using System;
using System.Drawing.Printing;

namespace Iocomp.Classes
{
	public class PrintPageEventArgs : EventArgs
	{
		private PrintDocument m_PrintDocument;

		private int m_PageNumber;

		private bool m_HasMorePages;

		public PrintDocument PrintDocument => this.m_PrintDocument;

		public int PageNumber => this.m_PageNumber;

		public bool HasMorePages
		{
			get
			{
				return this.m_HasMorePages;
			}
			set
			{
				this.m_HasMorePages = value;
			}
		}

		public PrintPageEventArgs(PrintDocument value, int pageNumber)
		{
			this.m_PrintDocument = value;
			this.m_PageNumber = pageNumber;
		}
	}
}
