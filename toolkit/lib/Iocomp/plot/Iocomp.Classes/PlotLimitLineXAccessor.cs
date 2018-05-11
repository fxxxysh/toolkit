namespace Iocomp.Classes
{
	public class PlotLimitLineXAccessor
	{
		private PlotLimitBaseCollection m_Collection;

		public PlotLimitLineX this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotLimitLineX;
			}
		}

		public PlotLimitLineX this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotLimitLineX;
			}
		}

		public PlotLimitLineXAccessor(PlotLimitBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
