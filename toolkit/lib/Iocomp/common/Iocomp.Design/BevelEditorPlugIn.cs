using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class BevelEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private FocusLabel label1;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox ThicknessComboBox;

		private FocusLabel label4;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginEdgeNumericUpDown;

		private Container components;

		public BevelEditorPlugIn()
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
			this.StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label2 = new FocusLabel();
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.label1 = new FocusLabel();
			this.ThicknessComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label4 = new FocusLabel();
			this.MarginEdgeNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			base.SuspendLayout();
			this.StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StyleComboBox.Location = new Point(96, 56);
			this.StyleComboBox.MaxDropDownItems = 20;
			this.StyleComboBox.Name = "StyleComboBox";
			this.StyleComboBox.PropertyName = "Style";
			this.StyleComboBox.Size = new Size(144, 21);
			this.StyleComboBox.TabIndex = 1;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.StyleComboBox;
			this.label2.Location = new Point(64, 58);
			this.label2.Name = "label2";
			this.label2.Size = new Size(32, 15);
			this.label2.Text = "Style";
			this.label2.LoadingEnd();
			this.VisibleCheckBox.Location = new Point(96, 24);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.ThicknessComboBox;
			this.label1.Location = new Point(39, 82);
			this.label1.Name = "label1";
			this.label1.Size = new Size(57, 15);
			this.label1.Text = "Thickness";
			this.label1.LoadingEnd();
			this.ThicknessComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.ThicknessComboBox.Location = new Point(96, 80);
			this.ThicknessComboBox.MaxDropDownItems = 20;
			this.ThicknessComboBox.Name = "ThicknessComboBox";
			this.ThicknessComboBox.PropertyName = "Thickness";
			this.ThicknessComboBox.Size = new Size(48, 21);
			this.ThicknessComboBox.TabIndex = 2;
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.MarginEdgeNumericUpDown;
			this.label4.Location = new Point(26, 105);
			this.label4.Name = "label4";
			this.label4.Size = new Size(70, 15);
			this.label4.Text = "Margin Edge";
			this.label4.LoadingEnd();
			this.MarginEdgeNumericUpDown.Location = new Point(96, 104);
			this.MarginEdgeNumericUpDown.Name = "MarginEdgeNumericUpDown";
			this.MarginEdgeNumericUpDown.PropertyName = "MarginEdge";
			this.MarginEdgeNumericUpDown.Size = new Size(48, 20);
			this.MarginEdgeNumericUpDown.TabIndex = 3;
			this.MarginEdgeNumericUpDown.TextAlign = HorizontalAlignment.Center;
			base.Controls.Add(this.MarginEdgeNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ThicknessComboBox);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.StyleComboBox);
			base.Controls.Add(this.label4);
			base.Name = "BevelEditorPlugIn";
			base.Size = new Size(392, 176);
			base.Title = "Bevel Editor";
			base.ResumeLayout(false);
		}
	}
}
