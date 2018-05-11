using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class AlignmentTextEditorPlugIn : PlugInStandard
	{
		private FocusLabel label3;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private EditBox MarginTextBox;

		private Container components;

		public AlignmentTextEditorPlugIn()
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
			this.label3 = new FocusLabel();
			this.MarginTextBox = new EditBox();
			this.StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label2 = new FocusLabel();
			base.SuspendLayout();
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.MarginTextBox;
			this.label3.Location = new Point(31, 50);
			this.label3.Name = "label3";
			this.label3.Size = new Size(41, 15);
			this.label3.Text = "Margin";
			this.label3.LoadingEnd();
			this.MarginTextBox.LoadingBegin();
			this.MarginTextBox.Location = new Point(72, 48);
			this.MarginTextBox.Name = "MarginTextBox";
			this.MarginTextBox.PropertyName = "Margin";
			this.MarginTextBox.Size = new Size(40, 20);
			this.MarginTextBox.TabIndex = 1;
			this.MarginTextBox.LoadingEnd();
			this.StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StyleComboBox.Location = new Point(72, 16);
			this.StyleComboBox.MaxDropDownItems = 20;
			this.StyleComboBox.Name = "StyleComboBox";
			this.StyleComboBox.PropertyName = "Style";
			this.StyleComboBox.Size = new Size(144, 21);
			this.StyleComboBox.TabIndex = 0;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.StyleComboBox;
			this.label2.Location = new Point(40, 18);
			this.label2.Name = "label2";
			this.label2.Size = new Size(32, 15);
			this.label2.Text = "Style";
			this.label2.LoadingEnd();
			base.Controls.Add(this.MarginTextBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.StyleComboBox);
			base.Controls.Add(this.label3);
			base.Name = "AlignmentTextEditorPlugIn";
			base.Size = new Size(328, 88);
			base.Title = "Alignment Editor";
			base.ResumeLayout(false);
		}
	}
}
