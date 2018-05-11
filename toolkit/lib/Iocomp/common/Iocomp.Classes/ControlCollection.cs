using System.Collections;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public class ControlCollection : IEnumerable
	{
		private ArrayList m_List;

		public int Count => this.m_List.Count;

		public Control this[int index]
		{
			get
			{
				return this.m_List[index] as Control;
			}
			set
			{
				this.m_List[index] = value;
			}
		}

		public ControlCollection()
		{
			this.m_List = new ArrayList();
		}

		public IEnumerator GetEnumerator()
		{
			return this.m_List.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public int Add(Control value)
		{
			return this.m_List.Add(value);
		}

		public void Clear()
		{
			this.m_List.Clear();
		}

		public void Sort(IComparer comparer)
		{
			this.m_List.Sort(comparer);
		}

		public int IndexOf(Control value)
		{
			return this.m_List.IndexOf(value);
		}
	}
}
