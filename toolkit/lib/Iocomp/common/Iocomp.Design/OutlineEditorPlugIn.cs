using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class OutlineEditorPlugIn : PlugInStandard
	{
		private FocusLabel label4;

		private FocusLabel label2;

		private EditBox ThicknessTextBox;

		private ColorPicker ColorPicker;

		private Container components;

		public OutlineEditorPlugIn()
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
			this.label4 = new FocusLabel();
			this.ColorPicker = new ColorPicker();
			this.label2 = new FocusLabel();
			this.ThicknessTextBox = new EditBox();
			base.SuspendLayout();
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.ColorPicker;
			this.label4.Location = new Point(38, 59);
			this.label4.Name = "label4";
			this.label4.Size = new Size(34, 15);
			this.label4.Text = "Color";
			this.label4.LoadingEnd();
			this.ColorPicker.Location = new Point(72, 56);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(144, 21);
			this.ColorPicker.TabIndex = 1;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.ThicknessTextBox;
			this.label2.Location = new Point(15, 26);
			this.label2.Name = "label2";
			this.label2.Size = new Size(57, 15);
			this.label2.Text = "Thickness";
			this.label2.LoadingEnd();
			this.ThicknessTextBox.LoadingBegin();
			this.ThicknessTextBox.Location = new Point(72, 24);
			this.ThicknessTextBox.Name = "ThicknessTextBox";
			this.ThicknessTextBox.PropertyName = "Thickness";
			this.ThicknessTextBox.Size = new Size(32, 20);
			this.ThicknessTextBox.TabIndex = 0;
			this.ThicknessTextBox.LoadingEnd();
			base.Controls.Add(this.ThicknessTextBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label4);
			base.Name = "OutlineEditorPlugIn";
			base.Size = new Size(264, 120);
			base.Title = "Outline Editor";
			base.ResumeLayout(false);
		}
	}
}
