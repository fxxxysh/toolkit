using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotBrushEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox StyleComboBox;

		private FocusLabel label2;

		private Iocomp.Design.Plugin.EditorControls.CheckBox VisibleCheckBox;

		private FocusLabel focusLabel1;

		private GroupBox GradientGroupBox;

		private FocusLabel focusLabel2;

		private GroupBox SolidGroupBox;

		private ColorPicker SolidColorPicker;

		private FocusLabel label8;

		private GroupBox HatchGroupBox;

		private FocusLabel focusLabel3;

		private FocusLabel focusLabel4;

		private ColorPicker GradientStartColorPicker;

		private ColorPicker GradientStopColorPicker;

		private ColorPicker HatchBackColorPicker;

		private ColorPicker HatchForeColorPicker;

		private Container components;

		public PlotBrushEditorPlugIn()
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
			this.GradientGroupBox = new GroupBox();
			this.GradientStopColorPicker = new ColorPicker();
			this.focusLabel2 = new FocusLabel();
			this.GradientStartColorPicker = new ColorPicker();
			this.focusLabel1 = new FocusLabel();
			this.SolidGroupBox = new GroupBox();
			this.SolidColorPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.HatchGroupBox = new GroupBox();
			this.HatchBackColorPicker = new ColorPicker();
			this.focusLabel3 = new FocusLabel();
			this.HatchForeColorPicker = new ColorPicker();
			this.focusLabel4 = new FocusLabel();
			this.GradientGroupBox.SuspendLayout();
			this.SolidGroupBox.SuspendLayout();
			this.HatchGroupBox.SuspendLayout();
			base.SuspendLayout();
			this.StyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.StyleComboBox.Location = new Point(48, 56);
			this.StyleComboBox.MaxDropDownItems = 20;
			this.StyleComboBox.Name = "StyleComboBox";
			this.StyleComboBox.PropertyName = "Style";
			this.StyleComboBox.Size = new Size(200, 21);
			this.StyleComboBox.TabIndex = 1;
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.StyleComboBox;
			this.label2.Location = new Point(16, 58);
			this.label2.Name = "label2";
			this.label2.Size = new Size(32, 15);
			this.label2.Text = "Style";
			this.label2.LoadingEnd();
			this.VisibleCheckBox.Location = new Point(48, 24);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.GradientGroupBox.Controls.Add(this.GradientStopColorPicker);
			this.GradientGroupBox.Controls.Add(this.focusLabel2);
			this.GradientGroupBox.Controls.Add(this.GradientStartColorPicker);
			this.GradientGroupBox.Controls.Add(this.focusLabel1);
			this.GradientGroupBox.Location = new Point(136, 88);
			this.GradientGroupBox.Name = "GradientGroupBox";
			this.GradientGroupBox.Size = new Size(128, 100);
			this.GradientGroupBox.TabIndex = 3;
			this.GradientGroupBox.TabStop = false;
			this.GradientGroupBox.Text = "Gradient";
			this.GradientStopColorPicker.Location = new Point(64, 56);
			this.GradientStopColorPicker.Name = "GradientStopColorPicker";
			this.GradientStopColorPicker.PropertyName = "GradientStopColor";
			this.GradientStopColorPicker.Size = new Size(48, 21);
			this.GradientStopColorPicker.Style = ColorPickerStyle.ColorBox;
			this.GradientStopColorPicker.TabIndex = 1;
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.GradientStopColorPicker;
			this.focusLabel2.Location = new Point(5, 59);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(59, 15);
			this.focusLabel2.Text = "Stop Color";
			this.focusLabel2.LoadingEnd();
			this.GradientStartColorPicker.Location = new Point(64, 32);
			this.GradientStartColorPicker.Name = "GradientStartColorPicker";
			this.GradientStartColorPicker.PropertyName = "GradientStartColor";
			this.GradientStartColorPicker.Size = new Size(48, 21);
			this.GradientStartColorPicker.Style = ColorPickerStyle.ColorBox;
			this.GradientStartColorPicker.TabIndex = 0;
			this.focusLabel1.LoadingBegin();
			this.focusLabel1.FocusControl = this.GradientStartColorPicker;
			this.focusLabel1.Location = new Point(4, 35);
			this.focusLabel1.Name = "focusLabel1";
			this.focusLabel1.Size = new Size(60, 15);
			this.focusLabel1.Text = "Start Color";
			this.focusLabel1.LoadingEnd();
			this.SolidGroupBox.Controls.Add(this.SolidColorPicker);
			this.SolidGroupBox.Controls.Add(this.label8);
			this.SolidGroupBox.Location = new Point(16, 88);
			this.SolidGroupBox.Name = "SolidGroupBox";
			this.SolidGroupBox.Size = new Size(112, 100);
			this.SolidGroupBox.TabIndex = 2;
			this.SolidGroupBox.TabStop = false;
			this.SolidGroupBox.Text = "Solid";
			this.SolidColorPicker.Location = new Point(48, 32);
			this.SolidColorPicker.Name = "SolidColorPicker";
			this.SolidColorPicker.PropertyName = "SolidColor";
			this.SolidColorPicker.Size = new Size(48, 21);
			this.SolidColorPicker.Style = ColorPickerStyle.ColorBox;
			this.SolidColorPicker.TabIndex = 0;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.SolidColorPicker;
			this.label8.Location = new Point(14, 35);
			this.label8.Name = "label8";
			this.label8.Size = new Size(34, 15);
			this.label8.Text = "Color";
			this.label8.LoadingEnd();
			this.HatchGroupBox.Controls.Add(this.HatchBackColorPicker);
			this.HatchGroupBox.Controls.Add(this.focusLabel3);
			this.HatchGroupBox.Controls.Add(this.HatchForeColorPicker);
			this.HatchGroupBox.Controls.Add(this.focusLabel4);
			this.HatchGroupBox.Location = new Point(272, 88);
			this.HatchGroupBox.Name = "HatchGroupBox";
			this.HatchGroupBox.Size = new Size(128, 100);
			this.HatchGroupBox.TabIndex = 4;
			this.HatchGroupBox.TabStop = false;
			this.HatchGroupBox.Text = "Hatch";
			this.HatchBackColorPicker.Location = new Point(64, 56);
			this.HatchBackColorPicker.Name = "HatchBackColorPicker";
			this.HatchBackColorPicker.PropertyName = "HatchBackColor";
			this.HatchBackColorPicker.Size = new Size(48, 21);
			this.HatchBackColorPicker.Style = ColorPickerStyle.ColorBox;
			this.HatchBackColorPicker.TabIndex = 1;
			this.focusLabel3.LoadingBegin();
			this.focusLabel3.FocusControl = this.HatchBackColorPicker;
			this.focusLabel3.Location = new Point(3, 59);
			this.focusLabel3.Name = "focusLabel3";
			this.focusLabel3.Size = new Size(61, 15);
			this.focusLabel3.Text = "Back Color";
			this.focusLabel3.LoadingEnd();
			this.HatchForeColorPicker.Location = new Point(64, 32);
			this.HatchForeColorPicker.Name = "HatchForeColorPicker";
			this.HatchForeColorPicker.PropertyName = "HatchForeColor";
			this.HatchForeColorPicker.Size = new Size(48, 21);
			this.HatchForeColorPicker.Style = ColorPickerStyle.ColorBox;
			this.HatchForeColorPicker.TabIndex = 0;
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.HatchForeColorPicker;
			this.focusLabel4.Location = new Point(5, 35);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(59, 15);
			this.focusLabel4.Text = "Fore Color";
			this.focusLabel4.LoadingEnd();
			base.Controls.Add(this.HatchGroupBox);
			base.Controls.Add(this.SolidGroupBox);
			base.Controls.Add(this.GradientGroupBox);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.StyleComboBox);
			base.Name = "PlotBrushEditorPlugIn";
			base.Size = new Size(424, 288);
			this.GradientGroupBox.ResumeLayout(false);
			this.SolidGroupBox.ResumeLayout(false);
			this.HatchGroupBox.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
