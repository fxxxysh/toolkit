using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using PlotToolBarIcons;
using System;
using System.Collections;
using System.ComponentModel.Design;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Iocomp.Design
{
	public class PlotToolBarStandardDesigner : System.Windows.Forms.Design.ControlDesigner
	{
		public override DesignerVerbCollection Verbs
		{
			get
			{
				DesignerVerb[] value = new DesignerVerb[4]
				{
					new DesignerVerb("Add ImageList (Small)", this.OnAddImageListSmall),
					new DesignerVerb("Add ImageList (Large)", this.OnAddImageListLarge),
					new DesignerVerb("Reset ImageList (Small)", this.OnResetImageListSmall),
					new DesignerVerb("Reset ImageList (Large)", this.OnResetImageListLarge)
				};
				return new DesignerVerbCollection(value);
			}
		}

		public override void OnSetComponentDefaults()
		{
			base.OnSetComponentDefaults();
			(this.Control as ISetDesignerDefaults).DoDefaults((IDesignerHost)this.GetService(typeof(IDesignerHost)));
			PlotToolBarStandardDesigner.LoadImages(this.AddImageList(), new Size(16, 16));
			base.RaiseComponentChanged(null, null, null);
		}

		private void OnAddImageListSmall(object sender, EventArgs e)
		{
			PlotToolBarStandardDesigner.LoadImages(this.AddImageList(), new Size(16, 16));
			base.RaiseComponentChanged(null, null, null);
		}

		private void OnAddImageListLarge(object sender, EventArgs e)
		{
			PlotToolBarStandardDesigner.LoadImages(this.AddImageList(), new Size(32, 32));
			base.RaiseComponentChanged(null, null, null);
		}

		private void OnResetImageListSmall(object sender, EventArgs e)
		{
			PlotToolBarStandardDesigner.LoadImages((this.Control as PlotToolBarStandard).ImageList, new Size(16, 16));
			base.RaiseComponentChanged(null, null, null);
		}

		private void OnResetImageListLarge(object sender, EventArgs e)
		{
			PlotToolBarStandardDesigner.LoadImages((this.Control as PlotToolBarStandard).ImageList, new Size(32, 32));
			base.RaiseComponentChanged(null, null, null);
		}

		public ImageList AddImageList()
		{
			IDesignerHost designerHost = (IDesignerHost)this.GetService(typeof(IDesignerHost));
			ImageList imageList = (ImageList)designerHost.CreateComponent(typeof(ImageList));
			PlotToolBarStandard plotToolBarStandard = this.Control as PlotToolBarStandard;
			plotToolBarStandard.ImageList = imageList;
			return imageList;
		}

		private static void LoadImagesByName(ImageList imageList, Size sizeRequired, string name)
		{
			Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(typeof(Access), name);
			if (manifestResourceStream != null)
			{
				Icon original = new Icon(manifestResourceStream);
				original = new Icon(original, sizeRequired);
				imageList.Images.Add(original);
			}
		}

		public static void LoadImages(ImageList imageList, Size sizeRequired)
		{
			if (imageList != null)
			{
				imageList.Images.Clear();
				imageList.ImageSize = sizeRequired;
				PlotToolBarStandardDesigner.LoadImagesByName(imageList, sizeRequired, "PlotToolBarTrackingResume.ico");
				PlotToolBarStandardDesigner.LoadImagesByName(imageList, sizeRequired, "PlotToolBarTrackingPause.ico");
				PlotToolBarStandardDesigner.LoadImagesByName(imageList, sizeRequired, "PlotToolBarAxesScroll.ico");
				PlotToolBarStandardDesigner.LoadImagesByName(imageList, sizeRequired, "PlotToolBarAxesZoom.ico");
				PlotToolBarStandardDesigner.LoadImagesByName(imageList, sizeRequired, "PlotToolBarZoomOut.ico");
				PlotToolBarStandardDesigner.LoadImagesByName(imageList, sizeRequired, "PlotToolBarZoomIn.ico");
				PlotToolBarStandardDesigner.LoadImagesByName(imageList, sizeRequired, "PlotToolBarSelect.ico");
				PlotToolBarStandardDesigner.LoadImagesByName(imageList, sizeRequired, "PlotToolBarZoomBox.ico");
				PlotToolBarStandardDesigner.LoadImagesByName(imageList, sizeRequired, "PlotToolBarDataCursor.ico");
				PlotToolBarStandardDesigner.LoadImagesByName(imageList, sizeRequired, "PlotToolBarEdit.ico");
				PlotToolBarStandardDesigner.LoadImagesByName(imageList, sizeRequired, "PlotToolBarCopy.ico");
				PlotToolBarStandardDesigner.LoadImagesByName(imageList, sizeRequired, "PlotToolBarSave.ico");
				PlotToolBarStandardDesigner.LoadImagesByName(imageList, sizeRequired, "PlotToolBarPrint.ico");
				PlotToolBarStandardDesigner.LoadImagesByName(imageList, sizeRequired, "PlotToolBarPreview.ico");
				PlotToolBarStandardDesigner.LoadImagesByName(imageList, sizeRequired, "PlotToolBarPageSetup.ico");
			}
		}

		protected override void PostFilterProperties(IDictionary properties)
		{
			base.PostFilterProperties(properties);
		}

		protected override void PostFilterEvents(IDictionary events)
		{
			base.PostFilterEvents(events);
		}
	}
}
