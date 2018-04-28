using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public abstract class PlotAnnotationBase : PlotXYAxisReferenceBase
	{
		private bool m_UserCanMove;

		private bool m_UserCanSize;

		private double m_Rotation;

		private Region m_ClickRegion;

		private GrabHandle[] m_GrabHandles;

		private double m_MouseDownUnitsX;

		private double m_MouseDownUnitsY;

		private int m_MouseDownXPixels;

		private int m_MouseDownYPixels;

		private double m_MouseDownX;

		private double m_MouseDownY;

		private double m_MouseDownLeft;

		private double m_MouseDownTop;

		private double m_MouseDownRight;

		private double m_MouseDownBottom;

		private double m_MouseDownWidth;

		private double m_MouseDownHeight;

		private EditMode m_MouseDownEditMode;

		private double m_Width;

		private double m_Height;

		private double m_X;

		private double m_Y;

		private PlotUnitType m_UnitTypeAll;

		private PlotUnitType m_UnitTypeLocation;

		private PlotUnitType m_UnitTypeSize;

		private PlotUnitType m_UnitTypeX;

		private PlotUnitType m_UnitTypeY;

		private PlotUnitType m_UnitTypeWidth;

		private PlotUnitType m_UnitTypeHeight;

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public double Rotation
		{
			get
			{
				return this.m_Rotation;
			}
			set
			{
				base.PropertyUpdateDefault("Rotation", value);
				if (this.Rotation != value)
				{
					this.m_Rotation = value;
					base.DoPropertyChange(this, "Rotation");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public bool UserCanMove
		{
			get
			{
				return this.m_UserCanMove;
			}
			set
			{
				base.PropertyUpdateDefault("UserCanMove", value);
				if (this.UserCanMove != value)
				{
					this.m_UserCanMove = value;
					base.DoPropertyChange(this, "UserCanMove");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public bool UserCanSize
		{
			get
			{
				return this.m_UserCanSize;
			}
			set
			{
				base.PropertyUpdateDefault("UserCanSize", value);
				if (this.UserCanSize != value)
				{
					this.m_UserCanSize = value;
					base.DoPropertyChange(this, "UserCanSize");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public virtual double Width
		{
			get
			{
				return this.m_Width;
			}
			set
			{
				base.PropertyUpdateDefault("Width", value);
				if (this.Width != value)
				{
					this.m_Width = value;
					base.DoPropertyChange(this, "Width");
				}
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public virtual double Height
		{
			get
			{
				return this.m_Height;
			}
			set
			{
				base.PropertyUpdateDefault("Height", value);
				if (this.Height != value)
				{
					this.m_Height = value;
					base.DoPropertyChange(this, "Height");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public virtual double X
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

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public virtual double Y
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

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotUnitType UnitTypeAll
		{
			get
			{
				return this.m_UnitTypeAll;
			}
			set
			{
				base.PropertyUpdateDefault("UnitTypeAll", value);
				if (this.UnitTypeAll != value)
				{
					this.m_UnitTypeAll = value;
					base.DoPropertyChange(this, "UnitTypeAll");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Category("Iocomp")]
		public PlotUnitType UnitTypeLocation
		{
			get
			{
				return this.m_UnitTypeLocation;
			}
			set
			{
				base.PropertyUpdateDefault("UnitTypeLocation", value);
				if (this.UnitTypeLocation != value)
				{
					this.m_UnitTypeLocation = value;
					base.DoPropertyChange(this, "UnitTypeLocation");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public PlotUnitType UnitTypeSize
		{
			get
			{
				return this.m_UnitTypeSize;
			}
			set
			{
				base.PropertyUpdateDefault("UnitTypeSize", value);
				if (this.UnitTypeSize != value)
				{
					this.m_UnitTypeSize = value;
					base.DoPropertyChange(this, "UnitTypeSize");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotUnitType UnitTypeX
		{
			get
			{
				return this.m_UnitTypeX;
			}
			set
			{
				base.PropertyUpdateDefault("UnitTypeX", value);
				if (this.UnitTypeX != value)
				{
					this.m_UnitTypeX = value;
					base.DoPropertyChange(this, "UnitTypeX");
				}
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotUnitType UnitTypeY
		{
			get
			{
				return this.m_UnitTypeY;
			}
			set
			{
				base.PropertyUpdateDefault("UnitTypeY", value);
				if (this.UnitTypeY != value)
				{
					this.m_UnitTypeY = value;
					base.DoPropertyChange(this, "UnitTypeY");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public PlotUnitType UnitTypeWidth
		{
			get
			{
				return this.m_UnitTypeWidth;
			}
			set
			{
				base.PropertyUpdateDefault("UnitTypeWidth", value);
				if (this.UnitTypeWidth != value)
				{
					this.m_UnitTypeWidth = value;
					base.DoPropertyChange(this, "UnitTypeWidth");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotUnitType UnitTypeHeight
		{
			get
			{
				return this.m_UnitTypeHeight;
			}
			set
			{
				base.PropertyUpdateDefault("UnitTypeHeight", value);
				if (this.UnitTypeHeight != value)
				{
					this.m_UnitTypeHeight = value;
					base.DoPropertyChange(this, "UnitTypeHeight");
				}
			}
		}

		private Color SolidColor => base.Color;

		private Color HatchForeColor => base.Color;

		private Color HatchBackColor
		{
			get
			{
				if (this.ControlBase != null)
				{
					return this.ControlBase.BackColor;
				}
				return Color.Empty;
			}
		}

		protected Region ClickRegion
		{
			get
			{
				return this.m_ClickRegion;
			}
			set
			{
				if (this.m_ClickRegion != value)
				{
					if (this.m_ClickRegion != null)
					{
						this.m_ClickRegion.Dispose();
					}
					this.m_ClickRegion = value;
				}
			}
		}

		private GrabHandle[] GrabHandles
		{
			get
			{
				if (this.m_GrabHandles != null)
				{
					return this.m_GrabHandles;
				}
				this.m_GrabHandles = new GrabHandle[8];
				for (int i = 0; i < this.m_GrabHandles.Length; i++)
				{
					this.m_GrabHandles[i] = new GrabHandle();
					this.m_GrabHandles[i].Rectangle = Rectangle.Empty;
					this.m_GrabHandles[i].Enabled = true;
				}
				return this.m_GrabHandles;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public double Left
		{
			get
			{
				return this.XValue - this.WidthValue / 2.0;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public double Top
		{
			get
			{
				return this.YValue + this.HeightValue / 2.0;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public double Right
		{
			get
			{
				return this.XValue + this.WidthValue / 2.0;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public double Bottom
		{
			get
			{
				return this.YValue - this.HeightValue / 2.0;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public double XMin
		{
			get
			{
				return this.X - this.Width / 2.0;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public double XMax
		{
			get
			{
				return this.X + this.Width / 2.0;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public double YMin
		{
			get
			{
				return this.Y - this.Height / 2.0;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public double YMax
		{
			get
			{
				return this.Y + this.Height / 2.0;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public PlotUnitType ActualUnitTypeAll
		{
			get
			{
				if (this.m_UnitTypeAll == PlotUnitType.Value)
				{
					return PlotUnitType.Value;
				}
				if (this.m_UnitTypeAll == PlotUnitType.Percent)
				{
					return PlotUnitType.Percent;
				}
				if (this.m_UnitTypeAll == PlotUnitType.Pixel)
				{
					return PlotUnitType.Pixel;
				}
				return PlotUnitType.Value;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public PlotUnitType ActualUnitTypeLocation
		{
			get
			{
				if (this.m_UnitTypeLocation == PlotUnitType.Value)
				{
					return PlotUnitType.Value;
				}
				if (this.m_UnitTypeLocation == PlotUnitType.Percent)
				{
					return PlotUnitType.Percent;
				}
				if (this.m_UnitTypeLocation == PlotUnitType.Pixel)
				{
					return PlotUnitType.Pixel;
				}
				return this.ActualUnitTypeAll;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public PlotUnitType ActualUnitTypeSize
		{
			get
			{
				if (this.m_UnitTypeSize == PlotUnitType.Value)
				{
					return PlotUnitType.Value;
				}
				if (this.m_UnitTypeSize == PlotUnitType.Percent)
				{
					return PlotUnitType.Percent;
				}
				if (this.m_UnitTypeSize == PlotUnitType.Pixel)
				{
					return PlotUnitType.Pixel;
				}
				return this.ActualUnitTypeAll;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public PlotUnitType ActualUnitTypeX
		{
			get
			{
				if (this.m_UnitTypeX == PlotUnitType.Value)
				{
					return PlotUnitType.Value;
				}
				if (this.m_UnitTypeX == PlotUnitType.Percent)
				{
					return PlotUnitType.Percent;
				}
				if (this.m_UnitTypeX == PlotUnitType.Pixel)
				{
					return PlotUnitType.Pixel;
				}
				return this.ActualUnitTypeLocation;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public PlotUnitType ActualUnitTypeY
		{
			get
			{
				if (this.m_UnitTypeY == PlotUnitType.Value)
				{
					return PlotUnitType.Value;
				}
				if (this.m_UnitTypeY == PlotUnitType.Percent)
				{
					return PlotUnitType.Percent;
				}
				if (this.m_UnitTypeY == PlotUnitType.Pixel)
				{
					return PlotUnitType.Pixel;
				}
				return this.ActualUnitTypeLocation;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		public PlotUnitType ActualUnitTypeWidth
		{
			get
			{
				if (this.m_UnitTypeWidth == PlotUnitType.Value)
				{
					return PlotUnitType.Value;
				}
				if (this.m_UnitTypeWidth == PlotUnitType.Percent)
				{
					return PlotUnitType.Percent;
				}
				if (this.m_UnitTypeWidth == PlotUnitType.Pixel)
				{
					return PlotUnitType.Pixel;
				}
				return this.ActualUnitTypeSize;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		public PlotUnitType ActualUnitTypeHeight
		{
			get
			{
				if (this.m_UnitTypeHeight == PlotUnitType.Value)
				{
					return PlotUnitType.Value;
				}
				if (this.m_UnitTypeHeight == PlotUnitType.Percent)
				{
					return PlotUnitType.Percent;
				}
				if (this.m_UnitTypeHeight == PlotUnitType.Pixel)
				{
					return PlotUnitType.Pixel;
				}
				return this.ActualUnitTypeSize;
			}
		}

		protected GrabHandle GrabHandle0 => this.GrabHandles[0];

		protected GrabHandle GrabHandle1 => this.GrabHandles[1];

		protected GrabHandle GrabHandle2 => this.GrabHandles[2];

		protected GrabHandle GrabHandle3 => this.GrabHandles[3];

		protected GrabHandle GrabHandle4 => this.GrabHandles[4];

		protected GrabHandle GrabHandle5 => this.GrabHandles[5];

		protected GrabHandle GrabHandle6 => this.GrabHandles[6];

		protected GrabHandle GrabHandle7 => this.GrabHandles[7];

		protected double XValue
		{
			get
			{
				if (this.ActualUnitTypeX == PlotUnitType.Percent)
				{
					return base.XAxis.PercentToValue(this.X);
				}
				if (this.ActualUnitTypeX == PlotUnitType.Pixel)
				{
					return base.XAxis.PixelsToValue((int)this.X);
				}
				return this.X;
			}
		}

		protected double YValue
		{
			get
			{
				if (this.ActualUnitTypeY == PlotUnitType.Percent)
				{
					return base.YAxis.PercentToValue(this.Y);
				}
				if (this.ActualUnitTypeY == PlotUnitType.Pixel)
				{
					return base.YAxis.PixelsToValue((int)this.Y);
				}
				return this.Y;
			}
		}

		protected double XPercent
		{
			get
			{
				if (this.ActualUnitTypeX == PlotUnitType.Value)
				{
					return base.XAxis.ValueToPercent(this.X);
				}
				if (this.ActualUnitTypeX == PlotUnitType.Pixel)
				{
					return base.XAxis.PixelsToPercent((int)this.X);
				}
				return this.X;
			}
		}

		protected double YPercent
		{
			get
			{
				if (this.ActualUnitTypeY == PlotUnitType.Value)
				{
					return base.YAxis.ValueToPercent(this.Y);
				}
				if (this.ActualUnitTypeY == PlotUnitType.Pixel)
				{
					return base.YAxis.PixelsToPercent((int)this.Y);
				}
				return this.Y;
			}
		}

		protected int XPixels
		{
			get
			{
				if (this.ActualUnitTypeX == PlotUnitType.Value)
				{
					return base.XAxis.ValueToPixels(this.X);
				}
				if (this.ActualUnitTypeX == PlotUnitType.Percent)
				{
					return base.XAxis.PercentToPixels(this.X);
				}
				return (int)this.X;
			}
		}

		protected int YPixels
		{
			get
			{
				if (this.ActualUnitTypeY == PlotUnitType.Value)
				{
					return base.YAxis.ValueToPixels(this.Y);
				}
				if (this.ActualUnitTypeY == PlotUnitType.Percent)
				{
					return base.YAxis.PercentToPixels(this.Y);
				}
				return (int)this.Y;
			}
		}

		protected double WidthValue
		{
			get
			{
				if (this.ActualUnitTypeWidth == PlotUnitType.Percent)
				{
					return base.XAxis.PercentSpanToValue(this.Width);
				}
				if (this.ActualUnitTypeWidth == PlotUnitType.Pixel)
				{
					return base.XAxis.PixelSpanToValue((int)this.Width);
				}
				return this.Width;
			}
		}

		protected double HeightValue
		{
			get
			{
				if (this.ActualUnitTypeHeight == PlotUnitType.Percent)
				{
					return base.YAxis.PercentSpanToValue(this.Height);
				}
				if (this.ActualUnitTypeHeight == PlotUnitType.Pixel)
				{
					return base.YAxis.PixelSpanToValue((int)this.Height);
				}
				return (double)(int)this.Height;
			}
		}

		protected double WidthPercent
		{
			get
			{
				if (this.ActualUnitTypeWidth == PlotUnitType.Value)
				{
					return base.XAxis.ValueSpanToPercent(this.Width);
				}
				if (this.ActualUnitTypeWidth == PlotUnitType.Pixel)
				{
					return base.XAxis.PixelSpanToPercent((int)this.Width);
				}
				return this.Width;
			}
		}

		protected double HeightPercent
		{
			get
			{
				if (this.ActualUnitTypeHeight == PlotUnitType.Value)
				{
					return base.YAxis.ValueSpanToPercent(this.Height);
				}
				if (this.ActualUnitTypeHeight == PlotUnitType.Pixel)
				{
					return base.YAxis.PixelSpanToPercent((int)this.Height);
				}
				return (double)(int)this.Height;
			}
		}

		protected int WidthPixels
		{
			get
			{
				if (this.ActualUnitTypeWidth == PlotUnitType.Value)
				{
					return base.XAxis.ValueToSpanPixels(this.Width);
				}
				if (this.ActualUnitTypeWidth == PlotUnitType.Percent)
				{
					return base.XAxis.PercentToSpanPixels(this.Width);
				}
				return (int)this.Width;
			}
		}

		protected int HeightPixels
		{
			get
			{
				if (this.ActualUnitTypeHeight == PlotUnitType.Value)
				{
					return base.YAxis.ValueToSpanPixels(this.Height);
				}
				if (this.ActualUnitTypeHeight == PlotUnitType.Percent)
				{
					return base.YAxis.PercentToSpanPixels(this.Height);
				}
				return (int)this.Height;
			}
		}

		protected int XMinPixels
		{
			get
			{
				if (this.ActualUnitTypeX == this.ActualUnitTypeWidth)
				{
					if (this.ActualUnitTypeX == PlotUnitType.Value)
					{
						return base.XAxis.ValueToPixels(this.XMin);
					}
					if (this.ActualUnitTypeX == PlotUnitType.Percent)
					{
						return base.XAxis.PercentToPixels(this.XMin);
					}
					return (int)this.XMin;
				}
				return this.XPixels - this.WidthPixels / 2;
			}
		}

		protected int XMaxPixels
		{
			get
			{
				if (this.ActualUnitTypeX == this.ActualUnitTypeWidth)
				{
					if (this.ActualUnitTypeX == PlotUnitType.Value)
					{
						return base.XAxis.ValueToPixels(this.XMax);
					}
					if (this.ActualUnitTypeX == PlotUnitType.Percent)
					{
						return base.XAxis.PercentToPixels(this.XMax);
					}
					return (int)this.XMax;
				}
				return this.XPixels + this.WidthPixels / 2;
			}
		}

		protected int YMinPixels
		{
			get
			{
				if (this.ActualUnitTypeY == this.ActualUnitTypeHeight)
				{
					if (this.ActualUnitTypeY == PlotUnitType.Value)
					{
						return base.YAxis.ValueToPixels(this.YMax);
					}
					if (this.ActualUnitTypeY == PlotUnitType.Percent)
					{
						return base.YAxis.PercentToPixels(this.YMax);
					}
					return (int)this.YMax;
				}
				return this.YPixels - this.HeightPixels / 2;
			}
		}

		protected int YMaxPixels
		{
			get
			{
				if (this.ActualUnitTypeY == this.ActualUnitTypeHeight)
				{
					if (this.ActualUnitTypeY == PlotUnitType.Value)
					{
						return base.YAxis.ValueToPixels(this.YMin);
					}
					if (this.ActualUnitTypeY == PlotUnitType.Percent)
					{
						return base.YAxis.PercentToPixels(this.YMin);
					}
					return (int)this.YMin;
				}
				return this.YPixels + this.HeightPixels / 2;
			}
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Visible = true;
			base.Enabled = false;
			this.Rotation = 0.0;
			this.UserCanMove = false;
			this.UserCanSize = false;
			this.Width = 10.0;
			this.Height = 10.0;
			base.Color = Color.Empty;
			this.X = 50.0;
			this.Y = 50.0;
			this.UnitTypeAll = PlotUnitType.Auto;
			this.UnitTypeLocation = PlotUnitType.Auto;
			this.UnitTypeSize = PlotUnitType.Auto;
			this.UnitTypeX = PlotUnitType.Auto;
			this.UnitTypeY = PlotUnitType.Auto;
			this.UnitTypeWidth = PlotUnitType.Auto;
			this.UnitTypeHeight = PlotUnitType.Auto;
		}

		private bool ShouldSerializeRotation()
		{
			return base.PropertyShouldSerialize("Rotation");
		}

		private void ResetRotation()
		{
			base.PropertyReset("Rotation");
		}

		private bool ShouldSerializeUserCanMove()
		{
			return base.PropertyShouldSerialize("UserCanMove");
		}

		private void ResetUserCanMove()
		{
			base.PropertyReset("UserCanMove");
		}

		private bool ShouldSerializeUserCanSize()
		{
			return base.PropertyShouldSerialize("UserCanSize");
		}

		private void ResetUserCanSize()
		{
			base.PropertyReset("UserCanSize");
		}

		private bool ShouldSerializeWidth()
		{
			return base.PropertyShouldSerialize("Width");
		}

		private void ResetWidth()
		{
			base.PropertyReset("Width");
		}

		private bool ShouldSerializeHeight()
		{
			return base.PropertyShouldSerialize("Height");
		}

		private void ResetHeight()
		{
			base.PropertyReset("Height");
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

		private bool ShouldSerializeUnitTypeAll()
		{
			return base.PropertyShouldSerialize("UnitTypeAll");
		}

		private void ResetUnitTypeAll()
		{
			base.PropertyReset("UnitTypeAll");
		}

		private bool ShouldSerializeUnitTypeLocation()
		{
			return base.PropertyShouldSerialize("UnitTypeLocation");
		}

		private void ResetUnitTypeLocation()
		{
			base.PropertyReset("UnitTypeLocation");
		}

		private bool ShouldSerializeUnitTypeSize()
		{
			return base.PropertyShouldSerialize("UnitTypeSize");
		}

		private void ResetUnitTypeSize()
		{
			base.PropertyReset("UnitTypeSize");
		}

		private bool ShouldSerializeUnitTypeX()
		{
			return base.PropertyShouldSerialize("UnitTypeX");
		}

		private void ResetUnitTypeX()
		{
			base.PropertyReset("UnitTypeX");
		}

		private bool ShouldSerializeUnitTypeY()
		{
			return base.PropertyShouldSerialize("UnitTypeY");
		}

		private void ResetUnitTypeY()
		{
			base.PropertyReset("UnitTypeY");
		}

		private bool ShouldSerializeUnitTypeWidth()
		{
			return base.PropertyShouldSerialize("UnitTypeWidth");
		}

		private void ResetUnitTypeWidth()
		{
			base.PropertyReset("UnitTypeWidth");
		}

		private bool ShouldSerializeUnitTypeHeight()
		{
			return base.PropertyShouldSerialize("UnitTypeHeight");
		}

		private void ResetUnitTypeHeight()
		{
			base.PropertyReset("UnitTypeHeight");
		}

		protected int GetXPixels(double value)
		{
			if (this.ActualUnitTypeX == PlotUnitType.Value)
			{
				return base.XAxis.ValueToPixels(value);
			}
			if (this.ActualUnitTypeX == PlotUnitType.Percent)
			{
				return base.XAxis.PercentToPixels(value);
			}
			return (int)value;
		}

		protected int GetYPixels(double value)
		{
			if (this.ActualUnitTypeY == PlotUnitType.Value)
			{
				return base.YAxis.ValueToPixels(value);
			}
			if (this.ActualUnitTypeY == PlotUnitType.Percent)
			{
				return base.YAxis.PercentToPixels(value);
			}
			return (int)value;
		}

		protected double GetXFromValueUnits(double value)
		{
			if (this.ActualUnitTypeX == PlotUnitType.Percent)
			{
				return base.XAxis.ValueToPercent(value);
			}
			if (this.ActualUnitTypeX == PlotUnitType.Pixel)
			{
				return (double)base.XAxis.ValueToPixels(value);
			}
			return value;
		}

		protected double GetYFromValueUnits(double value)
		{
			if (this.ActualUnitTypeY == PlotUnitType.Percent)
			{
				return base.YAxis.ValueToPercent(value);
			}
			if (this.ActualUnitTypeY == PlotUnitType.Pixel)
			{
				return (double)base.YAxis.ValueToPixels(value);
			}
			return value;
		}

		protected double GetWidthFromValueUnits(double value)
		{
			if (this.ActualUnitTypeWidth == PlotUnitType.Percent)
			{
				return base.XAxis.ValueSpanToPercent(value);
			}
			if (this.ActualUnitTypeWidth == PlotUnitType.Pixel)
			{
				return (double)base.XAxis.ValueToSpanPixels(value);
			}
			return value;
		}

		protected double GetHeightFromValueUnits(double value)
		{
			if (this.ActualUnitTypeHeight == PlotUnitType.Percent)
			{
				return base.YAxis.ValueSpanToPercent(value);
			}
			if (this.ActualUnitTypeHeight == PlotUnitType.Pixel)
			{
				return (double)base.YAxis.ValueToSpanPixels(value);
			}
			return value;
		}

		protected double ConvertPixelsToX(int value)
		{
			if (this.ActualUnitTypeX == PlotUnitType.Value)
			{
				return base.XAxis.PixelsToValue(value);
			}
			if (this.ActualUnitTypeX == PlotUnitType.Percent)
			{
				return base.XAxis.PixelsToPercent(value);
			}
			return (double)value;
		}

		protected double ConvertPixelsToY(int value)
		{
			if (this.ActualUnitTypeY == PlotUnitType.Value)
			{
				return base.YAxis.PixelsToValue(value);
			}
			if (this.ActualUnitTypeY == PlotUnitType.Percent)
			{
				return base.YAxis.PixelsToPercent(value);
			}
			return (double)value;
		}

		protected double ConvertPixelsToWidth(int value)
		{
			if (this.ActualUnitTypeWidth == PlotUnitType.Value)
			{
				return base.XAxis.PixelsToValue(value);
			}
			if (this.ActualUnitTypeWidth == PlotUnitType.Percent)
			{
				return base.XAxis.PixelsToPercent(value);
			}
			return (double)value;
		}

		protected double ConvertPixelsToHeight(int value)
		{
			if (this.ActualUnitTypeHeight == PlotUnitType.Value)
			{
				return base.YAxis.PixelsToValue(value);
			}
			if (this.ActualUnitTypeHeight == PlotUnitType.Percent)
			{
				return base.YAxis.PixelsToPercent(value);
			}
			return (double)value;
		}

		protected virtual void SetXAndWidth(double x, double width)
		{
			this.X = x;
			this.Width = width;
		}

		protected virtual void SetYAndHeight(double y, double height)
		{
			this.Y = y;
			this.Height = height;
		}

		protected virtual void DragX(double original, double delta)
		{
			this.X = original + delta;
		}

		protected virtual void DragY(double original, double delta)
		{
			this.Y = original + delta;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			base.InternalOnMouseLeft(e, shouldFocus);
			if (base.Enabled)
			{
				int num;
				int num2;
				if (base.XYSwapped)
				{
					num = e.Y;
					num2 = e.X;
				}
				else
				{
					num = e.X;
					num2 = e.Y;
				}
				this.m_MouseDownEditMode = this.GetEditMode(e);
				this.ControlBase.Cursor = this.GetCursor(this.m_MouseDownEditMode);
				this.m_MouseDownXPixels = num;
				this.m_MouseDownYPixels = num2;
				this.m_MouseDownUnitsX = this.ConvertPixelsToX(num);
				this.m_MouseDownUnitsY = this.ConvertPixelsToY(num2);
				this.m_MouseDownX = this.X;
				this.m_MouseDownY = this.Y;
				this.m_MouseDownLeft = this.Left;
				this.m_MouseDownTop = this.Top;
				this.m_MouseDownRight = this.Right;
				this.m_MouseDownBottom = this.Bottom;
				this.m_MouseDownHeight = this.HeightValue;
				this.m_MouseDownWidth = this.WidthValue;
				base.IsMouseActive = true;
				if (shouldFocus)
				{
					base.Focus();
				}
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			int num;
			int num2;
			if (base.XYSwapped)
			{
				num = e.Y;
				num2 = e.X;
			}
			else
			{
				num = e.X;
				num2 = e.Y;
			}
			bool flag2;
			bool flag3;
			bool flag4;
			int value;
			int value2;
			if (base.IsMouseActive)
			{
				if (this.m_MouseDownEditMode == EditMode.Move)
				{
					double delta = this.ConvertPixelsToX(num) - this.m_MouseDownUnitsX;
					double delta2 = this.ConvertPixelsToY(num2) - this.m_MouseDownUnitsY;
					this.DragX(this.m_MouseDownX, delta);
					this.DragY(this.m_MouseDownY, delta2);
				}
				else if (this.m_MouseDownEditMode != 0)
				{
					EditMode mouseDownEditMode = this.m_MouseDownEditMode;
					bool flag;
					if (!base.XYSwapped)
					{
						flag = (mouseDownEditMode == EditMode.Size6 || mouseDownEditMode == EditMode.Size7 || mouseDownEditMode == EditMode.Size0);
						flag2 = (mouseDownEditMode == EditMode.Size2 || mouseDownEditMode == EditMode.Size3 || mouseDownEditMode == EditMode.Size4);
						flag3 = (mouseDownEditMode == EditMode.Size0 || mouseDownEditMode == EditMode.Size1 || mouseDownEditMode == EditMode.Size2);
						flag4 = (mouseDownEditMode == EditMode.Size4 || mouseDownEditMode == EditMode.Size5 || mouseDownEditMode == EditMode.Size6);
					}
					else
					{
						flag = (mouseDownEditMode == EditMode.Size6 || mouseDownEditMode == EditMode.Size5 || mouseDownEditMode == EditMode.Size4);
						flag2 = (mouseDownEditMode == EditMode.Size0 || mouseDownEditMode == EditMode.Size1 || mouseDownEditMode == EditMode.Size2);
						flag3 = (mouseDownEditMode == EditMode.Size2 || mouseDownEditMode == EditMode.Size3 || mouseDownEditMode == EditMode.Size4);
						flag4 = (mouseDownEditMode == EditMode.Size0 || mouseDownEditMode == EditMode.Size7 || mouseDownEditMode == EditMode.Size6);
					}
					if (base.XAxis.ScaleRange.Reverse)
					{
						Math2.Switch(ref flag, ref flag2);
					}
					if (base.YAxis.ScaleRange.Reverse)
					{
						Math2.Switch(ref flag4, ref flag3);
					}
					value = num - this.m_MouseDownXPixels;
					value2 = num2 - this.m_MouseDownYPixels;
					if (flag)
					{
						double num3 = (!base.XAxis.ScaleRange.Reverse) ? (this.m_MouseDownWidth - base.XAxis.PixelSpanToValue(value)) : (this.m_MouseDownWidth + base.XAxis.PixelSpanToValue(value));
						if (!(num3 < 0.0))
						{
							double value3 = this.m_MouseDownRight - num3 / 2.0;
							this.SetXAndWidth(this.GetXFromValueUnits(value3), this.GetWidthFromValueUnits(num3));
							goto IL_01fd;
						}
						return;
					}
					goto IL_01fd;
				}
			}
			else if (base.Focused)
			{
				this.ControlBase.Cursor = this.GetCursor(this.GetEditMode(e));
			}
			goto IL_0393;
			IL_02f3:
			if (flag4)
			{
				double num4 = (!base.YAxis.ScaleRange.Reverse) ? (this.m_MouseDownHeight + base.YAxis.PixelSpanToValue(value2)) : (this.m_MouseDownHeight - base.YAxis.PixelSpanToValue(value2));
				if (!(num4 < 0.0))
				{
					double value4 = this.m_MouseDownTop - num4 / 2.0;
					this.SetYAndHeight(this.GetYFromValueUnits(value4), this.GetHeightFromValueUnits(num4));
					goto IL_0393;
				}
				return;
			}
			goto IL_0393;
			IL_0278:
			if (flag3)
			{
				double num4 = (!base.YAxis.ScaleRange.Reverse) ? (this.m_MouseDownHeight - base.YAxis.PixelSpanToValue(value2)) : (this.m_MouseDownHeight + base.YAxis.PixelSpanToValue(value2));
				if (!(num4 < 0.0))
				{
					double value4 = this.m_MouseDownBottom + num4 / 2.0;
					this.SetYAndHeight(this.GetYFromValueUnits(value4), this.GetHeightFromValueUnits(num4));
					goto IL_02f3;
				}
				return;
			}
			goto IL_02f3;
			IL_01fd:
			if (flag2)
			{
				double num3 = (!base.XAxis.ScaleRange.Reverse) ? (this.m_MouseDownWidth + base.XAxis.PixelSpanToValue(value)) : (this.m_MouseDownWidth - base.XAxis.PixelSpanToValue(value));
				if (!(num3 < 0.0))
				{
					double value3 = this.m_MouseDownLeft + num3 / 2.0;
					this.SetXAndWidth(this.GetXFromValueUnits(value3), this.GetWidthFromValueUnits(num3));
					goto IL_0278;
				}
				return;
			}
			goto IL_0278;
			IL_0393:
			base.InternalOnMouseMove(e);
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			base.InternalOnMouseUp(e);
			if (base.IsMouseActive)
			{
				base.Bounds.Contains(e.X, e.Y);
			}
		}

		protected override bool InternalHitTest(MouseEventArgs e)
		{
			if (this.m_ClickRegion == null)
			{
				return false;
			}
			if (base.Focused)
			{
				for (int i = 0; i < this.GrabHandles.Length; i++)
				{
					if (this.GrabHandles[i].Rectangle.Contains(e.X, e.Y))
					{
						return true;
					}
				}
			}
			return this.m_ClickRegion.IsVisible((float)e.X, (float)e.Y);
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			if (base.Plot == null)
			{
				return Cursors.Default;
			}
			return this.GetCursor(this.GetEditMode(e));
		}

		protected EditMode GetEditMode(MouseEventArgs e)
		{
			if (this.UserCanSize && this.GrabHandle0.Enabled && this.GrabHandle0.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size0;
			}
			if (this.UserCanSize && this.GrabHandle1.Enabled && this.GrabHandle1.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size1;
			}
			if (this.UserCanSize && this.GrabHandle2.Enabled && this.GrabHandle2.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size2;
			}
			if (this.UserCanSize && this.GrabHandle3.Enabled && this.GrabHandle3.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size3;
			}
			if (this.UserCanSize && this.GrabHandle4.Enabled && this.GrabHandle4.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size4;
			}
			if (this.UserCanSize && this.GrabHandle5.Enabled && this.GrabHandle5.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size5;
			}
			if (this.UserCanSize && this.GrabHandle6.Enabled && this.GrabHandle6.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size6;
			}
			if (this.UserCanSize && this.GrabHandle7.Enabled && this.GrabHandle7.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size7;
			}
			if (this.UserCanMove)
			{
				return EditMode.Move;
			}
			return EditMode.None;
		}

		protected Cursor GetCursor(EditMode editMode)
		{
			switch (editMode)
			{
			case EditMode.Size0:
				return Cursors.SizeNWSE;
			case EditMode.Size1:
				return Cursors.SizeNS;
			case EditMode.Size2:
				return Cursors.SizeNESW;
			case EditMode.Size3:
				return Cursors.SizeWE;
			case EditMode.Size4:
				return Cursors.SizeNWSE;
			case EditMode.Size5:
				return Cursors.SizeNS;
			case EditMode.Size6:
				return Cursors.SizeNESW;
			case EditMode.Size7:
				return Cursors.SizeWE;
			case EditMode.Move:
				return Cursors.SizeAll;
			default:
				return Cursors.Default;
			}
		}

		protected void UpdateGrabHandles(Rectangle r)
		{
			int num = (r.Left + r.Right) / 2;
			int num2 = (r.Top + r.Bottom) / 2;
			if (this.Rotation == 0.0)
			{
				this.GrabHandle0.Rectangle = this.CalcGrabRect(new Point(r.Left, r.Top));
				this.GrabHandle1.Rectangle = this.CalcGrabRect(new Point(num, r.Top));
				this.GrabHandle2.Rectangle = this.CalcGrabRect(new Point(r.Right, r.Top));
				this.GrabHandle3.Rectangle = this.CalcGrabRect(new Point(r.Right, num2));
				this.GrabHandle4.Rectangle = this.CalcGrabRect(new Point(r.Right, r.Bottom));
				this.GrabHandle5.Rectangle = this.CalcGrabRect(new Point(num, r.Bottom));
				this.GrabHandle6.Rectangle = this.CalcGrabRect(new Point(r.Left, r.Bottom));
				this.GrabHandle7.Rectangle = this.CalcGrabRect(new Point(r.Left, num2));
			}
			else
			{
				int num3 = r.Width / 2;
				int num4 = r.Height / 2;
				double num5 = Math.Atan2((double)num4, (double)num3) * 360.0 / 6.2831853071795862;
				double radius = Math.Sqrt((double)(num3 * num3 + num4 * num4));
				this.GrabHandle0.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(180.0 + num5 + this.Rotation, radius, (double)num, (double)num2));
				this.GrabHandle1.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(270.0 + this.Rotation, (double)num4, (double)num, (double)num2));
				this.GrabHandle2.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(0.0 - num5 + this.Rotation, radius, (double)num, (double)num2));
				this.GrabHandle3.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(0.0 + this.Rotation, (double)num3, (double)num, (double)num2));
				this.GrabHandle4.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(0.0 + num5 + this.Rotation, radius, (double)num, (double)num2));
				this.GrabHandle5.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(90.0 + this.Rotation, (double)num4, (double)num, (double)num2));
				this.GrabHandle6.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(180.0 - num5 + this.Rotation, radius, (double)num, (double)num2));
				this.GrabHandle7.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(180.0 + this.Rotation, (double)num3, (double)num, (double)num2));
			}
		}

		private Rectangle CalcGrabRect(Point point)
		{
			return new Rectangle(point.X - 2, point.Y - 2, 5, 5);
		}

		protected void DrawGrabHandles(PaintArgs p, Color grabHandleDisabledColor)
		{
			if (base.Focused && (this.ControlBase == null || this.ControlBase.Focused))
			{
				Color color = Color.White;
				if (this.ControlBase != null)
				{
					color = this.ControlBase.BackColor;
				}
				Color color2 = Color.FromArgb(255, color.R ^ 0xFF, color.G ^ 0xFF, color.B ^ 0xFF);
				for (int i = 0; i < this.GrabHandles.Length; i++)
				{
					Color color3 = (!this.UserCanSize || !this.GrabHandles[i].Enabled) ? grabHandleDisabledColor : color2;
					p.Graphics.FillRectangle(p.Graphics.Brush(color3), this.GrabHandles[i].Rectangle);
					p.Graphics.DrawRectangle(p.Graphics.Pen(Color.Red), this.GrabHandles[i].Rectangle);
				}
			}
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			this.GrabHandle0.Rectangle = Rectangle.Empty;
			this.GrabHandle1.Rectangle = Rectangle.Empty;
			this.GrabHandle2.Rectangle = Rectangle.Empty;
			this.GrabHandle3.Rectangle = Rectangle.Empty;
			this.GrabHandle4.Rectangle = Rectangle.Empty;
			this.GrabHandle5.Rectangle = Rectangle.Empty;
			this.GrabHandle6.Rectangle = Rectangle.Empty;
			this.GrabHandle7.Rectangle = Rectangle.Empty;
			Point point = new Point(this.XPixels, this.YPixels);
			GraphicsState gstate = p.Graphics.Save();
			p.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			p.Graphics.TranslateTransform((float)point.X, (float)point.Y);
			p.Graphics.RotateTransform((float)this.Rotation);
			p.Graphics.TranslateTransform((float)(-point.X), (float)(-point.Y));
			this.DrawCustom(p, xAxis, yAxis);
			p.Graphics.Restore(gstate);
			if (this.ClickRegion != null)
			{
				Rectangle rectangle = Rectangle.Truncate(this.ClickRegion.GetBounds(p.Graphics.GraphicsMS));
				if (rectangle.Width <= 0)
				{
					rectangle = new Rectangle(rectangle.Left - 2, rectangle.Top, 4, rectangle.Height);
					this.ClickRegion = new Region(rectangle);
					base.Bounds = rectangle;
				}
				else if (rectangle.Height <= 0)
				{
					rectangle = new Rectangle(rectangle.Left, rectangle.Top - 2, rectangle.Width, 4);
					this.ClickRegion = new Region(rectangle);
					base.Bounds = rectangle;
				}
				else
				{
					base.Bounds = rectangle;
				}
			}
		}

		protected override void DrawFocusRectangles(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			if (this.ClickRegion != null)
			{
				this.DrawGrabHandles(p, base.Plot.DefaultGridLineColor);
			}
		}

		protected abstract void DrawCustom(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis);

		protected virtual Region ToClickRegion(Rectangle r)
		{
			return new Region(r);
		}
	}
}
