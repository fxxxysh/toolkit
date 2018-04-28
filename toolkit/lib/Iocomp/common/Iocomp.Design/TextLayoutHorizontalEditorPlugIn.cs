using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class TextLayoutHorizontalEditorPlugIn : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox TrimmingComboBox;

		private FocusLabel label5;

		private Iocomp.Design.Plugin.EditorControls.CheckBox FlippedCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LineLimitCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox NoClipCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox MeasureTrailingSpacesCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox NoWrapCheckBox;

		private Container components;

		public TextLayoutHorizontalEditorPlugIn()
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
			this.TrimmingComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			this.label5 = new FocusLabel();
			this.FlippedCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.LineLimitCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.NoClipCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.MeasureTrailingSpacesCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.NoWrapCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			this.TrimmingComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.TrimmingComboBox.Location = new Point(224, 16);
			this.TrimmingComboBox.Name = "TrimmingComboBox";
			this.TrimmingComboBox.PropertyName = "Trimming";
			this.TrimmingComboBox.Size = new Size(120, 21);
			this.TrimmingComboBox.TabIndex = 5;
			this.label5.LoadingBegin();
			this.label5.FocusControl = this.TrimmingComboBox;
			this.label5.Location = new Point(171, 18);
			this.label5.Name = "label5";
			this.label5.Size = new Size(53, 15);
			this.label5.Text = "Trimming";
			this.label5.LoadingEnd();
			this.FlippedCheckBox.Location = new Point(16, 88);
			this.FlippedCheckBox.Name = "FlippedCheckBox";
			this.FlippedCheckBox.PropertyName = "Flipped";
			this.FlippedCheckBox.Size = new Size(80, 24);
			this.FlippedCheckBox.TabIndex = 3;
			this.FlippedCheckBox.Text = "Flipped";
			this.LineLimitCheckBox.Location = new Point(16, 16);
			this.LineLimitCheckBox.Name = "LineLimitCheckBox";
			this.LineLimitCheckBox.PropertyName = "LineLimit";
			this.LineLimitCheckBox.Size = new Size(80, 24);
			this.LineLimitCheckBox.TabIndex = 0;
			this.LineLimitCheckBox.Text = "Line Limit";
			this.NoClipCheckBox.Location = new Point(16, 40);
			this.NoClipCheckBox.Name = "NoClipCheckBox";
			this.NoClipCheckBox.PropertyName = "NoClip";
			this.NoClipCheckBox.Size = new Size(80, 24);
			this.NoClipCheckBox.TabIndex = 1;
			this.NoClipCheckBox.Text = "No Clip";
			this.MeasureTrailingSpacesCheckBox.Location = new Point(16, 112);
			this.MeasureTrailingSpacesCheckBox.Name = "MeasureTrailingSpacesCheckBox";
			this.MeasureTrailingSpacesCheckBox.PropertyName = "MeasureTrailingSpaces";
			this.MeasureTrailingSpacesCheckBox.Size = new Size(152, 24);
			this.MeasureTrailingSpacesCheckBox.TabIndex = 4;
			this.MeasureTrailingSpacesCheckBox.Text = "Measure Trailing Spaces";
			this.NoWrapCheckBox.Location = new Point(16, 64);
			this.NoWrapCheckBox.Name = "NoWrapCheckBox";
			this.NoWrapCheckBox.PropertyName = "NoWrap";
			this.NoWrapCheckBox.Size = new Size(80, 24);
			this.NoWrapCheckBox.TabIndex = 2;
			this.NoWrapCheckBox.Text = "No Wrap";
			base.Controls.Add(this.FlippedCheckBox);
			base.Controls.Add(this.LineLimitCheckBox);
			base.Controls.Add(this.NoClipCheckBox);
			base.Controls.Add(this.MeasureTrailingSpacesCheckBox);
			base.Controls.Add(this.NoWrapCheckBox);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.TrimmingComboBox);
			base.Name = "TextLayoutHorizontalEditorPlugIn";
			base.Size = new Size(416, 176);
			base.Title = "Text Layout Editor";
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new AlignmentTextEditorPlugIn(), "Alignment", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as TextLayoutHorizontal).Alignment;
		}
	}
}
