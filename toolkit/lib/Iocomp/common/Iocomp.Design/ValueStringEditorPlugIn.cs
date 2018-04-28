using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public sealed class ValueStringEditorPlugIn : PlugInStandard
	{
		private EditBox StringTextBox;

		private FocusLabel label1;

		private CheckBox EventsEnabledCheckBox;

		private Container components;

		public ValueStringEditorPlugIn()
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
			this.StringTextBox = new EditBox();
			this.label1 = new FocusLabel();
			this.EventsEnabledCheckBox = new CheckBox();
			base.SuspendLayout();
			this.StringTextBox.LoadingBegin();
			this.StringTextBox.Location = new Point(56, 32);
			this.StringTextBox.Name = "StringTextBox";
			this.StringTextBox.PropertyName = "AsString";
			this.StringTextBox.Size = new Size(320, 20);
			this.StringTextBox.TabIndex = 0;
			this.StringTextBox.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.StringTextBox;
			this.label1.Location = new Point(20, 34);
			this.label1.Name = "label1";
			this.label1.Size = new Size(36, 15);
			this.label1.Text = "Value";
			this.label1.LoadingEnd();
			this.EventsEnabledCheckBox.Location = new Point(56, 64);
			this.EventsEnabledCheckBox.Name = "EventsEnabledCheckBox";
			this.EventsEnabledCheckBox.PropertyName = "EventsEnabled";
			this.EventsEnabledCheckBox.Size = new Size(120, 24);
			this.EventsEnabledCheckBox.TabIndex = 1;
			this.EventsEnabledCheckBox.Text = "Events Enabled";
			base.Controls.Add(this.EventsEnabledCheckBox);
			base.Controls.Add(this.StringTextBox);
			base.Controls.Add(this.label1);
			base.Name = "ValueStringEditorPlugIn";
			base.Size = new Size(408, 112);
			base.Title = "Value String Editor";
			base.ResumeLayout(false);
		}
	}
}
