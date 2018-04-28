using Iocomp.Interfaces;
using System;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("")]
	public sealed class ScaleAnnotation : SubClassBase, IScaleAnnotation
	{
		private double m_OriginX;

		private double m_OriginY;

		private double m_SpanX;

		private double m_SpanY;

		private int m_PixelLeft;

		private int m_PixelTop;

		private int m_PixelWidth;

		private int m_PixelHeight;

		int IScaleAnnotation.PixelLeft
		{
			get
			{
				return this.PixelLeft;
			}
			set
			{
				this.PixelLeft = value;
			}
		}

		int IScaleAnnotation.PixelTop
		{
			get
			{
				return this.PixelTop;
			}
			set
			{
				this.PixelTop = value;
			}
		}

		int IScaleAnnotation.PixelWidth
		{
			get
			{
				return this.PixelWidth;
			}
			set
			{
				this.PixelWidth = value;
			}
		}

		int IScaleAnnotation.PixelHeight
		{
			get
			{
				return this.PixelHeight;
			}
			set
			{
				this.PixelHeight = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Category("Iocomp")]
		public double OriginX
		{
			get
			{
				return this.m_OriginX;
			}
			set
			{
				base.PropertyUpdateDefault("OriginX", value);
				if (this.OriginX != value)
				{
					this.m_OriginX = value;
					base.DoPropertyChange(this, "OriginX");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public double OriginY
		{
			get
			{
				return this.m_OriginY;
			}
			set
			{
				base.PropertyUpdateDefault("OriginY", value);
				if (this.OriginY != value)
				{
					this.m_OriginY = value;
					base.DoPropertyChange(this, "OriginY");
				}
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double SpanX
		{
			get
			{
				return this.m_SpanX;
			}
			set
			{
				base.PropertyUpdateDefault("SpanX", value);
				if (this.SpanX != value)
				{
					this.m_SpanX = value;
					base.DoPropertyChange(this, "SpanX");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Category("Iocomp")]
		public double SpanY
		{
			get
			{
				return this.m_SpanY;
			}
			set
			{
				base.PropertyUpdateDefault("SpanY", value);
				if (this.SpanY != value)
				{
					this.m_SpanY = value;
					base.DoPropertyChange(this, "SpanY");
				}
			}
		}

		private int PixelLeft
		{
			get
			{
				return this.m_PixelLeft;
			}
			set
			{
				this.m_PixelLeft = value;
			}
		}

		private int PixelTop
		{
			get
			{
				return this.m_PixelTop;
			}
			set
			{
				this.m_PixelTop = value;
			}
		}

		private int PixelWidth
		{
			get
			{
				return this.m_PixelWidth;
			}
			set
			{
				this.m_PixelWidth = value;
			}
		}

		private int PixelHeight
		{
			get
			{
				return this.m_PixelHeight;
			}
			set
			{
				this.m_PixelHeight = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Scale";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleAnnotationEditorPlugIn";
		}

		public ScaleAnnotation()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeOriginX()
		{
			return base.PropertyShouldSerialize("OriginX");
		}

		private void ResetOriginX()
		{
			base.PropertyReset("OriginX");
		}

		private bool ShouldSerializeOriginY()
		{
			return base.PropertyShouldSerialize("OriginY");
		}

		private void ResetOriginY()
		{
			base.PropertyReset("OriginY");
		}

		private bool ShouldSerializeSpanX()
		{
			return base.PropertyShouldSerialize("SpanX");
		}

		private void ResetSpanX()
		{
			base.PropertyReset("SpanX");
		}

		private bool ShouldSerializeSpanY()
		{
			return base.PropertyShouldSerialize("SpanY");
		}

		private void ResetSpanY()
		{
			base.PropertyReset("SpanY");
		}

		public int ConvertUnitsToPixelsX(double value)
		{
			double num = (double)this.PixelLeft + value * (double)this.PixelWidth / this.SpanX - this.OriginX * (double)this.PixelWidth / this.SpanX + (double)((float)this.PixelWidth / 2f);
			if (num > 1E+30)
			{
				num = 1E+30;
			}
			if (num < -1E+30)
			{
				num = -1E+30;
			}
			return (int)num;
		}

		public int ConvertUnitsToPixelsY(double value)
		{
			double num = (double)this.PixelTop + (0.0 - value) * (double)this.PixelHeight / this.SpanY - this.OriginY * (double)this.PixelHeight / this.SpanY + (double)((float)this.PixelHeight / 2f);
			if (num > 1E+30)
			{
				num = 1E+30;
			}
			if (num < -1E+30)
			{
				num = -1E+30;
			}
			return (int)num;
		}

		public double ConvertPixelsToUnitsX(int value)
		{
			return (double)(value - this.PixelLeft) * this.SpanX / (double)this.PixelWidth + this.OriginX - this.SpanX / 2.0;
		}

		public double ConvertPixelsToUnitsY(int value)
		{
			return (double)(-(value - this.PixelTop)) * this.SpanY / (double)this.PixelHeight - this.OriginY + this.SpanY / 2.0;
		}

		public int ConvertHeightUnitsToPixels(double value)
		{
			return Math.Abs(this.ConvertUnitsToPixelsY(value) - this.ConvertUnitsToPixelsY(0.0));
		}

		public int ConvertWidthUnitsToPixels(double value)
		{
			return Math.Abs(this.ConvertUnitsToPixelsX(value) - this.ConvertUnitsToPixelsX(0.0));
		}
	}
}
