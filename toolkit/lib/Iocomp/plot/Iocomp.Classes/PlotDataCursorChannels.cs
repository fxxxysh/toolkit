using Iocomp.Types;
using System;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor Channels.")]
	public class PlotDataCursorChannels : PlotDataCursorBase
	{
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public new bool SnapToPoint
		{
			get
			{
				return base.SnapToPoint;
			}
			set
			{
				base.SnapToPoint = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public new string XAxisName
		{
			get
			{
				return base.XAxisName;
			}
			set
			{
				base.XAxisName = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public new string YAxisName
		{
			get
			{
				return base.YAxisName;
			}
			set
			{
				base.YAxisName = value;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double PositionX
		{
			get
			{
				return base.Pointer1.Position;
			}
			set
			{
				base.PropertyUpdateDefault("PositionX", value);
				if (this.PositionX != value)
				{
					base.Pointer1.Position = value;
					base.DoPropertyChange(this, "PositionX");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Data-Cursor Channels";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotDataCursorChannelsEditorPlugIn";
		}

		public PlotDataCursorChannels()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Channels";
			this.SnapToPoint = true;
			this.PositionX = 0.5;
			base.SetupPointersValueX();
		}

		private bool ShouldSerializeSnapToPoint()
		{
			return base.PropertyShouldSerialize("SnapToPoint");
		}

		private void ResetSnapToPoint()
		{
			base.PropertyReset("SnapToPoint");
		}

		private bool ShouldSerializeXAxisName()
		{
			return base.PropertyShouldSerialize("XAxisName");
		}

		private void ResetXAxisName()
		{
			base.PropertyReset("XAxisName");
		}

		private bool ShouldSerializeYAxisName()
		{
			return base.PropertyShouldSerialize("YAxisName");
		}

		private void ResetYAxisName()
		{
			base.PropertyReset("YAxisName");
		}

		private bool ShouldSerializePositionX()
		{
			return base.PropertyShouldSerialize("PositionX");
		}

		private void ResetPositionX()
		{
			base.PropertyReset("PositionX");
		}

		protected override void HintUpdate(PaintArgs p, PlotDataCursorDisplay display)
		{
			base.Hint.Text = display.XText + ", " + display.YText;
		}

		protected override void UpdateDisplays()
		{
			base.Displays.Clear();
			if (!(this.XAxisName == Const.EmptyString) && !(this.YAxisName == Const.EmptyString))
			{
				foreach (PlotChannelBase channel in base.Plot.Channels)
				{
					if (!(channel.XAxisName != this.XAxisName) && !(channel.YAxisName != this.YAxisName) && channel.Visible)
					{
						PlotDataCursorDisplay plotDataCursorDisplay = new PlotDataCursorDisplay();
						plotDataCursorDisplay.XPosition = base.Pointer1.Position;
						plotDataCursorDisplay.YPosition = base.Pointer2.Position;
						plotDataCursorDisplay.XValue = base.Pointer1.AxisPosition.PercentToValue(base.Pointer1.Position);
						plotDataCursorDisplay.YValue = base.Pointer2.AxisPosition.PercentToValue(base.Pointer2.Position);
						plotDataCursorDisplay.XText = base.Pointer1.AxisPosition.TextFormatting.GetText(plotDataCursorDisplay.XValue);
						plotDataCursorDisplay.YText = base.Pointer2.AxisPosition.TextFormatting.GetText(plotDataCursorDisplay.YValue);
						plotDataCursorDisplay.YStatus = PlotChannelInterpolationResult.Valid;
						plotDataCursorDisplay.HintPosition = base.Hint.Position;
						if (channel is PlotChannelConsecutive)
						{
							plotDataCursorDisplay.YStatus = channel.GetYInterpolated(plotDataCursorDisplay.XValue, out plotDataCursorDisplay.YValue);
							plotDataCursorDisplay.YText = base.Pointer2.AxisPosition.TextFormatting.GetText(plotDataCursorDisplay.YValue);
							if (plotDataCursorDisplay.YStatus == PlotChannelInterpolationResult.Valid)
							{
								plotDataCursorDisplay.YPosition = base.Pointer2.AxisPosition.ValueToPercent(plotDataCursorDisplay.YValue);
								plotDataCursorDisplay.HintPosition = plotDataCursorDisplay.YPosition;
							}
							else
							{
								if (plotDataCursorDisplay.YStatus == PlotChannelInterpolationResult.Empty)
								{
									plotDataCursorDisplay.YText = "Empty";
								}
								else if (plotDataCursorDisplay.YStatus == PlotChannelInterpolationResult.Invalid)
								{
									plotDataCursorDisplay.YText = "Invalid";
								}
								else if (plotDataCursorDisplay.YStatus == PlotChannelInterpolationResult.NoData)
								{
									plotDataCursorDisplay.YText = "NoData";
								}
								else if (plotDataCursorDisplay.YStatus == PlotChannelInterpolationResult.Null)
								{
									plotDataCursorDisplay.YText = "Invalid";
								}
								else if (plotDataCursorDisplay.YStatus == PlotChannelInterpolationResult.Valid)
								{
									plotDataCursorDisplay.YText = "Invalid";
								}
								else if (plotDataCursorDisplay.YStatus == PlotChannelInterpolationResult.Void)
								{
									plotDataCursorDisplay.YText = "Invalid";
								}
								else
								{
									plotDataCursorDisplay.YText = "Not Defined - Contact Iocomp for Update";
								}
								plotDataCursorDisplay.HintPosition = base.Pointer2.AxisPosition.ValueToPercent(channel.YMean);
								if (!base.Pointer2.AxisPosition.ValueVisible(plotDataCursorDisplay.HintPosition))
								{
									plotDataCursorDisplay.HintPosition = base.Pointer2.AxisPosition.ValueToPercent(base.Pointer2.AxisPosition.Mid);
								}
							}
						}
						channel.DataCursorX = plotDataCursorDisplay.XValue;
						channel.DataCursorY = plotDataCursorDisplay.YValue;
						base.Displays.Add(plotDataCursorDisplay);
					}
				}
			}
		}

		protected override void DoPointerLimits()
		{
			if (base.Pointer1.Position < 0.001)
			{
				base.Pointer1.Position = 0.001;
			}
			if (base.Pointer1.Position > 0.999)
			{
				base.Pointer1.Position = 0.999;
			}
		}

		private void UpdateDeltaMin(double targetValue, double newValue, ref double minDelta, ref double minValue)
		{
			double num = Math.Abs(targetValue - newValue);
			if (num < minDelta)
			{
				minValue = newValue;
				minDelta = num;
			}
		}

		public override void DoSnapToPoint()
		{
			if (!(this.XAxisName == Const.EmptyString) && !(this.YAxisName == Const.EmptyString))
			{
				double num = 1.7976931348623157E+308;
				double xValue = 0.0;
				double num2 = base.XAxis.PercentToValue(base.Pointer1.Position);
				foreach (PlotChannelBase channel in base.Plot.Channels)
				{
					if (!(channel.XAxisName != this.XAxisName) && !(channel.YAxisName != this.YAxisName) && channel is PlotChannelConsecutive)
					{
						if (num2 > channel.XMax)
						{
							this.UpdateDeltaMin(num2, channel.XMax, ref num, ref xValue);
						}
						else if (num2 < channel.XMin)
						{
							this.UpdateDeltaMin(num2, channel.XMax, ref num, ref xValue);
						}
						else
						{
							int num3 = (channel as PlotChannelConsecutive).CalculateXValueNearestIndex(num2);
							if (num3 != -1)
							{
								this.UpdateDeltaMin(num2, channel.GetX(num3), ref num, ref xValue);
							}
						}
					}
				}
				if (num != 1.7976931348623157E+308)
				{
					base.SnapPointer1To(xValue);
				}
			}
		}

		protected override void SetupPointers()
		{
			base.Pointer1.Style = PlotAxisReference.XAxis;
			base.Pointer2.Style = PlotAxisReference.YAxis;
			base.Pointer1.Visible = true;
			base.Pointer2.Visible = false;
		}
	}
}
