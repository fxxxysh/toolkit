using Iocomp.Classes;
using System;
using System.ComponentModel;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("code")]
	public class PlotAnnotationBaseCollectionEditorPlugIn : PlugInCollection
	{
		protected override Type[] Types => new Type[9]
		{
			typeof(PlotAnnotationArc),
			typeof(PlotAnnotationEllipse),
			typeof(PlotAnnotationImage),
			typeof(PlotAnnotationLine),
			typeof(PlotAnnotationPie),
			typeof(PlotAnnotationPolygon),
			typeof(PlotAnnotationRectangle),
			typeof(PlotAnnotationText),
			typeof(PlotAnnotationTextBox)
		};

		public PlotAnnotationBaseCollectionEditorPlugIn()
		{
			base.Title = "Plot Annotation Collection Editor";
		}

		protected override PlugInStandard[] CreatePlugInPool()
		{
			return new PlugInStandard[9]
			{
				new PlotAnnotationArcEditorPlugIn(),
				new PlotAnnotationEllipseEditorPlugIn(),
				new PlotAnnotationImageEditorPlugIn(),
				new PlotAnnotationLineEditorPlugIn(),
				new PlotAnnotationPieEditorPlugIn(),
				new PlotAnnotationPolygonEditorPlugIn(),
				new PlotAnnotationRectangleEditorPlugIn(),
				new PlotAnnotationTextEditorPlugIn(),
				new PlotAnnotationTextBoxEditorPlugIn()
			};
		}

		protected override PlugInStandard GetClassPlugIn(object value)
		{
			if (value is PlotAnnotationArc)
			{
				return base.PlugInPool[0];
			}
			if (value is PlotAnnotationEllipse)
			{
				return base.PlugInPool[1];
			}
			if (value is PlotAnnotationImage)
			{
				return base.PlugInPool[2];
			}
			if (value is PlotAnnotationLine)
			{
				return base.PlugInPool[3];
			}
			if (value is PlotAnnotationPie)
			{
				return base.PlugInPool[4];
			}
			if (value is PlotAnnotationPolygon)
			{
				return base.PlugInPool[5];
			}
			if (value is PlotAnnotationRectangle)
			{
				return base.PlugInPool[6];
			}
			if (value is PlotAnnotationText)
			{
				return base.PlugInPool[7];
			}
			if (value is PlotAnnotationTextBox)
			{
				return base.PlugInPool[8];
			}
			return null;
		}

		protected override int GetPlugInIndex(object value)
		{
			if (value is PlotAnnotationArc)
			{
				return 0;
			}
			if (value is PlotAnnotationEllipse)
			{
				return 1;
			}
			if (value is PlotAnnotationImage)
			{
				return 2;
			}
			if (value is PlotAnnotationLine)
			{
				return 3;
			}
			if (value is PlotAnnotationPie)
			{
				return 4;
			}
			if (value is PlotAnnotationPolygon)
			{
				return 5;
			}
			if (value is PlotAnnotationRectangle)
			{
				return 6;
			}
			if (value is PlotAnnotationText)
			{
				return 7;
			}
			if (value is PlotAnnotationTextBox)
			{
				return 8;
			}
			return 0;
		}
	}
}
