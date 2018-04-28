namespace Iocomp.Classes
{
	public class PlotLimitPolyBandAccessor
	{
		private PlotLimitBaseCollection m_Collection;

		public PlotLimitPolyBand this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotLimitPolyBand;
			}
		}

		public PlotLimitPolyBand this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotLimitPolyBand;
			}
		}

		public PlotLimitPolyBandAccessor(PlotLimitBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
