namespace Iocomp.Classes
{
	public class PlotChannelPolynomialAccessor
	{
		private PlotChannelBaseCollection m_Collection;

		public PlotChannelPolynomial this[int index]
		{
			get
			{
				return this.m_Collection[index] as PlotChannelPolynomial;
			}
		}

		public PlotChannelPolynomial this[string name]
		{
			get
			{
				return this.m_Collection[name] as PlotChannelPolynomial;
			}
		}

		public PlotChannelPolynomialAccessor(PlotChannelBaseCollection value)
		{
			this.m_Collection = value;
		}
	}
}
