using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Limit Poly Band.")]
	public class PlotLimitPolyBand : PlotLimitBandBase
	{
		private PointDoubleCollection m_Points;

		private Region m_HitRegion;

		protected override IComponentBase ComponentBase
		{
			get
			{
				return base.ComponentBase;
			}
			set
			{
				base.ComponentBase = value;
				((ICollectionBase)this.Points).ComponentBase = value;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PointDoubleCollection Points
		{
			get
			{
				return this.m_Points;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Limit Poly-Band";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLimitPolyBandEditorPlugIn";
		}

		public PlotLimitPolyBand()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Points = new PointDoubleCollection(this.ComponentBase);
			this.Points.Changed += this.Points_Changed;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "PolyBand";
		}

		private bool ShouldSerializePoints()
		{
			return this.Points.Count != 0;
		}

		private void ResetPoints()
		{
			this.Points.Clear();
		}

		private void Points_Changed(object sender, EventArgs e)
		{
			base.DoPropertyChange(this, "PointsChanged");
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (this.Points.Count < 3)
			{
				base.CanDraw = false;
			}
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			Point[] array = new Point[this.m_Points.Count];
			for (int i = 0; i < this.m_Points.Count; i++)
			{
				array[i] = base.GetPoint(this.m_Points[i].X, this.m_Points[i].Y);
			}
			GraphicsPath graphicsPath = new GraphicsPath();
			try
			{
				graphicsPath.AddPolygon(array);
				if (this.m_HitRegion != null)
				{
					this.m_HitRegion.Dispose();
				}
				this.m_HitRegion = new Region(graphicsPath);
			}
			finally
			{
				graphicsPath.Dispose();
			}
			Rectangle rectangle = Rectangle.Round(this.m_HitRegion.GetBounds(p.Graphics.GraphicsMS));
			base.I_Fill.Draw(p, array, rectangle);
			base.Bounds = rectangle;
		}

		protected override bool InternalHitTest(MouseEventArgs e)
		{
			if (this.m_HitRegion == null)
			{
				return false;
			}
			return this.m_HitRegion.IsVisible((float)e.X, (float)e.Y);
		}

		protected override void DrawFocusRectangles(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			if (base.Focused)
			{
				p.Graphics.DrawFocusRectangle(base.Bounds, base.BackColor);
			}
		}
	}
}
