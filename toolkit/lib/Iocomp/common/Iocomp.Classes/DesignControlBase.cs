using Iocomp.Delegates;
using Iocomp.Design;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Serializable]
	[DesignerSerializer(typeof(LoadBeginEndSerializerControlBase), typeof(CodeDomSerializer))]
	[DesignerCategory("code")]
	[Description("Iocomp's ancestor class for all controls.")]
	[Editor(typeof(UITypeEditorGeneric), typeof(UITypeEditor))]
	public abstract class DesignControlBase : Control, IPropertyDefaults, ISupportUITypeEditor, IControlBase, IComponentBase
	{
		protected License m_License;

		private bool m_Loading;

		private bool m_Creating;

		private bool m_SettingDefaults;

		private bool m_AutoSizing;

		private bool m_ManualSizeFixing;

		private bool m_AfterCreating;

		private bool m_MouseDown;

		private bool m_KeyDown;

		private int m_MouseDownX;

		private int m_MouseDownY;

		private MouseEventArgs m_LastMouseDownEventArgs;

		private BorderControl m_Border;

		private bool m_GettingDefault;

		private bool m_DefaultReadBack;

		private ArrayList m_DefaultArray;

		private RotationQuad m_Rotation;

		private bool m_Rotating;

		private bool m_SettingBoundsCore;

		private bool m_AutoSize;

		private Color m_BackColor;

		private Color m_ForeColor;

		private bool m_SnapShotTransparent;

		private SubClassBaseCollection m_SubClassList;

		private bool m_FreezeAutoSize;

		private int m_FreezeAutoSizeOffsetTotal;

		bool IControlBase.FreezeAutoSize
		{
			get
			{
				return this.FreezeAutoSize;
			}
			set
			{
				this.FreezeAutoSize = value;
			}
		}

		Control IControlBase.Control
		{
			get
			{
				return this;
			}
		}

		Control IControlBase._Parent
		{
			get
			{
				return base.Parent;
			}
		}

		bool IPropertyDefaults.DefaultReadBack
		{
			get
			{
				return this.DefaultReadBack;
			}
			set
			{
				this.DefaultReadBack = value;
			}
		}

		protected override Size DefaultSize => this.GetDefaultSize();

		[Browsable(false)]
		public bool Designing
		{
			get
			{
				return base.DesignMode;
			}
		}

		[Browsable(false)]
		public bool Loading
		{
			get
			{
				return this.m_Loading;
			}
		}

		[Browsable(false)]
		public bool AutoSizing
		{
			get
			{
				return this.m_AutoSizing;
			}
		}

		protected bool ManualSizeFixing => this.m_ManualSizeFixing;

		[Browsable(false)]
		public bool Creating
		{
			get
			{
				return this.m_Creating;
			}
		}

		[Browsable(false)]
		public bool AfterCreating
		{
			get
			{
				return this.m_AfterCreating;
			}
		}

		[Browsable(false)]
		public bool SettingDefaults
		{
			get
			{
				return this.m_SettingDefaults;
			}
		}

		[Browsable(false)]
		public bool Rotating
		{
			get
			{
				return this.m_Rotating;
			}
		}

		[Browsable(false)]
		[Category("Iocomp")]
		public EventSource EventSource
		{
			get
			{
				return EventSource.Code;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool OPCUpdateActive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		protected bool GettingDefault
		{
			get
			{
				if (!this.m_GettingDefault)
				{
					return this.m_DefaultReadBack;
				}
				return true;
			}
		}

		protected bool FreezeAutoSize
		{
			get
			{
				return this.m_FreezeAutoSize;
			}
			set
			{
				this.m_Loading = value;
				if (this.m_FreezeAutoSize != value)
				{
					this.m_FreezeAutoSize = value;
					if (this.m_FreezeAutoSize)
					{
						this.m_FreezeAutoSizeOffsetTotal = 0;
					}
					else
					{
						this.DoAutoSize(this.m_FreezeAutoSizeOffsetTotal);
					}
				}
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		private bool DefaultReadBack
		{
			get
			{
				return this.m_DefaultReadBack;
			}
			set
			{
				if (this.m_SubClassList != null)
				{
					foreach (IPropertyDefaults subClass in this.m_SubClassList)
					{
						subClass.DefaultReadBack = value;
					}
				}
			}
		}

		protected int InnerOffset => this.Border.Offset + this.SpecialOffset;

		[Description("Specifies the rotation of the title and bevel.")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public RotationQuad Rotation
		{
			get
			{
				return this.m_Rotation;
			}
			set
			{
				this.PropertyUpdateDefault("Rotation", value);
				if (this.m_Rotation != value)
				{
					this.m_Rotating = true;
					try
					{
						RotationQuad rotation = this.m_Rotation;
						this.m_Rotation = value;
						if (!this.Loading && !this.Creating && this.NeedsSizeSwap(rotation))
						{
							this.Size = new Size(base.Height, base.Width);
						}
						this.DoPropertyChange(this, "Rotation");
					}
					finally
					{
						this.m_Rotating = false;
					}
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("Determines if the control will adjust its size or orientation in response to specific properties change.")]
		public new bool AutoSize
		{
			get
			{
				return this.m_AutoSize;
			}
			set
			{
				this.PropertyUpdateDefault("AutoSize", value);
				if (this.m_AutoSize != value)
				{
					this.m_AutoSize = value;
					if (this.m_AutoSize)
					{
						this.DoAutoSize();
					}
					this.DoPropertyChange(this, "AutoSize");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		public new Size Size
		{
			get
			{
				return base.Size;
			}
			set
			{
				base.Size = value;
			}
		}

		public new Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				if (!GPFunctions.Equals(base.Font, value))
				{
					base.Font = value;
					this.DoPropertyChange(this, "Font");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		public new Color ForeColor
		{
			get
			{
				if (this.GettingDefault)
				{
					return this.m_ForeColor;
				}
				if (this.m_ForeColor == Color.Empty && base.Parent != null)
				{
					return base.Parent.ForeColor;
				}
				return this.m_ForeColor;
			}
			set
			{
				this.PropertyUpdateDefault("ForeColor", value);
				if (this.ForeColor != value)
				{
					base.ForeColor = value;
					this.m_ForeColor = value;
					this.DoPropertyChange(this, "ForeColor");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		public new Color BackColor
		{
			get
			{
				if (this.GettingDefault)
				{
					return this.m_BackColor;
				}
				if (this.m_BackColor == Color.Empty && base.Parent != null)
				{
					return base.Parent.BackColor;
				}
				return this.m_BackColor;
			}
			set
			{
				this.PropertyUpdateDefault("BackColor", value);
				if (this.BackColor != value)
				{
					base.BackColor = value;
					this.m_BackColor = value;
					this.DoPropertyChange(this, "BackColor");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public BorderControl Border
		{
			get
			{
				return this.m_Border;
			}
		}

		protected Rectangle InnerRectangle
		{
			get
			{
				Rectangle clientRectangle = base.ClientRectangle;
				clientRectangle.Inflate(-this.InnerOffset, -this.InnerOffset);
				return clientRectangle;
			}
		}

		[Browsable(false)]
		public Image SnapShot
		{
			get
			{
				Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
				Bitmap bitmap = new Bitmap(base.Width, base.Height, PixelFormat.Format32bppArgb);
				Graphics graphics = Graphics.FromImage(bitmap);
				PaintEventArgs paintEventArgs = new PaintEventArgs(graphics, rectangle);
				if (!this.SnapShotTransparent)
				{
					Brush brush = new SolidBrush(this.BackColor);
					paintEventArgs.Graphics.FillRectangle(brush, rectangle);
					brush.Dispose();
				}
				this.OnPaint(paintEventArgs);
				graphics.Dispose();
				return bitmap;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		public bool SnapShotTransparent
		{
			get
			{
				return this.m_SnapShotTransparent;
			}
			set
			{
				this.PropertyUpdateDefault("SnapShotTransparent", value);
				if (this.SnapShotTransparent != value)
				{
					this.m_SnapShotTransparent = value;
					this.DoPropertyChange(this, "SnapShotTransparent");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		protected bool IsMouseDown
		{
			get
			{
				return this.m_MouseDown;
			}
			set
			{
				if (this.m_MouseDown != value)
				{
					this.m_MouseDown = value;
					this.m_KeyDown = false;
					this.UIInvalidate(this);
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		protected bool IsKeyDown
		{
			get
			{
				return this.m_KeyDown;
			}
			set
			{
				if (this.m_KeyDown != value)
				{
					this.m_KeyDown = value;
					this.m_MouseDown = false;
					this.UIInvalidate(this);
				}
			}
		}

		protected bool IsDown
		{
			get
			{
				if (!this.m_KeyDown)
				{
					return this.m_MouseDown;
				}
				return true;
			}
		}

		protected int MouseDownX
		{
			get
			{
				return this.m_MouseDownX;
			}
			set
			{
				if (this.m_MouseDownX != value)
				{
					this.m_MouseDownX = value;
					this.UIInvalidate(this);
				}
			}
		}

		protected int MouseDownY
		{
			get
			{
				return this.m_MouseDownY;
			}
			set
			{
				if (this.m_MouseDownY != value)
				{
					this.m_MouseDownY = value;
					this.UIInvalidate(this);
				}
			}
		}

		protected virtual int SpecialOffset => 0;

		[Browsable(false)]
		public event PropertyChangeEventHandler PropertyChanged;

		string ISupportUITypeEditor.GetPlugInTitle()
		{
			return this.GetPlugInTitle();
		}

		string ISupportUITypeEditor.GetPlugInClassName()
		{
			return this.GetPlugInClassName();
		}

		void IComponentBase.ForceDesignerChange()
		{
			this.ForceDesignerChange();
		}

		void IComponentBase.SetComponentDefaults()
		{
			this.SetComponentDefaults();
		}

		void IControlBase.DoAutoSize()
		{
			this.DoAutoSize(0);
		}

		void IControlBase.DoAutoSizeSpecialOffset(int specialOffset)
		{
			this.DoAutoSize(specialOffset);
		}

		void IComponentBase.DoPropertyChange(object sender, string propertyName)
		{
			this.DoPropertyChange(sender, propertyName);
		}

		protected void DoCreate()
		{
			this.m_Creating = true;
			this.m_DefaultReadBack = false;
			try
			{
				this.AutoSize = true;
				base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
				this.ModifyStyle();
				base.UpdateStyles();
				this.m_Border = new BorderControl();
				this.AddSubClass(this.Border);
				this.CreateObjects();
			}
			finally
			{
				this.m_Creating = false;
			}
			this.m_SettingDefaults = true;
			try
			{
				if (this.m_SubClassList != null)
				{
					foreach (ISubClassBase subClass in this.m_SubClassList)
					{
						subClass.SettingDefaults = true;
					}
				}
				this.SetDefaults();
				this.Size = this.GetDefaultSize();
				if (this.m_SubClassList != null)
				{
					foreach (ISubClassBase subClass2 in this.m_SubClassList)
					{
						subClass2.SettingDefaults = false;
					}
				}
			}
			finally
			{
				this.m_SettingDefaults = false;
			}
			this.m_AfterCreating = true;
			try
			{
				this.AfterCreate();
			}
			finally
			{
				this.m_AfterCreating = false;
			}
		}

		protected virtual Size GetDefaultSize()
		{
			return new Size(50, 50);
		}

		protected override void Dispose(bool disposing)
		{
			if (this.m_License != null)
			{
				this.m_License.Dispose();
				this.m_License = null;
			}
			base.Dispose(disposing);
		}

		protected virtual void Loaded()
		{
		}

		protected virtual void ModifyStyle()
		{
		}

		protected virtual void CreateObjects()
		{
		}

		protected virtual void AfterCreate()
		{
		}

		protected virtual string GetPlugInTitle()
		{
			return Const.EmptyString;
		}

		protected virtual string GetPlugInClassName()
		{
			return Const.EmptyString;
		}

		protected virtual void SetDefaults()
		{
			this.Rotation = RotationQuad.X000;
			this.Border.Style = BorderStyleControl.None;
			this.Border.Margin = 0;
			this.Border.ThicknessDesired = 2;
			this.Border.Color = Color.Empty;
			this.BackColor = Color.Empty;
			this.ForeColor = Color.Empty;
			this.AutoSize = true;
			this.SnapShotTransparent = false;
		}

		public virtual void LoadingBegin()
		{
			this.m_Loading = true;
		}

		public virtual void LoadingEnd()
		{
			this.m_Loading = false;
			this.Loaded();
		}

		private bool ShouldSerializeSecondHandColor()
		{
			return this.PropertyShouldSerialize("SecondHandColor");
		}

		private void ResetSecondHandColor()
		{
			this.PropertyReset("SecondHandColor");
		}

		protected void AddSubClass(ISubClassBase value)
		{
			if (this.m_SubClassList == null)
			{
				this.m_SubClassList = new SubClassBaseCollection();
			}
			this.m_SubClassList.Add(value);
			value.ControlBase = this;
			value.ComponentBase = this;
		}

		protected virtual bool NeedsSizeSwap(RotationQuad value)
		{
			if (value == this.m_Rotation)
			{
				return false;
			}
			bool flag = this.m_Rotation == RotationQuad.X000 || this.m_Rotation == RotationQuad.X180;
			bool flag2 = value == RotationQuad.X000 || value == RotationQuad.X180;
			return flag != flag2;
		}

		protected bool NeedsSizeSwap()
		{
			if (this.Rotation == RotationQuad.X090)
			{
				return true;
			}
			if (this.Rotation == RotationQuad.X270)
			{
				return true;
			}
			return false;
		}

		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			bool flag = this.NeedsSizeSwap();
			this.m_SettingBoundsCore = true;
			try
			{
				if (flag)
				{
					this.InternalSetBoundsCore(x, y, height, width, specified);
				}
				else
				{
					this.InternalSetBoundsCore(x, y, width, height, specified);
				}
				if (!this.AutoSizing && !this.Loading)
				{
					if (flag)
					{
						this.ManualSizeFixupInternal(height - 2 * this.InnerOffset, width - 2 * this.InnerOffset);
					}
					else
					{
						this.ManualSizeFixupInternal(width - 2 * this.InnerOffset, height - 2 * this.InnerOffset);
					}
				}
			}
			finally
			{
				this.m_SettingBoundsCore = false;
			}
		}

		protected virtual void InternalSetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
			if (this.NeedsSizeSwap())
			{
				base.SetBoundsCore(x, y, height, width, specified);
			}
			else
			{
				base.SetBoundsCore(x, y, width, height, specified);
			}
		}

		private void ManualSizeFixupInternal(int innerWidth, int innerHeight)
		{
			this.m_ManualSizeFixing = true;
			this.ManualSizeFixup(innerWidth, innerHeight);
			this.m_ManualSizeFixing = false;
		}

		protected virtual void ManualSizeFixup(int innerWidth, int innerHeight)
		{
		}

		protected virtual Size CalculateAutoSize(int innerWidth, int innerHeight)
		{
			return Size.Empty;
		}

		protected virtual Point CalculateAutoSizeLocation(Size newSize)
		{
			return new Point(0, 0);
		}

		protected void DoAutoSize()
		{
			this.DoAutoSize(0);
		}

		protected void DoAutoSize(object sender, string propertyName)
		{
			this.DoAutoSize(0);
		}

		protected void DoAutoSizeSpecialOffset(int specialOffset)
		{
			this.DoAutoSize(specialOffset);
		}

		protected virtual void DoAutoSize(int specialOffset)
		{
			if (!this.Loading && !this.Creating && !this.AfterCreating && !this.SettingDefaults)
			{
				if (this.FreezeAutoSize)
				{
					this.m_FreezeAutoSizeOffsetTotal += specialOffset;
				}
				else
				{
					bool flag = this.NeedsSizeSwap();
					if (!this.AutoSize)
					{
						if (flag)
						{
							this.ManualSizeFixupInternal(base.Height - 2 * this.InnerOffset, base.Width - 2 * this.InnerOffset);
						}
						else
						{
							this.ManualSizeFixupInternal(base.Width - 2 * this.InnerOffset, base.Height - 2 * this.InnerOffset);
						}
					}
					else if (!this.m_SettingBoundsCore && !this.AutoSizing)
					{
						this.m_AutoSizing = true;
						try
						{
							int num;
							int num2;
							if (flag)
							{
								num = base.Height - 2 * this.InnerOffset;
								num2 = base.Width - 2 * this.InnerOffset;
							}
							else
							{
								num = base.Width - 2 * this.InnerOffset;
								num2 = base.Height - 2 * this.InnerOffset;
							}
							Size size = this.CalculateAutoSize(num, num2);
							num = ((size.Width != 0) ? (size.Width + 2 * this.InnerOffset) : (num + 2 * this.InnerOffset + 2 * specialOffset));
							num2 = ((size.Height != 0) ? (size.Height + 2 * this.InnerOffset) : (num2 + 2 * this.InnerOffset + 2 * specialOffset));
							size = ((!flag) ? new Size(num, num2) : new Size(num2, num));
							Point location = this.CalculateAutoSizeLocation(size);
							this.Size = size;
							if (!location.IsEmpty)
							{
								base.Location = location;
							}
						}
						finally
						{
							this.m_AutoSizing = false;
						}
						this.ForceDesignerChange();
					}
				}
			}
		}

		private bool ShouldSerializeRotation()
		{
			return this.PropertyShouldSerialize("Rotation");
		}

		private void ResetRotation()
		{
			this.PropertyReset("Rotation");
		}

		private bool ShouldSerializeAutoSize()
		{
			return this.PropertyShouldSerialize("AutoSize");
		}

		private void ResetAutoSize()
		{
			this.PropertyReset("AutoSize");
		}

		private void ResetSize()
		{
			if (this.NeedsSizeSwap(RotationQuad.X000))
			{
				this.Size = new Size(this.DefaultSize.Height, this.DefaultSize.Width);
			}
			else
			{
				this.Size = this.DefaultSize;
			}
		}

		protected override void OnParentFontChanged(EventArgs e)
		{
			base.OnParentFontChanged(e);
			this.DoPropertyChange(this, "Font");
		}

		public bool ShouldSerializeForeColor()
		{
			return this.PropertyShouldSerialize("ForeColor");
		}

		public override void ResetForeColor()
		{
			this.PropertyReset("ForeColor");
		}

		public bool ShouldSerializeBackColor()
		{
			return this.PropertyShouldSerialize("BackColor");
		}

		public override void ResetBackColor()
		{
			this.PropertyReset("BackColor");
		}

		private bool ShouldSerializeBorder()
		{
			return ((ISubClassBase)this.Border).ShouldSerialize();
		}

		private void ResetBorder()
		{
			((ISubClassBase)this.Border).ResetToDefault();
		}

		private bool ShouldSerializeSnapShotTransparent()
		{
			return this.PropertyShouldSerialize("SnapShotTransparent");
		}

		private void ResetSnapShotTransparent()
		{
			this.PropertyReset("SnapShotTransparent");
		}

		protected void ForceDesignerChange()
		{
			IComponentChangeService componentChangeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
			componentChangeService?.OnComponentChanged(this, null, null, null);
			base.Invalidate();
		}

		protected virtual void SetComponentDefaults()
		{
		}

		protected void ThrowStreamingSafeException(string value)
		{
			if (this.Loading)
			{
				return;
			}
			throw new Exception(value);
		}

		protected virtual void InternalOnMouseLeft(MouseEventArgs e)
		{
		}

		protected virtual void InternalOnMouseRight(MouseEventArgs e)
		{
		}

		protected virtual void InternalOnMouseMove(MouseEventArgs e)
		{
		}

		protected virtual void InternalOnMouseUp(MouseEventArgs e)
		{
		}

		protected virtual void InternalOnDoubleClick(MouseEventArgs e)
		{
		}

		protected virtual void InternalOnMouseWheel(MouseEventArgs e)
		{
		}

		protected virtual void InternalOnLostFocus(EventArgs e)
		{
		}

		protected virtual void InternalOnGotFocus(EventArgs e)
		{
		}

		protected virtual void InternalOnKeyDown(KeyEventArgs e)
		{
		}

		protected virtual void InternalOnKeyUp(KeyEventArgs e)
		{
		}

		protected virtual void InternalOnKeyPress(KeyPressEventArgs e)
		{
		}

		protected MouseEventArgs GetRotatedMouseEventArgs(MouseEventArgs e)
		{
			Point point = new Point(e.X, e.Y);
			Rectangle rectangle = this.InnerRectangle;
			rectangle = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width - 1, rectangle.Height - 1);
			Point point2 = (this.Rotation != RotationQuad.X090) ? ((this.Rotation != RotationQuad.X180) ? ((this.Rotation != RotationQuad.X270) ? point : new Point(rectangle.Bottom - point.Y, point.X)) : new Point(rectangle.Right - point.X, rectangle.Bottom - point.Y)) : new Point(point.Y, rectangle.Right - point.X);
			return new MouseEventArgs(e.Button, e.Clicks, point2.X, point2.Y, e.Delta);
		}

		public MouseEventArgs GetInternalMouseEventArgs(MouseEventArgs e)
		{
			return this.GetRotatedMouseEventArgs(e);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.m_LastMouseDownEventArgs = e;
			if (e.Button == MouseButtons.Right)
			{
				e = this.GetRotatedMouseEventArgs(e);
				this.m_MouseDownX = e.X;
				this.m_MouseDownY = e.Y;
				this.InternalOnMouseRight(e);
			}
			else if (e.Button == MouseButtons.Left)
			{
				e = this.GetRotatedMouseEventArgs(e);
				this.m_MouseDownX = e.X;
				this.m_MouseDownY = e.Y;
				this.InternalOnMouseLeft(e);
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			e = this.GetRotatedMouseEventArgs(e);
			this.InternalOnMouseMove(e);
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			e = this.GetRotatedMouseEventArgs(e);
			this.InternalOnMouseUp(e);
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			e = this.GetRotatedMouseEventArgs(e);
			this.InternalOnMouseWheel(e);
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);
			this.InternalOnDoubleClick(this.m_LastMouseDownEventArgs);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			this.InternalOnKeyDown(e);
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			this.InternalOnKeyUp(e);
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			this.InternalOnKeyPress(e);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			this.m_MouseDown = false;
			this.m_KeyDown = false;
			this.UIInvalidate(this);
			this.InternalOnLostFocus(e);
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.UIInvalidate(this);
			this.InternalOnGotFocus(e);
		}

		protected virtual void DoPaint(PaintArgs p)
		{
		}

		private void OnPropertyChanged(object sender, string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
			}
		}

		protected void DoPropertyChange(object sender, string propertyName)
		{
			if (!this.Creating && !this.SettingDefaults)
			{
				this.PropertyChangedHook(sender, propertyName);
				this.CodeInvalidate(this);
				if (this.PropertyChanged != null)
				{
					this.OnPropertyChanged(sender, propertyName);
				}
			}
		}

		public void InvalidateControl()
		{
			base.Invalidate();
		}

		[Browsable(false)]
		public void UIInvalidate(object sender)
		{
			this.InvalidateControl();
		}

		[Browsable(false)]
		public void CodeInvalidate(object sender)
		{
			this.InvalidateControl();
		}

		protected virtual void PropertyChangedHook(object sender, string propertyName)
		{
		}

		public void ShowEditorCustom(bool designTimeStyle, bool modal)
		{
			UITypeEditorGeneric uITypeEditorGeneric = (UITypeEditorGeneric)TypeDescriptor.GetEditor(this, typeof(UITypeEditor));
			uITypeEditorGeneric?.EditValue(this, designTimeStyle, modal);
		}

		protected void PropertyUpdateDefault(string name, object value)
		{
			if (this.SettingDefaults)
			{
				if (this.m_DefaultArray == null)
				{
					this.m_DefaultArray = new ArrayList();
				}
				foreach (PropertyData item in this.m_DefaultArray)
				{
					if (!(item.Name.ToUpper(CultureInfo.InvariantCulture) == name.ToUpper(CultureInfo.InvariantCulture)))
					{
						continue;
					}
					item.Value = value;
					return;
				}
				PropertyData propertyData2 = new PropertyData();
				propertyData2.Name = name;
				propertyData2.Value = value;
				this.m_DefaultArray.Add(propertyData2);
			}
		}

		protected void PropertyReset(string name)
		{
			if (this.m_DefaultArray != null)
			{
				foreach (PropertyData item in this.m_DefaultArray)
				{
					if (!(item.Name.ToUpper(CultureInfo.InvariantCulture) == name.ToUpper(CultureInfo.InvariantCulture)))
					{
						continue;
					}
					PropertyInfo property = base.GetType().GetProperty(name);
					if (property != (PropertyInfo)null)
					{
						property.SetValue(this, item.Value, null);
					}
					this.ForceDesignerChange();
					break;
				}
			}
		}

		protected bool PropertyShouldSerialize(string name)
		{
			if (this.m_DefaultArray == null)
			{
				return true;
			}
			this.m_GettingDefault = true;
			try
			{
				foreach (PropertyData item in this.m_DefaultArray)
				{
					if (item.Name.ToUpper(CultureInfo.InvariantCulture) == name.ToUpper(CultureInfo.InvariantCulture))
					{
						PropertyInfo property = base.GetType().GetProperty(name);
						if (property == (PropertyInfo)null)
						{
							continue;
						}
						if (item.Value == null)
						{
							return property.GetValue(this, null) != null;
						}
						if (item.Value.GetType() == typeof(string[]))
						{
							if ((property.GetValue(this, null) as string[]).Length > 1)
							{
								return true;
							}
							return (property.GetValue(this, null) as string[])[0].Length != 0;
						}
						return !item.Value.Equals(property.GetValue(this, null));
					}
				}
				return true;
			}
			finally
			{
				this.m_GettingDefault = false;
			}
		}

		protected override void OnPaint(PaintEventArgs p)
		{
			this.PaintAll(p);
			base.OnPaint(p);
		}

		protected void PaintAll(PaintEventArgs p)
		{
			Rectangle innerRectangle = this.InnerRectangle;
			PaintArgs paintArgs = new PaintArgs(p.Graphics, innerRectangle, this.BackColor);
			if (innerRectangle.Width != 0 && innerRectangle.Height != 0)
			{
				paintArgs.Rotate(this.Rotation);
				try
				{
					this.DoPaint(paintArgs);
				}
				catch (Exception ex)
				{
					Font font = new Font("Microsoft Sans Serif", 8f, FontStyle.Regular);
					p.Graphics.ResetClip();
					p.Graphics.FillRectangle(new SolidBrush(Color.White), base.ClientRectangle);
					p.Graphics.DrawString(ex.Message, font, new SolidBrush(Color.Black), base.ClientRectangle);
					if (ex.GetType().Name == "Exception")
					{
						throw new Exception(ex.Message);
					}
					if (!(ex.GetType().Name == "SystemException"))
					{
						goto end_IL_004a;
					}
					throw new SystemException(ex.Message);
					end_IL_004a:;
				}
			}
			p.Graphics.ResetTransform();
			p.Graphics.ResetClip();
			paintArgs.Rotation = RotationQuad.X000;
			((IBorderControl)this.m_Border).Draw(paintArgs, base.ClientRectangle);
			paintArgs.CleanUp();
		}

		bool IControlBase.Focus()
		{
			return base.Focus();
		}
	}
}
