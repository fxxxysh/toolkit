using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotChannelCandlestick1SpecificEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel6;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel5;

		private FocusLabel focusLabel7;

		private EditBox WidthBodyTextBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox WidthStyleBodyComboBox;

		private GroupBox BodyGroupBox;

		private GroupBox ShadowGroupBox;

		private EditBox WidthShadowEditBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox WidthStyleShadowComboBox;

		private Container components;

		public PlotChannelCandlestick1SpecificEditorPlugIn()
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
			this.WidthBodyTextBox = new EditBox();
			this.focusLabel6 = new FocusLabel();
			this.WidthStyleBodyComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel1 = new FocusLabel();
			this.BodyGroupBox = new GroupBox();
			this.ShadowGroupBox = new GroupBox();
			this.focusLabel5 = new FocusLabel();
			this.WidthShadowEditBox = new EditBox();
			this.focusLabel7 = new FocusLabel();
			this.WidthStyleShadowComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.BodyGroupBox.SuspendLayout();
			this.ShadowGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.WidthBodyTextBox.LoadingBegin();
			this.WidthBodyTextBox.Location = new Point(64, 24);
			this.WidthBodyTextBox.Name = "WidthBodyTextBox";
			this.WidthBodyTextBox.PropertyName = "WidthBody";
			this.WidthBodyTextBox.Size = new Size(56, 20);
			this.WidthBodyTextBox.TabIndex = 1;
			this.WidthBodyTextBox.LoadingEnd();
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.WidthBodyTextBox;
			this.focusLabel6.Location = new Point(29, 26);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(35, 15);
			this.focusLabel6.Text = "Width";
			this.focusLabel6.LoadingEnd();
			this.WidthStyleBodyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.WidthStyleBodyComboBox.Location = new Point(208, 24);
			this.WidthStyleBodyComboBox.MaxDropDownItems = 20;
			this.WidthStyleBodyComboBox.Name = "WidthStyleBodyComboBox";
			this.WidthStyleBodyComboBox.PropertyName = "WidthStyleBody";
			this.WidthStyleBodyComboBox.Size = new Size(136, 21);
			this.WidthStyleBodyComboBox.TabIndex = 31;
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.WidthStyleBodyComboBox;
			this.focusLabel1.Location = new Point(146, 26);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(62, 15);
			this.focusLabel1.Text = "Width Style";
			this.focusLabel1.LoadingEnd();
			this.BodyGroupBox.Controls.Add(this.focusLabel6);
			this.BodyGroupBox.Controls.Add(this.focusLabel1);
			this.BodyGroupBox.Controls.Add(this.WidthStyleBodyComboBox);
			this.BodyGroupBox.Controls.Add(this.WidthBodyTextBox);
			this.BodyGroupBox.Location = new Point(16, 16);
			this.BodyGroupBox.Name = "BodyGroupBox";
			this.BodyGroupBox.Size = new Size(416, 56);
			this.BodyGroupBox.TabIndex = 54;
			this.BodyGroupBox.TabStop = false;
			this.BodyGroupBox.Text = "Body";
			this.ShadowGroupBox.Controls.Add(this.focusLabel5);
			this.ShadowGroupBox.Controls.Add(this.focusLabel7);
			this.ShadowGroupBox.Controls.Add(this.WidthStyleShadowComboBox);
			this.ShadowGroupBox.Controls.Add(this.WidthShadowEditBox);
			this.ShadowGroupBox.Location = new Point(16, 80);
			this.ShadowGroupBox.Name = "ShadowGroupBox";
			this.ShadowGroupBox.Size = new Size(416, 56);
			this.ShadowGroupBox.TabIndex = 55;
			this.ShadowGroupBox.TabStop = false;
			this.ShadowGroupBox.Text = "Shadow";
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.WidthShadowEditBox;
			this.focusLabel5.Location = new Point(29, 26);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(35, 15);
			this.focusLabel5.Text = "Width";
			this.focusLabel5.LoadingEnd();
			this.WidthShadowEditBox.LoadingBegin();
			this.WidthShadowEditBox.Location = new Point(64, 24);
			this.WidthShadowEditBox.Name = "WidthShadowEditBox";
			this.WidthShadowEditBox.PropertyName = "WidthShadow";
			this.WidthShadowEditBox.Size = new Size(56, 20);
			this.WidthShadowEditBox.TabIndex = 1;
			this.WidthShadowEditBox.LoadingEnd();
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.WidthStyleShadowComboBox;
			this.focusLabel7.Location = new Point(146, 26);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(62, 15);
			this.focusLabel7.Text = "Width Style";
			this.focusLabel7.LoadingEnd();
			this.WidthStyleShadowComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.WidthStyleShadowComboBox.Location = new Point(208, 24);
			this.WidthStyleShadowComboBox.MaxDropDownItems = 20;
			this.WidthStyleShadowComboBox.Name = "WidthStyleShadowComboBox";
			this.WidthStyleShadowComboBox.PropertyName = "WidthStyleShadow";
			this.WidthStyleShadowComboBox.Size = new Size(136, 21);
			this.WidthStyleShadowComboBox.TabIndex = 31;
			base.Controls.Add(this.ShadowGroupBox);
			base.Controls.Add(this.BodyGroupBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelCandlestick1SpecificEditorPlugIn";
			base.Size = new Size(728, 320);
			this.BodyGroupBox.ResumeLayout(false);
			this.ShadowGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
