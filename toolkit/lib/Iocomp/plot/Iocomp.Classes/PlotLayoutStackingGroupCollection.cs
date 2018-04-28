using System;
using System.Collections;
using System.Drawing;

namespace Iocomp.Classes
{
	public class PlotLayoutStackingGroupCollection : IEnumerable
	{
		private ArrayList m_List;

		public int MaxDepthTopScreen;

		public int MaxDepthTopLayout;

		public int MaxDepthBottomScreen;

		public int MaxDepthBottomLayout;

		public Rectangle BoundsScreen;

		public Rectangle BoundsLayout;

		public int Count => this.m_List.Count;

		public PlotLayoutStackingGroup this[int index]
		{
			get
			{
				return this.m_List[index] as PlotLayoutStackingGroup;
			}
			set
			{
				this.m_List[index] = value;
			}
		}

		public PlotLayoutStackingGroupCollection()
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

		public PlotLayoutStackingGroup GetStackingGroup(PlotLayoutDataView dataView)
		{
			foreach (PlotLayoutStackingGroup item in this)
			{
				if (item.Index == dataView.StackingGroupIndex)
				{
					return item;
				}
			}
			return null;
		}

		public int Add(PlotLayoutStackingGroup value)
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

		public void SortStackingIndex()
		{
			this.m_List.Sort(PlotLayoutManager.StackingGroupSorter);
		}

		public void SortDataViewsDockOrder()
		{
			foreach (PlotLayoutStackingGroup item in this)
			{
				item.SortDataViewsDockOrder();
			}
		}

		public int IndexOf(PlotLayoutStackingGroup value)
		{
			return this.m_List.IndexOf(value);
		}

		public virtual void Calculate()
		{
			foreach (PlotLayoutStackingGroup item in this)
			{
				item.Calculate();
			}
		}

		public virtual void SetDataViewWidthsAndReferences()
		{
			this.MaxDepthTopScreen = 0;
			this.MaxDepthTopLayout = 0;
			this.MaxDepthBottomScreen = 0;
			this.MaxDepthBottomLayout = 0;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			if (this.Count != 0)
			{
				int num6 = 0;
				for (int i = 0; i < this.Count; i++)
				{
					PlotLayoutStackingGroup plotLayoutStackingGroup = this[i];
					num2 += plotLayoutStackingGroup.MaxDepthWidthLayout;
					this.MaxDepthTopLayout = Math.Max(this.MaxDepthTopLayout, plotLayoutStackingGroup.MaxDepthTopLayout);
					this.MaxDepthBottomLayout = Math.Max(this.MaxDepthBottomLayout, plotLayoutStackingGroup.MaxDepthBottomLayout);
					num4 += plotLayoutStackingGroup.OuterMarginLayout * 2;
					if (plotLayoutStackingGroup.DataViewVisibleCount != 0)
					{
						num += plotLayoutStackingGroup.MaxDepthWidthScreen;
						this.MaxDepthTopScreen = Math.Max(this.MaxDepthTopScreen, plotLayoutStackingGroup.MaxDepthTopScreen);
						this.MaxDepthBottomScreen = Math.Max(this.MaxDepthBottomScreen, plotLayoutStackingGroup.MaxDepthBottomScreen);
						num3 += plotLayoutStackingGroup.OuterMarginScreen * 2;
						num5++;
					}
				}
				if (num5 != 0)
				{
					num6 = (num5 - 1) * PlotLayoutStackingGroup.DockMarginScreen;
					int num7 = this.BoundsScreen.Width - num - num3 - num6;
					int num8 = this.BoundsLayout.Width - num2 - num4;
					int num9 = num7 / num5;
					int num10 = num8 / this.Count;
					int num11 = num7 - num9 * num5;
					int num12 = num8 - num10 * this.Count;
					foreach (PlotLayoutStackingGroup item in this)
					{
						if (item.DataViewVisibleCount != 0)
						{
							if (num11 > 0)
							{
								item.DataViewWidthScreen = num9 + 1;
								num11--;
							}
							else
							{
								item.DataViewWidthScreen = num9;
							}
						}
						if (num12 > 0)
						{
							item.DataViewWidthLayout = num10 + 1;
							num12--;
						}
						else
						{
							item.DataViewWidthLayout = num10;
						}
					}
					foreach (PlotLayoutStackingGroup item2 in this)
					{
						if (item2.DataViewVisibleCount != 0)
						{
							item2.DataViewReferenceTopScreen = this.BoundsScreen.Top + this.MaxDepthTopScreen + item2.OuterMarginScreen;
							item2.DataViewReferenceBottomScreen = this.BoundsScreen.Bottom - this.MaxDepthBottomScreen - item2.OuterMarginScreen;
						}
						item2.DataViewReferenceTopLayout = this.BoundsLayout.Top + this.MaxDepthTopLayout + item2.OuterMarginLayout;
						item2.DataViewReferenceBottomLayout = this.BoundsLayout.Bottom - this.MaxDepthBottomLayout - item2.OuterMarginLayout;
					}
				}
			}
		}

		public virtual void CalculateEachStackingGroupBounds()
		{
			int num = this.BoundsScreen.Left;
			int num2 = this.BoundsLayout.Left;
			for (int i = 0; i < this.Count; i++)
			{
				PlotLayoutStackingGroup plotLayoutStackingGroup = this[i];
				int maxDepthLeftScreen = plotLayoutStackingGroup.MaxDepthLeftScreen;
				int maxDepthLeftLayout = plotLayoutStackingGroup.MaxDepthLeftLayout;
				int dataViewWidthScreen = plotLayoutStackingGroup.DataViewWidthScreen;
				int dataViewWidthLayout = plotLayoutStackingGroup.DataViewWidthLayout;
				int maxDepthRightScreen = plotLayoutStackingGroup.MaxDepthRightScreen;
				int maxDepthRightLayout = plotLayoutStackingGroup.MaxDepthRightLayout;
				int num3 = maxDepthLeftScreen + dataViewWidthScreen + maxDepthRightScreen + plotLayoutStackingGroup.OuterMarginScreen * 2;
				int num4 = maxDepthLeftLayout + dataViewWidthLayout + maxDepthRightLayout + plotLayoutStackingGroup.OuterMarginLayout * 2;
				plotLayoutStackingGroup.BoundsScreen = new Rectangle(num, this.BoundsScreen.Top, num3, this.BoundsScreen.Height);
				plotLayoutStackingGroup.BoundsLayout = new Rectangle(num2, this.BoundsLayout.Top, num4, this.BoundsLayout.Height);
				num += num3 + PlotLayoutStackingGroup.DockMarginScreen;
				num2 += num4;
				plotLayoutStackingGroup.DataViewReferenceLeftScreen = plotLayoutStackingGroup.BoundsScreen.Left + plotLayoutStackingGroup.MaxDepthLeftScreen + plotLayoutStackingGroup.OuterMarginScreen;
				plotLayoutStackingGroup.DataViewReferenceRightScreen = plotLayoutStackingGroup.BoundsScreen.Right - plotLayoutStackingGroup.MaxDepthRightScreen - plotLayoutStackingGroup.OuterMarginScreen;
				plotLayoutStackingGroup.DataViewReferenceLeftLayout = plotLayoutStackingGroup.BoundsLayout.Left + plotLayoutStackingGroup.MaxDepthLeftLayout + plotLayoutStackingGroup.OuterMarginLayout;
				plotLayoutStackingGroup.DataViewReferenceRightLayout = plotLayoutStackingGroup.BoundsLayout.Right - plotLayoutStackingGroup.MaxDepthRightLayout - plotLayoutStackingGroup.OuterMarginLayout;
			}
		}

		public virtual void PerformDataViewHeightCalculations()
		{
			foreach (PlotLayoutStackingGroup item in this)
			{
				item.PerformDataViewHeightCalculations();
			}
		}

		public virtual void PerformDataViewBoundsCalculations()
		{
			foreach (PlotLayoutStackingGroup item in this)
			{
				item.PerformDataViewBoundsCalculations();
			}
		}
	}
}
