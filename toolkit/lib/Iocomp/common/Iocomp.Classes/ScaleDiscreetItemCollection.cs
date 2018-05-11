using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class ScaleDiscreetItemCollection : CollectionBase
	{
		public ScaleDiscreetItem this[int index]
		{
			get
			{
				return base.List[index] as ScaleDiscreetItem;
			}
			set
			{
				base.List[index] = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Item Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleDiscreetItemCollectionEditorPlugIn";
		}

		public ScaleDiscreetItemCollection()
			: base(null)
		{
		}

		public ScaleDiscreetItemCollection(IComponentBase componentBase)
			: base(componentBase)
		{
		}

		public void CopyTo(ScaleDiscreetItem[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(ScaleDiscreetItem value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, ScaleDiscreetItem value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(ScaleDiscreetItem value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(ScaleDiscreetItem value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(ScaleDiscreetItem value)
		{
			return base.List.Contains(value);
		}

		public override void Reset()
		{
			base.Clear();
			this.Add(new ScaleDiscreetItem("Low"));
			this.Add(new ScaleDiscreetItem("Medium"));
			this.Add(new ScaleDiscreetItem("High"));
		}
	}
}
