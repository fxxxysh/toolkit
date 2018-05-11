using System;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Design
{
	public class SubClassTypeConverter : ExpandableObjectConverter
	{
		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] filter)
		{
			return TypeDescriptor.GetProperties(value, filter);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				return "(sub-class)";
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
