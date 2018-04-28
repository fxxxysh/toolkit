using Iocomp.Classes;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Plugin.EditorControls
{
	[DesignerCategory("code")]
	[DefaultEvent("")]
	[Designer(typeof(FocusLabelDesigner))]
	[ToolboxItem(false)]
	[Description("PlugIn Editor Focus Label")]
	public class FocusLabel : DesignControlBase
	{
		private TextLayoutFull m_TextLayout;

		private Control m_FocusControl;

		private int m_NewLocationX;

		private int m_NewLocationY;

		private string m_Text;

		private AlignmentQuadSide m_FocusControlAlignment;

		private bool m_RecursionBlock;

		protected override Size DefaultSize => new Size(100, 23);

		[Description("")]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TextLayoutFull TextLayout
		{
			get
			{
				return this.m_TextLayout;
			}
		}

		[Description("")]
		[TypeConverter(typeof(FocusControlConverter))]
		[ParenthesizePropertyName(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Category("Iocomp")]
		[DefaultValue(null)]
		[RefreshProperties(RefreshProperties.All)]
		public Control FocusControl
		{
			get
			{
				return this.m_FocusControl;
			}
			set
			{
				if (this.m_FocusControl != value)
				{
					if (this.m_FocusControl != null)
					{
						this.m_FocusControl.LocationChanged -= this.m_FocusControl_LocationChanged;
						this.m_FocusControl.SizeChanged -= this.m_FocusControl_LocationChanged;
					}
					this.m_FocusControl = value;
					if (this.FocusControl != null)
					{
						this.m_FocusControl.LocationChanged += this.m_FocusControl_LocationChanged;
						this.m_FocusControl.SizeChanged += this.m_FocusControl_LocationChanged;
						this.Align();
					}
				}
				base.UIInvalidate(this);
			}
		}

		[Category("Iocomp")]
		[ParenthesizePropertyName(true)]
		[Description("Specifies the text for the label.")]
		[RefreshProperties(RefreshProperties.All)]
		public new string Text
		{
			get
			{
				return this.m_Text;
			}
			set
			{
				value = value.Replace(":", "");
				base.PropertyUpdateDefault("Text", value);
				if (this.m_Text != value)
				{
					this.m_Text = value;
					base.DoPropertyChange(this, "Text");
					this.OnTextChanged(EventArgs.Empty);
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the side of the FocusControl that the label will align to.")]
		public AlignmentQuadSide FocusControlAlignment
		{
			get
			{
				return this.m_FocusControlAlignment;
			}
			set
			{
				base.PropertyUpdateDefault("FocusControlAlignment", value);
				if (this.m_FocusControlAlignment != value)
				{
					this.m_FocusControlAlignment = value;
					this.Align();
					base.DoPropertyChange(this, "FocusControlAlignment");
				}
			}
		}

		public FocusLabel()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			this.m_TextLayout = new TextLayoutFull();
			base.AddSubClass(this.TextLayout);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.FocusControl = null;
			}
			base.Dispose(disposing);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.Rotation = RotationQuad.X000;
			this.Text = "";
			base.AutoSize = true;
			this.FocusControlAlignment = AlignmentQuadSide.Left;
			base.TabStop = false;
			this.TextLayout.Trimming = StringTrimming.None;
			this.TextLayout.LineLimit = false;
			this.TextLayout.MeasureTrailingSpaces = false;
			this.TextLayout.NoWrap = false;
			this.TextLayout.NoClip = false;
			this.TextLayout.AlignmentHorizontal.Style = StringAlignment.Far;
			this.TextLayout.AlignmentHorizontal.Margin = 0.5;
			this.TextLayout.AlignmentVertical.Style = StringAlignment.Center;
			this.TextLayout.AlignmentVertical.Margin = 0.5;
		}

		public override void LoadingEnd()
		{
			base.LoadingEnd();
			this.Align();
		}

		protected override Size CalculateAutoSize(int innerWidth, int innerHeight)
		{
			Graphics graphics = base.CreateGraphics();
			Size requiredSize = ((ITextLayoutBase)this.TextLayout).GetRequiredSize(this.Text, base.Font, new GraphicsAPI(graphics));
			graphics.Dispose();
			return new Size(requiredSize.Width, requiredSize.Height);
		}

		protected override void PropertyChangedHook(object sender, string propertyName)
		{
			if (sender == this && propertyName == "Text")
			{
				base.DoAutoSize();
			}
			base.PropertyChangedHook(sender, propertyName);
		}

		protected override Point CalculateAutoSizeLocation(Size NewSize)
		{
			int x = (this.TextLayout.AlignmentHorizontal.Style != 0) ? ((this.TextLayout.AlignmentHorizontal.Style != StringAlignment.Center) ? (base.Location.X + base.Size.Width - NewSize.Width) : (base.Location.X + base.Size.Width / 2 - NewSize.Width / 2)) : base.Location.X;
			int y = (this.TextLayout.AlignmentVertical.Style != 0) ? ((this.TextLayout.AlignmentVertical.Style != StringAlignment.Center) ? (base.Location.Y + base.Size.Height - NewSize.Height) : (base.Location.Y + base.Size.Height / 2 - NewSize.Height / 2)) : base.Location.Y;
			return new Point(x, y);
		}

		private bool ShouldSerializeTextLayout()
		{
			return ((ISubClassBase)this.TextLayout).ShouldSerialize();
		}

		private void ResetTextLayout()
		{
			((ISubClassBase)this.TextLayout).ResetToDefault();
		}

		public bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		public new void ResetText()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeFocusControlAlignment()
		{
			return base.PropertyShouldSerialize("FocusControlAlignment");
		}

		private void ResetFocusControlAlignment()
		{
			base.PropertyReset("FocusControlAlignment");
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e)
		{
			if (this.FocusControl != null)
			{
				this.FocusControl.Focus();
			}
		}

		public void Align()
		{
			if (this.FocusControlAlignment == AlignmentQuadSide.Left)
			{
				this.AlignLeft();
			}
			else if (this.FocusControlAlignment == AlignmentQuadSide.Top)
			{
				this.AlignTop();
			}
			else if (this.FocusControlAlignment == AlignmentQuadSide.Right)
			{
				this.AlignRight();
			}
			else
			{
				this.AlignBottom();
			}
		}

		public void AlignLeft()
		{
			if (this.FocusControl != null)
			{
				this.m_FocusControlAlignment = AlignmentQuadSide.Left;
				int num = 0;
				if (this.FocusControl is TextBox)
				{
					num = -1;
				}
				if (this.FocusControl is ComboBox)
				{
					num = -1;
				}
				if (this.FocusControl is NumericUpDown)
				{
					num = -2;
				}
				this.m_NewLocationX = this.FocusControl.Location.X - base.Width;
				this.m_NewLocationY = this.FocusControl.Location.Y + this.FocusControl.Height / 2 - base.Height / 2 + num;
				base.Location = new Point(this.m_NewLocationX, this.m_NewLocationY);
			}
		}

		public void AlignRight()
		{
			if (this.FocusControl != null)
			{
				this.m_FocusControlAlignment = AlignmentQuadSide.Right;
				int num = 0;
				if (this.FocusControl is TextBox)
				{
					num = -1;
				}
				if (this.FocusControl is ComboBox)
				{
					num = -1;
				}
				if (this.FocusControl is NumericUpDown)
				{
					num = -2;
				}
				this.m_NewLocationX = this.FocusControl.Location.X + this.FocusControl.Width;
				this.m_NewLocationY = this.FocusControl.Location.Y + this.FocusControl.Height / 2 - base.Height / 2 + num;
				base.Location = new Point(this.m_NewLocationX, this.m_NewLocationY);
			}
		}

		public void AlignTop()
		{
			if (this.FocusControl != null)
			{
				this.m_FocusControlAlignment = AlignmentQuadSide.Top;
				this.m_NewLocationX = this.FocusControl.Location.X;
				this.m_NewLocationY = this.FocusControl.Top - base.Height;
				base.Location = new Point(this.m_NewLocationX, this.m_NewLocationY);
			}
		}

		public void AlignBottom()
		{
			if (this.FocusControl != null)
			{
				this.m_FocusControlAlignment = AlignmentQuadSide.Bottom;
				this.m_NewLocationX = this.FocusControl.Location.X;
				this.m_NewLocationY = this.FocusControl.Bottom;
				base.Location = new Point(this.m_NewLocationX, this.m_NewLocationY);
			}
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			if (!this.m_RecursionBlock)
			{
				this.m_RecursionBlock = true;
				try
				{
					base.OnSizeChanged(e);
					this.Align();
				}
				finally
				{
					this.m_RecursionBlock = false;
				}
			}
		}

		protected override void OnLocationChanged(EventArgs e)
		{
			if (!this.m_RecursionBlock)
			{
				this.m_RecursionBlock = true;
				try
				{
					base.OnLocationChanged(e);
					this.Align();
				}
				finally
				{
					this.m_RecursionBlock = false;
				}
			}
		}

		private void m_FocusControl_LocationChanged(object sender, EventArgs e)
		{
			this.Align();
		}

		protected override void DoPaint(PaintArgs p)
		{
			((ITextLayoutBase)this.TextLayout).Draw(p.Graphics, base.Font, p.Graphics.Brush(base.ForeColor), this.Text, p.DrawRectangle);
		}
	}
}
