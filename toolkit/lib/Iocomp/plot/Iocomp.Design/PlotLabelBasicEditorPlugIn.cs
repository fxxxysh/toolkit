using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotLabelBasicEditorPlugIn : PlugInStandard
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

		private EditMultiLine TextEditMultiLine;

		private FocusLabel focusLabel10;

		private Iocomp.Design.Plugin.EditorControls.ComboBox TextRotationComboBox;

		private FocusLabel label11;

		private EditBox MarginOuterTextBox;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown ImageIndexUpDown;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ImageTransparentCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotLabelBasicEditorPlugIn()
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
			this.TextEditMultiLine = new EditMultiLine();
			this.focusLabel10 = new FocusLabel();
			this.TextRotationComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label11 = new FocusLabel();
			this.MarginOuterTextBox = new EditBox();
			this.focusLabel2 = new FocusLabel();
			this.ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			this.UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ImageIndexUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.focusLabel3 = new FocusLabel();
			this.ImageTransparentCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(344, 4);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 10;
			this.VisibleCheckBox.Text = "Visible";
			this.EnabledCheckBox.Location = new Point(344, 28);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(80, 24);
			this.EnabledCheckBox.TabIndex = 11;
			this.EnabledCheckBox.Text = "Enabled";
			this.NameTextBox.LoadingBegin();
			this.NameTextBox.Location = new Point(112, 8);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.PropertyName = "Name";
			this.NameTextBox.Size = new Size(144, 20);
			this.NameTextBox.TabIndex = 0;
			this.NameTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.NameTextBox;
			this.focusLabel1.Location = new Point(75, 10);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(37, 15);
			this.focusLabel1.Text = "Name";
			this.focusLabel1.LoadingEnd();
			this.ColorPicker.Location = new Point(112, 112);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(48, 21);
			this.ColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorPicker.TabIndex = 4;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorPicker;
			this.label8.Location = new Point(78, 115);
			this.label8.Name = "label8";
			this.label8.Size = new Size(34, 15);
			this.label8.Text = "Color";
			this.label8.LoadingEnd();
			this.FontButton.Location = new Point(176, 208);
			this.FontButton.Name = "FontButton";
			this.FontButton.PropertyName = "Font";
			this.FontButton.Size = new Size(72, 23);
			this.FontButton.TabIndex = 9;
			this.focusLabel11.LoadingBegin();
			this.focusLabel11.FocusControl = this.ForeColorPicker;
			this.focusLabel11.Location = new Point(53, 211);
			this.focusLabel11.Name = "focusLabel11";
			this.focusLabel11.Size = new Size(59, 15);
			this.focusLabel11.Text = "Fore Color";
			this.focusLabel11.LoadingEnd();
			this.ForeColorPicker.Location = new Point(112, 208);
			this.ForeColorPicker.Name = "ForeColorPicker";
			this.ForeColorPicker.PropertyName = "ForeColor";
			this.ForeColorPicker.Size = new Size(49, 21);
			this.ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ForeColorPicker.TabIndex = 8;
			this.TextEditMultiLine.EditFont = null;
			this.TextEditMultiLine.Location = new Point(112, 40);
			this.TextEditMultiLine.Name = "TextEditMultiLine";
			this.TextEditMultiLine.PropertyName = "Text";
			this.TextEditMultiLine.Size = new Size(208, 20);
			this.TextEditMultiLine.TabIndex = 1;
			this.focusLabel10.LoadingBegin();
			this.focusLabel10.FocusControl = this.TextEditMultiLine;
			this.focusLabel10.Location = new Point(83, 43);
			this.focusLabel10.Name = "focusLabel10";
			this.focusLabel10.Size = new Size(29, 15);
			this.focusLabel10.Text = "Text";
			this.focusLabel10.LoadingEnd();
			this.TextRotationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.TextRotationComboBox.Location = new Point(112, 176);
			this.TextRotationComboBox.Name = "TextRotationComboBox";
			this.TextRotationComboBox.PropertyName = "TextRotation";
			this.TextRotationComboBox.Size = new Size(121, 21);
			this.TextRotationComboBox.TabIndex = 7;
			this.label11.LoadingBegin();
			this.label11.FocusControl = this.TextRotationComboBox;
			this.label11.Location = new Point(63, 178);
			this.label11.Name = "label11";
			this.label11.Size = new Size(49, 15);
			this.label11.Text = "Rotation";
			this.label11.LoadingEnd();
			this.MarginOuterTextBox.LoadingBegin();
			this.MarginOuterTextBox.Location = new Point(112, 144);
			this.MarginOuterTextBox.Name = "MarginOuterTextBox";
			this.MarginOuterTextBox.PropertyName = "MarginOuter";
			this.MarginOuterTextBox.Size = new Size(88, 20);
			this.MarginOuterTextBox.TabIndex = 6;
			this.MarginOuterTextBox.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.MarginOuterTextBox;
			this.focusLabel2.Location = new Point(40, 146);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(72, 15);
			this.focusLabel2.Text = "Margin Outer";
			this.focusLabel2.LoadingEnd();
			this.ContextMenuEnabledCheckBox.Location = new Point(344, 52);
			this.ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			this.ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			this.ContextMenuEnabledCheckBox.Size = new Size(144, 24);
			this.ContextMenuEnabledCheckBox.TabIndex = 12;
			this.ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			this.LayerNumericUpDown.Location = new Point(200, 112);
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
			this.LayerNumericUpDown.TabIndex = 5;
			this.LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.LayerNumericUpDown;
			this.label1.Location = new Point(165, 113);
			this.label1.Name = "label1";
			this.label1.Size = new Size(35, 15);
			this.label1.Text = "Layer";
			this.label1.LoadingEnd();
			this.UserCanEditCheckBox.Location = new Point(344, 76);
			this.UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			this.UserCanEditCheckBox.PropertyName = "UserCanEdit";
			this.UserCanEditCheckBox.Size = new Size(96, 24);
			this.UserCanEditCheckBox.TabIndex = 13;
			this.UserCanEditCheckBox.Text = "User Can Edit";
			this.ImageIndexUpDown.Location = new Point(112, 72);
			this.ImageIndexUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			this.ImageIndexUpDown.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				-2147483648
			});
			this.ImageIndexUpDown.Name = "ImageIndexUpDown";
			this.ImageIndexUpDown.PropertyName = "ImageIndex";
			this.ImageIndexUpDown.Size = new Size(56, 20);
			this.ImageIndexUpDown.TabIndex = 2;
			this.ImageIndexUpDown.TextAlign = HorizontalAlignment.Center;
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.ImageIndexUpDown;
			this.focusLabel3.Location = new Point(44, 73);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(68, 15);
			this.focusLabel3.Text = "Image Index";
			this.focusLabel3.LoadingEnd();
			this.ImageTransparentCheckBox.Location = new Point(174, 70);
			this.ImageTransparentCheckBox.Name = "ImageTransparentCheckBox";
			this.ImageTransparentCheckBox.PropertyName = "ImageTransparent";
			this.ImageTransparentCheckBox.Size = new Size(128, 24);
			this.ImageTransparentCheckBox.TabIndex = 3;
			this.ImageTransparentCheckBox.Text = "Image Transparent";
			this.CanFocusCheckBox.Location = new Point(344, 100);
			this.CanFocusCheckBox.Name = "CanFocusCheckBox";
			this.CanFocusCheckBox.PropertyName = "CanFocus";
			this.CanFocusCheckBox.Size = new Size(80, 24);
			this.CanFocusCheckBox.TabIndex = 14;
			this.CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(this.CanFocusCheckBox);
			base.Controls.Add(this.ImageTransparentCheckBox);
			base.Controls.Add(this.ImageIndexUpDown);
			base.Controls.Add(this.focusLabel3);
			base.Controls.Add(this.UserCanEditCheckBox);
			base.Controls.Add(this.LayerNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ContextMenuEnabledCheckBox);
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
			base.Controls.Add(this.NameTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotLabelBasicEditorPlugIn";
			base.Size = new Size(504, 256);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new TextLayoutFullEditorPlugin(), "Text Layout", false);
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill", false);
			base.AddSubPlugIn(new PlotLayoutDockableAllEditorPlugIn(), "Dock", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotLabelBasic).TextLayout;
			base.SubPlugIns[1].Value = (base.Value as PlotLabelBasic).Fill;
			base.SubPlugIns[2].Value = base.Value;
		}
	}
}
