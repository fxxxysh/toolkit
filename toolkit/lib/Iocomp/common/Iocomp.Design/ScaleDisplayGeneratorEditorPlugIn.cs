using Iocomp.Classes;
using Iocomp.Design.Plugin.EditorControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[ToolboxItem(false)]
	[DesignerCategory("Form")]
	public class ScaleDisplayGeneratorEditorPlugIn : PlugInStandard
	{
		private FocusLabel label4;

		private Iocomp.Design.Plugin.EditorControls.ComboBox GeneratorStyleComboBox;

		private Container components;

		public ScaleDisplayGeneratorEditorPlugIn()
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
			this.label4 = new FocusLabel();
			this.GeneratorStyleComboBox = new Iocomp.Design.Plugin.EditorControls.ComboBox();
			base.SuspendLayout();
			this.label4.LoadingBegin();
			this.label4.FocusControl = this.GeneratorStyleComboBox;
			this.label4.Location = new Point(8, 26);
			this.label4.Name = "label4";
			this.label4.Size = new Size(32, 15);
			this.label4.Text = "Style";
			this.label4.LoadingEnd();
			this.GeneratorStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			this.GeneratorStyleComboBox.Location = new Point(40, 24);
			this.GeneratorStyleComboBox.Name = "GeneratorStyleComboBox";
			this.GeneratorStyleComboBox.PropertyName = "GeneratorStyle";
			this.GeneratorStyleComboBox.Size = new Size(121, 21);
			this.GeneratorStyleComboBox.TabIndex = 0;
			base.Controls.Add(this.label4);
			base.Controls.Add(this.GeneratorStyleComboBox);
			base.Name = "ScaleDisplayGeneratorEditorPlugIn";
			base.Size = new Size(616, 216);
			base.Title = "Scale Display Editor";
			base.ResumeLayout(false);
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new ScaleGeneratorAutoEditorPlugIn(), "Auto", false);
			base.AddSubPlugIn(new ScaleGeneratorFixedEditorPlugIn(), "Fixed", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as ScaleDisplay).GeneratorAuto;
			base.SubPlugIns[1].Value = (base.Value as ScaleDisplay).GeneratorFixed;
		}
	}
}
