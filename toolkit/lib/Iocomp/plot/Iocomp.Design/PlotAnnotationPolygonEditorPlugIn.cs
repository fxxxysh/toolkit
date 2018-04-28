using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotAnnotationPolygonEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanEditCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanSizeCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanMoveCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel7;

		private EditBox YAxisNameTextBox;

		private FocusLabel focusLabel5;

		private EditBox XAxisNameTextBox;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel focusLabel4;

		private EditBox RotationTextBox;

		private FocusLabel focusLabel1;

		private EditBox YTextBox;

		private FocusLabel label9;

		private EditBox XTextBox;

		private FocusLabel label8;

		private EditBox HeightTextBox;

		private EditBox WidthTextBox;

		private FocusLabel label7;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ClippingStyleComboBox;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox CanFocusCheckBox;

		private Container components;

		public PlotAnnotationPolygonEditorPlugIn()
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
			this.EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.UserCanEditCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.UserCanSizeCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.UserCanMoveCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.NameTextBox = new EditBox();
			this.focusLabel7 = new FocusLabel();
			this.YAxisNameTextBox = new EditBox();
			this.focusLabel5 = new FocusLabel();
			this.XAxisNameTextBox = new EditBox();
			this.focusLabel6 = new FocusLabel();
			this.LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.focusLabel4 = new FocusLabel();
			this.RotationTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.YTextBox = new EditBox();
			this.label9 = new FocusLabel();
			this.XTextBox = new EditBox();
			this.label8 = new FocusLabel();
			this.HeightTextBox = new EditBox();
			this.WidthTextBox = new EditBox();
			this.label7 = new FocusLabel();
			this.label1 = new FocusLabel();
			this.ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ClippingStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel2 = new FocusLabel();
			this.CanFocusCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			this.EnabledCheckBox.Location = new Point(16, 35);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(72, 24);
			this.EnabledCheckBox.TabIndex = 1;
			this.EnabledCheckBox.Text = "Enabled";
			this.VisibleCheckBox.Location = new Point(16, 11);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.UserCanEditCheckBox.Location = new Point(16, 107);
			this.UserCanEditCheckBox.Name = "UserCanEditCheckBox";
			this.UserCanEditCheckBox.PropertyName = "UserCanEdit";
			this.UserCanEditCheckBox.Size = new Size(96, 24);
			this.UserCanEditCheckBox.TabIndex = 4;
			this.UserCanEditCheckBox.Text = "User Can Edit";
			this.UserCanSizeCheckBox.Location = new Point(16, 83);
			this.UserCanSizeCheckBox.Name = "UserCanSizeCheckBox";
			this.UserCanSizeCheckBox.PropertyName = "UserCanSize";
			this.UserCanSizeCheckBox.TabIndex = 3;
			this.UserCanSizeCheckBox.Text = "User Can Size";
			this.UserCanMoveCheckBox.Location = new Point(16, 59);
			this.UserCanMoveCheckBox.Name = "UserCanMoveCheckBox";
			this.UserCanMoveCheckBox.PropertyName = "UserCanMove";
			this.UserCanMoveCheckBox.TabIndex = 2;
			this.UserCanMoveCheckBox.Text = "User Can Move";
			this.NameTextBox.LoadingBegin();
			this.NameTextBox.Location = new Point(232, 16);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.PropertyName = "Name";
			this.NameTextBox.Size = new Size(144, 20);
			this.NameTextBox.TabIndex = 7;
			this.NameTextBox.LoadingEnd();
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.NameTextBox;
			this.focusLabel7.Location = new Point(195, 18);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(37, 15);
			this.focusLabel7.Text = "Name";
			this.focusLabel7.LoadingEnd();
			this.YAxisNameTextBox.LoadingBegin();
			this.YAxisNameTextBox.Location = new Point(232, 64);
			this.YAxisNameTextBox.Name = "YAxisNameTextBox";
			this.YAxisNameTextBox.PropertyName = "YAxisName";
			this.YAxisNameTextBox.Size = new Size(144, 20);
			this.YAxisNameTextBox.TabIndex = 9;
			this.YAxisNameTextBox.LoadingEnd();
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.YAxisNameTextBox;
			this.focusLabel5.Location = new Point(160, 66);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(72, 15);
			this.focusLabel5.Text = "Y-Axis Name";
			this.focusLabel5.LoadingEnd();
			this.XAxisNameTextBox.LoadingBegin();
			this.XAxisNameTextBox.Location = new Point(232, 40);
			this.XAxisNameTextBox.Name = "XAxisNameTextBox";
			this.XAxisNameTextBox.PropertyName = "XAxisName";
			this.XAxisNameTextBox.Size = new Size(144, 20);
			this.XAxisNameTextBox.TabIndex = 8;
			this.XAxisNameTextBox.LoadingEnd();
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.XAxisNameTextBox;
			this.focusLabel6.Location = new Point(160, 42);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(72, 15);
			this.focusLabel6.Text = "X-Axis Name";
			this.focusLabel6.LoadingEnd();
			this.LayerNumericUpDown.Location = new Point(320, 88);
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
			this.LayerNumericUpDown.TabIndex = 11;
			this.LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.LayerNumericUpDown;
			this.focusLabel4.Location = new Point(285, 89);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(35, 15);
			this.focusLabel4.Text = "Layer";
			this.focusLabel4.LoadingEnd();
			this.RotationTextBox.LoadingBegin();
			this.RotationTextBox.Location = new Point(232, 88);
			this.RotationTextBox.Name = "RotationTextBox";
			this.RotationTextBox.PropertyName = "Rotation";
			this.RotationTextBox.Size = new Size(48, 20);
			this.RotationTextBox.TabIndex = 10;
			this.RotationTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.RotationTextBox;
			this.focusLabel1.Location = new Point(183, 90);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(49, 15);
			this.focusLabel1.Text = "Rotation";
			this.focusLabel1.LoadingEnd();
			this.YTextBox.LoadingBegin();
			this.YTextBox.Location = new Point(432, 40);
			this.YTextBox.Name = "YTextBox";
			this.YTextBox.PropertyName = "Y";
			this.YTextBox.Size = new Size(112, 20);
			this.YTextBox.TabIndex = 14;
			this.YTextBox.LoadingEnd();
			this.label9.LoadingBegin();
			this.label9.FocusControl = this.YTextBox;
			this.label9.Location = new Point(417, 42);
			this.label9.Name = "label9";
			this.label9.Size = new Size(15, 15);
			this.label9.Text = "Y";
			this.label9.LoadingEnd();
			this.XTextBox.LoadingBegin();
			this.XTextBox.Location = new Point(432, 16);
			this.XTextBox.Name = "XTextBox";
			this.XTextBox.PropertyName = "X";
			this.XTextBox.Size = new Size(112, 20);
			this.XTextBox.TabIndex = 13;
			this.XTextBox.LoadingEnd();
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.XTextBox;
			this.label8.Location = new Point(417, 18);
			this.label8.Name = "label8";
			this.label8.Size = new Size(15, 15);
			this.label8.Text = "X";
			this.label8.LoadingEnd();
			this.HeightTextBox.LoadingBegin();
			this.HeightTextBox.Location = new Point(432, 88);
			this.HeightTextBox.Name = "HeightTextBox";
			this.HeightTextBox.PropertyName = "Height";
			this.HeightTextBox.Size = new Size(112, 20);
			this.HeightTextBox.TabIndex = 16;
			this.HeightTextBox.LoadingEnd();
			this.WidthTextBox.LoadingBegin();
			this.WidthTextBox.Location = new Point(432, 64);
			this.WidthTextBox.Name = "WidthTextBox";
			this.WidthTextBox.PropertyName = "Width";
			this.WidthTextBox.Size = new Size(112, 20);
			this.WidthTextBox.TabIndex = 15;
			this.WidthTextBox.LoadingEnd();
			this.label7.LoadingBegin();
			this.label7.FocusControl = this.WidthTextBox;
			this.label7.Location = new Point(396, 66);
			this.label7.Name = "label7";
			this.label7.Size = new Size(36, 15);
			this.label7.Text = "Width";
			this.label7.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.HeightTextBox;
			this.label1.Location = new Point(393, 90);
			this.label1.Name = "label1";
			this.label1.Size = new Size(39, 15);
			this.label1.Text = "Height";
			this.label1.LoadingEnd();
			this.ContextMenuEnabledCheckBox.Location = new Point(16, 132);
			this.ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			this.ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			this.ContextMenuEnabledCheckBox.Size = new Size(144, 24);
			this.ContextMenuEnabledCheckBox.TabIndex = 5;
			this.ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			this.ClippingStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ClippingStyleComboBox.Location = new Point(232, 112);
			this.ClippingStyleComboBox.MaxDropDownItems = 20;
			this.ClippingStyleComboBox.Name = "ClippingStyleComboBox";
			this.ClippingStyleComboBox.PropertyName = "ClippingStyle";
			this.ClippingStyleComboBox.Size = new Size(80, 21);
			this.ClippingStyleComboBox.TabIndex = 12;
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.ClippingStyleComboBox;
			this.focusLabel2.Location = new Point(157, 114);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(75, 15);
			this.focusLabel2.Text = "Clipping Style";
			this.focusLabel2.LoadingEnd();
			this.CanFocusCheckBox.Location = new Point(16, 157);
			this.CanFocusCheckBox.Name = "CanFocusCheckBox";
			this.CanFocusCheckBox.PropertyName = "CanFocus";
			this.CanFocusCheckBox.Size = new Size(144, 24);
			this.CanFocusCheckBox.TabIndex = 6;
			this.CanFocusCheckBox.Text = "Can Focus";
			base.Controls.Add(this.CanFocusCheckBox);
			base.Controls.Add(this.ClippingStyleComboBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.ContextMenuEnabledCheckBox);
			base.Controls.Add(this.NameTextBox);
			base.Controls.Add(this.focusLabel7);
			base.Controls.Add(this.YAxisNameTextBox);
			base.Controls.Add(this.focusLabel5);
			base.Controls.Add(this.XAxisNameTextBox);
			base.Controls.Add(this.focusLabel6);
			base.Controls.Add(this.LayerNumericUpDown);
			base.Controls.Add(this.focusLabel4);
			base.Controls.Add(this.RotationTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.YTextBox);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.XTextBox);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.HeightTextBox);
			base.Controls.Add(this.WidthTextBox);
			base.Controls.Add(this.label7);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.UserCanEditCheckBox);
			base.Controls.Add(this.UserCanSizeCheckBox);
			base.Controls.Add(this.UserCanMoveCheckBox);
			base.Controls.Add(this.EnabledCheckBox);
			base.Controls.Add(this.VisibleCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotAnnotationPolygonEditorPlugIn";
			base.Size = new Size(584, 272);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotAnnotationUnitTypesEditorPlugIn(), "Unit Types", false);
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill", false);
			base.AddSubPlugIn(new PointDoubleCollectionEditorPlugIn(), "Points", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = base.Value;
			base.SubPlugIns[1].Value = (base.Value as PlotAnnotationPolygon).Fill;
			base.SubPlugIns[2].Value = (base.Value as PlotAnnotationPolygon).Points;
		}
	}
}
