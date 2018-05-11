using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Contains the horizontal and vertical layout properties for text.")]
	public class TextLayoutBase : SubClassBase, ITextLayoutBase
	{
		private AlignmentText m_AlignmentVertical;

		private AlignmentText m_AlignmentHorizontal;

		DrawStringFormat ITextLayoutBase.StringFormat
		{
			get
			{
				return this.StringFormat;
			}
		}

		[Description("")]
		[ParenthesizePropertyName(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[RefreshProperties(RefreshProperties.All)]
		public AlignmentText AlignmentVertical
		{
			get
			{
				return this.m_AlignmentVertical;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[ParenthesizePropertyName(true)]
		public AlignmentText AlignmentHorizontal
		{
			get
			{
				return this.m_AlignmentHorizontal;
			}
		}

		protected virtual DrawStringFormat StringFormat
		{
			get
			{
				DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
				genericTypographic.Alignment = this.AlignmentHorizontal.Style;
				genericTypographic.LineAlignment = this.AlignmentVertical.Style;
				return genericTypographic;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Text Layout";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.TextLayoutBaseEditorPlugIn";
		}

		void ITextLayoutBase.Draw(GraphicsAPI graphics, Font font, Brush brush, string s, Rectangle r)
		{
			this.Draw(graphics, font, brush, s, r);
		}

		Size ITextLayoutBase.GetRequiredSize(string s, Font font, GraphicsAPI graphics)
		{
			return this.GetRequiredSize(s, font, graphics);
		}

		Size ITextLayoutBase.GetRequiredSize(string s, Font font, int width, GraphicsAPI graphics)
		{
			return this.GetRequiredSize(s, font, width, graphics);
		}

		Rectangle ITextLayoutBase.GetRectangle(Rectangle bounds, Font font, GraphicsAPI graphics)
		{
			return this.GetRectangle(bounds, font, graphics);
		}

		Rectangle ITextLayoutBase.GetRectangle(string s, Point pt, Font font, GraphicsAPI graphics)
		{
			return this.GetRectangle(s, pt, font, graphics);
		}

		Point ITextLayoutBase.GetMarginsAlignment(Font font, GraphicsAPI graphics)
		{
			return this.GetMarginsAlignment(font, graphics);
		}

		public TextLayoutBase()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_AlignmentVertical = new AlignmentText();
			base.AddSubClass(this.AlignmentVertical);
			this.m_AlignmentHorizontal = new AlignmentText();
			base.AddSubClass(this.AlignmentHorizontal);
		}

		private bool ShouldSerializeAlignmentVertical()
		{
			return ((ISubClassBase)this.AlignmentVertical).ShouldSerialize();
		}

		private void ResetAlignmentVertical()
		{
			((ISubClassBase)this.AlignmentVertical).ResetToDefault();
		}

		private bool ShouldSerializeAlignmentHorizontal()
		{
			return ((ISubClassBase)this.AlignmentHorizontal).ShouldSerialize();
		}

		private void ResetAlignmentHorizontal()
		{
			((ISubClassBase)this.AlignmentHorizontal).ResetToDefault();
		}

		protected Point GetMarginsAlignment(Font font, GraphicsAPI graphics)
		{
			Size size = graphics.MeasureString("0", font, true);
			int x = (this.AlignmentHorizontal.Style != StringAlignment.Center) ? ((int)Math.Ceiling((double)size.Width * this.AlignmentHorizontal.Margin)) : 0;
			int y = (this.AlignmentVertical.Style != StringAlignment.Center) ? ((int)Math.Ceiling((double)size.Height * this.AlignmentVertical.Margin)) : 0;
			return new Point(x, y);
		}

		protected Size GetRequiredSize(string s, Font font, GraphicsAPI graphics)
		{
			Point marginsAlignment = this.GetMarginsAlignment(font, graphics);
			Size size = graphics.MeasureString(s, font, true);
			return new Size(size.Width + marginsAlignment.X + 1, size.Height + marginsAlignment.Y + 1);
		}

		protected virtual Size GetRequiredSize(string s, Font font, int width, GraphicsAPI graphics)
		{
			Point marginsAlignment = this.GetMarginsAlignment(font, graphics);
			Size size = graphics.MeasureString(s, font, true, width);
			return new Size(size.Width + marginsAlignment.X + 1, size.Height + marginsAlignment.Y + 1);
		}

		protected Rectangle GetRectangle(Rectangle bounds, Font font, GraphicsAPI graphics)
		{
			int num = bounds.Left;
			int num2 = bounds.Top;
			int num3 = bounds.Right;
			int num4 = bounds.Bottom;
			Point marginsAlignment = this.GetMarginsAlignment(font, graphics);
			if (this.AlignmentHorizontal.Style == StringAlignment.Near)
			{
				num += marginsAlignment.X;
			}
			else if (this.AlignmentHorizontal.Style == StringAlignment.Far)
			{
				num3 -= marginsAlignment.X;
			}
			if (this.AlignmentVertical.Style == StringAlignment.Near)
			{
				num2 += marginsAlignment.Y;
			}
			else if (this.AlignmentVertical.Style == StringAlignment.Far)
			{
				num4 -= marginsAlignment.Y;
			}
			return iRectangle.FromLTRB(num, num2, num3, num4);
		}

		protected Rectangle GetRectangle(string s, Point pt, Font font, GraphicsAPI graphics)
		{
			Point marginsAlignment = this.GetMarginsAlignment(font, graphics);
			Size size = graphics.MeasureString(s, font, true);
			size = new Size(size.Width + 1, size.Height + 1);
			int left = (this.AlignmentHorizontal.Style != 0) ? ((this.AlignmentHorizontal.Style != StringAlignment.Far) ? (pt.X - size.Width / 2) : (pt.X + marginsAlignment.X)) : (pt.X - marginsAlignment.X - size.Width);
			int top = (this.AlignmentVertical.Style != 0) ? ((this.AlignmentVertical.Style != StringAlignment.Far) ? (pt.Y - size.Height / 2) : (pt.Y + marginsAlignment.Y)) : (pt.Y - marginsAlignment.Y - size.Height);
			return iRectangle.FromLTWH(left, top, size.Width, size.Height);
		}

		protected void Draw(GraphicsAPI graphics, Font font, Brush brush, string s, Rectangle r)
		{
			Point marginsAlignment = this.GetMarginsAlignment(font, graphics);
			if (this.AlignmentHorizontal.Style == StringAlignment.Near)
			{
				r.Offset(marginsAlignment.X, 0);
			}
			else if (this.AlignmentHorizontal.Style == StringAlignment.Far)
			{
				r.Offset(-marginsAlignment.X, 0);
			}
			if (this.AlignmentVertical.Style == StringAlignment.Near)
			{
				r.Offset(0, marginsAlignment.Y);
			}
			else if (this.AlignmentVertical.Style == StringAlignment.Far)
			{
				r.Offset(0, -marginsAlignment.Y);
			}
			graphics.DrawString(s, font, brush, r, this.StringFormat);
		}
	}
}
