using Iocomp.Classes;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Design
{
	public class ValueIntegerTypeConverter : ValueBaseConverter
	{
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				return new ValueInteger(value as string);
			}
			return this.ConvertFrom(context, culture, value);
		}
	}
}
