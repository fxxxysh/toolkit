using System;

namespace Iocomp.Classes
{
	public abstract class PlotDataPointBase
	{
		protected PlotChannelBase m_CH;

		private double m_X;

		private bool m_Null;

		private bool m_Empty;

		public double X
		{
			get
			{
				return this.m_X;
			}
			set
			{
				if (this.m_X != value)
				{
					this.m_X = value;
					this.m_CH.DoDataChange();
				}
			}
		}

		public bool Null
		{
			get
			{
				return this.m_Null;
			}
			set
			{
				if (this.m_Null != value)
				{
					this.m_Null = value;
					this.m_CH.DoDataChange();
				}
			}
		}

		public bool Empty
		{
			get
			{
				return this.m_Empty;
			}
			set
			{
				if (this.m_Empty != value)
				{
					this.m_Empty = value;
					this.m_CH.DoDataChange();
				}
			}
		}

		public PlotDataPointBase(PlotChannelBase channel)
		{
			if (channel == null)
			{
				throw new Exception("Channel must be specified");
			}
			this.m_CH = channel;
		}
	}
}
