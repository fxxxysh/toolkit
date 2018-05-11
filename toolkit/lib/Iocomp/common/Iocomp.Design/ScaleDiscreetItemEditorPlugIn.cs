using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class ScaleDiscreetItemEditorPlugIn : PlugInStandard
	{
		private EditBox TitleTextBox;

		private FocusLabel label2;

		private Container components;

		public ScaleDiscreetItemEditorPlugIn()
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
			base.SuspendLayout();
			this.TitleTextBox.LoadingBegin();
			this.TitleTextBox.Location = new Point(72, 48);
			this.TitleTextBox.Name = "TitleTextBox";
			this.TitleTextBox.PropertyName = "Text";
			this.TitleTextBox.Size = new Size(144, 20);
			this.TitleTextBox.TabIndex = 0;
			this.TitleTextBox.LoadingEnd();
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.TitleTextBox;
			this.label2.Location = new Point(43, 50);
			this.label2.Name = "label2";
			this.label2.Size = new Size(29, 15);
			this.label2.Text = "Text";
			this.label2.LoadingEnd();
			base.Controls.Add(this.TitleTextBox);
			base.Controls.Add(this.label2);
			base.Name = "ScaleDiscreetItemEditorPlugIn";
			base.Size = new Size(224, 112);
			base.ResumeLayout(false);
		}
	}
}
