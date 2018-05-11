namespace Iocomp.Classes
{
	public class PlotAnnotationPolygonAccessor
	{
		private PlotAnnotationBaseCollection m_Collection;

		public PlotAnnotationPolygon this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotAnnotationPolygon;
			}
		}

		public PlotAnnotationPolygon this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotAnnotationPolygon;
			}
		}

		public PlotAnnotationPolygonAccessor(PlotAnnotationBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
