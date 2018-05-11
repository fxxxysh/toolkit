using Iocomp.Design.Plugin.EditorControls;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotEditorPlugIn : PlugInStandard
	{
		private FocusLabel label4;

		private ColorPicker ForeColorPicker;

		private FocusLabel label3;

		private ColorPicker BackColorPicker;

		private Iocomp.Design.Plugin.EditorControls.CheckBox AutoSizeCheckBox;

		private FontButton FontButton;

		private Iocomp.Design.Plugin.EditorControls.ComboBox RotationComboBox;

		private FocusLabel focusLabel1;

		private ColorPicker DefaultGridLineColorPicker;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenusEnabledCheckBox;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox FileDeliminatorComboBox;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.ComboBox CopyToClipboardFormatComboBox;

		private FocusLabel focusLabel4;

		private EditBox UpdateFrameRateTextBox;

		private FocusLabel focusLabel5;

		private FocusLabel RotationLabel;

		private FocusLabel label2;

		private EditBox DefaultSaveImagePathTextBox;

		private Button DefaultSaveImagePathEditButton;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox XValueTextDateTimeFormatComboBox;

		private Container components;

		public PlotEditorPlugIn()
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
			this.ForeColorPicker = new ColorPicker();
			this.label3 = new FocusLabel();
			this.BackColorPicker = new ColorPicker();
			this.AutoSizeCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.FontButton = new FontButton();
			this.RotationLabel = new FocusLabel();
			this.RotationComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel1 = new FocusLabel();
			this.DefaultGridLineColorPicker = new ColorPicker();
			this.ContextMenusEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.focusLabel2 = new FocusLabel();
			this.FileDeliminatorComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel3 = new FocusLabel();
			this.CopyToClipboardFormatComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel4 = new FocusLabel();
			this.UpdateFrameRateTextBox = new EditBox();
			this.focusLabel5 = new FocusLabel();
			this.DefaultSaveImagePathTextBox = new EditBox();
			this.label2 = new FocusLabel();
			this.DefaultSaveImagePathEditButton = new Button();
			this.focusLabel6 = new FocusLabel();
			this.XValueTextDateTimeFormatComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			base.SuspendLayout();
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.ForeColorPicker;
			this.label4.Location = new Point(69, 123);
			this.label4.Name = "label4";
			this.label4.Size = new Size(59, 15);
			this.label4.Text = "Fore Color";
			this.label4.LoadingEnd();
			this.ForeColorPicker.Location = new Point(128, 120);
			this.ForeColorPicker.Name = "ForeColorPicker";
			this.ForeColorPicker.PropertyName = "ForeColor";
			this.ForeColorPicker.Size = new Size(136, 21);
			this.ForeColorPicker.TabIndex = 5;
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.BackColorPicker;
			this.label3.Location = new Point(67, 147);
			this.label3.Name = "label3";
			this.label3.Size = new Size(61, 15);
			this.label3.Text = "Back Color";
			this.label3.LoadingEnd();
			this.BackColorPicker.Location = new Point(128, 144);
			this.BackColorPicker.Name = "BackColorPicker";
			this.BackColorPicker.PropertyName = "BackColor";
			this.BackColorPicker.Size = new Size(136, 21);
			this.BackColorPicker.TabIndex = 7;
			this.AutoSizeCheckBox.Location = new Point(280, 176);
			this.AutoSizeCheckBox.Name = "AutoSizeCheckBox";
			this.AutoSizeCheckBox.PropertyName = "AutoSize";
			this.AutoSizeCheckBox.TabIndex = 9;
			this.AutoSizeCheckBox.Text = "Auto Size";
			this.FontButton.Location = new Point(280, 120);
			this.FontButton.Name = "FontButton";
			this.FontButton.PropertyName = "Font";
			this.FontButton.TabIndex = 6;
			this.RotationLabel.LoadingBegin();
			this.RotationLabel.FocusControl = this.RotationComboBox;
			this.RotationLabel.Location = new Point(79, 178);
			this.RotationLabel.Name = "RotationLabel";
			this.RotationLabel.Size = new Size(49, 15);
			this.RotationLabel.Text = "Rotation";
			this.RotationLabel.LoadingEnd();
			this.RotationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.RotationComboBox.Location = new Point(128, 176);
			this.RotationComboBox.Name = "RotationComboBox";
			this.RotationComboBox.PropertyName = "Rotation";
			this.RotationComboBox.Size = new Size(136, 21);
			this.RotationComboBox.TabIndex = 8;
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.DefaultGridLineColorPicker;
			this.focusLabel1.Location = new Point(8, 91);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(120, 15);
			this.focusLabel1.Text = "Default Grid-Line Color";
			this.focusLabel1.LoadingEnd();
			this.DefaultGridLineColorPicker.Location = new Point(128, 88);
			this.DefaultGridLineColorPicker.Name = "DefaultGridLineColorPicker";
			this.DefaultGridLineColorPicker.PropertyName = "DefaultGridLineColor";
			this.DefaultGridLineColorPicker.Size = new Size(136, 21);
			this.DefaultGridLineColorPicker.TabIndex = 4;
			this.ContextMenusEnabledCheckBox.Location = new Point(64, 16);
			this.ContextMenusEnabledCheckBox.Name = "ContextMenusEnabledCheckBox";
			this.ContextMenusEnabledCheckBox.PropertyName = "ContextMenusEnabled";
			this.ContextMenusEnabledCheckBox.Size = new Size(168, 24);
			this.ContextMenusEnabledCheckBox.TabIndex = 0;
			this.ContextMenusEnabledCheckBox.Text = "Context Menus Enabled";
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.FileDeliminatorComboBox;
			this.focusLabel2.Location = new Point(412, 18);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(84, 15);
			this.focusLabel2.Text = "File Deliminator";
			this.focusLabel2.LoadingEnd();
			this.FileDeliminatorComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.FileDeliminatorComboBox.Location = new Point(496, 16);
			this.FileDeliminatorComboBox.Name = "FileDeliminatorComboBox";
			this.FileDeliminatorComboBox.PropertyName = "FileDeliminator";
			this.FileDeliminatorComboBox.Size = new Size(136, 21);
			this.FileDeliminatorComboBox.TabIndex = 1;
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.CopyToClipboardFormatComboBox;
			this.focusLabel3.Location = new Point(359, 50);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(137, 15);
			this.focusLabel3.Text = "Copy To Clipboard Format";
			this.focusLabel3.LoadingEnd();
			this.CopyToClipboardFormatComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.CopyToClipboardFormatComboBox.Location = new Point(496, 48);
			this.CopyToClipboardFormatComboBox.Name = "CopyToClipboardFormatComboBox";
			this.CopyToClipboardFormatComboBox.PropertyName = "CopyToClipboardFormat";
			this.CopyToClipboardFormatComboBox.Size = new Size(136, 21);
			this.CopyToClipboardFormatComboBox.TabIndex = 2;
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.UpdateFrameRateTextBox;
			this.focusLabel4.FocusControlAlignment = AlignmentQuadSide.Right;
			this.focusLabel4.Location = new Point(168, 210);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(60, 15);
			this.focusLabel4.Text = "(Max = 50)";
			this.focusLabel4.LoadingEnd();
			this.UpdateFrameRateTextBox.LoadingBegin();
			this.UpdateFrameRateTextBox.Location = new Point(128, 208);
			this.UpdateFrameRateTextBox.Name = "UpdateFrameRateTextBox";
			this.UpdateFrameRateTextBox.PropertyName = "UpdateFrameRate";
			this.UpdateFrameRateTextBox.Size = new Size(40, 20);
			this.UpdateFrameRateTextBox.TabIndex = 10;
			this.UpdateFrameRateTextBox.LoadingEnd();
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.UpdateFrameRateTextBox;
			this.focusLabel5.Location = new Point(24, 210);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(104, 15);
			this.focusLabel5.Text = "Update Frame Rate";
			this.focusLabel5.LoadingEnd();
			this.DefaultSaveImagePathTextBox.LoadingBegin();
			this.DefaultSaveImagePathTextBox.Location = new Point(128, 248);
			this.DefaultSaveImagePathTextBox.Name = "DefaultSaveImagePathTextBox";
			this.DefaultSaveImagePathTextBox.PropertyName = "DefaultSaveImagePath";
			this.DefaultSaveImagePathTextBox.Size = new Size(384, 20);
			this.DefaultSaveImagePathTextBox.TabIndex = 11;
			this.DefaultSaveImagePathTextBox.LoadingEnd();
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.DefaultSaveImagePathTextBox;
			this.label2.Location = new Point(0, 250);
			this.label2.Name = "label2";
			this.label2.Size = new Size(128, 15);
			this.label2.Text = "Default Save Image Path";
			this.label2.LoadingEnd();
			this.DefaultSaveImagePathEditButton.Location = new Point(512, 248);
			this.DefaultSaveImagePathEditButton.Name = "DefaultSaveImagePathEditButton";
			this.DefaultSaveImagePathEditButton.Size = new Size(24, 21);
			this.DefaultSaveImagePathEditButton.TabIndex = 12;
			this.DefaultSaveImagePathEditButton.Text = "...";
			this.DefaultSaveImagePathEditButton.Click += this.DefaultSaveImagePathEditButton_Click;
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.XValueTextDateTimeFormatComboBox;
			this.focusLabel6.Location = new Point(335, 74);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(161, 15);
			this.focusLabel6.Text = "X-Value Text Date/Time Format";
			this.focusLabel6.LoadingEnd();
			this.XValueTextDateTimeFormatComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.XValueTextDateTimeFormatComboBox.Location = new Point(496, 72);
			this.XValueTextDateTimeFormatComboBox.Name = "XValueTextDateTimeFormatComboBox";
			this.XValueTextDateTimeFormatComboBox.PropertyName = "XValueTextDateTimeFormat";
			this.XValueTextDateTimeFormatComboBox.Size = new Size(136, 21);
			this.XValueTextDateTimeFormatComboBox.TabIndex = 3;
			base.Controls.Add(this.focusLabel6);
			base.Controls.Add(this.XValueTextDateTimeFormatComboBox);
			base.Controls.Add(this.DefaultSaveImagePathEditButton);
			base.Controls.Add(this.DefaultSaveImagePathTextBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.focusLabel4);
			base.Controls.Add(this.UpdateFrameRateTextBox);
			base.Controls.Add(this.focusLabel5);
			base.Controls.Add(this.focusLabel3);
			base.Controls.Add(this.CopyToClipboardFormatComboBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.FileDeliminatorComboBox);
			base.Controls.Add(this.ContextMenusEnabledCheckBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.DefaultGridLineColorPicker);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.ForeColorPicker);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.BackColorPicker);
			base.Controls.Add(this.AutoSizeCheckBox);
			base.Controls.Add(this.FontButton);
			base.Controls.Add(this.RotationLabel);
			base.Controls.Add(this.RotationComboBox);
			base.Name = "PlotEditorPlugIn";
			base.Size = new Size(752, 296);
			base.Title = "Plot Editor";
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotPrintAdapterEditorPlugIn(), "Print", true);
			base.AddSubPlugIn(new PlotLogFileAdapterEditorPlugIn(), "Log File", true);
			base.AddSubPlugIn(new PlotFileIOEditorPlugIn(), "File I/O", true);
			base.AddSubPlugIn(new PlotLayoutViewerEditorPlugIn(), "Layout", false);
			base.AddSubPlugIn(new PlotChannelBaseCollectionEditorPlugIn(), "Channels", false);
			base.AddSubPlugIn(new PlotXAxisCollectionEditorPlugIn(), "X-Axes", false);
			base.AddSubPlugIn(new PlotYAxisCollectionEditorPlugIn(), "Y-Axes", false);
			base.AddSubPlugIn(new PlotDataViewCollectionEditorPlugIn(), "Data-Views", false);
			base.AddSubPlugIn(new PlotLimitBaseCollectionEditorPlugIn(), "Limits", false);
			base.AddSubPlugIn(new PlotDataCursorBaseCollectionEditorPlugIn(), "Data-Cursors", false);
			base.AddSubPlugIn(new PlotLabelBaseCollectionEditorPlugIn(), "Labels", false);
			base.AddSubPlugIn(new PlotLegendBaseCollectionEditorPlugIn(), "Legends", false);
			base.AddSubPlugIn(new PlotTableBaseCollectionEditorPlugIn(), "Tables", false);
			base.AddSubPlugIn(new PlotAnnotationBaseCollectionEditorPlugIn(), "Annotations", false);
			base.AddSubPlugIn(new PlotBrushEditorPlugIn(), "Background", true);
			base.AddSubPlugIn(new BorderControlEditorPlugIn(), "Border", true);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as Plot).PrintAdapter;
			base.SubPlugIns[1].Value = (base.Value as Plot).LogFile;
			base.SubPlugIns[2].Value = base.Value;
			base.SubPlugIns[3].Value = base.Value;
			base.SubPlugIns[4].Value = (base.Value as Plot).Channels;
			base.SubPlugIns[5].Value = (base.Value as Plot).XAxes;
			base.SubPlugIns[6].Value = (base.Value as Plot).YAxes;
			base.SubPlugIns[7].Value = (base.Value as Plot).DataViews;
			base.SubPlugIns[8].Value = (base.Value as Plot).Limits;
			base.SubPlugIns[9].Value = (base.Value as Plot).DataCursors;
			base.SubPlugIns[10].Value = (base.Value as Plot).Labels;
			base.SubPlugIns[11].Value = (base.Value as Plot).Legends;
			base.SubPlugIns[12].Value = (base.Value as Plot).Tables;
			base.SubPlugIns[13].Value = (base.Value as Plot).Annotations;
			base.SubPlugIns[14].Value = (base.Value as Plot).Background;
			base.SubPlugIns[15].Value = (base.Value as Plot).Border;
		}

		private void DefaultSaveImagePathEditButton_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.SelectedPath = this.DefaultSaveImagePathTextBox.AsString;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				this.DefaultSaveImagePathTextBox.AsString = folderBrowserDialog.SelectedPath;
				this.DefaultSaveImagePathTextBox.ForceUpdate();
			}
		}
	}
}
