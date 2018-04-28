using System.Collections;
using System.Windows.Forms.Design;

namespace Iocomp.Design.Plugin.EditorControls
{
	public class ComboBoxDesigner : System.Windows.Forms.Design.ControlDesigner
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
			properties.Remove("ContextMenu");
			properties.Remove("Cursor");
			properties.Remove("DataSource");
			properties.Remove("DisplayMember");
			properties.Remove("DataBindings");
			properties.Remove("Dock");
			properties.Remove("DrawMode");
			properties.Remove("DynamicProperties");
			properties.Remove("Enabled");
			properties.Remove("Font");
			properties.Remove("ForeColor");
			properties.Remove("ImeMode");
			properties.Remove("IntegralHeight");
			properties.Remove("ItemHeight");
			properties.Remove("Items");
			properties.Remove("MaxLength");
			properties.Remove("RightToLeft");
			properties.Remove("Sorted");
			properties.Remove("Tag");
			properties.Remove("Text");
			properties.Remove("ValueMember");
		}

		protected override void PostFilterEvents(IDictionary events)
		{
			base.PostFilterEvents(events);
			events.Clear();
		}
	}
}
