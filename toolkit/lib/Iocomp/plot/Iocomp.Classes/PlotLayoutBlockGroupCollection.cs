using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLayoutBlockGroupCollection : IEnumerable
	{
		private ArrayList m_List;

		public int Count => this.m_List.Count;

		public PlotLayoutBlockGroup this[int index]
		{
			get
			{
				return this.m_List[index] as PlotLayoutBlockGroup;
			}
			set
			{
				this.m_List[index] = value;
			}
		}

		public PlotLayoutBlockGroupCollection()
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

		public int Add(PlotLayoutBlockGroup value)
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

		public void SortDockOrders()
		{
			foreach (PlotLayoutBlockGroup item in this)
			{
				item.SortDockOrders();
			}
		}

		public void SortDataViewsDockOrder()
		{
			this.Sort(PlotLayoutManager.BlockItemDockOrderSorter);
		}

		public int IndexOf(PlotLayoutBlockGroup value)
		{
			return this.m_List.IndexOf(value);
		}

		public virtual void Calculate(PaintArgs p)
		{
			foreach (PlotLayoutBlockGroup item in this)
			{
				item.Calculate(p);
			}
		}

		public void CalculateAndSetAllDockObjectBounds()
		{
			foreach (PlotLayoutBlockGroup item in this)
			{
				item.CalculateAndSetAllDockObjectBounds();
			}
		}

		public void TransferBoundsToLayoutObjects()
		{
			foreach (PlotLayoutBlockGroup item in this)
			{
				item.TransferBoundsToLayoutObjects();
			}
		}
	}
}
