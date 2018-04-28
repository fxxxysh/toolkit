using Iocomp.Design.Components;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[Description("PlugIn Editor Color Picker")]
	[DefaultEvent("")]
	[DesignerCategory("code")]
	[ToolboxItem(false)]
	[Designer(typeof(ColorPickerDesigner))]
	public class ColorPicker : Control, IPlugInEditorControl
	{
		private int m_BorderWidth;

		private int m_ButtonWidth;

		private Rectangle m_ButtonRect;

		private bool m_MouseDown;

		private ColorPickerStyle m_Style;

		private PlugInEditorControlPropertyAdapter m_PropertyAdapter;

		private IPlugInStandard m_PlugInForm;

		private object m_UploadSource;

		private Color m_Color;

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

		protected override Size DefaultSize => new Size(141, 21);

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

		[DefaultValue(typeof(Color), "Empty")]
		public Color Color
		{
			get
			{
				return this.m_Color;
			}
			set
			{
				if (this.m_Color != value)
				{
					this.m_Color = value;
					base.Invalidate();
					this.OnColorChanged();
				}
			}
		}

		[DefaultValue(typeof(SystemColors), "Window")]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
			}
		}

		[DefaultValue(ColorPickerStyle.ColorBoxAndText)]
		public ColorPickerStyle Style
		{
			get
			{
				return this.m_Style;
			}
			set
			{
				if (this.m_Style != value)
				{
					this.m_Style = value;
					base.Invalidate();
				}
			}
		}

		public event EventHandler ColorChanged;

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

		public ColorPicker()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.UpdateStyles();
			this.m_Style = ColorPickerStyle.ColorBoxAndText;
			this.m_PropertyAdapter = new PlugInEditorControlPropertyAdapter();
			this.BackColor = SystemColors.Window;
			this.IsValid = true;
			this.ColorChanged += this.ColorPicker_ColorChanged;
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
				this.BackColor = SystemColors.Control;
				base.Enabled = false;
			}
			if (!this.IsValid)
			{
				this.ColorChanged -= this.ColorPicker_ColorChanged;
				this.Color = Color.Empty;
			}
		}

		private void OnColorChanged()
		{
			if (!this.m_BlockEvents && this.ColorChanged != null)
			{
				this.ColorChanged(this, EventArgs.Empty);
			}
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			base.Focus();
			if (this.m_ButtonRect.Contains(e.X, e.Y))
			{
				this.m_MouseDown = true;
			}
			base.Invalidate();
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			if (this.m_MouseDown)
			{
				this.m_MouseDown = false;
				if (this.m_ButtonRect.Contains(e.X, e.Y))
				{
					this.ShowDialog();
				}
				base.Invalidate();
			}
		}

		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			base.OnKeyPress(e);
			if (e.KeyChar == ' ')
			{
				this.ShowDialog();
				e.Handled = true;
			}
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			base.Invalidate();
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			this.m_MouseDown = false;
			base.Invalidate();
		}

		protected void DrawButton(PaintEventArgs e)
		{
			StringFormat genericDefault = StringFormat.GenericDefault;
			genericDefault.LineAlignment = StringAlignment.Center;
			genericDefault.Alignment = StringAlignment.Center;
			this.m_ButtonRect = new Rectangle(base.Width - this.m_BorderWidth - this.m_ButtonWidth, this.m_BorderWidth, this.m_ButtonWidth, base.Height - 2 * this.m_BorderWidth);
			Brush brush = new SolidBrush(SystemColors.Control);
			e.Graphics.FillRectangle(brush, this.m_ButtonRect);
			brush.Dispose();
			brush = ((!base.Enabled) ? new SolidBrush(SystemColors.GrayText) : new SolidBrush(this.ForeColor));
			e.Graphics.DrawString("...", this.Font, brush, this.m_ButtonRect, genericDefault);
			brush.Dispose();
			if (this.m_MouseDown)
			{
				ControlPaint.DrawBorder3D(e.Graphics, this.m_ButtonRect, Border3DStyle.Sunken);
			}
			else
			{
				ControlPaint.DrawBorder3D(e.Graphics, this.m_ButtonRect, Border3DStyle.Raised);
			}
			if (this.Focused)
			{
				Rectangle buttonRect = this.m_ButtonRect;
				buttonRect.Inflate(-2, -2);
				ControlPaint.DrawFocusRectangle(e.Graphics, buttonRect, Color.White, this.BackColor);
			}
		}

		protected void DrawColorBoxAndText(PaintEventArgs e)
		{
			this.m_BorderWidth = 2;
			this.m_ButtonWidth = (int)e.Graphics.MeasureString("....", this.Font).Width + 1;
			int num = base.Height - 2 * this.m_BorderWidth;
			Rectangle rect = new Rectangle(this.m_BorderWidth + 2, 2 * this.m_BorderWidth, 20, num - 2 * this.m_BorderWidth - 1);
			Brush brush = new SolidBrush(this.Color);
			e.Graphics.FillRectangle(brush, rect);
			brush.Dispose();
			if (base.Enabled)
			{
				e.Graphics.DrawRectangle(Pens.Black, rect);
			}
			else
			{
				e.Graphics.DrawRectangle(SystemPens.GrayText, rect);
			}
			this.DrawButton(e);
			int num2 = rect.Right + 2;
			Rectangle r = new Rectangle(num2, this.m_BorderWidth, this.m_ButtonRect.Left - num2, num);
			StringFormat genericDefault = StringFormat.GenericDefault;
			genericDefault.LineAlignment = StringAlignment.Center;
			genericDefault.Alignment = StringAlignment.Near;
			genericDefault.Trimming = StringTrimming.EllipsisCharacter;
			genericDefault.FormatFlags = StringFormatFlags.NoWrap;
			string s = (!(this.Color == Color.Empty)) ? ((!this.Color.IsKnownColor) ? string.Format(CultureInfo.CurrentCulture, "{0}, {1}, {2}", new object[3]
			{
				this.Color.R,
				this.Color.G,
				this.Color.B
			}) : this.Color.ToKnownColor().ToString()) : "Empty (Reset)";
			brush = ((!base.Enabled) ? new SolidBrush(SystemColors.GrayText) : new SolidBrush(this.ForeColor));
			e.Graphics.DrawString(s, this.Font, brush, r, genericDefault);
			brush.Dispose();
			ControlPaint.DrawBorder3D(e.Graphics, base.ClientRectangle, Border3DStyle.Sunken);
			base.OnPaint(e);
		}

		protected void DrawColorBox(PaintEventArgs e)
		{
			this.m_BorderWidth = 0;
			this.m_ButtonWidth = base.Height;
			this.DrawButton(e);
			int height = base.Height;
			Rectangle rect = new Rectangle(0, 0, base.Width - this.m_ButtonRect.Width - 1, base.Height - 1);
			Brush brush = new SolidBrush(this.Color);
			e.Graphics.FillRectangle(brush, rect);
			brush.Dispose();
			if (base.Enabled)
			{
				e.Graphics.DrawRectangle(Pens.Black, rect);
			}
			else
			{
				e.Graphics.DrawRectangle(SystemPens.GrayText, rect);
			}
			base.OnPaint(e);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (this.m_Style == ColorPickerStyle.ColorBoxAndText)
			{
				this.DrawColorBoxAndText(e);
			}
			else
			{
				this.DrawColorBox(e);
			}
			base.OnPaint(e);
		}

		private void ShowDialog()
		{
			Iocomp.Design.Components.ColorDialog colorDialog = new Iocomp.Design.Components.ColorDialog();
			if (colorDialog.ShowDialog(this.Color) == DialogResult.OK)
			{
				this.Color = colorDialog.Color;
			}
			colorDialog.Dispose();
		}

		private void ColorPicker_ColorChanged(object sender, EventArgs e)
		{
			this.DownloadDisplay(this.m_UploadSource);
			if (this.PlugInForm != null)
			{
				this.PlugInForm.ForceDirtyUpdate();
			}
		}

		public void UploadDisplay(object source)
		{
			this.m_UploadSource = source;
			object displayValue = this.PropertyAdapter.GetDisplayValue(source);
			bool flag = displayValue != null && true;
			if (flag)
			{
				if (displayValue is Color)
				{
					this.m_BlockEvents = true;
					this.Color = (Color)displayValue;
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
				if (displayValue != null && displayValue is Color)
				{
					this.PropertyAdapter.SetValue(target, this.Color);
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
			if (displayValue is Color)
			{
				return (Color)displayValue != this.Color;
			}
			return false;
		}
	}
}
