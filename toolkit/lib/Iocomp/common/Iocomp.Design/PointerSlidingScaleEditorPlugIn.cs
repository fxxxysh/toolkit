using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PointerSlidingScaleEditorPlugIn : PlugInStandard
	{
		private FocusLabel label4;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private FocusLabel label6;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SizeNumericUpDown;

		private FocusLabel label2;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LineWidthNumericUpDown;

		private FocusLabel label9;

		private ColorPicker ColorPicker;

		private ColorPicker LineColorPicker;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private Container components;

		public PointerSlidingScaleEditorPlugIn()
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
			this.ColorPicker = new ColorPicker();
			this.label4 = new FocusLabel();
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label6 = new FocusLabel();
			this.SizeNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label2 = new FocusLabel();
			this.LineColorPicker = new ColorPicker();
			this.label1 = new FocusLabel();
			this.LineWidthNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label9 = new FocusLabel();
			this.NameTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			base.SuspendLayout();
			this.ColorPicker.Location = new Point(72, 192);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(144, 21);
			this.ColorPicker.TabIndex = 6;
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.ColorPicker;
			this.label4.Location = new Point(38, 195);
			this.label4.Name = "label4";
			this.label4.Size = new Size(34, 15);
			this.label4.Text = "Color";
			this.label4.LoadingEnd();
			this.VisibleCheckBox.Location = new Point(72, 16);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StyleComboBox.Location = new Point(72, 80);
			this.StyleComboBox.Name = "StyleComboBox";
			this.StyleComboBox.PropertyName = "Style";
			this.StyleComboBox.Size = new Size(121, 21);
			this.StyleComboBox.TabIndex = 2;
			this.label6.LoadingBegin();
			this.label6.FocusControl = this.StyleComboBox;
			this.label6.Location = new Point(40, 82);
			this.label6.Name = "label6";
			this.label6.Size = new Size(32, 15);
			this.label6.Text = "Style";
			this.label6.LoadingEnd();
			this.SizeNumericUpDown.Location = new Point(72, 112);
			this.SizeNumericUpDown.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				-2147483648
			});
			this.SizeNumericUpDown.Name = "SizeNumericUpDown";
			this.SizeNumericUpDown.PropertyName = "Size";
			this.SizeNumericUpDown.Size = new Size(48, 20);
			this.SizeNumericUpDown.TabIndex = 3;
			this.SizeNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.SizeNumericUpDown;
			this.label2.Location = new Point(43, 113);
			this.label2.Name = "label2";
			this.label2.Size = new Size(29, 15);
			this.label2.Text = "Size";
			this.label2.LoadingEnd();
			this.LineColorPicker.Location = new Point(72, 168);
			this.LineColorPicker.Name = "LineColorPicker";
			this.LineColorPicker.PropertyName = "LineColor";
			this.LineColorPicker.Size = new Size(144, 21);
			this.LineColorPicker.TabIndex = 5;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.LineColorPicker;
			this.label1.Location = new Point(14, 171);
			this.label1.Name = "label1";
			this.label1.Size = new Size(58, 15);
			this.label1.Text = "Line Color";
			this.label1.LoadingEnd();
			this.LineWidthNumericUpDown.Location = new Point(72, 136);
			this.LineWidthNumericUpDown.Minimum = new decimal(new int[4]
			{
				1,
				0,
				0,
				-2147483648
			});
			this.LineWidthNumericUpDown.Name = "LineWidthNumericUpDown";
			this.LineWidthNumericUpDown.PropertyName = "LineWidth";
			this.LineWidthNumericUpDown.Size = new Size(48, 20);
			this.LineWidthNumericUpDown.TabIndex = 4;
			this.LineWidthNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label9.LoadingBegin();
			this.label9.FocusControl = this.LineWidthNumericUpDown;
			this.label9.Location = new Point(13, 137);
			this.label9.Name = "label9";
			this.label9.Size = new Size(59, 15);
			this.label9.Text = "Line Width";
			this.label9.LoadingEnd();
			this.NameTextBox.LoadingBegin();
			this.NameTextBox.Location = new Point(72, 48);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.PropertyName = "Value";
			this.NameTextBox.Size = new Size(136, 20);
			this.NameTextBox.TabIndex = 1;
			this.NameTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.NameTextBox;
			this.focusLabel1.Location = new Point(36, 50);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(36, 15);
			this.focusLabel1.Text = "Value";
			this.focusLabel1.LoadingEnd();
			base.Controls.Add(this.NameTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.LineWidthNumericUpDown);
			base.Controls.Add(this.label9);
			base.Controls.Add(this.LineColorPicker);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.SizeNumericUpDown);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.StyleComboBox);
			base.Controls.Add(this.label6);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label4);
			base.Name = "PointerSlidingScaleEditorPlugIn";
			base.Size = new Size(248, 256);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new ValueDoubleEditorPlugIn(), "Value", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PointerSlidingScale).Value;
		}
	}
}
