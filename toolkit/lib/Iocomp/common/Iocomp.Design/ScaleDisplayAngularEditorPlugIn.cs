using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class ScaleDisplayAngularEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private GroupBox groupBox2;

		private FocusLabel label5;

		private EditBox TextWidthMinValueTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox TextWidthMinAutoCheckBox;

		private GroupBox groupBox1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox StartRefEnabledCheckBox;

		private FocusLabel label8;

		private EditBox StartRefValueTextBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox TextAlignmentComboBox;

		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LineInnerVisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LineOuterVisibleCheckBox;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginNumericUpDown;

		private FocusLabel focusLabel1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LineThicknessUpDown;

		private Container components;

		public ScaleDisplayAngularEditorPlugIn()
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
			this.groupBox2 = new GroupBox();
			this.TextAlignmentComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label2 = new FocusLabel();
			this.TextWidthMinAutoCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.label5 = new FocusLabel();
			this.TextWidthMinValueTextBox = new EditBox();
			this.groupBox1 = new GroupBox();
			this.StartRefEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.StartRefValueTextBox = new EditBox();
			this.label8 = new FocusLabel();
			this.LineInnerVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LineOuterVisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.label1 = new FocusLabel();
			this.MarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.focusLabel1 = new FocusLabel();
			this.LineThicknessUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.MarginNumericUpDown).BeginInit();
			((ISupportInitialize)this.LineThicknessUpDown).BeginInit();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(24, 8);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(64, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.groupBox2.Controls.Add(this.TextAlignmentComboBox);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.TextWidthMinAutoCheckBox);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.TextWidthMinValueTextBox);
			this.groupBox2.Location = new Point(240, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(256, 88);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Text";
			this.TextAlignmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.TextAlignmentComboBox.Location = new Point(104, 24);
			this.TextAlignmentComboBox.Name = "TextAlignmentComboBox";
			this.TextAlignmentComboBox.PropertyName = "TextAlignment";
			this.TextAlignmentComboBox.Size = new Size(121, 21);
			this.TextAlignmentComboBox.TabIndex = 0;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.TextAlignmentComboBox;
			this.label2.Location = new Point(47, 26);
			this.label2.Name = "label2";
			this.label2.Size = new Size(57, 15);
			this.label2.Text = "Alignment";
			this.label2.LoadingEnd();
			this.TextWidthMinAutoCheckBox.Location = new Point(144, 56);
			this.TextWidthMinAutoCheckBox.Name = "TextWidthMinAutoCheckBox";
			this.TextWidthMinAutoCheckBox.PropertyName = "TextWidthMinAuto";
			this.TextWidthMinAutoCheckBox.TabIndex = 2;
			this.TextWidthMinAutoCheckBox.Text = "Width Min Auto";
			this.label5.LoadingBegin();
			this.label5.FocusControl = this.TextWidthMinValueTextBox;
			this.label5.Location = new Point(16, 58);
			this.label5.Name = "label5";
			this.label5.Size = new Size(88, 15);
			this.label5.Text = "Width Min Value";
			this.label5.LoadingEnd();
			this.TextWidthMinValueTextBox.LoadingBegin();
			this.TextWidthMinValueTextBox.Location = new Point(104, 56);
			this.TextWidthMinValueTextBox.Name = "TextWidthMinValueTextBox";
			this.TextWidthMinValueTextBox.PropertyName = "TextWidthMinValue";
			this.TextWidthMinValueTextBox.Size = new Size(32, 20);
			this.TextWidthMinValueTextBox.TabIndex = 1;
			this.TextWidthMinValueTextBox.LoadingEnd();
			this.groupBox1.Controls.Add(this.StartRefEnabledCheckBox);
			this.groupBox1.Controls.Add(this.StartRefValueTextBox);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Location = new Point(240, 96);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(256, 56);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Start Ref";
			this.StartRefEnabledCheckBox.Location = new Point(144, 20);
			this.StartRefEnabledCheckBox.Name = "StartRefEnabledCheckBox";
			this.StartRefEnabledCheckBox.PropertyName = "StartRefEnabled";
			this.StartRefEnabledCheckBox.Size = new Size(72, 24);
			this.StartRefEnabledCheckBox.TabIndex = 1;
			this.StartRefEnabledCheckBox.Text = "Enabled";
			this.StartRefValueTextBox.LoadingBegin();
			this.StartRefValueTextBox.Location = new Point(64, 20);
			this.StartRefValueTextBox.Name = "StartRefValueTextBox";
			this.StartRefValueTextBox.PropertyName = "StartRefValue";
			this.StartRefValueTextBox.Size = new Size(72, 20);
			this.StartRefValueTextBox.TabIndex = 0;
			this.StartRefValueTextBox.LoadingEnd();
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.StartRefValueTextBox;
			this.label8.Location = new Point(28, 22);
			this.label8.Name = "label8";
			this.label8.Size = new Size(36, 15);
			this.label8.Text = "Value";
			this.label8.LoadingEnd();
			this.LineInnerVisibleCheckBox.Location = new Point(24, 32);
			this.LineInnerVisibleCheckBox.Name = "LineInnerVisibleCheckBox";
			this.LineInnerVisibleCheckBox.PropertyName = "LineInnerVisible";
			this.LineInnerVisibleCheckBox.Size = new Size(128, 24);
			this.LineInnerVisibleCheckBox.TabIndex = 1;
			this.LineInnerVisibleCheckBox.Text = "Line Inner Visible";
			this.LineOuterVisibleCheckBox.Location = new Point(24, 56);
			this.LineOuterVisibleCheckBox.Name = "LineOuterVisibleCheckBox";
			this.LineOuterVisibleCheckBox.PropertyName = "LineOuterVisible";
			this.LineOuterVisibleCheckBox.Size = new Size(128, 24);
			this.LineOuterVisibleCheckBox.TabIndex = 2;
			this.LineOuterVisibleCheckBox.Text = "Line Outer Visible";
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.MarginNumericUpDown;
			this.label1.Location = new Point(63, 121);
			this.label1.Name = "label1";
			this.label1.Size = new Size(41, 15);
			this.label1.Text = "Margin";
			this.label1.LoadingEnd();
			this.MarginNumericUpDown.Location = new Point(104, 120);
			this.MarginNumericUpDown.Name = "MarginNumericUpDown";
			this.MarginNumericUpDown.PropertyName = "Margin";
			this.MarginNumericUpDown.Size = new Size(48, 20);
			this.MarginNumericUpDown.TabIndex = 4;
			this.MarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.LineThicknessUpDown;
			this.focusLabel1.Location = new Point(24, 89);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(80, 15);
			this.focusLabel1.Text = "Line Thickness";
			this.focusLabel1.LoadingEnd();
			this.LineThicknessUpDown.Location = new Point(104, 88);
			this.LineThicknessUpDown.Name = "LineThicknessUpDown";
			this.LineThicknessUpDown.PropertyName = "LineThickness";
			this.LineThicknessUpDown.Size = new Size(48, 20);
			this.LineThicknessUpDown.TabIndex = 3;
			this.LineThicknessUpDown.TextAlign = HorizontalAlignment.Center;
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.LineThicknessUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.MarginNumericUpDown);
			base.Controls.Add(this.LineOuterVisibleCheckBox);
			base.Controls.Add(this.LineInnerVisibleCheckBox);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.VisibleCheckBox);
			base.Name = "ScaleDisplayAngularEditorPlugIn";
			base.Size = new Size(536, 192);
			base.Title = "Scale Display Editor";
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
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
			base.SubPlugIns[0].Value = (base.Value as ScaleDisplayAngular);
			base.SubPlugIns[1].Value = (base.Value as ScaleDisplayAngular).TextFormatting;
			base.SubPlugIns[2].Value = (base.Value as ScaleDisplayAngular).TickMajor;
			base.SubPlugIns[3].Value = (base.Value as ScaleDisplayAngular).TickMinor;
			base.SubPlugIns[4].Value = (base.Value as ScaleDisplayAngular).TickMid;
		}
	}
}
