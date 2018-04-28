namespace Iocomp.Classes
{
	public class PlotChannelRationalAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelRational this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotChannelRational;
			}
		}

		public PlotChannelRational this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotChannelRational;
			}
		}

		public PlotChannelRationalAccessor(PlotChannelBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
