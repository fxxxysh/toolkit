using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace Iocomp.Classes
{
	[Description("Plot Channel Image")]
	public class PlotChannelImage : PlotChannelXYBase
	{
		private Bitmap m_Image;

		private bool m_ImageXAutoSetup;

		private bool m_ImageXAutoSetupComplete;

		private int m_ImageXSpanSamples;

		private double m_ImageXSpan;

		private double m_ImageXMin;

		private bool m_ImageYAutoSetup;

		private bool m_ImageYAutoSetupComplete;

		private int m_ImageYSpanSamples;

		private double m_ImageYSpan;

		private double m_ImageYMin;

		private PlotColorLookupGradient m_IntensityGradient;

		private bool m_FirstDrawComplete;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public PlotColorLookupGradient IntensityGradient
		{
			get
			{
				return this.m_IntensityGradient;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ImageXAutoSetup
		{
			get
			{
				return this.m_ImageXAutoSetup;
			}
			set
			{
				base.PropertyUpdateDefault("ImageXAutoSetup", value);
				if (this.ImageXAutoSetup != value)
				{
					this.m_ImageXAutoSetup = value;
					base.DoPropertyChange(this, "ImageXAutoSetup");
					if (!this.ImageXAutoSetup)
					{
						this.m_ImageXAutoSetupComplete = false;
					}
					if (!base.Designing && this.ImageXAutoSetup && !this.m_ImageXAutoSetupComplete && this.m_FirstDrawComplete && base.XAxis != null)
					{
						this.ImageXSamples = base.XAxis.ScaleDisplay.PixelsSpan;
						this.ImageXSpanSamples = base.XAxis.ScaleDisplay.PixelsSpan;
						this.ImageXMin = base.XAxis.Min;
						this.ImageXSpan = base.XAxis.Span;
						this.m_ImageXAutoSetupComplete = true;
					}
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int ImageXSamples
		{
			get
			{
				return this.m_Image.Width;
			}
			set
			{
				if (value < 1)
				{
					value = 1;
				}
				base.PropertyUpdateDefault("ImageXSamples", value);
				if (this.ImageXSamples != value)
				{
					Bitmap image = this.m_Image;
					this.m_Image = new Bitmap(value, this.ImageYSamples);
					if (image != null)
					{
						Graphics graphics = Graphics.FromImage(this.m_Image);
						Rectangle rectangle = (this.m_Image.Width <= image.Width) ? new Rectangle(0, 0, this.m_Image.Width, this.m_Image.Height) : new Rectangle(0, 0, image.Width, image.Height);
						graphics.DrawImage(image, rectangle, rectangle, GraphicsUnit.Pixel);
						graphics.Dispose();
						image.Dispose();
					}
					base.DoPropertyChange(this, "ImageXSamples");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int ImageXSpanSamples
		{
			get
			{
				return this.m_ImageXSpanSamples;
			}
			set
			{
				base.PropertyUpdateDefault("ImageXSpanSamples", value);
				if (this.ImageXSpanSamples != value)
				{
					this.m_ImageXSpanSamples = value;
					base.DoPropertyChange(this, "ImageXSpanSamples");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double ImageXSpan
		{
			get
			{
				return this.m_ImageXSpan;
			}
			set
			{
				base.PropertyUpdateDefault("ImageXSpan", value);
				if (this.ImageXSpan != value)
				{
					this.m_ImageXSpan = value;
					base.DoPropertyChange(this, "ImageXSpan");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double ImageXMin
		{
			get
			{
				return this.m_ImageXMin;
			}
			set
			{
				base.PropertyUpdateDefault("ImageXMin", value);
				if (this.ImageXMin != value)
				{
					this.m_ImageXMin = value;
					base.DoPropertyChange(this, "ImageXMin");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool ImageYAutoSetup
		{
			get
			{
				return this.m_ImageYAutoSetup;
			}
			set
			{
				base.PropertyUpdateDefault("ImageYAutoSetup", value);
				if (this.ImageYAutoSetup != value)
				{
					this.m_ImageYAutoSetup = value;
					base.DoPropertyChange(this, "ImageYAutoSetup");
					if (!this.ImageYAutoSetup)
					{
						this.m_ImageYAutoSetupComplete = false;
					}
					if (!base.Designing && this.ImageYAutoSetup && !this.m_ImageYAutoSetupComplete && this.m_FirstDrawComplete && base.YAxis != null)
					{
						this.ImageYSamples = base.YAxis.ScaleDisplay.PixelsSpan;
						this.ImageYSpanSamples = base.YAxis.ScaleDisplay.PixelsSpan;
						this.ImageYMin = base.YAxis.Min;
						this.ImageYSpan = base.YAxis.Span;
						this.m_ImageYAutoSetupComplete = true;
					}
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int ImageYSamples
		{
			get
			{
				return this.m_Image.Height;
			}
			set
			{
				if (value < 1)
				{
					value = 1;
				}
				base.PropertyUpdateDefault("ImageYSamples", value);
				if (this.ImageYSamples != value)
				{
					Bitmap image = this.m_Image;
					this.m_Image = new Bitmap(this.ImageXSamples, value);
					if (image != null)
					{
						Graphics graphics = Graphics.FromImage(this.m_Image);
						if (this.m_Image.Height > image.Height)
						{
							Rectangle rectangle = new Rectangle(0, 0, image.Width, image.Height);
							graphics.DrawImage(image, rectangle, rectangle, GraphicsUnit.Pixel);
						}
						else
						{
							Rectangle rectangle = new Rectangle(0, image.Height - this.m_Image.Height, this.m_Image.Width, this.m_Image.Height);
							Rectangle destRect = new Rectangle(0, 0, this.m_Image.Width, this.m_Image.Height);
							graphics.DrawImage(image, destRect, rectangle, GraphicsUnit.Pixel);
						}
						graphics.Dispose();
						image.Dispose();
					}
					base.DoPropertyChange(this, "ImageYSamples");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int ImageYSpanSamples
		{
			get
			{
				return this.m_ImageYSpanSamples;
			}
			set
			{
				base.PropertyUpdateDefault("ImageYSpanSamples", value);
				if (this.ImageYSpanSamples != value)
				{
					this.m_ImageYSpanSamples = value;
					base.DoPropertyChange(this, "ImageYSpanSamples");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double ImageYSpan
		{
			get
			{
				return this.m_ImageYSpan;
			}
			set
			{
				base.PropertyUpdateDefault("ImageYSpan", value);
				if (this.ImageYSpan != value)
				{
					this.m_ImageYSpan = value;
					base.DoPropertyChange(this, "ImageYSpan");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double ImageYMin
		{
			get
			{
				return this.m_ImageYMin;
			}
			set
			{
				base.PropertyUpdateDefault("ImageYMin", value);
				if (this.ImageYMin != value)
				{
					this.m_ImageYMin = value;
					base.DoPropertyChange(this, "ImageYMin");
				}
			}
		}

		private int ImagePixelLeft => 0;

		private int ImagePixelRight => this.m_Image.Width - 1;

		private int ImagePixelTop => 0;

		private int ImagePixelBottom => this.m_Image.Height - 1;

		private int ImagePixelWidth => this.m_Image.Width;

		private int ImagePixelHeight => this.m_Image.Height;

		public double ImageXMax => this.ImageXMin + (double)(this.ImageXSamples - 1) / (double)this.ImageXSpanSamples * this.ImageXSpan;

		public double ImageYMax => this.ImageYMin + (double)(this.ImageYSamples - 1) / (double)this.ImageYSpanSamples * this.ImageYSpan;

		protected override string GetPlugInTitle()
		{
			return "Channel Image";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotChannelImageEditorPlugIn";
		}

		public PlotChannelImage()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Image = new Bitmap(1, 1);
			this.m_IntensityGradient = new PlotColorLookupGradient();
			base.AddSubClass(this.IntensityGradient);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Image";
			this.ImageXSamples = 100;
			this.ImageYSamples = 256;
			this.ImageXAutoSetup = false;
			this.ImageXSpanSamples = 100;
			this.ImageXSpan = 100.0;
			this.ImageXMin = 0.0;
			this.ImageYAutoSetup = false;
			this.ImageYSpanSamples = 100;
			this.ImageYSpan = 100.0;
			this.ImageYMin = 0.0;
			base.SendXAxisTrackingData = true;
			base.SendYAxisTrackingData = true;
			this.IntensityGradient.Min = 0.0;
			this.IntensityGradient.Max = 256.0;
			this.IntensityGradient.StepsCount = 10;
		}

		private bool ShouldSerializeIntensityGradient()
		{
			return ((ISubClassBase)this.IntensityGradient).ShouldSerialize();
		}

		private void ResetIntensityGradient()
		{
			((ISubClassBase)this.IntensityGradient).ResetToDefault();
		}

		private bool ShouldSerializeImageXAutoSetup()
		{
			return base.PropertyShouldSerialize("ImageXAutoSetup");
		}

		private void ResetImageXAutoSetup()
		{
			base.PropertyReset("ImageXAutoSetup");
		}

		private bool ShouldSerializeImageXSamples()
		{
			return base.PropertyShouldSerialize("ImageXSamples");
		}

		private void ResetImageXSamples()
		{
			base.PropertyReset("ImageXSamples");
		}

		private bool ShouldSerializeImageXSpanSamples()
		{
			return base.PropertyShouldSerialize("ImageXSpanSamples");
		}

		private void ResetImageXSpanSamples()
		{
			base.PropertyReset("ImageXSpanSamples");
		}

		private bool ShouldSerializeImageXSpan()
		{
			return base.PropertyShouldSerialize("ImageXSpan");
		}

		private void ResetImageXSpan()
		{
			base.PropertyReset("ImageXSpan");
		}

		private bool ShouldSerializeImageXMin()
		{
			return base.PropertyShouldSerialize("ImageXMin");
		}

		private void ResetImageXMin()
		{
			base.PropertyReset("ImageXMin");
		}

		private bool ShouldSerializeImageYAutoSetup()
		{
			return base.PropertyShouldSerialize("ImageYAutoSetup");
		}

		private void ResetImageYAutoSetup()
		{
			base.PropertyReset("ImageYAutoSetup");
		}

		private bool ShouldSerializeImageYSamples()
		{
			return base.PropertyShouldSerialize("ImageYSamples");
		}

		private void ResetImageYSamples()
		{
			base.PropertyReset("ImageYSamples");
		}

		private bool ShouldSerializeImageYSpanSamples()
		{
			return base.PropertyShouldSerialize("ImageYSpanSamples");
		}

		private void ResetImageYSpanSamples()
		{
			base.PropertyReset("ImageYSpanSamples");
		}

		private bool ShouldSerializeImageYSpan()
		{
			return base.PropertyShouldSerialize("ImageYSpan");
		}

		private void ResetImageYSpan()
		{
			base.PropertyReset("ImageYSpan");
		}

		private bool ShouldSerializeImageYMin()
		{
			return base.PropertyShouldSerialize("ImageYMin");
		}

		private void ResetImageYMin()
		{
			base.PropertyReset("ImageYMin");
		}

		public Color GetPointColor(int x, int y)
		{
			if (x > this.ImageXSamples - 1)
			{
				throw new Exception("X index out of bounds.");
			}
			if (y > this.ImageYSamples - 1)
			{
				throw new Exception("Y index out of bounds.");
			}
			return this.m_Image.GetPixel(x, y);
		}

		public void SetPointColor(int x, int y, Color value)
		{
			if (x > this.ImageXSamples - 1)
			{
				throw new Exception("X index out of bounds.");
			}
			if (y > this.ImageYSamples - 1)
			{
				throw new Exception("Y index out of bounds.");
			}
			this.m_Image.SetPixel(x, y, value);
		}

		public int ValueToImageSampleX(double value)
		{
			if (this.ImageXSpan == 0.0)
			{
				return 0;
			}
			return (int)Math.Round((value - this.ImageXMin) / this.ImageXSpan * (double)this.ImageXSpanSamples);
		}

		public int ValueToImageSampleY(double value)
		{
			if (this.ImageYSpan == 0.0)
			{
				return 0;
			}
			return (int)Math.Round((value - this.ImageYMin) / this.ImageYSpan * (double)this.ImageYSpanSamples);
		}

		public double ImageSampleToValueX(int value)
		{
			return (double)value / (double)this.ImageXSpanSamples * this.ImageXSpan + this.ImageXMin;
		}

		public double ImageSampleToValueY(int value)
		{
			return (double)value / (double)this.ImageYSpanSamples * this.ImageYSpan + this.ImageYMin;
		}

		protected override PlotDataPointBase CreateDataPoint()
		{
			return null;
		}

		private int AddXY(double x, double y, bool nullValue, bool emptyValue, double intensity)
		{
			int num = this.ValueToImageSampleX(x);
			int num2 = this.ValueToImageSampleY(y);
			if (num > this.ImageXSamples - 1)
			{
				throw new Exception("X out of bounds.");
			}
			if (num2 > this.ImageYSamples - 1)
			{
				throw new Exception("Y out of bounds.");
			}
			Color color = (!nullValue) ? this.IntensityGradient.GetColor(intensity) : Color.Empty;
			this.m_Image.SetPixel(num, num2, color);
			base.m_Data.UpdateMinMaxMean(x, y, emptyValue, nullValue);
			if (base.SendXAxisTrackingData)
			{
				PlotXAxis xAxis = base.XAxis;
				xAxis?.Tracking.NewData(x);
			}
			if (!nullValue && !emptyValue && base.SendYAxisTrackingData)
			{
				PlotYAxis yAxis = base.YAxis;
				yAxis?.Tracking.NewData(y);
			}
			this.DoDataChange();
			return -1;
		}

		public int Add(double x, double y, double intensity)
		{
			return this.AddXY(x, y, false, false, intensity);
		}

		public int Add(int x, int y, double intensity)
		{
			return this.AddXY(this.ImageSampleToValueX(x), this.ImageSampleToValueY(y), false, false, intensity);
		}

		public void AddIntensityArray(double y, double startX, double span, Array intensityArray)
		{
			if (intensityArray.Rank != 1)
			{
				throw new Exception("Array must be one-dimensional.");
			}
			Type elementType = intensityArray.GetType().GetElementType();
			int lowerBound = intensityArray.GetLowerBound(0);
			int upperBound = intensityArray.GetUpperBound(0);
			int num = upperBound - lowerBound + 1;
			if (num < 1)
			{
				throw new Exception("Intensity Array must have one or more elements.");
			}
			if (num == 1)
			{
				if (elementType == typeof(double))
				{
					this.AddXY(startX, y, false, false, (double)intensityArray.GetValue(lowerBound));
					return;
				}
				if (elementType == typeof(float))
				{
					this.AddXY(startX, y, false, false, (double)(float)intensityArray.GetValue(lowerBound));
					return;
				}
				if (elementType == typeof(int))
				{
					this.AddXY(startX, y, false, false, (double)(int)intensityArray.GetValue(lowerBound));
					return;
				}
				throw new Exception("Array data type must be of type double, float, or int.");
			}
			if (elementType == typeof(double))
			{
				for (int i = lowerBound; i <= upperBound; i++)
				{
					this.AddXY(startX + (double)(i - lowerBound) * span / (double)(num - 1), y, false, false, (double)intensityArray.GetValue(i));
				}
				return;
			}
			if (elementType == typeof(float))
			{
				for (int j = lowerBound; j <= upperBound; j++)
				{
					this.AddXY(startX + (double)(j - lowerBound) * span / (double)(num - 1), y, false, false, (double)(float)intensityArray.GetValue(j));
				}
				return;
			}
			if (elementType == typeof(int))
			{
				for (int k = lowerBound; k <= upperBound; k++)
				{
					this.AddXY(startX + (double)(k - lowerBound) * span / (double)(num - 1), y, false, false, (double)(int)intensityArray.GetValue(k));
				}
				return;
			}
			throw new Exception("Array data type must be of type double, float, or int.");
		}

		public override int AddXY(double x, double y)
		{
			return this.AddXY(x, y, false, false, 0.0);
		}

		public override int AddEmpty(double x)
		{
			return -1;
		}

		public override int AddNull(double x)
		{
			return -1;
		}

		public override double GetX(int index)
		{
			return -1.0;
		}

		public override double GetY(int index)
		{
			return -1.0;
		}

		public double GetIntensity(int index)
		{
			return -1.0;
		}

		public override bool GetNull(int index)
		{
			return false;
		}

		public override bool GetEmpty(int index)
		{
			return false;
		}

		public override void SetX(int index, double value)
		{
		}

		public override void SetY(int index, double value)
		{
		}

		public void SetIntensity(int index, double value)
		{
		}

		public override void SetNull(int index, bool value)
		{
		}

		public override void SetEmpty(int index, bool value)
		{
		}

		public override void Clear()
		{
			Bitmap image = this.m_Image;
			this.m_Image = new Bitmap(this.ImageXSamples, this.ImageYSamples);
			image?.Dispose();
			base.m_Data.ClearMinMeanMax();
			this.DoDataChange();
		}

		protected override void LoadDesignTimeData(PlotXAxis xAxis, PlotYAxis yAxis, Random random, double yMin, double ySpan)
		{
			for (int i = 0; i < this.ImageXSamples; i++)
			{
				for (int j = 0; j < this.ImageYSamples; j++)
				{
					this.Add(i, j, random.NextDouble() * (this.IntensityGradient.Max - this.IntensityGradient.Min) + this.IntensityGradient.Min);
				}
			}
		}

		public override void SaveDataToStream(Stream value, out StreamWriter streamWriter)
		{
			streamWriter = new StreamWriter(value);
			streamWriter.WriteLine("No Data Saved : Not supported on Image channel Type");
		}

		public override void LoadDataFromStream(Stream stream)
		{
		}

		protected override void UpdateCanDraw(PaintArgs p)
		{
			base.UpdateCanDraw(p);
			if (this.m_Image == null)
			{
				base.CanDraw = false;
			}
		}

		public void DeleteDataByLines(int numberOfLines)
		{
			if (numberOfLines >= 1)
			{
				if (numberOfLines > this.ImageYSamples)
				{
					throw new Exception("Number of lines deleted must less than or equal to the ImageYSamples value.");
				}
				int height = this.ImageYSamples - numberOfLines;
				Bitmap image = this.m_Image;
				this.m_Image = new Bitmap(this.ImageXSamples, this.ImageYSamples);
				if (image != null)
				{
					Graphics graphics = Graphics.FromImage(this.m_Image);
					Rectangle srcRect = new Rectangle(0, numberOfLines, image.Width, height);
					Rectangle destRect = new Rectangle(0, 0, image.Width, height);
					graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
					graphics.Dispose();
					image.Dispose();
				}
				this.m_ImageYMin += (double)numberOfLines / (double)this.ImageYSpanSamples * this.ImageYSpan;
			}
		}

		public void SlideImage(double yOffset)
		{
			int num = (int)Math.Round(yOffset / this.ImageYSpan * (double)this.ImageYSpanSamples);
			if (num >= 1)
			{
				if (num > this.ImageYSamples)
				{
					this.m_Image = new Bitmap(this.ImageXSamples, this.ImageYSamples);
				}
				else
				{
					Bitmap image = this.m_Image;
					this.m_Image = new Bitmap(this.ImageXSamples, this.ImageYSamples);
					if (image != null)
					{
						Graphics graphics = Graphics.FromImage(this.m_Image);
						Rectangle srcRect = new Rectangle(0, num, image.Width, this.ImageYSamples - num);
						Rectangle destRect = new Rectangle(0, 0, image.Width, this.ImageYSamples - num);
						graphics.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
						graphics.Dispose();
						image.Dispose();
					}
					this.m_ImageYMin += yOffset;
				}
			}
		}

		protected override void Draw(PaintArgs p, PlotXAxis xAxis, PlotYAxis yAxis)
		{
			this.m_FirstDrawComplete = true;
			if (!base.Designing && this.ImageXAutoSetup && !this.m_ImageXAutoSetupComplete)
			{
				this.ImageXSamples = xAxis.ScaleDisplay.PixelsSpan;
				this.ImageXSpanSamples = xAxis.ScaleDisplay.PixelsSpan;
				this.ImageXMin = xAxis.Min;
				this.ImageXSpan = xAxis.Span;
				this.m_ImageXAutoSetupComplete = true;
			}
			if (!base.Designing && this.ImageYAutoSetup && !this.m_ImageYAutoSetupComplete)
			{
				this.ImageYSamples = yAxis.ScaleDisplay.PixelsSpan;
				this.ImageYSpanSamples = yAxis.ScaleDisplay.PixelsSpan;
				this.ImageYMin = yAxis.Min;
				this.ImageYSpan = yAxis.Span;
				this.m_ImageXAutoSetupComplete = true;
			}
			if (!(xAxis.Min > this.ImageXMax) && !(xAxis.Max < this.ImageXMin) && !(yAxis.Min > this.ImageYMax) && !(yAxis.Max < this.ImageYMin))
			{
				double num = xAxis.Min;
				double num2 = xAxis.Max;
				double num3 = yAxis.Min;
				double num4 = yAxis.Max;
				if (num < this.ImageXMin)
				{
					num = this.ImageXMin;
				}
				if (num2 > this.ImageXMax)
				{
					num2 = this.ImageXMax;
				}
				if (num3 < this.ImageYMin)
				{
					num3 = this.ImageYMin;
				}
				if (num4 > this.ImageYMax)
				{
					num4 = this.ImageYMax;
				}
				Rectangle rectangle = iRectangle.FromLTRB(base.XYSwapped, xAxis.ValueToPixels(num), yAxis.ValueToPixels(num3), xAxis.ValueToPixels(num2), yAxis.ValueToPixels(num4));
				Point[] array = new Point[3];
				if (!base.XYSwapped)
				{
					if (!xAxis.Reverse && !yAxis.Reverse)
					{
						array[0] = new Point(rectangle.Left, rectangle.Bottom);
						array[1] = new Point(rectangle.Right, rectangle.Bottom);
						array[2] = new Point(rectangle.Left, rectangle.Top);
					}
					else if (!xAxis.Reverse && yAxis.Reverse)
					{
						array[0] = new Point(rectangle.Left, rectangle.Top);
						array[1] = new Point(rectangle.Right, rectangle.Top);
						array[2] = new Point(rectangle.Left, rectangle.Bottom);
					}
					else if (xAxis.Reverse && !yAxis.Reverse)
					{
						array[0] = new Point(rectangle.Right, rectangle.Bottom);
						array[1] = new Point(rectangle.Left, rectangle.Bottom);
						array[2] = new Point(rectangle.Right, rectangle.Top);
					}
					else
					{
						array[0] = new Point(rectangle.Right, rectangle.Top);
						array[1] = new Point(rectangle.Left, rectangle.Top);
						array[2] = new Point(rectangle.Right, rectangle.Bottom);
					}
				}
				else if (!xAxis.Reverse && !yAxis.Reverse)
				{
					array[0] = new Point(rectangle.Left, rectangle.Bottom);
					array[1] = new Point(rectangle.Left, rectangle.Top);
					array[2] = new Point(rectangle.Right, rectangle.Bottom);
				}
				else if (!xAxis.Reverse && yAxis.Reverse)
				{
					array[0] = new Point(rectangle.Right, rectangle.Bottom);
					array[1] = new Point(rectangle.Right, rectangle.Top);
					array[2] = new Point(rectangle.Left, rectangle.Bottom);
				}
				else if (xAxis.Reverse && !yAxis.Reverse)
				{
					array[0] = new Point(rectangle.Left, rectangle.Top);
					array[1] = new Point(rectangle.Left, rectangle.Bottom);
					array[2] = new Point(rectangle.Right, rectangle.Top);
				}
				else
				{
					array[0] = new Point(rectangle.Right, rectangle.Top);
					array[1] = new Point(rectangle.Right, rectangle.Bottom);
					array[2] = new Point(rectangle.Left, rectangle.Top);
				}
				int left = this.ValueToImageSampleX(num);
				int right = this.ValueToImageSampleX(num2);
				int top = this.ValueToImageSampleY(num4);
				int bottom = this.ValueToImageSampleY(num3);
				Rectangle srcRect = iRectangle.FromLTRB(left, top, right, bottom);
				srcRect = new Rectangle(srcRect.Left, srcRect.Top, srcRect.Width, srcRect.Height);
				p.Graphics.DrawImage(this.m_Image, array, srcRect, GraphicsUnit.Pixel);
			}
		}
	}
}
