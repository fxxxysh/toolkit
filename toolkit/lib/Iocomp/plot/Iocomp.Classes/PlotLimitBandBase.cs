using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Limit Band Base.")]
	public abstract class PlotLimitBandBase : PlotLimitBase
	{
		private PlotFill m_Fill;

		protected IPlotFill I_Fill;

		private int m_HitRegionSize;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill Fill
		{
			get
			{
				return this.m_Fill;
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

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Fill = new PlotFill();
			base.AddSubClass(this.Fill);
			this.I_Fill = this.Fill;
			((ISubClassBase)this.Fill.Pen).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.Fill.Brush).ColorAmbientSource = AmbientColorSouce.Color;
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
			this.HitRegionSize = 5;
		}

		private bool ShouldSerializeFill()
		{
			return ((ISubClassBase)this.Fill).ShouldSerialize();
		}

		private void ResetFill()
		{
			((ISubClassBase)this.Fill).ResetToDefault();
		}

		private bool ShouldSerializeHitRegionSize()
		{
			return base.PropertyShouldSerialize("HitRegionSize");
		}

		private void ResetHitRegionSize()
		{
			base.PropertyReset("HitRegionSize");
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
