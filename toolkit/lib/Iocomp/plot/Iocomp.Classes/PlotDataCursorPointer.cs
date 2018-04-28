using Iocomp.Interfaces;
using Iocomp.Types;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor Pointer")]
	public class PlotDataCursorPointer : SubClassBase, IPlotDataCursorPointer
	{
		private bool m_Visible;

		private double m_Position;

		private int m_PositionPixels;

		private PlotAxisReference m_Style;

		private PlotDataCursorBase m_DataCursor;

		private Region m_HitRegion;

		private bool m_MouseActive;

		private double m_MouseDownPosition;

		private double m_MouseDownActual;

		private ArrayList m_PositionArray;

		Region IPlotDataCursorPointer.HitRegion
		{
			get
			{
				return this.m_HitRegion;
			}
			set
			{
				this.m_HitRegion = value;
			}
		}

		bool IPlotDataCursorPointer.MouseActive
		{
			get
			{
				return this.m_MouseActive;
			}
			set
			{
				this.m_MouseActive = value;
			}
		}

		double IPlotDataCursorPointer.MouseDownPosition
		{
			get
			{
				return this.m_MouseDownPosition;
			}
			set
			{
				this.m_MouseDownPosition = value;
			}
		}

		double IPlotDataCursorPointer.MouseDownActual
		{
			get
			{
				return this.m_MouseDownActual;
			}
			set
			{
				this.m_MouseDownActual = value;
			}
		}

		public bool Visible
		{
			get
			{
				return this.m_Visible;
			}
			set
			{
				this.m_Visible = value;
			}
		}

		public PlotAxisReference Style
		{
			get
			{
				return this.m_Style;
			}
			set
			{
				this.m_Style = value;
			}
		}

		public double Position
		{
			get
			{
				return this.m_Position;
			}
			set
			{
				if (this.m_Position != value)
				{
					this.m_Position = value;
					base.DoPropertyChange(this, "Position");
				}
			}
		}

		private PlotXAxis XAxis
		{
			get
			{
				if (this.DataCursor == null)
				{
					return null;
				}
				return this.DataCursor.XAxis;
			}
		}

		private PlotYAxis YAxis
		{
			get
			{
				if (this.DataCursor == null)
				{
					return null;
				}
				return this.DataCursor.YAxis;
			}
		}

		private PlotDataCursorBase DataCursor => this.m_DataCursor;

		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		public PlotAxis AxisPosition
		{
			get
			{
				if (this.DataCursor == null)
				{
					return null;
				}
				if (this.Style == PlotAxisReference.XAxis)
				{
					return this.DataCursor.XAxis;
				}
				return this.DataCursor.YAxis;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PlotAxis AxisRange
		{
			get
			{
				if (this.DataCursor == null)
				{
					return null;
				}
				if (this.Style == PlotAxisReference.XAxis)
				{
					return this.DataCursor.YAxis;
				}
				return this.DataCursor.XAxis;
			}
		}

		public int PositionPixels => this.AxisPosition.PercentToPixels(this.Position);

		private Region HitRegion
		{
			get
			{
				return this.m_HitRegion;
			}
			set
			{
				this.m_HitRegion = value;
			}
		}

		void IPlotDataCursorPointer.Draw(PaintArgs p, Pen pen, PlotDataCursorDisplayCollection displays)
		{
			this.Draw(p, pen, displays);
		}

		public PlotDataCursorPointer()
		{
			base.DoCreate();
		}

		public PlotDataCursorPointer(PlotDataCursorBase value)
		{
			this.m_DataCursor = value;
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_PositionArray = new ArrayList();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Position = 0.5;
		}

		private void Draw(PaintArgs p, Pen pen, PlotDataCursorDisplayCollection displays)
		{
			if (this.HitRegion != null)
			{
				this.HitRegion.Dispose();
				this.HitRegion = null;
			}
			if (this.Visible && this.DataCursor != null && this.XAxis != null && this.YAxis != null)
			{
				bool swap = this.Style == PlotAxisReference.YAxis ^ this.DataCursor.XYSwapped;
				PlotAxis axisPosition = this.AxisPosition;
				PlotAxis axisRange = this.AxisRange;
				int positionPixels = this.PositionPixels;
				int dataViewPixelsMin = axisRange.DataViewPixelsMin;
				int dataViewPixelsMax = axisRange.DataViewPixelsMax;
				this.m_PositionArray.Clear();
				this.m_PositionArray.Add(dataViewPixelsMin);
				this.m_PositionArray.Add(dataViewPixelsMax);
				if (this.DataCursor.WindowShowing)
				{
					foreach (PlotDataCursorDisplay display in displays)
					{
						if (!display.DisableWindow)
						{
							if (this.Style == PlotAxisReference.XAxis)
							{
								this.m_PositionArray.Add(this.AxisRange.PercentToPixels(display.YPosition) - this.DataCursor.Window.Size);
								this.m_PositionArray.Add(this.AxisRange.PercentToPixels(display.YPosition) + this.DataCursor.Window.Size);
							}
							else
							{
								this.m_PositionArray.Add(this.AxisRange.PercentToPixels(display.XPosition) - this.DataCursor.Window.Size);
								this.m_PositionArray.Add(this.AxisRange.PercentToPixels(display.XPosition) + this.DataCursor.Window.Size);
							}
						}
					}
				}
				this.m_PositionArray.Sort();
				for (int i = 0; i < this.m_PositionArray.Count; i += 2)
				{
					Point pt = iDraw.Point(swap, positionPixels, (int)this.m_PositionArray[i]);
					Point pt2 = iDraw.Point(swap, positionPixels, (int)this.m_PositionArray[i + 1]);
					p.Graphics.DrawLine(pen, pt, pt2);
				}
				Rectangle b = iRectangle.FromLTRB(swap, positionPixels, dataViewPixelsMin, positionPixels, dataViewPixelsMax);
				b.Inflate(this.DataCursor.HitRegionSize, this.DataCursor.HitRegionSize);
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddRectangle(Rectangle.Intersect(this.DataCursor.BoundsClip, b));
				this.HitRegion = new Region(graphicsPath);
				this.m_PositionPixels = positionPixels;
			}
		}
	}
}
