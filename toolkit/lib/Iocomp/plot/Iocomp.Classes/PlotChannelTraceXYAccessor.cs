namespace Iocomp.Classes
{
	public class PlotChannelTraceXYAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelTraceXY this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotChannelTraceXY;
			}
		}

		public PlotChannelTraceXY this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotChannelTraceXY;
			}
		}

		public PlotChannelTraceXYAccessor(PlotChannelBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
