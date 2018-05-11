using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotChannelImageSpecificEditorPlugIn : PlugInStandard
	{
		private GroupBox ImageXGroupBox;

		private FocusLabel focusLabel7;

		private GroupBox ImageYGroupBox;

		private FocusLabel focusLabel5;

		private FocusLabel focusLabel6;

		private EditBox ImageXSpanEditBox;

		private FocusLabel focusLabel2;

		private EditBox ImageXMinEditBox;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel8;

		private EditBox ImageYSpanEditBox;

		private FocusLabel focusLabel3;

		private EditBox ImageYMinEditBox;

		private FocusLabel focusLabel4;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ImageXAutoSetupCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ImageYAutoSetupCheckBox;

		private EditBox ImageXSpanSamplesEditBox;

		private EditBox ImageXSamplesTextBox;

		private EditBox ImageYSpanSamplesEditBox;

		private EditBox ImageYSamplesTextBox;

		private Container components;

		public PlotChannelImageSpecificEditorPlugIn()
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
			this.ImageXGroupBox = new GroupBox();
			this.ImageXAutoSetupCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ImageXSpanSamplesEditBox = new EditBox();
			this.focusLabel6 = new FocusLabel();
			this.ImageXSpanEditBox = new EditBox();
			this.focusLabel2 = new FocusLabel();
			this.ImageXMinEditBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.ImageXSamplesTextBox = new EditBox();
			this.focusLabel7 = new FocusLabel();
			this.ImageYGroupBox = new GroupBox();
			this.ImageYAutoSetupCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ImageYSpanSamplesEditBox = new EditBox();
			this.focusLabel8 = new FocusLabel();
			this.ImageYSpanEditBox = new EditBox();
			this.focusLabel3 = new FocusLabel();
			this.ImageYMinEditBox = new EditBox();
			this.focusLabel4 = new FocusLabel();
			this.ImageYSamplesTextBox = new EditBox();
			this.focusLabel5 = new FocusLabel();
			this.ImageXGroupBox.SuspendLayout();
			this.ImageYGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.ImageXGroupBox.Controls.Add(this.ImageXAutoSetupCheckBox);
			this.ImageXGroupBox.Controls.Add(this.ImageXSpanSamplesEditBox);
			this.ImageXGroupBox.Controls.Add(this.focusLabel6);
			this.ImageXGroupBox.Controls.Add(this.ImageXSpanEditBox);
			this.ImageXGroupBox.Controls.Add(this.focusLabel2);
			this.ImageXGroupBox.Controls.Add(this.ImageXMinEditBox);
			this.ImageXGroupBox.Controls.Add(this.focusLabel1);
			this.ImageXGroupBox.Controls.Add(this.ImageXSamplesTextBox);
			this.ImageXGroupBox.Controls.Add(this.focusLabel7);
			this.ImageXGroupBox.Location = new Point(16, 16);
			this.ImageXGroupBox.Name = "ImageXGroupBox";
			this.ImageXGroupBox.Size = new Size(160, 168);
			this.ImageXGroupBox.TabIndex = 0;
			this.ImageXGroupBox.TabStop = false;
			this.ImageXGroupBox.Text = "X";
			this.ImageXAutoSetupCheckBox.Location = new Point(24, 24);
			this.ImageXAutoSetupCheckBox.Name = "ImageXAutoSetupCheckBox";
			this.ImageXAutoSetupCheckBox.PropertyName = "ImageXAutoSetup";
			this.ImageXAutoSetupCheckBox.TabIndex = 0;
			this.ImageXAutoSetupCheckBox.Text = "Auto Setup";
			this.ImageXSpanSamplesEditBox.LoadingBegin();
			this.ImageXSpanSamplesEditBox.Location = new Point(80, 88);
			this.ImageXSpanSamplesEditBox.Name = "ImageXSpanSamplesEditBox";
			this.ImageXSpanSamplesEditBox.PropertyName = "ImageXSpanSamples";
			this.ImageXSpanSamplesEditBox.Size = new Size(56, 20);
			this.ImageXSpanSamplesEditBox.TabIndex = 2;
			this.ImageXSpanSamplesEditBox.LoadingEnd();
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.ImageXSpanSamplesEditBox;
			this.focusLabel6.Location = new Point(1, 90);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(79, 15);
			this.focusLabel6.Text = "Span Samples";
			this.focusLabel6.LoadingEnd();
			this.ImageXSpanEditBox.LoadingBegin();
			this.ImageXSpanEditBox.Location = new Point(80, 112);
			this.ImageXSpanEditBox.Name = "ImageXSpanEditBox";
			this.ImageXSpanEditBox.PropertyName = "ImageXSpan";
			this.ImageXSpanEditBox.Size = new Size(56, 20);
			this.ImageXSpanEditBox.TabIndex = 3;
			this.ImageXSpanEditBox.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.ImageXSpanEditBox;
			this.focusLabel2.Location = new Point(47, 114);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(33, 15);
			this.focusLabel2.Text = "Span";
			this.focusLabel2.LoadingEnd();
			this.ImageXMinEditBox.LoadingBegin();
			this.ImageXMinEditBox.Location = new Point(80, 136);
			this.ImageXMinEditBox.Name = "ImageXMinEditBox";
			this.ImageXMinEditBox.PropertyName = "ImageXMin";
			this.ImageXMinEditBox.Size = new Size(56, 20);
			this.ImageXMinEditBox.TabIndex = 4;
			this.ImageXMinEditBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.ImageXMinEditBox;
			this.focusLabel1.Location = new Point(55, 138);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(25, 15);
			this.focusLabel1.Text = "Min";
			this.focusLabel1.LoadingEnd();
			this.ImageXSamplesTextBox.LoadingBegin();
			this.ImageXSamplesTextBox.Location = new Point(80, 56);
			this.ImageXSamplesTextBox.Name = "ImageXSamplesTextBox";
			this.ImageXSamplesTextBox.PropertyName = "ImageXSamples";
			this.ImageXSamplesTextBox.Size = new Size(56, 20);
			this.ImageXSamplesTextBox.TabIndex = 1;
			this.ImageXSamplesTextBox.LoadingEnd();
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.ImageXSamplesTextBox;
			this.focusLabel7.Location = new Point(30, 58);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(50, 15);
			this.focusLabel7.Text = "Samples";
			this.focusLabel7.LoadingEnd();
			this.ImageYGroupBox.Controls.Add(this.ImageYAutoSetupCheckBox);
			this.ImageYGroupBox.Controls.Add(this.ImageYSpanSamplesEditBox);
			this.ImageYGroupBox.Controls.Add(this.focusLabel8);
			this.ImageYGroupBox.Controls.Add(this.ImageYSpanEditBox);
			this.ImageYGroupBox.Controls.Add(this.focusLabel3);
			this.ImageYGroupBox.Controls.Add(this.ImageYMinEditBox);
			this.ImageYGroupBox.Controls.Add(this.focusLabel4);
			this.ImageYGroupBox.Controls.Add(this.ImageYSamplesTextBox);
			this.ImageYGroupBox.Controls.Add(this.focusLabel5);
			this.ImageYGroupBox.Location = new Point(192, 16);
			this.ImageYGroupBox.Name = "ImageYGroupBox";
			this.ImageYGroupBox.Size = new Size(160, 168);
			this.ImageYGroupBox.TabIndex = 1;
			this.ImageYGroupBox.TabStop = false;
			this.ImageYGroupBox.Text = "Y";
			this.ImageYAutoSetupCheckBox.Location = new Point(24, 24);
			this.ImageYAutoSetupCheckBox.Name = "ImageYAutoSetupCheckBox";
			this.ImageYAutoSetupCheckBox.PropertyName = "ImageYAutoSetup";
			this.ImageYAutoSetupCheckBox.TabIndex = 0;
			this.ImageYAutoSetupCheckBox.Text = "Auto Setup";
			this.ImageYSpanSamplesEditBox.LoadingBegin();
			this.ImageYSpanSamplesEditBox.Location = new Point(80, 88);
			this.ImageYSpanSamplesEditBox.Name = "ImageYSpanSamplesEditBox";
			this.ImageYSpanSamplesEditBox.PropertyName = "ImageYSpanSamples";
			this.ImageYSpanSamplesEditBox.Size = new Size(56, 20);
			this.ImageYSpanSamplesEditBox.TabIndex = 2;
			this.ImageYSpanSamplesEditBox.LoadingEnd();
			this.focusLabel8.LoadingBegin();
			this.focusLabel8.FocusControl = this.ImageYSpanSamplesEditBox;
			this.focusLabel8.Location = new Point(1, 90);
			this.focusLabel8.Name = "focusLabel8";
			this.focusLabel8.Size = new Size(79, 15);
			this.focusLabel8.Text = "Span Samples";
			this.focusLabel8.LoadingEnd();
			this.ImageYSpanEditBox.LoadingBegin();
			this.ImageYSpanEditBox.Location = new Point(80, 112);
			this.ImageYSpanEditBox.Name = "ImageYSpanEditBox";
			this.ImageYSpanEditBox.PropertyName = "ImageYSpan";
			this.ImageYSpanEditBox.Size = new Size(56, 20);
			this.ImageYSpanEditBox.TabIndex = 3;
			this.ImageYSpanEditBox.LoadingEnd();
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.ImageYSpanEditBox;
			this.focusLabel3.Location = new Point(47, 114);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(33, 15);
			this.focusLabel3.Text = "Span";
			this.focusLabel3.LoadingEnd();
			this.ImageYMinEditBox.LoadingBegin();
			this.ImageYMinEditBox.Location = new Point(80, 136);
			this.ImageYMinEditBox.Name = "ImageYMinEditBox";
			this.ImageYMinEditBox.PropertyName = "ImageYMin";
			this.ImageYMinEditBox.Size = new Size(56, 20);
			this.ImageYMinEditBox.TabIndex = 4;
			this.ImageYMinEditBox.LoadingEnd();
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.ImageYMinEditBox;
			this.focusLabel4.Location = new Point(55, 138);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(25, 15);
			this.focusLabel4.Text = "Min";
			this.focusLabel4.LoadingEnd();
			this.ImageYSamplesTextBox.LoadingBegin();
			this.ImageYSamplesTextBox.Location = new Point(80, 56);
			this.ImageYSamplesTextBox.Name = "ImageYSamplesTextBox";
			this.ImageYSamplesTextBox.PropertyName = "ImageYSamples";
			this.ImageYSamplesTextBox.Size = new Size(56, 20);
			this.ImageYSamplesTextBox.TabIndex = 1;
			this.ImageYSamplesTextBox.LoadingEnd();
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.ImageYSamplesTextBox;
			this.focusLabel5.Location = new Point(30, 58);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(50, 15);
			this.focusLabel5.Text = "Samples";
			this.focusLabel5.LoadingEnd();
			base.Controls.Add(this.ImageYGroupBox);
			base.Controls.Add(this.ImageXGroupBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelImageSpecificEditorPlugIn";
			base.Size = new Size(400, 240);
			this.ImageXGroupBox.ResumeLayout(false);
			this.ImageYGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
