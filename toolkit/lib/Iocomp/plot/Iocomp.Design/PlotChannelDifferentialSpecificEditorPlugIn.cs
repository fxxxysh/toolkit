using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotChannelDifferentialSpecificEditorPlugIn : PlugInStandard
	{
		private CheckBox TerminatedCheckBox;

		private EditBox ReferenceTextBox;

		private FocusLabel focusLabel6;

		private Container components;

		public PlotChannelDifferentialSpecificEditorPlugIn()
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
			this.TerminatedCheckBox = new CheckBox();
			this.ReferenceTextBox = new EditBox();
			this.focusLabel6 = new FocusLabel();
			base.SuspendLayout();
			this.TerminatedCheckBox.Location = new Point(88, 16);
			this.TerminatedCheckBox.Name = "TerminatedCheckBox";
			this.TerminatedCheckBox.PropertyName = "Terminated";
			this.TerminatedCheckBox.Size = new Size(96, 24);
			this.TerminatedCheckBox.TabIndex = 0;
			this.TerminatedCheckBox.Text = "Terminated";
			this.ReferenceTextBox.LoadingBegin();
			this.ReferenceTextBox.Location = new Point(88, 48);
			this.ReferenceTextBox.Name = "ReferenceTextBox";
			this.ReferenceTextBox.PropertyName = "Reference";
			this.ReferenceTextBox.Size = new Size(56, 20);
			this.ReferenceTextBox.TabIndex = 1;
			this.ReferenceTextBox.LoadingEnd();
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.ReferenceTextBox;
			this.focusLabel6.Location = new Point(30, 50);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(58, 15);
			this.focusLabel6.Text = "Reference";
			this.focusLabel6.LoadingEnd();
			base.Controls.Add(this.TerminatedCheckBox);
			base.Controls.Add(this.ReferenceTextBox);
			base.Controls.Add(this.focusLabel6);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelDifferentialSpecificEditorPlugIn";
			base.Size = new Size(512, 200);
			base.ResumeLayout(false);
		}
	}
}
