using Iocomp.Classes;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[ToolboxItem(false)]
	[DesignerCategory("code")]
	[Description("PlugIn Editor NumericUpDown")]
	[DefaultEvent("")]
	[Designer(typeof(NumericUpDownDesigner))]
	public class NumericUpDown : System.Windows.Forms.NumericUpDown, IPlugInEditorControl
	{
		private PlugInEditorControlPropertyAdapter m_PropertyAdapter;

		private IPlugInStandard m_PlugInForm;

		private object m_UploadSource;

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
				return this.ReadOnly;
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
		public new bool ReadOnly
		{
			get
			{
				return base.ReadOnly;
			}
			set
			{
				base.ReadOnly = value;
				this.ReadOnlyIsValidUpdate();
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string AsString
		{
			get
			{
				return Convert2.ToString(base.Value);
			}
			set
			{
				this.Text = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int AsInteger
		{
			get
			{
				return Convert.ToInt32(base.Value, CultureInfo.CurrentCulture);
			}
			set
			{
				this.Text = Convert.ToString(value, CultureInfo.CurrentCulture);
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public long AsLong
		{
			get
			{
				return Convert.ToInt64(base.Value, CultureInfo.CurrentCulture);
			}
			set
			{
				this.Text = Convert.ToString(value, CultureInfo.CurrentCulture);
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double AsDouble
		{
			get
			{
				return Convert.ToDouble(base.Value, CultureInfo.CurrentCulture);
			}
			set
			{
				this.Text = Convert.ToString(value, CultureInfo.CurrentCulture);
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

		public NumericUpDown()
		{
			this.m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			(base.Controls[1] as TextBox).AcceptsReturn = true;
			(base.Controls[1] as TextBox).WordWrap = true;
			base.Leave += this.NumericUpDown_Leave;
			(base.Controls[1] as TextBox).KeyPress += this.NumericUpDown_KeyPress;
			this.IsValid = true;
			base.ValueChanged += this.NumericUpDown_ValueChanged;
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
				base.ValueChanged -= this.NumericUpDown_ValueChanged;
				base.Value = 0m;
			}
		}

		private void NumericUpDown_ValueChanged(object sender, EventArgs e)
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

		private void NumericUpDown_Leave(object sender, EventArgs e)
		{
			if (this.GetIsDisplayDirty(this.m_UploadSource))
			{
				this.NumericUpDown_ValueChanged(null, null);
			}
		}

		private void NumericUpDown_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				e.Handled = true;
				(base.Controls[1] as TextBox).SelectAll();
				if (this.GetIsDisplayDirty(this.m_UploadSource))
				{
					this.NumericUpDown_ValueChanged(null, null);
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
				if (displayValue is int)
				{
					this.AsInteger = (int)displayValue;
				}
				else if (displayValue is long)
				{
					this.AsLong = (long)displayValue;
				}
				else if (displayValue is double)
				{
					this.AsDouble = (double)displayValue;
				}
				else if (displayValue is ValueInteger)
				{
					this.AsInteger = (displayValue as ValueInteger).AsInteger;
				}
				else if (displayValue is ValueLong)
				{
					this.AsLong = (displayValue as ValueInteger).AsLong;
				}
				else if (displayValue is ValueDouble)
				{
					this.AsDouble = (displayValue as ValueDouble).AsDouble;
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
					if (displayValue is int)
					{
						this.PropertyAdapter.SetValue(target, (int)base.Value);
					}
					else if (displayValue is long)
					{
						this.PropertyAdapter.SetValue(target, (long)base.Value);
					}
					else if (displayValue is double)
					{
						this.PropertyAdapter.SetValue(target, (double)base.Value);
					}
					else if (displayValue is ValueInteger)
					{
						this.PropertyAdapter.SetValue(target, new ValueInteger((int)base.Value));
					}
					else if (displayValue is ValueLong)
					{
						this.PropertyAdapter.SetValue(target, new ValueLong((long)base.Value));
					}
					else if (displayValue is ValueDouble)
					{
						this.PropertyAdapter.SetValue(target, new ValueDouble((double)base.Value));
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
			if (displayValue is int)
			{
				return (int)displayValue != this.AsInteger;
			}
			if (displayValue is long)
			{
				return (long)displayValue != this.AsLong;
			}
			if (displayValue is double)
			{
				return (double)displayValue != this.AsDouble;
			}
			if (displayValue is ValueInteger)
			{
				return (displayValue as ValueInteger).AsInteger != this.AsInteger;
			}
			if (displayValue is ValueLong)
			{
				return (displayValue as ValueLong).AsLong != this.AsLong;
			}
			if (displayValue is ValueDouble)
			{
				return (displayValue as ValueDouble).AsDouble != this.AsDouble;
			}
			return false;
		}
	}
}
