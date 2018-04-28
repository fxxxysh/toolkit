using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelBiFillSpecificEditorPlugIn : PlugInStandard
	{
		private EditBox ReferenceTextBox;

		private FocusLabel focusLabel6;

		private Container components;

		public PlotChannelBiFillSpecificEditorPlugIn()
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
			this.ReferenceTextBox = new EditBox();
			this.focusLabel6 = new FocusLabel();
			base.SuspendLayout();
			this.ReferenceTextBox.LoadingBegin();
			this.ReferenceTextBox.Location = new Point(96, 32);
			this.ReferenceTextBox.Name = "ReferenceTextBox";
			this.ReferenceTextBox.PropertyName = "Reference";
			this.ReferenceTextBox.Size = new Size(56, 20);
			this.ReferenceTextBox.TabIndex = 0;
			this.ReferenceTextBox.LoadingEnd();
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.ReferenceTextBox;
			this.focusLabel6.Location = new Point(38, 34);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(58, 15);
			this.focusLabel6.Text = "Reference";
			this.focusLabel6.LoadingEnd();
			base.Controls.Add(this.ReferenceTextBox);
			base.Controls.Add(this.focusLabel6);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelBiFillSpecificEditorPlugIn";
			base.Size = new Size(728, 328);
			base.ResumeLayout(false);
		}
	}
}
