using Iocomp.Interfaces;
using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace Iocomp.Design
{
	public class ControlDesigner : System.Windows.Forms.Design.ControlDesigner, IForceDesignerChange
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

		protected override void PostFilterProperties(IDictionary properties)
		{
			base.PostFilterProperties(properties);
			properties.Remove("ValueDataBind");
		}

		private void EditorCustom(object sender, EventArgs e)
		{
			this.DoEditorCustom();
		}

		protected void DoEditorCustom()
		{
			UITypeEditor uITypeEditor = null;
			string message = "Iocomp : Unable to create UITypeEditor";
			try
			{
				if (uITypeEditor == null)
				{
					uITypeEditor = new UITypeEditorGeneric();
				}
			}
			catch (Exception)
			{
				message = "Iocomp : Error Creating UITypeEditor with new UITypeEditorGeneric()";
			}
			if (uITypeEditor == null)
			{
				new Exception(message);
			}
			if (uITypeEditor is UITypeEditorGeneric)
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
