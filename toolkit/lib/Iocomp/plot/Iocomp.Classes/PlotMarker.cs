using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Marker.")]
	public class PlotMarker : SubClassBase, IPlotMarker
	{
		private PlotMarkerStyle m_Style;

		private PlotFill m_Fill;

		private IPlotFill I_Fill;

		private int m_Size;

		private string m_Text;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotMarkerStyle Style
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string Text
		{
			get
			{
				if (this.m_Text == null)
				{
					return Const.EmptyString;
				}
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

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill Fill
		{
			get
			{
				return this.m_Fill;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Marker";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotMarkerEditorPlugIn";
		}

		void IPlotMarker.Draw(PaintArgs p, int x, int y, Brush brush, Pen pen)
		{
			this.Draw(p, x, y, brush, pen);
		}

		void IPlotMarker.Draw(PaintArgs p, int x, int y)
		{
			this.Draw(p, x, y);
		}

		void IPlotMarker.DrawLegend(PaintArgs p, Rectangle r)
		{
			this.DrawLegend(p, r);
		}

		public PlotMarker()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Fill = new PlotFill();
			base.AddSubClass(this.Fill);
			this.I_Fill = this.Fill;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Visible = true;
			this.Font = null;
			this.Style = PlotMarkerStyle.Circle;
			this.Size = 4;
			this.Text = "";
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
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

		private bool ShouldSerializeStyle()
		{
			return base.PropertyShouldSerialize("Style");
		}

		private void ResetStyle()
		{
			base.PropertyReset("Style");
		}

		private bool ShouldSerializeSize()
		{
			return base.PropertyShouldSerialize("Size");
		}

		private void ResetSize()
		{
			base.PropertyReset("Size");
		}

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeFill()
		{
			return ((ISubClassBase)this.Fill).ShouldSerialize();
		}

		private void ResetFill()
		{
			((ISubClassBase)this.Fill).ResetToDefault();
		}

		private void Draw(PaintArgs p, int x, int y)
		{
			this.Draw(p, x, y, null, null);
		}

		protected virtual void Draw(PaintArgs p, int x, int y, Brush brush, Pen pen)
		{
			this.Draw(p, x, y, brush, pen, this.Size);
		}

		protected virtual void DrawLegend(PaintArgs p, Rectangle r)
		{
			int num = r.Width / 3;
			if (num % 2 == 0)
			{
				num++;
			}
			if (this.Size < num)
			{
				num = this.Size;
			}
			this.Draw(p, (r.Left + r.Right) / 2, (r.Top + r.Bottom) / 2, null, null, num);
		}

		private void Draw(PaintArgs p, int x, int y, Brush brush, Pen pen, int size)
		{
			if (this.Visible && !this.Fill.NotDrawVisible && size >= 1)
			{
				Rectangle rectangle = new Rectangle(x - size, y - size, 2 * size, 2 * size);
				if (p.Graphics.ClipBounds.Contains(x, y))
				{
					if (brush == null && this.Fill.Brush.Visible)
					{
						brush = ((IPlotBrush)this.Fill.Brush).GetBrush(p, rectangle);
					}
					if (pen == null && this.Fill.Pen.Visible)
					{
						pen = ((IPlotPen)this.Fill.Pen).GetPen(p);
					}
					if (this.Style == PlotMarkerStyle.Circle)
					{
						if (this.Fill.Brush.Visible)
						{
							p.Graphics.FillEllipse(brush, rectangle);
						}
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawEllipse(pen, rectangle);
						}
					}
					else if (this.Style == PlotMarkerStyle.Square)
					{
						if (this.Fill.Brush.Visible)
						{
							p.Graphics.FillRectangle(brush, rectangle);
						}
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawRectangle(pen, rectangle);
						}
					}
					else if (this.Style == PlotMarkerStyle.Diamond)
					{
						Point[] points = new Point[4]
						{
							new Point(x, y - size),
							new Point(x + size, y),
							new Point(x, y + size),
							new Point(x - size, y)
						};
						if (this.Fill.Brush.Visible)
						{
							p.Graphics.FillPolygon(brush, points);
						}
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawPolygon(pen, points);
						}
					}
					else if (this.Style == PlotMarkerStyle.TriangleLeft)
					{
						Point[] points = new Point[3]
						{
							new Point(x, y),
							new Point(x + 2 * size, y - size),
							new Point(x + 2 * size, y + size)
						};
						if (this.Fill.Brush.Visible)
						{
							p.Graphics.FillPolygon(brush, points);
						}
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawPolygon(pen, points);
						}
					}
					else if (this.Style == PlotMarkerStyle.TriangleRight)
					{
						Point[] points = new Point[3]
						{
							new Point(x - 2 * size, y - size),
							new Point(x - 2 * size, y + size),
							new Point(x, y)
						};
						if (this.Fill.Brush.Visible)
						{
							p.Graphics.FillPolygon(brush, points);
						}
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawPolygon(pen, points);
						}
					}
					else if (this.Style == PlotMarkerStyle.TriangleUp)
					{
						Point[] points = new Point[3]
						{
							new Point(x, y),
							new Point(x + size, y + 2 * size),
							new Point(x - size, y + 2 * size)
						};
						if (this.Fill.Brush.Visible)
						{
							p.Graphics.FillPolygon(brush, points);
						}
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawPolygon(pen, points);
						}
					}
					else if (this.Style == PlotMarkerStyle.TriangleDown)
					{
						Point[] points = new Point[3]
						{
							new Point(x, y),
							new Point(x + size, y - 2 * size),
							new Point(x - size, y - 2 * size)
						};
						if (this.Fill.Brush.Visible)
						{
							p.Graphics.FillPolygon(brush, points);
						}
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawPolygon(pen, points);
						}
					}
					else if (this.Style == PlotMarkerStyle.TriangleLeftCenter)
					{
						Point[] points = new Point[3]
						{
							new Point(x - this.Size, y),
							new Point(x + size, y - size),
							new Point(x + size, y + size)
						};
						if (this.Fill.Brush.Visible)
						{
							p.Graphics.FillPolygon(brush, points);
						}
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawPolygon(pen, points);
						}
					}
					else if (this.Style == PlotMarkerStyle.TriangleRightCenter)
					{
						Point[] points = new Point[3]
						{
							new Point(x - size, y - size),
							new Point(x - size, y + size),
							new Point(x + size, y)
						};
						if (this.Fill.Brush.Visible)
						{
							p.Graphics.FillPolygon(brush, points);
						}
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawPolygon(pen, points);
						}
					}
					else if (this.Style == PlotMarkerStyle.TriangleUpCenter)
					{
						Point[] points = new Point[3]
						{
							new Point(x, y - size),
							new Point(x + size, y + size),
							new Point(x - size, y + size)
						};
						if (this.Fill.Brush.Visible)
						{
							p.Graphics.FillPolygon(brush, points);
						}
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawPolygon(pen, points);
						}
					}
					else if (this.Style == PlotMarkerStyle.TriangleDownCenter)
					{
						Point[] points = new Point[3]
						{
							new Point(x, y + size),
							new Point(x + size, y - size),
							new Point(x - size, y - size)
						};
						if (this.Fill.Brush.Visible)
						{
							p.Graphics.FillPolygon(brush, points);
						}
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawPolygon(pen, points);
						}
					}
					else if (this.Style == PlotMarkerStyle.Cross)
					{
						Point[] points = new Point[3]
						{
							new Point(x, y + size),
							new Point(x + size, y - size),
							new Point(x - size, y - size)
						};
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawLine(pen, x, y - size, x, y + 2 * size);
						}
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawLine(pen, x - this.Size, y, x + size, y);
						}
					}
					else if (this.Style == PlotMarkerStyle.Plus)
					{
						Point[] points = new Point[3]
						{
							new Point(x, y + size),
							new Point(x + size, y - size),
							new Point(x - size, y - size)
						};
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawLine(pen, x, y - size, x, y + size);
						}
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawLine(pen, x - this.Size, y, x + size, y);
						}
					}
					else if (this.Style == PlotMarkerStyle.LineHorizontial)
					{
						Point[] points = new Point[3]
						{
							new Point(x, y + size),
							new Point(x + size, y - size),
							new Point(x - size, y - size)
						};
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawLine(pen, x - this.Size, y, x + size, y);
						}
					}
					else if (this.Style == PlotMarkerStyle.LineVertical)
					{
						Point[] points = new Point[3]
						{
							new Point(x, y + size),
							new Point(x + size, y - size),
							new Point(x - size, y - size)
						};
						if (this.Fill.Pen.Visible)
						{
							p.Graphics.DrawLine(pen, x, y - size, x, y + size);
						}
					}
					else if (this.Style == PlotMarkerStyle.Text)
					{
						DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
						genericTypographic.LineAlignment = StringAlignment.Center;
						genericTypographic.Alignment = StringAlignment.Center;
						p.Graphics.MeasureString(this.Text, this.Font);
						p.Graphics.DrawString(this.Text, this.Font, p.Graphics.Brush(this.ForeColor), (float)x, (float)y, genericTypographic);
					}
				}
			}
		}
	}
}
