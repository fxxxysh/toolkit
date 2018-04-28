using Iocomp.Design;
using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlugInStandardCollection : System.Collections.CollectionBase
	{
		public PlugInStandard this[int index]
		{
			get
			{
				return (PlugInStandard)base.List[index];
			}
			set
			{
				base.List[index] = value;
			}
		}

		public void CopyTo(PlugInStandard[] array, int index)
		{
			((ICollection)this).CopyTo((Array)array, index);
		}

		public int Add(PlugInStandard value)
		{
			return base.List.Add(value);
		}

		public void Insert(int index, PlugInStandard value)
		{
			base.List.Insert(index, value);
		}

		public void Remove(int index)
		{
			base.List.RemoveAt(index);
		}

		public void Remove(PlugInStandard value)
		{
			base.List.Remove(value);
		}

		public int IndexOf(PlugInStandard value)
		{
			return base.List.IndexOf(value);
		}

		public bool Contains(PlugInStandard value)
		{
			return base.List.Contains(value);
		}
	}
}
