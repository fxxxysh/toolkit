using Iocomp.Classes;
using System.Collections;
using System.Windows.Forms.Design;

namespace Iocomp.Design.Plugin.EditorControls
{
	public class EditBoxDesigner : ControlDesigner
	{
		public override SelectionRules SelectionRules
		{
			get
			{
				if ((base.Component as EditBase).AutoSize)
				{
					return base.SelectionRules & ~SelectionRules.TopSizeable & ~SelectionRules.BottomSizeable;
				}
				return base.SelectionRules;
			}
		}

		protected override void PostFilterProperties(IDictionary properties)
		{
			base.PostFilterProperties(properties);
			properties.Remove("AcceptsReturn");
			properties.Remove("AcceptsTab");
			properties.Remove("AccessibleDescription");
			properties.Remove("AccessibleName");
			properties.Remove("AccessibleRole");
			properties.Remove("AllowDrop");
			properties.Remove("Anchor");
			properties.Remove("AutoSize");
			properties.Remove("BackColor");
			properties.Remove("BackgroundImage");
			properties.Remove("BorderStyle");
			properties.Remove("CausesValidation");
			properties.Remove("CharacterCasing");
			properties.Remove("ContextMenu");
			properties.Remove("Cursor");
			properties.Remove("DataBindings");
			properties.Remove("Dock");
			properties.Remove("DynamicProperties");
			properties.Remove("Enabled");
			properties.Remove("Font");
			properties.Remove("ForeColor");
			properties.Remove("HideSelection");
			properties.Remove("ImeMode");
			properties.Remove("Length");
			properties.Remove("Lines");
			properties.Remove("MaxLength");
			properties.Remove("Multiline");
			properties.Remove("PasswordChar");
			properties.Remove("RightToLeft");
			properties.Remove("ScrollBars");
			properties.Remove("TabStop");
			properties.Remove("Tag");
			properties.Remove("Text");
			properties.Remove("UpdateOnLostFocus");
			properties.Remove("Value");
			properties.Remove("WordWrap");
		}

		protected override void PostFilterEvents(IDictionary events)
		{
			base.PostFilterEvents(events);
			events.Clear();
		}
	}
}
