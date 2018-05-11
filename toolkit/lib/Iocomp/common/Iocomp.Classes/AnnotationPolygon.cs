using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Serializable]
	public sealed class AnnotationPolygon : AnnotationShape
	{
		private PointDoubleCollection m_Points;

		private PointDoubleCollection m_PointsCached;

		protected override IComponentBase ComponentBase
		{
			get
			{
				return base.ComponentBase;
			}
			set
			{
				base.ComponentBase = value;
				((ICollectionBase)this.m_Points).ComponentBase = value;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PointDoubleCollection Points
		{
			get
			{
				return this.m_Points;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		[Category("Iocomp")]
		public override double X
		{
			get
			{
				if (this.m_Points.Count == 0)
				{
					return 0.0;
				}
				double num = this.m_Points[0].X;
				double num2 = this.m_Points[0].X;
				for (int i = 1; i < this.m_Points.Count; i++)
				{
					num = Math.Max(num, this.m_Points[i].X);
					num2 = Math.Min(num2, this.m_Points[i].X);
				}
				return (num + num2) / 2.0;
			}
			set
			{
				double num = value - this.X;
				for (int i = 0; i < this.m_Points.Count; i++)
				{
					this.m_Points[i].X += num;
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		public override double Y
		{
			get
			{
				if (this.m_Points.Count == 0)
				{
					return 0.0;
				}
				double num = this.m_Points[0].Y;
				double num2 = this.m_Points[0].Y;
				for (int i = 1; i < this.m_Points.Count; i++)
				{
					num = Math.Max(num, this.m_Points[i].Y);
					num2 = Math.Min(num2, this.m_Points[i].Y);
				}
				return (num + num2) / 2.0;
			}
			set
			{
				double num = value - this.Y;
				for (int i = 0; i < this.m_Points.Count; i++)
				{
					this.m_Points[i].Y += num;
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		public override double Height
		{
			get
			{
				if (this.m_Points.Count == 0)
				{
					return 0.0;
				}
				double num = this.m_Points[0].Y;
				double num2 = this.m_Points[0].Y;
				for (int i = 1; i < this.m_Points.Count; i++)
				{
					num = Math.Max(num, this.m_Points[i].Y);
					num2 = Math.Min(num2, this.m_Points[i].Y);
				}
				return num - num2;
			}
			set
			{
				double num = value / this.Height;
				for (int i = 0; i < this.m_Points.Count; i++)
				{
					this.m_Points[i].Y = (this.m_Points[i].Y - base.Top) * num + base.Top;
				}
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public override double Width
		{
			get
			{
				if (this.m_Points.Count == 0)
				{
					return 0.0;
				}
				double num = this.m_Points[0].X;
				double num2 = this.m_Points[0].X;
				for (int i = 1; i < this.m_Points.Count; i++)
				{
					num = Math.Max(num, this.m_Points[i].X);
					num2 = Math.Min(num2, this.m_Points[i].X);
				}
				return num - num2;
			}
			set
			{
				double left = base.Left;
				double num = value / this.Width;
				for (int i = 0; i < this.m_Points.Count; i++)
				{
					this.m_Points[i].X = (this.m_Points[i].X - left) * num + left;
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation Polygon";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnnotationPolygonEditorPlugIn";
		}

		public AnnotationPolygon()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Points = new PointDoubleCollection(this.ComponentBase);
			this.m_Points.Changed += this.m_Points_Changed;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.X = 0.0;
			this.Y = 0.0;
		}

		private bool ShouldSerializePoints()
		{
			return this.Points.Count != 0;
		}

		private void ResetPoints()
		{
			this.Points.Clear();
		}

		private bool ShouldSerializeX()
		{
			return false;
		}

		private void ResetX()
		{
		}

		private bool ShouldSerializeY()
		{
			return false;
		}

		private void ResetY()
		{
		}

		private bool ShouldSerializeHeight()
		{
			return false;
		}

		private void ResetHeight()
		{
		}

		private bool ShouldSerializeWidth()
		{
			return false;
		}

		private void ResetWidth()
		{
		}

		protected override void SetXAndWidth(double x, double width)
		{
			double left = base.Left;
			double num = width / this.Width;
			double num2 = x - this.X;
			for (int i = 0; i < this.m_Points.Count; i++)
			{
				this.m_Points[i].X = (this.m_Points[i].X - left) * num + left + num2;
			}
		}

		protected override void SetYAndHeight(double y, double height)
		{
			double top = base.Top;
			double num = height / this.Height;
			double num2 = y - this.Y;
			for (int i = 0; i < this.m_Points.Count; i++)
			{
				this.m_Points[i].Y = (this.m_Points[i].Y - top) * num + top + num2;
			}
		}

		protected override void DragX(double original, double delta)
		{
			for (int i = 0; i < this.m_Points.Count; i++)
			{
				this.m_Points[i].X = this.m_PointsCached[i].X + delta;
			}
		}

		protected override void DragY(double original, double delta)
		{
			for (int i = 0; i < this.m_Points.Count; i++)
			{
				this.m_Points[i].Y = this.m_PointsCached[i].Y + delta;
			}
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			base.InternalOnMouseLeft(e, shouldFocus);
			this.m_PointsCached = new PointDoubleCollection(null);
			for (int i = 0; i < this.m_Points.Count; i++)
			{
				PointDouble pointDouble = new PointDouble();
				pointDouble.X = this.m_Points[i].X;
				pointDouble.Y = this.m_Points[i].Y;
				this.m_PointsCached.Add(pointDouble);
			}
		}

		private void m_Points_Changed(object sender, EventArgs e)
		{
			base.DoPropertyChange(this, "PointsChanged");
		}

		protected override void DrawOutline(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.DrawPolygon(p.Graphics.Pen(base.OutlineColor, base.DashStyle), points);
		}

		protected override void DrawFillHatch(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.FillPolygon(p.Graphics.Brush(base.HatchStyle, base.HatchForeColor, base.HatchBackColor), points);
		}

		protected override void DrawFillGradient(PaintArgs p, Rectangle rect, Point[] points)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddPolygon(points);
			p.Graphics.FillGradientPath(rect, graphicsPath, base.GradientStartColor, base.GradientStopColor, base.ModeAngle, 1f, false);
		}

		protected override void DrawFillSolid(PaintArgs p, Rectangle rect, Point[] points)
		{
			p.Graphics.FillPolygon(p.Graphics.Brush(base.FillColor), points);
		}

		protected override void DrawCustom(PaintArgs p)
		{
			if (this.m_Points.Count >= 2)
			{
				Point[] array = new Point[this.m_Points.Count];
				for (int i = 0; i < this.m_Points.Count; i++)
				{
					array[i] = new Point(this.Scale.ConvertUnitsToPixelsX(this.m_Points[i].X), this.Scale.ConvertUnitsToPixelsY(this.m_Points[i].Y));
				}
				Rectangle rectangle = new Rectangle(this.Scale.ConvertUnitsToPixelsX(base.Left), this.Scale.ConvertUnitsToPixelsY(base.Top), this.Scale.ConvertWidthUnitsToPixels(this.Width), this.Scale.ConvertHeightUnitsToPixels(this.Height));
				base.ClickRegion = new Region(rectangle);
				base.UpdateGrabHandles(rectangle);
				if (rectangle.Height != 0 && rectangle.Width != 0)
				{
					if (base.FillStyle != AnnotationFillStyle.Clear)
					{
						base.DrawFill(p, rectangle, array);
					}
					rectangle = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width - 1, rectangle.Height - 1);
					if (rectangle.Height != 0 && rectangle.Width != 0 && base.OutlineStyle != AnnotationOutlineStyle.Clear)
					{
						this.DrawOutline(p, rectangle, array);
					}
				}
			}
		}

		public override string ToString()
		{
			return "Annotation Polygon";
		}
	}
}
