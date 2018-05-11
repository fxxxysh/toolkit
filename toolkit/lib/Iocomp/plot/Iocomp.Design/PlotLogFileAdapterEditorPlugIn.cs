using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotLogFileAdapterEditorPlugIn : PlugInStandard
	{
		private FocusLabel label3;

		private FocusLabel focusLabel1;

		private CheckBox AppendCheckBox;

		private CheckBox AppendFileMustExistCheckBox;

		private CheckBox AllowFileOverwriteCheckBox;

		private EditBox FileNameTextBox;

		private EditBox BufferSizeTextBox;

		private Container components;

		public PlotLogFileAdapterEditorPlugIn()
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
			this.AppendCheckBox = new CheckBox();
			this.AllowFileOverwriteCheckBox = new CheckBox();
			this.AppendFileMustExistCheckBox = new CheckBox();
			this.FileNameTextBox = new EditBox();
			this.label3 = new FocusLabel();
			this.BufferSizeTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			base.SuspendLayout();
			this.AppendCheckBox.Location = new Point(80, 96);
			this.AppendCheckBox.Name = "AppendCheckBox";
			this.AppendCheckBox.PropertyName = "Append";
			this.AppendCheckBox.Size = new Size(72, 24);
			this.AppendCheckBox.TabIndex = 2;
			this.AppendCheckBox.Text = "Append";
			this.AllowFileOverwriteCheckBox.Location = new Point(80, 144);
			this.AllowFileOverwriteCheckBox.Name = "AllowFileOverwriteCheckBox";
			this.AllowFileOverwriteCheckBox.PropertyName = "AllowFileOverwrite";
			this.AllowFileOverwriteCheckBox.Size = new Size(160, 24);
			this.AllowFileOverwriteCheckBox.TabIndex = 4;
			this.AllowFileOverwriteCheckBox.Text = "Allow File Overwrite";
			this.AppendFileMustExistCheckBox.Location = new Point(80, 120);
			this.AppendFileMustExistCheckBox.Name = "AppendFileMustExistCheckBox";
			this.AppendFileMustExistCheckBox.PropertyName = "AppendFileMustExist";
			this.AppendFileMustExistCheckBox.Size = new Size(160, 24);
			this.AppendFileMustExistCheckBox.TabIndex = 3;
			this.AppendFileMustExistCheckBox.Text = "Append File Must Exist";
			this.FileNameTextBox.LoadingBegin();
			this.FileNameTextBox.Location = new Point(80, 32);
			this.FileNameTextBox.Name = "FileNameTextBox";
			this.FileNameTextBox.PropertyName = "FileName";
			this.FileNameTextBox.Size = new Size(189, 20);
			this.FileNameTextBox.TabIndex = 0;
			this.FileNameTextBox.LoadingEnd();
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.FileNameTextBox;
			this.label3.Location = new Point(22, 34);
			this.label3.Name = "label3";
			this.label3.Size = new Size(58, 15);
			this.label3.Text = "File Name";
			this.label3.LoadingEnd();
			this.BufferSizeTextBox.LoadingBegin();
			this.BufferSizeTextBox.Location = new Point(80, 64);
			this.BufferSizeTextBox.Name = "BufferSizeTextBox";
			this.BufferSizeTextBox.PropertyName = "BufferSize";
			this.BufferSizeTextBox.Size = new Size(80, 20);
			this.BufferSizeTextBox.TabIndex = 1;
			this.BufferSizeTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.BufferSizeTextBox;
			this.focusLabel1.Location = new Point(19, 66);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(61, 15);
			this.focusLabel1.Text = "Buffer Size";
			this.focusLabel1.LoadingEnd();
			base.Controls.Add(this.BufferSizeTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.FileNameTextBox);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.AppendFileMustExistCheckBox);
			base.Controls.Add(this.AllowFileOverwriteCheckBox);
			base.Controls.Add(this.AppendCheckBox);
			base.Name = "PlotLogFileAdapterEditorPlugIn";
			base.Size = new Size(424, 288);
			base.ResumeLayout(false);
		}
	}
}
