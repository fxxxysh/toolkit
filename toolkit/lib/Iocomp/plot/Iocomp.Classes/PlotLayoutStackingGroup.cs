using Iocomp.Interfaces;
using System;
using System.Drawing;

namespace Iocomp.Classes
{
	public class PlotLayoutStackingGroup : IDrawLayoutControl
	{
		private static Color[] m_ColorTable;

		public static int DockMarginScreen;

		private int m_Index;

		private PlotLayoutBlockGroupCollection m_Items;

		public int DataViewVisibleCount;

		public Rectangle BoundsScreen;

		public Rectangle BoundsLayout;

		public int OuterMarginScreen;

		public int OuterMarginLayout;

		public double TotalDockDepthRatioScreen;

		public double TotalDockDepthRatioLayout;

		public int DataViewWidthScreen;

		public int DataViewWidthLayout;

		public int MaxDepthLeftScreen;

		public int MaxDepthLeftLayout;

		public int MaxDepthRightScreen;

		public int MaxDepthRightLayout;

		public int MaxDepthTopScreen;

		public int MaxDepthTopLayout;

		public int MaxDepthBottomScreen;

		public int MaxDepthBottomLayout;

		public int TotalDepthHeightScreen;

		public int TotalDepthHeightLayout;

		public int TotalInnerDepthHeightScreen;

		public int TotalInnerDepthHeightLayout;

		public int DataViewReferenceLeftScreen;

		public int DataViewReferenceLeftLayout;

		public int DataViewReferenceRightScreen;

		public int DataViewReferenceRightLayout;

		public int DataViewReferenceTopScreen;

		public int DataViewReferenceTopLayout;

		public int DataViewReferenceBottomScreen;

		public int DataViewReferenceBottomLayout;

		public int Index
		{
			get
			{
				return this.m_Index;
			}
			set
			{
				this.m_Index = value;
			}
		}

		public PlotLayoutBlockGroupCollection Items => this.m_Items;

		public int MaxDepthWidthScreen => this.MaxDepthLeftScreen + this.MaxDepthRightScreen;

		public int MaxDepthWidthLayout => this.MaxDepthLeftLayout + this.MaxDepthRightLayout;

		static PlotLayoutStackingGroup()
		{
			PlotLayoutStackingGroup.m_ColorTable = new Color[2];
			PlotLayoutStackingGroup.m_ColorTable[0] = Color.CornflowerBlue;
			PlotLayoutStackingGroup.m_ColorTable[1] = Color.DarkSeaGreen;
			PlotLayoutStackingGroup.DockMarginScreen = 10;
		}

		public PlotLayoutStackingGroup()
		{
			this.m_Items = new PlotLayoutBlockGroupCollection();
			this.OuterMarginScreen = 0;
			this.OuterMarginLayout = 5;
		}

		public void SortDataViewsDockOrder()
		{
			this.Items.SortDataViewsDockOrder();
		}

		public void Add(PlotLayoutBlockGroup value)
		{
			if (value.Object is PlotLayoutDataView)
			{
				PlotLayoutDataView plotLayoutDataView = value.Object as PlotLayoutDataView;
				this.Items.Add(value);
				plotLayoutDataView.StackingGroup = this;
			}
		}

		public void Calculate()
		{
			this.MaxDepthLeftScreen = 0;
			this.MaxDepthLeftLayout = 0;
			this.MaxDepthRightScreen = 0;
			this.MaxDepthRightLayout = 0;
			this.MaxDepthTopScreen = 0;
			this.MaxDepthTopLayout = 0;
			this.MaxDepthBottomScreen = 0;
			this.MaxDepthBottomLayout = 0;
			this.TotalDepthHeightScreen = 0;
			this.TotalDepthHeightLayout = 0;
			this.TotalInnerDepthHeightScreen = 0;
			this.TotalInnerDepthHeightLayout = 0;
			this.TotalDockDepthRatioScreen = 0.0;
			this.TotalDockDepthRatioLayout = 0.0;
			PlotLayoutBlockGroup plotLayoutBlockGroup = null;
			PlotLayoutBlockGroup plotLayoutBlockGroup2 = null;
			this.DataViewVisibleCount = 0;
			for (int i = 0; i < this.Items.Count; i++)
			{
				PlotLayoutBlockGroup plotLayoutBlockGroup3 = this.Items[i];
				PlotLayoutDataView plotLayoutDataView = plotLayoutBlockGroup3.Object as PlotLayoutDataView;
				if (plotLayoutDataView != null)
				{
					this.TotalDockDepthRatioLayout += plotLayoutDataView.DockDepthRatio;
					this.MaxDepthLeftLayout = Math.Max(this.MaxDepthLeftLayout, plotLayoutBlockGroup3.DepthLeftLayout);
					this.MaxDepthRightLayout = Math.Max(this.MaxDepthRightLayout, plotLayoutBlockGroup3.DepthRightLayout);
					this.TotalDepthHeightLayout += plotLayoutBlockGroup3.DepthHeightLayout;
					if (plotLayoutDataView.Visible)
					{
						this.TotalDockDepthRatioScreen += plotLayoutDataView.DockDepthRatio;
						if (plotLayoutBlockGroup == null)
						{
							plotLayoutBlockGroup = plotLayoutBlockGroup3;
						}
						plotLayoutBlockGroup2 = plotLayoutBlockGroup3;
						this.MaxDepthLeftScreen = Math.Max(this.MaxDepthLeftScreen, plotLayoutBlockGroup3.DepthLeftScreen);
						this.MaxDepthRightScreen = Math.Max(this.MaxDepthRightScreen, plotLayoutBlockGroup3.DepthRightScreen);
						this.TotalDepthHeightScreen += plotLayoutBlockGroup3.DepthHeightScreen;
						this.DataViewVisibleCount++;
					}
				}
			}
			if (plotLayoutBlockGroup != null)
			{
				this.MaxDepthBottomScreen = plotLayoutBlockGroup.DepthBottomScreen;
			}
			if (plotLayoutBlockGroup2 != null)
			{
				this.MaxDepthTopScreen = plotLayoutBlockGroup2.DepthTopScreen;
			}
			if (this.Items.Count != 0)
			{
				this.MaxDepthBottomLayout = this.Items[0].DepthBottomLayout;
				this.MaxDepthTopLayout = this.Items[this.Items.Count - 1].DepthTopLayout;
			}
			if (this.DataViewVisibleCount >= 2)
			{
				for (int j = 0; j < this.Items.Count; j++)
				{
					PlotLayoutBlockGroup plotLayoutBlockGroup3 = this.Items[j];
					PlotLayoutDataView plotLayoutDataView = plotLayoutBlockGroup3.Object as PlotLayoutDataView;
					if (plotLayoutDataView.Visible)
					{
						if (plotLayoutBlockGroup3 == plotLayoutBlockGroup)
						{
							this.TotalInnerDepthHeightScreen += plotLayoutBlockGroup3.DepthTopScreen;
						}
						else if (plotLayoutBlockGroup3 == plotLayoutBlockGroup2)
						{
							this.TotalInnerDepthHeightScreen += plotLayoutBlockGroup3.DepthBottomScreen;
						}
						else
						{
							this.TotalInnerDepthHeightScreen += plotLayoutBlockGroup3.DepthHeightScreen;
						}
					}
				}
			}
			if (this.Items.Count >= 2)
			{
				for (int k = 0; k < this.Items.Count; k++)
				{
					PlotLayoutBlockGroup plotLayoutBlockGroup3 = this.Items[k];
					PlotLayoutDataView plotLayoutDataView = plotLayoutBlockGroup3.Object as PlotLayoutDataView;
					if (k == 0)
					{
						this.TotalInnerDepthHeightLayout += plotLayoutBlockGroup3.DepthTopLayout;
					}
					else if (k == this.Items.Count - 1)
					{
						this.TotalInnerDepthHeightLayout += plotLayoutBlockGroup3.DepthBottomLayout;
					}
					else
					{
						this.TotalInnerDepthHeightLayout += plotLayoutBlockGroup3.DepthHeightLayout;
					}
				}
			}
		}

		public void PerformDataViewHeightCalculations()
		{
			int num = this.DataViewReferenceBottomScreen - this.DataViewReferenceTopScreen - this.TotalInnerDepthHeightScreen;
			int num2 = this.DataViewReferenceBottomLayout - this.DataViewReferenceTopLayout - this.TotalInnerDepthHeightLayout;
			foreach (PlotLayoutBlockGroup item in this.Items)
			{
				PlotLayoutDataView plotLayoutDataView = item.Object as PlotLayoutDataView;
				if (plotLayoutDataView != null)
				{
					double num3 = (this.TotalDockDepthRatioScreen == 0.0) ? ((this.DataViewVisibleCount == 0) ? 0.0 : (1.0 / (double)this.DataViewVisibleCount)) : (plotLayoutDataView.DockDepthRatio / this.TotalDockDepthRatioScreen);
					double num4 = (this.TotalDockDepthRatioLayout == 0.0) ? (1.0 / (double)this.Items.Count) : (plotLayoutDataView.DockDepthRatio / this.TotalDockDepthRatioLayout);
					if (plotLayoutDataView.Visible)
					{
						item.DataViewHeightScreen = (int)((double)num * num3);
					}
					item.DataViewHeightLayout = (int)((double)num2 * num4);
				}
			}
		}

		public void PerformDataViewBoundsCalculations()
		{
			int num = this.DataViewReferenceBottomScreen;
			int num2 = this.DataViewReferenceBottomLayout;
			for (int i = 0; i < this.Items.Count; i++)
			{
				PlotLayoutBlockGroup plotLayoutBlockGroup = this.Items[i];
				PlotLayoutDataView plotLayoutDataView = plotLayoutBlockGroup.Object as PlotLayoutDataView;
				if (plotLayoutDataView != null)
				{
					if (num2 != this.DataViewReferenceBottomLayout)
					{
						num2 -= plotLayoutBlockGroup.DepthBottomLayout;
					}
					int num3 = num2 - plotLayoutBlockGroup.DataViewHeightLayout;
					plotLayoutBlockGroup.InnerRectangleLayout = Rectangle.FromLTRB(this.DataViewReferenceLeftLayout, num3, this.DataViewReferenceRightLayout, num2);
					plotLayoutBlockGroup.BoundsLayout = Rectangle.FromLTRB(this.DataViewReferenceLeftLayout - plotLayoutBlockGroup.DepthLeftLayout, num3 - plotLayoutBlockGroup.DepthTopLayout, this.DataViewReferenceRightLayout + plotLayoutBlockGroup.DepthRightLayout, num2 + plotLayoutBlockGroup.DepthBottomLayout);
					num2 = num3 - plotLayoutBlockGroup.DepthTopLayout;
					if (plotLayoutDataView.Visible)
					{
						if (num != this.DataViewReferenceBottomScreen)
						{
							num -= plotLayoutBlockGroup.DepthBottomScreen;
						}
						int num4 = num - plotLayoutBlockGroup.DataViewHeightScreen;
						plotLayoutBlockGroup.InnerRectangleScreen = Rectangle.FromLTRB(this.DataViewReferenceLeftScreen, num4, this.DataViewReferenceRightScreen, num);
						plotLayoutBlockGroup.BoundsScreen = Rectangle.FromLTRB(this.DataViewReferenceLeftScreen - plotLayoutBlockGroup.DepthLeftScreen, num4 - plotLayoutBlockGroup.DepthTopScreen, this.DataViewReferenceRightScreen + plotLayoutBlockGroup.DepthRightScreen, num + plotLayoutBlockGroup.DepthBottomScreen);
						num = num4 - plotLayoutBlockGroup.DepthTopScreen;
					}
				}
			}
		}

		public void Draw(PaintArgs p, Font font, Color foreColor, Color backColor)
		{
			Rectangle boundsLayout = this.BoundsLayout;
			Color color = PlotLayoutStackingGroup.m_ColorTable[Math.Abs(this.Index % 2)];
			p.Graphics.FillRectangle(p.Graphics.Brush(color), boundsLayout);
		}
	}
}
