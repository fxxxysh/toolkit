using Iocomp.Types;
using System.Drawing;

namespace Iocomp.Classes
{
	public class PaintArgs
	{
		private Color m_ControlBackColor;

		private GraphicsAPI m_Graphics;

		private int m_Left;

		private int m_Top;

		private int m_Width;

		private int m_Height;

		private int m_Right;

		private int m_Bottom;

		private int m_WidthHalf;

		private int m_HeightHalf;

		private Point m_CenterPoint;

		private Rectangle m_Rectangle;

		private Rectangle m_PenRectangle;

		private RotationQuad m_Rotation;

		public GraphicsAPI Graphics => this.m_Graphics;

		public RotationQuad Rotation
		{
			get
			{
				return this.m_Rotation;
			}
			set
			{
				this.m_Rotation = value;
			}
		}

		public Color ControlBackColor => this.m_ControlBackColor;

		public int Left => this.m_Left;

		public int Top => this.m_Top;

		public int Width => this.m_Width;

		public int Height => this.m_Height;

		public Size Size => new Size(this.m_Width, this.m_Height);

		public int Right => this.m_Right;

		public int Bottom => this.m_Bottom;

		public Point CenterPoint => this.m_CenterPoint;

		public int CenterX => this.m_CenterPoint.X;

		public int CenterY => this.m_CenterPoint.Y;

		public Rectangle DrawRectangle
		{
			get
			{
				return this.m_Rectangle;
			}
			set
			{
				this.m_Left = value.Left;
				this.m_Top = value.Top;
				this.m_Width = value.Width;
				this.m_Height = value.Height;
			}
		}

		public Rectangle PenRectangle => this.m_PenRectangle;

		public int WidthHalf => this.m_WidthHalf;

		public int HeightHalf => this.m_HeightHalf;

		public float RotationAngle
		{
			get
			{
				if (this.Rotation == RotationQuad.X000)
				{
					return 0f;
				}
				if (this.Rotation == RotationQuad.X090)
				{
					return 90f;
				}
				if (this.Rotation == RotationQuad.X180)
				{
					return 180f;
				}
				return 270f;
			}
		}

		public PaintArgs(Graphics graphics, Rectangle r, Color color)
		{
			this.m_ControlBackColor = color;
			this.m_Graphics = new GraphicsAPI(graphics);
			this.SetRectangle(r);
		}

		private void SetRectangle(Rectangle r)
		{
			this.m_Rectangle = r;
			this.m_Left = r.Left;
			this.m_Top = r.Top;
			this.m_Width = r.Width;
			this.m_Height = r.Height;
			this.m_Right = this.m_Left + this.m_Width - 1;
			this.m_Bottom = this.m_Top + this.m_Height - 1;
			this.m_CenterPoint = new Point(this.m_Left + this.m_Width / 2, this.m_Top + this.m_Height / 2);
			this.m_PenRectangle = new Rectangle(this.m_Left, this.m_Top, this.m_Width - 1, this.m_Height - 1);
			this.m_WidthHalf = this.m_Width / 2;
			this.m_HeightHalf = this.m_Height / 2;
		}

		public void CleanUp()
		{
			this.m_Graphics.CleanUp();
		}

		public void Rotate(RotationQuad rotation)
		{
			this.m_Rotation = this.Rotation;
			switch (rotation)
			{
			case RotationQuad.X090:
				this.Graphics.TranslateTransform((float)this.CenterX, (float)this.CenterY);
				this.Graphics.RotateTransform(90f);
				this.Graphics.TranslateTransform((float)(-this.CenterY), (float)(-this.CenterX + 1));
				this.SetRectangle(new Rectangle(this.Left, this.Top, this.Height, this.Width));
				break;
			case RotationQuad.X180:
				this.Graphics.TranslateTransform((float)this.CenterX, (float)this.CenterY);
				this.Graphics.RotateTransform(180f);
				this.Graphics.TranslateTransform((float)(-this.CenterX + 1), (float)(-this.CenterY + 1));
				break;
			case RotationQuad.X270:
				this.Graphics.TranslateTransform((float)this.CenterX, (float)this.CenterY);
				this.Graphics.RotateTransform(270f);
				this.Graphics.TranslateTransform((float)(-this.CenterY + 1), (float)(-this.CenterX));
				this.SetRectangle(new Rectangle(this.Left, this.Top, this.Height, this.Width));
				break;
			}
		}
	}
}
