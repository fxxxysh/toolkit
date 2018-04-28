using Iocomp.Delegates;
using Iocomp.Design;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(ValueLongTypeConverter))]
	public sealed class ValueLong : Value, IConvertible, IComparable
	{
		private long m_Value;

		private long m_Max;

		private long m_Min;

		private long m_ValueOld;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Value specified as a long.")]
		[RefreshProperties(RefreshProperties.All)]
		public long AsLong
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				base.PropertyUpdateDefault("AsLong", value);
				long num;
				if (this.AsLong != value)
				{
					ValueLongEventArgs valueLongEventArgs = null;
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
						valueLongEventArgs = new ValueLongEventArgs(this.m_Value, num, false, base.EventSource);
						this.OnBeforeChangeEvent(valueLongEventArgs);
						if (!valueLongEventArgs.Cancel)
						{
							num = valueLongEventArgs.ValueNew;
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
				if (this.AsLong != num)
				{
					this.m_Value = num;
					base.DoPropertyChange(this, "AsLong");
					if (base.ShouldTriggerEvents)
					{
						ValueLongEventArgs valueLongEventArgs = new ValueLongEventArgs(this.m_Value, this.m_Value, false, base.EventSource);
						this.OnChangedEvent(valueLongEventArgs);
					}
				}
			}
		}

		private bool ShouldEnforceMinMax
		{
			get
			{
				if (this.Max == 0L && this.Min == 0L)
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

		[Description("Specifies the maximum value allowed.")]
		[RefreshProperties(RefreshProperties.All)]
		public long Max
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
					if (this.ShouldEnforceMinMax && this.AsLong > this.m_Max)
					{
						this.AsLong = this.m_Max;
					}
					base.DoPropertyChange(this, "Max");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the minimum value allowed.")]
		public long Min
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
					if (this.ShouldEnforceMinMax && this.AsLong < this.m_Min)
					{
						this.AsLong = this.m_Min;
					}
					base.DoPropertyChange(this, "Min");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("Value specified as a Integer.")]
		[RefreshProperties(RefreshProperties.All)]
		public int AsInteger
		{
			get
			{
				return (int)this.m_Value;
			}
			set
			{
				base.PropertyUpdateDefault("AsInteger", value);
				this.AsLong = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("Value specified as a hexadecimal string.")]
		public string AsStringHex
		{
			get
			{
				return Convert2.ToString(this.m_Value, 16).ToUpper(CultureInfo.CurrentCulture);
			}
			set
			{
				base.PropertyUpdateDefault("AsStringHex", value);
				this.AsLong = Convert.ToInt64(value, 16);
			}
		}

		[Description("Value specified as a binary string.")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string AsStringBinary
		{
			get
			{
				return Convert2.ToString(this.m_Value, 2).ToUpper(CultureInfo.CurrentCulture);
			}
			set
			{
				base.PropertyUpdateDefault("AsStringBinary", value);
				this.AsLong = Convert.ToInt64(value, 2);
			}
		}

		[Description("Value specified as a string.")]
		[RefreshProperties(RefreshProperties.All)]
		public override string AsString
		{
			get
			{
				return Convert2.ToString(this.m_Value);
			}
			set
			{
				base.PropertyUpdateDefault("AsString", value);
				this.AsLong = Convert.ToInt64(value, CultureInfo.CurrentCulture);
			}
		}

		[Browsable(false)]
		public event ValueLongEventHandler Changing;

		[Browsable(false)]
		public event ValueLongEventHandler Changed;

		[Browsable(false)]
		public event ValueLongEventHandler UserChangeFinished;

		protected override string GetPlugInTitle()
		{
			return "Value Long";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ValueLongEditorPlugIn";
		}

		public ValueLong()
		{
			base.DoCreate();
		}

		public ValueLong(string value)
		{
			base.DoCreate();
			this.AsString = value;
		}

		public ValueLong(long value)
		{
			base.DoCreate();
			this.AsLong = value;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.AsLong = 0L;
			this.AsString = this.AsString;
			this.AsInteger = this.AsInteger;
			this.AsStringBinary = this.AsStringBinary;
			this.AsStringHex = this.AsStringHex;
			this.Max = 0L;
			this.Min = 0L;
		}

		public void BeginUserUpdate()
		{
			this.m_ValueOld = this.AsLong;
		}

		public void EndUserUpdate()
		{
			ValueLongEventArgs valueLongEventArgs = null;
			if (this.m_ValueOld != this.AsLong && base.ShouldTriggerEvents)
			{
				valueLongEventArgs = new ValueLongEventArgs(this.m_ValueOld, this.AsLong, false, base.EventSource);
				this.OnUserChangeFinished(valueLongEventArgs);
			}
		}

		private bool ShouldSerializeAsLong()
		{
			return base.PropertyShouldSerialize("AsLong");
		}

		private void ResetAsLong()
		{
			base.PropertyReset("AsLong");
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

		private bool ShouldSerializeAsInteger()
		{
			return base.PropertyShouldSerialize("AsInteger");
		}

		private void ResetAsInteger()
		{
			base.PropertyReset("AsInteger");
		}

		private bool ShouldSerializeAsStringHex()
		{
			return base.PropertyShouldSerialize("AsStringHex");
		}

		private void ResetAsStringHex()
		{
			base.PropertyReset("AsStringHex");
		}

		private bool ShouldSerializeAsStringBinary()
		{
			return base.PropertyShouldSerialize("AsStringBinary");
		}

		private void ResetAsStringBinary()
		{
			base.PropertyReset("AsStringBinary");
		}

		private bool ShouldSerializeAsString()
		{
			return base.PropertyShouldSerialize("AsString");
		}

		private void ResetAsString()
		{
			base.PropertyReset("AsString");
		}

		private void OnBeforeChangeEvent(ValueLongEventArgs e)
		{
			if (this.Changing != null)
			{
				this.Changing(this, e);
			}
		}

		private void OnChangedEvent(ValueLongEventArgs e)
		{
			if (this.Changed != null)
			{
				this.Changed(this, e);
			}
		}

		private void OnUserChangeFinished(ValueLongEventArgs e)
		{
			if (this.UserChangeFinished != null)
			{
				this.UserChangeFinished(this, e);
			}
		}

		public static implicit operator ValueLong(int value)
		{
			ValueLong valueLong = new ValueLong();
			valueLong.AsInteger = value;
			return valueLong;
		}

		public static implicit operator ValueLong(long value)
		{
			ValueLong valueLong = new ValueLong();
			valueLong.AsLong = value;
			return valueLong;
		}

		public static implicit operator ValueLong(string value)
		{
			ValueLong valueLong = new ValueLong();
			valueLong.AsString = value;
			return valueLong;
		}

		public static implicit operator int(ValueLong value)
		{
			return value.AsInteger;
		}

		public static implicit operator long(ValueLong value)
		{
			return value.AsLong;
		}

		public static implicit operator string(ValueLong value)
		{
			return value.AsString;
		}

		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ValueLong))
			{
				return false;
			}
			return ((IComparable)this).CompareTo(obj) == 0;
		}

		public static bool operator ==(ValueLong v1, ValueLong v2)
		{
			if ((object)v1 == null ^ (object)v2 == null)
			{
				return false;
			}
			if ((object)v1 == null & (object)v2 == null)
			{
				return true;
			}
			return v1.AsLong == v2.AsLong;
		}

		public static bool operator !=(ValueLong v1, ValueLong v2)
		{
			return !(v1 == v2);
		}

		public static bool operator <(ValueLong v1, ValueLong v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) < 0;
		}

		public static bool operator >(ValueLong v1, ValueLong v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) > 0;
		}

		int IComparable.CompareTo(object obj)
		{
			long value;
			if (obj is long)
			{
				value = (long)obj;
				goto IL_0032;
			}
			if (obj is ValueLong)
			{
				value = (obj as ValueLong).AsLong;
				goto IL_0032;
			}
			throw new ArgumentException("CompareTo object not supported");
			IL_0032:
			return this.m_Value.CompareTo(value);
		}

		TypeCode IConvertible.GetTypeCode()
		{
			return TypeCode.Int64;
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
