using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotDataViewCollection : PlotObjectCollectionBase
	{
		public PlotDataView this[int index]
		{
			get
			{
				return base.List[index] as PlotDataView;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public PlotDataView this[string name]
		{
			get
			{
				return base.GetPlotObjectByName(name) as PlotDataView;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Data-View Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotDataViewCollectionEditorPlugIn";
		}

		public PlotDataViewCollection()
			: base(null)
		{
			this.Initialize();
		}

		public PlotDataViewCollection(IComponentBase componentBase)
			: base(componentBase)
		{
			this.Initialize();
		}

		private void Initialize()
		{
			base.AllowEdit = true;
			base.BaseName = "Data-View";
		}

		public void CopyTo(PlotDataView[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PlotDataView value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PlotDataView value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(PlotDataView value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PlotDataView value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PlotDataView value)
		{
			return base.List.Contains(value);
		}

		public override void Reset()
		{
			base.Clear();
			this.Add(new PlotDataView());
		}

		protected override void SetupObjectBeforeAmbientControlBaseConnection(object value)
		{
			base.SetupObjectBeforeAmbientControlBaseConnection(value);
		}
	}
}
