using Iocomp.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Iocomp.Classes
{
	[Serializable]
	[Description("Plot Color Lookup Gradient.")]
	public class PlotColorLookupGradient : SubClassBase
	{
		private double m_Min;

		private double m_Max;

		private int m_StepsCount;

		private bool m_StepsEnabled;

		private GradientColorCollection m_GradientColors;

		private ColorBlend m_ColorBlend;

		private Color m_ColorStart;

		private Color m_ColorStop;

		private Bitmap m_Bitmap;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public GradientColorCollection GradientColors
		{
			get
			{
				return this.m_GradientColors;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Min
		{
			get
			{
				return this.m_Min;
			}
			set
			{
				base.PropertyUpdateDefault("Min", value);
				if (this.Min != value)
				{
					this.m_Min = value;
					this.Regenerate();
					base.DoPropertyChange(this, "Min");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double Max
		{
			get
			{
				return this.m_Max;
			}
			set
			{
				base.PropertyUpdateDefault("Max", value);
				if (this.Max != value)
				{
					this.m_Max = value;
					this.Regenerate();
					base.DoPropertyChange(this, "Max");
				}
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double Span
		{
			get
			{
				return this.Max - this.Min;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Bitmap Bitmap
		{
			get
			{
				return this.m_Bitmap;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int StepsCount
		{
			get
			{
				return this.m_StepsCount;
			}
			set
			{
				if (value < 2)
				{
					value = 2;
				}
				base.PropertyUpdateDefault("StepsCount", value);
				if (this.StepsCount != value)
				{
					this.m_StepsCount = value;
					this.Regenerate();
					base.DoPropertyChange(this, "StepsCount");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool StepsEnabled
		{
			get
			{
				return this.m_StepsEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("StepsEnabled", value);
				if (this.StepsEnabled != value)
				{
					this.m_StepsEnabled = value;
					this.Regenerate();
					base.DoPropertyChange(this, "StepsEnabled");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public Color ColorStart
		{
			get
			{
				return this.m_ColorStart;
			}
			set
			{
				base.PropertyUpdateDefault("ColorStart", value);
				if (this.ColorStart != value)
				{
					this.m_ColorStart = value;
					this.Regenerate();
					base.DoPropertyChange(this, "ColorStart");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public Color ColorStop
		{
			get
			{
				return this.m_ColorStop;
			}
			set
			{
				base.PropertyUpdateDefault("ColorStop", value);
				if (this.ColorStop != value)
				{
					this.m_ColorStop = value;
					this.Regenerate();
					base.DoPropertyChange(this, "ColorStop");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Color[] Colors
		{
			get
			{
				if (!this.StepsEnabled)
				{
					if (this.GradientColors.IsValid)
					{
						return this.GradientColors.Colors;
					}
					return new Color[2]
					{
						this.ColorStart,
						this.ColorStop
					};
				}
				Color[] array = new Color[this.StepsCount + 1];
				for (int i = 0; i < this.StepsCount + 1; i++)
				{
					if (i == this.StepsCount)
					{
						array[i] = Color.Empty;
					}
					else
					{
						array[i] = this.GetColor(i);
					}
				}
				return array;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public float[] Positions
		{
			get
			{
				if (!this.StepsEnabled)
				{
					if (this.GradientColors.IsValid)
					{
						return this.GradientColors.Positions;
					}
					return new float[2]
					{
						0f,
						1f
					};
				}
				float[] array = new float[this.StepsCount + 1];
				for (int i = 0; i < this.StepsCount + 1; i++)
				{
					array[i] = (float)((double)i * 1.0 / (double)this.StepsCount);
				}
				return array;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Color Lookup Gradient";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotColorLookupGradientEditorPlugIn";
		}

		public PlotColorLookupGradient()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_ColorBlend = new ColorBlend();
			this.m_GradientColors = new GradientColorCollection(this.ComponentBase);
			this.m_GradientColors.ObjectAdded += this.m_Colors_ObjectAdded;
			this.m_GradientColors.ObjectRemoved += this.m_Colors_ObjectRemoved;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Min = 0.0;
			this.Max = 100.0;
			this.StepsEnabled = false;
			this.StepsCount = 10;
			this.ColorStart = Color.Orange;
			this.ColorStop = Color.Yellow;
		}

		private bool ShouldSerializeColors()
		{
			return this.GradientColors.Count != 0;
		}

		private void ResetColors()
		{
			this.GradientColors.Clear();
		}

		private bool ShouldSerializeMin()
		{
			return base.PropertyShouldSerialize("Min");
		}

		private void ResetMin()
		{
			base.PropertyReset("Min");
		}

		private bool ShouldSerializeMax()
		{
			return base.PropertyShouldSerialize("Max");
		}

		private void ResetMax()
		{
			base.PropertyReset("Max");
		}

		private bool ShouldSerializeStepsCount()
		{
			return base.PropertyShouldSerialize("StepsCount");
		}

		private void ResetStepsCount()
		{
			base.PropertyReset("StepsCount");
		}

		private bool ShouldSerializeStepsEnabled()
		{
			return base.PropertyShouldSerialize("StepsEnabled");
		}

		private void ResetStepsEnabled()
		{
			base.PropertyReset("StepsEnabled");
		}

		private bool ShouldSerializeColorStart()
		{
			return base.PropertyShouldSerialize("ColorStart");
		}

		private void ResetColorStart()
		{
			base.PropertyReset("ColorStart");
		}

		private bool ShouldSerializeColorStop()
		{
			return base.PropertyShouldSerialize("ColorStop");
		}

		private void ResetColorStop()
		{
			base.PropertyReset("ColorStop");
		}

		public void Regenerate()
		{
			if (this.m_Bitmap != null)
			{
				this.m_Bitmap.Dispose();
				this.m_Bitmap = null;
			}
			if (!this.StepsEnabled)
			{
				this.m_Bitmap = new Bitmap(1, 256);
			}
			else
			{
				this.m_Bitmap = new Bitmap(1, this.StepsCount);
			}
			Rectangle rect = new Rectangle(0, 0, this.m_Bitmap.Width, this.m_Bitmap.Height);
			LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect, this.ColorStart, this.ColorStop, LinearGradientMode.Vertical);
			if (this.GradientColors.IsValid)
			{
				this.m_ColorBlend.Colors = this.GradientColors.Colors;
				this.m_ColorBlend.Positions = this.GradientColors.Positions;
				linearGradientBrush.InterpolationColors = this.m_ColorBlend;
			}
			Graphics graphics = Graphics.FromImage(this.m_Bitmap);
			graphics.FillRectangle(linearGradientBrush, rect);
			linearGradientBrush.Dispose();
			graphics.Dispose();
		}

		public Color GetColor(double value)
		{
			if (this.m_Bitmap == null)
			{
				return Color.Empty;
			}
			int num = (int)((value - this.Min) / (this.Max - this.Min) * (double)this.m_Bitmap.Height);
			if (num < 0)
			{
				num = 0;
			}
			if (num > this.m_Bitmap.Height - 1)
			{
				num = this.m_Bitmap.Height - 1;
			}
			return this.m_Bitmap.GetPixel(0, num);
		}

		public Color GetColor(int index)
		{
			if (index > this.m_Bitmap.Height - 1)
			{
				throw new Exception("Index out of bounds");
			}
			return this.m_Bitmap.GetPixel(0, index);
		}

		private void m_Colors_ObjectAdded(object sender, ObjectEventArgs e)
		{
			(e.Object as ISubClassBase).PropertyChanged += this.PlotColorLookupGradient_PropertyChanged;
		}

		private void m_Colors_ObjectRemoved(object sender, ObjectEventArgs e)
		{
			(e.Object as ISubClassBase).PropertyChanged -= this.PlotColorLookupGradient_PropertyChanged;
		}

		private void PlotColorLookupGradient_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.Regenerate();
		}
	}
}
