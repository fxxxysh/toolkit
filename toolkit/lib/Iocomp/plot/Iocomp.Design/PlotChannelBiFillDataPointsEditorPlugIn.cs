using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class PlotChannelBiFillDataPointsEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox DataPointMoveStyleComboBox;

		private FocusLabel focusLabel6;

		private Iocomp.Design.Plugin.EditorControls.CheckBox UserCanMoveDataPointsCheckBox;

		private Container components;

		public PlotChannelBiFillDataPointsEditorPlugIn()
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
			this.focusLabel6 = new FocusLabel();
			this.UserCanMoveDataPointsCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			this.DataPointMoveStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.DataPointMoveStyleComboBox.Location = new Point(104, 72);
			this.DataPointMoveStyleComboBox.MaxDropDownItems = 20;
			this.DataPointMoveStyleComboBox.Name = "DataPointMoveStyleComboBox";
			this.DataPointMoveStyleComboBox.PropertyName = "DataPointsMoveStyle";
			this.DataPointMoveStyleComboBox.Size = new Size(80, 21);
			this.DataPointMoveStyleComboBox.TabIndex = 1;
			this.focusLabel6.LoadingBegin();
			this.focusLabel6.FocusControl = this.DataPointMoveStyleComboBox;
			this.focusLabel6.Location = new Point(43, 74);
			this.focusLabel6.Name = "focusLabel6";
			this.focusLabel6.Size = new Size(61, 15);
			this.focusLabel6.Text = "Move Style";
			this.focusLabel6.LoadingEnd();
			this.UserCanMoveDataPointsCheckBox.Location = new Point(24, 40);
			this.UserCanMoveDataPointsCheckBox.Name = "UserCanMoveDataPointsCheckBox";
			this.UserCanMoveDataPointsCheckBox.PropertyName = "UserCanMoveDataPoints";
			this.UserCanMoveDataPointsCheckBox.Size = new Size(176, 24);
			this.UserCanMoveDataPointsCheckBox.TabIndex = 0;
			this.UserCanMoveDataPointsCheckBox.Text = "User Can Move";
			base.Controls.Add(this.DataPointMoveStyleComboBox);
			base.Controls.Add(this.focusLabel6);
			base.Controls.Add(this.UserCanMoveDataPointsCheckBox);
			base.Location = new Point(10, 20);
			base.Name = "PlotChannelBiFillDataPointsEditorPlugIn";
			base.Size = new Size(592, 288);
			base.ResumeLayout(false);
		}
	}
}
