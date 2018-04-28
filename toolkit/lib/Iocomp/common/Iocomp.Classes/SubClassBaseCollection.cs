using Iocomp.Interfaces;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class SubClassBaseCollection : System.Collections.CollectionBase
	{
		public ISubClassBase this[int index]
		{
			get
			{
				return (ISubClassBase)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}

		public void CopyTo(ISubClassBase[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(ISubClassBase value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, ISubClassBase value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(int index)
		{
			base.List.RemoveAt(index);
		}

		public void Remove(ISubClassBase value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(ISubClassBase value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(ISubClassBase value)
		{
			return base.List.Contains(value);
		}
	}
}
