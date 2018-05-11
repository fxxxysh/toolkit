using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	public class FocusControlConverter : TypeConverter
	{
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			if (context == null)
			{
				return null;
			}
			if (context.Instance == null)
			{
				return null;
			}
			if ((context.Instance as Control).Parent == null)
			{
				return null;
			}
			Control parent = (context.Instance as Control).Parent;
			ArrayList arrayList = new ArrayList();
			foreach (Control control in parent.Controls)
			{
				if (!(control is FocusLabel) && !(control is GroupBox))
				{
					arrayList.Add(control.Name);
				}
			}
			string[] array = new string[arrayList.Count];
			arrayList.Sort();
			for (int i = 0; i < arrayList.Count; i++)
			{
				array[i] = (string)arrayList[i];
			}
			return new StandardValuesCollection(array);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return true;
		}

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == typeof(string) && value is Control)
			{
				return (value as Control).Name;
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return true;
		}

		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (value is string)
			{
				if (context == null)
				{
					return null;
				}
				if (context.Instance == null)
				{
					return null;
				}
				if ((context.Instance as Control).Parent == null)
				{
					return null;
				}
				Control parent = (context.Instance as Control).Parent;
				foreach (Control control in parent.Controls)
				{
					if (control.Name == (string)value)
					{
						return control;
					}
				}
				return null;
			}
			return this.ConvertFrom(context, culture, value);
		}
	}
}
