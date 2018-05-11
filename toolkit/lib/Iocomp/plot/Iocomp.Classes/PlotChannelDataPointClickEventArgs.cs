using System;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public class PlotChannelDataPointClickEventArgs : EventArgs
	{
		private PlotChannelBase m_Channel;

		private MouseButtons m_Button;

		private int m_Index;

		public PlotChannelBase Channel => this.m_Channel;

		public int Index => this.m_Index;

		public MouseButtons Button => this.m_Button;

		public PlotChannelDataPointClickEventArgs(PlotChannelBase channel, MouseButtons button, int index)
		{
			this.m_Channel = channel;
			this.m_Button = button;
			this.m_Index = index;
		}
	}
}
