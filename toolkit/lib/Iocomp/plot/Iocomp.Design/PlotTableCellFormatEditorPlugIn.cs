using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotTableCellFormatEditorPlugIn : PlugInStandard
	{
		private ColorPicker ColorPicker;

		private FocusLabel label8;

		private FontButton FontButton;

		private Container components;

		public PlotTableCellFormatEditorPlugIn()
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
			this.FontButton = new FontButton();
			base.SuspendLayout();
			this.ColorPicker.Location = new Point(80, 72);
			this.ColorPicker.Name = "ColorPicker";
			this.ColorPicker.PropertyName = "ForeColor";
			this.ColorPicker.Size = new Size(48, 21);
			this.ColorPicker.Style = ColorPickerStyle.ColorBox;
			this.ColorPicker.TabIndex = 0;
			this.label8.LoadingBegin();
			this.label8.FocusControl = this.ColorPicker;
			this.label8.Location = new Point(21, 75);
			this.label8.Name = "label8";
			this.label8.Size = new Size(59, 15);
			this.label8.Text = "Fore Color";
			this.label8.LoadingEnd();
			this.FontButton.Location = new Point(80, 112);
			this.FontButton.Name = "FontButton";
			this.FontButton.PropertyName = "Font";
			this.FontButton.TabIndex = 1;
			base.Controls.Add(this.FontButton);
			base.Controls.Add(this.ColorPicker);
			base.Controls.Add(this.label8);
			base.Name = "PlotTableCellFormatEditorPlugIn";
			base.Size = new Size(424, 288);
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new PlotBrushEditorPlugIn(), "Background", false);
			base.AddSubPlugIn(new TextLayoutFullEditorPlugin(), "Text Layout", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as PlotTableCellFormat).Background;
			base.SubPlugIns[1].Value = (base.Value as PlotTableCellFormat).TextLayout;
		}
	}
}
