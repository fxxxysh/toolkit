namespace Iocomp.Classes
{
	public class PlotLabelBasicAccessor
	{
		private PlotLabelBaseCollection m_Collection;

		public PlotLabelBasic this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotLabelBasic;
			}
		}

		public PlotLabelBasic this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotLabelBasic;
			}
		}

		public PlotLabelBasicAccessor(PlotLabelBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
