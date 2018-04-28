using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public abstract class PlotAnnotationFillBase : PlotAnnotationBase
	{
		private PlotFill m_Fill;

		protected IPlotFill I_Fill;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotFill Fill
		{
			get
			{
				return this.m_Fill;
			}
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Fill = new PlotFill();
			base.AddSubClass(this.Fill);
			this.I_Fill = this.Fill;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Fill.Visible = true;
			this.Fill.Brush.Visible = true;
			this.Fill.Brush.Style = PlotBrushStyle.Solid;
			this.Fill.Brush.SolidColor = Color.Empty;
			this.Fill.Brush.GradientStartColor = Color.Blue;
			this.Fill.Brush.GradientStopColor = Color.Aqua;
			this.Fill.Brush.HatchForeColor = Color.Empty;
			this.Fill.Brush.HatchBackColor = Color.Empty;
			this.Fill.Pen.Visible = true;
			this.Fill.Pen.Color = Color.Empty;
			this.Fill.Pen.Thickness = 1.0;
			this.Fill.Pen.Style = PlotPenStyle.Solid;
		}

		private bool ShouldSerializeFill()
		{
			return ((ISubClassBase)this.Fill).ShouldSerialize();
		}

		private void ResetFill()
		{
			((ISubClassBase)this.Fill).ResetToDefault();
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (this.Fill.NotDrawVisible)
			{
				base.CanDraw = false;
			}
		}
	}
}
