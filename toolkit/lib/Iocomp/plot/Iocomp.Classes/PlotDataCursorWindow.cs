using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Crosshair Window")]
	public class PlotDataCursorWindow : SubClassBase, IPlotDataCursorWindow
	{
		private PlotPen m_Line;

		protected IPlotPen I_Line;

		private int m_Size;

		private PlotDataCursorBase m_DataCursor;

		private Region m_HitRegion;

		Region IPlotDataCursorWindow.HitRegion
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

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotPen Line
		{
			get
			{
				return this.m_Line;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool Visible
		{
			get
			{
				return this.VisibleInternal;
			}
			set
			{
				this.VisibleInternal = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int Size
		{
			get
			{
				return this.m_Size;
			}
			set
			{
				base.PropertyUpdateDefault("Size", value);
				if (this.Size != value)
				{
					this.m_Size = value;
					base.DoPropertyChange(this, "Size");
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

		protected override string GetPlugInTitle()
		{
			return "Data-Cursor Window";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotDataCursorWindowEditorPlugIn";
		}

		void IPlotDataCursorWindow.Draw(PaintArgs p, Point centerPoint)
		{
			this.Draw(p, centerPoint);
		}

		public PlotDataCursorWindow()
		{
			base.DoCreate();
		}

		public PlotDataCursorWindow(PlotDataCursorBase value)
		{
			this.m_DataCursor = value;
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Line = new PlotPen();
			base.AddSubClass(this.Line);
			this.I_Line = this.Line;
			((ISubClassBase)this.Line).ColorAmbientSource = AmbientColorSouce.Color;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Visible = true;
			this.Size = 4;
		}

		private bool ShouldSerializeLine()
		{
			return ((ISubClassBase)this.Line).ShouldSerialize();
		}

		private void ResetLine()
		{
			((ISubClassBase)this.Line).ResetToDefault();
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeSize()
		{
			return base.PropertyShouldSerialize("Size");
		}

		private void ResetSize()
		{
			base.PropertyReset("Size");
		}

		private void Draw(PaintArgs p, Point centerPoint)
		{
			if (this.HitRegion != null)
			{
				this.HitRegion.Dispose();
				this.HitRegion = null;
			}
			if (this.Visible && this.DataCursor != null && this.XAxis != null && this.YAxis != null && this.DataCursor.Pointer1.Visible && this.DataCursor.Pointer1.AxisPosition != this.DataCursor.Pointer2.AxisPosition)
			{
				Rectangle rect = iRectangle.FromLTRB(centerPoint.X - this.Size, centerPoint.Y - this.Size, centerPoint.X + this.Size, centerPoint.Y + this.Size);
				if (this.Line.Visible)
				{
					p.Graphics.DrawEllipse(this.I_Line.GetPen(p), rect);
				}
			}
		}
	}
}
