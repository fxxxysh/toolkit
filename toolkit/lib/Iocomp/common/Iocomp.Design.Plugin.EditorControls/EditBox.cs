using Iocomp.Classes;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[Description("PlugIn Editor EditBox")]
	[ToolboxItem(false)]
	[Designer(typeof(EditBoxDesigner))]
	[DesignerCategory("code")]
	[DefaultEvent("")]
	public class EditBox : EditBase, IPlugInEditorControl
	{
		private ValueString m_Value;

		private EditBoxDataStyle m_DataStyle;

		private EditBoxLongFormat m_LongFormat;

		private PlugInEditorControlPropertyAdapter m_PropertyAdapter;

		private IPlugInStandard m_PlugInForm;

		private object m_UploadSource;

		private bool m_IsValid;

		private bool m_SentForceApplyButtonEnabled;

		private bool m_SentForceDirtyUpdate;

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

		private EditBoxDataStyle DataStyle
		{
			get
			{
				return this.m_DataStyle;
			}
			set
			{
				this.m_DataStyle = value;
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

		[DefaultValue(HorizontalAlignment.Left)]
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

		[DefaultValue(false)]
		public new bool WordWrap
		{
			get
			{
				return base.WordWrap;
			}
			set
			{
				base.WordWrap = value;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[DefaultValue(EditBoxLongFormat.Int)]
		public EditBoxLongFormat LongFormat
		{
			get
			{
				return this.m_LongFormat;
			}
			set
			{
				this.m_LongFormat = value;
			}
		}

		protected override Size DefaultSize => new Size(100, 20);

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public string AsString
		{
			get
			{
				return this.Value.AsString;
			}
			set
			{
				this.Value.AsString = value;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int AsInteger
		{
			get
			{
				if (this.Value.AsString.Length == 0)
				{
					return 0;
				}
				return Convert.ToInt32(this.Value.AsString, CultureInfo.CurrentCulture);
			}
			set
			{
				this.Value.AsString = Convert2.ToString(value);
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public long AsLong
		{
			get
			{
				if (this.Value.AsString.Length == 0)
				{
					return 0L;
				}
				if (this.LongFormat == EditBoxLongFormat.Int)
				{
					return Convert.ToInt64(this.Value.AsString, CultureInfo.CurrentCulture);
				}
				if (this.LongFormat == EditBoxLongFormat.Hex)
				{
					return Convert.ToInt64(this.Value.AsString, 16);
				}
				return Convert.ToInt64(this.Value.AsString, 2);
			}
			set
			{
				if (this.LongFormat == EditBoxLongFormat.Int)
				{
					this.Value.AsString = Convert2.ToString(value);
				}
				else if (this.LongFormat == EditBoxLongFormat.Hex)
				{
					this.Value.AsString = Convert2.ToString(value, 16).ToUpper(CultureInfo.CurrentCulture);
				}
				else
				{
					this.Value.AsString = Convert2.ToString(value, 2).ToUpper(CultureInfo.CurrentCulture);
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public double AsDouble
		{
			get
			{
				if (this.Value.AsString.Length == 0)
				{
					return 0.0;
				}
				double num = Convert.ToDouble(this.Value.AsString, CultureInfo.CurrentCulture);
				if (double.IsNaN(num))
				{
					num = 0.0;
				}
				return num;
			}
			set
			{
				this.Value.AsString = Convert2.ToString(value);
			}
		}

		public int Length => this.Value.AsString.Length;

		public ValueString Value => this.m_Value;

		[Category("Iocomp")]
		public event EventHandler Changed;

		[Category("Iocomp")]
		public event EventHandler ForcedUpdate;

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

		public EditBox()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			this.m_Value = new ValueString();
			base.AddSubClass(this.Value);
			this.m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			this.Value.Changed += this.OnValueChanged;
			base.TextChanged += this.EditBox_TextChanged;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.IsValid = true;
			this.TextAlign = HorizontalAlignment.Left;
			this.WordWrap = false;
			this.Value.AsString = "";
		}

		private void ReadOnlyIsValidUpdate()
		{
			if (!this.ReadOnly && this.IsValid)
			{
				if (base.DesignMode)
				{
					base.BackColor = SystemColors.Window;
				}
			}
			else if (base.DesignMode)
			{
				base.BackColor = SystemColors.Control;
			}
			if (!this.IsValid)
			{
				this.Value.Changed -= this.Value_Changed;
				base.TextChanged -= this.EditBox_TextChanged;
				this.Value.AsString = "Error";
			}
		}

		protected override void PropertyChangedHook(object sender, string propertyName)
		{
			if (sender == this.Value)
			{
				this.UpdateText();
			}
			base.PropertyChangedHook(sender, propertyName);
		}

		private void OnChanged()
		{
			if (this.Changed != null)
			{
				this.Changed(this, EventArgs.Empty);
			}
		}

		public void ForceUpdate()
		{
			this.DownloadDisplay(this.m_UploadSource);
			if (this.PlugInForm != null)
			{
				this.PlugInForm.ForceDirtyUpdate();
			}
			if (this.ForcedUpdate != null)
			{
				this.ForcedUpdate(this, EventArgs.Empty);
			}
		}

		protected override void UpdateValue()
		{
			this.Value.AsString = base.Text;
			if (this.m_SentForceApplyButtonEnabled && !this.m_SentForceDirtyUpdate)
			{
				this.ForceUpdate();
			}
			base.SelectAll();
		}

		protected override void UpdateText()
		{
			base.Text = this.Value.AsString;
			base.SelectAll();
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.m_SentForceApplyButtonEnabled = false;
		}

		protected override void InternalOnKeyPress(KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r')
			{
				this.m_SentForceDirtyUpdate = false;
				this.UpdateValue();
				e.Handled = true;
			}
			else if (e.KeyChar == '\u001b')
			{
				this.m_SentForceDirtyUpdate = false;
				this.UpdateText();
				e.Handled = true;
			}
			else if (this.DataStyle != EditBoxDataStyle.Double && this.DataStyle != EditBoxDataStyle.ValueDouble)
			{
				if (this.DataStyle != EditBoxDataStyle.Int && this.DataStyle != EditBoxDataStyle.ValueInteger)
				{
					if (this.DataStyle != EditBoxDataStyle.Long && this.DataStyle != EditBoxDataStyle.ValueLong)
					{
						e.Handled = false;
					}
					else if (this.LongFormat == EditBoxLongFormat.Int)
					{
						if (char.IsNumber(e.KeyChar))
						{
							e.Handled = false;
						}
						else if (e.KeyChar == '-')
						{
							e.Handled = false;
						}
						else if (e.KeyChar == '\b')
						{
							e.Handled = false;
						}
						else if (e.KeyChar == '\u0003')
						{
							e.Handled = false;
						}
						else if (e.KeyChar == '\u0016')
						{
							e.Handled = false;
						}
						else if (e.KeyChar == '\u0018')
						{
							e.Handled = false;
						}
						else if (e.KeyChar == '\u001a')
						{
							e.Handled = false;
						}
						else
						{
							e.Handled = true;
						}
					}
					else if (this.LongFormat == EditBoxLongFormat.Hex)
					{
						if (char.IsNumber(e.KeyChar))
						{
							e.Handled = false;
						}
						else if (char.ToUpper(e.KeyChar) == 'A')
						{
							e.Handled = false;
						}
						else if (char.ToUpper(e.KeyChar) == 'B')
						{
							e.Handled = false;
						}
						else if (char.ToUpper(e.KeyChar) == 'C')
						{
							e.Handled = false;
						}
						else if (char.ToUpper(e.KeyChar) == 'D')
						{
							e.Handled = false;
						}
						else if (char.ToUpper(e.KeyChar) == 'E')
						{
							e.Handled = false;
						}
						else if (char.ToUpper(e.KeyChar) == 'F')
						{
							e.Handled = false;
						}
						else if (char.ToUpper(e.KeyChar) == '\b')
						{
							e.Handled = false;
						}
						else if (e.KeyChar == '\u0003')
						{
							e.Handled = false;
						}
						else if (e.KeyChar == '\u0016')
						{
							e.Handled = false;
						}
						else if (e.KeyChar == '\u0018')
						{
							e.Handled = false;
						}
						else if (e.KeyChar == '\u001a')
						{
							e.Handled = false;
						}
						else
						{
							e.Handled = true;
						}
					}
					else if (e.KeyChar == '0')
					{
						e.Handled = false;
					}
					else if (e.KeyChar == '1')
					{
						e.Handled = false;
					}
					else if (e.KeyChar == '\b')
					{
						e.Handled = false;
					}
					else
					{
						e.Handled = true;
					}
				}
				else if (char.IsNumber(e.KeyChar))
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '-')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\b')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\u0003')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\u0016')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\u0018')
				{
					e.Handled = false;
				}
				else if (e.KeyChar == '\u001a')
				{
					e.Handled = false;
				}
				else
				{
					e.Handled = true;
				}
			}
			else if (char.IsNumber(e.KeyChar))
			{
				e.Handled = false;
			}
			else if (char.ToUpper(e.KeyChar) == 'E')
			{
				e.Handled = false;
			}
			else if (e.KeyChar == '-')
			{
				e.Handled = false;
			}
			else if (e.KeyChar == '\b')
			{
				e.Handled = false;
			}
			else if (e.KeyChar == '.')
			{
				e.Handled = false;
			}
			else if (e.KeyChar == ',')
			{
				e.Handled = false;
			}
			else if (e.KeyChar == '\u0003')
			{
				e.Handled = false;
			}
			else if (e.KeyChar == '\u0016')
			{
				e.Handled = false;
			}
			else if (e.KeyChar == '\u0018')
			{
				e.Handled = false;
			}
			else if (e.KeyChar == '\u001a')
			{
				e.Handled = false;
			}
			else
			{
				e.Handled = true;
			}
		}

		private void OnValueChanged(object sender, ValueStringEventArgs e)
		{
			this.OnChanged();
		}

		private void EditBox_TextChanged(object sender, EventArgs e)
		{
			if (!this.m_BlockEvents)
			{
				if (this.PlugInForm != null)
				{
					this.PlugInForm.ForceApplyButtonEnabled();
				}
				this.m_SentForceApplyButtonEnabled = true;
			}
		}

		private void Value_Changed(object sender, ValueStringEventArgs e)
		{
			if (!this.m_BlockEvents)
			{
				this.ForceUpdate();
				this.m_SentForceDirtyUpdate = true;
			}
		}

		public void UploadDisplay(object source)
		{
			this.m_UploadSource = source;
			object displayValue = this.PropertyAdapter.GetDisplayValue(source);
			bool isValid = true;
			this.DataStyle = EditBoxDataStyle.None;
			if (displayValue == null)
			{
				this.DataStyle = EditBoxDataStyle.String;
			}
			else if (displayValue is int)
			{
				this.DataStyle = EditBoxDataStyle.Int;
			}
			else if (displayValue is long)
			{
				this.DataStyle = EditBoxDataStyle.Long;
			}
			else if (displayValue is double)
			{
				this.DataStyle = EditBoxDataStyle.Double;
			}
			else if (displayValue is string)
			{
				this.DataStyle = EditBoxDataStyle.String;
			}
			else if (displayValue is ValueDouble)
			{
				this.DataStyle = EditBoxDataStyle.ValueDouble;
			}
			else if (displayValue is ValueInteger)
			{
				this.DataStyle = EditBoxDataStyle.ValueInteger;
			}
			else if (displayValue is ValueLong)
			{
				this.DataStyle = EditBoxDataStyle.ValueLong;
			}
			else if (displayValue is ValueString)
			{
				this.DataStyle = EditBoxDataStyle.ValueString;
			}
			else
			{
				isValid = false;
			}
			if (this.DataStyle != 0)
			{
				this.m_BlockEvents = true;
				if (this.DataStyle == EditBoxDataStyle.Int)
				{
					this.AsInteger = (int)displayValue;
				}
				else if (this.DataStyle == EditBoxDataStyle.Long)
				{
					this.AsLong = (long)displayValue;
				}
				else if (this.DataStyle == EditBoxDataStyle.Double)
				{
					this.AsDouble = (double)displayValue;
				}
				else if (this.DataStyle == EditBoxDataStyle.String)
				{
					this.AsString = (string)displayValue;
				}
				else if (this.DataStyle == EditBoxDataStyle.ValueDouble)
				{
					this.AsString = (displayValue as ValueDouble).AsString;
				}
				else if (this.DataStyle == EditBoxDataStyle.ValueInteger)
				{
					this.AsString = (displayValue as ValueInteger).AsString;
				}
				else if (this.DataStyle == EditBoxDataStyle.ValueString)
				{
					this.AsString = (displayValue as ValueString).AsString;
				}
				else if (this.DataStyle == EditBoxDataStyle.ValueLong)
				{
					if (this.LongFormat == EditBoxLongFormat.Int)
					{
						this.AsString = (displayValue as ValueLong).AsString;
					}
					else if (this.LongFormat == EditBoxLongFormat.Hex)
					{
						this.AsString = (displayValue as ValueLong).AsStringHex;
					}
					else
					{
						this.AsString = (displayValue as ValueLong).AsStringBinary;
					}
				}
				this.m_BlockEvents = false;
			}
			this.IsValid = isValid;
		}

		private void DownloadDisplay(object target)
		{
			if (this.IsValid)
			{
				object displayValue = this.PropertyAdapter.GetDisplayValue(target);
				try
				{
					if (displayValue == null && this.AsString != string.Empty)
					{
						this.PropertyAdapter.SetValue(target, this.AsString);
					}
					else if (displayValue is int)
					{
						this.PropertyAdapter.SetValue(target, this.AsInteger);
					}
					else if (displayValue is long)
					{
						this.PropertyAdapter.SetValue(target, this.AsLong);
					}
					else if (displayValue is double)
					{
						this.PropertyAdapter.SetValue(target, this.AsDouble);
					}
					else if (displayValue is string)
					{
						this.PropertyAdapter.SetValue(target, this.AsString);
					}
					else if (displayValue is ValueInteger)
					{
						this.PropertyAdapter.SetValue(target, new ValueInteger(this.AsInteger));
					}
					else if (displayValue is ValueLong)
					{
						this.PropertyAdapter.SetValue(target, new ValueLong(this.AsLong));
					}
					else if (displayValue is ValueDouble)
					{
						this.PropertyAdapter.SetValue(target, new ValueDouble(this.AsDouble));
					}
					else if (displayValue is ValueString)
					{
						this.PropertyAdapter.SetValue(target, new ValueString(this.AsString));
					}
				}
				catch
				{
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
			if (displayValue is string)
			{
				return (string)displayValue != this.AsString;
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
			if (displayValue is ValueString)
			{
				return (displayValue as ValueString).AsString != this.AsString;
			}
			return false;
		}
	}
}
