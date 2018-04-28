using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class TextFormatIntegerEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown FixedLengthNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private Container components;

		public TextFormatIntegerEditorPlugIn()
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
			this.StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.FixedLengthNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			base.SuspendLayout();
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.StyleComboBox;
			this.label2.Location = new Point(64, 26);
			this.label2.Name = "label2";
			this.label2.Size = new Size(32, 15);
			this.label2.Text = "Style";
			this.label2.LoadingEnd();
			this.StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StyleComboBox.Location = new Point(96, 24);
			this.StyleComboBox.Name = "StyleComboBox";
			this.StyleComboBox.PropertyName = "Style";
			this.StyleComboBox.Size = new Size(121, 21);
			this.StyleComboBox.TabIndex = 0;
			this.FixedLengthNumericUpDown.Location = new Point(96, 56);
			this.FixedLengthNumericUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			this.FixedLengthNumericUpDown.Name = "FixedLengthNumericUpDown";
			this.FixedLengthNumericUpDown.PropertyName = "FixedLength";
			this.FixedLengthNumericUpDown.Size = new Size(48, 20);
			this.FixedLengthNumericUpDown.TabIndex = 1;
			this.FixedLengthNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.FixedLengthNumericUpDown;
			this.label1.Location = new Point(25, 57);
			this.label1.Name = "label1";
			this.label1.Size = new Size(71, 15);
			this.label1.Text = "Fixed Length";
			this.label1.LoadingEnd();
			base.Controls.Add(this.FixedLengthNumericUpDown);
			base.Controls.Add(this.StyleComboBox);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label2);
			base.Location = new Point(10, 20);
			base.Name = "TextFormatIntegerEditorPlugIn";
			base.Size = new Size(520, 144);
			base.Title = "Text Formatting Editor";
			base.ResumeLayout(false);
		}
	}
}
