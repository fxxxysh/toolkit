namespace Iocomp.Classes
{
	public class PlotDataPointBubble : PlotDataPointYDouble
	{
		private double m_Radius;

		public double Radius
		{
			get
			{
				return this.m_Radius;
			}
			set
			{
				if (this.m_Radius != value)
				{
					this.m_Radius = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public PlotDataPointBubble(PlotChannelBase channel)
			: base(channel)
		{
		}
	}
}
