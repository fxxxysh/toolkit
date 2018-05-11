using System.Collections;
using System.Windows.Forms.Design;

namespace Iocomp.Design.Plugin.EditorControls
{
	public class DateTimePickerDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		protected override void PostFilterProperties(IDictionary properties)
		{
			properties.Remove("AccessibleDescription");
			properties.Remove("AccessibleName");
			properties.Remove("AccessibleRole");
			properties.Remove("AllowDrop");
			properties.Remove("Anchor");
			properties.Remove("BackColor");
			properties.Remove("BackgroundImage");
			properties.Remove("CalendarFont");
			properties.Remove("CalendarForeColor");
			properties.Remove("CalendarMonthBackground");
			properties.Remove("CalendarTitleBackColor");
			properties.Remove("CalendarTitleForeColor");
			properties.Remove("CalendarTrailingForeColor");
			properties.Remove("CausesValidation");
			properties.Remove("Checked");
			properties.Remove("ContextMenu");
			properties.Remove("Cursor");
			properties.Remove("DataBindings");
			properties.Remove("Dock");
			properties.Remove("DropDownAlign");
			properties.Remove("DynamicProperties");
			properties.Remove("Enabled");
			properties.Remove("Font");
			properties.Remove("ForeColor");
			properties.Remove("ImeMode");
			properties.Remove("MaxDate");
			properties.Remove("MinDate");
			properties.Remove("RightToLeft");
			properties.Remove("ShowCheckBox");
			properties.Remove("TabStop");
			properties.Remove("Tag");
			properties.Remove("Text");
			properties.Remove("Value");
		}

		protected override void PostFilterEvents(IDictionary events)
		{
			base.PostFilterEvents(events);
			events.Clear();
		}
	}
}
