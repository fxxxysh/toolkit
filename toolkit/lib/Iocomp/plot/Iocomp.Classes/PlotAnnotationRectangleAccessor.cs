namespace Iocomp.Classes
{
	public class PlotAnnotationRectangleAccessor
	{
		private PlotAnnotationBaseCollection m_Collection;

		public PlotAnnotationRectangle this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotAnnotationRectangle;
			}
		}

		public PlotAnnotationRectangle this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotAnnotationRectangle;
			}
		}

		public PlotAnnotationRectangleAccessor(PlotAnnotationBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
