using System.Drawing;

namespace Iocomp.Classes
{
	public class PlotColorTableEntry
	{
		private Color m_Color;

		private int m_Count;

		public Color Color
		{
			get
			{
				return this.m_Color;
			}
			set
			{
				this.m_Color = value;
			}
		}

		public int Count
		{
			get
			{
				return this.m_Count;
			}
			set
			{
				this.m_Count = value;
			}
		}

		public PlotColorTableEntry(Color color)
		{
			this.m_Color = color;
		}
	}
}
