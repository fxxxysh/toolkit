using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlugInControlPanel : UserControl
	{
		private Button m_ApplyButton;

		private Button m_CancelButton;

		private Button m_OKButton;

		private Button m_ResetButton;

		private Button m_RestoreButton;

		private Container components;

		public Button ApplyButton => this.m_ApplyButton;

		public Button CancelButton => this.m_CancelButton;

		public Button OKButton => this.m_OKButton;

		public Button ResetButton => this.m_ResetButton;

		public Button RestoreButton => this.m_RestoreButton;

		public int RequiredWidthMin => 10 + this.ApplyButton.Width + this.CancelButton.Width + this.OKButton.Width + this.ResetButton.Width + this.RestoreButton.Width + 20;

		public PlugInControlPanel()
		{
			this.InitializeComponent();
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
			this.m_ApplyButton = new Button();
			this.m_CancelButton = new Button();
			this.m_OKButton = new Button();
			this.m_ResetButton = new Button();
			this.m_RestoreButton = new Button();
			base.SuspendLayout();
			this.m_ApplyButton.Location = new Point(344, 6);
			this.m_ApplyButton.Name = "m_ApplyButton";
			this.m_ApplyButton.Size = new Size(60, 22);
			this.m_ApplyButton.TabIndex = 4;
			this.m_ApplyButton.Text = "Apply";
			this.m_CancelButton.Location = new Point(264, 6);
			this.m_CancelButton.Name = "m_CancelButton";
			this.m_CancelButton.Size = new Size(60, 22);
			this.m_CancelButton.TabIndex = 3;
			this.m_CancelButton.Text = "Cancel";
			this.m_OKButton.Location = new Point(184, 6);
			this.m_OKButton.Name = "m_OKButton";
			this.m_OKButton.Size = new Size(60, 22);
			this.m_OKButton.TabIndex = 2;
			this.m_OKButton.Text = "OK";
			this.m_ResetButton.Location = new Point(8, 6);
			this.m_ResetButton.Name = "m_ResetButton";
			this.m_ResetButton.Size = new Size(60, 23);
			this.m_ResetButton.TabIndex = 0;
			this.m_ResetButton.Text = "Reset";
			this.m_RestoreButton.Location = new Point(88, 6);
			this.m_RestoreButton.Name = "m_RestoreButton";
			this.m_RestoreButton.Size = new Size(60, 23);
			this.m_RestoreButton.TabIndex = 1;
			this.m_RestoreButton.Text = "Restore";
			base.Controls.Add(this.m_RestoreButton);
			base.Controls.Add(this.m_ResetButton);
			base.Controls.Add(this.m_ApplyButton);
			base.Controls.Add(this.m_CancelButton);
			base.Controls.Add(this.m_OKButton);
			base.Name = "PlugInControlPanel";
			base.Size = new Size(418, 32);
			base.SizeChanged += this.UITypeEditorControlPanel_SizeChanged;
			base.ResumeLayout(false);
		}

		private void UITypeEditorControlPanel_SizeChanged(object sender, EventArgs e)
		{
			this.DoLayout();
		}

		public void DoLayout()
		{
			this.ApplyButton.Left = base.Width - 5 - this.ApplyButton.Width;
			this.CancelButton.Left = this.ApplyButton.Left - this.CancelButton.Width;
			this.OKButton.Left = this.CancelButton.Left - this.OKButton.Width;
			this.ResetButton.Left = 5;
			this.RestoreButton.Left = this.ResetButton.Right;
		}
	}
}
