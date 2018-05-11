using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[Designer(typeof(ComboBoxDesigner))]
	[DesignerCategory("code")]
	[DefaultEvent("")]
	[ToolboxItem(false)]
	[Description("PlugIn Editor ComboBox")]
	public class ComboBox : System.Windows.Forms.ComboBox, IPlugInEditorControl
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

		public ComboBox()
		{
			this.m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			this.IsValid = true;
			base.SelectedIndexChanged += this.ComboBox_SelectedIndexChanged;
		}

		private void ReadOnlyIsValidUpdate()
		{
			if (!this.ReadOnly && this.IsValid)
			{
				if (base.DesignMode)
				{
					this.BackColor = SystemColors.Window;
				}
				else
				{
					base.Enabled = true;
				}
			}
			else if (base.DesignMode)
			{
				this.BackColor = SystemColors.Control;
			}
			else
			{
				base.Enabled = false;
			}
			if (!this.IsValid)
			{
				base.SelectedIndexChanged -= this.ComboBox_SelectedIndexChanged;
				base.Items.Clear();
				base.Items.Add("Error");
				this.SelectedIndex = 0;
			}
		}

		private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
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
				if (this.PropertyAdapter.GetIsEnum(source))
				{
					base.DropDownStyle = ComboBoxStyle.DropDownList;
					if (base.Items.Count == 0)
					{
						this.PropertyAdapter.LoadEnums(source, this);
					}
					this.m_BlockEvents = true;
					this.PropertyAdapter.SetEnumIndex(source, displayValue, this);
					this.m_BlockEvents = false;
				}
				else if (displayValue is string)
				{
					base.DropDownStyle = ComboBoxStyle.DropDown;
					this.Text = (string)displayValue;
				}
				else
				{
					flag = false;
				}
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
					if (this.PropertyAdapter.GetIsEnum(target))
					{
						this.PropertyAdapter.SetValue(target, Enum.Parse(displayValue.GetType(), (string)base.Items[this.SelectedIndex]));
					}
					else if (displayValue is string)
					{
						this.PropertyAdapter.SetValue(target, this.Text);
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
			if (this.PropertyAdapter.GetIsEnum(original))
			{
				return (int)displayValue != this.SelectedIndex;
			}
			if (displayValue is string)
			{
				return (string)displayValue != this.Text;
			}
			return false;
		}
	}
}
