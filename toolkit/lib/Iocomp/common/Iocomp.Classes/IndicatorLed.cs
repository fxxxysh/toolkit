using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Contains the properties that control the appearance for the indicator.")]
	public class IndicatorLed : IndicatorText, IIndicatorLed
	{
		private ShapeBasic m_Style;

		private IndicatorStyleLED3D m_Style3D;

		private BevelThick m_Bezel;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Bezel properties")]
		public BevelThick Bezel
		{
			get
			{
				return this.m_Bezel;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the indicator bezel style.")]
		public ShapeBasic Style
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

		[Description("Specifies the indicator bezel style.")]
		[RefreshProperties(RefreshProperties.All)]
		public IndicatorStyleLED3D Style3D
		{
			get
			{
				return this.m_Style3D;
			}
			set
			{
				base.PropertyUpdateDefault("Style3D", value);
				if (this.Style3D != value)
				{
					this.m_Style3D = value;
					base.DoPropertyChange(this, "Style3D");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Indicator";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.IndicatorLedEditorPlugIn";
		}

		void IIndicatorLed.Draw(PaintArgs p, Rectangle r, bool value)
		{
			this.Draw(p, r, value);
		}

		void IIndicatorLed.Draw(PaintArgs p, Rectangle r, bool value, Color color, string s, Color textColorActive, Color textColorInactive)
		{
			this.Draw(p, r, value, color, s, textColorActive, textColorInactive);
		}

		public IndicatorLed()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Bezel = new BevelThick();
			base.AddSubClass(this.m_Bezel);
		}

		private bool ShouldSerializeBezel()
		{
			return ((ISubClassBase)this.Bezel).ShouldSerialize();
		}

		private void ResetBezel()
		{
			((ISubClassBase)this.Bezel).ResetToDefault();
		}

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private bool ShouldSerializeStyle3D()
		{
			return base.PropertyShouldSerialize("Style3D");
		}

		private void ResetStyle3D()
		{
			base.PropertyReset("Style3D");
		}

		private void DrawLedRectangle(PaintArgs p, Rectangle r, Color color)
		{
			p.Graphics.FillRectangle(p.Graphics.Brush(color), r);
		}

		private void DrawLedDiamond(PaintArgs p, Rectangle r, Color color)
		{
			Point[] array = new Point[4];
			int x = (r.Left + r.Right) / 2;
			int y = (r.Top + r.Bottom) / 2;
			array[0] = new Point(r.Left, y);
			array[1] = new Point(x, r.Top);
			array[2] = new Point(r.Right, y);
			array[3] = new Point(x, r.Bottom);
			p.Graphics.FillPolygon(p.Graphics.Brush(color), array);
		}

		private void DrawLedEllipse(PaintArgs p, Rectangle r, Color color)
		{
			p.Graphics.FillEllipse(p.Graphics.Brush(color), r);
			p.Graphics.DrawEllipse(p.Graphics.Pen(color, 2f), r);
		}

		private void DrawLedRectangle3D(PaintArgs p, Rectangle r, IndicatorStyleLED3D style3D, bool active, Color color)
		{
			this.DrawLedRectangle(p, r, color);
			switch (style3D)
			{
			case IndicatorStyleLED3D.Auto:
				BorderSpecial.DrawRectangle(p, r, BevelStyle.Raised, p.Width / 10, this.Bezel.Color);
				break;
			case IndicatorStyleLED3D.Thin:
				BorderSpecial.DrawRectangle(p, r, BevelStyle.Raised, 2, this.Bezel.Color);
				break;
			}
		}

		private void DrawLedDiamond3D(PaintArgs p, Rectangle r, IndicatorStyleLED3D style3D, bool active, Color color)
		{
			this.DrawLedDiamond(p, r, color);
			switch (style3D)
			{
			case IndicatorStyleLED3D.Auto:
				BorderSpecial.DrawDiamond(p, r, BevelStyle.Raised, p.Width / 10, this.Bezel.Color);
				break;
			case IndicatorStyleLED3D.Thin:
				BorderSpecial.DrawDiamond(p, r, BevelStyle.Raised, 2, this.Bezel.Color);
				break;
			}
		}

		private void DrawLedEllipse3D(PaintArgs p, Rectangle r, IndicatorStyleLED3D style3D, bool active, Color color)
		{
			r.Inflate(-1, -1);
			r.Width--;
			r.Height--;
			if (style3D == IndicatorStyleLED3D.None)
			{
				this.DrawLedEllipse(p, r, color);
			}
			else
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddEllipse(r);
				PathGradientBrush pathGradientBrush = new PathGradientBrush(graphicsPath);
				if (p.Rotation == RotationQuad.X000)
				{
					pathGradientBrush.CenterPoint = new PointF((float)(r.Left + r.Width / 3), (float)(r.Top + r.Height / 3));
				}
				else if (p.Rotation == RotationQuad.X090)
				{
					pathGradientBrush.CenterPoint = new PointF((float)(r.Left + r.Width / 3), (float)(r.Bottom - r.Height / 3));
				}
				else if (p.Rotation == RotationQuad.X180)
				{
					pathGradientBrush.CenterPoint = new PointF((float)(r.Right - r.Width / 3), (float)(r.Bottom - r.Height / 3));
				}
				else
				{
					pathGradientBrush.CenterPoint = new PointF((float)(r.Right - r.Width / 3), (float)(r.Top + r.Height / 3));
				}
				if (active)
				{
					pathGradientBrush.CenterColor = Color.White;
				}
				else
				{
					pathGradientBrush.CenterColor = Color.Silver;
				}
				pathGradientBrush.SurroundColors = new Color[1]
				{
					color
				};
				p.Graphics.FillPath(pathGradientBrush, graphicsPath);
				pathGradientBrush.Dispose();
				graphicsPath.Dispose();
				p.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				p.Graphics.DrawEllipse(p.Graphics.Pen(color, 2f), r);
				p.Graphics.SmoothingMode = SmoothingMode.None;
			}
		}

		protected void Draw(PaintArgs p, Rectangle r, bool value)
		{
			this.Draw(p, r, value, base.GetStateColor(value), base.Text, base.TextColorActive, base.TextColorInactive);
		}

		protected void Draw(PaintArgs p, Rectangle r, bool value, Color color, string s, Color textColorActive, Color textColorInactive)
		{
			base.Bounds = Rectangle.Empty;
			base.Bounds = r;
			p.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			((IBevelThick)this.Bezel).Draw(p, r, this.Style, this.Bezel.Color);
			r.Inflate(-this.Bezel.ActualThickness, -this.Bezel.ActualThickness);
			if (this.Style == ShapeBasic.Rectangle)
			{
				this.DrawLedRectangle3D(p, r, this.Style3D, value, color);
			}
			else if (this.Style == ShapeBasic.Ellipse)
			{
				this.DrawLedEllipse3D(p, r, this.Style3D, value, color);
			}
			else if (this.Style == ShapeBasic.Diamond)
			{
				this.DrawLedDiamond3D(p, r, this.Style3D, value, color);
			}
			Brush brush = (!value) ? new SolidBrush(textColorInactive) : new SolidBrush(textColorActive);
			DrawStringFormat genericDefault = DrawStringFormat.GenericDefault;
			genericDefault.Alignment = StringAlignment.Center;
			genericDefault.LineAlignment = StringAlignment.Center;
			if (this.ControlBase != null)
			{
				p.Graphics.DrawString(s, this.ControlBase.Font, brush, r, genericDefault);
			}
		}
	}
}
