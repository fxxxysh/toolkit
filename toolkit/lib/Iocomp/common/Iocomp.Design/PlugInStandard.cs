using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("code")]
	public class PlugInStandard : UserControl, IPlugInStandard
	{
		private IPlugInMaster m_Master;

		private object m_Value;

		private PlugInStandardCollection m_SubPlugIns;

		private PlugInStandardCollection m_ClassPlugIns;

		private Iocomp.Classes.ControlCollection m_AllControls;

		private string m_TabName;

		private string m_Title;

		private TabControl m_TabControl;

		private TabPage m_TabPage;

		private bool m_BlockChange;

		private bool m_SameLevel;

		private int m_MarginLeft;

		private int m_MarginRight;

		private int m_MarginTop;

		private int m_MarginBottom;

		private object m_Source;

		private object m_Destination;

		private object m_WorkingInstance;

		private object m_OriginalInstance;

		[Browsable(false)]
		public object Value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = value;
				this.SetSubPlugInsValue();
			}
		}

		[Browsable(false)]
		public object Source
		{
			get
			{
				return this.m_Source;
			}
			set
			{
				this.Value = value;
				this.SetSource();
			}
		}

		[Browsable(false)]
		public object Destination
		{
			get
			{
				return this.m_Destination;
			}
			set
			{
				this.Value = value;
				this.SetDestination();
			}
		}

		[Browsable(false)]
		public object WorkingInstance
		{
			get
			{
				return this.m_WorkingInstance;
			}
			set
			{
				this.Value = value;
				this.SetWorkingInstance();
			}
		}

		[Browsable(false)]
		public object OriginalInstance
		{
			get
			{
				return this.m_OriginalInstance;
			}
			set
			{
				this.Value = value;
				this.SetOriginalInstance();
			}
		}

		[Browsable(false)]
		public int MarginLeft
		{
			get
			{
				return this.m_MarginLeft;
			}
		}

		[Browsable(false)]
		public int MarginRight
		{
			get
			{
				return this.m_MarginRight;
			}
		}

		[Browsable(false)]
		public int MarginTop
		{
			get
			{
				return this.m_MarginTop;
			}
		}

		[Browsable(false)]
		public int MarginBottom
		{
			get
			{
				return this.m_MarginBottom;
			}
		}

		[Browsable(false)]
		public string TabName
		{
			get
			{
				return this.m_TabName;
			}
			set
			{
				this.m_TabName = value;
			}
		}

		public string Title
		{
			get
			{
				return this.m_Title;
			}
			set
			{
				this.m_Title = value;
			}
		}

		protected IPlugInMaster Master
		{
			get
			{
				return this.m_Master;
			}
			set
			{
				this.m_Master = value;
			}
		}

		[Browsable(false)]
		public TabControl TabControl
		{
			get
			{
				return this.m_TabControl;
			}
			set
			{
				this.m_TabControl = value;
			}
		}

		[Browsable(false)]
		public TabPage TabPage
		{
			get
			{
				return this.m_TabPage;
			}
			set
			{
				this.m_TabPage = value;
			}
		}

		[Browsable(false)]
		public bool BlockChange
		{
			get
			{
				return this.m_BlockChange;
			}
			set
			{
				this.m_BlockChange = value;
			}
		}

		[Browsable(false)]
		public bool SameLevel
		{
			get
			{
				return this.m_SameLevel;
			}
			set
			{
				this.m_SameLevel = value;
			}
		}

		[Browsable(false)]
		public PlugInStandardCollection SubPlugIns
		{
			get
			{
				if (this.m_SubPlugIns == null)
				{
					this.m_SubPlugIns = new PlugInStandardCollection();
				}
				return this.m_SubPlugIns;
			}
		}

		[Browsable(false)]
		public PlugInStandardCollection ClassPlugIns
		{
			get
			{
				if (this.m_ClassPlugIns == null)
				{
					this.m_ClassPlugIns = new PlugInStandardCollection();
				}
				return this.m_ClassPlugIns;
			}
		}

		[Browsable(false)]
		public Iocomp.Classes.ControlCollection AllControls
		{
			get
			{
				if (this.m_AllControls == null)
				{
					this.m_AllControls = new Iocomp.Classes.ControlCollection();
				}
				return this.m_AllControls;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				foreach (PlugInStandard classPlugIn in this.ClassPlugIns)
				{
					if (classPlugIn != this)
					{
						classPlugIn.Dispose();
					}
				}
			}
			base.Dispose(disposing);
		}

		public void AddSubPlugIn(PlugInStandard plugIn, string tabName, bool sameLevel)
		{
			this.SubPlugIns.Add(plugIn);
			plugIn.TabName = tabName;
			plugIn.SameLevel = sameLevel;
		}

		private void SetSource()
		{
			this.m_Source = this.Value;
			foreach (PlugInStandard classPlugIn in this.ClassPlugIns)
			{
				if (classPlugIn != this)
				{
					classPlugIn.SetSource();
				}
			}
		}

		private void SetDestination()
		{
			this.m_Destination = this.Value;
			foreach (PlugInStandard classPlugIn in this.ClassPlugIns)
			{
				if (classPlugIn != this)
				{
					classPlugIn.SetDestination();
				}
			}
		}

		private void SetWorkingInstance()
		{
			this.m_WorkingInstance = this.Value;
			foreach (PlugInStandard classPlugIn in this.ClassPlugIns)
			{
				if (classPlugIn != this)
				{
					classPlugIn.SetWorkingInstance();
				}
			}
		}

		private void SetOriginalInstance()
		{
			this.m_OriginalInstance = this.Value;
			foreach (PlugInStandard classPlugIn in this.ClassPlugIns)
			{
				if (classPlugIn != this)
				{
					classPlugIn.SetOriginalInstance();
				}
			}
		}

		public virtual void UploadDisplay()
		{
			for (int i = 0; i < this.AllControls.Count; i++)
			{
				if (this.AllControls[i] is IPlugInEditorControl)
				{
					(this.AllControls[i] as IPlugInEditorControl).UploadDisplay(this.WorkingInstance);
				}
			}
			for (int j = 0; j < this.ClassPlugIns.Count; j++)
			{
				if (this.ClassPlugIns[j] != this)
				{
					this.ClassPlugIns[j].UploadDisplay();
				}
			}
		}

		public virtual void TransferAmbient()
		{
			for (int i = 0; i < this.AllControls.Count; i++)
			{
				IPlugInEditorControl plugInEditorControl = this.AllControls[i] as IPlugInEditorControl;
				plugInEditorControl?.TransferAmbient(this.Source, this.Destination);
			}
			foreach (PlugInStandard classPlugIn in this.ClassPlugIns)
			{
				if (classPlugIn != this)
				{
					classPlugIn.TransferAmbient();
				}
			}
		}

		public virtual bool GetIsDirty()
		{
			int num = 0;
			while (true)
			{
				if (num < this.AllControls.Count)
				{
					IPlugInEditorControl plugInEditorControl = this.AllControls[num] as IPlugInEditorControl;
					if (plugInEditorControl != null && plugInEditorControl.GetIsDisplayDirty(this.OriginalInstance))
					{
						break;
					}
					num++;
					continue;
				}
				foreach (PlugInStandard classPlugIn in this.ClassPlugIns)
				{
					if (classPlugIn != this && classPlugIn.GetIsDirty())
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}

		public void ForceDirtyUpdate()
		{
			this.Master.ForceDirtyUpdate(this);
		}

		public void ForceApplyButtonEnabled()
		{
			this.Master.ForceApplyButtonEnabled(this);
		}

		public virtual void CreateSubPlugIns()
		{
		}

		public virtual void SetSubPlugInsValue()
		{
		}

		private void ConnectEditorControls()
		{
			for (int i = 0; i < this.AllControls.Count; i++)
			{
				IPlugInEditorControl plugInEditorControl = this.AllControls[i] as IPlugInEditorControl;
				if (plugInEditorControl != null)
				{
					plugInEditorControl.PlugInForm = this;
				}
			}
		}

		private void FixupSize(int MarginLeft, int MarginTop)
		{
			int num = 999;
			int num2 = 999;
			int num3 = 0;
			int num4 = 0;
			foreach (Control control4 in base.Controls)
			{
				num = Math.Min(num, control4.Left);
				num2 = Math.Min(num2, control4.Top);
				num3 = Math.Max(num3, control4.Right);
				num4 = Math.Max(num4, control4.Bottom);
			}
			foreach (Control control5 in base.Controls)
			{
				if (!(control5 is FocusLabel))
				{
					control5.Left = control5.Left - num + MarginLeft;
					control5.Top = control5.Top - num2 + MarginTop;
				}
			}
			foreach (Control control6 in base.Controls)
			{
				if (control6 is FocusLabel)
				{
					(control6 as FocusLabel).AutoSize = false;
					(control6 as FocusLabel).AutoSize = true;
					(control6 as FocusLabel).Align();
				}
			}
			base.Width = num3 - num;
			base.Height = num4 - num2;
		}

		public void FixupAlign()
		{
			this.Dock = DockStyle.Fill;
			foreach (Control allControl in this.AllControls)
			{
				if (allControl is FocusLabel)
				{
					(allControl as FocusLabel).Align();
				}
			}
			foreach (PlugInStandard classPlugIn in this.ClassPlugIns)
			{
				if (classPlugIn != this)
				{
					classPlugIn.FixupAlign();
				}
			}
		}

		public void PopulateAllControls(ControlCollection controls)
		{
			foreach (Control control in controls)
			{
				if (control.Controls.Count != 0 && !(control is EditMultiLine) && !(control is Iocomp.Design.Plugin.EditorControls.NumericUpDown))
				{
					this.PopulateAllControls(control.Controls);
				}
				this.AllControls.Add(control);
			}
		}

		protected virtual void CreatePlugInTab(int offsetLeft, int offsetRight, int offsetTop, int offsetBottom)
		{
			if (base.Controls.Count != 0)
			{
				this.TabPage = new TabPage();
				this.TabPage.Text = this.TabName;
				this.TabControl.Controls.Add(this.TabPage);
				this.TabPage.Controls.Add(this);
				base.Location = new Point(this.Master.TabPageDockMargin, this.Master.TabPageDockMargin);
				this.m_MarginLeft = offsetLeft + this.Master.TabPageDockMargin;
				this.m_MarginRight = offsetRight + this.Master.TabPageDockMargin;
				this.m_MarginTop = offsetTop + this.Master.TabPageDockMargin;
				this.m_MarginBottom = offsetBottom + this.Master.TabPageDockMargin;
				this.Master.UpdateExtents(this);
				this.Dock = DockStyle.Fill;
				this.FixupSize(this.Master.TabPageDockMargin, this.Master.TabPageDockMargin);
				if (this is AboutPlugIn)
				{
					this.Dock = DockStyle.Fill;
				}
			}
		}

		public virtual void DoTabs(TabControl tabControl, bool first, int offsetLeft, int offsetRight, int offsetTop, int offsetBottom, float scaleRatio, IPlugInMaster master, PlugInStandardCollection classPlugIns)
		{
			this.m_Master = master;
			this.PopulateAllControls(base.Controls);
			if (!(this is AboutPlugIn))
			{
				classPlugIns.Add(this);
				this.ConnectEditorControls();
			}
			base.Scale(new SizeF(scaleRatio, scaleRatio));
			this.FixupSize(0, 0);
			this.CreateSubPlugIns();
			bool flag = false;
			int num = 0;
			while (num < this.SubPlugIns.Count)
			{
				if (!this.SubPlugIns[num].SameLevel)
				{
					num++;
					continue;
				}
				flag = true;
				break;
			}
			if (flag)
			{
				this.TabPage = new TabPage();
				this.TabPage.Text = this.TabName;
				tabControl.Controls.Add(this.TabPage);
				this.TabControl = new TabControl();
				this.TabControl.Dock = DockStyle.Fill;
				this.TabPage.Controls.Add(this.TabControl);
				int offsetLeft2 = offsetLeft;
				int offsetRight2 = offsetRight;
				int offsetTop2 = offsetTop;
				int offsetBottom2 = offsetBottom;
				offsetLeft += this.Master.TabPageBorderSize;
				offsetRight += this.Master.TabPageBorderSize;
				offsetTop += this.Master.TabPageBorderSize + this.Master.TabHeight;
				offsetBottom += this.Master.TabPageBorderSize;
				this.TabName = "General";
				this.CreatePlugInTab(offsetLeft, offsetRight, offsetTop, offsetBottom);
				for (int i = 0; i < this.SubPlugIns.Count; i++)
				{
					if (this.SubPlugIns[i].SameLevel)
					{
						this.SubPlugIns[i].DoTabs(this.TabControl, false, offsetLeft, offsetRight, offsetTop, offsetBottom, scaleRatio, master, classPlugIns);
					}
				}
				for (int j = 0; j < this.SubPlugIns.Count; j++)
				{
					if (!this.SubPlugIns[j].SameLevel)
					{
						this.SubPlugIns[j].DoTabs(tabControl, false, offsetLeft2, offsetRight2, offsetTop2, offsetBottom2, scaleRatio, master, classPlugIns);
					}
				}
			}
			else if (!first && this.SubPlugIns.Count != 0)
			{
				this.TabPage = new TabPage();
				this.TabPage.Text = this.TabName;
				tabControl.Controls.Add(this.TabPage);
				this.TabControl = new TabControl();
				this.TabControl.Dock = DockStyle.Fill;
				this.TabPage.Controls.Add(this.TabControl);
				offsetLeft += this.Master.TabPageBorderSize;
				offsetRight += this.Master.TabPageBorderSize;
				offsetTop += this.Master.TabPageBorderSize + this.Master.TabHeight;
				offsetBottom += this.Master.TabPageBorderSize;
				this.TabName = "General";
				this.CreatePlugInTab(offsetLeft, offsetRight, offsetTop, offsetBottom);
				for (int k = 0; k < this.SubPlugIns.Count; k++)
				{
					this.SubPlugIns[k].DoTabs(this.TabControl, false, offsetLeft, offsetRight, offsetTop, offsetBottom, scaleRatio, master, classPlugIns);
				}
			}
			else
			{
				this.TabControl = tabControl;
				this.CreatePlugInTab(offsetLeft, offsetRight, offsetTop, offsetBottom);
				for (int l = 0; l < this.SubPlugIns.Count; l++)
				{
					this.SubPlugIns[l].DoTabs(tabControl, false, offsetLeft, offsetRight, offsetTop, offsetBottom, scaleRatio, master, classPlugIns);
				}
			}
		}
	}
}
