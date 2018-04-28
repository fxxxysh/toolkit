using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotDataCursorBaseCollection : PlotObjectCollectionBase
	{
		private PlotDataCursorChannelAccessor m_Channel;

		private PlotDataCursorChannelsAccessor m_Channels;

		private PlotDataCursorXYAccessor m_XY;

		public PlotDataCursorBase this[int index]
		{
			get
			{
				return base.List[index] as PlotDataCursorBase;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public PlotDataCursorBase this[string name]
		{
			get
			{
				return base.GetPlotObjectByName(name) as PlotDataCursorBase;
			}
		}

		public PlotDataCursorChannelAccessor Channel => this.m_Channel;

		public PlotDataCursorChannelsAccessor Channels => this.m_Channels;

		public PlotDataCursorXYAccessor XY => this.m_XY;

		protected override string GetPlugInTitle()
		{
			return "Data Cursor Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotDataCursorBaseCollectionEditorPlugIn";
		}

		public PlotDataCursorBaseCollection()
			: base(null)
		{
			this.Initialize();
		}

		public PlotDataCursorBaseCollection(IComponentBase componentBase)
			: base(componentBase)
		{
			this.Initialize();
		}

		private void Initialize()
		{
			base.AllowEdit = true;
			base.BaseName = "Data-Cursor";
			this.m_Channel = new PlotDataCursorChannelAccessor(this);
			this.m_Channels = new PlotDataCursorChannelsAccessor(this);
			this.m_XY = new PlotDataCursorXYAccessor(this);
		}

		public void CopyTo(PlotDataCursorBase[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PlotDataCursorBase value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PlotDataCursorBase value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(PlotDataCursorBase value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PlotDataCursorBase value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PlotDataCursorBase value)
		{
			return base.List.Contains(value);
		}

		public override void Reset()
		{
			base.Clear();
			this.Add(new PlotDataCursorXY());
		}

		protected override void SetupObjectBeforeAmbientControlBaseConnection(object value)
		{
			base.SetupObjectBeforeAmbientControlBaseConnection(value);
			PlotDataCursorBase plotDataCursorBase = value as PlotDataCursorBase;
			Plot plot = ((IPlotObject)plotDataCursorBase).Plot;
			if (plot != null && plotDataCursorBase is PlotDataCursorXY)
			{
				PlotDataCursorXY plotDataCursorXY = plotDataCursorBase as PlotDataCursorXY;
				if (plotDataCursorXY.XAxisName == "" && plot.XAxes.Count != 0)
				{
					plotDataCursorXY.XAxisName = plot.XAxes[0].Name;
				}
				if (plotDataCursorXY.YAxisName == "" && plot.YAxes.Count != 0)
				{
					plotDataCursorXY.YAxisName = plot.YAxes[0].Name;
				}
			}
		}
	}
}
