using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public abstract class SubControlBase : SubClassBase, ISubControlBase
	{
		private int m_Left;

		private int m_Top;

		private int m_Width;

		private int m_Height;

		private BorderControl m_Border;

		private string m_Text;

		public int Left
		{
			get
			{
				return this.m_Left;
			}
			set
			{
				this.m_Left = value;
				base.DoPropertyChange(this, "Left");
			}
		}

		public int Top
		{
			get
			{
				return this.m_Top;
			}
			set
			{
				this.m_Top = value;
				base.DoPropertyChange(this, "Top");
			}
		}

		public int Width
		{
			get
			{
				return this.m_Width;
			}
			set
			{
				this.m_Width = value;
				base.DoPropertyChange(this, "Width");
			}
		}

		public int Height
		{
			get
			{
				return this.m_Height;
			}
			set
			{
				this.m_Height = value;
				base.DoPropertyChange(this, "Height");
			}
		}

		public int Right => this.m_Left + this.m_Width - 1;

		public int Bottom => this.m_Top + this.m_Height - 1;

		public int CenterX => this.m_Left + this.m_Width / 2;

		public int CenterY => this.m_Top + this.m_Height / 2;

		public new Rectangle Bounds
		{
			get
			{
				return new Rectangle(this.m_Left, this.m_Top, this.m_Width, this.m_Height);
			}
			set
			{
				this.m_Left = value.Left;
				this.m_Top = value.Top;
				this.m_Width = value.Width;
				this.m_Height = value.Height;
				base.DoPropertyChange(this, "Bounds");
			}
		}

		public Rectangle ClientRectangle => new Rectangle(0, 0, this.m_Width, this.m_Height);

		public Rectangle InnerRectangle => new Rectangle(0, 0, this.m_Width - 2 * this.Border.Offset, this.m_Height - 2 * this.Border.Offset);

		[Description("")]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public BorderControl Border
		{
			get
			{
				return this.m_Border;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public bool Visible
		{
			get
			{
				return this.VisibleInternal;
			}
			set
			{
				this.VisibleInternal = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool Enabled
		{
			get
			{
				return base.EnabledInternal;
			}
			set
			{
				base.EnabledInternal = value;
			}
		}

		public new bool Focused => base.Focused;

		public new Cursor Cursor => base.Cursor;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string Text
		{
			get
			{
				return this.m_Text;
			}
			set
			{
				base.PropertyUpdateDefault("Text", value);
				if (this.Text != value)
				{
					this.m_Text = value;
					base.DoPropertyChange(this, "Text");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public new Color BackColor
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public new Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		void ISubControlBase.OnPaint(PaintArgs p)
		{
			this.OnPaint(p);
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Border = new BorderControl();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Visible = true;
			this.Enabled = true;
		}

		private bool ShouldSerializeBorder()
		{
			return ((ISubClassBase)this.Border).ShouldSerialize();
		}

		private void ResetBorder()
		{
			((ISubClassBase)this.Border).ResetToDefault();
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeEnabled()
		{
			return base.PropertyShouldSerialize("Enabled");
		}

		private void ResetEnabled()
		{
			base.PropertyReset("Enabled");
		}

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeBackColor()
		{
			return base.PropertyShouldSerialize("BackColor");
		}

		private void ResetBackColor()
		{
			base.PropertyReset("BackColor");
		}

		private bool ShouldSerializeFont()
		{
			return base.PropertyShouldSerialize("Font");
		}

		private void ResetFont()
		{
			base.PropertyReset("Font");
		}

		private bool ShouldSerializeForeColor()
		{
			return base.PropertyShouldSerialize("ForeColor");
		}

		private void ResetForeColor()
		{
			base.PropertyReset("ForeColor");
		}

		protected override bool InternalHitTest(MouseEventArgs e)
		{
			return this.Bounds.Contains(e.X, e.Y);
		}

		private void OnPaint(PaintArgs p)
		{
			if (this.Visible)
			{
				GraphicsState gstate = p.Graphics.Save();
				Rectangle drawRectangle = p.DrawRectangle;
				p.Graphics.SetClip(this.Bounds);
				p.Graphics.FillRectangle(p.Graphics.Brush(this.BackColor), this.Bounds);
				p.Graphics.TranslateTransform((float)(this.Left + this.Border.Offset), (float)(this.Top + this.Border.Offset));
				p.DrawRectangle = this.InnerRectangle;
				this.DoPaint(p);
				p.Rotation = RotationQuad.X000;
				p.Graphics.TranslateTransform((float)(-this.Border.Offset), (float)(-this.Border.Offset));
				((IBorderControl)this.Border).Draw(p, this.ClientRectangle);
				p.Graphics.Restore(gstate);
				p.DrawRectangle = drawRectangle;
				p.Graphics.ResetClip();
			}
		}

		protected abstract void DoPaint(PaintArgs p);
	}
}
