using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class ColorSectionEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private FocusLabel label4;

		private EditBox StartTextBox;

		private EditBox StopTextBox;

		private CheckBox VisibleCheckBox;

		private FocusLabel label1;

		private ColorPicker ColorPicker;

		private Container components;

		public ColorSectionEditorPlugIn()
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
			this.StartTextBox = new EditBox();
			this.label2 = new FocusLabel();
			this.ColorPicker = new ColorPicker();
			this.label4 = new FocusLabel();
			this.StopTextBox = new EditBox();
			this.VisibleCheckBox = new CheckBox();
			this.label1 = new FocusLabel();
			base.SuspendLayout();
			this.StartTextBox.LoadingBegin();
			this.StartTextBox.Location = new Point(72, 72);
			this.StartTextBox.Name = "StartTextBox";
			this.StartTextBox.PropertyName = "Start";
			this.StartTextBox.Size = new Size(48, 20);
			this.StartTextBox.TabIndex = 2;
			this.StartTextBox.LoadingEnd();
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.StartTextBox;
			this.label2.Location = new Point(41, 74);
			this.label2.Name = "label2";
			this.label2.Size = new Size(31, 15);
			this.label2.Text = "Start";
			this.label2.LoadingEnd();
			this.ColorPicker.Location = new Point(72, 40);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(144, 21);
			this.ColorPicker.TabIndex = 1;
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.ColorPicker;
			this.label4.Location = new Point(38, 43);
			this.label4.Name = "label4";
			this.label4.Size = new Size(34, 15);
			this.label4.Text = "Color";
			this.label4.LoadingEnd();
			this.StopTextBox.LoadingBegin();
			this.StopTextBox.Location = new Point(72, 96);
			this.StopTextBox.Name = "StopTextBox";
			this.StopTextBox.PropertyName = "Stop";
			this.StopTextBox.Size = new Size(48, 20);
			this.StopTextBox.TabIndex = 3;
			this.StopTextBox.LoadingEnd();
			this.VisibleCheckBox.Location = new Point(72, 8);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.StopTextBox;
			this.label1.Location = new Point(42, 98);
			this.label1.Name = "label1";
			this.label1.Size = new Size(30, 15);
			this.label1.Text = "Stop";
			this.label1.LoadingEnd();
			base.Controls.Add(this.label1);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.StopTextBox);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.StartTextBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label4);
			base.Name = "ColorSectionEditorPlugIn";
			base.Size = new Size(232, 328);
			base.ResumeLayout(false);
		}
	}
}
