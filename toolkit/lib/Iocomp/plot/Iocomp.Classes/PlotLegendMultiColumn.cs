using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Legend with a list of channels and the option to add multi-colums with channel statistics")]
	public class PlotLegendMultiColumn : PlotLegendBase
	{
		private PlotLegendMultiColumnItemCollection m_Columns;

		private PlotLegendMultiColumnCellFormatting m_CellFormatting;

		private iRectangle m_Rect;

		private int m_MarginOuterPixels;

		private int m_LengthPixels;

		protected override IComponentBase ComponentBase
		{
			get
			{
				return base.ComponentBase;
			}
			set
			{
				base.ComponentBase = value;
				((ICollectionBase)this.m_Columns).ComponentBase = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotLegendMultiColumnItemCollection Columns
		{
			get
			{
				return this.m_Columns;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Iocomp")]
		[Description("")]
		public PlotLegendMultiColumnCellFormatting CellFormatting
		{
			get
			{
				return this.m_CellFormatting;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Legend Multi-Column";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLegendMultiColumnEditorPlugIn";
		}

		public PlotLegendMultiColumn()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Rect = new iRectangle();
			this.m_CellFormatting = new PlotLegendMultiColumnCellFormatting();
			base.AddSubClass(this.CellFormatting);
			this.m_Columns = new PlotLegendMultiColumnItemCollection(this.ComponentBase);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Multi-Column";
		}

		private bool ShouldSerializeColumns()
		{
			return this.Columns.Count != 0;
		}

		private void ResetColumns()
		{
			this.Columns.Clear();
		}

		private bool ShouldSerializeCellFormatting()
		{
			return ((ISubClassBase)this.CellFormatting).ShouldSerialize();
		}

		private void ResetCellFormatting()
		{
			((ISubClassBase)this.CellFormatting).ResetToDefault();
		}

		protected override void CalculateDepthPixels(PaintArgs p)
		{
			base.UpdateChannelList();
			this.m_MarginOuterPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(base.Font).Height * base.MarginOuter);
			int drawPixelsMarginOuter = (int)Math.Ceiling((double)p.Graphics.MeasureString(this.CellFormatting.TitleFont).Height * this.CellFormatting.MarginOuter);
			int height = p.Graphics.MeasureString(this.CellFormatting.DataFont).Height;
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			foreach (IPlotLegendMultiColumnItem column in this.Columns)
			{
				column.DrawTitleFont = this.CellFormatting.TitleFont;
				column.DrawDataFont = this.CellFormatting.DataFont;
				column.DrawPixelsMarginOuter = drawPixelsMarginOuter;
				column.DrawPixelsMarkerMinWidth = height;
				column.Calculate(p, base.Channels);
				num2 = Math.Max(num2, column.DrawPixelsHeightTitle);
				num += column.DrawPixelsTextWidth + 2 * column.DrawPixelsMarginOuter;
			}
			foreach (IPlotLegendMultiColumnItem column2 in this.Columns)
			{
				column2.DrawPixelsHeightTitle = num2;
				num3 = column2.DrawPixelsHeightTitle + 2 * column2.DrawPixelsMarginOuter + base.ItemCount * (column2.DrawPixelsHeightData + 2 * column2.DrawPixelsMarginOuter);
			}
			this.m_LengthPixels = num3 + 2 * this.m_MarginOuterPixels;
			base.DockDepthPixels = num + 2 * this.m_MarginOuterPixels;
		}

		protected override void DrawCalculations(PaintArgs p)
		{
			base.CalculateBoundsAlignment(this.m_LengthPixels);
		}

		protected override void Draw(PaintArgs p)
		{
			base.I_Fill.Draw(p, base.BoundsAlignment);
			int num = base.BoundsAlignment.Left + this.m_MarginOuterPixels;
			int num2 = base.BoundsAlignment.Top + this.m_MarginOuterPixels;
			int num3 = base.BoundsAlignment.Bottom - this.m_MarginOuterPixels;
			foreach (IPlotLegendMultiColumnItem column in this.Columns)
			{
				int num4 = column.DrawPixelsTextWidth + 2 * column.DrawPixelsMarginOuter;
				Rectangle r = new Rectangle(num, num2, num4, num3 - num2);
				column.Draw(p, base.Channels, r);
				num += num4;
			}
		}
	}
}
