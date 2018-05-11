using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class AnnotationBaseCollection : CollectionBase
	{
		public AnnotationBase this[int index]
		{
			get
			{
				return base.List[index] as AnnotationBase;
			}
			set
			{
				base.List[index] = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Annotation Collection";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnnotationBaseCollectionEditorPlugIn";
		}

		public AnnotationBaseCollection()
			: base(null)
		{
		}

		public AnnotationBaseCollection(IComponentBase componentBase)
			: base(componentBase)
		{
		}

		public void CopyTo(AnnotationBase[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(AnnotationBase value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, AnnotationBase value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(AnnotationBase value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(AnnotationBase value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(AnnotationBase value)
		{
			return base.List.Contains(value);
		}
	}
}
