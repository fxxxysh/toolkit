namespace Iocomp.Classes
{
	public class PlotChannelBiFillAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelBiFill this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotChannelBiFill;
			}
		}

		public PlotChannelBiFill this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotChannelBiFill;
			}
		}

		public PlotChannelBiFillAccessor(PlotChannelBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
