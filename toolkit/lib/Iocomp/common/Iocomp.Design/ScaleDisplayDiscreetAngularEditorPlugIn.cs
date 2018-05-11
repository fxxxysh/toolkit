using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleDisplayDiscreetAngularEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private GroupBox groupBox2;

		private FocusLabel label4;

		private FontButton TextActiveFontButton;

		private GroupBox groupBox1;

		private FocusLabel label3;

		private FontButton TextInactiveFontButton;

		private FocusLabel label5;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginNumericUpDown;

		private GroupBox groupBox3;

		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox TextAlignmentComboBox;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown TextMarginNumericUpDown;

		private FocusLabel label6;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown CallOutLengthNumericUpDown;

		private ColorPicker TextActiveForeColorPicker;

		private ColorPicker TextInactiveForeColorPicker;

		private Container components;

		public ScaleDisplayDiscreetAngularEditorPlugIn()
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
			this.label4 = new FocusLabel();
			this.TextActiveForeColorPicker = new ColorPicker();
			this.TextActiveFontButton = new FontButton();
			this.groupBox1 = new GroupBox();
			this.label3 = new FocusLabel();
			this.TextInactiveForeColorPicker = new ColorPicker();
			this.TextInactiveFontButton = new FontButton();
			this.label5 = new FocusLabel();
			this.MarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.groupBox3 = new GroupBox();
			this.TextMarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			this.TextAlignmentComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label2 = new FocusLabel();
			this.label6 = new FocusLabel();
			this.CallOutLengthNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(24, 16);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.TextActiveForeColorPicker);
			this.groupBox2.Controls.Add(this.TextActiveFontButton);
			this.groupBox2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox2.Location = new Point(240, 16);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(224, 91);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Text Active";
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.TextActiveForeColorPicker;
			this.label4.Location = new Point(13, 51);
			this.label4.Name = "label4";
			this.label4.Size = new Size(59, 15);
			this.label4.Text = "Fore Color";
			this.label4.LoadingEnd();
			this.TextActiveForeColorPicker.Location = new Point(72, 48);
			this.TextActiveForeColorPicker.Name = "TextActiveForeColorPicker";
			this.TextActiveForeColorPicker.PropertyName = "TextActiveForeColor";
			this.TextActiveForeColorPicker.Size = new Size(144, 21);
			this.TextActiveForeColorPicker.TabIndex = 1;
			this.TextActiveFontButton.Location = new Point(72, 16);
			this.TextActiveFontButton.Name = "TextActiveFontButton";
			this.TextActiveFontButton.PropertyName = "TextActiveFont";
			this.TextActiveFontButton.TabIndex = 0;
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.TextInactiveForeColorPicker);
			this.groupBox1.Controls.Add(this.TextInactiveFontButton);
			this.groupBox1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			this.groupBox1.Location = new Point(240, 120);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(224, 80);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Text Inactive";
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.TextInactiveForeColorPicker;
			this.label3.Location = new Point(13, 51);
			this.label3.Name = "label3";
			this.label3.Size = new Size(59, 15);
			this.label3.Text = "Fore Color";
			this.label3.LoadingEnd();
			this.TextInactiveForeColorPicker.Location = new Point(72, 48);
			this.TextInactiveForeColorPicker.Name = "TextInactiveForeColorPicker";
			this.TextInactiveForeColorPicker.PropertyName = "TextInactiveForeColor";
			this.TextInactiveForeColorPicker.Size = new Size(144, 21);
			this.TextInactiveForeColorPicker.TabIndex = 1;
			this.TextInactiveFontButton.Location = new Point(72, 16);
			this.TextInactiveFontButton.Name = "TextInactiveFontButton";
			this.TextInactiveFontButton.PropertyName = "TextInactiveFont";
			this.TextInactiveFontButton.TabIndex = 0;
			this.label5.LoadingBegin();
			this.label5.FocusControl = this.MarginNumericUpDown;
			this.label5.Location = new Point(63, 73);
			this.label5.Name = "label5";
			this.label5.Size = new Size(41, 15);
			this.label5.Text = "Margin";
			this.label5.LoadingEnd();
			this.MarginNumericUpDown.Location = new Point(104, 72);
			this.MarginNumericUpDown.Name = "MarginNumericUpDown";
			this.MarginNumericUpDown.PropertyName = "Margin";
			this.MarginNumericUpDown.Size = new Size(48, 20);
			this.MarginNumericUpDown.TabIndex = 2;
			this.MarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.groupBox3.Controls.Add(this.TextMarginNumericUpDown);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.TextAlignmentComboBox);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Location = new Point(24, 120);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(208, 80);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Text";
			this.TextMarginNumericUpDown.Location = new Point(72, 40);
			this.TextMarginNumericUpDown.Name = "TextMarginNumericUpDown";
			this.TextMarginNumericUpDown.PropertyName = "TextMargin";
			this.TextMarginNumericUpDown.Size = new Size(48, 20);
			this.TextMarginNumericUpDown.TabIndex = 1;
			this.TextMarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.TextMarginNumericUpDown;
			this.label1.Location = new Point(31, 41);
			this.label1.Name = "label1";
			this.label1.Size = new Size(41, 15);
			this.label1.Text = "Margin";
			this.label1.LoadingEnd();
			this.TextAlignmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.TextAlignmentComboBox.Location = new Point(72, 16);
			this.TextAlignmentComboBox.Name = "TextAlignmentComboBox";
			this.TextAlignmentComboBox.PropertyName = "TextAlignment";
			this.TextAlignmentComboBox.Size = new Size(121, 21);
			this.TextAlignmentComboBox.TabIndex = 0;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.TextAlignmentComboBox;
			this.label2.Location = new Point(15, 18);
			this.label2.Name = "label2";
			this.label2.Size = new Size(57, 15);
			this.label2.Text = "Alignment";
			this.label2.LoadingEnd();
			this.label6.LoadingBegin();
			this.label6.FocusControl = this.CallOutLengthNumericUpDown;
			this.label6.Location = new Point(20, 49);
			this.label6.Name = "label6";
			this.label6.Size = new Size(84, 15);
			this.label6.Text = "Call Out Length";
			this.label6.LoadingEnd();
			this.CallOutLengthNumericUpDown.Location = new Point(104, 48);
			this.CallOutLengthNumericUpDown.Name = "CallOutLengthNumericUpDown";
			this.CallOutLengthNumericUpDown.PropertyName = "CallOutLength";
			this.CallOutLengthNumericUpDown.Size = new Size(48, 20);
			this.CallOutLengthNumericUpDown.TabIndex = 1;
			this.CallOutLengthNumericUpDown.TextAlign = HorizontalAlignment.Center;
			base.Controls.Add(this.label6);
			base.Controls.Add(this.CallOutLengthNumericUpDown);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.MarginNumericUpDown);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.VisibleCheckBox);
			base.Name = "ScaleDisplayDiscreetAngularEditorPlugIn";
			base.Size = new Size(512, 248);
			base.Title = "Scale Display Editor";
			this.groupBox2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new ScaleDiscreetMarkerEditorPlugIn(), "Markers", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as ScaleDisplayDiscreetAngular).Markers;
		}
	}
}
