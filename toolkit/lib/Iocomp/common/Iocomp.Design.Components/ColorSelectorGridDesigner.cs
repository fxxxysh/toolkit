using System.Collections;
using System.Windows.Forms.Design;

namespace Iocomp.Design.Components
{
	public class ColorSelectorGridDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		protected override void PostFilterProperties(IDictionary Properties)
		{
			Properties.Remove("BackgroundImage");
			Properties.Remove("Font");
			Properties.Remove("ForeColor");
			Properties.Remove("ImeMode");
			Properties.Remove("Text");
			Properties.Remove("RightToLeft");
		}
	}
}
