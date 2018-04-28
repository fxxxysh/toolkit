using Iocomp.Delegates;
using Iocomp.Design;
using Iocomp.Interfaces;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing.Design;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Serializable]
	[Description("Iocomp's ancestor class for all components.")]
	[DesignerSerializer(typeof(LoadBeginEndSerializerComponentBase), typeof(CodeDomSerializer))]
	[DesignerCategory("code")]
	[Editor(typeof(UITypeEditorGeneric), typeof(UITypeEditor))]
	public abstract class ComponentBase : Component, IPropertyDefaults, ISupportUITypeEditor, IComponentBase
	{
		private bool m_Loading;

		private bool m_Creating;

		private bool m_SettingDefaults;

		private bool m_AfterCreating;

		private SubClassBaseCollection m_SubClassList;

		private ArrayList m_DefaultArray;

		private Form m_Form;

		private bool m_GettingDefault;

		private bool m_DefaultReadBack;

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

		bool IComponentBase.SettingDefaults
		{
			get
			{
				return this.SettingDefaults;
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

		protected bool SettingDefaults => this.m_SettingDefaults;

		[Browsable(false)]
		public Form Form
		{
			get
			{
				if (this.m_Form != null)
				{
					return this.m_Form;
				}
				return base.Container as Form;
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

		[Browsable(false)]
		public event PropertyChangeEventHandler PropertyChanged;

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
			this.SetComponentDefaults();
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
					foreach (SubClassBase subClass in this.m_SubClassList)
					{
						((ISubClassBase)subClass).SettingDefaults = true;
					}
				}
				this.SetDefaults();
				if (this.m_SubClassList != null)
				{
					foreach (SubClassBase subClass2 in this.m_SubClassList)
					{
						((ISubClassBase)subClass2).SettingDefaults = false;
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

		public void SetForm(Form value)
		{
			this.m_Form = value;
		}

		protected void AddSubClass(ISubClassBase value)
		{
			if (this.m_SubClassList == null)
			{
				this.m_SubClassList = new SubClassBaseCollection();
			}
			this.m_SubClassList.Add(value);
			value.ComponentBase = this;
		}

		protected void ForceDesignerChange()
		{
			IComponentChangeService componentChangeService = (IComponentChangeService)this.GetService(typeof(IComponentChangeService));
			componentChangeService?.OnComponentChanged(this, null, null, null);
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
				if (this.PropertyChanged != null)
				{
					this.OnPropertyChanged(sender, propertyName);
				}
			}
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
	}
}
