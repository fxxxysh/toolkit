using System.Collections;
using System.Windows.Forms.Design;

namespace Iocomp.Design.Plugin.EditorControls
{
	public class EditMultiLineDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		protected override void PostFilterProperties(IDictionary properties)
		{
			properties.Remove("AccessibleDescription");
			properties.Remove("AccessibleName");
			properties.Remove("AccessibleRole");
			properties.Remove("AllowDrop");
			properties.Remove("Anchor");
			properties.Remove("AsString");
			properties.Remove("AutoScroll");
			properties.Remove("AutoScrollMargin");
			properties.Remove("AutoScrollMinSize");
			properties.Remove("BackColor");
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
			properties.Remove("RightToLeft");
			properties.Remove("TabStop");
			properties.Remove("Tag");
			properties.Remove("Text");
		}

		protected override void PostFilterEvents(IDictionary events)
		{
			base.PostFilterEvents(events);
			events.Clear();
		}
	}
}
