using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public class PlotAnnotationArc : PlotAnnotationOutlineBase
	{
		private double m_StartAngle;

		private double m_SweepAngle;

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public double StartAngle
		{
			get
			{
				return this.m_StartAngle;
			}
			set
			{
				base.PropertyUpdateDefault("StartAngle", value);
				if (this.StartAngle != value)
				{
					this.m_StartAngle = value;
					base.DoPropertyChange(this, "StartAngle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Category("Iocomp")]
		[Description("")]
		public double SweepAngle
		{
			get
			{
				return this.m_SweepAngle;
			}
			set
			{
				base.PropertyUpdateDefault("SweepAngle", value);
				if (this.SweepAngle != value)
				{
					this.m_SweepAngle = value;
					base.DoPropertyChange(this, "SweepAngle");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation Arc";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotAnnotationArcEditorPlugIn";
		}

		public PlotAnnotationArc()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Arc";
			this.StartAngle = 0.0;
			this.SweepAngle = 90.0;
		}

		private bool ShouldSerializeStartAngle()
		{
			return base.PropertyShouldSerialize("StartAngle");
		}

		private void ResetStartAngle()
		{
			base.PropertyReset("StartAngle");
		}

		private bool ShouldSerializeSweepAngle()
		{
			return base.PropertyShouldSerialize("SweepAngle");
		}

		private void ResetSweepAngle()
		{
			base.PropertyReset("SweepAngle");
		}

		protected override void DrawCustom(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			Rectangle rectangle = iRectangle.FromLTRB(base.XYSwapped, base.XMinPixels, base.YMinPixels, base.XMaxPixels, base.YMaxPixels);
			if (!base.BoundsClip.IntersectsWith(rectangle))
			{
				base.ClickRegion = null;
			}
			else
			{
				base.ClickRegion = new Region(rectangle);
				base.UpdateGrabHandles(rectangle);
				base.I_Pen.DrawArc(p, rectangle, this.StartAngle, this.SweepAngle);
			}
		}
	}
}
