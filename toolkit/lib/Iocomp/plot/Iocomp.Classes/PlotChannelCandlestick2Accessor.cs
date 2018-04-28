namespace Iocomp.Classes
{
	public class PlotChannelCandlestick2Accessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelCandlestick2 this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotChannelCandlestick2;
			}
		}

		public PlotChannelCandlestick2 this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotChannelCandlestick2;
			}
		}

		public PlotChannelCandlestick2Accessor(PlotChannelBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
