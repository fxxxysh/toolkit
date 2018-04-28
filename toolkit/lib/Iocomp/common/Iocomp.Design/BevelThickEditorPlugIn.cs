using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class BevelThickEditorPlugIn : PlugInStandard
	{
		private FocusLabel label3;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown ThicknessNumericUpDown;

		private FocusLabel label4;

		private EditBox ActualThicknessTextBox;

		private ColorPicker ColorPicker;

		private Container components;

		public BevelThickEditorPlugIn()
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
			this.label3 = new FocusLabel();
			this.ActualThicknessTextBox = new EditBox();
			this.StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label2 = new FocusLabel();
			this.label1 = new FocusLabel();
			this.ThicknessNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.ColorPicker = new ColorPicker();
			this.label4 = new FocusLabel();
			base.SuspendLayout();
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.ActualThicknessTextBox;
			this.label3.Location = new Point(13, 82);
			this.label3.Name = "label3";
			this.label3.Size = new Size(91, 15);
			this.label3.Text = "Actual Thickness";
			this.label3.LoadingEnd();
			this.ActualThicknessTextBox.LoadingBegin();
			this.ActualThicknessTextBox.Location = new Point(104, 80);
			this.ActualThicknessTextBox.Name = "ActualThicknessTextBox";
			this.ActualThicknessTextBox.PropertyName = "ActualThickness";
			this.ActualThicknessTextBox.ReadOnly = true;
			this.ActualThicknessTextBox.Size = new Size(40, 20);
			this.ActualThicknessTextBox.TabIndex = 2;
			this.ActualThicknessTextBox.TextAlign = HorizontalAlignment.Center;
			this.ActualThicknessTextBox.LoadingEnd();
			this.StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StyleComboBox.Location = new Point(104, 32);
			this.StyleComboBox.MaxDropDownItems = 20;
			this.StyleComboBox.Name = "StyleComboBox";
			this.StyleComboBox.PropertyName = "Style";
			this.StyleComboBox.Size = new Size(144, 21);
			this.StyleComboBox.TabIndex = 0;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.StyleComboBox;
			this.label2.Location = new Point(72, 34);
			this.label2.Name = "label2";
			this.label2.Size = new Size(32, 15);
			this.label2.Text = "Style";
			this.label2.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.ThicknessNumericUpDown;
			this.label1.Location = new Point(47, 57);
			this.label1.Name = "label1";
			this.label1.Size = new Size(57, 15);
			this.label1.Text = "Thickness";
			this.label1.LoadingEnd();
			this.ThicknessNumericUpDown.Location = new Point(104, 56);
			this.ThicknessNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			this.ThicknessNumericUpDown.Name = "ThicknessNumericUpDown";
			this.ThicknessNumericUpDown.PropertyName = "Thickness";
			this.ThicknessNumericUpDown.Size = new Size(56, 20);
			this.ThicknessNumericUpDown.TabIndex = 1;
			this.ThicknessNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.ColorPicker.Location = new Point(104, 112);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(144, 21);
			this.ColorPicker.TabIndex = 3;
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.ColorPicker;
			this.label4.Location = new Point(70, 115);
			this.label4.Name = "label4";
			this.label4.Size = new Size(34, 15);
			this.label4.Text = "Color";
			this.label4.LoadingEnd();
			base.Controls.Add(this.ActualThicknessTextBox);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.ThicknessNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.StyleComboBox);
			base.Controls.Add(this.label3);
			base.Name = "BevelThickEditorPlugIn";
			base.Size = new Size(424, 288);
			base.Title = "Bevel Editor";
			base.ResumeLayout(false);
		}
	}
}
