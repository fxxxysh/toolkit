using Iocomp.Classes;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Design
{
	public class ValueBooleanTypeConverter : ValueBaseConverter
	{
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				return new ValueBoolean(value as string);
			}
			return this.ConvertFrom(context, culture, value);
		}
	}
}
