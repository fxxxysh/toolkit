using Iocomp.Types;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Layout Data-View.")]
	public abstract class PlotLayoutDataView : PlotLayoutBase
	{
		private double m_DockDepthRatio;

		private PlotLayoutStackingGroup m_StackingGroup;

		private int m_StackingGroupIndex;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double DockDepthRatio
		{
			get
			{
				return this.m_DockDepthRatio;
			}
			set
			{
				base.PropertyUpdateDefault("DockDepthRatio", value);
				if (this.DockDepthRatio != value)
				{
					this.m_DockDepthRatio = value;
					base.DoPropertyChange(this, "DockDepthRatio");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int StackingGroupIndex
		{
			get
			{
				return this.m_StackingGroupIndex;
			}
			set
			{
				base.PropertyUpdateDefault("StackingGroupIndex", value);
				if (this.StackingGroupIndex != value)
				{
					this.m_StackingGroupIndex = value;
					base.DoPropertyChange(this, "StackingGroupIndex");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		[Browsable(false)]
		public PlotLayoutStackingGroup StackingGroup
		{
			get
			{
				return this.m_StackingGroup;
			}
			set
			{
				this.m_StackingGroup = value;
			}
		}

		public override bool DocksToDataView => false;

		public override bool DocksToPlot => true;

		protected override string GetPlugInTitle()
		{
			return "Layout";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLayoutDataViewEditorPlugIn";
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.DockSide = AlignmentQuadSide.Bottom;
			this.DockDepthRatio = 100.0;
			this.StackingGroupIndex = 0;
		}

		private bool ShouldSerializeDockDepthRatio()
		{
			return base.PropertyShouldSerialize("DockDepthRatio");
		}

		private void ResetDockDepthRatio()
		{
			base.PropertyReset("DockDepthRatio");
		}

		private bool ShouldSerializeStackingGroupIndex()
		{
			return base.PropertyShouldSerialize("StackingGroupIndex");
		}

		private void ResetStackingGroupIndex()
		{
			base.PropertyReset("StackingGroupIndex");
		}

		protected override void CalculateDepthPixels(PaintArgs p)
		{
			base.DockDepthPixels = 0;
		}

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
			return base.BoundsClip.Contains(e.X, e.Y);
		}

		public bool IsDocked(PlotLayoutBase value)
		{
			PlotLayoutDockableDataView plotLayoutDockableDataView = value as PlotLayoutDockableDataView;
			if (plotLayoutDockableDataView == null)
			{
				return false;
			}
			if (!plotLayoutDockableDataView.DocksToDataView)
			{
				return false;
			}
			if (plotLayoutDockableDataView.DockDataViewName.ToUpper() != base.Name.ToUpper())
			{
				return false;
			}
			return true;
		}
	}
}
