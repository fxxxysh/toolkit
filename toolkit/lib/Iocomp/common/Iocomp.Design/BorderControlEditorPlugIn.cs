using Iocomp.Design.Plugin.EditorControls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class BorderControlEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginNumericUpDown;

		private FocusLabel label3;

		private FocusLabel label4;

		private ColorPicker ColorPicker;

		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private GroupBox groupBox1;

		private FocusLabel label5;

		private FocusLabel label6;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown ThicknessDesiredNumericUpDown;

		private EditBox ThicknessActualTextBox;

		private GroupBox groupBox2;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginTopNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginBottomNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginLeftNumericUpDown;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown MarginRightNumericUpDown;

		private Container components;

		public BorderControlEditorPlugIn()
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
			this.MarginNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label3 = new FocusLabel();
			this.label4 = new FocusLabel();
			this.ColorPicker = new ColorPicker();
			this.StyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label2 = new FocusLabel();
			this.groupBox1 = new GroupBox();
			this.ThicknessActualTextBox = new EditBox();
			this.label5 = new FocusLabel();
			this.ThicknessDesiredNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label6 = new FocusLabel();
			this.groupBox2 = new GroupBox();
			this.MarginRightNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.MarginLeftNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.MarginBottomNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.MarginTopNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			((ISupportInitialize)this.MarginNumericUpDown).BeginInit();
			this.groupBox1.SuspendLayout();
			((ISupportInitialize)this.ThicknessDesiredNumericUpDown).BeginInit();
			this.groupBox2.SuspendLayout();
			((ISupportInitialize)this.MarginRightNumericUpDown).BeginInit();
			((ISupportInitialize)this.MarginLeftNumericUpDown).BeginInit();
			((ISupportInitialize)this.MarginBottomNumericUpDown).BeginInit();
			((ISupportInitialize)this.MarginTopNumericUpDown).BeginInit();
			base.SuspendLayout();
			this.MarginNumericUpDown.Location = new Point(48, 152);
			this.MarginNumericUpDown.Maximum = new decimal(new int[4]
			{
				0,
				0,
				-2147483648,
				0
			});
			this.MarginNumericUpDown.Name = "MarginNumericUpDown";
			this.MarginNumericUpDown.PropertyName = "Margin";
			this.MarginNumericUpDown.Size = new Size(48, 20);
			this.MarginNumericUpDown.TabIndex = 3;
			this.MarginNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.MarginNumericUpDown;
			this.label3.Location = new Point(7, 153);
			this.label3.Name = "label3";
			this.label3.Size = new Size(41, 15);
			this.label3.Text = "Margin";
			this.label3.LoadingEnd();
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.ColorPicker;
			this.label4.Location = new Point(14, 43);
			this.label4.Name = "label4";
			this.label4.Size = new Size(34, 15);
			this.label4.Text = "Color";
			this.label4.LoadingEnd();
			this.ColorPicker.Location = new Point(48, 40);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(144, 21);
			this.ColorPicker.TabIndex = 1;
			this.StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StyleComboBox.Location = new Point(48, 8);
			this.StyleComboBox.MaxDropDownItems = 20;
			this.StyleComboBox.Name = "StyleComboBox";
			this.StyleComboBox.PropertyName = "Style";
			this.StyleComboBox.Size = new Size(144, 21);
			this.StyleComboBox.TabIndex = 0;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.StyleComboBox;
			this.label2.Location = new Point(16, 10);
			this.label2.Name = "label2";
			this.label2.Size = new Size(32, 15);
			this.label2.Text = "Style";
			this.label2.LoadingEnd();
			this.groupBox1.Controls.Add(this.ThicknessActualTextBox);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.ThicknessDesiredNumericUpDown);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Location = new Point(216, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(128, 78);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Thickness";
			this.ThicknessActualTextBox.LoadingBegin();
			this.ThicknessActualTextBox.Location = new Point(64, 48);
			this.ThicknessActualTextBox.Name = "ThicknessActualTextBox";
			this.ThicknessActualTextBox.PropertyName = "ThicknessActual";
			this.ThicknessActualTextBox.ReadOnly = true;
			this.ThicknessActualTextBox.Size = new Size(32, 20);
			this.ThicknessActualTextBox.TabIndex = 1;
			this.ThicknessActualTextBox.TextAlign = HorizontalAlignment.Center;
			this.ThicknessActualTextBox.LoadingEnd();
			this.label5.LoadingBegin();
			this.label5.FocusControl = this.ThicknessActualTextBox;
			this.label5.Location = new Point(26, 50);
			this.label5.Name = "label5";
			this.label5.Size = new Size(38, 15);
			this.label5.Text = "Actual";
			this.label5.LoadingEnd();
			this.ThicknessDesiredNumericUpDown.Location = new Point(64, 24);
			this.ThicknessDesiredNumericUpDown.Minimum = new decimal(new int[4]
			{
				2,
				0,
				0,
				0
			});
			this.ThicknessDesiredNumericUpDown.Name = "ThicknessDesiredNumericUpDown";
			this.ThicknessDesiredNumericUpDown.PropertyName = "ThicknessDesired";
			this.ThicknessDesiredNumericUpDown.Size = new Size(48, 20);
			this.ThicknessDesiredNumericUpDown.TabIndex = 0;
			this.ThicknessDesiredNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label6.LoadingBegin();
			this.label6.FocusControl = this.ThicknessDesiredNumericUpDown;
			this.label6.Location = new Point(19, 25);
			this.label6.Name = "label6";
			this.label6.Size = new Size(45, 15);
			this.label6.Text = "Desired";
			this.label6.LoadingEnd();
			this.groupBox2.Controls.Add(this.MarginRightNumericUpDown);
			this.groupBox2.Controls.Add(this.MarginLeftNumericUpDown);
			this.groupBox2.Controls.Add(this.MarginBottomNumericUpDown);
			this.groupBox2.Controls.Add(this.MarginTopNumericUpDown);
			this.groupBox2.Location = new Point(120, 96);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new Size(224, 128);
			this.groupBox2.TabIndex = 4;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Margin";
			this.groupBox2.Enter += this.groupBox2_Enter;
			this.MarginRightNumericUpDown.Location = new Point(144, 56);
			this.MarginRightNumericUpDown.Maximum = new decimal(new int[4]
			{
				5000,
				0,
				0,
				0
			});
			this.MarginRightNumericUpDown.Minimum = new decimal(new int[4]
			{
				5000,
				0,
				0,
				-2147483648
			});
			this.MarginRightNumericUpDown.Name = "MarginRightNumericUpDown";
			this.MarginRightNumericUpDown.PropertyName = "MarginRight";
			this.MarginRightNumericUpDown.Size = new Size(48, 20);
			this.MarginRightNumericUpDown.TabIndex = 2;
			this.MarginRightNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.MarginLeftNumericUpDown.Location = new Point(48, 56);
			this.MarginLeftNumericUpDown.Maximum = new decimal(new int[4]
			{
				5000,
				0,
				0,
				0
			});
			this.MarginLeftNumericUpDown.Minimum = new decimal(new int[4]
			{
				5000,
				0,
				0,
				-2147483648
			});
			this.MarginLeftNumericUpDown.Name = "MarginLeftNumericUpDown";
			this.MarginLeftNumericUpDown.PropertyName = "MarginLeft";
			this.MarginLeftNumericUpDown.Size = new Size(48, 20);
			this.MarginLeftNumericUpDown.TabIndex = 1;
			this.MarginLeftNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.MarginBottomNumericUpDown.Location = new Point(96, 88);
			this.MarginBottomNumericUpDown.Maximum = new decimal(new int[4]
			{
				5000,
				0,
				0,
				0
			});
			this.MarginBottomNumericUpDown.Minimum = new decimal(new int[4]
			{
				5000,
				0,
				0,
				-2147483648
			});
			this.MarginBottomNumericUpDown.Name = "MarginBottomNumericUpDown";
			this.MarginBottomNumericUpDown.PropertyName = "MarginBottom";
			this.MarginBottomNumericUpDown.Size = new Size(48, 20);
			this.MarginBottomNumericUpDown.TabIndex = 3;
			this.MarginBottomNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.MarginTopNumericUpDown.Location = new Point(96, 24);
			this.MarginTopNumericUpDown.Maximum = new decimal(new int[4]
			{
				5000,
				0,
				0,
				0
			});
			this.MarginTopNumericUpDown.Minimum = new decimal(new int[4]
			{
				5000,
				0,
				0,
				-2147483648
			});
			this.MarginTopNumericUpDown.Name = "MarginTopNumericUpDown";
			this.MarginTopNumericUpDown.PropertyName = "MarginTop";
			this.MarginTopNumericUpDown.Size = new Size(48, 20);
			this.MarginTopNumericUpDown.TabIndex = 0;
			this.MarginTopNumericUpDown.TextAlign = HorizontalAlignment.Center;
			base.Controls.Add(this.groupBox2);
			base.Controls.Add(this.groupBox1);
			base.Controls.Add(this.StyleComboBox);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.MarginNumericUpDown);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Name = "BorderControlEditorPlugIn";
			base.Size = new Size(376, 248);
			base.Title = "Border Editor";
			((ISupportInitialize)this.MarginNumericUpDown).EndInit();
			this.groupBox1.ResumeLayout(false);
			((ISupportInitialize)this.ThicknessDesiredNumericUpDown).EndInit();
			this.groupBox2.ResumeLayout(false);
			((ISupportInitialize)this.MarginRightNumericUpDown).EndInit();
			((ISupportInitialize)this.MarginLeftNumericUpDown).EndInit();
			((ISupportInitialize)this.MarginBottomNumericUpDown).EndInit();
			((ISupportInitialize)this.MarginTopNumericUpDown).EndInit();
			base.ResumeLayout(false);
		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{
		}
	}
}
