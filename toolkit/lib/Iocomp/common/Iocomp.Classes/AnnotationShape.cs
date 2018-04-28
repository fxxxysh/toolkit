using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Serializable]
	public abstract class AnnotationShape : AnnotationOutline
	{
		private Color m_GradientStartColor;

		private Color m_GradientStopColor;

		private Color m_HatchBackColor;

		private Color m_HatchForeColor;

		private Color m_FillColor;

		private AnnotationFillStyle m_FillStyle;

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public Color GradientStartColor
		{
			get
			{
				return this.m_GradientStartColor;
			}
			set
			{
				base.PropertyUpdateDefault("GradientStartColor", value);
				if (this.GradientStartColor != value)
				{
					this.m_GradientStartColor = value;
					base.DoPropertyChange(this, "GradientStartColor");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public Color GradientStopColor
		{
			get
			{
				return this.m_GradientStopColor;
			}
			set
			{
				base.PropertyUpdateDefault("GradientStopColor", value);
				if (this.GradientStopColor != value)
				{
					this.m_GradientStopColor = value;
					base.DoPropertyChange(this, "GradientStopColor");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public Color HatchBackColor
		{
			get
			{
				return this.m_HatchBackColor;
			}
			set
			{
				base.PropertyUpdateDefault("HatchBackColor", value);
				if (this.HatchBackColor != value)
				{
					this.m_HatchBackColor = value;
					base.DoPropertyChange(this, "HatchBackColor");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Category("Iocomp")]
		public Color HatchForeColor
		{
			get
			{
				return this.m_HatchForeColor;
			}
			set
			{
				base.PropertyUpdateDefault("HatchForeColor", value);
				if (this.HatchForeColor != value)
				{
					this.m_HatchForeColor = value;
					base.DoPropertyChange(this, "HatchForeColor");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public Color FillColor
		{
			get
			{
				return this.m_FillColor;
			}
			set
			{
				base.PropertyUpdateDefault("FillColor", value);
				if (this.FillColor != value)
				{
					this.m_FillColor = value;
					base.DoPropertyChange(this, "FillColor");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Category("Iocomp")]
		public AnnotationFillStyle FillStyle
		{
			get
			{
				return this.m_FillStyle;
			}
			set
			{
				base.PropertyUpdateDefault("FillStyle", value);
				if (this.FillStyle != value)
				{
					this.m_FillStyle = value;
					base.DoPropertyChange(this, "FillStyle");
				}
			}
		}

		protected float ModeAngle
		{
			get
			{
				if (this.FillStyle == AnnotationFillStyle.GradientHorizontal)
				{
					return 0f;
				}
				if (this.FillStyle == AnnotationFillStyle.GradientForwardDiagonal)
				{
					return 45f;
				}
				if (this.FillStyle == AnnotationFillStyle.GradientVertical)
				{
					return 90f;
				}
				return 135f;
			}
		}

		protected HatchStyle HatchStyle
		{
			get
			{
				if (this.FillStyle == AnnotationFillStyle.HatchBackwardDiagonal)
				{
					return HatchStyle.BackwardDiagonal;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchCross)
				{
					return HatchStyle.Cross;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchDarkDownwardDiagonal)
				{
					return HatchStyle.DarkDownwardDiagonal;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchDarkHorizontal)
				{
					return HatchStyle.DarkHorizontal;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchDarkUpwardDiagonal)
				{
					return HatchStyle.DarkUpwardDiagonal;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchDarkVertical)
				{
					return HatchStyle.DarkVertical;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchDashedDownwardDiagonal)
				{
					return HatchStyle.DashedDownwardDiagonal;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchDashedHorizontal)
				{
					return HatchStyle.DashedHorizontal;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchDashedUpwardDiagonal)
				{
					return HatchStyle.DashedUpwardDiagonal;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchDashedVertical)
				{
					return HatchStyle.DashedVertical;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchDiagonalBrick)
				{
					return HatchStyle.DiagonalBrick;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchDiagonalCross)
				{
					return HatchStyle.DiagonalCross;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchDivot)
				{
					return HatchStyle.Divot;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchDottedDiamond)
				{
					return HatchStyle.DottedDiamond;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchDottedGrid)
				{
					return HatchStyle.DottedGrid;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchForwardDiagonal)
				{
					return HatchStyle.ForwardDiagonal;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchHorizontal)
				{
					return HatchStyle.Horizontal;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchHorizontalBrick)
				{
					return HatchStyle.HorizontalBrick;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchLargeCheckerBoard)
				{
					return HatchStyle.LargeCheckerBoard;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchLargeConfetti)
				{
					return HatchStyle.LargeConfetti;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchLargeGrid)
				{
					return HatchStyle.Cross;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchLightDownwardDiagonal)
				{
					return HatchStyle.LightDownwardDiagonal;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchLightHorizontal)
				{
					return HatchStyle.LightHorizontal;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchLightUpwardDiagonal)
				{
					return HatchStyle.LightUpwardDiagonal;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchLightVertical)
				{
					return HatchStyle.LightVertical;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchMax)
				{
					return HatchStyle.Cross;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchMin)
				{
					return HatchStyle.Horizontal;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchNarrowHorizontal)
				{
					return HatchStyle.NarrowHorizontal;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchNarrowVertical)
				{
					return HatchStyle.NarrowVertical;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchOutlinedDiamond)
				{
					return HatchStyle.OutlinedDiamond;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchPercent05)
				{
					return HatchStyle.Percent05;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchPercent10)
				{
					return HatchStyle.Percent10;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchPercent20)
				{
					return HatchStyle.Percent20;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchPercent25)
				{
					return HatchStyle.Percent25;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchPercent30)
				{
					return HatchStyle.Percent30;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchPercent40)
				{
					return HatchStyle.Percent40;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchPercent50)
				{
					return HatchStyle.Percent50;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchPercent60)
				{
					return HatchStyle.Percent60;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchPercent70)
				{
					return HatchStyle.Percent70;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchPercent75)
				{
					return HatchStyle.Percent75;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchPercent80)
				{
					return HatchStyle.Percent80;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchPercent90)
				{
					return HatchStyle.Percent90;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchPlaid)
				{
					return HatchStyle.Plaid;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchShingle)
				{
					return HatchStyle.Shingle;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchSmallCheckerBoard)
				{
					return HatchStyle.SmallCheckerBoard;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchSmallConfetti)
				{
					return HatchStyle.SmallConfetti;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchSmallGrid)
				{
					return HatchStyle.SmallGrid;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchSolidDiamond)
				{
					return HatchStyle.SolidDiamond;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchSphere)
				{
					return HatchStyle.Sphere;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchTrellis)
				{
					return HatchStyle.Trellis;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchVertical)
				{
					return HatchStyle.Vertical;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchWave)
				{
					return HatchStyle.Wave;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchWeave)
				{
					return HatchStyle.Weave;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchWideDownwardDiagonal)
				{
					return HatchStyle.WideDownwardDiagonal;
				}
				if (this.FillStyle == AnnotationFillStyle.HatchWideUpwardDiagonal)
				{
					return HatchStyle.WideUpwardDiagonal;
				}
				return HatchStyle.ZigZag;
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.GradientStartColor = Color.Black;
			this.GradientStopColor = Color.Black;
			this.HatchBackColor = Color.White;
			this.HatchForeColor = Color.Black;
			this.FillColor = Color.Yellow;
			this.FillStyle = AnnotationFillStyle.Solid;
		}

		private bool ShouldSerializeGradientStartColor()
		{
			return base.PropertyShouldSerialize("GradientStartColor");
		}

		private void ResetGradientStartColor()
		{
			base.PropertyReset("GradientStartColor");
		}

		private bool ShouldSerializeGradientStopColor()
		{
			return base.PropertyShouldSerialize("GradientStopColor");
		}

		private void ResetGradientStopColor()
		{
			base.PropertyReset("GradientStopColor");
		}

		private bool ShouldSerializeHatchBackColor()
		{
			return base.PropertyShouldSerialize("HatchBackColor");
		}

		private void ResetHatchBackColor()
		{
			base.PropertyReset("HatchBackColor");
		}

		private bool ShouldSerializeHatchForeColor()
		{
			return base.PropertyShouldSerialize("HatchForeColor");
		}

		private void ResetHatchForeColor()
		{
			base.PropertyReset("HatchForeColor");
		}

		private bool ShouldSerializeFillColor()
		{
			return base.PropertyShouldSerialize("FillColor");
		}

		private void ResetFillColor()
		{
			base.PropertyReset("FillColor");
		}

		private bool ShouldSerializeFillStyle()
		{
			return base.PropertyShouldSerialize("FillStyle");
		}

		private void ResetFillStyle()
		{
			base.PropertyReset("FillStyle");
		}

		protected void DrawFill(PaintArgs p, Rectangle r, Point[] points)
		{
			if (this.FillStyle == AnnotationFillStyle.Solid)
			{
				this.DrawFillSolid(p, r, points);
			}
			else if (this.FillStyle == AnnotationFillStyle.Clear)
			{
				this.DrawFillSolid(p, r, points);
			}
			else if (this.FillStyle == AnnotationFillStyle.GradientBackwardDiagonal)
			{
				this.DrawFillGradient(p, r, points);
			}
			else if (this.FillStyle == AnnotationFillStyle.GradientForwardDiagonal)
			{
				this.DrawFillGradient(p, r, points);
			}
			else if (this.FillStyle == AnnotationFillStyle.GradientHorizontal)
			{
				this.DrawFillGradient(p, r, points);
			}
			else if (this.FillStyle == AnnotationFillStyle.GradientVertical)
			{
				this.DrawFillGradient(p, r, points);
			}
			else
			{
				this.DrawFillHatch(p, r, points);
			}
		}

		protected abstract void DrawFillSolid(PaintArgs p, Rectangle r, Point[] points);

		protected abstract void DrawFillGradient(PaintArgs p, Rectangle r, Point[] points);

		protected abstract void DrawFillHatch(PaintArgs p, Rectangle r, Point[] points);

		protected override void DrawCustom(PaintArgs p)
		{
			Rectangle rectangle = new Rectangle(this.Scale.ConvertUnitsToPixelsX(base.Left), this.Scale.ConvertUnitsToPixelsY(base.Top), this.Scale.ConvertWidthUnitsToPixels(this.Width), this.Scale.ConvertHeightUnitsToPixels(this.Height));
			base.ClickRegion = new Region(rectangle);
			base.UpdateGrabHandles(rectangle);
			if (rectangle.Height != 0 && rectangle.Width != 0)
			{
				if (this.FillStyle != AnnotationFillStyle.Clear)
				{
					this.DrawFill(p, rectangle, null);
				}
				rectangle = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width - 1, rectangle.Height - 1);
				if (rectangle.Height != 0 && rectangle.Width != 0 && base.OutlineStyle != AnnotationOutlineStyle.Clear)
				{
					this.DrawOutline(p, rectangle, null);
				}
			}
		}
	}
}
