using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor XY.")]
	public class PlotDataCursorXY : PlotDataCursorMultipleBase
	{
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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

		protected override string GetPlugInTitle()
		{
			return "Data-Cursor XY";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotDataCursorXYEditorPlugIn";
		}

		public PlotDataCursorXY()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "XY";
			base.SnapToPoint = false;
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

		protected override void PopulateContextMenu(ContextMenu menu)
		{
			base.PopulateContextMenu(menu);
		}

		protected override void UpdateDisplays()
		{
			base.Displays.Clear();
			base.Display.XPosition = base.Pointer1.Position;
			base.Display.YPosition = base.Pointer2.Position;
			base.Display.XValue = base.Pointer1.AxisPosition.PercentToValue(base.Pointer1.Position);
			base.Display.YValue = base.Pointer2.AxisPosition.PercentToValue(base.Pointer2.Position);
			base.Display.XText = base.Pointer1.AxisPosition.TextFormatting.GetText(base.Display.XValue);
			base.Display.YText = base.Pointer2.AxisPosition.TextFormatting.GetText(base.Display.YValue);
			base.Display.YStatus = PlotChannelInterpolationResult.Valid;
			base.Display.HintPosition = base.Hint.Position;
			base.Display.DisableWindow = (base.Style != PlotDataCursorMultipleStyle.ValueXY);
			base.Displays.Add(base.Display);
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
			if (base.Pointer1.Position < 0.0)
			{
				base.Pointer1.Position = 0.0;
			}
			if (base.Pointer1.Position > 0.999)
			{
				base.Pointer1.Position = 0.999;
			}
			if (base.Pointer2.Position < 0.0)
			{
				base.Pointer2.Position = 0.0;
			}
			if (base.Pointer2.Position > 0.999)
			{
				base.Pointer2.Position = 0.999;
			}
		}

		protected override void SetupPointers()
		{
			if (base.Style == PlotDataCursorMultipleStyle.ValueX)
			{
				base.SetupPointersValueX();
			}
			else if (base.Style == PlotDataCursorMultipleStyle.ValueY)
			{
				base.SetupPointersValueY();
			}
			else if (base.Style == PlotDataCursorMultipleStyle.ValueXY)
			{
				base.SetupPointersValueXY();
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
		}
	}
}
