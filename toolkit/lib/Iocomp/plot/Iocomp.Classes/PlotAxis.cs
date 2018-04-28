using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Base Class for Plot Axes")]
	public abstract class PlotAxis : PlotLayoutAxis
	{
		private ScaleDisplayLinear m_ScaleDisplay;

		private IScaleDisplayLinear I_Display;

		private ScaleRangeLinear m_ScaleRange;

		protected PlotAxisTracking m_Tracking;

		private PlotAxisGridLines m_GridLines;

		private IPlotAxisGridLines I_GridLines;

		private PlotTitle m_Title;

		private IPlotTitle I_Title;

		private double m_CursorScaler;

		private bool m_ControlKeyToggleEnabled;

		private bool m_MasterUI;

		private bool m_MasterUISlave;

		private bool m_ClipToMinMax;

		private static bool m_MasterUIBlock;

		private double m_MouseDownPos;

		private double m_MouseDownMin;

		private double m_MouseDownMax;

		private double m_MouseDownSpan;

		private int m_MouseDownPixels;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public new Color Color
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.PropertyUpdateDefault("Color", value);
				base.ForeColor = value;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Iocomp")]
		public ScaleRangeLinear ScaleRange
		{
			get
			{
				return this.m_ScaleRange;
			}
		}

		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public ScaleDisplayLinear ScaleDisplay
		{
			get
			{
				return this.m_ScaleDisplay;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Iocomp")]
		public PlotAxisTracking Tracking
		{
			get
			{
				return this.m_Tracking;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		[Category("Iocomp")]
		public PlotAxisGridLines GridLines
		{
			get
			{
				return this.m_GridLines;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		[Category("Iocomp")]
		public PlotTitle Title
		{
			get
			{
				return this.m_Title;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public TextFormatDoubleAll TextFormatting
		{
			get
			{
				return this.ScaleDisplay.TextFormatting;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public double Span
		{
			get
			{
				return this.ScaleRange.Span;
			}
			set
			{
				this.ScaleRange.Span = value;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public double Min
		{
			get
			{
				return this.ScaleRange.Min;
			}
			set
			{
				this.ScaleRange.Min = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		[Category("Iocomp")]
		public double Max
		{
			get
			{
				return this.ScaleRange.Max;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double Mid
		{
			get
			{
				return this.ScaleRange.Mid;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public ScaleType ScaleType
		{
			get
			{
				return this.ScaleRange.ScaleType;
			}
			set
			{
				this.ScaleRange.ScaleType = value;
			}
		}

		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool Reverse
		{
			get
			{
				return this.ScaleRange.Reverse;
			}
			set
			{
				this.ScaleRange.Reverse = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public override string TitleText
		{
			get
			{
				return this.Title.Text;
			}
			set
			{
				this.Title.Text = value;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ControlKeyToggleEnabled
		{
			get
			{
				return this.m_ControlKeyToggleEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("ControlKeyToggleEnabled", value);
				if (this.ControlKeyToggleEnabled != value)
				{
					this.m_ControlKeyToggleEnabled = value;
					base.DoPropertyChange(this, "ControlKeyToggleEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public bool MasterUI
		{
			get
			{
				return this.m_MasterUI;
			}
			set
			{
				base.PropertyUpdateDefault("MasterUI", value);
				if (this.MasterUI != value)
				{
					this.m_MasterUI = value;
					base.DoPropertyChange(this, "MasterUI");
				}
			}
		}

		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool MasterUISlave
		{
			get
			{
				return this.m_MasterUISlave;
			}
			set
			{
				base.PropertyUpdateDefault("MasterUISlave", value);
				if (this.MasterUISlave != value)
				{
					this.m_MasterUISlave = value;
					base.DoPropertyChange(this, "MasterUISlave");
				}
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ClipToMinMax
		{
			get
			{
				return this.m_ClipToMinMax;
			}
			set
			{
				base.PropertyUpdateDefault("ClipToMinMax", value);
				if (this.ClipToMinMax != value)
				{
					this.m_ClipToMinMax = value;
					base.DoPropertyChange(this, "ClipToMinMax");
				}
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public int DataViewPixelsMax
		{
			get
			{
				if (base.DockDataView == null)
				{
					return this.ScaleDisplay.PixelsMax;
				}
				if (base.DockVertical)
				{
					return base.DockDataView.BoundsClip.Right;
				}
				return base.DockDataView.BoundsClip.Bottom;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		[Category("Iocomp")]
		public int DataViewPixelsMin
		{
			get
			{
				if (base.DockDataView == null)
				{
					return this.ScaleDisplay.PixelsMin;
				}
				if (base.DockVertical)
				{
					return base.DockDataView.BoundsClip.Left;
				}
				return base.DockDataView.BoundsClip.Top;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public double CursorScaler
		{
			get
			{
				return this.m_CursorScaler;
			}
			set
			{
				base.PropertyUpdateDefault("CursorScaler", value);
				if (this.CursorScaler != value)
				{
					this.m_CursorScaler = value;
					base.DoPropertyChange(this, "CursorScaler");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Category("Iocomp")]
		[Description("")]
		public PlotAxisMouseMode MouseMode
		{
			get
			{
				if (base.Plot == null)
				{
					return PlotAxisMouseMode.Scroll;
				}
				PlotAxisMouseMode axisMouseMode = base.Plot.ToolBarAdapter.AxisMouseMode;
				if (this.ControlKeyToggleEnabled && Control.ModifierKeys == Keys.Control)
				{
					if (axisMouseMode == PlotAxisMouseMode.Scroll)
					{
						return PlotAxisMouseMode.Zoom;
					}
					return PlotAxisMouseMode.Scroll;
				}
				return axisMouseMode;
			}
		}

		[Description("Returns the number of pixels the text overlaps the ends of the scale")]
		[Category("Iocomp")]
		public int ScaleTextOverlapPixels
		{
			get
			{
				return this.ScaleDisplay.TextOverlapPixels;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		public override int DockMargin
		{
			get
			{
				return this.ScaleDisplay.Margin;
			}
			set
			{
				base.DockMargin = value;
				this.ScaleDisplay.Margin = value;
			}
		}

		public override AlignmentQuadSide DockSide
		{
			get
			{
				return base.DockSide;
			}
			set
			{
				base.DockSide = value;
				if (this.DockSide == AlignmentQuadSide.Left)
				{
					this.ScaleDisplay.Direction = SideDirection.RightToLeft;
					this.I_Display.Orientation = Orientation.Vertical;
				}
				else if (this.DockSide == AlignmentQuadSide.Right)
				{
					this.ScaleDisplay.Direction = SideDirection.LeftToRight;
					this.I_Display.Orientation = Orientation.Vertical;
				}
				else if (this.DockSide == AlignmentQuadSide.Top)
				{
					this.ScaleDisplay.Direction = SideDirection.RightToLeft;
					this.I_Display.Orientation = Orientation.Horizontal;
				}
				else if (this.DockSide == AlignmentQuadSide.Bottom)
				{
					this.ScaleDisplay.Direction = SideDirection.LeftToRight;
					this.I_Display.Orientation = Orientation.Horizontal;
				}
			}
		}

		protected Color SolidColor
		{
			get
			{
				if (this.ControlBase != null)
				{
					return this.ControlBase.ForeColor;
				}
				return Color.Empty;
			}
		}

		protected Color HatchForeColor
		{
			get
			{
				if (this.ControlBase != null)
				{
					return this.ControlBase.ForeColor;
				}
				return Color.Empty;
			}
		}

		protected Color HatchBackColor
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

		protected override string GetPlugInTitle()
		{
			return "Plot Axis";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotAxisEditorPlugIn";
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_ScaleRange = new ScaleRangeLinear();
			base.AddSubClass(this.ScaleRange);
			this.m_ScaleDisplay = new ScaleDisplayLinear();
			base.AddSubClass(this.ScaleDisplay);
			this.I_Display = this.ScaleDisplay;
			this.m_Tracking = new PlotAxisTracking();
			base.AddSubClass(this.Tracking);
			this.m_GridLines = new PlotAxisGridLines();
			base.AddSubClass(this.GridLines);
			this.I_GridLines = this.GridLines;
			this.m_Title = new PlotTitle();
			base.AddSubClass(this.Title);
			this.I_Title = this.Title;
			PlotAxis.m_MasterUIBlock = false;
			((IPlotObjectSubClass)this.Tracking).Owner = this;
			((IScaleDisplay)this.ScaleDisplay).Range = this.m_ScaleRange;
			((ISubClassBase)this.ScaleDisplay).ColorAmbientSource = AmbientColorSouce.ForeColor;
			((ISubClassBase)this.GridLines).ColorAmbientSource = AmbientColorSouce.CustomColor1;
			((ISubClassBase)this.GridLines.Major).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.GridLines.Mid).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.GridLines.Minor).ColorAmbientSource = AmbientColorSouce.Color;
			base.ColorAmbientSource = AmbientColorSouce.ForeColor;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Color = Color.Empty;
			this.CursorScaler = 1.0;
			this.ControlKeyToggleEnabled = true;
			this.MasterUI = false;
			this.MasterUISlave = true;
			this.ClipToMinMax = false;
			this.ScaleRange.Span = 100.0;
			this.ScaleRange.Min = 0.0;
			this.ScaleRange.Reverse = false;
			this.ScaleDisplay.GeneratorAuto.DesiredIncrement = 0.0;
			this.ScaleDisplay.GeneratorAuto.MinTextSpacing = 1.0;
			this.ScaleDisplay.GeneratorAuto.MinorCount = 4;
			this.ScaleDisplay.GeneratorAuto.MidIncluded = false;
			this.ScaleDisplay.GeneratorFixed.MinorCount = 4;
			this.ScaleDisplay.GeneratorFixed.MidIncluded = false;
			this.ScaleDisplay.GeneratorFixed.MajorCount = 6;
			this.ScaleDisplay.AntiAliasEnabled = false;
			this.ScaleDisplay.GeneratorStyle = ScaleGeneratorStyle.Auto;
			this.ScaleDisplay.Direction = SideDirection.LeftToRight;
			this.ScaleDisplay.Margin = 3;
			this.ScaleDisplay.StartRefValue = 0.0;
			this.ScaleDisplay.StartRefEnabled = false;
			this.ScaleDisplay.TextRotation = TextRotation.X000;
			this.ScaleDisplay.TextAlignment = StringAlignment.Near;
			this.ScaleDisplay.TextWidthMinValue = 6.0;
			this.ScaleDisplay.TextWidthMinAuto = false;
			this.ScaleDisplay.LineInnerVisible = true;
			this.ScaleDisplay.LineOuterVisible = false;
			this.ScaleDisplay.Visible = true;
			this.ScaleDisplay.TextFormatting.Precision = 1;
			this.ScaleDisplay.TextFormatting.PrecisionStyle = PrecisionStyle.FixedDecimalPoints;
			this.ScaleDisplay.TextFormatting.UnitsText = "";
			this.ScaleDisplay.TextFormatting.Style = TextFormatDoubleStyle.Number;
			this.ScaleDisplay.TextFormatting.DateTimeFormat = "hh:mm:ss";
			this.ScaleDisplay.TickMinor.Alignment = AlignmentStyle.Near;
			this.ScaleDisplay.TickMinor.Length = 3;
			this.ScaleDisplay.TickMinor.Color = Color.Empty;
			this.ScaleDisplay.TickMinor.Thickness = 1;
			this.ScaleDisplay.TickMid.Length = 5;
			this.ScaleDisplay.TickMid.Font = null;
			this.ScaleDisplay.TickMid.ForeColor = Color.Empty;
			this.ScaleDisplay.TickMid.TextVisible = true;
			this.ScaleDisplay.TickMid.TextMargin = 2;
			this.ScaleDisplay.TickMid.Alignment = AlignmentStyle.Near;
			this.ScaleDisplay.TickMid.Color = Color.Empty;
			this.ScaleDisplay.TickMid.Thickness = 1;
			this.ScaleDisplay.TickMajor.Length = 10;
			this.ScaleDisplay.TickMajor.Font = null;
			this.ScaleDisplay.TickMajor.ForeColor = Color.Empty;
			this.ScaleDisplay.TickMajor.TextVisible = true;
			this.ScaleDisplay.TickMajor.TextMargin = 2;
			this.ScaleDisplay.TickMajor.Color = Color.Empty;
			this.ScaleDisplay.TickMajor.Thickness = 1;
			this.Tracking.Enabled = true;
			this.Tracking.ExpandStyle = PlotTrackingExpandStyle.Minimum;
			this.Tracking.ScrollCompressMax = 0.0;
			this.Tracking.RestoreValuesOnResume = true;
			this.Title.Visible = false;
			this.Title.Color = Color.Empty;
			this.Title.Font = null;
			this.Title.ForeColor = Color.Empty;
			this.Title.MarginSpacing = 0.5;
			this.Title.MarginOuter = 0.0;
			this.Title.Text = "Label";
			this.Title.TextRotation = PlotAutoRotation.Auto;
			this.Title.TextLayout.Trimming = StringTrimming.None;
			this.Title.TextLayout.LineLimit = false;
			this.Title.TextLayout.MeasureTrailingSpaces = false;
			this.Title.TextLayout.NoWrap = false;
			this.Title.TextLayout.NoClip = false;
			this.Title.TextLayout.AlignmentHorizontal.Style = StringAlignment.Center;
			this.Title.TextLayout.AlignmentHorizontal.Margin = 0.5;
			this.Title.TextLayout.AlignmentVertical.Style = StringAlignment.Center;
			this.Title.TextLayout.AlignmentVertical.Margin = 0.5;
			this.Title.Fill.Visible = false;
			this.Title.Fill.Brush.Visible = true;
			this.Title.Fill.Brush.Style = PlotBrushStyle.Solid;
			this.Title.Fill.Brush.SolidColor = Color.Empty;
			this.Title.Fill.Brush.GradientStartColor = Color.Blue;
			this.Title.Fill.Brush.GradientStopColor = Color.Aqua;
			this.Title.Fill.Brush.HatchForeColor = Color.Empty;
			this.Title.Fill.Brush.HatchBackColor = Color.Empty;
			this.Title.Fill.Pen.Visible = true;
			this.Title.Fill.Pen.Color = Color.Empty;
			this.Title.Fill.Pen.Thickness = 1.0;
			this.Title.Fill.Pen.Style = PlotPenStyle.Solid;
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeScaleRange()
		{
			return ((ISubClassBase)this.ScaleRange).ShouldSerialize();
		}

		private void ResetScaleRange()
		{
			((ISubClassBase)this.ScaleRange).ResetToDefault();
		}

		private bool ShouldSerializeScaleDisplay()
		{
			return ((ISubClassBase)this.ScaleDisplay).ShouldSerialize();
		}

		private void ResetScaleDisplay()
		{
			((ISubClassBase)this.ScaleDisplay).ResetToDefault();
		}

		private bool ShouldSerializeTracking()
		{
			return ((ISubClassBase)this.Tracking).ShouldSerialize();
		}

		private void ResetTracking()
		{
			((ISubClassBase)this.Tracking).ResetToDefault();
		}

		private bool ShouldSerializeGridLines()
		{
			return ((ISubClassBase)this.GridLines).ShouldSerialize();
		}

		private void ResetGridLines()
		{
			((ISubClassBase)this.GridLines).ResetToDefault();
		}

		private bool ShouldSerializeTitle()
		{
			return ((ISubClassBase)this.Title).ShouldSerialize();
		}

		private void ResetTitle()
		{
			((ISubClassBase)this.Title).ResetToDefault();
		}

		private bool ShouldSerializeControlKeyToggleEnabled()
		{
			return base.PropertyShouldSerialize("ControlKeyToggleEnabled");
		}

		private void ResetControlKeyToggleEnabled()
		{
			base.PropertyReset("ControlKeyToggleEnabled");
		}

		private bool ShouldSerializeMasterUI()
		{
			return base.PropertyShouldSerialize("MasterUI");
		}

		private void ResetMasterUI()
		{
			base.PropertyReset("MasterUI");
		}

		private bool ShouldSerializeMasterUISlave()
		{
			return base.PropertyShouldSerialize("MasterUISlave");
		}

		private void ResetMasterUISlave()
		{
			base.PropertyReset("MasterUISlave");
		}

		private bool ShouldSerializeClipToMinMax()
		{
			return base.PropertyShouldSerialize("ClipToMinMax");
		}

		private void ResetClipToMinMax()
		{
			base.PropertyReset("ClipToMinMax");
		}

		private bool ShouldSerializeCursorScaler()
		{
			return base.PropertyShouldSerialize("CursorScaler");
		}

		private void ResetCursorScaler()
		{
			base.PropertyReset("CursorScaler");
		}

		private bool ShouldSerializeDockMargin()
		{
			return false;
		}

		private void ResetDockMargin()
		{
		}

		private bool ShouldSerializeDockSide()
		{
			return base.PropertyShouldSerialize("DockSide");
		}

		private void ResetDockSide()
		{
			base.PropertyReset("DockSide");
		}

		private void UpdateBounds()
		{
			if (this.DockSide == AlignmentQuadSide.Left)
			{
				this.I_Display.EdgeRef = base.Bounds.Right;
				this.I_Display.SetClipEnds(base.BoundsClip.Top, base.BoundsClip.Bottom);
				this.I_Display.SetBoundsEnds(base.Bounds.Top, base.Bounds.Bottom);
			}
			else if (this.DockSide == AlignmentQuadSide.Right)
			{
				this.I_Display.EdgeRef = base.Bounds.Left;
				this.I_Display.SetClipEnds(base.BoundsClip.Top, base.BoundsClip.Bottom);
				this.I_Display.SetBoundsEnds(base.Bounds.Top, base.Bounds.Bottom);
			}
			else if (this.DockSide == AlignmentQuadSide.Top)
			{
				this.I_Display.EdgeRef = base.Bounds.Bottom;
				this.I_Display.SetClipEnds(base.BoundsClip.Left, base.BoundsClip.Right);
				this.I_Display.SetBoundsEnds(base.Bounds.Left, base.Bounds.Right);
			}
			else if (this.DockSide == AlignmentQuadSide.Bottom)
			{
				this.I_Display.EdgeRef = base.Bounds.Top;
				this.I_Display.SetClipEnds(base.BoundsClip.Left, base.BoundsClip.Right);
				this.I_Display.SetBoundsEnds(base.Bounds.Left, base.Bounds.Right);
			}
		}

		protected override void OnBoundsChanged(Rectangle r)
		{
			base.OnBoundsChanged(r);
			this.UpdateBounds();
		}

		protected override void OnBoundsClipChanged(Rectangle r)
		{
			base.OnBoundsClipChanged(r);
			this.UpdateBounds();
		}

		protected override void OnDockSideChanged()
		{
			base.OnDockSideChanged();
			this.UpdateBounds();
		}

		protected void ZoomPercent(double refMin, double refSpan, double refMax, double percent)
		{
			if (this.ScaleRange.ScaleType != ScaleType.SplitLinearLog10)
			{
				if (this.ScaleType == ScaleType.Linear)
				{
					double num = refSpan * 1.0 / Math.Pow(10.0, percent);
					double num2 = (refMin + refMax) / 2.0;
					double num3 = num2 - num / 2.0;
					this.ScaleRange.AdjustSpanUsingMidReference(num);
				}
				else
				{
					double num3 = refMin * Math.Pow(10.0, percent);
					double num = refSpan / Math.Pow(10.0, percent);
					this.ScaleRange.SetMinMax(num3, num);
				}
			}
		}

		protected void ScrollPercent(double refMin, double refSpan, double refMax, double percent)
		{
			if (this.ScaleRange.ScaleType != ScaleType.SplitLinearLog10)
			{
				if (this.ScaleType == ScaleType.Linear)
				{
					this.ScaleRange.Min = this.m_MouseDownMin + this.ScaleRange.Span * percent;
				}
				else
				{
					double num = Math.Log10(refMax) - Math.Log10(refMin);
					double min = refMin * Math.Pow(10.0, percent * num);
					double max = refMax * Math.Pow(10.0, percent * num);
					this.ScaleRange.SetMinMax(min, max);
				}
			}
		}

		public virtual void Zoom(double factor)
		{
			if (this.ScaleRange.ScaleType != ScaleType.SplitLinearLog10)
			{
				this.Tracking.Enabled = false;
				if (factor <= 0.0)
				{
					throw new Exception("Zoom Factor must be greater than zero");
				}
				double desiredSpan = this.ScaleRange.Span * factor;
				double mid = this.ScaleRange.Mid;
				this.ScaleRange.AdjustSpanUsingMidReference(desiredSpan);
			}
		}

		public void Scroll(double factor)
		{
			if (this.ScaleRange.ScaleType != ScaleType.SplitLinearLog10)
			{
				this.Tracking.Enabled = false;
				this.ScaleRange.Min = this.ScaleRange.Min + this.ScaleRange.Span * factor;
			}
		}

		public double GetMouseValue(MouseEventArgs e)
		{
			return this.GetMouseValue(e.X, e.Y);
		}

		public double GetMouseValue(Point value)
		{
			return this.GetMouseValue(value.X, value.Y);
		}

		public double GetMouseValue(int x, int y)
		{
			if (base.DockHorizontal)
			{
				return this.ScaleDisplay.PixelsToValue(y);
			}
			return this.ScaleDisplay.PixelsToValue(x);
		}

		public double GetMousePercent(MouseEventArgs e)
		{
			return this.GetMousePercent(e.X, e.Y);
		}

		public double GetMousePercent(Point value)
		{
			return this.GetMousePercent(value.X, value.Y);
		}

		public double GetMousePercent(int x, int y)
		{
			if (base.DockHorizontal)
			{
				return this.ScaleDisplay.PixelsToPercent(y);
			}
			return this.ScaleDisplay.PixelsToPercent(x);
		}

		public void SetSpan(int hours, int minutes, int seconds, int milliseconds)
		{
			this.ScaleRange.SetSpan(hours, minutes, seconds, milliseconds);
		}

		public virtual void Zoom(Rectangle r)
		{
			if (base.DockHorizontal)
			{
				double min;
				double max;
				if (!this.ScaleRange.Reverse)
				{
					min = this.ScaleDisplay.PixelsToValue(r.Bottom);
					max = this.ScaleDisplay.PixelsToValue(r.Top);
				}
				else
				{
					min = this.ScaleDisplay.PixelsToValue(r.Top);
					max = this.ScaleDisplay.PixelsToValue(r.Bottom);
				}
				this.ScaleRange.SetMinMax(min, max);
			}
			else
			{
				double min;
				double max;
				if (!this.ScaleRange.Reverse)
				{
					min = this.ScaleDisplay.PixelsToValue(r.Left);
					max = this.ScaleDisplay.PixelsToValue(r.Right);
				}
				else
				{
					min = this.ScaleDisplay.PixelsToValue(r.Right);
					max = this.ScaleDisplay.PixelsToValue(r.Left);
				}
				this.ScaleRange.SetMinMax(min, max);
			}
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			if (base.Plot == null)
			{
				return Cursors.Default;
			}
			if (this.MouseMode == PlotAxisMouseMode.Scroll)
			{
				if (base.DockVertical)
				{
					return Cursors.Hand;
				}
				return Cursors.Hand;
			}
			if (this.MouseMode == PlotAxisMouseMode.Zoom)
			{
				if (base.DockVertical)
				{
					return Cursors.SizeWE;
				}
				return Cursors.SizeNS;
			}
			return Cursors.Default;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (this.ScaleRange.ScaleType != ScaleType.SplitLinearLog10)
			{
				if (shouldFocus)
				{
					base.Focus();
				}
				base.IsMouseActive = true;
				if (base.DockVertical)
				{
					this.m_MouseDownPixels = e.X;
				}
				else
				{
					this.m_MouseDownPixels = e.Y;
				}
				this.m_MouseDownPos = this.ScaleDisplay.PixelsToValue(this.m_MouseDownPixels);
				this.m_MouseDownMin = this.ScaleRange.Min;
				this.m_MouseDownMax = this.ScaleRange.Max;
				this.m_MouseDownSpan = this.ScaleRange.Span;
				if (this.MasterUI && base.Plot != null && !PlotAxis.m_MasterUIBlock)
				{
					PlotAxis.m_MasterUIBlock = true;
					try
					{
						if (this is PlotXAxis)
						{
							for (int i = 0; i < base.Plot.XAxes.Count; i++)
							{
								if (base.Plot.XAxes[i] != this && (!base.Plot.XAxes[i].MasterUI || base.Plot.XAxes[i].MasterUISlave))
								{
									((IUIInput)base.Plot.XAxes[i]).MouseLeft(e, false);
								}
							}
						}
						else
						{
							for (int j = 0; j < base.Plot.YAxes.Count; j++)
							{
								if (base.Plot.YAxes[j] != this && (!base.Plot.YAxes[j].MasterUI || base.Plot.YAxes[j].MasterUISlave))
								{
									((IUIInput)base.Plot.YAxes[j]).MouseLeft(e, false);
								}
							}
						}
					}
					finally
					{
						PlotAxis.m_MasterUIBlock = false;
					}
				}
			}
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			if (base.IsMouseActive)
			{
				this.Tracking.Enabled = false;
				int num = (!base.DockVertical) ? e.Y : e.X;
				int pixelsSpan = ((IScaleDisplay)this.ScaleDisplay).PixelsSpan;
				int num2 = this.m_MouseDownPixels - num;
				if (base.DockHorizontal)
				{
					num2 = -num2;
				}
				if (this.ScaleRange.Reverse)
				{
					num2 = -num2;
				}
				this.ScaleDisplay.PixelsToValue(num);
				if (this.MouseMode == PlotAxisMouseMode.Scroll)
				{
					this.ScrollPercent(this.m_MouseDownMin, this.m_MouseDownSpan, this.m_MouseDownMax, (double)num2 / (double)pixelsSpan);
				}
				else
				{
					double percent = (!base.DockVertical) ? ((double)(this.m_MouseDownPixels - num) / (double)pixelsSpan) : ((double)(num - this.m_MouseDownPixels) / (double)pixelsSpan);
					this.ZoomPercent(this.m_MouseDownMin, this.m_MouseDownSpan, this.m_MouseDownMax, percent);
				}
				if (this.MasterUI && base.Plot != null && !PlotAxis.m_MasterUIBlock)
				{
					PlotAxis.m_MasterUIBlock = true;
					try
					{
						if (this is PlotXAxis)
						{
							for (int i = 0; i < base.Plot.XAxes.Count; i++)
							{
								if (base.Plot.XAxes[i] != this && (!base.Plot.XAxes[i].MasterUI || base.Plot.XAxes[i].MasterUISlave))
								{
									((IUIInput)base.Plot.XAxes[i]).MouseMove(e);
								}
							}
						}
						else
						{
							for (int j = 0; j < base.Plot.YAxes.Count; j++)
							{
								if (base.Plot.YAxes[j] != this && (!base.Plot.YAxes[j].MasterUI || base.Plot.YAxes[j].MasterUISlave))
								{
									((IUIInput)base.Plot.YAxes[j]).MouseMove(e);
								}
							}
						}
					}
					finally
					{
						PlotAxis.m_MasterUIBlock = false;
					}
				}
			}
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			base.IsMouseActive = false;
			if (this.MasterUI && base.Plot != null && !PlotAxis.m_MasterUIBlock)
			{
				PlotAxis.m_MasterUIBlock = true;
				try
				{
					if (this is PlotXAxis)
					{
						for (int i = 0; i < base.Plot.XAxes.Count; i++)
						{
							if (base.Plot.XAxes[i] != this && (!base.Plot.XAxes[i].MasterUI || base.Plot.XAxes[i].MasterUISlave))
							{
								((IUIInput)base.Plot.XAxes[i]).MouseUp(e);
							}
						}
					}
					else
					{
						for (int j = 0; j < base.Plot.YAxes.Count; j++)
						{
							if (base.Plot.YAxes[j] != this && (!base.Plot.YAxes[j].MasterUI || base.Plot.YAxes[j].MasterUISlave))
							{
								((IUIInput)base.Plot.YAxes[j]).MouseUp(e);
							}
						}
					}
				}
				finally
				{
					PlotAxis.m_MasterUIBlock = false;
				}
			}
		}

		protected override void PopulateContextMenu(ContextMenu menu)
		{
			base.PopulateContextMenu(menu);
			MenuItem menuItem = new MenuItem();
			menuItem.Text = "Tracking Enabled";
			menuItem.Click += this.MenuItemTracking_Click;
			menuItem.Checked = this.Tracking.Enabled;
			menu.MenuItems.Add(menuItem);
			menuItem = new MenuItem();
			menuItem.Text = "Update Resume Values";
			menuItem.Click += this.MenuItemUpdateResumeValues_Click;
			menuItem.Enabled = !this.Tracking.Enabled;
			menu.MenuItems.Add(menuItem);
			MenuItem menuItem2 = new MenuItem();
			menuItem2.Text = "Zoom To Fit";
			menu.MenuItems.Add(menuItem2);
			menuItem = new MenuItem();
			menuItem.Text = "All";
			menuItem.Click += this.MenuItemZoomToFitAll_Click;
			menuItem2.MenuItems.Add(menuItem);
			menuItem = new MenuItem();
			menuItem.Text = "In-View";
			menuItem.Click += this.MenuItemZoomToFitInView_Click;
			menuItem2.MenuItems.Add(menuItem);
		}

		protected override void InternalOnKeyDown(KeyEventArgs e)
		{
			double num = (e.KeyCode != Keys.Left) ? ((e.KeyCode != Keys.Down) ? ((e.KeyCode != Keys.Right) ? ((e.KeyCode != Keys.Up) ? ((e.KeyCode != Keys.Prior) ? ((e.KeyCode != Keys.Next) ? ((e.KeyCode != Keys.Home) ? ((e.KeyCode != Keys.End) ? 0.0 : 1.0) : -1.0) : -1.0) : 1.0) : 0.01) : 0.01) : -0.01) : -0.01;
			if (num != 0.0)
			{
				this.Scroll(num);
			}
			if (this.MasterUI && base.Plot != null && !PlotAxis.m_MasterUIBlock)
			{
				PlotAxis.m_MasterUIBlock = true;
				try
				{
					if (this is PlotXAxis)
					{
						for (int i = 0; i < base.Plot.XAxes.Count; i++)
						{
							if (base.Plot.XAxes[i] != this && (!base.Plot.XAxes[i].MasterUI || base.Plot.XAxes[i].MasterUISlave))
							{
								((IUIInput)base.Plot.XAxes[i]).KeyDown(e);
							}
						}
					}
					else
					{
						for (int j = 0; j < base.Plot.YAxes.Count; j++)
						{
							if (base.Plot.YAxes[j] != this && (!base.Plot.YAxes[j].MasterUI || base.Plot.YAxes[j].MasterUISlave))
							{
								((IUIInput)base.Plot.YAxes[j]).KeyDown(e);
							}
						}
					}
				}
				finally
				{
					PlotAxis.m_MasterUIBlock = false;
				}
			}
		}

		protected override void InternalOnMouseWheel(MouseEventArgs e)
		{
			if (e.Delta != 0)
			{
				int num = e.Delta / Math.Abs(e.Delta);
				if (this.MouseMode == PlotAxisMouseMode.Scroll)
				{
					if (this.ScaleType == ScaleType.Linear)
					{
						this.Scroll(0.01 * (double)num);
					}
					else
					{
						this.ScrollPercent(this.ScaleRange.Min, this.ScaleRange.Span, this.ScaleRange.Max, 0.01 * (double)num);
					}
				}
				else
				{
					this.ZoomPercent(this.ScaleRange.Min, this.ScaleRange.Span, this.ScaleRange.Max, 0.01 * (double)num);
				}
				if (this.MasterUI && base.Plot != null && !PlotAxis.m_MasterUIBlock)
				{
					PlotAxis.m_MasterUIBlock = true;
					try
					{
						if (this is PlotXAxis)
						{
							for (int i = 0; i < base.Plot.XAxes.Count; i++)
							{
								if (base.Plot.XAxes[i] != this && (!base.Plot.XAxes[i].MasterUI || base.Plot.XAxes[i].MasterUISlave))
								{
									((IUIInput)base.Plot.XAxes[i]).MouseWheel(e);
								}
							}
						}
						else
						{
							for (int j = 0; j < base.Plot.YAxes.Count; j++)
							{
								if (base.Plot.YAxes[j] != this && (!base.Plot.YAxes[j].MasterUI || base.Plot.YAxes[j].MasterUISlave))
								{
									((IUIInput)base.Plot.YAxes[j]).MouseWheel(e);
								}
							}
						}
					}
					finally
					{
						PlotAxis.m_MasterUIBlock = false;
					}
				}
			}
		}

		private void MenuItemTracking_Click(object sender, EventArgs e)
		{
			this.Tracking.Enabled = !this.Tracking.Enabled;
		}

		private void MenuItemUpdateResumeValues_Click(object sender, EventArgs e)
		{
			this.Tracking.UpdateResumeValues();
		}

		private void MenuItemZoomToFitAll_Click(object sender, EventArgs e)
		{
			this.Tracking.ZoomToFitAll();
		}

		private void MenuItemZoomToFitInView_Click(object sender, EventArgs e)
		{
			this.Tracking.ZoomToFitInView();
		}

		public int ValueToPixels(double value)
		{
			return this.ScaleDisplay.ValueToPixels(value);
		}

		public double ValueToPercent(double value)
		{
			return this.ScaleDisplay.ValueToPercent(value);
		}

		public double PercentToValue(double value)
		{
			return this.ScaleDisplay.PercentToValue(value);
		}

		public int PercentToPixels(double value)
		{
			return this.ScaleDisplay.PercentToPixels(value);
		}

		public double PixelsToValue(int value)
		{
			return this.ScaleDisplay.PixelsToValue(value);
		}

		public double PixelsToPercent(int value)
		{
			return this.ScaleDisplay.PixelsToPercent(value);
		}

		public int PercentToSpanPixels(double value)
		{
			return this.ScaleDisplay.PercentToSpanPixels(value);
		}

		public double PercentSpanToValue(double value)
		{
			return this.ScaleDisplay.PercentSpanToValue(value);
		}

		public double PixelSpanToValue(int value)
		{
			return this.ScaleDisplay.PixelSpanToValue(value);
		}

		public double PixelSpanToPercent(int value)
		{
			return this.ScaleDisplay.PixelSpanToPercent(value);
		}

		public double ValueSpanToPercent(double value)
		{
			return this.ScaleDisplay.ValueSpanToPercent(value);
		}

		public int ValueToSpanPixels(double value)
		{
			return this.ScaleDisplay.ValueToSpanPixels(value);
		}

		public bool ValueVisible(double value)
		{
			return this.ScaleRange.OnRange(value);
		}

		public abstract double PixelsToValue(MouseEventArgs e);

		protected override void CalculateDepthPixels(PaintArgs p)
		{
			if (this.I_Display.PixelsSpan == 0)
			{
				this.I_Display.EdgeRef = 0;
				this.I_Display.SetBoundsEnds(0, 1000);
				this.I_Display.SetClipEnds(0, 1000);
			}
			this.I_Display.Generate(p);
			int pixelsSpan = this.I_Display.PixelsSpan;
			this.I_Title.DockSide = this.DockSide;
			this.I_Title.CalculateDrawingData(p, pixelsSpan);
			base.DockDepthPixels = this.I_Display.MaxDepth + this.I_Title.TitleDepthPixels + this.I_Title.SpacingPixels;
		}

		protected override void DrawCalculations(PaintArgs p)
		{
			this.I_Display.Generate(p);
		}

		protected override void DrawBackgroundLayer1(PaintArgs p)
		{
			if (!this.GridLines.ShowOnTop)
			{
				this.I_GridLines.DrawMinors(p, base.Plot, this);
			}
		}

		protected override void DrawBackgroundLayer2(PaintArgs p)
		{
			if (!this.GridLines.ShowOnTop)
			{
				this.I_GridLines.DrawMajors(p, base.Plot, this);
			}
		}

		protected override void DrawForegroundLayer1(PaintArgs p)
		{
			if (this.GridLines.ShowOnTop)
			{
				this.I_GridLines.DrawMinors(p, base.Plot, this);
			}
		}

		protected override void DrawForegroundLayer2(PaintArgs p)
		{
			if (this.GridLines.ShowOnTop)
			{
				this.I_GridLines.DrawMajors(p, base.Plot, this);
			}
		}

		protected override void Draw(PaintArgs p)
		{
			Rectangle rectangle = base.BoundsClip;
			rectangle.Inflate(1, 1);
			if (this.ClipToMinMax)
			{
				if (base.DockVertical)
				{
					p.Graphics.SetClip(iRectangle.FromLTRB(this.ScaleDisplay.PixelsMin, rectangle.Top, this.ScaleDisplay.PixelsMax, rectangle.Bottom));
				}
				else
				{
					p.Graphics.SetClip(iRectangle.FromLTRB(rectangle.Left, this.ScaleDisplay.PixelsMin, rectangle.Right, this.ScaleDisplay.PixelsMax));
				}
			}
			else
			{
				p.Graphics.SetClip(rectangle);
			}
			this.I_Display.Draw(p);
			int left;
			int right;
			int top;
			int bottom;
			if (base.DockVertical)
			{
				left = base.BoundsClip.Left;
				right = base.BoundsClip.Right;
				top = base.Bounds.Top;
				bottom = base.Bounds.Bottom;
			}
			else
			{
				left = base.Bounds.Left;
				right = base.Bounds.Right;
				top = base.BoundsClip.Top;
				bottom = base.BoundsClip.Bottom;
			}
			if (base.DockBottom)
			{
				top = base.Bounds.Bottom - this.I_Title.TitleDepthPixels - 1;
			}
			else if (base.DockTop)
			{
				bottom = base.Bounds.Top + this.I_Title.TitleDepthPixels;
			}
			else if (base.DockLeft)
			{
				right = base.Bounds.Left + this.I_Title.TitleDepthPixels;
			}
			else
			{
				left = base.Bounds.Right - this.I_Title.TitleDepthPixels - 1;
			}
			rectangle = iRectangle.FromLTRB(left, top, right, bottom);
			if (base.DockBottom)
			{
				rectangle.Offset(0, this.DockMargin);
			}
			else if (base.DockTop)
			{
				rectangle.Offset(0, -this.DockMargin);
			}
			else if (base.DockLeft)
			{
				rectangle.Offset(-this.DockMargin, 0);
			}
			else
			{
				rectangle.Offset(this.DockMargin, 0);
			}
			this.I_Title.Draw(p, rectangle);
		}

		protected override void DrawFocusRectangles(PaintArgs p)
		{
			if (base.Focused)
			{
				p.Graphics.DrawFocusRectangle(base.BoundsClip, base.BackColor);
			}
		}
	}
}
