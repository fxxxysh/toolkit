using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PercentLegendColumnEditorPlugIn : PlugInStandard
	{
		private Container components;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private FocusLabel label6;

		private FocusLabel label1;

		private EditBox MarginTextBox;

		private EditBox WidthMinTextBox;

		public PercentLegendColumnEditorPlugIn()
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
			this.MarginTextBox = new EditBox();
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.label6 = new FocusLabel();
			this.WidthMinTextBox = new EditBox();
			this.label1 = new FocusLabel();
			base.SuspendLayout();
			this.MarginTextBox.LoadingBegin();
			this.MarginTextBox.Location = new Point(64, 40);
			this.MarginTextBox.Name = "MarginTextBox";
			this.MarginTextBox.PropertyName = "Margin";
			this.MarginTextBox.Size = new Size(48, 20);
			this.MarginTextBox.TabIndex = 1;
			this.MarginTextBox.TextAlign = HorizontalAlignment.Center;
			this.MarginTextBox.LoadingEnd();
			this.VisibleCheckBox.Location = new Point(64, 0);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(78, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visble";
			this.label6.LoadingBegin();
			this.label6.FocusControl = this.MarginTextBox;
			this.label6.Location = new Point(23, 42);
			this.label6.Name = "label6";
			this.label6.Size = new Size(41, 15);
			this.label6.Text = "Margin";
			this.label6.LoadingEnd();
			this.WidthMinTextBox.LoadingBegin();
			this.WidthMinTextBox.Location = new Point(64, 64);
			this.WidthMinTextBox.Name = "WidthMinTextBox";
			this.WidthMinTextBox.PropertyName = "WidthMin";
			this.WidthMinTextBox.Size = new Size(48, 20);
			this.WidthMinTextBox.TabIndex = 2;
			this.WidthMinTextBox.TextAlign = HorizontalAlignment.Center;
			this.WidthMinTextBox.LoadingEnd();
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.WidthMinTextBox;
			this.label1.Location = new Point(8, 66);
			this.label1.Name = "label1";
			this.label1.Size = new Size(56, 15);
			this.label1.Text = "Width Min";
			this.label1.LoadingEnd();
			base.Controls.Add(this.label1);
			base.Controls.Add(this.WidthMinTextBox);
			base.Controls.Add(this.MarginTextBox);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.label6);
			base.Name = "PercentLegendColumnEditorPlugIn";
			base.Size = new Size(296, 104);
			base.Title = "Column Editor";
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new TextFormatDoubleEditorPlugIn(), "Format", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PercentLegendColumn).Format;
		}
	}
}
