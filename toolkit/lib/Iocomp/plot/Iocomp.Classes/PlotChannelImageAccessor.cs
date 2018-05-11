namespace Iocomp.Classes
{
	public class PlotChannelImageAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelImage this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotChannelImage;
			}
		}

		public PlotChannelImage this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotChannelImage;
			}
		}

		public PlotChannelImageAccessor(PlotChannelBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
