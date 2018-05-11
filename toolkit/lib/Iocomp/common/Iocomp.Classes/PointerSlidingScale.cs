using Iocomp.Design;
using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("")]
	[TypeConverter(typeof(CollectionItemConverter))]
	public sealed class PointerSlidingScale : SubClassBase, IPointerSlidingScale
	{
		private ValueDouble m_Value;

		private PointerStyleSlidingScale m_Style;

		private Color m_LineColor;

		private int m_LineWidth;

		private int m_Size;

		int IPointerSlidingScale.SpaceLeft
		{
			get
			{
				return this.SpaceLeft;
			}
		}

		int IPointerSlidingScale.SpaceRight
		{
			get
			{
				return this.SpaceRight;
			}
		}

		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public ValueDouble Value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value.AsDouble = value.AsDouble;
			}
		}

		[Description("")]
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

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public PointerStyleSlidingScale Style
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color LineColor
		{
			get
			{
				return this.m_LineColor;
			}
			set
			{
				base.PropertyUpdateDefault("LineColor", value);
				if (this.LineColor != value)
				{
					this.m_LineColor = value;
					base.DoPropertyChange(this, "LineColor");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int LineWidth
		{
			get
			{
				return this.m_LineWidth;
			}
			set
			{
				base.PropertyUpdateDefault("LineWidth", value);
				if (this.LineWidth != value)
				{
					this.m_LineWidth = value;
					base.DoPropertyChange(this, "LineWidth");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public new Color Color
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.Color = value;
			}
		}

		private int SpaceLeft
		{
			get
			{
				if (!this.Visible)
				{
					return 0;
				}
				if (this.Style == PointerStyleSlidingScale.DualArrow)
				{
					return this.Size;
				}
				if (this.Style == PointerStyleSlidingScale.Arrow)
				{
					return this.Size;
				}
				if (this.Style == PointerStyleSlidingScale.Pointer)
				{
					return this.Size * 2;
				}
				return 0;
			}
		}

		private int SpaceRight
		{
			get
			{
				if (!this.Visible)
				{
					return 0;
				}
				if (this.Style == PointerStyleSlidingScale.DualArrow)
				{
					return this.Size;
				}
				return 0;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Pointer";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PointerSlidingScaleEditorPlugIn";
		}

		void IPointerSlidingScale.Draw(PaintArgs p, int referenceY)
		{
			this.Draw(p, referenceY);
		}

		public PointerSlidingScale()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Value = new ValueDouble();
			base.AddSubClass(this.Value);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Visible = true;
			this.Style = PointerStyleSlidingScale.DualArrow;
			this.Color = Color.Yellow;
			this.Size = 10;
			this.LineColor = Color.Blue;
			this.LineWidth = 2;
		}

		private bool ShouldSerializeValue()
		{
			return ((ISubClassBase)this.Value).ShouldSerialize();
		}

		private void ResetValue()
		{
			((ISubClassBase)this.Value).ResetToDefault();
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
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

		private bool ShouldSerializeLineColor()
		{
			return base.PropertyShouldSerialize("LineColor");
		}

		private void ResetLineColor()
		{
			base.PropertyReset("LineColor");
		}

		private bool ShouldSerializeLineWidth()
		{
			return base.PropertyShouldSerialize("LineWidth");
		}

		private void ResetLineWidth()
		{
			base.PropertyReset("LineWidth");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private void Draw(PaintArgs p, int referenceY)
		{
			if (this.Visible)
			{
				if (this.Style == PointerStyleSlidingScale.DualArrow)
				{
					Rectangle r = new Rectangle(p.Left, referenceY - this.Size / 2, this.Size, this.Size);
					Point[] trianglePoints = Shapes.GetTrianglePoints(r, Direction.Right);
					p.Graphics.FillPolygon(p.Graphics.Brush(this.Color), trianglePoints);
					r = new Rectangle(p.Right - this.Size, referenceY - this.Size / 2, this.Size, this.Size);
					trianglePoints = Shapes.GetTrianglePoints(r, Direction.Left);
					p.Graphics.FillPolygon(p.Graphics.Brush(this.Color), trianglePoints);
					p.Graphics.DrawLine(p.Graphics.Pen(this.LineColor, (float)this.LineWidth), p.Left + this.Size, referenceY, p.Right - this.Size, referenceY);
				}
				else if (this.Style == PointerStyleSlidingScale.Arrow)
				{
					Rectangle r = new Rectangle(p.Left, referenceY - this.Size / 2, this.Size, this.Size);
					Point[] trianglePoints = Shapes.GetTrianglePoints(r, Direction.Right);
					p.Graphics.FillPolygon(p.Graphics.Brush(this.Color), trianglePoints);
				}
				else if (this.Style == PointerStyleSlidingScale.Pointer)
				{
					Rectangle r = new Rectangle(p.Left, referenceY - this.Size / 2, 2 * this.Size, this.Size);
					Point[] trianglePoints = Shapes.GetPointerPoints(r, Direction.Right);
					p.Graphics.FillPolygon(p.Graphics.Brush(this.Color), trianglePoints);
				}
				else if (this.Style == PointerStyleSlidingScale.Line)
				{
					p.Graphics.DrawLine(p.Graphics.Pen(this.LineColor, (float)this.LineWidth), p.Left, referenceY, p.Right, referenceY);
				}
			}
		}

		public override string ToString()
		{
			return "Pointer-" + this.Color.ToString();
		}
	}
}
