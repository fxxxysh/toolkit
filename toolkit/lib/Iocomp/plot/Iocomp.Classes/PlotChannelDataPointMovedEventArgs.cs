using System;

namespace Iocomp.Classes
{
	public class PlotChannelDataPointMovedEventArgs : EventArgs
	{
		private PlotChannelBase m_Channel;

		private int m_Index;

		private double m_OldX;

		private double m_OldY;

		private double m_NewX;

		private double m_NewY;

		public PlotChannelBase Channel => this.m_Channel;

		public int Index => this.m_Index;

		public double OldX => this.m_OldX;

		public double OldY => this.m_OldY;

		public double NewX => this.m_NewX;

		public double NewY => this.m_NewY;

		public PlotChannelDataPointMovedEventArgs(PlotChannelBase channel, int index, double oldX, double oldY, double newX, double newY)
		{
			this.m_Channel = channel;
			this.m_Index = index;
			this.m_OldX = oldX;
			this.m_OldY = oldY;
			this.m_NewX = newX;
			this.m_NewY = newY;
		}
	}
}
