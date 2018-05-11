using Iocomp.Delegates;
using Iocomp.Design;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(ValueBooleanTypeConverter))]
	public sealed class ValueBoolean : Value, IConvertible, IComparable
	{
		private bool m_Value;

		[Description("Value specified as a boolean type.")]
		[RefreshProperties(RefreshProperties.All)]
		public bool AsBoolean
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				base.PropertyUpdateDefault("AsBoolean", value);
				bool flag;
				if (this.AsBoolean != value)
				{
					ValueBooleanEventArgs valueBooleanEventArgs = null;
					flag = value;
					if (base.ShouldTriggerEvents)
					{
						valueBooleanEventArgs = new ValueBooleanEventArgs(this.m_Value, flag, false, base.EventSource);
						this.OnBeforeChangeEvent(valueBooleanEventArgs);
						if (!valueBooleanEventArgs.Cancel)
						{
							flag = valueBooleanEventArgs.ValueNew;
							goto IL_0052;
						}
						return;
					}
					goto IL_0052;
				}
				return;
				IL_0052:
				if (this.AsBoolean != flag)
				{
					this.m_Value = flag;
					base.DoPropertyChange(this, "AsBoolean");
					if (base.ShouldTriggerEvents)
					{
						ValueBooleanEventArgs valueBooleanEventArgs = new ValueBooleanEventArgs(this.m_Value, this.m_Value, false, base.EventSource);
						this.OnChangedEvent(valueBooleanEventArgs);
					}
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("Value specified as a string.")]
		public override string AsString
		{
			get
			{
				if (this.AsBoolean)
				{
					return "True";
				}
				return "False";
			}
			set
			{
				base.PropertyUpdateDefault("AsString", value);
				if (value.ToUpper(CultureInfo.CurrentCulture) == "TRUE")
				{
					this.AsBoolean = true;
				}
				else if (value.ToUpper(CultureInfo.CurrentCulture) == "T")
				{
					this.AsBoolean = true;
				}
				else if (value.ToUpper(CultureInfo.CurrentCulture) == "ON")
				{
					this.AsBoolean = true;
				}
				else if (value.ToUpper(CultureInfo.CurrentCulture) == "ACTIVE")
				{
					this.AsBoolean = true;
				}
				else if (value.ToUpper(CultureInfo.CurrentCulture) == "HIGH")
				{
					this.AsBoolean = true;
				}
				else if (value.ToUpper(CultureInfo.CurrentCulture) == "1")
				{
					this.AsBoolean = true;
				}
				else if (value.ToUpper(CultureInfo.CurrentCulture) == "FALSE")
				{
					this.AsBoolean = false;
				}
				else if (value.ToUpper(CultureInfo.CurrentCulture) == "F")
				{
					this.AsBoolean = false;
				}
				else if (value.ToUpper(CultureInfo.CurrentCulture) == "OFF")
				{
					this.AsBoolean = false;
				}
				else if (value.ToUpper(CultureInfo.CurrentCulture) == "INACTIVE")
				{
					this.AsBoolean = false;
				}
				else if (value.ToUpper(CultureInfo.CurrentCulture) == "LOW")
				{
					this.AsBoolean = false;
				}
				else if (value.ToUpper(CultureInfo.CurrentCulture) == "0")
				{
					this.AsBoolean = false;
				}
			}
		}

		[Browsable(false)]
		public event ValueBooleanEventHandler Changing;

		[Browsable(false)]
		public event ValueBooleanEventHandler Changed;

		protected override string GetPlugInTitle()
		{
			return "Value Boolean";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ValueBooleanEditorPlugIn";
		}

		public ValueBoolean()
		{
			base.DoCreate();
		}

		public ValueBoolean(string value)
		{
			base.DoCreate();
			this.AsString = value;
		}

		public ValueBoolean(bool value)
		{
			base.DoCreate();
			this.AsBoolean = value;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.AsBoolean = false;
			this.AsString = this.AsString;
		}

		private bool ShouldSerializeAsBoolean()
		{
			return base.PropertyShouldSerialize("AsBoolean");
		}

		private void ResetAsBoolean()
		{
			base.PropertyReset("AsBoolean");
		}

		private bool ShouldSerializeAsString()
		{
			return base.PropertyShouldSerialize("AsString");
		}

		private void ResetAsString()
		{
			base.PropertyReset("AsString");
		}

		private void OnBeforeChangeEvent(ValueBooleanEventArgs e)
		{
			if (this.Changing != null)
			{
				this.Changing(this, e);
			}
		}

		private void OnChangedEvent(ValueBooleanEventArgs e)
		{
			if (this.Changed != null)
			{
				this.Changed(this, e);
			}
		}

		public static implicit operator ValueBoolean(bool value)
		{
			ValueBoolean valueBoolean = new ValueBoolean();
			valueBoolean.AsBoolean = value;
			return valueBoolean;
		}

		public static implicit operator ValueBoolean(string value)
		{
			ValueBoolean valueBoolean = new ValueBoolean();
			valueBoolean.AsString = value;
			return valueBoolean;
		}

		public static implicit operator bool(ValueBoolean value)
		{
			return value.AsBoolean;
		}

		public static implicit operator string(ValueBoolean value)
		{
			return value.AsString;
		}

		public override int GetHashCode()
		{
			return this.m_Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (!(obj is ValueBoolean))
			{
				return false;
			}
			return ((IComparable)this).CompareTo(obj) == 0;
		}

		public static bool operator ==(ValueBoolean v1, ValueBoolean v2)
		{
			if ((object)v1 == null ^ (object)v2 == null)
			{
				return false;
			}
			if ((object)v1 == null & (object)v2 == null)
			{
				return true;
			}
			return v1.AsBoolean == v2.AsBoolean;
		}

		public static bool operator !=(ValueBoolean v1, ValueBoolean v2)
		{
			return !(v1 == v2);
		}

		public static bool operator <(ValueBoolean v1, ValueBoolean v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) < 0;
		}

		public static bool operator >(ValueBoolean v1, ValueBoolean v2)
		{
			return ((IComparable)v1).CompareTo((object)v2) > 0;
		}

		int IComparable.CompareTo(object obj)
		{
			bool value;
			if (obj is bool)
			{
				value = (bool)obj;
				goto IL_0032;
			}
			if (obj is ValueBoolean)
			{
				value = (obj as ValueBoolean).AsBoolean;
				goto IL_0032;
			}
			throw new ArgumentException("CompareTo object not supported");
			IL_0032:
			return this.m_Value.CompareTo(value);
		}

		TypeCode IConvertible.GetTypeCode()
		{
			return TypeCode.Boolean;
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
