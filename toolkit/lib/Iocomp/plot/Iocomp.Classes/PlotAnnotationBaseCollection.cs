using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotAnnotationBaseCollection : PlotObjectCollectionBase
	{
		private PlotAnnotationArcAccessor m_Arc;

		private PlotAnnotationEllipseAccessor m_Ellipse;

		private PlotAnnotationImageAccessor m_Image;

		private PlotAnnotationLineAccessor m_Line;

		private PlotAnnotationPieAccessor m_Pie;

		private PlotAnnotationPolygonAccessor m_Polygon;

		private PlotAnnotationRectangleAccessor m_Rectangle;

		private PlotAnnotationTextAccessor m_Text;

		private PlotAnnotationTextBoxAccessor m_TextBox;

		public PlotAnnotationBase this[int index]
		{
			get
			{
				return base.List[index] as PlotAnnotationBase;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public PlotAnnotationBase this[string name]
		{
			get
			{
				return base.GetPlotObjectByName(name) as PlotAnnotationBase;
			}
		}

		public PlotAnnotationArcAccessor Arc => this.m_Arc;

		public PlotAnnotationEllipseAccessor Ellipse => this.m_Ellipse;

		public PlotAnnotationImageAccessor Image => this.m_Image;

		public PlotAnnotationLineAccessor Line => this.m_Line;

		public PlotAnnotationPieAccessor Pie => this.m_Pie;

		public PlotAnnotationPolygonAccessor Polygon => this.m_Polygon;

		public PlotAnnotationRectangleAccessor Rectangle => this.m_Rectangle;

		public PlotAnnotationTextAccessor Text => this.m_Text;

		public PlotAnnotationTextBoxAccessor TextBox => this.m_TextBox;

		protected override string GetPlugInTitle()
		{
			return "Annotation Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotAnnotationBaseCollectionEditorPlugIn";
		}

		public PlotAnnotationBaseCollection()
			: base(null)
		{
			this.Initialize();
		}

		public PlotAnnotationBaseCollection(IComponentBase componentBase)
			: base(componentBase)
		{
			this.Initialize();
		}

		private void Initialize()
		{
			base.AllowEdit = true;
			base.BaseName = "Annotation";
			this.m_Arc = new PlotAnnotationArcAccessor(this);
			this.m_Ellipse = new PlotAnnotationEllipseAccessor(this);
			this.m_Image = new PlotAnnotationImageAccessor(this);
			this.m_Line = new PlotAnnotationLineAccessor(this);
			this.m_Pie = new PlotAnnotationPieAccessor(this);
			this.m_Polygon = new PlotAnnotationPolygonAccessor(this);
			this.m_Rectangle = new PlotAnnotationRectangleAccessor(this);
			this.m_Text = new PlotAnnotationTextAccessor(this);
			this.m_TextBox = new PlotAnnotationTextBoxAccessor(this);
		}

		public void CopyTo(PlotAnnotationBase[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PlotAnnotationBase value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PlotAnnotationBase value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(PlotAnnotationBase value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PlotAnnotationBase value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PlotAnnotationBase value)
		{
			return base.List.Contains(value);
		}

		public override void Reset()
		{
			base.Clear();
		}

		protected override void SetupObjectBeforeAmbientControlBaseConnection(object value)
		{
			base.SetupObjectBeforeAmbientControlBaseConnection(value);
			PlotAnnotationBase plotAnnotationBase = value as PlotAnnotationBase;
			Plot plot = ((IPlotObject)plotAnnotationBase).Plot;
			if (plot != null)
			{
				if (plotAnnotationBase.XAxisName == "" && plot.XAxes.Count != 0)
				{
					plotAnnotationBase.XAxisName = plot.XAxes[0].Name;
				}
				if (plotAnnotationBase.YAxisName == "" && plot.YAxes.Count != 0)
				{
					plotAnnotationBase.YAxisName = plot.YAxes[0].Name;
				}
			}
		}
	}
}
