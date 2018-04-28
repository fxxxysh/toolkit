using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Classes
{
	[Description("Contains the properties to format the text.")]
	public class TextFormatDouble : SubClassBase
	{
		private int m_Precision;

		private PrecisionStyle m_PrecisionStyle;

		private string m_UnitsText;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int Precision
		{
			get
			{
				return this.m_Precision;
			}
			set
			{
				base.PropertyUpdateDefault("Precision", value);
				if (value < 0)
				{
					base.ThrowStreamingSafeException("Precision must be 0 or greater.");
				}
				if (value < 0)
				{
					value = 0;
				}
				if (this.Precision != value)
				{
					this.m_Precision = value;
					base.DoPropertyChange(this, "Precision");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PrecisionStyle PrecisionStyle
		{
			get
			{
				return this.m_PrecisionStyle;
			}
			set
			{
				base.PropertyUpdateDefault("PrecisionStyle", value);
				if (this.PrecisionStyle != value)
				{
					this.m_PrecisionStyle = value;
					base.DoPropertyChange(this, "PrecisionStyle");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string UnitsText
		{
			get
			{
				return this.m_UnitsText;
			}
			set
			{
				base.PropertyUpdateDefault("UnitsText", value);
				if (this.UnitsText != value)
				{
					this.m_UnitsText = value;
					base.DoPropertyChange(this, "UnitsText");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Text Format";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.TextFormatDoubleEditorPlugIn";
		}

		public TextFormatDouble()
		{
			base.DoCreate();
		}

		private bool ShouldSerializePrecision()
		{
			return base.PropertyShouldSerialize("Precision");
		}

		private void ResetPrecision()
		{
			base.PropertyReset("Precision");
		}

		private bool ShouldSerializePrecisionStyle()
		{
			return base.PropertyShouldSerialize("PrecisionStyle");
		}

		private void ResetPrecisionStyle()
		{
			base.PropertyReset("PrecisionStyle");
		}

		private bool ShouldSerializeUnitsText()
		{
			return base.PropertyShouldSerialize("UnitsText");
		}

		private void ResetUnitsText()
		{
			base.PropertyReset("UnitsText");
		}

		protected virtual string GetActualPrecisionString(double value)
		{
			if (this.PrecisionStyle == PrecisionStyle.None)
			{
				return "";
			}
			if (this.PrecisionStyle == PrecisionStyle.FixedDecimalPoints)
			{
				return Convert2.ToString(this.Precision);
			}
			int num = (value != 0.0) ? ((int)Math.Log10(Math.Abs(value)) + 1) : 0;
			int num2 = this.Precision - num;
			if (num2 < 0)
			{
				num2 = 0;
			}
			return Convert2.ToString(num2);
		}

		public virtual string GetText(double value)
		{
			string actualPrecisionString = this.GetActualPrecisionString(value);
			return string.Format(CultureInfo.CurrentCulture, "{0:f" + actualPrecisionString + "}" + this.UnitsText, new object[1]
			{
				value
			});
		}
	}
}
