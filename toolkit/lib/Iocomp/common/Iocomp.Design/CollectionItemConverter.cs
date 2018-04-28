using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace Iocomp.Design
{
	public class CollectionItemConverter : SubClassTypeConverter
	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				return true;
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				return true;
			}
			return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string))
			{
				return "(Collection-Item)";
			}
			if (destinationType == typeof(InstanceDescriptor))
			{
				ConstructorInfo constructor = value.GetType().GetConstructor(Type.EmptyTypes);
				if (constructor != (ConstructorInfo)null)
				{
					return new InstanceDescriptor(constructor, null, false);
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}
	}
}
