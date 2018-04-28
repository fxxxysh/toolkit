using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public class PlotAnnotationLine : PlotAnnotationOutlineBase
	{
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
			return "Iocomp.Design.PlotAnnotationLineEditorPlugIn";
		}

		public PlotAnnotationLine()
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
			base.NameShort = "Line";
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

		protected override void DrawCustom(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			Rectangle rectangle = iRectangle.FromLTRB(base.XYSwapped, base.XMinPixels, base.YMinPixels, base.XMaxPixels, base.YMaxPixels);
			if (!base.BoundsClip.IntersectsWith(rectangle))
			{
				base.ClickRegion = null;
			}
			else
			{
				base.ClickRegion = new Region(rectangle);
				base.UpdateGrabHandles(rectangle);
				if (!base.XYSwapped)
				{
					base.I_Pen.DrawLine(p, new Point(base.GetXPixels(this.Point1X), base.GetYPixels(this.Point1Y)), new Point(base.GetXPixels(this.Point2X), base.GetYPixels(this.Point2Y)));
				}
				else
				{
					base.I_Pen.DrawLine(p, new Point(base.GetYPixels(this.Point1Y), base.GetXPixels(this.Point1X)), new Point(base.GetYPixels(this.Point2Y), base.GetXPixels(this.Point2X)));
				}
			}
		}
	}
}
