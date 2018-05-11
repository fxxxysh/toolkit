namespace Iocomp.Classes
{
	public class PlotDataPointDigital : PlotDataPointBase
	{
		private bool m_Y;

		public bool Y
		{
			get
			{
				return this.m_Y;
			}
			set
			{
				if (this.m_Y != value)
				{
					this.m_Y = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public PlotDataPointDigital(PlotChannelBase channel)
			: base(channel)
		{
		}
	}
}
