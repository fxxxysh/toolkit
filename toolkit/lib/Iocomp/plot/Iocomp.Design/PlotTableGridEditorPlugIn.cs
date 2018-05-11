using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotTableGridEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private FontButton FontButton;

		private FocusLabel focusLabel11;

		private ColorPicker ForeColorPicker;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ColWidthStyleComboBox;

		private FocusLabel focusLabel5;

		private FocusLabel focusLabel6;

		private FocusLabel focusLabel7;

		private EditBox MarginOuterTextBox;

		private FocusLabel focusLabel8;

		private GroupBox DataGroupBox;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown DataColCountUpDown;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown DataRowCountUpDown;

		private GroupBox ColWidthGroupBox;

		private EditBox ColWidthValueTextBox;

		private GroupBox RowHeightGoupBox;

		private EditBox RowHeightValueEditBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox RowHeightStyleComboBox;

		private FocusLabel focusLabel9;

		private FocusLabel focusLabel10;

		private FocusLabel focusLabel12;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ColTitlesVisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox RowTitlesVisibleCheckBox;

		private EditBox ColOuterMarginEditBox;

		private EditBox RowOuterMarginEditBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel15;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotTableGridEditorPlugIn()
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
			this.EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.NameTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.ColorPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			this.FontButton = new FontButton();
			this.focusLabel11 = new FocusLabel();
			this.ForeColorPicker = new ColorPicker();
			this.ColWidthGroupBox = new GroupBox();
			this.ColTitlesVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ColOuterMarginEditBox = new EditBox();
			this.focusLabel10 = new FocusLabel();
			this.ColWidthValueTextBox = new EditBox();
			this.focusLabel4 = new FocusLabel();
			this.ColWidthStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel5 = new FocusLabel();
			this.focusLabel9 = new FocusLabel();
			this.RowHeightGoupBox = new GroupBox();
			this.RowTitlesVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.RowOuterMarginEditBox = new EditBox();
			this.focusLabel12 = new FocusLabel();
			this.RowHeightValueEditBox = new EditBox();
			this.focusLabel6 = new FocusLabel();
			this.RowHeightStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel7 = new FocusLabel();
			this.MarginOuterTextBox = new EditBox();
			this.focusLabel8 = new FocusLabel();
			this.DataGroupBox = new GroupBox();
			this.focusLabel2 = new FocusLabel();
			this.DataRowCountUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.focusLabel3 = new FocusLabel();
			this.DataColCountUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.TitleTextBox = new EditMultiLine();
			this.focusLabel15 = new FocusLabel();
			this.CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ColWidthGroupBox.SuspendLayout();
			this.RowHeightGoupBox.SuspendLayout();
			this.DataGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(248, 11);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 4;
			this.VisibleCheckBox.Text = "Visible";
			this.EnabledCheckBox.Location = new Point(248, 35);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(80, 24);
			this.EnabledCheckBox.TabIndex = 5;
			this.EnabledCheckBox.Text = "Enabled";
			this.NameTextBox.LoadingBegin();
			this.NameTextBox.Location = new Point(88, 16);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.PropertyName = "Name";
			this.NameTextBox.Size = new Size(144, 20);
			this.NameTextBox.TabIndex = 0;
			this.NameTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.NameTextBox;
			this.focusLabel1.Location = new Point(51, 18);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(37, 15);
			this.focusLabel1.Text = "Name";
			this.focusLabel1.LoadingEnd();
			this.ColorPicker.Location = new Point(88, 80);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(48, 21);
			this.ColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorPicker.TabIndex = 2;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorPicker;
			this.label8.Location = new Point(54, 83);
			this.label8.Name = "label8";
			this.label8.Size = new Size(34, 15);
			this.label8.Text = "Color";
			this.label8.LoadingEnd();
			this.ContextMenuEnabledCheckBox.Location = new Point(248, 59);
			this.ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			this.ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			this.ContextMenuEnabledCheckBox.Size = new Size(152, 24);
			this.ContextMenuEnabledCheckBox.TabIndex = 6;
			this.ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			this.LayerNumericUpDown.Location = new Point(176, 80);
			this.LayerNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			this.LayerNumericUpDown.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			this.LayerNumericUpDown.Name = "LayerNumericUpDown";
			this.LayerNumericUpDown.PropertyName = "Layer";
			this.LayerNumericUpDown.Size = new Size(56, 20);
			this.LayerNumericUpDown.TabIndex = 3;
			this.LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.LayerNumericUpDown;
			this.label1.Location = new Point(141, 81);
			this.label1.Name = "label1";
			this.label1.Size = new Size(35, 15);
			this.label1.Text = "Layer";
			this.label1.LoadingEnd();
			this.FontButton.Location = new Point(456, 80);
			this.FontButton.Name = "FontButton";
			this.FontButton.PropertyName = "Font";
			this.FontButton.Size = new Size(72, 23);
			this.FontButton.TabIndex = 11;
			this.focusLabel11.LoadingBegin();
			this.focusLabel11.FocusControl = this.ForeColorPicker;
			this.focusLabel11.Location = new Point(397, 51);
			this.focusLabel11.Name = "focusLabel11";
			this.focusLabel11.Size = new Size(59, 15);
			this.focusLabel11.Text = "Fore Color";
			this.focusLabel11.LoadingEnd();
			this.ForeColorPicker.Location = new Point(456, 48);
			this.ForeColorPicker.Name = "ForeColorPicker";
			this.ForeColorPicker.PropertyName = "ForeColor";
			this.ForeColorPicker.Size = new Size(49, 21);
			this.ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ForeColorPicker.TabIndex = 10;
			this.ColWidthGroupBox.Controls.Add(this.ColTitlesVisibleCheckBox);
			this.ColWidthGroupBox.Controls.Add(this.ColOuterMarginEditBox);
			this.ColWidthGroupBox.Controls.Add(this.focusLabel10);
			this.ColWidthGroupBox.Controls.Add(this.ColWidthValueTextBox);
			this.ColWidthGroupBox.Controls.Add(this.focusLabel4);
			this.ColWidthGroupBox.Controls.Add(this.ColWidthStyleComboBox);
			this.ColWidthGroupBox.Controls.Add(this.focusLabel5);
			this.ColWidthGroupBox.Controls.Add(this.focusLabel9);
			this.ColWidthGroupBox.Location = new Point(144, 152);
			this.ColWidthGroupBox.Name = "ColWidthGroupBox";
			this.ColWidthGroupBox.Size = new Size(200, 120);
			this.ColWidthGroupBox.TabIndex = 13;
			this.ColWidthGroupBox.TabStop = false;
			this.ColWidthGroupBox.Text = "Col";
			this.ColTitlesVisibleCheckBox.Location = new Point(80, 16);
			this.ColTitlesVisibleCheckBox.Name = "ColTitlesVisibleCheckBox";
			this.ColTitlesVisibleCheckBox.PropertyName = "ColTitlesVisible";
			this.ColTitlesVisibleCheckBox.Size = new Size(112, 24);
			this.ColTitlesVisibleCheckBox.TabIndex = 0;
			this.ColTitlesVisibleCheckBox.Text = "Col Titles Visible";
			this.ColOuterMarginEditBox.LoadingBegin();
			this.ColOuterMarginEditBox.Location = new Point(80, 88);
			this.ColOuterMarginEditBox.Name = "ColOuterMarginEditBox";
			this.ColOuterMarginEditBox.PropertyName = "ColOuterMargin";
			this.ColOuterMarginEditBox.Size = new Size(104, 20);
			this.ColOuterMarginEditBox.TabIndex = 3;
			this.ColOuterMarginEditBox.LoadingEnd();
			this.focusLabel10.LoadingBegin();
			this.focusLabel10.FocusControl = this.ColOuterMarginEditBox;
			this.focusLabel10.Location = new Point(8, 90);
			this.focusLabel10.Name = "focusLabel10";
			this.focusLabel10.Size = new Size(72, 15);
			this.focusLabel10.Text = "Outer Margin";
			this.focusLabel10.LoadingEnd();
			this.ColWidthValueTextBox.LoadingBegin();
			this.ColWidthValueTextBox.Location = new Point(80, 64);
			this.ColWidthValueTextBox.Name = "ColWidthValueTextBox";
			this.ColWidthValueTextBox.PropertyName = "ColWidthValue";
			this.ColWidthValueTextBox.Size = new Size(104, 20);
			this.ColWidthValueTextBox.TabIndex = 2;
			this.ColWidthValueTextBox.LoadingEnd();
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.ColWidthValueTextBox;
			this.focusLabel4.Location = new Point(13, 66);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(67, 15);
			this.focusLabel4.Text = "Width Value";
			this.focusLabel4.LoadingEnd();
			this.ColWidthStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ColWidthStyleComboBox.Location = new Point(80, 40);
			this.ColWidthStyleComboBox.MaxDropDownItems = 20;
			this.ColWidthStyleComboBox.Name = "ColWidthStyleComboBox";
			this.ColWidthStyleComboBox.PropertyName = "ColWidthStyle";
			this.ColWidthStyleComboBox.Size = new Size(104, 21);
			this.ColWidthStyleComboBox.TabIndex = 1;
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.ColWidthStyleComboBox;
			this.focusLabel5.Location = new Point(17, 42);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(63, 15);
			this.focusLabel5.Text = "Width Style";
			this.focusLabel5.LoadingEnd();
			this.focusLabel9.LoadingBegin();
			this.focusLabel9.FocusControl = this.ColWidthValueTextBox;
			this.focusLabel9.Location = new Point(46, 66);
			this.focusLabel9.Name = "focusLabel9";
			this.focusLabel9.Size = new Size(34, 14);
			this.focusLabel9.Text = "Value";
			this.focusLabel9.LoadingEnd();
			this.RowHeightGoupBox.Controls.Add(this.RowTitlesVisibleCheckBox);
			this.RowHeightGoupBox.Controls.Add(this.RowOuterMarginEditBox);
			this.RowHeightGoupBox.Controls.Add(this.focusLabel12);
			this.RowHeightGoupBox.Controls.Add(this.RowHeightValueEditBox);
			this.RowHeightGoupBox.Controls.Add(this.focusLabel6);
			this.RowHeightGoupBox.Controls.Add(this.RowHeightStyleComboBox);
			this.RowHeightGoupBox.Controls.Add(this.focusLabel7);
			this.RowHeightGoupBox.Location = new Point(352, 152);
			this.RowHeightGoupBox.Name = "RowHeightGoupBox";
			this.RowHeightGoupBox.Size = new Size(200, 120);
			this.RowHeightGoupBox.TabIndex = 14;
			this.RowHeightGoupBox.TabStop = false;
			this.RowHeightGoupBox.Text = "Row ";
			this.RowTitlesVisibleCheckBox.Location = new Point(80, 16);
			this.RowTitlesVisibleCheckBox.Name = "RowTitlesVisibleCheckBox";
			this.RowTitlesVisibleCheckBox.PropertyName = "RowTitlesVisible";
			this.RowTitlesVisibleCheckBox.Size = new Size(113, 24);
			this.RowTitlesVisibleCheckBox.TabIndex = 0;
			this.RowTitlesVisibleCheckBox.Text = "Row Titles Visible";
			this.RowOuterMarginEditBox.LoadingBegin();
			this.RowOuterMarginEditBox.Location = new Point(80, 88);
			this.RowOuterMarginEditBox.Name = "RowOuterMarginEditBox";
			this.RowOuterMarginEditBox.PropertyName = "RowOuterMargin";
			this.RowOuterMarginEditBox.Size = new Size(104, 20);
			this.RowOuterMarginEditBox.TabIndex = 3;
			this.RowOuterMarginEditBox.LoadingEnd();
			this.focusLabel12.LoadingBegin();
			this.focusLabel12.FocusControl = this.RowOuterMarginEditBox;
			this.focusLabel12.Location = new Point(8, 90);
			this.focusLabel12.Name = "focusLabel12";
			this.focusLabel12.Size = new Size(72, 15);
			this.focusLabel12.Text = "Outer Margin";
			this.focusLabel12.LoadingEnd();
			this.RowHeightValueEditBox.LoadingBegin();
			this.RowHeightValueEditBox.Location = new Point(80, 64);
			this.RowHeightValueEditBox.Name = "RowHeightValueEditBox";
			this.RowHeightValueEditBox.PropertyName = "RowHeightValue";
			this.RowHeightValueEditBox.Size = new Size(104, 20);
			this.RowHeightValueEditBox.TabIndex = 2;
			this.RowHeightValueEditBox.LoadingEnd();
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.RowHeightValueEditBox;
			this.focusLabel6.Location = new Point(10, 66);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(70, 15);
			this.focusLabel6.Text = "Height Value";
			this.focusLabel6.LoadingEnd();
			this.RowHeightStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.RowHeightStyleComboBox.Location = new Point(80, 40);
			this.RowHeightStyleComboBox.MaxDropDownItems = 20;
			this.RowHeightStyleComboBox.Name = "RowHeightStyleComboBox";
			this.RowHeightStyleComboBox.PropertyName = "RowHeightStyle";
			this.RowHeightStyleComboBox.Size = new Size(104, 21);
			this.RowHeightStyleComboBox.TabIndex = 1;
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.RowHeightStyleComboBox;
			this.focusLabel7.Location = new Point(13, 42);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(67, 15);
			this.focusLabel7.Text = "Height Style";
			this.focusLabel7.LoadingEnd();
			this.MarginOuterTextBox.LoadingBegin();
			this.MarginOuterTextBox.Location = new Point(456, 16);
			this.MarginOuterTextBox.Name = "MarginOuterTextBox";
			this.MarginOuterTextBox.PropertyName = "MarginOuter";
			this.MarginOuterTextBox.Size = new Size(88, 20);
			this.MarginOuterTextBox.TabIndex = 9;
			this.MarginOuterTextBox.LoadingEnd();
			this.focusLabel8.LoadingBegin();
			this.focusLabel8.FocusControl = this.MarginOuterTextBox;
			this.focusLabel8.Location = new Point(384, 18);
			this.focusLabel8.Name = "focusLabel8";
			this.focusLabel8.Size = new Size(72, 15);
			this.focusLabel8.Text = "Margin Outer";
			this.focusLabel8.LoadingEnd();
			this.DataGroupBox.Controls.Add(this.focusLabel2);
			this.DataGroupBox.Controls.Add(this.DataRowCountUpDown);
			this.DataGroupBox.Controls.Add(this.focusLabel3);
			this.DataGroupBox.Controls.Add(this.DataColCountUpDown);
			this.DataGroupBox.Location = new Point(8, 152);
			this.DataGroupBox.Name = "DataGroupBox";
			this.DataGroupBox.Size = new Size(128, 120);
			this.DataGroupBox.TabIndex = 12;
			this.DataGroupBox.TabStop = false;
			this.DataGroupBox.Text = "Data";
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.DataRowCountUpDown;
			this.focusLabel2.Location = new Point(10, 65);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(62, 15);
			this.focusLabel2.Text = "Row Count";
			this.focusLabel2.LoadingEnd();
			this.DataRowCountUpDown.Location = new Point(72, 64);
			this.DataRowCountUpDown.Name = "DataRowCountUpDown";
			this.DataRowCountUpDown.PropertyName = "DataRowCount";
			this.DataRowCountUpDown.Size = new Size(48, 20);
			this.DataRowCountUpDown.TabIndex = 1;
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.DataColCountUpDown;
			this.focusLabel3.Location = new Point(16, 41);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(56, 15);
			this.focusLabel3.Text = "Col Count";
			this.focusLabel3.LoadingEnd();
			this.DataColCountUpDown.Location = new Point(72, 40);
			this.DataColCountUpDown.Name = "DataColCountUpDown";
			this.DataColCountUpDown.PropertyName = "DataColCount";
			this.DataColCountUpDown.Size = new Size(48, 20);
			this.DataColCountUpDown.TabIndex = 0;
			this.UserCanEditCheckBox.Location = new Point(248, 83);
			this.UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			this.UserCanEditCheckBox.PropertyName = "UserCanEdit";
			this.UserCanEditCheckBox.Size = new Size(96, 24);
			this.UserCanEditCheckBox.TabIndex = 7;
			this.UserCanEditCheckBox.Text = "User Can Edit";
			this.TitleTextBox.EditFont = null;
			this.TitleTextBox.Location = new Point(88, 48);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.PropertyName = "TitleText";
			this.TitleTextBox.Size = new Size(144, 20);
			this.TitleTextBox.TabIndex = 1;
			this.focusLabel15.LoadingBegin();
			this.focusLabel15.FocusControl = this.TitleTextBox;
			this.focusLabel15.Location = new Point(35, 51);
			this.focusLabel15.Name = "focusLabel15";
			this.focusLabel15.Size = new Size(53, 15);
			this.focusLabel15.Text = "Title Text";
			this.focusLabel15.LoadingEnd();
			this.CanFocusCheckBox.Location = new Point(248, 107);
			this.CanFocusCheckBox.Name = "CanFocusCheckBox";
			this.CanFocusCheckBox.PropertyName = "CanFocus";
			this.CanFocusCheckBox.Size = new Size(80, 24);
			this.CanFocusCheckBox.TabIndex = 8;
			this.CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(this.CanFocusCheckBox);
			base.Controls.Add(this.TitleTextBox);
			base.Controls.Add(this.focusLabel15);
			base.Controls.Add(this.UserCanEditCheckBox);
			base.Controls.Add(this.DataGroupBox);
			base.Controls.Add(this.MarginOuterTextBox);
			base.Controls.Add(this.focusLabel8);
			base.Controls.Add(this.RowHeightGoupBox);
			base.Controls.Add(this.ColWidthGroupBox);
			base.Controls.Add(this.FontButton);
			base.Controls.Add(this.focusLabel11);
			base.Controls.Add(this.ForeColorPicker);
			base.Controls.Add(this.LayerNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ContextMenuEnabledCheckBox);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.NameTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotTableGridEditorPlugIn";
			base.Size = new Size(624, 288);
			this.ColWidthGroupBox.ResumeLayout(false);
			this.RowHeightGoupBox.ResumeLayout(false);
			this.DataGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotTableCellsFormattingEditorPlugIn(), "Cell Formatting", false);
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Grid Outline", false);
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill", false);
			base.AddSubPlugIn(new PlotLayoutDockableAllEditorPlugIn(), "Dock", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotTableGrid).CellsFormatting;
			base.SubPlugIns[1].Value = (base.Value as PlotTableGrid).GridOutline;
			base.SubPlugIns[2].Value = (base.Value as PlotTableGrid).Fill;
			base.SubPlugIns[3].Value = base.Value;
		}
	}
}
