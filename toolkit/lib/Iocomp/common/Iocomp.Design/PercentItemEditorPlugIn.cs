using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PercentItemEditorPlugIn : PlugInStandard
	{
		private EditBox TitleTextBox;

		private FocusLabel label2;

		private EditBox ValueTextBox;

		private FocusLabel label1;

		private FocusLabel label4;

		private ColorPicker ColorPicker;

		private Container components;

		public PercentItemEditorPlugIn()
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
			this.TitleTextBox = new EditBox();
			this.label2 = new FocusLabel();
			this.ValueTextBox = new EditBox();
			this.label1 = new FocusLabel();
			this.ColorPicker = new ColorPicker();
			this.label4 = new FocusLabel();
			base.SuspendLayout();
			this.TitleTextBox.LoadingBegin();
			this.TitleTextBox.Location = new Point(80, 24);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.PropertyName = "Title";
			this.TitleTextBox.Size = new Size(144, 20);
			this.TitleTextBox.TabIndex = 0;
			this.TitleTextBox.LoadingEnd();
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.TitleTextBox;
			this.label2.Location = new Point(52, 26);
			this.label2.Name = "label2";
			this.label2.Size = new Size(28, 15);
			this.label2.Text = "Title";
			this.label2.LoadingEnd();
			this.ValueTextBox.LoadingBegin();
			this.ValueTextBox.Location = new Point(80, 56);
			this.ValueTextBox.Name = "ValueTextBox";
			this.ValueTextBox.PropertyName = "Value";
			this.ValueTextBox.Size = new Size(144, 20);
			this.ValueTextBox.TabIndex = 1;
			this.ValueTextBox.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.ValueTextBox;
			this.label1.Location = new Point(44, 58);
			this.label1.Name = "label1";
			this.label1.Size = new Size(36, 15);
			this.label1.Text = "Value";
			this.label1.LoadingEnd();
			this.ColorPicker.Location = new Point(80, 88);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(144, 21);
			this.ColorPicker.TabIndex = 2;
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.ColorPicker;
			this.label4.Location = new Point(46, 91);
			this.label4.Name = "label4";
			this.label4.Size = new Size(34, 15);
			this.label4.Text = "Color";
			this.label4.LoadingEnd();
			base.Controls.Add(this.TitleTextBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.ValueTextBox);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label4);
			base.Name = "PercentItemEditorPlugIn";
			base.Size = new Size(376, 176);
			base.ResumeLayout(false);
		}
	}
}
