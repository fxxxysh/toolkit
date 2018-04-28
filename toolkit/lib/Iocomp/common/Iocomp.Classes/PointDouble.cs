using Iocomp.Design;
using System.ComponentModel;
using System.Globalization;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(CollectionItemConverter))]
	public sealed class PointDouble : SubClassBase
	{
		private double m_X;

		private double m_Y;

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public double X
		{
			get
			{
				return this.m_X;
			}
			set
			{
				base.PropertyUpdateDefault("X", value);
				if (this.X != value)
				{
					this.m_X = value;
					base.DoPropertyChange(this, "X");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public double Y
		{
			get
			{
				return this.m_Y;
			}
			set
			{
				base.PropertyUpdateDefault("Y", value);
				if (this.Y != value)
				{
					this.m_Y = value;
					base.DoPropertyChange(this, "Y");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Point Double";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PointDoubleEditorPlugIn";
		}

		public PointDouble()
		{
			base.DoCreate();
		}

		public PointDouble(double x, double y)
		{
			base.DoCreate();
			this.X = x;
			this.Y = y;
		}

		protected override void SetDefaults()
		{
			this.X = 0.0;
			this.Y = 0.0;
		}

		private bool ShouldSerializeX()
		{
			return base.PropertyShouldSerialize("X");
		}

		private void ResetX()
		{
			base.PropertyReset("X");
		}

		private bool ShouldSerializeY()
		{
			return base.PropertyShouldSerialize("Y");
		}

		private void ResetY()
		{
			base.PropertyReset("Y");
		}

		public override string ToString()
		{
			return this.X.ToString(CultureInfo.CurrentCulture) + ", " + this.Y.ToString(CultureInfo.CurrentCulture);
		}
	}
}
