using Iocomp.Classes;
using Iocomp.Interfaces;
using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace Iocomp.Design.Plugin.EditorControls
{
	public class FocusLabelDesigner : ControlDesigner
	{
		public override DesignerVerbCollection Verbs
		{
			get
			{
				DesignerVerb[] value = new DesignerVerb[5]
				{
					new DesignerVerb("Align Left", this.OnAlignLeft),
					new DesignerVerb("Align Right", this.OnAlignRight),
					new DesignerVerb("Align Top", this.OnAlignTop),
					new DesignerVerb("Align Bottom", this.OnAlignBottom),
					new DesignerVerb("Text = FocusControl-PropertyName", this.OnSetTextFocusControlPropertyName)
				};
				return new DesignerVerbCollection(value);
			}
		}

		public override SelectionRules SelectionRules
		{
			get
			{
				if ((base.Component as FocusLabel).AutoSize)
				{
					return base.SelectionRules & ~(SelectionRules.TopSizeable | SelectionRules.BottomSizeable | SelectionRules.LeftSizeable | SelectionRules.RightSizeable);
				}
				return base.SelectionRules;
			}
		}

		protected override void PostFilterProperties(IDictionary properties)
		{
			properties.Remove("AccessibleDescription");
			properties.Remove("AccessibleName");
			properties.Remove("AccessibleRole");
			properties.Remove("AllowDrop");
			properties.Remove("Anchor");
			properties.Remove("Appearance");
			properties.Remove("BackColor");
			properties.Remove("Border");
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
			properties.Remove("Rotation");
			properties.Remove("SnapShotTransparent");
			properties.Remove("TabStop");
			properties.Remove("TabIndex");
			properties.Remove("Tag");
			properties.Remove("TextLayout");
		}

		protected override void PostFilterEvents(IDictionary events)
		{
			base.PostFilterEvents(events);
			events.Clear();
		}

		protected override void OnContextMenu(int x, int y)
		{
			FocusLabel focusLabel = base.Component as FocusLabel;
			this.Verbs[0].Enabled = (focusLabel.FocusControl != null);
			this.Verbs[1].Enabled = (focusLabel.FocusControl != null);
			this.Verbs[2].Enabled = (focusLabel.FocusControl != null);
			this.Verbs[3].Enabled = (focusLabel.FocusControl != null);
			this.Verbs[4].Enabled = (focusLabel.FocusControl != null);
			base.OnContextMenu(x, y);
		}

		private void OnAlignRight(object sender, EventArgs e)
		{
			(base.Component as FocusLabel).AlignRight();
			base.RaiseComponentChanged(null, null, null);
		}

		private void OnAlignLeft(object sender, EventArgs e)
		{
			(base.Component as FocusLabel).AlignLeft();
			base.RaiseComponentChanged(null, null, null);
		}

		private void OnAlignTop(object sender, EventArgs e)
		{
			(base.Component as FocusLabel).AlignTop();
			base.RaiseComponentChanged(null, null, null);
		}

		private void OnAlignBottom(object sender, EventArgs e)
		{
			(base.Component as FocusLabel).AlignBottom();
			base.RaiseComponentChanged(null, null, null);
		}

		private void OnSetTextFocusControlPropertyName(object sender, EventArgs e)
		{
			FocusLabel focusLabel = base.Component as FocusLabel;
			IPlugInEditorControl plugInEditorControl = focusLabel.FocusControl as IPlugInEditorControl;
			if (!(plugInEditorControl.PropertyName == Const.EmptyString))
			{
				focusLabel.Text = plugInEditorControl.PropertyName;
			}
		}
	}
}
