namespace Iocomp.Classes
{
	public class PlotAnnotationImageAccessor
	{
		private PlotAnnotationBaseCollection m_Collection;

		public PlotAnnotationImage this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotAnnotationImage;
			}
		}

		public PlotAnnotationImage this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotAnnotationImage;
			}
		}

		public PlotAnnotationImageAccessor(PlotAnnotationBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
