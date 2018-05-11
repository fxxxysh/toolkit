using Iocomp.Design;
using Iocomp.Interfaces;
using Iocomp.Types;
using System.Drawing;

namespace Iocomp.Classes
{
	public class PlotLayoutViewerDragControl
	{
		public PlotLayoutBlockBase m_Source;

		public PlotLayoutBlockBase m_Destination;

		private bool m_Visible;

		private Rectangle m_Bounds;

		private ControlBase m_ControlBase;

		public PlotDragType SourceType;

		public PlotDragType DestinationType;

		public PlotDragSide DestinationSide;

		public Rectangle DestinationRect;

		public PlotDragDockOrderOffset DestinationDockOrderOffset;

		public Point MousePoint;

		public bool Visible
		{
			get
			{
				return this.m_Visible;
			}
			set
			{
				if (this.m_Visible != value)
				{
					this.m_Visible = value;
					this.m_ControlBase.UIInvalidate(this);
				}
			}
		}

		public Rectangle Bounds
		{
			get
			{
				return this.m_Bounds;
			}
			set
			{
				if (this.m_Bounds != value)
				{
					this.m_Bounds = value;
					this.m_ControlBase.UIInvalidate(this);
				}
			}
		}

		public PlotLayoutBlockBase Source
		{
			get
			{
				return this.m_Source;
			}
			set
			{
				if (this.m_Source != value)
				{
					this.m_Source = value;
					if (this.Source != null)
					{
						if (this.m_Source.Object is PlotDataView)
						{
							this.SourceType = PlotDragType.Group;
						}
						else
						{
							this.SourceType = PlotDragType.Item;
						}
					}
				}
				this.Update();
			}
		}

		public PlotLayoutBlockBase Destination
		{
			get
			{
				return this.m_Destination;
			}
			set
			{
				if (this.m_Destination != value)
				{
					if (this.m_Destination != null && this.m_Destination != this.m_Source)
					{
						this.m_Destination.BackColor = SystemColors.Control;
					}
					this.m_Destination = value;
					if (this.m_Destination != null)
					{
						if (this.m_Destination.Object != null && !(this.m_Destination.Object is PlotDataView))
						{
							this.DestinationType = PlotDragType.Item;
						}
						else
						{
							this.DestinationType = PlotDragType.Group;
						}
					}
				}
				this.Update();
			}
		}

		public PlotLayoutViewerDragControl(ControlBase controlBase)
		{
			this.m_ControlBase = controlBase;
		}

		public void UpdateDestinationSide()
		{
			Rectangle rectangle;
			if (this.DestinationType == PlotDragType.Group)
			{
				PlotLayoutBlockGroup plotLayoutBlockGroup = this.Destination as PlotLayoutBlockGroup;
				rectangle = plotLayoutBlockGroup.InnerRectangleLayout;
				Point[] array = new Point[3];
				Point point = new Point((rectangle.Left + rectangle.Right) / 2, (rectangle.Top + rectangle.Bottom) / 2);
				array[0] = new Point(rectangle.Left, rectangle.Top);
				array[1] = point;
				array[2] = new Point(rectangle.Left, rectangle.Bottom);
				if (HitTest.Contains(this.MousePoint, array))
				{
					this.DestinationRect = new Rectangle(rectangle.Left - 10, rectangle.Top, 21, rectangle.Height);
					this.DestinationSide = PlotDragSide.Left;
					this.Destination.List = plotLayoutBlockGroup.ListLeft;
					this.DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
				}
				else
				{
					array[0] = new Point(rectangle.Right, rectangle.Top);
					array[1] = point;
					array[2] = new Point(rectangle.Right, rectangle.Bottom);
					if (HitTest.Contains(this.MousePoint, array))
					{
						this.DestinationRect = new Rectangle(rectangle.Right - 10, rectangle.Top, 21, rectangle.Height);
						this.DestinationSide = PlotDragSide.Right;
						this.Destination.List = plotLayoutBlockGroup.ListRight;
						this.DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
					}
					else
					{
						array[0] = new Point(rectangle.Left, rectangle.Top);
						array[1] = point;
						array[2] = new Point(rectangle.Right, rectangle.Top);
						if (HitTest.Contains(this.MousePoint, array))
						{
							this.DestinationRect = new Rectangle(rectangle.Left, rectangle.Top - 10, rectangle.Width, 21);
							this.DestinationSide = PlotDragSide.Top;
							this.Destination.List = plotLayoutBlockGroup.ListTop;
							this.DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
						}
						else
						{
							this.DestinationRect = new Rectangle(rectangle.Left, rectangle.Bottom - 10, rectangle.Width, 21);
							this.DestinationSide = PlotDragSide.Bottom;
							this.Destination.List = plotLayoutBlockGroup.ListBottom;
							this.DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
						}
					}
				}
			}
			else
			{
				rectangle = this.Destination.BoundsLayout;
				iRectangle iRectangle = new iRectangle(rectangle);
				if (this.Destination.Object != null && !this.Destination.Object.DockHorizontal)
				{
					iRectangle.Height /= 3;
					if (iRectangle.Rectangle.Contains(this.MousePoint))
					{
						rectangle.Offset(0, -10);
						this.DestinationRect = rectangle;
						this.DestinationSide = PlotDragSide.Top;
						if (this.Destination.Object.DockTop)
						{
							this.DestinationDockOrderOffset = PlotDragDockOrderOffset.Higher;
						}
						else
						{
							this.DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
						}
					}
					else
					{
						iRectangle.OffsetY(7);
						if (iRectangle.Rectangle.Contains(this.MousePoint))
						{
							this.DestinationRect = rectangle;
							this.DestinationSide = PlotDragSide.Stack;
							this.DestinationDockOrderOffset = PlotDragDockOrderOffset.Same;
						}
						else
						{
							rectangle.Offset(0, 10);
							this.DestinationRect = rectangle;
							this.DestinationSide = PlotDragSide.Bottom;
							if (this.Destination.Object.DockTop)
							{
								this.DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
							}
							else
							{
								this.DestinationDockOrderOffset = PlotDragDockOrderOffset.Higher;
							}
						}
					}
				}
				else
				{
					iRectangle.Width /= 3;
					if (iRectangle.Rectangle.Contains(this.MousePoint))
					{
						rectangle.Offset(-10, 0);
						this.DestinationRect = rectangle;
						this.DestinationSide = PlotDragSide.Left;
						if (this.Destination.Object.DockLeft)
						{
							this.DestinationDockOrderOffset = PlotDragDockOrderOffset.Higher;
						}
						else
						{
							this.DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
						}
					}
					else
					{
						iRectangle.OffsetX(7);
						if (iRectangle.Rectangle.Contains(this.MousePoint))
						{
							this.DestinationRect = rectangle;
							this.DestinationSide = PlotDragSide.Stack;
							this.DestinationDockOrderOffset = PlotDragDockOrderOffset.Same;
						}
						else
						{
							rectangle.Offset(10, 0);
							this.DestinationRect = rectangle;
							this.DestinationSide = PlotDragSide.Right;
							if (this.Destination.Object != null && !this.Destination.Object.DockLeft)
							{
								this.DestinationDockOrderOffset = PlotDragDockOrderOffset.Higher;
							}
							else
							{
								this.DestinationDockOrderOffset = PlotDragDockOrderOffset.Lower;
							}
						}
					}
				}
			}
		}

		public void Update()
		{
			bool flag = true;
			if (this.Source == null)
			{
				flag = false;
			}
			if (this.Destination == null)
			{
				flag = false;
			}
			if (this.Source == this.Destination)
			{
				flag = false;
			}
			if (this.Source != null && this.Destination != null)
			{
				if (this.Source.Object is PlotDataView && !(this.Destination.Object is PlotDataView))
				{
					flag = false;
				}
				if (this.Source.Object is PlotAxis)
				{
					if (this.Destination.Object == null)
					{
						flag = false;
					}
					else if (this.Destination.Object is PlotLayoutDockableAll && !(this.Destination.Object as PlotLayoutDockableAll).DocksToDataView)
					{
						flag = false;
					}
				}
			}
			if (!flag)
			{
				this.Visible = false;
			}
			else
			{
				this.Visible = true;
				this.UpdateDestinationSide();
				if (this.DestinationType == PlotDragType.Group)
				{
					Rectangle innerRectangleLayout = (this.Destination as PlotLayoutBlockGroup).InnerRectangleLayout;
				}
				else
				{
					Rectangle boundsLayout = this.Destination.BoundsLayout;
				}
				this.Bounds = this.DestinationRect;
				this.Destination.BackColor = Color.Wheat;
			}
		}

		public void FixupStacking(PlotLayoutBlockItemCollection list, int targetIndex)
		{
			PlotLayoutBlockItemCollection plotLayoutBlockItemCollection = new PlotLayoutBlockItemCollection();
			foreach (PlotLayoutBlockItem item in list)
			{
				if (item.Object.DockOrder == targetIndex)
				{
					plotLayoutBlockItemCollection.Add(item);
				}
			}
			plotLayoutBlockItemCollection.SortDockPercentStart();
			for (int i = 0; i < plotLayoutBlockItemCollection.Count; i++)
			{
				PlotLayoutBlockItem plotLayoutBlockItem2 = plotLayoutBlockItemCollection[i];
				PlotLayoutDockableDataView plotLayoutDockableDataView = plotLayoutBlockItem2.Object as PlotLayoutDockableDataView;
				if (plotLayoutDockableDataView != null)
				{
					plotLayoutDockableDataView.DockPercentStart = (double)i * 1.0 / (double)plotLayoutBlockItemCollection.Count;
					plotLayoutDockableDataView.DockPercentStop = plotLayoutDockableDataView.DockPercentStart + 1.0 / (double)plotLayoutBlockItemCollection.Count;
				}
			}
		}

		public void DropDockableAllOnDockableAll()
		{
			PlotLayoutDockableDataView plotLayoutDockableDataView = this.Source.Object as PlotLayoutDockableDataView;
			PlotLayoutDockableDataView plotLayoutDockableDataView2 = this.Destination.Object as PlotLayoutDockableDataView;
			int dockOrder = plotLayoutDockableDataView.DockOrder;
			bool flag = plotLayoutDockableDataView.DockDataViewName == plotLayoutDockableDataView2.DockDataViewName && plotLayoutDockableDataView.DockOrder == plotLayoutDockableDataView2.DockOrder && plotLayoutDockableDataView.DockSide == plotLayoutDockableDataView2.DockSide;
			plotLayoutDockableDataView.DockDataViewName = plotLayoutDockableDataView2.DockDataViewName;
			plotLayoutDockableDataView.DockSide = plotLayoutDockableDataView2.DockSide;
			if (this.DestinationDockOrderOffset == PlotDragDockOrderOffset.Higher)
			{
				if (this.Destination.List != null)
				{
					this.Source.List.Remove(this.Source);
					this.FixupStacking(this.Source.List, dockOrder);
					int num = this.Destination.Object.DockOrder + 1;
					foreach (PlotLayoutBlockItem item in this.Destination.List)
					{
						if (item.Object.DockOrder >= num)
						{
							item.Object.DockOrder++;
						}
					}
					plotLayoutDockableDataView.DockOrder = num;
					plotLayoutDockableDataView.DockPercentStart = 0.0;
					plotLayoutDockableDataView.DockPercentStop = 1.0;
				}
			}
			else if (this.DestinationDockOrderOffset == PlotDragDockOrderOffset.Lower)
			{
				if (this.Destination.List != null)
				{
					this.Source.List.Remove(this.Source);
					this.FixupStacking(this.Source.List, dockOrder);
					int num = this.Destination.Object.DockOrder;
					foreach (PlotLayoutBlockItem item2 in this.Destination.List)
					{
						if (item2.Object.DockOrder >= num)
						{
							item2.Object.DockOrder++;
						}
					}
					plotLayoutDockableDataView.DockOrder = num;
					plotLayoutDockableDataView.DockPercentStart = 0.0;
					plotLayoutDockableDataView.DockPercentStop = 1.0;
				}
			}
			else if (this.DestinationDockOrderOffset == PlotDragDockOrderOffset.Same)
			{
				if (!flag)
				{
					plotLayoutDockableDataView.DockOrder = plotLayoutDockableDataView2.DockOrder;
					this.Source.List.Remove(this.Source);
					this.Destination.List.Add(this.Source as PlotLayoutBlockItem);
					this.FixupStacking(this.Destination.List, plotLayoutDockableDataView2.DockOrder);
					this.FixupStacking(this.Source.List, dockOrder);
				}
				else
				{
					double dockPercentStart = plotLayoutDockableDataView.DockPercentStart;
					double dockPercentStop = plotLayoutDockableDataView.DockPercentStop;
					plotLayoutDockableDataView.DockPercentStart = plotLayoutDockableDataView2.DockPercentStart;
					plotLayoutDockableDataView.DockPercentStop = plotLayoutDockableDataView2.DockPercentStop;
					plotLayoutDockableDataView2.DockPercentStart = dockPercentStart;
					plotLayoutDockableDataView2.DockPercentStop = dockPercentStop;
				}
			}
		}

		public void DropDockableDataViewOnDataView()
		{
			PlotLayoutDockableDataView plotLayoutDockableDataView = this.Source.Object as PlotLayoutDockableDataView;
			PlotLayoutDataView plotLayoutDataView = this.Destination.Object as PlotLayoutDataView;
			int dockOrder = plotLayoutDockableDataView.DockOrder;
			plotLayoutDockableDataView.DockDataViewName = plotLayoutDataView.Name;
			if (this.DestinationSide == PlotDragSide.Left)
			{
				plotLayoutDockableDataView.DockSide = AlignmentQuadSide.Left;
			}
			else if (this.DestinationSide == PlotDragSide.Right)
			{
				plotLayoutDockableDataView.DockSide = AlignmentQuadSide.Right;
			}
			else if (this.DestinationSide == PlotDragSide.Top)
			{
				plotLayoutDockableDataView.DockSide = AlignmentQuadSide.Top;
			}
			else if (this.DestinationSide == PlotDragSide.Bottom)
			{
				plotLayoutDockableDataView.DockSide = AlignmentQuadSide.Bottom;
			}
			this.Source.List.Remove(this.Source);
			this.FixupStacking(this.Source.List, dockOrder);
			if (this.Destination.List != null)
			{
				if (this.Destination.List.Count != 0)
				{
					plotLayoutDockableDataView.DockOrder = this.Destination.List[0].Object.DockOrder - 1;
				}
				else
				{
					plotLayoutDockableDataView.DockOrder = 0;
				}
				plotLayoutDockableDataView.DockPercentStart = 0.0;
				plotLayoutDockableDataView.DockPercentStop = 1.0;
			}
		}

		public void DropDockableAllOnPlotDockGroup()
		{
			PlotLayoutDockableAll plotLayoutDockableAll = this.Source.Object as PlotLayoutDockableAll;
			plotLayoutDockableAll.DockDataViewName = "";
			PlotLayoutBlockItemCollection plotLayoutBlockItemCollection;
			if (this.DestinationSide == PlotDragSide.Left)
			{
				plotLayoutDockableAll.DockSide = AlignmentQuadSide.Left;
				plotLayoutBlockItemCollection = (this.Destination as PlotLayoutBlockGroup).ListLeft;
			}
			else if (this.DestinationSide == PlotDragSide.Right)
			{
				plotLayoutDockableAll.DockSide = AlignmentQuadSide.Right;
				plotLayoutBlockItemCollection = (this.Destination as PlotLayoutBlockGroup).ListRight;
			}
			else if (this.DestinationSide == PlotDragSide.Top)
			{
				plotLayoutDockableAll.DockSide = AlignmentQuadSide.Top;
				plotLayoutBlockItemCollection = (this.Destination as PlotLayoutBlockGroup).ListTop;
			}
			else
			{
				plotLayoutDockableAll.DockSide = AlignmentQuadSide.Bottom;
				plotLayoutBlockItemCollection = (this.Destination as PlotLayoutBlockGroup).ListBottom;
			}
			this.Source.List.Remove(this.Source);
			this.FixupStacking(this.Source.List, plotLayoutDockableAll.DockOrder);
			if (this.Destination.List != null)
			{
				if (plotLayoutBlockItemCollection.Count != 0)
				{
					plotLayoutDockableAll.DockOrder = plotLayoutBlockItemCollection[0].Object.DockOrder - 1;
				}
				else
				{
					plotLayoutDockableAll.DockOrder = 0;
				}
				plotLayoutDockableAll.DockPercentStart = 0.0;
				plotLayoutDockableAll.DockPercentStop = 1.0;
			}
		}

		public void DropDataViewOnDataView()
		{
			PlotLayoutDataView plotLayoutDataView = this.Source.Object as PlotLayoutDataView;
			PlotLayoutDataView plotLayoutDataView2 = this.Destination.Object as PlotLayoutDataView;
			if (this.DestinationSide != PlotDragSide.Top && this.DestinationSide != PlotDragSide.Bottom)
			{
				plotLayoutDataView.StackingGroupIndex = plotLayoutDataView2.StackingGroupIndex;
				if (this.DestinationSide == PlotDragSide.Left)
				{
					foreach (PlotLayoutDataView dataView in ((IPlotObject)plotLayoutDataView2).Plot.DataViews)
					{
						if (dataView.StackingGroupIndex < plotLayoutDataView2.StackingGroupIndex)
						{
							dataView.StackingGroupIndex--;
						}
					}
					plotLayoutDataView.DockOrder = 0;
					plotLayoutDataView.StackingGroupIndex = plotLayoutDataView2.StackingGroupIndex - 1;
				}
				else
				{
					foreach (PlotLayoutDataView dataView2 in ((IPlotObject)plotLayoutDataView2).Plot.DataViews)
					{
						if (dataView2.StackingGroupIndex > plotLayoutDataView2.StackingGroupIndex)
						{
							dataView2.StackingGroupIndex++;
						}
					}
					plotLayoutDataView.DockOrder = 0;
					plotLayoutDataView.StackingGroupIndex = plotLayoutDataView2.StackingGroupIndex + 1;
				}
			}
			else
			{
				plotLayoutDataView.StackingGroupIndex = plotLayoutDataView2.StackingGroupIndex;
				if (this.DestinationSide == PlotDragSide.Top)
				{
					foreach (PlotLayoutBlockGroup item in plotLayoutDataView2.StackingGroup.Items)
					{
						if (item.Object.DockOrder > plotLayoutDataView2.DockOrder)
						{
							item.Object.DockOrder++;
						}
					}
					plotLayoutDataView.DockOrder = plotLayoutDataView2.DockOrder + 1;
				}
				else
				{
					foreach (PlotLayoutBlockGroup item2 in plotLayoutDataView2.StackingGroup.Items)
					{
						if (item2.Object.DockOrder < plotLayoutDataView2.DockOrder)
						{
							item2.Object.DockOrder--;
						}
					}
					plotLayoutDataView.DockOrder = plotLayoutDataView2.DockOrder - 1;
				}
			}
		}

		public void CompleteDrag()
		{
			if (this.Visible)
			{
				PlotLayoutAxis plotLayoutAxis = this.Source.Object as PlotLayoutAxis;
				PlotLayoutAxis plotLayoutAxis2 = this.Destination.Object as PlotLayoutAxis;
				PlotLayoutDockableAll plotLayoutDockableAll = this.Source.Object as PlotLayoutDockableAll;
				PlotLayoutDockableAll plotLayoutDockableAll2 = this.Destination.Object as PlotLayoutDockableAll;
				PlotLayoutDockableDataView plotLayoutDockableDataView = this.Source.Object as PlotLayoutDockableDataView;
				PlotLayoutDockableDataView plotLayoutDockableDataView2 = this.Destination.Object as PlotLayoutDockableDataView;
				PlotLayoutDataView plotLayoutDataView = this.Source.Object as PlotLayoutDataView;
				PlotLayoutDataView plotLayoutDataView2 = this.Destination.Object as PlotLayoutDataView;
				if (plotLayoutDataView != null && plotLayoutDataView2 != null)
				{
					this.DropDataViewOnDataView();
				}
				else if (plotLayoutDockableDataView != null)
				{
					if (plotLayoutDockableDataView != null && plotLayoutDockableDataView2 != null)
					{
						this.DropDockableAllOnDockableAll();
					}
					else if (plotLayoutDockableDataView != null && plotLayoutDataView2 != null)
					{
						this.DropDockableDataViewOnDataView();
					}
					else if (plotLayoutDockableAll != null && this.Destination.Object == null)
					{
						this.DropDockableAllOnPlotDockGroup();
					}
					if (plotLayoutAxis != null && plotLayoutAxis2 != null)
					{
						plotLayoutAxis.DockStyle = plotLayoutAxis2.DockStyle;
					}
					else if (plotLayoutDockableAll != null && plotLayoutDockableAll2 != null)
					{
						plotLayoutDockableAll.DockStyle = plotLayoutDockableAll2.DockStyle;
					}
					else if (plotLayoutDockableAll != null && plotLayoutAxis2 != null)
					{
						plotLayoutDockableAll.DockStyle = PlotDockStyleAll.DataView;
					}
					else if (plotLayoutDockableAll != null && plotLayoutDataView2 != null)
					{
						plotLayoutDockableAll.DockStyle = PlotDockStyleAll.DataView;
					}
					else if (plotLayoutAxis != null && plotLayoutDataView2 != null)
					{
						plotLayoutAxis.DockStyle = PlotDockStyleAxis.DataView;
					}
					else if (plotLayoutDockableAll != null && this.Destination.Object == null)
					{
						plotLayoutDockableAll.DockStyle = PlotDockStyleAll.Plot;
					}
				}
				(this.m_ControlBase as PlotLayoutViewer).MakeDirty();
			}
		}

		public void Draw(PaintArgs p, Font font, Color foreColor, Color backColor)
		{
			if (this.Source != null && this.Visible)
			{
				string s = this.Source.Object.ToString();
				Rectangle bounds = this.Bounds;
				DrawStringFormat genericDefault = DrawStringFormat.GenericDefault;
				genericDefault.Alignment = StringAlignment.Center;
				genericDefault.LineAlignment = StringAlignment.Center;
				p.Graphics.FillRectangle(p.Graphics.Brush(backColor), bounds);
				BorderSimple.Draw(p, bounds, BorderStyleSimple.Raised, backColor);
				TextRotation rotation = (this.Destination.Object == null || this.Destination.Object is PlotDataView) ? ((this.DestinationSide != 0) ? ((this.DestinationSide == PlotDragSide.Right) ? TextRotation.X090 : TextRotation.X000) : TextRotation.X270) : ((!this.Destination.Object.DockLeft) ? (this.Destination.Object.DockRight ? TextRotation.X090 : TextRotation.X000) : TextRotation.X270);
				p.Graphics.DrawRotatedText(s, font, foreColor, bounds, rotation, genericDefault);
			}
		}
	}
}
