using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Table Base.")]
	public abstract class PlotTableBase : PlotLayoutFill
	{
		private int m_DataColCount;

		private int m_DataRowCount;

		private SizeStyle m_ColWidthStyle;

		private double m_ColWidthValue;

		private double m_ColOuterMargin;

		private SizeStyle m_RowHeightStyle;

		private double m_RowHeightValue;

		private double m_RowOuterMargin;

		private bool m_ColTitlesVisible;

		private bool m_RowTitlesVisible;

		private PlotTableCellsFormatting m_CellsFormatting;

		private PlotPen m_GridOutline;

		protected IPlotPen I_GridOutline;

		private int m_MarginOuterPixels;

		private int m_LengthPixels;

		private Size m_CellOuterMargin;

		private ITextLayoutFull I_TextLayoutDat;

		private ITextLayoutFull I_TextLayoutCol;

		private ITextLayoutFull I_TextLayoutRow;

		private Array m_Cells;

		private ArrayList m_ColWidths;

		private ArrayList m_RowHeights;

		private bool m_IgnoreCellChanges;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotTableCellsFormatting CellsFormatting
		{
			get
			{
				return this.m_CellsFormatting;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotPen GridOutline
		{
			get
			{
				return this.m_GridOutline;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool ColTitlesVisible
		{
			get
			{
				return this.m_ColTitlesVisible;
			}
			set
			{
				base.PropertyUpdateDefault("ColTitlesVisible", value);
				if (this.ColTitlesVisible != value)
				{
					this.m_ColTitlesVisible = value;
					this.RegenerateArray();
					base.DoPropertyChange(this, "ColTitlesVisible");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool RowTitlesVisible
		{
			get
			{
				return this.m_RowTitlesVisible;
			}
			set
			{
				base.PropertyUpdateDefault("RowTitlesVisible", value);
				if (this.RowTitlesVisible != value)
				{
					this.m_RowTitlesVisible = value;
					this.RegenerateArray();
					base.DoPropertyChange(this, "RowTitlesVisible");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		public PlotTableCell this[int col, int row]
		{
			get
			{
				return (PlotTableCell)this.m_Cells.GetValue(col, row);
			}
		}

		protected int DataColCount
		{
			get
			{
				return this.m_DataColCount;
			}
			set
			{
				base.PropertyUpdateDefault("DataColCount", value);
				if (this.DataColCount != value)
				{
					this.m_DataColCount = value;
					this.RegenerateArray();
					base.DoPropertyChange(this, "DataColCount");
				}
			}
		}

		protected int DataRowCount
		{
			get
			{
				return this.m_DataRowCount;
			}
			set
			{
				base.PropertyUpdateDefault("DataRowCount", value);
				if (this.DataRowCount != value)
				{
					this.m_DataRowCount = value;
					this.RegenerateArray();
					base.DoPropertyChange(this, "DataRowCount");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public SizeStyle ColWidthStyle
		{
			get
			{
				return this.m_ColWidthStyle;
			}
			set
			{
				base.PropertyUpdateDefault("ColWidthStyle", value);
				if (this.ColWidthStyle != value)
				{
					this.m_ColWidthStyle = value;
					base.DoPropertyChange(this, "ColWidthStyle");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double ColWidthValue
		{
			get
			{
				return this.m_ColWidthValue;
			}
			set
			{
				base.PropertyUpdateDefault("ColWidthValue", value);
				if (this.ColWidthValue != value)
				{
					this.m_ColWidthValue = value;
					base.DoPropertyChange(this, "ColWidthValue");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double ColOuterMargin
		{
			get
			{
				return this.m_ColOuterMargin;
			}
			set
			{
				base.PropertyUpdateDefault("ColOuterMargin", value);
				if (this.ColOuterMargin != value)
				{
					this.m_ColOuterMargin = value;
					base.DoPropertyChange(this, "ColOuterMargin");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public SizeStyle RowHeightStyle
		{
			get
			{
				return this.m_RowHeightStyle;
			}
			set
			{
				base.PropertyUpdateDefault("RowHeightStyle", value);
				if (this.RowHeightStyle != value)
				{
					this.m_RowHeightStyle = value;
					base.DoPropertyChange(this, "RowHeightStyle");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double RowHeightValue
		{
			get
			{
				return this.m_RowHeightValue;
			}
			set
			{
				base.PropertyUpdateDefault("RowHeightValue", value);
				if (this.RowHeightValue != value)
				{
					this.m_RowHeightValue = value;
					base.DoPropertyChange(this, "RowHeightValue");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double RowOuterMargin
		{
			get
			{
				return this.m_RowOuterMargin;
			}
			set
			{
				base.PropertyUpdateDefault("RowOuterMargin", value);
				if (this.RowOuterMargin != value)
				{
					this.m_RowOuterMargin = value;
					base.DoPropertyChange(this, "RowOuterMargin");
				}
			}
		}

		public int ActualColCount => this.DataColCount + 1;

		public int ActualRowCount => this.DataRowCount + 1;

		protected int MarginOuterPixels => this.m_MarginOuterPixels;

		protected int LengthPixels => this.m_LengthPixels;

		protected bool IgnoreCellChanges
		{
			get
			{
				return this.m_IgnoreCellChanges;
			}
			set
			{
				this.m_IgnoreCellChanges = value;
			}
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_CellsFormatting = new PlotTableCellsFormatting();
			base.AddSubClass(this.CellsFormatting);
			this.m_GridOutline = new PlotPen();
			base.AddSubClass(this.GridOutline);
			this.I_GridOutline = this.GridOutline;
			this.I_TextLayoutDat = this.CellsFormatting.Data.TextLayout;
			this.I_TextLayoutCol = this.CellsFormatting.ColTitles.TextLayout;
			this.I_TextLayoutRow = this.CellsFormatting.RowTitles.TextLayout;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.DockSide = AlignmentQuadSide.Right;
			this.DataColCount = 5;
			this.DataRowCount = 1;
			this.ColWidthStyle = SizeStyle.Auto;
			this.ColWidthValue = 6.0;
			this.ColOuterMargin = 1.0;
			this.RowHeightStyle = SizeStyle.Auto;
			this.RowHeightValue = 2.0;
			this.RowOuterMargin = 0.25;
			this.ColTitlesVisible = false;
			this.RowTitlesVisible = false;
			this.GridOutline.Color = Color.Empty;
			this.GridOutline.Thickness = 1.0;
			this.GridOutline.Style = PlotPenStyle.Solid;
			this.GridOutline.Visible = true;
		}

		private bool ShouldSerializeCellsFormatting()
		{
			return ((ISubClassBase)this.CellsFormatting).ShouldSerialize();
		}

		private void ResetCellsFormatting()
		{
			((ISubClassBase)this.CellsFormatting).ResetToDefault();
		}

		private bool ShouldSerializeGridOutline()
		{
			return ((ISubClassBase)this.GridOutline).ShouldSerialize();
		}

		private void ResetGridOutline()
		{
			((ISubClassBase)this.GridOutline).ResetToDefault();
		}

		private bool ShouldSerializeColTitlesVisible()
		{
			return base.PropertyShouldSerialize("ColTitlesVisible");
		}

		private void ResetColTitlesVisible()
		{
			base.PropertyReset("ColTitlesVisible");
		}

		private bool ShouldSerializeRowTitlesVisible()
		{
			return base.PropertyShouldSerialize("RowTitlesVisible");
		}

		private void ResetRowTitlesVisible()
		{
			base.PropertyReset("RowTitlesVisible");
		}

		private bool ShouldSerializeColWidthStyle()
		{
			return base.PropertyShouldSerialize("ColWidthStyle");
		}

		private void ResetColWidthStyle()
		{
			base.PropertyReset("ColWidthStyle");
		}

		private bool ShouldSerializeColWidthValue()
		{
			return base.PropertyShouldSerialize("ColWidthValue");
		}

		private void ResetColWidthValue()
		{
			base.PropertyReset("ColWidthValue");
		}

		private bool ShouldSerializeColOuterMargin()
		{
			return base.PropertyShouldSerialize("ColOuterMargin");
		}

		private void ResetColOuterMargin()
		{
			base.PropertyReset("ColOuterMargin");
		}

		private bool ShouldSerializeRowHeightStyle()
		{
			return base.PropertyShouldSerialize("RowHeightStyle");
		}

		private void ResetRowHeightStyle()
		{
			base.PropertyReset("RowHeightStyle");
		}

		private bool ShouldSerializeRowHeightValue()
		{
			return base.PropertyShouldSerialize("RowHeightValue");
		}

		private void ResetRowHeightValue()
		{
			base.PropertyReset("RowHeightValue");
		}

		private bool ShouldSerializeRowOuterMargin()
		{
			return base.PropertyShouldSerialize("RowOuterMargin");
		}

		private void ResetRowOuterMargin()
		{
			base.PropertyReset("RowOuterMargin");
		}

		private void RegenerateArray()
		{
			Array cells = this.m_Cells;
			this.m_Cells = Array.CreateInstance(typeof(PlotTableCell), this.ActualColCount, this.ActualRowCount);
			this.m_ColWidths = new ArrayList();
			for (int i = 0; i < this.ActualColCount; i++)
			{
				this.m_ColWidths.Add(0);
			}
			this.m_RowHeights = new ArrayList();
			for (int j = 0; j < this.ActualRowCount; j++)
			{
				this.m_RowHeights.Add(0);
			}
			for (int k = 0; k < this.ActualRowCount; k++)
			{
				for (int l = 0; l < this.ActualColCount; l++)
				{
					bool flag = true;
					if (cells == null)
					{
						flag = false;
					}
					if (cells != null && l > cells.GetUpperBound(0))
					{
						flag = false;
					}
					if (cells != null && k > cells.GetUpperBound(1))
					{
						flag = false;
					}
					object obj = (!flag) ? ((l != 0) ? ((k != 0) ? new PlotTableCell(this, this.CellsFormatting.Data) : new PlotTableCell(this, this.CellsFormatting.ColTitles)) : new PlotTableCell(this, this.CellsFormatting.RowTitles)) : cells.GetValue(l, k);
					this.m_Cells.SetValue(obj, l, k);
					if (k == 0)
					{
						(obj as PlotTableCell).Text = "C" + l.ToString();
					}
					else if (l == 0)
					{
						(obj as PlotTableCell).Text = "R" + k.ToString();
					}
					else
					{
						(obj as PlotTableCell).Text = "0";
					}
				}
			}
		}

		[Browsable(false)]
		public void DoCellChange()
		{
			if (!this.IgnoreCellChanges && base.Plot != null)
			{
				base.Plot.CodeInvalidate(this);
			}
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (shouldFocus)
			{
				base.Focus();
			}
		}

		private Size GetMaxTextSize(PaintArgs p, string[] strings, ITextLayoutFull textLayout, Font font)
		{
			Size size = Size.Empty;
			for (int i = 0; i < strings.Length; i++)
			{
				size = Math2.Max(size, textLayout.GetRequiredSize(strings[i], font, p.Graphics));
			}
			return size;
		}

		protected override void CalculateDepthPixels(PaintArgs p)
		{
			this.m_MarginOuterPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(base.Font).Height * base.MarginOuter);
			Size size = p.Graphics.MeasureString(this.CellsFormatting.Data.Font);
			Size size2 = p.Graphics.MeasureString(this.CellsFormatting.ColTitles.Font);
			Size size3 = p.Graphics.MeasureString(this.CellsFormatting.RowTitles.Font);
			if (!this.ColTitlesVisible)
			{
				size2 = new Size(0, 0);
			}
			if (!this.RowTitlesVisible)
			{
				size3 = new Size(0, 0);
			}
			Size size4 = size;
			size4 = Math2.Max(size4, size2);
			size4 = Math2.Max(size4, size3);
			this.m_CellOuterMargin = new Size((int)((double)size4.Width * this.ColOuterMargin), (int)((double)size4.Height * this.RowOuterMargin));
			int fixedWidth = (this.ColWidthStyle != SizeStyle.FixedPixels) ? ((this.ColWidthStyle != SizeStyle.FixedCharacters) ? (-1) : ((int)((double)size4.Width * this.ColWidthValue))) : ((int)this.ColWidthValue);
			int fixedHeight = (this.RowHeightStyle != SizeStyle.FixedPixels) ? ((this.RowHeightStyle != SizeStyle.FixedCharacters) ? (-1) : ((int)((double)size4.Height * this.RowHeightValue))) : ((int)this.RowHeightValue);
			for (int i = 0; i < this.ActualColCount; i++)
			{
				for (int j = 0; j < this.ActualRowCount; j++)
				{
					PlotTableCell plotTableCell = this[i, j];
					if (i == 0 && j == 0)
					{
						((IPlotTableCell)plotTableCell).UpdateRequiredSize(p, false, this.m_CellOuterMargin, fixedWidth, fixedHeight);
					}
					else if (j == 0)
					{
						((IPlotTableCell)plotTableCell).UpdateRequiredSize(p, this.ColTitlesVisible, this.m_CellOuterMargin, fixedWidth, fixedHeight);
					}
					else if (i == 0)
					{
						((IPlotTableCell)plotTableCell).UpdateRequiredSize(p, this.RowTitlesVisible, this.m_CellOuterMargin, fixedWidth, fixedHeight);
					}
					else
					{
						((IPlotTableCell)plotTableCell).UpdateRequiredSize(p, true, this.m_CellOuterMargin, fixedWidth, fixedHeight);
					}
				}
			}
			for (int k = 0; k < this.ActualColCount; k++)
			{
				this.m_ColWidths[k] = 0;
			}
			for (int l = 0; l < this.ActualRowCount; l++)
			{
				this.m_RowHeights[l] = 0;
			}
			for (int m = 0; m < this.ActualColCount; m++)
			{
				for (int n = 0; n < this.ActualRowCount; n++)
				{
					PlotTableCell plotTableCell = this[m, n];
					if (plotTableCell.RequiredSize.Width > (int)this.m_ColWidths[m])
					{
						this.m_ColWidths[m] = plotTableCell.RequiredSize.Width;
					}
					if (plotTableCell.RequiredSize.Height > (int)this.m_RowHeights[n])
					{
						this.m_RowHeights[n] = plotTableCell.RequiredSize.Height;
					}
				}
			}
			int num = 2 * this.m_MarginOuterPixels;
			int num2 = 2 * this.m_MarginOuterPixels;
			for (int num3 = 0; num3 < this.ActualColCount; num3++)
			{
				num += (int)this.m_ColWidths[num3];
			}
			for (int num4 = 0; num4 < this.ActualRowCount; num4++)
			{
				num2 += (int)this.m_RowHeights[num4];
			}
			Size size5 = new Size(num, num2);
			if (base.DockHorizontal)
			{
				base.DockDepthPixels = size5.Width;
				this.m_LengthPixels = size5.Height;
			}
			else
			{
				base.DockDepthPixels = size5.Height;
				this.m_LengthPixels = size5.Width;
			}
		}

		protected override void DrawCalculations(PaintArgs p)
		{
			base.CalculateBoundsAlignment(this.m_LengthPixels);
		}

		protected override void Draw(PaintArgs p)
		{
			base.I_Fill.Draw(p, base.BoundsAlignment);
			Rectangle boundsAlignment = base.BoundsAlignment;
			boundsAlignment.Inflate(-this.MarginOuterPixels, -this.MarginOuterPixels);
			Rectangle r = boundsAlignment;
			Rectangle r2 = new Rectangle(boundsAlignment.Left, boundsAlignment.Top, boundsAlignment.Width, (int)this.m_RowHeights[0]);
			Rectangle r3 = new Rectangle(boundsAlignment.Left, boundsAlignment.Top, (int)this.m_ColWidths[0], boundsAlignment.Height);
			if (this.RowTitlesVisible)
			{
				r.Offset((int)this.m_ColWidths[0], 0);
				r2.Offset((int)this.m_ColWidths[0], 0);
			}
			if (this.ColTitlesVisible)
			{
				r.Offset(0, (int)this.m_RowHeights[0]);
				r3.Offset(0, (int)this.m_RowHeights[0]);
			}
			r.Intersect(boundsAlignment);
			r2.Intersect(boundsAlignment);
			r3.Intersect(boundsAlignment);
			((IPlotTableCellFormat)this.CellsFormatting.Data).Draw(p, r);
			if (this.ColTitlesVisible)
			{
				((IPlotTableCellFormat)this.CellsFormatting.ColTitles).Draw(p, r2);
			}
			if (this.RowTitlesVisible)
			{
				((IPlotTableCellFormat)this.CellsFormatting.RowTitles).Draw(p, r3);
			}
			int num = boundsAlignment.Top;
			for (int i = 0; i < this.ActualRowCount; i++)
			{
				int num2 = (int)this.m_RowHeights[i];
				int num3 = boundsAlignment.Left;
				for (int j = 0; j < this.ActualColCount; j++)
				{
					PlotTableCell plotTableCell = this[j, i];
					int num4 = (int)this.m_ColWidths[j];
					plotTableCell.Bounds = new Rectangle(num3, num, num4, num2);
					((IPlotTableCell)plotTableCell).Draw(p, this.GridOutline.Visible, ((IPlotPen)this.GridOutline).GetPen(p));
					num3 += num4;
				}
				num += num2;
			}
		}

		protected override void DrawFocusRectangles(PaintArgs p)
		{
			if (base.Focused)
			{
				Rectangle boundsAlignment = base.BoundsAlignment;
				boundsAlignment.Inflate(2, 2);
				p.Graphics.DrawFocusRectangle(boundsAlignment, base.BackColor);
			}
		}
	}
}
