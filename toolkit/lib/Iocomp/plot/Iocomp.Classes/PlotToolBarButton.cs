using Iocomp.Design;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Types;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[DesignerCategory("code")]
	[DesignerSerializer(typeof(LoadBeginEndSerializerPlotToolBarButton), typeof(CodeDomSerializer))]
	[DefaultEvent("")]
	[Description("Plot ToolBar Button.")]
	[ToolboxItem(false)]
	public class PlotToolBarButton : ToolBarButton
	{
		private PlotToolBarCommandStyle m_Command;

		[DefaultValue(PlotToolBarCommandStyle.TrackingResume)]
		[RefreshProperties(RefreshProperties.All)]
		public PlotToolBarCommandStyle Command
		{
			get
			{
				return this.m_Command;
			}
			set
			{
				if (this.m_Command != value)
				{
					this.m_Command = value;
					if (this.Command == PlotToolBarCommandStyle.Separator)
					{
						base.ImageIndex = -1;
						base.ToolTipText = "";
						base.Style = ToolBarButtonStyle.Separator;
						base.Enabled = false;
					}
					else if (this.Command == PlotToolBarCommandStyle.TrackingResume)
					{
						base.ImageIndex = 0;
						base.ToolTipText = "Tracking Resume";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (this.Command == PlotToolBarCommandStyle.TrackingPause)
					{
						base.ImageIndex = 1;
						base.ToolTipText = "Tracking Pause";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (this.Command == PlotToolBarCommandStyle.AxesScroll)
					{
						base.ImageIndex = 2;
						base.ToolTipText = "Axes Scroll";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (this.Command == PlotToolBarCommandStyle.AxesZoom)
					{
						base.ImageIndex = 3;
						base.ToolTipText = "Axes Zoom";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (this.Command == PlotToolBarCommandStyle.ZoomOut)
					{
						base.ImageIndex = 4;
						base.ToolTipText = "Zoom-Out";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (this.Command == PlotToolBarCommandStyle.ZoomIn)
					{
						base.ImageIndex = 5;
						base.ToolTipText = "Zoom-In";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (this.Command == PlotToolBarCommandStyle.Select)
					{
						base.ImageIndex = 6;
						base.ToolTipText = "Select";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (this.Command == PlotToolBarCommandStyle.ZoomBox)
					{
						base.ImageIndex = 7;
						base.ToolTipText = "Zoom-Box";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (this.Command == PlotToolBarCommandStyle.DataCursor)
					{
						base.ImageIndex = 8;
						base.ToolTipText = "Data-Cursor";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (this.Command == PlotToolBarCommandStyle.Edit)
					{
						base.ImageIndex = 9;
						base.ToolTipText = "Edit";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (this.Command == PlotToolBarCommandStyle.Copy)
					{
						base.ImageIndex = 10;
						base.ToolTipText = "Copy to Clipboard";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (this.Command == PlotToolBarCommandStyle.Save)
					{
						base.ImageIndex = 11;
						base.ToolTipText = "Save";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (this.Command == PlotToolBarCommandStyle.Print)
					{
						base.ImageIndex = 12;
						base.ToolTipText = "Print";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (this.Command == PlotToolBarCommandStyle.Preview)
					{
						base.ImageIndex = 13;
						base.ToolTipText = "Preview";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (this.Command == PlotToolBarCommandStyle.PageSetup)
					{
						base.ImageIndex = 14;
						base.ToolTipText = "Page Setup";
						base.Style = ToolBarButtonStyle.PushButton;
						base.Enabled = true;
					}
					else if (this.Command == PlotToolBarCommandStyle.None)
					{
						base.Enabled = true;
					}
				}
			}
		}

		public PlotToolBarButton()
		{
			this.Command = PlotToolBarCommandStyle.TrackingResume;
			base.Style = ToolBarButtonStyle.PushButton;
			base.ToolTipText = "Tracking Resume";
		}

		public virtual void LoadingBegin()
		{
		}

		public virtual void LoadingEnd()
		{
			this.UpdateToolBar();
		}

		private void UpdateToolBar()
		{
			if (base.Parent is PlotToolBarStandard)
			{
				(base.Parent as PlotToolBarStandard).SetupButton(this);
			}
		}
	}
}
