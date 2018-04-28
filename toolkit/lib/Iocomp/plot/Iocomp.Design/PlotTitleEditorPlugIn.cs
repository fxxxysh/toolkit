using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotTitleEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private FontButton FontButton;

		private FocusLabel focusLabel11;

		private ColorPicker ForeColorPicker;

		private EditMultiLine TextEditMultiLine;

		private FocusLabel focusLabel10;

		private Iocomp.Design.Plugin.EditorControls.ComboBox TextRotationComboBox;

		private FocusLabel label11;

		private EditBox MarginOuterTextBox;

		private FocusLabel focusLabel2;

		private EditBox MarginSpacingTextBox;

		private FocusLabel focusLabel3;

		private Container components;

		public PlotTitleEditorPlugIn()
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
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ColorPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.FontButton = new FontButton();
			this.focusLabel11 = new FocusLabel();
			this.ForeColorPicker = new ColorPicker();
			this.TextEditMultiLine = new EditMultiLine();
			this.focusLabel10 = new FocusLabel();
			this.TextRotationComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label11 = new FocusLabel();
			this.MarginOuterTextBox = new EditBox();
			this.focusLabel2 = new FocusLabel();
			this.MarginSpacingTextBox = new EditBox();
			this.focusLabel3 = new FocusLabel();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(112, 8);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.ColorPicker.Location = new Point(112, 72);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(48, 21);
			this.ColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorPicker.TabIndex = 2;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorPicker;
			this.label8.Location = new Point(78, 75);
			this.label8.Name = "label8";
			this.label8.Size = new Size(34, 15);
			this.label8.Text = "Color";
			this.label8.LoadingEnd();
			this.FontButton.Location = new Point(304, 72);
			this.FontButton.Name = "FontButton";
			this.FontButton.PropertyName = "Font";
			this.FontButton.Size = new Size(72, 23);
			this.FontButton.TabIndex = 4;
			this.focusLabel11.LoadingBegin();
			this.focusLabel11.FocusControl = this.ForeColorPicker;
			this.focusLabel11.Location = new Point(181, 75);
			this.focusLabel11.Name = "focusLabel11";
			this.focusLabel11.Size = new Size(59, 15);
			this.focusLabel11.Text = "Fore Color";
			this.focusLabel11.LoadingEnd();
			this.ForeColorPicker.Location = new Point(240, 72);
			this.ForeColorPicker.Name = "ForeColorPicker";
			this.ForeColorPicker.PropertyName = "ForeColor";
			this.ForeColorPicker.Size = new Size(49, 21);
			this.ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ForeColorPicker.TabIndex = 3;
			this.TextEditMultiLine.EditFont = null;
			this.TextEditMultiLine.Location = new Point(112, 40);
			this.TextEditMultiLine.Name = "TextEditMultiLine";
			this.TextEditMultiLine.PropertyName = "Text";
			this.TextEditMultiLine.Size = new Size(264, 20);
			this.TextEditMultiLine.TabIndex = 1;
			this.focusLabel10.LoadingBegin();
			this.focusLabel10.FocusControl = this.TextEditMultiLine;
			this.focusLabel10.Location = new Point(83, 43);
			this.focusLabel10.Name = "focusLabel10";
			this.focusLabel10.Size = new Size(29, 15);
			this.focusLabel10.Text = "Text";
			this.focusLabel10.LoadingEnd();
			this.TextRotationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.TextRotationComboBox.Location = new Point(112, 160);
			this.TextRotationComboBox.Name = "TextRotationComboBox";
			this.TextRotationComboBox.PropertyName = "TextRotation";
			this.TextRotationComboBox.Size = new Size(121, 21);
			this.TextRotationComboBox.TabIndex = 7;
			this.label11.LoadingBegin();
			this.label11.FocusControl = this.TextRotationComboBox;
			this.label11.Location = new Point(63, 162);
			this.label11.Name = "label11";
			this.label11.Size = new Size(49, 15);
			this.label11.Text = "Rotation";
			this.label11.LoadingEnd();
			this.MarginOuterTextBox.LoadingBegin();
			this.MarginOuterTextBox.Location = new Point(112, 128);
			this.MarginOuterTextBox.Name = "MarginOuterTextBox";
			this.MarginOuterTextBox.PropertyName = "MarginOuter";
			this.MarginOuterTextBox.Size = new Size(88, 20);
			this.MarginOuterTextBox.TabIndex = 6;
			this.MarginOuterTextBox.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.MarginOuterTextBox;
			this.focusLabel2.Location = new Point(40, 130);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(72, 15);
			this.focusLabel2.Text = "Margin Outer";
			this.focusLabel2.LoadingEnd();
			this.MarginSpacingTextBox.LoadingBegin();
			this.MarginSpacingTextBox.Location = new Point(112, 104);
			this.MarginSpacingTextBox.Name = "MarginSpacingTextBox";
			this.MarginSpacingTextBox.PropertyName = "MarginSpacing";
			this.MarginSpacingTextBox.Size = new Size(88, 20);
			this.MarginSpacingTextBox.TabIndex = 5;
			this.MarginSpacingTextBox.LoadingEnd();
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.MarginSpacingTextBox;
			this.focusLabel3.Location = new Point(28, 106);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(84, 15);
			this.focusLabel3.Text = "Margin Spacing";
			this.focusLabel3.LoadingEnd();
			base.Controls.Add(this.MarginSpacingTextBox);
			base.Controls.Add(this.focusLabel3);
			base.Controls.Add(this.MarginOuterTextBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.TextRotationComboBox);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.FontButton);
			base.Controls.Add(this.focusLabel11);
			base.Controls.Add(this.ForeColorPicker);
			base.Controls.Add(this.TextEditMultiLine);
			base.Controls.Add(this.focusLabel10);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.VisibleCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotTitleEditorPlugIn";
			base.Size = new Size(504, 240);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new TextLayoutFullEditorPlugin(), "Text Layout", false);
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotTitle).TextLayout;
			base.SubPlugIns[1].Value = (base.Value as PlotTitle).Fill;
		}
	}
}
