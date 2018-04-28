using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Axis Grid Lines.")]
	public class PlotAxisGridLines : SubClassBase, IPlotAxisGridLines
	{
		private PlotPen m_Major;

		private IPlotPen I_Major;

		private PlotPen m_Mid;

		private IPlotPen I_Mid;

		private PlotPen m_Minor;

		private IPlotPen I_Minor;

		private bool m_ShowOnTop;

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

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotPen Major
		{
			get
			{
				return this.m_Major;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotPen Mid
		{
			get
			{
				return this.m_Mid;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotPen Minor
		{
			get
			{
				return this.m_Minor;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ShowOnTop
		{
			get
			{
				return this.m_ShowOnTop;
			}
			set
			{
				base.PropertyUpdateDefault("ShowOnTop", value);
				if (this.ShowOnTop != value)
				{
					this.m_ShowOnTop = value;
					base.DoPropertyChange(this, "ShowOnTop");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Axis Grid Lines";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotAxisGridLinesEditorPlugIn";
		}

		void IPlotAxisGridLines.DrawMajors(PaintArgs p, Plot plot, PlotAxis axis)
		{
			this.Draw(p, plot, axis, true);
		}

		void IPlotAxisGridLines.DrawMinors(PaintArgs p, Plot plot, PlotAxis axis)
		{
			this.Draw(p, plot, axis, false);
		}

		public PlotAxisGridLines()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Major = new PlotPen();
			base.AddSubClass(this.Major);
			this.I_Major = this.Major;
			this.m_Mid = new PlotPen();
			base.AddSubClass(this.Mid);
			this.I_Mid = this.Mid;
			this.m_Minor = new PlotPen();
			base.AddSubClass(this.Minor);
			this.I_Minor = this.Minor;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Visible = true;
			this.Color = Color.Empty;
			this.Major.Visible = true;
			this.Major.Style = PlotPenStyle.Solid;
			this.Major.Color = Color.Empty;
			this.Major.Thickness = 1.0;
			this.Mid.Visible = false;
			this.Mid.Style = PlotPenStyle.Solid;
			this.Mid.Color = Color.Empty;
			this.Mid.Thickness = 1.0;
			this.Minor.Visible = false;
			this.Minor.Style = PlotPenStyle.Solid;
			this.Minor.Color = Color.Empty;
			this.Minor.Thickness = 1.0;
			this.ShowOnTop = false;
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeMajor()
		{
			return ((ISubClassBase)this.Major).ShouldSerialize();
		}

		private void ResetMajor()
		{
			((ISubClassBase)this.Major).ResetToDefault();
		}

		private bool ShouldSerializeMid()
		{
			return ((ISubClassBase)this.Mid).ShouldSerialize();
		}

		private void ResetMid()
		{
			((ISubClassBase)this.Mid).ResetToDefault();
		}

		private bool ShouldSerializeMinor()
		{
			return ((ISubClassBase)this.Minor).ShouldSerialize();
		}

		private void ResetMinor()
		{
			((ISubClassBase)this.Minor).ResetToDefault();
		}

		private bool ShouldSerializeShowOnTop()
		{
			return base.PropertyShouldSerialize("ShowOnTop");
		}

		private void ResetShowOnTop()
		{
			base.PropertyReset("ShowOnTop");
		}

		private void DrawLine(PaintArgs p, PlotAxis axis, Rectangle r, Pen pen, int APixels)
		{
			if (axis.DockHorizontal)
			{
				p.Graphics.DrawLine(pen, r.Left, APixels, r.Right, APixels);
			}
			else
			{
				p.Graphics.DrawLine(pen, APixels, r.Top, APixels, r.Bottom);
			}
		}

		private void DrawToDataView(PaintArgs p, PlotAxis axis, Rectangle r, bool drawMajors)
		{
			p.Graphics.SetClip(r);
			if (this.Major.Visible && drawMajors)
			{
				Pen pen = this.I_Major.GetPen(p);
				foreach (ScaleTickBase tick in axis.ScaleDisplay.TickList)
				{
					if (tick is ScaleTickMajor)
					{
						this.DrawLine(p, axis, r, pen, axis.ScaleDisplay.ValueToPixels(tick.Value));
					}
				}
			}
			if (this.Mid.Visible && drawMajors)
			{
				Pen pen = this.I_Mid.GetPen(p);
				foreach (ScaleTickBase tick2 in axis.ScaleDisplay.TickList)
				{
					if (tick2 is ScaleTickMid)
					{
						this.DrawLine(p, axis, r, pen, axis.ScaleDisplay.ValueToPixels(tick2.Value));
					}
				}
			}
			if (this.Minor.Visible && !drawMajors)
			{
				Pen pen = this.I_Minor.GetPen(p);
				foreach (ScaleTickBase tick3 in axis.ScaleDisplay.TickList)
				{
					if (tick3 is ScaleTickMinor)
					{
						this.DrawLine(p, axis, r, pen, axis.ScaleDisplay.ValueToPixels(tick3.Value));
					}
				}
			}
		}

		private void Draw(PaintArgs p, Plot plot, PlotAxis axis, bool drawMajors)
		{
			if (this.Visible && plot != null)
			{
				string dockDataViewName = axis.DockDataViewName;
				PlotDataView plotDataView = plot.DataViews[dockDataViewName];
				if (plotDataView != null)
				{
					p.Graphics.SetClip(plotDataView.BoundsClip);
					this.DrawToDataView(p, axis, plotDataView.BoundsClip, drawMajors);
					foreach (PlotDataView dataView in plot.DataViews)
					{
						if (dataView != plotDataView)
						{
							if (axis.DockVertical)
							{
								if (PlotBase.GetNamesMatch(dataView.GridLinesMirrorVertical, dockDataViewName))
								{
									this.DrawToDataView(p, axis, dataView.BoundsClip, drawMajors);
								}
							}
							else if (PlotBase.GetNamesMatch(dataView.GridLinesMirrorHorizontal, dockDataViewName))
							{
								this.DrawToDataView(p, axis, dataView.BoundsClip, drawMajors);
							}
						}
					}
				}
			}
		}
	}
}
