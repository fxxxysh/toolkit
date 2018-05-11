using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Layout Manager.")]
	public class PlotLayoutManager
	{
		private Rectangle m_Bounds;

		private Plot m_Plot;

		private bool m_ObjectsDirty;

		private Rectangle m_LayoutRectangle;

		private static PlotLayoutBlockItemDockOrderSorter m_BlockItemDockOrderSorter;

		private static PlotLayoutBlockItemDockPercentStartSorter m_BlockItemDockPercentStartSorter;

		private static PlotLayoutStackingGroupSorter m_StackingGroupSorter;

		private PlotLayoutBaseCollection m_LayoutObjects;

		private PlotLayoutBlockItemCollection m_BlockItems;

		private PlotLayoutStackingGroupCollection m_StackingGroups;

		private PlotLayoutBlockGroupCollection m_DataViewGroups;

		private PlotLayoutBlockGroup m_PlotDockGroup;

		private PlotLayoutBlockGroup m_LayoutGroupOrphan;

		private PlotLayoutBlockBaseCollection m_BlockObjects;

		private PlotLayoutBaseCollection m_ListDataViews;

		private bool m_LayoutDesign;

		private bool m_AutoInsertEnabled;

		public bool AutoInsertEnabled
		{
			get
			{
				return this.m_AutoInsertEnabled;
			}
			set
			{
				this.m_AutoInsertEnabled = value;
			}
		}

		private PlotLayoutBaseCollection ListDataViews => this.m_ListDataViews;

		private PlotLayoutBaseCollection LayoutObjects => this.m_LayoutObjects;

		private PlotLayoutBlockItemCollection BlockItems => this.m_BlockItems;

		private PlotLayoutStackingGroupCollection StackingGroups => this.m_StackingGroups;

		private PlotLayoutBlockGroupCollection DataViewGroups => this.m_DataViewGroups;

		public PlotLayoutBlockBaseCollection BlockObjects => this.m_BlockObjects;

		public static PlotLayoutBlockItemDockOrderSorter BlockItemDockOrderSorter => PlotLayoutManager.m_BlockItemDockOrderSorter;

		public static PlotLayoutBlockItemDockPercentStartSorter BlockItemDockPercentStartSorter => PlotLayoutManager.m_BlockItemDockPercentStartSorter;

		public static PlotLayoutStackingGroupSorter StackingGroupSorter => PlotLayoutManager.m_StackingGroupSorter;

		private Rectangle Bounds
		{
			get
			{
				return this.m_Bounds;
			}
			set
			{
				this.m_Bounds = value;
			}
		}

		public Rectangle LayoutRectangle
		{
			get
			{
				return this.m_LayoutRectangle;
			}
			set
			{
				this.m_LayoutRectangle = value;
			}
		}

		private Plot Plot
		{
			get
			{
				return this.m_Plot;
			}
			set
			{
				this.m_Plot = value;
			}
		}

		private bool LayoutDesign
		{
			get
			{
				return this.m_LayoutDesign;
			}
			set
			{
				this.m_LayoutDesign = value;
			}
		}

		private PlotLayoutBlockGroup PlotDockGroup => this.m_PlotDockGroup;

		private PlotLayoutBlockGroup LayoutGroupOrphan => this.m_LayoutGroupOrphan;

		public event EventHandler BeforeLayout;

		public event EventHandler AfterLayout;

		static PlotLayoutManager()
		{
			PlotLayoutManager.m_BlockItemDockOrderSorter = new PlotLayoutBlockItemDockOrderSorter();
			PlotLayoutManager.m_BlockItemDockPercentStartSorter = new PlotLayoutBlockItemDockPercentStartSorter();
			PlotLayoutManager.m_StackingGroupSorter = new PlotLayoutStackingGroupSorter();
		}

		public PlotLayoutManager(Plot plot)
		{
			this.m_LayoutObjects = new PlotLayoutBaseCollection();
			this.m_BlockItems = new PlotLayoutBlockItemCollection();
			this.m_StackingGroups = new PlotLayoutStackingGroupCollection();
			this.m_DataViewGroups = new PlotLayoutBlockGroupCollection();
			this.m_ListDataViews = new PlotLayoutBaseCollection();
			this.m_PlotDockGroup = new PlotLayoutBlockGroup();
			this.m_LayoutGroupOrphan = new PlotLayoutBlockGroup();
			this.m_BlockObjects = new PlotLayoutBlockBaseCollection();
			plot.PlotObjectAdded += this.plot_PlotObjectAdded;
			plot.PlotObjectRemoved += this.plot_PlotObjectRemoved;
			this.AutoInsertEnabled = true;
			this.Plot = plot;
		}

		private void plot_PlotObjectAdded(object sender, ObjectEventArgs e)
		{
			this.m_ObjectsDirty = true;
		}

		private void plot_PlotObjectRemoved(object sender, ObjectEventArgs e)
		{
			this.m_ObjectsDirty = true;
		}

		private PlotLayoutBlockGroup GetBlockGroup(PlotLayoutDataView dataView)
		{
			foreach (PlotLayoutBlockGroup dataViewGroup in this.DataViewGroups)
			{
				if (dataViewGroup.Object == dataView)
				{
					return dataViewGroup;
				}
			}
			return null;
		}

		private void AssignGroups()
		{
			this.PlotDockGroup.Clear();
			this.LayoutGroupOrphan.Clear();
			this.StackingGroups.Clear();
			foreach (PlotLayoutBlockGroup dataViewGroup in this.DataViewGroups)
			{
				dataViewGroup.Clear();
				PlotLayoutStackingGroup plotLayoutStackingGroup = this.StackingGroups.GetStackingGroup(dataViewGroup.DataView);
				if (plotLayoutStackingGroup == null)
				{
					plotLayoutStackingGroup = new PlotLayoutStackingGroup();
					plotLayoutStackingGroup.Index = dataViewGroup.DataView.StackingGroupIndex;
					this.StackingGroups.Add(plotLayoutStackingGroup);
				}
				plotLayoutStackingGroup.Add(dataViewGroup);
			}
			foreach (PlotLayoutBlockItem blockItem in this.BlockItems)
			{
				if (blockItem.Object is PlotLayoutAxis)
				{
					PlotLayoutAxis plotLayoutAxis = blockItem.Object as PlotLayoutAxis;
					PlotLayoutBlockGroup blockGroup = this.GetBlockGroup(plotLayoutAxis.DockDataView);
					if (blockGroup != null)
					{
						blockGroup.Add(blockItem);
					}
					else
					{
						this.LayoutGroupOrphan.Add(blockItem);
					}
				}
				else if (blockItem.Object is PlotLayoutDockableAll)
				{
					PlotLayoutDockableAll plotLayoutDockableAll = blockItem.Object as PlotLayoutDockableAll;
					if (plotLayoutDockableAll.DockStyle == PlotDockStyleAll.Plot)
					{
						this.PlotDockGroup.Add(blockItem);
					}
					else
					{
						PlotLayoutBlockGroup blockGroup = this.GetBlockGroup(plotLayoutDockableAll.DockDataView);
						if (blockGroup != null)
						{
							blockGroup.Add(blockItem);
						}
						else
						{
							this.LayoutGroupOrphan.Add(blockItem);
						}
					}
				}
			}
		}

		private void Setup(PaintArgs p, Rectangle rScreen, Rectangle rLayout)
		{
			if (this.m_ObjectsDirty)
			{
				this.LayoutObjects.Clear();
				foreach (PlotLayoutBase xAxis in this.Plot.XAxes)
				{
					this.LayoutObjects.Add(xAxis);
				}
				foreach (PlotLayoutBase yAxis in this.Plot.YAxes)
				{
					this.LayoutObjects.Add(yAxis);
				}
				foreach (PlotLayoutBase legend in this.Plot.Legends)
				{
					this.LayoutObjects.Add(legend);
				}
				foreach (PlotLayoutBase table in this.Plot.Tables)
				{
					this.LayoutObjects.Add(table);
				}
				foreach (PlotLayoutBase label in this.Plot.Labels)
				{
					this.LayoutObjects.Add(label);
				}
				this.BlockItems.Clear();
				this.BlockObjects.Clear();
				this.BlockObjects.Add(this.PlotDockGroup);
				foreach (PlotLayoutBase layoutObject in this.LayoutObjects)
				{
					PlotLayoutBlockItem plotLayoutBlockItem = new PlotLayoutBlockItem();
					plotLayoutBlockItem.Object = layoutObject;
					this.BlockItems.Add(plotLayoutBlockItem);
					this.BlockObjects.Add(plotLayoutBlockItem);
				}
				this.DataViewGroups.Clear();
				foreach (PlotLayoutDataView dataView in this.Plot.DataViews)
				{
					PlotLayoutBlockGroup plotLayoutBlockGroup = new PlotLayoutBlockGroup();
					plotLayoutBlockGroup.Object = dataView;
					plotLayoutBlockGroup.DataView = dataView;
					this.DataViewGroups.Add(plotLayoutBlockGroup);
					this.BlockObjects.Add(plotLayoutBlockGroup);
				}
				this.m_ObjectsDirty = false;
			}
			foreach (PlotLayoutBase layoutObject2 in this.LayoutObjects)
			{
				layoutObject2.Bounds = rScreen;
				layoutObject2.BoundsClip = rScreen;
				layoutObject2.TextOverlapPixelsStart = 0;
				layoutObject2.TextOverlapPixelsStop = 0;
			}
			for (int i = 0; i < 2; i++)
			{
				this.AssignGroups();
				foreach (PlotLayoutDataView dataView2 in this.Plot.DataViews)
				{
					dataView2.Bounds = Rectangle.Empty;
					dataView2.BoundsClip = Rectangle.Empty;
					dataView2.DockDepthPixels = 0;
					dataView2.TextOverlapPixelsStart = 0;
					dataView2.TextOverlapPixelsStop = 0;
				}
				foreach (PlotLayoutBase layoutObject3 in this.LayoutObjects)
				{
					((IPlotLayout)layoutObject3).CalculateDepthPixels(p);
				}
				this.PlotDockGroup.SortDockOrders();
				this.DataViewGroups.SortDockOrders();
				this.StackingGroups.SortStackingIndex();
				this.StackingGroups.SortDataViewsDockOrder();
				this.PlotDockGroup.Calculate(p);
				this.DataViewGroups.Calculate(p);
				this.PlotDockGroup.InnerRectangleScreen = new Rectangle(rScreen.Left + this.PlotDockGroup.DepthLeftScreen, rScreen.Top + this.PlotDockGroup.DepthTopScreen, rScreen.Width - this.PlotDockGroup.DepthWidthScreen, rScreen.Height - this.PlotDockGroup.DepthHeightScreen);
				this.PlotDockGroup.InnerRectangleLayout = new Rectangle(rLayout.Left + this.PlotDockGroup.DepthLeftLayout, rLayout.Left + this.PlotDockGroup.DepthTopLayout, rLayout.Width - this.PlotDockGroup.DepthWidthLayout, rLayout.Height - this.PlotDockGroup.DepthHeightLayout);
				this.StackingGroups.BoundsScreen = this.PlotDockGroup.InnerRectangleScreen;
				this.StackingGroups.BoundsLayout = this.PlotDockGroup.InnerRectangleLayout;
				this.StackingGroups.Calculate();
				this.StackingGroups.SetDataViewWidthsAndReferences();
				this.StackingGroups.CalculateEachStackingGroupBounds();
				this.StackingGroups.PerformDataViewHeightCalculations();
				this.StackingGroups.PerformDataViewBoundsCalculations();
				this.PlotDockGroup.CalculateAndSetAllDockObjectBounds();
				this.DataViewGroups.CalculateAndSetAllDockObjectBounds();
				this.BlockItems.TransferBoundsToLayoutObjects();
				this.DataViewGroups.TransferBoundsToLayoutObjects();
			}
		}

		private void PerformStartStopFixup(PaintArgs p)
		{
			foreach (PlotLayoutBase layoutObject in this.LayoutObjects)
			{
				Rectangle rectangle;
				if (layoutObject is PlotLayoutDockableAll)
				{
					PlotLayoutDockableAll plotLayoutDockableAll = layoutObject as PlotLayoutDockableAll;
					if (plotLayoutDockableAll.DockStartStyle != 0)
					{
						PlotDataView dockStartDataView = plotLayoutDockableAll.DockStartDataView;
						if (dockStartDataView != null)
						{
							rectangle = ((plotLayoutDockableAll.DockStartStyle != PlotDockStartStopStyleDockableAll.DataViewOuter) ? dockStartDataView.BoundsClip : dockStartDataView.Bounds);
							if (plotLayoutDockableAll.DockVertical)
							{
								plotLayoutDockableAll.Bounds = Rectangle.FromLTRB(rectangle.Left, plotLayoutDockableAll.Bounds.Top, plotLayoutDockableAll.Bounds.Right, plotLayoutDockableAll.Bounds.Bottom);
							}
							else
							{
								plotLayoutDockableAll.Bounds = Rectangle.FromLTRB(plotLayoutDockableAll.Bounds.Left, plotLayoutDockableAll.Bounds.Top, plotLayoutDockableAll.Bounds.Right, rectangle.Bottom);
							}
						}
					}
					if (plotLayoutDockableAll.DockStopStyle != 0)
					{
						PlotDataView dockStartDataView = plotLayoutDockableAll.DockStopDataView;
						if (dockStartDataView != null)
						{
							rectangle = ((plotLayoutDockableAll.DockStopStyle != PlotDockStartStopStyleDockableAll.DataViewOuter) ? dockStartDataView.BoundsClip : dockStartDataView.Bounds);
							if (plotLayoutDockableAll.DockVertical)
							{
								plotLayoutDockableAll.Bounds = Rectangle.FromLTRB(plotLayoutDockableAll.Bounds.Left, plotLayoutDockableAll.Bounds.Top, rectangle.Right, plotLayoutDockableAll.Bounds.Bottom);
							}
							else
							{
								plotLayoutDockableAll.Bounds = Rectangle.FromLTRB(plotLayoutDockableAll.Bounds.Left, rectangle.Top, plotLayoutDockableAll.Bounds.Right, plotLayoutDockableAll.Bounds.Bottom);
							}
						}
					}
				}
				else if (layoutObject is PlotLayoutAxis)
				{
					PlotLayoutAxis plotLayoutAxis = layoutObject as PlotLayoutAxis;
					if (plotLayoutAxis.DockStartStyle != 0)
					{
						PlotLayoutAxis dockStartAxis = plotLayoutAxis.DockStartAxis;
						if (dockStartAxis != null)
						{
							rectangle = dockStartAxis.Bounds;
							if (dockStartAxis.DockVertical)
							{
								plotLayoutAxis.Bounds = Rectangle.FromLTRB(rectangle.Left, plotLayoutAxis.Bounds.Top, plotLayoutAxis.Bounds.Right, plotLayoutAxis.Bounds.Bottom);
							}
							else
							{
								plotLayoutAxis.Bounds = Rectangle.FromLTRB(plotLayoutAxis.Bounds.Left, plotLayoutAxis.Bounds.Top, plotLayoutAxis.Bounds.Right, rectangle.Bottom);
							}
						}
					}
					if (plotLayoutAxis.DockStopStyle != 0)
					{
						PlotLayoutAxis dockStartAxis = plotLayoutAxis.DockStopAxis;
						if (dockStartAxis != null)
						{
							rectangle = dockStartAxis.Bounds;
							if (dockStartAxis.DockVertical)
							{
								plotLayoutAxis.Bounds = Rectangle.FromLTRB(plotLayoutAxis.Bounds.Left, plotLayoutAxis.Bounds.Top, rectangle.Right, plotLayoutAxis.Bounds.Bottom);
							}
							else
							{
								plotLayoutAxis.Bounds = Rectangle.FromLTRB(plotLayoutAxis.Bounds.Left, rectangle.Top, plotLayoutAxis.Bounds.Right, plotLayoutAxis.Bounds.Bottom);
							}
						}
					}
				}
			}
		}

		public void DrawLayout(PaintArgs p, Font font, Color foreColor, Color backColor)
		{
			foreach (IDrawLayoutControl stackingGroup in this.StackingGroups)
			{
				stackingGroup.Draw(p, font, foreColor, backColor);
			}
			foreach (IDrawLayoutControl dataViewGroup in this.DataViewGroups)
			{
				dataViewGroup.Draw(p, font, foreColor, backColor);
			}
			foreach (IDrawLayoutControl blockItem in this.BlockItems)
			{
				blockItem.Draw(p, font, foreColor, backColor);
			}
		}

		public void Execute(PaintArgs p, bool layoutDesign, Rectangle rScreen, Rectangle rLayout)
		{
			if (this.Plot != null)
			{
				if (this.BeforeLayout != null)
				{
					this.BeforeLayout(this.Plot, EventArgs.Empty);
				}
				this.Setup(p, rScreen, this.m_LayoutRectangle);
				if (this.AfterLayout != null)
				{
					this.AfterLayout(this.Plot, EventArgs.Empty);
				}
				this.PerformStartStopFixup(p);
			}
		}
	}
}
