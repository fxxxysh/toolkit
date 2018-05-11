using Iocomp.Classes;
using System;
using System.ComponentModel;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("code")]
	public class AnnotationBaseCollectionEditorPlugIn : PlugInCollection
	{
		protected override Type[] Types => new Type[9]
		{
			typeof(AnnotationText),
			typeof(AnnotationTextBox),
			typeof(AnnotationRectangle),
			typeof(AnnotationEllipse),
			typeof(AnnotationLine),
			typeof(AnnotationArc),
			typeof(AnnotationPie),
			typeof(AnnotationPolygon),
			typeof(AnnotationImage)
		};

		public AnnotationBaseCollectionEditorPlugIn()
		{
			base.Title = "Annotation Collection Editor";
		}

		protected override PlugInStandard[] CreatePlugInPool()
		{
			return new PlugInStandard[9]
			{
				new AnnotationRectangleEditorPlugIn(),
				new AnnotationEllipseEditorPlugIn(),
				new AnnotationLineEditorPlugIn(),
				new AnnotationArcEditorPlugIn(),
				new AnnotationImageEditorPlugIn(),
				new AnnotationPieEditorPlugIn(),
				new AnnotationPolygonEditorPlugIn(),
				new AnnotationTextEditorPlugIn(),
				new AnnotationTextBoxEditorPlugIn()
			};
		}

		protected override PlugInStandard GetClassPlugIn(object value)
		{
			if (value is AnnotationRectangle)
			{
				return base.PlugInPool[0];
			}
			if (value is AnnotationEllipse)
			{
				return base.PlugInPool[1];
			}
			if (value is AnnotationLine)
			{
				return base.PlugInPool[2];
			}
			if (value is AnnotationArc)
			{
				return base.PlugInPool[3];
			}
			if (value is AnnotationImage)
			{
				return base.PlugInPool[4];
			}
			if (value is AnnotationPie)
			{
				return base.PlugInPool[5];
			}
			if (value is AnnotationPolygon)
			{
				return base.PlugInPool[6];
			}
			if (value is AnnotationText)
			{
				return base.PlugInPool[7];
			}
			if (value is AnnotationTextBox)
			{
				return base.PlugInPool[8];
			}
			return null;
		}

		protected override int GetPlugInIndex(object value)
		{
			if (value is AnnotationRectangle)
			{
				return 0;
			}
			if (value is AnnotationEllipse)
			{
				return 1;
			}
			if (value is AnnotationLine)
			{
				return 2;
			}
			if (value is AnnotationArc)
			{
				return 3;
			}
			if (value is AnnotationImage)
			{
				return 4;
			}
			if (value is AnnotationPie)
			{
				return 5;
			}
			if (value is AnnotationPolygon)
			{
				return 6;
			}
			if (value is AnnotationText)
			{
				return 7;
			}
			if (value is AnnotationTextBox)
			{
				return 8;
			}
			return 0;
		}
	}
}
