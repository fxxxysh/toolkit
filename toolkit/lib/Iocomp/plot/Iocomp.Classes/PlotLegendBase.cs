using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Legend Base.")]
	public abstract class PlotLegendBase : PlotLayoutFill
	{
		private PlotObjectCollection m_ChannelList;

		protected int ItemCount => this.m_ChannelList.Count;

		protected PlotObjectCollection Channels => this.m_ChannelList;

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_ChannelList = new PlotObjectCollection();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.DockSide = AlignmentQuadSide.Right;
			base.DockAutoSizeAlignment = PlotDockAutoSizeAlignment.Near;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (shouldFocus)
			{
				base.Focus();
			}
		}

		protected void UpdateChannelList()
		{
			this.m_ChannelList.Clear();
			if (base.Plot != null)
			{
				foreach (PlotChannelBase channel in base.Plot.Channels)
				{
					if (channel.VisibleInLegend && channel.LegendName.Trim().ToUpper() == base.Name.Trim().ToUpper())
					{
						this.m_ChannelList.Add(channel);
					}
				}
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
