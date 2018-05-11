using Iocomp.Interfaces;
using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class PlotDataPointCubicSpline : PlotDataPointYDouble
	{
		private PlotMarker m_Marker;

		private PlotChannelCubicSpline m_Channel;

		private double m_Y2;

		private double m_U;

		public PlotMarker Marker
		{
			get
			{
				if (this.m_Marker == null)
				{
					return this.m_Channel.Markers;
				}
				return this.m_Marker;
			}
			set
			{
				if (this.m_Marker != value)
				{
					if (this.m_Marker != null)
					{
						((ISubClassBase)this.m_Marker).ComponentBase = null;
						((ISubClassBase)this.m_Marker.Fill.Pen).AmbientOwner = null;
						((ISubClassBase)this.m_Marker.Fill.Brush).AmbientOwner = null;
					}
					this.m_Marker = value;
					if (this.m_Marker != null)
					{
						((ISubClassBase)this.m_Marker).ComponentBase = ((ISubClassBase)this.m_Channel).ComponentBase;
						((ISubClassBase)this.m_Marker.Fill.Pen).AmbientOwner = this.m_Channel;
						((ISubClassBase)this.m_Marker.Fill.Brush).AmbientOwner = this.m_Channel;
						((ISubClassBase)this.m_Marker.Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
						((ISubClassBase)this.m_Marker.Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
					}
					this.m_Channel.DoDataChange();
				}
			}
		}

		public double Y2
		{
			get
			{
				return this.m_Y2;
			}
			set
			{
				this.m_Y2 = value;
			}
		}

		public double U
		{
			get
			{
				return this.m_U;
			}
			set
			{
				this.m_U = value;
			}
		}

		public PlotDataPointCubicSpline(PlotChannelBase channel)
			: base(channel)
		{
			if (!(channel is PlotChannelCubicSpline))
			{
				throw new Exception("Invalid Channel type for PlotDataPointCubicSpline");
			}
			this.m_Channel = (channel as PlotChannelCubicSpline);
		}
	}
}
