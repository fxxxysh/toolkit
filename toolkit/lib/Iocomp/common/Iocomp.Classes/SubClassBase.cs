using Iocomp.Delegates;
using Iocomp.Design;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Serializable]
	[TypeConverter(typeof(SubClassTypeConverter))]
	[ToolboxItem(false)]
	[Editor(typeof(UITypeEditorGeneric), typeof(UITypeEditor))]
	[Description("Iocomp's ancestor for all sub class objects.")]
	[Category("Iocomp")]
	public abstract class SubClassBase : ISubClassBase, IUIInput, IAmbientOwner, IPropertyDefaults, ISupportUITypeEditor
	{
		private IControlBase m_ControlBase;

		private IComponentBase m_ComponentBase;

		private CollectionBase m_Collection;

		private bool m_Creating;

		private bool m_CreationComplete;

		private ArrayList m_DefaultArray;

		private SubClassBaseCollection m_SubClassList;

		private bool m_DefaultReadBack;

		private bool m_GettingDefault;

		private bool m_SettingDefaults;

		private UIInputCollection m_UICollection;

		private Rectangle m_Bounds;

		private bool m_IsMouseDown;

		private bool m_IsMouseActive;

		private bool m_IsKeyDown;

		private bool m_IsKeyActive;

		private bool m_VisibleInternal;

		private bool m_EnabledInternal;

		private Font m_Font;

		private Color m_ForeColor;

		private Color m_BackColor;

		private Color m_CustomColor1;

		private Color m_CustomColor2;

		private Color m_CustomColor3;

		private Color m_Color;

		private IAmbientOwner I_AmbientOwner;

		private AmbientColorSouce m_ColorAmbientSource;

		private bool m_FreezePropertyChange;

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
				return this.CustomColor2;
			}
		}

		Color IAmbientOwner.CustomColor3
		{
			get
			{
				return this.CustomColor3;
			}
		}

		IControlBase ISubClassBase.ControlBase
		{
			get
			{
				return this.ControlBase;
			}
			set
			{
				this.ControlBase = value;
			}
		}

		IComponentBase ISubClassBase.ComponentBase
		{
			get
			{
				return this.ComponentBase;
			}
			set
			{
				this.ComponentBase = value;
			}
		}

		CollectionBase ISubClassBase.Collection
		{
			get
			{
				return this.m_Collection;
			}
			set
			{
				this.m_Collection = value;
			}
		}

		IAmbientOwner ISubClassBase.AmbientOwner
		{
			get
			{
				return this.I_AmbientOwner;
			}
			set
			{
				this.I_AmbientOwner = value;
			}
		}

		SubClassBaseCollection ISubClassBase.SubClassList
		{
			get
			{
				return this.SubClassList;
			}
		}

		bool ISubClassBase.SettingDefaults
		{
			get
			{
				return this.SettingDefaults;
			}
			set
			{
				this.SettingDefaults = value;
			}
		}

		bool ISubClassBase.FreezePropertyChange
		{
			get
			{
				return this.FreezePropertyChange;
			}
			set
			{
				this.FreezePropertyChange = value;
			}
		}

		AmbientColorSouce ISubClassBase.ColorAmbientSource
		{
			get
			{
				return this.ColorAmbientSource;
			}
			set
			{
				this.ColorAmbientSource = value;
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

		UIInputCollection IUIInput.UICollection
		{
			get
			{
				return this.m_UICollection;
			}
			set
			{
				this.m_UICollection = value;
			}
		}

		bool IUIInput.Visible
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

		bool IUIInput.HitVisible
		{
			get
			{
				return this.HitVisibleInternal;
			}
		}

		bool IUIInput.Enabled
		{
			get
			{
				return this.EnabledInternal;
			}
			set
			{
				this.EnabledInternal = value;
			}
		}

		bool IUIInput.Focused
		{
			get
			{
				return this.Focused;
			}
		}

		bool IUIInput.IsMouseDown
		{
			get
			{
				return this.IsMouseDown;
			}
			set
			{
				this.IsMouseDown = value;
			}
		}

		bool IUIInput.IsMouseActive
		{
			get
			{
				return this.IsMouseActive;
			}
			set
			{
				this.IsMouseActive = value;
			}
		}

		bool IUIInput.IsKeyDown
		{
			get
			{
				return this.IsKeyDown;
			}
			set
			{
				this.IsKeyDown = value;
			}
		}

		bool IUIInput.IsKeyActive
		{
			get
			{
				return this.IsKeyActive;
			}
			set
			{
				this.IsKeyActive = value;
			}
		}

		Rectangle IUIInput.Bounds
		{
			get
			{
				return this.Bounds;
			}
			set
			{
				this.Bounds = value;
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

		protected IAmbientOwner AmbientOwner => this.I_AmbientOwner;

		[Browsable(false)]
		public bool Creating
		{
			get
			{
				return this.m_Creating;
			}
		}

		protected bool SettingDefaults
		{
			get
			{
				return this.m_SettingDefaults;
			}
			set
			{
				this.m_SettingDefaults = value;
				if (this.m_SubClassList != null)
				{
					foreach (SubClassBase subClass in this.m_SubClassList)
					{
						((ISubClassBase)subClass).SettingDefaults = value;
					}
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
				this.m_DefaultReadBack = value;
				if (this.m_SubClassList != null)
				{
					foreach (IPropertyDefaults subClass in this.m_SubClassList)
					{
						subClass.DefaultReadBack = value;
					}
				}
			}
		}

		protected virtual IControlBase ControlBase
		{
			get
			{
				return this.m_ControlBase;
			}
			set
			{
				if (this.m_ControlBase != value)
				{
					this.m_ControlBase = value;
					if (this.m_SubClassList != null)
					{
						foreach (SubClassBase subClass in this.m_SubClassList)
						{
							((ISubClassBase)subClass).ControlBase = this.ControlBase;
						}
					}
				}
			}
		}

		protected virtual IComponentBase ComponentBase
		{
			get
			{
				return this.m_ComponentBase;
			}
			set
			{
				if (this.m_ComponentBase != value)
				{
					this.m_ComponentBase = value;
					if (this.m_SubClassList != null)
					{
						foreach (SubClassBase subClass in this.m_SubClassList)
						{
							((ISubClassBase)subClass).ComponentBase = this.ComponentBase;
						}
					}
				}
			}
		}

		protected CollectionBase Collection => this.m_Collection;

		protected bool Designing
		{
			get
			{
				if (this.ComponentBase != null)
				{
					return this.ComponentBase.Designing;
				}
				return false;
			}
		}

		protected virtual bool VisibleInternal
		{
			get
			{
				return this.m_VisibleInternal;
			}
			set
			{
				this.PropertyUpdateDefault("Visible", value);
				if (this.VisibleInternal != value)
				{
					this.m_VisibleInternal = value;
					if (!this.m_VisibleInternal && this.UICollection != null)
					{
						this.UICollection.FocusDisabled(this);
					}
					this.DoPropertyChange(this, "Visible");
				}
			}
		}

		protected virtual bool HitVisibleInternal => this.m_VisibleInternal;

		protected bool EnabledInternal
		{
			get
			{
				return this.m_EnabledInternal;
			}
			set
			{
				this.PropertyUpdateDefault("Enabled", value);
				if (this.EnabledInternal != value)
				{
					this.m_EnabledInternal = value;
					if (!this.m_EnabledInternal && this.UICollection != null)
					{
						this.UICollection.FocusDisabled(this);
					}
					this.DoPropertyChange(this, "Enabled");
				}
			}
		}

		[Category("Iocomp")]
		[Description("")]
		protected Font Font
		{
			get
			{
				if (this.GettingDefault)
				{
					return this.m_Font;
				}
				if (this.m_Font == null && this.AmbientOwner != null)
				{
					return this.AmbientOwner.Font;
				}
				return this.m_Font;
			}
			set
			{
				this.PropertyUpdateDefault("Font", value);
				if (!GPFunctions.Equals(this.Font, value))
				{
					this.m_Font = value;
					this.DoPropertyChange(this, "Font");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		protected Color ForeColor
		{
			get
			{
				if (this.GettingDefault)
				{
					return this.m_ForeColor;
				}
				if (this.m_ForeColor == Color.Empty && this.AmbientOwner != null)
				{
					return this.AmbientOwner.ForeColor;
				}
				return this.m_ForeColor;
			}
			set
			{
				this.PropertyUpdateDefault("ForeColor", value);
				if (this.ForeColor != value)
				{
					this.m_ForeColor = value;
					this.DoPropertyChange(this, "ForeColor");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		protected Color BackColor
		{
			get
			{
				if (this.GettingDefault)
				{
					return this.m_BackColor;
				}
				if (this.m_BackColor == Color.Empty && this.AmbientOwner != null)
				{
					return this.AmbientOwner.BackColor;
				}
				return this.m_BackColor;
			}
			set
			{
				this.PropertyUpdateDefault("BackColor", value);
				if (this.BackColor != value)
				{
					this.m_BackColor = value;
					this.DoPropertyChange(this, "BackColor");
				}
			}
		}

		protected Color CustomColor1
		{
			get
			{
				if (this.GettingDefault)
				{
					return this.m_CustomColor1;
				}
				if (this.m_CustomColor1 == Color.Empty && this.AmbientOwner != null)
				{
					return this.AmbientOwner.CustomColor1;
				}
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
				if (this.GettingDefault)
				{
					return this.m_CustomColor2;
				}
				if (this.m_CustomColor2 == Color.Empty && this.AmbientOwner != null)
				{
					return this.AmbientOwner.CustomColor2;
				}
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
				if (this.GettingDefault)
				{
					return this.m_CustomColor3;
				}
				if (this.m_CustomColor3 == Color.Empty && this.AmbientOwner != null)
				{
					return this.AmbientOwner.CustomColor3;
				}
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

		protected Color Color
		{
			get
			{
				if (this.GettingDefault)
				{
					return this.m_Color;
				}
				if (this.m_Color == Color.Empty && this.AmbientOwner != null)
				{
					if (this.ColorAmbientSource == AmbientColorSouce.Color)
					{
						return this.AmbientOwner.Color;
					}
					if (this.ColorAmbientSource == AmbientColorSouce.ForeColor)
					{
						return this.AmbientOwner.ForeColor;
					}
					if (this.ColorAmbientSource == AmbientColorSouce.BackColor)
					{
						return this.AmbientOwner.BackColor;
					}
					if (this.ColorAmbientSource == AmbientColorSouce.CustomColor1)
					{
						return this.AmbientOwner.CustomColor1;
					}
					if (this.ColorAmbientSource == AmbientColorSouce.CustomColor2)
					{
						return this.AmbientOwner.CustomColor2;
					}
					if (this.ColorAmbientSource == AmbientColorSouce.CustomColor3)
					{
						return this.AmbientOwner.CustomColor3;
					}
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

		protected bool FreezePropertyChange
		{
			get
			{
				return this.m_FreezePropertyChange;
			}
			set
			{
				this.m_FreezePropertyChange = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Rectangle Bounds
		{
			get
			{
				return this.m_Bounds;
			}
			set
			{
				if (this.m_Bounds != value)
				{
					this.m_Bounds = value;
					this.OnBoundsChanged(this.m_Bounds);
				}
			}
		}

		protected bool Focused
		{
			get
			{
				if (this.UICollection == null)
				{
					return false;
				}
				return this.UICollection.GetIsFocused(this);
			}
		}

		protected Cursor Cursor
		{
			get
			{
				if (this.UICollection == null)
				{
					return Cursors.Default;
				}
				return this.UICollection.Cursor;
			}
		}

		protected UIInputCollection UICollection
		{
			get
			{
				return this.m_UICollection;
			}
			set
			{
				this.m_UICollection = value;
			}
		}

		protected bool IsMouseDown
		{
			get
			{
				return this.m_IsMouseDown;
			}
			set
			{
				this.m_IsMouseDown = value;
			}
		}

		protected bool IsMouseActive
		{
			get
			{
				return this.m_IsMouseActive;
			}
			set
			{
				this.m_IsMouseActive = value;
			}
		}

		protected bool IsKeyDown
		{
			get
			{
				return this.m_IsKeyDown;
			}
			set
			{
				this.m_IsKeyDown = value;
			}
		}

		protected bool IsKeyActive
		{
			get
			{
				return this.m_IsKeyActive;
			}
			set
			{
				this.m_IsKeyActive = value;
			}
		}

		protected bool IsMouseOrKeyActive
		{
			get
			{
				if (!this.m_IsMouseActive)
				{
					return this.m_IsKeyActive;
				}
				return true;
			}
		}

		protected virtual bool HitTestEnabled => true;

		protected virtual bool CanFocusInternal => true;

		protected SubClassBaseCollection SubClassList => this.m_SubClassList;

		[Browsable(false)]
		public event PropertyChangeEventHandler PropertyChanged;

		[Browsable(false)]
		public event BoundsChangeEventHandler BoundsChanged;

		public event GetMouseCursorEventHandler GetMouseCursor;

		public event MouseEventHandler MouseLeft;

		public event MouseEventHandler MouseRight;

		public event MouseEventHandler MouseMove;

		public event MouseEventHandler MouseUp;

		public event MouseEventHandler Click;

		public event MouseEventHandler DoubleClick;

		public event MouseEventHandler MouseWheel;

		public event KeyEventHandler KeyDown;

		public event KeyEventHandler KeyUp;

		public event KeyPressEventHandler KeyPress;

		public event EventHandler LostFocus;

		public event EventHandler GotFocus;

		string ISupportUITypeEditor.GetPlugInTitle()
		{
			return this.GetPlugInTitle();
		}

		string ISupportUITypeEditor.GetPlugInClassName()
		{
			return this.GetPlugInClassName();
		}

		void ISubClassBase.ResetToDefault()
		{
			this.ResetToDefault();
		}

		void ISubClassBase.ResetClone(ISubClassBase clone)
		{
			this.ResetClone(clone);
		}

		bool ISubClassBase.ShouldSerialize()
		{
			return this.ShouldSerialize();
		}

		bool IUIInput.HitTest(MouseEventArgs e)
		{
			return this.InternalHitTest(e);
		}

		void IUIInput.MouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			this.InternalOnMouseLeft(e, shouldFocus);
			this.OnMouseLeft(e);
		}

		void IUIInput.MouseRight(MouseEventArgs e)
		{
			this.InternalOnMouseRight(e);
			this.OnMouseRight(e);
		}

		void IUIInput.MouseMove(MouseEventArgs e)
		{
			this.InternalOnMouseMove(e);
			this.OnMouseMove(e);
		}

		void IUIInput.MouseUp(MouseEventArgs e)
		{
			this.InternalOnMouseUp(e);
			this.OnMouseUp(e);
		}

		void IUIInput.Click(MouseEventArgs e)
		{
			this.InternalOnClick(e);
			this.OnClick(e);
		}

		void IUIInput.DoubleClick(MouseEventArgs e)
		{
			this.InternalOnDoubleClick(e);
			this.OnDoubleClick(e);
		}

		void IUIInput.MouseWheel(MouseEventArgs e)
		{
			this.InternalOnMouseWheel(e);
			this.OnMouseWheel(e);
		}

		void IUIInput.KeyDown(KeyEventArgs e)
		{
			this.InternalOnKeyDown(e);
			this.OnKeyDown(e);
		}

		void IUIInput.KeyUp(KeyEventArgs e)
		{
			this.InternalOnKeyUp(e);
			this.OnKeyUp(e);
		}

		void IUIInput.KeyPress(KeyPressEventArgs e)
		{
			this.InternalOnKeyPress(e);
			this.OnKeyPress(e);
		}

		void IUIInput.LostFocus(LostFocusEventArgs e)
		{
			this.InternalOnLostFocus(e);
			this.OnLostFocus(e);
		}

		void IUIInput.GotFocus(EventArgs e)
		{
			this.InternalOnGotFocus(e);
			this.OnGotFocus(e);
		}

		Cursor IUIInput.GetMouseCursor(MouseEventArgs e)
		{
			Cursor cursor = this.InternalGetMouseCursor(e);
			if (this.GetMouseCursor != null)
			{
				GetMouseCursorEventArgs getMouseCursorEventArgs = new GetMouseCursorEventArgs(cursor);
				this.GetMouseCursor(this, getMouseCursorEventArgs);
				return getMouseCursorEventArgs.Cursor;
			}
			return cursor;
		}

		private void OnMouseLeft(MouseEventArgs e)
		{
			if (this.MouseLeft != null)
			{
				this.MouseLeft(this, e);
			}
		}

		private void OnMouseRight(MouseEventArgs e)
		{
			if (this.MouseRight != null)
			{
				this.MouseRight(this, e);
			}
		}

		private void OnMouseMove(MouseEventArgs e)
		{
			if (this.MouseMove != null)
			{
				this.MouseMove(this, e);
			}
		}

		private void OnMouseUp(MouseEventArgs e)
		{
			if (this.MouseUp != null)
			{
				this.MouseUp(this, e);
			}
		}

		private void OnClick(MouseEventArgs e)
		{
			if (this.Click != null)
			{
				this.Click(this, e);
			}
		}

		private void OnDoubleClick(MouseEventArgs e)
		{
			if (this.DoubleClick != null)
			{
				this.DoubleClick(this, e);
			}
		}

		private void OnMouseWheel(MouseEventArgs e)
		{
			if (this.MouseWheel != null)
			{
				this.MouseWheel(this, e);
			}
		}

		private void OnKeyDown(KeyEventArgs e)
		{
			if (this.KeyDown != null)
			{
				this.KeyDown(this, e);
			}
		}

		private void OnKeyUp(KeyEventArgs e)
		{
			if (this.KeyUp != null)
			{
				this.KeyUp(this, e);
			}
		}

		private void OnKeyPress(KeyPressEventArgs e)
		{
			if (this.KeyPress != null)
			{
				this.KeyPress(this, e);
			}
		}

		private void OnLostFocus(EventArgs e)
		{
			if (this.LostFocus != null)
			{
				this.LostFocus(this, e);
			}
		}

		private void OnGotFocus(EventArgs e)
		{
			if (this.GotFocus != null)
			{
				this.GotFocus(this, e);
			}
		}

		protected void DoCreate()
		{
			if (!this.m_CreationComplete)
			{
				this.ColorAmbientSource = AmbientColorSouce.Color;
				this.m_Creating = true;
				try
				{
					this.CreateObjects();
				}
				finally
				{
					this.m_Creating = false;
				}
				this.SettingDefaults = true;
				try
				{
					this.SetDefaults();
				}
				finally
				{
					this.SettingDefaults = false;
				}
				this.AfterCreate();
				this.m_CreationComplete = true;
			}
		}

		protected virtual void CreateObjects()
		{
		}

		protected virtual void SetDefaults()
		{
			this.VisibleInternal = true;
			this.EnabledInternal = true;
		}

		protected virtual void AfterCreate()
		{
		}

		protected void AddSubClass(ISubClassBase value)
		{
			if (this.m_SubClassList == null)
			{
				this.m_SubClassList = new SubClassBaseCollection();
			}
			this.m_SubClassList.Add(value);
			value.AmbientOwner = this;
		}

		protected void RemoveSubClass(ISubClassBase value)
		{
			if (this.m_SubClassList == null)
			{
				this.m_SubClassList = new SubClassBaseCollection();
			}
			this.m_SubClassList.Remove(value);
			value.AmbientOwner = null;
		}

		protected void PropertyUpdateDefault(string name, object value)
		{
			bool flag = this.SettingDefaults;
			if (this.Creating)
			{
				flag = true;
			}
			if (this.ComponentBase != null && this.ComponentBase.SettingDefaults)
			{
				flag = true;
			}
			if (flag)
			{
				if (this.m_DefaultArray == null)
				{
					this.m_DefaultArray = new ArrayList();
				}
				foreach (PropertyData item in this.m_DefaultArray)
				{
					if (!(item.Name == name))
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

		protected bool ShouldSerialize()
		{
			bool result = false;
			if (this.m_DefaultArray != null)
			{
				foreach (PropertyData item in this.m_DefaultArray)
				{
					if (this.PropertyShouldSerialize(item.Name))
					{
						result = true;
					}
				}
			}
			if (this.m_SubClassList != null)
			{
				{
					foreach (SubClassBase subClass in this.m_SubClassList)
					{
						if (((ISubClassBase)subClass).ShouldSerialize())
						{
							return true;
						}
					}
					return result;
				}
			}
			return result;
		}

		protected void ResetToDefault()
		{
			if (this.m_DefaultArray != null)
			{
				foreach (PropertyData item in this.m_DefaultArray)
				{
					PropertyInfo property = base.GetType().GetProperty(item.Name);
					if (property != (PropertyInfo)null)
					{
						property.SetValue(this, item.Value, null);
					}
				}
			}
			if (this.m_SubClassList != null)
			{
				foreach (SubClassBase subClass in this.m_SubClassList)
				{
					((ISubClassBase)subClass).ResetToDefault();
				}
			}
			if (this.ComponentBase != null)
			{
				this.ComponentBase.ForceDesignerChange();
			}
		}

		protected void ResetClone(ISubClassBase clone)
		{
			if (this.m_DefaultArray != null)
			{
				foreach (PropertyData item in this.m_DefaultArray)
				{
					PropertyInfo property = clone.GetType().GetProperty(item.Name);
					if (property != (PropertyInfo)null)
					{
						property.SetValue(clone, item.Value, null);
					}
				}
			}
			if (this.m_SubClassList != null)
			{
				for (int i = 0; i < this.m_SubClassList.Count; i++)
				{
					ISubClassBase subClassBase = this.m_SubClassList[i];
					ISubClassBase clone2 = clone.SubClassList[i];
					subClassBase.ResetClone(clone2);
				}
			}
		}

		protected void PropertyReset(string name)
		{
			if (this.m_DefaultArray != null)
			{
				foreach (PropertyData item in this.m_DefaultArray)
				{
					if (!(item.Name == name))
					{
						continue;
					}
					PropertyInfo property = base.GetType().GetProperty(name);
					if (property != (PropertyInfo)null)
					{
						property.SetValue(this, item.Value, null);
					}
					if (this.ComponentBase == null)
					{
						break;
					}
					this.ComponentBase.ForceDesignerChange();
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
					if (item.Name == name)
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
						return !item.Value.Equals(property.GetValue(this, null));
					}
				}
				return false;
			}
			finally
			{
				this.m_GettingDefault = false;
			}
		}

		protected void ThrowStreamingSafeException(string value)
		{
			if (this.ComponentBase != null)
			{
				if (this.ComponentBase.Loading)
				{
					return;
				}
				throw new Exception(value);
			}
			throw new Exception(value);
		}

		protected bool NeedToSquashEvent()
		{
			if (this.FreezePropertyChange)
			{
				return true;
			}
			if (this.ComponentBase != null && this.ComponentBase.Creating)
			{
				return true;
			}
			return false;
		}

		protected void DoAutoSizeSpecialOffset(int specialOffset)
		{
			if (this.ControlBase != null)
			{
				this.ControlBase.DoAutoSizeSpecialOffset(specialOffset);
			}
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
			if (!this.NeedToSquashEvent())
			{
				if (this.ComponentBase != null)
				{
					this.ComponentBase.DoPropertyChange(sender, propertyName);
				}
				if (this.PropertyChanged != null)
				{
					this.OnPropertyChanged(sender, propertyName);
				}
			}
		}

		protected virtual string GetPlugInTitle()
		{
			return Const.EmptyString;
		}

		protected virtual string GetPlugInClassName()
		{
			return Const.EmptyString;
		}

		public void ShowEditorCustom(bool designTimeStyle, bool modal)
		{
			UITypeEditorGeneric uITypeEditorGeneric = (UITypeEditorGeneric)TypeDescriptor.GetEditor(this, typeof(UITypeEditor));
			uITypeEditorGeneric?.EditValue(this, designTimeStyle, modal);
		}

		protected virtual void OnBoundsChanged(Rectangle r)
		{
			if (this.BoundsChanged != null)
			{
				this.BoundsChanged(this, new BoundsEventArgs(r));
			}
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

		public void Focus()
		{
			if (this.CanFocusInternal && this.UICollection != null)
			{
				this.UICollection.SetFocus(this);
			}
		}

		protected virtual bool InternalHitTest(MouseEventArgs e)
		{
			if (!this.HitTestEnabled)
			{
				return false;
			}
			return this.Bounds.Contains(e.X, e.Y);
		}

		protected virtual Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			return Cursors.Default;
		}

		protected virtual void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
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

		protected virtual void InternalOnClick(EventArgs e)
		{
		}

		protected virtual void InternalOnDoubleClick(MouseEventArgs e)
		{
		}

		protected virtual void InternalOnMouseWheel(MouseEventArgs e)
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

		protected virtual void InternalOnLostFocus(LostFocusEventArgs e)
		{
		}

		protected virtual void InternalOnGotFocus(EventArgs e)
		{
		}
	}
}
