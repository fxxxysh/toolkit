namespace Iocomp.Classes
{
	public class PlotChannelCandlestick1Accessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelCandlestick1 this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotChannelCandlestick1;
			}
		}

		public PlotChannelCandlestick1 this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotChannelCandlestick1;
			}
		}

		public PlotChannelCandlestick1Accessor(PlotChannelBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
