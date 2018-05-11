using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Plot Brush.")]
	public class PlotBrush : SubClassBase, IPlotBrush
	{
		private Color m_GradientStartColor;

		private Color m_GradientStopColor;

		private PlotBrushStyle m_Style;

		private HatchStyle m_StyleGDI;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool Visible
		{
			get
			{
				return this.VisibleInternal;
			}
			set
			{
				this.VisibleInternal = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color SolidColor
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.PropertyUpdateDefault("SolidColor", value);
				base.Color = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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
		[Description("")]
		public Color HatchBackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.PropertyUpdateDefault("HatchBackColor", value);
				base.BackColor = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color HatchForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.PropertyUpdateDefault("HatchForeColor", value);
				base.ForeColor = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotBrushStyle Style
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
					if (this.m_Style == PlotBrushStyle.HatchBackwardDiagonal)
					{
						this.m_StyleGDI = HatchStyle.BackwardDiagonal;
					}
					else if (this.m_Style == PlotBrushStyle.HatchCross)
					{
						this.m_StyleGDI = HatchStyle.Cross;
					}
					else if (this.m_Style == PlotBrushStyle.HatchDarkDownwardDiagonal)
					{
						this.m_StyleGDI = HatchStyle.DarkDownwardDiagonal;
					}
					else if (this.m_Style == PlotBrushStyle.HatchDarkHorizontal)
					{
						this.m_StyleGDI = HatchStyle.DarkHorizontal;
					}
					else if (this.m_Style == PlotBrushStyle.HatchDarkUpwardDiagonal)
					{
						this.m_StyleGDI = HatchStyle.DarkUpwardDiagonal;
					}
					else if (this.m_Style == PlotBrushStyle.HatchDarkVertical)
					{
						this.m_StyleGDI = HatchStyle.DarkVertical;
					}
					else if (this.m_Style == PlotBrushStyle.HatchDashedDownwardDiagonal)
					{
						this.m_StyleGDI = HatchStyle.DashedDownwardDiagonal;
					}
					else if (this.m_Style == PlotBrushStyle.HatchDashedHorizontal)
					{
						this.m_StyleGDI = HatchStyle.DashedHorizontal;
					}
					else if (this.m_Style == PlotBrushStyle.HatchDashedUpwardDiagonal)
					{
						this.m_StyleGDI = HatchStyle.DashedUpwardDiagonal;
					}
					else if (this.m_Style == PlotBrushStyle.HatchDashedVertical)
					{
						this.m_StyleGDI = HatchStyle.DashedVertical;
					}
					else if (this.m_Style == PlotBrushStyle.HatchDiagonalBrick)
					{
						this.m_StyleGDI = HatchStyle.DiagonalBrick;
					}
					else if (this.m_Style == PlotBrushStyle.HatchDiagonalCross)
					{
						this.m_StyleGDI = HatchStyle.DiagonalCross;
					}
					else if (this.m_Style == PlotBrushStyle.HatchDivot)
					{
						this.m_StyleGDI = HatchStyle.Divot;
					}
					else if (this.m_Style == PlotBrushStyle.HatchDottedDiamond)
					{
						this.m_StyleGDI = HatchStyle.DottedDiamond;
					}
					else if (this.m_Style == PlotBrushStyle.HatchDottedGrid)
					{
						this.m_StyleGDI = HatchStyle.DottedGrid;
					}
					else if (this.m_Style == PlotBrushStyle.HatchForwardDiagonal)
					{
						this.m_StyleGDI = HatchStyle.ForwardDiagonal;
					}
					else if (this.m_Style == PlotBrushStyle.HatchHorizontal)
					{
						this.m_StyleGDI = HatchStyle.Horizontal;
					}
					else if (this.m_Style == PlotBrushStyle.HatchHorizontalBrick)
					{
						this.m_StyleGDI = HatchStyle.HorizontalBrick;
					}
					else if (this.m_Style == PlotBrushStyle.HatchLargeCheckerBoard)
					{
						this.m_StyleGDI = HatchStyle.LargeCheckerBoard;
					}
					else if (this.m_Style == PlotBrushStyle.HatchLargeConfetti)
					{
						this.m_StyleGDI = HatchStyle.LargeConfetti;
					}
					else if (this.m_Style == PlotBrushStyle.HatchLargeGrid)
					{
						this.m_StyleGDI = HatchStyle.Cross;
					}
					else if (this.m_Style == PlotBrushStyle.HatchLightDownwardDiagonal)
					{
						this.m_StyleGDI = HatchStyle.LightDownwardDiagonal;
					}
					else if (this.m_Style == PlotBrushStyle.HatchLightHorizontal)
					{
						this.m_StyleGDI = HatchStyle.LightHorizontal;
					}
					else if (this.m_Style == PlotBrushStyle.HatchLightUpwardDiagonal)
					{
						this.m_StyleGDI = HatchStyle.LightUpwardDiagonal;
					}
					else if (this.m_Style == PlotBrushStyle.HatchLightVertical)
					{
						this.m_StyleGDI = HatchStyle.LightVertical;
					}
					else if (this.m_Style == PlotBrushStyle.HatchMax)
					{
						this.m_StyleGDI = HatchStyle.Cross;
					}
					else if (this.m_Style == PlotBrushStyle.HatchMin)
					{
						this.m_StyleGDI = HatchStyle.Horizontal;
					}
					else if (this.m_Style == PlotBrushStyle.HatchNarrowHorizontal)
					{
						this.m_StyleGDI = HatchStyle.NarrowHorizontal;
					}
					else if (this.m_Style == PlotBrushStyle.HatchNarrowVertical)
					{
						this.m_StyleGDI = HatchStyle.NarrowVertical;
					}
					else if (this.m_Style == PlotBrushStyle.HatchOutlinedDiamond)
					{
						this.m_StyleGDI = HatchStyle.OutlinedDiamond;
					}
					else if (this.m_Style == PlotBrushStyle.HatchPercent05)
					{
						this.m_StyleGDI = HatchStyle.Percent05;
					}
					else if (this.m_Style == PlotBrushStyle.HatchPercent10)
					{
						this.m_StyleGDI = HatchStyle.Percent10;
					}
					else if (this.m_Style == PlotBrushStyle.HatchPercent20)
					{
						this.m_StyleGDI = HatchStyle.Percent20;
					}
					else if (this.m_Style == PlotBrushStyle.HatchPercent25)
					{
						this.m_StyleGDI = HatchStyle.Percent25;
					}
					else if (this.m_Style == PlotBrushStyle.HatchPercent30)
					{
						this.m_StyleGDI = HatchStyle.Percent30;
					}
					else if (this.m_Style == PlotBrushStyle.HatchPercent40)
					{
						this.m_StyleGDI = HatchStyle.Percent40;
					}
					else if (this.m_Style == PlotBrushStyle.HatchPercent50)
					{
						this.m_StyleGDI = HatchStyle.Percent50;
					}
					else if (this.m_Style == PlotBrushStyle.HatchPercent60)
					{
						this.m_StyleGDI = HatchStyle.Percent60;
					}
					else if (this.m_Style == PlotBrushStyle.HatchPercent70)
					{
						this.m_StyleGDI = HatchStyle.Percent70;
					}
					else if (this.m_Style == PlotBrushStyle.HatchPercent75)
					{
						this.m_StyleGDI = HatchStyle.Percent75;
					}
					else if (this.m_Style == PlotBrushStyle.HatchPercent80)
					{
						this.m_StyleGDI = HatchStyle.Percent80;
					}
					else if (this.m_Style == PlotBrushStyle.HatchPercent90)
					{
						this.m_StyleGDI = HatchStyle.Percent90;
					}
					else if (this.m_Style == PlotBrushStyle.HatchPlaid)
					{
						this.m_StyleGDI = HatchStyle.Plaid;
					}
					else if (this.m_Style == PlotBrushStyle.HatchShingle)
					{
						this.m_StyleGDI = HatchStyle.Shingle;
					}
					else if (this.m_Style == PlotBrushStyle.HatchSmallCheckerBoard)
					{
						this.m_StyleGDI = HatchStyle.SmallCheckerBoard;
					}
					else if (this.m_Style == PlotBrushStyle.HatchSmallConfetti)
					{
						this.m_StyleGDI = HatchStyle.SmallConfetti;
					}
					else if (this.m_Style == PlotBrushStyle.HatchSmallGrid)
					{
						this.m_StyleGDI = HatchStyle.SmallGrid;
					}
					else if (this.m_Style == PlotBrushStyle.HatchSolidDiamond)
					{
						this.m_StyleGDI = HatchStyle.SolidDiamond;
					}
					else if (this.m_Style == PlotBrushStyle.HatchSphere)
					{
						this.m_StyleGDI = HatchStyle.Sphere;
					}
					else if (this.m_Style == PlotBrushStyle.HatchTrellis)
					{
						this.m_StyleGDI = HatchStyle.Trellis;
					}
					else if (this.m_Style == PlotBrushStyle.HatchVertical)
					{
						this.m_StyleGDI = HatchStyle.Vertical;
					}
					else if (this.m_Style == PlotBrushStyle.HatchWave)
					{
						this.m_StyleGDI = HatchStyle.Wave;
					}
					else if (this.m_Style == PlotBrushStyle.HatchWeave)
					{
						this.m_StyleGDI = HatchStyle.Weave;
					}
					else if (this.m_Style == PlotBrushStyle.HatchWideDownwardDiagonal)
					{
						this.m_StyleGDI = HatchStyle.WideDownwardDiagonal;
					}
					else if (this.m_Style == PlotBrushStyle.HatchWideUpwardDiagonal)
					{
						this.m_StyleGDI = HatchStyle.WideUpwardDiagonal;
					}
					else
					{
						this.m_StyleGDI = HatchStyle.ZigZag;
					}
					base.DoPropertyChange(this, "Style");
				}
			}
		}

		private HatchStyle StyleGDI => this.m_StyleGDI;

		private float ModeAngle
		{
			get
			{
				if (this.Style == PlotBrushStyle.GradientHorizontal)
				{
					return 0f;
				}
				if (this.Style == PlotBrushStyle.GradientForwardDiagonal)
				{
					return 45f;
				}
				if (this.Style == PlotBrushStyle.GradientVertical)
				{
					return 90f;
				}
				return 135f;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Plot Brush";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotBrushEditorPlugIn";
		}

		Brush IPlotBrush.GetBrush(PaintArgs p, Rectangle rectangle)
		{
			return this.GetBrush(p, rectangle);
		}

		Brush IPlotBrush.GetBrush(PaintArgs p, Point[] points)
		{
			return this.GetBrush(p, points);
		}

		public PlotBrush()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.ColorAmbientSource = AmbientColorSouce.BackColor;
			this.Visible = true;
			this.Style = PlotBrushStyle.Solid;
			this.SolidColor = Color.Empty;
			this.GradientStartColor = Color.Blue;
			this.GradientStopColor = Color.Aqua;
			this.HatchBackColor = Color.Empty;
			this.HatchForeColor = Color.Empty;
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeSolidColor()
		{
			return base.PropertyShouldSerialize("SolidColor");
		}

		private void ResetSolidColor()
		{
			base.PropertyReset("SolidColor");
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

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private Brush GetBrush(PaintArgs p, Rectangle rectangle)
		{
			if (this.Style == PlotBrushStyle.Solid)
			{
				return p.Graphics.Brush(this.SolidColor);
			}
			if (this.Style == PlotBrushStyle.GradientBackwardDiagonal && rectangle.IsEmpty)
			{
				return null;
			}
			if (this.Style == PlotBrushStyle.GradientForwardDiagonal && rectangle.IsEmpty)
			{
				return null;
			}
			if (this.Style == PlotBrushStyle.GradientHorizontal && rectangle.IsEmpty)
			{
				return null;
			}
			if (this.Style == PlotBrushStyle.GradientVertical && rectangle.IsEmpty)
			{
				return null;
			}
			if (this.Style == PlotBrushStyle.GradientVertical && rectangle.Width <= 0)
			{
				return null;
			}
			if (this.Style == PlotBrushStyle.GradientVertical && rectangle.Height <= 0)
			{
				return null;
			}
			if (this.Style == PlotBrushStyle.GradientBackwardDiagonal)
			{
				return new LinearGradientBrush(rectangle, this.GradientStartColor, this.GradientStopColor, this.ModeAngle);
			}
			if (this.Style == PlotBrushStyle.GradientForwardDiagonal)
			{
				return new LinearGradientBrush(rectangle, this.GradientStartColor, this.GradientStopColor, this.ModeAngle);
			}
			if (this.Style == PlotBrushStyle.GradientHorizontal)
			{
				return new LinearGradientBrush(rectangle, this.GradientStartColor, this.GradientStopColor, this.ModeAngle);
			}
			if (this.Style == PlotBrushStyle.GradientVertical)
			{
				return new LinearGradientBrush(rectangle, this.GradientStartColor, this.GradientStopColor, this.ModeAngle);
			}
			return p.Graphics.Brush(this.StyleGDI, this.HatchForeColor, this.HatchBackColor);
		}

		private Brush GetBrush(PaintArgs p, Point[] points)
		{
			int num = 2147483647;
			int num2 = 2147483647;
			int num3 = -2147483648;
			int num4 = -2147483648;
			for (int i = 0; i < points.Length; i++)
			{
				num = Math.Min(num, points[i].X);
				num2 = Math.Min(num2, points[i].Y);
				num3 = Math.Max(num3, points[i].X);
				num4 = Math.Max(num4, points[i].Y);
			}
			return this.GetBrush(p, Rectangle.FromLTRB(num, num2, num3, num4));
		}
	}
}
