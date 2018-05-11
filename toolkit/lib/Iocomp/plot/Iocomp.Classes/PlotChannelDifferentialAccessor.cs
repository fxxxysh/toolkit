namespace Iocomp.Classes
{
	public class PlotChannelDifferentialAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelDifferential this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotChannelDifferential;
			}
		}

		public PlotChannelDifferential this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotChannelDifferential;
			}
		}

		public PlotChannelDifferentialAccessor(PlotChannelBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
