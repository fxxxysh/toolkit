using Iocomp.Design.Plugin.EditorControls;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelDigitalSpecificEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox TerminatedCheckBox;

		private GroupBox groupBox1;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ReferenceStyleComboBox;

		private FocusLabel focusLabel9;

		private EditBox ReferenceHighTextBox;

		private EditBox ReferenceLowTextBox;

		private FocusLabel focusLabel7;

		private FocusLabel focusLabel6;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel2;

		private Container components;

		public PlotChannelDigitalSpecificEditorPlugIn()
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
			this.TerminatedCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.groupBox1 = new GroupBox();
			this.focusLabel2 = new FocusLabel();
			this.ReferenceHighTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.ReferenceLowTextBox = new EditBox();
			this.ReferenceStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel9 = new FocusLabel();
			this.focusLabel7 = new FocusLabel();
			this.focusLabel6 = new FocusLabel();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.TerminatedCheckBox.Location = new Point(32, 16);
			this.TerminatedCheckBox.Name = "TerminatedCheckBox";
			this.TerminatedCheckBox.PropertyName = "Terminated";
			this.TerminatedCheckBox.Size = new Size(96, 24);
			this.TerminatedCheckBox.TabIndex = 0;
			this.TerminatedCheckBox.Text = "Terminated";
			this.groupBox1.Controls.Add(this.focusLabel2);
			this.groupBox1.Controls.Add(this.focusLabel1);
			this.groupBox1.Controls.Add(this.ReferenceStyleComboBox);
			this.groupBox1.Controls.Add(this.focusLabel9);
			this.groupBox1.Controls.Add(this.ReferenceHighTextBox);
			this.groupBox1.Controls.Add(this.ReferenceLowTextBox);
			this.groupBox1.Controls.Add(this.focusLabel7);
			this.groupBox1.Controls.Add(this.focusLabel6);
			this.groupBox1.Location = new Point(32, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(344, 104);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Reference";
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.ReferenceHighTextBox;
			this.focusLabel2.FocusControlAlignment = AlignmentQuadSide.Right;
			this.focusLabel2.Location = new Point(104, 74);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(182, 15);
			this.focusLabel2.Text = "Use 0.0 to 1.0 when Style = Percent";
			this.focusLabel2.LoadingEnd();
			this.ReferenceHighTextBox.LoadingBegin();
			this.ReferenceHighTextBox.Location = new Point(48, 72);
			this.ReferenceHighTextBox.Name = "ReferenceHighTextBox";
			this.ReferenceHighTextBox.PropertyName = "ReferenceHigh";
			this.ReferenceHighTextBox.Size = new Size(56, 20);
			this.ReferenceHighTextBox.TabIndex = 2;
			this.ReferenceHighTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.ReferenceLowTextBox;
			this.focusLabel1.FocusControlAlignment = AlignmentQuadSide.Right;
			this.focusLabel1.Location = new Point(104, 50);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(182, 15);
			this.focusLabel1.Text = "Use 0.0 to 1.0 when Style = Percent";
			this.focusLabel1.LoadingEnd();
			this.ReferenceLowTextBox.LoadingBegin();
			this.ReferenceLowTextBox.Location = new Point(48, 48);
			this.ReferenceLowTextBox.Name = "ReferenceLowTextBox";
			this.ReferenceLowTextBox.PropertyName = "ReferenceLow";
			this.ReferenceLowTextBox.Size = new Size(56, 20);
			this.ReferenceLowTextBox.TabIndex = 1;
			this.ReferenceLowTextBox.LoadingEnd();
			this.ReferenceStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ReferenceStyleComboBox.Location = new Point(48, 24);
			this.ReferenceStyleComboBox.MaxDropDownItems = 20;
			this.ReferenceStyleComboBox.Name = "ReferenceStyleComboBox";
			this.ReferenceStyleComboBox.PropertyName = "ReferenceStyle";
			this.ReferenceStyleComboBox.Size = new Size(64, 21);
			this.ReferenceStyleComboBox.TabIndex = 0;
			this.focusLabel9.LoadingBegin();
			this.focusLabel9.FocusControl = this.ReferenceStyleComboBox;
			this.focusLabel9.Location = new Point(16, 26);
			this.focusLabel9.Name = "focusLabel9";
			this.focusLabel9.Size = new Size(32, 15);
			this.focusLabel9.Text = "Style";
			this.focusLabel9.LoadingEnd();
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.ReferenceHighTextBox;
			this.focusLabel7.Location = new Point(18, 74);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(30, 15);
			this.focusLabel7.Text = "High";
			this.focusLabel7.LoadingEnd();
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.ReferenceLowTextBox;
			this.focusLabel6.Location = new Point(20, 50);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(28, 15);
			this.focusLabel6.Text = "Low";
			this.focusLabel6.LoadingEnd();
			base.Controls.Add(this.TerminatedCheckBox);
			base.Controls.Add(this.groupBox1);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelDigitalSpecificEditorPlugIn";
			base.Size = new Size(728, 328);
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
