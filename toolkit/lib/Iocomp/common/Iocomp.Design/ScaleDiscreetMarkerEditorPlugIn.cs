using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class ScaleDiscreetMarkerEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private FocusLabel label1;

		private FocusLabel label4;

		private FocusLabel label5;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SizeNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.ComboBox BevelStyleComboBox;

		private ColorPicker ColorPicker;

		private Container components;

		public ScaleDiscreetMarkerEditorPlugIn()
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
			this.StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label2 = new FocusLabel();
			this.label1 = new FocusLabel();
			this.SizeNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.ColorPicker = new ColorPicker();
			this.label4 = new FocusLabel();
			this.label5 = new FocusLabel();
			this.BevelStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			base.SuspendLayout();
			this.StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StyleComboBox.Location = new Point(56, 24);
			this.StyleComboBox.MaxDropDownItems = 20;
			this.StyleComboBox.Name = "StyleComboBox";
			this.StyleComboBox.PropertyName = "Style";
			this.StyleComboBox.Size = new Size(144, 21);
			this.StyleComboBox.TabIndex = 0;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.StyleComboBox;
			this.label2.Location = new Point(24, 26);
			this.label2.Name = "label2";
			this.label2.Size = new Size(32, 15);
			this.label2.Text = "Style";
			this.label2.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.SizeNumericUpDown;
			this.label1.Location = new Point(27, 65);
			this.label1.Name = "label1";
			this.label1.Size = new Size(29, 15);
			this.label1.Text = "Size";
			this.label1.LoadingEnd();
			this.SizeNumericUpDown.Location = new Point(56, 64);
			this.SizeNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			this.SizeNumericUpDown.Name = "SizeNumericUpDown";
			this.SizeNumericUpDown.PropertyName = "Size";
			this.SizeNumericUpDown.Size = new Size(56, 20);
			this.SizeNumericUpDown.TabIndex = 1;
			this.SizeNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.ColorPicker.Location = new Point(56, 104);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(144, 21);
			this.ColorPicker.TabIndex = 2;
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.ColorPicker;
			this.label4.Location = new Point(22, 107);
			this.label4.Name = "label4";
			this.label4.Size = new Size(34, 15);
			this.label4.Text = "Color";
			this.label4.LoadingEnd();
			this.label5.LoadingBegin();
			this.label5.FocusControl = this.BevelStyleComboBox;
			this.label5.Location = new Point(249, 26);
			this.label5.Name = "label5";
			this.label5.Size = new Size(63, 15);
			this.label5.Text = "Bevel Style";
			this.label5.LoadingEnd();
			this.BevelStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.BevelStyleComboBox.Location = new Point(312, 24);
			this.BevelStyleComboBox.MaxDropDownItems = 20;
			this.BevelStyleComboBox.Name = "BevelStyleComboBox";
			this.BevelStyleComboBox.PropertyName = "BevelStyle";
			this.BevelStyleComboBox.Size = new Size(144, 21);
			this.BevelStyleComboBox.TabIndex = 3;
			base.Controls.Add(this.label5);
			base.Controls.Add(this.BevelStyleComboBox);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.SizeNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.StyleComboBox);
			base.Name = "ScaleDiscreetMarkerEditorPlugIn";
			base.Size = new Size(608, 256);
			base.Title = "Markers Editor";
			base.ResumeLayout(false);
		}
	}
}
