using System;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Design
{
	public class AnnotationBaseConverter : CollectionItemConverter
	{
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
				return value.GetType().Name;
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
