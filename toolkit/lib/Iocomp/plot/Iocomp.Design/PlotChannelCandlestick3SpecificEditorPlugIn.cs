using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelCandlestick3SpecificEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel6;

		private FocusLabel focusLabel1;

		private Iocomp.Design.Plugin.EditorControls.ComboBox WidthStyleMinMaxComboBox;

		private EditBox WidthMinMaxTextBox;

		private GroupBox MinMaxGroupBox;

		private GroupBox StdDevGroupBox;

		private FocusLabel focusLabel5;

		private FocusLabel focusLabel7;

		private GroupBox MeanGroupBox;

		private FocusLabel focusLabel8;

		private FocusLabel focusLabel9;

		private FocusLabel focusLabel10;

		private FocusLabel focusLabel11;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ThicknessStyleMeanComboBox;

		private EditBox ThicknessMeanEditBox;

		private EditBox WidthStdDevEditBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox WidthStyleStdDevComboBox;

		private EditBox WidthMeanEditBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox WidthStyleMeanComboBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ShowMeanCheckBox;

		private Container components;

		public PlotChannelCandlestick3SpecificEditorPlugIn()
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
			this.WidthMinMaxTextBox = new EditBox();
			this.focusLabel6 = new FocusLabel();
			this.WidthStyleMinMaxComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel1 = new FocusLabel();
			this.MinMaxGroupBox = new GroupBox();
			this.StdDevGroupBox = new GroupBox();
			this.focusLabel5 = new FocusLabel();
			this.WidthStdDevEditBox = new EditBox();
			this.focusLabel7 = new FocusLabel();
			this.WidthStyleStdDevComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.MeanGroupBox = new GroupBox();
			this.focusLabel8 = new FocusLabel();
			this.WidthMeanEditBox = new EditBox();
			this.focusLabel9 = new FocusLabel();
			this.WidthStyleMeanComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.ShowMeanCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.ThicknessMeanEditBox = new EditBox();
			this.focusLabel10 = new FocusLabel();
			this.focusLabel11 = new FocusLabel();
			this.ThicknessStyleMeanComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.MinMaxGroupBox.SuspendLayout();
			this.StdDevGroupBox.SuspendLayout();
			this.MeanGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.WidthMinMaxTextBox.LoadingBegin();
			this.WidthMinMaxTextBox.Location = new Point(64, 24);
			this.WidthMinMaxTextBox.Name = "WidthMinMaxTextBox";
			this.WidthMinMaxTextBox.PropertyName = "WidthMinMax";
			this.WidthMinMaxTextBox.Size = new Size(56, 20);
			this.WidthMinMaxTextBox.TabIndex = 1;
			this.WidthMinMaxTextBox.LoadingEnd();
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.WidthMinMaxTextBox;
			this.focusLabel6.Location = new Point(29, 26);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(35, 15);
			this.focusLabel6.Text = "Width";
			this.focusLabel6.LoadingEnd();
			this.WidthStyleMinMaxComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.WidthStyleMinMaxComboBox.Location = new Point(208, 24);
			this.WidthStyleMinMaxComboBox.MaxDropDownItems = 20;
			this.WidthStyleMinMaxComboBox.Name = "WidthStyleMinMaxComboBox";
			this.WidthStyleMinMaxComboBox.PropertyName = "WidthStyleMinMax";
			this.WidthStyleMinMaxComboBox.Size = new Size(136, 21);
			this.WidthStyleMinMaxComboBox.TabIndex = 31;
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.WidthStyleMinMaxComboBox;
			this.focusLabel1.Location = new Point(146, 26);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(62, 15);
			this.focusLabel1.Text = "Width Style";
			this.focusLabel1.LoadingEnd();
			this.MinMaxGroupBox.Controls.Add(this.focusLabel6);
			this.MinMaxGroupBox.Controls.Add(this.focusLabel1);
			this.MinMaxGroupBox.Controls.Add(this.WidthStyleMinMaxComboBox);
			this.MinMaxGroupBox.Controls.Add(this.WidthMinMaxTextBox);
			this.MinMaxGroupBox.Location = new Point(16, 16);
			this.MinMaxGroupBox.Name = "MinMaxGroupBox";
			this.MinMaxGroupBox.Size = new Size(416, 56);
			this.MinMaxGroupBox.TabIndex = 54;
			this.MinMaxGroupBox.TabStop = false;
			this.MinMaxGroupBox.Text = "Min-Max";
			this.StdDevGroupBox.Controls.Add(this.focusLabel5);
			this.StdDevGroupBox.Controls.Add(this.focusLabel7);
			this.StdDevGroupBox.Controls.Add(this.WidthStyleStdDevComboBox);
			this.StdDevGroupBox.Controls.Add(this.WidthStdDevEditBox);
			this.StdDevGroupBox.Location = new Point(16, 80);
			this.StdDevGroupBox.Name = "StdDevGroupBox";
			this.StdDevGroupBox.Size = new Size(416, 56);
			this.StdDevGroupBox.TabIndex = 55;
			this.StdDevGroupBox.TabStop = false;
			this.StdDevGroupBox.Text = "Std-Dev";
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.WidthStdDevEditBox;
			this.focusLabel5.Location = new Point(29, 26);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(35, 15);
			this.focusLabel5.Text = "Width";
			this.focusLabel5.LoadingEnd();
			this.WidthStdDevEditBox.LoadingBegin();
			this.WidthStdDevEditBox.Location = new Point(64, 24);
			this.WidthStdDevEditBox.Name = "WidthStdDevEditBox";
			this.WidthStdDevEditBox.PropertyName = "WidthStdDev";
			this.WidthStdDevEditBox.Size = new Size(56, 20);
			this.WidthStdDevEditBox.TabIndex = 1;
			this.WidthStdDevEditBox.LoadingEnd();
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.WidthStyleStdDevComboBox;
			this.focusLabel7.Location = new Point(146, 26);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(62, 15);
			this.focusLabel7.Text = "Width Style";
			this.focusLabel7.LoadingEnd();
			this.WidthStyleStdDevComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.WidthStyleStdDevComboBox.Location = new Point(208, 24);
			this.WidthStyleStdDevComboBox.MaxDropDownItems = 20;
			this.WidthStyleStdDevComboBox.Name = "WidthStyleStdDevComboBox";
			this.WidthStyleStdDevComboBox.PropertyName = "WidthStyleStdDev";
			this.WidthStyleStdDevComboBox.Size = new Size(136, 21);
			this.WidthStyleStdDevComboBox.TabIndex = 31;
			this.MeanGroupBox.Controls.Add(this.focusLabel8);
			this.MeanGroupBox.Controls.Add(this.focusLabel9);
			this.MeanGroupBox.Controls.Add(this.WidthStyleMeanComboBox);
			this.MeanGroupBox.Controls.Add(this.WidthMeanEditBox);
			this.MeanGroupBox.Controls.Add(this.ShowMeanCheckBox);
			this.MeanGroupBox.Controls.Add(this.ThicknessMeanEditBox);
			this.MeanGroupBox.Controls.Add(this.focusLabel10);
			this.MeanGroupBox.Controls.Add(this.focusLabel11);
			this.MeanGroupBox.Controls.Add(this.ThicknessStyleMeanComboBox);
			this.MeanGroupBox.Location = new Point(16, 144);
			this.MeanGroupBox.Name = "MeanGroupBox";
			this.MeanGroupBox.Size = new Size(416, 128);
			this.MeanGroupBox.TabIndex = 56;
			this.MeanGroupBox.TabStop = false;
			this.MeanGroupBox.Text = "Mean";
			this.focusLabel8.LoadingBegin();
			this.focusLabel8.FocusControl = this.WidthMeanEditBox;
			this.focusLabel8.Location = new Point(29, 58);
			this.focusLabel8.Name = "focusLabel8";
			this.focusLabel8.Size = new Size(35, 15);
			this.focusLabel8.Text = "Width";
			this.focusLabel8.LoadingEnd();
			this.WidthMeanEditBox.LoadingBegin();
			this.WidthMeanEditBox.Location = new Point(64, 56);
			this.WidthMeanEditBox.Name = "WidthMeanEditBox";
			this.WidthMeanEditBox.PropertyName = "WidthMean";
			this.WidthMeanEditBox.Size = new Size(56, 20);
			this.WidthMeanEditBox.TabIndex = 1;
			this.WidthMeanEditBox.LoadingEnd();
			this.focusLabel9.LoadingBegin();
			this.focusLabel9.FocusControl = this.WidthStyleMeanComboBox;
			this.focusLabel9.Location = new Point(146, 58);
			this.focusLabel9.Name = "focusLabel9";
			this.focusLabel9.Size = new Size(62, 15);
			this.focusLabel9.Text = "Width Style";
			this.focusLabel9.LoadingEnd();
			this.WidthStyleMeanComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.WidthStyleMeanComboBox.Location = new Point(208, 56);
			this.WidthStyleMeanComboBox.MaxDropDownItems = 20;
			this.WidthStyleMeanComboBox.Name = "WidthStyleMeanComboBox";
			this.WidthStyleMeanComboBox.PropertyName = "WidthStyleMean";
			this.WidthStyleMeanComboBox.Size = new Size(136, 21);
			this.WidthStyleMeanComboBox.TabIndex = 31;
			this.ShowMeanCheckBox.Location = new Point(64, 24);
			this.ShowMeanCheckBox.Name = "ShowMeanCheckBox";
			this.ShowMeanCheckBox.PropertyName = "ShowMean";
			this.ShowMeanCheckBox.Size = new Size(56, 24);
			this.ShowMeanCheckBox.TabIndex = 58;
			this.ShowMeanCheckBox.Text = "Show";
			this.ThicknessMeanEditBox.LoadingBegin();
			this.ThicknessMeanEditBox.Location = new Point(64, 88);
			this.ThicknessMeanEditBox.Name = "ThicknessMeanEditBox";
			this.ThicknessMeanEditBox.PropertyName = "ThicknessMean";
			this.ThicknessMeanEditBox.Size = new Size(56, 20);
			this.ThicknessMeanEditBox.TabIndex = 1;
			this.ThicknessMeanEditBox.LoadingEnd();
			this.focusLabel10.LoadingBegin();
			this.focusLabel10.FocusControl = this.ThicknessMeanEditBox;
			this.focusLabel10.Location = new Point(8, 90);
			this.focusLabel10.Name = "focusLabel10";
			this.focusLabel10.Size = new Size(56, 15);
			this.focusLabel10.Text = "Thickness";
			this.focusLabel10.LoadingEnd();
			this.focusLabel11.LoadingBegin();
			this.focusLabel11.FocusControl = this.ThicknessStyleMeanComboBox;
			this.focusLabel11.Location = new Point(124, 90);
			this.focusLabel11.Name = "focusLabel11";
			this.focusLabel11.Size = new Size(84, 15);
			this.focusLabel11.Text = "Thickness Style";
			this.focusLabel11.LoadingEnd();
			this.ThicknessStyleMeanComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ThicknessStyleMeanComboBox.Location = new Point(208, 88);
			this.ThicknessStyleMeanComboBox.MaxDropDownItems = 20;
			this.ThicknessStyleMeanComboBox.Name = "ThicknessStyleMeanComboBox";
			this.ThicknessStyleMeanComboBox.PropertyName = "ThicknessStyleMean";
			this.ThicknessStyleMeanComboBox.Size = new Size(136, 21);
			this.ThicknessStyleMeanComboBox.TabIndex = 31;
			base.Controls.Add(this.MeanGroupBox);
			base.Controls.Add(this.StdDevGroupBox);
			base.Controls.Add(this.MinMaxGroupBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelCandlestick3SpecificEditorPlugIn";
			base.Size = new Size(728, 320);
			this.MinMaxGroupBox.ResumeLayout(false);
			this.StdDevGroupBox.ResumeLayout(false);
			this.MeanGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
