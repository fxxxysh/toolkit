using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotYAxisCollection : PlotObjectCollectionBase
	{
		public PlotYAxis this[int index]
		{
			get
			{
				return base.List[index] as PlotYAxis;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public PlotYAxis this[string name]
		{
			get
			{
				return base.GetPlotObjectByName(name) as PlotYAxis;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "YAxis Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotYAxisCollectionEditorPlugIn";
		}

		public PlotYAxisCollection()
			: base(null)
		{
			this.Initialize();
		}

		public PlotYAxisCollection(IComponentBase componentBase)
			: base(componentBase)
		{
			this.Initialize();
		}

		private void Initialize()
		{
			base.AllowEdit = true;
			base.BaseName = "Y-Axis";
		}

		public void CopyTo(PlotYAxis[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PlotYAxis value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PlotYAxis value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(PlotYAxis value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PlotYAxis value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PlotYAxis value)
		{
			return base.List.Contains(value);
		}

		public override void Reset()
		{
			base.Clear();
			this.Add(new PlotYAxis());
		}

		protected override void SetupObjectBeforeAmbientControlBaseConnection(object value)
		{
			base.SetupObjectBeforeAmbientControlBaseConnection(value);
		}
	}
}
