using Iocomp.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Interfaces
{
	public interface IUIInput
	{
		bool Visible
		{
			get;
			set;
		}

		bool HitVisible
		{
			get;
		}

		bool Enabled
		{
			get;
			set;
		}

		bool Focused
		{
			get;
		}

		bool IsMouseDown
		{
			get;
			set;
		}

		bool IsMouseActive
		{
			get;
			set;
		}

		bool IsKeyDown
		{
			get;
			set;
		}

		bool IsKeyActive
		{
			get;
			set;
		}

		Rectangle Bounds
		{
			get;
			set;
		}

		UIInputCollection UICollection
		{
			get;
			set;
		}

		bool HitTest(MouseEventArgs e);

		Cursor GetMouseCursor(MouseEventArgs e);

		void MouseLeft(MouseEventArgs e, bool shouldFocus);

		void MouseRight(MouseEventArgs e);

		void MouseMove(MouseEventArgs e);

		void MouseUp(MouseEventArgs e);

		void Click(MouseEventArgs e);

		void DoubleClick(MouseEventArgs e);

		void MouseWheel(MouseEventArgs e);

		void KeyDown(KeyEventArgs e);

		void KeyUp(KeyEventArgs e);

		void KeyPress(KeyPressEventArgs e);

		void LostFocus(LostFocusEventArgs e);

		void GotFocus(EventArgs e);
	}
}
