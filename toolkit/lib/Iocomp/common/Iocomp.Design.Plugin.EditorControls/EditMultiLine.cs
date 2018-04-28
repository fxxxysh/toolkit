using Iocomp.Classes;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[Description("PlugIn Editor EditMultiLine")]
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	[Designer(typeof(EditMultiLineDesigner))]
	[DefaultEvent("")]
	public class EditMultiLine : Control, IPlugInEditorControl
	{
		private EditBox m_TextBox;

		private Button m_EditButton;

		private Button m_OkButton;

		private Button m_CancelButton;

		private Panel m_Panel;

		private TextBox m_MemoBox;

		private Form m_Form;

		private PlugInEditorControlPropertyAdapter m_PropertyAdapter;

		private IPlugInStandard m_PlugInForm;

		private object m_UploadSource;

		private bool m_ReadOnly;

		private bool m_IsValid;

		private bool m_BlockEvents;

		private Font m_EditFont;

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

		protected override Size DefaultSize => new Size(176, 96);

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

		public Font EditFont
		{
			get
			{
				return this.m_EditFont;
			}
			set
			{
				this.m_EditFont = value;
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

		[Browsable(true)]
		public override string Text
		{
			get
			{
				return this.m_TextBox.AsString;
			}
			set
			{
				this.m_TextBox.AsString = value;
			}
		}

		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string AsString
		{
			get
			{
				return this.m_TextBox.AsString;
			}
			set
			{
				this.m_TextBox.AsString = value;
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

		public EditMultiLine()
		{
			this.m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			this.m_EditButton = new Button();
			this.m_EditButton.Location = new Point(100, 0);
			this.m_EditButton.Name = "EditButton";
			this.m_EditButton.Size = new Size(22, 20);
			this.m_EditButton.TabIndex = 1;
			this.m_EditButton.Text = "...";
			this.m_TextBox = new EditBox();
			this.m_TextBox.Location = new Point(0, 0);
			this.m_TextBox.Name = "TextBox";
			this.m_TextBox.TabIndex = 0;
			base.Controls.Add(this.m_EditButton);
			base.Controls.Add(this.m_TextBox);
			base.Resize += this.EditMultiLine_Resize;
			this.m_EditButton.Click += this.EditButton_Click;
			this.m_TextBox.Changed += this.m_TextBox_Changed;
			this.m_TextBox.ForcedUpdate += this.m_TextBox_ForcedUpdate;
			this.m_TextBox.TextChanged += this.m_TextBox_TextChanged;
			this.IsValid = true;
			base.TabStop = false;
			this.EditMultiLine_Resize(this, null);
		}

		private void ReadOnlyIsValidUpdate()
		{
			if (!this.ReadOnly && this.IsValid)
			{
				if (base.DesignMode)
				{
					this.m_TextBox.BackColor = SystemColors.Window;
				}
				else
				{
					base.Enabled = true;
					this.m_TextBox.Enabled = true;
					this.m_EditButton.Enabled = true;
				}
			}
			else if (base.DesignMode)
			{
				this.m_TextBox.BackColor = SystemColors.Control;
			}
			else
			{
				base.Enabled = false;
				this.m_TextBox.Enabled = false;
				this.m_EditButton.Enabled = false;
			}
			if (!this.IsValid)
			{
				this.m_TextBox.ForcedUpdate -= this.m_TextBox_ForcedUpdate;
				this.m_TextBox.TextChanged -= this.m_TextBox_TextChanged;
				this.m_TextBox.AsString = "Error";
			}
		}

		private void OnChanged()
		{
			if (this.Changed != null)
			{
				this.Changed(this, EventArgs.Empty);
			}
		}

		private void EditMultiLine_Resize(object sender, EventArgs e)
		{
			this.m_EditButton.Dock = DockStyle.Right;
			this.m_TextBox.Dock = DockStyle.Fill;
			base.Height = this.m_TextBox.Height;
		}

		private void TextBox_Resize(object sender, EventArgs e)
		{
			this.m_EditButton.Width = (int)((double)this.m_TextBox.Height * 1.1);
			base.Height = this.m_TextBox.Height;
		}

		private void EditButton_Click(object sender, EventArgs e)
		{
			this.m_Form = new Form();
			try
			{
				this.m_Form.FormBorderStyle = FormBorderStyle.Sizable;
				this.m_Form.MinimizeBox = false;
				this.m_Form.MaximizeBox = false;
				this.m_Form.Text = "Lines Editor";
				this.m_Form.Icon = null;
				this.m_Form.StartPosition = FormStartPosition.CenterScreen;
				this.m_Form.ShowInTaskbar = false;
				this.m_Form.ClientSize = new Size((int)(this.Font.GetHeight() * 20f + 45f), (int)(this.Font.GetHeight() * 15f + 45f));
				this.m_Form.MinimumSize = new Size(200, 150);
				this.m_Form.SizeGripStyle = SizeGripStyle.Show;
				this.m_Panel = new Panel();
				this.m_Panel.Height = 45;
				this.m_Panel.Dock = DockStyle.Bottom;
				this.m_MemoBox = new TextBox();
				this.m_MemoBox.ScrollBars = ScrollBars.Both;
				this.m_MemoBox.Multiline = true;
				this.m_MemoBox.WordWrap = false;
				this.m_MemoBox.Lines = this.m_TextBox.Lines;
				this.m_MemoBox.Font = this.EditFont;
				this.m_OkButton = new Button();
				this.m_OkButton.DialogResult = DialogResult.OK;
				this.m_OkButton.Text = "OK";
				this.m_OkButton.Width = 75;
				this.m_OkButton.Height = 27;
				this.m_CancelButton = new Button();
				this.m_CancelButton.DialogResult = DialogResult.Cancel;
				this.m_CancelButton.Text = "Cancel";
				this.m_CancelButton.Width = 75;
				this.m_CancelButton.Height = 27;
				this.m_Panel.Controls.Add(this.m_OkButton);
				this.m_Panel.Controls.Add(this.m_CancelButton);
				this.m_Form.Controls.Add(this.m_Panel);
				this.m_Form.Controls.Add(this.m_MemoBox);
				this.m_Form.Resize += this.m_Form_Resize;
				this.m_Form_Resize(this, e);
				if (this.m_Form.ShowDialog() == DialogResult.OK)
				{
					this.AsString = this.m_MemoBox.Text;
					if (!this.m_BlockEvents)
					{
						this.DownloadDisplay(this.m_UploadSource);
						if (this.PlugInForm != null)
						{
							this.PlugInForm.ForceApplyButtonEnabled();
						}
					}
				}
			}
			finally
			{
				this.m_Form.Dispose();
			}
		}

		private void m_Form_Resize(object sender, EventArgs e)
		{
			this.m_CancelButton.Location = new Point(this.m_Panel.Right - this.m_CancelButton.Width - 10, this.m_Panel.Height / 2 - this.m_CancelButton.Height / 2);
			this.m_OkButton.Location = new Point(this.m_CancelButton.Left - this.m_OkButton.Width - 5, this.m_Panel.Height / 2 - this.m_OkButton.Height / 2);
			this.m_MemoBox.Height = this.m_Form.ClientSize.Height - this.m_Panel.Height;
			this.m_MemoBox.Width = this.m_Form.ClientSize.Width;
		}

		private void m_TextBox_Changed(object sender, EventArgs e)
		{
			this.OnChanged();
		}

		private void m_TextBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.m_BlockEvents && this.PlugInForm != null)
			{
				this.PlugInForm.ForceApplyButtonEnabled();
			}
		}

		private void m_TextBox_ForcedUpdate(object sender, EventArgs e)
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
			bool isValid = true;
			this.m_BlockEvents = true;
			if (displayValue == null)
			{
				this.m_TextBox.AsString = "";
			}
			else if (displayValue is ValueString)
			{
				this.m_TextBox.AsString = (displayValue as ValueString).AsString;
			}
			else if (displayValue is string)
			{
				this.m_TextBox.AsString = (string)displayValue;
			}
			else
			{
				isValid = false;
			}
			this.m_BlockEvents = false;
			this.IsValid = isValid;
		}

		private void DownloadDisplay(object target)
		{
			if (this.IsValid)
			{
				object displayValue = this.PropertyAdapter.GetDisplayValue(target);
				if (displayValue == null && this.AsString != string.Empty)
				{
					this.PropertyAdapter.SetValue(target, this.AsString);
				}
				else if (displayValue is ValueString)
				{
					this.PropertyAdapter.SetValue(target, new ValueString(this.AsString));
				}
				else if (displayValue is string)
				{
					this.PropertyAdapter.SetValue(target, this.AsString);
				}
			}
		}

		private bool GetIsDisplayDirty(object original)
		{
			object displayValue = this.PropertyAdapter.GetDisplayValue(original);
			if (displayValue == null)
			{
				return this.AsString != string.Empty;
			}
			if (displayValue is ValueString)
			{
				return (displayValue as ValueString).AsString != this.AsString;
			}
			if (displayValue is string)
			{
				return (string)displayValue != this.AsString;
			}
			return false;
		}
	}
}
