using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Layout Dockable Class")]
	public abstract class PlotLayoutDockableAll : PlotLayoutDockableDataView
	{
		private PlotDockStyleAll m_DockStyle;

		private double m_FloatingAbsoluteX;

		private double m_FloatingAbsoluteY;

		private PlotFloatingReferenceStyle m_FloatingReferenceStyle;

		private AlignmentText m_FloatingAlignmentHorizontal;

		private AlignmentText m_FloatingAlignmentVertical;

		private PlotDockAutoSizeAlignment m_DockAutoSizeAlignment;

		private PlotDockStartStopStyleDockableAll m_DockStartStyle;

		private string m_DockStartDataViewName;

		private PlotDockStartStopStyleDockableAll m_DockStopStyle;

		private string m_DockStopDataViewName;

		private PlotDataView m_CachedDockStartDataView;

		private PlotDataView m_CachedDockStopDataView;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotDockStartStopStyleDockableAll DockStartStyle
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
		public PlotDockStartStopStyleDockableAll DockStopStyle
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
		public string DockStartDataViewName
		{
			get
			{
				return this.m_DockStartDataViewName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("DockStartDataViewName", value);
				if (this.DockStartDataViewName != value)
				{
					this.m_DockStartDataViewName = value;
					this.m_CachedDockStartDataView = null;
					this.m_CachedDockStartDataView = this.DockStartDataView;
					base.DoPropertyChange(this, "DockStartDataViewName");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string DockStopDataViewName
		{
			get
			{
				return this.m_DockStopDataViewName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("DockStopDataViewName", value);
				if (this.DockStopDataViewName != value)
				{
					this.m_DockStopDataViewName = value;
					this.m_CachedDockStopDataView = null;
					this.m_CachedDockStopDataView = this.DockStopDataView;
					base.DoPropertyChange(this, "DockStopDataViewName");
				}
			}
		}

		[Description("")]
		public PlotDataView DockStartDataView
		{
			get
			{
				if (this.m_CachedDockStartDataView != null)
				{
					return this.m_CachedDockStartDataView;
				}
				if (base.Plot == null)
				{
					return null;
				}
				this.m_CachedDockStartDataView = base.Plot.DataViews[this.m_DockStartDataViewName];
				return this.m_CachedDockStartDataView;
			}
		}

		[Description("")]
		public PlotDataView DockStopDataView
		{
			get
			{
				if (this.m_CachedDockStopDataView != null)
				{
					return this.m_CachedDockStopDataView;
				}
				if (base.Plot == null)
				{
					return null;
				}
				this.m_CachedDockStopDataView = base.Plot.DataViews[this.m_DockStopDataViewName];
				return this.m_CachedDockStopDataView;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		private AlignmentText FloatingAlignmentVertical
		{
			get
			{
				return this.m_FloatingAlignmentVertical;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		private AlignmentText FloatingAlignmentHorizontal
		{
			get
			{
				return this.m_FloatingAlignmentHorizontal;
			}
		}

		public PlotDockStyleAll DockStyle
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

		private double FloatingAbsoluteX
		{
			get
			{
				return this.m_FloatingAbsoluteX;
			}
			set
			{
				base.PropertyUpdateDefault("FloatingAbsoluteX", value);
				if (this.FloatingAbsoluteX != value)
				{
					this.m_FloatingAbsoluteX = value;
					base.DoPropertyChange(this, "FloatingAbsoluteX");
				}
			}
		}

		private double FloatingAbsoluteY
		{
			get
			{
				return this.m_FloatingAbsoluteY;
			}
			set
			{
				base.PropertyUpdateDefault("FloatingAbsoluteY", value);
				if (this.FloatingAbsoluteY != value)
				{
					this.m_FloatingAbsoluteY = value;
					base.DoPropertyChange(this, "FloatingAbsoluteY");
				}
			}
		}

		private PlotFloatingReferenceStyle FloatingReferenceStyle
		{
			get
			{
				return this.m_FloatingReferenceStyle;
			}
			set
			{
				base.PropertyUpdateDefault("FloatingReferenceStyle", value);
				if (this.FloatingReferenceStyle != value)
				{
					this.m_FloatingReferenceStyle = value;
					base.DoPropertyChange(this, "FloatingReferenceStyle");
				}
			}
		}

		public PlotDockAutoSizeAlignment DockAutoSizeAlignment
		{
			get
			{
				return this.m_DockAutoSizeAlignment;
			}
			set
			{
				base.PropertyUpdateDefault("DockAutoSizeAlignment", value);
				if (this.DockAutoSizeAlignment != value)
				{
					this.m_DockAutoSizeAlignment = value;
					base.DoPropertyChange(this, "DockAutoSizeAlignment");
				}
			}
		}

		public override bool DocksToDataView => this.DockStyle == PlotDockStyleAll.DataView;

		public override bool DocksToPlot => this.DockStyle == PlotDockStyleAll.Plot;

		protected override string GetPlugInTitle()
		{
			return "Layout";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLayoutDockableAllEditorPlugIn";
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_FloatingAlignmentVertical = new AlignmentText();
			base.AddSubClass(this.FloatingAlignmentVertical);
			this.m_FloatingAlignmentHorizontal = new AlignmentText();
			base.AddSubClass(this.FloatingAlignmentHorizontal);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.DockStyle = PlotDockStyleAll.Plot;
			this.DockSide = AlignmentQuadSide.Left;
			this.DockAutoSizeAlignment = PlotDockAutoSizeAlignment.Center;
			this.DockStartStyle = PlotDockStartStopStyleDockableAll.Percent;
			this.DockStopStyle = PlotDockStartStopStyleDockableAll.Percent;
			this.DockStartDataViewName = "Data-View 1";
			this.DockStopDataViewName = "Data-View 1";
			this.FloatingAbsoluteX = 0.0;
			this.FloatingAbsoluteY = 0.0;
			this.FloatingReferenceStyle = PlotFloatingReferenceStyle.Absolute;
			this.FloatingAlignmentHorizontal.Margin = 0.0;
			this.FloatingAlignmentHorizontal.Style = StringAlignment.Near;
			this.FloatingAlignmentVertical.Margin = 0.0;
			this.FloatingAlignmentVertical.Style = StringAlignment.Near;
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

		private bool ShouldSerializeDockStartDataViewName()
		{
			return base.PropertyShouldSerialize("DockStartDataViewName");
		}

		private void ResetDockStartDataViewName()
		{
			base.PropertyReset("DockStartDataViewName");
		}

		private bool ShouldSerializeDockStopDataViewName()
		{
			return base.PropertyShouldSerialize("DockStopDataViewName");
		}

		private void ResetDockStopDataViewName()
		{
			base.PropertyReset("DockStopDataViewName");
		}

		public override void ObjectRenamed(PlotObject value, string oldName)
		{
			base.ObjectRenamed(value, oldName);
			if (value is PlotDataView && oldName == this.m_DockStartDataViewName)
			{
				this.m_DockStartDataViewName = value.Name;
			}
			else if (value is PlotDataView && oldName == this.m_DockStopDataViewName)
			{
				this.m_DockStopDataViewName = value.Name;
			}
		}

		public override void ObjectRemoved(PlotObject value)
		{
			base.ObjectRemoved(value);
			if (value == this.m_CachedDockStartDataView)
			{
				this.m_CachedDockStartDataView = null;
			}
			else if (value == this.m_CachedDockStopDataView)
			{
				this.m_CachedDockStopDataView = null;
			}
		}

		public override void ObjectAdded(PlotObject value)
		{
			base.ObjectAdded(value);
			if (value is PlotDataView && value.Name == this.m_DockStartDataViewName)
			{
				this.m_CachedDockStartDataView = (value as PlotDataView);
			}
			else if (value is PlotDataView && value.Name == this.m_DockStopDataViewName)
			{
				this.m_CachedDockStopDataView = (value as PlotDataView);
			}
		}

		private bool ShouldSerializeFloatingAlignmentVertical()
		{
			return ((ISubClassBase)this.FloatingAlignmentVertical).ShouldSerialize();
		}

		private void ResetFloatingAlignmentVertical()
		{
			((ISubClassBase)this.FloatingAlignmentVertical).ResetToDefault();
		}

		private bool ShouldSerializeFloatingAlignmentHorizontal()
		{
			return ((ISubClassBase)this.FloatingAlignmentHorizontal).ShouldSerialize();
		}

		private void ResetFloatingAlignmentHorizontal()
		{
			((ISubClassBase)this.FloatingAlignmentHorizontal).ResetToDefault();
		}

		private bool ShouldSerializeDockStyle()
		{
			return base.PropertyShouldSerialize("DockStyle");
		}

		private void ResetDockStyle()
		{
			base.PropertyReset("DockStyle");
		}

		private bool ShouldSerializeFloatingAbsoluteX()
		{
			return base.PropertyShouldSerialize("FloatingAbsoluteX");
		}

		private void ResetFloatingAbsoluteX()
		{
			base.PropertyReset("FloatingAbsoluteX");
		}

		private bool ShouldSerializeFloatingAbsoluteY()
		{
			return base.PropertyShouldSerialize("FloatingAbsoluteY");
		}

		private void ResetFloatingAbsoluteY()
		{
			base.PropertyReset("FloatingAbsoluteY");
		}

		private bool ShouldSerializeFloatingReferenceStyle()
		{
			return base.PropertyShouldSerialize("FloatingReferenceStyle");
		}

		private void ResetFloatingReferenceStyle()
		{
			base.PropertyReset("FloatingReferenceStyle");
		}

		private bool ShouldSerializeDockAutoSizeAlignment()
		{
			return base.PropertyShouldSerialize("DockAutoSizeAlignment");
		}

		private void ResetDockAutoSizeAlignment()
		{
			base.PropertyReset("DockAutoSizeAlignment");
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (this.DockStyle == PlotDockStyleAll.DataView)
			{
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

		protected void CalculateBoundsAlignment(int requiredLength)
		{
			int num = base.Bounds.Left;
			int num2 = base.Bounds.Top;
			int right = base.Bounds.Right;
			int bottom = base.Bounds.Bottom;
			if (base.DockHorizontal)
			{
				if (this.DockAutoSizeAlignment == PlotDockAutoSizeAlignment.Near)
				{
					bottom = num2 + requiredLength;
				}
				else if (this.DockAutoSizeAlignment == PlotDockAutoSizeAlignment.Far)
				{
					num2 = base.Bounds.Bottom - requiredLength;
					bottom = base.Bounds.Bottom;
				}
				else if (this.DockAutoSizeAlignment == PlotDockAutoSizeAlignment.Center)
				{
					num2 = (base.Bounds.Top + base.Bounds.Bottom) / 2 - requiredLength / 2;
					bottom = num2 + requiredLength;
				}
			}
			else if (this.DockAutoSizeAlignment == PlotDockAutoSizeAlignment.Near)
			{
				right = num + requiredLength;
			}
			else if (this.DockAutoSizeAlignment == PlotDockAutoSizeAlignment.Far)
			{
				num = base.Bounds.Right - requiredLength;
				right = base.Bounds.Right;
			}
			else if (this.DockAutoSizeAlignment == PlotDockAutoSizeAlignment.Center)
			{
				num = (base.Bounds.Left + base.Bounds.Right) / 2 - requiredLength / 2;
				right = num + requiredLength;
			}
			base.BoundsAlignment = iRectangle.FromLTRB(num, num2, right, bottom);
		}
	}
}
