using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLayoutBlockBaseCollection : IEnumerable
	{
		private ArrayList m_List;

		public int Count => this.m_List.Count;

		public PlotLayoutBlockBase this[int index]
		{
			get
			{
				return this.m_List[index] as PlotLayoutBlockItem;
			}
			set
			{
				this.m_List[index] = value;
			}
		}

		public PlotLayoutBlockBaseCollection()
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

		public int Add(PlotLayoutBlockBase value)
		{
			return this.m_List.Add(value);
		}

		public void Clear()
		{
			this.m_List.Clear();
		}

		private void Sort(IComparer comparer)
		{
			this.m_List.Sort(comparer);
		}

		public int IndexOf(PlotLayoutBlockItem value)
		{
			return this.m_List.IndexOf(value);
		}
	}
}
