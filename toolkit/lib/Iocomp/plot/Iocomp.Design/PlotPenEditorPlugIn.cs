using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotPenEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private FocusLabel label1;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private EditBox ThicknessTextBox;

		private Container components;

		public PlotPenEditorPlugIn()
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
			this.ThicknessTextBox = new EditBox();
			this.ColorPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			this.StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StyleComboBox.Location = new Point(104, 112);
			this.StyleComboBox.MaxDropDownItems = 20;
			this.StyleComboBox.Name = "StyleComboBox";
			this.StyleComboBox.PropertyName = "Style";
			this.StyleComboBox.Size = new Size(144, 21);
			this.StyleComboBox.TabIndex = 3;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.StyleComboBox;
			this.label2.Location = new Point(72, 114);
			this.label2.Name = "label2";
			this.label2.Size = new Size(32, 15);
			this.label2.Text = "Style";
			this.label2.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.ThicknessTextBox;
			this.label1.Location = new Point(47, 82);
			this.label1.Name = "label1";
			this.label1.Size = new Size(57, 15);
			this.label1.Text = "Thickness";
			this.label1.LoadingEnd();
			this.ThicknessTextBox.LoadingBegin();
			this.ThicknessTextBox.Location = new Point(104, 80);
			this.ThicknessTextBox.Name = "ThicknessTextBox";
			this.ThicknessTextBox.PropertyName = "Thickness";
			this.ThicknessTextBox.Size = new Size(64, 20);
			this.ThicknessTextBox.TabIndex = 2;
			this.ThicknessTextBox.LoadingEnd();
			this.ColorPicker.Location = new Point(104, 48);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(48, 21);
			this.ColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorPicker.TabIndex = 1;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorPicker;
			this.label8.Location = new Point(70, 51);
			this.label8.Name = "label8";
			this.label8.Size = new Size(34, 15);
			this.label8.Text = "Color";
			this.label8.LoadingEnd();
			this.VisibleCheckBox.Location = new Point(104, 16);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			base.Controls.Add(this.ThicknessTextBox);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.StyleComboBox);
			base.Name = "PlotPenEditorPlugIn";
			base.Size = new Size(424, 288);
			base.ResumeLayout(false);
		}
	}
}
