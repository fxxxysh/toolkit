namespace Iocomp.Classes
{
	public class PlotLimitBandXAccessor
	{
		private PlotLimitBaseCollection m_Collection;

		public PlotLimitBandX this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotLimitBandX;
			}
		}

		public PlotLimitBandX this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotLimitBandX;
			}
		}

		public PlotLimitBandXAccessor(PlotLimitBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
