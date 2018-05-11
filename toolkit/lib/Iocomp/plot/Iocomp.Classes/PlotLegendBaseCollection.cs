using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLegendBaseCollection : PlotObjectCollectionBase
	{
		private PlotLegendBasicAccessor m_Basic;

		private PlotLegendMultiColumnAccessor m_MultiColumn;

		private PlotLegendChannelImageAccessor m_ChannelImage;

		public PlotLegendBase this[int index]
		{
			get
			{
				return base.List[index] as PlotLegendBase;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public PlotLegendBase this[string name]
		{
			get
			{
				return base.GetPlotObjectByName(name) as PlotLegendBase;
			}
		}

		public PlotLegendBasicAccessor Basic => this.m_Basic;

		public PlotLegendMultiColumnAccessor MultiColumn => this.m_MultiColumn;

		public PlotLegendChannelImageAccessor ChannelImage => this.m_ChannelImage;

		protected override string GetPlugInTitle()
		{
			return "Legend Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLegendBaseCollectionEditorPlugIn";
		}

		public PlotLegendBaseCollection()
			: base(null)
		{
			this.Initialize();
		}

		public PlotLegendBaseCollection(IComponentBase componentBase)
			: base(componentBase)
		{
			this.Initialize();
		}

		private void Initialize()
		{
			base.AllowEdit = true;
			base.BaseName = "Legend";
			this.m_Basic = new PlotLegendBasicAccessor(this);
			this.m_MultiColumn = new PlotLegendMultiColumnAccessor(this);
			this.m_ChannelImage = new PlotLegendChannelImageAccessor(this);
		}

		public void CopyTo(PlotLegendBase[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PlotLegendBase value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PlotLegendBase value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(PlotLegendBase value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PlotLegendBase value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PlotLegendBase value)
		{
			return base.List.Contains(value);
		}

		public override void Reset()
		{
			base.Clear();
			this.Add(new PlotLegendBasic());
		}

		protected override void SetupObjectBeforeAmbientControlBaseConnection(object value)
		{
			base.SetupObjectBeforeAmbientControlBaseConnection(value);
			PlotLegendBase plotLegendBase = value as PlotLegendBase;
			Plot plot = ((IPlotObject)plotLegendBase).Plot;
			if (plot != null && plotLegendBase is PlotLegendChannelImage)
			{
				PlotLegendChannelImage plotLegendChannelImage = plotLegendBase as PlotLegendChannelImage;
				if (plotLegendChannelImage.ChannelName == "" && plot.Channels.Count != 0)
				{
					plotLegendChannelImage.ChannelName = plot.Channels[0].Name;
				}
			}
		}
	}
}
