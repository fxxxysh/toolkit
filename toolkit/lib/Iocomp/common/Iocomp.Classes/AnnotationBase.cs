using Iocomp.Design;
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
	[TypeConverter(typeof(AnnotationBaseConverter))]
	public abstract class AnnotationBase : SubClassBase, IAnnotationBase
	{
		private double m_Rotation;

		private bool m_CanMove;

		private bool m_CanSize;

		private Region m_ClickRegion;

		private GrabHandle[] m_GrabHandles;

		private double m_MouseDownUnitsX;

		private double m_MouseDownUnitsY;

		private double m_MouseDownOriginalX;

		private double m_MouseDownOriginalY;

		private double m_MouseDownOriginalWidth;

		private double m_MouseDownOriginalHeight;

		private EditMode m_MouseDownEditMode;

		private ScaleAnnotation m_Scale;

		private double m_Width;

		private double m_Height;

		private double m_X;

		private double m_Y;

		ScaleAnnotation IAnnotationBase.Scale
		{
			get
			{
				return this.Scale;
			}
			set
			{
				this.Scale = value;
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

		[Category("Iocomp")]
		public double Left
		{
			get
			{
				return this.X - this.Width / 2.0;
			}
		}

		[Category("Iocomp")]
		public double Top
		{
			get
			{
				return this.Y + this.Height / 2.0;
			}
		}

		[Category("Iocomp")]
		public double Right
		{
			get
			{
				return this.X + this.Width / 2.0;
			}
		}

		[Category("Iocomp")]
		public double Bottom
		{
			get
			{
				return this.Y - this.Height / 2.0;
			}
		}

		protected GrabHandle GrabHandle0 => this.m_GrabHandles[0];

		protected GrabHandle GrabHandle1 => this.m_GrabHandles[1];

		protected GrabHandle GrabHandle2 => this.m_GrabHandles[2];

		protected GrabHandle GrabHandle3 => this.m_GrabHandles[3];

		protected GrabHandle GrabHandle4 => this.m_GrabHandles[4];

		protected GrabHandle GrabHandle5 => this.m_GrabHandles[5];

		protected GrabHandle GrabHandle6 => this.m_GrabHandles[6];

		protected GrabHandle GrabHandle7 => this.m_GrabHandles[7];

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Category("Iocomp")]
		public bool Enabled
		{
			get
			{
				return base.EnabledInternal;
			}
			set
			{
				base.EnabledInternal = value;
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
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
		[Description("")]
		[Category("Iocomp")]
		public bool CanMove
		{
			get
			{
				return this.m_CanMove;
			}
			set
			{
				base.PropertyUpdateDefault("CanMove", value);
				if (this.CanMove != value)
				{
					this.m_CanMove = value;
					base.DoPropertyChange(this, "CanMove");
				}
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool CanSize
		{
			get
			{
				return this.m_CanSize;
			}
			set
			{
				base.PropertyUpdateDefault("CanSize", value);
				if (this.CanSize != value)
				{
					this.m_CanSize = value;
					base.DoPropertyChange(this, "CanSize");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Category("Iocomp")]
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

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
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

		protected virtual ScaleAnnotation Scale
		{
			get
			{
				return this.m_Scale;
			}
			set
			{
				this.m_Scale = value;
			}
		}

		void IAnnotationBase.Draw(PaintArgs p, Color grabHandleDisabledColor)
		{
			this.Draw(p, grabHandleDisabledColor);
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_GrabHandles = new GrabHandle[8];
			for (int i = 0; i < this.m_GrabHandles.Length; i++)
			{
				this.m_GrabHandles[i] = new GrabHandle();
				this.m_GrabHandles[i].Rectangle = Rectangle.Empty;
				this.m_GrabHandles[i].Enabled = true;
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Rotation = 0.0;
			this.CanMove = false;
			this.CanSize = false;
			this.Width = 10.0;
			this.Height = 10.0;
			this.Visible = true;
			this.Enabled = true;
			this.X = 0.0;
			this.Y = 0.0;
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeEnabled()
		{
			return base.PropertyShouldSerialize("Enabled");
		}

		private void ResetEnabled()
		{
			base.PropertyReset("Enabled");
		}

		private bool ShouldSerializeRotation()
		{
			return base.PropertyShouldSerialize("Rotation");
		}

		private void ResetRotation()
		{
			base.PropertyReset("Rotation");
		}

		private bool ShouldSerializeCanMove()
		{
			return base.PropertyShouldSerialize("CanMove");
		}

		private void ResetCanMove()
		{
			base.PropertyReset("CanMove");
		}

		private bool ShouldSerializeCanSize()
		{
			return base.PropertyShouldSerialize("CanSize");
		}

		private void ResetCanSize()
		{
			base.PropertyReset("CanSize");
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
			if (this.Scale != null && this.Enabled)
			{
				this.m_MouseDownEditMode = this.GetEditMode(e);
				this.ControlBase.Cursor = this.GetCursor(this.m_MouseDownEditMode);
				this.m_MouseDownUnitsX = this.Scale.ConvertPixelsToUnitsX(e.X);
				this.m_MouseDownUnitsY = this.Scale.ConvertPixelsToUnitsY(e.Y);
				this.m_MouseDownOriginalX = this.X;
				this.m_MouseDownOriginalY = this.Y;
				this.m_MouseDownOriginalHeight = this.Height;
				this.m_MouseDownOriginalWidth = this.Width;
				base.IsMouseActive = true;
				if (shouldFocus)
				{
					base.Focus();
				}
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			double num;
			double num2;
			double num3;
			if (base.IsMouseActive)
			{
				num = this.Scale.ConvertPixelsToUnitsX(e.X) - this.m_MouseDownUnitsX;
				num2 = this.Scale.ConvertPixelsToUnitsY(e.Y) - this.m_MouseDownUnitsY;
				if (this.m_MouseDownEditMode == EditMode.Move)
				{
					this.DragX(this.m_MouseDownOriginalX, num);
					this.DragY(this.m_MouseDownOriginalY, num2);
				}
				else if (this.m_MouseDownEditMode != 0)
				{
					if (this.m_MouseDownEditMode != EditMode.Size0 && this.m_MouseDownEditMode != EditMode.Size6 && this.m_MouseDownEditMode != EditMode.Size7)
					{
						goto IL_00bb;
					}
					num3 = this.m_MouseDownOriginalWidth - num;
					if (!(num3 < 0.0))
					{
						this.SetXAndWidth(this.m_MouseDownOriginalX + num / 2.0, num3);
						goto IL_00bb;
					}
					return;
				}
			}
			else if (base.Focused)
			{
				this.ControlBase.Cursor = this.GetCursor(this.GetEditMode(e));
			}
			goto IL_01bb;
			IL_0105:
			if (this.m_MouseDownEditMode != EditMode.Size0 && this.m_MouseDownEditMode != EditMode.Size1 && this.m_MouseDownEditMode != EditMode.Size2)
			{
				goto IL_014f;
			}
			double num4 = this.m_MouseDownOriginalHeight + num2;
			if (!(num4 < 0.0))
			{
				this.SetYAndHeight(this.m_MouseDownOriginalY + num2 / 2.0, num4);
				goto IL_014f;
			}
			return;
			IL_01bb:
			base.InternalOnMouseMove(e);
			return;
			IL_014f:
			if (this.m_MouseDownEditMode != EditMode.Size4 && this.m_MouseDownEditMode != EditMode.Size5 && this.m_MouseDownEditMode != EditMode.Size6)
			{
				goto IL_01bb;
			}
			num4 = this.m_MouseDownOriginalHeight - num2;
			if (!(num4 < 0.0))
			{
				this.SetYAndHeight(this.m_MouseDownOriginalY + num2 / 2.0, num4);
				goto IL_01bb;
			}
			return;
			IL_00bb:
			if (this.m_MouseDownEditMode != EditMode.Size2 && this.m_MouseDownEditMode != EditMode.Size3 && this.m_MouseDownEditMode != EditMode.Size4)
			{
				goto IL_0105;
			}
			num3 = this.m_MouseDownOriginalWidth + num;
			if (!(num3 < 0.0))
			{
				this.SetXAndWidth(this.m_MouseDownOriginalX + num / 2.0, num3);
				goto IL_0105;
			}
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
				for (int i = 0; i < this.m_GrabHandles.Length; i++)
				{
					if (this.m_GrabHandles[i].Rectangle.Contains(e.X, e.Y))
					{
						return true;
					}
				}
			}
			return this.m_ClickRegion.IsVisible((float)e.X, (float)e.Y);
		}

		protected EditMode GetEditMode(MouseEventArgs e)
		{
			if (this.CanSize && this.GrabHandle0.Enabled && this.GrabHandle0.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size0;
			}
			if (this.CanSize && this.GrabHandle1.Enabled && this.GrabHandle1.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size1;
			}
			if (this.CanSize && this.GrabHandle2.Enabled && this.GrabHandle2.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size2;
			}
			if (this.CanSize && this.GrabHandle3.Enabled && this.GrabHandle3.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size3;
			}
			if (this.CanSize && this.GrabHandle4.Enabled && this.GrabHandle4.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size4;
			}
			if (this.CanSize && this.GrabHandle5.Enabled && this.GrabHandle5.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size5;
			}
			if (this.CanSize && this.GrabHandle6.Enabled && this.GrabHandle6.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size6;
			}
			if (this.CanSize && this.GrabHandle7.Enabled && this.GrabHandle7.Rectangle.Contains(e.X, e.Y))
			{
				return EditMode.Size7;
			}
			if (this.CanMove)
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
			double centerX = (double)(r.Left + r.Right) / 2.0;
			double centerY = (double)(r.Top + r.Bottom) / 2.0;
			double num = (double)r.Width / 2.0;
			double num2 = (double)r.Height / 2.0;
			double num3 = Math.Atan2(num2, num) * 360.0 / 6.2831853071795862;
			double radius = Math.Sqrt(num * num + num2 * num2);
			this.GrabHandle0.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(180.0 + num3 + this.Rotation, radius, centerX, centerY));
			this.GrabHandle1.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(270.0 + this.Rotation, num2, centerX, centerY));
			this.GrabHandle2.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(0.0 - num3 + this.Rotation, radius, centerX, centerY));
			this.GrabHandle3.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(0.0 + this.Rotation, num, centerX, centerY));
			this.GrabHandle4.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(0.0 + num3 + this.Rotation, radius, centerX, centerY));
			this.GrabHandle5.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(90.0 + this.Rotation, num2, centerX, centerY));
			this.GrabHandle6.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(180.0 - num3 + this.Rotation, radius, centerX, centerY));
			this.GrabHandle7.Rectangle = this.CalcGrabRect(Math2.ToRotatedPoint(180.0 + this.Rotation, num, centerX, centerY));
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
				for (int i = 0; i < this.m_GrabHandles.Length; i++)
				{
					Color color3 = (!this.CanSize || !this.m_GrabHandles[i].Enabled) ? grabHandleDisabledColor : color2;
					p.Graphics.FillRectangle(p.Graphics.Brush(color3), this.m_GrabHandles[i].Rectangle);
				}
			}
		}

		protected void Draw(PaintArgs p, Color grabHandleDisabledColor)
		{
			if (this.Visible)
			{
				Point point = new Point(p.Left + this.Scale.ConvertUnitsToPixelsX(this.X), p.Top + this.Scale.ConvertUnitsToPixelsY(this.Y));
				GraphicsState gstate = p.Graphics.Save();
				p.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				p.Graphics.TranslateTransform((float)point.X, (float)point.Y);
				p.Graphics.RotateTransform((float)this.Rotation);
				p.Graphics.TranslateTransform((float)(-point.X), (float)(-point.Y));
				this.DrawCustom(p);
				p.Graphics.Restore(gstate);
				this.DrawGrabHandles(p, grabHandleDisabledColor);
			}
		}

		protected abstract void DrawCustom(PaintArgs p);

		protected virtual Region ToClickRegion(Rectangle r)
		{
			return new Region(r);
		}
	}
}
