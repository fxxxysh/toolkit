using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotAxisEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private EditBox MaxTextBox;

		private FocusLabel label2;

		private EditBox SpanTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ReverseCheckBox;

		private EditBox MinTextBox;

		private FocusLabel label3;

		private FocusLabel focusLabel2;

		private DoubleEditButton MinDoubleEditButton;

		private DoubleEditButton MaxDoubleEditButton;

		private DoubleEditButton SpanDoubleEditButton;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private EditBox CursorScalerEditBox;

		private FocusLabel focusLabel3;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel4;

		private FocusLabel focusLabel5;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ScaleTypeComboBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ControlKeyToggleEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox MasterUICheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ClipToMinMaxCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox MasterUISlaveCheckBox;

		private Container components;

		public PlotAxisEditorPlugIn()
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
			this.ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			this.MaxTextBox = new EditBox();
			this.label2 = new FocusLabel();
			this.SpanTextBox = new EditBox();
			this.ReverseCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.MinTextBox = new EditBox();
			this.label3 = new FocusLabel();
			this.focusLabel2 = new FocusLabel();
			this.MinDoubleEditButton = new DoubleEditButton();
			this.MaxDoubleEditButton = new DoubleEditButton();
			this.SpanDoubleEditButton = new DoubleEditButton();
			this.ColorPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.CursorScalerEditBox = new EditBox();
			this.focusLabel3 = new FocusLabel();
			this.TitleTextBox = new EditMultiLine();
			this.focusLabel4 = new FocusLabel();
			this.focusLabel5 = new FocusLabel();
			this.ScaleTypeComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.ControlKeyToggleEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.MasterUICheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ClipToMinMaxCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.MasterUISlaveCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			((ISupportInitialize)this.LayerNumericUpDown).BeginInit();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(288, 3);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 13;
			this.VisibleCheckBox.Text = "Visible";
			this.EnabledCheckBox.Location = new Point(288, 27);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(80, 24);
			this.EnabledCheckBox.TabIndex = 14;
			this.EnabledCheckBox.Text = "Enabled";
			this.NameTextBox.LoadingBegin();
			this.NameTextBox.Location = new Point(104, 8);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.PropertyName = "Name";
			this.NameTextBox.Size = new Size(144, 20);
			this.NameTextBox.TabIndex = 0;
			this.NameTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.NameTextBox;
			this.focusLabel1.Location = new Point(67, 10);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(37, 15);
			this.focusLabel1.Text = "Name";
			this.focusLabel1.LoadingEnd();
			this.ContextMenuEnabledCheckBox.Location = new Point(288, 51);
			this.ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			this.ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			this.ContextMenuEnabledCheckBox.Size = new Size(152, 24);
			this.ContextMenuEnabledCheckBox.TabIndex = 15;
			this.ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			this.LayerNumericUpDown.Location = new Point(192, 64);
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
			this.label1.Location = new Point(157, 65);
			this.label1.Name = "label1";
			this.label1.Size = new Size(35, 15);
			this.label1.Text = "Layer";
			this.label1.LoadingEnd();
			this.MaxTextBox.LoadingBegin();
			this.MaxTextBox.Location = new Point(104, 128);
			this.MaxTextBox.Name = "MaxTextBox";
			this.MaxTextBox.PropertyName = "Max";
			this.MaxTextBox.ReadOnly = true;
			this.MaxTextBox.Size = new Size(144, 20);
			this.MaxTextBox.TabIndex = 6;
			this.MaxTextBox.TextAlign = HorizontalAlignment.Center;
			this.MaxTextBox.LoadingEnd();
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.SpanTextBox;
			this.label2.Location = new Point(71, 154);
			this.label2.Name = "label2";
			this.label2.Size = new Size(33, 15);
			this.label2.Text = "Span";
			this.label2.LoadingEnd();
			this.SpanTextBox.LoadingBegin();
			this.SpanTextBox.Location = new Point(104, 152);
			this.SpanTextBox.Name = "SpanTextBox";
			this.SpanTextBox.PropertyName = "Span";
			this.SpanTextBox.Size = new Size(144, 20);
			this.SpanTextBox.TabIndex = 8;
			this.SpanTextBox.TextAlign = HorizontalAlignment.Center;
			this.SpanTextBox.LoadingEnd();
			this.ReverseCheckBox.Location = new Point(216, 184);
			this.ReverseCheckBox.Name = "ReverseCheckBox";
			this.ReverseCheckBox.PropertyName = "Reverse";
			this.ReverseCheckBox.Size = new Size(72, 24);
			this.ReverseCheckBox.TabIndex = 11;
			this.ReverseCheckBox.Text = "Reverse";
			this.MinTextBox.LoadingBegin();
			this.MinTextBox.Location = new Point(104, 104);
			this.MinTextBox.Name = "MinTextBox";
			this.MinTextBox.PropertyName = "Min";
			this.MinTextBox.Size = new Size(144, 20);
			this.MinTextBox.TabIndex = 4;
			this.MinTextBox.TextAlign = HorizontalAlignment.Center;
			this.MinTextBox.LoadingEnd();
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.MaxTextBox;
			this.label3.Location = new Point(76, 130);
			this.label3.Name = "label3";
			this.label3.Size = new Size(28, 15);
			this.label3.Text = "Max";
			this.label3.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.MinTextBox;
			this.focusLabel2.Location = new Point(79, 106);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(25, 15);
			this.focusLabel2.Text = "Min";
			this.focusLabel2.LoadingEnd();
			this.MinDoubleEditButton.EditBox = this.MinTextBox;
			this.MinDoubleEditButton.Location = new Point(248, 102);
			this.MinDoubleEditButton.Name = "MinDoubleEditButton";
			this.MinDoubleEditButton.TabIndex = 5;
			this.MaxDoubleEditButton.EditBox = this.MaxTextBox;
			this.MaxDoubleEditButton.Location = new Point(248, 126);
			this.MaxDoubleEditButton.Name = "MaxDoubleEditButton";
			this.MaxDoubleEditButton.TabIndex = 7;
			this.SpanDoubleEditButton.EditBox = this.SpanTextBox;
			this.SpanDoubleEditButton.Location = new Point(248, 150);
			this.SpanDoubleEditButton.Name = "SpanDoubleEditButton";
			this.SpanDoubleEditButton.TabIndex = 9;
			this.ColorPicker.Location = new Point(104, 64);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(48, 21);
			this.ColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorPicker.TabIndex = 2;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorPicker;
			this.label8.Location = new Point(70, 67);
			this.label8.Name = "label8";
			this.label8.Size = new Size(34, 15);
			this.label8.Text = "Color";
			this.label8.LoadingEnd();
			this.UserCanEditCheckBox.Location = new Point(288, 75);
			this.UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			this.UserCanEditCheckBox.PropertyName = "UserCanEdit";
			this.UserCanEditCheckBox.Size = new Size(96, 24);
			this.UserCanEditCheckBox.TabIndex = 16;
			this.UserCanEditCheckBox.Text = "User Can Edit";
			this.CursorScalerEditBox.LoadingBegin();
			this.CursorScalerEditBox.Location = new Point(104, 224);
			this.CursorScalerEditBox.Name = "CursorScalerEditBox";
			this.CursorScalerEditBox.PropertyName = "CursorScaler";
			this.CursorScalerEditBox.Size = new Size(144, 20);
			this.CursorScalerEditBox.TabIndex = 12;
			this.CursorScalerEditBox.LoadingEnd();
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.CursorScalerEditBox;
			this.focusLabel3.Location = new Point(29, 226);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(75, 15);
			this.focusLabel3.Text = "Cursor Scaler";
			this.focusLabel3.LoadingEnd();
			this.TitleTextBox.EditFont = null;
			this.TitleTextBox.Location = new Point(104, 32);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.PropertyName = "TitleText";
			this.TitleTextBox.Size = new Size(144, 20);
			this.TitleTextBox.TabIndex = 1;
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.TitleTextBox;
			this.focusLabel4.Location = new Point(51, 35);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(53, 15);
			this.focusLabel4.Text = "Title Text";
			this.focusLabel4.LoadingEnd();
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.ScaleTypeComboBox;
			this.focusLabel5.Location = new Point(42, 186);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(62, 15);
			this.focusLabel5.Text = "Scale Type";
			this.focusLabel5.LoadingEnd();
			this.ScaleTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ScaleTypeComboBox.Location = new Point(104, 184);
			this.ScaleTypeComboBox.Name = "ScaleTypeComboBox";
			this.ScaleTypeComboBox.PropertyName = "ScaleType";
			this.ScaleTypeComboBox.Size = new Size(104, 21);
			this.ScaleTypeComboBox.TabIndex = 10;
			this.ControlKeyToggleEnabledCheckBox.Location = new Point(288, 123);
			this.ControlKeyToggleEnabledCheckBox.Name = "ControlKeyToggleEnabledCheckBox";
			this.ControlKeyToggleEnabledCheckBox.PropertyName = "ControlKeyToggleEnabled";
			this.ControlKeyToggleEnabledCheckBox.Size = new Size(208, 24);
			this.ControlKeyToggleEnabledCheckBox.TabIndex = 18;
			this.ControlKeyToggleEnabledCheckBox.Text = "Control-Key Toggle Enabled";
			this.CanFocusCheckBox.Location = new Point(288, 99);
			this.CanFocusCheckBox.Name = "CanFocusCheckBox";
			this.CanFocusCheckBox.PropertyName = "CanFocus";
			this.CanFocusCheckBox.Size = new Size(144, 24);
			this.CanFocusCheckBox.TabIndex = 17;
			this.CanFocusCheckBox.Text = "Can Focus";
			this.MasterUICheckBox.Location = new Point(288, 147);
			this.MasterUICheckBox.Name = "MasterUICheckBox";
			this.MasterUICheckBox.PropertyName = "MasterUI";
			this.MasterUICheckBox.Size = new Size(208, 24);
			this.MasterUICheckBox.TabIndex = 19;
			this.MasterUICheckBox.Text = "Master UI";
			this.ClipToMinMaxCheckBox.Location = new Point(288, 195);
			this.ClipToMinMaxCheckBox.Name = "ClipToMinMaxCheckBox";
			this.ClipToMinMaxCheckBox.PropertyName = "ClipToMinMax";
			this.ClipToMinMaxCheckBox.Size = new Size(208, 24);
			this.ClipToMinMaxCheckBox.TabIndex = 21;
			this.ClipToMinMaxCheckBox.Text = "Clip To Min-Max";
			this.MasterUISlaveCheckBox.Location = new Point(288, 171);
			this.MasterUISlaveCheckBox.Name = "MasterUISlaveCheckBox";
			this.MasterUISlaveCheckBox.PropertyName = "MasterUISlave";
			this.MasterUISlaveCheckBox.Size = new Size(208, 24);
			this.MasterUISlaveCheckBox.TabIndex = 20;
			this.MasterUISlaveCheckBox.Text = "Master UI Slave";
			base.Controls.Add(this.MasterUISlaveCheckBox);
			base.Controls.Add(this.ClipToMinMaxCheckBox);
			base.Controls.Add(this.MasterUICheckBox);
			base.Controls.Add(this.CanFocusCheckBox);
			base.Controls.Add(this.ControlKeyToggleEnabledCheckBox);
			base.Controls.Add(this.focusLabel5);
			base.Controls.Add(this.ScaleTypeComboBox);
			base.Controls.Add(this.TitleTextBox);
			base.Controls.Add(this.focusLabel4);
			base.Controls.Add(this.CursorScalerEditBox);
			base.Controls.Add(this.focusLabel3);
			base.Controls.Add(this.UserCanEditCheckBox);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.SpanDoubleEditButton);
			base.Controls.Add(this.MaxDoubleEditButton);
			base.Controls.Add(this.MinDoubleEditButton);
			base.Controls.Add(this.MaxTextBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.SpanTextBox);
			base.Controls.Add(this.ReverseCheckBox);
			base.Controls.Add(this.MinTextBox);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.LayerNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ContextMenuEnabledCheckBox);
			base.Controls.Add(this.NameTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotAxisEditorPlugIn";
			base.Size = new Size(568, 272);
			base.Tag = "";
			base.Title = "Plot Axis Editor";
			((ISupportInitialize)this.LayerNumericUpDown).EndInit();
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotTitleEditorPlugIn(), "Title", false);
			base.AddSubPlugIn(new ScaleDisplayLinearEditorPlugIn(), "Scale Display", false);
			base.AddSubPlugIn(new ScaleRangeLinearEditorPlugIn(), "Scale Range", false);
			base.AddSubPlugIn(new PlotAxisGridLinesEditorPlugIn(), "Grid-Lines", false);
			base.AddSubPlugIn(new PlotAxisTrackingEditorPlugIn(), "Tracking", false);
			base.AddSubPlugIn(new PlotLayoutAxisEditorPlugIn(), "Dock", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotAxis).Title;
			base.SubPlugIns[1].Value = (base.Value as PlotAxis).ScaleDisplay;
			base.SubPlugIns[2].Value = (base.Value as PlotAxis).ScaleRange;
			base.SubPlugIns[3].Value = (base.Value as PlotAxis).GridLines;
			base.SubPlugIns[4].Value = (base.Value as PlotAxis).Tracking;
			base.SubPlugIns[5].Value = base.Value;
		}
	}
}
