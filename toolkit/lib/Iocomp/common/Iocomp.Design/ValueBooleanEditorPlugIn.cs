using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public sealed class ValueBooleanEditorPlugIn : PlugInStandard
	{
		private Container components;

		private CheckBox EventsEnabledCheckBox;

		private CheckBox AsBooleanCheckBox;

		public ValueBooleanEditorPlugIn()
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
			this.EventsEnabledCheckBox = new CheckBox();
			this.AsBooleanCheckBox = new CheckBox();
			base.SuspendLayout();
			this.EventsEnabledCheckBox.Location = new Point(24, 48);
			this.EventsEnabledCheckBox.Name = "EventsEnabledCheckBox";
			this.EventsEnabledCheckBox.PropertyName = "EventsEnabled";
			this.EventsEnabledCheckBox.Size = new Size(120, 24);
			this.EventsEnabledCheckBox.TabIndex = 1;
			this.EventsEnabledCheckBox.Text = "Events Enabled";
			this.AsBooleanCheckBox.Location = new Point(24, 16);
			this.AsBooleanCheckBox.Name = "AsBooleanCheckBox";
			this.AsBooleanCheckBox.PropertyName = "AsBoolean";
			this.AsBooleanCheckBox.TabIndex = 0;
			this.AsBooleanCheckBox.Text = "Value";
			base.Controls.Add(this.AsBooleanCheckBox);
			base.Controls.Add(this.EventsEnabledCheckBox);
			base.Name = "ValueBooleanEditorPlugIn";
			base.Size = new Size(408, 112);
			base.Title = "Value Boolean Editor";
			base.ResumeLayout(false);
		}
	}
}
