using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotLegendMultiColumnCellFormattingPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private FontButton TitleFontButton;

		private FontButton DataFontButton;

		private GroupBox groupBox1;

		private EditBox MarginOuterTextBox;

		private Container components;

		public PlotLegendMultiColumnCellFormattingPlugIn()
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
			this.label2 = new FocusLabel();
			this.MarginOuterTextBox = new EditBox();
			this.TitleFontButton = new FontButton();
			this.DataFontButton = new FontButton();
			this.groupBox1 = new GroupBox();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.MarginOuterTextBox;
			this.label2.Location = new Point(193, 122);
			this.label2.Name = "label2";
			this.label2.Size = new Size(71, 15);
			this.label2.Text = "Margin Outer";
			this.label2.LoadingEnd();
			this.MarginOuterTextBox.LoadingBegin();
			this.MarginOuterTextBox.Location = new Point(264, 120);
			this.MarginOuterTextBox.Name = "MarginOuterTextBox";
			this.MarginOuterTextBox.PropertyName = "MarginOuter";
			this.MarginOuterTextBox.Size = new Size(48, 20);
			this.MarginOuterTextBox.TabIndex = 1;
			this.MarginOuterTextBox.LoadingEnd();
			this.TitleFontButton.Location = new Point(32, 24);
			this.TitleFontButton.Name = "TitleFontButton";
			this.TitleFontButton.PropertyName = "TitleFont";
			this.TitleFontButton.Size = new Size(80, 25);
			this.TitleFontButton.TabIndex = 0;
			this.TitleFontButton.Text = "Titles";
			this.DataFontButton.Location = new Point(32, 72);
			this.DataFontButton.Name = "DataFontButton";
			this.DataFontButton.PropertyName = "DataFont";
			this.DataFontButton.Size = new Size(80, 25);
			this.DataFontButton.TabIndex = 1;
			this.DataFontButton.Text = "Data";
			this.groupBox1.Controls.Add(this.TitleFontButton);
			this.groupBox1.Controls.Add(this.DataFontButton);
			this.groupBox1.Location = new Point(32, 72);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(136, 112);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Font";
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.MarginOuterTextBox);
			base.Controls.Add(this.label2);
			base.Name = "PlotLegendMultiColumnCellFormattingPlugIn";
			base.Size = new Size(560, 264);
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
