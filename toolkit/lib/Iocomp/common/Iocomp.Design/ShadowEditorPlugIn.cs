using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class ShadowEditorPlugIn : PlugInStandard
	{
		private FocusLabel ColorLabel;

		private ColorPicker ColorPicker;

		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown OffsetNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.CheckBox StretchedcheckBox;

		private FocusLabel label3;

		private Container components;

		public ShadowEditorPlugIn()
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
			this.ColorLabel = new FocusLabel();
			this.ColorPicker = new ColorPicker();
			this.label2 = new FocusLabel();
			this.StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.OffsetNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.StretchedcheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.label3 = new FocusLabel();
			base.SuspendLayout();
			this.ColorLabel.LoadingBegin();
			this.ColorLabel.AutoSize = false;
			this.ColorLabel.FocusControl = this.ColorPicker;
			this.ColorLabel.Location = new Point(48, 138);
			this.ColorLabel.Name = "ColorLabel";
			this.ColorLabel.Size = new Size(40, 16);
			this.ColorLabel.Text = "Color";
			this.ColorLabel.LoadingEnd();
			this.ColorPicker.Location = new Point(88, 136);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(144, 21);
			this.ColorPicker.TabIndex = 3;
			this.label2.LoadingBegin();
			this.label2.AutoSize = false;
			this.label2.FocusControl = this.StyleComboBox;
			this.label2.Location = new Point(48, 25);
			this.label2.Name = "label2";
			this.label2.Size = new Size(40, 16);
			this.label2.Text = "Style";
			this.label2.LoadingEnd();
			this.StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StyleComboBox.Location = new Point(88, 24);
			this.StyleComboBox.MaxDropDownItems = 20;
			this.StyleComboBox.Name = "StyleComboBox";
			this.StyleComboBox.PropertyName = "Style";
			this.StyleComboBox.Size = new Size(144, 21);
			this.StyleComboBox.TabIndex = 0;
			this.OffsetNumericUpDown.Location = new Point(88, 56);
			this.OffsetNumericUpDown.Name = "OffsetNumericUpDown";
			this.OffsetNumericUpDown.PropertyName = "Offset";
			this.OffsetNumericUpDown.Size = new Size(48, 20);
			this.OffsetNumericUpDown.TabIndex = 1;
			this.OffsetNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.StretchedcheckBox.Location = new Point(88, 96);
			this.StretchedcheckBox.Name = "StretchedcheckBox";
			this.StretchedcheckBox.PropertyName = "Stretched";
			this.StretchedcheckBox.Size = new Size(80, 24);
			this.StretchedcheckBox.TabIndex = 2;
			this.StretchedcheckBox.Text = "Stretched";
			this.label3.LoadingBegin();
			this.label3.AutoSize = false;
			this.label3.FocusControl = this.OffsetNumericUpDown;
			this.label3.Location = new Point(50, 56);
			this.label3.Name = "label3";
			this.label3.Size = new Size(38, 16);
			this.label3.Text = "Offset";
			this.label3.LoadingEnd();
			base.Controls.Add(this.ColorLabel);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.StyleComboBox);
			base.Controls.Add(this.OffsetNumericUpDown);
			base.Controls.Add(this.StretchedcheckBox);
			base.Controls.Add(this.label3);
			base.Location = new Point(10, 20);
			base.Name = "ShadowEditorPlugIn";
			base.Size = new Size(544, 248);
			base.Title = "Shadow Editor";
			base.ResumeLayout(false);
		}
	}
}
