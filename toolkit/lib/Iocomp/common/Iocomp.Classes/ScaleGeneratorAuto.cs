using Iocomp.Types;
using System;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("")]
	public sealed class ScaleGeneratorAuto : ScaleGeneratorBase
	{
		private double m_DesiredIncrement;

		private double m_MinTextSpacing;

		private bool m_FixedMinMaxMajors;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double DesiredIncrement
		{
			get
			{
				return this.m_DesiredIncrement;
			}
			set
			{
				base.PropertyUpdateDefault("DesiredIncrement", value);
				if (this.DesiredIncrement != value)
				{
					this.m_DesiredIncrement = value;
					base.DoPropertyChange(this, "DesiredIncrement");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double MinTextSpacing
		{
			get
			{
				return this.m_MinTextSpacing;
			}
			set
			{
				base.PropertyUpdateDefault("MinTextSpacing", value);
				if (this.MinTextSpacing != value)
				{
					this.m_MinTextSpacing = value;
					base.DoPropertyChange(this, "MinTextSpacing");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public bool FixedMinMaxMajors
		{
			get
			{
				return this.m_FixedMinMaxMajors;
			}
			set
			{
				base.PropertyUpdateDefault("FixedMinMaxMajors", value);
				if (this.FixedMinMaxMajors != value)
				{
					this.m_FixedMinMaxMajors = value;
					base.DoPropertyChange(this, "FixedMinMaxMajors");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Scale Generator Auto";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleGeneratorAutoEditorPlugIn";
		}

		public ScaleGeneratorAuto()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.FixedMinMaxMajors = false;
		}

		private bool ShouldSerializeDesiredIncrement()
		{
			return base.PropertyShouldSerialize("DesiredIncrement");
		}

		private void ResetDesiredIncrement()
		{
			base.PropertyReset("DesiredIncrement");
		}

		private bool ShouldSerializeMinTextSpacing()
		{
			return base.PropertyShouldSerialize("MinTextSpacing");
		}

		private void ResetMinTextSpacing()
		{
			base.PropertyReset("MinTextSpacing");
		}

		private bool ShouldSerializeFixedMinMaxMajors()
		{
			return base.PropertyShouldSerialize("FixedMinMaxMajors");
		}

		private void ResetFixedMinMaxMajors()
		{
			base.PropertyReset("FixedMinMaxMajors");
		}

		private void CalcLinearTicks(ScaleTickInfo tickInfo)
		{
			double span = tickInfo.Span;
			int num = (int)(Math.Log10(span) - 1.0 - Math.Log10((double)tickInfo.MaxTicks));
			while (true)
			{
				double num2 = Math.Pow(10.0, (double)num);
				if (!tickInfo.LabelsFit(span, num2 * 1.0) && !tickInfo.LabelsFit(span, num2 * 2.0) && !tickInfo.LabelsFit(span, num2 * 5.0))
				{
					num++;
					continue;
				}
				break;
			}
		}

		private void CalcDateTimeTicks(ScaleTickInfo tickInfo)
		{
			double span = tickInfo.Span;
			if (!tickInfo.LabelsFit(span, Math2.TIME_MILLISECOND * 1.0) && !tickInfo.LabelsFit(span, Math2.TIME_MILLISECOND * 2.0) && !tickInfo.LabelsFit(span, Math2.TIME_MILLISECOND * 5.0) && !tickInfo.LabelsFit(span, Math2.TIME_MILLISECOND * 10.0) && !tickInfo.LabelsFit(span, Math2.TIME_MILLISECOND * 20.0) && !tickInfo.LabelsFit(span, Math2.TIME_MILLISECOND * 50.0) && !tickInfo.LabelsFit(span, Math2.TIME_MILLISECOND * 100.0) && !tickInfo.LabelsFit(span, Math2.TIME_MILLISECOND * 200.0) && !tickInfo.LabelsFit(span, Math2.TIME_MILLISECOND * 500.0) && !tickInfo.LabelsFit(span, Math2.TIME_SECOND * 1.0) && !tickInfo.LabelsFit(span, Math2.TIME_SECOND * 2.0) && !tickInfo.LabelsFit(span, Math2.TIME_SECOND * 5.0) && !tickInfo.LabelsFit(span, Math2.TIME_SECOND * 10.0) && !tickInfo.LabelsFit(span, Math2.TIME_SECOND * 15.0) && !tickInfo.LabelsFit(span, Math2.TIME_SECOND * 20.0) && !tickInfo.LabelsFit(span, Math2.TIME_SECOND * 30.0) && !tickInfo.LabelsFit(span, Math2.TIME_MINUTE * 1.0) && !tickInfo.LabelsFit(span, Math2.TIME_MINUTE * 2.0) && !tickInfo.LabelsFit(span, Math2.TIME_MINUTE * 5.0) && !tickInfo.LabelsFit(span, Math2.TIME_MINUTE * 10.0) && !tickInfo.LabelsFit(span, Math2.TIME_MINUTE * 15.0) && !tickInfo.LabelsFit(span, Math2.TIME_MINUTE * 20.0) && !tickInfo.LabelsFit(span, Math2.TIME_MINUTE * 30.0) && !tickInfo.LabelsFit(span, Math2.TIME_HOUR * 1.0) && !tickInfo.LabelsFit(span, Math2.TIME_HOUR * 2.0) && !tickInfo.LabelsFit(span, Math2.TIME_HOUR * 4.0) && !tickInfo.LabelsFit(span, Math2.TIME_HOUR * 6.0) && !tickInfo.LabelsFit(span, Math2.TIME_HOUR * 12.0) && !tickInfo.LabelsFit(span, 1.0) && !tickInfo.LabelsFit(span, 7.0) && !tickInfo.LabelsFit(span, 14.0) && !tickInfo.LabelsFit(span, 31.0) && !tickInfo.LabelsFit(span, 61.0) && !tickInfo.LabelsFit(span, 92.0) && !tickInfo.LabelsFit(span, 182.0))
			{
				int num = 0;
				while (true)
				{
					double num2 = Math.Pow(10.0, (double)num);
					if (!tickInfo.LabelsFit(span, 1.0 * num2 * 365.0) && !tickInfo.LabelsFit(span, 2.0 * num2 * 365.0) && !tickInfo.LabelsFit(span, 5.0 * num2 * 365.0))
					{
						num++;
						continue;
					}
					break;
				}
			}
		}

		protected override void InitializeTickInfo(ScaleTickInfo tickInfo)
		{
			base.InitializeTickInfo(tickInfo);
			tickInfo.StartStandard = 0.0;
			tickInfo.MinTextSpacing = this.MinTextSpacing;
			tickInfo.DesiredIncrement = this.DesiredIncrement;
		}

		protected override void CalculateMajorTicks(ScaleTickInfo tickInfo)
		{
			if (this.DesiredIncrement != 0.0 && tickInfo.Span / this.DesiredIncrement <= (double)tickInfo.MaxTicks)
			{
				tickInfo.MajorCount = (int)(tickInfo.Span / this.DesiredIncrement);
				tickInfo.MajorStepSize = this.DesiredIncrement;
			}
			else if (tickInfo.TextFormatting.Style == TextFormatDoubleStyle.DateTime)
			{
				this.CalcDateTimeTicks(tickInfo);
			}
			else
			{
				this.CalcLinearTicks(tickInfo);
			}
			tickInfo.MinorStepSize = tickInfo.MajorStepSize / (double)(tickInfo.MinorCount + 1);
		}

		private ScaleTickLabel GetFirstTickLabel(ScaleTickInfo tickInfo)
		{
			int num = 0;
			while (true)
			{
				if (num < tickInfo.TickList.Count)
				{
					if (tickInfo.TickList[num] is ScaleTickLabel)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return tickInfo.TickList[num] as ScaleTickLabel;
		}

		private ScaleTickLabel GetLastTickLabel(ScaleTickInfo tickInfo)
		{
			int num = tickInfo.TickList.Count - 1;
			while (true)
			{
				if (num >= 0)
				{
					if (tickInfo.TickList[num] is ScaleTickLabel)
					{
						break;
					}
					num--;
					continue;
				}
				return null;
			}
			return tickInfo.TickList[num] as ScaleTickLabel;
		}

		protected override void Generate(PaintArgs p, ScaleTickInfo tickInfo)
		{
			base.Generate(p, tickInfo);
			if (this.FixedMinMaxMajors)
			{
				if (tickInfo.Display is ScaleDisplayLinear)
				{
					ScaleDisplayLinear scaleDisplayLinear = tickInfo.Display as ScaleDisplayLinear;
					ScaleTickLabel firstTickLabel = this.GetFirstTickLabel(tickInfo);
					if (firstTickLabel != null && scaleDisplayLinear.ValueToPixels(firstTickLabel.Value) - tickInfo.LabelMaxWidth < scaleDisplayLinear.PixelsMin)
					{
						tickInfo.TickList.Remove(firstTickLabel);
					}
					firstTickLabel = this.GetLastTickLabel(tickInfo);
					if (firstTickLabel != null && scaleDisplayLinear.ValueToPixels(firstTickLabel.Value) + tickInfo.LabelMaxWidth > scaleDisplayLinear.PixelsMax)
					{
						tickInfo.TickList.Remove(firstTickLabel);
					}
				}
				if (tickInfo.Display is ScaleDisplayAngular)
				{
					ScaleTickLabel firstTickLabel = this.GetFirstTickLabel(tickInfo);
					if (firstTickLabel != null)
					{
						tickInfo.TickList.Remove(firstTickLabel);
					}
					firstTickLabel = this.GetLastTickLabel(tickInfo);
					if (firstTickLabel != null)
					{
						tickInfo.TickList.Remove(firstTickLabel);
					}
				}
				tickInfo.Display.AddTickMajor(tickInfo.Display.Range.Min, false);
				tickInfo.Display.AddTickMajor(tickInfo.Display.Range.Max, false);
			}
		}
	}
}
