using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelBubbleSpecificEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.CheckBox RequireConsecutiveDataCheckBox;

		private Iocomp.Design.Plugin.EditorControls.ComboBox RadiusStyleComboBox;

		private FocusLabel focusLabel7;

		private EditBox RadiusTextBox;

		private FocusLabel focusLabel6;

		private Container components;

		public PlotChannelBubbleSpecificEditorPlugIn()
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
			this.RequireConsecutiveDataCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.RadiusStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel7 = new FocusLabel();
			this.RadiusTextBox = new EditBox();
			this.focusLabel6 = new FocusLabel();
			base.SuspendLayout();
			this.RequireConsecutiveDataCheckBox.Location = new Point(88, 32);
			this.RequireConsecutiveDataCheckBox.Name = "RequireConsecutiveDataCheckBox";
			this.RequireConsecutiveDataCheckBox.PropertyName = "RequireConsecutiveData";
			this.RequireConsecutiveDataCheckBox.Size = new Size(168, 24);
			this.RequireConsecutiveDataCheckBox.TabIndex = 0;
			this.RequireConsecutiveDataCheckBox.Text = "Require Consecutive Data";
			this.RadiusStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.RadiusStyleComboBox.Location = new Point(88, 88);
			this.RadiusStyleComboBox.MaxDropDownItems = 20;
			this.RadiusStyleComboBox.Name = "RadiusStyleComboBox";
			this.RadiusStyleComboBox.PropertyName = "RadiusStyle";
			this.RadiusStyleComboBox.Size = new Size(80, 21);
			this.RadiusStyleComboBox.TabIndex = 2;
			this.focusLabel7.LoadingBegin();
			this.focusLabel7.FocusControl = this.RadiusStyleComboBox;
			this.focusLabel7.Location = new Point(19, 90);
			this.focusLabel7.Name = "focusLabel7";
			this.focusLabel7.Size = new Size(69, 15);
			this.focusLabel7.Text = "Radius Style";
			this.focusLabel7.LoadingEnd();
			this.RadiusTextBox.LoadingBegin();
			this.RadiusTextBox.Location = new Point(88, 64);
			this.RadiusTextBox.Name = "RadiusTextBox";
			this.RadiusTextBox.PropertyName = "Radius";
			this.RadiusTextBox.Size = new Size(80, 20);
			this.RadiusTextBox.TabIndex = 1;
			this.RadiusTextBox.LoadingEnd();
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.RadiusTextBox;
			this.focusLabel6.Location = new Point(46, 66);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(42, 15);
			this.focusLabel6.Text = "Radius";
			this.focusLabel6.LoadingEnd();
			base.Controls.Add(this.RequireConsecutiveDataCheckBox);
			base.Controls.Add(this.RadiusStyleComboBox);
			base.Controls.Add(this.focusLabel7);
			base.Controls.Add(this.RadiusTextBox);
			base.Controls.Add(this.focusLabel6);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelBubbleSpecificEditorPlugIn";
			base.Size = new Size(480, 248);
			base.ResumeLayout(false);
		}
	}
}
