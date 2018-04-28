using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotTableChannelEditorPlugIn : PlugInStandard
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

		private EditBox MarginOuterTextBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private EditBox ChannelNameTextBox;

		private FocusLabel focusLabel13;

		private GroupBox RowHeightGoupBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox RowTitlesVisibleCheckBox;

		private EditBox RowOuterMarginEditBox;

		private FocusLabel focusLabel12;

		private EditBox RowHeightValueEditBox;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox RowHeightStyleComboBox;

		private FocusLabel focusLabel7;

		private GroupBox ColWidthGroupBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ColTitlesVisibleCheckBox;

		private EditBox ColOuterMarginEditBox;

		private FocusLabel focusLabel10;

		private EditBox ColWidthValueTextBox;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ColWidthStyleComboBox;

		private FocusLabel focusLabel9;

		private FocusLabel focusLabel14;

		private GroupBox DataPointGroupBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DataPointRangeStyleComboBox;

		private FocusLabel focusLabel5;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown DataPointStartIndexNumericUpDown;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown DataPointCountNumericUpDown;

		private FocusLabel focusLabel2;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel15;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotTableChannelEditorPlugIn()
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
			this.MarginOuterTextBox = new EditBox();
			this.focusLabel8 = new FocusLabel();
			this.UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ChannelNameTextBox = new EditBox();
			this.focusLabel13 = new FocusLabel();
			this.RowHeightGoupBox = new GroupBox();
			this.RowTitlesVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.RowOuterMarginEditBox = new EditBox();
			this.focusLabel12 = new FocusLabel();
			this.RowHeightValueEditBox = new EditBox();
			this.focusLabel6 = new FocusLabel();
			this.RowHeightStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel7 = new FocusLabel();
			this.ColWidthGroupBox = new GroupBox();
			this.ColTitlesVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ColOuterMarginEditBox = new EditBox();
			this.focusLabel10 = new FocusLabel();
			this.ColWidthValueTextBox = new EditBox();
			this.focusLabel4 = new FocusLabel();
			this.ColWidthStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel9 = new FocusLabel();
			this.focusLabel14 = new FocusLabel();
			this.DataPointGroupBox = new GroupBox();
			this.DataPointRangeStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel5 = new FocusLabel();
			this.DataPointStartIndexNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.focusLabel3 = new FocusLabel();
			this.DataPointCountNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.focusLabel2 = new FocusLabel();
			this.TitleTextBox = new EditMultiLine();
			this.focusLabel15 = new FocusLabel();
			this.CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.RowHeightGoupBox.SuspendLayout();
			this.ColWidthGroupBox.SuspendLayout();
			this.DataPointGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(248, 11);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 5;
			this.VisibleCheckBox.Text = "Visible";
			this.EnabledCheckBox.Location = new Point(248, 35);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(80, 24);
			this.EnabledCheckBox.TabIndex = 6;
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
			this.ContextMenuEnabledCheckBox.Size = new Size(144, 24);
			this.ContextMenuEnabledCheckBox.TabIndex = 7;
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
			this.FontButton.Location = new Point(472, 80);
			this.FontButton.Name = "FontButton";
			this.FontButton.PropertyName = "Font";
			this.FontButton.Size = new Size(72, 23);
			this.FontButton.TabIndex = 12;
			this.focusLabel11.LoadingBegin();
			this.focusLabel11.FocusControl = this.ForeColorPicker;
			this.focusLabel11.Location = new Point(413, 51);
			this.focusLabel11.Name = "focusLabel11";
			this.focusLabel11.Size = new Size(59, 15);
			this.focusLabel11.Text = "Fore Color";
			this.focusLabel11.LoadingEnd();
			this.ForeColorPicker.Location = new Point(472, 48);
			this.ForeColorPicker.Name = "ForeColorPicker";
			this.ForeColorPicker.PropertyName = "ForeColor";
			this.ForeColorPicker.Size = new Size(49, 21);
			this.ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ForeColorPicker.TabIndex = 11;
			this.MarginOuterTextBox.LoadingBegin();
			this.MarginOuterTextBox.Location = new Point(472, 16);
			this.MarginOuterTextBox.Name = "MarginOuterTextBox";
			this.MarginOuterTextBox.PropertyName = "MarginOuter";
			this.MarginOuterTextBox.Size = new Size(88, 20);
			this.MarginOuterTextBox.TabIndex = 10;
			this.MarginOuterTextBox.LoadingEnd();
			this.focusLabel8.LoadingBegin();
			this.focusLabel8.FocusControl = this.MarginOuterTextBox;
			this.focusLabel8.Location = new Point(400, 18);
			this.focusLabel8.Name = "focusLabel8";
			this.focusLabel8.Size = new Size(72, 15);
			this.focusLabel8.Text = "Margin Outer";
			this.focusLabel8.LoadingEnd();
			this.UserCanEditCheckBox.Location = new Point(248, 83);
			this.UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			this.UserCanEditCheckBox.PropertyName = "UserCanEdit";
			this.UserCanEditCheckBox.Size = new Size(96, 24);
			this.UserCanEditCheckBox.TabIndex = 8;
			this.UserCanEditCheckBox.Text = "User Can Edit";
			this.ChannelNameTextBox.LoadingBegin();
			this.ChannelNameTextBox.Location = new Point(88, 120);
			this.ChannelNameTextBox.Name = "ChannelNameTextBox";
			this.ChannelNameTextBox.PropertyName = "ChannelName";
			this.ChannelNameTextBox.Size = new Size(144, 20);
			this.ChannelNameTextBox.TabIndex = 4;
			this.ChannelNameTextBox.LoadingEnd();
			this.focusLabel13.LoadingBegin();
			this.focusLabel13.FocusControl = this.ChannelNameTextBox;
			this.focusLabel13.Location = new Point(7, 122);
			this.focusLabel13.Name = "focusLabel13";
			this.focusLabel13.Size = new Size(81, 15);
			this.focusLabel13.Text = "Channel Name";
			this.focusLabel13.LoadingEnd();
			this.RowHeightGoupBox.Controls.Add(this.RowTitlesVisibleCheckBox);
			this.RowHeightGoupBox.Controls.Add(this.RowOuterMarginEditBox);
			this.RowHeightGoupBox.Controls.Add(this.focusLabel12);
			this.RowHeightGoupBox.Controls.Add(this.RowHeightValueEditBox);
			this.RowHeightGoupBox.Controls.Add(this.focusLabel6);
			this.RowHeightGoupBox.Controls.Add(this.RowHeightStyleComboBox);
			this.RowHeightGoupBox.Controls.Add(this.focusLabel7);
			this.RowHeightGoupBox.Location = new Point(384, 152);
			this.RowHeightGoupBox.Name = "RowHeightGoupBox";
			this.RowHeightGoupBox.Size = new Size(184, 120);
			this.RowHeightGoupBox.TabIndex = 15;
			this.RowHeightGoupBox.TabStop = false;
			this.RowHeightGoupBox.Text = "Row ";
			this.RowTitlesVisibleCheckBox.Location = new Point(72, 16);
			this.RowTitlesVisibleCheckBox.Name = "RowTitlesVisibleCheckBox";
			this.RowTitlesVisibleCheckBox.PropertyName = "RowTitlesVisible";
			this.RowTitlesVisibleCheckBox.Size = new Size(92, 24);
			this.RowTitlesVisibleCheckBox.TabIndex = 0;
			this.RowTitlesVisibleCheckBox.Text = "Titles Visible";
			this.RowOuterMarginEditBox.LoadingBegin();
			this.RowOuterMarginEditBox.Location = new Point(72, 88);
			this.RowOuterMarginEditBox.Name = "RowOuterMarginEditBox";
			this.RowOuterMarginEditBox.PropertyName = "RowOuterMargin";
			this.RowOuterMarginEditBox.Size = new Size(104, 20);
			this.RowOuterMarginEditBox.TabIndex = 3;
			this.RowOuterMarginEditBox.LoadingEnd();
			this.focusLabel12.LoadingBegin();
			this.focusLabel12.FocusControl = this.RowOuterMarginEditBox;
			this.focusLabel12.Location = new Point(0, 90);
			this.focusLabel12.Name = "focusLabel12";
			this.focusLabel12.Size = new Size(72, 15);
			this.focusLabel12.Text = "Outer Margin";
			this.focusLabel12.LoadingEnd();
			this.RowHeightValueEditBox.LoadingBegin();
			this.RowHeightValueEditBox.Location = new Point(72, 64);
			this.RowHeightValueEditBox.Name = "RowHeightValueEditBox";
			this.RowHeightValueEditBox.PropertyName = "RowHeightValue";
			this.RowHeightValueEditBox.Size = new Size(104, 20);
			this.RowHeightValueEditBox.TabIndex = 2;
			this.RowHeightValueEditBox.LoadingEnd();
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.RowHeightValueEditBox;
			this.focusLabel6.Location = new Point(2, 66);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(70, 15);
			this.focusLabel6.Text = "Height Value";
			this.focusLabel6.LoadingEnd();
			this.RowHeightStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.RowHeightStyleComboBox.Location = new Point(72, 40);
			this.RowHeightStyleComboBox.MaxDropDownItems = 20;
			this.RowHeightStyleComboBox.Name = "RowHeightStyleComboBox";
			this.RowHeightStyleComboBox.PropertyName = "RowHeightStyle";
			this.RowHeightStyleComboBox.Size = new Size(104, 21);
			this.RowHeightStyleComboBox.TabIndex = 1;
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.RowHeightStyleComboBox;
			this.focusLabel7.Location = new Point(5, 42);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(67, 15);
			this.focusLabel7.Text = "Height Style";
			this.focusLabel7.LoadingEnd();
			this.ColWidthGroupBox.Controls.Add(this.ColTitlesVisibleCheckBox);
			this.ColWidthGroupBox.Controls.Add(this.ColOuterMarginEditBox);
			this.ColWidthGroupBox.Controls.Add(this.focusLabel10);
			this.ColWidthGroupBox.Controls.Add(this.ColWidthValueTextBox);
			this.ColWidthGroupBox.Controls.Add(this.focusLabel4);
			this.ColWidthGroupBox.Controls.Add(this.ColWidthStyleComboBox);
			this.ColWidthGroupBox.Controls.Add(this.focusLabel9);
			this.ColWidthGroupBox.Controls.Add(this.focusLabel14);
			this.ColWidthGroupBox.Location = new Point(192, 152);
			this.ColWidthGroupBox.Name = "ColWidthGroupBox";
			this.ColWidthGroupBox.Size = new Size(184, 120);
			this.ColWidthGroupBox.TabIndex = 14;
			this.ColWidthGroupBox.TabStop = false;
			this.ColWidthGroupBox.Text = "Col";
			this.ColTitlesVisibleCheckBox.Location = new Point(72, 16);
			this.ColTitlesVisibleCheckBox.Name = "ColTitlesVisibleCheckBox";
			this.ColTitlesVisibleCheckBox.PropertyName = "ColTitlesVisible";
			this.ColTitlesVisibleCheckBox.Size = new Size(92, 24);
			this.ColTitlesVisibleCheckBox.TabIndex = 0;
			this.ColTitlesVisibleCheckBox.Text = "Titles Visible";
			this.ColOuterMarginEditBox.LoadingBegin();
			this.ColOuterMarginEditBox.Location = new Point(72, 88);
			this.ColOuterMarginEditBox.Name = "ColOuterMarginEditBox";
			this.ColOuterMarginEditBox.PropertyName = "ColOuterMargin";
			this.ColOuterMarginEditBox.Size = new Size(104, 20);
			this.ColOuterMarginEditBox.TabIndex = 3;
			this.ColOuterMarginEditBox.LoadingEnd();
			this.focusLabel10.LoadingBegin();
			this.focusLabel10.FocusControl = this.ColOuterMarginEditBox;
			this.focusLabel10.Location = new Point(0, 90);
			this.focusLabel10.Name = "focusLabel10";
			this.focusLabel10.Size = new Size(72, 15);
			this.focusLabel10.Text = "Outer Margin";
			this.focusLabel10.LoadingEnd();
			this.ColWidthValueTextBox.LoadingBegin();
			this.ColWidthValueTextBox.Location = new Point(72, 64);
			this.ColWidthValueTextBox.Name = "ColWidthValueTextBox";
			this.ColWidthValueTextBox.PropertyName = "ColWidthValue";
			this.ColWidthValueTextBox.Size = new Size(104, 20);
			this.ColWidthValueTextBox.TabIndex = 2;
			this.ColWidthValueTextBox.LoadingEnd();
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.ColWidthValueTextBox;
			this.focusLabel4.Location = new Point(5, 66);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(67, 15);
			this.focusLabel4.Text = "Width Value";
			this.focusLabel4.LoadingEnd();
			this.ColWidthStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ColWidthStyleComboBox.Location = new Point(72, 40);
			this.ColWidthStyleComboBox.MaxDropDownItems = 20;
			this.ColWidthStyleComboBox.Name = "ColWidthStyleComboBox";
			this.ColWidthStyleComboBox.PropertyName = "ColWidthStyle";
			this.ColWidthStyleComboBox.Size = new Size(104, 21);
			this.ColWidthStyleComboBox.TabIndex = 1;
			this.focusLabel9.LoadingBegin();
			this.focusLabel9.FocusControl = this.ColWidthStyleComboBox;
			this.focusLabel9.Location = new Point(9, 42);
			this.focusLabel9.Name = "focusLabel9";
			this.focusLabel9.Size = new Size(63, 15);
			this.focusLabel9.Text = "Width Style";
			this.focusLabel9.LoadingEnd();
			this.focusLabel14.LoadingBegin();
			this.focusLabel14.FocusControl = this.ColWidthValueTextBox;
			this.focusLabel14.Location = new Point(38, 66);
			this.focusLabel14.Name = "focusLabel14";
			this.focusLabel14.Size = new Size(34, 14);
			this.focusLabel14.Text = "Value";
			this.focusLabel14.LoadingEnd();
			this.DataPointGroupBox.Controls.Add(this.DataPointRangeStyleComboBox);
			this.DataPointGroupBox.Controls.Add(this.focusLabel5);
			this.DataPointGroupBox.Controls.Add(this.DataPointStartIndexNumericUpDown);
			this.DataPointGroupBox.Controls.Add(this.focusLabel3);
			this.DataPointGroupBox.Controls.Add(this.DataPointCountNumericUpDown);
			this.DataPointGroupBox.Controls.Add(this.focusLabel2);
			this.DataPointGroupBox.Location = new Point(8, 152);
			this.DataPointGroupBox.Name = "DataPointGroupBox";
			this.DataPointGroupBox.Size = new Size(176, 120);
			this.DataPointGroupBox.TabIndex = 13;
			this.DataPointGroupBox.TabStop = false;
			this.DataPointGroupBox.Text = "Data Point";
			this.DataPointRangeStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.DataPointRangeStyleComboBox.Location = new Point(72, 46);
			this.DataPointRangeStyleComboBox.MaxDropDownItems = 20;
			this.DataPointRangeStyleComboBox.Name = "DataPointRangeStyleComboBox";
			this.DataPointRangeStyleComboBox.PropertyName = "DataPointRangeStyle";
			this.DataPointRangeStyleComboBox.Size = new Size(96, 21);
			this.DataPointRangeStyleComboBox.TabIndex = 1;
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.DataPointRangeStyleComboBox;
			this.focusLabel5.Location = new Point(5, 48);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(67, 15);
			this.focusLabel5.Text = "Range Style";
			this.focusLabel5.LoadingEnd();
			this.DataPointStartIndexNumericUpDown.Location = new Point(72, 70);
			this.DataPointStartIndexNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			this.DataPointStartIndexNumericUpDown.Name = "DataPointStartIndexNumericUpDown";
			this.DataPointStartIndexNumericUpDown.PropertyName = "DataPointStartIndex";
			this.DataPointStartIndexNumericUpDown.Size = new Size(72, 20);
			this.DataPointStartIndexNumericUpDown.TabIndex = 2;
			this.DataPointStartIndexNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.DataPointStartIndexNumericUpDown;
			this.focusLabel3.Location = new Point(11, 71);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(61, 15);
			this.focusLabel3.Text = "Start Index";
			this.focusLabel3.LoadingEnd();
			this.DataPointCountNumericUpDown.Location = new Point(72, 22);
			this.DataPointCountNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			this.DataPointCountNumericUpDown.Name = "DataPointCountNumericUpDown";
			this.DataPointCountNumericUpDown.PropertyName = "DataPointCount";
			this.DataPointCountNumericUpDown.Size = new Size(56, 20);
			this.DataPointCountNumericUpDown.TabIndex = 0;
			this.DataPointCountNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.DataPointCountNumericUpDown;
			this.focusLabel2.Location = new Point(35, 23);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(37, 15);
			this.focusLabel2.Text = "Count";
			this.focusLabel2.LoadingEnd();
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
			this.CanFocusCheckBox.TabIndex = 9;
			this.CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(this.CanFocusCheckBox);
			base.Controls.Add(this.TitleTextBox);
			base.Controls.Add(this.focusLabel15);
			base.Controls.Add(this.DataPointGroupBox);
			base.Controls.Add(this.RowHeightGoupBox);
			base.Controls.Add(this.ColWidthGroupBox);
			base.Controls.Add(this.ChannelNameTextBox);
			base.Controls.Add(this.focusLabel13);
			base.Controls.Add(this.UserCanEditCheckBox);
			base.Controls.Add(this.MarginOuterTextBox);
			base.Controls.Add(this.focusLabel8);
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
			base.Name = "PlotTableChannelEditorPlugIn";
			base.Size = new Size(632, 288);
			this.RowHeightGoupBox.ResumeLayout(false);
			this.ColWidthGroupBox.ResumeLayout(false);
			this.DataPointGroupBox.ResumeLayout(false);
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
			base.SubPlugIns[0].Value = (base.Value as PlotTableChannel).CellsFormatting;
			base.SubPlugIns[1].Value = (base.Value as PlotTableChannel).GridOutline;
			base.SubPlugIns[2].Value = (base.Value as PlotTableChannel).Fill;
			base.SubPlugIns[3].Value = base.Value;
		}
	}
}
