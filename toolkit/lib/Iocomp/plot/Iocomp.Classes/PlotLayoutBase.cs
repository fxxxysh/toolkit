using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Base Class for all Plot Layout objects.")]
	public abstract class PlotLayoutBase : PlotObject, IPlotLayout
	{
		private int m_DockOrder;

		private AlignmentQuadSide m_DockSide;

		private int m_DockMargin;

		private Rectangle m_BoundsAlignment;

		private int m_DockDepthPixels;

		private int m_TextOverlapPixelsStart;

		private int m_TextOverlapPixelsStop;

		private int m_StackingPixelsStart;

		private int m_StackingPixelsStop;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int DockOrder
		{
			get
			{
				return this.m_DockOrder;
			}
			set
			{
				base.PropertyUpdateDefault("DockOrder", value);
				if (this.DockOrder != value)
				{
					this.m_DockOrder = value;
					base.DoPropertyChange(this, "DockOrder");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public virtual AlignmentQuadSide DockSide
		{
			get
			{
				return this.m_DockSide;
			}
			set
			{
				base.PropertyUpdateDefault("DockSide", value);
				if (this.DockSide != value)
				{
					this.m_DockSide = value;
					base.DoPropertyChange(this, "DockSide");
					this.OnDockSideChanged();
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public virtual int DockMargin
		{
			get
			{
				return this.m_DockMargin;
			}
			set
			{
				base.PropertyUpdateDefault("DockMargin", value);
				if (this.DockMargin != value)
				{
					this.m_DockMargin = value;
					base.DoPropertyChange(this, "DockMargin");
				}
			}
		}

		public bool DockLeft => this.m_DockSide == AlignmentQuadSide.Left;

		public bool DockRight => this.m_DockSide == AlignmentQuadSide.Right;

		public bool DockTop => this.m_DockSide == AlignmentQuadSide.Top;

		public bool DockBottom => this.m_DockSide == AlignmentQuadSide.Bottom;

		public bool DockVertical
		{
			get
			{
				if (!this.DockTop)
				{
					return this.DockBottom;
				}
				return true;
			}
		}

		public bool DockHorizontal
		{
			get
			{
				if (!this.DockLeft)
				{
					return this.DockRight;
				}
				return true;
			}
		}

		public Orientation DockOrientation
		{
			get
			{
				if (this.DockVertical)
				{
					return Orientation.Vertical;
				}
				return Orientation.Horizontal;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		[Browsable(false)]
		[RefreshProperties(RefreshProperties.All)]
		public int DockDepthPixels
		{
			get
			{
				return this.m_DockDepthPixels;
			}
			set
			{
				this.m_DockDepthPixels = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		public int TextOverlapPixelsStart
		{
			get
			{
				return this.m_TextOverlapPixelsStart;
			}
			set
			{
				this.m_TextOverlapPixelsStart = value;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Browsable(false)]
		public int TextOverlapPixelsStop
		{
			get
			{
				return this.m_TextOverlapPixelsStop;
			}
			set
			{
				this.m_TextOverlapPixelsStop = value;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Browsable(false)]
		public int StackingPixelsStart
		{
			get
			{
				return this.m_StackingPixelsStart;
			}
			set
			{
				this.m_StackingPixelsStart = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public int StackingPixelsStop
		{
			get
			{
				return this.m_StackingPixelsStop;
			}
			set
			{
				this.m_StackingPixelsStop = value;
			}
		}

		protected Rectangle BoundsAlignment
		{
			get
			{
				return this.m_BoundsAlignment;
			}
			set
			{
				this.m_BoundsAlignment = value;
			}
		}

		public abstract bool DocksToDataView
		{
			get;
		}

		public abstract bool DocksToPlot
		{
			get;
		}

		public static int BlockSize => 21;

		void IPlotLayout.CalculateDepthPixels(PaintArgs p)
		{
			this.CalculateDepthPixels(p);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.DockOrder = -1;
			this.DockSide = AlignmentQuadSide.Left;
			this.DockMargin = 3;
		}

		private bool ShouldSerializeDockOrder()
		{
			return base.PropertyShouldSerialize("DockOrder");
		}

		private void ResetDockOrder()
		{
			base.PropertyReset("DockOrder");
		}

		private bool ShouldSerializeDockSide()
		{
			return base.PropertyShouldSerialize("DockSide");
		}

		private void ResetDockSide()
		{
			base.PropertyReset("DockSide");
		}

		private bool ShouldSerializeDockMargin()
		{
			return base.PropertyShouldSerialize("DockMargin");
		}

		private void ResetDockMargin()
		{
			base.PropertyReset("DockMargin");
		}

		protected virtual void OnDockSideChanged()
		{
		}

		protected abstract void CalculateDepthPixels(PaintArgs p);

		protected override bool InternalHitTest(MouseEventArgs e)
		{
			if (!this.Visible)
			{
				return false;
			}
			if (!base.Enabled)
			{
				return false;
			}
			return base.Bounds.Contains(e.X, e.Y);
		}
	}
}
