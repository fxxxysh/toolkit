using System;
using System.Drawing;

namespace Iocomp.Classes
{
	public class BoundsEventArgs : EventArgs
	{
		private Rectangle m_Rectangle;

		public Rectangle Rectangle => this.m_Rectangle;

		public BoundsEventArgs(Rectangle value)
		{
			this.m_Rectangle = value;
		}
	}
}
