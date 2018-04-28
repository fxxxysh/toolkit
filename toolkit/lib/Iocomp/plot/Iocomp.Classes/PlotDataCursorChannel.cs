using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor Channel.")]
	public class PlotDataCursorChannel : PlotDataCursorChannelBase
	{
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public new bool HideHintOnDrag
		{
			get
			{
				return base.HideHintOnDrag;
			}
			set
			{
				base.HideHintOnDrag = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Data-Cursor Channel";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotDataCursorChannelEditorPlugIn";
		}

		public PlotDataCursorChannel()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Channel";
			this.SnapToPoint = true;
			this.HideHintOnDrag = false;
		}

		private bool ShouldSerializeSnapToPoint()
		{
			return base.PropertyShouldSerialize("SnapToPoint");
		}

		private void ResetSnapToPoint()
		{
			base.PropertyReset("SnapToPoint");
		}

		private bool ShouldSerializeHideHintOnDrag()
		{
			return base.PropertyShouldSerialize("HideHintOnDrag");
		}

		private void ResetHideHintOnDrag()
		{
			base.PropertyReset("HideHintOnDrag");
		}

		protected override void PopulateContextMenu(ContextMenu menu)
		{
			base.PopulateContextMenu(menu);
			MenuItem menuItem = new MenuItem();
			menuItem.Text = "Channel";
			menu.MenuItems.Add(menuItem);
			foreach (PlotChannelBase channel in base.Plot.Channels)
			{
				base.AddMenuItem(menuItem, channel.TitleText, this.MenuItemChannel_Click, base.ChannelName == channel.TitleText);
			}
		}

		protected void MovePointerNextDataPoint(int Offset)
		{
			PlotChannelConsecutive plotChannelConsecutive = base.Channel as PlotChannelConsecutive;
			if (plotChannelConsecutive != null && plotChannelConsecutive.Count != 0 && base.XAxis != null && base.YAxis != null && (base.Style != PlotDataCursorMultipleStyle.ValueY || base.YIsInterpolated) && base.Style != PlotDataCursorMultipleStyle.DeltaY && base.Style != PlotDataCursorMultipleStyle.InverseDeltaY)
			{
				bool flag = false;
				bool flag2 = false;
				bool flag3 = (Control.ModifierKeys & Keys.Control) == Keys.Control;
				if (base.Style == PlotDataCursorMultipleStyle.ValueXY)
				{
					flag = true;
					flag2 = false;
				}
				if (base.Style == PlotDataCursorMultipleStyle.ValueX)
				{
					flag = true;
					flag2 = false;
				}
				if (base.Style == PlotDataCursorMultipleStyle.ValueY)
				{
					flag = true;
					flag2 = false;
				}
				if (base.Style == PlotDataCursorMultipleStyle.DeltaX)
				{
					if (flag3)
					{
						flag = false;
						flag2 = true;
					}
					else
					{
						flag = true;
						flag2 = false;
					}
				}
				if (base.Style == PlotDataCursorMultipleStyle.InverseDeltaX)
				{
					if (flag3)
					{
						flag = false;
						flag2 = true;
					}
					else
					{
						flag = true;
						flag2 = false;
					}
				}
				if (plotChannelConsecutive != null)
				{
					if (flag)
					{
						double num = base.XAxis.PercentToValue(base.Pointer1.Position);
						if (num > plotChannelConsecutive.XLast)
						{
							base.SnapPointer1To(plotChannelConsecutive.XLast);
							return;
						}
						if (num < plotChannelConsecutive.XFirst)
						{
							base.SnapPointer1To(plotChannelConsecutive.XMin);
							return;
						}
						int num2 = plotChannelConsecutive.CalculateXValueNearestIndex(num) + Offset;
						if (num2 != -1)
						{
							base.SnapPointer1To(plotChannelConsecutive.GetX(num2));
						}
					}
					if (flag2)
					{
						double num = base.XAxis.PercentToValue(base.Pointer2.Position);
						if (num > plotChannelConsecutive.XLast)
						{
							base.SnapPointer2To(plotChannelConsecutive.XLast);
						}
						else if (num < plotChannelConsecutive.XFirst)
						{
							base.SnapPointer2To(plotChannelConsecutive.XMin);
						}
						else
						{
							int num2 = plotChannelConsecutive.CalculateXValueNearestIndex(num) + Offset;
							if (num2 != -1)
							{
								base.SnapPointer2To(plotChannelConsecutive.GetX(num2));
							}
						}
					}
				}
			}
		}

		protected override void InternalOnKeyDown(KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left)
			{
				this.MovePointerNextDataPoint(-1);
			}
			else if (e.KeyCode == Keys.Right)
			{
				this.MovePointerNextDataPoint(1);
			}
		}

		private void MenuItemChannel_Click(object sender, EventArgs e)
		{
			foreach (PlotChannelBase channel in base.Plot.Channels)
			{
				if (!(channel.TitleText == (sender as MenuItem).Text))
				{
					continue;
				}
				base.ChannelName = channel.Name;
				break;
			}
		}

		protected override void InternalOnLostFocus(LostFocusEventArgs e)
		{
			if (e.NewFocusObject != null && e.NewFocusObject is PlotChannelBase)
			{
				PlotChannelBase plotChannelBase = e.NewFocusObject as PlotChannelBase;
				base.ChannelName = plotChannelBase.Name;
			}
		}

		protected override void UpdateDisplays()
		{
			base.Displays.Clear();
			PlotChannelBase channel = base.Channel;
			if (channel != null)
			{
				bool flag = false;
				if (base.Style == PlotDataCursorMultipleStyle.ValueXY)
				{
					flag = true;
				}
				if (base.Style == PlotDataCursorMultipleStyle.ValueX)
				{
					flag = true;
				}
				if (base.Style == PlotDataCursorMultipleStyle.ValueY)
				{
					flag = true;
				}
				base.Display.XPosition = base.Pointer1.Position;
				base.Display.YPosition = base.Pointer2.Position;
				base.Display.XValue = base.Pointer1.AxisPosition.PercentToValue(base.Pointer1.Position);
				base.Display.YValue = base.Pointer2.AxisPosition.PercentToValue(base.Pointer2.Position);
				base.Display.XText = base.Pointer1.AxisPosition.TextFormatting.GetText(base.Display.XValue);
				base.Display.YText = base.Pointer2.AxisPosition.TextFormatting.GetText(base.Display.YValue);
				base.Display.YStatus = PlotChannelInterpolationResult.Valid;
				base.Display.HintPosition = base.Hint.Position;
				if (channel is PlotChannelConsecutive && flag)
				{
					base.Display.YStatus = channel.GetYInterpolated(base.Display.XValue, out base.Display.YValue);
					if (base.Display.YStatus == PlotChannelInterpolationResult.Valid)
					{
						base.Display.YText = channel.GetYValueText(base.Display.YValue);
						((ISubClassBase)base.Pointer2).FreezePropertyChange = true;
						base.Pointer2.Position = base.Pointer2.AxisPosition.ValueToPercent(channel.GetYValueAxisValue(base.Display.YValue));
						((ISubClassBase)base.Pointer2).FreezePropertyChange = false;
						base.Display.YPosition = base.Pointer2.Position;
					}
					else
					{
						if (base.Display.YStatus == PlotChannelInterpolationResult.Empty)
						{
							base.Display.YText = "Empty";
						}
						else if (base.Display.YStatus == PlotChannelInterpolationResult.Invalid)
						{
							base.Display.YText = "Invalid";
						}
						else if (base.Display.YStatus == PlotChannelInterpolationResult.NoData)
						{
							base.Display.YText = "NoData";
						}
						else if (base.Display.YStatus == PlotChannelInterpolationResult.Null)
						{
							base.Display.YText = "Null";
						}
						else if (base.Display.YStatus == PlotChannelInterpolationResult.Valid)
						{
							base.Display.YText = "Invalid";
						}
						else if (base.Display.YStatus == PlotChannelInterpolationResult.Void)
						{
							base.Display.YText = "Invalid";
						}
						else
						{
							base.Display.YText = "Not Defined - Contact Iocomp for Update";
						}
						base.Display.YPosition = base.Pointer2.AxisPosition.ValueToPercent(channel.GetYValueAxisValue(channel.YMean));
						((ISubClassBase)base.Pointer2).FreezePropertyChange = true;
						base.Pointer2.Position = base.Display.YPosition;
						((ISubClassBase)base.Pointer2).FreezePropertyChange = false;
					}
				}
				channel.DataCursorX = base.Display.XValue;
				channel.DataCursorY = base.Display.YValue;
				base.Displays.Add(base.Display);
			}
		}

		protected override void HintUpdate(PaintArgs p, PlotDataCursorDisplay display)
		{
			if (base.Style == PlotDataCursorMultipleStyle.ValueXY)
			{
				base.Hint.Text = display.XText + ", " + display.YText;
			}
			if (base.Style == PlotDataCursorMultipleStyle.ValueX)
			{
				base.Hint.Text = display.XText;
			}
			if (base.Style == PlotDataCursorMultipleStyle.ValueY)
			{
				base.Hint.Text = display.YText;
			}
			if (base.Style == PlotDataCursorMultipleStyle.DeltaX)
			{
				base.Hint.Text = base.Pointer1.AxisPosition.TextFormatting.GetText(Math.Abs(display.XValue - display.YValue));
			}
			if (base.Style == PlotDataCursorMultipleStyle.DeltaY)
			{
				base.Hint.Text = base.Pointer1.AxisPosition.TextFormatting.GetText(Math.Abs(display.XValue - display.YValue));
			}
			if (base.Style == PlotDataCursorMultipleStyle.InverseDeltaX)
			{
				base.Hint.Text = base.Pointer1.AxisPosition.TextFormatting.GetText(1.0 / Math.Abs(display.XValue - display.YValue) * base.Pointer1.AxisPosition.CursorScaler);
			}
			if (base.Style == PlotDataCursorMultipleStyle.InverseDeltaY)
			{
				base.Hint.Text = base.Pointer1.AxisPosition.TextFormatting.GetText(1.0 / Math.Abs(display.XValue - display.YValue) * base.Pointer1.AxisPosition.CursorScaler);
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
			if (base.Style != 0)
			{
				if (base.Pointer2.Position < 0.001)
				{
					base.Pointer2.Position = 0.001;
				}
				if (base.Pointer2.Position > 0.999)
				{
					base.Pointer2.Position = 0.999;
				}
			}
		}

		protected override void SetupPointers()
		{
			PlotChannelBase channel = base.Channel;
			bool visible;
			if (channel != null)
			{
				if (channel is PlotChannelConsecutive)
				{
					base.YIsInterpolated = true;
				}
				else
				{
					base.YIsInterpolated = false;
				}
				visible = (!(channel is PlotChannelDigital) && true);
			}
			else
			{
				base.YIsInterpolated = false;
				visible = false;
			}
			if (base.Style == PlotDataCursorMultipleStyle.ValueX)
			{
				base.SetupPointersValueX();
			}
			else if (base.Style == PlotDataCursorMultipleStyle.DeltaX)
			{
				base.SetupPointersDeltaX();
			}
			else if (base.Style == PlotDataCursorMultipleStyle.DeltaY)
			{
				base.SetupPointersDeltaY();
			}
			else if (base.Style == PlotDataCursorMultipleStyle.InverseDeltaX)
			{
				base.SetupPointersInverseDeltaX();
			}
			else if (base.Style == PlotDataCursorMultipleStyle.InverseDeltaY)
			{
				base.SetupPointersInverseDeltaY();
			}
			else if (!base.YIsInterpolated)
			{
				if (base.Style == PlotDataCursorMultipleStyle.ValueXY)
				{
					base.SetupPointersValueXY();
				}
				else if (base.Style == PlotDataCursorMultipleStyle.ValueY)
				{
					base.SetupPointersValueY();
				}
			}
			else if (base.Style == PlotDataCursorMultipleStyle.ValueXY)
			{
				base.Pointer1.Style = PlotAxisReference.XAxis;
				base.Pointer2.Style = PlotAxisReference.YAxis;
				base.Pointer1.Visible = true;
				base.Pointer2.Visible = visible;
			}
			else if (base.Style == PlotDataCursorMultipleStyle.ValueY)
			{
				base.Pointer1.Style = PlotAxisReference.XAxis;
				base.Pointer2.Style = PlotAxisReference.YAxis;
				base.Pointer1.Visible = true;
				base.Pointer2.Visible = false;
			}
		}

		public override void DoSnapToPoint()
		{
			PlotChannelConsecutive plotChannelConsecutive = base.Channel as PlotChannelConsecutive;
			if (plotChannelConsecutive != null && base.XAxis != null && base.YAxis != null && (base.Style != PlotDataCursorMultipleStyle.ValueY || base.YIsInterpolated) && base.Style != PlotDataCursorMultipleStyle.DeltaY && base.Style != PlotDataCursorMultipleStyle.InverseDeltaY && plotChannelConsecutive.Count != 0)
			{
				bool flag = false;
				bool flag2 = false;
				if (base.Style == PlotDataCursorMultipleStyle.ValueXY)
				{
					flag = true;
					flag2 = false;
				}
				if (base.Style == PlotDataCursorMultipleStyle.ValueX)
				{
					flag = true;
					flag2 = false;
				}
				if (base.Style == PlotDataCursorMultipleStyle.ValueY)
				{
					flag = true;
					flag2 = false;
				}
				if (base.Style == PlotDataCursorMultipleStyle.DeltaX)
				{
					flag = true;
					flag2 = true;
				}
				if (base.Style == PlotDataCursorMultipleStyle.InverseDeltaX)
				{
					flag = true;
					flag2 = true;
				}
				if (plotChannelConsecutive != null)
				{
					if (flag)
					{
						double num = base.XAxis.PercentToValue(base.Pointer1.Position);
						if (num > plotChannelConsecutive.XLast)
						{
							base.SnapPointer1To(plotChannelConsecutive.XLast);
							return;
						}
						if (num < plotChannelConsecutive.XFirst)
						{
							base.SnapPointer1To(plotChannelConsecutive.XMin);
							return;
						}
						int num2 = plotChannelConsecutive.CalculateXValueNearestIndex(num);
						if (num2 != -1)
						{
							base.SnapPointer1To(plotChannelConsecutive.GetX(num2));
						}
					}
					if (flag2)
					{
						double num = base.XAxis.PercentToValue(base.Pointer2.Position);
						if (num > plotChannelConsecutive.XLast)
						{
							base.SnapPointer2To(plotChannelConsecutive.XLast);
						}
						else if (num < plotChannelConsecutive.XFirst)
						{
							base.SnapPointer2To(plotChannelConsecutive.XMin);
						}
						else
						{
							int num2 = plotChannelConsecutive.CalculateXValueNearestIndex(num);
							if (num2 != -1)
							{
								base.SnapPointer2To(plotChannelConsecutive.GetX(num2));
							}
						}
					}
				}
			}
		}
	}
}
