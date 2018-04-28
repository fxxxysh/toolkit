using Iocomp.Delegates;
using Iocomp.Instrumentation.Plotting;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot ToolBar Adapter.")]
	public class PlotToolBarAdapter
	{
		private Plot m_Plot;

		private PlotAxisMouseMode m_AxisMouseMode;

		private PlotDataViewMouseMode m_DataViewMouseMode;

		private bool m_DefaultSavePathUsed;

		[Description("")]
		public Plot Plot
		{
			get
			{
				return this.m_Plot;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotAxisMouseMode AxisMouseMode
		{
			get
			{
				return this.m_AxisMouseMode;
			}
			set
			{
				if (this.m_AxisMouseMode != value)
				{
					this.m_AxisMouseMode = value;
					this.OnChange();
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public PlotDataViewMouseMode DataViewMouseMode
		{
			get
			{
				return this.m_DataViewMouseMode;
			}
			set
			{
				if (this.m_DataViewMouseMode != value)
				{
					this.m_DataViewMouseMode = value;
					this.OnChange();
				}
			}
		}

		[Description("")]
		public bool AxesTrackingAnyEnabled
		{
			get
			{
				if (this.Plot == null)
				{
					return true;
				}
				foreach (PlotAxis xAxis in this.Plot.XAxes)
				{
					if (xAxis.Tracking.Enabled)
					{
						return true;
					}
				}
				foreach (PlotAxis yAxis in this.Plot.YAxes)
				{
					if (yAxis.Tracking.Enabled)
					{
						return true;
					}
				}
				return false;
			}
		}

		[Description("")]
		public bool AxesTrackingAnyDisabled
		{
			get
			{
				if (this.Plot == null)
				{
					return true;
				}
				foreach (PlotAxis xAxis in this.Plot.XAxes)
				{
					if (!xAxis.Tracking.Enabled)
					{
						return true;
					}
				}
				foreach (PlotAxis yAxis in this.Plot.YAxes)
				{
					if (!yAxis.Tracking.Enabled)
					{
						return true;
					}
				}
				return false;
			}
		}

		public event SaveDialogEventHandler SaveDialogSetup;

		[Description("")]
		public event EventHandler Changed;

		public PlotToolBarAdapter(Plot plot)
		{
			this.m_Plot = plot;
		}

		private void OnChange()
		{
			if (this.Changed != null)
			{
				this.Changed(this, EventArgs.Empty);
			}
		}

		[Description("")]
		public void DoButtonClickEdit()
		{
			this.Plot.ShowEditorCustom(false, true);
		}

		[Description("")]
		public void DoButtonClickTrackingResumeAll()
		{
			foreach (PlotAxis xAxis in this.Plot.XAxes)
			{
				xAxis.Tracking.Enabled = true;
			}
			foreach (PlotAxis yAxis in this.Plot.YAxes)
			{
				yAxis.Tracking.Enabled = true;
			}
			if (this.DataViewMouseMode != 0)
			{
				this.DoButtonClickSelect();
			}
			this.Plot.ClearSubFocus();
			this.Plot.UIInvalidate(this);
		}

		[Description("")]
		public void DoButtonClickTrackingResumeSelected()
		{
			foreach (PlotAxis xAxis in this.Plot.XAxes)
			{
				if (xAxis.DockDataView != null && (xAxis.Focused || xAxis.DockDataView.Focused))
				{
					xAxis.Tracking.Enabled = true;
				}
			}
			foreach (PlotAxis yAxis in this.Plot.YAxes)
			{
				if (yAxis.DockDataView != null && (yAxis.Focused || yAxis.DockDataView.Focused))
				{
					yAxis.Tracking.Enabled = true;
				}
			}
			if (this.DataViewMouseMode != 0)
			{
				this.DoButtonClickSelect();
			}
			this.Plot.UIInvalidate(this);
		}

		[Description("")]
		public void DoButtonClickCopyPicture()
		{
			Clipboard.SetDataObject(this.Plot.SnapShot, true);
		}

		[Description("")]
		public void DoButtonClickCopyData()
		{
			MemoryStream memoryStream = new MemoryStream();
			this.Plot.SaveDataToStream((Stream)memoryStream, out StreamWriter streamWriter);
			streamWriter.Flush();
			memoryStream.Seek(0L, SeekOrigin.Begin);
			StreamReader streamReader = new StreamReader(memoryStream);
			string data = streamReader.ReadToEnd();
			Clipboard.SetDataObject(data, true);
			streamReader.Close();
		}

		[Description("")]
		public void DoButtonClickCopy()
		{
			if (this.Plot.CopyToClipboardFormat == PlotCopyToClipboardFormat.Picture)
			{
				this.DoButtonClickCopyPicture();
			}
			else
			{
				this.DoButtonClickCopyData();
			}
		}

		[Description("")]
		public void DoButtonClickTrackingPause()
		{
			foreach (PlotAxis xAxis in this.Plot.XAxes)
			{
				xAxis.Tracking.Enabled = false;
			}
			foreach (PlotAxis yAxis in this.Plot.YAxes)
			{
				yAxis.Tracking.Enabled = false;
			}
		}

		private void DoZoomInOut(double factor)
		{
			bool flag = false;
			foreach (PlotAxis xAxis in this.Plot.XAxes)
			{
				if (xAxis.DockDataView != null && (xAxis.Focused || xAxis.DockDataView.Focused))
				{
					flag = true;
					xAxis.Zoom(factor);
				}
			}
			foreach (PlotAxis yAxis in this.Plot.YAxes)
			{
				if (yAxis.DockDataView != null && (yAxis.Focused || yAxis.DockDataView.Focused))
				{
					flag = true;
					yAxis.Zoom(factor);
				}
			}
			if (!flag)
			{
				foreach (PlotAxis xAxis2 in this.Plot.XAxes)
				{
					if (xAxis2.DockDataView != null && xAxis2.Visible)
					{
						xAxis2.Zoom(factor);
					}
				}
				foreach (PlotAxis yAxis2 in this.Plot.YAxes)
				{
					if (yAxis2.DockDataView != null && yAxis2.Visible)
					{
						yAxis2.Zoom(factor);
					}
				}
			}
			this.Plot.UIInvalidate(this);
		}

		[Description("")]
		public void DoButtonClickZoomOut()
		{
			this.DoZoomInOut(2.0);
		}

		[Description("")]
		public void DoButtonClickZoomIn()
		{
			this.DoZoomInOut(0.5);
		}

		[Description("")]
		public void ForceChange()
		{
			this.OnChange();
		}

		[Description("")]
		public void DoButtonClickAxesScroll()
		{
			this.AxisMouseMode = PlotAxisMouseMode.Scroll;
		}

		[Description("")]
		public void DoButtonClickAxesZoom()
		{
			this.AxisMouseMode = PlotAxisMouseMode.Zoom;
		}

		[Description("")]
		public void DoButtonClickZoomBox()
		{
			if (this.DataViewMouseMode == PlotDataViewMouseMode.ZoomBox)
			{
				this.DataCursorsOff();
				this.DataViewMouseMode = PlotDataViewMouseMode.Select;
			}
			else
			{
				this.DataCursorsOff();
				this.DataViewMouseMode = PlotDataViewMouseMode.ZoomBox;
			}
		}

		[Description("")]
		public void DoButtonClickDataCursor()
		{
			if (this.DataViewMouseMode == PlotDataViewMouseMode.DataCursor)
			{
				this.DataCursorsOff();
				this.DataViewMouseMode = PlotDataViewMouseMode.Select;
			}
			else
			{
				this.DataCursorsOn();
				this.DataViewMouseMode = PlotDataViewMouseMode.DataCursor;
			}
			this.Plot.UIInvalidate(this);
		}

		[Description("")]
		public void DoButtonClickSelect()
		{
			if (this.DataViewMouseMode == PlotDataViewMouseMode.Select)
			{
				this.DataCursorsOff();
				this.DataViewMouseMode = PlotDataViewMouseMode.ZoomBox;
			}
			else
			{
				this.DataCursorsOff();
				this.DataViewMouseMode = PlotDataViewMouseMode.Select;
			}
		}

		[Description("")]
		public void DoButtonClickPrint()
		{
			this.Plot.PrintAdapter.Print();
		}

		[Description("")]
		public void DoButtonClickPrintPreview()
		{
			this.Plot.PrintAdapter.PrintPreview();
		}

		[Description("")]
		public void DoButtonClickPrintPageSetup()
		{
			this.Plot.PrintAdapter.PrintPageSetup();
		}

		private void DataCursorsOn()
		{
			foreach (PlotDataCursorBase dataCursor in this.Plot.DataCursors)
			{
				dataCursor.Visible = true;
			}
		}

		private void DataCursorsOff()
		{
			foreach (PlotDataCursorBase dataCursor in this.Plot.DataCursors)
			{
				dataCursor.Visible = false;
			}
		}

		private void OnSaveDialogSetup(SaveFileDialog saveFileDialog)
		{
			if (this.SaveDialogSetup != null)
			{
				this.SaveDialogSetup(this, new SaveDialogEventArgs(saveFileDialog));
			}
		}

		[Description("")]
		public void DoButtonClickSave()
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Title = "Save Plot as";
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.CheckPathExists = true;
			saveFileDialog.AddExtension = true;
			saveFileDialog.ShowHelp = true;
			if (!this.m_DefaultSavePathUsed && this.Plot.DefaultSaveImagePath != "")
			{
				saveFileDialog.InitialDirectory = this.Plot.DefaultSaveImagePath;
				this.m_DefaultSavePathUsed = true;
			}
			saveFileDialog.Filter = "Bitmap File(*.bmp)|*.bmp|GIF File(*.gif)|*.gif|JPEG File(*.jpg)|*.jpg|PNG File(*.png)|*.png|TIFF File(*.tif)|*.tif|EMF File(*.emf)|*.emf|All Data(*.dat)|*.dat";
			saveFileDialog.FilterIndex = 4;
			this.OnSaveDialogSetup(saveFileDialog);
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				string fileName = saveFileDialog.FileName;
				if (saveFileDialog.FilterIndex == 1)
				{
					this.Plot.SnapShot.Save(fileName, ImageFormat.Bmp);
				}
				else if (saveFileDialog.FilterIndex == 2)
				{
					this.Plot.SnapShot.Save(fileName, ImageFormat.Gif);
				}
				else if (saveFileDialog.FilterIndex == 3)
				{
					this.Plot.SnapShot.Save(fileName, ImageFormat.Jpeg);
				}
				else if (saveFileDialog.FilterIndex == 4)
				{
					this.Plot.SnapShot.Save(fileName, ImageFormat.Png);
				}
				else if (saveFileDialog.FilterIndex == 5)
				{
					this.Plot.SnapShot.Save(fileName, ImageFormat.Tiff);
				}
				else if (saveFileDialog.FilterIndex == 6)
				{
					this.Plot.GetMetaFile().Save(fileName);
				}
				else if (saveFileDialog.FilterIndex == 7)
				{
					this.Plot.SaveDataToFile(fileName);
				}
			}
		}
	}
}
