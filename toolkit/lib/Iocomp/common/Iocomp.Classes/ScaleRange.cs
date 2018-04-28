using Iocomp.Types;
using System.ComponentModel;

namespace Iocomp.Classes
{
	public abstract class ScaleRange : SubClassBase
	{
		private double m_Min;

		private double m_Span;

		private bool m_Reverse;

		private ScaleType m_ScaleType;

		private double m_SplitStart;

		private double m_SplitPercent;

		private bool m_LimitMinLowerEnabled;

		private double m_LimitMinLowerValue;

		private bool m_LimitMaxUpperEnabled;

		private double m_LimitMaxUpperValue;

		private bool m_LimitSpanLowerEnabled;

		private double m_LimitSpanLowerValue;

		private bool m_LimitSpanUpperEnabled;

		private double m_LimitSpanUpperValue;

		public bool LimitsEnforced
		{
			get
			{
				bool flag = false;
				if (this.LimitMinLowerEnabled)
				{
					flag = true;
				}
				if (this.LimitMaxUpperEnabled)
				{
					flag = true;
				}
				if (this.LimitSpanLowerEnabled)
				{
					flag = true;
				}
				if (this.LimitSpanUpperEnabled)
				{
					flag = true;
				}
				if (!flag)
				{
					return false;
				}
				if (this.LimitMinLowerEnabled && this.LimitMaxUpperEnabled)
				{
					double num = this.LimitMaxUpperValue - this.LimitMinLowerValue;
					if (num <= 0.0)
					{
						return false;
					}
					if (num < this.LimitSpanLowerValue)
					{
						return false;
					}
				}
				else if (this.LimitSpanLowerEnabled && this.LimitSpanUpperEnabled && this.LimitSpanLowerValue > this.LimitSpanUpperValue)
				{
					return false;
				}
				return true;
			}
		}

		public double LimitSpanUpperActual
		{
			get
			{
				if (this.LimitSpanUpperEnforced)
				{
					if (this.LimitMinLowerEnabled && this.LimitMaxUpperEnabled)
					{
						return this.LimitMaxUpperActual - this.LimitMinLowerActual;
					}
					return this.LimitSpanUpperValue;
				}
				return 1E+300;
			}
		}

		[Description("Specifies the minimum value the scale will show.")]
		[RefreshProperties(RefreshProperties.All)]
		public double Min
		{
			get
			{
				if (this.ScaleType == ScaleType.Log10 && this.m_Min < 1E-300)
				{
					this.m_Min = 1.0;
				}
				return this.m_Min;
			}
			set
			{
				if (value > 1E+300)
				{
					value = 1E+300;
				}
				if (value < -1E+300)
				{
					value = -1E+300;
				}
				base.PropertyUpdateDefault("Min", value);
				if (this.LimitMinLowerEnforced && value < this.LimitMinLowerValue)
				{
					value = this.LimitMinLowerValue;
				}
				if (this.LimitMaxUpperEnforced && value + this.Span > this.LimitMaxUpperActual)
				{
					value = this.LimitMaxUpperActual - this.Span;
				}
				if (this.Min != value)
				{
					this.m_Min = value;
					base.DoPropertyChange(this, "Min");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the range of the scale.")]
		public double Span
		{
			get
			{
				if (this.m_Span < 1E-300)
				{
					this.m_Span = 1E-300;
				}
				return this.m_Span;
			}
			set
			{
				if (value > 1E+300)
				{
					value = 1E+300;
				}
				if (value < 1E-300)
				{
					value = 1E-300;
				}
				if (this.LimitSpanLowerEnabled && value < this.LimitSpanLowerValue)
				{
					value = this.LimitSpanLowerValue;
				}
				if (this.LimitSpanUpperEnabled && value > this.LimitSpanUpperValue)
				{
					value = this.LimitSpanUpperValue;
				}
				base.PropertyUpdateDefault("Span", value);
				if (this.Span != value)
				{
					this.m_Span = value;
					base.DoPropertyChange(this, "Span");
					if (this.LimitMaxUpperEnforced && this.Max > this.LimitMaxUpperValue)
					{
						this.Min = this.Max - this.Span;
					}
				}
			}
		}

		[Description("Indicates the maximum value the scale will show.")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double Max
		{
			get
			{
				if (this.ScaleType == ScaleType.Log10 && this.m_Min < 1E-300)
				{
					this.m_Min = 1.0;
				}
				if (this.m_Span < 1E-300)
				{
					this.m_Span = 1E-300;
				}
				return this.m_Min + this.m_Span;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Description("Indicates the middle value of the scale.")]
		[RefreshProperties(RefreshProperties.All)]
		public double Mid
		{
			get
			{
				if (this.ScaleType == ScaleType.Log10 && this.m_Min < 1E-300)
				{
					this.m_Min = 1.0;
				}
				if (this.m_Span < 1E-300)
				{
					this.m_Span = 1E-300;
				}
				return this.m_Min + this.m_Span / 2.0;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies if the direction of the scale is reversed.")]
		public bool Reverse
		{
			get
			{
				return this.m_Reverse;
			}
			set
			{
				base.PropertyUpdateDefault("Reverse", value);
				if (this.Reverse != value)
				{
					this.m_Reverse = value;
					base.DoPropertyChange(this, "Reverse");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public ScaleType ScaleType
		{
			get
			{
				return this.m_ScaleType;
			}
			set
			{
				base.PropertyUpdateDefault("ScaleType", value);
				if (this.ScaleType != value)
				{
					this.m_ScaleType = value;
					base.DoPropertyChange(this, "ScaleType");
				}
			}
		}

		[Description("Specifies the value where the linear scale ends and the split scale starts.")]
		[RefreshProperties(RefreshProperties.All)]
		public double SplitStart
		{
			get
			{
				return this.m_SplitStart;
			}
			set
			{
				if (value > 1E+300)
				{
					value = 1E+300;
				}
				if (value <= 0.0)
				{
					value = 1.0;
				}
				base.PropertyUpdateDefault("SplitStart", value);
				if (this.SplitStart != value)
				{
					this.m_SplitStart = value;
					base.DoPropertyChange(this, "SplitStart");
				}
			}
		}

		[Description("Specifies the percent of the scale height or width, depending on the scale orientation that is reserved for the non-linear split.")]
		[RefreshProperties(RefreshProperties.All)]
		public double SplitPercent
		{
			get
			{
				return this.m_SplitPercent;
			}
			set
			{
				if (value > 1.0)
				{
					value = 1.0;
				}
				if (value < 0.0)
				{
					value = 0.0;
				}
				base.PropertyUpdateDefault("SplitPercent", value);
				if (this.SplitPercent != value)
				{
					this.m_SplitPercent = value;
					base.DoPropertyChange(this, "SplitPercent");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Determines if the Min property is limited on the lower end.")]
		public bool LimitMinLowerEnabled
		{
			get
			{
				return this.m_LimitMinLowerEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("LimitMinLowerEnabled", value);
				if (this.LimitMinLowerEnabled != value)
				{
					this.m_LimitMinLowerEnabled = value;
					base.DoPropertyChange(this, "LimitMinLowerEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Determines if the Max property is limited on the upper end.")]
		public bool LimitMaxUpperEnabled
		{
			get
			{
				return this.m_LimitMaxUpperEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("LimitMaxUpperEnabled", value);
				if (this.LimitMaxUpperEnabled != value)
				{
					this.m_LimitMaxUpperEnabled = value;
					base.DoPropertyChange(this, "LimitMaxUpperEnabled");
				}
			}
		}

		[Description("Determines if the Span property is limited on the lower end.")]
		[RefreshProperties(RefreshProperties.All)]
		public bool LimitSpanLowerEnabled
		{
			get
			{
				return this.m_LimitSpanLowerEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("LimitSpanLowerEnabled", value);
				if (this.LimitSpanLowerEnabled != value)
				{
					this.m_LimitSpanLowerEnabled = value;
					base.DoPropertyChange(this, "LimitSpanLowerEnabled");
				}
			}
		}

		[Description("Determines if the Span property is limited on the upper end.")]
		[RefreshProperties(RefreshProperties.All)]
		public bool LimitSpanUpperEnabled
		{
			get
			{
				return this.m_LimitSpanUpperEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("LimitSpanUpperEnabled", value);
				if (this.LimitSpanUpperEnabled != value)
				{
					this.m_LimitSpanUpperEnabled = value;
					base.DoPropertyChange(this, "LimitSpanUpperEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the value of the Min lower limit.")]
		public double LimitMinLowerValue
		{
			get
			{
				return this.m_LimitMinLowerValue;
			}
			set
			{
				base.PropertyUpdateDefault("LimitMinLowerValue", value);
				if (this.LimitMinLowerValue != value)
				{
					this.m_LimitMinLowerValue = value;
					base.DoPropertyChange(this, "LimitMinLowerValue");
				}
			}
		}

		[Description("Specifies the value of the Max upper limit.")]
		[RefreshProperties(RefreshProperties.All)]
		public double LimitMaxUpperValue
		{
			get
			{
				return this.m_LimitMaxUpperValue;
			}
			set
			{
				base.PropertyUpdateDefault("LimitMaxUpperValue", value);
				if (this.LimitMaxUpperValue != value)
				{
					this.m_LimitMaxUpperValue = value;
					base.DoPropertyChange(this, "LimitMaxUpperValue");
				}
			}
		}

		[Description("Specifies the value of the Span lower limit.")]
		[RefreshProperties(RefreshProperties.All)]
		public double LimitSpanLowerValue
		{
			get
			{
				return this.m_LimitSpanLowerValue;
			}
			set
			{
				if (value < 1E-300)
				{
					value = 1E-300;
				}
				base.PropertyUpdateDefault("LimitSpanLowerValue", value);
				if (this.LimitSpanLowerValue != value)
				{
					this.m_LimitSpanLowerValue = value;
					base.DoPropertyChange(this, "LimitSpanLowerValue");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the value of the Span upper limit.")]
		public double LimitSpanUpperValue
		{
			get
			{
				return this.m_LimitSpanUpperValue;
			}
			set
			{
				if (value < 1E-300)
				{
					value = 1E-300;
				}
				base.PropertyUpdateDefault("LimitSpanUpperValue", value);
				if (this.LimitSpanUpperValue != value)
				{
					this.m_LimitSpanUpperValue = value;
					base.DoPropertyChange(this, "LimitSpanUpperValue");
				}
			}
		}

		public double LimitMinLowerActual
		{
			get
			{
				if (this.LimitMinLowerEnabled)
				{
					return this.LimitMinLowerValue;
				}
				return -1E+300;
			}
		}

		public double LimitMaxUpperActual
		{
			get
			{
				if (this.LimitMaxUpperEnabled)
				{
					return this.LimitMaxUpperValue;
				}
				return 1E+300;
			}
		}

		public double LimitSpanLowerActual
		{
			get
			{
				if (this.LimitSpanLowerEnabled)
				{
					return this.LimitSpanLowerValue;
				}
				return 1E-300;
			}
		}

		private bool LimitMinLowerEnforced
		{
			get
			{
				if (!this.LimitsEnforced)
				{
					return false;
				}
				return this.LimitMinLowerEnabled;
			}
		}

		private bool LimitMaxUpperEnforced
		{
			get
			{
				if (!this.LimitsEnforced)
				{
					return false;
				}
				return this.LimitMaxUpperEnabled;
			}
		}

		private bool LimitSpanLowerEnforced
		{
			get
			{
				if (!this.LimitsEnforced)
				{
					return false;
				}
				return this.LimitSpanLowerEnabled;
			}
		}

		private bool LimitSpanUpperEnforced
		{
			get
			{
				if (!this.LimitsEnforced)
				{
					return false;
				}
				return this.LimitSpanUpperEnabled;
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.ScaleType = ScaleType.Linear;
			this.SplitPercent = 0.5;
			this.SplitStart = 50.0;
			this.LimitMinLowerEnabled = false;
			this.LimitMinLowerValue = 0.0;
			this.LimitMaxUpperEnabled = false;
			this.LimitMaxUpperValue = 100.0;
			this.LimitSpanLowerEnabled = false;
			this.LimitSpanLowerValue = 1E-300;
			this.LimitSpanUpperEnabled = false;
			this.LimitSpanUpperValue = 1E+300;
		}

		[Description("")]
		public void AdjustSpanUsingMidReference(double desiredSpan)
		{
			if (desiredSpan != this.Span)
			{
				double min = this.Mid - desiredSpan / 2.0;
				if (this.NotLimited(min, desiredSpan))
				{
					this.SetMinSpanNotLimited(min, desiredSpan);
				}
				else
				{
					this.AdjustSpanWhenLimited(desiredSpan);
				}
			}
		}

		[Description("")]
		public void SetMinSpan(double newMin, double newSpan)
		{
			if (this.NotLimited(newMin, newSpan))
			{
				this.SetMinSpanNotLimited(newMin, newSpan);
			}
			else
			{
				this.Span = newSpan;
				this.Min = newMin;
			}
		}

		[Description("")]
		public void SetMinMax(double min, double max)
		{
			this.Span = max - min;
			this.Min = min;
		}

		[Description("")]
		public void SetMaxSpan(double max, double span)
		{
			this.Span = span;
			this.Min = max - span;
		}

		private bool ShouldSerializeMin()
		{
			return base.PropertyShouldSerialize("Min");
		}

		private void ResetMin()
		{
			base.PropertyReset("Min");
		}

		private bool ShouldSerializeSpan()
		{
			return base.PropertyShouldSerialize("Span");
		}

		private void ResetSpan()
		{
			base.PropertyReset("Span");
		}

		public void SetSpan(int hours, int minutes, int seconds, int milliseconds)
		{
			this.Span = (double)hours * 1.0 / 24.0 + (double)minutes * 1.0 / 1440.0 + (double)seconds * 1.0 / 86400.0 + (double)milliseconds * 1.0 / 86400000.0;
		}

		private bool ShouldSerializeReverse()
		{
			return base.PropertyShouldSerialize("Reverse");
		}

		private void ResetReverse()
		{
			base.PropertyReset("Reverse");
		}

		private bool ShouldSerializeScaleType()
		{
			return base.PropertyShouldSerialize("ScaleType");
		}

		private void ResetScaleType()
		{
			base.PropertyReset("ScaleType");
		}

		private bool ShouldSerializeSplitStart()
		{
			return base.PropertyShouldSerialize("SplitStart");
		}

		private void ResetSplitStart()
		{
			base.PropertyReset("SplitStart");
		}

		private bool ShouldSerializeSplitPercent()
		{
			return base.PropertyShouldSerialize("SplitPercent");
		}

		private void ResetSplitPercent()
		{
			base.PropertyReset("SplitPercent");
		}

		private bool ShouldSerializeLimitMinLowerEnabled()
		{
			return base.PropertyShouldSerialize("LimitMinLowerEnabled");
		}

		private void ResetLimitMinLowerEnabled()
		{
			base.PropertyReset("LimitMinLowerEnabled");
		}

		private bool ShouldSerializeLimitMaxUpperEnabled()
		{
			return base.PropertyShouldSerialize("LimitMaxUpperEnabled");
		}

		private void ResetLimitMaxUpperEnabled()
		{
			base.PropertyReset("LimitMaxUpperEnabled");
		}

		private bool ShouldSerializeLimitSpanLowerEnabled()
		{
			return base.PropertyShouldSerialize("LimitSpanLowerEnabled");
		}

		private void ResetLimitSpanLowerEnabled()
		{
			base.PropertyReset("LimitSpanLowerEnabled");
		}

		private bool ShouldSerializeLimitSpanUpperEnabled()
		{
			return base.PropertyShouldSerialize("LimitSpanUpperEnabled");
		}

		private void ResetLimitSpanUpperEnabled()
		{
			base.PropertyReset("LimitSpanUpperEnabled");
		}

		private bool ShouldSerializeLimitMinLowerValue()
		{
			return base.PropertyShouldSerialize("LimitMinLowerValue");
		}

		private void ResetLimitMinLowerValue()
		{
			base.PropertyReset("LimitMinLowerValue");
		}

		private bool ShouldSerializeLimitMaxUpperValue()
		{
			return base.PropertyShouldSerialize("LimitMaxUpperValue");
		}

		private void ResetLimitMaxUpperValue()
		{
			base.PropertyReset("LimitMaxUpperValue");
		}

		private bool ShouldSerializeLimitSpanLowerValue()
		{
			return base.PropertyShouldSerialize("LimitSpanLowerValue");
		}

		private void ResetLimitSpanLowerValue()
		{
			base.PropertyReset("LimitSpanLowerValue");
		}

		private bool ShouldSerializeLimitSpanUpperValue()
		{
			return base.PropertyShouldSerialize("LimitSpanUpperValue");
		}

		private void ResetLimitSpanUpperValue()
		{
			base.PropertyReset("LimitSpanUpperValue");
		}

		[Description("Converts a percent value to a scale value. Percent is in (0.0-1.0) form.")]
		public double PercentToValue(double percent)
		{
			return percent * this.Span + this.Min;
		}

		[Description("Converts a relative percent span to a range in axis value units. Percent is in (0.0-1.0) form.")]
		public double PercentSpanToValue(double percent)
		{
			return percent * this.Span;
		}

		[Description("Converts a scale value to a percent value. Percent is in (0.0-1.0) form.")]
		public double ValueToPercent(double value)
		{
			return (value - this.Min) / this.Span;
		}

		[Description("Converts a relative span in value units to a relative span in percent units. Percent is in (0.0-1.0) form.")]
		public double ValueSpanToPercent(double value)
		{
			return value / this.Span;
		}

		[Description("Returns a True or False to indicate if the value is on the Range (Min <= Value <= Max)")]
		public bool OnRange(double value)
		{
			if (value >= this.Min && value <= this.Max)
			{
				return true;
			}
			return false;
		}

		private void AdjustSpanWhenLimited(double desiredSpan)
		{
			double num = desiredSpan - this.Span;
			if (num != 0.0)
			{
				if (num < 0.0)
				{
					this.Span = desiredSpan;
				}
				else
				{
					double num2 = this.Min - num;
					double num3 = this.Max + num;
					double num4 = desiredSpan;
					if (num4 > this.LimitSpanUpperActual)
					{
						num4 = this.LimitSpanUpperActual;
					}
					if (num3 > this.LimitMaxUpperActual)
					{
						this.SetMinSpan(this.LimitMaxUpperActual - num4, num4);
					}
					else if (num2 < this.LimitMinLowerActual)
					{
						this.SetMinSpan(this.LimitMinLowerActual, num4);
					}
					else
					{
						this.SetMinSpan(num2, num4);
					}
				}
			}
		}

		private void SetMinSpanNotLimited(double min, double span)
		{
			if (this.Min == min && this.Span == span)
			{
				return;
			}
			base.PropertyUpdateDefault("Min", min);
			if (this.Min != min)
			{
				if (min > 1E+300)
				{
					min = 1E+300;
				}
				if (min < -1E+300)
				{
					min = -1E+300;
				}
				if (this.m_Min != min)
				{
					this.m_Min = min;
					base.DoPropertyChange(this, "Min");
				}
			}
			base.PropertyUpdateDefault("Span", span);
			if (this.Span != span)
			{
				if (span > 1E+300)
				{
					span = 1E+300;
				}
				if (span < 1E-300)
				{
					span = 1E-300;
				}
				if (this.m_Span != span)
				{
					this.m_Span = span;
					base.DoPropertyChange(this, "Span");
				}
			}
		}

		private bool NotLimited(double min, double span)
		{
			return this.NotLimited(min, min + span, span);
		}

		private bool NotLimited(double min, double max, double span)
		{
			if (this.LimitMinLowerEnabled && min < this.LimitMinLowerValue)
			{
				return false;
			}
			if (this.LimitMaxUpperEnabled && max > this.LimitMaxUpperValue)
			{
				return false;
			}
			if (this.LimitSpanLowerEnabled && span < this.LimitSpanLowerValue)
			{
				return false;
			}
			if (this.LimitSpanUpperEnabled && span > this.LimitSpanUpperValue)
			{
				return false;
			}
			return true;
		}
	}
}
