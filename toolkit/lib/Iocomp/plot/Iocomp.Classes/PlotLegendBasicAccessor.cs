namespace Iocomp.Classes
{
	public class PlotLegendBasicAccessor
	{
		private PlotLegendBaseCollection m_Collection;

		public PlotLegendBasic this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotLegendBasic;
			}
		}

		public PlotLegendBasic this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotLegendBasic;
			}
		}

		public PlotLegendBasicAccessor(PlotLegendBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
