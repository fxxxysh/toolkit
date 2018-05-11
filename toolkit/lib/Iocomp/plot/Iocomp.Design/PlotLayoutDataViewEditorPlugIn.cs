using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotLayoutDataViewEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel1;

		private FocusLabel focusLabel3;

		private EditBox DockOrderTextBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DockSideComboBox;

		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown DockMarginUpDown;

		private FocusLabel focusLabel6;

		private EditBox DockDepthRatioTextBox;

		private EditBox StackingGroupIndexEditBox;

		private FocusLabel focusLabel2;

		private Container components;

		public PlotLayoutDataViewEditorPlugIn()
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
			this.DockOrderTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.DockDepthRatioTextBox = new EditBox();
			this.focusLabel3 = new FocusLabel();
			this.DockSideComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label2 = new FocusLabel();
			this.DockMarginUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.focusLabel6 = new FocusLabel();
			this.StackingGroupIndexEditBox = new EditBox();
			this.focusLabel2 = new FocusLabel();
			((ISupportInitialize)this.DockMarginUpDown).BeginInit();
			base.SuspendLayout();
			this.DockOrderTextBox.LoadingBegin();
			this.DockOrderTextBox.Location = new Point(120, 192);
			this.DockOrderTextBox.Name = "DockOrderTextBox";
			this.DockOrderTextBox.PropertyName = "DockOrder";
			this.DockOrderTextBox.ReadOnly = true;
			this.DockOrderTextBox.Size = new Size(136, 20);
			this.DockOrderTextBox.TabIndex = 3;
			this.DockOrderTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.DockOrderTextBox;
			this.focusLabel1.Location = new Point(84, 194);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(36, 15);
			this.focusLabel1.Text = "Order";
			this.focusLabel1.LoadingEnd();
			this.DockDepthRatioTextBox.LoadingBegin();
			this.DockDepthRatioTextBox.Location = new Point(120, 48);
			this.DockDepthRatioTextBox.Name = "DockDepthRatioTextBox";
			this.DockDepthRatioTextBox.PropertyName = "DockDepthRatio";
			this.DockDepthRatioTextBox.Size = new Size(136, 20);
			this.DockDepthRatioTextBox.TabIndex = 1;
			this.DockDepthRatioTextBox.LoadingEnd();
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.DockDepthRatioTextBox;
			this.focusLabel3.Location = new Point(54, 50);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(66, 15);
			this.focusLabel3.Text = "Depth Ratio";
			this.focusLabel3.LoadingEnd();
			this.DockSideComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.DockSideComboBox.Location = new Point(120, 168);
			this.DockSideComboBox.MaxDropDownItems = 20;
			this.DockSideComboBox.Name = "DockSideComboBox";
			this.DockSideComboBox.PropertyName = "DockSide";
			this.DockSideComboBox.ReadOnly = true;
			this.DockSideComboBox.Size = new Size(136, 21);
			this.DockSideComboBox.TabIndex = 2;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.DockSideComboBox;
			this.label2.Location = new Point(90, 170);
			this.label2.Name = "label2";
			this.label2.Size = new Size(30, 15);
			this.label2.Text = "Side";
			this.label2.LoadingEnd();
			this.DockMarginUpDown.Location = new Point(120, 16);
			this.DockMarginUpDown.Maximum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				0
			});
			this.DockMarginUpDown.Minimum = new decimal(new int[4]
			{
				1000,
				0,
				0,
				-2147483648
			});
			this.DockMarginUpDown.Name = "DockMarginUpDown";
			this.DockMarginUpDown.PropertyName = "DockMargin";
			this.DockMarginUpDown.Size = new Size(48, 20);
			this.DockMarginUpDown.TabIndex = 0;
			this.DockMarginUpDown.TextAlign = HorizontalAlignment.Center;
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.DockMarginUpDown;
			this.focusLabel6.Location = new Point(79, 17);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(41, 15);
			this.focusLabel6.Text = "Margin";
			this.focusLabel6.LoadingEnd();
			this.StackingGroupIndexEditBox.LoadingBegin();
			this.StackingGroupIndexEditBox.Location = new Point(120, 216);
			this.StackingGroupIndexEditBox.Name = "StackingGroupIndexEditBox";
			this.StackingGroupIndexEditBox.PropertyName = "StackingGroupIndex";
			this.StackingGroupIndexEditBox.ReadOnly = true;
			this.StackingGroupIndexEditBox.Size = new Size(136, 20);
			this.StackingGroupIndexEditBox.TabIndex = 4;
			this.StackingGroupIndexEditBox.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.StackingGroupIndexEditBox;
			this.focusLabel2.Location = new Point(7, 218);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(113, 15);
			this.focusLabel2.Text = "Stacking Group Index";
			this.focusLabel2.LoadingEnd();
			base.Controls.Add(this.StackingGroupIndexEditBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.DockMarginUpDown);
			base.Controls.Add(this.focusLabel6);
			base.Controls.Add(this.DockSideComboBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.DockDepthRatioTextBox);
			base.Controls.Add(this.focusLabel3);
			base.Controls.Add(this.DockOrderTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Location = new Point(10, 20);
			base.Name = "PlotLayoutDataViewEditorPlugIn";
			base.Size = new Size(456, 248);
			((ISupportInitialize)this.DockMarginUpDown).EndInit();
			base.ResumeLayout(false);
		}
	}
}
