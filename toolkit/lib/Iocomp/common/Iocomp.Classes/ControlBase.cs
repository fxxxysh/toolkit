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
using System.IO;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Serializable]
	[Editor(typeof(UITypeEditorGeneric), typeof(UITypeEditor))]
	[DesignerSerializer(typeof(LoadBeginEndSerializerControlBase), typeof(CodeDomSerializer))]
	[Description("Iocomp's ancestor class for all controls.")]
	[DesignerCategory("code")]
	public abstract class ControlBase : Control, IAmbientOwner, IPropertyDefaults, ISupportUITypeEditor, IUpdateRate, IControlBase, IComponentBase
	{
		protected License m_License;

		private bool m_Loading;

		private bool m_Creating;

		private bool m_SettingDefaults;

		private bool m_AutoSizing;

		private bool m_ManualSizeFixing;

		private bool m_AfterCreating;

		private bool m_UserGenerated;

		private bool m_OPCUpdateActive;

		private bool m_MouseDown;

		private bool m_KeyDown;

		private int m_MouseDownX;

		private int m_MouseDownY;

		private MouseEventArgs m_LastMouseDownEventArgs;

		private double m_UpdateFrameRate;

		private DateTime m_UpdateLastRepaintTime;

		private bool m_UpdateActive;

		private bool m_UpdateNeeded;

		private BorderControl m_Border;

		private bool m_GettingDefault;

		private bool m_DefaultReadBack;

		private ArrayList m_DefaultArray;

		private RotationQuad m_Rotation;

		private bool m_Rotating;

		private bool m_SettingBoundsCore;

		private System.Windows.Forms.Timer m_Timer;

		public DateTime m_CreationTime;

		private bool m_AutoSize;

		private Color m_BackColor;

		private Color m_ForeColor;

		private bool m_SnapShotTransparent;

		private SubClassBaseCollection m_SubClassList;

		private bool m_FreezeAutoSize;

		private int m_FreezeAutoSizeOffsetTotal;

		private Color m_Color;

		private Color m_CustomColor1;

		private Color m_CustomColor2;

		private Color m_CustomColor3;

		private AmbientColorSouce m_ColorAmbientSource;

		Font IAmbientOwner.Font
		{
			get
			{
				return this.Font;
			}
		}

		Color IAmbientOwner.ForeColor
		{
			get
			{
				return this.ForeColor;
			}
		}

		Color IAmbientOwner.BackColor
		{
			get
			{
				return this.BackColor;
			}
		}

		Color IAmbientOwner.Color
		{
			get
			{
				return this.Color;
			}
		}

		Color IAmbientOwner.CustomColor1
		{
			get
			{
				return this.CustomColor1;
			}
		}

		Color IAmbientOwner.CustomColor2
		{
			get
			{
				return this.CustomColor1;
			}
		}

		Color IAmbientOwner.CustomColor3
		{
			get
			{
				return this.CustomColor1;
			}
		}

		double IUpdateRate.FrameRate
		{
			get
			{
				return this.m_UpdateFrameRate;
			}
			set
			{
				this.m_UpdateFrameRate = value;
			}
		}

		DateTime IUpdateRate.LastRepaintTime
		{
			get
			{
				return this.m_UpdateLastRepaintTime;
			}
			set
			{
				this.m_UpdateLastRepaintTime = value;
			}
		}

		bool IUpdateRate.Active
		{
			get
			{
				return this.m_UpdateActive;
			}
			set
			{
				this.m_UpdateActive = value;
			}
		}

		bool IUpdateRate.Needed
		{
			get
			{
				return this.m_UpdateNeeded;
			}
			set
			{
				this.m_UpdateNeeded = value;
			}
		}

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

		protected AmbientColorSouce ColorAmbientSource
		{
			get
			{
				return this.m_ColorAmbientSource;
			}
			set
			{
				this.m_ColorAmbientSource = value;
			}
		}

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
		public bool UserGenerated
		{
			get
			{
				return this.m_UserGenerated;
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
				if (!value)
				{
					this.LoadingEnd();
				}
			}
		}

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

		[Category("Iocomp")]
		[Description("Specifies the rotation of the title and bevel.")]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Category("Iocomp")]
		[Description("Determines if the control will adjust its size or orientation in response to specific property changes.")]
		[RefreshProperties(RefreshProperties.All)]
		[Browsable(true)]
		[DefaultValue(true)]
		public override bool AutoSize
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

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("Determines if the control will adjust its size or orientation in response to specific properties change.")]
		public double UpdateFrameRate
		{
			get
			{
				return this.m_UpdateFrameRate;
			}
			set
			{
				if (value > 50.0)
				{
					value = 50.0;
				}
				this.PropertyUpdateDefault("UpdateFrameRate", value);
				if (this.m_UpdateFrameRate != value)
				{
					this.m_UpdateFrameRate = value;
					this.DoPropertyChange(this, "UpdateFrameRate");
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

		[RefreshProperties(RefreshProperties.All)]
		protected Color Color
		{
			get
			{
				if (this.m_Color == Color.Empty && this.ColorAmbientSource == AmbientColorSouce.BackColor)
				{
					return this.BackColor;
				}
				if (this.m_Color == Color.Empty && this.ColorAmbientSource == AmbientColorSouce.ForeColor)
				{
					return this.ForeColor;
				}
				return this.m_Color;
			}
			set
			{
				this.PropertyUpdateDefault("Color", value);
				if (this.Color != value)
				{
					this.m_Color = value;
					this.DoPropertyChange(this, "Color");
				}
			}
		}

		protected Color CustomColor1
		{
			get
			{
				return this.m_CustomColor1;
			}
			set
			{
				this.PropertyUpdateDefault("CustomColor1", value);
				if (this.CustomColor1 != value)
				{
					this.m_CustomColor1 = value;
					this.DoPropertyChange(this, "CustomColor1");
				}
			}
		}

		protected Color CustomColor2
		{
			get
			{
				return this.m_CustomColor2;
			}
			set
			{
				this.PropertyUpdateDefault("CustomColor2", value);
				if (this.CustomColor2 != value)
				{
					this.m_CustomColor2 = value;
					this.DoPropertyChange(this, "CustomColor2");
				}
			}
		}

		protected Color CustomColor3
		{
			get
			{
				return this.m_CustomColor3;
			}
			set
			{
				this.PropertyUpdateDefault("CustomColor3", value);
				if (this.CustomColor3 != value)
				{
					this.m_CustomColor3 = value;
					this.DoPropertyChange(this, "CustomColor3");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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
				Rectangle result = base.ClientRectangle;
				result.Inflate(-this.InnerOffset, -this.InnerOffset);
				result = Rectangle.FromLTRB(result.Left + this.Border.MarginLeft, result.Top + this.Border.MarginTop, result.Right - this.Border.MarginRight, result.Bottom - this.Border.MarginBottom);
				return result;
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

		[Browsable(false)]
		[Category("Iocomp")]
		public EventSource EventSource
		{
			get
			{
				if (this.m_UserGenerated)
				{
					return EventSource.User;
				}
				if (this.m_OPCUpdateActive)
				{
					return EventSource.Opc;
				}
				return EventSource.Code;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public bool OPCUpdateActive
		{
			get
			{
				return this.m_OPCUpdateActive;
			}
			set
			{
				this.m_OPCUpdateActive = value;
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
			this.m_CreationTime = DateTime.Now;
			this.m_Creating = true;
			this.m_DefaultReadBack = false;
			this.UpdateFrameRate = 50.0;
			UpdateRateTimer.AddControl(this);
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
			if (disposing)
			{
				this.AnimationTimerDestroy();
				UpdateRateTimer.RemoveControl(this);
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
			this.Border.MarginLeft = 0;
			this.Border.MarginRight = 0;
			this.Border.MarginTop = 0;
			this.Border.MarginBottom = 0;
			this.Border.ThicknessDesired = 2;
			this.Border.Color = Color.Empty;
			this.BackColor = Color.Empty;
			this.ForeColor = Color.Empty;
			this.AutoSize = true;
			this.UpdateFrameRate = 50.0;
			this.SnapShotTransparent = false;
			this.ColorAmbientSource = AmbientColorSouce.BackColor;
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

		public void SavePropertiesToFile(string fileName)
		{
			InstanceIO.SavePropertiesToFile(this, fileName);
		}

		public void LoadPropertiesFromFile(string fileName)
		{
			InstanceIO.LoadPropertiesFromFile(this, fileName);
		}

		public void SavePropertiesToStream(StreamWriter streamWriter)
		{
			InstanceIO.SavePropertiesToStream(this, streamWriter);
		}

		public void LoadPropertiesFromStream(StreamReader streamReader)
		{
			InstanceIO.LoadPropertiesFromStream(this, streamReader);
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
			value.AmbientOwner = this;
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

		private bool ShouldSerializeUpdateFrameRate()
		{
			return this.PropertyShouldSerialize("UpdateFrameRate");
		}

		private void ResetUpdateFrameRate()
		{
			this.PropertyReset("UpdateFrameRate");
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

		protected void AnimationTimerCreate(int value)
		{
			if (this.m_Timer == null)
			{
				this.m_Timer = new System.Windows.Forms.Timer();
				this.m_Timer.Interval = value;
				this.m_Timer.Tick += this.m_Timer_Tick;
				this.m_Timer.Enabled = true;
			}
			this.CodeInvalidate(this);
		}

		protected void AnimationTimerDestroy()
		{
			if (this.m_Timer != null)
			{
				this.m_Timer.Enabled = false;
				this.m_Timer.Dispose();
				this.m_Timer = null;
			}
			this.CodeInvalidate(this);
		}

		private void m_TimerHandler(object sender, ElapsedEventArgs e)
		{
			this.AnimationTimerHandler(sender);
		}

		private void m_Timer_Tick(object sender, EventArgs e)
		{
			this.AnimationTimerHandler(sender);
		}

		protected virtual void AnimationTimerHandler(object sender)
		{
			this.AnimationTimerDestroy();
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
				this.m_UserGenerated = true;
				try
				{
					this.m_MouseDownX = e.X;
					this.m_MouseDownY = e.Y;
					this.InternalOnMouseRight(e);
				}
				finally
				{
					this.m_UserGenerated = false;
				}
			}
			else if (e.Button == MouseButtons.Left)
			{
				e = this.GetRotatedMouseEventArgs(e);
				this.m_UserGenerated = true;
				try
				{
					this.m_MouseDownX = e.X;
					this.m_MouseDownY = e.Y;
					this.InternalOnMouseLeft(e);
				}
				finally
				{
					this.m_UserGenerated = false;
				}
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			e = this.GetRotatedMouseEventArgs(e);
			this.m_UserGenerated = true;
			try
			{
				this.InternalOnMouseMove(e);
			}
			finally
			{
				this.m_UserGenerated = false;
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			e = this.GetRotatedMouseEventArgs(e);
			this.m_UserGenerated = true;
			try
			{
				this.InternalOnMouseUp(e);
			}
			finally
			{
				this.m_UserGenerated = false;
			}
		}

		protected override void OnMouseWheel(MouseEventArgs e)
		{
			base.OnMouseWheel(e);
			e = this.GetRotatedMouseEventArgs(e);
			this.m_UserGenerated = true;
			try
			{
				this.InternalOnMouseWheel(e);
			}
			finally
			{
				this.m_UserGenerated = false;
			}
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);
			this.m_UserGenerated = true;
			try
			{
				this.InternalOnDoubleClick(this.m_LastMouseDownEventArgs);
			}
			finally
			{
				this.m_UserGenerated = false;
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			this.m_UserGenerated = true;
			try
			{
				this.InternalOnKeyDown(e);
			}
			finally
			{
				this.m_UserGenerated = false;
			}
		}

		protected override void OnKeyUp(KeyEventArgs e)
		{
			base.OnKeyUp(e);
			this.m_UserGenerated = true;
			try
			{
				this.InternalOnKeyUp(e);
			}
			finally
			{
				this.m_UserGenerated = false;
			}
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			this.m_UserGenerated = true;
			try
			{
				this.InternalOnKeyPress(e);
			}
			finally
			{
				this.m_UserGenerated = false;
			}
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
				if (sender is Value)
				{
					this.ForegroundInvalidate(this);
				}
				else
				{
					this.CodeInvalidate(this);
				}
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
			base.Invalidate();
		}

		[Browsable(false)]
		public void CodeInvalidate(object sender)
		{
			this.InvalidateFrameRate(sender);
		}

		private void ForegroundInvalidate(object sender)
		{
			this.InvalidateFrameRate(sender);
		}

		private void InvalidateFrameRate(object sender)
		{
			if (!base.Disposing)
			{
				if (this.Designing)
				{
					base.Invalidate();
				}
				else
				{
					this.m_UpdateNeeded = true;
					this.InvalidateCheck();
				}
			}
		}

		public void InvalidateCheck()
		{
			if (!base.Disposing && UpdateRateTimer.NeedsUpdate(this))
			{
				base.Invalidate();
			}
		}

		public void BeginUpdate()
		{
			this.m_UpdateActive = true;
		}

		public void EndUpdate()
		{
			this.m_UpdateActive = false;
			this.InvalidateCheck();
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
			if (!this.m_UpdateActive)
			{
				this.m_UpdateLastRepaintTime = DateTime.Now;
				this.m_UpdateNeeded = false;
				this.PaintAll(p);
				base.OnPaint(p);
			}
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
