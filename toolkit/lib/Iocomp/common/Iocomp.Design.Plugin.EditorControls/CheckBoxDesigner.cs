using System.Collections;
using System.Windows.Forms.Design;

namespace Iocomp.Design.Plugin.EditorControls
{
	public class CheckBoxDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		protected override void PostFilterProperties(IDictionary properties)
		{
			properties.Remove("AccessibleDescription");
			properties.Remove("AccessibleName");
			properties.Remove("AccessibleRole");
			properties.Remove("AllowDrop");
			properties.Remove("Anchor");
			properties.Remove("Appearance");
			properties.Remove("AutoCheck");
			properties.Remove("BackColor");
			properties.Remove("BackgroundImage");
			properties.Remove("CausesValidation");
			properties.Remove("CheckAlign");
			properties.Remove("Checked");
			properties.Remove("CheckState");
			properties.Remove("ContextMenu");
			properties.Remove("Cursor");
			properties.Remove("DataBindings");
			properties.Remove("Dock");
			properties.Remove("DynamicProperties");
			properties.Remove("Enabled");
			properties.Remove("FlatStyle");
			properties.Remove("Font");
			properties.Remove("ForeColor");
			properties.Remove("Image");
			properties.Remove("ImageAlign");
			properties.Remove("ImageIndex");
			properties.Remove("ImageList");
			properties.Remove("ImeMode");
			properties.Remove("RightToLeft");
			properties.Remove("TabStop");
			properties.Remove("Tag");
			properties.Remove("TextAlign");
			properties.Remove("ThreeState");
		}

		protected override void PostFilterEvents(IDictionary events)
		{
			base.PostFilterEvents(events);
			events.Clear();
		}
	}
}
