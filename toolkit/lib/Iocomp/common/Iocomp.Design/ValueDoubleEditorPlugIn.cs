using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public sealed class ValueDoubleEditorPlugIn : PlugInStandard
	{
		private Container components;

		private FocusLabel label1;

		private CheckBox EventsEnabledCheckBox;

		private FocusLabel label2;

		private FocusLabel label3;

		private EditBox MinTextBox;

		private EditBox ValueTextBox;

		private EditBox MaxTextBox;

		public ValueDoubleEditorPlugIn()
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
			this.ValueTextBox = new EditBox();
			this.label1 = new FocusLabel();
			this.EventsEnabledCheckBox = new CheckBox();
			this.label2 = new FocusLabel();
			this.MinTextBox = new EditBox();
			this.label3 = new FocusLabel();
			this.MaxTextBox = new EditBox();
			base.SuspendLayout();
			this.ValueTextBox.LoadingBegin();
			this.ValueTextBox.Location = new Point(40, 16);
			this.ValueTextBox.Name = "ValueTextBox";
			this.ValueTextBox.PropertyName = "AsDouble";
			this.ValueTextBox.Size = new Size(144, 20);
			this.ValueTextBox.TabIndex = 0;
			this.ValueTextBox.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.ValueTextBox;
			this.label1.Location = new Point(4, 18);
			this.label1.Name = "label1";
			this.label1.Size = new Size(36, 15);
			this.label1.Text = "Value";
			this.label1.LoadingEnd();
			this.EventsEnabledCheckBox.Location = new Point(40, 160);
			this.EventsEnabledCheckBox.Name = "EventsEnabledCheckBox";
			this.EventsEnabledCheckBox.PropertyName = "EventsEnabled";
			this.EventsEnabledCheckBox.Size = new Size(112, 24);
			this.EventsEnabledCheckBox.TabIndex = 3;
			this.EventsEnabledCheckBox.Text = "Events Enabled";
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.MinTextBox;
			this.label2.Location = new Point(15, 74);
			this.label2.Name = "label2";
			this.label2.Size = new Size(25, 15);
			this.label2.Text = "Min";
			this.label2.LoadingEnd();
			this.MinTextBox.LoadingBegin();
			this.MinTextBox.Location = new Point(40, 72);
			this.MinTextBox.Name = "MinTextBox";
			this.MinTextBox.PropertyName = "Min";
			this.MinTextBox.Size = new Size(144, 20);
			this.MinTextBox.TabIndex = 1;
			this.MinTextBox.LoadingEnd();
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.MaxTextBox;
			this.label3.Location = new Point(12, 98);
			this.label3.Name = "label3";
			this.label3.Size = new Size(28, 15);
			this.label3.Text = "Max";
			this.label3.LoadingEnd();
			this.MaxTextBox.LoadingBegin();
			this.MaxTextBox.Location = new Point(40, 96);
			this.MaxTextBox.Name = "MaxTextBox";
			this.MaxTextBox.PropertyName = "Max";
			this.MaxTextBox.Size = new Size(144, 20);
			this.MaxTextBox.TabIndex = 2;
			this.MaxTextBox.LoadingEnd();
			base.Controls.Add(this.MaxTextBox);
			base.Controls.Add(this.MinTextBox);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.EventsEnabledCheckBox);
			base.Controls.Add(this.ValueTextBox);
			base.Controls.Add(this.label1);
			base.Name = "ValueDoubleEditorPlugIn";
			base.Size = new Size(440, 232);
			base.Title = "Value Double Editor";
			base.ResumeLayout(false);
		}
	}
}
