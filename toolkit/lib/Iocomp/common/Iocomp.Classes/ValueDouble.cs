using Iocomp.Delegates;
using Iocomp.Design;
using System;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(ValueDoubleTypeConverter))]
	public sealed class ValueDouble : Value, IConvertible, IComparable
	{
		private double m_Value;

		private double m_Max;

		private double m_Min;

		private double m_ValueOld;

		[RefreshProperties(RefreshProperties.All)]
		[Description("Value specified as a double.")]
		public double AsDouble
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				base.PropertyUpdateDefault("AsDouble", value);
				double num;
				if (this.AsDouble != value)
				{
					ValueDoubleEventArgs valueDoubleEventArgs = null;
					num = value;
					if (this.ShouldEnforceMinMax)
					{
						if (num > this.Max)
						{
							num = this.Max;
						}
						if (num < this.Min)
						{
							num = this.Min;
						}
					}
					if (base.ShouldTriggerEvents)
					{
						valueDoubleEventArgs = new ValueDoubleEventArgs(this.m_Value, num, false, base.EventSource);
						this.OnBeforeChangeEvent(valueDoubleEventArgs);
						if (!valueDoubleEventArgs.Cancel)
						{
							num = valueDoubleEventArgs.ValueNew;
							if (this.ShouldEnforceMinMax)
							{
								if (num > this.Max)
								{
									num = this.Max;
								}
								if (num < this.Min)
								{
									num = this.Min;
								}
							}
							goto IL_00a2;
						}
						return;
					}
					goto IL_00a2;
				}
				return;
				IL_00a2:
				if (this.AsDouble != num)
				{
					this.m_Value = num;
					base.DoPropertyChange(this, "AsDouble");
					if (base.ShouldTriggerEvents)
					{
						ValueDoubleEventArgs valueDoubleEventArgs = new ValueDoubleEventArgs(this.m_Value, this.m_Value, false, base.EventSource);
						this.OnChangedEvent(valueDoubleEventArgs);
					}
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the maximum value allowed.")]
		public double Max
		{
			get
			{
				return this.m_Max;
			}
			set
			{
				base.PropertyUpdateDefault("Max", value);
				if (this.Max != value)
				{
					this.m_Max = value;
					if (this.ShouldEnforceMinMax && this.AsDouble > this.m_Max)
					{
						this.AsDouble = this.m_Max;
					}
					base.DoPropertyChange(this, "Max");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the minimum value allowed.")]
		public double Min
		{
			get
			{
				return this.m_Min;
			}
			set
			{
				base.PropertyUpdateDefault("Min", value);
				if (this.Min != value)
				{
					this.m_Min = value;
					if (this.ShouldEnforceMinMax && this.AsDouble < this.m_Min)
					{
						this.AsDouble = this.m_Min;
					}
					base.DoPropertyChange(this, "Min");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Value specified as a string.")]
		public override string AsString
		{
			get
			{
				return Convert2.ToString(this.m_Value);
			}
			set
			{
				base.PropertyUpdateDefault("AsString", value);
				this.AsDouble = Convert2.ToDouble(value);
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Value specified as a integer.")]
		public int AsInteger
		{
			get
			{
				return (int)this.m_Value;
			}
			set
			{
				base.PropertyUpdateDefault("AsInteger", value);
				this.AsDouble = (double)value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Value specified as a integer.")]
		[RefreshProperties(RefreshProperties.All)]
		public DateTime AsDateTime
		{
			get
			{
				return Math2.DoubleToDateTime(this.m_Value);
			}
			set
			{
				base.PropertyUpdateDefault("AsDateTime", value);
				this.AsDouble = Math2.DateTimeToDouble(value);
			}
		}

		private bool ShouldEnforceMinMax
		{
			get
			{
				if (this.Max == 0.0 && this.Min == 0.0)
				{
					return false;
				}
				if (this.ComponentBase != null && this.ComponentBase.Creating)
				{
					return false;
				}
				if (this.ComponentBase != null && this.ComponentBase.Loading)
				{
					return false;
				}
				return true;
			}
		}

		[Browsable(false)]
		public event ValueDoubleEventHandler Changing;

		[Browsable(false)]
		public event ValueDoubleEventHandler Changed;

		public event ValueDoubleEventHandler UserChangeFinished;

		protected override string GetPlugInTitle()
		{
			return "Value Double";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ValueDoubleEditorPlugIn";
		}

		public ValueDouble()
		{
			base.DoCreate();
		}

		public ValueDouble(string value)
		{
			base.DoCreate();
			this.AsString = value;
		}

		public ValueDouble(double value)
		{
			base.DoCreate();
			this.AsDouble = value;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.AsDouble = 0.0;
			this.AsInteger = this.AsInteger;
			this.AsString = this.AsString;
			this.AsDateTime = this.AsDateTime;
			this.Max = 0.0;
			this.Min = 0.0;
		}

		public void BeginUserUpdate()
		{
			this.m_ValueOld = this.AsDouble;
		}

		public void EndUserUpdate()
		{
			ValueDoubleEventArgs valueDoubleEventArgs = null;
			if (this.m_ValueOld != this.AsDouble && base.ShouldTriggerEvents)
			{
				valueDoubleEventArgs = new ValueDoubleEventArgs(this.m_ValueOld, this.AsDouble, false, base.EventSource);
				this.OnUserChangeFinished(valueDoubleEventArgs);
			}
		}

		private bool ShouldSerializeAsDouble()
		{
			return base.PropertyShouldSerialize("AsDouble");
		}

		private void ResetAsDouble()
		{
			base.PropertyReset("AsDouble");
		}

		private bool ShouldSerializeMax()
		{
			return base.PropertyShouldSerialize("Max");
		}

		private void ResetMax()
		{
			base.PropertyReset("Max");
		}

		private bool ShouldSerializeMin()
		{
			return base.PropertyShouldSerialize("Min");
		}

		private void ResetMin()
		{
			base.PropertyReset("Min");
		}

		private bool ShouldSerializeAsString()
		{
			return base.PropertyShouldSerialize("AsString");
		}

		private void ResetAsString()
		{
			base.PropertyReset("AsString");
		}

		private bool ShouldSerializeAsInteger()
		{
			return base.PropertyShouldSerialize("AsInteger");
		}

		private void ResetAsInteger()
		{
			base.PropertyReset("AsInteger");
		}

		private bool ShouldSerializeAsDateTime()
		{
			return base.PropertyShouldSerialize("AsDateTime");
		}

		private void ResetAsDateTime()
		{
			base.PropertyReset("AsDateTime");
		}

		private void OnBeforeChangeEvent(ValueDoubleEventArgs e)
		{
			if (this.Changing != null)
			{
				this.Changing(this, e);
			}
		}

		private void OnChangedEvent(ValueDoubleEventArgs e)
		{
			if (this.Changed != null)
			{
				this.Changed(this, e);
			}
		}

		private void OnUserChangeFinished(ValueDoubleEventArgs e)
		{
			if (this.UserChangeFinished != null)
			{
				this.UserChangeFinished(this, e);
			}
		}

		public static implicit operator ValueDouble(double value)
		{
			ValueDouble valueDouble = new ValueDouble();
			valueDouble.AsDouble = value;
			return valueDouble;
		}

		public static implicit operator ValueDouble(int value)
		{
			ValueDouble valueDouble = new ValueDouble();
			valueDouble.AsInteger = value;
			return valueDouble;
		}

		public static implicit operator ValueDouble(string value)
		{
			ValueDouble valueDouble = new ValueDouble();
			valueDouble.AsString = value;
			return valueDouble;
		}

		public static implicit operator ValueDouble(DateTime value)
		{
			ValueDouble valueDouble = new ValueDouble();
			valueDouble.AsDateTime = value;
			return valueDouble;
		}

		public static implicit operator double(ValueDouble value)
		{
			return value.AsDouble;
		}

		public static implicit operator int(ValueDouble value)
		{
			return value.AsInteger;
		}

		public static implicit operator string(ValueDouble value)
		{
			return value.AsString;
		}

		public static implicit operator DateTime(ValueDouble value)
		{
			return value.AsDateTime;
		}

		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ValueDouble))
			{
				return false;
			}
			return ((IComparable)this).CompareTo(obj) == 0;
		}

		public static bool operator ==(ValueDouble v1, ValueDouble v2)
		{
			if ((object)v1 == null ^ (object)v2 == null)
			{
				return false;
			}
			if ((object)v1 == null & (object)v2 == null)
			{
				return true;
			}
			return v1.AsDouble == v2.AsDouble;
		}

		public static bool operator !=(ValueDouble v1, ValueDouble v2)
		{
			return !(v1 == v2);
		}

		public static bool operator <(ValueDouble v1, ValueDouble v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) < 0;
		}

		public static bool operator >(ValueDouble v1, ValueDouble v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) > 0;
		}

		int IComparable.CompareTo(object obj)
		{
			double value;
			if (obj is double)
			{
				value = (double)obj;
				goto IL_0032;
			}
			if (obj is ValueDouble)
			{
				value = (obj as ValueDouble).AsDouble;
				goto IL_0032;
			}
			throw new ArgumentException("CompareTo object not supported");
			IL_0032:
			return this.m_Value.CompareTo(value);
		}

		TypeCode IConvertible.GetTypeCode()
		{
			return TypeCode.Double;
		}

		object IConvertible.ToType(Type conversionType, IFormatProvider provider)
		{
			return Convert.ChangeType(this.m_Value, conversionType, provider);
		}

		string IConvertible.ToString(IFormatProvider provider)
		{
			return Convert.ToString(this.m_Value, provider);
		}

		ulong IConvertible.ToUInt64(IFormatProvider provider)
		{
			return Convert.ToUInt64(this.m_Value, provider);
		}

		sbyte IConvertible.ToSByte(IFormatProvider provider)
		{
			return Convert.ToSByte(this.m_Value, provider);
		}

		double IConvertible.ToDouble(IFormatProvider provider)
		{
			return Convert.ToDouble(this.m_Value, provider);
		}

		DateTime IConvertible.ToDateTime(IFormatProvider provider)
		{
			return Convert.ToDateTime(this.m_Value, provider);
		}

		float IConvertible.ToSingle(IFormatProvider provider)
		{
			return Convert.ToSingle(this.m_Value, provider);
		}

		bool IConvertible.ToBoolean(IFormatProvider provider)
		{
			return Convert.ToBoolean(this.m_Value, provider);
		}

		int IConvertible.ToInt32(IFormatProvider provider)
		{
			return Convert.ToInt32(this.m_Value, provider);
		}

		ushort IConvertible.ToUInt16(IFormatProvider provider)
		{
			return Convert.ToUInt16(this.m_Value, provider);
		}

		short IConvertible.ToInt16(IFormatProvider provider)
		{
			return Convert.ToInt16(this.m_Value, provider);
		}

		byte IConvertible.ToByte(IFormatProvider provider)
		{
			return Convert.ToByte(this.m_Value, provider);
		}

		char IConvertible.ToChar(IFormatProvider provider)
		{
			return Convert.ToChar(this.m_Value, provider);
		}

		long IConvertible.ToInt64(IFormatProvider provider)
		{
			return Convert.ToInt64(this.m_Value, provider);
		}

		decimal IConvertible.ToDecimal(IFormatProvider provider)
		{
			return Convert.ToDecimal(this.m_Value, provider);
		}

		uint IConvertible.ToUInt32(IFormatProvider provider)
		{
			return Convert.ToUInt32(this.m_Value, provider);
		}
	}
}
