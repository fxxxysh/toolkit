using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PointDoubleCollection : CollectionBase
	{
		public PointDouble this[int index]
		{
			get
			{
				return base.List[index] as PointDouble;
			}
			set
			{
				base.List[index] = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Point Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PointDoubleCollectionEditorPlugIn";
		}

		public PointDoubleCollection()
			: base(null)
		{
		}

		public PointDoubleCollection(IComponentBase componentBase)
			: base(componentBase)
		{
		}

		public void CopyTo(PointDouble[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PointDouble value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PointDouble value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(PointDouble value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PointDouble value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PointDouble value)
		{
			return base.List.Contains(value);
		}
	}
}
