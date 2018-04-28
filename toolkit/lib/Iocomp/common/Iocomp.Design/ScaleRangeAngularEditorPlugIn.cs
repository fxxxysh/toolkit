using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class ScaleRangeAngularEditorPlugIn : PlugInStandard
	{
		private FocusLabel label1;

		private FocusLabel label3;

		private EditBox MinTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ReverseCheckBox;

		private FocusLabel label2;

		private EditBox SpanTextBox;

		private EditBox MaxTextBox;

		private GroupBox groupBox1;

		private EditBox AngleMaxTextBox;

		private FocusLabel label6;

		private FocusLabel label5;

		private EditBox AngleSpanTextBox;

		private EditBox AngleMinTextBox;

		private FocusLabel label4;

		private GroupBox LimitGroupBox;

		private FocusLabel focusLabel7;

		private FocusLabel focusLabel6;

		private FocusLabel focusLabel5;

		private FocusLabel focusLabel4;

		private FocusLabel focusLabel3;

		private FocusLabel focusLabel2;

		private FocusLabel focusLabel1;

		private EditBox LimitMinLowerActualEditBox;

		private EditBox LimitMaxUpperActualEditBox;

		private EditBox LimitSpanLowerActualEditBox;

		private EditBox LimitSpanUpperActualEditBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox checkBox1;

		private EditBox LimitSpanUpperValueEditBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LimitSpanUpperEnabledCheckBox;

		private EditBox LimitMaxUpperValueEditBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LimitMaxUpperEnabledCheckBox;

		private EditBox LimitMinLowerValueEditBox;

		private EditBox LimitSpanLowerValueEditBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LimitSpanLowerEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LimitMinLowerEnabledCheckBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ScaleTypeComboBox;

		private GroupBox groupBox2;

		private EditBox SplitPercentEditBox;

		private FocusLabel focusLabel9;

		private EditBox SplitStartTextBox;

		private FocusLabel label8;

		private Container components;

		public ScaleRangeAngularEditorPlugIn()
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
			this.label1 = new FocusLabel();
			this.MinTextBox = new EditBox();
			this.label3 = new FocusLabel();
			this.MaxTextBox = new EditBox();
			this.SpanTextBox = new EditBox();
			this.ReverseCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.label2 = new FocusLabel();
			this.groupBox1 = new GroupBox();
			this.AngleMaxTextBox = new EditBox();
			this.AngleSpanTextBox = new EditBox();
			this.AngleMinTextBox = new EditBox();
			this.label4 = new FocusLabel();
			this.label6 = new FocusLabel();
			this.label5 = new FocusLabel();
			this.LimitGroupBox = new GroupBox();
			this.focusLabel7 = new FocusLabel();
			this.focusLabel6 = new FocusLabel();
			this.focusLabel5 = new FocusLabel();
			this.focusLabel4 = new FocusLabel();
			this.focusLabel3 = new FocusLabel();
			this.focusLabel2 = new FocusLabel();
			this.focusLabel1 = new FocusLabel();
			this.LimitMinLowerActualEditBox = new EditBox();
			this.LimitMaxUpperActualEditBox = new EditBox();
			this.LimitSpanLowerActualEditBox = new EditBox();
			this.LimitSpanUpperActualEditBox = new EditBox();
			this.checkBox1 = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LimitSpanUpperValueEditBox = new EditBox();
			this.LimitSpanUpperEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LimitMaxUpperValueEditBox = new EditBox();
			this.LimitMaxUpperEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LimitMinLowerValueEditBox = new EditBox();
			this.LimitSpanLowerValueEditBox = new EditBox();
			this.LimitSpanLowerEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LimitMinLowerEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.focusLabel8 = new FocusLabel();
			this.ScaleTypeComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.groupBox2 = new GroupBox();
			this.SplitPercentEditBox = new EditBox();
			this.focusLabel9 = new FocusLabel();
			this.SplitStartTextBox = new EditBox();
			this.label8 = new FocusLabel();
			this.groupBox1.SuspendLayout();
			this.LimitGroupBox.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.MinTextBox;
			this.label1.Location = new Point(39, 50);
			this.label1.Name = "label1";
			this.label1.Size = new Size(25, 15);
			this.label1.Text = "Min";
			this.label1.LoadingEnd();
			this.MinTextBox.LoadingBegin();
			this.MinTextBox.Location = new Point(64, 48);
			this.MinTextBox.Name = "MinTextBox";
			this.MinTextBox.PropertyName = "Min";
			this.MinTextBox.Size = new Size(144, 20);
			this.MinTextBox.TabIndex = 0;
			this.MinTextBox.TextAlign = HorizontalAlignment.Center;
			this.MinTextBox.LoadingEnd();
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.MaxTextBox;
			this.label3.Location = new Point(36, 74);
			this.label3.Name = "label3";
			this.label3.Size = new Size(28, 15);
			this.label3.Text = "Max";
			this.label3.LoadingEnd();
			this.MaxTextBox.LoadingBegin();
			this.MaxTextBox.Location = new Point(64, 72);
			this.MaxTextBox.Name = "MaxTextBox";
			this.MaxTextBox.PropertyName = "Max";
			this.MaxTextBox.ReadOnly = true;
			this.MaxTextBox.Size = new Size(144, 20);
			this.MaxTextBox.TabIndex = 1;
			this.MaxTextBox.TextAlign = HorizontalAlignment.Center;
			this.MaxTextBox.LoadingEnd();
			this.SpanTextBox.LoadingBegin();
			this.SpanTextBox.Location = new Point(64, 96);
			this.SpanTextBox.Name = "SpanTextBox";
			this.SpanTextBox.PropertyName = "Span";
			this.SpanTextBox.Size = new Size(144, 20);
			this.SpanTextBox.TabIndex = 2;
			this.SpanTextBox.TextAlign = HorizontalAlignment.Center;
			this.SpanTextBox.LoadingEnd();
			this.ReverseCheckBox.Location = new Point(64, 120);
			this.ReverseCheckBox.Name = "ReverseCheckBox";
			this.ReverseCheckBox.PropertyName = "Reverse";
			this.ReverseCheckBox.Size = new Size(72, 24);
			this.ReverseCheckBox.TabIndex = 3;
			this.ReverseCheckBox.Text = "Reverse";
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.SpanTextBox;
			this.label2.Location = new Point(31, 98);
			this.label2.Name = "label2";
			this.label2.Size = new Size(33, 15);
			this.label2.Text = "Span";
			this.label2.LoadingEnd();
			this.groupBox1.Controls.Add(this.AngleMaxTextBox);
			this.groupBox1.Controls.Add(this.AngleSpanTextBox);
			this.groupBox1.Controls.Add(this.AngleMinTextBox);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new Point(220, 23);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(120, 104);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Angle";
			this.AngleMaxTextBox.LoadingBegin();
			this.AngleMaxTextBox.Location = new Point(48, 48);
			this.AngleMaxTextBox.Name = "AngleMaxTextBox";
			this.AngleMaxTextBox.PropertyName = "AngleMax";
			this.AngleMaxTextBox.ReadOnly = true;
			this.AngleMaxTextBox.Size = new Size(56, 20);
			this.AngleMaxTextBox.TabIndex = 1;
			this.AngleMaxTextBox.TextAlign = HorizontalAlignment.Center;
			this.AngleMaxTextBox.LoadingEnd();
			this.AngleSpanTextBox.LoadingBegin();
			this.AngleSpanTextBox.Location = new Point(48, 72);
			this.AngleSpanTextBox.Name = "AngleSpanTextBox";
			this.AngleSpanTextBox.PropertyName = "AngleSpan";
			this.AngleSpanTextBox.Size = new Size(56, 20);
			this.AngleSpanTextBox.TabIndex = 2;
			this.AngleSpanTextBox.TextAlign = HorizontalAlignment.Center;
			this.AngleSpanTextBox.LoadingEnd();
			this.AngleMinTextBox.LoadingBegin();
			this.AngleMinTextBox.Location = new Point(48, 24);
			this.AngleMinTextBox.Name = "AngleMinTextBox";
			this.AngleMinTextBox.PropertyName = "AngleMin";
			this.AngleMinTextBox.Size = new Size(56, 20);
			this.AngleMinTextBox.TabIndex = 0;
			this.AngleMinTextBox.TextAlign = HorizontalAlignment.Center;
			this.AngleMinTextBox.LoadingEnd();
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.AngleMinTextBox;
			this.label4.Location = new Point(23, 26);
			this.label4.Name = "label4";
			this.label4.Size = new Size(25, 15);
			this.label4.Text = "Min";
			this.label4.LoadingEnd();
			this.label6.LoadingBegin();
			this.label6.FocusControl = this.AngleMaxTextBox;
			this.label6.Location = new Point(20, 50);
			this.label6.Name = "label6";
			this.label6.Size = new Size(28, 15);
			this.label6.Text = "Max";
			this.label6.LoadingEnd();
			this.label5.LoadingBegin();
			this.label5.FocusControl = this.AngleSpanTextBox;
			this.label5.Location = new Point(15, 74);
			this.label5.Name = "label5";
			this.label5.Size = new Size(33, 15);
			this.label5.Text = "Span";
			this.label5.LoadingEnd();
			this.LimitGroupBox.Controls.Add(this.focusLabel7);
			this.LimitGroupBox.Controls.Add(this.focusLabel6);
			this.LimitGroupBox.Controls.Add(this.focusLabel5);
			this.LimitGroupBox.Controls.Add(this.focusLabel4);
			this.LimitGroupBox.Controls.Add(this.focusLabel3);
			this.LimitGroupBox.Controls.Add(this.focusLabel2);
			this.LimitGroupBox.Controls.Add(this.focusLabel1);
			this.LimitGroupBox.Controls.Add(this.LimitMinLowerActualEditBox);
			this.LimitGroupBox.Controls.Add(this.LimitMaxUpperActualEditBox);
			this.LimitGroupBox.Controls.Add(this.LimitSpanLowerActualEditBox);
			this.LimitGroupBox.Controls.Add(this.LimitSpanUpperActualEditBox);
			this.LimitGroupBox.Controls.Add(this.checkBox1);
			this.LimitGroupBox.Controls.Add(this.LimitSpanUpperValueEditBox);
			this.LimitGroupBox.Controls.Add(this.LimitSpanUpperEnabledCheckBox);
			this.LimitGroupBox.Controls.Add(this.LimitMaxUpperValueEditBox);
			this.LimitGroupBox.Controls.Add(this.LimitMaxUpperEnabledCheckBox);
			this.LimitGroupBox.Controls.Add(this.LimitMinLowerValueEditBox);
			this.LimitGroupBox.Controls.Add(this.LimitSpanLowerValueEditBox);
			this.LimitGroupBox.Controls.Add(this.LimitSpanLowerEnabledCheckBox);
			this.LimitGroupBox.Controls.Add(this.LimitMinLowerEnabledCheckBox);
			this.LimitGroupBox.Location = new Point(352, 23);
			this.LimitGroupBox.Name = "LimitGroupBox";
			this.LimitGroupBox.Size = new Size(328, 248);
			this.LimitGroupBox.TabIndex = 7;
			this.LimitGroupBox.TabStop = false;
			this.LimitGroupBox.Text = "Limit";
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.Location = new Point(14, 123);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(66, 15);
			this.focusLabel7.Text = "Span Upper";
			this.focusLabel7.LoadingEnd();
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.Location = new Point(14, 99);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(66, 15);
			this.focusLabel6.Text = "Span Lower";
			this.focusLabel6.LoadingEnd();
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.Location = new Point(22, 75);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(61, 15);
			this.focusLabel5.Text = "Max Upper";
			this.focusLabel5.LoadingEnd();
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.Location = new Point(22, 51);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(58, 15);
			this.focusLabel4.Text = "Min Lower";
			this.focusLabel4.LoadingEnd();
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.Location = new Point(70, 24);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(48, 15);
			this.focusLabel3.Text = "Enabled";
			this.focusLabel3.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.Location = new Point(158, 24);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(36, 15);
			this.focusLabel2.Text = "Value";
			this.focusLabel2.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.Location = new Point(254, 26);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(38, 15);
			this.focusLabel1.Text = "Actual";
			this.focusLabel1.LoadingEnd();
			this.LimitMinLowerActualEditBox.LoadingBegin();
			this.LimitMinLowerActualEditBox.Location = new Point(224, 48);
			this.LimitMinLowerActualEditBox.Name = "LimitMinLowerActualEditBox";
			this.LimitMinLowerActualEditBox.PropertyName = "LimitMinLowerActual";
			this.LimitMinLowerActualEditBox.ReadOnly = true;
			this.LimitMinLowerActualEditBox.Size = new Size(88, 20);
			this.LimitMinLowerActualEditBox.TabIndex = 2;
			this.LimitMinLowerActualEditBox.TextAlign = HorizontalAlignment.Center;
			this.LimitMinLowerActualEditBox.LoadingEnd();
			this.LimitMaxUpperActualEditBox.LoadingBegin();
			this.LimitMaxUpperActualEditBox.Location = new Point(224, 72);
			this.LimitMaxUpperActualEditBox.Name = "LimitMaxUpperActualEditBox";
			this.LimitMaxUpperActualEditBox.PropertyName = "LimitMaxUpperActual";
			this.LimitMaxUpperActualEditBox.ReadOnly = true;
			this.LimitMaxUpperActualEditBox.Size = new Size(88, 20);
			this.LimitMaxUpperActualEditBox.TabIndex = 5;
			this.LimitMaxUpperActualEditBox.TextAlign = HorizontalAlignment.Center;
			this.LimitMaxUpperActualEditBox.LoadingEnd();
			this.LimitSpanLowerActualEditBox.LoadingBegin();
			this.LimitSpanLowerActualEditBox.Location = new Point(224, 96);
			this.LimitSpanLowerActualEditBox.Name = "LimitSpanLowerActualEditBox";
			this.LimitSpanLowerActualEditBox.PropertyName = "LimitSpanLowerActual";
			this.LimitSpanLowerActualEditBox.ReadOnly = true;
			this.LimitSpanLowerActualEditBox.Size = new Size(88, 20);
			this.LimitSpanLowerActualEditBox.TabIndex = 8;
			this.LimitSpanLowerActualEditBox.TextAlign = HorizontalAlignment.Center;
			this.LimitSpanLowerActualEditBox.LoadingEnd();
			this.LimitSpanUpperActualEditBox.LoadingBegin();
			this.LimitSpanUpperActualEditBox.Location = new Point(224, 120);
			this.LimitSpanUpperActualEditBox.Name = "LimitSpanUpperActualEditBox";
			this.LimitSpanUpperActualEditBox.PropertyName = "LimitSpanUpperActual";
			this.LimitSpanUpperActualEditBox.ReadOnly = true;
			this.LimitSpanUpperActualEditBox.Size = new Size(88, 20);
			this.LimitSpanUpperActualEditBox.TabIndex = 11;
			this.LimitSpanUpperActualEditBox.TextAlign = HorizontalAlignment.Center;
			this.LimitSpanUpperActualEditBox.LoadingEnd();
			this.checkBox1.Location = new Point(88, 152);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.PropertyName = "LimitsEnforced";
			this.checkBox1.ReadOnly = true;
			this.checkBox1.TabIndex = 12;
			this.checkBox1.Text = "Limits Enforced";
			this.LimitSpanUpperValueEditBox.LoadingBegin();
			this.LimitSpanUpperValueEditBox.Location = new Point(128, 120);
			this.LimitSpanUpperValueEditBox.Name = "LimitSpanUpperValueEditBox";
			this.LimitSpanUpperValueEditBox.PropertyName = "LimitSpanUpperValue";
			this.LimitSpanUpperValueEditBox.Size = new Size(88, 20);
			this.LimitSpanUpperValueEditBox.TabIndex = 10;
			this.LimitSpanUpperValueEditBox.TextAlign = HorizontalAlignment.Center;
			this.LimitSpanUpperValueEditBox.LoadingEnd();
			this.LimitSpanUpperEnabledCheckBox.Location = new Point(88, 120);
			this.LimitSpanUpperEnabledCheckBox.Name = "LimitSpanUpperEnabledCheckBox";
			this.LimitSpanUpperEnabledCheckBox.PropertyName = "LimitSpanUpperEnabled";
			this.LimitSpanUpperEnabledCheckBox.Size = new Size(24, 24);
			this.LimitSpanUpperEnabledCheckBox.TabIndex = 9;
			this.LimitMaxUpperValueEditBox.LoadingBegin();
			this.LimitMaxUpperValueEditBox.Location = new Point(128, 72);
			this.LimitMaxUpperValueEditBox.Name = "LimitMaxUpperValueEditBox";
			this.LimitMaxUpperValueEditBox.PropertyName = "LimitMaxUpperValue";
			this.LimitMaxUpperValueEditBox.Size = new Size(88, 20);
			this.LimitMaxUpperValueEditBox.TabIndex = 4;
			this.LimitMaxUpperValueEditBox.TextAlign = HorizontalAlignment.Center;
			this.LimitMaxUpperValueEditBox.LoadingEnd();
			this.LimitMaxUpperEnabledCheckBox.Location = new Point(88, 72);
			this.LimitMaxUpperEnabledCheckBox.Name = "LimitMaxUpperEnabledCheckBox";
			this.LimitMaxUpperEnabledCheckBox.PropertyName = "LimitMaxUpperEnabled";
			this.LimitMaxUpperEnabledCheckBox.Size = new Size(24, 24);
			this.LimitMaxUpperEnabledCheckBox.TabIndex = 3;
			this.LimitMinLowerValueEditBox.LoadingBegin();
			this.LimitMinLowerValueEditBox.Location = new Point(128, 48);
			this.LimitMinLowerValueEditBox.Name = "LimitMinLowerValueEditBox";
			this.LimitMinLowerValueEditBox.PropertyName = "LimitMinLowerValue";
			this.LimitMinLowerValueEditBox.Size = new Size(88, 20);
			this.LimitMinLowerValueEditBox.TabIndex = 1;
			this.LimitMinLowerValueEditBox.TextAlign = HorizontalAlignment.Center;
			this.LimitMinLowerValueEditBox.LoadingEnd();
			this.LimitSpanLowerValueEditBox.LoadingBegin();
			this.LimitSpanLowerValueEditBox.Location = new Point(128, 96);
			this.LimitSpanLowerValueEditBox.Name = "LimitSpanLowerValueEditBox";
			this.LimitSpanLowerValueEditBox.PropertyName = "LimitSpanLowerValue";
			this.LimitSpanLowerValueEditBox.Size = new Size(88, 20);
			this.LimitSpanLowerValueEditBox.TabIndex = 7;
			this.LimitSpanLowerValueEditBox.TextAlign = HorizontalAlignment.Center;
			this.LimitSpanLowerValueEditBox.LoadingEnd();
			this.LimitSpanLowerEnabledCheckBox.Location = new Point(88, 96);
			this.LimitSpanLowerEnabledCheckBox.Name = "LimitSpanLowerEnabledCheckBox";
			this.LimitSpanLowerEnabledCheckBox.PropertyName = "LimitSpanLowerEnabled";
			this.LimitSpanLowerEnabledCheckBox.Size = new Size(24, 24);
			this.LimitSpanLowerEnabledCheckBox.TabIndex = 6;
			this.LimitMinLowerEnabledCheckBox.Location = new Point(88, 48);
			this.LimitMinLowerEnabledCheckBox.Name = "LimitMinLowerEnabledCheckBox";
			this.LimitMinLowerEnabledCheckBox.PropertyName = "LimitMinLowerEnabled";
			this.LimitMinLowerEnabledCheckBox.Size = new Size(24, 24);
			this.LimitMinLowerEnabledCheckBox.TabIndex = 0;
			this.focusLabel8.LoadingBegin();
			this.focusLabel8.FocusControl = this.ScaleTypeComboBox;
			this.focusLabel8.Location = new Point(2, 154);
			this.focusLabel8.Name = "focusLabel8";
			this.focusLabel8.Size = new Size(62, 15);
			this.focusLabel8.Text = "Scale Type";
			this.focusLabel8.LoadingEnd();
			this.ScaleTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ScaleTypeComboBox.Location = new Point(64, 152);
			this.ScaleTypeComboBox.Name = "ScaleTypeComboBox";
			this.ScaleTypeComboBox.PropertyName = "ScaleType";
			this.ScaleTypeComboBox.Size = new Size(112, 21);
			this.ScaleTypeComboBox.TabIndex = 4;
			this.groupBox2.Controls.Add(this.SplitPercentEditBox);
			this.groupBox2.Controls.Add(this.focusLabel9);
			this.groupBox2.Controls.Add(this.SplitStartTextBox);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Location = new Point(64, 184);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(152, 72);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Split";
			this.SplitPercentEditBox.LoadingBegin();
			this.SplitPercentEditBox.Location = new Point(56, 40);
			this.SplitPercentEditBox.Name = "SplitPercentEditBox";
			this.SplitPercentEditBox.PropertyName = "SplitPercent";
			this.SplitPercentEditBox.Size = new Size(80, 20);
			this.SplitPercentEditBox.TabIndex = 1;
			this.SplitPercentEditBox.LoadingEnd();
			this.focusLabel9.LoadingBegin();
			this.focusLabel9.FocusControl = this.SplitPercentEditBox;
			this.focusLabel9.Location = new Point(11, 42);
			this.focusLabel9.Name = "focusLabel9";
			this.focusLabel9.Size = new Size(45, 15);
			this.focusLabel9.Text = "Percent";
			this.focusLabel9.LoadingEnd();
			this.SplitStartTextBox.LoadingBegin();
			this.SplitStartTextBox.Location = new Point(56, 16);
			this.SplitStartTextBox.Name = "SplitStartTextBox";
			this.SplitStartTextBox.PropertyName = "SplitStart";
			this.SplitStartTextBox.Size = new Size(80, 20);
			this.SplitStartTextBox.TabIndex = 0;
			this.SplitStartTextBox.LoadingEnd();
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.SplitStartTextBox;
			this.label8.Location = new Point(25, 18);
			this.label8.Name = "label8";
			this.label8.Size = new Size(31, 15);
			this.label8.Text = "Start";
			this.label8.LoadingEnd();
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.focusLabel8);
			base.Controls.Add(this.ScaleTypeComboBox);
			base.Controls.Add(this.LimitGroupBox);
			base.Controls.Add(this.MaxTextBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.ReverseCheckBox);
			base.Controls.Add(this.SpanTextBox);
			base.Controls.Add(this.MinTextBox);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			base.Name = "ScaleRangeAngularEditorPlugIn";
			base.Size = new Size(704, 320);
			base.Title = "Scale Range Editor";
			this.groupBox1.ResumeLayout(false);
			this.LimitGroupBox.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
