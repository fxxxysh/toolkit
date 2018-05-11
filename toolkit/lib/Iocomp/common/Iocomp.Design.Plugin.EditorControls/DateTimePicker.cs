using Iocomp.Classes;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[ToolboxItem(false)]
	[Designer(typeof(DateTimePickerDesigner))]
	[DefaultEvent("")]
	[Description("PlugIn Editor DateTimePicker")]
	[DesignerCategory("code")]
	public class DateTimePicker : System.Windows.Forms.DateTimePicker, IPlugInEditorControl
	{
		private PlugInEditorControlPropertyAdapter m_PropertyAdapter;

		private IPlugInStandard m_PlugInForm;

		private object m_UploadSource;

		private bool m_ReadOnly;

		private bool m_IsValid;

		private bool m_BlockEvents;

		IPlugInStandard IPlugInEditorControl.PlugInForm
		{
			get
			{
				return this.m_PlugInForm;
			}
			set
			{
				this.m_PlugInForm = value;
			}
		}

		bool IPlugInEditorControl.IsReadOnly
		{
			get
			{
				return this.m_ReadOnly;
			}
		}

		bool IPlugInEditorControl.IsValid
		{
			get
			{
				return this.m_IsValid;
			}
		}

		private PlugInEditorControlPropertyAdapter PropertyAdapter => this.m_PropertyAdapter;

		private IPlugInStandard PlugInForm => this.m_PlugInForm;

		private bool IsValid
		{
			get
			{
				return this.m_IsValid;
			}
			set
			{
				this.m_IsValid = value;
				this.ReadOnlyIsValidUpdate();
			}
		}

		[DefaultValue(false)]
		public bool ReadOnly
		{
			get
			{
				return this.m_ReadOnly;
			}
			set
			{
				this.m_ReadOnly = value;
				this.ReadOnlyIsValidUpdate();
			}
		}

		[ParenthesizePropertyName(true)]
		[DefaultValue("")]
		public string PropertyName
		{
			get
			{
				return this.m_PropertyAdapter.PropertyName;
			}
			set
			{
				this.m_PropertyAdapter.PropertyName = value;
			}
		}

		void IPlugInEditorControl.UploadDisplay(object source)
		{
			this.UploadDisplay(source);
		}

		void IPlugInEditorControl.TransferAmbient(object source, object destination)
		{
			this.m_PropertyAdapter.TransferAmbient(source, destination);
		}

		bool IPlugInEditorControl.GetIsDisplayDirty(object original)
		{
			return this.GetIsDisplayDirty(original);
		}

		public DateTimePicker()
		{
			this.m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			this.IsValid = true;
			base.ValueChanged += this.DateTimePicker_ValueChanged;
		}

		private void ReadOnlyIsValidUpdate()
		{
			if (!this.ReadOnly && this.IsValid)
			{
				if (!base.DesignMode)
				{
					base.Enabled = true;
				}
			}
			else if (!base.DesignMode)
			{
				base.Enabled = false;
			}
			if (!this.IsValid)
			{
				base.ValueChanged -= this.DateTimePicker_ValueChanged;
				base.Value = new DateTime(1777, 7, 7, 1, 1, 1, 1);
			}
		}

		private void DateTimePicker_ValueChanged(object sender, EventArgs e)
		{
			if (!this.m_BlockEvents)
			{
				this.DownloadDisplay(this.m_UploadSource);
				if (this.PlugInForm != null)
				{
					this.PlugInForm.ForceDirtyUpdate();
				}
			}
		}

		public void UploadDisplay(object source)
		{
			this.m_UploadSource = source;
			object displayValue = this.PropertyAdapter.GetDisplayValue(source);
			bool flag = displayValue != null && true;
			if (flag)
			{
				this.m_BlockEvents = true;
				if (displayValue is ValueDateTime)
				{
					base.Value = (displayValue as ValueDateTime).AsDateTime;
				}
				else if (displayValue is DateTime)
				{
					base.Value = (DateTime)displayValue;
				}
				else
				{
					flag = false;
				}
				this.m_BlockEvents = false;
			}
			this.IsValid = flag;
		}

		private void DownloadDisplay(object target)
		{
			if (this.IsValid)
			{
				object displayValue = this.PropertyAdapter.GetDisplayValue(target);
				if (displayValue != null)
				{
					if (displayValue is ValueDateTime)
					{
						this.PropertyAdapter.SetValue(target, new ValueDateTime(base.Value));
					}
					else if (displayValue is DateTime)
					{
						this.PropertyAdapter.SetValue(target, base.Value);
					}
				}
			}
		}

		private bool GetIsDisplayDirty(DateTime original)
		{
			if (base.Format != DateTimePickerFormat.Long && base.Format != DateTimePickerFormat.Short)
			{
				if (base.Format == DateTimePickerFormat.Time)
				{
					if (base.Value.Hour == original.Hour && base.Value.Minute == original.Minute)
					{
						return base.Value.Second != original.Second;
					}
					return true;
				}
				return !DateTime.Equals(base.Value, original);
			}
			if (base.Value.Year == original.Year && base.Value.Month == original.Month)
			{
				return base.Value.Day != original.Day;
			}
			return true;
		}

		private bool GetIsDisplayDirty(object original)
		{
			object displayValue = this.PropertyAdapter.GetDisplayValue(original);
			if (displayValue == null)
			{
				return false;
			}
			if (displayValue is ValueDateTime)
			{
				return this.GetIsDisplayDirty((displayValue as ValueDateTime).AsDateTime);
			}
			if (displayValue is DateTime)
			{
				return this.GetIsDisplayDirty((DateTime)displayValue);
			}
			return false;
		}
	}
}
