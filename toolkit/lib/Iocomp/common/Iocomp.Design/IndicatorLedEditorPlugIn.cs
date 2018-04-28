using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public sealed class IndicatorLedEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private FocusLabel label1;

		private GroupBox groupBox2;

		private FocusLabel label6;

		private FocusLabel label7;

		private ColorPicker ColorActiveColorPicker;

		private GroupBox groupBox3;

		private FocusLabel label8;

		private FocusLabel label9;

		private ColorPicker TextColorActiveColorPicker;

		private Iocomp.Design.Plugin.EditorControls.ComboBox Style3DComboBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private EditMultiLine TextEditMultiLine;

		private FocusLabel label11;

		private ColorPicker ColorInactiveColorPicker;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ColorInactiveAutoCheckBox;

		private ColorPicker TextColorInactiveColorPicker;

		private Container components;

		public IndicatorLedEditorPlugIn()
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
			this.StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label1 = new FocusLabel();
			this.Style3DComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.groupBox2 = new GroupBox();
			this.label6 = new FocusLabel();
			this.ColorInactiveColorPicker = new ColorPicker();
			this.label7 = new FocusLabel();
			this.ColorActiveColorPicker = new ColorPicker();
			this.ColorInactiveAutoCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.groupBox3 = new GroupBox();
			this.label8 = new FocusLabel();
			this.TextColorInactiveColorPicker = new ColorPicker();
			this.label9 = new FocusLabel();
			this.TextColorActiveColorPicker = new ColorPicker();
			this.TextEditMultiLine = new EditMultiLine();
			this.label11 = new FocusLabel();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			base.SuspendLayout();
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.StyleComboBox;
			this.label2.Location = new Point(40, 10);
			this.label2.Name = "label2";
			this.label2.Size = new Size(32, 15);
			this.label2.Text = "Style";
			this.label2.LoadingEnd();
			this.StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StyleComboBox.Location = new Point(72, 8);
			this.StyleComboBox.Name = "StyleComboBox";
			this.StyleComboBox.PropertyName = "Style";
			this.StyleComboBox.Size = new Size(121, 21);
			this.StyleComboBox.TabIndex = 0;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.Style3DComboBox;
			this.label1.Location = new Point(26, 34);
			this.label1.Name = "label1";
			this.label1.Size = new Size(46, 15);
			this.label1.Text = "Style3D";
			this.label1.LoadingEnd();
			this.Style3DComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.Style3DComboBox.Location = new Point(72, 32);
			this.Style3DComboBox.Name = "Style3DComboBox";
			this.Style3DComboBox.PropertyName = "Style3D";
			this.Style3DComboBox.Size = new Size(121, 21);
			this.Style3DComboBox.TabIndex = 1;
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.ColorInactiveColorPicker);
			this.groupBox2.Controls.Add(this.ColorActiveColorPicker);
			this.groupBox2.Controls.Add(this.ColorInactiveAutoCheckBox);
			this.groupBox2.Location = new Point(16, 72);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(216, 104);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Color";
			this.label6.LoadingBegin();
			this.label6.FocusControl = this.ColorInactiveColorPicker;
			this.label6.Location = new Point(11, 49);
			this.label6.Name = "label6";
			this.label6.Size = new Size(45, 15);
			this.label6.Text = "Inactive";
			this.label6.LoadingEnd();
			this.ColorInactiveColorPicker.Location = new Point(56, 46);
			this.ColorInactiveColorPicker.Name = "ColorInactiveColorPicker";
			this.ColorInactiveColorPicker.PropertyName = "ColorInactive";
			this.ColorInactiveColorPicker.Size = new Size(144, 21);
			this.ColorInactiveColorPicker.TabIndex = 1;
			this.label7.LoadingBegin();
			this.label7.FocusControl = this.ColorActiveColorPicker;
			this.label7.Location = new Point(18, 23);
			this.label7.Name = "label7";
			this.label7.Size = new Size(38, 15);
			this.label7.Text = "Active";
			this.label7.LoadingEnd();
			this.ColorActiveColorPicker.Location = new Point(56, 20);
			this.ColorActiveColorPicker.Name = "ColorActiveColorPicker";
			this.ColorActiveColorPicker.PropertyName = "ColorActive";
			this.ColorActiveColorPicker.Size = new Size(144, 21);
			this.ColorActiveColorPicker.TabIndex = 0;
			this.ColorInactiveAutoCheckBox.Location = new Point(56, 72);
			this.ColorInactiveAutoCheckBox.Name = "ColorInactiveAutoCheckBox";
			this.ColorInactiveAutoCheckBox.PropertyName = "ColorInactiveAuto";
			this.ColorInactiveAutoCheckBox.Size = new Size(120, 24);
			this.ColorInactiveAutoCheckBox.TabIndex = 2;
			this.ColorInactiveAutoCheckBox.Text = "Inactive Auto";
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.label9);
			this.groupBox3.Controls.Add(this.TextColorInactiveColorPicker);
			this.groupBox3.Controls.Add(this.TextColorActiveColorPicker);
			this.groupBox3.Location = new Point(264, 72);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(248, 72);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Text";
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.TextColorInactiveColorPicker;
			this.label8.Location = new Point(13, 49);
			this.label8.Name = "label8";
			this.label8.Size = new Size(75, 15);
			this.label8.Text = "Color Inactive";
			this.label8.LoadingEnd();
			this.TextColorInactiveColorPicker.Location = new Point(88, 46);
			this.TextColorInactiveColorPicker.Name = "TextColorInactiveColorPicker";
			this.TextColorInactiveColorPicker.PropertyName = "TextColorInactive";
			this.TextColorInactiveColorPicker.Size = new Size(144, 21);
			this.TextColorInactiveColorPicker.TabIndex = 1;
			this.label9.LoadingBegin();
			this.label9.FocusControl = this.TextColorActiveColorPicker;
			this.label9.Location = new Point(21, 23);
			this.label9.Name = "label9";
			this.label9.Size = new Size(67, 15);
			this.label9.Text = "Color Active";
			this.label9.LoadingEnd();
			this.TextColorActiveColorPicker.Location = new Point(88, 20);
			this.TextColorActiveColorPicker.Name = "TextColorActiveColorPicker";
			this.TextColorActiveColorPicker.PropertyName = "TextColorActive";
			this.TextColorActiveColorPicker.Size = new Size(144, 21);
			this.TextColorActiveColorPicker.TabIndex = 0;
			this.TextEditMultiLine.EditFont = null;
			this.TextEditMultiLine.Location = new Point(264, 8);
			this.TextEditMultiLine.Name = "TextEditMultiLine";
			this.TextEditMultiLine.PropertyName = "Text";
			this.TextEditMultiLine.Size = new Size(176, 20);
			this.TextEditMultiLine.TabIndex = 2;
			this.label11.LoadingBegin();
			this.label11.FocusControl = this.TextEditMultiLine;
			this.label11.Location = new Point(235, 11);
			this.label11.Name = "label11";
			this.label11.Size = new Size(29, 15);
			this.label11.Text = "Text";
			this.label11.LoadingEnd();
			base.Controls.Add(this.label11);
			base.Controls.Add(this.TextEditMultiLine);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.StyleComboBox);
			base.Controls.Add(this.Style3DComboBox);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label2);
			base.Location = new Point(10, 20);
			base.Name = "IndicatorLedEditorPlugIn";
			base.Size = new Size(536, 192);
			base.Title = "Indicator Editor";
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new BevelThickEditorPlugIn(), "Bezel", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as IndicatorLed).Bezel;
		}
	}
}
