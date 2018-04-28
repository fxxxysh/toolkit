namespace Iocomp.Classes
{
	public class PlotChannelBarAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelBar this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotChannelBar;
			}
		}

		public PlotChannelBar this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotChannelBar;
			}
		}

		public PlotChannelBarAccessor(PlotChannelBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
