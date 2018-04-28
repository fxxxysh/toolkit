using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Table Cell.")]
	public class PlotTableCell : IPlotTableCell
	{
		protected PlotTableBase m_Table;

		private Rectangle m_Bounds;

		private Rectangle m_BoundsText;

		private string m_Text;

		private Color m_ForeColor;

		private Font m_Font;

		private Size m_RequiredSize;

		private TextLayoutFull m_TextLayout;

		private bool m_Visible;

		private int m_ImageIndex;

		private ImageList m_ImageList;

		private bool m_ImageTransparent;

		private Size m_OuterMargin;

		private IAmbientOwner I_AmbientOwner;

		[Description("")]
		public Rectangle Bounds
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

		[Description("")]
		public Rectangle BoundsText
		{
			get
			{
				return this.m_BoundsText;
			}
		}

		[Description("")]
		public Size RequiredSize
		{
			get
			{
				return this.m_RequiredSize;
			}
			set
			{
				this.m_RequiredSize = value;
			}
		}

		[Description("")]
		public TextLayoutFull TextLayout
		{
			get
			{
				return this.m_TextLayout;
			}
		}

		[Description("")]
		public bool Visible
		{
			get
			{
				return this.m_Visible;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string Text
		{
			get
			{
				if (this.m_Text == null)
				{
					this.m_Text = Const.EmptyString;
				}
				return this.m_Text;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				if (this.Text != value)
				{
					this.m_Text = value;
					this.m_Table.DoCellChange();
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Font Font
		{
			get
			{
				if (this.m_Font == null && this.I_AmbientOwner != null)
				{
					return this.I_AmbientOwner.Font;
				}
				return this.m_Font;
			}
			set
			{
				if (!GPFunctions.Equals(this.Font, value))
				{
					this.m_Font = value;
					this.m_Table.DoCellChange();
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color ForeColor
		{
			get
			{
				if (this.m_ForeColor == Color.Empty && this.I_AmbientOwner != null)
				{
					return this.I_AmbientOwner.ForeColor;
				}
				return this.m_ForeColor;
			}
			set
			{
				if (this.ForeColor != value)
				{
					this.m_ForeColor = value;
					this.m_Table.DoCellChange();
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public ImageList ImageList
		{
			get
			{
				Plot plot = null;
				if (this.m_Table != null)
				{
					plot = ((IPlotObject)this.m_Table).Plot;
				}
				if (this.m_ImageList == null && plot != null)
				{
					return plot.ImageListCommon;
				}
				return this.m_ImageList;
			}
			set
			{
				if (!GPFunctions.Equals(this.ImageList, value))
				{
					this.m_ImageList = value;
					this.m_Table.DoCellChange();
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int ImageIndex
		{
			get
			{
				return this.m_ImageIndex;
			}
			set
			{
				if (this.ImageIndex != value)
				{
					this.m_ImageIndex = value;
					this.m_Table.DoCellChange();
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ImageTransparent
		{
			get
			{
				return this.m_ImageTransparent;
			}
			set
			{
				if (this.ImageTransparent != value)
				{
					this.m_ImageTransparent = value;
					this.m_Table.DoCellChange();
				}
			}
		}

		void IPlotTableCell.Draw(PaintArgs p, bool showGrid, Pen gridPen)
		{
			this.Draw(p, showGrid, gridPen);
		}

		void IPlotTableCell.UpdateRequiredSize(PaintArgs p, bool visible, Size outerMargin, int fixedWidth, int fixedHeight)
		{
			this.UpdateRequiredSize(p, visible, outerMargin, fixedWidth, fixedHeight);
		}

		public PlotTableCell(PlotTableBase table, PlotTableCellFormat cellFormat)
		{
			this.m_Table = table;
			this.m_TextLayout = cellFormat.TextLayout;
			this.I_AmbientOwner = cellFormat;
			this.m_ImageIndex = -1;
		}

		protected Image GetImage()
		{
			if (this.ImageList != null && this.ImageIndex >= 0 && this.ImageIndex < this.ImageList.Images.Count)
			{
				return this.ImageList.Images[this.ImageIndex];
			}
			return null;
		}

		private void UpdateRequiredSize(PaintArgs p, bool visible, Size outerMargin, int fixedWidth, int fixedHeight)
		{
			this.m_Visible = visible;
			this.m_OuterMargin = outerMargin;
			if (!visible)
			{
				this.m_RequiredSize = Size.Empty;
			}
			else
			{
				Image image = this.GetImage();
				if (image == null)
				{
					this.m_RequiredSize = ((ITextLayoutBase)this.TextLayout).GetRequiredSize(this.Text, this.Font, p.Graphics);
				}
				else
				{
					this.m_RequiredSize = image.Size;
				}
				if (fixedWidth != -1)
				{
					this.m_RequiredSize = new Size(fixedWidth, this.m_RequiredSize.Height);
				}
				if (fixedHeight != -1)
				{
					this.m_RequiredSize = new Size(this.m_RequiredSize.Width, fixedHeight);
				}
				this.m_RequiredSize = new Size(this.m_RequiredSize.Width + 2 * this.m_OuterMargin.Width, this.m_RequiredSize.Height + 2 * this.m_OuterMargin.Height);
			}
		}

		private void Draw(PaintArgs p, bool showGrid, Pen gridPen)
		{
			if (this.Visible)
			{
				Region clip = p.Graphics.Clip;
				Image image = this.GetImage();
				this.m_BoundsText = this.Bounds;
				this.m_BoundsText.Inflate(-this.m_OuterMargin.Width, -this.m_OuterMargin.Height);
				p.Graphics.SetClip(this.Bounds);
				if (image == null)
				{
					((ITextLayoutBase)this.TextLayout).Draw(p.Graphics, this.Font, p.Graphics.Brush(this.ForeColor), this.Text, this.BoundsText);
				}
				else
				{
					Point point = new Point(this.BoundsText.Left, this.BoundsText.Top);
					Rectangle r = new Rectangle(point.X, point.Y, image.Width, image.Height);
					if (this.ImageTransparent)
					{
						p.Graphics.DrawImageTransparent(image, r);
					}
					else
					{
						p.Graphics.DrawImage(image, point.X, point.Y);
					}
				}
				p.Graphics.Clip = clip;
				if (showGrid)
				{
					p.Graphics.DrawRectangle(gridPen, this.Bounds);
				}
			}
		}
	}
}
