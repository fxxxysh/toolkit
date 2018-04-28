using Iocomp.Interfaces;
using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class PlotDataPointBar : PlotDataPointYDouble
	{
		private PlotFill m_Fill;

		private PlotChannelBar m_Channel;

		private double m_Width;

		public double Width
		{
			get
			{
				return this.m_Width;
			}
			set
			{
				if (this.m_Width != value)
				{
					this.m_Width = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public PlotFill Fill
		{
			get
			{
				if (this.m_Fill == null)
				{
					return this.m_Channel.Fill;
				}
				return this.m_Fill;
			}
			set
			{
				if (this.m_Fill != value)
				{
					if (this.m_Fill != null)
					{
						((ISubClassBase)this.m_Fill).AmbientOwner = null;
						((ISubClassBase)this.m_Fill).ComponentBase = null;
					}
					this.m_Fill = value;
					if (this.m_Fill != null)
					{
						((ISubClassBase)this.m_Fill).AmbientOwner = this.m_Channel;
						((ISubClassBase)this.m_Fill).ColorAmbientSource = AmbientColorSouce.Color;
						((ISubClassBase)this.m_Fill).ComponentBase = ((ISubClassBase)this.m_Channel).ComponentBase;
					}
					base.m_CH.DoDataChange();
				}
			}
		}

		public PlotDataPointBar(PlotChannelBase channel)
			: base(channel)
		{
			if (!(channel is PlotChannelBar))
			{
				throw new Exception("Invalid Channel type for PlotDataPointBar");
			}
			this.m_Channel = (channel as PlotChannelBar);
		}
	}
}
