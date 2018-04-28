namespace Iocomp.Classes
{
	public class PlotChannelTraceAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelTrace this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotChannelTrace;
			}
		}

		public PlotChannelTrace this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotChannelTrace;
			}
		}

		public PlotChannelTraceAccessor(PlotChannelBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
