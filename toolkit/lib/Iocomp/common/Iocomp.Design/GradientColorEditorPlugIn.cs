using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class GradientColorEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private EditBox PositionTextBox;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private Label label1;

		private Label label3;

		private Label label4;

		private Label label6;

		private Label label7;

		private Container components;

		public GradientColorEditorPlugIn()
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
			this.label2 = new FocusLabel();
			this.PositionTextBox = new EditBox();
			this.ColorPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.label1 = new Label();
			this.label3 = new Label();
			this.label4 = new Label();
			this.label6 = new Label();
			this.label7 = new Label();
			base.SuspendLayout();
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.PositionTextBox;
			this.label2.Location = new Point(113, 42);
			this.label2.Name = "label2";
			this.label2.Size = new Size(47, 15);
			this.label2.Text = "Position";
			this.label2.LoadingEnd();
			this.PositionTextBox.LoadingBegin();
			this.PositionTextBox.Location = new Point(160, 40);
			this.PositionTextBox.Name = "PositionTextBox";
			this.PositionTextBox.PropertyName = "Position";
			this.PositionTextBox.Size = new Size(104, 20);
			this.PositionTextBox.TabIndex = 1;
			this.PositionTextBox.LoadingEnd();
			this.ColorPicker.Location = new Point(48, 40);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(48, 21);
			this.ColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorPicker.TabIndex = 0;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorPicker;
			this.label8.Location = new Point(14, 43);
			this.label8.Name = "label8";
			this.label8.Size = new Size(34, 15);
			this.label8.Text = "Color";
			this.label8.LoadingEnd();
			this.label1.AutoSize = true;
			this.label1.Location = new Point(24, 110);
			this.label1.Name = "label1";
			this.label1.Size = new Size(155, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "- First item position must be 0.";
			this.label3.AutoSize = true;
			this.label3.Location = new Point(24, 154);
			this.label3.Name = "label3";
			this.label3.Size = new Size(155, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "- Last item position must be 1.";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(24, 88);
			this.label4.Name = "label4";
			this.label4.Size = new Size(112, 16);
			this.label4.TabIndex = 2;
			this.label4.Text = "- Minimum of 2 items.";
			this.label6.Location = new Point(24, 176);
			this.label6.Name = "label6";
			this.label6.Size = new Size(296, 32);
			this.label6.TabIndex = 6;
			this.label6.Text = "- If any of the previous requirements are not satisfied, orange && yellow will be used.";
			this.label7.AutoSize = true;
			this.label7.Location = new Point(24, 132);
			this.label7.Name = "label7";
			this.label7.Size = new Size(191, 16);
			this.label7.TabIndex = 4;
			this.label7.Text = "- Item position's must be incremental.";
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.PositionTextBox);
			base.Controls.Add(this.label2);
			base.Name = "GradientColorEditorPlugIn";
			base.Size = new Size(560, 240);
			base.ResumeLayout(false);
		}
	}
}
