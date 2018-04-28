using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class AnimationEditorPlugIn : PlugInStandard
	{
		private FocusLabel label3;

		private FocusLabel label4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox DirectionComboBox;

		private EditBox IntervalTextBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox OnCheckBox;

		private Container components;

		public AnimationEditorPlugIn()
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
			this.label3 = new FocusLabel();
			this.IntervalTextBox = new EditBox();
			this.label4 = new FocusLabel();
			this.DirectionComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.OnCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			this.label3.LoadingBegin();
			this.label3.FocusControl = this.IntervalTextBox;
			this.label3.Location = new Point(52, 74);
			this.label3.Name = "label3";
			this.label3.Size = new Size(44, 15);
			this.label3.Text = "Interval";
			this.label3.LoadingEnd();
			this.IntervalTextBox.LoadingBegin();
			this.IntervalTextBox.Location = new Point(96, 72);
			this.IntervalTextBox.Name = "IntervalTextBox";
			this.IntervalTextBox.PropertyName = "Interval";
			this.IntervalTextBox.Size = new Size(48, 20);
			this.IntervalTextBox.TabIndex = 2;
			this.IntervalTextBox.LoadingEnd();
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.DirectionComboBox;
			this.label4.Location = new Point(45, 42);
			this.label4.Name = "label4";
			this.label4.Size = new Size(51, 15);
			this.label4.Text = "Direction";
			this.label4.LoadingEnd();
			this.DirectionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.DirectionComboBox.Location = new Point(96, 40);
			this.DirectionComboBox.Name = "DirectionComboBox";
			this.DirectionComboBox.PropertyName = "Direction";
			this.DirectionComboBox.Size = new Size(120, 21);
			this.DirectionComboBox.TabIndex = 1;
			this.OnCheckBox.Location = new Point(96, 8);
			this.OnCheckBox.Name = "OnCheckBox";
			this.OnCheckBox.PropertyName = "On";
			this.OnCheckBox.Size = new Size(40, 24);
			this.OnCheckBox.TabIndex = 0;
			this.OnCheckBox.Text = "On";
			base.Controls.Add(this.OnCheckBox);
			base.Controls.Add(this.IntervalTextBox);
			base.Controls.Add(this.DirectionComboBox);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Location = new Point(10, 20);
			base.Name = "AnimationEditorPlugIn";
			base.Size = new Size(464, 200);
			base.Title = "Animation Editor";
			base.ResumeLayout(false);
		}
	}
}
