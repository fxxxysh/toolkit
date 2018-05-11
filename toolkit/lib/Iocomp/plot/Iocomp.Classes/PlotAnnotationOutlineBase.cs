using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public abstract class PlotAnnotationOutlineBase : PlotAnnotationBase
	{
		private PlotPen m_Pen;

		protected IPlotPen I_Pen;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotPen Pen
		{
			get
			{
				return this.m_Pen;
			}
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Pen = new PlotPen();
			base.AddSubClass(this.Pen);
			this.I_Pen = this.Pen;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Pen.Color = Color.Empty;
			this.Pen.Thickness = 1.0;
			this.Pen.Style = PlotPenStyle.Solid;
			this.Pen.Visible = true;
		}

		private bool ShouldSerializePen()
		{
			return ((ISubClassBase)this.Pen).ShouldSerialize();
		}

		private void ResetPen()
		{
			((ISubClassBase)this.Pen).ResetToDefault();
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (!this.Pen.Visible)
			{
				base.CanDraw = false;
			}
		}
	}
}
