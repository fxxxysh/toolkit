using Iocomp.Classes;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Iocomp.Design
{
	[Description("Plot Layout Viewer")]
	[ToolboxItem(false)]
	[DesignerCategory("code")]
	public class PlotLayoutViewer : ControlBase, IPlugInEditorControl
	{
		private Plot m_Plot;

		private IPlugInStandard m_PlugInForm;

		private UIInputCollection m_UICollection;

		private bool m_IsDirty;

		public static PlotLayoutViewerDragControl m_DragControl;

		IPlugInStandard IPlugInEditorControl.PlugInForm
		{
			get
			{
				return this.m_PlugInForm;
			}
			set
			{
				this.m_PlugInForm = value;
			}
		}

		string IPlugInEditorControl.PropertyName
		{
			get
			{
				return "";
			}
			set
			{
			}
		}

		bool IPlugInEditorControl.IsValid
		{
			get
			{
				return true;
			}
		}

		bool IPlugInEditorControl.IsReadOnly
		{
			get
			{
				return false;
			}
		}

		protected override Size DefaultSize => new Size(300, 150);

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public Plot Plot
		{
			get
			{
				return this.m_Plot;
			}
			set
			{
				this.m_Plot = value;
			}
		}

		public static PlotLayoutViewerDragControl DragControl => PlotLayoutViewer.m_DragControl;

		void IPlugInEditorControl.UploadDisplay(object value)
		{
			this.m_Plot = (value as Plot);
			this.DoSetup();
			this.m_IsDirty = false;
		}

		void IPlugInEditorControl.TransferAmbient(object source, object destination)
		{
		}

		bool IPlugInEditorControl.GetIsDisplayDirty(object original)
		{
			return this.m_IsDirty;
		}

		public PlotLayoutViewer()
		{
			base.DoCreate();
			PlotLayoutViewer.m_DragControl = new PlotLayoutViewerDragControl(this);
		}

		protected override void CreateObjects()
		{
			this.m_UICollection = new UIInputCollection(this);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.Border.Margin = 2;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e)
		{
			this.m_UICollection.MouseLeft(e);
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			this.m_UICollection.MouseMove(e);
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			this.m_UICollection.MouseUp(e);
		}

		protected override void InternalOnMouseWheel(MouseEventArgs e)
		{
			this.m_UICollection.MouseWheel(e);
		}

		protected override void InternalOnKeyDown(KeyEventArgs e)
		{
			this.m_UICollection.KeyDown(e);
		}

		protected override void InternalOnKeyUp(KeyEventArgs e)
		{
			this.m_UICollection.KeyUp(e);
		}

		protected override void InternalOnLostFocus(EventArgs e)
		{
			this.m_UICollection.LostFocus(e);
		}

		protected override void InternalOnGotFocus(EventArgs e)
		{
			this.m_UICollection.GotFocus(e);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			if (this.Plot != null)
			{
				this.DoSetup();
			}
		}

		protected override void DoPaint(PaintArgs p)
		{
			this.Plot.LayoutManager.Execute(p, false, base.InnerRectangle, base.InnerRectangle);
			this.Plot.LayoutManager.DrawLayout(p, base.Font, SystemColors.ControlText, SystemColors.Control);
			PlotLayoutViewer.DragControl.Draw(p, base.Font, SystemColors.ControlText, Color.FromArgb(200, Color.SteelBlue));
			this.DoSetup();
		}

		private void DoSetup()
		{
			this.m_UICollection.Clear();
			foreach (PlotLayoutBlockBase blockObject in this.Plot.LayoutManager.BlockObjects)
			{
				this.m_UICollection.Add(blockObject);
			}
			this.Plot.LayoutManager.LayoutRectangle = base.InnerRectangle;
		}

		public void MakeDirty()
		{
			this.m_IsDirty = true;
			this.m_PlugInForm.ForceDirtyUpdate();
		}
	}
}
