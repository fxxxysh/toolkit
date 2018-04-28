using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Controls the scale display layout properties.")]
	public abstract class ScaleDisplay : SubClassBase, IScaleDisplay
	{
		private ScaleGeneratorAuto m_GeneratorAuto;

		private ScaleGeneratorFixed m_GeneratorFixed;

		private ScaleTickMajor m_TickMajor;

		private ScaleTickMid m_TickMid;

		private ScaleTickMinor m_TickMinor;

		private ScaleRange m_Range;

		private ScaleGeneratorStyle m_GeneratorStyle;

		private double m_StartRefValue;

		private bool m_StartRefEnabled;

		private TextFormatDoubleAll m_TextFormatting;

		private double m_TextWidthMinValue;

		private int m_TextWidthMinPixels;

		private bool m_TextWidthMinAuto;

		private bool m_LineInnerVisible;

		private bool m_LineOuterVisible;

		private int m_LineThickness;

		private bool m_SlidingScale;

		private bool m_DegreeModeEnabled;

		private int m_EdgeRef;

		private ScaleTickInfo m_TickInfo;

		private bool m_Dirty;

		private int m_MaxTextWidth;

		private int m_MaxTextHeight;

		private Size m_MaxTextSize;

		private Size m_MaxTextAlignmentSize;

		private int m_MaxTickStackingDepth;

		private double m_MajorIncrement;

		private double m_MinorIncrement;

		bool IScaleDisplay.SlidingScale
		{
			get
			{
				return this.SlidingScale;
			}
			set
			{
				this.SlidingScale = value;
			}
		}

		bool IScaleDisplay.DegreeModeEnabled
		{
			get
			{
				return this.DegreeModeEnabled;
			}
			set
			{
				this.DegreeModeEnabled = value;
			}
		}

		int IScaleDisplay.EdgeRef
		{
			get
			{
				return this.EdgeRef;
			}
			set
			{
				this.EdgeRef = value;
			}
		}

		ScaleRange IScaleDisplay.Range
		{
			get
			{
				return this.Range;
			}
			set
			{
				this.Range = value;
			}
		}

		double IScaleDisplay.MajorIncrement
		{
			get
			{
				return this.m_MajorIncrement;
			}
			set
			{
				this.m_MajorIncrement = value;
			}
		}

		double IScaleDisplay.MinorIncrement
		{
			get
			{
				return this.m_MinorIncrement;
			}
			set
			{
				this.m_MinorIncrement = value;
			}
		}

		int IScaleDisplay.PixelsSpan
		{
			get
			{
				return this.PixelsSpan;
			}
		}

		protected bool Dirty
		{
			get
			{
				return this.m_Dirty;
			}
			set
			{
				this.m_Dirty = value;
			}
		}

		protected bool DegreeModeEnabled
		{
			get
			{
				return this.m_DegreeModeEnabled;
			}
			set
			{
				this.m_DegreeModeEnabled = value;
			}
		}

		protected bool SlidingScale
		{
			get
			{
				return this.m_SlidingScale;
			}
			set
			{
				this.m_SlidingScale = value;
			}
		}

		protected int EdgeRef
		{
			get
			{
				return this.m_EdgeRef;
			}
			set
			{
				this.m_EdgeRef = value;
			}
		}

		protected int MaxTextWidth
		{
			get
			{
				return this.m_MaxTextWidth;
			}
			set
			{
				this.m_MaxTextWidth = value;
			}
		}

		protected int MaxTextHeight
		{
			get
			{
				return this.m_MaxTextHeight;
			}
			set
			{
				this.m_MaxTextHeight = value;
			}
		}

		protected Size MaxTextSize
		{
			get
			{
				return this.m_MaxTextSize;
			}
			set
			{
				this.m_MaxTextSize = value;
			}
		}

		protected Size MaxTextAlignmentSize
		{
			get
			{
				return this.m_MaxTextAlignmentSize;
			}
			set
			{
				this.m_MaxTextAlignmentSize = value;
			}
		}

		protected int MaxTickStackingDepth
		{
			get
			{
				return this.m_MaxTickStackingDepth;
			}
			set
			{
				this.m_MaxTickStackingDepth = value;
			}
		}

		protected IScaleGeneratorBase Generator
		{
			get
			{
				if (this.GeneratorStyle == ScaleGeneratorStyle.Fixed)
				{
					return this.GeneratorFixed;
				}
				return this.GeneratorAuto;
			}
		}

		protected ScaleTickInfo TickInfo => this.m_TickInfo;

		[Description("")]
		[Browsable(false)]
		public ArrayList TickList
		{
			get
			{
				return this.m_TickInfo.TickList;
			}
		}

		[Description("GeneratorAuto properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ScaleGeneratorAuto GeneratorAuto
		{
			get
			{
				return this.m_GeneratorAuto;
			}
		}

		[Description("GeneratorAuto properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ScaleGeneratorFixed GeneratorFixed
		{
			get
			{
				return this.m_GeneratorFixed;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Tick Major properties")]
		public ScaleTickMajor TickMajor
		{
			get
			{
				return this.m_TickMajor;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Tick Mid properties")]
		public ScaleTickMid TickMid
		{
			get
			{
				return this.m_TickMid;
			}
		}

		[Description("Tick Minor properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ScaleTickMinor TickMinor
		{
			get
			{
				return this.m_TickMinor;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Text Format properties")]
		[RefreshProperties(RefreshProperties.All)]
		public TextFormatDoubleAll TextFormatting
		{
			get
			{
				return this.m_TextFormatting;
			}
			set
			{
				if (this.m_TextFormatting != null)
				{
					base.RemoveSubClass(this.m_TextFormatting);
				}
				this.m_TextFormatting = value;
				base.AddSubClass(this.m_TextFormatting);
			}
		}

		[Description("Scale Range properties")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Browsable(false)]
		public ScaleRange ScaleRange
		{
			get
			{
				return this.m_Range;
			}
		}

		protected virtual ScaleRange Range
		{
			get
			{
				return this.m_Range;
			}
			set
			{
				if (this.Range != value)
				{
					this.m_Range = value;
					base.DoPropertyChange(this, "Range");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool Visible
		{
			get
			{
				return this.VisibleInternal;
			}
			set
			{
				this.VisibleInternal = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public ScaleGeneratorStyle GeneratorStyle
		{
			get
			{
				return this.m_GeneratorStyle;
			}
			set
			{
				base.PropertyUpdateDefault("GeneratorStyle", value);
				if (this.GeneratorStyle != value)
				{
					this.m_GeneratorStyle = value;
					base.DoPropertyChange(this, "GeneratorStyle");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double StartRefValue
		{
			get
			{
				return this.m_StartRefValue;
			}
			set
			{
				base.PropertyUpdateDefault("StartRefValue", value);
				if (this.StartRefValue != value)
				{
					this.m_StartRefValue = value;
					base.DoPropertyChange(this, "StartRefValue");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool StartRefEnabled
		{
			get
			{
				return this.m_StartRefEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("StartRefEnabled", value);
				if (this.StartRefEnabled != value)
				{
					this.m_StartRefEnabled = value;
					base.DoPropertyChange(this, "StartRefEnabled");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double TextWidthMinValue
		{
			get
			{
				return this.m_TextWidthMinValue;
			}
			set
			{
				base.PropertyUpdateDefault("TextWidthMinValue", value);
				if (this.TextWidthMinValue != value)
				{
					this.m_TextWidthMinValue = value;
					base.DoPropertyChange(this, "TextWidthMinValue");
				}
			}
		}

		protected int TextWidthMinPixels
		{
			get
			{
				return this.m_TextWidthMinPixels;
			}
			set
			{
				this.m_TextWidthMinPixels = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool TextWidthMinAuto
		{
			get
			{
				return this.m_TextWidthMinAuto;
			}
			set
			{
				base.PropertyUpdateDefault("TextWidthMinAuto", value);
				if (this.TextWidthMinAuto != value)
				{
					this.m_TextWidthMinAuto = value;
					base.DoPropertyChange(this, "TextWidthMinAuto");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool LineInnerVisible
		{
			get
			{
				return this.m_LineInnerVisible;
			}
			set
			{
				base.PropertyUpdateDefault("LineInnerVisible", value);
				if (this.LineInnerVisible != value)
				{
					this.m_LineInnerVisible = value;
					base.DoPropertyChange(this, "LineInnerVisible");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool LineOuterVisible
		{
			get
			{
				return this.m_LineOuterVisible;
			}
			set
			{
				base.PropertyUpdateDefault("LineOuterVisible", value);
				if (this.LineOuterVisible != value)
				{
					this.m_LineOuterVisible = value;
					base.DoPropertyChange(this, "LineOuterVisible");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int LineThickness
		{
			get
			{
				return this.m_LineThickness;
			}
			set
			{
				base.PropertyUpdateDefault("LineThickness", value);
				if (this.LineThickness != value)
				{
					this.m_LineThickness = value;
					base.DoPropertyChange(this, "LineThickness");
				}
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public double MajorIncrement
		{
			get
			{
				return this.m_MajorIncrement;
			}
			set
			{
				this.m_MajorIncrement = value;
			}
		}

		[Description("")]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public double MinorIncrement
		{
			get
			{
				return this.m_MinorIncrement;
			}
			set
			{
				this.m_MinorIncrement = value;
			}
		}

		public abstract int PixelsSpan
		{
			get;
		}

		bool IScaleDisplay.GetValueOnScale(double value)
		{
			return this.GetValueOnScale(value);
		}

		void IScaleDisplay.Generate(PaintArgs p)
		{
			this.Generate(p);
		}

		void IScaleDisplay.Draw(PaintArgs p)
		{
			this.Draw(p);
		}

		void IScaleDisplay.DrawTickLabel(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format)
		{
			this.DrawTickLabel(p, tick, format);
		}

		void IScaleDisplay.DrawTickLine(PaintArgs p, IScaleTickBase tick)
		{
			this.DrawTickLine(p, tick);
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_GeneratorAuto = new ScaleGeneratorAuto();
			base.AddSubClass(this.GeneratorAuto);
			this.m_GeneratorFixed = new ScaleGeneratorFixed();
			base.AddSubClass(this.GeneratorFixed);
			this.m_TickMajor = new ScaleTickMajor();
			base.AddSubClass(this.TickMajor);
			this.m_TickMid = new ScaleTickMid();
			base.AddSubClass(this.TickMid);
			this.m_TickMinor = new ScaleTickMinor();
			base.AddSubClass(this.TickMinor);
			this.TextFormatting = new TextFormatDoubleAll();
			((IScaleGeneratorBase)this.m_GeneratorAuto).Display = this;
			((IScaleGeneratorBase)this.m_GeneratorFixed).Display = this;
			this.m_TickInfo = new ScaleTickInfo(this);
			((ISubClassBase)this.TickMajor).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.TickMinor).ColorAmbientSource = AmbientColorSouce.Color;
			((ISubClassBase)this.TickMid).ColorAmbientSource = AmbientColorSouce.Color;
			this.m_MajorIncrement = 10.0;
			this.m_MinorIncrement = 1.0;
			base.ColorAmbientSource = AmbientColorSouce.ForeColor;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.LineThickness = 1;
		}

		private bool ShouldSerializeGeneratorAuto()
		{
			return ((ISubClassBase)this.GeneratorAuto).ShouldSerialize();
		}

		private void ResetGeneratorAuto()
		{
			((ISubClassBase)this.GeneratorAuto).ResetToDefault();
		}

		private bool ShouldSerializeGeneratorFixed()
		{
			return ((ISubClassBase)this.GeneratorFixed).ShouldSerialize();
		}

		private void ResetGeneratorFixed()
		{
			((ISubClassBase)this.GeneratorFixed).ResetToDefault();
		}

		private bool ShouldSerializeTickMajor()
		{
			return ((ISubClassBase)this.TickMajor).ShouldSerialize();
		}

		private void ResetTickMajor()
		{
			((ISubClassBase)this.TickMajor).ResetToDefault();
		}

		private bool ShouldSerializeTickMid()
		{
			return ((ISubClassBase)this.TickMid).ShouldSerialize();
		}

		private void ResetTickMid()
		{
			((ISubClassBase)this.TickMid).ResetToDefault();
		}

		private bool ShouldSerializeTickMinor()
		{
			return ((ISubClassBase)this.TickMinor).ShouldSerialize();
		}

		private void ResetTickMinor()
		{
			((ISubClassBase)this.TickMinor).ResetToDefault();
		}

		private bool ShouldSerializeTextFormatting()
		{
			return ((ISubClassBase)this.TextFormatting).ShouldSerialize();
		}

		private void ResetTextFormatting()
		{
			((ISubClassBase)this.TextFormatting).ResetToDefault();
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private bool ShouldSerializeGeneratorStyle()
		{
			return base.PropertyShouldSerialize("GeneratorStyle");
		}

		private void ResetGeneratorStyle()
		{
			base.PropertyReset("GeneratorStyle");
		}

		private bool ShouldSerializeStartRefValue()
		{
			return base.PropertyShouldSerialize("StartRefValue");
		}

		private void ResetStartRefValue()
		{
			base.PropertyReset("StartRefValue");
		}

		private bool ShouldSerializeStartRefEnabled()
		{
			return base.PropertyShouldSerialize("StartRefEnabled");
		}

		private void ResetStartRefEnabled()
		{
			base.PropertyReset("StartRefEnabled");
		}

		private bool ShouldSerializeTextWidthMinValue()
		{
			return base.PropertyShouldSerialize("TextWidthMinValue");
		}

		private void ResetTextWidthMinValue()
		{
			base.PropertyReset("TextWidthMinValue");
		}

		private bool ShouldSerializeTextWidthMinAuto()
		{
			return base.PropertyShouldSerialize("TextWidthMinAuto");
		}

		private void ResetTextWidthMinAuto()
		{
			base.PropertyReset("TextWidthMinAuto");
		}

		private bool ShouldSerializeLineInnerVisible()
		{
			return base.PropertyShouldSerialize("LineInnerVisible");
		}

		private void ResetLineInnerVisible()
		{
			base.PropertyReset("LineInnerVisible");
		}

		private bool ShouldSerializeLineOuterVisible()
		{
			return base.PropertyShouldSerialize("LineOuterVisible");
		}

		private void ResetLineOuterVisible()
		{
			base.PropertyReset("LineOuterVisible");
		}

		private bool ShouldSerializeLineThickness()
		{
			return base.PropertyShouldSerialize("LineThickness");
		}

		private void ResetLineThickness()
		{
			base.PropertyReset("LineThickness");
		}

		public ScaleTickMajor AddTickMajor(double value, bool permanent)
		{
			if (this.Range.ScaleType == ScaleType.Log10 && value <= 0.0)
			{
				return null;
			}
			if (this.Range.ScaleType == ScaleType.SplitLinearLog10 && value >= this.Range.SplitStart && value <= 0.0)
			{
				return null;
			}
			ScaleTickMajor scaleTickMajor = new ScaleTickMajor();
			scaleTickMajor.Value = value;
			scaleTickMajor.Color = this.TickMajor.Color;
			scaleTickMajor.ForeColor = this.TickMajor.ForeColor;
			scaleTickMajor.Font = this.TickMajor.Font;
			scaleTickMajor.Thickness = this.TickMajor.Thickness;
			scaleTickMajor.Length = this.TickMajor.Length;
			scaleTickMajor.TextVisible = this.TickMajor.TextVisible;
			scaleTickMajor.TextMargin = this.TickMajor.TextMargin;
			scaleTickMajor.Permanent = permanent;
			if (this.DegreeModeEnabled)
			{
				scaleTickMajor.Text = this.TextFormatting.GetText(Math2.AngleNormalized(scaleTickMajor.Value));
			}
			else
			{
				scaleTickMajor.Text = this.TextFormatting.GetText(scaleTickMajor.Value);
			}
			((ISubClassBase)scaleTickMajor).AmbientOwner = this;
			((IScaleTickBase)scaleTickMajor).Display = this;
			this.TickList.Add(scaleTickMajor);
			return scaleTickMajor;
		}

		public ScaleTickMajor AddTickMajor(double value, string text, bool permanent)
		{
			ScaleTickMajor scaleTickMajor = this.AddTickMajor(value, permanent);
			scaleTickMajor.Text = text;
			return scaleTickMajor;
		}

		public ScaleTickMid AddTickMid(double value, bool permanent)
		{
			if (this.Range.ScaleType != 0 && value <= 0.0)
			{
				return null;
			}
			ScaleTickMid scaleTickMid = new ScaleTickMid();
			scaleTickMid.Value = value;
			scaleTickMid.Color = this.TickMid.Color;
			scaleTickMid.ForeColor = this.TickMid.ForeColor;
			scaleTickMid.Font = this.TickMid.Font;
			scaleTickMid.Thickness = this.TickMid.Thickness;
			scaleTickMid.Length = this.TickMid.Length;
			scaleTickMid.TextVisible = this.TickMid.TextVisible;
			scaleTickMid.TextMargin = this.TickMid.TextMargin;
			scaleTickMid.Alignment = this.TickMid.Alignment;
			scaleTickMid.Permanent = permanent;
			if (this.DegreeModeEnabled)
			{
				scaleTickMid.Text = this.TextFormatting.GetText(Math2.AngleNormalized(scaleTickMid.Value));
			}
			else
			{
				scaleTickMid.Text = this.TextFormatting.GetText(scaleTickMid.Value);
			}
			((ISubClassBase)scaleTickMid).AmbientOwner = this;
			((IScaleTickBase)scaleTickMid).Display = this;
			this.TickList.Add(scaleTickMid);
			return scaleTickMid;
		}

		public ScaleTickMid AddTickMid(double value, string text, bool permanent)
		{
			ScaleTickMid scaleTickMid = this.AddTickMid(value, permanent);
			scaleTickMid.Text = text;
			return scaleTickMid;
		}

		public ScaleTickMinor AddTickMinor(double value, bool permanent)
		{
			if (this.Range.ScaleType != 0 && value <= 0.0)
			{
				return null;
			}
			ScaleTickMinor scaleTickMinor = new ScaleTickMinor();
			scaleTickMinor.Value = value;
			scaleTickMinor.Color = this.TickMinor.Color;
			scaleTickMinor.Thickness = this.TickMinor.Thickness;
			scaleTickMinor.Length = this.TickMinor.Length;
			scaleTickMinor.Alignment = this.TickMinor.Alignment;
			scaleTickMinor.Permanent = permanent;
			((ISubClassBase)scaleTickMinor).AmbientOwner = this;
			((IScaleTickBase)scaleTickMinor).Display = this;
			this.TickList.Add(scaleTickMinor);
			return scaleTickMinor;
		}

		protected void UpdateTextWidthMinPixels(PaintArgs p)
		{
			if (this.TextWidthMinAuto && !base.Designing)
			{
				this.TextWidthMinPixels = (int)Math.Max((double)this.TextWidthMinPixels, (double)p.Graphics.MeasureString(this.TickMajor.Font).Width * this.TextWidthMinValue);
			}
			else
			{
				this.TextWidthMinPixels = (int)((double)p.Graphics.MeasureString(this.TickMajor.Font).Width * this.TextWidthMinValue);
			}
		}

		protected void UpdateTicksTextSizeInfo(PaintArgs p)
		{
			for (int i = 0; i < this.TickList.Count; i++)
			{
				if (this.TickList[i] is IScaleTickLabel)
				{
					IScaleTickLabel scaleTickLabel = this.TickList[i] as IScaleTickLabel;
					scaleTickLabel.TextSize = p.Graphics.MeasureString(scaleTickLabel.Text, scaleTickLabel.Font, false);
				}
			}
			int num = (this is ScaleDisplayLinear) ? this.TextWidthMinPixels : 0;
			this.m_MaxTextWidth = 0;
			this.m_MaxTextHeight = 0;
			for (int j = 0; j < this.TickList.Count; j++)
			{
				if (this.TickList[j] is IScaleTickLabel)
				{
					IScaleTickLabel scaleTickLabel = this.TickList[j] as IScaleTickLabel;
					if (scaleTickLabel.TextVisible)
					{
						this.m_MaxTextWidth = Math.Max(this.m_MaxTextWidth, scaleTickLabel.TextSize.Width);
						this.m_MaxTextHeight = Math.Max(this.m_MaxTextHeight, scaleTickLabel.TextSize.Height);
						num = Math.Max(num, this.m_MaxTextWidth);
					}
				}
			}
			this.MaxTextSize = new Size(this.m_MaxTextWidth, this.m_MaxTextHeight);
			this.MaxTextAlignmentSize = new Size(num, this.m_MaxTextHeight);
			if (this.TickInfo.StackingDimension == StackingDimension.Height)
			{
				this.m_MaxTickStackingDepth = this.MaxTextSize.Height;
			}
			else
			{
				this.m_MaxTickStackingDepth = this.MaxTextSize.Width;
			}
			for (int k = 0; k < this.TickList.Count; k++)
			{
				if (this.TickList[k] is IScaleTickLabel)
				{
					IScaleTickLabel scaleTickLabel = this.TickList[k] as IScaleTickLabel;
					scaleTickLabel.TextMaxSize = this.MaxTextSize;
					scaleTickLabel.TextAlignmentSize = this.MaxTextAlignmentSize;
					scaleTickLabel.StackingDimension = this.TickInfo.StackingDimension;
				}
			}
		}

		public double ValueClamped(double value)
		{
			if (value <= this.ScaleRange.Min)
			{
				return this.ScaleRange.Min;
			}
			if (value >= this.ScaleRange.Max)
			{
				return this.ScaleRange.Max;
			}
			return value;
		}

		public void ClearAllNonPermanentTicks()
		{
			int num = 0;
			while (num < this.TickList.Count)
			{
				ScaleTickBase scaleTickBase = this.TickList[num] as ScaleTickBase;
				if (!scaleTickBase.Permanent)
				{
					this.TickList.Remove(scaleTickBase);
				}
				else
				{
					num++;
				}
			}
		}

		protected void CalcTicks(PaintArgs p)
		{
			this.Generator.Generate(p, this.TickInfo);
			this.UpdateTicksTextSizeInfo(p);
		}

		protected virtual void Generate(PaintArgs p)
		{
			this.ScaleInitializeTickInfo();
			this.UpdateTextWidthMinPixels(p);
			if (!(this.ScaleRange.Span > 1E+300) && this.ScaleRange.Span >= 1E-300)
			{
				this.ClearAllNonPermanentTicks();
				if (this.GeneratorStyle != ScaleGeneratorStyle.Custom)
				{
					if (this.Range.ScaleType != 0 && this.Range.ScaleType != ScaleType.Log10)
					{
						if (this.Range.ScaleType == ScaleType.SplitLinearLog10)
						{
							this.TickInfo.Painter = p;
							this.TickInfo.TextFormatting = this.TextFormatting;
							this.TickInfo.PixelSpanTotal = this.PixelsSpan;
							this.TickInfo.PixelSpanCalculation = (int)((double)this.TickInfo.PixelSpanTotal * this.Range.SplitPercent);
							this.TickInfo.ScaleType = ScaleType.Linear;
							this.TickInfo.Span = this.Range.SplitStart - this.Range.Min;
							this.TickInfo.Min = this.Range.Min;
							this.TickInfo.Max = this.TickInfo.Min + this.TickInfo.Span;
							this.Generator.InitializeTickInfo(this.TickInfo);
							this.TickInfo.MaxTicks = this.GetMaxTicks();
							this.CalcTicks(p);
							this.TickInfo.Painter = p;
							this.TickInfo.TextFormatting = this.TextFormatting;
							this.TickInfo.PixelSpanTotal = this.PixelsSpan;
							this.TickInfo.PixelSpanCalculation = (int)((double)this.TickInfo.PixelSpanTotal * (1.0 - this.Range.SplitPercent));
							this.TickInfo.ScaleType = ScaleType.Log10;
							this.TickInfo.Min = this.Range.SplitStart;
							this.TickInfo.Max = this.Range.Max;
							this.TickInfo.Span = this.TickInfo.Max - this.TickInfo.Min;
							this.Generator.InitializeTickInfo(this.TickInfo);
							this.TickInfo.MaxTicks = this.GetMaxTicks();
							if (!double.IsNaN(this.TickInfo.Min) && !double.IsNaN(this.TickInfo.Max) && !double.IsNaN(this.TickInfo.Span))
							{
								this.CalcTicks(p);
							}
						}
					}
					else
					{
						this.TickInfo.Painter = p;
						this.TickInfo.TextFormatting = this.TextFormatting;
						this.TickInfo.PixelSpanTotal = this.PixelsSpan;
						this.TickInfo.PixelSpanCalculation = this.TickInfo.PixelSpanTotal;
						this.TickInfo.ScaleType = this.Range.ScaleType;
						this.TickInfo.Span = this.Range.Span;
						this.TickInfo.Min = this.Range.Min;
						this.TickInfo.Max = this.Range.Max;
						this.Generator.InitializeTickInfo(this.TickInfo);
						this.TickInfo.MaxTicks = this.GetMaxTicks();
						this.CalcTicks(p);
					}
				}
				else
				{
					this.UpdateTicksTextSizeInfo(p);
				}
			}
			else
			{
				this.TickList.Clear();
				this.AddTickMajor(this.ScaleRange.Mid, "Out of Range", false);
			}
			if (this.TextWidthMinAuto && !base.Designing)
			{
				this.TextWidthMinPixels = Math.Max(this.TextWidthMinPixels, this.MaxTextWidth);
			}
			this.UpdateScaleExtents(p);
		}

		private void Draw(PaintArgs p)
		{
			if (this.Visible)
			{
				this.DrawInternal(p, DrawStringFormat.GenericDefault);
			}
		}

		protected abstract Point GetTickPoint(IScaleTickBase tick);

		protected abstract Point[] GetTickLine(IScaleTickBase tick);

		protected abstract int GetMaxTicks();

		protected abstract void ScaleInitializeTickInfo();

		protected abstract bool GetValueOnScale(double value);

		protected abstract void UpdateScaleExtents(PaintArgs p);

		protected abstract void DrawInternal(PaintArgs p, DrawStringFormat stringFormat);

		protected abstract void DrawTickLine(PaintArgs p, IScaleTickBase tick);

		protected abstract void DrawTickLabel(PaintArgs p, IScaleTickLabel tick, DrawStringFormat format);
	}
}
