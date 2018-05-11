using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotTableEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox EnabledCheckBox;

		private EditBox NameTextBox;

		private FocusLabel focusLabel1;

		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ContextMenuEnabledCheckBox;

		private Iocomp.Design.Plugin.EditorControls.NumericUpDown LayerNumericUpDown;

		private FocusLabel label1;

		private Container components;

		public PlotTableEditorPlugIn()
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
			this.VisibleCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.EnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.NameTextBox = new EditBox();
			this.focusLabel1 = new FocusLabel();
			this.ColorPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.ContextMenuEnabledCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LayerNumericUpDown = new Iocomp.Design.Plugin.EditorControls.NumericUpDown();
			this.label1 = new FocusLabel();
			base.SuspendLayout();
			this.VisibleCheckBox.Location = new Point(272, 16);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.EnabledCheckBox.Location = new Point(272, 40);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(80, 24);
			this.EnabledCheckBox.TabIndex = 2;
			this.EnabledCheckBox.Text = "Enabled";
			this.NameTextBox.LoadingBegin();
			this.NameTextBox.Location = new Point(104, 16);
			this.NameTextBox.Name = "NameTextBox";
			this.NameTextBox.PropertyName = "Name";
			this.NameTextBox.Size = new Size(144, 20);
			this.NameTextBox.TabIndex = 9;
			this.NameTextBox.LoadingEnd();
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.NameTextBox;
			this.focusLabel1.Location = new Point(69, 15);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(35, 21);
			this.focusLabel1.Text = "Name";
			this.focusLabel1.LoadingEnd();
			this.ColorPicker.Location = new Point(104, 48);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(48, 21);
			this.ColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorPicker.TabIndex = 33;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorPicker;
			this.label8.Location = new Point(72, 48);
			this.label8.Name = "label8";
			this.label8.Size = new Size(32, 21);
			this.label8.Text = "Color";
			this.label8.LoadingEnd();
			this.ContextMenuEnabledCheckBox.Location = new Point(272, 64);
			this.ContextMenuEnabledCheckBox.Name = "ContextMenuEnabledCheckBox";
			this.ContextMenuEnabledCheckBox.PropertyName = "ContextMenuEnabled";
			this.ContextMenuEnabledCheckBox.Size = new Size(152, 24);
			this.ContextMenuEnabledCheckBox.TabIndex = 36;
			this.ContextMenuEnabledCheckBox.Text = "Context Menu Enabled";
			this.LayerNumericUpDown.Location = new Point(192, 48);
			this.LayerNumericUpDown.Maximum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				0
			});
			this.LayerNumericUpDown.Minimum = new decimal(new int[4]
			{
				10000,
				0,
				0,
				-2147483648
			});
			this.LayerNumericUpDown.Name = "LayerNumericUpDown";
			this.LayerNumericUpDown.PropertyName = "Layer";
			this.LayerNumericUpDown.Size = new Size(56, 20);
			this.LayerNumericUpDown.TabIndex = 103;
			this.LayerNumericUpDown.TextAlign = HorizontalAlignment.Center;
			this.label1.LoadingBegin();
			this.label1.FocusControl = this.LayerNumericUpDown;
			this.label1.Location = new Point(159, 49);
			this.label1.Name = "label1";
			this.label1.Size = new Size(33, 14);
			this.label1.Text = "Layer";
			this.label1.LoadingEnd();
			base.Controls.Add(this.LayerNumericUpDown);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.ContextMenuEnabledCheckBox);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label8);
			base.Controls.Add(this.NameTextBox);
			base.Controls.Add(this.focusLabel1);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotTableEditorPlugIn";
			base.Size = new Size(456, 208);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.SubPlugIns.Add(new PlotFillEditorPlugIn());
			base.SubPlugIns[base.SubPlugIns.Count - 1].TabName = "Fill";
			base.SubPlugIns.Add(new PlotLayoutDockableAllEditorPlugIn());
			base.SubPlugIns[base.SubPlugIns.Count - 1].TabName = "Dock";
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotTableGrid).Fill;
			base.SubPlugIns[1].Value = base.Value;
		}
	}
}
