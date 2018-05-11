using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class PlotChannelSweepIntervalDataPointsEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox DataPointMoveStyleComboBox;

		private FocusLabel focusLabel8;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanMoveDataPointsCheckBox;

		private Container components;

		public PlotChannelSweepIntervalDataPointsEditorPlugIn()
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
			this.DataPointMoveStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.focusLabel8 = new FocusLabel();
			this.UserCanMoveDataPointsCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			this.DataPointMoveStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.DataPointMoveStyleComboBox.Location = new Point(104, 72);
			this.DataPointMoveStyleComboBox.MaxDropDownItems = 20;
			this.DataPointMoveStyleComboBox.Name = "DataPointMoveStyleComboBox";
			this.DataPointMoveStyleComboBox.PropertyName = "DataPointsMoveStyle";
			this.DataPointMoveStyleComboBox.Size = new Size(80, 21);
			this.DataPointMoveStyleComboBox.TabIndex = 1;
			this.focusLabel8.LoadingBegin();
			this.focusLabel8.FocusControl = this.DataPointMoveStyleComboBox;
			this.focusLabel8.Location = new Point(43, 74);
			this.focusLabel8.Name = "focusLabel8";
			this.focusLabel8.Size = new Size(61, 15);
			this.focusLabel8.Text = "Move Style";
			this.focusLabel8.LoadingEnd();
			this.UserCanMoveDataPointsCheckBox.Location = new Point(24, 40);
			this.UserCanMoveDataPointsCheckBox.Name = "UserCanMoveDataPointsCheckBox";
			this.UserCanMoveDataPointsCheckBox.PropertyName = "UserCanMoveDataPoints";
			this.UserCanMoveDataPointsCheckBox.Size = new Size(176, 24);
			this.UserCanMoveDataPointsCheckBox.TabIndex = 0;
			this.UserCanMoveDataPointsCheckBox.Text = "User Can Move";
			base.Controls.Add(this.DataPointMoveStyleComboBox);
			base.Controls.Add(this.focusLabel8);
			base.Controls.Add(this.UserCanMoveDataPointsCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelSweepIntervalDataPointsEditorPlugIn";
			base.Size = new Size(584, 280);
			base.ResumeLayout(false);
		}
	}
}
