using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	public class PlotDesigner : ControlDesigner
	{
		public override DesignerVerbCollection Verbs
		{
			get
			{
				DesignerVerb[] value = new DesignerVerb[2]
				{
					new DesignerVerb("Editor (Custom)", this.EditorCustom),
					new DesignerVerb("Add ToolBar (Standard)", this.OnAddToolBarStandard)
				};
				return new DesignerVerbCollection(value);
			}
		}

		private void EditorCustom(object sender, EventArgs e)
		{
			base.DoEditorCustom();
		}

		private void OnAddToolBarStandard(object sender, EventArgs e)
		{
			IDesignerHost designerHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
			PlotToolBarStandard plotToolBarStandard = (PlotToolBarStandard)designerHost.CreateComponent(typeof(PlotToolBarStandard));
			ImageList imageList = (ImageList)designerHost.CreateComponent(typeof(ImageList));
			plotToolBarStandard.Plot = (this.Control as Plot);
			plotToolBarStandard.ImageList = imageList;
			PlotToolBarStandardDesigner.LoadImages(imageList, new Size(16, 16));
			this.Control.Parent.Controls.Add(plotToolBarStandard);
			((ISetDesignerDefaults)plotToolBarStandard).DoDefaults(designerHost);
		}

		protected override void PostFilterProperties(IDictionary properties)
		{
			base.PostFilterProperties(properties);
			properties.Remove("BackgroundImage");
			properties.Remove("ImeMode");
			properties.Remove("RigthToLeft");
			properties.Remove("Text");
		}

		protected override void PostFilterEvents(IDictionary events)
		{
			base.PostFilterEvents(events);
			events.Remove("BackgroundImageChanged");
			events.Remove("ImeModeChanged");
			events.Remove("RightToLeftChanged");
			events.Remove("TextChanged");
		}
	}
}
