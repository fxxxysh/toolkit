using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotPrintAdapterEditorPlugIn : PlugInStandard
	{
		private FocusLabel label3;

		private EditBox DocumentNameTextBox;

		private GroupBox MarginGroupBox;

		private EditBox MarginLeftEditBox;

		private EditBox MarginTopEditBox;

		private EditBox MarginRightEditBox;

		private EditBox MarginBottomEditBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ShowPrintDialogCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox SizingStyleComboBox;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox OrientationComboBox;

		private Container components;

		public PlotPrintAdapterEditorPlugIn()
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
			this.DocumentNameTextBox = new EditBox();
			this.label3 = new FocusLabel();
			this.MarginGroupBox = new GroupBox();
			this.MarginBottomEditBox = new EditBox();
			this.MarginRightEditBox = new EditBox();
			this.MarginTopEditBox = new EditBox();
			this.MarginLeftEditBox = new EditBox();
			this.ShowPrintDialogCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.SizingStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel1 = new FocusLabel();
			this.focusLabel2 = new FocusLabel();
			this.OrientationComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.MarginGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.DocumentNameTextBox.LoadingBegin();
			this.DocumentNameTextBox.Location = new Point(104, 112);
			this.DocumentNameTextBox.Name = "DocumentNameTextBox";
			this.DocumentNameTextBox.PropertyName = "DocumentName";
			this.DocumentNameTextBox.Size = new Size(189, 20);
			this.DocumentNameTextBox.TabIndex = 3;
			this.DocumentNameTextBox.LoadingEnd();
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.DocumentNameTextBox;
			this.label3.Location = new Point(14, 114);
			this.label3.Name = "label3";
			this.label3.Size = new Size(90, 15);
			this.label3.Text = "Document Name";
			this.label3.LoadingEnd();
			this.MarginGroupBox.Controls.Add(this.MarginBottomEditBox);
			this.MarginGroupBox.Controls.Add(this.MarginRightEditBox);
			this.MarginGroupBox.Controls.Add(this.MarginTopEditBox);
			this.MarginGroupBox.Controls.Add(this.MarginLeftEditBox);
			this.MarginGroupBox.Location = new Point(104, 144);
			this.MarginGroupBox.Name = "MarginGroupBox";
			this.MarginGroupBox.Size = new Size(192, 120);
			this.MarginGroupBox.TabIndex = 4;
			this.MarginGroupBox.TabStop = false;
			this.MarginGroupBox.Text = "Margin";
			this.MarginBottomEditBox.LoadingBegin();
			this.MarginBottomEditBox.Location = new Point(72, 88);
			this.MarginBottomEditBox.Name = "MarginBottomEditBox";
			this.MarginBottomEditBox.PropertyName = "MarginBottom";
			this.MarginBottomEditBox.Size = new Size(48, 20);
			this.MarginBottomEditBox.TabIndex = 3;
			this.MarginBottomEditBox.TextAlign = HorizontalAlignment.Center;
			this.MarginBottomEditBox.LoadingEnd();
			this.MarginRightEditBox.LoadingBegin();
			this.MarginRightEditBox.Location = new Point(120, 56);
			this.MarginRightEditBox.Name = "MarginRightEditBox";
			this.MarginRightEditBox.PropertyName = "MarginRight";
			this.MarginRightEditBox.Size = new Size(48, 20);
			this.MarginRightEditBox.TabIndex = 2;
			this.MarginRightEditBox.TextAlign = HorizontalAlignment.Center;
			this.MarginRightEditBox.LoadingEnd();
			this.MarginTopEditBox.LoadingBegin();
			this.MarginTopEditBox.Location = new Point(72, 24);
			this.MarginTopEditBox.Name = "MarginTopEditBox";
			this.MarginTopEditBox.PropertyName = "MarginTop";
			this.MarginTopEditBox.Size = new Size(48, 20);
			this.MarginTopEditBox.TabIndex = 0;
			this.MarginTopEditBox.TextAlign = HorizontalAlignment.Center;
			this.MarginTopEditBox.LoadingEnd();
			this.MarginLeftEditBox.LoadingBegin();
			this.MarginLeftEditBox.Location = new Point(24, 56);
			this.MarginLeftEditBox.Name = "MarginLeftEditBox";
			this.MarginLeftEditBox.PropertyName = "MarginLeft";
			this.MarginLeftEditBox.Size = new Size(48, 20);
			this.MarginLeftEditBox.TabIndex = 1;
			this.MarginLeftEditBox.TextAlign = HorizontalAlignment.Center;
			this.MarginLeftEditBox.LoadingEnd();
			this.ShowPrintDialogCheckBox.Location = new Point(104, 24);
			this.ShowPrintDialogCheckBox.Name = "ShowPrintDialogCheckBox";
			this.ShowPrintDialogCheckBox.PropertyName = "ShowPrintDialog";
			this.ShowPrintDialogCheckBox.Size = new Size(136, 24);
			this.ShowPrintDialogCheckBox.TabIndex = 0;
			this.ShowPrintDialogCheckBox.Text = "Show Print Dialog";
			this.SizingStyleComboBox.Location = new Point(104, 80);
			this.SizingStyleComboBox.Name = "SizingStyleComboBox";
			this.SizingStyleComboBox.PropertyName = "SizingStyle";
			this.SizingStyleComboBox.Size = new Size(121, 21);
			this.SizingStyleComboBox.TabIndex = 2;
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.SizingStyleComboBox;
			this.focusLabel1.Location = new Point(39, 82);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(65, 15);
			this.focusLabel1.Text = "Sizing Style";
			this.focusLabel1.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.OrientationComboBox;
			this.focusLabel2.Location = new Point(43, 58);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(61, 15);
			this.focusLabel2.Text = "Orientation";
			this.focusLabel2.LoadingEnd();
			this.OrientationComboBox.Location = new Point(104, 56);
			this.OrientationComboBox.Name = "OrientationComboBox";
			this.OrientationComboBox.PropertyName = "Orientation";
			this.OrientationComboBox.Size = new Size(121, 21);
			this.OrientationComboBox.TabIndex = 1;
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.OrientationComboBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.SizingStyleComboBox);
			base.Controls.Add(this.ShowPrintDialogCheckBox);
			base.Controls.Add(this.MarginGroupBox);
			base.Controls.Add(this.DocumentNameTextBox);
			base.Controls.Add(this.label3);
			base.Name = "PlotPrintAdapterEditorPlugIn";
			base.Size = new Size(424, 288);
			this.MarginGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
