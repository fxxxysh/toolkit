using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Base Class for all Plot Layout objects.")]
	public class PlotLayoutBlockGroup : PlotLayoutBlockBase
	{
		private PlotLayoutBlockItemCollection m_ListLeft;

		private PlotLayoutBlockItemCollection m_ListRight;

		private PlotLayoutBlockItemCollection m_ListTop;

		private PlotLayoutBlockItemCollection m_ListBottom;

		public PlotLayoutDataView DataView;

		public Rectangle InnerRectangleScreen;

		public Rectangle InnerRectangleLayout;

		public int DepthLeftScreen;

		public int DepthLeftLayout;

		public int DepthRightScreen;

		public int DepthRightLayout;

		public int DepthTopScreen;

		public int DepthTopLayout;

		public int DepthBottomScreen;

		public int DepthBottomLayout;

		public int DepthWidthScreen;

		public int DepthWidthLayout;

		public int DepthHeightScreen;

		public int DepthHeightLayout;

		public int OverlapLeftStart;

		public int OverlapLeftStop;

		public int OverlapRightStart;

		public int OverlapRightStop;

		public int OverlapTopStart;

		public int OverlapTopStop;

		public int OverlapBottomStart;

		public int OverlapBottomStop;

		public int DataViewHeightScreen;

		public int DataViewHeightLayout;

		public PlotLayoutBlockItemCollection ListLeft => this.m_ListLeft;

		public PlotLayoutBlockItemCollection ListRight => this.m_ListRight;

		public PlotLayoutBlockItemCollection ListTop => this.m_ListTop;

		public PlotLayoutBlockItemCollection ListBottom => this.m_ListBottom;

		public PlotLayoutBlockGroup()
		{
			this.m_ListLeft = new PlotLayoutBlockItemCollection();
			this.m_ListRight = new PlotLayoutBlockItemCollection();
			this.m_ListTop = new PlotLayoutBlockItemCollection();
			this.m_ListBottom = new PlotLayoutBlockItemCollection();
		}

		public void Add(PlotLayoutBlockItem value)
		{
			PlotLayoutDockableDataView plotLayoutDockableDataView = value.Object as PlotLayoutDockableDataView;
			if (plotLayoutDockableDataView != null)
			{
				if (plotLayoutDockableDataView.DockLeft)
				{
					this.ListLeft.Add(value);
					value.List = this.ListLeft;
				}
				else if (plotLayoutDockableDataView.DockRight)
				{
					this.ListRight.Add(value);
					value.List = this.ListRight;
				}
				else if (plotLayoutDockableDataView.DockTop)
				{
					this.ListTop.Add(value);
					value.List = this.ListTop;
				}
				else if (plotLayoutDockableDataView.DockBottom)
				{
					this.ListBottom.Add(value);
					value.List = this.ListBottom;
				}
			}
		}

		public void SortDockOrders()
		{
			this.ListLeft.SortDockOrder();
			this.ListRight.SortDockOrder();
			this.ListTop.SortDockOrder();
			this.ListBottom.SortDockOrder();
		}

		public void Clear()
		{
			this.ListLeft.Clear();
			this.ListLeft.UniqueDockOrders.Clear();
			this.ListRight.Clear();
			this.ListRight.UniqueDockOrders.Clear();
			this.ListTop.Clear();
			this.ListTop.UniqueDockOrders.Clear();
			this.ListBottom.Clear();
			this.ListBottom.UniqueDockOrders.Clear();
		}

		public void Calculate(PaintArgs p)
		{
			this.ListLeft.Calculate(p);
			this.ListRight.Calculate(p);
			this.ListTop.Calculate(p);
			this.ListBottom.Calculate(p);
			this.DepthLeftScreen = this.ListLeft.TotalDepthScreen;
			this.DepthLeftLayout = this.ListLeft.TotalDepthLayout;
			this.DepthLeftScreen = Math.Max(this.DepthLeftScreen, this.ListTop.MaxOverlapStart);
			this.DepthLeftScreen = Math.Max(this.DepthLeftScreen, this.ListBottom.MaxOverlapStart);
			this.DepthRightScreen = this.ListRight.TotalDepthScreen;
			this.DepthRightLayout = this.ListRight.TotalDepthLayout;
			this.DepthRightScreen = Math.Max(this.DepthRightScreen, this.ListTop.MaxOverlapStop);
			this.DepthRightScreen = Math.Max(this.DepthRightScreen, this.ListBottom.MaxOverlapStop);
			this.DepthTopScreen = this.ListTop.TotalDepthScreen;
			this.DepthTopLayout = this.ListTop.TotalDepthLayout;
			this.DepthTopScreen = Math.Max(this.DepthTopScreen, this.ListLeft.MaxOverlapStop);
			this.DepthTopScreen = Math.Max(this.DepthTopScreen, this.ListRight.MaxOverlapStop);
			this.DepthBottomScreen = this.ListBottom.TotalDepthScreen;
			this.DepthBottomLayout = this.ListBottom.TotalDepthLayout;
			this.DepthBottomScreen = Math.Max(this.DepthBottomScreen, this.ListLeft.MaxOverlapStart);
			this.DepthBottomScreen = Math.Max(this.DepthBottomScreen, this.ListRight.MaxOverlapStart);
			this.DepthWidthScreen = this.DepthLeftScreen + this.DepthRightScreen;
			this.DepthWidthLayout = this.DepthLeftLayout + this.DepthRightLayout;
			this.DepthHeightScreen = this.DepthTopScreen + this.DepthBottomScreen;
			this.DepthHeightLayout = this.DepthTopLayout + this.DepthBottomLayout;
		}

		public void CalculateAndSetAllDockObjectBounds()
		{
			int num = this.InnerRectangleScreen.Left;
			int num2 = this.InnerRectangleLayout.Left;
			int height = this.InnerRectangleScreen.Height;
			int height2 = this.InnerRectangleLayout.Height;
			int maxDepthScreen;
			int maxDepthLayout;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder in this.ListLeft.UniqueDockOrders)
			{
				maxDepthScreen = uniqueDockOrder.MaxDepthScreen;
				maxDepthLayout = uniqueDockOrder.MaxDepthLayout;
				int num3 = num - uniqueDockOrder.MaxDockMargin;
				int num4 = num2;
				int left = num3 - maxDepthScreen;
				int left2 = num4 - maxDepthLayout;
				foreach (PlotLayoutBlockItem item in uniqueDockOrder.Items)
				{
					PlotLayoutDockableDataView plotLayoutDockableDataView = item.Object as PlotLayoutDockableDataView;
					if (plotLayoutDockableDataView != null)
					{
						int num5 = (int)((double)this.InnerRectangleScreen.Bottom - plotLayoutDockableDataView.DockPercentStart * (double)height);
						int bottom = (int)((double)this.InnerRectangleLayout.Bottom - plotLayoutDockableDataView.DockPercentStart * (double)height2);
						num5 -= plotLayoutDockableDataView.TextOverlapPixelsStart + plotLayoutDockableDataView.StackingPixelsStart;
						int num6 = (int)((double)this.InnerRectangleScreen.Bottom - plotLayoutDockableDataView.DockPercentStop * (double)height);
						int top = (int)((double)this.InnerRectangleLayout.Bottom - plotLayoutDockableDataView.DockPercentStop * (double)height2);
						num6 += plotLayoutDockableDataView.TextOverlapPixelsStop + plotLayoutDockableDataView.StackingPixelsStop;
						item.BoundsScreen = iRectangle.FromLTRB(left, num6, num3, num5);
						item.BoundsLayout = iRectangle.FromLTRB(left2, top, num4, bottom);
						PlotAxis plotAxis = item.Object as PlotAxis;
						if (plotAxis != null)
						{
							item.BoundsClip = iRectangle.FromLTRB(left, num6 - plotAxis.ScaleTextOverlapPixels, num3, num5 + plotAxis.ScaleTextOverlapPixels);
						}
						else
						{
							item.BoundsClip = item.BoundsScreen;
						}
					}
				}
				num -= maxDepthScreen + uniqueDockOrder.MaxDockMargin;
				num2 -= maxDepthLayout;
			}
			num = this.InnerRectangleScreen.Right;
			num2 = this.InnerRectangleLayout.Right;
			height = this.InnerRectangleScreen.Height;
			height2 = this.InnerRectangleLayout.Height;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder2 in this.ListRight.UniqueDockOrders)
			{
				maxDepthScreen = uniqueDockOrder2.MaxDepthScreen;
				maxDepthLayout = uniqueDockOrder2.MaxDepthLayout;
				int left = num + uniqueDockOrder2.MaxDockMargin;
				int left2 = num2;
				int num3 = left + maxDepthScreen;
				int num4 = left2 + maxDepthLayout;
				foreach (PlotLayoutBlockItem item2 in uniqueDockOrder2.Items)
				{
					PlotLayoutDockableDataView plotLayoutDockableDataView = item2.Object as PlotLayoutDockableDataView;
					if (plotLayoutDockableDataView != null)
					{
						int num5 = (int)((double)this.InnerRectangleScreen.Bottom - plotLayoutDockableDataView.DockPercentStart * (double)height);
						int bottom = (int)((double)this.InnerRectangleLayout.Bottom - plotLayoutDockableDataView.DockPercentStart * (double)height2);
						num5 -= plotLayoutDockableDataView.TextOverlapPixelsStart + plotLayoutDockableDataView.StackingPixelsStart;
						int num6 = (int)((double)this.InnerRectangleScreen.Bottom - plotLayoutDockableDataView.DockPercentStop * (double)height);
						int top = (int)((double)this.InnerRectangleLayout.Bottom - plotLayoutDockableDataView.DockPercentStop * (double)height2);
						num6 += plotLayoutDockableDataView.TextOverlapPixelsStop + plotLayoutDockableDataView.StackingPixelsStop;
						item2.BoundsScreen = iRectangle.FromLTRB(left, num6, num3, num5);
						item2.BoundsLayout = iRectangle.FromLTRB(left2, top, num4, bottom);
						PlotAxis plotAxis = item2.Object as PlotAxis;
						if (plotAxis != null)
						{
							item2.BoundsClip = iRectangle.FromLTRB(left, num6 - plotAxis.ScaleTextOverlapPixels, num3, num5 + plotAxis.ScaleTextOverlapPixels);
						}
						else
						{
							item2.BoundsClip = item2.BoundsScreen;
						}
					}
				}
				num += maxDepthScreen + uniqueDockOrder2.MaxDockMargin;
				num2 += maxDepthLayout;
			}
			num = this.InnerRectangleScreen.Top;
			num2 = this.InnerRectangleLayout.Top;
			maxDepthScreen = this.InnerRectangleScreen.Width;
			maxDepthLayout = this.InnerRectangleLayout.Width;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder3 in this.ListTop.UniqueDockOrders)
			{
				height = uniqueDockOrder3.MaxDepthScreen;
				height2 = uniqueDockOrder3.MaxDepthLayout;
				int num5 = num - uniqueDockOrder3.MaxDockMargin;
				int bottom = num2;
				int num6 = num5 - height;
				int top = bottom - height2;
				foreach (PlotLayoutBlockItem item3 in uniqueDockOrder3.Items)
				{
					PlotLayoutDockableDataView plotLayoutDockableDataView = item3.Object as PlotLayoutDockableDataView;
					if (plotLayoutDockableDataView != null)
					{
						int left = (int)((double)this.InnerRectangleScreen.Left + plotLayoutDockableDataView.DockPercentStart * (double)maxDepthScreen);
						int left2 = (int)((double)this.InnerRectangleLayout.Left + plotLayoutDockableDataView.DockPercentStart * (double)maxDepthLayout);
						left += plotLayoutDockableDataView.TextOverlapPixelsStart + plotLayoutDockableDataView.StackingPixelsStart;
						int num3 = (int)((double)this.InnerRectangleScreen.Left + plotLayoutDockableDataView.DockPercentStop * (double)maxDepthScreen);
						int num4 = (int)((double)this.InnerRectangleLayout.Left + plotLayoutDockableDataView.DockPercentStop * (double)maxDepthLayout);
						num3 -= plotLayoutDockableDataView.TextOverlapPixelsStop + plotLayoutDockableDataView.StackingPixelsStop;
						item3.BoundsScreen = iRectangle.FromLTRB(left, num6, num3, num5);
						item3.BoundsLayout = iRectangle.FromLTRB(left2, top, num4, bottom);
						PlotAxis plotAxis = item3.Object as PlotAxis;
						if (plotAxis != null)
						{
							item3.BoundsClip = iRectangle.FromLTRB(left - plotAxis.ScaleTextOverlapPixels, num6, num3 + plotAxis.ScaleTextOverlapPixels, num5);
						}
						else
						{
							item3.BoundsClip = item3.BoundsScreen;
						}
					}
				}
				num -= height + uniqueDockOrder3.MaxDockMargin;
				num2 -= height2;
			}
			num = this.InnerRectangleScreen.Bottom;
			num2 = this.InnerRectangleLayout.Bottom;
			maxDepthScreen = this.InnerRectangleScreen.Width;
			maxDepthLayout = this.InnerRectangleLayout.Width;
			foreach (PlotLayoutUniqueDockOrder uniqueDockOrder4 in this.ListBottom.UniqueDockOrders)
			{
				height = uniqueDockOrder4.MaxDepthScreen;
				height2 = uniqueDockOrder4.MaxDepthLayout;
				int num6 = num + uniqueDockOrder4.MaxDockMargin;
				int top = num2;
				int num5 = num6 + height;
				int bottom = top + height2;
				foreach (PlotLayoutBlockItem item4 in uniqueDockOrder4.Items)
				{
					PlotLayoutDockableDataView plotLayoutDockableDataView = item4.Object as PlotLayoutDockableDataView;
					if (plotLayoutDockableDataView != null)
					{
						int left = (int)((double)this.InnerRectangleScreen.Left + plotLayoutDockableDataView.DockPercentStart * (double)maxDepthScreen);
						int left2 = (int)((double)this.InnerRectangleLayout.Left + plotLayoutDockableDataView.DockPercentStart * (double)maxDepthLayout);
						left += plotLayoutDockableDataView.TextOverlapPixelsStart + plotLayoutDockableDataView.StackingPixelsStart;
						int num3 = (int)((double)this.InnerRectangleScreen.Left + plotLayoutDockableDataView.DockPercentStop * (double)maxDepthScreen);
						int num4 = (int)((double)this.InnerRectangleLayout.Left + plotLayoutDockableDataView.DockPercentStop * (double)maxDepthLayout);
						num3 -= plotLayoutDockableDataView.TextOverlapPixelsStop + plotLayoutDockableDataView.StackingPixelsStop;
						item4.BoundsScreen = iRectangle.FromLTRB(left, num6, num3, num5);
						item4.BoundsLayout = iRectangle.FromLTRB(left2, top, num4, bottom);
						PlotAxis plotAxis = item4.Object as PlotAxis;
						if (plotAxis != null)
						{
							item4.BoundsClip = iRectangle.FromLTRB(left - plotAxis.ScaleTextOverlapPixels, num6, num3 + plotAxis.ScaleTextOverlapPixels, num5);
						}
						else
						{
							item4.BoundsClip = item4.BoundsScreen;
						}
					}
				}
				num += height + uniqueDockOrder4.MaxDockMargin;
				num2 += height2;
			}
			int val = 2147483647;
			int val2 = -2147483648;
			int val3 = 2147483647;
			int val4 = -2147483648;
			if (base.Object != null)
			{
				val = Math.Min(val, this.ListLeft.GetMinBoundsScreenTop());
				val = Math.Min(val, this.ListRight.GetMinBoundsScreenTop());
				val2 = Math.Max(val2, this.ListLeft.GetMaxBoundsScreenBottom());
				val2 = Math.Max(val2, this.ListRight.GetMaxBoundsScreenBottom());
				val3 = Math.Min(val3, this.ListTop.GetMinBoundsScreenLeft());
				val3 = Math.Min(val3, this.ListBottom.GetMinBoundsScreenLeft());
				val4 = Math.Max(val4, this.ListTop.GetMaxBoundsScreenRight());
				val4 = Math.Max(val4, this.ListBottom.GetMaxBoundsScreenRight());
				if (val == 2147483647)
				{
					val = this.InnerRectangleScreen.Top;
				}
				if (val2 == -2147483648)
				{
					val2 = this.InnerRectangleScreen.Bottom;
				}
				if (val3 == 2147483647)
				{
					val3 = this.InnerRectangleScreen.Left;
				}
				if (val4 == -2147483648)
				{
					val4 = this.InnerRectangleScreen.Right;
				}
				this.InnerRectangleScreen = Rectangle.FromLTRB(val3, val, val4, val2);
			}
		}

		public void TransferBoundsToLayoutObjects()
		{
			PlotLayoutDataView plotLayoutDataView = base.Object as PlotLayoutDataView;
			plotLayoutDataView.Bounds = base.BoundsScreen;
			plotLayoutDataView.BoundsClip = this.InnerRectangleScreen;
		}
	}
}
