using Iocomp.Classes;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Design
{
	public class ValueDoubleTypeConverter : ValueBaseConverter
	{
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				return new ValueDouble(value as string);
			}
			return this.ConvertFrom(context, culture, value);
		}
	}
}
