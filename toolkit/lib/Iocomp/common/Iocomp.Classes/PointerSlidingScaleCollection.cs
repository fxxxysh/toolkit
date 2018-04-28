using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PointerSlidingScaleCollection : CollectionBase
	{
		public PointerSlidingScale this[int index]
		{
			get
			{
				return base.List[index] as PointerSlidingScale;
			}
			set
			{
				base.List[index] = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Pointer Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PointerSlidingScaleCollectionEditorPlugIn";
		}

		public PointerSlidingScaleCollection()
			: base(null)
		{
		}

		public PointerSlidingScaleCollection(IComponentBase componentBase)
			: base(componentBase)
		{
		}

		public void CopyTo(PointerSlidingScale[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PointerSlidingScale value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PointerSlidingScale value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(PointerSlidingScale value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PointerSlidingScale value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PointerSlidingScale value)
		{
			return base.List.Contains(value);
		}

		public override void Reset()
		{
			base.Clear();
			this.Add(new PointerSlidingScale());
		}
	}
}
