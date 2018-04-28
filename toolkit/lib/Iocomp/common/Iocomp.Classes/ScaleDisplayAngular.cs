using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Controls the scale display angular layout properties.")]
	public sealed class ScaleDisplayAngular : ScaleDisplay, IScaleDisplay, IScaleDisplayAngular
	{
		private DrawExtent m_DrawExtent;

		private StringAlignmentAngular m_TextAlignment;

		private int m_Radius;

		private int m_Margin;

		private int m_HubRadius;

		private Point m_CenterPoint;

		private int m_MaxRequiredWidth;

		private int m_MaxRequiredHeight;

		int IScaleDisplayAngular.Radius
		{
			get
			{
				return this.Radius;
			}
			set
			{
				this.Radius = value;
			}
		}

		int IScaleDisplayAngular.HubRadius
		{
			get
			{
				return this.HubRadius;
			}
			set
			{
				this.HubRadius = value;
			}
		}

		Point IScaleDisplayAngular.CenterPoint
		{
			get
			{
				return this.CenterPoint;
			}
			set
			{
				this.CenterPoint = value;
			}
		}

		Size IScaleDisplayAngular.RequiredSize
		{
			get
			{
				return new Size(this.m_MaxRequiredWidth, this.m_MaxRequiredHeight);
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public StringAlignmentAngular TextAlignment
		{
			get
			{
				return this.m_TextAlignment;
			}
			set
			{
				base.PropertyUpdateDefault("TextAlignment", value);
				if (this.TextAlignment != value)
				{
					this.m_TextAlignment = value;
					base.DoPropertyChange(this, "TextAlignment");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int Margin
		{
			get
			{
				return this.m_Margin;
			}
			set
			{
				base.PropertyUpdateDefault("Margin", value);
				if (this.Margin != value)
				{
					this.m_Margin = value;
					base.DoPropertyChange(this, "Margin");
				}
			}
		}

		private int Radius
		{
			get
			{
				return this.m_Radius;
			}
			set
			{
				this.m_Radius = value;
			}
		}

		private int HubRadius
		{
			get
			{
				return this.m_HubRadius;
			}
			set
			{
				this.m_HubRadius = value;
			}
		}

		private Point CenterPoint
		{
			get
			{
				return this.m_CenterPoint;
			}
			set
			{
				this.m_CenterPoint = value;
			}
		}

		private IScaleRangeAngular I_Range => base.ScaleRange as IScaleRangeAngular;

		public override int PixelsSpan => (int)(6.2831853071795862 * (double)this.Radius / 360.0 * (base.ScaleRange as IScaleRangeAngular).AngleSpan);

		protected override string GetPlugInTitle()
		{
			return "Scale Display";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleDisplayAngularEditorPlugIn";
		}

		Point IScaleDisplayAngular.GetScalePoint(double value, float radius)
		{
			return this.GetScalePoint(value, (double)radius);
		}

		public ScaleDisplayAngular()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			this.m_DrawExtent = new DrawExtent();
			base.CreateObjects();
		}

		private bool ShouldSerializeTextAlignment()
		{
			return base.PropertyShouldSerialize("TextAlignment");
		}

		private void ResetTextAlignment()
		{
			base.PropertyReset("TextAlignment");
		}

		private bool ShouldSerializeMargin()
		{
			return base.PropertyShouldSerialize("Margin");
		}

		private void ResetMargin()
		{
			base.PropertyReset("Margin");
		}

		protected override int GetMaxTicks()
		{
			Size size = base.TickInfo.Painter.Graphics.MeasureString("0", base.TickMajor.Font, true);
			double num = base.TickInfo.MinTextSpacing * (double)size.Height;
			string text = base.TextFormatting.GetText(base.ScaleRange.Min);
			double num2 = (double)base.TickInfo.Painter.Graphics.MeasureString(text, base.TickMajor.Font, true).Height;
			base.TickInfo.LabelMaxWidth = (int)Math.Round(num2 + num);
			int num3 = base.TickInfo.PixelSpanCalculation / base.TickInfo.LabelMaxWidth;
			if (num3 < 1)
			{
				return 1;
			}
			return num3;
		}

		protected override bool GetValueOnScale(double value)
		{
			return Math2.InRangeDelta(value, base.ScaleRange.Min, base.ScaleRange.Max);
		}

		private Point GetScalePoint(double value, double radius)
		{
			double angle = this.I_Range.ValueToAngle(value);
			return Math2.ToRotatedPoint(angle, radius, this.CenterPoint);
		}

		private Point GetTickPoint(IScaleTickBase tick, float radius)
		{
			double angle = this.I_Range.ValueToAngle(tick.Value);
			double num;
			switch ((!(tick is ScaleTickMinor)) ? ((tick is ScaleTickMid) ? (tick as ScaleTickMid).Alignment : AlignmentStyle.Near) : (tick as ScaleTickMinor).Alignment)
			{
			case AlignmentStyle.Center:
				num = (double)((float)(base.TickMajor.Length - tick.Length) / 2f);
				break;
			case AlignmentStyle.Far:
				num = (double)(base.TickMajor.Length - tick.Length);
				break;
			default:
				num = 0.0;
				break;
			}
			return Math2.ToRotatedPoint(angle, (double)(radius + (float)this.Margin) + num, this.CenterPoint);
		}

		protected override Point GetTickPoint(IScaleTickBase tick)
		{
			return this.GetTickPoint(tick, (float)this.Radius);
		}

		protected override Point[] GetTickLine(IScaleTickBase tick)
		{
			return new Point[2]
			{
				this.GetTickPoint(tick, (float)this.Radius),
				this.GetTickPoint(tick, (float)(this.Radius + tick.Length))
			};
		}

		private double GetTextAngle(IScaleTickLabel tick)
		{
			if (this.TextAlignment != StringAlignmentAngular.RadialOuter && this.TextAlignment != StringAlignmentAngular.RadialInner)
			{
				return 0.0;
			}
			return this.I_Range.ValueToAngle(tick.Value);
		}

		private Rectangle GetTextRect(PaintArgs p, IScaleTickLabel tick)
		{
			double num = Math2.AngleNormalized(this.I_Range.ValueToAngle(tick.Value));
			float num2 = (float)tick.TextSize.Width;
			float num3 = (float)tick.TextSize.Height;
			Size size = p.Graphics.MeasureString(base.TickMajor.Font);
			Point point = default(Point);
			Rectangle result = default(Rectangle);
			if (this.TextAlignment == StringAlignmentAngular.Center)
			{
				float num4 = (float)(this.Radius + this.Margin + base.TickMajor.Length + tick.TextMargin + tick.TextMaxSize.Width / 2);
				point = new Point((int)(Math2.Cos(num) * (double)num4 + (double)this.CenterPoint.X), (int)(Math2.Sin(num) * (double)num4 + (double)this.CenterPoint.Y));
				result = new Rectangle((int)((float)point.X - num2 / 2f), (int)((float)point.Y - num3 / 2f), (int)num2, (int)num3);
				goto IL_0479;
			}
			if (this.TextAlignment == StringAlignmentAngular.Justified)
			{
				float num5 = (float)Math.Sqrt((double)(size.Width * size.Width + size.Height * size.Height)) / 2f;
				float num4 = (float)(this.Radius + base.TickMajor.Length + tick.TextMargin) + num5;
				point = new Point((int)(Math2.Cos(num) * (double)num4 + (double)this.CenterPoint.X), (int)(Math2.Sin(num) * (double)num4 + (double)this.CenterPoint.Y));
				result = new Rectangle((int)((float)point.X - num2 / 2f), (int)((float)point.Y - num3 / 2f), (int)num2, (int)num3);
				if (num == 0.0)
				{
					result.Offset((int)(num2 / 2f - (float)(size.Width / 2)), 0);
				}
				else if (num == 180.0)
				{
					result.Offset((int)((0f - num2) / 2f + (float)(size.Width / 2)), 0);
				}
				else if (num > 0.0 && num < 90.0)
				{
					result.Offset((int)(num2 / 2f - (float)(size.Width / 2)), 0);
				}
				else if (num > 90.0 && num < 270.0)
				{
					result.Offset((int)((0f - num2) / 2f + (float)(size.Width / 2)), 0);
				}
				else if (num > 270.0 && num < 360.0)
				{
					result.Offset((int)(num2 / 2f - (float)(size.Width / 2)), 0);
				}
				goto IL_0479;
			}
			Point point2 = default(Point);
			if (this.TextAlignment == StringAlignmentAngular.RadialOuter)
			{
				float num6 = (float)(this.Radius + base.TickMajor.Length + tick.TextMargin + tick.TextSize.Width / 2);
				point2 = new Point((int)(Math2.Cos(num) * (double)num6 + (double)this.CenterPoint.X), (int)(Math2.Sin(num) * (double)num6 + (double)this.CenterPoint.Y));
				result = new Rectangle(point2.X - tick.TextSize.Width / 2, point2.Y - tick.TextSize.Height / 2, tick.TextSize.Width, tick.TextSize.Height);
				goto IL_0479;
			}
			if (this.TextAlignment == StringAlignmentAngular.RadialInner)
			{
				float num6 = (float)(this.Radius - tick.TextMargin - tick.TextMaxSize.Width / 2);
				point2 = new Point((int)(Math2.Cos(num) * (double)num6 + (double)this.CenterPoint.X), (int)(Math2.Sin(num) * (double)num6 + (double)this.CenterPoint.Y));
				result = new Rectangle(point2.X - tick.TextMaxSize.Width / 2, point2.Y - tick.TextMaxSize.Height / 2, tick.TextMaxSize.Width, tick.TextMaxSize.Height);
				goto IL_0479;
			}
			result = Rectangle.Empty;
			return result;
			IL_0479:
			return result;
		}

		protected override void DrawTickLine(PaintArgs p, IScaleTickBase tick)
		{
			Point[] tickLine = this.GetTickLine(tick);
			p.Graphics.DrawLine(p.Graphics.Pen(tick.Color, (float)tick.Thickness), tickLine[0], tickLine[1]);
		}

		protected override void DrawTickLabel(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format)
		{
			if (this.TextAlignment == StringAlignmentAngular.Center)
			{
				this.DrawTickLabelHorizontalCenter(p, tick, format);
			}
			else if (this.TextAlignment == StringAlignmentAngular.Justified)
			{
				this.DrawTickLabelHorizontalJustified(p, tick, format);
			}
			else if (this.TextAlignment == StringAlignmentAngular.RadialOuter)
			{
				this.DrawTickLabelRotatedOuter(p, tick, format);
			}
			else if (this.TextAlignment == StringAlignmentAngular.RadialInner)
			{
				this.DrawTickLabelRotatedInner(p, tick, format);
			}
		}

		private void DrawTickLabelRotatedOuter(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format)
		{
			double num = this.I_Range.ValueToAngle(tick.Value);
			Rectangle textRect = this.GetTextRect(p, tick);
			Point point = Math2.ToCenterPoint(textRect);
			GraphicsState gstate = p.Graphics.Save();
			p.Graphics.TranslateTransform((float)point.X, (float)point.Y);
			p.Graphics.RotateTransform(180f + (float)num);
			p.Graphics.TranslateTransform((float)(-point.X), (float)(-point.Y));
			p.Graphics.DrawString(tick.Text, tick.Font, p.Graphics.Brush(tick.ForeColor), textRect, format);
			p.Graphics.Restore(gstate);
		}

		private void DrawTickLabelRotatedInner(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format)
		{
			format.Alignment = StringAlignment.Far;
			double num = this.I_Range.ValueToAngle(tick.Value);
			Rectangle textRect = this.GetTextRect(p, tick);
			Point point = Math2.ToCenterPoint(textRect);
			GraphicsState gstate = p.Graphics.Save();
			p.Graphics.TranslateTransform((float)point.X, (float)point.Y);
			p.Graphics.RotateTransform(180f + (float)num);
			p.Graphics.TranslateTransform((float)(-point.X), (float)(-point.Y));
			p.Graphics.DrawString(tick.Text, tick.Font, p.Graphics.Brush(tick.ForeColor), textRect, format);
			p.Graphics.Restore(gstate);
		}

		private void DrawTickLabelHorizontalJustified(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format)
		{
			p.Graphics.DrawString(tick.Text, tick.Font, p.Graphics.Brush(tick.ForeColor), this.GetTextRect(p, tick), format);
		}

		private void DrawTickLabelHorizontalCenter(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format)
		{
			p.Graphics.DrawString(tick.Text, tick.Font, p.Graphics.Brush(tick.ForeColor), this.GetTextRect(p, tick), format);
		}

		protected override void DrawInternal(PaintArgs p, DrawStringFormat stringFormat)
		{
			foreach (IScaleTickBase tick in base.TickList)
			{
				if ((this.Range as ScaleRangeAngular).AngleSpan == 360.0)
				{
					if (base.TickList[base.TickList.Count - 1] != tick)
					{
						tick.Draw(p, stringFormat, base.TickMajor.Length);
					}
				}
				else
				{
					tick.Draw(p, stringFormat, base.TickMajor.Length);
				}
			}
			float num = (float)this.I_Range.ValueToAngle(base.ScaleRange.Min);
			float num2 = (float)this.I_Range.ValueToAngle(base.ScaleRange.Max);
			Rectangle rect = default(Rectangle);
			if (base.LineInnerVisible)
			{
				int num3 = this.Radius + this.Margin;
				rect = new Rectangle(this.CenterPoint.X - num3, this.CenterPoint.Y - num3, 2 * num3, 2 * num3);
				p.Graphics.DrawArc(p.Graphics.Pen(base.TickMajor.Color, (float)base.LineThickness), rect, num, num2 - num);
			}
			if (base.LineOuterVisible)
			{
				int num3 = this.Radius + this.Margin + base.TickMajor.Length;
				rect = new Rectangle(this.CenterPoint.X - num3, this.CenterPoint.Y - num3, 2 * num3, 2 * num3);
				p.Graphics.DrawArc(p.Graphics.Pen(base.TickMajor.Color, (float)base.LineThickness), rect, num, num2 - num);
			}
		}

		protected override void UpdateScaleExtents(PaintArgs p)
		{
			Rectangle drawRectangle = p.DrawRectangle;
			Rectangle value = new Rectangle(this.CenterPoint.X - this.HubRadius, this.CenterPoint.Y - this.HubRadius, 2 * this.HubRadius, 2 * this.HubRadius);
			this.m_DrawExtent.Reset();
			this.m_DrawExtent.Add(this.CenterPoint);
			this.m_DrawExtent.Add(value);
			for (int i = 0; i < base.TickList.Count; i++)
			{
				Point[] tickLine = this.GetTickLine(base.TickList[i] as IScaleTickBase);
				this.m_DrawExtent.Add(tickLine[0], tickLine[1]);
				if (base.TickList[i] is IScaleTickLabel)
				{
					IScaleTickLabel scaleTickLabel = base.TickList[i] as IScaleTickLabel;
					if (scaleTickLabel.TextVisible)
					{
						Rectangle textRect = this.GetTextRect(p, scaleTickLabel);
						double textAngle = this.GetTextAngle(scaleTickLabel);
						Point[] array = Math2.ToRotatedPoints(textAngle, textRect);
						for (int j = 0; j < array.Length; j++)
						{
							this.m_DrawExtent.Add(array[j]);
						}
					}
				}
			}
			this.m_MaxRequiredWidth = this.m_DrawExtent.MaxWidth + 4;
			this.m_MaxRequiredHeight = this.m_DrawExtent.MaxHeight + 4;
			this.CenterPoint = this.m_DrawExtent.GetNewCenterPoint(this.CenterPoint, drawRectangle);
		}

		protected override void ScaleInitializeTickInfo()
		{
		}
	}
}
