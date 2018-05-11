using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotLegendWrappingEditorPlugIn : PlugInStandard
	{
		private CheckBox EnabledCheckBox;

		private FocusLabel focusLabel4;

		private EditBox MarginEditBox;

		private Container components;

		public PlotLegendWrappingEditorPlugIn()
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
			this.EnabledCheckBox = new CheckBox();
			this.MarginEditBox = new EditBox();
			this.focusLabel4 = new FocusLabel();
			base.SuspendLayout();
			this.EnabledCheckBox.Location = new Point(96, 40);
			this.EnabledCheckBox.Name = "EnabledCheckBox";
			this.EnabledCheckBox.PropertyName = "Enabled";
			this.EnabledCheckBox.Size = new Size(72, 24);
			this.EnabledCheckBox.TabIndex = 0;
			this.EnabledCheckBox.Text = "Enabled";
			this.MarginEditBox.LoadingBegin();
			this.MarginEditBox.Location = new Point(96, 80);
			this.MarginEditBox.Name = "MarginEditBox";
			this.MarginEditBox.PropertyName = "Margin";
			this.MarginEditBox.Size = new Size(136, 20);
			this.MarginEditBox.TabIndex = 3;
			this.MarginEditBox.LoadingEnd();
			this.focusLabel4.LoadingBegin();
			this.focusLabel4.FocusControl = this.MarginEditBox;
			this.focusLabel4.Location = new Point(56, 82);
			this.focusLabel4.Name = "focusLabel4";
			this.focusLabel4.Size = new Size(40, 15);
			this.focusLabel4.Text = "Margin";
			this.focusLabel4.LoadingEnd();
			base.Controls.Add(this.MarginEditBox);
			base.Controls.Add(this.focusLabel4);
			base.Controls.Add(this.EnabledCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotLegendWrappingEditorPlugIn";
			base.Size = new Size(504, 336);
			base.ResumeLayout(false);
		}
	}
}
