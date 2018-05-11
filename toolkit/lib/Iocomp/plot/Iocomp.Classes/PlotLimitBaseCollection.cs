using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLimitBaseCollection : PlotObjectCollectionBase
	{
		private PlotLimitBandXAccessor m_BandX;

		private PlotLimitBandYAccessor m_BandY;

		private PlotLimitLineXAccessor m_LineX;

		private PlotLimitLineYAccessor m_LineY;

		private PlotLimitPolyBandAccessor m_PolyBand;

		public PlotLimitBase this[int index]
		{
			get
			{
				return base.List[index] as PlotLimitBase;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public PlotLimitBase this[string name]
		{
			get
			{
				return base.GetPlotObjectByName(name) as PlotLimitBase;
			}
		}

		public PlotLimitBandXAccessor BandX => this.m_BandX;

		public PlotLimitBandYAccessor BandY => this.m_BandY;

		public PlotLimitLineXAccessor LineX => this.m_LineX;

		public PlotLimitLineYAccessor LineY => this.m_LineY;

		public PlotLimitPolyBandAccessor PolyBand => this.m_PolyBand;

		protected override string GetPlugInTitle()
		{
			return "Limit Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLimitBaseCollectionEditorPlugIn";
		}

		public PlotLimitBaseCollection()
			: base(null)
		{
			this.Initialize();
		}

		public PlotLimitBaseCollection(IComponentBase componentBase)
			: base(componentBase)
		{
			this.Initialize();
		}

		private void Initialize()
		{
			base.AllowEdit = true;
			base.BaseName = "Limit";
			this.m_BandX = new PlotLimitBandXAccessor(this);
			this.m_BandY = new PlotLimitBandYAccessor(this);
			this.m_LineX = new PlotLimitLineXAccessor(this);
			this.m_LineY = new PlotLimitLineYAccessor(this);
			this.m_PolyBand = new PlotLimitPolyBandAccessor(this);
		}

		public void CopyTo(PlotLimitBase[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PlotLimitBase value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PlotLimitBase value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(PlotLimitBase value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PlotLimitBase value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PlotLimitBase value)
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
			PlotLimitBase plotLimitBase = value as PlotLimitBase;
			Plot plot = ((IPlotObject)plotLimitBase).Plot;
			if (plot != null)
			{
				if (plotLimitBase.XAxisName == "" && plot.XAxes.Count != 0)
				{
					plotLimitBase.XAxisName = plot.XAxes[0].Name;
				}
				if (plotLimitBase.YAxisName == "" && plot.YAxes.Count != 0)
				{
					plotLimitBase.YAxisName = plot.YAxes[0].Name;
				}
			}
		}
	}
}
