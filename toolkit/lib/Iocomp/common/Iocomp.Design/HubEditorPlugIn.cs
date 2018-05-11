using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class HubEditorPlugIn : PlugInStandard
	{
		private FocusLabel label4;

		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SizeNumericUpDown;

		private ColorPicker ColorPicker;

		private Container components;

		public HubEditorPlugIn()
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
			this.SizeNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.ColorPicker;
			this.label4.Location = new Point(38, 99);
			this.label4.Name = "label4";
			this.label4.Size = new Size(34, 15);
			this.label4.Text = "Color";
			this.label4.LoadingEnd();
			this.ColorPicker.Location = new Point(72, 96);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(144, 21);
			this.ColorPicker.TabIndex = 2;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.SizeNumericUpDown;
			this.label2.Location = new Point(43, 65);
			this.label2.Name = "label2";
			this.label2.Size = new Size(29, 15);
			this.label2.Text = "Size";
			this.label2.LoadingEnd();
			this.SizeNumericUpDown.Location = new Point(72, 64);
			this.SizeNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			this.SizeNumericUpDown.Name = "SizeNumericUpDown";
			this.SizeNumericUpDown.PropertyName = "Size";
			this.SizeNumericUpDown.Size = new Size(48, 20);
			this.SizeNumericUpDown.TabIndex = 1;
			this.SizeNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.VisibleCheckBox.Location = new Point(72, 32);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(64, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			base.Controls.Add(this.SizeNumericUpDown);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label4);
			base.Name = "HubEditorPlugIn";
			base.Size = new Size(400, 256);
			base.Title = "Hub Editor";
			base.ResumeLayout(false);
		}
	}
}
