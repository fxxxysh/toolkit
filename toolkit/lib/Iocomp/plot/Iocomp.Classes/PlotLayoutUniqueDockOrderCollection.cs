using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLayoutUniqueDockOrderCollection : IEnumerable
	{
		private ArrayList m_List;

		public int Count => this.m_List.Count;

		public PlotLayoutUniqueDockOrder this[int index]
		{
			get
			{
				return this.m_List[index] as PlotLayoutUniqueDockOrder;
			}
			set
			{
				this.m_List[index] = value;
			}
		}

		public PlotLayoutUniqueDockOrderCollection()
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

		public int Add(PlotLayoutUniqueDockOrder value)
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

		public void Sort()
		{
			foreach (PlotLayoutUniqueDockOrder item in this)
			{
				item.Items.SortDockPercentStart();
			}
		}

		public int IndexOf(PlotLayoutUniqueDockOrder value)
		{
			return this.m_List.IndexOf(value);
		}

		public void CalcualteDimensions(PaintArgs p)
		{
			foreach (PlotLayoutUniqueDockOrder item in this)
			{
				item.CalcualteDimensions(p);
			}
		}
	}
}
