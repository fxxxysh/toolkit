using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Plot Fill Grid.")]
	public class PlotFillGrid : PlotFill
	{
		private bool m_GridShowLeft;

		private bool m_GridShowRight;

		private bool m_GridShowTop;

		private bool m_GridShowBottom;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool GridShowLeft
		{
			get
			{
				return this.m_GridShowLeft;
			}
			set
			{
				base.PropertyUpdateDefault("GridShowLeft", value);
				if (this.GridShowLeft != value)
				{
					this.m_GridShowLeft = value;
					base.DoPropertyChange(this, "GridShowLeft");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool GridShowRight
		{
			get
			{
				return this.m_GridShowRight;
			}
			set
			{
				base.PropertyUpdateDefault("GridShowRight", value);
				if (this.GridShowRight != value)
				{
					this.m_GridShowRight = value;
					base.DoPropertyChange(this, "GridShowRight");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool GridShowTop
		{
			get
			{
				return this.m_GridShowTop;
			}
			set
			{
				base.PropertyUpdateDefault("GridShowTop", value);
				if (this.GridShowTop != value)
				{
					this.m_GridShowTop = value;
					base.DoPropertyChange(this, "GridShowTop");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool GridShowBottom
		{
			get
			{
				return this.m_GridShowBottom;
			}
			set
			{
				base.PropertyUpdateDefault("GridShowBottom", value);
				if (this.GridShowBottom != value)
				{
					this.m_GridShowBottom = value;
					base.DoPropertyChange(this, "GridShowBottom");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Plot Fill Grid";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotFillGridEditorPlugIn";
		}

		public PlotFillGrid()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.GridShowLeft = true;
			this.GridShowRight = true;
			this.GridShowTop = true;
			this.GridShowBottom = true;
		}

		private bool ShouldSerializeGridShowLeft()
		{
			return base.PropertyShouldSerialize("GridShowLeft");
		}

		private void ResetGridShowLeft()
		{
			base.PropertyReset("GridShowLeft");
		}

		private bool ShouldSerializeGridShowRight()
		{
			return base.PropertyShouldSerialize("GridShowRight");
		}

		private void ResetGridShowRight()
		{
			base.PropertyReset("GridShowRight");
		}

		private bool ShouldSerializeGridShowTop()
		{
			return base.PropertyShouldSerialize("GridShowTop");
		}

		private void ResetGridShowTop()
		{
			base.PropertyReset("GridShowTop");
		}

		private bool ShouldSerializeGridShowBottom()
		{
			return base.PropertyShouldSerialize("GridShowBottom");
		}

		private void ResetGridShowBottom()
		{
			base.PropertyReset("GridShowBottom");
		}

		protected override void Draw(PaintArgs p, Rectangle r)
		{
			if (base.Visible && r.Height > 0 && r.Width > 0)
			{
				GraphicsState gstate = p.Graphics.Save();
				p.Graphics.SmoothingMode = SmoothingMode.HighQuality;
				if (base.Brush.Visible)
				{
					p.Graphics.FillRectangle(base.I_Brush.GetBrush(p, r), r);
				}
				if (base.Pen.Visible)
				{
					Pen pen = base.I_Pen.GetPen(p);
					if (this.GridShowLeft)
					{
						p.Graphics.DrawLine(pen, r.Left, r.Top, r.Left, r.Bottom);
					}
					if (this.GridShowRight)
					{
						p.Graphics.DrawLine(pen, r.Right, r.Top, r.Right, r.Bottom);
					}
					if (this.GridShowTop)
					{
						p.Graphics.DrawLine(pen, r.Left, r.Top, r.Right, r.Top);
					}
					if (this.GridShowBottom)
					{
						p.Graphics.DrawLine(pen, r.Left, r.Bottom, r.Right, r.Bottom);
					}
				}
				p.Graphics.Restore(gstate);
			}
		}
	}
}
