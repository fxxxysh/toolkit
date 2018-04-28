using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotAxisGridLinesEditorPlugIn : PlugInStandard
	{
		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private CheckBox VisibleCheckBox;

		private CheckBox ShowOnTopCheckBox;

		private Container components;

		public PlotAxisGridLinesEditorPlugIn()
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
			this.ColorPicker = new ColorPicker();
			this.label8 = new FocusLabel();
			this.VisibleCheckBox = new CheckBox();
			this.ShowOnTopCheckBox = new CheckBox();
			base.SuspendLayout();
			this.ColorPicker.Location = new Point(80, 96);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "Color";
			this.ColorPicker.Size = new Size(48, 21);
			this.ColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorPicker.TabIndex = 1;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorPicker;
			this.label8.Location = new Point(46, 99);
			this.label8.Name = "label8";
			this.label8.Size = new Size(34, 15);
			this.label8.Text = "Color";
			this.label8.LoadingEnd();
			this.VisibleCheckBox.Location = new Point(80, 32);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(72, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			this.ShowOnTopCheckBox.Location = new Point(80, 56);
			this.ShowOnTopCheckBox.Name = "ShowOnTopCheckBox";
			this.ShowOnTopCheckBox.PropertyName = "ShowOnTop";
			this.ShowOnTopCheckBox.TabIndex = 3;
			this.ShowOnTopCheckBox.Text = "Show On Top";
			base.Controls.Add(this.ShowOnTopCheckBox);
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label8);
			base.Name = "PlotAxisGridLinesEditorPlugIn";
			base.Size = new Size(424, 288);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Major", false);
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Mid", false);
			base.AddSubPlugIn(new PlotPenEditorPlugIn(), "Minor", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotAxisGridLines).Major;
			base.SubPlugIns[1].Value = (base.Value as PlotAxisGridLines).Mid;
			base.SubPlugIns[2].Value = (base.Value as PlotAxisGridLines).Minor;
		}
	}
}
