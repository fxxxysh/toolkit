using System;
using System.Drawing;

namespace Iocomp.Classes
{
	[Serializable]
	public class PlotAnnotationRectangle : PlotAnnotationFillBase
	{
		protected override string GetPlugInTitle()
		{
			return "Annotation Rectangle";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotAnnotationRectangleEditorPlugIn";
		}

		public PlotAnnotationRectangle()
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
			base.NameShort = "Rectangle";
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
				base.I_Fill.Draw(p, rectangle);
			}
		}
	}
}
