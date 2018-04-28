using Iocomp.Delegates;
using Iocomp.Design;
using Iocomp.Interfaces;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;

namespace Iocomp.Classes
{
	[Editor(typeof(UITypeEditorGeneric), typeof(UITypeEditor))]
	public abstract class CollectionBase : System.Collections.CollectionBase, IAmbientOwner, ISupportUITypeEditor, ICollectionBase
	{
		private bool m_AllowEdit;

		private IComponentBase m_ComponentBase;

		private IAmbientOwner I_AmbientOwner;

		bool ICollectionBase.AllowEdit
		{
			get
			{
				return this.AllowEdit;
			}
		}

		IComponentBase ICollectionBase.ComponentBase
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

		Font IAmbientOwner.Font
		{
			get
			{
				if (this.I_AmbientOwner != null)
				{
					return this.I_AmbientOwner.Font;
				}
				return null;
			}
		}

		Color IAmbientOwner.ForeColor
		{
			get
			{
				if (this.I_AmbientOwner != null)
				{
					return this.I_AmbientOwner.ForeColor;
				}
				return Color.Empty;
			}
		}

		Color IAmbientOwner.BackColor
		{
			get
			{
				if (this.I_AmbientOwner != null)
				{
					return this.I_AmbientOwner.BackColor;
				}
				return Color.Empty;
			}
		}

		Color IAmbientOwner.Color
		{
			get
			{
				if (this.I_AmbientOwner != null)
				{
					return this.I_AmbientOwner.Color;
				}
				return Color.Empty;
			}
		}

		Color IAmbientOwner.CustomColor1
		{
			get
			{
				if (this.I_AmbientOwner != null)
				{
					return this.I_AmbientOwner.CustomColor1;
				}
				return Color.Empty;
			}
		}

		Color IAmbientOwner.CustomColor2
		{
			get
			{
				if (this.I_AmbientOwner != null)
				{
					return this.I_AmbientOwner.CustomColor2;
				}
				return Color.Empty;
			}
		}

		Color IAmbientOwner.CustomColor3
		{
			get
			{
				if (this.I_AmbientOwner != null)
				{
					return this.I_AmbientOwner.CustomColor3;
				}
				return Color.Empty;
			}
		}

		protected bool AllowEdit
		{
			get
			{
				return this.m_AllowEdit;
			}
			set
			{
				this.m_AllowEdit = value;
			}
		}

		public int LastIndex => base.Count - 1;

		protected IComponentBase ComponentBase
		{
			get
			{
				return this.m_ComponentBase;
			}
			set
			{
				this.m_ComponentBase = value;
				this.I_AmbientOwner = (value as IAmbientOwner);
				foreach (ISubClassBase item in this)
				{
					if (item != null)
					{
						item.ComponentBase = this.ComponentBase;
						item.ControlBase = (this.ComponentBase as IControlBase);
					}
				}
			}
		}

		[Browsable(false)]
		public event EventHandler Changed;

		[Browsable(false)]
		public event AddRemoveObjectEventHandler ObjectAdded;

		[Browsable(false)]
		public event AddRemoveObjectEventHandler ObjectRemoved;

		object ICollectionBase.CreateInstance(Type type)
		{
			return this.CreateInstance(type);
		}

		string ISupportUITypeEditor.GetPlugInTitle()
		{
			return this.GetPlugInTitle();
		}

		string ISupportUITypeEditor.GetPlugInClassName()
		{
			return this.GetPlugInClassName();
		}

		protected object CreateInstance(Type type)
		{
			object obj = GPFunctions.CreateInstance(type, type.FullName);
			base.List.Add(obj);
			return obj;
		}

		protected CollectionBase(IComponentBase componentBase)
		{
			this.ComponentBase = componentBase;
			this.AllowEdit = true;
		}

		public void Remove(int index)
		{
			base.List.RemoveAt(index);
		}

		protected virtual string GetPlugInTitle()
		{
			return Const.EmptyString;
		}

		protected virtual string GetPlugInClassName()
		{
			return Const.EmptyString;
		}

		protected virtual void SetupObjectBeforeAmbientControlBaseConnection(object value)
		{
		}

		public void ShowEditorCustom(bool designTimeStyle, bool modal)
		{
			UITypeEditorGeneric uITypeEditorGeneric = (UITypeEditorGeneric)TypeDescriptor.GetEditor(this, typeof(UITypeEditor));
			uITypeEditorGeneric?.EditValue(this, designTimeStyle, modal);
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

		protected override void OnInsertComplete(int index, object value)
		{
			base.OnInsertComplete(index, value);
			this.SetupObjectBeforeAmbientControlBaseConnection(value);
			this.OnObjectAdded(value);
			this.OnChanged();
		}

		protected override void OnRemoveComplete(int index, object value)
		{
			base.OnRemoveComplete(index, value);
			this.OnObjectRemoved(value);
			this.OnChanged();
		}

		protected override void OnSetComplete(int index, object oldValue, object newValue)
		{
			base.OnSetComplete(index, oldValue, newValue);
			this.OnObjectRemoved(oldValue);
			this.OnObjectAdded(newValue);
			this.OnChanged();
		}

		protected override void OnClear()
		{
			while (base.Count > 0)
			{
				base.RemoveAt(0);
			}
			this.OnChanged();
		}

		public virtual void Reset()
		{
			base.Clear();
		}

		protected virtual void OnChanged()
		{
			if (this.ComponentBase != null)
			{
				this.ComponentBase.DoPropertyChange(this, "Changed");
			}
			if (this.Changed != null)
			{
				this.Changed(this, EventArgs.Empty);
			}
		}

		protected virtual void OnObjectAdded(object value)
		{
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).ComponentBase = this.ComponentBase;
			}
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).ControlBase = (this.ComponentBase as IControlBase);
			}
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).AmbientOwner = this;
			}
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).Collection = this;
			}
			if (this.ComponentBase != null)
			{
				this.ComponentBase.DoPropertyChange(this, "Add");
			}
			if (this.ObjectAdded != null)
			{
				this.ObjectAdded(this, new ObjectEventArgs(value));
			}
		}

		protected virtual void OnObjectRemoved(object value)
		{
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).ComponentBase = null;
			}
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).ControlBase = null;
			}
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).AmbientOwner = null;
			}
			if (value is ISubClassBase)
			{
				(value as ISubClassBase).Collection = null;
			}
			if (this.ComponentBase != null)
			{
				this.ComponentBase.DoPropertyChange(this, "Remove");
			}
			if (this.ObjectRemoved != null)
			{
				this.ObjectRemoved(this, new ObjectEventArgs(value));
			}
		}
	}
}
