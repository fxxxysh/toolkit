using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotMarkerEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SizeNumericUpDown;

		private EditMultiLine TextEditMultiLine;

		private FocusLabel focusLabel10;

		private FontButton FontButton;

		private FocusLabel focusLabel11;

		private ColorPicker ForeColorPicker;

		private Container components;

		public PlotMarkerEditorPlugIn()
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
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.TextEditMultiLine = new EditMultiLine();
			this.focusLabel10 = new FocusLabel();
			this.FontButton = new FontButton();
			this.focusLabel11 = new FocusLabel();
			this.ForeColorPicker = new ColorPicker();
			base.SuspendLayout();
			this.StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StyleComboBox.Location = new Point(104, 112);
			this.StyleComboBox.MaxDropDownItems = 20;
			this.StyleComboBox.Name = "StyleComboBox";
			this.StyleComboBox.PropertyName = "Style";
			this.StyleComboBox.Size = new Size(144, 21);
			this.StyleComboBox.TabIndex = 2;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.StyleComboBox;
			this.label2.Location = new Point(72, 114);
			this.label2.Name = "label2";
			this.label2.Size = new Size(32, 15);
			this.label2.Text = "Style";
			this.label2.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.SizeNumericUpDown;
			this.label1.Location = new Point(75, 81);
			this.label1.Name = "label1";
			this.label1.Size = new Size(29, 15);
			this.label1.Text = "Size";
			this.label1.LoadingEnd();
			this.SizeNumericUpDown.Location = new Point(104, 80);
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
			this.VisibleCheckBox.Location = new Point(104, 48);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.TextEditMultiLine.EditFont = null;
			this.TextEditMultiLine.Location = new Point(104, 144);
			this.TextEditMultiLine.Name = "TextEditMultiLine";
			this.TextEditMultiLine.PropertyName = "Text";
			this.TextEditMultiLine.Size = new Size(144, 20);
			this.TextEditMultiLine.TabIndex = 3;
			this.focusLabel10.LoadingBegin();
			this.focusLabel10.FocusControl = this.TextEditMultiLine;
			this.focusLabel10.Location = new Point(75, 147);
			this.focusLabel10.Name = "focusLabel10";
			this.focusLabel10.Size = new Size(29, 15);
			this.focusLabel10.Text = "Text";
			this.focusLabel10.LoadingEnd();
			this.FontButton.Location = new Point(104, 176);
			this.FontButton.Name = "FontButton";
			this.FontButton.PropertyName = "Font";
			this.FontButton.Size = new Size(72, 23);
			this.FontButton.TabIndex = 4;
			this.focusLabel11.LoadingBegin();
			this.focusLabel11.FocusControl = this.ForeColorPicker;
			this.focusLabel11.Location = new Point(181, 179);
			this.focusLabel11.Name = "focusLabel11";
			this.focusLabel11.Size = new Size(59, 15);
			this.focusLabel11.Text = "Fore Color";
			this.focusLabel11.LoadingEnd();
			this.ForeColorPicker.Location = new Point(240, 176);
			this.ForeColorPicker.Name = "ForeColorPicker";
			this.ForeColorPicker.PropertyName = "ForeColor";
			this.ForeColorPicker.Size = new Size(49, 21);
			this.ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ForeColorPicker.TabIndex = 5;
			base.Controls.Add(this.focusLabel11);
			base.Controls.Add(this.ForeColorPicker);
			base.Controls.Add(this.FontButton);
			base.Controls.Add(this.TextEditMultiLine);
			base.Controls.Add(this.focusLabel10);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.SizeNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.StyleComboBox);
			base.Name = "PlotMarkerEditorPlugIn";
			base.Size = new Size(424, 288);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotMarker).Fill;
		}
	}
}
