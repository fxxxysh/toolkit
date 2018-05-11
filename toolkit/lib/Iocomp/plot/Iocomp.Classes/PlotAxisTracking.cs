using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Axis Tracking")]
	public class PlotAxisTracking : SubClassBase, IPlotObjectSubClass
	{
		private PlotTrackingStyle m_Style;

		private PlotTrackingAlignFirstStyle m_AlignFirstStyle;

		private PlotTrackingExpandStyle m_ExpandStyle;

		private bool m_AlignFirstDone;

		private double m_ScrollCompressMax;

		private double m_SpanMin;

		private double m_MinMargin;

		private double m_MaxMargin;

		private PlotAxis m_Axis;

		private bool m_ModeScroll;

		private bool m_ModeExpandMinMax;

		private bool m_ModeExpandCollapse;

		private PlotObjectCollection m_ChannelList;

		private double m_ResumeMin;

		private double m_ResumeSpan;

		private bool m_RestoreValuesOnResume;

		PlotObject IPlotObjectSubClass.Owner
		{
			get
			{
				return this.Axis;
			}
			set
			{
				this.Axis = (value as PlotAxis);
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool Enabled
		{
			get
			{
				return base.EnabledInternal;
			}
			set
			{
				if (base.EnabledInternal != value)
				{
					base.EnabledInternal = value;
					if (!base.EnabledInternal)
					{
						this.UpdateResumeValues();
					}
					else if (this.RestoreValuesOnResume)
					{
						this.ApplyResumeValues();
					}
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotTrackingStyle Style
		{
			get
			{
				return this.m_Style;
			}
			set
			{
				base.PropertyUpdateDefault("Style", value);
				this.m_ModeExpandCollapse = (value == PlotTrackingStyle.ExpandCollapse || value == PlotTrackingStyle.ExpandCollapseInView);
				this.m_ModeExpandMinMax = (value == PlotTrackingStyle.ExpandMin || value == PlotTrackingStyle.ExpandMax || value == PlotTrackingStyle.ExpandMinMax);
				this.m_ModeScroll = (value == PlotTrackingStyle.ScrollPage || value == PlotTrackingStyle.ScrollSmooth);
				if (this.Style != value)
				{
					this.m_Style = value;
					base.DoPropertyChange(this, "Style");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotTrackingAlignFirstStyle AlignFirstStyle
		{
			get
			{
				return this.m_AlignFirstStyle;
			}
			set
			{
				base.PropertyUpdateDefault("AlignFirstStyle", value);
				if (this.AlignFirstStyle != value)
				{
					this.m_AlignFirstStyle = value;
					base.DoPropertyChange(this, "AlignFirstStyle");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotTrackingExpandStyle ExpandStyle
		{
			get
			{
				return this.m_ExpandStyle;
			}
			set
			{
				base.PropertyUpdateDefault("ExpandStyle", value);
				if (this.ExpandStyle != value)
				{
					this.m_ExpandStyle = value;
					base.DoPropertyChange(this, "ExpandStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double ScrollCompressMax
		{
			get
			{
				return this.m_ScrollCompressMax;
			}
			set
			{
				base.PropertyUpdateDefault("ScrollCompressMax", value);
				if (this.ScrollCompressMax != value)
				{
					this.m_ScrollCompressMax = value;
					base.DoPropertyChange(this, "ScrollCompressMax");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double SpanMin
		{
			get
			{
				return this.m_SpanMin;
			}
			set
			{
				base.PropertyUpdateDefault("SpanMin", value);
				if (value < 0.0)
				{
					value = 0.0;
				}
				if (this.SpanMin != value)
				{
					this.m_SpanMin = value;
					base.DoPropertyChange(this, "SpanMin");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double MinMargin
		{
			get
			{
				return this.m_MinMargin;
			}
			set
			{
				base.PropertyUpdateDefault("MinMargin", value);
				if (this.MinMargin != value)
				{
					this.m_MinMargin = value;
					base.DoPropertyChange(this, "MinMargin");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double MaxMargin
		{
			get
			{
				return this.m_MaxMargin;
			}
			set
			{
				base.PropertyUpdateDefault("MaxMargin", value);
				if (this.MaxMargin != value)
				{
					this.m_MaxMargin = value;
					base.DoPropertyChange(this, "MaxMargin");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool RestoreValuesOnResume
		{
			get
			{
				return this.m_RestoreValuesOnResume;
			}
			set
			{
				base.PropertyUpdateDefault("RestoreValuesOnResume", value);
				if (this.RestoreValuesOnResume != value)
				{
					this.m_RestoreValuesOnResume = value;
					base.DoPropertyChange(this, "RestoreValuesOnResume");
				}
			}
		}

		private PlotAxis Axis
		{
			get
			{
				return this.m_Axis;
			}
			set
			{
				this.m_Axis = value;
			}
		}

		private bool ModeScroll => this.m_ModeScroll;

		private bool ModeExpandMinMax => this.m_ModeExpandMinMax;

		private bool ModeExpandCollapse => this.m_ModeExpandCollapse;

		[Description("")]
		public bool AlignFirstDone
		{
			get
			{
				return this.m_AlignFirstDone;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Axis Tracking";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotAxisTrackingEditorPlugIn";
		}

		public PlotAxisTracking()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_ChannelList = new PlotObjectCollection();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.SpanMin = 0.0;
			this.MinMargin = 0.0;
			this.MaxMargin = 0.0;
			this.AlignFirstReset();
		}

		private bool ShouldSerializeEnabled()
		{
			return base.PropertyShouldSerialize("Enabled");
		}

		private void ResetEnabled()
		{
			base.PropertyReset("Enabled");
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private bool ShouldSerializeAlignFirstStyle()
		{
			return base.PropertyShouldSerialize("AlignFirstStyle");
		}

		private void ResetAlignFirstStyle()
		{
			base.PropertyReset("AlignFirstStyle");
		}

		private bool ShouldSerializeExpandStyle()
		{
			return base.PropertyShouldSerialize("ExpandStyle");
		}

		private void ResetExpandStyle()
		{
			base.PropertyReset("ExpandStyle");
		}

		private bool ShouldSerializeScrollCompressMax()
		{
			return base.PropertyShouldSerialize("ScrollCompressMax");
		}

		private void ResetScrollCompressMax()
		{
			base.PropertyReset("ScrollCompressMax");
		}

		private bool ShouldSerializeSpanMin()
		{
			return base.PropertyShouldSerialize("SpanMin");
		}

		private void ResetSpanMin()
		{
			base.PropertyReset("SpanMin");
		}

		private bool ShouldSerializeMinMargin()
		{
			return base.PropertyShouldSerialize("MinMargin");
		}

		private void ResetMinMargin()
		{
			base.PropertyReset("MinMargin");
		}

		private bool ShouldSerializeMaxMargin()
		{
			return base.PropertyShouldSerialize("MaxMargin");
		}

		private void ResetMaxMargin()
		{
			base.PropertyReset("MaxMargin");
		}

		private bool ShouldSerializeRestoreValuesOnResume()
		{
			return base.PropertyShouldSerialize("RestoreValuesOnResume");
		}

		private void ResetRestoreValuesOnResume()
		{
			base.PropertyReset("RestoreValuesOnResume");
		}

		[Description("")]
		public void AlignFirstReset()
		{
			this.m_AlignFirstDone = false;
		}

		[Description("")]
		public virtual void UpdateResumeValues()
		{
			if (this.Axis != null)
			{
				this.m_ResumeMin = this.Axis.ScaleRange.Min;
				this.m_ResumeSpan = this.Axis.ScaleRange.Span;
			}
		}

		[Description("")]
		public virtual void ApplyResumeValues()
		{
			if (this.Axis != null)
			{
				this.Axis.ScaleRange.SetMinSpan(this.m_ResumeMin, this.m_ResumeSpan);
			}
		}

		private void UpdateChannelList(Plot plot)
		{
			this.m_ChannelList.Clear();
			foreach (PlotChannelBase channel in plot.Channels)
			{
				if (this.Axis is PlotXAxis)
				{
					if (PlotBase.GetNamesMatch(this.Axis.Name, channel.XAxisName))
					{
						this.m_ChannelList.Add(channel);
					}
				}
				else if (this.Axis is PlotYAxis && PlotBase.GetNamesMatch(this.Axis.Name, channel.YAxisName))
				{
					this.m_ChannelList.Add(channel);
				}
			}
		}

		[Description("")]
		public void ZoomToFitAll()
		{
			Plot plot = ((IPlotObject)this.Axis).Plot;
			if (plot != null)
			{
				this.UpdateChannelList(plot);
				double num = double.PositiveInfinity;
				double num2 = double.NegativeInfinity;
				foreach (PlotChannelBase channel in this.m_ChannelList)
				{
					if (channel.Count > 0)
					{
						double val;
						double val2;
						if (this.Axis is PlotXAxis)
						{
							val = channel.XMin;
							val2 = channel.XMax;
						}
						else
						{
							val = channel.YMinScale;
							val2 = channel.YMaxScale;
						}
						num = Math.Min(num, val);
						num2 = Math.Max(num2, val2);
					}
				}
				if (num != double.PositiveInfinity)
				{
					if (num2 == num)
					{
						this.Axis.ScaleRange.Min = num2 - this.Axis.ScaleRange.Span / 2.0;
					}
					else
					{
						double num4;
						double num5;
						if (num2 - num < this.SpanMin)
						{
							double num3 = (num2 + num) / 2.0;
							num4 = num3 + this.SpanMin / 2.0;
							num5 = num3 - this.SpanMin / 2.0;
						}
						else
						{
							num4 = num2;
							num5 = num;
						}
						this.Axis.ScaleRange.SetMinMax(num5 - this.MinMargin, num4 + this.MaxMargin);
					}
				}
			}
		}

		[Description("")]
		public void ZoomToFitInView()
		{
			Plot plot = ((IPlotObject)this.Axis).Plot;
			if (plot != null)
			{
				this.UpdateChannelList(plot);
				double num = double.PositiveInfinity;
				double num2 = double.NegativeInfinity;
				foreach (PlotChannelBase channel in this.m_ChannelList)
				{
					if (channel.Count > 1 && ((!(this.Axis is PlotXAxis)) ? channel.GetInViewMinMaxY(out double val, out double val2) : channel.GetInViewMinMaxX(out val, out val2)))
					{
						num = Math.Min(num, val);
						num2 = Math.Max(num2, val2);
					}
				}
				if (num != double.PositiveInfinity)
				{
					if (num2 == num)
					{
						this.Axis.ScaleRange.Min = num2 - this.Axis.ScaleRange.Span / 2.0;
					}
					else
					{
						double num4;
						double num5;
						if (num2 - num < this.SpanMin)
						{
							double num3 = (num2 + num) / 2.0;
							num4 = num3 + this.SpanMin / 2.0;
							num5 = num3 - this.SpanMin / 2.0;
						}
						else
						{
							num4 = num2;
							num5 = num;
						}
						this.Axis.ScaleRange.SetMinMax(num5 - this.MinMargin, num4 + this.MaxMargin);
					}
				}
			}
		}

		private void DoAlignFirst(double value)
		{
			this.m_AlignFirstDone = true;
			if (this.AlignFirstStyle == PlotTrackingAlignFirstStyle.Min)
			{
				this.Axis.ScaleRange.Min = value;
			}
			else if (this.AlignFirstStyle == PlotTrackingAlignFirstStyle.Max)
			{
				this.Axis.ScaleRange.Min = value + this.Axis.ScaleRange.Span;
			}
			else if (this.AlignFirstStyle == PlotTrackingAlignFirstStyle.Auto && !this.Axis.ScaleRange.OnRange(value))
			{
				this.Axis.ScaleRange.Min = value;
			}
		}

		[Description("")]
		public void ScrollNewPage(double value)
		{
			this.Axis.ScaleRange.Min = value;
		}

		[Description("")]
		public void AdjustToIncrement(double increment)
		{
			double min = this.Axis.ScaleRange.Min;
			double max = this.Axis.ScaleRange.Max;
			double num = min;
			double num2 = max;
			if (max % increment != 0.0)
			{
				num2 = (double)(int)(max / increment) * increment;
			}
			if (min % increment != 0.0)
			{
				num = (double)(int)(min / increment) * increment;
			}
			if (num2 < max)
			{
				num2 += increment;
			}
			if (num > min)
			{
				num -= increment;
			}
			if (min == num && max == num2)
			{
				return;
			}
			this.Axis.ScaleRange.SetMinMax(num, num2);
		}

		[Description("")]
		public virtual void NewData(double value)
		{
			double min;
			double max;
			double min2;
			double max2;
			double num;
			double majorIncrement;
			double minorIncrement;
			if (this.Enabled && this.Axis != null)
			{
				min = this.Axis.ScaleRange.Min;
				max = this.Axis.ScaleRange.Max;
				double span = this.Axis.ScaleRange.Span;
				min2 = min;
				max2 = max;
				num = span;
				majorIncrement = this.Axis.ScaleDisplay.MajorIncrement;
				minorIncrement = this.Axis.ScaleDisplay.MinorIncrement;
				bool flag = false;
				if (this.ExpandStyle != PlotTrackingExpandStyle.Minor && minorIncrement == 0.0)
				{
					flag = true;
				}
				if (this.ExpandStyle != PlotTrackingExpandStyle.Major && majorIncrement == 0.0)
				{
					flag = true;
				}
				if (flag)
				{
					Plot plot = ((IPlotObject)this.Axis).Plot;
					if (plot != null)
					{
						plot.ReCalcLayout();
						majorIncrement = this.Axis.ScaleDisplay.MajorIncrement;
						minorIncrement = this.Axis.ScaleDisplay.MinorIncrement;
						goto IL_00e5;
					}
					return;
				}
				goto IL_00e5;
			}
			return;
			IL_00e5:
			if (!this.AlignFirstDone)
			{
				if (this.AlignFirstStyle != PlotTrackingAlignFirstStyle.None)
				{
					this.DoAlignFirst(value);
					return;
				}
				this.m_AlignFirstDone = true;
			}
			if (this.ModeScroll)
			{
				if (this.ScrollCompressMax != 0.0)
				{
					double num2 = value + this.MaxMargin - this.Axis.ScaleRange.Min;
					if (this.Axis.ScaleRange.Span < num2)
					{
						num = Math.Min(this.ScrollCompressMax, num2);
					}
					if (num != this.Axis.ScaleRange.Span)
					{
						this.Axis.ScaleRange.Span = num;
						return;
					}
				}
				if (this.Style == PlotTrackingStyle.ScrollSmooth)
				{
					if (value > this.Axis.ScaleRange.Max - this.MaxMargin)
					{
						this.Axis.ScaleRange.Min = value - this.Axis.ScaleRange.Span + this.MaxMargin;
					}
					else if (value < this.Axis.ScaleRange.Min + this.MinMargin)
					{
						this.Axis.ScaleRange.Min = value - this.MinMargin;
					}
				}
				else if (this.Style == PlotTrackingStyle.ScrollPage && value > this.Axis.ScaleRange.Max - this.MaxMargin)
				{
					this.ScrollNewPage(value);
				}
			}
			else if (this.ModeExpandMinMax)
			{
				if ((this.Style == PlotTrackingStyle.ExpandMin || this.Style == PlotTrackingStyle.ExpandMinMax) && value < min + this.MinMargin)
				{
					min2 = value - this.MinMargin;
				}
				if ((this.Style == PlotTrackingStyle.ExpandMax || this.Style == PlotTrackingStyle.ExpandMinMax) && value > max - this.MaxMargin)
				{
					max2 = value + this.MaxMargin;
				}
				this.Axis.ScaleRange.SetMinMax(min2, max2);
				if (this.ExpandStyle == PlotTrackingExpandStyle.Major)
				{
					this.AdjustToIncrement(majorIncrement);
				}
				else if (this.ExpandStyle == PlotTrackingExpandStyle.Minor)
				{
					this.AdjustToIncrement(minorIncrement);
				}
			}
			else if (this.ModeExpandCollapse)
			{
				if (this.Style == PlotTrackingStyle.ExpandCollapse)
				{
					this.ZoomToFitAll();
				}
				if (this.Style == PlotTrackingStyle.ExpandCollapseInView)
				{
					this.ZoomToFitInView();
				}
				if (this.ExpandStyle == PlotTrackingExpandStyle.Major)
				{
					this.AdjustToIncrement(majorIncrement);
				}
				else if (this.ExpandStyle == PlotTrackingExpandStyle.Minor)
				{
					this.AdjustToIncrement(minorIncrement);
				}
			}
		}
	}
}
