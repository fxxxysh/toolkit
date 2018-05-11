using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Base Class for all Plot Channels.")]
	public abstract class PlotChannelBase : PlotXYAxisReferenceBase, IOPCDataDoubleReceiver, IPlotChannelBase
	{
		private bool m_VisibleInLegend;

		private string m_LegendName;

		private bool m_SendXAxisTrackingData;

		private bool m_SendYAxisTrackingData;

		protected string m_DeliminatorChar;

		private Rectangle m_LegendRectangle;

		protected PlotChannelDataCollection m_Data;

		protected PlotChannelDataCollection m_DataOriginal;

		private bool m_DataPointInitializing;

		private bool m_DesignTimeDataLoaded;

		private double m_DataCursorX;

		private double m_DataCursorY;

		private PlotLegendBase m_CachedLegend;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool VisibleInLegend
		{
			get
			{
				return this.m_VisibleInLegend;
			}
			set
			{
				base.PropertyUpdateDefault("VisibleInLegend", value);
				if (this.VisibleInLegend != value)
				{
					this.m_VisibleInLegend = value;
					base.DoPropertyChange(this, "VisibleInLegend");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool SendXAxisTrackingData
		{
			get
			{
				return this.m_SendXAxisTrackingData;
			}
			set
			{
				base.PropertyUpdateDefault("SendXAxisTrackingData", value);
				if (this.SendXAxisTrackingData != value)
				{
					this.m_SendXAxisTrackingData = value;
					base.DoPropertyChange(this, "SendXAxisTrackingData");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool SendYAxisTrackingData
		{
			get
			{
				return this.m_SendYAxisTrackingData;
			}
			set
			{
				base.PropertyUpdateDefault("SendYAxisTrackingData", value);
				if (this.SendYAxisTrackingData != value)
				{
					this.m_SendYAxisTrackingData = value;
					base.DoPropertyChange(this, "SendYAxisTrackingData");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int RingBufferCount
		{
			get
			{
				return this.m_Data.RingBufferCount;
			}
			set
			{
				base.PropertyUpdateDefault("RingBufferCount", value);
				if (this.RingBufferCount != value)
				{
					this.m_Data.RingBufferCount = value;
					base.DoPropertyChange(this, "RingBufferCount");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string LegendName
		{
			get
			{
				if (this.m_LegendName == null)
				{
					return Const.EmptyString;
				}
				return this.m_LegendName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("LegendName", value);
				if (this.LegendName != value)
				{
					this.m_LegendName = value;
					this.m_CachedLegend = null;
					this.m_CachedLegend = this.Legend;
					base.DoPropertyChange(this, "LegendName");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double OPCLink
		{
			get
			{
				return 0.0;
			}
			set
			{
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PlotLegendBase Legend
		{
			get
			{
				if (this.m_CachedLegend != null)
				{
					return this.m_CachedLegend;
				}
				if (base.Plot == null)
				{
					return null;
				}
				this.m_CachedLegend = base.Plot.Legends[this.LegendName];
				return this.m_CachedLegend;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Rectangle LegendRectangle
		{
			get
			{
				return this.m_LegendRectangle;
			}
			set
			{
				this.m_LegendRectangle = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public new Color Color
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.Color = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double DataCursorX
		{
			get
			{
				return this.m_DataCursorX;
			}
			set
			{
				this.m_DataCursorX = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double DataCursorY
		{
			get
			{
				return this.m_DataCursorY;
			}
			set
			{
				this.m_DataCursorY = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		public PlotChannelDataCollection DataCollection
		{
			get
			{
				return this.m_Data;
			}
		}

		protected override bool HitVisibleInternal
		{
			get
			{
				if (!this.Visible)
				{
					return this.VisibleInLegend;
				}
				return true;
			}
		}

		public virtual double YMinScale => this.m_Data.YMin;

		public virtual double YMaxScale => this.m_Data.YMax;

		public double XMin => this.m_Data.XMin;

		public double XMax => this.m_Data.XMax;

		public double XMean => this.m_Data.XMean;

		public double XStandardDeviation => this.m_Data.XStandardDeviation;

		public double YMin => this.m_Data.YMin;

		public double YMax => this.m_Data.YMax;

		public double YMean => this.m_Data.YMean;

		public double YStandardDeviation => this.m_Data.YStandardDeviation;

		public virtual int IndexDrawStart
		{
			get
			{
				if (this.m_Data.Count == 0)
				{
					return -1;
				}
				return 0;
			}
		}

		public virtual int IndexDrawStop
		{
			get
			{
				if (this.m_Data.Count == 0)
				{
					return -1;
				}
				return this.m_Data.Count - 1;
			}
		}

		public virtual int Count => this.m_Data.Count;

		public int IndexLast
		{
			get
			{
				if (this.m_Data.Count == 0)
				{
					return -1;
				}
				return this.m_Data.Count - 1;
			}
		}

		public int IndexFirst
		{
			get
			{
				if (this.m_Data.Count == 0)
				{
					return -1;
				}
				return 0;
			}
		}

		public bool Empty
		{
			get
			{
				if (this.m_Data.Count == 0)
				{
					return true;
				}
				return false;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public virtual int Capacity
		{
			get
			{
				return this.m_Data.Capacity;
			}
			set
			{
				base.PropertyUpdateDefault("Capacity", value);
				this.m_Data.Capacity = value;
			}
		}

		public double XFirst
		{
			get
			{
				if (this.Empty)
				{
					return 0.0;
				}
				return this.GetX(0);
			}
		}

		public double XLast
		{
			get
			{
				if (this.Empty)
				{
					return 0.0;
				}
				return this.GetX(this.Count - 1);
			}
		}

		public double YFirst
		{
			get
			{
				if (this.Empty)
				{
					return 0.0;
				}
				return this.GetY(0);
			}
		}

		public double YLast
		{
			get
			{
				if (this.Empty)
				{
					return 0.0;
				}
				return this.GetY(this.Count - 1);
			}
		}

		private Color SolidColor => this.Color;

		private Color HatchForeColor => this.Color;

		private Color HatchBackColor
		{
			get
			{
				if (this.ControlBase != null)
				{
					return this.ControlBase.BackColor;
				}
				return Color.Empty;
			}
		}

		protected bool DataPointInitializing
		{
			get
			{
				return this.m_DataPointInitializing;
			}
			set
			{
				this.m_DataPointInitializing = value;
			}
		}

		void IPlotChannelBase.DrawLegendMarker(PaintArgs p, Rectangle r)
		{
			this.DrawLegendMarker(p, r);
		}

		PlotDataPointBase IPlotChannelBase.CreateDataPoint()
		{
			return this.CreateDataPoint();
		}

		void IOPCDataDoubleReceiver.NewOPCData(double data, DateTime timeStamp)
		{
			this.NewOPCData(data, timeStamp);
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Data = new PlotChannelDataCollection(this);
			this.m_DataOriginal = this.m_Data;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Color = Color.Empty;
			this.VisibleInLegend = true;
			this.Capacity = 128;
			this.SendXAxisTrackingData = true;
			this.SendYAxisTrackingData = true;
			this.RingBufferCount = 0;
			this.LegendName = "Legend 1";
			this.m_Data.ClearMinMeanMax();
		}

		[Browsable(false)]
		public virtual void DoDataChange()
		{
			if (!this.DataPointInitializing && base.Plot != null)
			{
				base.Plot.CodeInvalidate(this);
			}
		}

		private bool ShouldSerializeVisibleInLegend()
		{
			return base.PropertyShouldSerialize("VisibleInLegend");
		}

		private void ResetVisibleInLegend()
		{
			base.PropertyReset("VisibleInLegend");
		}

		private bool ShouldSerializeSendXAxisTrackingData()
		{
			return base.PropertyShouldSerialize("SendXAxisTrackingData");
		}

		private void ResetSendXAxisTrackingData()
		{
			base.PropertyReset("SendXAxisTrackingData");
		}

		private bool ShouldSerializeSendYAxisTrackingData()
		{
			return base.PropertyShouldSerialize("SendYAxisTrackingData");
		}

		private void ResetSendYAxisTrackingData()
		{
			base.PropertyReset("SendYAxisTrackingData");
		}

		private bool ShouldSerializeRingBufferCount()
		{
			return base.PropertyShouldSerialize("RingBufferCount");
		}

		private void ResetRingBufferCount()
		{
			base.PropertyReset("RingBufferCount");
		}

		private bool ShouldSerializeLegendName()
		{
			return base.PropertyShouldSerialize("LegendName");
		}

		private void ResetLegendName()
		{
			base.PropertyReset("LegendName");
		}

		public virtual void NewOPCData(double data, DateTime timeStamp)
		{
			this.AddXY(DateTime.Now.ToOADate(), data);
		}

		public override void ObjectRenamed(PlotObject value, string oldName)
		{
			base.ObjectRenamed(value, oldName);
			if (value is PlotLegendBase && oldName == this.m_LegendName)
			{
				this.m_LegendName = value.Name;
			}
		}

		public override void ObjectRemoved(PlotObject value)
		{
			base.ObjectRemoved(value);
			if (value == this.m_CachedLegend)
			{
				this.m_CachedLegend = null;
			}
		}

		public override void ObjectAdded(PlotObject value)
		{
			base.ObjectAdded(value);
			if (value is PlotLegendBase && value.Name == this.m_LegendName)
			{
				this.m_CachedLegend = (value as PlotLegendBase);
			}
		}

		public double GetNormalizedWidth(PlotXAxis xAxis, double width, MagnitudeStyle widthStyle)
		{
			switch (widthStyle)
			{
			case MagnitudeStyle.Value:
				return width;
			case MagnitudeStyle.Pixel:
				return xAxis.ScaleDisplay.PixelSpanToValue((int)width);
			default:
				return xAxis.ScaleDisplay.PercentSpanToValue(width);
			}
		}

		public double GetNormalizedHeight(PlotYAxis yAxis, double height, MagnitudeStyle heightStyle)
		{
			switch (heightStyle)
			{
			case MagnitudeStyle.Value:
				return height;
			case MagnitudeStyle.Pixel:
				return yAxis.ScaleDisplay.PixelSpanToValue((int)height);
			default:
				return yAxis.ScaleDisplay.PercentSpanToValue(height);
			}
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		[Description("")]
		public bool GetInViewMinMaxX(out double minX, out double maxX)
		{
			minX = double.PositiveInfinity;
			maxX = double.NegativeInfinity;
			if (this.IndexDrawStop == -1)
			{
				return false;
			}
			if (this.IndexDrawStart == -1)
			{
				return false;
			}
			for (int i = this.IndexDrawStart; i <= this.IndexDrawStop; i++)
			{
				minX = Math.Min(minX, this.GetX(i));
				maxX = Math.Max(maxX, this.GetX(i));
			}
			return true;
		}

		[Description("")]
		public bool GetInViewMinMaxY(out double minY, out double maxY)
		{
			minY = double.PositiveInfinity;
			maxY = double.NegativeInfinity;
			if (this.IndexDrawStop == -1)
			{
				return false;
			}
			if (this.IndexDrawStart == -1)
			{
				return false;
			}
			if (this.Count == 0)
			{
				return false;
			}
			for (int i = this.IndexDrawStart; i <= this.IndexDrawStop; i++)
			{
				if (!this.GetEmpty(i) && !this.GetNull(i))
				{
					minY = Math.Min(minY, this.GetY(i));
					maxY = Math.Max(maxY, this.GetY(i));
				}
			}
			return true;
		}

		public void ShareDataCollection(PlotChannelDataCollection value)
		{
			if (value == null)
			{
				throw new Exception("The shared Data Collection must not be null");
			}
			this.m_Data = value;
		}

		public void UnShareDataCollection()
		{
			this.m_Data = this.m_DataOriginal;
		}

		private bool ShouldSerializeCapacity()
		{
			return base.PropertyShouldSerialize("Capacity");
		}

		private void ResetCapacity()
		{
			base.PropertyReset("Capacity");
		}

		public virtual void Clear()
		{
			this.m_Data.Clear();
			this.m_Data.ClearMinMeanMax();
			this.DoDataChange();
		}

		protected abstract PlotDataPointBase CreateDataPoint();

		public abstract int AddXY(double x, double y);

		public abstract int AddNull(double x);

		public abstract int AddEmpty(double x);

		public abstract double GetX(int index);

		public abstract double GetY(int index);

		public abstract bool GetNull(int index);

		public abstract bool GetEmpty(int index);

		public abstract void SetX(int index, double value);

		public abstract void SetY(int index, double value);

		public abstract void SetNull(int index, bool value);

		public abstract void SetEmpty(int index, bool value);

		public abstract int CalculateXValueNearestIndex(double value);

		public int AddXY(DateTime x, double y)
		{
			return this.AddXY(Math2.DateTimeToDouble(x), y);
		}

		public int AddNull(DateTime x)
		{
			return this.AddNull(Math2.DateTimeToDouble(x));
		}

		public int AddEmpty(DateTime x)
		{
			return this.AddEmpty(Math2.DateTimeToDouble(x));
		}

		public void RemoveAt(int index)
		{
			this.m_Data.RemoveAt(index);
		}

		public void RemoveRange(int index, int count)
		{
			this.m_Data.RemoveRange(index, count);
		}

		public virtual double GetYValueAxisValue(double yValue)
		{
			return yValue;
		}

		public virtual string GetXValueText(double value)
		{
			if (base.XAxis != null)
			{
				return base.XAxis.TextFormatting.GetText(value);
			}
			return "X-Axis Null";
		}

		public virtual string GetYValueText(double value)
		{
			if (base.YAxis != null)
			{
				return base.YAxis.TextFormatting.GetText(value);
			}
			return "Y-Axis Null";
		}

		public string GetXValueTextSpecial(int index)
		{
			if (base.Plot == null)
			{
				return this.GetX(index).ToString();
			}
			if (base.Plot.XValueTextDateTimeFormat == PlotXValueTextDateTimeFormat.TimeStamp)
			{
				if (base.XAxis != null)
				{
					if (base.XAxis.TextFormatting.Style != TextFormatDoubleStyle.DateTime && base.XAxis.TextFormatting.Style != TextFormatDoubleStyle.DateTimeUTC)
					{
						return this.GetX(index).ToString();
					}
					return DateTime.FromOADate(this.GetX(index)).ToString();
				}
				return this.GetX(index).ToString();
			}
			return this.GetX(index).ToString();
		}

		[Description("")]
		public void UpdateCalculatedStatistics()
		{
			this.m_Data.ClearMinMeanMax();
			for (int i = 0; i < this.Count; i++)
			{
				this.m_Data.UpdateMinMaxMean(this.GetX(i), this.GetY(i), this.GetEmpty(i), this.GetNull(i));
			}
			this.m_Data.UpdateStandardDeviations();
		}

		public abstract PlotChannelInterpolationResult GetYInterpolated(double xValue, out double yValue);

		public void AddDataArray(Array value)
		{
			if (value.Rank != 2)
			{
				throw new Exception("Array must be two-dimensional.");
			}
			if (value.GetUpperBound(0) != 1 && value.GetUpperBound(1) != 1)
			{
				throw new Exception("One of the Array dimension bounds must be 2 (X & Y columns).");
			}
			Type elementType = value.GetType().GetElementType();
			if (value.GetUpperBound(0) == 1)
			{
				int lowerBound = value.GetLowerBound(0);
				int upperBound = value.GetUpperBound(0);
				int lowerBound2 = value.GetLowerBound(1);
				int upperBound2 = value.GetUpperBound(1);
				if (elementType == typeof(double))
				{
					for (int i = lowerBound2; i <= upperBound2; i++)
					{
						this.AddXY((double)value.GetValue(lowerBound, i), (double)value.GetValue(upperBound, i));
					}
				}
				else if (elementType == typeof(float))
				{
					for (int j = lowerBound2; j <= upperBound2; j++)
					{
						this.AddXY((double)(float)value.GetValue(lowerBound, j), (double)(float)value.GetValue(upperBound, j));
					}
				}
				else if (elementType == typeof(int))
				{
					for (int k = lowerBound2; k <= upperBound2; k++)
					{
						this.AddXY((double)(int)value.GetValue(lowerBound, k), (double)(int)value.GetValue(upperBound, k));
					}
				}
			}
			else
			{
				int lowerBound = value.GetLowerBound(1);
				int upperBound = value.GetUpperBound(1);
				int lowerBound2 = value.GetLowerBound(0);
				int upperBound2 = value.GetUpperBound(0);
				if (elementType == typeof(double))
				{
					for (int l = lowerBound2; l <= upperBound2; l++)
					{
						this.AddXY((double)value.GetValue(l, lowerBound), (double)value.GetValue(l, upperBound));
					}
				}
				else if (elementType == typeof(float))
				{
					for (int m = lowerBound2; m <= upperBound2; m++)
					{
						this.AddXY((double)(float)value.GetValue(m, lowerBound), (double)(float)value.GetValue(m, upperBound));
					}
				}
				else if (elementType == typeof(int))
				{
					for (int n = lowerBound2; n <= upperBound2; n++)
					{
						this.AddXY((double)(int)value.GetValue(n, lowerBound), (double)(int)value.GetValue(n, upperBound));
					}
				}
			}
		}

		public void AddDataArray(double startX, double interval, Array yArray)
		{
			if (yArray.Rank != 1)
			{
				throw new Exception("Array must be one-dimensional.");
			}
			Type elementType = yArray.GetType().GetElementType();
			int lowerBound = yArray.GetLowerBound(0);
			int upperBound = yArray.GetUpperBound(0);
			if (elementType == typeof(double))
			{
				for (int i = lowerBound; i <= upperBound; i++)
				{
					this.AddXY(startX + (double)(i - lowerBound) * interval, (double)yArray.GetValue(i));
				}
				return;
			}
			if (elementType == typeof(float))
			{
				for (int j = lowerBound; j <= upperBound; j++)
				{
					this.AddXY(startX + (double)(j - lowerBound) * interval, (double)(float)yArray.GetValue(j));
				}
				return;
			}
			if (elementType == typeof(int))
			{
				for (int k = lowerBound; k <= upperBound; k++)
				{
					this.AddXY(startX + (double)(k - lowerBound) * interval, (double)(int)yArray.GetValue(k));
				}
				return;
			}
			throw new Exception("Array data type must be of type double, float, or int.");
		}

		public void AddDataArray(DateTime startX, double interval, Array yArray)
		{
			this.AddDataArray(Math2.DateTimeToDouble(startX), interval, yArray);
		}

		public void AddDataArray(DateTime startX, TimeSpan interval, Array yArray)
		{
			this.AddDataArray(Math2.DateTimeToDouble(startX), Math2.TimeSpanToDouble(interval), yArray);
		}

		public void AddDataArray(double interval, Array yArray)
		{
			if (this.Count == 0)
			{
				this.AddDataArray(0.0, interval, yArray);
			}
			else
			{
				this.AddDataArray(this.XLast + interval, interval, yArray);
			}
		}

		public void AddDataArray(Array xArray, Array yArray)
		{
			if (xArray.Rank != 1)
			{
				throw new Exception("X-Array must be one-dimension.");
			}
			if (yArray.Rank != 1)
			{
				throw new Exception("Y-Array must be one-dimension.");
			}
			Type elementType = xArray.GetType().GetElementType();
			Type elementType2 = yArray.GetType().GetElementType();
			if (elementType != elementType2)
			{
				throw new Exception("Array data types must match.");
			}
			int lowerBound = xArray.GetLowerBound(0);
			int upperBound = xArray.GetUpperBound(0);
			int lowerBound2 = yArray.GetLowerBound(0);
			int upperBound2 = yArray.GetUpperBound(0);
			if (lowerBound != lowerBound2)
			{
				throw new Exception("Array lower bounds must match.");
			}
			if (upperBound != upperBound2)
			{
				throw new Exception("Array upper bounds must match.");
			}
			if (elementType == typeof(double))
			{
				for (int i = lowerBound; i <= upperBound; i++)
				{
					this.AddXY((double)xArray.GetValue(i), (double)yArray.GetValue(i));
				}
				return;
			}
			if (elementType == typeof(float))
			{
				for (int j = lowerBound; j <= upperBound; j++)
				{
					this.AddXY((double)(float)xArray.GetValue(j), (double)(float)yArray.GetValue(j));
				}
				return;
			}
			if (elementType == typeof(int))
			{
				for (int k = lowerBound; k <= upperBound; k++)
				{
					this.AddXY((double)(int)xArray.GetValue(k), (double)(int)yArray.GetValue(k));
				}
				return;
			}
			throw new Exception("Array data type must be of type double, float, or int.");
		}

		public virtual void LoadDataFromStream(Stream stream)
		{
			if (base.Plot == null)
			{
				throw new Exception("Plot not assigned.");
			}
			this.m_DeliminatorChar = base.Plot.FileDeliminatorCharacter;
			this.Clear();
			StreamReader streamReader = new StreamReader(stream);
			try
			{
				while (streamReader.Peek() != -1)
				{
					string stringline = streamReader.ReadLine();
					this.ReadDataPointFromStreamReader(streamReader, stringline);
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

		public void SaveDataToFile(string filename)
		{
			FileStream fileStream = File.Create(filename);
			this.SaveDataToStream((Stream)fileStream, out StreamWriter streamWriter);
			streamWriter.Close();
			fileStream.Close();
		}

		public virtual void SaveDataToStream(Stream value, out StreamWriter streamWriter)
		{
			if (base.Plot == null)
			{
				throw new Exception("Plot not assigned.");
			}
			this.m_DeliminatorChar = base.Plot.FileDeliminatorCharacter;
			streamWriter = new StreamWriter(value);
			for (int i = 0; i < this.Count; i++)
			{
				if (!this.GetEmpty(i))
				{
					this.WriteDataPointToStreamWriter(streamWriter, i);
				}
			}
		}

		protected virtual void WriteDataPointToStreamWriter(StreamWriter streamWriter, int index)
		{
			if (this.GetNull(index))
			{
				streamWriter.WriteLine(this.GetXValueTextSpecial(index) + this.m_DeliminatorChar + "null");
			}
			else
			{
				streamWriter.WriteLine(this.GetXValueTextSpecial(index) + this.m_DeliminatorChar + this.GetY(index));
			}
		}

		protected virtual void ReadDataPointFromStreamReader(StreamReader streamReader, string stringline)
		{
			string[] array = stringline.Split(this.m_DeliminatorChar.ToCharArray());
			if (array.Length != 2)
			{
				throw new Exception("Invalid File Format");
			}
			double num;
			double x = (!double.TryParse(array[0], NumberStyles.Any, (IFormatProvider)null, out num)) ? Convert.ToDateTime(array[0]).ToOADate() : num;
			if (array[1].ToUpper().CompareTo("NULL") == 0)
			{
				this.AddNull(x);
			}
			else
			{
				this.AddXY(x, Convert.ToDouble(array[1]));
			}
		}

		public bool GetValid(int index)
		{
			if (!this.GetEmpty(index))
			{
				return !this.GetNull(index);
			}
			return false;
		}

		protected virtual void DrawLegendMarker(PaintArgs p, Rectangle r)
		{
			p.Graphics.FillRectangle(p.Graphics.Brush(this.Color), r);
		}

		protected abstract void LoadDesignTimeData(PlotXAxis xAxis, PlotYAxis yAxis, Random random, double yMin, double ySpan);

		public void LoadSampleData()
		{
			this.Clear();
			int num = ((IList)base.Collection).IndexOf((object)this);
			double num2 = base.YAxis.Span / (double)base.Collection.Count;
			double num3 = num2 * (double)num;
			Random random = new Random((int)DateTime.Now.Ticks);
			bool sendXAxisTrackingData = this.SendXAxisTrackingData;
			bool sendYAxisTrackingData = this.SendYAxisTrackingData;
			this.SendXAxisTrackingData = false;
			this.SendYAxisTrackingData = false;
			this.LoadDesignTimeData(base.XAxis, base.YAxis, random, num3 + num2 * 0.125, num2 * 0.75);
			this.SendXAxisTrackingData = sendXAxisTrackingData;
			this.SendYAxisTrackingData = sendYAxisTrackingData;
		}

		protected override bool InternalHitTest(MouseEventArgs e)
		{
			return this.LegendRectangle.Contains(e.X, e.Y);
		}

		protected override Cursor InternalGetMouseCursor(MouseEventArgs e)
		{
			return Cursors.Hand;
		}

		protected override void InternalOnMouseLeft(MouseEventArgs e, bool shouldFocus)
		{
			if (shouldFocus)
			{
				base.Focus();
			}
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (base.Designing && !this.m_DesignTimeDataLoaded && this.Count == 0 && base.Collection != null && base.XAxis != null && base.YAxis != null)
			{
				this.m_DesignTimeDataLoaded = true;
				this.Clear();
				int num = ((IList)base.Collection).IndexOf((object)this);
				double num2 = base.YAxis.Span / (double)base.Collection.Count;
				double num3 = num2 * (double)num;
				Random random = new Random(num);
				bool sendXAxisTrackingData = this.SendXAxisTrackingData;
				bool sendYAxisTrackingData = this.SendYAxisTrackingData;
				this.SendXAxisTrackingData = false;
				this.SendYAxisTrackingData = false;
				this.LoadDesignTimeData(base.XAxis, base.YAxis, random, num3 + num2 * 0.125, num2 * 0.75);
				this.SendXAxisTrackingData = sendXAxisTrackingData;
				this.SendYAxisTrackingData = sendYAxisTrackingData;
			}
			if (base.YAxis != null && base.YAxis.Bounds.Height < 1)
			{
				base.CanDraw = false;
			}
		}

		protected virtual void DrawMarkers(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis, PlotMarker markers)
		{
			if (markers.Visible)
			{
				Brush brush = ((IPlotBrush)markers.Fill.Brush).GetBrush(p, Rectangle.Empty);
				Pen pen = ((IPlotPen)markers.Fill.Pen).GetPen(p);
				for (int i = this.IndexDrawStart; i <= this.IndexDrawStop; i++)
				{
					if (!this.GetNull(i) && !this.GetEmpty(i))
					{
						int num = xAxis.ScaleDisplay.ValueToPixels(this.GetX(i));
						int num2 = yAxis.ScaleDisplay.ValueToPixels(this.GetY(i));
						if (base.XYSwapped)
						{
							((IPlotMarker)markers).Draw(p, num2, num, brush, pen);
						}
						else
						{
							((IPlotMarker)markers).Draw(p, num, num2, brush, pen);
						}
					}
				}
			}
		}
	}
}
