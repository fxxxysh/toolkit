using Iocomp.Classes;
using Iocomp.Delegates;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ToolboxBitmaps;

namespace Iocomp.Design.Components
{
	[ToolboxItem(false)]
	public class CollectionNavigatorPanel : UserControl
	{
		private ListBox ItemListBox;

		private Button RemoveButton;

		private Button AddButton;

		private Button MoveUpButton;

		private Button MoveDownButton;

		private Container components;

		private Button AddClassButton;

		private ContextMenu ContextMenu1;

		private bool m_AllowEdit;

		private Type[] m_ClassTypes;

		public bool AllowEdit
		{
			get
			{
				return this.m_AllowEdit;
			}
			set
			{
				this.m_AllowEdit = value;
				this.AddButton.Visible = this.m_AllowEdit;
				this.RemoveButton.Visible = this.m_AllowEdit;
				this.OnSizeChanged(EventArgs.Empty);
			}
		}

		public Type[] Types
		{
			get
			{
				return this.m_ClassTypes;
			}
			set
			{
				this.m_ClassTypes = value;
				if (value.Length > 1)
				{
					this.AddClassButton.Visible = true;
					foreach (Type type in value)
					{
						MenuItem menuItem = new MenuItem(type.Name);
						menuItem.Click += this.AMenuItem_Click;
						this.ContextMenu1.MenuItems.Add(menuItem);
					}
				}
			}
		}

		public ListBox.ObjectCollection Items => this.ItemListBox.Items;

		public object SelectedObject
		{
			get
			{
				if (this.ItemListBox.SelectedIndex == -1)
				{
					return null;
				}
				return this.ItemListBox.Items[this.ItemListBox.SelectedIndex];
			}
			set
			{
				if (this.ItemListBox.Items.Count != 0)
				{
					this.ItemListBox.SelectedItem = value;
				}
			}
		}

		public int LastIndex => this.ItemListBox.Items.Count - 1;

		public bool Empty => this.ItemListBox.Items.Count == 0;

		public int SelectedIndex
		{
			get
			{
				return this.ItemListBox.SelectedIndex;
			}
			set
			{
				this.ItemListBox.SelectedIndex = value;
			}
		}

		public event EventHandler SelectedIndexChanged;

		public event ObjectMoveIndexEventHandler ItemMoved;

		public event TypeEventHandler ItemAdd;

		public event EventHandler ItemRemove;

		public CollectionNavigatorPanel()
		{
			this.InitializeComponent();
			this.AllowEdit = true;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.ItemListBox = new ListBox();
			this.RemoveButton = new Button();
			this.AddButton = new Button();
			this.MoveUpButton = new Button();
			this.MoveDownButton = new Button();
			this.AddClassButton = new Button();
			this.ContextMenu1 = new ContextMenu();
			base.SuspendLayout();
			this.ItemListBox.HorizontalScrollbar = true;
			this.ItemListBox.Location = new Point(5, 4);
			this.ItemListBox.Name = "ItemListBox";
			this.ItemListBox.Size = new Size(163, 121);
			this.ItemListBox.TabIndex = 0;
			this.ItemListBox.SelectedIndexChanged += this.ItemListBox_SelectedIndexChanged;
			this.RemoveButton.Enabled = false;
			this.RemoveButton.Location = new Point(104, 128);
			this.RemoveButton.Name = "RemoveButton";
			this.RemoveButton.Size = new Size(65, 23);
			this.RemoveButton.TabIndex = 5;
			this.RemoveButton.Text = "Remove";
			this.RemoveButton.Click += this.RemoveButton_Click;
			this.AddButton.Location = new Point(5, 128);
			this.AddButton.Name = "AddButton";
			this.AddButton.Size = new Size(65, 23);
			this.AddButton.TabIndex = 3;
			this.AddButton.Text = "Add";
			this.AddButton.Click += this.AddButton_Click;
			this.MoveUpButton.Location = new Point(168, 0);
			this.MoveUpButton.Name = "MoveUpButton";
			this.MoveUpButton.Size = new Size(23, 25);
			this.MoveUpButton.TabIndex = 1;
			this.MoveUpButton.Click += this.MoveUpButton_Click;
			this.MoveDownButton.Location = new Point(168, 40);
			this.MoveDownButton.Name = "MoveDownButton";
			this.MoveDownButton.Size = new Size(23, 25);
			this.MoveDownButton.TabIndex = 2;
			this.MoveDownButton.Click += this.MoveDownButton_Click;
			this.AddClassButton.Location = new Point(69, 128);
			this.AddClassButton.Name = "AddClassButton";
			this.AddClassButton.Size = new Size(16, 23);
			this.AddClassButton.TabIndex = 4;
			this.AddClassButton.Visible = false;
			this.AddClassButton.Click += this.AddClassButton_Click;
			base.Controls.Add(this.AddClassButton);
			base.Controls.Add(this.MoveDownButton);
			base.Controls.Add(this.MoveUpButton);
			base.Controls.Add(this.AddButton);
			base.Controls.Add(this.RemoveButton);
			base.Controls.Add(this.ItemListBox);
			base.Name = "CollectionNavigatorPanel";
			base.Size = new Size(195, 152);
			base.Load += this.CollectionNavigatorPanel_Load;
			base.ResumeLayout(false);
		}

		protected override void OnLocationChanged(EventArgs e)
		{
			base.OnLocationChanged(e);
		}

		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
		}

		public void DoLayout()
		{
			if (this.AllowEdit)
			{
				this.ItemListBox.Height = base.Height - 10 - this.AddButton.Height - 5;
			}
			else
			{
				this.ItemListBox.Height = base.Height - 10;
			}
			this.ItemListBox.Location = new Point(5, 5);
			this.ItemListBox.Width = base.Width - 10 - 5 - this.MoveUpButton.Width;
			this.MoveUpButton.Left = this.ItemListBox.Right + 5;
			this.MoveDownButton.Left = this.MoveUpButton.Left;
			this.MoveUpButton.Top = this.ItemListBox.Top;
			this.MoveDownButton.Top = this.MoveUpButton.Bottom + 10;
			this.AddButton.Left = this.ItemListBox.Left;
			this.RemoveButton.Left = this.ItemListBox.Right - this.RemoveButton.Width;
			this.AddButton.Top = this.ItemListBox.Bottom + 5;
			this.RemoveButton.Top = this.AddButton.Top;
			this.AddClassButton.Left = this.AddButton.Right;
			this.AddClassButton.Top = this.AddButton.Top;
		}

		private void ItemListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.UpdateButtons();
			this.OnSelectedIndexChanged();
		}

		public void SelectFirst()
		{
			if (this.ItemListBox.Items.Count != 0)
			{
				this.ItemListBox.SelectedIndex = 0;
			}
		}

		public void SelectLast()
		{
			if (this.ItemListBox.Items.Count != 0)
			{
				this.ItemListBox.SelectedIndex = this.ItemListBox.Items.Count - 1;
			}
		}

		private void OnSelectedIndexChanged()
		{
			if (this.SelectedIndexChanged != null)
			{
				this.SelectedIndexChanged(this, EventArgs.Empty);
			}
		}

		private void OnItemMoved(object instance, int oldIndex, int newIndex)
		{
			if (this.ItemMoved != null)
			{
				this.ItemMoved(this, new ObjectMoveIndexEventArgs(instance, oldIndex, newIndex));
			}
		}

		private void OnItemAdd(Type value)
		{
			if (this.ItemAdd != null)
			{
				this.ItemAdd(this, new TypeEventArgs(value));
			}
		}

		private void OnItemRemove()
		{
			if (this.ItemRemove != null)
			{
				this.ItemRemove(this, EventArgs.Empty);
			}
		}

		public void BeginUpdate()
		{
			this.ItemListBox.BeginUpdate();
		}

		public void EndUpdate()
		{
			this.ItemListBox.EndUpdate();
		}

		private void RemoveButton_Click(object sender, EventArgs e)
		{
			this.OnItemRemove();
			this.UpdateButtons();
		}

		private void AddButton_Click(object sender, EventArgs e)
		{
			if (this.m_ClassTypes != null && this.m_ClassTypes.Length != 0)
			{
				this.OnItemAdd(this.m_ClassTypes[0]);
				this.UpdateButtons();
			}
		}

		private void AMenuItem_Click(object sender, EventArgs e)
		{
			if (this.m_ClassTypes != null && this.m_ClassTypes.Length != 0)
			{
				this.OnItemAdd(this.m_ClassTypes[(sender as MenuItem).Index]);
				this.UpdateButtons();
			}
		}

		private void AddClassButton_Click(object sender, EventArgs e)
		{
			this.ContextMenu1.Show(this.AddButton, new Point(0, this.AddButton.Height));
		}

		private void MoveUpButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.ItemListBox.SelectedIndex;
			if (selectedIndex >= 1)
			{
				object obj = this.ItemListBox.Items[selectedIndex];
				this.ItemListBox.Items.RemoveAt(selectedIndex);
				int num = selectedIndex - 1;
				this.ItemListBox.Items.Insert(num, obj);
				this.ItemListBox.SelectedIndex = num;
				this.OnItemMoved(obj, selectedIndex, num);
				this.UpdateButtons();
			}
		}

		private void MoveDownButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.ItemListBox.SelectedIndex;
			if (selectedIndex != this.ItemListBox.Items.Count - 1)
			{
				object obj = this.ItemListBox.Items[selectedIndex];
				this.ItemListBox.Items.RemoveAt(selectedIndex);
				int num = selectedIndex + 1;
				this.ItemListBox.Items.Insert(num, obj);
				this.ItemListBox.SelectedIndex = num;
				this.OnItemMoved(obj, selectedIndex, num);
				this.UpdateButtons();
			}
		}

		private void UpdateButtons()
		{
			this.RemoveButton.Enabled = true;
			this.MoveUpButton.Enabled = true;
			this.MoveDownButton.Enabled = true;
			if (this.ItemListBox.SelectedIndex == -1)
			{
				this.RemoveButton.Enabled = false;
			}
			if (this.ItemListBox.SelectedIndex == -1)
			{
				this.MoveUpButton.Enabled = false;
			}
			if (this.ItemListBox.SelectedIndex == -1)
			{
				this.MoveDownButton.Enabled = false;
			}
			if (this.ItemListBox.SelectedIndex == 0)
			{
				this.MoveUpButton.Enabled = false;
			}
			if (this.ItemListBox.SelectedIndex == this.ItemListBox.Items.Count - 1)
			{
				this.MoveDownButton.Enabled = false;
			}
		}

		private void CollectionNavigatorPanel_Load(object sender, EventArgs e)
		{
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(Access), "ARW08UP.ICO");
			if (manifestResourceStream != null)
			{
				Icon original = new Icon(manifestResourceStream);
				original = new Icon(original, new Size(16, 16));
				this.MoveUpButton.Image = original.ToBitmap();
			}
			manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(Access), "ARW08DN.ICO");
			if (manifestResourceStream != null)
			{
				Icon original = new Icon(manifestResourceStream);
				original = new Icon(original, new Size(16, 16));
				this.MoveDownButton.Image = original.ToBitmap();
			}
			manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(Access), "ARWHEAD.ICO");
			if (manifestResourceStream != null)
			{
				Icon original = new Icon(manifestResourceStream);
				original = new Icon(original, new Size(16, 16));
				this.AddClassButton.Image = original.ToBitmap();
			}
		}
	}
}
