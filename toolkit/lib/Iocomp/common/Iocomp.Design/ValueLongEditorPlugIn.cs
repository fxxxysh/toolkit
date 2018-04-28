using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public sealed class ValueLongEditorPlugIn : PlugInStandard
	{
		private Container components;

		private FocusLabel label1;

		private CheckBox EventsEnabledCheckBox;

		private FocusLabel label2;

		private FocusLabel label3;

		private EditBox MinTextBox;

		private EditBox ValueTextBox;

		private EditBox AsHexTextBox;

		private FocusLabel label4;

		private EditBox AsBinaryTextBox;

		private FocusLabel focusLabel1;

		private EditBox MaxTextBox;

		public ValueLongEditorPlugIn()
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
			this.AsHexTextBox = new EditBox();
			this.label4 = new FocusLabel();
			this.AsBinaryTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			base.SuspendLayout();
			this.ValueTextBox.LoadingBegin();
			this.ValueTextBox.Location = new Point(64, 8);
			this.ValueTextBox.Name = "ValueTextBox";
			this.ValueTextBox.PropertyName = "AsLong";
			this.ValueTextBox.Size = new Size(208, 20);
			this.ValueTextBox.TabIndex = 0;
			this.ValueTextBox.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.ValueTextBox;
			this.label1.Location = new Point(28, 10);
			this.label1.Name = "label1";
			this.label1.Size = new Size(36, 15);
			this.label1.Text = "Value";
			this.label1.LoadingEnd();
			this.EventsEnabledCheckBox.Location = new Point(64, 152);
			this.EventsEnabledCheckBox.Name = "EventsEnabledCheckBox";
			this.EventsEnabledCheckBox.PropertyName = "EventsEnabled";
			this.EventsEnabledCheckBox.Size = new Size(112, 24);
			this.EventsEnabledCheckBox.TabIndex = 5;
			this.EventsEnabledCheckBox.Text = "Events Enabled";
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.MinTextBox;
			this.label2.Location = new Point(39, 90);
			this.label2.Name = "label2";
			this.label2.Size = new Size(25, 15);
			this.label2.Text = "Min";
			this.label2.LoadingEnd();
			this.MinTextBox.LoadingBegin();
			this.MinTextBox.Location = new Point(64, 88);
			this.MinTextBox.Name = "MinTextBox";
			this.MinTextBox.PropertyName = "Min";
			this.MinTextBox.Size = new Size(104, 20);
			this.MinTextBox.TabIndex = 3;
			this.MinTextBox.LoadingEnd();
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.MaxTextBox;
			this.label3.Location = new Point(36, 114);
			this.label3.Name = "label3";
			this.label3.Size = new Size(28, 15);
			this.label3.Text = "Max";
			this.label3.LoadingEnd();
			this.MaxTextBox.LoadingBegin();
			this.MaxTextBox.Location = new Point(64, 112);
			this.MaxTextBox.Name = "MaxTextBox";
			this.MaxTextBox.PropertyName = "Max";
			this.MaxTextBox.Size = new Size(104, 20);
			this.MaxTextBox.TabIndex = 4;
			this.MaxTextBox.LoadingEnd();
			this.AsHexTextBox.LoadingBegin();
			this.AsHexTextBox.Location = new Point(64, 32);
			this.AsHexTextBox.LongFormat = EditBoxLongFormat.Hex;
			this.AsHexTextBox.Name = "AsHexTextBox";
			this.AsHexTextBox.PropertyName = "AsLong";
			this.AsHexTextBox.Size = new Size(208, 20);
			this.AsHexTextBox.TabIndex = 1;
			this.AsHexTextBox.LoadingEnd();
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.AsHexTextBox;
			this.label4.Location = new Point(21, 34);
			this.label4.Name = "label4";
			this.label4.Size = new Size(43, 15);
			this.label4.Text = "As Hex";
			this.label4.LoadingEnd();
			this.AsBinaryTextBox.LoadingBegin();
			this.AsBinaryTextBox.Location = new Point(64, 56);
			this.AsBinaryTextBox.LongFormat = EditBoxLongFormat.Binary;
			this.AsBinaryTextBox.Name = "AsBinaryTextBox";
			this.AsBinaryTextBox.PropertyName = "AsLong";
			this.AsBinaryTextBox.Size = new Size(208, 20);
			this.AsBinaryTextBox.TabIndex = 2;
			this.AsBinaryTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.AsBinaryTextBox;
			this.focusLabel1.Location = new Point(9, 58);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(55, 15);
			this.focusLabel1.Text = "As Binary";
			this.focusLabel1.LoadingEnd();
			base.Controls.Add(this.AsBinaryTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.AsHexTextBox);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.MaxTextBox);
			base.Controls.Add(this.MinTextBox);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.EventsEnabledCheckBox);
			base.Controls.Add(this.ValueTextBox);
			base.Controls.Add(this.label1);
			base.Name = "ValueLongEditorPlugIn";
			base.Size = new Size(400, 216);
			base.Title = "Value Long Editor";
			base.ResumeLayout(false);
		}
	}
}
