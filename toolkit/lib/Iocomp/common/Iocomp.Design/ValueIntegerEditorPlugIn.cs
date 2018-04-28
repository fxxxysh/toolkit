using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public sealed class ValueIntegerEditorPlugIn : PlugInStandard
	{
		private EditBox MaxTextBox;

		private EditBox MinTextBox;

		private FocusLabel label3;

		private FocusLabel label2;

		private CheckBox EventsEnabledCheckBox;

		private EditBox AsIntegerTextBox;

		private FocusLabel label1;

		private Container components;

		public ValueIntegerEditorPlugIn()
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
			this.MaxTextBox = new EditBox();
			this.MinTextBox = new EditBox();
			this.label3 = new FocusLabel();
			this.label2 = new FocusLabel();
			this.EventsEnabledCheckBox = new CheckBox();
			this.AsIntegerTextBox = new EditBox();
			this.label1 = new FocusLabel();
			base.SuspendLayout();
			this.MaxTextBox.LoadingBegin();
			this.MaxTextBox.Location = new Point(64, 56);
			this.MaxTextBox.Name = "MaxTextBox";
			this.MaxTextBox.PropertyName = "Max";
			this.MaxTextBox.TabIndex = 2;
			this.MaxTextBox.LoadingEnd();
			this.MinTextBox.LoadingBegin();
			this.MinTextBox.Location = new Point(64, 32);
			this.MinTextBox.Name = "MinTextBox";
			this.MinTextBox.PropertyName = "Min";
			this.MinTextBox.TabIndex = 1;
			this.MinTextBox.LoadingEnd();
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.MaxTextBox;
			this.label3.Location = new Point(36, 58);
			this.label3.Name = "label3";
			this.label3.Size = new Size(28, 15);
			this.label3.Text = "Max";
			this.label3.LoadingEnd();
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.MinTextBox;
			this.label2.Location = new Point(39, 34);
			this.label2.Name = "label2";
			this.label2.Size = new Size(25, 15);
			this.label2.Text = "Min";
			this.label2.LoadingEnd();
			this.EventsEnabledCheckBox.Location = new Point(64, 96);
			this.EventsEnabledCheckBox.Name = "EventsEnabledCheckBox";
			this.EventsEnabledCheckBox.PropertyName = "EventsEnabled";
			this.EventsEnabledCheckBox.Size = new Size(112, 24);
			this.EventsEnabledCheckBox.TabIndex = 3;
			this.EventsEnabledCheckBox.Text = "Events Enabled";
			this.AsIntegerTextBox.LoadingBegin();
			this.AsIntegerTextBox.Location = new Point(64, 0);
			this.AsIntegerTextBox.Name = "AsIntegerTextBox";
			this.AsIntegerTextBox.PropertyName = "AsInteger";
			this.AsIntegerTextBox.TabIndex = 0;
			this.AsIntegerTextBox.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.AsIntegerTextBox;
			this.label1.Location = new Point(28, 2);
			this.label1.Name = "label1";
			this.label1.Size = new Size(36, 15);
			this.label1.Text = "Value";
			this.label1.LoadingEnd();
			base.Controls.Add(this.MaxTextBox);
			base.Controls.Add(this.MinTextBox);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.EventsEnabledCheckBox);
			base.Controls.Add(this.AsIntegerTextBox);
			base.Controls.Add(this.label1);
			base.Name = "ValueIntegerEditorPlugIn";
			base.Size = new Size(352, 144);
			base.Title = "Value Integer Editor";
			base.ResumeLayout(false);
		}
	}
}
