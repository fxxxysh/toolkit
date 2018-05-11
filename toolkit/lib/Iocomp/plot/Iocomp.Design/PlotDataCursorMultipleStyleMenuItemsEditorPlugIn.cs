using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotDataCursorMultipleStyleMenuItemsEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel2;

		private EditBox CaptionValueXTextBox;

		private FocusLabel focusLabel1;

		private FocusLabel focusLabel3;

		private FocusLabel focusLabel4;

		private FocusLabel focusLabel5;

		private FocusLabel focusLabel6;

		private FocusLabel focusLabel7;

		private EditBox CaptionValueYEditBox;

		private EditBox CaptionValueXYEditBox;

		private EditBox CaptionDeltaXEditBox;

		private EditBox CaptionDeltaYEditBox;

		private EditBox CaptionInverseDeltaXEditBox;

		private EditBox CaptionInverseDeltaYEditBox;

		private CheckBox ShowValueYCheckBox;

		private CheckBox ShowValueXYCheckBox;

		private CheckBox ShowDeltaXCheckBox;

		private CheckBox ShowValueXCheckBox;

		private CheckBox ShowDeltaYCheckBox;

		private CheckBox ShowInverseDeltaXCheckBox;

		private CheckBox ShowInverseDeltaYCheckBox;

		private Container components;

		public PlotDataCursorMultipleStyleMenuItemsEditorPlugIn()
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
			this.ShowValueXCheckBox = new CheckBox();
			this.CaptionValueXTextBox = new EditBox();
			this.focusLabel2 = new FocusLabel();
			this.CaptionValueYEditBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.ShowValueYCheckBox = new CheckBox();
			this.CaptionValueXYEditBox = new EditBox();
			this.focusLabel3 = new FocusLabel();
			this.ShowValueXYCheckBox = new CheckBox();
			this.CaptionDeltaXEditBox = new EditBox();
			this.focusLabel4 = new FocusLabel();
			this.ShowDeltaXCheckBox = new CheckBox();
			this.CaptionDeltaYEditBox = new EditBox();
			this.focusLabel5 = new FocusLabel();
			this.ShowDeltaYCheckBox = new CheckBox();
			this.CaptionInverseDeltaXEditBox = new EditBox();
			this.focusLabel6 = new FocusLabel();
			this.ShowInverseDeltaXCheckBox = new CheckBox();
			this.CaptionInverseDeltaYEditBox = new EditBox();
			this.focusLabel7 = new FocusLabel();
			this.ShowInverseDeltaYCheckBox = new CheckBox();
			base.SuspendLayout();
			this.ShowValueXCheckBox.Location = new Point(288, 87);
			this.ShowValueXCheckBox.Name = "ShowValueXCheckBox";
			this.ShowValueXCheckBox.PropertyName = "ShowValueX";
			this.ShowValueXCheckBox.Size = new Size(60, 24);
			this.ShowValueXCheckBox.TabIndex = 1;
			this.ShowValueXCheckBox.Text = "Show";
			this.CaptionValueXTextBox.LoadingBegin();
			this.CaptionValueXTextBox.Location = new Point(144, 88);
			this.CaptionValueXTextBox.Name = "CaptionValueXTextBox";
			this.CaptionValueXTextBox.PropertyName = "CaptionValueX";
			this.CaptionValueXTextBox.Size = new Size(136, 20);
			this.CaptionValueXTextBox.TabIndex = 0;
			this.CaptionValueXTextBox.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.CaptionValueXTextBox;
			this.focusLabel2.Location = new Point(57, 90);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(87, 15);
			this.focusLabel2.Text = "Caption Value X";
			this.focusLabel2.LoadingEnd();
			this.CaptionValueYEditBox.LoadingBegin();
			this.CaptionValueYEditBox.Location = new Point(144, 112);
			this.CaptionValueYEditBox.Name = "CaptionValueYEditBox";
			this.CaptionValueYEditBox.PropertyName = "CaptionValueY";
			this.CaptionValueYEditBox.Size = new Size(136, 20);
			this.CaptionValueYEditBox.TabIndex = 2;
			this.CaptionValueYEditBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.CaptionValueYEditBox;
			this.focusLabel1.Location = new Point(57, 114);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(87, 15);
			this.focusLabel1.Text = "Caption Value Y";
			this.focusLabel1.LoadingEnd();
			this.ShowValueYCheckBox.Location = new Point(288, 112);
			this.ShowValueYCheckBox.Name = "ShowValueYCheckBox";
			this.ShowValueYCheckBox.PropertyName = "ShowValueY";
			this.ShowValueYCheckBox.Size = new Size(60, 24);
			this.ShowValueYCheckBox.TabIndex = 3;
			this.ShowValueYCheckBox.Text = "Show";
			this.CaptionValueXYEditBox.LoadingBegin();
			this.CaptionValueXYEditBox.Location = new Point(144, 136);
			this.CaptionValueXYEditBox.Name = "CaptionValueXYEditBox";
			this.CaptionValueXYEditBox.PropertyName = "CaptionValueXY";
			this.CaptionValueXYEditBox.Size = new Size(136, 20);
			this.CaptionValueXYEditBox.TabIndex = 4;
			this.CaptionValueXYEditBox.LoadingEnd();
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.CaptionValueXYEditBox;
			this.focusLabel3.Location = new Point(50, 138);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(94, 15);
			this.focusLabel3.Text = "Caption Value XY";
			this.focusLabel3.LoadingEnd();
			this.ShowValueXYCheckBox.Location = new Point(288, 136);
			this.ShowValueXYCheckBox.Name = "ShowValueXYCheckBox";
			this.ShowValueXYCheckBox.PropertyName = "ShowValueXY";
			this.ShowValueXYCheckBox.Size = new Size(60, 24);
			this.ShowValueXYCheckBox.TabIndex = 5;
			this.ShowValueXYCheckBox.Text = "Show";
			this.CaptionDeltaXEditBox.LoadingBegin();
			this.CaptionDeltaXEditBox.Location = new Point(144, 160);
			this.CaptionDeltaXEditBox.Name = "CaptionDeltaXEditBox";
			this.CaptionDeltaXEditBox.PropertyName = "CaptionDeltaX";
			this.CaptionDeltaXEditBox.Size = new Size(136, 20);
			this.CaptionDeltaXEditBox.TabIndex = 6;
			this.CaptionDeltaXEditBox.LoadingEnd();
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.CaptionDeltaXEditBox;
			this.focusLabel4.Location = new Point(60, 162);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(84, 15);
			this.focusLabel4.Text = "Caption Delta X";
			this.focusLabel4.LoadingEnd();
			this.ShowDeltaXCheckBox.Location = new Point(288, 160);
			this.ShowDeltaXCheckBox.Name = "ShowDeltaXCheckBox";
			this.ShowDeltaXCheckBox.PropertyName = "ShowDeltaX";
			this.ShowDeltaXCheckBox.Size = new Size(60, 24);
			this.ShowDeltaXCheckBox.TabIndex = 7;
			this.ShowDeltaXCheckBox.Text = "Show";
			this.CaptionDeltaYEditBox.LoadingBegin();
			this.CaptionDeltaYEditBox.Location = new Point(144, 184);
			this.CaptionDeltaYEditBox.Name = "CaptionDeltaYEditBox";
			this.CaptionDeltaYEditBox.PropertyName = "CaptionDeltaY";
			this.CaptionDeltaYEditBox.Size = new Size(136, 20);
			this.CaptionDeltaYEditBox.TabIndex = 8;
			this.CaptionDeltaYEditBox.LoadingEnd();
			this.focusLabel5.LoadingBegin();
			this.focusLabel5.FocusControl = this.CaptionDeltaYEditBox;
			this.focusLabel5.Location = new Point(60, 186);
			this.focusLabel5.Name = "focusLabel5";
			this.focusLabel5.Size = new Size(84, 15);
			this.focusLabel5.Text = "Caption Delta Y";
			this.focusLabel5.LoadingEnd();
			this.ShowDeltaYCheckBox.Location = new Point(288, 184);
			this.ShowDeltaYCheckBox.Name = "ShowDeltaYCheckBox";
			this.ShowDeltaYCheckBox.PropertyName = "ShowDeltaY";
			this.ShowDeltaYCheckBox.Size = new Size(60, 24);
			this.ShowDeltaYCheckBox.TabIndex = 9;
			this.ShowDeltaYCheckBox.Text = "Show";
			this.CaptionInverseDeltaXEditBox.LoadingBegin();
			this.CaptionInverseDeltaXEditBox.Location = new Point(144, 208);
			this.CaptionInverseDeltaXEditBox.Name = "CaptionInverseDeltaXEditBox";
			this.CaptionInverseDeltaXEditBox.PropertyName = "CaptionInverseDeltaX";
			this.CaptionInverseDeltaXEditBox.Size = new Size(136, 20);
			this.CaptionInverseDeltaXEditBox.TabIndex = 10;
			this.CaptionInverseDeltaXEditBox.LoadingEnd();
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.CaptionInverseDeltaXEditBox;
			this.focusLabel6.Location = new Point(21, 210);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(123, 15);
			this.focusLabel6.Text = "Caption Inverse Delta X";
			this.focusLabel6.LoadingEnd();
			this.ShowInverseDeltaXCheckBox.Location = new Point(288, 208);
			this.ShowInverseDeltaXCheckBox.Name = "ShowInverseDeltaXCheckBox";
			this.ShowInverseDeltaXCheckBox.PropertyName = "ShowInverseDeltaX";
			this.ShowInverseDeltaXCheckBox.Size = new Size(60, 24);
			this.ShowInverseDeltaXCheckBox.TabIndex = 11;
			this.ShowInverseDeltaXCheckBox.Text = "Show";
			this.CaptionInverseDeltaYEditBox.LoadingBegin();
			this.CaptionInverseDeltaYEditBox.Location = new Point(144, 232);
			this.CaptionInverseDeltaYEditBox.Name = "CaptionInverseDeltaYEditBox";
			this.CaptionInverseDeltaYEditBox.PropertyName = "CaptionInverseDeltaY";
			this.CaptionInverseDeltaYEditBox.Size = new Size(136, 20);
			this.CaptionInverseDeltaYEditBox.TabIndex = 12;
			this.CaptionInverseDeltaYEditBox.LoadingEnd();
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.CaptionInverseDeltaYEditBox;
			this.focusLabel7.Location = new Point(21, 234);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(123, 15);
			this.focusLabel7.Text = "Caption Inverse Delta Y";
			this.focusLabel7.LoadingEnd();
			this.ShowInverseDeltaYCheckBox.Location = new Point(288, 232);
			this.ShowInverseDeltaYCheckBox.Name = "ShowInverseDeltaYCheckBox";
			this.ShowInverseDeltaYCheckBox.PropertyName = "ShowInverseDeltaY";
			this.ShowInverseDeltaYCheckBox.Size = new Size(60, 24);
			this.ShowInverseDeltaYCheckBox.TabIndex = 13;
			this.ShowInverseDeltaYCheckBox.Text = "Show";
			base.Controls.Add(this.CaptionInverseDeltaYEditBox);
			base.Controls.Add(this.focusLabel7);
			base.Controls.Add(this.ShowInverseDeltaYCheckBox);
			base.Controls.Add(this.CaptionInverseDeltaXEditBox);
			base.Controls.Add(this.focusLabel6);
			base.Controls.Add(this.ShowInverseDeltaXCheckBox);
			base.Controls.Add(this.CaptionDeltaYEditBox);
			base.Controls.Add(this.focusLabel5);
			base.Controls.Add(this.ShowDeltaYCheckBox);
			base.Controls.Add(this.CaptionDeltaXEditBox);
			base.Controls.Add(this.focusLabel4);
			base.Controls.Add(this.ShowDeltaXCheckBox);
			base.Controls.Add(this.CaptionValueXYEditBox);
			base.Controls.Add(this.focusLabel3);
			base.Controls.Add(this.ShowValueXYCheckBox);
			base.Controls.Add(this.CaptionValueYEditBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.ShowValueYCheckBox);
			base.Controls.Add(this.CaptionValueXTextBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.ShowValueXCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotDataCursorMultipleStyleMenuItemsEditorPlugIn";
			base.Size = new Size(504, 336);
			base.ResumeLayout(false);
		}
	}
}
