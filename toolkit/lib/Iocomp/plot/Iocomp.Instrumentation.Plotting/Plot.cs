using Iocomp.Classes;
using Iocomp.Design;
using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ToolboxBitmaps;

namespace Iocomp.Instrumentation.Plotting
{
	[Description("Plot")]
	[Designer(typeof(PlotDesigner))]
	[DefaultEvent("Click")]
	[LicenseProvider(typeof(IocompLicenseProviderPlot))]
	[ToolboxBitmap(typeof(Access), "Plot.bmp")]
	[DesignerCategory("code")]
	public class Plot : PlotBase
	{
		private PlotChannelBaseCollection m_Channels;

		private PlotDataViewCollection m_DataViews;

		private PlotXAxisCollection m_XAxes;

		private PlotYAxisCollection m_YAxes;

		private PlotLimitBaseCollection m_Limits;

		private PlotDataCursorBaseCollection m_DataCursors;

		private PlotToolBarAdapter m_ToolBarAdapter;

		private PlotLogFileAdapter m_LogFileAdapter;

		private PlotLayoutManager m_LayoutManager;

		[Browsable(false)]
		[Description("Plot ToolBar Adapter")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PlotToolBarAdapter ToolBarAdapter
		{
			get
			{
				return this.m_ToolBarAdapter;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Log File")]
		public PlotLogFileAdapter LogFile
		{
			get
			{
				return this.m_LogFileAdapter;
			}
		}

		[Browsable(false)]
		[Description("Plot Layout Manager")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PlotLayoutManager LayoutManager
		{
			get
			{
				return this.m_LayoutManager;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		[Category("Iocomp")]
		public PlotChannelBaseCollection Channels
		{
			get
			{
				return this.m_Channels;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Iocomp")]
		public PlotDataViewCollection DataViews
		{
			get
			{
				return this.m_DataViews;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Iocomp")]
		public PlotXAxisCollection XAxes
		{
			get
			{
				return this.m_XAxes;
			}
		}

		[Category("Iocomp")]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotYAxisCollection YAxes
		{
			get
			{
				return this.m_YAxes;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Iocomp")]
		public PlotLimitBaseCollection Limits
		{
			get
			{
				return this.m_Limits;
			}
		}

		[Description("")]
		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotDataCursorBaseCollection DataCursors
		{
			get
			{
				return this.m_DataCursors;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Plot";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotEditorPlugIn";
		}

		public Plot()
		{
			base.m_License = LicenseManager.Validate(typeof(Plot), this);
			base.DoCreate();
		}

		~Plot()
		{
			base.Dispose();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_ToolBarAdapter = new PlotToolBarAdapter(this);
			this.m_LogFileAdapter = new PlotLogFileAdapter(this);
			base.AddSubClass(this.LogFile);
			this.m_LayoutManager = new PlotLayoutManager(this);
			this.m_Channels = new PlotChannelBaseCollection(this);
			this.m_DataViews = new PlotDataViewCollection(this);
			this.m_XAxes = new PlotXAxisCollection(this);
			this.m_YAxes = new PlotYAxisCollection(this);
			this.m_Limits = new PlotLimitBaseCollection(this);
			this.m_DataCursors = new PlotDataCursorBaseCollection(this);
			this.Channels.ObjectAdded += this.m_Plot_ObjectAdded;
			this.Channels.ObjectRemoved += this.m_Plot_ObjectRemoved;
			this.Channels.ObjectRenamed += this.m_Plot_ObjectRenamed;
			this.DataViews.ObjectAdded += this.m_Plot_ObjectAdded;
			this.DataViews.ObjectRemoved += this.m_Plot_ObjectRemoved;
			this.DataViews.ObjectRenamed += this.m_Plot_ObjectRenamed;
			this.XAxes.ObjectAdded += this.m_Plot_ObjectAdded;
			this.XAxes.ObjectRemoved += this.m_Plot_ObjectRemoved;
			this.XAxes.ObjectRenamed += this.m_Plot_ObjectRenamed;
			this.YAxes.ObjectAdded += this.m_Plot_ObjectAdded;
			this.YAxes.ObjectRemoved += this.m_Plot_ObjectRemoved;
			this.YAxes.ObjectRenamed += this.m_Plot_ObjectRenamed;
			base.Labels.ObjectAdded += this.m_Plot_ObjectAdded;
			base.Labels.ObjectRemoved += this.m_Plot_ObjectRemoved;
			base.Labels.ObjectRenamed += this.m_Plot_ObjectRenamed;
			base.Legends.ObjectAdded += this.m_Plot_ObjectAdded;
			base.Legends.ObjectRemoved += this.m_Plot_ObjectRemoved;
			base.Legends.ObjectRenamed += this.m_Plot_ObjectRenamed;
			base.Tables.ObjectAdded += this.m_Plot_ObjectAdded;
			base.Tables.ObjectRemoved += this.m_Plot_ObjectRemoved;
			base.Tables.ObjectRenamed += this.m_Plot_ObjectRenamed;
			this.Limits.ObjectAdded += this.m_Plot_ObjectAdded;
			this.Limits.ObjectRemoved += this.m_Plot_ObjectRemoved;
			this.Limits.ObjectRenamed += this.m_Plot_ObjectRenamed;
			base.Annotations.ObjectAdded += this.m_Plot_ObjectAdded;
			base.Annotations.ObjectRemoved += this.m_Plot_ObjectRemoved;
			base.Annotations.ObjectRenamed += this.m_Plot_ObjectRenamed;
			this.DataCursors.ObjectAdded += this.m_Plot_ObjectAdded;
			this.DataCursors.ObjectRemoved += this.m_Plot_ObjectRemoved;
			this.DataCursors.ObjectRenamed += this.m_Plot_ObjectRenamed;
		}

		protected override void SetComponentDefaults()
		{
			this.DataViews.Reset();
			this.XAxes.Reset();
			this.YAxes.Reset();
			base.Labels.Reset();
			base.Legends.Reset();
			base.Tables.Reset();
			this.Limits.Reset();
			base.Annotations.Reset();
			this.DataCursors.Reset();
			this.Channels.Reset();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.LogFile.FileName = "";
			this.LogFile.BufferSize = 10;
			this.LogFile.Append = false;
			this.LogFile.AppendFileMustExist = false;
			this.LogFile.AllowFileOverwrite = true;
		}

		protected override Size GetDefaultSize()
		{
			return new Size(500, 250);
		}

		protected override void PropertyChangedHook(object sender, string propertyName)
		{
			base.PropertyChangedHook(sender, propertyName);
			if (sender is PlotAxisTracking && propertyName == "Enabled")
			{
				this.ToolBarAdapter.ForceChange();
			}
		}

		public override void LoadingBegin()
		{
			base.LoadingBegin();
			this.Channels.Clear();
			this.DataViews.Clear();
			this.XAxes.Clear();
			this.YAxes.Clear();
			base.Labels.Clear();
			base.Legends.Clear();
			this.Limits.Clear();
			base.Tables.Clear();
			base.Annotations.Clear();
			this.DataCursors.Clear();
		}

		private bool ShouldSerializeChannels()
		{
			return this.Channels.Count != 0;
		}

		private bool ShouldSerializeDataViews()
		{
			return this.DataViews.Count != 0;
		}

		private bool ShouldSerializeXAxes()
		{
			return this.XAxes.Count != 0;
		}

		private bool ShouldSerializeYAxes()
		{
			return this.YAxes.Count != 0;
		}

		private bool ShouldSerializeLimits()
		{
			return this.Limits.Count != 0;
		}

		private bool ShouldSerializeDataCursors()
		{
			return this.DataCursors.Count != 0;
		}

		private void m_Plot_ObjectAdded(object sender, ObjectEventArgs e)
		{
			if (e.Object is IUIInput)
			{
				base.m_UICollection.Add(e.Object as IUIInput);
			}
			((IPlotObjectCollectionBase)this.Channels).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)this.DataViews).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)this.XAxes).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)this.YAxes).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Labels).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)this.Limits).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Annotations).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)this.DataCursors).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Legends).NotifyAllObjectAdded(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Tables).NotifyAllObjectAdded(e.Object as PlotObject);
			this.OnPlotObjectAdded(e);
		}

		private void m_Plot_ObjectRemoved(object sender, ObjectEventArgs e)
		{
			if (e.Object is IUIInput)
			{
				base.m_UICollection.Remove(e.Object as IUIInput);
			}
			((IPlotObjectCollectionBase)this.Channels).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)this.DataViews).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)this.XAxes).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)this.YAxes).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Labels).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)this.Limits).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Annotations).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)this.DataCursors).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Legends).NotifyAllObjectRemoved(e.Object as PlotObject);
			((IPlotObjectCollectionBase)base.Tables).NotifyAllObjectRemoved(e.Object as PlotObject);
			this.OnPlotObjectRemoved(e);
		}

		private void m_Plot_ObjectRenamed(object sender, PlotObjectRenamedEventArgs e)
		{
			((IPlotObjectCollectionBase)this.Channels).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)this.DataViews).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)this.XAxes).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)this.YAxes).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)base.Labels).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)this.Limits).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)base.Annotations).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)this.DataCursors).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)base.Legends).NotifyAllObjectRenamed(e.Object, e.OldName);
			((IPlotObjectCollectionBase)base.Tables).NotifyAllObjectRenamed(e.Object, e.OldName);
			this.OnPlotObjectRenamed(e);
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e)
		{
			base.m_UICollection.MouseLeft(e);
		}

		protected override void InternalOnMouseRight(MouseEventArgs e)
		{
			base.m_UICollection.MouseRight(e);
		}

		protected override void InternalOnMouseMove(MouseEventArgs e)
		{
			base.m_UICollection.MouseMove(e);
		}

		protected override void InternalOnMouseUp(MouseEventArgs e)
		{
			base.m_UICollection.MouseUp(e);
		}

		protected override void InternalOnDoubleClick(MouseEventArgs e)
		{
			base.m_UICollection.DoubleClick(e);
		}

		protected override void InternalOnMouseWheel(MouseEventArgs e)
		{
			base.m_UICollection.MouseWheel(e);
		}

		protected override void InternalOnKeyDown(KeyEventArgs e)
		{
			base.m_UICollection.KeyDown(e);
		}

		protected override void InternalOnKeyUp(KeyEventArgs e)
		{
			base.m_UICollection.KeyUp(e);
		}

		protected override void InternalOnLostFocus(EventArgs e)
		{
			base.m_UICollection.LostFocus(e);
		}

		protected override void InternalOnGotFocus(EventArgs e)
		{
			base.m_UICollection.GotFocus(e);
		}

		protected override bool IsInputKey(Keys keyData)
		{
			switch (keyData)
			{
			default:
				return base.IsInputKey(keyData);
			case Keys.Left:
				return true;
			case Keys.Up:
				return true;
			case Keys.Right:
				return true;
			case Keys.Down:
				return true;
			}
		}

		public void AddNullDataSet(double x)
		{
			for (int i = 0; i < this.Channels.Count; i++)
			{
				this.Channels[i].AddNull(x);
			}
			if (this.LogFile.Active)
			{
				((IPlotLogFileAdapter)this.LogFile).IncrementBufferCount();
			}
		}

		public void AddDataArray(double x, Array yArray)
		{
			if (yArray.Rank != 1)
			{
				throw new Exception("Array must be one-dimensional.");
			}
			Type elementType = yArray.GetType().GetElementType();
			int lowerBound = yArray.GetLowerBound(0);
			int upperBound = yArray.GetUpperBound(0);
			int num = upperBound - lowerBound + 1;
			if (num > this.Channels.Count)
			{
				num = this.Channels.Count;
			}
			if (elementType == typeof(double))
			{
				for (int i = 0; i < num; i++)
				{
					this.Channels[i].AddXY(x, (double)yArray.GetValue(i + lowerBound));
				}
				goto IL_0128;
			}
			if (elementType == typeof(float))
			{
				for (int j = 0; j < num; j++)
				{
					this.Channels[j].AddXY(x, (double)(float)yArray.GetValue(j + lowerBound));
				}
				goto IL_0128;
			}
			if (elementType == typeof(int))
			{
				for (int k = 0; k < num; k++)
				{
					this.Channels[k].AddXY(x, (double)(int)yArray.GetValue(k + lowerBound));
				}
				goto IL_0128;
			}
			throw new Exception("Data type must be of type double, float, or int.");
			IL_0128:
			if (this.LogFile.Active)
			{
				((IPlotLogFileAdapter)this.LogFile).IncrementBufferCount();
			}
		}

		public void AddDataArray(double startX, double interval, Array yArray)
		{
			if (yArray.Rank != 2)
			{
				throw new Exception("Array must be two-dimensional.");
			}
			int lowerBound = yArray.GetLowerBound(0);
			int upperBound = yArray.GetUpperBound(0);
			int num = upperBound - lowerBound + 1;
			if (num > this.Channels.Count)
			{
				num = this.Channels.Count;
			}
			Type elementType = yArray.GetType().GetElementType();
			Array array;
			if (elementType == typeof(double))
			{
				array = Array.CreateInstance(typeof(double), num);
				goto IL_00c4;
			}
			if (elementType == typeof(float))
			{
				array = Array.CreateInstance(typeof(float), num);
				goto IL_00c4;
			}
			if (elementType == typeof(int))
			{
				array = Array.CreateInstance(typeof(int), num);
				goto IL_00c4;
			}
			throw new Exception("Array data type must be of type double, float, or int.");
			IL_00c4:
			int lowerBound2 = yArray.GetLowerBound(1);
			int upperBound2 = yArray.GetUpperBound(1);
			for (int i = lowerBound2; i <= upperBound2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					array.SetValue(yArray.GetValue(j + lowerBound, i), j);
				}
				this.AddDataArray(startX + interval * (double)i, array);
			}
		}

		public void LoadDataFromStream(Stream stream)
		{
			this.ClearAllData();
			int num = 0;
			bool flag = false;
			char c = base.FileDeliminatorCharacter[0];
			StreamReader streamReader = new StreamReader(stream);
			try
			{
				while (streamReader.Peek() != -1)
				{
					num++;
					string text = streamReader.ReadLine();
					if (num == 1)
					{
						string[] array = text.Split(c);
						string text2 = array[0];
						flag = (text2.ToUpper().Trim() == "(X)" && true);
						if (!flag && double.TryParse(text2, NumberStyles.Any, (IFormatProvider)null, out double _))
						{
							goto IL_0081;
						}
						continue;
					}
					goto IL_0081;
					IL_0081:
					if (flag)
					{
						this.ReadLogDataLineFromStream(streamReader, text);
					}
					else
					{
						this.ReadXYDataLineFromStream(streamReader, text);
					}
				}
			}
			finally
			{
				streamReader.Close();
			}
		}

		public void LoadDataFromFile(string filename)
		{
			FileStream fileStream = File.OpenRead(filename);
			try
			{
				this.LoadDataFromStream(fileStream);
			}
			finally
			{
				fileStream.Close();
			}
		}

		protected virtual void ReadXYDataLineFromStream(StreamReader streamReader, string rowString)
		{
			string[] array = rowString.Split(base.FileDeliminatorCharacter[0]);
			if (array.Length % 2 != 0)
			{
				throw new Exception("Invalid File Format!");
			}
			for (int i = 0; i < array.Length; i += 2)
			{
				int num = i / 2;
				if (num > this.Channels.Count - 1)
				{
					break;
				}
				string text = array[i];
				string text2 = array[i + 1];
				if (!(text == string.Empty) || !(text2 == string.Empty))
				{
					double num2;
					double x = (!double.TryParse(text, NumberStyles.Any, (IFormatProvider)null, out num2)) ? Convert.ToDateTime(text).ToOADate() : num2;
					if (text2.ToUpper().Trim() == "NULL")
					{
						this.Channels[num].AddNull(x);
					}
					else if (text2.ToUpper().Trim() == "EMPTY")
					{
						this.Channels[num].AddEmpty(x);
					}
					else
					{
						this.Channels[num].AddXY(x, Convert.ToDouble(text2));
					}
				}
			}
		}

		protected virtual void ReadLogDataLineFromStream(StreamReader streamReader, string rowString)
		{
			string[] array = rowString.Split(base.FileDeliminatorCharacter[0]);
			string text = array[0];
			double num;
			double x = (!double.TryParse(text, NumberStyles.Any, (IFormatProvider)null, out num)) ? Convert.ToDateTime(text).ToOADate() : num;
			for (int i = 1; i < array.Length; i++)
			{
				int num2 = i - 1;
				if (num2 > this.Channels.Count - 1)
				{
					break;
				}
				string text2 = array[i];
				if (text2.ToUpper().Trim() == "NULL")
				{
					this.Channels[num2].AddNull(x);
				}
				else if (text2.ToUpper().Trim() == "EMPTY")
				{
					this.Channels[num2].AddEmpty(x);
				}
				else
				{
					this.Channels[num2].AddXY(x, Convert.ToDouble(text2));
				}
			}
		}

		public void SaveDataToStream(Stream value, out StreamWriter streamWriter)
		{
			int count = this.Channels.Count;
			int num = 0;
			string fileDeliminatorCharacter = base.FileDeliminatorCharacter;
			streamWriter = new StreamWriter(value);
			foreach (PlotChannelBase channel in this.Channels)
			{
				if (channel.Count > num)
				{
					num = channel.Count;
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < count; i++)
			{
				string displayDescription = this.Channels[i].DisplayDescription;
				stringBuilder.Append(displayDescription);
				stringBuilder.Append("(X)");
				stringBuilder.Append(fileDeliminatorCharacter);
				stringBuilder.Append(displayDescription);
				stringBuilder.Append("(Y)");
				if (i != count - 1)
				{
					stringBuilder.Append(fileDeliminatorCharacter);
				}
			}
			streamWriter.WriteLine(stringBuilder.ToString());
			for (int j = 0; j < num; j++)
			{
				stringBuilder.Length = 0;
				for (int k = 0; k < count; k++)
				{
					string value2;
					string value3;
					if (j > this.Channels[k].Count - 1)
					{
						value2 = "";
						value3 = "";
					}
					else if (this.Channels[k].GetNull(j))
					{
						value2 = this.Channels[k].GetXValueTextSpecial(j);
						value3 = "Null";
					}
					else if (this.Channels[k].GetEmpty(j))
					{
						value2 = this.Channels[k].GetXValueTextSpecial(j);
						value3 = "Empty";
					}
					else
					{
						value2 = this.Channels[k].GetXValueTextSpecial(j);
						value3 = this.Channels[k].GetY(j).ToString();
					}
					if (k != 0)
					{
						stringBuilder.Append(fileDeliminatorCharacter);
					}
					stringBuilder.Append(value2);
					stringBuilder.Append(fileDeliminatorCharacter);
					stringBuilder.Append(value3);
				}
				streamWriter.WriteLine(stringBuilder.ToString());
			}
		}

		public void SaveDataToFile(string filename)
		{
			FileStream fileStream = File.Create(filename);
			this.SaveDataToStream((Stream)fileStream, out StreamWriter streamWriter);
			streamWriter.Close();
			fileStream.Close();
		}

		public void ClearAllData()
		{
			foreach (PlotChannelBase channel in this.Channels)
			{
				channel.Clear();
			}
			foreach (PlotAxis xAxis in this.XAxes)
			{
				xAxis.Tracking.AlignFirstReset();
			}
			foreach (PlotAxis yAxis in this.YAxes)
			{
				yAxis.Tracking.AlignFirstReset();
			}
		}

		public void ShowLayoutEditor(bool modal)
		{
			UITypeEditorGeneric uITypeEditorGeneric = (UITypeEditorGeneric)TypeDescriptor.GetEditor(this, typeof(UITypeEditor));
			if (uITypeEditorGeneric != null)
			{
				uITypeEditorGeneric.CreateMainPlugIn += this.CreateLayoutPlugIn;
				uITypeEditorGeneric.EditValue(this, false, modal);
				uITypeEditorGeneric.CreateMainPlugIn -= this.CreateLayoutPlugIn;
			}
		}

		private void CreateLayoutPlugIn(object sender, UITypeEditorEventArgs e)
		{
			e.MainPlugIn = new PlotLayoutViewerEditorPlugIn();
			e.MainPlugInTitle = "Plot";
			e.MainPlugInTabName = "Layout";
		}

		protected override void DoPaint(PaintArgs p)
		{
			base.m_ObjectList.Clear();
			foreach (PlotObject dataView in this.DataViews)
			{
				base.m_ObjectList.Add(dataView);
			}
			foreach (PlotObject label in base.Labels)
			{
				base.m_ObjectList.Add(label);
			}
			foreach (PlotObject legend in base.Legends)
			{
				base.m_ObjectList.Add(legend);
			}
			foreach (PlotObject table in base.Tables)
			{
				base.m_ObjectList.Add(table);
			}
			foreach (PlotObject xAxis in this.XAxes)
			{
				base.m_ObjectList.Add(xAxis);
			}
			foreach (PlotObject yAxis in this.YAxes)
			{
				base.m_ObjectList.Add(yAxis);
			}
			foreach (PlotObject annotation in base.Annotations)
			{
				base.m_ObjectList.Add(annotation);
			}
			foreach (PlotObject dataCursor in this.DataCursors)
			{
				base.m_ObjectList.Add(dataCursor);
			}
			foreach (PlotObject limit in this.Limits)
			{
				base.m_ObjectList.Add(limit);
			}
			foreach (PlotChannelBase channel in this.Channels)
			{
				channel.LegendRectangle = Rectangle.Empty;
				base.m_ObjectList.Add(channel);
			}
			base.m_ObjectList.Sort(base.m_SorterLayer);
			this.m_LayoutManager.Execute(p, false, p.DrawRectangle, p.DrawRectangle);
			GraphicsState gstate = p.Graphics.Save();
			p.Graphics.ResetTransform();
			if (base.Background.Visible)
			{
				p.Graphics.FillRectangle(base.I_Background.GetBrush(p, base.ClientRectangle), base.ClientRectangle);
			}
			p.Graphics.Restore(gstate);
			foreach (IPlotDraw @object in base.m_ObjectList)
			{
				@object.DrawSetup(p);
			}
			foreach (IPlotDraw object2 in base.m_ObjectList)
			{
				object2.UpdateCanDraw(p);
				object2.UpdateBoundsClip(p);
			}
			foreach (IPlotDraw object3 in base.m_ObjectList)
			{
				object3.DrawCalculations(p);
			}
			foreach (IPlotDraw object4 in base.m_ObjectList)
			{
				p.Graphics.ResetClip();
				object4.DrawBackgroundLayer1(p);
			}
			foreach (IPlotDraw object5 in base.m_ObjectList)
			{
				p.Graphics.ResetClip();
				object5.DrawBackgroundLayer2(p);
			}
			foreach (IPlotDraw object6 in base.m_ObjectList)
			{
				p.Graphics.ResetClip();
				object6.Draw(p);
			}
			foreach (IPlotDraw object7 in base.m_ObjectList)
			{
				p.Graphics.ResetClip();
				object7.DrawForegroundLayer1(p);
			}
			foreach (IPlotDraw object8 in base.m_ObjectList)
			{
				p.Graphics.ResetClip();
				object8.DrawForegroundLayer2(p);
			}
			foreach (IPlotDraw object9 in base.m_ObjectList)
			{
				p.Graphics.ResetClip();
				object9.DrawFocusRectangles(p);
			}
		}
	}
}
