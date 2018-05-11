namespace Iocomp.Classes
{
	public class PlotDataCursorXYAccessor
	{
		private PlotDataCursorBaseCollection m_Collection;

		public PlotDataCursorXY this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotDataCursorXY;
			}
		}

		public PlotDataCursorXY this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotDataCursorXY;
			}
		}

		public PlotDataCursorXYAccessor(PlotDataCursorBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
