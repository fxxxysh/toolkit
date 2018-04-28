using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PointDoubleEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private EditBox XTextBox;

		private EditBox YTextBox;

		private FocusLabel focusLabel1;

		private Container components;

		public PointDoubleEditorPlugIn()
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
			this.XTextBox = new EditBox();
			this.YTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			base.SuspendLayout();
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.XTextBox;
			this.label2.Location = new Point(57, 10);
			this.label2.Name = "label2";
			this.label2.Size = new Size(15, 15);
			this.label2.Text = "X";
			this.label2.LoadingEnd();
			this.XTextBox.LoadingBegin();
			this.XTextBox.Location = new Point(72, 8);
			this.XTextBox.Name = "XTextBox";
			this.XTextBox.PropertyName = "X";
			this.XTextBox.Size = new Size(104, 20);
			this.XTextBox.TabIndex = 0;
			this.XTextBox.LoadingEnd();
			this.YTextBox.LoadingBegin();
			this.YTextBox.Location = new Point(72, 32);
			this.YTextBox.Name = "YTextBox";
			this.YTextBox.PropertyName = "Y";
			this.YTextBox.Size = new Size(104, 20);
			this.YTextBox.TabIndex = 1;
			this.YTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.YTextBox;
			this.focusLabel1.Location = new Point(57, 34);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(15, 15);
			this.focusLabel1.Text = "Y";
			this.focusLabel1.LoadingEnd();
			base.Controls.Add(this.YTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.XTextBox);
			base.Controls.Add(this.label2);
			base.Name = "PointDoubleEditorPlugIn";
			base.Size = new Size(520, 152);
			base.ResumeLayout(false);
		}
	}
}
