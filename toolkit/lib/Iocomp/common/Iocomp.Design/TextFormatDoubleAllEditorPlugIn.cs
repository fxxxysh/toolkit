using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public sealed class TextFormatDoubleAllEditorPlugIn : PlugInStandard
	{
		private FocusLabel label2;

		private FocusLabel label11;

		private Iocomp.Design.Plugin.EditorControls.ComboBox PrecisionStyleComboBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown PrecisionNumericUpDown;

		private FocusLabel label1;

		private EditMultiLine UnitsTextEditMultiLine;

		private FocusLabel label3;

		private FocusLabel label4;

		private EditMultiLine DateTimeFormatEditMultiLine;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private Container components;

		public TextFormatDoubleAllEditorPlugIn()
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
			this.PrecisionStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.UnitsTextEditMultiLine = new EditMultiLine();
			this.label11 = new FocusLabel();
			this.PrecisionNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			this.DateTimeFormatEditMultiLine = new EditMultiLine();
			this.label3 = new FocusLabel();
			this.StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label4 = new FocusLabel();
			base.SuspendLayout();
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.PrecisionStyleComboBox;
			this.label2.Location = new Point(120, 90);
			this.label2.Name = "label2";
			this.label2.Size = new Size(80, 15);
			this.label2.Text = "Precision Style";
			this.label2.LoadingEnd();
			this.PrecisionStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.PrecisionStyleComboBox.Location = new Point(200, 88);
			this.PrecisionStyleComboBox.Name = "PrecisionStyleComboBox";
			this.PrecisionStyleComboBox.PropertyName = "PrecisionStyle";
			this.PrecisionStyleComboBox.Size = new Size(144, 21);
			this.PrecisionStyleComboBox.TabIndex = 1;
			this.UnitsTextEditMultiLine.EditFont = null;
			this.UnitsTextEditMultiLine.Location = new Point(200, 184);
			this.UnitsTextEditMultiLine.Name = "UnitsTextEditMultiLine";
			this.UnitsTextEditMultiLine.PropertyName = "UnitsText";
			this.UnitsTextEditMultiLine.Size = new Size(142, 20);
			this.UnitsTextEditMultiLine.TabIndex = 4;
			this.label11.LoadingBegin();
			this.label11.FocusControl = this.UnitsTextEditMultiLine;
			this.label11.Location = new Point(143, 187);
			this.label11.Name = "label11";
			this.label11.Size = new Size(57, 15);
			this.label11.Text = "Units Text";
			this.label11.LoadingEnd();
			this.PrecisionNumericUpDown.Location = new Point(200, 116);
			this.PrecisionNumericUpDown.Maximum = new decimal(new int[4]
			{
				16,
				0,
				0,
				0
			});
			this.PrecisionNumericUpDown.Name = "PrecisionNumericUpDown";
			this.PrecisionNumericUpDown.PropertyName = "Precision";
			this.PrecisionNumericUpDown.Size = new Size(48, 20);
			this.PrecisionNumericUpDown.TabIndex = 2;
			this.PrecisionNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.PrecisionNumericUpDown;
			this.label1.Location = new Point(147, 117);
			this.label1.Name = "label1";
			this.label1.Size = new Size(53, 15);
			this.label1.Text = "Precision";
			this.label1.LoadingEnd();
			this.DateTimeFormatEditMultiLine.EditFont = null;
			this.DateTimeFormatEditMultiLine.Location = new Point(200, 152);
			this.DateTimeFormatEditMultiLine.Name = "DateTimeFormatEditMultiLine";
			this.DateTimeFormatEditMultiLine.PropertyName = "DateTimeFormat";
			this.DateTimeFormatEditMultiLine.Size = new Size(142, 20);
			this.DateTimeFormatEditMultiLine.TabIndex = 3;
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.DateTimeFormatEditMultiLine;
			this.label3.Location = new Point(104, 155);
			this.label3.Name = "label3";
			this.label3.Size = new Size(96, 15);
			this.label3.Text = "Date Time Format";
			this.label3.LoadingEnd();
			this.StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StyleComboBox.Location = new Point(200, 48);
			this.StyleComboBox.Name = "StyleComboBox";
			this.StyleComboBox.PropertyName = "Style";
			this.StyleComboBox.Size = new Size(144, 21);
			this.StyleComboBox.TabIndex = 0;
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.StyleComboBox;
			this.label4.Location = new Point(168, 50);
			this.label4.Name = "label4";
			this.label4.Size = new Size(32, 15);
			this.label4.Text = "Style";
			this.label4.LoadingEnd();
			base.Controls.Add(this.StyleComboBox);
			base.Controls.Add(this.DateTimeFormatEditMultiLine);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.PrecisionNumericUpDown);
			base.Controls.Add(this.UnitsTextEditMultiLine);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.PrecisionStyleComboBox);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label4);
			base.Location = new Point(10, 20);
			base.Name = "TextFormatDoubleAllEditorPlugIn";
			base.Size = new Size(392, 224);
			base.Title = "Text Formatting Editor";
			base.ResumeLayout(false);
		}
	}
}
