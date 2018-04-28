using Iocomp.Interfaces;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	public class UIInputCollection : IEnumerable
	{
		private ArrayList m_List;

		private IUIInput m_MouseDownControl;

		private IUIInput m_FocusControl;

		private ControlBase m_ControlBase;

		private bool m_DragActive;

		private Type m_NoHitDefaultType;

		public int Count => this.m_List.Count;

		public Type NoHitDefaultType
		{
			get
			{
				return this.m_NoHitDefaultType;
			}
			set
			{
				this.m_NoHitDefaultType = value;
			}
		}

		public IUIInput this[int index]
		{
			get
			{
				return this.m_List[index] as IUIInput;
			}
		}

		private IUIInput MouseDownControl => this.m_MouseDownControl;

		private IUIInput FocusControl => this.m_FocusControl;

		private ControlBase ControlBase => this.m_ControlBase;

		private bool Focused => this.ControlBase.Focused;

		public bool DragActive => this.m_DragActive;

		public Cursor Cursor
		{
			get
			{
				if (this.ControlBase == null)
				{
					return Cursors.Default;
				}
				return this.ControlBase.Cursor;
			}
		}

		public UIInputCollection(ControlBase value)
		{
			if (value == null)
			{
				throw new Exception("ControlBase must be assigned");
			}
			this.m_ControlBase = value;
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

		public int Add(IUIInput value)
		{
			value.UICollection = this;
			value.IsMouseDown = false;
			value.IsMouseActive = false;
			value.IsKeyDown = false;
			value.IsKeyActive = false;
			return this.m_List.Add(value);
		}

		public void Remove(IUIInput value)
		{
			value.UICollection = null;
			this.m_List.Remove(value);
			if (this.m_FocusControl == value)
			{
				this.m_FocusControl = null;
				if (this.m_List.Count != 0)
				{
					this.m_FocusControl = (this.m_List[0] as IUIInput);
					if (this.Focused)
					{
						this.m_FocusControl.GotFocus(EventArgs.Empty);
					}
				}
			}
		}

		public void Clear()
		{
			foreach (IUIInput item in this.m_List)
			{
				item.UICollection = null;
			}
			this.m_List.Clear();
			this.m_FocusControl = null;
		}

		public void ClearFocus()
		{
			this.m_FocusControl = null;
		}

		public void Sort(IComparer comparer)
		{
			this.m_List.Sort(comparer);
		}

		public int IndexOf(IUIInput value)
		{
			return this.m_List.IndexOf(value);
		}

		public void UIInvalidate(object value)
		{
			if (this.m_ControlBase != null)
			{
				this.m_ControlBase.UIInvalidate(value);
			}
		}

		private IUIInput GetUIInputControl(MouseEventArgs e)
		{
			IUIInput iUIInput = null;
			IUIInput iUIInput2 = null;
			int num = 2147483647;
			for (int i = 0; i < this.Count; i++)
			{
				IUIInput iUIInput3 = this[i];
				if (iUIInput3 != null && iUIInput3.Enabled && iUIInput3.HitVisible && iUIInput3.HitTest(e))
				{
					int num2 = iUIInput3.Bounds.Width * iUIInput3.Bounds.Height;
					if (num2 < num)
					{
						if (iUIInput3.GetType() == this.NoHitDefaultType)
						{
							iUIInput2 = iUIInput3;
						}
						else
						{
							num = num2;
							iUIInput = iUIInput3;
						}
					}
				}
			}
			if (iUIInput == null)
			{
				iUIInput = iUIInput2;
			}
			return iUIInput;
		}

		public void FocusDisabled(IUIInput value)
		{
			if (this.FocusControl == value)
			{
				if (this.Focused)
				{
					this.FocusControl.LostFocus(new LostFocusEventArgs(null));
				}
				this.m_FocusControl = null;
				if (this.m_List.Count != 0)
				{
					this.m_FocusControl = (this.m_List[0] as IUIInput);
					if (this.Focused)
					{
						this.FocusControl.GotFocus(EventArgs.Empty);
					}
				}
			}
		}

		public void SetFocus(IUIInput value)
		{
			if (this.FocusControl != null && this.FocusControl != value)
			{
				LostFocusEventArgs lostFocusEventArgs = new LostFocusEventArgs(value);
				if (this.Focused)
				{
					this.FocusControl.LostFocus(lostFocusEventArgs);
				}
				if (!lostFocusEventArgs.Cancel)
				{
					this.FocusControl.IsMouseDown = false;
					this.FocusControl.IsMouseActive = false;
					this.FocusControl.IsKeyDown = false;
					this.FocusControl.IsKeyActive = false;
					goto IL_0065;
				}
				return;
			}
			goto IL_0065;
			IL_0065:
			this.m_FocusControl = value;
			if (!this.ControlBase.Focused)
			{
				this.Focus();
			}
			else
			{
				this.FocusControl.GotFocus(EventArgs.Empty);
				this.ControlBase.UIInvalidate(this);
			}
		}

		public void Focus()
		{
			if (!this.ControlBase.Focused)
			{
				this.ControlBase.Focus();
				this.ControlBase.UIInvalidate(this);
			}
		}

		public void StartDrag()
		{
			this.m_DragActive = true;
		}

		public bool GetIsFocused(IUIInput value)
		{
			if (!this.Focused)
			{
				return false;
			}
			return value == this.FocusControl;
		}

		public void MouseRight(MouseEventArgs e)
		{
			this.Focus();
			IUIInput uIInputControl = this.GetUIInputControl(e);
			if (uIInputControl != null)
			{
				uIInputControl.IsMouseDown = false;
				uIInputControl.IsMouseActive = false;
				uIInputControl.IsKeyDown = false;
				uIInputControl.IsKeyActive = false;
				uIInputControl.MouseRight(e);
			}
			this.ControlBase.UIInvalidate(this);
		}

		public void MouseLeft(MouseEventArgs e)
		{
			this.m_DragActive = false;
			this.Focus();
			Control controlBase = this.ControlBase;
			IUIInput uIInputControl = this.GetUIInputControl(e);
			if (uIInputControl != null)
			{
				uIInputControl.IsMouseDown = true;
				uIInputControl.IsMouseActive = false;
				uIInputControl.IsKeyDown = false;
				uIInputControl.IsKeyActive = false;
				if (controlBase != null)
				{
					controlBase.Cursor = uIInputControl.GetMouseCursor(e);
				}
				uIInputControl.MouseLeft(e, true);
			}
			this.m_MouseDownControl = uIInputControl;
			this.ControlBase.UIInvalidate(this);
		}

		public bool MouseMove(MouseEventArgs e)
		{
			Control controlBase = this.ControlBase;
			if (!this.m_DragActive && this.MouseDownControl != null)
			{
				if (controlBase != null)
				{
					controlBase.Cursor = this.MouseDownControl.GetMouseCursor(e);
				}
				this.MouseDownControl.MouseMove(e);
				this.ControlBase.UIInvalidate(this);
			}
			else
			{
				IUIInput uIInputControl = this.GetUIInputControl(e);
				if (uIInputControl != null)
				{
					if (controlBase != null)
					{
						controlBase.Cursor = uIInputControl.GetMouseCursor(e);
					}
					uIInputControl.MouseMove(e);
					return true;
				}
				controlBase.Cursor = Cursors.Default;
			}
			return false;
		}

		public void MouseUp(MouseEventArgs e)
		{
			if (this.MouseDownControl != null)
			{
				IUIInput mouseDownControl = this.MouseDownControl;
				mouseDownControl.MouseUp(e);
				mouseDownControl.Click(e);
				mouseDownControl.IsMouseDown = false;
				mouseDownControl.IsMouseActive = false;
				mouseDownControl.IsKeyDown = false;
				mouseDownControl.IsKeyActive = false;
				this.m_MouseDownControl = null;
				this.m_DragActive = false;
				this.ControlBase.UIInvalidate(this);
			}
		}

		public void DoubleClick(MouseEventArgs e)
		{
			if (this.MouseDownControl != null)
			{
				Point point = this.ControlBase.PointToClient(Control.MousePosition);
				this.MouseDownControl.DoubleClick(new MouseEventArgs(Control.MouseButtons, 0, point.X, point.Y, 0));
			}
		}

		public void MouseWheel(MouseEventArgs e)
		{
			if (this.FocusControl != null)
			{
				this.FocusControl.MouseWheel(e);
				this.ControlBase.UIInvalidate(this);
			}
		}

		public void KeyDown(KeyEventArgs e)
		{
			if (this.FocusControl != null)
			{
				this.FocusControl.IsKeyDown = true;
				this.FocusControl.IsKeyActive = false;
				this.FocusControl.KeyDown(e);
				this.ControlBase.UIInvalidate(this);
			}
		}

		public void KeyUp(KeyEventArgs e)
		{
			if (this.FocusControl != null)
			{
				this.FocusControl.KeyUp(e);
				this.FocusControl.IsKeyDown = false;
				this.FocusControl.IsKeyActive = false;
				this.ControlBase.UIInvalidate(this);
			}
		}

		public void KeyPress(KeyPressEventArgs e)
		{
			if (this.FocusControl != null)
			{
				this.FocusControl.IsKeyDown = false;
				this.FocusControl.IsKeyActive = false;
				this.FocusControl.KeyPress(e);
				this.ControlBase.UIInvalidate(this);
			}
		}

		public void LostFocus(EventArgs e)
		{
			if (this.FocusControl != null)
			{
				this.FocusControl.LostFocus(new LostFocusEventArgs(null));
				this.FocusControl.IsMouseDown = false;
				this.FocusControl.IsMouseActive = false;
				this.FocusControl.IsKeyDown = false;
				this.FocusControl.IsKeyActive = false;
				this.ControlBase.UIInvalidate(this);
			}
			if (this.MouseDownControl != null)
			{
				this.MouseDownControl.MouseUp(new MouseEventArgs(Control.MouseButtons, 0, 0, 0, 0));
				this.MouseDownControl.IsMouseDown = false;
				this.MouseDownControl.IsMouseActive = false;
				this.MouseDownControl.IsKeyDown = false;
				this.MouseDownControl.IsKeyActive = false;
				this.m_MouseDownControl = null;
				this.ControlBase.UIInvalidate(this);
			}
		}

		public void GotFocus(EventArgs e)
		{
			if (this.FocusControl != null)
			{
				this.FocusControl.GotFocus(e);
				this.ControlBase.UIInvalidate(this);
			}
		}
	}
}
