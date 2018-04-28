namespace Iocomp.Classes
{
	public class PlotChannelFillAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelFill this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotChannelFill;
			}
		}

		public PlotChannelFill this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotChannelFill;
			}
		}

		public PlotChannelFillAccessor(PlotChannelBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
