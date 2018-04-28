using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotTableBaseCollection : PlotObjectCollectionBase
	{
		private PlotTableChannelAccessor m_Channel;

		private PlotTableGridAccessor m_Grid;

		public PlotTableBase this[int index]
		{
			get
			{
				return base.List[index] as PlotTableBase;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public PlotTableBase this[string name]
		{
			get
			{
				return base.GetPlotObjectByName(name) as PlotTableBase;
			}
		}

		public PlotTableChannelAccessor Channel => this.m_Channel;

		public PlotTableGridAccessor Grid => this.m_Grid;

		protected override string GetPlugInTitle()
		{
			return "Table Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotTableBaseCollectionEditorPlugIn";
		}

		public PlotTableBaseCollection()
			: base(null)
		{
			this.Initialize();
		}

		public PlotTableBaseCollection(IComponentBase componentBase)
			: base(componentBase)
		{
			this.Initialize();
		}

		private void Initialize()
		{
			base.AllowEdit = true;
			base.BaseName = "Table";
			this.m_Channel = new PlotTableChannelAccessor(this);
			this.m_Grid = new PlotTableGridAccessor(this);
		}

		public void CopyTo(PlotTableBase[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PlotTableBase value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PlotTableBase value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(PlotTableBase value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PlotTableBase value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PlotTableBase value)
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
		}
	}
}
