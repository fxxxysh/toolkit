using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotChannelBarDataPointsEditorPlugIn : PlugInStandard
	{
		private CheckBox DrawCustomDataPointAttributesCheckBox;

		private Container components;

		public PlotChannelBarDataPointsEditorPlugIn()
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
			this.DrawCustomDataPointAttributesCheckBox = new CheckBox();
			base.SuspendLayout();
			this.DrawCustomDataPointAttributesCheckBox.Location = new Point(24, 16);
			this.DrawCustomDataPointAttributesCheckBox.Name = "DrawCustomDataPointAttributesCheckBox";
			this.DrawCustomDataPointAttributesCheckBox.PropertyName = "DrawCustomDataPointAttributes";
			this.DrawCustomDataPointAttributesCheckBox.Size = new Size(200, 24);
			this.DrawCustomDataPointAttributesCheckBox.TabIndex = 0;
			this.DrawCustomDataPointAttributesCheckBox.Text = "Draw Custom Attributes";
			base.Controls.Add(this.DrawCustomDataPointAttributesCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelBarDataPointsEditorPlugIn";
			base.Size = new Size(736, 280);
			base.ResumeLayout(false);
		}
	}
}
