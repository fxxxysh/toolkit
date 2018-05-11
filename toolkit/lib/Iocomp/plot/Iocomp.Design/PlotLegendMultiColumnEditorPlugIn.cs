using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotLegendMultiColumnEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private FontButton FontButton;

		private FocusLabel focusLabel11;

		private ColorPicker ForeColorPicker;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private EditBox MarginOuterTextBox;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private EditMultiLine TitleTextBox;

		private FocusLabel focusLabel15;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotLegendMultiColumnEditorPlugIn()
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
			this.FontButton = new FontButton();
			this.focusLabel11 = new FocusLabel();
			this.ForeColorPicker = new ColorPicker();
			this.ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			this.MarginOuterTextBox = new EditBox();
			this.focusLabel2 = new FocusLabel();
			this.UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.TitleTextBox = new EditMultiLine();
			this.focusLabel15 = new FocusLabel();
			this.CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			((ISupportInitialize)this.LayerNumericUpDown).BeginInit();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(288, 11);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 9;
			this.VisibleCheckBox.Text = "Visible";
			this.EnabledCheckBox.Location = new Point(288, 35);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(80, 24);
			this.EnabledCheckBox.TabIndex = 10;
			this.EnabledCheckBox.Text = "Enabled";
			this.NameTextBox.LoadingBegin();
			this.NameTextBox.Location = new Point(104, 16);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.PropertyName = "Name";
			this.NameTextBox.Size = new Size(144, 20);
			this.NameTextBox.TabIndex = 0;
			this.NameTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.NameTextBox;
			this.focusLabel1.Location = new Point(67, 18);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(37, 15);
			this.focusLabel1.Text = "Name";
			this.focusLabel1.LoadingEnd();
			this.ColorPicker.Location = new Point(104, 80);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(48, 21);
			this.ColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorPicker.TabIndex = 2;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorPicker;
			this.label8.Location = new Point(70, 83);
			this.label8.Name = "label8";
			this.label8.Size = new Size(34, 15);
			this.label8.Text = "Color";
			this.label8.LoadingEnd();
			this.FontButton.Location = new Point(176, 144);
			this.FontButton.Name = "FontButton";
			this.FontButton.PropertyName = "Font";
			this.FontButton.Size = new Size(72, 23);
			this.FontButton.TabIndex = 6;
			this.focusLabel11.LoadingBegin();
			this.focusLabel11.FocusControl = this.ForeColorPicker;
			this.focusLabel11.Location = new Point(45, 147);
			this.focusLabel11.Name = "focusLabel11";
			this.focusLabel11.Size = new Size(59, 15);
			this.focusLabel11.Text = "Fore Color";
			this.focusLabel11.LoadingEnd();
			this.ForeColorPicker.Location = new Point(104, 144);
			this.ForeColorPicker.Name = "ForeColorPicker";
			this.ForeColorPicker.PropertyName = "ForeColor";
			this.ForeColorPicker.Size = new Size(49, 21);
			this.ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ForeColorPicker.TabIndex = 5;
			this.ContextMenuEnabledCheckBox.Location = new Point(288, 59);
			this.ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			this.ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			this.ContextMenuEnabledCheckBox.Size = new Size(152, 24);
			this.ContextMenuEnabledCheckBox.TabIndex = 11;
			this.ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			this.LayerNumericUpDown.Location = new Point(192, 80);
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
			this.label1.Location = new Point(157, 81);
			this.label1.Name = "label1";
			this.label1.Size = new Size(35, 15);
			this.label1.Text = "Layer";
			this.label1.LoadingEnd();
			this.MarginOuterTextBox.LoadingBegin();
			this.MarginOuterTextBox.Location = new Point(104, 112);
			this.MarginOuterTextBox.Name = "MarginOuterTextBox";
			this.MarginOuterTextBox.PropertyName = "MarginOuter";
			this.MarginOuterTextBox.Size = new Size(88, 20);
			this.MarginOuterTextBox.TabIndex = 4;
			this.MarginOuterTextBox.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.MarginOuterTextBox;
			this.focusLabel2.Location = new Point(32, 114);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(72, 15);
			this.focusLabel2.Text = "Margin Outer";
			this.focusLabel2.LoadingEnd();
			this.UserCanEditCheckBox.Location = new Point(288, 83);
			this.UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			this.UserCanEditCheckBox.PropertyName = "UserCanEdit";
			this.UserCanEditCheckBox.Size = new Size(96, 24);
			this.UserCanEditCheckBox.TabIndex = 12;
			this.UserCanEditCheckBox.Text = "User Can Edit";
			this.TitleTextBox.EditFont = null;
			this.TitleTextBox.Location = new Point(104, 48);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.PropertyName = "TitleText";
			this.TitleTextBox.Size = new Size(144, 20);
			this.TitleTextBox.TabIndex = 1;
			this.focusLabel15.LoadingBegin();
			this.focusLabel15.FocusControl = this.TitleTextBox;
			this.focusLabel15.Location = new Point(51, 51);
			this.focusLabel15.Name = "focusLabel15";
			this.focusLabel15.Size = new Size(53, 15);
			this.focusLabel15.Text = "Title Text";
			this.focusLabel15.LoadingEnd();
			this.CanFocusCheckBox.Location = new Point(288, 107);
			this.CanFocusCheckBox.Name = "CanFocusCheckBox";
			this.CanFocusCheckBox.PropertyName = "CanFocus";
			this.CanFocusCheckBox.Size = new Size(80, 24);
			this.CanFocusCheckBox.TabIndex = 13;
			this.CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(this.CanFocusCheckBox);
			base.Controls.Add(this.TitleTextBox);
			base.Controls.Add(this.focusLabel15);
			base.Controls.Add(this.UserCanEditCheckBox);
			base.Controls.Add(this.MarginOuterTextBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.LayerNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ContextMenuEnabledCheckBox);
			base.Controls.Add(this.focusLabel11);
			base.Controls.Add(this.ForeColorPicker);
			base.Controls.Add(this.FontButton);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.NameTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotLegendMultiColumnEditorPlugIn";
			base.Size = new Size(456, 256);
			((ISupportInitialize)this.LayerNumericUpDown).EndInit();
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotLegendMultiColumnCellFormattingPlugIn(), "Cell Formatting", false);
			base.AddSubPlugIn(new PlotLegendMultiColumnItemCollectionEditorPlugIn(), "Columns", false);
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill", false);
			base.AddSubPlugIn(new PlotLayoutDockableAllEditorPlugIn(), "Dock", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotLegendMultiColumn).CellFormatting;
			base.SubPlugIns[1].Value = (base.Value as PlotLegendMultiColumn).Columns;
			base.SubPlugIns[2].Value = (base.Value as PlotLegendMultiColumn).Fill;
			base.SubPlugIns[3].Value = base.Value;
		}
	}
}
