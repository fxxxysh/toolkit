namespace Iocomp.Classes
{
	public class PlotDataCursorChannelsAccessor
	{
		private PlotDataCursorBaseCollection m_Collection;

		public PlotDataCursorChannels this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotDataCursorChannels;
			}
		}

		public PlotDataCursorChannels this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotDataCursorChannels;
			}
		}

		public PlotDataCursorChannelsAccessor(PlotDataCursorBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
