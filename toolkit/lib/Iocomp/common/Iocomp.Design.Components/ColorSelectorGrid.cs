using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design.Components
{
	[Designer(typeof(ColorSelectorGridDesigner))]
	[DefaultEvent("")]
	[Description("Color Selector Grid")]
	[ToolboxItem(false)]
	[DesignerCategory("code")]
	public class ColorSelectorGrid : Control
	{
		private Color m_Color;

		private int m_ColorFocusIndex;

		private bool m_MouseDown;

		private Color[] m_ColorArray = new Color[64]
		{
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 192, 192),
			Color.FromArgb(255, 224, 192),
			Color.FromArgb(255, 255, 192),
			Color.FromArgb(192, 255, 192),
			Color.FromArgb(192, 255, 255),
			Color.FromArgb(192, 192, 255),
			Color.FromArgb(255, 192, 255),
			Color.FromArgb(224, 224, 224),
			Color.FromArgb(255, 128, 128),
			Color.FromArgb(255, 192, 128),
			Color.FromArgb(255, 255, 128),
			Color.FromArgb(128, 255, 128),
			Color.FromArgb(128, 255, 255),
			Color.FromArgb(128, 128, 255),
			Color.FromArgb(255, 128, 255),
			Color.FromArgb(192, 192, 192),
			Color.FromArgb(255, 0, 0),
			Color.FromArgb(255, 128, 0),
			Color.FromArgb(255, 255, 0),
			Color.FromArgb(0, 255, 0),
			Color.FromArgb(0, 255, 255),
			Color.FromArgb(0, 0, 255),
			Color.FromArgb(255, 0, 255),
			Color.FromArgb(128, 128, 128),
			Color.FromArgb(192, 0, 0),
			Color.FromArgb(192, 64, 0),
			Color.FromArgb(192, 192, 0),
			Color.FromArgb(0, 192, 0),
			Color.FromArgb(0, 192, 192),
			Color.FromArgb(0, 0, 192),
			Color.FromArgb(192, 0, 192),
			Color.FromArgb(64, 64, 64),
			Color.FromArgb(128, 0, 0),
			Color.FromArgb(128, 64, 0),
			Color.FromArgb(128, 128, 0),
			Color.FromArgb(0, 128, 0),
			Color.FromArgb(0, 128, 128),
			Color.FromArgb(0, 0, 128),
			Color.FromArgb(128, 0, 128),
			Color.FromArgb(0, 0, 0),
			Color.FromArgb(64, 0, 0),
			Color.FromArgb(128, 64, 64),
			Color.FromArgb(64, 64, 0),
			Color.FromArgb(0, 64, 0),
			Color.FromArgb(0, 64, 64),
			Color.FromArgb(0, 0, 64),
			Color.FromArgb(64, 0, 64),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255),
			Color.FromArgb(255, 255, 255)
		};

		protected override Size DefaultSize => new Size(194, 198);

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
					this.m_ColorFocusIndex = this.GetColorBoxIndex(this.m_Color);
					base.Invalidate();
					this.OnColorChanged();
				}
			}
		}

		public event EventHandler ColorChanged;

		public event EventHandler ColorChangedDoubleClick;

		public ColorSelectorGrid()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
			base.UpdateStyles();
			this.m_ColorFocusIndex = -1;
		}

		private int GetColorBoxIndex(Color color)
		{
			int num = 0;
			while (true)
			{
				if (num < this.m_ColorArray.Length)
				{
					if (color.ToArgb() != this.m_ColorArray[num].ToArgb())
					{
						num++;
						continue;
					}
					break;
				}
				return -1;
			}
			return num;
		}

		private int GetColorBoxIndex(int x, int y)
		{
			int num = 0;
			while (true)
			{
				if (num < this.m_ColorArray.Length)
				{
					if (this.GetColorBoxRect(num).Contains(x, y))
					{
						break;
					}
					num++;
					continue;
				}
				return -1;
			}
			return num;
		}

		private Rectangle GetColorBoxRect(int index)
		{
			int num = (int)(index / 8L);
			int num2 = (int)(index % 8L);
			return new Rectangle(3 + num2 * 24, 5 + num * 24, 21, 21);
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			base.Focus();
			this.m_MouseDown = true;
			int colorBoxIndex = this.GetColorBoxIndex(e.X, e.Y);
			if (colorBoxIndex != -1)
			{
				this.m_ColorFocusIndex = colorBoxIndex;
				base.Invalidate();
			}
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (this.m_MouseDown)
			{
				int colorBoxIndex = this.GetColorBoxIndex(e.X, e.Y);
				if (colorBoxIndex != -1)
				{
					this.m_ColorFocusIndex = colorBoxIndex;
					base.Invalidate();
				}
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);
			this.m_MouseDown = false;
			int colorBoxIndex = this.GetColorBoxIndex(e.X, e.Y);
			if (colorBoxIndex != -1 && this.m_ColorFocusIndex == colorBoxIndex)
			{
				this.Color = this.m_ColorArray[colorBoxIndex];
			}
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			base.OnDoubleClick(e);
			Point point = base.PointToClient(Control.MousePosition);
			int colorBoxIndex = this.GetColorBoxIndex(point.X, point.Y);
			if (colorBoxIndex != -1)
			{
				this.OnColorChangedDoubleClick();
			}
		}

		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			this.m_MouseDown = false;
		}

		private void OnColorChanged()
		{
			if (this.ColorChanged != null)
			{
				this.ColorChanged(this, EventArgs.Empty);
			}
		}

		private void OnColorChangedDoubleClick()
		{
			if (this.ColorChangedDoubleClick != null)
			{
				this.ColorChangedDoubleClick(this, EventArgs.Empty);
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			for (int i = 0; i < this.m_ColorArray.Length; i++)
			{
				Rectangle colorBoxRect = this.GetColorBoxRect(i);
				Brush brush = new SolidBrush(this.m_ColorArray[i]);
				e.Graphics.FillRectangle(brush, colorBoxRect);
				brush.Dispose();
				ControlPaint.DrawBorder3D(e.Graphics, colorBoxRect, Border3DStyle.Sunken);
				if (i == this.m_ColorFocusIndex)
				{
					colorBoxRect.Inflate(1, 2);
					ControlPaint.DrawFocusRectangle(e.Graphics, colorBoxRect, Color.White, this.BackColor);
				}
			}
			base.OnPaint(e);
		}
	}
}
