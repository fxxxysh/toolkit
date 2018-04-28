using System;

namespace Iocomp.Design
{
	public class UITypeEditorEventArgs : EventArgs
	{
		private UITypeEditorGeneric m_Editor;

		private PlugInStandard m_MainPlugIn;

		private string m_MainPlugInTitle;

		private string m_MainPlugInTabName;

		public UITypeEditorGeneric Editor => this.m_Editor;

		public PlugInStandard MainPlugIn
		{
			get
			{
				return this.m_MainPlugIn;
			}
			set
			{
				this.m_MainPlugIn = value;
			}
		}

		public string MainPlugInTitle
		{
			get
			{
				return this.m_MainPlugInTitle;
			}
			set
			{
				this.m_MainPlugInTitle = value;
			}
		}

		public string MainPlugInTabName
		{
			get
			{
				return this.m_MainPlugInTabName;
			}
			set
			{
				this.m_MainPlugInTabName = value;
			}
		}

		public UITypeEditorEventArgs(UITypeEditorGeneric editor)
		{
			this.m_Editor = editor;
		}
	}
}
