using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public sealed class AnnotationLine : AnnotationOutline
	{
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Point1X
		{
			get
			{
				return this.X - this.Width / 2.0;
			}
			set
			{
				if (this.Point1X != value)
				{
					double point2X = this.Point2X;
					this.Width = point2X - value;
					this.X = (point2X + value) / 2.0;
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Point2X
		{
			get
			{
				return this.X + this.Width / 2.0;
			}
			set
			{
				if (this.Point2X != value)
				{
					double point1X = this.Point1X;
					this.Width = value - point1X;
					this.X = (point1X + value) / 2.0;
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Point1Y
		{
			get
			{
				return this.Y - this.Height / 2.0;
			}
			set
			{
				if (this.Point1Y != value)
				{
					double point2Y = this.Point2Y;
					this.Height = point2Y - value;
					this.Y = (point2Y + value) / 2.0;
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double Point2Y
		{
			get
			{
				return this.Y + this.Height / 2.0;
			}
			set
			{
				if (this.Point2Y != value)
				{
					double point1Y = this.Point1Y;
					this.Height = value - point1Y;
					this.Y = (point1Y + value) / 2.0;
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation Line";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnnotationLineEditorPlugIn";
		}

		public AnnotationLine()
		{
			base.DoCreate();
		}

		private bool ShouldSerializePoint1X()
		{
			if (!base.PropertyShouldSerialize("X"))
			{
				return base.PropertyShouldSerialize("Width");
			}
			return true;
		}

		private bool ShouldSerializePoint2X()
		{
			if (!base.PropertyShouldSerialize("X"))
			{
				return base.PropertyShouldSerialize("Width");
			}
			return true;
		}

		private bool ShouldSerializePoint1Y()
		{
			if (!base.PropertyShouldSerialize("Y"))
			{
				return base.PropertyShouldSerialize("Height");
			}
			return true;
		}

		private bool ShouldSerializePoint2Y()
		{
			if (!base.PropertyShouldSerialize("Y"))
			{
				return base.PropertyShouldSerialize("Height");
			}
			return true;
		}

		protected override void DrawOutline(PaintArgs p, Rectangle rect, Point[] points)
		{
			Point pt = new Point(this.Scale.ConvertUnitsToPixelsX(this.Point1X), this.Scale.ConvertUnitsToPixelsY(this.Point1Y));
			Point pt2 = new Point(this.Scale.ConvertUnitsToPixelsX(this.Point2X), this.Scale.ConvertUnitsToPixelsY(this.Point2Y));
			p.Graphics.DrawLine(p.Graphics.Pen(base.OutlineColor, base.DashStyle), pt, pt2);
		}

		protected override void DrawCustom(PaintArgs p)
		{
			Rectangle r = new Rectangle(this.Scale.ConvertUnitsToPixelsX(base.Left), this.Scale.ConvertUnitsToPixelsY(base.Top), this.Scale.ConvertWidthUnitsToPixels(this.Width), this.Scale.ConvertHeightUnitsToPixels(this.Height));
			base.ClickRegion = this.ToClickRegion(r);
			base.UpdateGrabHandles(r);
			if (base.OutlineStyle != AnnotationOutlineStyle.Clear)
			{
				this.DrawOutline(p, r, null);
			}
		}

		public override string ToString()
		{
			return "Annotation Line";
		}
	}
}
