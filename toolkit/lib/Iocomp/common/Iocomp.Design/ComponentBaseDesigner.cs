using Iocomp.Interfaces;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace Iocomp.Design
{
	public class ComponentBaseDesigner : ComponentDesigner, IForceDesignerChange
	{
		public override DesignerVerbCollection Verbs
		{
			get
			{
				DesignerVerb[] value = new DesignerVerb[1]
				{
					new DesignerVerb("Editor (Custom)", this.EditorCustom)
				};
				return new DesignerVerbCollection(value);
			}
		}

		private void EditorCustom(object sender, EventArgs e)
		{
			this.DoEditorCustom();
		}

		protected void DoEditorCustom()
		{
			UITypeEditor uITypeEditor = (UITypeEditor)TypeDescriptor.GetEditor(base.Component, typeof(UITypeEditor));
			if (uITypeEditor != null && uITypeEditor is UITypeEditorGeneric)
			{
				(uITypeEditor as UITypeEditorGeneric).IForceDesignerChange = this;
				(uITypeEditor as UITypeEditorGeneric).EditValue(null, null, base.Component);
			}
		}

		public void ForceChange()
		{
			base.RaiseComponentChanged(null, null, null);
		}

		public override void InitializeNewComponent(IDictionary defaultValues)
		{
			base.InitializeNewComponent(defaultValues);
			if (base.Component is IControlBase)
			{
				(base.Component as IControlBase).FreezeAutoSize = true;
				try
				{
					(base.Component as IComponentBase).SetComponentDefaults();
				}
				finally
				{
					(base.Component as IControlBase).FreezeAutoSize = false;
				}
			}
		}
	}
}
