using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class IndicatorEditorPlugIn : PlugInStandard
	{
		private GroupBox groupBox1;

		private FocusLabel label4;

		private FocusLabel label2;

		private ColorPicker ColorActiveColorPicker;

		private ColorPicker ColorInactiveColorPicker;

		private Iocomp.Design.Plugin.EditorControls.CheckBox ColorInactiveAutoCheckBox;

		private Container components;

		public IndicatorEditorPlugIn()
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
			this.groupBox1 = new GroupBox();
			this.label2 = new FocusLabel();
			this.ColorInactiveColorPicker = new ColorPicker();
			this.label4 = new FocusLabel();
			this.ColorActiveColorPicker = new ColorPicker();
			this.ColorInactiveAutoCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.groupBox1.SuspendLayout();
			base.SuspendLayout();
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.ColorInactiveColorPicker);
			this.groupBox1.Controls.Add(this.ColorActiveColorPicker);
			this.groupBox1.Controls.Add(this.ColorInactiveAutoCheckBox);
			this.groupBox1.Location = new Point(5, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new Size(219, 96);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Color";
			this.label2.LoadingBegin();
			this.label2.FocusControl = this.ColorInactiveColorPicker;
			this.label2.Location = new Point(11, 43);
			this.label2.Name = "label2";
			this.label2.Size = new Size(45, 15);
			this.label2.Text = "Inactive";
			this.label2.LoadingEnd();
			this.ColorInactiveColorPicker.Location = new Point(56, 40);
			this.ColorInactiveColorPicker.Name = "ColorInactiveColorPicker";
			this.ColorInactiveColorPicker.PropertyName = "ColorInactive";
			this.ColorInactiveColorPicker.Size = new Size(144, 21);
			this.ColorInactiveColorPicker.TabIndex = 1;
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.ColorActiveColorPicker;
			this.label4.Location = new Point(18, 19);
			this.label4.Name = "label4";
			this.label4.Size = new Size(38, 15);
			this.label4.Text = "Active";
			this.label4.LoadingEnd();
			this.ColorActiveColorPicker.Location = new Point(56, 16);
			this.ColorActiveColorPicker.Name = "ColorActiveColorPicker";
			this.ColorActiveColorPicker.PropertyName = "ColorActive";
			this.ColorActiveColorPicker.Size = new Size(144, 21);
			this.ColorActiveColorPicker.TabIndex = 0;
			this.ColorInactiveAutoCheckBox.Location = new Point(56, 64);
			this.ColorInactiveAutoCheckBox.Name = "ColorInactiveAutoCheckBox";
			this.ColorInactiveAutoCheckBox.PropertyName = "ColorInactiveAuto";
			this.ColorInactiveAutoCheckBox.Size = new Size(120, 24);
			this.ColorInactiveAutoCheckBox.TabIndex = 2;
			this.ColorInactiveAutoCheckBox.Text = "Inactive Auto";
			base.Controls.Add(this.groupBox1);
			base.Name = "IndicatorEditorPlugIn";
			base.Size = new Size(456, 104);
			base.Title = "Indicator Editor";
			this.groupBox1.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
