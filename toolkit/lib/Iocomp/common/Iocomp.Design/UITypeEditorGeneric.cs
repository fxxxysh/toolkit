using Iocomp.Classes;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	public class UITypeEditorGeneric : UITypeEditor, IControlBase, IPlugInMaster
	{
		private PlugInStandard m_MainPlugIn;

		private string m_MainPlugInTitle;

		private string m_MainPlugInTabName;

		private PlugInStandard m_AboutPlugIn;

		private Form m_MainForm;

		private int m_MaxWidth;

		private int m_MaxHeight;

		private int m_TabPageBorderSize;

		private int m_TabPageDockMargin;

		private int m_TabHeight;

		private float m_ScaleRatio;

		private PlugInControlPanel m_ControlPanel;

		private IForceDesignerChange I_IForceDesignerChange;

		private object m_OriginalInstance;

		private object m_WorkingInstance;

		private object m_RestoreInstance;

		private object m_ResetInstance;

		private IControlBase I_ControlBase;

		private ITypeDescriptorContext m_Context;

		private IServiceProvider m_Provider;

		private Control m_SurrogateParent;

		public int TabPageBorderSize => this.m_TabPageBorderSize;

		public int TabPageDockMargin => this.m_TabPageDockMargin;

		public int TabHeight => this.m_TabHeight;

		public PlugInStandard MainPlugIn => this.m_MainPlugIn;

		public string MainPlugInTitle => this.m_MainPlugInTitle;

		public string MainPlugInTabName => this.m_MainPlugInTabName;

		public object OriginalInstance => this.m_OriginalInstance;

		private Form MainForm
		{
			get
			{
				return this.m_MainForm;
			}
			set
			{
				this.m_MainForm = value;
			}
		}

		public IForceDesignerChange IForceDesignerChange
		{
			get
			{
				return this.I_IForceDesignerChange;
			}
			set
			{
				this.I_IForceDesignerChange = value;
			}
		}

		public Size Size
		{
			get
			{
				if (this.I_ControlBase != null)
				{
					return this.I_ControlBase.Size;
				}
				return Size.Empty;
			}
			set
			{
			}
		}

		public Color BackColor
		{
			get
			{
				if (this.I_ControlBase != null)
				{
					return this.I_ControlBase.BackColor;
				}
				return Color.Empty;
			}
			set
			{
			}
		}

		public Font Font
		{
			get
			{
				if (this.I_ControlBase != null)
				{
					return this.I_ControlBase.Font;
				}
				return null;
			}
			set
			{
			}
		}

		public Color ForeColor
		{
			get
			{
				if (this.I_ControlBase != null)
				{
					return this.I_ControlBase.ForeColor;
				}
				return Color.Empty;
			}
			set
			{
			}
		}

		public Control _Parent
		{
			get
			{
				if (this.I_ControlBase != null)
				{
					return this.I_ControlBase._Parent;
				}
				return null;
			}
		}

		public Control Control
		{
			get
			{
				if (this.I_ControlBase != null)
				{
					return this.I_ControlBase.Control;
				}
				return null;
			}
		}

		public Cursor Cursor
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public EventSource EventSource => EventSource.Code;

		public bool OPCUpdateActive
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool DefaultReadBack
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Loading => false;

		public bool Creating => false;

		public bool SettingDefaults => false;

		public bool Designing => true;

		public bool Focused => false;

		bool IControlBase.FreezeAutoSize
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public event UITypeEditorEventHandler CreateMainPlugIn;

		void IPlugInMaster.ForceDirtyUpdate(PlugInStandard value)
		{
			this.MainPlugIn.UploadDisplay();
			this.UpdateControlPanel();
		}

		void IPlugInMaster.ForceApplyButtonEnabled(PlugInStandard value)
		{
			if (this.m_ControlPanel != null)
			{
				this.m_ControlPanel.ApplyButton.Enabled = true;
			}
		}

		public void UpdateExtents(int width, int height)
		{
			this.m_MaxWidth = Math.Max(this.m_MaxWidth, width);
			this.m_MaxHeight = Math.Max(this.m_MaxHeight, height);
		}

		public void UpdateExtents(PlugInStandard plugIn)
		{
			int width = plugIn.Width + plugIn.MarginLeft + plugIn.MarginRight;
			int height = plugIn.Height + plugIn.MarginTop + plugIn.MarginBottom;
			this.UpdateExtents(width, height);
		}

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			if (context == null)
			{
				return base.GetEditStyle(context);
			}
			if (context.Instance == null)
			{
				return base.GetEditStyle(context);
			}
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			this.m_Context = context;
			this.m_Provider = provider;
			return this.Edit(value, true, true, true);
		}

		public object EditValue(object value, bool designTimeStyle, bool modal)
		{
			this.m_Context = null;
			this.m_Provider = null;
			return this.Edit(value, designTimeStyle, modal, false);
		}

		private object Edit(object value, bool designTimeStyle, bool modal, bool showAbout)
		{
			this.m_OriginalInstance = value;
			if (!modal && !designTimeStyle && this.MainPlugIn != null && this.MainForm != null)
			{
				this.MainForm.Show();
				this.MainForm.BringToFront();
				return value;
			}
			if (this.MainPlugIn != null)
			{
				this.MainPlugIn.Dispose();
				this.m_MainPlugIn = null;
			}
			if (this.MainForm != null)
			{
				this.MainForm.Dispose();
				this.m_MainForm = null;
			}
			this.CreatePlugInInternal();
			if (this.m_MainPlugIn == null)
			{
				return value;
			}
			if (designTimeStyle)
			{
				this.SetupDesignTime(showAbout);
			}
			else
			{
				this.SetupRuntime(showAbout);
			}
			if (this.m_Provider != null && this.m_Context != null)
			{
				IWindowsFormsEditorService windowsFormsEditorService = (IWindowsFormsEditorService)this.m_Provider.GetService(typeof(IWindowsFormsEditorService));
				if (windowsFormsEditorService != null)
				{
					windowsFormsEditorService.ShowDialog(this.MainForm);
					this.m_Context.OnComponentChanged();
					this.MainPlugIn.Dispose();
					this.m_MainPlugIn = null;
					goto IL_015b;
				}
				return base.EditValue(this.m_Context, this.m_Provider, this.m_OriginalInstance);
			}
			if (!modal && !designTimeStyle)
			{
				this.MainForm.TopMost = true;
				this.MainForm.Show();
				this.MainForm.BringToFront();
			}
			else
			{
				this.MainForm.ShowDialog();
				this.MainPlugIn.Dispose();
				this.MainForm.Dispose();
				this.m_MainPlugIn = null;
				this.m_MainForm = null;
			}
			goto IL_015b;
			IL_015b:
			return value;
		}

		private void SetupDesignTime(bool showAbout)
		{
			this.MainForm = new Form();
			this.MainForm.Text = this.MainPlugInTitle;
			this.MainForm.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MainForm.StartPosition = FormStartPosition.CenterScreen;
			this.MainForm.ShowInTaskbar = false;
			this.MainForm.MaximizeBox = false;
			this.MainForm.MinimizeBox = false;
			this.m_ScaleRatio = (float)((int)Math.Ceiling((double)this.MainForm.Font.GetHeight()) / this.MainForm.AutoScaleBaseSize.Height);
			this.MainForm.AutoScaleMode = AutoScaleMode.None;
			this.m_ControlPanel = new PlugInControlPanel();
			this.m_ControlPanel.Dock = DockStyle.Bottom;
			this.m_ControlPanel.OKButton.Click += this.ControlPanel_OkButtonClick;
			this.m_ControlPanel.CancelButton.Click += this.ControlPanel_CancelButtonClick;
			this.m_ControlPanel.ApplyButton.Click += this.ControlPanel_ApplyButtonClick;
			this.m_ControlPanel.ResetButton.Click += this.ResetButton_Click;
			this.m_ControlPanel.RestoreButton.Click += this.RestoreButton_Click;
			this.UpdateExtents(this.m_ControlPanel.RequiredWidthMin, 0);
			this.MainForm.Controls.Add(this.m_ControlPanel);
			this.m_WorkingInstance = GPFunctions.CreateInstance(this.m_OriginalInstance.GetType(), this.m_OriginalInstance.GetType().FullName);
			this.m_RestoreInstance = GPFunctions.CreateInstance(this.m_OriginalInstance.GetType(), this.m_OriginalInstance.GetType().FullName);
			this.m_ResetInstance = GPFunctions.CreateInstance(this.m_OriginalInstance.GetType(), this.m_OriginalInstance.GetType().FullName);
			if (this.m_OriginalInstance is SubClassBase)
			{
				(this.m_OriginalInstance as ISubClassBase).ResetClone(this.m_ResetInstance as SubClassBase);
			}
			if (this.m_ResetInstance is IComponentBase)
			{
				(this.m_ResetInstance as IComponentBase).SetComponentDefaults();
			}
			if (this.m_ResetInstance is CollectionBase)
			{
				(this.m_ResetInstance as CollectionBase).Reset();
			}
			if (this.m_OriginalInstance is IControlBase)
			{
				this.I_ControlBase = (this.m_OriginalInstance as IControlBase);
				this.m_SurrogateParent = new Label();
				if (this.I_ControlBase._Parent != null)
				{
					this.m_SurrogateParent.BackColor = this.I_ControlBase._Parent.BackColor;
					this.m_SurrogateParent.ForeColor = this.I_ControlBase._Parent.ForeColor;
					this.m_SurrogateParent.Font = this.I_ControlBase._Parent.Font;
				}
				(this.m_WorkingInstance as Control).Parent = this.m_SurrogateParent;
				(this.m_ResetInstance as Control).Parent = this.m_SurrogateParent;
				(this.m_RestoreInstance as Control).Parent = this.m_SurrogateParent;
			}
			else if (this.m_OriginalInstance is ISubClassBase)
			{
				this.I_ControlBase = (this.m_OriginalInstance as ISubClassBase).ControlBase;
				(this.m_WorkingInstance as ISubClassBase).ControlBase = this;
				(this.m_ResetInstance as ISubClassBase).ControlBase = this;
				(this.m_RestoreInstance as ISubClassBase).ControlBase = this;
				(this.m_WorkingInstance as ISubClassBase).AmbientOwner = (this.m_OriginalInstance as ISubClassBase).AmbientOwner;
				(this.m_ResetInstance as ISubClassBase).AmbientOwner = (this.m_OriginalInstance as ISubClassBase).AmbientOwner;
				(this.m_RestoreInstance as ISubClassBase).AmbientOwner = (this.m_OriginalInstance as ISubClassBase).AmbientOwner;
			}
			else if (this.m_OriginalInstance is ICollectionBase)
			{
				(this.m_WorkingInstance as ICollectionBase).ComponentBase = (this.m_OriginalInstance as ICollectionBase).ComponentBase;
				(this.m_ResetInstance as ICollectionBase).ComponentBase = (this.m_OriginalInstance as ICollectionBase).ComponentBase;
				(this.m_RestoreInstance as ICollectionBase).ComponentBase = (this.m_OriginalInstance as ICollectionBase).ComponentBase;
			}
			TabControl tabControl = new TabControl();
			this.MainForm.Controls.Add(tabControl);
			tabControl.Dock = DockStyle.Fill;
			if (this.m_OriginalInstance is SubClassBase)
			{
				this.MainPlugIn.TabName = "General";
			}
			else
			{
				this.MainPlugIn.TabName = "Control";
			}
			this.MainPlugIn.TabControl = tabControl;
			TabPage tabPage = new TabPage();
			tabPage.Text = "About";
			tabControl.Controls.Add(tabPage);
			this.m_TabPageBorderSize = 4;
			this.m_TabPageDockMargin = 8;
			this.m_TabHeight = tabControl.Height - tabControl.DisplayRectangle.Height - 8;
			tabControl.Controls.Remove(tabPage);
			tabPage.Dispose();
			int tabPageBorderSize = this.TabPageBorderSize;
			int tabPageBorderSize2 = this.TabPageBorderSize;
			int offsetTop = this.TabHeight + this.TabPageBorderSize;
			int tabPageBorderSize3 = this.TabPageBorderSize;
			this.MainPlugIn.DoTabs(tabControl, true, tabPageBorderSize, tabPageBorderSize2, offsetTop, tabPageBorderSize3, this.m_ScaleRatio, this, this.MainPlugIn.ClassPlugIns);
			if (showAbout)
			{
				this.m_AboutPlugIn = new AboutPlugIn();
				this.m_AboutPlugIn.TabName = "About";
				this.m_AboutPlugIn.DoTabs(tabControl, true, tabPageBorderSize, tabPageBorderSize2, offsetTop, tabPageBorderSize3, this.m_ScaleRatio, this, this.MainPlugIn.SubPlugIns);
			}
			this.MainPlugIn.WorkingInstance = this.m_WorkingInstance;
			this.MainPlugIn.OriginalInstance = this.m_OriginalInstance;
			this.TransferAmbient(this.m_OriginalInstance, this.m_WorkingInstance);
			this.TransferAmbient(this.m_OriginalInstance, this.m_RestoreInstance);
			this.MainPlugIn.UploadDisplay();
			this.MainForm.ClientSize = new Size(this.m_MaxWidth, this.m_MaxHeight + this.m_ControlPanel.Height);
			tabControl.Dock = DockStyle.None;
			tabControl.Height = this.m_MaxHeight;
			tabControl.Width = this.m_MaxWidth;
			this.MainPlugIn.FixupAlign();
			this.m_ControlPanel.Dock = DockStyle.None;
			this.m_ControlPanel.Width = this.MainForm.ClientSize.Width;
			this.m_ControlPanel.Top = this.MainForm.ClientSize.Height - this.m_ControlPanel.Height;
			this.m_ControlPanel.DoLayout();
			this.UpdateControlPanel();
		}

		private void SetupRuntime(bool showAbout)
		{
			this.MainForm = new Form();
			this.MainForm.Text = this.MainPlugInTitle;
			this.MainForm.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MainForm.StartPosition = FormStartPosition.CenterScreen;
			this.MainForm.ShowInTaskbar = false;
			this.MainForm.MaximizeBox = false;
			this.MainForm.MinimizeBox = false;
			this.m_ScaleRatio = (float)((int)Math.Ceiling((double)this.MainForm.Font.GetHeight()) / this.MainForm.AutoScaleBaseSize.Height);
			this.MainForm.AutoScaleMode = AutoScaleMode.None;
			TabControl tabControl = new TabControl();
			this.MainForm.Controls.Add(tabControl);
			tabControl.Dock = DockStyle.Fill;
			this.MainPlugIn.TabName = this.MainPlugInTabName;
			this.MainPlugIn.TabControl = tabControl;
			TabPage tabPage = new TabPage();
			tabPage.Text = "About";
			tabControl.Controls.Add(tabPage);
			this.m_TabPageBorderSize = 4;
			this.m_TabPageDockMargin = 8;
			this.m_TabHeight = tabControl.Height - tabControl.DisplayRectangle.Height - 8;
			tabControl.Controls.Remove(tabPage);
			tabPage.Dispose();
			int tabPageBorderSize = this.TabPageBorderSize;
			int tabPageBorderSize2 = this.TabPageBorderSize;
			int offsetTop = this.TabHeight + this.TabPageBorderSize;
			int tabPageBorderSize3 = this.TabPageBorderSize;
			this.MainPlugIn.DoTabs(tabControl, true, tabPageBorderSize, tabPageBorderSize2, offsetTop, tabPageBorderSize3, this.m_ScaleRatio, this, this.MainPlugIn.ClassPlugIns);
			if (showAbout)
			{
				this.m_AboutPlugIn = new AboutPlugIn();
				this.m_AboutPlugIn.TabName = "About";
				this.m_AboutPlugIn.DoTabs(tabControl, true, tabPageBorderSize, tabPageBorderSize2, offsetTop, tabPageBorderSize3, this.m_ScaleRatio, this, this.MainPlugIn.SubPlugIns);
			}
			this.MainPlugIn.OriginalInstance = this.m_OriginalInstance;
			this.MainPlugIn.WorkingInstance = this.m_OriginalInstance;
			this.MainPlugIn.UploadDisplay();
			this.MainForm.ClientSize = new Size(this.m_MaxWidth, this.m_MaxHeight);
			tabControl.Dock = DockStyle.None;
			tabControl.Height = this.m_MaxHeight;
			tabControl.Width = this.m_MaxWidth;
			this.MainPlugIn.FixupAlign();
		}

		private void UpdateControlPanel()
		{
			if (this.m_ControlPanel != null)
			{
				if (this.MainPlugIn.GetIsDirty())
				{
					this.m_ControlPanel.OKButton.Enabled = true;
					this.m_ControlPanel.CancelButton.Enabled = true;
					this.m_ControlPanel.ApplyButton.Enabled = true;
				}
				else
				{
					this.m_ControlPanel.OKButton.Enabled = true;
					this.m_ControlPanel.CancelButton.Enabled = true;
					this.m_ControlPanel.ApplyButton.Enabled = false;
				}
			}
		}

		private void TransferAmbient(object source, object destination)
		{
			this.MainPlugIn.Source = source;
			this.MainPlugIn.Destination = destination;
			this.MainPlugIn.TransferAmbient();
		}

		private void DownloadToOriginal()
		{
			if (this.I_ControlBase != null)
			{
				this.I_ControlBase.FreezeAutoSize = true;
			}
			try
			{
				this.TransferAmbient(this.m_WorkingInstance, this.m_OriginalInstance);
			}
			finally
			{
				if (this.I_ControlBase != null)
				{
					this.I_ControlBase.FreezeAutoSize = false;
				}
			}
			if (this.I_IForceDesignerChange != null)
			{
				this.I_IForceDesignerChange.ForceChange();
			}
		}

		private void ControlPanel_OkButtonClick(object sender, EventArgs e)
		{
			this.DownloadToOriginal();
			this.MainForm.DialogResult = DialogResult.OK;
		}

		private void ControlPanel_ApplyButtonClick(object sender, EventArgs e)
		{
			this.DownloadToOriginal();
			this.UpdateControlPanel();
		}

		private void ControlPanel_CancelButtonClick(object sender, EventArgs e)
		{
			this.MainForm.DialogResult = DialogResult.Cancel;
		}

		private void ResetButton_Click(object sender, EventArgs e)
		{
			this.TransferAmbient(this.m_ResetInstance, this.m_WorkingInstance);
			this.MainPlugIn.UploadDisplay();
			this.UpdateControlPanel();
		}

		private void RestoreButton_Click(object sender, EventArgs e)
		{
			this.TransferAmbient(this.m_RestoreInstance, this.m_WorkingInstance);
			this.MainPlugIn.UploadDisplay();
			this.UpdateControlPanel();
		}

		private object CreatePlugInByFullName(string fullName)
		{
			return (PlugInStandard)GPFunctions.CreateInstance(null, fullName);
		}

		private void CreatePlugInInternal()
		{
			if (this.CreateMainPlugIn != null)
			{
				UITypeEditorEventArgs uITypeEditorEventArgs = new UITypeEditorEventArgs(this);
				this.CreateMainPlugIn(this, uITypeEditorEventArgs);
				this.m_MainPlugIn = uITypeEditorEventArgs.MainPlugIn;
				this.m_MainPlugInTitle = uITypeEditorEventArgs.MainPlugInTitle;
				this.m_MainPlugInTabName = uITypeEditorEventArgs.MainPlugInTabName;
			}
			else if (this.m_OriginalInstance is ISupportUITypeEditor)
			{
				this.m_MainPlugInTitle = (this.m_OriginalInstance as ISupportUITypeEditor).GetPlugInTitle() + " Editor";
				string plugInClassName = (this.m_OriginalInstance as ISupportUITypeEditor).GetPlugInClassName();
				this.m_MainPlugIn = (this.CreatePlugInByFullName(plugInClassName) as PlugInStandard);
			}
			if (this.m_OriginalInstance is SubClassBase)
			{
				this.m_MainPlugInTabName = "General";
			}
			else
			{
				this.m_MainPlugInTabName = "Control";
			}
		}

		public void DoPropertyChange(object sender, string propertyName)
		{
		}

		public void ForceDesignerChange()
		{
		}

		public void DoAutoSize()
		{
		}

		public void DoAutoSizeSpecialOffset(int specialOffset)
		{
		}

		public void LoadingBegin()
		{
		}

		public void LoadingEnd()
		{
		}

		public bool Focus()
		{
			return false;
		}

		public void SetComponentDefaults()
		{
		}

		public void ShowEditorCustom(bool designTimeStyle, bool modal)
		{
		}
	}
}
