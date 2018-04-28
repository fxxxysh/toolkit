using System.Collections;
using System.Windows.Forms.Design;

namespace Iocomp.Design.Plugin.EditorControls
{
	public class NumericUpDownDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		protected override void PostFilterProperties(IDictionary properties)
		{
			properties.Remove("AccessibleDescription");
			properties.Remove("AccessibleName");
			properties.Remove("AccessibleRole");
			properties.Remove("AllowDrop");
			properties.Remove("Anchor");
			properties.Remove("Appearance");
			properties.Remove("BackColor");
			properties.Remove("BorderStyle");
			properties.Remove("BackgroundImage");
			properties.Remove("CausesValidation");
			properties.Remove("ContextMenu");
			properties.Remove("Cursor");
			properties.Remove("DataBindings");
			properties.Remove("Dock");
			properties.Remove("DynamicProperties");
			properties.Remove("Enabled");
			properties.Remove("Font");
			properties.Remove("ForeColor");
			properties.Remove("ImeMode");
			properties.Remove("InterceptArrowKeys");
			properties.Remove("RightToLeft");
			properties.Remove("TabStop");
			properties.Remove("Tag");
			properties.Remove("Value");
		}

		protected override void PostFilterEvents(IDictionary events)
		{
			base.PostFilterEvents(events);
			events.Clear();
		}
	}
}
