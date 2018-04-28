namespace Iocomp.Classes
{
	public class PlotAnnotationPieAccessor
	{
		private PlotAnnotationBaseCollection m_Collection;

		public PlotAnnotationPie this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotAnnotationPie;
			}
		}

		public PlotAnnotationPie this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotAnnotationPie;
			}
		}

		public PlotAnnotationPieAccessor(PlotAnnotationBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
