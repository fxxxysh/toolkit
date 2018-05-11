namespace Iocomp.Classes
{
	public class PlotLegendChannelImageAccessor
	{
		private PlotLegendBaseCollection m_Collection;

		public PlotLegendChannelImage this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotLegendChannelImage;
			}
		}

		public PlotLegendChannelImage this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotLegendChannelImage;
			}
		}

		public PlotLegendChannelImageAccessor(PlotLegendBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
