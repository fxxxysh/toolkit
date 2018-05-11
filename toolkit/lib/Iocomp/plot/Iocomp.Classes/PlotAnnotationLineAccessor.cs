namespace Iocomp.Classes
{
	public class PlotAnnotationLineAccessor
	{
		private PlotAnnotationBaseCollection m_Collection;

		public PlotAnnotationLine this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotAnnotationLine;
			}
		}

		public PlotAnnotationLine this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotAnnotationLine;
			}
		}

		public PlotAnnotationLineAccessor(PlotAnnotationBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
