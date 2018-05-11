namespace Iocomp.Classes
{
	public class PlotChannelBubbleAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelBubble this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotChannelBubble;
			}
		}

		public PlotChannelBubble this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotChannelBubble;
			}
		}

		public PlotChannelBubbleAccessor(PlotChannelBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
