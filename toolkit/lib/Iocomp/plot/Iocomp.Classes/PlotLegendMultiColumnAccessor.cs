namespace Iocomp.Classes
{
	public class PlotLegendMultiColumnAccessor
	{
		private PlotLegendBaseCollection m_Collection;

		public PlotLegendMultiColumn this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotLegendMultiColumn;
			}
		}

		public PlotLegendMultiColumn this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotLegendMultiColumn;
			}
		}

		public PlotLegendMultiColumnAccessor(PlotLegendBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
