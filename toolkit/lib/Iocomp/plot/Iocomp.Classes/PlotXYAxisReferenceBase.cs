using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Base Class for all Plot Objects Reference to a X & Y Axis.")]
	public abstract class PlotXYAxisReferenceBase : PlotObject
	{
		private string m_XAxisName;

		private string m_YAxisName;

		private PlotClippingStyle m_ClippingStyle;

		protected bool m_XYSwapped;

		private PlotXAxis m_CachedXAxis;

		private PlotYAxis m_CachedYAxis;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string XAxisName
		{
			get
			{
				if (this.m_XAxisName == null)
				{
					return Const.EmptyString;
				}
				return this.m_XAxisName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("XAxisName", value);
				if (this.XAxisName != value)
				{
					this.m_XAxisName = value;
					this.m_CachedXAxis = null;
					this.m_CachedXAxis = this.XAxis;
					base.DoPropertyChange(this, "XAxisName");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string YAxisName
		{
			get
			{
				if (this.m_YAxisName == null)
				{
					return Const.EmptyString;
				}
				return this.m_YAxisName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("YAxisName", value);
				if (this.YAxisName != value)
				{
					this.m_YAxisName = value;
					this.m_CachedYAxis = null;
					this.m_CachedYAxis = this.YAxis;
					base.DoPropertyChange(this, "YAxisName");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotClippingStyle ClippingStyle
		{
			get
			{
				return this.m_ClippingStyle;
			}
			set
			{
				base.PropertyUpdateDefault("ClippingStyle", value);
				if (this.ClippingStyle != value)
				{
					this.m_ClippingStyle = value;
					base.DoPropertyChange(this, "ClippingStyle");
				}
			}
		}

		[Description("")]
		public PlotXAxis XAxis
		{
			get
			{
				if (this.m_CachedXAxis != null)
				{
					return this.m_CachedXAxis;
				}
				if (base.Plot == null)
				{
					return null;
				}
				this.m_CachedXAxis = base.Plot.XAxes[this.XAxisName];
				return this.m_CachedXAxis;
			}
		}

		[Description("")]
		public PlotYAxis YAxis
		{
			get
			{
				if (this.m_CachedYAxis != null)
				{
					return this.m_CachedYAxis;
				}
				if (base.Plot == null)
				{
					return null;
				}
				this.m_CachedYAxis = base.Plot.YAxes[this.YAxisName];
				return this.m_CachedYAxis;
			}
		}

		[Description("")]
		public bool XYSwapped
		{
			get
			{
				return this.m_XYSwapped;
			}
		}

		protected override bool HitTestEnabled
		{
			get
			{
				if (base.Plot == null)
				{
					return false;
				}
				if (base.Plot.ToolBarAdapter.DataViewMouseMode != 0)
				{
					return false;
				}
				return true;
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.XAxisName = "X-Axis 1";
			this.YAxisName = "Y-Axis 1";
			this.ClippingStyle = PlotClippingStyle.Axes;
		}

		private bool ShouldSerializeXAxisName()
		{
			return base.PropertyShouldSerialize("XAxisName");
		}

		private void ResetXAxisName()
		{
			base.PropertyReset("XAxisName");
		}

		private bool ShouldSerializeYAxisName()
		{
			return base.PropertyShouldSerialize("YAxisName");
		}

		private void ResetYAxisName()
		{
			base.PropertyReset("YAxisName");
		}

		private bool ShouldSerializeClippingStyle()
		{
			return base.PropertyShouldSerialize("ClippingStyle");
		}

		private void ResetClippingStyle()
		{
			base.PropertyReset("ClippingStyle");
		}

		public override void ObjectRenamed(PlotObject value, string oldName)
		{
			base.ObjectRenamed(value, oldName);
			if (value is PlotXAxis && oldName == this.m_XAxisName)
			{
				this.m_XAxisName = value.Name;
			}
			else if (value is PlotYAxis && oldName == this.m_YAxisName)
			{
				this.m_YAxisName = value.Name;
			}
		}

		public override void ObjectRemoved(PlotObject value)
		{
			base.ObjectRemoved(value);
			if (value == this.m_CachedXAxis)
			{
				this.m_CachedXAxis = null;
			}
			else if (value == this.m_CachedYAxis)
			{
				this.m_CachedYAxis = null;
			}
		}

		public override void ObjectAdded(PlotObject value)
		{
			base.ObjectAdded(value);
			if (value is PlotXAxis && value.Name == this.m_XAxisName)
			{
				this.m_CachedXAxis = (value as PlotXAxis);
			}
			else if (value is PlotYAxis && value.Name == this.m_YAxisName)
			{
				this.m_CachedYAxis = (value as PlotYAxis);
			}
		}

		[Description("")]
		public Point GetPoint(double x, double y)
		{
			if (this.XAxis != null && this.YAxis != null)
			{
				if (!this.XYSwapped)
				{
					return new Point(this.XAxis.ScaleDisplay.ValueToPixels(x), this.YAxis.ScaleDisplay.ValueToPixels(y));
				}
				return new Point(this.YAxis.ScaleDisplay.ValueToPixels(y), this.XAxis.ScaleDisplay.ValueToPixels(x));
			}
			return Point.Empty;
		}

		[Description("")]
		public int GetDataViewYPixelsMin()
		{
			if (this.YAxis == null)
			{
				return 0;
			}
			return this.YAxis.DataViewPixelsMin;
		}

		[Description("")]
		public int GetDataViewYPixelsMax()
		{
			if (this.YAxis == null)
			{
				return 0;
			}
			return this.YAxis.DataViewPixelsMax;
		}

		[Description("")]
		public int GetDataViewXPixelsMin()
		{
			if (this.XAxis == null)
			{
				return 0;
			}
			return this.XAxis.DataViewPixelsMin;
		}

		[Description("")]
		public int GetDataViewXPixelsMax()
		{
			if (this.XAxis == null)
			{
				return 0;
			}
			return this.XAxis.DataViewPixelsMax;
		}

		[Description("")]
		public Point GetPixelPoint(int x, int y)
		{
			if (!this.XYSwapped)
			{
				return new Point(x, y);
			}
			return new Point(y, x);
		}

		[Description("")]
		public Rectangle GetRectangleLTWH(double left, double top, double width, double height)
		{
			if (this.XAxis != null && this.YAxis != null)
			{
				if (!this.XYSwapped)
				{
					return iRectangle.FromLTWH(this.XAxis.ScaleDisplay.ValueToPixels(left), this.YAxis.ScaleDisplay.ValueToPixels(top), this.XAxis.ScaleDisplay.ValueToSpanPixels(width), this.YAxis.ScaleDisplay.ValueToSpanPixels(height));
				}
				return iRectangle.FromLTWH(this.YAxis.ScaleDisplay.ValueToPixels(top), this.XAxis.ScaleDisplay.ValueToPixels(left), this.YAxis.ScaleDisplay.ValueToSpanPixels(height), this.XAxis.ScaleDisplay.ValueToSpanPixels(width));
			}
			return Rectangle.Empty;
		}

		[Description("")]
		public Rectangle GetRectangleLTRB(double left, double top, double right, double bottom)
		{
			if (this.XAxis != null && this.YAxis != null)
			{
				if (!this.XYSwapped)
				{
					return iRectangle.FromLTRB(this.XAxis.ScaleDisplay.ValueToPixels(left), this.YAxis.ScaleDisplay.ValueToPixels(top), this.XAxis.ScaleDisplay.ValueToPixels(right), this.YAxis.ScaleDisplay.ValueToPixels(bottom));
				}
				return iRectangle.FromLTRB(this.YAxis.ScaleDisplay.ValueToPixels(top), this.XAxis.ScaleDisplay.ValueToPixels(left), this.YAxis.ScaleDisplay.ValueToPixels(bottom), this.XAxis.ScaleDisplay.ValueToPixels(right));
			}
			return Rectangle.Empty;
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (this.XAxis == null)
			{
				base.CanDraw = false;
			}
			else if (this.YAxis == null)
			{
				base.CanDraw = false;
			}
			else if (this.XAxis.DockOrientation == this.YAxis.DockOrientation)
			{
				base.CanDraw = false;
			}
			else if (this.XAxis.DockDataView == null)
			{
				base.CanDraw = false;
			}
			else if (this.YAxis.DockDataView == null)
			{
				base.CanDraw = false;
			}
			else if (!this.XAxis.DockDataView.Visible)
			{
				base.CanDraw = false;
			}
			else if (!this.YAxis.DockDataView.Visible)
			{
				base.CanDraw = false;
			}
		}

		protected override void UpdateBoundsClip(PaintArgs p)
		{
			if (this.XAxis != null && this.YAxis != null)
			{
				this.m_XYSwapped = this.XAxis.DockHorizontal;
				int top = this.YAxis.ScaleDisplay.PixelsMin;
				int bottom = this.YAxis.ScaleDisplay.PixelsMax;
				int left = this.XAxis.ScaleDisplay.PixelsMin;
				int right = this.XAxis.ScaleDisplay.PixelsMax;
				if (this.ClippingStyle == PlotClippingStyle.DataView)
				{
					PlotDataView dockDataView = this.m_CachedYAxis.DockDataView;
					if (dockDataView != null)
					{
						if (!this.XYSwapped)
						{
							top = dockDataView.BoundsClip.Top;
							bottom = dockDataView.BoundsClip.Bottom;
						}
						else
						{
							top = dockDataView.BoundsClip.Left;
							bottom = dockDataView.BoundsClip.Right;
						}
					}
					dockDataView = this.XAxis.DockDataView;
					if (dockDataView != null)
					{
						if (!this.XYSwapped)
						{
							left = dockDataView.BoundsClip.Left;
							right = dockDataView.BoundsClip.Right;
						}
						else
						{
							left = dockDataView.BoundsClip.Top;
							right = dockDataView.BoundsClip.Bottom;
						}
					}
				}
				base.BoundsClip = iRectangle.FromLTRB(this.m_XYSwapped, left, top, right, bottom);
				base.BoundsClip = new Rectangle(base.BoundsClip.Left, base.BoundsClip.Top, base.BoundsClip.Width + 1, base.BoundsClip.Height + 1);
			}
		}

		protected void SetClipRect(PaintArgs p)
		{
			if (base.BoundsClip != Rectangle.Empty)
			{
				Rectangle boundsClip = base.BoundsClip;
				Rectangle clip = new Rectangle(boundsClip.Left, boundsClip.Top, boundsClip.Width + 1, boundsClip.Height + 1);
				p.Graphics.SetClip(clip);
			}
		}

		protected override void Draw(PaintArgs p)
		{
			this.SetClipRect(p);
			this.Draw(p, this.XAxis, this.YAxis);
		}

		protected override void DrawFocusRectangles(PaintArgs p)
		{
			if (base.BoundsClip != Rectangle.Empty)
			{
				p.Graphics.SetClip(base.BoundsClip);
			}
			this.DrawFocusRectangles(p, this.XAxis, this.YAxis);
		}

		protected virtual void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
		}

		protected virtual void DrawFocusRectangles(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
		}
	}
}
