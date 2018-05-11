using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor Base.")]
	public abstract class PlotDataCursorBase : PlotXYAxisReferenceBase, IPlotDataCursorBase
	{
		private PlotPen m_Line;

		protected IPlotPen I_Line;

		private PlotDataCursorHint m_Hint;

		protected IPlotDataCursorHint I_Hint;

		private PlotDataCursorWindow m_Window;

		protected IPlotDataCursorWindow I_Window;

		private PlotDataCursorPointer m_Pointer1;

		protected IPlotDataCursorPointer I_Pointer1;

		private PlotDataCursorPointer m_Pointer2;

		protected IPlotDataCursorPointer I_Pointer2;

		private PlotDataCursorDisplayCollection m_Displays;

		private bool m_WindowShowing;

		private bool m_YIsInterpolated;

		private bool m_SnapToPoint;

		private bool m_HideHintOnDrag;

		private bool m_MasterControl;

		private int m_HitRegionSize;

		PlotDataCursorDisplayCollection IPlotDataCursorBase.Displays
		{
			get
			{
				return this.Displays;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotPen Line
		{
			get
			{
				return this.m_Line;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotDataCursorHint Hint
		{
			get
			{
				return this.m_Hint;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotDataCursorWindow Window
		{
			get
			{
				return this.m_Window;
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

		protected bool SnapToPoint
		{
			get
			{
				return this.m_SnapToPoint;
			}
			set
			{
				base.PropertyUpdateDefault("SnapToPoint", value);
				if (this.SnapToPoint != value)
				{
					this.m_SnapToPoint = value;
					base.DoPropertyChange(this, "SnapToPoint");
				}
			}
		}

		protected bool HideHintOnDrag
		{
			get
			{
				return this.m_HideHintOnDrag;
			}
			set
			{
				base.PropertyUpdateDefault("HideHintOnDrag", value);
				if (this.HideHintOnDrag != value)
				{
					this.m_HideHintOnDrag = value;
					base.DoPropertyChange(this, "HideHintOnDrag");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int HitRegionSize
		{
			get
			{
				return this.m_HitRegionSize;
			}
			set
			{
				base.PropertyUpdateDefault("HitRegionSize", value);
				if (this.HitRegionSize != value)
				{
					this.m_HitRegionSize = value;
					base.DoPropertyChange(this, "HitRegionSize");
				}
			}
		}

		[Description("")]
		public bool MasterControl
		{
			get
			{
				return this.m_MasterControl;
			}
			set
			{
				base.PropertyUpdateDefault("MasterControl", value);
				if (this.MasterControl != value)
				{
					this.m_MasterControl = value;
					base.DoPropertyChange(this, "MasterControl");
				}
			}
		}

		public PlotDataCursorDisplayCollection Displays => this.m_Displays;

		public PlotDataCursorPointer Pointer1 => this.m_Pointer1;

		public PlotDataCursorPointer Pointer2 => this.m_Pointer2;

		public bool WindowShowing => this.m_WindowShowing;

		protected bool YIsInterpolated
		{
			get
			{
				return this.m_YIsInterpolated;
			}
			set
			{
				this.m_YIsInterpolated = value;
			}
		}

		private Color SolidColor => this.Color;

		private Color HatchForeColor => this.Color;

		private Color HatchBackColor
		{
			get
			{
				if (this.ControlBase != null)
				{
					return this.ControlBase.BackColor;
				}
				return Color.Empty;
			}
		}

		public event PlotDataCursorCustomizeHintTextEventHandler CustomizeHintText;

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Line = new PlotPen();
			base.AddSubClass(this.Line);
			this.I_Line = this.Line;
			this.m_Hint = new PlotDataCursorHint(this);
			base.AddSubClass(this.Hint);
			this.I_Hint = this.Hint;
			this.m_Window = new PlotDataCursorWindow(this);
			base.AddSubClass(this.Window);
			this.I_Window = this.Window;
			this.m_Pointer1 = new PlotDataCursorPointer(this);
			base.AddSubClass(this.Pointer1);
			this.I_Pointer1 = this.Pointer1;
			this.m_Pointer2 = new PlotDataCursorPointer(this);
			base.AddSubClass(this.Pointer2);
			this.I_Pointer2 = this.Pointer2;
			this.m_Displays = new PlotDataCursorDisplayCollection();
			((ISubClassBase)this.Line).ColorAmbientSource = AmbientColorSouce.Color;
			this.m_Pointer1.PropertyChanged += this.m_Pointer_PropertyChanged;
			this.m_Pointer2.PropertyChanged += this.m_Pointer_PropertyChanged;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Visible = false;
			this.Color = Color.Red;
			this.HitRegionSize = 5;
			base.ClippingStyle = PlotClippingStyle.DataView;
			this.MasterControl = false;
		}

		private bool ShouldSerializeLine()
		{
			return ((ISubClassBase)this.Line).ShouldSerialize();
		}

		private void ResetLine()
		{
			((ISubClassBase)this.Line).ResetToDefault();
		}

		private bool ShouldSerializeHint()
		{
			return ((ISubClassBase)this.Hint).ShouldSerialize();
		}

		private void ResetHint()
		{
			((ISubClassBase)this.Hint).ResetToDefault();
		}

		private bool ShouldSerializeWindow()
		{
			return ((ISubClassBase)this.Window).ShouldSerialize();
		}

		private void ResetWindow()
		{
			((ISubClassBase)this.Window).ResetToDefault();
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeHitRegionSize()
		{
			return base.PropertyShouldSerialize("HitRegionSize");
		}

		private void ResetHitRegionSize()
		{
			base.PropertyReset("HitRegionSize");
		}

		private bool ShouldSerializeMasterControl()
		{
			return base.PropertyShouldSerialize("MasterControl");
		}

		private void ResetMasterControl()
		{
			base.PropertyReset("MasterControl");
		}

		protected override bool InternalHitTest(MouseEventArgs e)
		{
			if (base.Plot == null)
			{
				return false;
			}
			if (base.Plot.ToolBarAdapter.DataViewMouseMode != PlotDataViewMouseMode.DataCursor)
			{
				return false;
			}
			if (this.I_Pointer1.HitRegion != null && this.I_Pointer1.HitRegion.IsVisible((float)e.X, (float)e.Y))
			{
				return true;
			}
			if (this.I_Pointer2.HitRegion != null && this.I_Pointer2.HitRegion.IsVisible((float)e.X, (float)e.Y))
			{
				return true;
			}
			if (this.I_Hint.HitRegion != null && this.I_Hint.HitRegion.IsVisible((float)e.X, (float)e.Y))
			{
				return true;
			}
			return false;
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			return Cursors.Hand;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (base.XAxis != null && base.YAxis != null)
			{
				if (this.I_Hint.AxisPosition == null)
				{
					this.I_Hint.AxisPosition = base.YAxis;
				}
				this.I_Pointer1.MouseDownPosition = this.Pointer1.Position;
				this.I_Pointer2.MouseDownPosition = this.Pointer2.Position;
				this.I_Hint.MouseDownPosition = this.Hint.Position;
				this.I_Pointer1.MouseDownActual = this.Pointer1.AxisPosition.GetMousePercent(e.X, e.Y);
				this.I_Pointer2.MouseDownActual = this.Pointer2.AxisPosition.GetMousePercent(e.X, e.Y);
				this.I_Hint.MouseDownActual = this.I_Hint.AxisPosition.GetMousePercent(e.X, e.Y);
				if (shouldFocus)
				{
					base.Focus();
				}
				if (this.I_Hint.HitRegion != null && this.I_Hint.HitRegion.IsVisible((float)e.X, (float)e.Y))
				{
					this.I_Hint.MouseActive = true;
				}
				else
				{
					if (this.I_Pointer1.HitRegion != null && this.I_Pointer1.HitRegion.IsVisible((float)e.X, (float)e.Y))
					{
						this.I_Pointer1.MouseActive = true;
					}
					if (this.I_Pointer1.MouseActive && this.Pointer1.AxisPosition == this.Pointer2.AxisPosition)
					{
						return;
					}
					if (this.I_Pointer2.HitRegion != null && this.I_Pointer2.HitRegion.IsVisible((float)e.X, (float)e.Y))
					{
						this.I_Pointer2.MouseActive = true;
					}
				}
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			if (!this.I_Pointer1.MouseActive && !this.I_Pointer2.MouseActive && !this.I_Hint.MouseActive)
			{
				return;
			}
			this.Pointer1.AxisPosition.GetMousePercent(e.X, e.Y);
			this.Pointer2.AxisPosition.GetMousePercent(e.X, e.Y);
			double mousePercent = this.I_Hint.AxisPosition.GetMousePercent(e.X, e.Y);
			if (this.I_Pointer1.MouseActive)
			{
				base.XAxis.Tracking.Enabled = false;
				base.YAxis.Tracking.Enabled = false;
				double num = Math.Round(this.Pointer1.AxisPosition.GetMousePercent(e.X, e.Y), 8);
				if (num < 0.0)
				{
					num = 0.0;
				}
				if (num > 1.0)
				{
					num = 1.0;
				}
				this.Pointer1.Position = num;
			}
			if (this.I_Pointer2.MouseActive)
			{
				base.XAxis.Tracking.Enabled = false;
				base.YAxis.Tracking.Enabled = false;
				double num = Math.Round(this.Pointer2.AxisPosition.GetMousePercent(e.X, e.Y), 8);
				if (num < 0.0)
				{
					num = 0.0;
				}
				if (num > 1.0)
				{
					num = 1.0;
				}
				this.Pointer2.Position = num;
			}
			if (this.I_Hint.MouseActive)
			{
				this.Hint.Position = this.I_Hint.MouseDownPosition + (mousePercent - this.I_Hint.MouseDownActual);
			}
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			this.I_Pointer1.MouseActive = false;
			this.I_Pointer2.MouseActive = false;
			this.I_Hint.MouseActive = false;
			if (this.SnapToPoint)
			{
				this.DoSnapToPoint();
			}
		}

		protected override void PopulateContextMenu(ContextMenu menu)
		{
			base.PopulateContextMenu(menu);
			MenuItem menuItem = new MenuItem();
			menuItem.Text = "Hide";
			menuItem.Click += this.MenuItemHide_Click;
			menu.MenuItems.Add(menuItem);
		}

		private void MenuItemHide_Click(object sender, EventArgs e)
		{
			this.Visible = false;
		}

		protected abstract void SetupPointers();

		protected void SetupPointersValueXY()
		{
			this.Pointer1.Style = PlotAxisReference.XAxis;
			this.Pointer2.Style = PlotAxisReference.YAxis;
			this.Pointer1.Visible = true;
			this.Pointer2.Visible = true;
		}

		protected void SetupPointersValueX()
		{
			this.Pointer1.Style = PlotAxisReference.XAxis;
			this.Pointer2.Style = PlotAxisReference.YAxis;
			this.Pointer1.Visible = true;
			this.Pointer2.Visible = false;
		}

		protected void SetupPointersValueY()
		{
			this.Pointer1.Style = PlotAxisReference.XAxis;
			this.Pointer2.Style = PlotAxisReference.YAxis;
			this.Pointer1.Visible = false;
			this.Pointer2.Visible = true;
		}

		protected void SetupPointersDeltaX()
		{
			this.Pointer1.Style = PlotAxisReference.XAxis;
			this.Pointer2.Style = PlotAxisReference.XAxis;
			this.Pointer1.Visible = true;
			this.Pointer2.Visible = true;
			if (this.Pointer1.Position == this.Pointer2.Position)
			{
				this.Pointer1.Position = 0.45;
				this.Pointer2.Position = 0.55;
			}
		}

		protected void SetupPointersDeltaY()
		{
			this.Pointer1.Style = PlotAxisReference.YAxis;
			this.Pointer2.Style = PlotAxisReference.YAxis;
			this.Pointer1.Visible = true;
			this.Pointer2.Visible = true;
			if (this.Pointer1.Position == this.Pointer2.Position)
			{
				this.Pointer1.Position = 0.45;
				this.Pointer2.Position = 0.55;
			}
		}

		protected void SetupPointersInverseDeltaX()
		{
			this.Pointer1.Style = PlotAxisReference.XAxis;
			this.Pointer2.Style = PlotAxisReference.XAxis;
			this.Pointer1.Visible = true;
			this.Pointer2.Visible = true;
			if (this.Pointer1.Position == this.Pointer2.Position)
			{
				this.Pointer1.Position = 0.45;
				this.Pointer2.Position = 0.55;
			}
		}

		protected void SetupPointersInverseDeltaY()
		{
			this.Pointer1.Style = PlotAxisReference.YAxis;
			this.Pointer2.Style = PlotAxisReference.YAxis;
			this.Pointer1.Visible = true;
			this.Pointer2.Visible = true;
			if (this.Pointer1.Position == this.Pointer2.Position)
			{
				this.Pointer1.Position = 0.45;
				this.Pointer2.Position = 0.55;
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (!this.Line.Visible)
			{
				base.CanDraw = false;
			}
		}

		protected abstract void HintUpdate(PaintArgs p, PlotDataCursorDisplay display);

		protected abstract void DoPointerLimits();

		protected abstract void UpdateDisplays();

		protected void SnapPointer1To(double xValue)
		{
			if (base.XAxis != null)
			{
				this.Pointer1.Position = base.XAxis.ValueToPercent(xValue);
			}
		}

		protected void SnapPointer2To(double xValue)
		{
			if (base.XAxis != null)
			{
				this.Pointer2.Position = base.XAxis.ValueToPercent(xValue);
			}
		}

		public virtual void DoSnapToPoint()
		{
		}

		private void m_Pointer_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (base.Plot != null)
			{
				if (this.MasterControl && sender == this.m_Pointer1 && e.Name == "Position")
				{
					foreach (PlotDataCursorBase dataCursor in base.Plot.DataCursors)
					{
						if (dataCursor != this)
						{
							dataCursor.Pointer1.Position = (sender as PlotDataCursorPointer).Position;
						}
					}
				}
				if (this.MasterControl && sender == this.m_Pointer2 && e.Name == "Position")
				{
					foreach (PlotDataCursorBase dataCursor2 in base.Plot.DataCursors)
					{
						if (dataCursor2 != this)
						{
							dataCursor2.Pointer2.Position = (sender as PlotDataCursorPointer).Position;
						}
					}
				}
			}
		}

		protected override void DrawSetup(PaintArgs p)
		{
			this.UpdateDisplays();
		}

		protected override void DrawFocusRectangles(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			this.DoPointerLimits();
			if (this.Hint.HideOnRelease && !base.IsMouseDown)
			{
				this.Hint.Hide = true;
			}
			if (this.HideHintOnDrag && base.IsMouseDown && !this.I_Hint.MouseActive)
			{
				this.Hint.Hide = true;
			}
			else
			{
				this.Hint.Hide = false;
			}
			this.m_WindowShowing = this.Window.Visible;
			if (!this.Pointer1.Visible)
			{
				this.m_WindowShowing = false;
			}
			if (this.Pointer1.AxisPosition == this.Pointer2.AxisPosition)
			{
				this.m_WindowShowing = false;
			}
			Pen pen = this.I_Line.GetPen(p);
			this.UpdateDisplays();
			this.I_Pointer1.Draw(p, pen, this.Displays);
			this.I_Pointer2.Draw(p, pen, this.Displays);
			foreach (PlotDataCursorDisplay display in this.Displays)
			{
				Point point = base.GetPoint(this.Pointer1.AxisPosition.PercentToValue(display.XPosition), this.Pointer2.AxisPosition.PercentToValue(display.YPosition));
				if (this.WindowShowing && !display.DisableWindow)
				{
					this.I_Window.Draw(p, point);
				}
				this.HintUpdate(p, display);
				if (this.CustomizeHintText != null)
				{
					PlotDataCursorCustomizeHintTextEventArgs plotDataCursorCustomizeHintTextEventArgs = new PlotDataCursorCustomizeHintTextEventArgs(this, this.Hint.Text);
					this.CustomizeHintText(this, plotDataCursorCustomizeHintTextEventArgs);
					this.Hint.Text = plotDataCursorCustomizeHintTextEventArgs.Text;
				}
				this.I_Hint.Draw(p, display);
			}
		}
	}
}
