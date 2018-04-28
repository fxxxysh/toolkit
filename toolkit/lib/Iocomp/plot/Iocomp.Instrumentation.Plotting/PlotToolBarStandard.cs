using Iocomp.Classes;
using Iocomp.Design;
using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Windows.Forms;
using ToolboxBitmaps;

namespace Iocomp.Instrumentation.Plotting
{
	[ToolboxItem(true)]
	[Designer(typeof(PlotToolBarStandardDesigner))]
	[DefaultEvent("ButtonClick")]
	[DesignerCategory("code")]
	[DesignerSerializer(typeof(LoadBeginEndSerializerPlotToolBarStandard), typeof(CodeDomSerializer))]
	[ToolboxBitmap(typeof(Access), "PlotToolBar.bmp")]
	[Description("Plot ToolBar Standard")]
	public class PlotToolBarStandard : ToolBar, ISetDesignerDefaults
	{
		private Plot m_Plot;

		private ContextMenu m_MenuResume;

		private ContextMenu m_MenuCopy;

		protected override Size DefaultSize => new Size(500, 42);

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public Plot Plot
		{
			get
			{
				return this.m_Plot;
			}
			set
			{
				if (value != this.m_Plot)
				{
					if (this.m_Plot != null)
					{
						this.m_Plot.ToolBarAdapter.Changed -= this.ToolBarAdapter_Changed;
					}
					this.m_Plot = value;
					if (this.m_Plot != null)
					{
						this.m_Plot.ToolBarAdapter.Changed += this.ToolBarAdapter_Changed;
						this.ToolBarAdapter_Changed(null, null);
					}
				}
			}
		}

		void ISetDesignerDefaults.DoDefaults(IDesignerHost host)
		{
			this.DoDefaults(host);
		}

		public PlotToolBarStandard()
		{
			base.Appearance = ToolBarAppearance.Flat;
		}

		public virtual void LoadingBegin()
		{
		}

		public virtual void LoadingEnd()
		{
			if (this.m_Plot != null)
			{
				this.ToolBarAdapter_Changed(null, null);
			}
			this.m_MenuResume = new ContextMenu();
			MenuItem menuItem = new MenuItem();
			menuItem.Click += this.ResumeAll_Click;
			menuItem.Text = "Resume All";
			this.m_MenuResume.MenuItems.Add(menuItem);
			menuItem = new MenuItem();
			menuItem.Click += this.ResumeSelected_Click;
			menuItem.Text = "Resume Selected";
			this.m_MenuResume.MenuItems.Add(menuItem);
			this.m_MenuCopy = new ContextMenu();
			this.m_MenuCopy.MenuItems.Add(new MenuItem("Copy Picture", this.CopyPicture_Click));
			this.m_MenuCopy.MenuItems.Add(new MenuItem("Copy Data", this.CopyData_Click));
		}

		private void ResumeAll_Click(object sender, EventArgs e)
		{
			this.Plot.ToolBarAdapter.DoButtonClickTrackingResumeAll();
		}

		private void ResumeSelected_Click(object sender, EventArgs e)
		{
			this.Plot.ToolBarAdapter.DoButtonClickTrackingResumeSelected();
		}

		private void CopyPicture_Click(object sender, EventArgs e)
		{
			this.Plot.ToolBarAdapter.DoButtonClickCopyPicture();
		}

		private void CopyData_Click(object sender, EventArgs e)
		{
			this.Plot.ToolBarAdapter.DoButtonClickCopyData();
		}

		private PlotToolBarButton CreateButton(IDesignerHost host, PlotToolBarCommandStyle command)
		{
			PlotToolBarButton plotToolBarButton = (PlotToolBarButton)host.CreateComponent(typeof(PlotToolBarButton));
			plotToolBarButton.Command = command;
			base.Buttons.Add(plotToolBarButton);
			return plotToolBarButton;
		}

		[Description("")]
		public void SetupButton(PlotToolBarButton value)
		{
			if (value.Command == PlotToolBarCommandStyle.TrackingResume)
			{
				value.DropDownMenu = this.m_MenuResume;
				value.Style = ToolBarButtonStyle.DropDownButton;
			}
			else if (value.Command == PlotToolBarCommandStyle.Copy)
			{
				value.DropDownMenu = this.m_MenuCopy;
				value.Style = ToolBarButtonStyle.DropDownButton;
			}
		}

		private void DoDefaults(IDesignerHost host)
		{
			this.CreateButton(host, PlotToolBarCommandStyle.TrackingResume);
			this.CreateButton(host, PlotToolBarCommandStyle.TrackingPause);
			this.CreateButton(host, PlotToolBarCommandStyle.Separator);
			this.CreateButton(host, PlotToolBarCommandStyle.AxesScroll);
			this.CreateButton(host, PlotToolBarCommandStyle.AxesZoom);
			this.CreateButton(host, PlotToolBarCommandStyle.Separator);
			this.CreateButton(host, PlotToolBarCommandStyle.ZoomOut);
			this.CreateButton(host, PlotToolBarCommandStyle.ZoomIn);
			this.CreateButton(host, PlotToolBarCommandStyle.Separator);
			this.CreateButton(host, PlotToolBarCommandStyle.Select);
			this.CreateButton(host, PlotToolBarCommandStyle.ZoomBox);
			this.CreateButton(host, PlotToolBarCommandStyle.DataCursor);
			this.CreateButton(host, PlotToolBarCommandStyle.Separator);
			this.CreateButton(host, PlotToolBarCommandStyle.Edit);
			this.CreateButton(host, PlotToolBarCommandStyle.Separator);
			this.CreateButton(host, PlotToolBarCommandStyle.Copy);
			this.CreateButton(host, PlotToolBarCommandStyle.Save);
			this.CreateButton(host, PlotToolBarCommandStyle.Separator);
			this.CreateButton(host, PlotToolBarCommandStyle.Print);
			this.CreateButton(host, PlotToolBarCommandStyle.Preview);
			this.CreateButton(host, PlotToolBarCommandStyle.PageSetup);
		}

		protected override void OnButtonClick(ToolBarButtonClickEventArgs e)
		{
			base.OnButtonClick(e);
			if (e.Button != null && this.Plot != null && e.Button is PlotToolBarButton)
			{
				switch ((e.Button as PlotToolBarButton).Command)
				{
				case PlotToolBarCommandStyle.TrackingResume:
					this.Plot.ToolBarAdapter.DoButtonClickTrackingResumeAll();
					break;
				case PlotToolBarCommandStyle.TrackingPause:
					this.Plot.ToolBarAdapter.DoButtonClickTrackingPause();
					break;
				case PlotToolBarCommandStyle.AxesScroll:
					this.Plot.ToolBarAdapter.DoButtonClickAxesScroll();
					break;
				case PlotToolBarCommandStyle.AxesZoom:
					this.Plot.ToolBarAdapter.DoButtonClickAxesZoom();
					break;
				case PlotToolBarCommandStyle.ZoomIn:
					this.Plot.ToolBarAdapter.DoButtonClickZoomIn();
					break;
				case PlotToolBarCommandStyle.ZoomOut:
					this.Plot.ToolBarAdapter.DoButtonClickZoomOut();
					break;
				case PlotToolBarCommandStyle.Select:
					this.Plot.ToolBarAdapter.DoButtonClickSelect();
					break;
				case PlotToolBarCommandStyle.ZoomBox:
					this.Plot.ToolBarAdapter.DoButtonClickZoomBox();
					break;
				case PlotToolBarCommandStyle.DataCursor:
					this.Plot.ToolBarAdapter.DoButtonClickDataCursor();
					break;
				case PlotToolBarCommandStyle.Save:
					this.Plot.ToolBarAdapter.DoButtonClickSave();
					break;
				case PlotToolBarCommandStyle.Edit:
					this.Plot.ToolBarAdapter.DoButtonClickEdit();
					break;
				case PlotToolBarCommandStyle.Copy:
					this.Plot.ToolBarAdapter.DoButtonClickCopy();
					break;
				case PlotToolBarCommandStyle.Print:
					this.Plot.ToolBarAdapter.DoButtonClickPrint();
					break;
				case PlotToolBarCommandStyle.Preview:
					this.Plot.ToolBarAdapter.DoButtonClickPrintPreview();
					break;
				case PlotToolBarCommandStyle.PageSetup:
					this.Plot.ToolBarAdapter.DoButtonClickPrintPageSetup();
					break;
				}
			}
		}

		private void ToolBarAdapter_Changed(object sender, EventArgs e)
		{
			if (this.Plot != null)
			{
				PlotToolBarAdapter toolBarAdapter = this.Plot.ToolBarAdapter;
				for (int i = 0; i < base.Buttons.Count; i++)
				{
					PlotToolBarButton plotToolBarButton = base.Buttons[i] as PlotToolBarButton;
					if (plotToolBarButton != null)
					{
						PlotToolBarCommandStyle command = plotToolBarButton.Command;
						if (command == PlotToolBarCommandStyle.TrackingResume)
						{
							plotToolBarButton.Enabled = toolBarAdapter.AxesTrackingAnyDisabled;
						}
						if (command == PlotToolBarCommandStyle.TrackingPause)
						{
							plotToolBarButton.Enabled = toolBarAdapter.AxesTrackingAnyEnabled;
						}
						if (command == PlotToolBarCommandStyle.AxesScroll)
						{
							plotToolBarButton.Pushed = (toolBarAdapter.AxisMouseMode == PlotAxisMouseMode.Scroll);
						}
						if (command == PlotToolBarCommandStyle.AxesZoom)
						{
							plotToolBarButton.Pushed = (toolBarAdapter.AxisMouseMode == PlotAxisMouseMode.Zoom);
						}
						if (command == PlotToolBarCommandStyle.Select)
						{
							plotToolBarButton.Pushed = (toolBarAdapter.DataViewMouseMode == PlotDataViewMouseMode.Select);
						}
						if (command == PlotToolBarCommandStyle.ZoomBox)
						{
							plotToolBarButton.Pushed = (toolBarAdapter.DataViewMouseMode == PlotDataViewMouseMode.ZoomBox);
						}
						if (command == PlotToolBarCommandStyle.DataCursor)
						{
							plotToolBarButton.Pushed = (toolBarAdapter.DataViewMouseMode == PlotDataViewMouseMode.DataCursor);
						}
					}
				}
			}
		}
	}
}
