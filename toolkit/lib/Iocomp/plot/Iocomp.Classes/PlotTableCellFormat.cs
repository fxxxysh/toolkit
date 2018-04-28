using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[Description("Plot Table Cell Format.")]
	public class PlotTableCellFormat : SubClassBase, IPlotTableCellFormat
	{
		private TextLayoutFull m_TextLayout;

		protected ITextLayoutFull I_TextLayout;

		private PlotBrush m_Background;

		protected IPlotBrush I_Background;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("")]
		public TextLayoutFull TextLayout
		{
			get
			{
				return this.m_TextLayout;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotBrush Background
		{
			get
			{
				return this.m_Background;
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		public new Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Table Cell Format";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotTableCellFormatEditorPlugIn";
		}

		void IPlotTableCellFormat.Draw(PaintArgs p, Rectangle r)
		{
			this.Draw(p, r);
		}

		public PlotTableCellFormat()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_TextLayout = new TextLayoutFull();
			base.AddSubClass(this.TextLayout);
			this.I_TextLayout = this.TextLayout;
			this.m_Background = new PlotBrush();
			base.AddSubClass(this.Background);
			this.I_Background = this.Background;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.ForeColor = Color.Empty;
			this.Font = null;
			this.TextLayout.Trimming = StringTrimming.None;
			this.TextLayout.LineLimit = false;
			this.TextLayout.MeasureTrailingSpaces = false;
			this.TextLayout.NoWrap = false;
			this.TextLayout.NoClip = false;
			this.TextLayout.AlignmentHorizontal.Style = StringAlignment.Center;
			this.TextLayout.AlignmentHorizontal.Margin = 0.0;
			this.TextLayout.AlignmentVertical.Style = StringAlignment.Center;
			this.TextLayout.AlignmentVertical.Margin = 0.0;
			this.Background.Visible = false;
			this.Background.Style = PlotBrushStyle.Solid;
			this.Background.SolidColor = Color.Empty;
			this.Background.GradientStartColor = Color.Blue;
			this.Background.GradientStopColor = Color.Aqua;
			this.Background.HatchForeColor = Color.Empty;
			this.Background.HatchBackColor = Color.Empty;
		}

		private bool ShouldSerializeTextLayout()
		{
			return ((ISubClassBase)this.TextLayout).ShouldSerialize();
		}

		private void ResetTextLayout()
		{
			((ISubClassBase)this.TextLayout).ResetToDefault();
		}

		private bool ShouldSerializeBackground()
		{
			return ((ISubClassBase)this.Background).ShouldSerialize();
		}

		private void ResetBackground()
		{
			((ISubClassBase)this.Background).ResetToDefault();
		}

		private bool ShouldSerializeFont()
		{
			return base.PropertyShouldSerialize("Font");
		}

		private void ResetFont()
		{
			base.PropertyReset("Font");
		}

		private bool ShouldSerializeForeColor()
		{
			return base.PropertyShouldSerialize("ForeColor");
		}

		private void ResetForeColor()
		{
			base.PropertyReset("ForeColor");
		}

		private void Draw(PaintArgs p, Rectangle r)
		{
			if (this.Background.Visible)
			{
				p.Graphics.FillRectangle(((IPlotBrush)this.Background).GetBrush(p, r), r);
			}
		}
	}
}
