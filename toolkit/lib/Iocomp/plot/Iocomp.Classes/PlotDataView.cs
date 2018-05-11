using Iocomp.Delegates;
using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Data-View.")]
	public class PlotDataView : PlotLayoutDataView
	{
		private PlotFillGrid m_FillInside;

		private PlotFill m_FillOutside;

		private string m_GridLinesMirrorVertical;

		private string m_GridLinesMirrorHorizontal;

		private bool m_AxesControlEnabled;

		private PlotDataViewAxesControlStyle m_AxesControlMouseStyle;

		private PlotDataViewAxesControlStyle m_AxesControlWheelStyle;

		private PlotDataViewAxesControlStyle m_AxesControlKeyboardStyle;

		private Cursor m_CursorSelectMode;

		private Cursor m_CursorZoomBoxMode;

		private Cursor m_CursorDataCursorMode;

		private int m_ZoomBoxStartX;

		private int m_ZoomBoxStartY;

		private int m_ZoomBoxStopX;

		private int m_ZoomBoxStopY;

		private PlotLayoutBaseCollection m_ZoomBoxAxes;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFillGrid FillInside
		{
			get
			{
				return this.m_FillInside;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill FillOutside
		{
			get
			{
				return this.m_FillOutside;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string GridLinesMirrorVertical
		{
			get
			{
				return this.m_GridLinesMirrorVertical;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				value = value.Trim();
				base.PropertyUpdateDefault("GridLinesMirrorVertical", value);
				if (this.GridLinesMirrorVertical != value)
				{
					this.m_GridLinesMirrorVertical = value;
					base.DoPropertyChange(this, "GridLinesMirrorVertical");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string GridLinesMirrorHorizontal
		{
			get
			{
				return this.m_GridLinesMirrorHorizontal;
			}
			set
			{
				if (value == null)
				{
					value = "";
				}
				value = value.Trim();
				base.PropertyUpdateDefault("GridLinesMirrorHorizontal", value);
				if (this.GridLinesMirrorHorizontal != value)
				{
					this.m_GridLinesMirrorHorizontal = value;
					base.DoPropertyChange(this, "GridLinesMirrorHorizontal");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool AxesControlEnabled
		{
			get
			{
				return this.m_AxesControlEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("AxesControlEnabled", value);
				if (this.AxesControlEnabled != value)
				{
					this.m_AxesControlEnabled = value;
					base.DoPropertyChange(this, "AxesControlEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotDataViewAxesControlStyle AxesControlMouseStyle
		{
			get
			{
				return this.m_AxesControlMouseStyle;
			}
			set
			{
				base.PropertyUpdateDefault("AxesControlMouseStyle", value);
				if (this.AxesControlMouseStyle != value)
				{
					this.m_AxesControlMouseStyle = value;
					base.DoPropertyChange(this, "AxesControlMouseStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotDataViewAxesControlStyle AxesControlWheelStyle
		{
			get
			{
				return this.m_AxesControlWheelStyle;
			}
			set
			{
				base.PropertyUpdateDefault("AxesControlWheelStyle", value);
				if (this.AxesControlWheelStyle != value)
				{
					this.m_AxesControlWheelStyle = value;
					base.DoPropertyChange(this, "AxesControlWheelStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotDataViewAxesControlStyle AxesControlKeyboardStyle
		{
			get
			{
				return this.m_AxesControlKeyboardStyle;
			}
			set
			{
				base.PropertyUpdateDefault("AxesControlKeyboardStyle", value);
				if (this.AxesControlKeyboardStyle != value)
				{
					this.m_AxesControlKeyboardStyle = value;
					base.DoPropertyChange(this, "AxesControlKeyboardStyle");
				}
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		public Cursor CursorSelectMode
		{
			get
			{
				return this.m_CursorSelectMode;
			}
			set
			{
				this.m_CursorSelectMode = value;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		public Cursor CursorZoomBoxMode
		{
			get
			{
				return this.m_CursorZoomBoxMode;
			}
			set
			{
				this.m_CursorZoomBoxMode = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Cursor CursorDataCursorMode
		{
			get
			{
				return this.m_CursorDataCursorMode;
			}
			set
			{
				this.m_CursorDataCursorMode = value;
			}
		}

		[Description("")]
		[Browsable(false)]
		public PlotDataViewMouseMode MouseMode
		{
			get
			{
				if (base.Plot == null)
				{
					return PlotDataViewMouseMode.Select;
				}
				return base.Plot.ToolBarAdapter.DataViewMouseMode;
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

		protected bool AllowAxesControlMouse
		{
			get
			{
				if (!this.AxesControlEnabled)
				{
					return false;
				}
				if (this.AxesControlMouseStyle == PlotDataViewAxesControlStyle.None)
				{
					return false;
				}
				return true;
			}
		}

		protected bool AllowAxesControlMouseX
		{
			get
			{
				if (!this.AxesControlEnabled)
				{
					return false;
				}
				if (this.AxesControlMouseStyle == PlotDataViewAxesControlStyle.XAxes)
				{
					return true;
				}
				if (this.AxesControlMouseStyle == PlotDataViewAxesControlStyle.Both)
				{
					return true;
				}
				return false;
			}
		}

		protected bool AllowAxesControlMouseY
		{
			get
			{
				if (!this.AxesControlEnabled)
				{
					return false;
				}
				if (this.AxesControlMouseStyle == PlotDataViewAxesControlStyle.YAxes)
				{
					return true;
				}
				if (this.AxesControlMouseStyle == PlotDataViewAxesControlStyle.Both)
				{
					return true;
				}
				return false;
			}
		}

		protected bool AllowAxesControlWheel
		{
			get
			{
				if (!this.AxesControlEnabled)
				{
					return false;
				}
				if (this.AxesControlWheelStyle == PlotDataViewAxesControlStyle.None)
				{
					return false;
				}
				return true;
			}
		}

		protected bool AllowAxesControlWheelX
		{
			get
			{
				if (!this.AxesControlEnabled)
				{
					return false;
				}
				if (this.AxesControlWheelStyle == PlotDataViewAxesControlStyle.XAxes)
				{
					return true;
				}
				if (this.AxesControlWheelStyle == PlotDataViewAxesControlStyle.Both)
				{
					return true;
				}
				return false;
			}
		}

		protected bool AllowAxesControlWheelY
		{
			get
			{
				if (!this.AxesControlEnabled)
				{
					return false;
				}
				if (this.AxesControlWheelStyle == PlotDataViewAxesControlStyle.YAxes)
				{
					return true;
				}
				if (this.AxesControlWheelStyle == PlotDataViewAxesControlStyle.Both)
				{
					return true;
				}
				return false;
			}
		}

		protected bool AllowAxesControlKeyboard
		{
			get
			{
				if (!this.AxesControlEnabled)
				{
					return false;
				}
				if (this.AxesControlKeyboardStyle == PlotDataViewAxesControlStyle.None)
				{
					return false;
				}
				return true;
			}
		}

		protected bool AllowAxesControlKeyboardX
		{
			get
			{
				if (!this.AxesControlEnabled)
				{
					return false;
				}
				if (this.AxesControlKeyboardStyle == PlotDataViewAxesControlStyle.XAxes)
				{
					return true;
				}
				if (this.AxesControlKeyboardStyle == PlotDataViewAxesControlStyle.Both)
				{
					return true;
				}
				return false;
			}
		}

		protected bool AllowAxesControlKeyboardY
		{
			get
			{
				if (!this.AxesControlEnabled)
				{
					return false;
				}
				if (this.AxesControlKeyboardStyle == PlotDataViewAxesControlStyle.YAxes)
				{
					return true;
				}
				if (this.AxesControlKeyboardStyle == PlotDataViewAxesControlStyle.Both)
				{
					return true;
				}
				return false;
			}
		}

		public event PlotDataViewZoomBoxEventHandler BeforeZoomBox;

		protected override string GetPlugInTitle()
		{
			return "Data-View";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotDataViewEditorPlugIn";
		}

		public PlotDataView()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_ZoomBoxAxes = new PlotLayoutBaseCollection();
			this.m_FillInside = new PlotFillGrid();
			base.AddSubClass(this.FillInside);
			this.m_FillOutside = new PlotFill();
			base.AddSubClass(this.FillOutside);
			((ISubClassBase)this.FillInside.Pen).ColorAmbientSource = AmbientColorSouce.CustomColor1;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Color = Color.Empty;
			this.GridLinesMirrorVertical = "";
			this.GridLinesMirrorHorizontal = "";
			this.FillInside.Brush.Visible = false;
			this.FillInside.Brush.Style = PlotBrushStyle.Solid;
			this.FillInside.Brush.SolidColor = Color.Empty;
			this.FillInside.Brush.GradientStartColor = Color.Blue;
			this.FillInside.Brush.GradientStopColor = Color.Aqua;
			this.FillInside.Brush.HatchForeColor = Color.Empty;
			this.FillInside.Brush.HatchBackColor = Color.Empty;
			this.FillInside.Pen.Visible = true;
			this.FillInside.Pen.Style = PlotPenStyle.Solid;
			this.FillInside.Pen.Color = Color.Empty;
			this.FillInside.Pen.Thickness = 1.0;
			this.FillOutside.Brush.Visible = false;
			this.FillOutside.Brush.Style = PlotBrushStyle.Solid;
			this.FillOutside.Brush.SolidColor = Color.Empty;
			this.FillOutside.Brush.GradientStartColor = Color.Blue;
			this.FillOutside.Brush.GradientStopColor = Color.Aqua;
			this.FillOutside.Brush.HatchForeColor = Color.Empty;
			this.FillOutside.Brush.HatchBackColor = Color.Empty;
			this.FillOutside.Pen.Visible = false;
			this.FillOutside.Pen.Style = PlotPenStyle.Solid;
			this.FillOutside.Pen.Color = Color.Empty;
			this.FillOutside.Pen.Thickness = 1.0;
			this.AxesControlEnabled = true;
			this.AxesControlMouseStyle = PlotDataViewAxesControlStyle.Both;
			this.AxesControlWheelStyle = PlotDataViewAxesControlStyle.XAxes;
			this.AxesControlKeyboardStyle = PlotDataViewAxesControlStyle.Both;
			this.CursorSelectMode = Cursors.SizeAll;
			this.CursorZoomBoxMode = Cursors.PanSE;
			this.CursorDataCursorMode = Cursors.SizeAll;
		}

		private bool ShouldSerializeFillInside()
		{
			return ((ISubClassBase)this.FillInside).ShouldSerialize();
		}

		private void ResetFillInside()
		{
			((ISubClassBase)this.FillInside).ResetToDefault();
		}

		private bool ShouldSerializeFillOutside()
		{
			return ((ISubClassBase)this.FillOutside).ShouldSerialize();
		}

		private void ResetFillOutside()
		{
			((ISubClassBase)this.FillOutside).ResetToDefault();
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeGridLinesMirrorVertical()
		{
			return base.PropertyShouldSerialize("GridLinesMirrorVertical");
		}

		private void ResetGridLinesMirrorVertical()
		{
			base.PropertyReset("GridLinesMirrorVertical");
		}

		private bool ShouldSerializeGridLinesMirrorHorizontal()
		{
			return base.PropertyShouldSerialize("GridLinesMirrorHorizontal");
		}

		private void ResetGridLinesMirrorHorizontal()
		{
			base.PropertyReset("GridLinesMirrorHorizontal");
		}

		private bool ShouldSerializeAxesControlEnabled()
		{
			return base.PropertyShouldSerialize("AxesControlEnabled");
		}

		private void ResetAxesControlEnabled()
		{
			base.PropertyReset("AxesControlEnabled");
		}

		private bool ShouldSerializeAxesControlMouseStyle()
		{
			return base.PropertyShouldSerialize("AxesControlMouseStyle");
		}

		private void ResetAxesControlMouseStyle()
		{
			base.PropertyReset("AxesControlMouseStyle");
		}

		private bool ShouldSerializeAxesControlWheelStyle()
		{
			return base.PropertyShouldSerialize("AxesControlWheelStyle");
		}

		private void ResetAxesControlWheelStyle()
		{
			base.PropertyReset("AxesControlWheelStyle");
		}

		private bool ShouldSerializeAxesControlKeyboardStyle()
		{
			return base.PropertyShouldSerialize("AxesControlKeyboardStyle");
		}

		private void ResetAxesControlKeyboardStyle()
		{
			base.PropertyReset("AxesControlKeyboardStyle");
		}

		protected virtual void DisableAllTracking()
		{
			if (base.Plot != null)
			{
				foreach (PlotAxis xAxis in base.Plot.XAxes)
				{
					if (base.IsDocked(xAxis))
					{
						xAxis.Tracking.Enabled = false;
					}
				}
				foreach (PlotAxis yAxis in base.Plot.YAxes)
				{
					if (base.IsDocked(yAxis))
					{
						yAxis.Tracking.Enabled = false;
					}
				}
			}
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			if (base.Plot == null)
			{
				return Cursors.Default;
			}
			if (base.Plot.ToolBarAdapter.DataViewMouseMode == PlotDataViewMouseMode.Select)
			{
				return this.CursorSelectMode;
			}
			if (base.Plot.ToolBarAdapter.DataViewMouseMode == PlotDataViewMouseMode.ZoomBox)
			{
				return this.CursorZoomBoxMode;
			}
			if (base.Plot.ToolBarAdapter.DataViewMouseMode == PlotDataViewMouseMode.DataCursor)
			{
				return this.CursorDataCursorMode;
			}
			return Cursors.Default;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (base.Plot != null)
			{
				if (shouldFocus)
				{
					base.Focus();
				}
				if (this.MouseMode == PlotDataViewMouseMode.ZoomBox)
				{
					base.IsMouseActive = true;
					this.m_ZoomBoxStartX = e.X;
					this.m_ZoomBoxStartY = e.Y;
					this.m_ZoomBoxStopX = e.X;
					this.m_ZoomBoxStopY = e.Y;
					this.DisableAllTracking();
					this.m_ZoomBoxAxes.Clear();
					foreach (PlotAxis xAxis in base.Plot.XAxes)
					{
						if (xAxis.Visible && base.IsDocked(xAxis) && xAxis.ValueVisible(xAxis.GetMouseValue(e)))
						{
							this.m_ZoomBoxAxes.Add(xAxis);
						}
					}
					foreach (PlotAxis yAxis in base.Plot.YAxes)
					{
						if (yAxis.Visible && base.IsDocked(yAxis) && yAxis.ValueVisible(yAxis.GetMouseValue(e)))
						{
							this.m_ZoomBoxAxes.Add(yAxis);
						}
					}
				}
				else if (this.AllowAxesControlMouse)
				{
					base.IsMouseActive = true;
					if (this.AllowAxesControlMouseX)
					{
						foreach (PlotAxis xAxis2 in base.Plot.XAxes)
						{
							if (xAxis2.Visible && base.IsDocked(xAxis2))
							{
								((IUIInput)xAxis2).MouseLeft(e, false);
							}
						}
					}
					if (this.AllowAxesControlMouseY)
					{
						foreach (PlotAxis yAxis2 in base.Plot.YAxes)
						{
							if (yAxis2.Visible && base.IsDocked(yAxis2))
							{
								((IUIInput)yAxis2).MouseLeft(e, false);
							}
						}
					}
				}
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			if (base.Plot != null && base.IsMouseActive)
			{
				if (this.MouseMode == PlotDataViewMouseMode.ZoomBox)
				{
					this.m_ZoomBoxStopX = e.X;
					this.m_ZoomBoxStopY = e.Y;
					base.Plot.UIInvalidate(this);
				}
				else
				{
					foreach (PlotAxis xAxis in base.Plot.XAxes)
					{
						if (xAxis.Visible && base.IsDocked(xAxis))
						{
							((IUIInput)xAxis).MouseMove(e);
						}
					}
					foreach (PlotAxis yAxis in base.Plot.YAxes)
					{
						if (yAxis.Visible && base.IsDocked(yAxis))
						{
							((IUIInput)yAxis).MouseMove(e);
						}
					}
				}
			}
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			if (base.Plot != null)
			{
				if (this.MouseMode == PlotDataViewMouseMode.ZoomBox)
				{
					if (base.IsMouseActive && Math2.Delta(this.m_ZoomBoxStartX, this.m_ZoomBoxStopX) >= 3 && Math2.Delta(this.m_ZoomBoxStartY, this.m_ZoomBoxStopY) >= 3)
					{
						Rectangle r = iRectangle.FromLTRB(this.m_ZoomBoxStartX, this.m_ZoomBoxStartY, this.m_ZoomBoxStopX, this.m_ZoomBoxStopY);
						if (this.BeforeZoomBox != null)
						{
							PlotDataViewZoomBoxEventArgs plotDataViewZoomBoxEventArgs = new PlotDataViewZoomBoxEventArgs(this, r);
							this.BeforeZoomBox(this, plotDataViewZoomBoxEventArgs);
							if (plotDataViewZoomBoxEventArgs.Cancel)
							{
								return;
							}
						}
						this.DisableAllTracking();
						foreach (PlotAxis zoomBoxAxis in this.m_ZoomBoxAxes)
						{
							zoomBoxAxis.Zoom(r);
						}
					}
				}
				else
				{
					base.IsMouseActive = false;
					foreach (PlotAxis xAxis in base.Plot.XAxes)
					{
						if (xAxis.Visible && base.IsDocked(xAxis))
						{
							((IUIInput)xAxis).MouseUp(e);
						}
					}
					foreach (PlotAxis yAxis in base.Plot.YAxes)
					{
						if (yAxis.Visible && base.IsDocked(yAxis))
						{
							((IUIInput)yAxis).MouseUp(e);
						}
					}
				}
			}
		}

		protected override void InternalOnMouseWheel(MouseEventArgs e)
		{
			if (this.MouseMode != PlotDataViewMouseMode.ZoomBox && this.AllowAxesControlWheel)
			{
				if (this.AllowAxesControlWheelX)
				{
					foreach (PlotAxis xAxis in base.Plot.XAxes)
					{
						if (xAxis.Visible && base.IsDocked(xAxis))
						{
							((IUIInput)xAxis).MouseWheel(e);
						}
					}
				}
				if (this.AllowAxesControlWheelY)
				{
					foreach (PlotAxis yAxis in base.Plot.YAxes)
					{
						if (yAxis.Visible && base.IsDocked(yAxis))
						{
							((IUIInput)yAxis).MouseWheel(e);
						}
					}
				}
			}
		}

		protected override void InternalOnKeyDown(KeyEventArgs e)
		{
			if (this.MouseMode != PlotDataViewMouseMode.ZoomBox && this.AllowAxesControlKeyboard)
			{
				if (this.AllowAxesControlKeyboardX)
				{
					foreach (PlotAxis xAxis in base.Plot.XAxes)
					{
						if (xAxis.Visible && base.IsDocked(xAxis))
						{
							((IUIInput)xAxis).KeyDown(e);
						}
					}
				}
				if (this.AllowAxesControlKeyboardY)
				{
					foreach (PlotAxis yAxis in base.Plot.YAxes)
					{
						if (yAxis.Visible && base.IsDocked(yAxis))
						{
							((IUIInput)yAxis).KeyDown(e);
						}
					}
				}
			}
		}

		protected override void DrawBackgroundLayer1(PaintArgs p)
		{
			((IPlotFill)this.FillOutside).Draw(p, base.Bounds);
			((IPlotFill)this.FillInside).Draw(p, base.BoundsClip);
		}

		protected override void Draw(PaintArgs p)
		{
		}

		protected override void DrawFocusRectangles(PaintArgs p)
		{
			if (base.Focused)
			{
				p.Graphics.DrawFocusRectangle(base.Bounds, base.BackColor);
			}
			if (this.MouseMode == PlotDataViewMouseMode.ZoomBox && base.IsMouseActive)
			{
				p.Graphics.DrawFocusRectangle(iRectangle.FromLTRB(this.m_ZoomBoxStartX, this.m_ZoomBoxStartY, this.m_ZoomBoxStopX, this.m_ZoomBoxStopY), base.BackColor);
			}
		}
	}
}
