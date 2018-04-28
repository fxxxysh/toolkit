using System;
using System.Globalization;

namespace Iocomp.Classes
{
	public sealed class Convert2
	{
		private Convert2()
		{
		}

		public static string ToString(int value)
		{
			return Convert.ToString(value, CultureInfo.CurrentCulture);
		}

		public static string ToString(long value)
		{
			return Convert.ToString(value, CultureInfo.CurrentCulture);
		}

		public static string ToString(long value, int toBase)
		{
			return Convert.ToString(value, toBase);
		}

		public static string ToString(decimal value)
		{
			return Convert.ToString(value, CultureInfo.CurrentCulture);
		}

		public static string ToString(double value)
		{
			return Convert.ToString(value, CultureInfo.CurrentCulture);
		}

		public static decimal ToDecimal(string value)
		{
			return Convert.ToDecimal(value, CultureInfo.CurrentCulture);
		}

		public static double ToDouble(string value)
		{
			return Convert.ToDouble(value, CultureInfo.CurrentCulture);
		}
	}
}
