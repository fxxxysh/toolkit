namespace Iocomp.Classes
{
	public class PlotChannelSweepIntervalAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelSweepInterval this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotChannelSweepInterval;
			}
		}

		public PlotChannelSweepInterval this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotChannelSweepInterval;
			}
		}

		public PlotChannelSweepIntervalAccessor(PlotChannelBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
