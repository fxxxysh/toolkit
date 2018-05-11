using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotChannelCandlestick2SpecificEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel6;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel5;

		private FocusLabel focusLabel7;

		private EditBox WidthBodyTextBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox WidthStyleBodyComboBox;

		private GroupBox BodyGroupBox;

		private GroupBox OpenGroupBox;

		private EditBox WidthOpenEditBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox WidthStyleOpenComboBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ShowOpenCheckBox;

		private FocusLabel focusLabel2;

		private FocusLabel focusLabel3;

		private EditBox HeightOpenEditBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox HeightStyleOpenComboBox;

		private GroupBox CloseGroupBox;

		private FocusLabel focusLabel4;

		private EditBox HeightCloseEditBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.ComboBox HeightStyleCloseComboBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ShowCloseCheckBox;

		private FocusLabel focusLabel9;

		private FocusLabel focusLabel12;

		private Iocomp.Design.Plugin.EditorControls.ComboBox WidthStyleCloseComboBox;

		private EditBox WidthCloseEditBox;

		private Container components;

		public PlotChannelCandlestick2SpecificEditorPlugIn()
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
			this.OpenGroupBox = new GroupBox();
			this.focusLabel2 = new FocusLabel();
			this.HeightOpenEditBox = new EditBox();
			this.focusLabel3 = new FocusLabel();
			this.HeightStyleOpenComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.ShowOpenCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.focusLabel5 = new FocusLabel();
			this.WidthOpenEditBox = new EditBox();
			this.focusLabel7 = new FocusLabel();
			this.WidthStyleOpenComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.CloseGroupBox = new GroupBox();
			this.focusLabel4 = new FocusLabel();
			this.HeightCloseEditBox = new EditBox();
			this.focusLabel8 = new FocusLabel();
			this.HeightStyleCloseComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.ShowCloseCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.focusLabel9 = new FocusLabel();
			this.focusLabel12 = new FocusLabel();
			this.WidthStyleCloseComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.WidthCloseEditBox = new EditBox();
			this.BodyGroupBox.SuspendLayout();
			this.OpenGroupBox.SuspendLayout();
			this.CloseGroupBox.SuspendLayout();
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
			this.OpenGroupBox.Controls.Add(this.focusLabel2);
			this.OpenGroupBox.Controls.Add(this.HeightOpenEditBox);
			this.OpenGroupBox.Controls.Add(this.focusLabel3);
			this.OpenGroupBox.Controls.Add(this.HeightStyleOpenComboBox);
			this.OpenGroupBox.Controls.Add(this.ShowOpenCheckBox);
			this.OpenGroupBox.Controls.Add(this.focusLabel5);
			this.OpenGroupBox.Controls.Add(this.focusLabel7);
			this.OpenGroupBox.Controls.Add(this.WidthStyleOpenComboBox);
			this.OpenGroupBox.Controls.Add(this.WidthOpenEditBox);
			this.OpenGroupBox.Location = new Point(16, 80);
			this.OpenGroupBox.Name = "OpenGroupBox";
			this.OpenGroupBox.Size = new Size(416, 104);
			this.OpenGroupBox.TabIndex = 55;
			this.OpenGroupBox.TabStop = false;
			this.OpenGroupBox.Text = "Open";
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.HeightOpenEditBox;
			this.focusLabel2.Location = new Point(26, 74);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(38, 15);
			this.focusLabel2.Text = "Height";
			this.focusLabel2.LoadingEnd();
			this.HeightOpenEditBox.LoadingBegin();
			this.HeightOpenEditBox.Location = new Point(64, 72);
			this.HeightOpenEditBox.Name = "HeightOpenEditBox";
			this.HeightOpenEditBox.PropertyName = "HeightOpen";
			this.HeightOpenEditBox.Size = new Size(56, 20);
			this.HeightOpenEditBox.TabIndex = 62;
			this.HeightOpenEditBox.LoadingEnd();
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.HeightStyleOpenComboBox;
			this.focusLabel3.Location = new Point(142, 74);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(66, 15);
			this.focusLabel3.Text = "Height Style";
			this.focusLabel3.LoadingEnd();
			this.HeightStyleOpenComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.HeightStyleOpenComboBox.Location = new Point(208, 72);
			this.HeightStyleOpenComboBox.MaxDropDownItems = 20;
			this.HeightStyleOpenComboBox.Name = "HeightStyleOpenComboBox";
			this.HeightStyleOpenComboBox.PropertyName = "HeightStyleOpen";
			this.HeightStyleOpenComboBox.Size = new Size(136, 21);
			this.HeightStyleOpenComboBox.TabIndex = 63;
			this.ShowOpenCheckBox.Location = new Point(64, 16);
			this.ShowOpenCheckBox.Name = "ShowOpenCheckBox";
			this.ShowOpenCheckBox.PropertyName = "ShowOpen";
			this.ShowOpenCheckBox.Size = new Size(56, 24);
			this.ShowOpenCheckBox.TabIndex = 59;
			this.ShowOpenCheckBox.Text = "Show";
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.WidthOpenEditBox;
			this.focusLabel5.Location = new Point(29, 50);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(35, 15);
			this.focusLabel5.Text = "Width";
			this.focusLabel5.LoadingEnd();
			this.WidthOpenEditBox.LoadingBegin();
			this.WidthOpenEditBox.Location = new Point(64, 48);
			this.WidthOpenEditBox.Name = "WidthOpenEditBox";
			this.WidthOpenEditBox.PropertyName = "WidthOpen";
			this.WidthOpenEditBox.Size = new Size(56, 20);
			this.WidthOpenEditBox.TabIndex = 1;
			this.WidthOpenEditBox.LoadingEnd();
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.WidthStyleOpenComboBox;
			this.focusLabel7.Location = new Point(146, 50);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(62, 15);
			this.focusLabel7.Text = "Width Style";
			this.focusLabel7.LoadingEnd();
			this.WidthStyleOpenComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.WidthStyleOpenComboBox.Location = new Point(208, 48);
			this.WidthStyleOpenComboBox.MaxDropDownItems = 20;
			this.WidthStyleOpenComboBox.Name = "WidthStyleOpenComboBox";
			this.WidthStyleOpenComboBox.PropertyName = "WidthStyleOpen";
			this.WidthStyleOpenComboBox.Size = new Size(136, 21);
			this.WidthStyleOpenComboBox.TabIndex = 31;
			this.CloseGroupBox.Controls.Add(this.focusLabel4);
			this.CloseGroupBox.Controls.Add(this.HeightCloseEditBox);
			this.CloseGroupBox.Controls.Add(this.focusLabel8);
			this.CloseGroupBox.Controls.Add(this.HeightStyleCloseComboBox);
			this.CloseGroupBox.Controls.Add(this.ShowCloseCheckBox);
			this.CloseGroupBox.Controls.Add(this.focusLabel9);
			this.CloseGroupBox.Controls.Add(this.focusLabel12);
			this.CloseGroupBox.Controls.Add(this.WidthStyleCloseComboBox);
			this.CloseGroupBox.Controls.Add(this.WidthCloseEditBox);
			this.CloseGroupBox.Location = new Point(16, 192);
			this.CloseGroupBox.Name = "CloseGroupBox";
			this.CloseGroupBox.Size = new Size(416, 104);
			this.CloseGroupBox.TabIndex = 58;
			this.CloseGroupBox.TabStop = false;
			this.CloseGroupBox.Text = "Close";
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.HeightCloseEditBox;
			this.focusLabel4.Location = new Point(26, 74);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(38, 15);
			this.focusLabel4.Text = "Height";
			this.focusLabel4.LoadingEnd();
			this.HeightCloseEditBox.LoadingBegin();
			this.HeightCloseEditBox.Location = new Point(64, 72);
			this.HeightCloseEditBox.Name = "HeightCloseEditBox";
			this.HeightCloseEditBox.PropertyName = "HeightClose";
			this.HeightCloseEditBox.Size = new Size(56, 20);
			this.HeightCloseEditBox.TabIndex = 62;
			this.HeightCloseEditBox.LoadingEnd();
			this.focusLabel8.LoadingBegin();
			this.focusLabel8.FocusControl = this.HeightStyleCloseComboBox;
			this.focusLabel8.Location = new Point(142, 74);
			this.focusLabel8.Name = "focusLabel8";
			this.focusLabel8.Size = new Size(66, 15);
			this.focusLabel8.Text = "Height Style";
			this.focusLabel8.LoadingEnd();
			this.HeightStyleCloseComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.HeightStyleCloseComboBox.Location = new Point(208, 72);
			this.HeightStyleCloseComboBox.MaxDropDownItems = 20;
			this.HeightStyleCloseComboBox.Name = "HeightStyleCloseComboBox";
			this.HeightStyleCloseComboBox.PropertyName = "HeightStyleClose";
			this.HeightStyleCloseComboBox.Size = new Size(136, 21);
			this.HeightStyleCloseComboBox.TabIndex = 63;
			this.ShowCloseCheckBox.Location = new Point(64, 16);
			this.ShowCloseCheckBox.Name = "ShowCloseCheckBox";
			this.ShowCloseCheckBox.PropertyName = "ShowClose";
			this.ShowCloseCheckBox.Size = new Size(56, 24);
			this.ShowCloseCheckBox.TabIndex = 59;
			this.ShowCloseCheckBox.Text = "Show";
			this.focusLabel9.LoadingBegin();
			this.focusLabel9.FocusControl = this.WidthCloseEditBox;
			this.focusLabel9.Location = new Point(29, 50);
			this.focusLabel9.Name = "focusLabel9";
			this.focusLabel9.Size = new Size(35, 15);
			this.focusLabel9.Text = "Width";
			this.focusLabel9.LoadingEnd();
			this.focusLabel12.LoadingBegin();
			this.focusLabel12.FocusControl = this.WidthStyleCloseComboBox;
			this.focusLabel12.Location = new Point(146, 50);
			this.focusLabel12.Name = "focusLabel12";
			this.focusLabel12.Size = new Size(62, 15);
			this.focusLabel12.Text = "Width Style";
			this.focusLabel12.LoadingEnd();
			this.WidthStyleCloseComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.WidthStyleCloseComboBox.Location = new Point(208, 48);
			this.WidthStyleCloseComboBox.MaxDropDownItems = 20;
			this.WidthStyleCloseComboBox.Name = "WidthStyleCloseComboBox";
			this.WidthStyleCloseComboBox.PropertyName = "WidthStyleClose";
			this.WidthStyleCloseComboBox.Size = new Size(136, 21);
			this.WidthStyleCloseComboBox.TabIndex = 31;
			this.WidthCloseEditBox.LoadingBegin();
			this.WidthCloseEditBox.Location = new Point(64, 48);
			this.WidthCloseEditBox.Name = "WidthCloseEditBox";
			this.WidthCloseEditBox.PropertyName = "WidthClose";
			this.WidthCloseEditBox.Size = new Size(56, 20);
			this.WidthCloseEditBox.TabIndex = 1;
			this.WidthCloseEditBox.LoadingEnd();
			base.Controls.Add(this.CloseGroupBox);
			base.Controls.Add(this.OpenGroupBox);
			base.Controls.Add(this.BodyGroupBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelCandlestick2SpecificEditorPlugIn";
			base.Size = new Size(728, 320);
			this.BodyGroupBox.ResumeLayout(false);
			this.OpenGroupBox.ResumeLayout(false);
			this.CloseGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
