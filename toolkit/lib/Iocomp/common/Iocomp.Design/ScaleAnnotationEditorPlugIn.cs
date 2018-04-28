using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class ScaleAnnotationEditorPlugIn : PlugInStandard
	{
		private EditBox SpanYTextBox;

		private EditBox SpanXTextBox;

		private GroupBox groupBox1;

		private GroupBox groupBox2;

		private FocusLabel label1;

		private FocusLabel label2;

		private FocusLabel label3;

		private FocusLabel label4;

		private EditBox OriginXTextBox;

		private EditBox OriginYTextBox;

		private Container components;

		public ScaleAnnotationEditorPlugIn()
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
			this.OriginXTextBox = new EditBox();
			this.OriginYTextBox = new EditBox();
			this.SpanYTextBox = new EditBox();
			this.SpanXTextBox = new EditBox();
			this.groupBox1 = new GroupBox();
			this.label2 = new FocusLabel();
			this.label1 = new FocusLabel();
			this.groupBox2 = new GroupBox();
			this.label3 = new FocusLabel();
			this.label4 = new FocusLabel();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.OriginXTextBox.LoadingBegin();
			this.OriginXTextBox.Location = new Point(24, 24);
			this.OriginXTextBox.Name = "OriginXTextBox";
			this.OriginXTextBox.PropertyName = "OriginX";
			this.OriginXTextBox.Size = new Size(48, 20);
			this.OriginXTextBox.TabIndex = 0;
			this.OriginXTextBox.TextAlign = HorizontalAlignment.Center;
			this.OriginXTextBox.LoadingEnd();
			this.OriginYTextBox.LoadingBegin();
			this.OriginYTextBox.Location = new Point(104, 24);
			this.OriginYTextBox.Name = "OriginYTextBox";
			this.OriginYTextBox.PropertyName = "OriginY";
			this.OriginYTextBox.Size = new Size(48, 20);
			this.OriginYTextBox.TabIndex = 1;
			this.OriginYTextBox.TextAlign = HorizontalAlignment.Center;
			this.OriginYTextBox.LoadingEnd();
			this.SpanYTextBox.LoadingBegin();
			this.SpanYTextBox.Location = new Point(104, 24);
			this.SpanYTextBox.Name = "SpanYTextBox";
			this.SpanYTextBox.PropertyName = "SpanY";
			this.SpanYTextBox.Size = new Size(48, 20);
			this.SpanYTextBox.TabIndex = 1;
			this.SpanYTextBox.TextAlign = HorizontalAlignment.Center;
			this.SpanYTextBox.LoadingEnd();
			this.SpanXTextBox.LoadingBegin();
			this.SpanXTextBox.Location = new Point(24, 24);
			this.SpanXTextBox.Name = "SpanXTextBox";
			this.SpanXTextBox.PropertyName = "SpanX";
			this.SpanXTextBox.Size = new Size(48, 20);
			this.SpanXTextBox.TabIndex = 0;
			this.SpanXTextBox.TextAlign = HorizontalAlignment.Center;
			this.SpanXTextBox.LoadingEnd();
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.OriginYTextBox);
			this.groupBox1.Controls.Add(this.OriginXTextBox);
			this.groupBox1.Location = new Point(104, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(168, 56);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Origin";
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.OriginYTextBox;
			this.label2.Location = new Point(89, 26);
			this.label2.Name = "label2";
			this.label2.Size = new Size(15, 15);
			this.label2.Text = "Y";
			this.label2.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.OriginXTextBox;
			this.label1.Location = new Point(9, 26);
			this.label1.Name = "label1";
			this.label1.Size = new Size(15, 15);
			this.label1.Text = "X";
			this.label1.LoadingEnd();
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.SpanXTextBox);
			this.groupBox2.Controls.Add(this.SpanYTextBox);
			this.groupBox2.Location = new Point(104, 96);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(168, 56);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Span";
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.SpanYTextBox;
			this.label3.Location = new Point(89, 26);
			this.label3.Name = "label3";
			this.label3.Size = new Size(15, 15);
			this.label3.Text = "Y";
			this.label3.LoadingEnd();
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.SpanXTextBox;
			this.label4.Location = new Point(9, 26);
			this.label4.Name = "label4";
			this.label4.Size = new Size(15, 15);
			this.label4.Text = "X";
			this.label4.LoadingEnd();
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Name = "ScaleAnnotationEditorPlugIn";
			base.Size = new Size(512, 328);
			base.Title = "Display Editor";
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
