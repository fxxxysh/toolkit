using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Label Basic")]
	public class PlotLabelBasic : PlotLabelBase
	{
		private int m_LengthPixels;

		private int m_MarginOuterPixels;

		protected override string GetPlugInTitle()
		{
			return "Label Basic";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLabelBasicEditorPlugIn";
		}

		public PlotLabelBasic()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.CanFocus = false;
			base.NameShort = "Basic";
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (shouldFocus)
			{
				base.Focus();
			}
		}

		protected override void CalculateDepthPixels(PaintArgs p)
		{
			this.m_MarginOuterPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(base.Font).Height * base.MarginOuter);
			Image image = base.GetImage();
			if (image == null)
			{
				Size size = (!base.TextHorizontal) ? ((ITextLayoutBase)base.TextLayout).GetRequiredSize(base.Text, base.Font, base.Bounds.Height - 2 * this.m_MarginOuterPixels, p.Graphics) : ((ITextLayoutBase)base.TextLayout).GetRequiredSize(base.Text, base.Font, base.Bounds.Width - 2 * this.m_MarginOuterPixels, p.Graphics);
				if (!((!base.DockVertical) ? base.TextHorizontal : (!base.TextHorizontal)))
				{
					base.DockDepthPixels = size.Height + 2 * this.m_MarginOuterPixels;
					this.m_LengthPixels = size.Width + 2 * this.m_MarginOuterPixels;
				}
				else
				{
					base.DockDepthPixels = size.Width + 2 * this.m_MarginOuterPixels;
					this.m_LengthPixels = size.Height + 2 * this.m_MarginOuterPixels;
				}
			}
			else if (base.DockVertical)
			{
				base.DockDepthPixels = image.Height + 2 * this.m_MarginOuterPixels;
				this.m_LengthPixels = image.Width + 2 * this.m_MarginOuterPixels;
			}
			else
			{
				base.DockDepthPixels = image.Width + 2 * this.m_MarginOuterPixels;
				this.m_LengthPixels = image.Height + 2 * this.m_MarginOuterPixels;
			}
		}

		protected override void DrawCalculations(PaintArgs p)
		{
			base.CalculateBoundsAlignment(this.m_LengthPixels);
		}

		protected override void Draw(PaintArgs p)
		{
			base.I_Fill.Draw(p, base.BoundsAlignment);
			Image image = base.GetImage();
			Rectangle r;
			if (image == null)
			{
				r = ((ITextLayoutBase)base.TextLayout).GetRectangle(base.BoundsAlignment, base.Font, p.Graphics);
				r.Inflate(-this.m_MarginOuterPixels, -this.m_MarginOuterPixels);
				p.Graphics.DrawRotatedText(base.Text, base.Font, base.ForeColor, r, base.ActualTextRotation, ((ITextLayoutBase)base.TextLayout).StringFormat);
			}
			else
			{
				Point point = new Point(base.BoundsAlignment.Left + this.m_MarginOuterPixels, base.BoundsAlignment.Top + this.m_MarginOuterPixels);
				r = new Rectangle(point.X, point.Y, image.Width, image.Height);
				if (base.ImageTransparent)
				{
					p.Graphics.DrawImageTransparent(image, r);
				}
				else
				{
					p.Graphics.DrawImage(image, point.X, point.Y);
				}
			}
		}

		protected override void DrawFocusRectangles(PaintArgs p)
		{
			if (base.Focused)
			{
				p.Graphics.DrawFocusRectangle(base.Bounds, base.BackColor);
			}
		}
	}
}
