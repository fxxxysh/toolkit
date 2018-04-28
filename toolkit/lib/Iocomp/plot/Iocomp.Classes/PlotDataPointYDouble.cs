namespace Iocomp.Classes
{
	public abstract class PlotDataPointYDouble : PlotDataPointBase
	{
		private double m_Y;

		public double Y
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

		public PlotDataPointYDouble(PlotChannelBase channel)
			: base(channel)
		{
		}
	}
}
