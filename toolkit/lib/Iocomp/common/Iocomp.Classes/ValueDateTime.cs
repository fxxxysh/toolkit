using Iocomp.Delegates;
using Iocomp.Design;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(ValueDateTimeTypeConverter))]
	public sealed class ValueDateTime : Value, IConvertible, IComparable
	{
		private DateTime m_Value;

		[RefreshProperties(RefreshProperties.All)]
		[Description("Value specified as a double.")]
		public DateTime AsDateTime
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				base.PropertyUpdateDefault("AsDateTime", value);
				DateTime dateTime;
				if (!(this.AsDateTime == value))
				{
					ValueDateTimeEventArgs valueDateTimeEventArgs = null;
					dateTime = value;
					if (base.ShouldTriggerEvents)
					{
						valueDateTimeEventArgs = new ValueDateTimeEventArgs(this.m_Value, dateTime, false, base.EventSource);
						this.OnBeforeChangeEvent(valueDateTimeEventArgs);
						if (!valueDateTimeEventArgs.Cancel)
						{
							dateTime = valueDateTimeEventArgs.ValueNew;
							goto IL_0057;
						}
						return;
					}
					goto IL_0057;
				}
				return;
				IL_0057:
				if (this.AsDateTime != dateTime)
				{
					this.m_Value = dateTime;
					base.DoPropertyChange(this, "AsDateTime");
					if (base.ShouldTriggerEvents)
					{
						ValueDateTimeEventArgs valueDateTimeEventArgs = new ValueDateTimeEventArgs(this.m_Value, this.m_Value, false, base.EventSource);
						this.OnChangedEvent(valueDateTimeEventArgs);
					}
				}
			}
		}

		[Description("Value specified as a string.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		public override string AsString
		{
			get
			{
				return this.m_Value.ToString("G", CultureInfo.CurrentCulture);
			}
			set
			{
				base.PropertyUpdateDefault("AsString", value);
				this.AsDateTime = DateTime.Parse(value, CultureInfo.CurrentCulture);
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Value specified as a string.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double AsDouble
		{
			get
			{
				return Math2.DateTimeToDouble(this.m_Value);
			}
			set
			{
				base.PropertyUpdateDefault("AsDouble", value);
				this.AsDateTime = Math2.DoubleToDateTime(value);
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Value specified as a integer.")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int AsInteger
		{
			get
			{
				return (int)this.AsDouble;
			}
			set
			{
				base.PropertyUpdateDefault("AsInteger", value);
				this.AsDateTime = Math2.DoubleToDateTime((double)value);
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("Value specified as a integer.")]
		public TimeSpan AsTimeSpan
		{
			get
			{
				return new TimeSpan(this.m_Value.Hour, this.m_Value.Minute, this.m_Value.Second);
			}
			set
			{
				base.PropertyUpdateDefault("AsTimeSpan", value);
				this.AsDateTime = new DateTime(this.m_Value.Year, this.m_Value.Month, this.m_Value.Day, value.Hours, value.Minutes, value.Seconds, value.Milliseconds);
			}
		}

		[Browsable(false)]
		public event ValueDateTimeEventHandler Changing;

		[Browsable(false)]
		public event ValueDateTimeEventHandler Changed;

		protected override string GetPlugInTitle()
		{
			return "Value DateTime";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ValueDateTimeEditorPlugIn";
		}

		public ValueDateTime()
		{
			base.DoCreate();
		}

		public ValueDateTime(string value)
		{
			base.DoCreate();
			this.AsString = value;
		}

		public ValueDateTime(DateTime value)
		{
			base.DoCreate();
			this.AsDateTime = value;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.AsDateTime = new DateTime(2000, 1, 1, 0, 0, 0);
			this.AsDouble = this.AsDouble;
			this.AsInteger = this.AsInteger;
			this.AsString = this.AsString;
			this.AsTimeSpan = this.AsTimeSpan;
		}

		private bool ShouldSerializeAsDateTime()
		{
			return base.PropertyShouldSerialize("AsDateTime");
		}

		private void ResetAsDateTime()
		{
			base.PropertyReset("AsDateTime");
		}

		private bool ShouldSerializeAsString()
		{
			return base.PropertyShouldSerialize("AsString");
		}

		private void ResetAsString()
		{
			base.PropertyReset("AsString");
		}

		private bool ShouldSerializeAsDouble()
		{
			return base.PropertyShouldSerialize("AsDouble");
		}

		private void ResetAsDouble()
		{
			base.PropertyReset("AsDouble");
		}

		private bool ShouldSerializeAsInteger()
		{
			return base.PropertyShouldSerialize("AsInteger");
		}

		private void ResetAsInteger()
		{
			base.PropertyReset("AsInteger");
		}

		private bool ShouldSerializeAsTimeSpan()
		{
			return base.PropertyShouldSerialize("AsTimeSpan");
		}

		private void ResetAsTimeSpan()
		{
			base.PropertyReset("AsTimeSpan");
		}

		private void OnBeforeChangeEvent(ValueDateTimeEventArgs e)
		{
			if (this.Changing != null)
			{
				this.Changing(this, e);
			}
		}

		private void OnChangedEvent(ValueDateTimeEventArgs e)
		{
			if (this.Changed != null)
			{
				this.Changed(this, e);
			}
		}

		public static implicit operator ValueDateTime(DateTime value)
		{
			ValueDateTime valueDateTime = new ValueDateTime();
			valueDateTime.AsDateTime = value;
			return valueDateTime;
		}

		public static implicit operator ValueDateTime(double value)
		{
			ValueDateTime valueDateTime = new ValueDateTime();
			valueDateTime.AsDouble = value;
			return valueDateTime;
		}

		public static implicit operator ValueDateTime(int value)
		{
			ValueDateTime valueDateTime = new ValueDateTime();
			valueDateTime.AsInteger = value;
			return valueDateTime;
		}

		public static implicit operator ValueDateTime(string value)
		{
			ValueDateTime valueDateTime = new ValueDateTime();
			valueDateTime.AsString = value;
			return valueDateTime;
		}

		public static implicit operator DateTime(ValueDateTime value)
		{
			return value.AsDateTime;
		}

		public static implicit operator double(ValueDateTime value)
		{
			return value.AsDouble;
		}

		public static implicit operator int(ValueDateTime value)
		{
			return value.AsInteger;
		}

		public static implicit operator string(ValueDateTime value)
		{
			return value.AsString;
		}

		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ValueDateTime))
			{
				return false;
			}
			return ((IComparable)this).CompareTo(obj) == 0;
		}

		public static bool operator ==(ValueDateTime v1, ValueDateTime v2)
		{
			if ((object)v1 == null ^ (object)v2 == null)
			{
				return false;
			}
			if ((object)v1 == null & (object)v2 == null)
			{
				return true;
			}
			return v1.AsDateTime == v2.AsDateTime;
		}

		public static bool operator !=(ValueDateTime v1, ValueDateTime v2)
		{
			return !(v1 == v2);
		}

		public static bool operator <(ValueDateTime v1, ValueDateTime v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) < 0;
		}

		public static bool operator >(ValueDateTime v1, ValueDateTime v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) > 0;
		}

		int IComparable.CompareTo(object obj)
		{
			DateTime value;
			if (obj is DateTime)
			{
				value = (DateTime)obj;
				goto IL_0032;
			}
			if (obj is ValueDateTime)
			{
				value = (obj as ValueDateTime).AsDateTime;
				goto IL_0032;
			}
			throw new ArgumentException("CompareTo object not supported");
			IL_0032:
			return this.m_Value.CompareTo(value);
		}

		TypeCode IConvertible.GetTypeCode()
		{
			return TypeCode.DateTime;
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
