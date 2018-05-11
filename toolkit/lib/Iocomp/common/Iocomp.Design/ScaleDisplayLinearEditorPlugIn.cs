using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class ScaleDisplayLinearEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox AntiAliasCheckBox;

		private GroupBox groupBox1;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox StartRefEnabledCheckBox;

		private EditBox StartRefValueTextBox;

		private GroupBox groupBox5;

		private Iocomp.Design.Plugin.EditorControls.ComboBox TextAlignmentComboBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox TextRotationComboBox;

		private FocusLabel label10;

		private FocusLabel label11;

		private FocusLabel label12;

		private Iocomp.Design.Plugin.EditorControls.CheckBox TextWidthMinAutoCheckBox;

		private EditBox TextWidthMinValueTextBox;

		private FocusLabel label5;

		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DirectionComboBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LineOuterVisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LineInnerVisibleCheckBox;

		private FocusLabel focusLabel1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LineThicknessUpDown;

		private Container components;

		public ScaleDisplayLinearEditorPlugIn()
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
			this.AntiAliasCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.groupBox1 = new GroupBox();
			this.StartRefValueTextBox = new EditBox();
			this.StartRefEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.label8 = new FocusLabel();
			this.groupBox5 = new GroupBox();
			this.label12 = new FocusLabel();
			this.TextWidthMinValueTextBox = new EditBox();
			this.TextWidthMinAutoCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.TextAlignmentComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.TextRotationComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label10 = new FocusLabel();
			this.label11 = new FocusLabel();
			this.label5 = new FocusLabel();
			this.MarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label2 = new FocusLabel();
			this.DirectionComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.LineOuterVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LineInnerVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.focusLabel1 = new FocusLabel();
			this.LineThicknessUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			((ISupportInitialize)this.MarginNumericUpDown).BeginInit();
			((ISupportInitialize)this.LineThicknessUpDown).BeginInit();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(16, 20);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.TabIndex = 1;
			this.VisibleCheckBox.Text = "Visible";
			this.AntiAliasCheckBox.Location = new Point(16, 0);
			this.AntiAliasCheckBox.Name = "AntiAliasCheckBox";
			this.AntiAliasCheckBox.PropertyName = "AntiAliasEnabled";
			this.AntiAliasCheckBox.Size = new Size(120, 24);
			this.AntiAliasCheckBox.TabIndex = 0;
			this.AntiAliasCheckBox.Text = "Anti Alias Enabled";
			this.groupBox1.Controls.Add(this.StartRefValueTextBox);
			this.groupBox1.Controls.Add(this.StartRefEnabledCheckBox);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Location = new Point(232, 128);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(264, 64);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Start Ref";
			this.StartRefValueTextBox.LoadingBegin();
			this.StartRefValueTextBox.Location = new Point(64, 28);
			this.StartRefValueTextBox.Name = "StartRefValueTextBox";
			this.StartRefValueTextBox.PropertyName = "StartRefValue";
			this.StartRefValueTextBox.Size = new Size(80, 20);
			this.StartRefValueTextBox.TabIndex = 0;
			this.StartRefValueTextBox.LoadingEnd();
			this.StartRefEnabledCheckBox.Location = new Point(152, 26);
			this.StartRefEnabledCheckBox.Name = "StartRefEnabledCheckBox";
			this.StartRefEnabledCheckBox.PropertyName = "StartRefEnabled";
			this.StartRefEnabledCheckBox.Size = new Size(72, 24);
			this.StartRefEnabledCheckBox.TabIndex = 1;
			this.StartRefEnabledCheckBox.Text = "Enabled";
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.StartRefValueTextBox;
			this.label8.Location = new Point(28, 30);
			this.label8.Name = "label8";
			this.label8.Size = new Size(36, 15);
			this.label8.Text = "Value";
			this.label8.LoadingEnd();
			this.groupBox5.Controls.Add(this.label12);
			this.groupBox5.Controls.Add(this.TextWidthMinAutoCheckBox);
			this.groupBox5.Controls.Add(this.TextWidthMinValueTextBox);
			this.groupBox5.Controls.Add(this.TextAlignmentComboBox);
			this.groupBox5.Controls.Add(this.TextRotationComboBox);
			this.groupBox5.Controls.Add(this.label10);
			this.groupBox5.Controls.Add(this.label11);
			this.groupBox5.Location = new Point(232, 8);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new Size(264, 112);
			this.groupBox5.TabIndex = 7;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Text";
			this.label12.LoadingBegin();
			this.label12.FocusControl = this.TextWidthMinValueTextBox;
			this.label12.Location = new Point(8, 82);
			this.label12.Name = "label12";
			this.label12.Size = new Size(88, 15);
			this.label12.Text = "Width Min Value";
			this.label12.LoadingEnd();
			this.TextWidthMinValueTextBox.LoadingBegin();
			this.TextWidthMinValueTextBox.Location = new Point(96, 80);
			this.TextWidthMinValueTextBox.Name = "TextWidthMinValueTextBox";
			this.TextWidthMinValueTextBox.PropertyName = "TextWidthMinValue";
			this.TextWidthMinValueTextBox.Size = new Size(40, 20);
			this.TextWidthMinValueTextBox.TabIndex = 2;
			this.TextWidthMinValueTextBox.LoadingEnd();
			this.TextWidthMinAutoCheckBox.Location = new Point(152, 80);
			this.TextWidthMinAutoCheckBox.Name = "TextWidthMinAutoCheckBox";
			this.TextWidthMinAutoCheckBox.PropertyName = "TextWidthMinAuto";
			this.TextWidthMinAutoCheckBox.TabIndex = 3;
			this.TextWidthMinAutoCheckBox.Text = "Width Min Auto";
			this.TextAlignmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.TextAlignmentComboBox.Location = new Point(96, 24);
			this.TextAlignmentComboBox.Name = "TextAlignmentComboBox";
			this.TextAlignmentComboBox.PropertyName = "TextAlignment";
			this.TextAlignmentComboBox.Size = new Size(121, 21);
			this.TextAlignmentComboBox.TabIndex = 0;
			this.TextRotationComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.TextRotationComboBox.Location = new Point(96, 48);
			this.TextRotationComboBox.Name = "TextRotationComboBox";
			this.TextRotationComboBox.PropertyName = "TextRotation";
			this.TextRotationComboBox.Size = new Size(121, 21);
			this.TextRotationComboBox.TabIndex = 1;
			this.label10.LoadingBegin();
			this.label10.FocusControl = this.TextAlignmentComboBox;
			this.label10.Location = new Point(39, 26);
			this.label10.Name = "label10";
			this.label10.Size = new Size(57, 15);
			this.label10.Text = "Alignment";
			this.label10.LoadingEnd();
			this.label11.LoadingBegin();
			this.label11.FocusControl = this.TextRotationComboBox;
			this.label11.Location = new Point(47, 50);
			this.label11.Name = "label11";
			this.label11.Size = new Size(49, 15);
			this.label11.Text = "Rotation";
			this.label11.LoadingEnd();
			this.label5.LoadingBegin();
			this.label5.FocusControl = this.MarginNumericUpDown;
			this.label5.Location = new Point(55, 161);
			this.label5.Name = "label5";
			this.label5.Size = new Size(41, 15);
			this.label5.Text = "Margin";
			this.label5.LoadingEnd();
			this.MarginNumericUpDown.Location = new Point(96, 160);
			this.MarginNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			this.MarginNumericUpDown.Minimum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				-2147483648
			});
			this.MarginNumericUpDown.Name = "MarginNumericUpDown";
			this.MarginNumericUpDown.PropertyName = "Margin";
			this.MarginNumericUpDown.Size = new Size(48, 20);
			this.MarginNumericUpDown.TabIndex = 6;
			this.MarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.DirectionComboBox;
			this.label2.Location = new Point(45, 130);
			this.label2.Name = "label2";
			this.label2.Size = new Size(51, 15);
			this.label2.Text = "Direction";
			this.label2.LoadingEnd();
			this.DirectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.DirectionComboBox.Location = new Point(96, 128);
			this.DirectionComboBox.Name = "DirectionComboBox";
			this.DirectionComboBox.PropertyName = "Direction";
			this.DirectionComboBox.Size = new Size(121, 21);
			this.DirectionComboBox.TabIndex = 5;
			this.LineOuterVisibleCheckBox.Location = new Point(16, 60);
			this.LineOuterVisibleCheckBox.Name = "LineOuterVisibleCheckBox";
			this.LineOuterVisibleCheckBox.PropertyName = "LineOuterVisible";
			this.LineOuterVisibleCheckBox.Size = new Size(120, 24);
			this.LineOuterVisibleCheckBox.TabIndex = 3;
			this.LineOuterVisibleCheckBox.Text = "Line Outer Visible";
			this.LineInnerVisibleCheckBox.Location = new Point(16, 40);
			this.LineInnerVisibleCheckBox.Name = "LineInnerVisibleCheckBox";
			this.LineInnerVisibleCheckBox.PropertyName = "LineInnerVisible";
			this.LineInnerVisibleCheckBox.Size = new Size(112, 24);
			this.LineInnerVisibleCheckBox.TabIndex = 2;
			this.LineInnerVisibleCheckBox.Text = "Line Inner Visible";
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.LineThicknessUpDown;
			this.focusLabel1.Location = new Point(16, 97);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(80, 15);
			this.focusLabel1.Text = "Line Thickness";
			this.focusLabel1.LoadingEnd();
			this.LineThicknessUpDown.Location = new Point(96, 96);
			this.LineThicknessUpDown.Name = "LineThicknessUpDown";
			this.LineThicknessUpDown.PropertyName = "LineThickness";
			this.LineThicknessUpDown.Size = new Size(48, 20);
			this.LineThicknessUpDown.TabIndex = 4;
			this.LineThicknessUpDown.TextAlign = HorizontalAlignment.Center;
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.LineThicknessUpDown);
			base.Controls.Add(this.LineOuterVisibleCheckBox);
			base.Controls.Add(this.LineInnerVisibleCheckBox);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.MarginNumericUpDown);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.DirectionComboBox);
			base.Controls.Add(this.groupBox5);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.AntiAliasCheckBox);
			base.Controls.Add(this.VisibleCheckBox);
			base.Name = "ScaleDisplayLinearEditorPlugIn";
			base.Size = new Size(616, 216);
			base.Title = "Scale Display Editor";
			this.groupBox1.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			((ISupportInitialize)this.MarginNumericUpDown).EndInit();
			((ISupportInitialize)this.LineThicknessUpDown).EndInit();
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new ScaleDisplayGeneratorEditorPlugIn(), "Generator", false);
			base.AddSubPlugIn(new TextFormatDoubleAllEditorPlugIn(), "Text Formatting", false);
			base.AddSubPlugIn(new ScaleTickMajorEditorPlugIn(), "Tick-Major", false);
			base.AddSubPlugIn(new ScaleTickMinorEditorPlugIn(), "Tick-Minor", false);
			base.AddSubPlugIn(new ScaleTickMidEditorPlugIn(), "Tick-Mid", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as ScaleDisplayLinear);
			base.SubPlugIns[1].Value = (base.Value as ScaleDisplayLinear).TextFormatting;
			base.SubPlugIns[2].Value = (base.Value as ScaleDisplayLinear).TickMajor;
			base.SubPlugIns[3].Value = (base.Value as ScaleDisplayLinear).TickMinor;
			base.SubPlugIns[4].Value = (base.Value as ScaleDisplayLinear).TickMid;
		}
	}
}
