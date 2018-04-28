using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public sealed class ValueDateTimeEditorPlugIn : PlugInStandard
	{
		private GroupBox groupBox1;

		private FocusLabel label7;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.DateTimePicker DatePicker;

		private Iocomp.Design.Plugin.EditorControls.DateTimePicker TimePicker;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EventsEnabledCheckBox;

		private Container components;

		public ValueDateTimeEditorPlugIn()
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
			this.groupBox1 = new GroupBox();
			this.label7 = new FocusLabel();
			this.DatePicker = new Iocomp.Design.Plugin.EditorControls.DateTimePicker();
			this.label8 = new FocusLabel();
			this.TimePicker = new Iocomp.Design.Plugin.EditorControls.DateTimePicker();
			this.EventsEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.DatePicker);
			this.groupBox1.Controls.Add(this.TimePicker);
			this.groupBox1.Location = new Point(16, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(168, 88);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "As Date Time";
			this.label7.LoadingBegin();
			this.label7.FocusControl = this.DatePicker;
			this.label7.Location = new Point(25, 35);
			this.label7.Name = "label7";
			this.label7.Size = new Size(31, 15);
			this.label7.Text = "Date";
			this.label7.LoadingEnd();
			this.DatePicker.Format = DateTimePickerFormat.Short;
			this.DatePicker.Location = new Point(56, 32);
			this.DatePicker.Name = "DatePicker";
			this.DatePicker.PropertyName = "AsDateTime";
			this.DatePicker.Size = new Size(96, 20);
			this.DatePicker.TabIndex = 0;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.TimePicker;
			this.label8.Location = new Point(24, 59);
			this.label8.Name = "label8";
			this.label8.Size = new Size(32, 15);
			this.label8.Text = "Time";
			this.label8.LoadingEnd();
			this.TimePicker.Format = DateTimePickerFormat.Time;
			this.TimePicker.Location = new Point(56, 56);
			this.TimePicker.Name = "TimePicker";
			this.TimePicker.PropertyName = "AsDateTime";
			this.TimePicker.ShowUpDown = true;
			this.TimePicker.Size = new Size(96, 20);
			this.TimePicker.TabIndex = 1;
			this.EventsEnabledCheckBox.Location = new Point(16, 112);
			this.EventsEnabledCheckBox.Name = "EventsEnabledCheckBox";
			this.EventsEnabledCheckBox.PropertyName = "EventsEnabled";
			this.EventsEnabledCheckBox.Size = new Size(112, 24);
			this.EventsEnabledCheckBox.TabIndex = 1;
			this.EventsEnabledCheckBox.Text = "Events Enabled";
			base.Controls.Add(this.EventsEnabledCheckBox);
			base.Controls.Add(this.groupBox1);
			base.Name = "ValueDateTimeEditorPlugIn";
			base.Size = new Size(424, 248);
			base.Title = "Value Date-Time Editor";
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
