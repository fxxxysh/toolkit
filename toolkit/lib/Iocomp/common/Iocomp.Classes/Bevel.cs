using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Controls the border layout properties.")]
	public class Bevel : SubClassBase, IBevel
	{
		private int m_MarginEdge;

		private BevelStyle m_Style;

		private BevelThickness m_Thickness;

		[Description("Specifies the bevel margin.")]
		[RefreshProperties(RefreshProperties.All)]
		public int MarginEdge
		{
			get
			{
				return this.m_MarginEdge;
			}
			set
			{
				base.PropertyUpdateDefault("MarginEdge", value);
				if (this.MarginEdge != value)
				{
					this.m_MarginEdge = value;
					base.DoPropertyChange(this, "MarginEdge");
				}
			}
		}

		[Description("Specifies the style of the bevel.")]
		[RefreshProperties(RefreshProperties.All)]
		public BevelStyle Style
		{
			get
			{
				return this.m_Style;
			}
			set
			{
				base.PropertyUpdateDefault("Style", value);
				if (this.Style != value)
				{
					this.m_Style = value;
					base.DoPropertyChange(this, "Style");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the style of the bevel.")]
		public BevelThickness Thickness
		{
			get
			{
				return this.m_Thickness;
			}
			set
			{
				base.PropertyUpdateDefault("Thickness", value);
				if (this.Thickness != value)
				{
					this.m_Thickness = value;
					base.DoPropertyChange(this, "Thickness");
				}
			}
		}

		[Description("Indicates if the bevel is visible or invisible.")]
		[RefreshProperties(RefreshProperties.All)]
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

		protected virtual int InternalMargin => 0;

		protected override string GetPlugInTitle()
		{
			return "Bevel";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.BevelEditorPlugIn";
		}

		void IBevel.DrawRange(PaintArgs p, Rectangle r, Color backColor, Orientation orientation)
		{
			this.DrawRange(p, r, backColor, orientation);
		}

		void IBevel.Draw(PaintArgs p, Rectangle r, Color backColor, Orientation orientation)
		{
			this.Draw(p, r, backColor, orientation);
		}

		public Bevel()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeMarginEdge()
		{
			return base.PropertyShouldSerialize("MarginEdge");
		}

		private void ResetMarginEdge()
		{
			base.PropertyReset("MarginEdge");
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private bool ShouldSerializeThickness()
		{
			return base.PropertyShouldSerialize("Thickness");
		}

		private void ResetThickness()
		{
			base.PropertyReset("Thickness");
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private int GetThicknessPixels()
		{
			if (this.Thickness == BevelThickness.X2)
			{
				return 2;
			}
			if (this.Thickness == BevelThickness.X3)
			{
				return 3;
			}
			return 4;
		}

		protected void DrawRange(PaintArgs p, Rectangle r, Color backColor, Orientation orientation)
		{
			int num = 1;
			int thicknessPixels = this.GetThicknessPixels();
			int num2 = (r.Height + 1) / (thicknessPixels + 1);
			iRectangle iRectangle = new iRectangle(r);
			for (int i = 0; i < num2; i++)
			{
				this.Draw(p, iRectangle.Rectangle, backColor, orientation);
				iRectangle.Top += thicknessPixels + num;
			}
		}

		protected void Draw(PaintArgs p, Rectangle r, Color backColor, Orientation orientation)
		{
			if (this.Visible && this.Style != 0)
			{
				bool invert = this.Style == BevelStyle.Sunken;
				iColors.FaceColorLight = iColors.Lighten4(backColor);
				iColors.FaceColorDark = iColors.Darken3(backColor);
				iColors.FaceColorFlat = backColor;
				if (orientation == Orientation.Horizontal)
				{
					int num = r.Top + this.InternalMargin;
					if (this.Thickness == BevelThickness.X2)
					{
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Top, p.Rotation, invert)), r.Left + this.MarginEdge, num, r.Right - this.MarginEdge, num);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Bottom, p.Rotation, invert)), r.Left + this.MarginEdge, num + 1, r.Right - this.MarginEdge, num + 1);
					}
					else if (this.Thickness == BevelThickness.X3)
					{
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Top, p.Rotation, invert)), r.Left + this.MarginEdge, num, r.Right - this.MarginEdge, num);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Flat, p.Rotation, invert)), r.Left + this.MarginEdge, num + 1, r.Right - this.MarginEdge, num + 1);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Bottom, p.Rotation, invert)), r.Left + this.MarginEdge, num + 2, r.Right - this.MarginEdge, num + 2);
					}
					else if (this.Thickness == BevelThickness.X4)
					{
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Top, p.Rotation, invert)), r.Left + this.MarginEdge, num, r.Right - this.MarginEdge, num);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Top, p.Rotation, invert)), r.Left + this.MarginEdge, num + 1, r.Right - this.MarginEdge, num + 1);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Bottom, p.Rotation, invert)), r.Left + this.MarginEdge, num + 2, r.Right - this.MarginEdge, num + 2);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Bottom, p.Rotation, invert)), r.Left + this.MarginEdge, num + 3, r.Right - this.MarginEdge, num + 3);
					}
				}
				else
				{
					int num = p.Left + this.InternalMargin;
					if (this.Thickness == BevelThickness.X2)
					{
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Left, p.Rotation, invert)), num, r.Top + this.MarginEdge, num, r.Bottom - this.MarginEdge);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Right, p.Rotation, invert)), num + 1, r.Top + this.MarginEdge, num + 1, r.Bottom - this.MarginEdge);
					}
					else if (this.Thickness == BevelThickness.X3)
					{
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Left, p.Rotation, invert)), num, r.Top + this.MarginEdge, num, r.Bottom - this.MarginEdge);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Flat, p.Rotation, invert)), num + 1, r.Top + this.MarginEdge, num + 1, r.Bottom - this.MarginEdge);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Right, p.Rotation, invert)), num + 2, r.Top + this.MarginEdge, num + 2, r.Bottom - this.MarginEdge);
					}
					else if (this.Thickness == BevelThickness.X4)
					{
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Left, p.Rotation, invert)), num, r.Top + this.MarginEdge, num, r.Bottom - this.MarginEdge);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Left, p.Rotation, invert)), num + 1, r.Top + this.MarginEdge, num + 1, r.Bottom - this.MarginEdge);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Right, p.Rotation, invert)), num + 2, r.Top + this.MarginEdge, num + 2, r.Bottom - this.MarginEdge);
						p.Graphics.DrawLine(p.Graphics.Pen(iColors.ToFaceColor(FaceReference.Right, p.Rotation, invert)), num + 3, r.Top + this.MarginEdge, num + 3, r.Bottom - this.MarginEdge);
					}
				}
			}
		}
	}
}
