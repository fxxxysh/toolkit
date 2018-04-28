using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Limit Line Base.")]
	public abstract class PlotLimitLineBase : PlotLimitBase
	{
		private PlotPen m_Line;

		private IPlotPen I_Line;

		private int m_HitRegionSize;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotPen Line
		{
			get
			{
				return this.m_Line;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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
			this.m_Line = new PlotPen();
			base.AddSubClass(this.Line);
			this.I_Line = this.Line;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Line.Color = Color.Empty;
			this.Line.Thickness = 1.0;
			this.Line.Style = PlotPenStyle.Solid;
			this.Line.Visible = true;
			this.HitRegionSize = 5;
			((ISubClassBase)this.Line).ColorAmbientSource = AmbientColorSouce.Color;
		}

		private bool ShouldSerializeLine()
		{
			return ((ISubClassBase)this.Line).ShouldSerialize();
		}

		private void ResetLine()
		{
			((ISubClassBase)this.Line).ResetToDefault();
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
			if (!this.Line.Visible)
			{
				base.CanDraw = false;
			}
		}
	}
}
