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
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[DesignerSerializer(typeof(LoadBeginEndSerializerEditBase), typeof(CodeDomSerializer))]
	[Description("Iocomp's ancestor class for all edit controls.")]
	[DesignerCategory("code")]
	[Editor(typeof(UITypeEditorGeneric), typeof(UITypeEditor))]
	[ToolboxItem(false)]
	public abstract class EditBase : TextBox, IAmbientOwner, IPropertyDefaults, ISupportUITypeEditor, IControlBase, IComponentBase
	{
		protected License m_License;

		private ArrayList m_DefaultArray;

		private bool m_GettingDefault;

		private bool m_Loading;

		private bool m_Creating;

		private bool m_SettingDefaults;

		private bool m_UserGenerated;

		private bool m_OPCUpdateActive;

		private bool m_UpdateOnLostFocus;

		private SubClassBaseCollection m_SubClassList;

		private bool m_DefaultReadBack;

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
				return Color.Empty;
			}
		}

		Color IAmbientOwner.CustomColor1
		{
			get
			{
				return Color.Empty;
			}
		}

		Color IAmbientOwner.CustomColor2
		{
			get
			{
				return Color.Empty;
			}
		}

		Color IAmbientOwner.CustomColor3
		{
			get
			{
				return Color.Empty;
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

		bool IControlBase.FreezeAutoSize
		{
			get
			{
				return false;
			}
			set
			{
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

		protected override Size DefaultSize => this.GetDefaultSize();

		[Description("")]
		[DefaultValue(HorizontalAlignment.Center)]
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

		[DefaultValue(HorizontalAlignment.Center)]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public new HorizontalAlignment TextAlign
		{
			get
			{
				return base.TextAlign;
			}
			set
			{
				base.TextAlign = value;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		[RefreshProperties(RefreshProperties.All)]
		[Browsable(false)]
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
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

		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		[RefreshProperties(RefreshProperties.All)]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				if (base.ForeColor != value)
				{
					base.ForeColor = value;
				}
			}
		}

		[Browsable(false)]
		[RefreshProperties(RefreshProperties.All)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				if (base.BackColor != value)
				{
					base.BackColor = value;
				}
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("determines if the value is updated when the control looses focus.")]
		[DefaultValue(true)]
		public bool UpdateOnLostFocus
		{
			get
			{
				return this.m_UpdateOnLostFocus;
			}
			set
			{
				this.PropertyUpdateDefault("UpdateOnLostFocus", value);
				if (this.UpdateOnLostFocus != value)
				{
					this.m_UpdateOnLostFocus = value;
					this.DoPropertyChange(this, "UpdateOnLostFocus");
				}
			}
		}

		[Browsable(false)]
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

		[Browsable(false)]
		public bool Loading
		{
			get
			{
				return this.m_Loading;
			}
		}

		[Browsable(false)]
		public bool Creating
		{
			get
			{
				return this.m_Creating;
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
		public bool Designing
		{
			get
			{
				return base.DesignMode;
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

		void IComponentBase.ForceDesignerChange()
		{
			this.ForceDesignerChange();
		}

		string ISupportUITypeEditor.GetPlugInTitle()
		{
			return this.GetPlugInTitle();
		}

		string ISupportUITypeEditor.GetPlugInClassName()
		{
			return this.GetPlugInClassName();
		}

		void IComponentBase.SetComponentDefaults()
		{
		}

		void IControlBase.DoAutoSize()
		{
			this.DoAutoSize();
		}

		void IControlBase.DoAutoSizeSpecialOffset(int specialOffset)
		{
			this.DoAutoSizeSpecialOffset(specialOffset);
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
				this.TextAlign = HorizontalAlignment.Center;
				base.WordWrap = false;
				this.UpdateOnLostFocus = true;
				this.CreateObjects();
			}
			finally
			{
				this.m_Creating = false;
			}
			this.m_SettingDefaults = true;
			try
			{
				this.SetDefaults();
			}
			finally
			{
				this.m_SettingDefaults = false;
			}
			this.UpdateText();
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

		protected virtual void CreateObjects()
		{
		}

		protected virtual void Loaded()
		{
		}

		protected virtual void SetDefaults()
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

		private void ResetSize()
		{
			this.Size = this.DefaultSize;
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

		private bool ShouldSerializeUpdateOnLostFocus()
		{
			return this.PropertyShouldSerialize("UpdateOnLostFocus");
		}

		private void ResetUpdateOnLostFocus()
		{
			this.PropertyReset("UpdateOnLostFocus");
		}

		protected abstract void UpdateText();

		protected abstract void UpdateValue();

		protected void TextRelatedPropertyChangedHandler(object sender, string propertyName)
		{
			this.UpdateText();
		}

		protected void DoPropertyChange(object sender, string propertyName)
		{
			if (!this.Creating && !this.SettingDefaults)
			{
				this.PropertyChangedHook(sender, propertyName);
			}
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

		protected virtual void PropertyChangedHook(object sender, string propertyName)
		{
		}

		protected void DoAutoSize()
		{
		}

		protected void DoAutoSizeSpecialOffset(int specialOffset)
		{
		}

		protected void ForceDesignerChange()
		{
			IComponentChangeService componentChangeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
			componentChangeService?.OnComponentChanged(this, null, null, null);
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			if (this.UpdateOnLostFocus)
			{
				this.UpdateValue();
			}
		}

		public void LoadingBegin()
		{
			this.m_Loading = true;
		}

		public void LoadingEnd()
		{
			this.m_Loading = false;
			this.Loaded();
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

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			try
			{
				this.m_UserGenerated = true;
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
			try
			{
				this.m_UserGenerated = true;
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
			try
			{
				this.m_UserGenerated = true;
				this.InternalOnKeyPress(e);
			}
			finally
			{
				this.m_UserGenerated = false;
			}
		}

		public void ShowEditorCustom(bool designTimeStyle, bool modal)
		{
			UITypeEditorGeneric uITypeEditorGeneric = (UITypeEditorGeneric)TypeDescriptor.GetEditor(this, typeof(UITypeEditor));
			uITypeEditorGeneric?.EditValue(this, designTimeStyle, modal);
		}

		bool IControlBase.Focus()
		{
			return base.Focus();
		}
	}
}
