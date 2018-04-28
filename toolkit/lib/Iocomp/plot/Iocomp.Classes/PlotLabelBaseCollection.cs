using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLabelBaseCollection : PlotObjectCollectionBase
	{
		private PlotLabelBasicAccessor m_Basic;

		public PlotLabelBase this[int index]
		{
			get
			{
				return base.List[index] as PlotLabelBase;
			}
			set
			{
				base.List[index] = value;
			}
		}

		public PlotLabelBase this[string name]
		{
			get
			{
				return base.GetPlotObjectByName(name) as PlotLabelBase;
			}
		}

		public PlotLabelBasicAccessor Basic => this.m_Basic;

		protected override string GetPlugInTitle()
		{
			return "Label Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLabelBaseCollectionEditorPlugIn";
		}

		public PlotLabelBaseCollection()
			: base(null)
		{
			this.Initialize();
		}

		public PlotLabelBaseCollection(IComponentBase componentBase)
			: base(componentBase)
		{
			this.Initialize();
		}

		private void Initialize()
		{
			base.AllowEdit = true;
			base.BaseName = "Label";
			this.m_Basic = new PlotLabelBasicAccessor(this);
		}

		public void CopyTo(PlotLabelBase[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PlotLabelBase value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PlotLabelBase value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(PlotLabelBase value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PlotLabelBase value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PlotLabelBase value)
		{
			return base.List.Contains(value);
		}

		public override void Reset()
		{
			base.Clear();
			this.Add(new PlotLabelBasic());
		}

		protected override void SetupObjectBeforeAmbientControlBaseConnection(object value)
		{
			base.SetupObjectBeforeAmbientControlBaseConnection(value);
		}
	}
}
