using System.Drawing;

namespace Iocomp.Classes
{
	public class GrabHandle
	{
		private Rectangle m_Rectangle;

		private bool m_Enabled;

		public Rectangle Rectangle
		{
			get
			{
				return this.m_Rectangle;
			}
			set
			{
				this.m_Rectangle = value;
			}
		}

		public bool Enabled
		{
			get
			{
				return this.m_Enabled;
			}
			set
			{
				this.m_Enabled = value;
			}
		}
	}
}
