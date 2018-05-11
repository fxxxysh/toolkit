namespace Iocomp.Classes
{
	public class PlotChannelCandlestick3Accessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelCandlestick3 this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotChannelCandlestick3;
			}
		}

		public PlotChannelCandlestick3 this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotChannelCandlestick3;
			}
		}

		public PlotChannelCandlestick3Accessor(PlotChannelBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
