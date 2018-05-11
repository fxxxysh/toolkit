using System;
using System.Collections;

namespace Iocomp.Classes
{
	public class PlotLayoutBlockItemCollection : IEnumerable
	{
		private ArrayList m_List;

		private PlotLayoutUniqueDockOrderCollection m_UniqueDockOrders;

		public int TotalDepthScreen;

		public int TotalDepthLayout;

		public int MaxOverlapStart;

		public int MaxOverlapStop;

		public int Count => this.m_List.Count;

		public PlotLayoutBlockItem this[int index]
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

		public PlotLayoutUniqueDockOrderCollection UniqueDockOrders => this.m_UniqueDockOrders;

		public PlotLayoutBlockItemCollection()
		{
			this.m_List = new ArrayList();
			this.m_UniqueDockOrders = new PlotLayoutUniqueDockOrderCollection();
		}

		public IEnumerator GetEnumerator()
		{
			return this.m_List.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public int Add(PlotLayoutBlockItem value)
		{
			return this.m_List.Add(value);
		}

		public void Remove(object value)
		{
			this.m_List.Remove(value);
		}

		public void Clear()
		{
			this.m_List.Clear();
		}

		private void Sort(IComparer comparer)
		{
			this.m_List.Sort(comparer);
		}

		public void SortDockOrder()
		{
			this.m_List.Sort(PlotLayoutManager.BlockItemDockOrderSorter);
			if (this.Count != 0)
			{
				while (this[0].Object.DockOrder == -1)
				{
					this[0].Object.DockOrder = this[this.Count - 1].Object.DockOrder + 1;
					this.m_List.Sort(PlotLayoutManager.BlockItemDockOrderSorter);
				}
			}
		}

		public void SortDockPercentStart()
		{
			this.m_List.Sort(PlotLayoutManager.BlockItemDockPercentStartSorter);
		}

		public int IndexOf(PlotLayoutBlockItem value)
		{
			return this.m_List.IndexOf(value);
		}

		private void CalculateUniqueDockOrders(PaintArgs p)
		{
			foreach (PlotLayoutBlockItem item in this)
			{
				if (this.UniqueDockOrders.Count == 0)
				{
					PlotLayoutUniqueDockOrder plotLayoutUniqueDockOrder = new PlotLayoutUniqueDockOrder();
					plotLayoutUniqueDockOrder.DockOrder = item.Object.DockOrder;
					plotLayoutUniqueDockOrder.Items.Add(item);
					this.UniqueDockOrders.Add(plotLayoutUniqueDockOrder);
				}
				else
				{
					PlotLayoutUniqueDockOrder plotLayoutUniqueDockOrder = this.UniqueDockOrders[this.UniqueDockOrders.Count - 1];
					if (plotLayoutUniqueDockOrder.DockOrder == item.Object.DockOrder)
					{
						plotLayoutUniqueDockOrder.Items.Add(item);
					}
					else
					{
						plotLayoutUniqueDockOrder = new PlotLayoutUniqueDockOrder();
						plotLayoutUniqueDockOrder.DockOrder = item.Object.DockOrder;
						plotLayoutUniqueDockOrder.Items.Add(item);
						this.UniqueDockOrders.Add(plotLayoutUniqueDockOrder);
					}
				}
			}
			this.UniqueDockOrders.Sort();
			this.UniqueDockOrders.CalcualteDimensions(p);
		}

		public void Calculate(PaintArgs p)
		{
			this.CalculateUniqueDockOrders(p);
			this.TotalDepthScreen = 0;
			this.TotalDepthLayout = 0;
			this.MaxOverlapStart = 0;
			this.MaxOverlapStop = 0;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder in this.UniqueDockOrders)
			{
				this.TotalDepthScreen += uniqueDockOrder.MaxDepthScreen + uniqueDockOrder.MaxDockMargin;
				this.TotalDepthLayout += uniqueDockOrder.MaxDepthLayout;
				this.MaxOverlapStart = Math.Max(this.MaxOverlapStart, uniqueDockOrder.OverlapStart);
				this.MaxOverlapStop = Math.Max(this.MaxOverlapStop, uniqueDockOrder.OverlapStop);
			}
		}

		public int GetMinBoundsScreenTop()
		{
			int num = 2147483647;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder in this.UniqueDockOrders)
			{
				num = Math.Min(num, uniqueDockOrder.GetMinBoundsScreenTop());
			}
			return num;
		}

		public int GetMaxBoundsScreenBottom()
		{
			int num = -2147483648;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder in this.UniqueDockOrders)
			{
				num = Math.Max(num, uniqueDockOrder.GetMaxBoundsScreenBottom());
			}
			return num;
		}

		public int GetMinBoundsScreenLeft()
		{
			int num = 2147483647;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder in this.UniqueDockOrders)
			{
				num = Math.Min(num, uniqueDockOrder.GetMinBoundsScreenLeft());
			}
			return num;
		}

		public int GetMaxBoundsScreenRight()
		{
			int num = -2147483648;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder in this.UniqueDockOrders)
			{
				num = Math.Max(num, uniqueDockOrder.GetMaxBoundsScreenRight());
			}
			return num;
		}

		public void TransferBoundsToLayoutObjects()
		{
			foreach (PlotLayoutBlockItem item in this)
			{
				item.TransferBoundsToLayoutObjects();
			}
		}
	}
}
