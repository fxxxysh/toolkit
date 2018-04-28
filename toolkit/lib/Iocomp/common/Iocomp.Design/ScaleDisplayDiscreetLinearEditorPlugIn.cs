using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleDisplayDiscreetLinearEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DirectionComboBox;

		private FocusLabel label5;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginNumericUpDown;

		private GroupBox groupBox1;

		private FocusLabel label3;

		private FontButton TextInactiveFontButton;

		private GroupBox groupBox2;

		private FocusLabel label4;

		private FontButton TextActiveFontButton;

		private Iocomp.Design.Plugin.EditorControls.ComboBox TextAlignmentComboBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown TextMarginNumericUpDown;

		private ColorPicker TextInactiveForeColorPicker;

		private ColorPicker TextActiveForeColorPicker;

		private Container components;

		public ScaleDisplayDiscreetLinearEditorPlugIn()
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
			this.label2 = new FocusLabel();
			this.DirectionComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label5 = new FocusLabel();
			this.MarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.groupBox1 = new GroupBox();
			this.label3 = new FocusLabel();
			this.TextInactiveForeColorPicker = new ColorPicker();
			this.TextInactiveFontButton = new FontButton();
			this.groupBox2 = new GroupBox();
			this.label4 = new FocusLabel();
			this.TextActiveForeColorPicker = new ColorPicker();
			this.TextActiveFontButton = new FontButton();
			this.TextAlignmentComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.label8 = new FocusLabel();
			this.TextMarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			((ISupportInitialize)this.MarginNumericUpDown).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.TextMarginNumericUpDown).BeginInit();
			base.SuspendLayout();
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.DirectionComboBox;
			this.label2.Location = new Point(45, 74);
			this.label2.Name = "label2";
			this.label2.Size = new Size(51, 15);
			this.label2.Text = "Direction";
			this.label2.LoadingEnd();
			this.DirectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.DirectionComboBox.Location = new Point(96, 72);
			this.DirectionComboBox.Name = "DirectionComboBox";
			this.DirectionComboBox.PropertyName = "Direction";
			this.DirectionComboBox.Size = new Size(121, 21);
			this.DirectionComboBox.TabIndex = 2;
			this.label5.LoadingBegin();
			this.label5.FocusControl = this.MarginNumericUpDown;
			this.label5.Location = new Point(55, 105);
			this.label5.Name = "label5";
			this.label5.Size = new Size(41, 15);
			this.label5.Text = "Margin";
			this.label5.LoadingEnd();
			this.MarginNumericUpDown.Location = new Point(96, 104);
			this.MarginNumericUpDown.Maximum = new decimal(new int[4]
			{
				0,
				0,
				-2147483648,
				0
			});
			this.MarginNumericUpDown.Minimum = new decimal(new int[4]
			{
				2,
				0,
				0,
				0
			});
			this.MarginNumericUpDown.Name = "MarginNumericUpDown";
			this.MarginNumericUpDown.PropertyName = "Margin";
			this.MarginNumericUpDown.Size = new Size(48, 20);
			this.MarginNumericUpDown.TabIndex = 3;
			this.MarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.TextInactiveForeColorPicker);
			this.groupBox1.Controls.Add(this.TextInactiveFontButton);
			this.groupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox1.Location = new Point(232, 96);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(224, 80);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Text Inactive";
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.TextInactiveForeColorPicker;
			this.label3.Location = new Point(16, 51);
			this.label3.Name = "label3";
			this.label3.Size = new Size(56, 15);
			this.label3.Text = "ForeColor";
			this.label3.LoadingEnd();
			this.TextInactiveForeColorPicker.Location = new Point(72, 48);
			this.TextInactiveForeColorPicker.Name = "TextInactiveForeColorPicker";
			this.TextInactiveForeColorPicker.PropertyName = "TextInactiveForeColor";
			this.TextInactiveForeColorPicker.Size = new Size(144, 21);
			this.TextInactiveForeColorPicker.TabIndex = 1;
			this.TextInactiveFontButton.Location = new Point(72, 16);
			this.TextInactiveFontButton.Name = "TextInactiveFontButton";
			this.TextInactiveFontButton.PropertyName = "TextInactiveFont";
			this.TextInactiveFontButton.Size = new Size(72, 23);
			this.TextInactiveFontButton.TabIndex = 0;
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.TextActiveForeColorPicker);
			this.groupBox2.Controls.Add(this.TextActiveFontButton);
			this.groupBox2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox2.Location = new Point(232, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(224, 80);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Text Active";
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.TextActiveForeColorPicker;
			this.label4.Location = new Point(16, 51);
			this.label4.Name = "label4";
			this.label4.Size = new Size(56, 15);
			this.label4.Text = "ForeColor";
			this.label4.LoadingEnd();
			this.TextActiveForeColorPicker.Location = new Point(72, 48);
			this.TextActiveForeColorPicker.Name = "TextActiveForeColorPicker";
			this.TextActiveForeColorPicker.PropertyName = "TextActiveForeColor";
			this.TextActiveForeColorPicker.Size = new Size(144, 21);
			this.TextActiveForeColorPicker.TabIndex = 1;
			this.TextActiveFontButton.Location = new Point(72, 16);
			this.TextActiveFontButton.Name = "TextActiveFontButton";
			this.TextActiveFontButton.PropertyName = "TextActiveFont";
			this.TextActiveFontButton.Size = new Size(72, 23);
			this.TextActiveFontButton.TabIndex = 0;
			this.TextAlignmentComboBox.Location = new Point(0, 0);
			this.TextAlignmentComboBox.Name = "TextAlignmentComboBox";
			this.TextAlignmentComboBox.TabIndex = 0;
			this.VisibleCheckBox.Location = new Point(96, 8);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(62, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visble";
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.TextMarginNumericUpDown;
			this.label8.Location = new Point(30, 41);
			this.label8.Name = "label8";
			this.label8.Size = new Size(66, 15);
			this.label8.Text = "Text Margin";
			this.label8.LoadingEnd();
			this.TextMarginNumericUpDown.Location = new Point(96, 40);
			this.TextMarginNumericUpDown.Name = "TextMarginNumericUpDown";
			this.TextMarginNumericUpDown.PropertyName = "TextMargin";
			this.TextMarginNumericUpDown.Size = new Size(48, 20);
			this.TextMarginNumericUpDown.TabIndex = 1;
			this.TextMarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			base.Controls.Add(this.label8);
			base.Controls.Add(this.TextMarginNumericUpDown);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.MarginNumericUpDown);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.DirectionComboBox);
			base.Controls.Add(this.label2);
			base.Name = "ScaleDisplayDiscreetLinearEditorPlugIn";
			base.Size = new Size(488, 200);
			base.Title = "Scale Display Editor";
			((ISupportInitialize)this.MarginNumericUpDown).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			((ISupportInitialize)this.TextMarginNumericUpDown).EndInit();
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new ScaleDiscreetMarkerEditorPlugIn(), "Markers", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as ScaleDisplayDiscreetLinear).Markers;
		}
	}
}
