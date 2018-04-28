namespace Iocomp.Classes
{
	public class PlotAnnotationEllipseAccessor
	{
		private PlotAnnotationBaseCollection m_Collection;

		public PlotAnnotationEllipse this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotAnnotationEllipse;
			}
		}

		public PlotAnnotationEllipse this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotAnnotationEllipse;
			}
		}

		public PlotAnnotationEllipseAccessor(PlotAnnotationBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
