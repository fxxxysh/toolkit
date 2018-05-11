using Iocomp.Classes;
using Iocomp.Design.Components;
using Iocomp.Interfaces;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("code")]
	public abstract class PlugInCollection : PlugInStandard, IPlugInMaster
	{
		private CollectionNavigatorPanel m_Navigator;

		private PlugInStandard[] m_PlugInPool;

		private TabControl[] m_ClassTabControls;

		private bool m_SelectLast;

		public PlugInStandard[] PlugInPool => this.m_PlugInPool;

		public CollectionNavigatorPanel Navigator => this.m_Navigator;

		protected abstract Type[] Types
		{
			get;
		}

		int IPlugInMaster.TabPageBorderSize
		{
			get
			{
				return base.Master.TabPageBorderSize;
			}
		}

		int IPlugInMaster.TabPageDockMargin
		{
			get
			{
				return base.Master.TabPageDockMargin;
			}
		}

		int IPlugInMaster.TabHeight
		{
			get
			{
				return base.Master.TabHeight;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.m_PlugInPool != null)
			{
				PlugInStandard[] plugInPool = this.m_PlugInPool;
				foreach (PlugInStandard plugInStandard in plugInPool)
				{
					plugInStandard.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		protected abstract PlugInStandard[] CreatePlugInPool();

		protected abstract PlugInStandard GetClassPlugIn(object value);

		protected abstract int GetPlugInIndex(object value);

		private void TabPage_Resize(object sender, EventArgs e)
		{
			for (int i = 0; i < this.m_ClassTabControls.Length; i++)
			{
				this.m_ClassTabControls[i].Size = new Size(base.TabPage.Width - this.Navigator.Width, base.TabPage.Height);
			}
		}

		public override void DoTabs(TabControl tabControl, bool first, int offsetLeft, int offsetRight, int offsetTop, int offsetBottom, float scaleRatio, IPlugInMaster master, PlugInStandardCollection classPlugIns)
		{
			classPlugIns.Add(this);
			base.Master = master;
			base.TabControl = tabControl;
			base.TabPage = new TabPage();
			base.TabPage.Text = base.TabName;
			base.TabPage.SizeChanged += this.TabPage_SizeChanged;
			base.TabControl.Controls.Add(base.TabPage);
			this.m_Navigator = new CollectionNavigatorPanel();
			this.Navigator.Dock = DockStyle.Left;
			this.Navigator.SelectedIndexChanged += this.Navigator_SelectedIndexChanged;
			this.Navigator.ItemMoved += this.Navigator_ItemMoved;
			this.Navigator.ItemAdd += this.Navigator_ItemAdd;
			this.Navigator.ItemRemove += this.Navigator_ItemRemove;
			this.Navigator.Types = this.Types;
			this.Navigator.DoLayout();
			base.Master.UpdateExtents(this.Navigator.Width + offsetLeft + offsetRight, this.Navigator.Height + offsetTop + offsetBottom);
			base.TabPage.Controls.Add(this.Navigator);
			this.Navigator.DoLayout();
			base.TabPage.Resize += this.TabPage_Resize;
			offsetLeft += base.Master.TabPageBorderSize + this.Navigator.Width;
			offsetRight += base.Master.TabPageBorderSize;
			offsetTop += base.Master.TabPageBorderSize + base.Master.TabHeight;
			offsetBottom += base.Master.TabPageBorderSize;
			this.m_PlugInPool = this.CreatePlugInPool();
			this.m_ClassTabControls = new TabControl[this.m_PlugInPool.Length];
			for (int i = 0; i < this.m_PlugInPool.Length; i++)
			{
				this.m_ClassTabControls[i] = new TabControl();
				this.m_ClassTabControls[i].Left = this.Navigator.Right;
				this.m_ClassTabControls[i].Width = 700;
				this.m_ClassTabControls[i].Height = 400;
				base.TabPage.Controls.Add(this.m_ClassTabControls[i]);
			}
			for (int j = 0; j < this.m_PlugInPool.Length; j++)
			{
				PlugInStandard plugInStandard = this.m_PlugInPool[j];
				plugInStandard.TabName = "General";
				plugInStandard.DoTabs(this.m_ClassTabControls[j], true, offsetLeft, offsetRight, offsetTop, offsetBottom, scaleRatio, master, plugInStandard.ClassPlugIns);
			}
			for (int k = 0; k < this.m_ClassTabControls.Length; k++)
			{
				this.m_ClassTabControls[k].Visible = false;
			}
		}

		public override void SetSubPlugInsValue()
		{
		}

		public override void UploadDisplay()
		{
			Iocomp.Classes.CollectionBase collectionBase = base.WorkingInstance as Iocomp.Classes.CollectionBase;
			this.Navigator.AllowEdit = ((ICollectionBase)collectionBase).AllowEdit;
			this.Navigator.BeginUpdate();
			int selectedIndex = this.Navigator.SelectedIndex;
			object selectedObject = this.Navigator.SelectedObject;
			this.Navigator.Items.Clear();
			for (int i = 0; i < collectionBase.Count; i++)
			{
				object item = ((IList)collectionBase)[i];
				this.Navigator.Items.Add(item);
			}
			if (this.m_SelectLast)
			{
				this.Navigator.SelectLast();
				this.m_SelectLast = false;
			}
			else if (selectedObject != null)
			{
				int num = this.Navigator.Items.IndexOf(selectedObject);
				if (num != -1)
				{
					this.Navigator.SelectedIndex = num;
				}
				else
				{
					this.Navigator.SelectLast();
				}
			}
			if (this.Navigator.Items.Count == 0)
			{
				TabControl[] classTabControls = this.m_ClassTabControls;
				foreach (TabControl tabControl in classTabControls)
				{
					tabControl.Visible = false;
				}
			}
			else if (this.Navigator.SelectedIndex == -1)
			{
				this.Navigator.SelectFirst();
			}
			this.Navigator.EndUpdate();
		}

		public override void TransferAmbient()
		{
			Iocomp.Classes.CollectionBase collectionBase = base.Source as Iocomp.Classes.CollectionBase;
			Iocomp.Classes.CollectionBase collectionBase2 = base.Destination as Iocomp.Classes.CollectionBase;
			collectionBase2.Clear();
			for (int i = 0; i < collectionBase.Count; i++)
			{
				object obj = ((IList)collectionBase)[i];
				object obj2 = ((ICollectionBase)collectionBase2).CreateInstance(obj.GetType());
				(obj2 as ISubClassBase).ControlBase = (base.Master as IControlBase);
				PlugInStandard classPlugIn = this.GetClassPlugIn(obj);
				classPlugIn.Source = obj;
				classPlugIn.Destination = obj2;
				classPlugIn.TransferAmbient();
			}
		}

		public override bool GetIsDirty()
		{
			try
			{
				Iocomp.Classes.CollectionBase collectionBase = base.OriginalInstance as Iocomp.Classes.CollectionBase;
				Iocomp.Classes.CollectionBase collectionBase2 = base.WorkingInstance as Iocomp.Classes.CollectionBase;
				if (collectionBase.Count != collectionBase2.Count)
				{
					return true;
				}
				int num = 0;
				while (true)
				{
					if (num < collectionBase2.Count)
					{
						object obj = ((IList)collectionBase)[num];
						object obj2 = ((IList)collectionBase2)[num];
						if (!(obj.GetType() != obj2.GetType()))
						{
							PlugInStandard classPlugIn = this.GetClassPlugIn(obj2);
							classPlugIn.WorkingInstance = obj2;
							classPlugIn.OriginalInstance = obj;
							classPlugIn.UploadDisplay();
							if (classPlugIn.GetIsDirty())
							{
								break;
							}
							num++;
							continue;
						}
						return true;
					}
					return false;
				}
				return true;
			}
			finally
			{
				if (this.Navigator.SelectedObject != null)
				{
					PlugInStandard classPlugIn = this.GetClassPlugIn(this.Navigator.SelectedObject);
					classPlugIn.WorkingInstance = this.Navigator.SelectedObject;
					classPlugIn.UploadDisplay();
				}
			}
		}

		private void Navigator_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.Navigator.SelectedObject == null)
			{
				TabControl[] classTabControls = this.m_ClassTabControls;
				foreach (TabControl tabControl in classTabControls)
				{
					tabControl.Visible = false;
				}
			}
			else
			{
				for (int j = 0; j < this.m_ClassTabControls.Length; j++)
				{
					this.m_ClassTabControls[j].Visible = (j == this.GetPlugInIndex(this.Navigator.SelectedObject));
				}
				PlugInStandard classPlugIn = this.GetClassPlugIn(this.Navigator.SelectedObject);
				classPlugIn.WorkingInstance = this.Navigator.SelectedObject;
				classPlugIn.UploadDisplay();
			}
		}

		private void Navigator_ItemAdd(object sender, TypeEventArgs e)
		{
			this.m_SelectLast = true;
			Iocomp.Classes.CollectionBase collectionBase = base.WorkingInstance as Iocomp.Classes.CollectionBase;
			object value = GPFunctions.CreateInstance(e.Type, e.Type.FullName);
			((IList)collectionBase).Add(value);
			base.Master.ForceDirtyUpdate(null);
		}

		private void Navigator_ItemRemove(object sender, EventArgs e)
		{
			Iocomp.Classes.CollectionBase collectionBase = base.WorkingInstance as Iocomp.Classes.CollectionBase;
			collectionBase.RemoveAt(this.Navigator.SelectedIndex);
			base.Master.ForceDirtyUpdate(null);
		}

		private void Navigator_ItemMoved(object sender, ObjectMoveIndexEventArgs e)
		{
			Iocomp.Classes.CollectionBase collectionBase = base.WorkingInstance as Iocomp.Classes.CollectionBase;
			object value = ((IList)collectionBase)[e.OldIndex];
			((IList)collectionBase).RemoveAt(e.OldIndex);
			((IList)collectionBase).Insert(e.NewIndex, value);
			base.Master.ForceDirtyUpdate(null);
		}

		void IPlugInMaster.ForceDirtyUpdate(PlugInStandard value)
		{
			base.Master.ForceDirtyUpdate(this);
		}

		void IPlugInMaster.ForceApplyButtonEnabled(PlugInStandard value)
		{
			base.Master.ForceApplyButtonEnabled(this);
		}

		void IPlugInMaster.UpdateExtents(PlugInStandard value)
		{
			base.Master.UpdateExtents(value);
		}

		void IPlugInMaster.UpdateExtents(int width, int height)
		{
			base.Master.UpdateExtents(width, height);
		}

		private void TabPage_SizeChanged(object sender, EventArgs e)
		{
			if (this.m_Navigator != null)
			{
				this.m_Navigator.Height = base.TabPage.Height;
				this.m_Navigator.DoLayout();
			}
		}
	}
}
