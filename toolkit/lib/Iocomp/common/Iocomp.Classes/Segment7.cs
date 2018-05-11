using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Contains the properties that control the appearance for the indicator.")]
	public sealed class Segment7 : SubClassBase, ISegment7
	{
		private Color m_ColorOn;

		private Color m_ColorOff;

		private bool m_ColorOffAuto;

		private int m_Size;

		private int m_Separation;

		private bool m_ShowOffSegments;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color ColorOn
		{
			get
			{
				return this.m_ColorOn;
			}
			set
			{
				base.PropertyUpdateDefault("ColorOn", value);
				if (this.ColorOn != value)
				{
					this.m_ColorOn = value;
					base.DoPropertyChange(this, "ColorOn");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color ColorOff
		{
			get
			{
				return this.m_ColorOff;
			}
			set
			{
				base.PropertyUpdateDefault("ColorOff", value);
				if (this.ColorOff != value)
				{
					this.m_ColorOff = value;
					base.DoPropertyChange(this, "ColorOff");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ColorOffAuto
		{
			get
			{
				return this.m_ColorOffAuto;
			}
			set
			{
				base.PropertyUpdateDefault("ColorOffAuto", value);
				if (this.ColorOffAuto != value)
				{
					this.m_ColorOffAuto = value;
					base.DoPropertyChange(this, "ColorOffAuto");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int Size
		{
			get
			{
				return this.m_Size;
			}
			set
			{
				base.PropertyUpdateDefault("Size", value);
				if (this.Size != value)
				{
					this.m_Size = value;
					base.DoPropertyChange(this, "Size");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int Separation
		{
			get
			{
				return this.m_Separation;
			}
			set
			{
				base.PropertyUpdateDefault("Separation", value);
				if (this.Separation != value)
				{
					this.m_Separation = value;
					base.DoPropertyChange(this, "Separation");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ShowOffSegments
		{
			get
			{
				return this.m_ShowOffSegments;
			}
			set
			{
				base.PropertyUpdateDefault("ShowOffSegments", value);
				if (this.ShowOffSegments != value)
				{
					this.m_ShowOffSegments = value;
					base.DoPropertyChange(this, "ShowOffSegments");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Segment-7";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.Segment7EditorPlugIn";
		}

		Size ISegment7.GetRequiredSize(Segment7Character character)
		{
			return this.GetRequiredSize(character);
		}

		void ISegment7.Draw(PaintArgs p, iRectangle r, Segment7Character character)
		{
			this.Draw(p, r, character);
		}

		public Segment7()
		{
			base.DoCreate();
		}

		private bool ShouldSerializeColorOn()
		{
			return base.PropertyShouldSerialize("ColorOn");
		}

		private void ResetColorOn()
		{
			base.PropertyReset("ColorOn");
		}

		private bool ShouldSerializeColorOff()
		{
			return base.PropertyShouldSerialize("ColorOff");
		}

		private void ResetColorOff()
		{
			base.PropertyReset("ColorOff");
		}

		private bool ShouldSerializeColorOffAuto()
		{
			return base.PropertyShouldSerialize("ColorOffAuto");
		}

		private void ResetColorOffAuto()
		{
			base.PropertyReset("ColorOffAuto");
		}

		private bool ShouldSerializeSize()
		{
			return base.PropertyShouldSerialize("Size");
		}

		private void ResetSize()
		{
			base.PropertyReset("Size");
		}

		private bool ShouldSerializeSeparation()
		{
			return base.PropertyShouldSerialize("Separation");
		}

		private void ResetSeparation()
		{
			base.PropertyReset("Separation");
		}

		private bool ShouldSerializeShowOffSegments()
		{
			return base.PropertyShouldSerialize("ShowOffSegments");
		}

		private void ResetShowOffSegments()
		{
			base.PropertyReset("ShowOffSegments");
		}

		public Segment7Character ConvertChar(char value)
		{
			switch (value)
			{
			case '0':
				return Segment7Character.X0;
			case '1':
				return Segment7Character.X1;
			case '2':
				return Segment7Character.X2;
			case '3':
				return Segment7Character.X3;
			case '4':
				return Segment7Character.X4;
			case '5':
				return Segment7Character.X5;
			case '6':
				return Segment7Character.X6;
			case '7':
				return Segment7Character.X7;
			case '8':
				return Segment7Character.X8;
			case '9':
				return Segment7Character.X9;
			case '<':
				return Segment7Character.ArrowDown;
			case '>':
				return Segment7Character.ArrowUp;
			case ':':
				return Segment7Character.Colon;
			case ',':
				return Segment7Character.Comma;
			case '-':
				return Segment7Character.Minus;
			case '.':
				return Segment7Character.Period;
			case '+':
				return Segment7Character.Plus;
			case ';':
				return Segment7Character.SemiColon;
			case ' ':
				return Segment7Character.Space;
			default:
				return Segment7Character.Space;
			case 'F':
			case 'f':
				return Segment7Character.XF;
			case 'E':
			case 'e':
				return Segment7Character.XE;
			case 'D':
			case 'd':
				return Segment7Character.XD;
			case 'C':
			case 'c':
				return Segment7Character.XC;
			case 'B':
			case 'b':
				return Segment7Character.XB;
			case 'A':
			case 'a':
				return Segment7Character.XA;
			}
		}

		private void DrawSegmentA(PaintArgs p, iRectangle r, Color color)
		{
			Point[] points = new Point[4]
			{
				new Point(r.Left + this.Separation, r.Top),
				new Point(r.Right - this.Separation, r.Top),
				new Point(r.Right - this.Separation - this.Size * 2, r.Top + this.Size * 2),
				new Point(r.Left + this.Separation + this.Size * 2, r.Top + this.Size * 2)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(color), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(color), points);
		}

		private void DrawSegmentB(PaintArgs p, iRectangle r, Color color)
		{
			Point[] points = new Point[4]
			{
				new Point(r.Right, r.Top + this.Separation),
				new Point(r.Right, r.CenterY - this.Separation),
				new Point(r.Right - this.Size * 2, r.CenterY - this.Separation - this.Size * 2),
				new Point(r.Right - this.Size * 2, r.Top + this.Separation + this.Size * 2)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(color), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(color), points);
		}

		private void DrawSegmentC(PaintArgs p, iRectangle r, Color color)
		{
			Point[] points = new Point[4]
			{
				new Point(r.Right, r.CenterY + this.Separation),
				new Point(r.Right, r.Bottom - this.Separation),
				new Point(r.Right - this.Size * 2, r.Bottom - this.Separation - this.Size * 2),
				new Point(r.Right - this.Size * 2, r.CenterY + this.Separation + this.Size * 2)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(color), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(color), points);
		}

		private void DrawSegmentD(PaintArgs p, iRectangle r, Color color)
		{
			Point[] points = new Point[4]
			{
				new Point(r.Left + this.Separation, r.Bottom),
				new Point(r.Right - this.Separation, r.Bottom),
				new Point(r.Right - this.Separation - this.Size * 2, r.Bottom - this.Size * 2),
				new Point(r.Left + this.Separation + this.Size * 2, r.Bottom - this.Size * 2)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(color), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(color), points);
		}

		private void DrawSegmentE(PaintArgs p, iRectangle r, Color color)
		{
			Point[] points = new Point[4]
			{
				new Point(r.Left, r.CenterY + this.Separation),
				new Point(r.Left, r.Bottom - this.Separation),
				new Point(r.Left + this.Size * 2, r.Bottom - this.Separation - this.Size * 2),
				new Point(r.Left + this.Size * 2, r.CenterY + this.Separation + this.Size * 2)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(color), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(color), points);
		}

		private void DrawSegmentF(PaintArgs p, iRectangle r, Color color)
		{
			Point[] points = new Point[4]
			{
				new Point(r.Left, r.Top + this.Separation),
				new Point(r.Left, r.CenterY - this.Separation),
				new Point(r.Left + this.Size * 2, r.CenterY - this.Separation - this.Size * 2),
				new Point(r.Left + this.Size * 2, r.Top + this.Separation + this.Size * 2)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(color), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(color), points);
		}

		private void DrawSegmentG(PaintArgs p, iRectangle r, Color color)
		{
			Point[] points = new Point[6]
			{
				new Point(r.Left + this.Separation, r.CenterY),
				new Point(r.Left + this.Separation + this.Size, r.CenterY - this.Size),
				new Point(r.Right - this.Separation - this.Size, r.CenterY - this.Size),
				new Point(r.Right - this.Separation, r.CenterY),
				new Point(r.Right - this.Separation - this.Size, r.CenterY + this.Size),
				new Point(r.Left + this.Separation + this.Size, r.CenterY + this.Size)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(color), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(color), points);
		}

		private void DrawArrowUp(PaintArgs p, iRectangle r)
		{
			Point[] points = new Point[3]
			{
				new Point(r.Left, r.CenterY + r.WidthHalf),
				new Point(r.Right, r.CenterY + r.WidthHalf),
				new Point(r.CenterX, r.CenterY - r.WidthHalf)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(this.ColorOn), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(this.ColorOn), points);
		}

		private void DrawArrowDown(PaintArgs p, iRectangle r)
		{
			Point[] points = new Point[3]
			{
				new Point(r.Left, r.CenterY - r.WidthHalf),
				new Point(r.Right, r.CenterY - r.WidthHalf),
				new Point(r.CenterX, r.CenterY + r.WidthHalf)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(this.ColorOn), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(this.ColorOn), points);
		}

		private void DrawMinus(PaintArgs p, iRectangle r)
		{
			Point[] points = new Point[4]
			{
				new Point(r.Left, r.CenterY - this.Size),
				new Point(r.Right, r.CenterY - this.Size),
				new Point(r.Right, r.CenterY + this.Size),
				new Point(r.Left, r.CenterY + this.Size)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(this.ColorOn), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(this.ColorOn), points);
		}

		private void DrawPlus(PaintArgs p, iRectangle r)
		{
			Point[] points = new Point[12]
			{
				new Point(r.CenterX - this.Size, r.CenterY - r.WidthHalf),
				new Point(r.CenterX + this.Size, r.CenterY - r.WidthHalf),
				new Point(r.CenterX + this.Size, r.CenterY - this.Size),
				new Point(r.Right, r.CenterY - this.Size),
				new Point(r.Right, r.CenterY + this.Size),
				new Point(r.CenterX + this.Size, r.CenterY + this.Size),
				new Point(r.CenterX + this.Size, r.CenterY + r.WidthHalf),
				new Point(r.CenterX - this.Size, r.CenterY + r.WidthHalf),
				new Point(r.CenterX - this.Size, r.CenterY + this.Size),
				new Point(r.Left, r.CenterY + this.Size),
				new Point(r.Left, r.CenterY - this.Size),
				new Point(r.CenterX - this.Size, r.CenterY - this.Size)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(this.ColorOn), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(this.ColorOn), points);
		}

		private void DrawDot(PaintArgs p, iRectangle r, int yCenter)
		{
			Point[] points = new Point[4]
			{
				new Point(r.CenterX - this.Size, yCenter - this.Size),
				new Point(r.CenterX + this.Size, yCenter - this.Size),
				new Point(r.CenterX + this.Size, yCenter + this.Size),
				new Point(r.CenterX - this.Size, yCenter + this.Size)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(this.ColorOn), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(this.ColorOn), points);
		}

		private void DrawDotComma(PaintArgs p, iRectangle r, int yCenterDot)
		{
			Point[] points = new Point[6]
			{
				new Point(r.CenterX - this.Size, yCenterDot - this.Size),
				new Point(r.CenterX + this.Size, yCenterDot - this.Size),
				new Point(r.CenterX + this.Size, yCenterDot + 3 * this.Size),
				new Point(r.CenterX, yCenterDot + 3 * this.Size),
				new Point(r.CenterX, yCenterDot + this.Size),
				new Point(r.CenterX - this.Size, yCenterDot + this.Size)
			};
			p.Graphics.FillPolygon(p.Graphics.Brush(this.ColorOn), points);
			p.Graphics.DrawPolygon(p.Graphics.Pen(this.ColorOn), points);
		}

		private void DrawColon(PaintArgs p, iRectangle r)
		{
			this.DrawDot(p, r, p.CenterY - this.Size * 3);
			this.DrawDot(p, r, p.CenterY + this.Size * 3);
		}

		private void DrawPeriod(PaintArgs p, iRectangle r)
		{
			this.DrawDot(p, r, p.Bottom - this.Size);
		}

		private void DrawComma(PaintArgs p, iRectangle r)
		{
			this.DrawDotComma(p, r, p.Bottom - 3 * this.Size);
		}

		private void DrawSemiColon(PaintArgs p, iRectangle r)
		{
			this.DrawDot(p, r, p.CenterY - this.Size * 3);
			this.DrawDotComma(p, r, p.CenterY + this.Size * 3);
		}

		private Color GetOffColor()
		{
			if (this.m_ColorOffAuto)
			{
				return iColors.ToOffColor(this.m_ColorOn);
			}
			return this.m_ColorOff;
		}

		private void Draw(PaintArgs p, iRectangle r, Segment7Character character)
		{
			Color colorOn = this.ColorOn;
			Color offColor = this.GetOffColor();
			bool[] array;
			switch (character)
			{
			case Segment7Character.Space:
			{
				bool[] array2 = new bool[7];
				array = array2;
				goto IL_01c9;
			}
			case Segment7Character.X0:
				array = new bool[7]
				{
					true,
					true,
					true,
					true,
					true,
					true,
					false
				};
				goto IL_01c9;
			case Segment7Character.X1:
				array = new bool[7]
				{
					false,
					true,
					true,
					false,
					false,
					false,
					false
				};
				goto IL_01c9;
			case Segment7Character.X2:
				array = new bool[7]
				{
					true,
					true,
					false,
					true,
					true,
					false,
					true
				};
				goto IL_01c9;
			case Segment7Character.X3:
				array = new bool[7]
				{
					true,
					true,
					true,
					true,
					false,
					false,
					true
				};
				goto IL_01c9;
			case Segment7Character.X4:
				array = new bool[7]
				{
					false,
					true,
					true,
					false,
					false,
					true,
					true
				};
				goto IL_01c9;
			case Segment7Character.X5:
				array = new bool[7]
				{
					true,
					false,
					true,
					true,
					false,
					true,
					true
				};
				goto IL_01c9;
			case Segment7Character.X6:
				array = new bool[7]
				{
					true,
					false,
					true,
					true,
					true,
					true,
					true
				};
				goto IL_01c9;
			case Segment7Character.X7:
				array = new bool[7]
				{
					true,
					true,
					true,
					false,
					false,
					false,
					false
				};
				goto IL_01c9;
			case Segment7Character.X8:
				array = new bool[7]
				{
					true,
					true,
					true,
					true,
					true,
					true,
					true
				};
				goto IL_01c9;
			case Segment7Character.X9:
				array = new bool[7]
				{
					true,
					true,
					true,
					false,
					false,
					true,
					true
				};
				goto IL_01c9;
			case Segment7Character.XA:
				array = new bool[7]
				{
					true,
					true,
					true,
					false,
					true,
					true,
					true
				};
				goto IL_01c9;
			case Segment7Character.XB:
				array = new bool[7]
				{
					false,
					false,
					true,
					true,
					true,
					true,
					true
				};
				goto IL_01c9;
			case Segment7Character.XC:
				array = new bool[7]
				{
					true,
					false,
					false,
					true,
					true,
					true,
					false
				};
				goto IL_01c9;
			case Segment7Character.XD:
				array = new bool[7]
				{
					false,
					true,
					true,
					true,
					true,
					false,
					true
				};
				goto IL_01c9;
			case Segment7Character.XE:
				array = new bool[7]
				{
					true,
					false,
					false,
					true,
					true,
					true,
					true
				};
				goto IL_01c9;
			case Segment7Character.XF:
				array = new bool[7]
				{
					true,
					false,
					false,
					false,
					true,
					true,
					true
				};
				goto IL_01c9;
			case Segment7Character.ArrowUp:
				this.DrawArrowUp(p, r);
				break;
			case Segment7Character.ArrowDown:
				this.DrawArrowDown(p, r);
				break;
			case Segment7Character.Colon:
				this.DrawColon(p, r);
				break;
			case Segment7Character.Comma:
				this.DrawComma(p, r);
				break;
			case Segment7Character.SemiColon:
				this.DrawSemiColon(p, r);
				break;
			case Segment7Character.Period:
				this.DrawPeriod(p, r);
				break;
			case Segment7Character.Minus:
				this.DrawMinus(p, r);
				break;
			case Segment7Character.Plus:
				{
					this.DrawPlus(p, r);
					break;
				}
				IL_01c9:
				if (array[0])
				{
					this.DrawSegmentA(p, r, colorOn);
				}
				else if (this.ShowOffSegments)
				{
					this.DrawSegmentA(p, r, offColor);
				}
				if (array[1])
				{
					this.DrawSegmentB(p, r, colorOn);
				}
				else if (this.ShowOffSegments)
				{
					this.DrawSegmentB(p, r, offColor);
				}
				if (array[2])
				{
					this.DrawSegmentC(p, r, colorOn);
				}
				else if (this.ShowOffSegments)
				{
					this.DrawSegmentC(p, r, offColor);
				}
				if (array[3])
				{
					this.DrawSegmentD(p, r, colorOn);
				}
				else if (this.ShowOffSegments)
				{
					this.DrawSegmentD(p, r, offColor);
				}
				if (array[4])
				{
					this.DrawSegmentE(p, r, colorOn);
				}
				else if (this.ShowOffSegments)
				{
					this.DrawSegmentE(p, r, offColor);
				}
				if (array[5])
				{
					this.DrawSegmentF(p, r, colorOn);
				}
				else if (this.ShowOffSegments)
				{
					this.DrawSegmentF(p, r, offColor);
				}
				if (array[6])
				{
					this.DrawSegmentG(p, r, colorOn);
				}
				else if (this.ShowOffSegments)
				{
					this.DrawSegmentG(p, r, offColor);
				}
				break;
			}
		}

		private Size GetRequiredSize(Segment7Character character)
		{
			if (character != Segment7Character.Period && character != Segment7Character.Colon && character != Segment7Character.SemiColon && character != Segment7Character.Comma)
			{
				return new Size(10 * this.Size, 18 * this.Size);
			}
			return new Size(2 * this.Size, 18 * this.Size);
		}
	}
}
