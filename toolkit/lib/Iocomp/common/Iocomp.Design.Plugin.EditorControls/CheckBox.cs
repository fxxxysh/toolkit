using Iocomp.Classes;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[Description("PlugIn Editor CheckBox")]
	[ToolboxItem(false)]
	[DefaultEvent("")]
	[DesignerCategory("code")]
	[Designer(typeof(CheckBoxDesigner))]
	public class CheckBox : System.Windows.Forms.CheckBox, IPlugInEditorControl
	{
		private PlugInEditorControlPropertyAdapter m_PropertyAdapter;

		private IPlugInStandard m_PlugInForm;

		private object m_UploadSource;

		private bool m_IsValid;

		private bool m_ReadOnly;

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

		[ParenthesizePropertyName(true)]
		public new string Text
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

		[DefaultValue("")]
		[ParenthesizePropertyName(true)]
		public string PropertyName
		{
			get
			{
				return this.m_PropertyAdapter.PropertyName;
			}
			set
			{
				if (this.m_PropertyAdapter.PropertyName != value)
				{
					this.m_PropertyAdapter.PropertyName = value;
					if (this.PropertyName != null && this.PropertyName != Const.EmptyString && this.Text == base.Name)
					{
						this.Text = this.PropertyName;
					}
				}
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

		public CheckBox()
		{
			this.IsValid = true;
			this.m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			base.CheckedChanged += this.CheckBox_CheckedChanged;
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
				base.CheckedChanged -= this.CheckBox_CheckedChanged;
				this.Text = "Error";
				base.Checked = false;
			}
		}

		private void CheckBox_CheckedChanged(object sender, EventArgs e)
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
				if (displayValue is ValueBoolean)
				{
					base.Checked = (displayValue as ValueBoolean).AsBoolean;
				}
				else if (displayValue is bool)
				{
					base.Checked = (bool)displayValue;
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
					if (displayValue is ValueBoolean)
					{
						this.PropertyAdapter.SetValue(target, new ValueBoolean(base.Checked));
					}
					else if (displayValue is bool)
					{
						this.PropertyAdapter.SetValue(target, base.Checked);
					}
				}
			}
		}

		private bool GetIsDisplayDirty(object original)
		{
			object displayValue = this.PropertyAdapter.GetDisplayValue(original);
			if (displayValue == null)
			{
				return false;
			}
			if (displayValue is ValueBoolean)
			{
				return (displayValue as ValueBoolean).AsBoolean != base.Checked;
			}
			if (displayValue is bool)
			{
				return (bool)displayValue != base.Checked;
			}
			return false;
		}
	}
}
