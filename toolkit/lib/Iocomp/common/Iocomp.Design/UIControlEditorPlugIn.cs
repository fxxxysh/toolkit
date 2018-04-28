using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class UIControlEditorPlugIn : PlugInStandard
	{
		private CheckBox KeyboardEnabledCheckBox;

		private CheckBox FocusRectangleShowCheckBox;

		private Container components;

		public UIControlEditorPlugIn()
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
			this.KeyboardEnabledCheckBox = new CheckBox();
			this.FocusRectangleShowCheckBox = new CheckBox();
			base.SuspendLayout();
			this.KeyboardEnabledCheckBox.Location = new Point(32, 16);
			this.KeyboardEnabledCheckBox.Name = "KeyboardEnabledCheckBox";
			this.KeyboardEnabledCheckBox.PropertyName = "KeyboardEnabled";
			this.KeyboardEnabledCheckBox.Size = new Size(120, 24);
			this.KeyboardEnabledCheckBox.TabIndex = 0;
			this.KeyboardEnabledCheckBox.Text = "Keyboard Enabled";
			this.FocusRectangleShowCheckBox.Location = new Point(32, 40);
			this.FocusRectangleShowCheckBox.Name = "FocusRectangleShowCheckBox";
			this.FocusRectangleShowCheckBox.PropertyName = "FocusRectangleShow";
			this.FocusRectangleShowCheckBox.Size = new Size(144, 24);
			this.FocusRectangleShowCheckBox.TabIndex = 1;
			this.FocusRectangleShowCheckBox.Text = "Focus Rectangle Show";
			base.Controls.Add(this.FocusRectangleShowCheckBox);
			base.Controls.Add(this.KeyboardEnabledCheckBox);
			base.Name = "UIControlEditorPlugIn";
			base.Size = new Size(304, 136);
			base.Title = "UI Control Editor";
			base.ResumeLayout(false);
		}
	}
}
