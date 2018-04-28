using Iocomp.Interfaces;
using Iocomp.Types;
using System;

namespace Iocomp.Classes
{
	public class PlotDataPointCandlestick3 : PlotDataPointYDouble
	{
		private PlotChannelCandlestick3 m_Channel;

		private double m_Max;

		private double m_Min;

		private double m_StdDevPos;

		private double m_StdDevNeg;

		private double m_WidthMinMax;

		private double m_WidthStdDev;

		private double m_WidthMean;

		private double m_ThicknessMean;

		private PlotFill m_FillMinMax;

		private PlotFill m_FillStdDev;

		private PlotFill m_FillMean;

		public double Max
		{
			get
			{
				return this.m_Max;
			}
			set
			{
				if (this.m_Max != value)
				{
					this.m_Max = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public double Min
		{
			get
			{
				return this.m_Min;
			}
			set
			{
				if (this.m_Min != value)
				{
					this.m_Min = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public double StdDevPos
		{
			get
			{
				return this.m_StdDevPos;
			}
			set
			{
				if (this.m_StdDevPos != value)
				{
					this.m_StdDevPos = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public double StdDevNeg
		{
			get
			{
				return this.m_StdDevNeg;
			}
			set
			{
				if (this.m_StdDevNeg != value)
				{
					this.m_StdDevNeg = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public double Mean
		{
			get
			{
				return base.Y;
			}
			set
			{
				base.Y = value;
			}
		}

		public double WidthMinMax
		{
			get
			{
				return this.m_WidthMinMax;
			}
			set
			{
				if (this.m_WidthMinMax != value)
				{
					this.m_WidthMinMax = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public double WidthStdDev
		{
			get
			{
				return this.m_WidthStdDev;
			}
			set
			{
				if (this.m_WidthStdDev != value)
				{
					this.m_WidthStdDev = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public double WidthMean
		{
			get
			{
				return this.m_WidthMean;
			}
			set
			{
				if (this.m_WidthMean != value)
				{
					this.m_WidthMean = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public double ThicknessMean
		{
			get
			{
				return this.m_ThicknessMean;
			}
			set
			{
				if (this.m_ThicknessMean != value)
				{
					this.m_ThicknessMean = value;
					base.m_CH.DoDataChange();
				}
			}
		}

		public PlotFill FillMinMax
		{
			get
			{
				if (this.m_FillMinMax == null)
				{
					return this.m_Channel.FillMinMax;
				}
				return this.m_FillMinMax;
			}
			set
			{
				if (this.m_FillMinMax != value)
				{
					if (this.m_FillMinMax != null)
					{
						((ISubClassBase)this.m_FillMinMax).AmbientOwner = null;
						((ISubClassBase)this.m_FillMinMax).ComponentBase = null;
					}
					this.m_FillMinMax = value;
					if (this.m_FillMinMax != null)
					{
						((ISubClassBase)this.m_FillMinMax).AmbientOwner = this.m_Channel;
						((ISubClassBase)this.m_FillMinMax).ColorAmbientSource = AmbientColorSouce.Color;
						((ISubClassBase)this.m_FillMinMax).ComponentBase = ((ISubClassBase)this.m_Channel).ComponentBase;
					}
					base.m_CH.DoDataChange();
				}
			}
		}

		public PlotFill FillStdDev
		{
			get
			{
				if (this.m_FillStdDev == null)
				{
					return this.m_Channel.FillStdDev;
				}
				return this.m_FillStdDev;
			}
			set
			{
				if (this.m_FillStdDev != value)
				{
					if (this.m_FillStdDev != null)
					{
						((ISubClassBase)this.m_FillStdDev).AmbientOwner = null;
						((ISubClassBase)this.m_FillStdDev).ComponentBase = null;
					}
					this.m_FillStdDev = value;
					if (this.m_FillStdDev != null)
					{
						((ISubClassBase)this.m_FillStdDev).AmbientOwner = this.m_Channel;
						((ISubClassBase)this.m_FillStdDev).ColorAmbientSource = AmbientColorSouce.Color;
						((ISubClassBase)this.m_FillStdDev).ComponentBase = ((ISubClassBase)this.m_Channel).ComponentBase;
					}
					base.m_CH.DoDataChange();
				}
			}
		}

		public PlotFill FillMean
		{
			get
			{
				if (this.m_FillMean == null)
				{
					return this.m_Channel.FillMean;
				}
				return this.m_FillMean;
			}
			set
			{
				if (this.m_FillMean != value)
				{
					if (this.m_FillMean != null)
					{
						((ISubClassBase)this.m_FillMean).AmbientOwner = null;
						((ISubClassBase)this.m_FillMean).ComponentBase = null;
					}
					this.m_FillMean = value;
					if (this.m_FillMean != null)
					{
						((ISubClassBase)this.m_FillMean).AmbientOwner = this.m_Channel;
						((ISubClassBase)this.m_FillMean).ColorAmbientSource = AmbientColorSouce.Color;
						((ISubClassBase)this.m_FillMean).ComponentBase = ((ISubClassBase)this.m_Channel).ComponentBase;
					}
					base.m_CH.DoDataChange();
				}
			}
		}

		public PlotDataPointCandlestick3(PlotChannelBase channel)
			: base(channel)
		{
			if (!(channel is PlotChannelCandlestick3))
			{
				throw new Exception("Invalid Channel type for PlotDataPointCandlestick3");
			}
			this.m_Channel = (channel as PlotChannelCandlestick3);
		}
	}
}
