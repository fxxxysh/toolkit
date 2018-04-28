using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotLegendMultiColumnItemPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private FocusLabel label8;

		private EditBox WidthTextBox;

		private ColorPicker DataForeColorPicker;

		private FocusLabel label11;

		private ColorPicker TitleForeColorPicker;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.ComboBox WidthStyleComboBox;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DataTypeComboBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private EditMultiLine TitleTextEditMultiLine;

		private Container components;

		public PlotLegendMultiColumnItemPlugIn()
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

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Title Fill", false);
			base.AddSubPlugIn(new TextLayoutHorizontalEditorPlugIn(), "Title Layout", false);
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Data Fill", false);
			base.AddSubPlugIn(new TextLayoutHorizontalEditorPlugIn(), "Data Layout", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotLegendMultiColumnItem).TitleFill;
			base.SubPlugIns[1].Value = (base.Value as PlotLegendMultiColumnItem).TitleLayout;
			base.SubPlugIns[2].Value = (base.Value as PlotLegendMultiColumnItem).DataFill;
			base.SubPlugIns[3].Value = (base.Value as PlotLegendMultiColumnItem).DataLayout;
		}

		private void InitializeComponent()
		{
			this.label2 = new FocusLabel();
			this.WidthTextBox = new EditBox();
			this.DataForeColorPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.TitleTextEditMultiLine = new EditMultiLine();
			this.label11 = new FocusLabel();
			this.TitleForeColorPicker = new ColorPicker();
			this.focusLabel1 = new FocusLabel();
			this.WidthStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel3 = new FocusLabel();
			this.DataTypeComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel2 = new FocusLabel();
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.WidthTextBox;
			this.label2.Location = new Point(93, 130);
			this.label2.Name = "label2";
			this.label2.Size = new Size(35, 15);
			this.label2.Text = "Width";
			this.label2.LoadingEnd();
			this.WidthTextBox.LoadingBegin();
			this.WidthTextBox.Location = new Point(128, 128);
			this.WidthTextBox.Name = "WidthTextBox";
			this.WidthTextBox.PropertyName = "Width";
			this.WidthTextBox.Size = new Size(48, 20);
			this.WidthTextBox.TabIndex = 4;
			this.WidthTextBox.LoadingEnd();
			this.DataForeColorPicker.Location = new Point(128, 184);
			this.DataForeColorPicker.Name = "DataForeColorPicker";
			this.DataForeColorPicker.PropertyName = "DataForeColor";
			this.DataForeColorPicker.Size = new Size(48, 21);
			this.DataForeColorPicker.Style = ColorPickerStyle.ColorBox;
			this.DataForeColorPicker.TabIndex = 6;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.DataForeColorPicker;
			this.label8.Location = new Point(43, 187);
			this.label8.Name = "label8";
			this.label8.Size = new Size(85, 15);
			this.label8.Text = "Data Fore Color";
			this.label8.LoadingEnd();
			this.TitleTextEditMultiLine.EditFont = null;
			this.TitleTextEditMultiLine.Location = new Point(128, 40);
			this.TitleTextEditMultiLine.Name = "TitleTextEditMultiLine";
			this.TitleTextEditMultiLine.PropertyName = "TitleText";
			this.TitleTextEditMultiLine.Size = new Size(142, 20);
			this.TitleTextEditMultiLine.TabIndex = 0;
			this.label11.LoadingBegin();
			this.label11.FocusControl = this.TitleTextEditMultiLine;
			this.label11.Location = new Point(76, 43);
			this.label11.Name = "label11";
			this.label11.Size = new Size(52, 15);
			this.label11.Text = "Title Text";
			this.label11.LoadingEnd();
			this.TitleForeColorPicker.Location = new Point(128, 160);
			this.TitleForeColorPicker.Name = "TitleForeColorPicker";
			this.TitleForeColorPicker.PropertyName = "TitleForeColor";
			this.TitleForeColorPicker.Size = new Size(48, 21);
			this.TitleForeColorPicker.Style = ColorPickerStyle.ColorBox;
			this.TitleForeColorPicker.TabIndex = 5;
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.TitleForeColorPicker;
			this.focusLabel1.Location = new Point(46, 163);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(82, 15);
			this.focusLabel1.Text = "Title Fore Color";
			this.focusLabel1.LoadingEnd();
			this.WidthStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.WidthStyleComboBox.Location = new Point(128, 104);
			this.WidthStyleComboBox.MaxDropDownItems = 20;
			this.WidthStyleComboBox.Name = "WidthStyleComboBox";
			this.WidthStyleComboBox.PropertyName = "WidthStyle";
			this.WidthStyleComboBox.Size = new Size(136, 21);
			this.WidthStyleComboBox.TabIndex = 3;
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.WidthStyleComboBox;
			this.focusLabel3.Location = new Point(66, 106);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(62, 15);
			this.focusLabel3.Text = "Width Style";
			this.focusLabel3.LoadingEnd();
			this.DataTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.DataTypeComboBox.Location = new Point(128, 72);
			this.DataTypeComboBox.MaxDropDownItems = 20;
			this.DataTypeComboBox.Name = "DataTypeComboBox";
			this.DataTypeComboBox.PropertyName = "DataType";
			this.DataTypeComboBox.Size = new Size(142, 21);
			this.DataTypeComboBox.TabIndex = 2;
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.DataTypeComboBox;
			this.focusLabel2.Location = new Point(71, 74);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(57, 15);
			this.focusLabel2.Text = "Data Type";
			this.focusLabel2.LoadingEnd();
			this.VisibleCheckBox.Location = new Point(288, 40);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "TitleVisible";
			this.VisibleCheckBox.Size = new Size(144, 24);
			this.VisibleCheckBox.TabIndex = 1;
			this.VisibleCheckBox.Text = "Title Visible";
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.DataTypeComboBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.WidthStyleComboBox);
			base.Controls.Add(this.focusLabel3);
			base.Controls.Add(this.TitleForeColorPicker);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.TitleTextEditMultiLine);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.DataForeColorPicker);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.WidthTextBox);
			base.Controls.Add(this.label2);
			base.Name = "PlotLegendMultiColumnItemPlugIn";
			base.Size = new Size(560, 264);
			base.ResumeLayout(false);
		}
	}
}
