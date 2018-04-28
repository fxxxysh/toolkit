using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotLayoutDockableAllEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel1;

		private EditBox DockOrderTextBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DockSideComboBox;

		private FocusLabel label2;

		private FocusLabel focusLabel3;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DockStyleComboBox;

		private FocusLabel focusLabel2;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown DockMarginUpDown;

		private FocusLabel focusLabel6;

		private FocusLabel focusLabel7;

		private EditBox DockDataViewNameTextBox;

		private EditBox DockPercentStartTextBox;

		private FocusLabel focusLabel4;

		private EditBox DockPercentStopTextBox;

		private FocusLabel focusLabel5;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DockAutoSizeAlignmentComboBox;

		private GroupBox StartGroupBox;

		private GroupBox StopGroupBox;

		private FocusLabel focusLabel8;

		private FocusLabel focusLabel9;

		private FocusLabel focusLabel10;

		private FocusLabel focusLabel11;

		private EditBox DockStartDataViewNameEditBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DockStartStyleComboBox;

		private EditBox DockStopDataViewNameEditBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DockStopStyleComboBox;

		private Container components;

		public PlotLayoutDockableAllEditorPlugIn()
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
			this.DockOrderTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.DockSideComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label2 = new FocusLabel();
			this.DockDataViewNameTextBox = new EditBox();
			this.focusLabel3 = new FocusLabel();
			this.DockStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel2 = new FocusLabel();
			this.DockMarginUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.focusLabel6 = new FocusLabel();
			this.DockAutoSizeAlignmentComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel7 = new FocusLabel();
			this.DockPercentStartTextBox = new EditBox();
			this.focusLabel4 = new FocusLabel();
			this.DockPercentStopTextBox = new EditBox();
			this.focusLabel5 = new FocusLabel();
			this.StartGroupBox = new GroupBox();
			this.DockStartDataViewNameEditBox = new EditBox();
			this.focusLabel9 = new FocusLabel();
			this.DockStartStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel8 = new FocusLabel();
			this.StopGroupBox = new GroupBox();
			this.DockStopDataViewNameEditBox = new EditBox();
			this.focusLabel10 = new FocusLabel();
			this.DockStopStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel11 = new FocusLabel();
			((ISupportInitialize)this.DockMarginUpDown).BeginInit();
			this.StartGroupBox.SuspendLayout();
			this.StopGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.DockOrderTextBox.LoadingBegin();
			this.DockOrderTextBox.Location = new Point(64, 240);
			this.DockOrderTextBox.Name = "DockOrderTextBox";
			this.DockOrderTextBox.PropertyName = "DockOrder";
			this.DockOrderTextBox.ReadOnly = true;
			this.DockOrderTextBox.Size = new Size(136, 20);
			this.DockOrderTextBox.TabIndex = 6;
			this.DockOrderTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.DockOrderTextBox;
			this.focusLabel1.Location = new Point(28, 242);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(36, 15);
			this.focusLabel1.Text = "Order";
			this.focusLabel1.LoadingEnd();
			this.DockSideComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.DockSideComboBox.Location = new Point(64, 216);
			this.DockSideComboBox.Name = "DockSideComboBox";
			this.DockSideComboBox.PropertyName = "DockSide";
			this.DockSideComboBox.ReadOnly = true;
			this.DockSideComboBox.Size = new Size(136, 21);
			this.DockSideComboBox.TabIndex = 5;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.DockSideComboBox;
			this.label2.Location = new Point(34, 218);
			this.label2.Name = "label2";
			this.label2.Size = new Size(30, 15);
			this.label2.Text = "Side";
			this.label2.LoadingEnd();
			this.DockDataViewNameTextBox.LoadingBegin();
			this.DockDataViewNameTextBox.Location = new Point(304, 192);
			this.DockDataViewNameTextBox.Name = "DockDataViewNameTextBox";
			this.DockDataViewNameTextBox.PropertyName = "DockDataViewName";
			this.DockDataViewNameTextBox.ReadOnly = true;
			this.DockDataViewNameTextBox.Size = new Size(144, 20);
			this.DockDataViewNameTextBox.TabIndex = 7;
			this.DockDataViewNameTextBox.LoadingEnd();
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.DockDataViewNameTextBox;
			this.focusLabel3.Location = new Point(213, 194);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(91, 15);
			this.focusLabel3.Text = "Data-View Name";
			this.focusLabel3.LoadingEnd();
			this.DockStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.DockStyleComboBox.Location = new Point(64, 192);
			this.DockStyleComboBox.Name = "DockStyleComboBox";
			this.DockStyleComboBox.PropertyName = "DockStyle";
			this.DockStyleComboBox.ReadOnly = true;
			this.DockStyleComboBox.Size = new Size(136, 21);
			this.DockStyleComboBox.TabIndex = 4;
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.DockStyleComboBox;
			this.focusLabel2.Location = new Point(32, 194);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(32, 15);
			this.focusLabel2.Text = "Style";
			this.focusLabel2.LoadingEnd();
			this.DockMarginUpDown.Location = new Point(112, 16);
			this.DockMarginUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			this.DockMarginUpDown.Minimum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				-2147483648
			});
			this.DockMarginUpDown.Name = "DockMarginUpDown";
			this.DockMarginUpDown.PropertyName = "DockMargin";
			this.DockMarginUpDown.Size = new Size(48, 20);
			this.DockMarginUpDown.TabIndex = 0;
			this.DockMarginUpDown.TextAlign = HorizontalAlignment.Center;
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.DockMarginUpDown;
			this.focusLabel6.Location = new Point(68, 17);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(44, 15);
			this.focusLabel6.Text = " Margin";
			this.focusLabel6.LoadingEnd();
			this.DockAutoSizeAlignmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.DockAutoSizeAlignmentComboBox.Location = new Point(112, 40);
			this.DockAutoSizeAlignmentComboBox.MaxDropDownItems = 20;
			this.DockAutoSizeAlignmentComboBox.Name = "DockAutoSizeAlignmentComboBox";
			this.DockAutoSizeAlignmentComboBox.PropertyName = "DockAutoSizeAlignment";
			this.DockAutoSizeAlignmentComboBox.Size = new Size(88, 21);
			this.DockAutoSizeAlignmentComboBox.TabIndex = 1;
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.DockAutoSizeAlignmentComboBox;
			this.focusLabel7.Location = new Point(6, 42);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(106, 15);
			this.focusLabel7.Text = "Auto Size Alignment";
			this.focusLabel7.LoadingEnd();
			this.DockPercentStartTextBox.LoadingBegin();
			this.DockPercentStartTextBox.Location = new Point(56, 16);
			this.DockPercentStartTextBox.Name = "DockPercentStartTextBox";
			this.DockPercentStartTextBox.PropertyName = "DockPercentStart";
			this.DockPercentStartTextBox.Size = new Size(112, 20);
			this.DockPercentStartTextBox.TabIndex = 0;
			this.DockPercentStartTextBox.LoadingEnd();
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.DockPercentStartTextBox;
			this.focusLabel4.Location = new Point(11, 18);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(45, 15);
			this.focusLabel4.Text = "Percent";
			this.focusLabel4.LoadingEnd();
			this.DockPercentStopTextBox.LoadingBegin();
			this.DockPercentStopTextBox.Location = new Point(56, 16);
			this.DockPercentStopTextBox.Name = "DockPercentStopTextBox";
			this.DockPercentStopTextBox.PropertyName = "DockPercentStop";
			this.DockPercentStopTextBox.Size = new Size(112, 20);
			this.DockPercentStopTextBox.TabIndex = 0;
			this.DockPercentStopTextBox.LoadingEnd();
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.DockPercentStopTextBox;
			this.focusLabel5.Location = new Point(11, 18);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(45, 15);
			this.focusLabel5.Text = "Percent";
			this.focusLabel5.LoadingEnd();
			this.StartGroupBox.Controls.Add(this.DockStartDataViewNameEditBox);
			this.StartGroupBox.Controls.Add(this.focusLabel9);
			this.StartGroupBox.Controls.Add(this.DockStartStyleComboBox);
			this.StartGroupBox.Controls.Add(this.focusLabel8);
			this.StartGroupBox.Controls.Add(this.DockPercentStartTextBox);
			this.StartGroupBox.Controls.Add(this.focusLabel4);
			this.StartGroupBox.Location = new Point(8, 72);
			this.StartGroupBox.Name = "StartGroupBox";
			this.StartGroupBox.Size = new Size(568, 48);
			this.StartGroupBox.TabIndex = 2;
			this.StartGroupBox.TabStop = false;
			this.StartGroupBox.Text = "Start";
			this.DockStartDataViewNameEditBox.LoadingBegin();
			this.DockStartDataViewNameEditBox.Location = new Point(408, 16);
			this.DockStartDataViewNameEditBox.Name = "DockStartDataViewNameEditBox";
			this.DockStartDataViewNameEditBox.PropertyName = "DockStartDataViewName";
			this.DockStartDataViewNameEditBox.Size = new Size(144, 20);
			this.DockStartDataViewNameEditBox.TabIndex = 2;
			this.DockStartDataViewNameEditBox.LoadingEnd();
			this.focusLabel9.LoadingBegin();
			this.focusLabel9.FocusControl = this.DockStartDataViewNameEditBox;
			this.focusLabel9.Location = new Point(317, 18);
			this.focusLabel9.Name = "focusLabel9";
			this.focusLabel9.Size = new Size(91, 15);
			this.focusLabel9.Text = "Data-View Name";
			this.focusLabel9.LoadingEnd();
			this.DockStartStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.DockStartStyleComboBox.Location = new Point(208, 16);
			this.DockStartStyleComboBox.MaxDropDownItems = 20;
			this.DockStartStyleComboBox.Name = "DockStartStyleComboBox";
			this.DockStartStyleComboBox.PropertyName = "DockStartStyle";
			this.DockStartStyleComboBox.Size = new Size(104, 21);
			this.DockStartStyleComboBox.TabIndex = 1;
			this.focusLabel8.LoadingBegin();
			this.focusLabel8.FocusControl = this.DockStartStyleComboBox;
			this.focusLabel8.Location = new Point(176, 18);
			this.focusLabel8.Name = "focusLabel8";
			this.focusLabel8.Size = new Size(32, 15);
			this.focusLabel8.Text = "Style";
			this.focusLabel8.LoadingEnd();
			this.StopGroupBox.Controls.Add(this.DockStopDataViewNameEditBox);
			this.StopGroupBox.Controls.Add(this.focusLabel10);
			this.StopGroupBox.Controls.Add(this.DockStopStyleComboBox);
			this.StopGroupBox.Controls.Add(this.focusLabel11);
			this.StopGroupBox.Controls.Add(this.DockPercentStopTextBox);
			this.StopGroupBox.Controls.Add(this.focusLabel5);
			this.StopGroupBox.Location = new Point(8, 128);
			this.StopGroupBox.Name = "StopGroupBox";
			this.StopGroupBox.Size = new Size(568, 48);
			this.StopGroupBox.TabIndex = 3;
			this.StopGroupBox.TabStop = false;
			this.StopGroupBox.Text = "Stop";
			this.DockStopDataViewNameEditBox.LoadingBegin();
			this.DockStopDataViewNameEditBox.Location = new Point(408, 16);
			this.DockStopDataViewNameEditBox.Name = "DockStopDataViewNameEditBox";
			this.DockStopDataViewNameEditBox.PropertyName = "DockStopDataViewName";
			this.DockStopDataViewNameEditBox.Size = new Size(144, 20);
			this.DockStopDataViewNameEditBox.TabIndex = 2;
			this.DockStopDataViewNameEditBox.LoadingEnd();
			this.focusLabel10.LoadingBegin();
			this.focusLabel10.FocusControl = this.DockStopDataViewNameEditBox;
			this.focusLabel10.Location = new Point(317, 18);
			this.focusLabel10.Name = "focusLabel10";
			this.focusLabel10.Size = new Size(91, 15);
			this.focusLabel10.Text = "Data-View Name";
			this.focusLabel10.LoadingEnd();
			this.DockStopStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.DockStopStyleComboBox.Location = new Point(208, 16);
			this.DockStopStyleComboBox.MaxDropDownItems = 20;
			this.DockStopStyleComboBox.Name = "DockStopStyleComboBox";
			this.DockStopStyleComboBox.PropertyName = "DockStopStyle";
			this.DockStopStyleComboBox.Size = new Size(104, 21);
			this.DockStopStyleComboBox.TabIndex = 1;
			this.focusLabel11.LoadingBegin();
			this.focusLabel11.FocusControl = this.DockStopStyleComboBox;
			this.focusLabel11.Location = new Point(176, 18);
			this.focusLabel11.Name = "focusLabel11";
			this.focusLabel11.Size = new Size(32, 15);
			this.focusLabel11.Text = "Style";
			this.focusLabel11.LoadingEnd();
			base.Controls.Add(this.StopGroupBox);
			base.Controls.Add(this.StartGroupBox);
			base.Controls.Add(this.DockAutoSizeAlignmentComboBox);
			base.Controls.Add(this.focusLabel7);
			base.Controls.Add(this.DockMarginUpDown);
			base.Controls.Add(this.focusLabel6);
			base.Controls.Add(this.DockStyleComboBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.DockDataViewNameTextBox);
			base.Controls.Add(this.focusLabel3);
			base.Controls.Add(this.DockSideComboBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.DockOrderTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Location = new Point(10, 20);
			base.Name = "PlotLayoutDockableAllEditorPlugIn";
			base.Size = new Size(712, 336);
			((ISupportInitialize)this.DockMarginUpDown).EndInit();
			this.StartGroupBox.ResumeLayout(false);
			this.StopGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
