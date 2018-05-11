using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class ScaleRangeDiscreetAngularEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox ReverseCheckBox;

		private GroupBox groupBox1;

		private EditBox AngleMaxTextBox;

		private FocusLabel label6;

		private FocusLabel label5;

		private EditBox AngleSpanTextBox;

		private EditBox AngleMinTextBox;

		private FocusLabel label4;

		private Container components;

		public ScaleRangeDiscreetAngularEditorPlugIn()
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
			this.ReverseCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.groupBox1 = new GroupBox();
			this.AngleMaxTextBox = new EditBox();
			this.AngleSpanTextBox = new EditBox();
			this.AngleMinTextBox = new EditBox();
			this.label4 = new FocusLabel();
			this.label6 = new FocusLabel();
			this.label5 = new FocusLabel();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.ReverseCheckBox.Location = new Point(80, 120);
			this.ReverseCheckBox.Name = "ReverseCheckBox";
			this.ReverseCheckBox.PropertyName = "Reverse";
			this.ReverseCheckBox.Size = new Size(72, 24);
			this.ReverseCheckBox.TabIndex = 1;
			this.ReverseCheckBox.Text = "Reverse";
			this.groupBox1.Controls.Add(this.AngleMaxTextBox);
			this.groupBox1.Controls.Add(this.AngleSpanTextBox);
			this.groupBox1.Controls.Add(this.AngleMinTextBox);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new Point(32, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(120, 104);
			this.groupBox1.TabIndex = 0;
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
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.ReverseCheckBox);
			base.Name = "ScaleRangeDiscreetAngularEditorPlugIn";
			base.Size = new Size(296, 152);
			base.Title = "Scale Range Editor";
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
