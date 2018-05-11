using Iocomp.Interfaces;
using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class PlotDataPointTrace : PlotDataPointYDouble
	{
		private PlotPen m_Trace;

		private PlotMarker m_Marker;

		private PlotChannelTrace m_Channel;

		public PlotPen Trace
		{
			get
			{
				if (this.m_Trace == null)
				{
					return this.m_Channel.Trace;
				}
				return this.m_Trace;
			}
			set
			{
				if (this.m_Trace != value)
				{
					if (this.m_Trace != null)
					{
						((ISubClassBase)this.m_Trace).AmbientOwner = null;
						((ISubClassBase)this.m_Trace).ComponentBase = null;
					}
					this.m_Trace = value;
					if (this.m_Trace != null)
					{
						((ISubClassBase)this.m_Trace).AmbientOwner = this.m_Channel;
						((ISubClassBase)this.m_Trace).ColorAmbientSource = AmbientColorSouce.Color;
						((ISubClassBase)this.m_Trace).ComponentBase = ((ISubClassBase)this.m_Channel).ComponentBase;
					}
					base.m_CH.DoDataChange();
				}
			}
		}

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

		public PlotDataPointTrace(PlotChannelBase channel)
			: base(channel)
		{
			if (!(channel is PlotChannelTrace))
			{
				throw new Exception("Invalid Channel type for PlotDataPointTrace");
			}
			this.m_Channel = (channel as PlotChannelTrace);
		}
	}
}
