using System;
using System.Drawing;

namespace Iocomp.Classes
{
	public class PlotDataViewZoomBoxEventArgs : EventArgs
	{
		private Rectangle m_Rectangle;

		private bool m_Cancel;

		private PlotDataView m_DataView;

		public PlotDataView DataView => this.m_DataView;

		public Rectangle Rectangle => this.m_Rectangle;

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

		public PlotDataViewZoomBoxEventArgs(PlotDataView dataView, Rectangle r)
		{
			this.m_DataView = dataView;
			this.m_Rectangle = r;
			this.m_Cancel = false;
		}
	}
}
