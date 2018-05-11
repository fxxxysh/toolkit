using Iocomp.Delegates;
using Iocomp.Design;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(ValueIntegerTypeConverter))]
	public sealed class ValueInteger : Value, IConvertible, IComparable
	{
		private int m_Value;

		private int m_Max;

		private int m_Min;

		private int m_ValueOld;

		[Description("Value specified as a long.")]
		[RefreshProperties(RefreshProperties.All)]
		public int AsInteger
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				base.PropertyUpdateDefault("AsInteger", value);
				int num;
				if (this.AsInteger != value)
				{
					ValueIntegerEventArgs valueIntegerEventArgs = null;
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
						valueIntegerEventArgs = new ValueIntegerEventArgs(this.m_Value, num, false, base.EventSource);
						this.OnBeforeChangeEvent(valueIntegerEventArgs);
						if (!valueIntegerEventArgs.Cancel)
						{
							num = valueIntegerEventArgs.ValueNew;
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
				if (this.AsInteger != num)
				{
					this.m_Value = num;
					base.DoPropertyChange(this, "AsInteger");
					if (base.ShouldTriggerEvents)
					{
						ValueIntegerEventArgs valueIntegerEventArgs = new ValueIntegerEventArgs(this.m_Value, this.m_Value, false, base.EventSource);
						this.OnChangedEvent(valueIntegerEventArgs);
					}
				}
			}
		}

		private bool ShouldEnforceMinMax
		{
			get
			{
				if (this.Max == 0 && this.Min == 0)
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the maximum value allowed.")]
		public int Max
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
					if (this.ShouldEnforceMinMax && this.AsInteger > this.m_Max)
					{
						this.AsInteger = this.m_Max;
					}
					base.DoPropertyChange(this, "Max");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the minimum value allowed.")]
		public int Min
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
					if (this.ShouldEnforceMinMax && this.AsInteger < this.m_Min)
					{
						this.AsInteger = this.m_Min;
					}
					base.DoPropertyChange(this, "Min");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("Value specified as a Integer.")]
		public long AsLong
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				base.PropertyUpdateDefault("AsLong", value);
				this.AsInteger = (int)value;
			}
		}

		[Description("Value specified as a string.")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
		public event ValueIntegerEventHandler Changing;

		[Browsable(false)]
		public event ValueIntegerEventHandler Changed;

		[Browsable(false)]
		public event ValueIntegerEventHandler UserChangeFinished;

		protected override string GetPlugInTitle()
		{
			return "Value Integer";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ValueIntegerEditorPlugIn";
		}

		public ValueInteger()
		{
			base.DoCreate();
		}

		public ValueInteger(string value)
		{
			base.DoCreate();
			this.AsString = value;
		}

		public ValueInteger(int value)
		{
			base.DoCreate();
			this.AsInteger = value;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.AsString = "0";
			this.AsInteger = this.AsInteger;
			this.AsLong = this.AsLong;
			this.Max = 0;
			this.Min = 0;
		}

		public void BeginUserUpdate()
		{
			this.m_ValueOld = this.AsInteger;
		}

		public void EndUserUpdate()
		{
			ValueIntegerEventArgs valueIntegerEventArgs = null;
			if (this.m_ValueOld != this.AsInteger && base.ShouldTriggerEvents)
			{
				valueIntegerEventArgs = new ValueIntegerEventArgs(this.m_ValueOld, this.AsInteger, false, base.EventSource);
				this.OnUserChangeFinished(valueIntegerEventArgs);
			}
		}

		private bool ShouldSerializeAsInteger()
		{
			return base.PropertyShouldSerialize("AsInteger");
		}

		private void ResetAsInteger()
		{
			base.PropertyReset("AsInteger");
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

		private bool ShouldSerializeAsLong()
		{
			return base.PropertyShouldSerialize("AsLong");
		}

		private void ResetAsLong()
		{
			base.PropertyReset("AsLong");
		}

		private bool ShouldSerializeAsString()
		{
			return base.PropertyShouldSerialize("AsString");
		}

		private void ResetAsString()
		{
			base.PropertyReset("AsString");
		}

		private void OnBeforeChangeEvent(ValueIntegerEventArgs e)
		{
			if (this.Changing != null)
			{
				this.Changing(this, e);
			}
		}

		private void OnChangedEvent(ValueIntegerEventArgs e)
		{
			if (this.Changed != null)
			{
				this.Changed(this, e);
			}
		}

		private void OnUserChangeFinished(ValueIntegerEventArgs e)
		{
			if (this.UserChangeFinished != null)
			{
				this.UserChangeFinished(this, e);
			}
		}

		public static implicit operator ValueInteger(int value)
		{
			ValueInteger valueInteger = new ValueInteger();
			valueInteger.AsInteger = value;
			return valueInteger;
		}

		public static implicit operator ValueInteger(long value)
		{
			ValueInteger valueInteger = new ValueInteger();
			valueInteger.AsLong = value;
			return valueInteger;
		}

		public static implicit operator ValueInteger(string value)
		{
			ValueInteger valueInteger = new ValueInteger();
			valueInteger.AsString = value;
			return valueInteger;
		}

		public static implicit operator int(ValueInteger value)
		{
			return value.AsInteger;
		}

		public static implicit operator long(ValueInteger value)
		{
			return value.AsLong;
		}

		public static implicit operator string(ValueInteger value)
		{
			return value.AsString;
		}

		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ValueInteger))
			{
				return false;
			}
			return ((IComparable)this).CompareTo(obj) == 0;
		}

		public static bool operator ==(ValueInteger v1, ValueInteger v2)
		{
			if ((object)v1 == null ^ (object)v2 == null)
			{
				return false;
			}
			if ((object)v1 == null & (object)v2 == null)
			{
				return true;
			}
			return v1.AsInteger == v2.AsInteger;
		}

		public static bool operator !=(ValueInteger v1, ValueInteger v2)
		{
			return !(v1 == v2);
		}

		public static bool operator <(ValueInteger v1, ValueInteger v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) < 0;
		}

		public static bool operator >(ValueInteger v1, ValueInteger v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) > 0;
		}

		int IComparable.CompareTo(object obj)
		{
			int value;
			if (obj is int)
			{
				value = (int)obj;
				goto IL_0032;
			}
			if (obj is ValueInteger)
			{
				value = (obj as ValueInteger).AsInteger;
				goto IL_0032;
			}
			throw new ArgumentException("CompareTo object not supported");
			IL_0032:
			return this.m_Value.CompareTo(value);
		}

		TypeCode IConvertible.GetTypeCode()
		{
			return TypeCode.Int32;
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
