using Iocomp.Types;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Interfaces
{
	public interface IControlBase
	{
		Size Size
		{
			get;
			set;
		}

		Color BackColor
		{
			get;
			set;
		}

		Font Font
		{
			get;
			set;
		}

		Color ForeColor
		{
			get;
			set;
		}

		bool FreezeAutoSize
		{
			get;
			set;
		}

		bool Focused
		{
			get;
		}

		Control _Parent
		{
			get;
		}

		Control Control
		{
			get;
		}

		EventSource EventSource
		{
			get;
		}

		bool OPCUpdateActive
		{
			get;
			set;
		}

		Cursor Cursor
		{
			get;
			set;
		}

		void DoAutoSize();

		void DoAutoSizeSpecialOffset(int specialOffset);

		bool Focus();
	}
}
