using System.Collections;

namespace Iocomp.Classes
{
	public class PlotDataCursorDisplayCollection : IEnumerable
	{
		private ArrayList m_List;

		public int Count => this.m_List.Count;

		public PlotDataCursorDisplay this[int index]
		{
			get
			{
				return this.m_List[index] as PlotDataCursorDisplay;
			}
			set
			{
				this.m_List[index] = value;
			}
		}

		public PlotDataCursorDisplayCollection()
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

		public int Add(PlotDataCursorDisplay value)
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

		public int IndexOf(PlotDataCursorDisplay value)
		{
			return this.m_List.IndexOf(value);
		}
	}
}
