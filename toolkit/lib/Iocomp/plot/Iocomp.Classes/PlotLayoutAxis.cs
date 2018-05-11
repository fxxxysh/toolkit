using Iocomp.Types;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Layout Axis.")]
	public abstract class PlotLayoutAxis : PlotLayoutDockableDataView
	{
		private PlotDockStyleAxis m_DockStyle;

		private double m_DockStackingEndsMargin;

		private bool m_DockForceStacking;

		private bool m_CartesianEnabled;

		private PlotDockStartStopStyleDockableAxis m_DockStartStyle;

		private string m_DockStartAxisName;

		private PlotDockStartStopStyleDockableAxis m_DockStopStyle;

		private string m_DockStopAxisName;

		private PlotAxis m_CachedDockStartAxis;

		private PlotAxis m_CachedDockStopAxis;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotDockStyleAxis DockStyle
		{
			get
			{
				return this.m_DockStyle;
			}
			set
			{
				base.PropertyUpdateDefault("DockStyle", value);
				if (this.DockStyle != value)
				{
					this.m_DockStyle = value;
					base.DoPropertyChange(this, "DockStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double DockStackingEndsMargin
		{
			get
			{
				return this.m_DockStackingEndsMargin;
			}
			set
			{
				base.PropertyUpdateDefault("DockStackingEndsMargin", value);
				if (this.DockStackingEndsMargin != value)
				{
					this.m_DockStackingEndsMargin = value;
					base.DoPropertyChange(this, "DockStackingEndsMargin");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool DockForceStacking
		{
			get
			{
				return this.m_DockForceStacking;
			}
			set
			{
				base.PropertyUpdateDefault("DockForceStacking", value);
				if (this.DockForceStacking != value)
				{
					this.m_DockForceStacking = value;
					base.DoPropertyChange(this, "DockForceStacking");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotDockStartStopStyleDockableAxis DockStartStyle
		{
			get
			{
				return this.m_DockStartStyle;
			}
			set
			{
				base.PropertyUpdateDefault("DockStartStyle", value);
				if (this.DockStartStyle != value)
				{
					this.m_DockStartStyle = value;
					base.DoPropertyChange(this, "DockStartStyle");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotDockStartStopStyleDockableAxis DockStopStyle
		{
			get
			{
				return this.m_DockStopStyle;
			}
			set
			{
				base.PropertyUpdateDefault("DockStopStyle", value);
				if (this.DockStopStyle != value)
				{
					this.m_DockStopStyle = value;
					base.DoPropertyChange(this, "DockStopStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string DockStartAxisName
		{
			get
			{
				return this.m_DockStartAxisName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("DockStartAxisName", value);
				if (this.DockStartAxisName != value)
				{
					this.m_DockStartAxisName = value;
					this.m_CachedDockStartAxis = null;
					this.m_CachedDockStartAxis = this.DockStartAxis;
					base.DoPropertyChange(this, "DockStartAxisName");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string DockStopAxisName
		{
			get
			{
				return this.m_DockStopAxisName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("DockStopAxisName", value);
				if (this.DockStopAxisName != value)
				{
					this.m_DockStopAxisName = value;
					this.m_CachedDockStopAxis = null;
					this.m_CachedDockStopAxis = this.DockStopAxis;
					base.DoPropertyChange(this, "DockStopAxisName");
				}
			}
		}

		[Description("")]
		public PlotAxis DockStartAxis
		{
			get
			{
				if (this.m_CachedDockStartAxis != null)
				{
					return this.m_CachedDockStartAxis;
				}
				if (base.Plot == null)
				{
					return null;
				}
				this.m_CachedDockStartAxis = base.Plot.XAxes[this.m_DockStartAxisName];
				if (this.m_CachedDockStartAxis == null)
				{
					this.m_CachedDockStartAxis = base.Plot.YAxes[this.m_DockStartAxisName];
				}
				return this.m_CachedDockStartAxis;
			}
		}

		[Description("")]
		public PlotAxis DockStopAxis
		{
			get
			{
				if (this.m_CachedDockStopAxis != null)
				{
					return this.m_CachedDockStopAxis;
				}
				if (base.Plot == null)
				{
					return null;
				}
				this.m_CachedDockStopAxis = base.Plot.XAxes[this.m_DockStopAxisName];
				if (this.m_CachedDockStopAxis == null)
				{
					this.m_CachedDockStopAxis = base.Plot.YAxes[this.m_DockStopAxisName];
				}
				return this.m_CachedDockStopAxis;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		private bool CartesianEnabled
		{
			get
			{
				return this.m_CartesianEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("CartesianEnabled", value);
				if (this.CartesianEnabled != value)
				{
					this.m_CartesianEnabled = value;
					base.DoPropertyChange(this, "CartesianEnabled");
				}
			}
		}

		public override bool DocksToDataView => this.DockStyle == PlotDockStyleAxis.DataView;

		public override bool DocksToPlot => false;

		protected override string GetPlugInTitle()
		{
			return "Layout";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLayoutAxisEditorPlugIn";
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.DockStyle = PlotDockStyleAxis.DataView;
			this.DockStackingEndsMargin = 0.25;
			this.DockForceStacking = false;
			this.DockStartStyle = PlotDockStartStopStyleDockableAxis.Percent;
			this.DockStopStyle = PlotDockStartStopStyleDockableAxis.Percent;
			this.DockStartAxisName = "Axis 1";
			this.DockStopAxisName = "Axis 1";
			this.CartesianEnabled = false;
		}

		private bool ShouldSerializeDockStyle()
		{
			return base.PropertyShouldSerialize("DockStyle");
		}

		private void ResetDockStyle()
		{
			base.PropertyReset("DockStyle");
		}

		private bool ShouldSerializeDockStackingEndsMargin()
		{
			return base.PropertyShouldSerialize("DockStackingEndsMargin");
		}

		private void ResetDockStackingEndsMargin()
		{
			base.PropertyReset("DockStackingEndsMargin");
		}

		private bool ShouldSerializeDockForceStacking()
		{
			return base.PropertyShouldSerialize("DockForceStacking");
		}

		private void ResetDockForceStacking()
		{
			base.PropertyReset("DockForceStacking");
		}

		private bool ShouldSerializeDockStartStyle()
		{
			return base.PropertyShouldSerialize("DockStartStyle");
		}

		private void ResetDockStartStyle()
		{
			base.PropertyReset("DockStartStyle");
		}

		private bool ShouldSerializeDockStopStyle()
		{
			return base.PropertyShouldSerialize("DockStopStyle");
		}

		private void ResetDockStopStyle()
		{
			base.PropertyReset("DockStopStyle");
		}

		private bool ShouldSerializeDockStartAxisName()
		{
			return base.PropertyShouldSerialize("DockStartAxisName");
		}

		private void ResetDockStartAxisName()
		{
			base.PropertyReset("DockStartAxisName");
		}

		private bool ShouldSerializeDockStopAxisName()
		{
			return base.PropertyShouldSerialize("DockStopAxisName");
		}

		private void ResetDockStopAxisName()
		{
			base.PropertyReset("DockStopAxisName");
		}

		private bool ShouldSerializeCartesianEnabled()
		{
			return base.PropertyShouldSerialize("CartesianEnabled");
		}

		private void ResetCartesianEnabled()
		{
			base.PropertyReset("CartesianEnabled");
		}

		public override void ObjectRenamed(PlotObject value, string oldName)
		{
			base.ObjectRenamed(value, oldName);
			if (value is PlotAxis && oldName == this.m_DockStartAxisName)
			{
				this.m_DockStartAxisName = value.Name;
			}
			else if (value is PlotAxis && oldName == this.m_DockStopAxisName)
			{
				this.m_DockStopAxisName = value.Name;
			}
		}

		public override void ObjectRemoved(PlotObject value)
		{
			base.ObjectRemoved(value);
			if (value == this.m_CachedDockStartAxis)
			{
				this.m_CachedDockStartAxis = null;
			}
			else if (value == this.m_CachedDockStopAxis)
			{
				this.m_CachedDockStopAxis = null;
			}
		}

		public override void ObjectAdded(PlotObject value)
		{
			base.ObjectAdded(value);
			if (value is PlotAxis && value.Name == this.m_DockStartAxisName)
			{
				this.m_CachedDockStartAxis = (value as PlotAxis);
			}
			else if (value is PlotAxis && value.Name == this.m_DockStopAxisName)
			{
				this.m_CachedDockStopAxis = (value as PlotAxis);
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (base.DockDataView == null)
			{
				base.CanDraw = false;
			}
			else if (!base.DockDataView.Visible)
			{
				base.CanDraw = false;
			}
		}
	}
}
