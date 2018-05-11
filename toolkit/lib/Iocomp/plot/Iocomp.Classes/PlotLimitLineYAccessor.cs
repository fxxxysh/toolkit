namespace Iocomp.Classes
{
	public class PlotLimitLineYAccessor
	{
		private PlotLimitBaseCollection m_Collection;

		public PlotLimitLineY this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotLimitLineY;
			}
		}

		public PlotLimitLineY this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotLimitLineY;
			}
		}

		public PlotLimitLineYAccessor(PlotLimitBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
