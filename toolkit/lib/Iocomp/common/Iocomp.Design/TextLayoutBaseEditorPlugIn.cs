using Iocomp.Classes;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Design
{
	[DesignerCategory("Form")]
	[ToolboxItem(false)]
	public class TextLayoutBaseEditorPlugIn : PlugInStandard
	{
		private Container components;

		public TextLayoutBaseEditorPlugIn()
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
			base.Name = "TextLayoutBaseEditorPlugIn";
			base.Size = new Size(384, 144);
			base.Title = "Text Layout Editor";
		}

		public override void CreateSubPlugIns()
		{
			base.AddSubPlugIn(new AlignmentTextEditorPlugIn(), "Alignment Horizontal", false);
			base.AddSubPlugIn(new AlignmentTextEditorPlugIn(), "Alignment Vertical", false);
		}

		public override void SetSubPlugInsValue()
		{
			base.SubPlugIns[0].Value = (base.Value as TextLayoutBase).AlignmentHorizontal;
			base.SubPlugIns[1].Value = (base.Value as TextLayoutBase).AlignmentVertical;
		}
	}
}
