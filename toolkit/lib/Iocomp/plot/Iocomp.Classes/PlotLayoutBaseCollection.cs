using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLayoutBaseCollection : IEnumerable
	{
		private ArrayList m_List;

		public int Count => this.m_List.Count;

		public PlotLayoutBase this[int index]
		{
			get
			{
				return this.m_List[index] as PlotLayoutBase;
			}
			set
			{
				this.m_List[index] = value;
			}
		}

		public PlotLayoutBaseCollection()
		{
			this.m_List = new ArrayList();
		}

		public IEnumerator GetEnumerator()
		{
			return this.m_List.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public int Add(PlotLayoutBase value)
		{
			return this.m_List.Add(value);
		}

		public void Clear()
		{
			this.m_List.Clear();
		}

		public void Sort(IComparer comparer)
		{
			this.m_List.Sort(comparer);
		}

		public int IndexOf(PlotLayoutBase value)
		{
			return this.m_List.IndexOf(value);
		}
	}
}
