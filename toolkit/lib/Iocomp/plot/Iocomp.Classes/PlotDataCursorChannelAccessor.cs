namespace Iocomp.Classes
{
	public class PlotDataCursorChannelAccessor
	{
		private PlotDataCursorBaseCollection m_Collection;

		public PlotDataCursorChannel this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotDataCursorChannel;
			}
		}

		public PlotDataCursorChannel this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotDataCursorChannel;
			}
		}

		public PlotDataCursorChannelAccessor(PlotDataCursorBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
