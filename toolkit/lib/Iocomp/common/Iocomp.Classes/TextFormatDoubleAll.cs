using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Classes
{
	[Description("Contains the properties to format the text.")]
	public class TextFormatDoubleAll : TextFormatDouble
	{
		private string m_DateTimeFormat;

		private TextFormatDoubleStyle m_Style;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string DateTimeFormat
		{
			get
			{
				return this.m_DateTimeFormat;
			}
			set
			{
				base.PropertyUpdateDefault("DateTimeFormat", value);
				if (this.DateTimeFormat != value)
				{
					this.m_DateTimeFormat = value;
					base.DoPropertyChange(this, "DateTimeFormat");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public TextFormatDoubleStyle Style
		{
			get
			{
				return this.m_Style;
			}
			set
			{
				base.PropertyUpdateDefault("Style", value);
				if (this.Style != value)
				{
					this.m_Style = value;
					base.DoPropertyChange(this, "Style");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Text Format";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.TextFormatDoubleAllEditorPlugIn";
		}

		public TextFormatDoubleAll()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeDateTimeFormat()
		{
			return base.PropertyShouldSerialize("DateTimeFormat");
		}

		private void ResetDateTimeFormat()
		{
			base.PropertyReset("DateTimeFormat");
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		protected override string GetActualPrecisionString(double value)
		{
			if (base.PrecisionStyle == PrecisionStyle.None)
			{
				return "";
			}
			if (base.PrecisionStyle == PrecisionStyle.FixedDecimalPoints)
			{
				return Convert2.ToString(base.Precision);
			}
			int num;
			if (this.Style == TextFormatDoubleStyle.Exponent)
			{
				num = base.Precision - 1;
				if (num < 0)
				{
					num = 0;
				}
				return Convert2.ToString(num);
			}
			int num2 = (value != 0.0) ? ((int)Math.Log10(Math.Abs(value)) + 1) : 0;
			num = base.Precision - num2;
			if (num < 0)
			{
				num = 0;
			}
			return Convert2.ToString(num);
		}

		public override string GetText(double value)
		{
			double num = Math.Abs(value);
			int num2 = (!(num < 1.0)) ? ((int)Math.Log10(Math.Abs(value)) + 1) : 0;
			if (num2 < 12 && !double.IsInfinity(value) && !double.IsNaN(value))
			{
				value = Math.Round(value, 12 - num2);
			}
			switch (this.Style)
			{
			default:
				return "Error";
			case TextFormatDoubleStyle.Number:
			{
				if (base.PrecisionStyle == PrecisionStyle.None)
				{
					return string.Format(CultureInfo.CurrentCulture, "{0:G}" + base.UnitsText, new object[1]
					{
						value
					});
				}
				string actualPrecisionString = this.GetActualPrecisionString(value);
				return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "}" + base.UnitsText, new object[1]
				{
					value
				});
			}
			case TextFormatDoubleStyle.Thousands:
			{
				string actualPrecisionString = this.GetActualPrecisionString(value);
				return string.Format(CultureInfo.CurrentCulture, "{0:n" + actualPrecisionString + "}" + base.UnitsText, new object[1]
				{
					value
				});
			}
			case TextFormatDoubleStyle.Prefix:
			{
				int num3 = (int)(Math.Log10(Math.Abs(value)) / 3.0) * 3;
				num = value / Math.Pow(10.0, (double)num3);
				string actualPrecisionString = this.GetActualPrecisionString(num);
				switch (num3)
				{
				case -21:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} z" + base.UnitsText, new object[1]
					{
						num
					});
				case -24:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} y" + base.UnitsText, new object[1]
					{
						num
					});
				case -15:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} f" + base.UnitsText, new object[1]
					{
						num
					});
				case -18:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} a" + base.UnitsText, new object[1]
					{
						num
					});
				case -9:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} n" + base.UnitsText, new object[1]
					{
						num
					});
				case -12:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} p" + base.UnitsText, new object[1]
					{
						num
					});
				case -3:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} m" + base.UnitsText, new object[1]
					{
						num
					});
				case -6:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} µ" + base.UnitsText, new object[1]
					{
						num
					});
				case 3:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} K" + base.UnitsText, new object[1]
					{
						num
					});
				case 0:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "}" + base.UnitsText, new object[1]
					{
						num
					});
				case 9:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} G" + base.UnitsText, new object[1]
					{
						num
					});
				case 6:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} M" + base.UnitsText, new object[1]
					{
						num
					});
				case 15:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} P" + base.UnitsText, new object[1]
					{
						num
					});
				case 12:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} T" + base.UnitsText, new object[1]
					{
						num
					});
				case 24:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} Y" + base.UnitsText, new object[1]
					{
						num
					});
				default:
					return string.Format(CultureInfo.CurrentCulture, "{0:e" + actualPrecisionString + "}" + base.UnitsText, new object[1]
					{
						value
					});
				case 21:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} Z" + base.UnitsText, new object[1]
					{
						num
					});
				case 18:
					return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "} E" + base.UnitsText, new object[1]
					{
						num
					});
				}
			}
			case TextFormatDoubleStyle.Exponent:
			{
				string actualPrecisionString = this.GetActualPrecisionString(value);
				return string.Format(CultureInfo.CurrentCulture, "{0:e" + actualPrecisionString + "}" + base.UnitsText, new object[1]
				{
					value
				});
			}
			case TextFormatDoubleStyle.ExponentShort:
			{
				string actualPrecisionString = this.GetActualPrecisionString(value);
				string text = string.Format(CultureInfo.CurrentCulture, "{0:e" + actualPrecisionString + "}" + base.UnitsText, new object[1]
				{
					value
				});
				int num4 = text.IndexOf('+');
				if (num4 != -1)
				{
					if (text.Substring(num4 + 1, 2) == "00")
					{
						text = text.Substring(0, num4 + 1) + text.Substring(num4 + 3, 1);
					}
					else if (text.Substring(num4 + 1, 1) == "0")
					{
						text = text.Substring(0, num4 + 1) + text.Substring(num4 + 2, 2);
					}
				}
				return text;
			}
			case TextFormatDoubleStyle.Price32nds:
			{
				double num5 = value - (double)(int)value;
				int num6 = (int)(num5 * 32.0);
				int num7 = (int)((num5 - (double)num6 / 32.0) * 256.0);
				string text2 = num6.ToString("d", CultureInfo.CurrentCulture);
				string text3 = num7.ToString("d", CultureInfo.CurrentCulture);
				if (text2.Length < 2)
				{
					text2 = "0" + text2;
				}
				return string.Format(CultureInfo.CurrentCulture, "{0:f0}." + text2 + text3 + " " + base.UnitsText, new object[1]
				{
					(int)(value + 0.0)
				});
			}
			case TextFormatDoubleStyle.DateTime:
			{
				DateTime dateTime2 = Math2.DoubleToDateTime(value);
				if (this.DateTimeFormat.IndexOf('f') != -1)
				{
					return dateTime2.ToString(this.DateTimeFormat, CultureInfo.CurrentCulture);
				}
				return dateTime2.AddMilliseconds(5.0).ToString(this.DateTimeFormat, CultureInfo.CurrentCulture);
			}
			case TextFormatDoubleStyle.DateTimeUTC:
			{
				DateTime dateTime = Math2.DoubleToDateTime(value).ToLocalTime();
				if (this.DateTimeFormat.IndexOf('f') != -1)
				{
					return dateTime.ToString(this.DateTimeFormat, CultureInfo.CurrentCulture);
				}
				return dateTime.AddMilliseconds(5.0).ToString(this.DateTimeFormat, CultureInfo.CurrentCulture);
			}
			}
		}
	}
}
