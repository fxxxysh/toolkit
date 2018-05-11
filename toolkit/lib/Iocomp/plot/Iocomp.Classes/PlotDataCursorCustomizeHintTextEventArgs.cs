using System;

namespace Iocomp.Classes
{
	public class PlotDataCursorCustomizeHintTextEventArgs : EventArgs
	{
		private string m_Text;

		private PlotDataCursorBase m_DataCursor;

		public PlotDataCursorBase DataCursor => this.m_DataCursor;

		public string Text
		{
			get
			{
				return this.m_Text;
			}
			set
			{
				this.m_Text = value;
			}
		}

		public PlotDataCursorCustomizeHintTextEventArgs(PlotDataCursorBase dataCursor, string text)
		{
			this.m_DataCursor = dataCursor;
			this.m_Text = text;
		}
	}
}
