namespace Iocomp.Classes
{
	public class PlotLimitBandYAccessor
	{
		private PlotLimitBaseCollection m_Collection;

		public PlotLimitBandY this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotLimitBandY;
			}
		}

		public PlotLimitBandY this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotLimitBandY;
			}
		}

		public PlotLimitBandYAccessor(PlotLimitBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
