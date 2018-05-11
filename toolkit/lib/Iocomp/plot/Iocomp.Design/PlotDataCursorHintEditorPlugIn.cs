using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotDataCursorHintEditorPlugIn : PlugInStandard
	{
		private FocusLabel focusLabel2;

		private EditBox PositionTextBox;

		private CheckBox HideOnReleaseCheckBox;

		private FontButton FontButton;

		private FocusLabel focusLabel11;

		private ColorPicker ForeColorPicker;

		private CheckBox VisibleCheckBox;

		private Container components;

		public PlotDataCursorHintEditorPlugIn()
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
			this.HideOnReleaseCheckBox = new CheckBox();
			this.PositionTextBox = new EditBox();
			this.focusLabel2 = new FocusLabel();
			this.FontButton = new FontButton();
			this.focusLabel11 = new FocusLabel();
			this.ForeColorPicker = new ColorPicker();
			this.VisibleCheckBox = new CheckBox();
			base.SuspendLayout();
			this.HideOnReleaseCheckBox.Location = new Point(272, 88);
			this.HideOnReleaseCheckBox.Name = "HideOnReleaseCheckBox";
			this.HideOnReleaseCheckBox.PropertyName = "HideOnRelease";
			this.HideOnReleaseCheckBox.Size = new Size(152, 24);
			this.HideOnReleaseCheckBox.TabIndex = 2;
			this.HideOnReleaseCheckBox.Text = "Hide On Release";
			this.PositionTextBox.LoadingBegin();
			this.PositionTextBox.Location = new Point(120, 88);
			this.PositionTextBox.Name = "PositionTextBox";
			this.PositionTextBox.PropertyName = "Position";
			this.PositionTextBox.Size = new Size(136, 20);
			this.PositionTextBox.TabIndex = 1;
			this.PositionTextBox.LoadingEnd();
			this.focusLabel2.LoadingBegin();
			this.focusLabel2.FocusControl = this.PositionTextBox;
			this.focusLabel2.Location = new Point(73, 90);
			this.focusLabel2.Name = "focusLabel2";
			this.focusLabel2.Size = new Size(47, 15);
			this.focusLabel2.Text = "Position";
			this.focusLabel2.LoadingEnd();
			this.FontButton.Location = new Point(120, 160);
			this.FontButton.Name = "FontButton";
			this.FontButton.PropertyName = "Font";
			this.FontButton.Size = new Size(72, 23);
			this.FontButton.TabIndex = 5;
			this.focusLabel11.LoadingBegin();
			this.focusLabel11.FocusControl = this.ForeColorPicker;
			this.focusLabel11.Location = new Point(61, 131);
			this.focusLabel11.Name = "focusLabel11";
			this.focusLabel11.Size = new Size(59, 15);
			this.focusLabel11.Text = "Fore Color";
			this.focusLabel11.LoadingEnd();
			this.ForeColorPicker.Location = new Point(120, 128);
			this.ForeColorPicker.Name = "ForeColorPicker";
			this.ForeColorPicker.PropertyName = "ForeColor";
			this.ForeColorPicker.Size = new Size(49, 21);
			this.ForeColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ForeColorPicker.TabIndex = 4;
			this.VisibleCheckBox.Location = new Point(120, 48);
			this.VisibleCheckBox.Name = "VisibleCheckBox";
			this.VisibleCheckBox.PropertyName = "Visible";
			this.VisibleCheckBox.Size = new Size(152, 24);
			this.VisibleCheckBox.TabIndex = 0;
			this.VisibleCheckBox.Text = "Visible";
			base.Controls.Add(this.VisibleCheckBox);
			base.Controls.Add(this.FontButton);
			base.Controls.Add(this.focusLabel11);
			base.Controls.Add(this.ForeColorPicker);
			base.Controls.Add(this.PositionTextBox);
			base.Controls.Add(this.focusLabel2);
			base.Controls.Add(this.HideOnReleaseCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotDataCursorHintEditorPlugIn";
			base.Size = new Size(504, 336);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotFillEditorPlugIn(), "Fill", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotDataCursorHint).Fill;
		}
	}
}
