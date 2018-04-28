using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public sealed class TextFormatDoubleEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.NumericUpDown PrecisionNumericUpDown;

		private EditMultiLine UnitsTextEditMultiLine;

		private FocusLabel label11;

		private Iocomp.Design.Plugin.EditorControls.ComboBox PrecisionStyleComboBox;

		private FocusLabel label1;

		private FocusLabel label2;

		private Container components;

		public TextFormatDoubleEditorPlugIn()
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
			this.PrecisionNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.UnitsTextEditMultiLine = new EditMultiLine();
			this.label11 = new FocusLabel();
			this.PrecisionStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label1 = new FocusLabel();
			this.label2 = new FocusLabel();
			base.SuspendLayout();
			this.PrecisionNumericUpDown.Location = new Point(96, 80);
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
			this.PrecisionNumericUpDown.TabIndex = 1;
			this.PrecisionNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.UnitsTextEditMultiLine.EditFont = null;
			this.UnitsTextEditMultiLine.Location = new Point(288, 48);
			this.UnitsTextEditMultiLine.Name = "UnitsTextEditMultiLine";
			this.UnitsTextEditMultiLine.PropertyName = "UnitsText";
			this.UnitsTextEditMultiLine.Size = new Size(142, 20);
			this.UnitsTextEditMultiLine.TabIndex = 2;
			this.label11.LoadingBegin();
			this.label11.AutoSize = false;
			this.label11.FocusControl = this.UnitsTextEditMultiLine;
			this.label11.Location = new Point(224, 50);
			this.label11.Name = "label11";
			this.label11.Size = new Size(64, 16);
			this.label11.Text = "Units Text";
			this.label11.LoadingEnd();
			this.PrecisionStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.PrecisionStyleComboBox.Location = new Point(96, 48);
			this.PrecisionStyleComboBox.Name = "PrecisionStyleComboBox";
			this.PrecisionStyleComboBox.PropertyName = "PrecisionStyle";
			this.PrecisionStyleComboBox.Size = new Size(121, 21);
			this.PrecisionStyleComboBox.TabIndex = 0;
			this.label1.LoadingBegin();
			this.label1.AutoSize = false;
			this.label1.FocusControl = this.PrecisionNumericUpDown;
			this.label1.Location = new Point(40, 80);
			this.label1.Name = "label1";
			this.label1.Size = new Size(56, 16);
			this.label1.Text = "Precision";
			this.label1.LoadingEnd();
			this.label2.LoadingBegin();
			this.label2.AutoSize = false;
			this.label2.FocusControl = this.PrecisionStyleComboBox;
			this.label2.Location = new Point(8, 49);
			this.label2.Name = "label2";
			this.label2.Size = new Size(88, 16);
			this.label2.Text = "Precision Style";
			this.label2.LoadingEnd();
			base.Controls.Add(this.PrecisionNumericUpDown);
			base.Controls.Add(this.UnitsTextEditMultiLine);
			base.Controls.Add(this.label11);
			base.Controls.Add(this.PrecisionStyleComboBox);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label2);
			base.Location = new Point(10, 20);
			base.Name = "TextFormatDoubleEditorPlugIn";
			base.Size = new Size(512, 224);
			base.Title = "Text Formatting Editor";
			base.ResumeLayout(false);
		}
	}
}
