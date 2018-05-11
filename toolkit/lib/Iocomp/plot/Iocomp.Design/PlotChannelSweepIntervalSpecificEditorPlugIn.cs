using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelSweepIntervalSpecificEditorPlugIn : PlugInStandard
	{
		private GroupBox groupBox3;

		private Iocomp.Design.Plugin.EditorControls.CheckBox SweepYDefaultNullCheckBox;

		private EditBox SweepYDefaultValueTextBox;

		private FocusLabel focusLabel12;

		private GroupBox groupBox2;

		private EditBox SweepXIntervalTextBox;

		private FocusLabel focusLabel9;

		private EditBox SweepXStartTextBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown SweepLeadingBreakCountUpDown;

		private FocusLabel focusLabel10;

		private EditBox SweepCountTextBox;

		private FocusLabel focusLabel7;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ClearOnRetraceCheckBox;

		private Container components;

		public PlotChannelSweepIntervalSpecificEditorPlugIn()
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
			this.groupBox3 = new GroupBox();
			this.SweepYDefaultNullCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.SweepYDefaultValueTextBox = new EditBox();
			this.focusLabel12 = new FocusLabel();
			this.groupBox2 = new GroupBox();
			this.SweepXIntervalTextBox = new EditBox();
			this.focusLabel9 = new FocusLabel();
			this.SweepXStartTextBox = new EditBox();
			this.focusLabel8 = new FocusLabel();
			this.SweepLeadingBreakCountUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.focusLabel10 = new FocusLabel();
			this.SweepCountTextBox = new EditBox();
			this.focusLabel7 = new FocusLabel();
			this.ClearOnRetraceCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			base.SuspendLayout();
			this.groupBox3.Controls.Add(this.SweepYDefaultNullCheckBox);
			this.groupBox3.Controls.Add(this.SweepYDefaultValueTextBox);
			this.groupBox3.Controls.Add(this.focusLabel12);
			this.groupBox3.Location = new Point(168, 128);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new Size(128, 80);
			this.groupBox3.TabIndex = 4;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Y-Default";
			this.SweepYDefaultNullCheckBox.Location = new Point(48, 48);
			this.SweepYDefaultNullCheckBox.Name = "SweepYDefaultNullCheckBox";
			this.SweepYDefaultNullCheckBox.PropertyName = "SweepYDefaultNull";
			this.SweepYDefaultNullCheckBox.Size = new Size(48, 24);
			this.SweepYDefaultNullCheckBox.TabIndex = 1;
			this.SweepYDefaultNullCheckBox.Text = "Null";
			this.SweepYDefaultValueTextBox.LoadingBegin();
			this.SweepYDefaultValueTextBox.Location = new Point(48, 24);
			this.SweepYDefaultValueTextBox.Name = "SweepYDefaultValueTextBox";
			this.SweepYDefaultValueTextBox.PropertyName = "SweepYDefaultValue";
			this.SweepYDefaultValueTextBox.Size = new Size(64, 20);
			this.SweepYDefaultValueTextBox.TabIndex = 0;
			this.SweepYDefaultValueTextBox.LoadingEnd();
			this.focusLabel12.LoadingBegin();
			this.focusLabel12.FocusControl = this.SweepYDefaultValueTextBox;
			this.focusLabel12.Location = new Point(12, 26);
			this.focusLabel12.Name = "focusLabel12";
			this.focusLabel12.Size = new Size(36, 15);
			this.focusLabel12.Text = "Value";
			this.focusLabel12.LoadingEnd();
			this.groupBox2.Controls.Add(this.SweepXIntervalTextBox);
			this.groupBox2.Controls.Add(this.focusLabel9);
			this.groupBox2.Controls.Add(this.SweepXStartTextBox);
			this.groupBox2.Controls.Add(this.focusLabel8);
			this.groupBox2.Location = new Point(24, 128);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(128, 80);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "X";
			this.SweepXIntervalTextBox.LoadingBegin();
			this.SweepXIntervalTextBox.Location = new Point(48, 48);
			this.SweepXIntervalTextBox.Name = "SweepXIntervalTextBox";
			this.SweepXIntervalTextBox.PropertyName = "SweepXInterval";
			this.SweepXIntervalTextBox.Size = new Size(64, 20);
			this.SweepXIntervalTextBox.TabIndex = 1;
			this.SweepXIntervalTextBox.LoadingEnd();
			this.focusLabel9.LoadingBegin();
			this.focusLabel9.FocusControl = this.SweepXIntervalTextBox;
			this.focusLabel9.Location = new Point(4, 50);
			this.focusLabel9.Name = "focusLabel9";
			this.focusLabel9.Size = new Size(44, 15);
			this.focusLabel9.Text = "Interval";
			this.focusLabel9.LoadingEnd();
			this.SweepXStartTextBox.LoadingBegin();
			this.SweepXStartTextBox.Location = new Point(48, 24);
			this.SweepXStartTextBox.Name = "SweepXStartTextBox";
			this.SweepXStartTextBox.PropertyName = "SweepXStart";
			this.SweepXStartTextBox.Size = new Size(64, 20);
			this.SweepXStartTextBox.TabIndex = 0;
			this.SweepXStartTextBox.LoadingEnd();
			this.focusLabel8.LoadingBegin();
			this.focusLabel8.FocusControl = this.SweepXStartTextBox;
			this.focusLabel8.Location = new Point(17, 26);
			this.focusLabel8.Name = "focusLabel8";
			this.focusLabel8.Size = new Size(31, 15);
			this.focusLabel8.Text = "Start";
			this.focusLabel8.LoadingEnd();
			this.SweepLeadingBreakCountUpDown.Location = new Point(128, 64);
			this.SweepLeadingBreakCountUpDown.Name = "SweepLeadingBreakCountUpDown";
			this.SweepLeadingBreakCountUpDown.PropertyName = "SweepLeadingBreakCount";
			this.SweepLeadingBreakCountUpDown.Size = new Size(64, 20);
			this.SweepLeadingBreakCountUpDown.TabIndex = 1;
			this.SweepLeadingBreakCountUpDown.TextAlign = HorizontalAlignment.Center;
			this.focusLabel10.LoadingBegin();
			this.focusLabel10.FocusControl = this.SweepLeadingBreakCountUpDown;
			this.focusLabel10.Location = new Point(17, 65);
			this.focusLabel10.Name = "focusLabel10";
			this.focusLabel10.Size = new Size(111, 15);
			this.focusLabel10.Text = "Leading Break Count";
			this.focusLabel10.LoadingEnd();
			this.SweepCountTextBox.LoadingBegin();
			this.SweepCountTextBox.Location = new Point(128, 32);
			this.SweepCountTextBox.Name = "SweepCountTextBox";
			this.SweepCountTextBox.PropertyName = "SweepCount";
			this.SweepCountTextBox.Size = new Size(64, 20);
			this.SweepCountTextBox.TabIndex = 0;
			this.SweepCountTextBox.LoadingEnd();
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.SweepCountTextBox;
			this.focusLabel7.Location = new Point(91, 34);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(37, 15);
			this.focusLabel7.Text = "Count";
			this.focusLabel7.LoadingEnd();
			this.ClearOnRetraceCheckBox.Location = new Point(128, 88);
			this.ClearOnRetraceCheckBox.Name = "ClearOnRetraceCheckBox";
			this.ClearOnRetraceCheckBox.PropertyName = "ClearOnRetrace";
			this.ClearOnRetraceCheckBox.Size = new Size(156, 24);
			this.ClearOnRetraceCheckBox.TabIndex = 2;
			this.ClearOnRetraceCheckBox.Text = "Clear On Retrace";
			base.Controls.Add(this.ClearOnRetraceCheckBox);
			base.Controls.Add(this.groupBox3);
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.SweepLeadingBreakCountUpDown);
			base.Controls.Add(this.focusLabel10);
			base.Controls.Add(this.SweepCountTextBox);
			base.Controls.Add(this.focusLabel7);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelSweepIntervalSpecificEditorPlugIn";
			base.Size = new Size(728, 328);
			this.groupBox3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
