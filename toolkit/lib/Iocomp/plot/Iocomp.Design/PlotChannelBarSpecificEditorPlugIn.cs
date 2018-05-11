using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelBarSpecificEditorPlugIn : PlugInStandard
	{
		private EditBox ReferenceTextBox;

		private FocusLabel focusLabel7;

		private EditBox WidthTextBox;

		private FocusLabel focusLabel6;

		private FocusLabel label4;

		private ComboBox WidthStyleComboBox;

		private Container components;

		public PlotChannelBarSpecificEditorPlugIn()
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
			this.focusLabel7 = new FocusLabel();
			this.WidthTextBox = new EditBox();
			this.focusLabel6 = new FocusLabel();
			this.label4 = new FocusLabel();
			this.WidthStyleComboBox = new ComboBox();
			base.SuspendLayout();
			this.ReferenceTextBox.LoadingBegin();
			this.ReferenceTextBox.Location = new Point(96, 32);
			this.ReferenceTextBox.Name = "ReferenceTextBox";
			this.ReferenceTextBox.PropertyName = "Reference";
			this.ReferenceTextBox.Size = new Size(56, 20);
			this.ReferenceTextBox.TabIndex = 0;
			this.ReferenceTextBox.LoadingEnd();
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.ReferenceTextBox;
			this.focusLabel7.Location = new Point(38, 34);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(58, 15);
			this.focusLabel7.Text = "Reference";
			this.focusLabel7.LoadingEnd();
			this.WidthTextBox.LoadingBegin();
			this.WidthTextBox.Location = new Point(96, 56);
			this.WidthTextBox.Name = "WidthTextBox";
			this.WidthTextBox.PropertyName = "Width";
			this.WidthTextBox.Size = new Size(56, 20);
			this.WidthTextBox.TabIndex = 1;
			this.WidthTextBox.LoadingEnd();
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.WidthTextBox;
			this.focusLabel6.Location = new Point(60, 58);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(36, 15);
			this.focusLabel6.Text = "Width";
			this.focusLabel6.LoadingEnd();
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.WidthStyleComboBox;
			this.label4.Location = new Point(169, 58);
			this.label4.Name = "label4";
			this.label4.Size = new Size(63, 15);
			this.label4.Text = "Width Style";
			this.label4.LoadingEnd();
			this.WidthStyleComboBox.Location = new Point(232, 56);
			this.WidthStyleComboBox.Name = "WidthStyleComboBox";
			this.WidthStyleComboBox.PropertyName = "WidthStyle";
			this.WidthStyleComboBox.Size = new Size(121, 21);
			this.WidthStyleComboBox.TabIndex = 2;
			base.Controls.Add(this.label4);
			base.Controls.Add(this.WidthStyleComboBox);
			base.Controls.Add(this.ReferenceTextBox);
			base.Controls.Add(this.focusLabel7);
			base.Controls.Add(this.WidthTextBox);
			base.Controls.Add(this.focusLabel6);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelBarSpecificEditorPlugIn";
			base.Size = new Size(728, 328);
			base.ResumeLayout(false);
		}
	}
}
