using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Color Table.")]
	public class PlotColorTable
	{
		private ArrayList m_List;

		public int Count => this.m_List.Count;

		public PlotColorTableEntry this[int index]
		{
			get
			{
				return this.m_List[index] as PlotColorTableEntry;
			}
		}

		[Browsable(false)]
		public event EventHandler RefreshTable;

		public PlotColorTable()
		{
			this.m_List = new ArrayList();
			this.AddColor(Color.Red);
			this.AddColor(Color.Blue);
			this.AddColor(Color.Lime);
			this.AddColor(Color.Yellow);
			this.AddColor(Color.Aqua);
			this.AddColor(Color.White);
		}

		public void AddColor(Color color)
		{
			this.m_List.Add(new PlotColorTableEntry(color));
		}

		public void AddUsedColor(Color color)
		{
			for (int i = 0; i < this.Count; i++)
			{
				if (this[i].Color.Equals(color))
				{
					this[i].Count++;
				}
			}
		}

		public void Clear()
		{
			this.m_List.Clear();
		}

		public void RemoveAt(int index)
		{
			this.m_List.RemoveAt(index);
		}

		private void PerformRefreshTable()
		{
			for (int i = 0; i < this.Count; i++)
			{
				this[i].Count = 0;
			}
			if (this.RefreshTable != null)
			{
				this.RefreshTable(this, EventArgs.Empty);
			}
		}

		public Color NextColor()
		{
			if (this.Count == 0)
			{
				return Color.Empty;
			}
			this.PerformRefreshTable();
			int num = 2147483647;
			foreach (PlotColorTableEntry item in this.m_List)
			{
				num = Math.Min(num, item.Count);
			}
			foreach (PlotColorTableEntry item2 in this.m_List)
			{
				if (item2.Count == num)
				{
					return item2.Color;
				}
			}
			return Color.Empty;
		}
	}
}
