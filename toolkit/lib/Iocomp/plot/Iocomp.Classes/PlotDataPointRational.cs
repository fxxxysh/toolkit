using Iocomp.Interfaces;
using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class PlotDataPointRational : PlotDataPointYDouble
	{
		private PlotMarker m_Marker;

		private PlotChannelRational m_Channel;

		private double m_C;

		private double m_D;

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

		public double C
		{
			get
			{
				return this.m_C;
			}
			set
			{
				this.m_C = value;
			}
		}

		public double D
		{
			get
			{
				return this.m_D;
			}
			set
			{
				this.m_D = value;
			}
		}

		public PlotDataPointRational(PlotChannelBase channel)
			: base(channel)
		{
			if (!(channel is PlotChannelRational))
			{
				throw new Exception("Invalid Channel type for PlotDataPointRational");
			}
			this.m_Channel = (channel as PlotChannelRational);
		}
	}
}
