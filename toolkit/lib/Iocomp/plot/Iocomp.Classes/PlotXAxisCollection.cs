using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotXAxisCollection : PlotObjectCollectionBase
	{
		public PlotXAxis this[int index]
		{
			get
			{
				return base.List[index] as PlotXAxis;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public PlotXAxis this[string name]
		{
			get
			{
				return base.GetPlotObjectByName(name) as PlotXAxis;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "XAxis Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotXAxisCollectionEditorPlugIn";
		}

		public PlotXAxisCollection()
			: base(null)
		{
			this.Initialize();
		}

		public PlotXAxisCollection(IComponentBase componentBase)
			: base(componentBase)
		{
			this.Initialize();
		}

		private void Initialize()
		{
			base.AllowEdit = true;
			base.BaseName = "X-Axis";
		}

		public void CopyTo(PlotXAxis[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PlotXAxis value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PlotXAxis value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(PlotXAxis value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PlotXAxis value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PlotXAxis value)
		{
			return base.List.Contains(value);
		}

		public override void Reset()
		{
			base.Clear();
			this.Add(new PlotXAxis());
		}

		protected override void SetupObjectBeforeAmbientControlBaseConnection(object value)
		{
			base.SetupObjectBeforeAmbientControlBaseConnection(value);
		}
	}
}
