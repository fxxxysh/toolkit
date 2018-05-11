using System;

namespace Iocomp.Classes
{
	public class PlotDataPointCandlestick2 : PlotDataPointYDouble
	{
		private PlotChannelCandlestick2 m_Channel;

		private double m_High;

		private double m_Low;

		private double m_Open;

		private double m_Close;

		public double High
		{
			get
			{
				return this.m_High;
			}
			set
			{
				if (this.m_High != value)
				{
					this.m_High = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public double Low
		{
			get
			{
				return this.m_Low;
			}
			set
			{
				if (this.m_Low != value)
				{
					this.m_Low = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public double Open
		{
			get
			{
				return this.m_Open;
			}
			set
			{
				if (this.m_Open != value)
				{
					this.m_Open = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public double Close
		{
			get
			{
				return this.m_Close;
			}
			set
			{
				if (this.m_Close != value)
				{
					this.m_Close = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public PlotDataPointCandlestick2(PlotChannelBase channel)
			: base(channel)
		{
			if (!(channel is PlotChannelCandlestick2))
			{
				throw new Exception("Invalid Channel type for PlotDataPointCandlestick2");
			}
			this.m_Channel = (channel as PlotChannelCandlestick2);
		}
	}
}
