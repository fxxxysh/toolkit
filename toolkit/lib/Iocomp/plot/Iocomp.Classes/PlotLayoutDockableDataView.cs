using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Layout Dockable.")]
	public abstract class PlotLayoutDockableDataView : PlotLayoutBase
	{
		private string m_DockDataViewName;

		private double m_DockPercentStart;

		private double m_DockPercentStop;

		private PlotDataView m_CachedDockDataView;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double DockPercentStart
		{
			get
			{
				return this.m_DockPercentStart;
			}
			set
			{
				base.PropertyUpdateDefault("DockPercentStart", value);
				if (value < 0.0)
				{
					base.ThrowStreamingSafeException("DockPercentStart must be in the range of 0-1 (0% to 100%).");
				}
				if (value > 1.0)
				{
					base.ThrowStreamingSafeException("DockPercentStart must be in the range of 0-1 (0% to 100%).");
				}
				if (value < 0.0)
				{
					value = 0.0;
				}
				if (value > 1.0)
				{
					value = 1.0;
				}
				if (this.DockPercentStart != value)
				{
					this.m_DockPercentStart = value;
					base.DoPropertyChange(this, "DockPercentStart");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double DockPercentStop
		{
			get
			{
				return this.m_DockPercentStop;
			}
			set
			{
				base.PropertyUpdateDefault("DockPercentStop", value);
				if (value < 0.0)
				{
					base.ThrowStreamingSafeException("DockPercentStop must be in the range of 0-1 (0% to 100%).");
				}
				if (value > 1.0)
				{
					base.ThrowStreamingSafeException("DockPercentStop must be in the range of 0-1 (0% to 100%).");
				}
				if (value < 0.0)
				{
					value = 0.0;
				}
				if (value > 1.0)
				{
					value = 1.0;
				}
				if (this.DockPercentStop != value)
				{
					this.m_DockPercentStop = value;
					base.DoPropertyChange(this, "DockPercentStop");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string DockDataViewName
		{
			get
			{
				return this.m_DockDataViewName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("DockDataViewName", value);
				if (this.DockDataViewName != value)
				{
					this.m_DockDataViewName = value;
					this.m_CachedDockDataView = null;
					this.m_CachedDockDataView = this.DockDataView;
					base.DoPropertyChange(this, "DockDataViewName");
				}
			}
		}

		[Description("")]
		public bool LayoutFullSize
		{
			get
			{
				if (this.m_DockPercentStart == 0.0)
				{
					return this.m_DockPercentStop == 1.0;
				}
				return false;
			}
		}

		[Description("")]
		[Browsable(false)]
		public PlotDataView DockDataView
		{
			get
			{
				if (this.m_CachedDockDataView != null)
				{
					return this.m_CachedDockDataView;
				}
				if (base.Plot == null)
				{
					return null;
				}
				this.m_CachedDockDataView = base.Plot.DataViews[this.DockDataViewName];
				return this.m_CachedDockDataView;
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.DockPercentStart = 0.0;
			this.DockPercentStop = 1.0;
			this.DockDataViewName = "Data-View 1";
		}

		private bool ShouldSerializeDockPercentStart()
		{
			return base.PropertyShouldSerialize("DockPercentStart");
		}

		private void ResetDockPercentStart()
		{
			base.PropertyReset("DockPercentStart");
		}

		private bool ShouldSerializeDockPercentStop()
		{
			return base.PropertyShouldSerialize("DockPercentStop");
		}

		private void ResetDockPercentStop()
		{
			base.PropertyReset("DockPercentStop");
		}

		private bool ShouldSerializeDockDataViewName()
		{
			return base.PropertyShouldSerialize("DockDataViewName");
		}

		private void ResetDockDataViewName()
		{
			base.PropertyReset("DockDataViewName");
		}

		public override void ObjectRenamed(PlotObject value, string oldName)
		{
			base.ObjectRenamed(value, oldName);
			if (value is PlotDataView && oldName == this.m_DockDataViewName)
			{
				this.m_DockDataViewName = value.Name;
			}
		}

		public override void ObjectRemoved(PlotObject value)
		{
			base.ObjectRemoved(value);
			if (value == this.m_CachedDockDataView)
			{
				this.m_CachedDockDataView = null;
			}
		}

		public override void ObjectAdded(PlotObject value)
		{
			base.ObjectAdded(value);
			if (value is PlotDataView && value.Name == this.m_DockDataViewName)
			{
				this.m_CachedDockDataView = (value as PlotDataView);
			}
		}
	}
}
