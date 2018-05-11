using Iocomp.Interfaces;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor Hint")]
	public class PlotDataCursorHint : SubClassBase, IPlotDataCursorHint
	{
		private PlotDataCursorBase m_DataCursor;

		private double m_Position;

		private bool m_HideOnRelease;

		private bool m_Hide;

		private PlotFill m_Fill;

		private IPlotFill I_Fill;

		private string m_Text;

		private Region m_HitRegion;

		private bool m_MouseActive;

		private double m_MouseDownPosition;

		private double m_MouseDownActual;

		private PlotAxis m_AxisPosition;

		Region IPlotDataCursorHint.HitRegion
		{
			get
			{
				return this.m_HitRegion;
			}
			set
			{
				this.m_HitRegion = value;
			}
		}

		bool IPlotDataCursorHint.MouseActive
		{
			get
			{
				return this.m_MouseActive;
			}
			set
			{
				this.m_MouseActive = value;
			}
		}

		double IPlotDataCursorHint.MouseDownPosition
		{
			get
			{
				return this.m_MouseDownPosition;
			}
			set
			{
				this.m_MouseDownPosition = value;
			}
		}

		double IPlotDataCursorHint.MouseDownActual
		{
			get
			{
				return this.m_MouseDownActual;
			}
			set
			{
				this.m_MouseDownActual = value;
			}
		}

		PlotAxis IPlotDataCursorHint.AxisPosition
		{
			get
			{
				return this.m_AxisPosition;
			}
			set
			{
				this.m_AxisPosition = value;
			}
		}

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public PlotFill Fill
		{
			get
			{
				return this.m_Fill;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool Enabled
		{
			get
			{
				return base.EnabledInternal;
			}
			set
			{
				base.EnabledInternal = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double Position
		{
			get
			{
				return this.m_Position;
			}
			set
			{
				base.PropertyUpdateDefault("Position", value);
				value = Math2.Clamp(value, 0.02, 0.98);
				if (this.Position != value)
				{
					this.m_Position = value;
					base.DoPropertyChange(this, "Position");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool HideOnRelease
		{
			get
			{
				return this.m_HideOnRelease;
			}
			set
			{
				base.PropertyUpdateDefault("HideOnRelease", value);
				if (this.HideOnRelease != value)
				{
					this.m_HideOnRelease = value;
					base.DoPropertyChange(this, "HideOnRelease");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		public bool Hide
		{
			get
			{
				return this.m_Hide;
			}
			set
			{
				base.PropertyUpdateDefault("Hide", value);
				if (this.Hide != value)
				{
					this.m_Hide = value;
					base.DoPropertyChange(this, "Hide");
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string Text
		{
			get
			{
				return this.m_Text;
			}
			set
			{
				this.m_Text = value;
			}
		}

		private PlotXAxis XAxis
		{
			get
			{
				if (this.DataCursor == null)
				{
					return null;
				}
				return this.DataCursor.XAxis;
			}
		}

		private PlotYAxis YAxis
		{
			get
			{
				if (this.DataCursor == null)
				{
					return null;
				}
				return this.DataCursor.YAxis;
			}
		}

		private PlotDataCursorBase DataCursor => this.m_DataCursor;

		private Region HitRegion
		{
			get
			{
				return this.m_HitRegion;
			}
			set
			{
				this.m_HitRegion = value;
			}
		}

		private PlotAxis AxisPosition
		{
			get
			{
				return this.m_AxisPosition;
			}
			set
			{
				this.m_AxisPosition = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Data-Cursor Hint";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotDataCursorHintEditorPlugIn";
		}

		void IPlotDataCursorHint.Draw(PaintArgs p, PlotDataCursorDisplay display)
		{
			this.Draw(p, display);
		}

		public PlotDataCursorHint()
		{
			base.DoCreate();
		}

		public PlotDataCursorHint(PlotDataCursorBase value)
		{
			this.m_DataCursor = value;
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Fill = new PlotFill();
			base.AddSubClass(this.Fill);
			this.I_Fill = this.Fill;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Visible = true;
			this.Enabled = true;
			this.ForeColor = SystemColors.InfoText;
			this.Font = null;
			this.Position = 0.5;
			this.HideOnRelease = false;
			this.Fill.Brush.SolidColor = SystemColors.Info;
			this.Fill.Pen.Color = SystemColors.InfoText;
		}

		private bool ShouldSerializeFill()
		{
			return ((ISubClassBase)this.Fill).ShouldSerialize();
		}

		private void ResetFill()
		{
			((ISubClassBase)this.Fill).ResetToDefault();
		}

		private bool ShouldSerializeEnabled()
		{
			return base.PropertyShouldSerialize("Enabled");
		}

		private void ResetEnabled()
		{
			base.PropertyReset("Enabled");
		}

		private bool ShouldSerializeForeColor()
		{
			return base.PropertyShouldSerialize("ForeColor");
		}

		private void ResetForeColor()
		{
			base.PropertyReset("ForeColor");
		}

		private bool ShouldSerializeFont()
		{
			return base.PropertyShouldSerialize("Font");
		}

		private void ResetFont()
		{
			base.PropertyReset("Font");
		}

		private bool ShouldSerializePosition()
		{
			return base.PropertyShouldSerialize("Position");
		}

		private void ResetPosition()
		{
			base.PropertyReset("Position");
		}

		private bool ShouldSerializeHideOnRelease()
		{
			return base.PropertyShouldSerialize("HideOnRelease");
		}

		private void ResetHideOnRelease()
		{
			base.PropertyReset("HideOnRelease");
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		private void DrawHintBox(PaintArgs p, Rectangle r)
		{
			DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
			genericTypographic.Alignment = StringAlignment.Center;
			genericTypographic.LineAlignment = StringAlignment.Center;
			this.I_Fill.Draw(p, r);
			p.Graphics.DrawString(this.Text, this.Font, p.Graphics.Brush(this.ForeColor), r, genericTypographic);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddRectangle(Rectangle.Intersect(this.DataCursor.BoundsClip, r));
			this.HitRegion = new Region(graphicsPath);
			if (this.DataCursor.Focused)
			{
				r.Inflate(-3, -3);
				p.Graphics.DrawFocusRectangle(r, this.Fill.Brush.SolidColor);
			}
		}

		private void Draw(PaintArgs p, PlotDataCursorDisplay display)
		{
			int num = 3;
			if (this.DataCursor.WindowShowing)
			{
				num += this.DataCursor.Window.Size;
			}
			if (this.HitRegion != null)
			{
				this.HitRegion.Dispose();
				this.HitRegion = null;
			}
			if (this.Visible && !this.Hide && this.DataCursor != null && this.XAxis != null && this.YAxis != null)
			{
				PlotDataCursorPointer pointer = this.DataCursor.Pointer1;
				PlotDataCursorPointer pointer2 = this.DataCursor.Pointer2;
				Pen pen = p.Graphics.Pen(this.DataCursor.Line.Color, DashStyle.Dash, (float)this.DataCursor.Line.Thickness);
				bool flag;
				int num2;
				if (pointer.Visible && pointer2.Visible && pointer.AxisPosition == pointer2.AxisPosition)
				{
					flag = true;
					this.AxisPosition = pointer.AxisRange;
					num2 = (pointer.PositionPixels + pointer2.PositionPixels) / 2;
				}
				else if (pointer.Visible && pointer2.Visible)
				{
					flag = false;
					if (pointer.AxisRange.DockHorizontal)
					{
						this.AxisPosition = pointer.AxisRange;
						num2 = pointer.PositionPixels;
					}
					else
					{
						this.AxisPosition = pointer2.AxisRange;
						num2 = pointer2.PositionPixels;
					}
				}
				else
				{
					flag = false;
					if (pointer.Visible)
					{
						this.AxisPosition = pointer.AxisRange;
						num2 = pointer.AxisPosition.PercentToPixels(display.XPosition);
					}
					else
					{
						this.AxisPosition = pointer2.AxisRange;
						num2 = pointer2.AxisPosition.PercentToPixels(display.YPosition);
					}
				}
				Orientation orientation = this.AxisPosition.DockHorizontal ? Orientation.Vertical : Orientation.Horizontal;
				Size size = p.Graphics.MeasureString(this.Text, this.Font);
				int width = size.Width;
				int height = size.Height;
				int num3 = width + 6;
				int num4 = height + 6;
				int num5 = this.AxisPosition.PercentToPixels(display.HintPosition);
				Rectangle r;
				if (orientation == Orientation.Vertical)
				{
					int num6 = width + num + 6;
					r = new Rectangle(num2 - num3 / 2, num5 - num4 / 2, num3, num4);
					if (!flag)
					{
						if (num2 + num6 > this.DataCursor.BoundsClip.Right)
						{
							r.Offset(-(num3 / 2 + num), 0);
						}
						else
						{
							r.Offset(num3 / 2 + num, 0);
						}
					}
					else
					{
						p.Graphics.DrawLine(pen, pointer.PositionPixels, num5, pointer2.PositionPixels, num5);
					}
				}
				else
				{
					int num6 = height + num + 6;
					r = new Rectangle(num5 - num3 / 2, num2 - num4 / 2, num3, num4);
					if (!flag)
					{
						if (num2 + num6 > this.DataCursor.BoundsClip.Bottom)
						{
							r.Offset(0, -(num4 / 2 + num));
						}
						else
						{
							r.Offset(0, num4 / 2 + num);
						}
					}
					else
					{
						p.Graphics.DrawLine(pen, num5, pointer.PositionPixels, num5, pointer2.PositionPixels);
					}
				}
				this.DrawHintBox(p, r);
			}
		}
	}
}
