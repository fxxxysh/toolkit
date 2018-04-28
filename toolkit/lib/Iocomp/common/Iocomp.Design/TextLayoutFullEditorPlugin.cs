using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class TextLayoutFullEditorPlugin : PlugInStandard
	{
		private Iocomp.Design.Plugin.EditorControls.ComboBox TrimmingComboBox;

		private FocusLabel label5;

		private Iocomp.Design.Plugin.EditorControls.CheckBox LineLimitCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox NoClipCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox MeasureTrailingSpacesCheckBox;

		private Iocomp.Design.Plugin.EditorControls.CheckBox NoWrapCheckBox;

		private Container components;

		public TextLayoutFullEditorPlugin()
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
			this.LineLimitCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.NoClipCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.MeasureTrailingSpacesCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			this.NoWrapCheckBox = new Iocomp.Design.Plugin.EditorControls.CheckBox();
			base.SuspendLayout();
			this.TrimmingComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.TrimmingComboBox.Location = new Point(216, 24);
			this.TrimmingComboBox.Name = "TrimmingComboBox";
			this.TrimmingComboBox.PropertyName = "Trimming";
			this.TrimmingComboBox.Size = new Size(120, 21);
			this.TrimmingComboBox.TabIndex = 4;
			this.label5.LoadingBegin();
			this.label5.FocusControl = this.TrimmingComboBox;
			this.label5.Location = new Point(163, 26);
			this.label5.Name = "label5";
			this.label5.Size = new Size(53, 15);
			this.label5.Text = "Trimming";
			this.label5.LoadingEnd();
			this.LineLimitCheckBox.Location = new Point(16, 24);
			this.LineLimitCheckBox.Name = "LineLimitCheckBox";
			this.LineLimitCheckBox.PropertyName = "LineLimit";
			this.LineLimitCheckBox.Size = new Size(80, 24);
			this.LineLimitCheckBox.TabIndex = 0;
			this.LineLimitCheckBox.Text = "Line Limit";
			this.NoClipCheckBox.Location = new Point(16, 48);
			this.NoClipCheckBox.Name = "NoClipCheckBox";
			this.NoClipCheckBox.PropertyName = "NoClip";
			this.NoClipCheckBox.Size = new Size(80, 24);
			this.NoClipCheckBox.TabIndex = 1;
			this.NoClipCheckBox.Text = "No Clip";
			this.MeasureTrailingSpacesCheckBox.Location = new Point(16, 96);
			this.MeasureTrailingSpacesCheckBox.Name = "MeasureTrailingSpacesCheckBox";
			this.MeasureTrailingSpacesCheckBox.PropertyName = "MeasureTrailingSpaces";
			this.MeasureTrailingSpacesCheckBox.Size = new Size(152, 24);
			this.MeasureTrailingSpacesCheckBox.TabIndex = 3;
			this.MeasureTrailingSpacesCheckBox.Text = "Measure Trailing Spaces";
			this.NoWrapCheckBox.Location = new Point(16, 72);
			this.NoWrapCheckBox.Name = "NoWrapCheckBox";
			this.NoWrapCheckBox.PropertyName = "NoWrap";
			this.NoWrapCheckBox.Size = new Size(80, 24);
			this.NoWrapCheckBox.TabIndex = 2;
			this.NoWrapCheckBox.Text = "No Wrap";
			base.Controls.Add(this.LineLimitCheckBox);
			base.Controls.Add(this.NoClipCheckBox);
			base.Controls.Add(this.MeasureTrailingSpacesCheckBox);
			base.Controls.Add(this.NoWrapCheckBox);
			base.Controls.Add(this.TrimmingComboBox);
			base.Controls.Add(this.label5);
			base.Name = "TextLayoutFullEditorPlugin";
			base.Size = new Size(392, 160);
			base.Title = "Text Layout Editor";
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new AlignmentTextEditorPlugIn(), "Alignment Horizontal", false);
			base.AddSubPlugIn(new AlignmentTextEditorPlugIn(), "Alignment Vertical", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as TextLayoutFull).AlignmentHorizontal;
			base.SubPlugIns[1].Value = (base.Value as TextLayoutFull).AlignmentVertical;
		}
	}
}
