using Iocomp.Classes;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[Designer(typeof(FontButtonDesigner))]
	[DesignerCategory("code")]
	[DefaultEvent("")]
	[ToolboxItem(false)]
	[Description("PlugIn Editor Font Button")]
	public class FontButton : Button, IPlugInEditorControl
	{
		private PlugInEditorControlPropertyAdapter m_PropertyAdapter;

		private IPlugInStandard m_PlugInForm;

		private object m_UploadSource;

		private Font m_Font;

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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new Font Font
		{
			get
			{
				return this.m_Font;
			}
			set
			{
				if (!GPFunctions.Equals(this.Font, value))
				{
					this.m_Font = value;
					this.OnChanged();
				}
			}
		}

		[DefaultValue("Font")]
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

		public event EventHandler Changed;

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

		public FontButton()
		{
			this.Text = "Font";
			this.IsValid = true;
			this.m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			this.Changed += this.FontButton_Changed;
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
				this.Changed -= this.FontButton_Changed;
				this.Font = null;
				this.Text = "Error";
			}
		}

		private void OnChanged()
		{
			if (this.Changed != null)
			{
				this.Changed(this, EventArgs.Empty);
			}
		}

		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
			FontDialog fontDialog = new FontDialog();
			try
			{
				fontDialog.Font = this.Font;
				if (fontDialog.ShowDialog() == DialogResult.OK)
				{
					this.Font = fontDialog.Font;
				}
			}
			finally
			{
				fontDialog.Dispose();
			}
		}

		private void FontButton_Changed(object sender, EventArgs e)
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
				if (displayValue is Font)
				{
					this.m_BlockEvents = true;
					this.Font = (Font)displayValue;
					this.m_BlockEvents = false;
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
				if (displayValue != null && displayValue is Font)
				{
					this.PropertyAdapter.SetValue(target, this.Font);
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
			if (displayValue is Font)
			{
				return !GPFunctions.Equals((Font)displayValue, this.Font);
			}
			return false;
		}
	}
}
