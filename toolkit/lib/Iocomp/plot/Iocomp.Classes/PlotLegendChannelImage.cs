using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Iocomp.Classes
{
	[Description("Legend used to display a color gradient for an Image type channel")]
	public class PlotLegendChannelImage : PlotLegendBase
	{
		private string m_ChannelName;

		private int m_MarginOuterPixels;

		private int m_LengthPixels;

		private int m_GradientWidth;

		private int m_GradientMinHeight;

		private bool m_TicksVisible;

		private int m_TicksLength;

		private int m_TicksMargin;

		private double m_TicksLabelMargin;

		private bool m_TicksShowFirstAndLastOnly;

		private ArrayList m_Ticks;

		private Size m_MaxSizeTickLabels;

		private int m_TicksLabelMarginPixels;

		private TextFormatDouble m_TextFormat;

		private Color[] m_Colors;

		private float[] m_Positions;

		private int m_EndsMargin;

		private PlotChannelImage m_CachedChannel;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public TextFormatDouble TextFormat
		{
			get
			{
				return this.m_TextFormat;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int GradientWidth
		{
			get
			{
				return this.m_GradientWidth;
			}
			set
			{
				base.PropertyUpdateDefault("GradientWidth", value);
				if (this.GradientWidth != value)
				{
					this.m_GradientWidth = value;
					base.DoPropertyChange(this, "GradientWidth");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int GradientMinHeight
		{
			get
			{
				return this.m_GradientMinHeight;
			}
			set
			{
				base.PropertyUpdateDefault("GradientMinHeight", value);
				if (this.GradientMinHeight != value)
				{
					this.m_GradientMinHeight = value;
					base.DoPropertyChange(this, "GradientMinHeight");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool TicksVisible
		{
			get
			{
				return this.m_TicksVisible;
			}
			set
			{
				base.PropertyUpdateDefault("TicksVisible", value);
				if (this.TicksVisible != value)
				{
					this.m_TicksVisible = value;
					base.DoPropertyChange(this, "TicksVisible");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public bool TicksShowFirstAndLastOnly
		{
			get
			{
				return this.m_TicksShowFirstAndLastOnly;
			}
			set
			{
				base.PropertyUpdateDefault("TicksShowFirstAndLastOnly", value);
				if (this.TicksShowFirstAndLastOnly != value)
				{
					this.m_TicksShowFirstAndLastOnly = value;
					base.DoPropertyChange(this, "TicksShowFirstAndLastOnly");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int TicksLength
		{
			get
			{
				return this.m_TicksLength;
			}
			set
			{
				base.PropertyUpdateDefault("TicksLength", value);
				if (this.TicksLength != value)
				{
					this.m_TicksLength = value;
					base.DoPropertyChange(this, "TicksLength");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int TicksMargin
		{
			get
			{
				return this.m_TicksMargin;
			}
			set
			{
				base.PropertyUpdateDefault("TicksMargin", value);
				if (this.TicksMargin != value)
				{
					this.m_TicksMargin = value;
					base.DoPropertyChange(this, "TicksMargin");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public double TicksLabelMargin
		{
			get
			{
				return this.m_TicksLabelMargin;
			}
			set
			{
				base.PropertyUpdateDefault("TicksLabelMargin", value);
				if (this.TicksLabelMargin != value)
				{
					this.m_TicksLabelMargin = value;
					base.DoPropertyChange(this, "TicksLabelMargin");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public string ChannelName
		{
			get
			{
				if (this.m_ChannelName == null)
				{
					return Const.EmptyString;
				}
				return this.m_ChannelName;
			}
			set
			{
				if (value == null)
				{
					value = Const.EmptyString;
				}
				value = value.Trim();
				base.PropertyUpdateDefault("ChannelName", value);
				if (this.ChannelName != value)
				{
					this.m_ChannelName = value;
					this.m_CachedChannel = null;
					this.m_CachedChannel = this.Channel;
					base.DoPropertyChange(this, "ChannelName");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PlotChannelImage Channel
		{
			get
			{
				if (this.m_CachedChannel != null)
				{
					return this.m_CachedChannel;
				}
				if (base.Plot == null)
				{
					return null;
				}
				this.m_CachedChannel = base.Plot.Channels.Image[this.ChannelName];
				return this.m_CachedChannel;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Legend Channel Image";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotLegendChannelImageEditorPlugIn";
		}

		public PlotLegendChannelImage()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_TextFormat = new TextFormatDouble();
			base.AddSubClass(this.TextFormat);
			this.m_Ticks = new ArrayList();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "ChannelImage";
			base.DockAutoSizeAlignment = PlotDockAutoSizeAlignment.None;
			this.GradientWidth = 15;
			this.GradientMinHeight = 75;
			this.TicksVisible = true;
			this.TicksLength = 7;
			this.TicksMargin = 7;
			this.TicksLabelMargin = 0.5;
		}

		private bool ShouldSerializeTextFormat()
		{
			return ((ISubClassBase)this.TextFormat).ShouldSerialize();
		}

		private void ResetTextFormat()
		{
			((ISubClassBase)this.TextFormat).ResetToDefault();
		}

		private bool ShouldSerializeGradientWidth()
		{
			return base.PropertyShouldSerialize("GradientWidth");
		}

		private void ResetGradientWidth()
		{
			base.PropertyReset("GradientWidth");
		}

		private bool ShouldSerializeGradientMinHeight()
		{
			return base.PropertyShouldSerialize("GradientMinHeight");
		}

		private void ResetGradientMinHeight()
		{
			base.PropertyReset("GradientMinHeight");
		}

		private bool ShouldSerializeTicksVisible()
		{
			return base.PropertyShouldSerialize("TicksVisible");
		}

		private void ResetTicksVisible()
		{
			base.PropertyReset("TicksVisible");
		}

		private bool ShouldSerializeTicksShowFirstAndLastOnly()
		{
			return base.PropertyShouldSerialize("TicksShowFirstAndLastOnly");
		}

		private void ResetTicksShowFirstAndLastOnly()
		{
			base.PropertyReset("TicksShowFirstAndLastOnly");
		}

		private bool ShouldSerializeTicksLength()
		{
			return base.PropertyShouldSerialize("TicksLength");
		}

		private void ResetTicksLength()
		{
			base.PropertyReset("TicksLength");
		}

		private bool ShouldSerializeTicksMargin()
		{
			return base.PropertyShouldSerialize("TicksMargin");
		}

		private void ResetTicksMargin()
		{
			base.PropertyReset("TicksMargin");
		}

		private bool ShouldSerializeTicksLabelMargin()
		{
			return base.PropertyShouldSerialize("TicksLabelMargin");
		}

		private void ResetTicksLabelMargin()
		{
			base.PropertyReset("TicksLabelMargin");
		}

		private bool ShouldSerializeChannelName()
		{
			return base.PropertyShouldSerialize("ChannelName");
		}

		private void ResetChannelName()
		{
			base.PropertyReset("ChannelName");
		}

		public override void ObjectRenamed(PlotObject value, string oldName)
		{
			base.ObjectRenamed(value, oldName);
			if (value is PlotChannelBase && oldName == this.m_ChannelName)
			{
				this.m_ChannelName = value.Name;
			}
		}

		public override void ObjectRemoved(PlotObject value)
		{
			base.ObjectRemoved(value);
			if (value == this.m_CachedChannel)
			{
				this.m_CachedChannel = null;
			}
		}

		public override void ObjectAdded(PlotObject value)
		{
			base.ObjectAdded(value);
			if (value is PlotChannelImage && value.Name == this.m_ChannelName)
			{
				this.m_CachedChannel = (value as PlotChannelImage);
			}
		}

		protected override void PopulateContextMenu(ContextMenu menu)
		{
			base.PopulateContextMenu(menu);
			base.AddMenuItem(menu, "Edit Channel", this.MenuItemEditChannel_Click, false);
		}

		private void MenuItemEditChannel_Click(object sender, EventArgs e)
		{
			this.Channel.ShowEditorCustom(false, true);
		}

		private void GenerateTicks(PaintArgs p, PlotChannelImage channel)
		{
			this.m_Ticks.Clear();
			this.m_MaxSizeTickLabels = Size.Empty;
			double num = channel.IntensityGradient.Span / (double)(this.m_Positions.Length - 1);
			for (int i = 0; i < this.m_Positions.Length; i++)
			{
				double value = channel.IntensityGradient.Min + (double)i * num;
				string text = this.m_TextFormat.GetText(value);
				this.m_MaxSizeTickLabels = Math2.Max(this.m_MaxSizeTickLabels, p.Graphics.MeasureString(text, base.Font));
				this.m_Ticks.Add(text);
			}
		}

		protected override void CalculateDepthPixels(PaintArgs p)
		{
			this.m_MarginOuterPixels = (int)Math.Ceiling((double)p.Graphics.MeasureString(base.Font).Height * base.MarginOuter);
			this.m_TicksLabelMarginPixels = (int)((double)p.Graphics.MeasureString(base.Font).Width * this.TicksLabelMargin);
			this.m_LengthPixels = 100;
			PlotChannelImage channel = this.Channel;
			if (channel != null)
			{
				this.m_Colors = channel.IntensityGradient.Colors;
				this.m_Positions = channel.IntensityGradient.Positions;
				this.GenerateTicks(p, channel);
				this.m_EndsMargin = this.m_MarginOuterPixels + (int)Math.Ceiling((double)this.m_MaxSizeTickLabels.Height / 2.0);
				if (base.DockHorizontal)
				{
					this.m_LengthPixels += 2 * this.m_EndsMargin + this.GradientMinHeight;
				}
				else
				{
					this.m_LengthPixels += 2 * this.m_EndsMargin + this.GradientMinHeight;
				}
				base.DockDepthPixels = this.GradientWidth;
				if (this.TicksVisible)
				{
					base.DockDepthPixels += this.TicksMargin + this.TicksLength + this.m_TicksLabelMarginPixels + this.m_MaxSizeTickLabels.Width;
				}
				base.DockDepthPixels += 2 * this.m_MarginOuterPixels;
			}
		}

		protected override void DrawCalculations(PaintArgs p)
		{
			base.CalculateBoundsAlignment(this.m_LengthPixels);
		}

		private Bitmap GetGradientBitmap(int length, bool swapped)
		{
			Bitmap bitmap;
			Rectangle rect;
			LinearGradientBrush linearGradientBrush;
			if (!swapped)
			{
				bitmap = new Bitmap(this.GradientWidth, length);
				rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				linearGradientBrush = new LinearGradientBrush(rect, Color.Orange, Color.Yellow, LinearGradientMode.Vertical);
			}
			else
			{
				bitmap = new Bitmap(length, this.GradientWidth);
				rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
				linearGradientBrush = new LinearGradientBrush(rect, Color.Orange, Color.Yellow, LinearGradientMode.Horizontal);
			}
			ColorBlend colorBlend = new ColorBlend();
			colorBlend.Colors = this.m_Colors;
			colorBlend.Positions = this.m_Positions;
			linearGradientBrush.InterpolationColors = colorBlend;
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.FillRectangle(linearGradientBrush, rect);
			graphics.Dispose();
			linearGradientBrush.Dispose();
			return bitmap;
		}

		private Bitmap GetStepBitmap(int length, bool swapped)
		{
			Bitmap bitmap = swapped ? new Bitmap(length, this.GradientWidth) : new Bitmap(this.GradientWidth, length);
			Graphics graphics = Graphics.FromImage(bitmap);
			for (int i = 0; i < this.m_Colors.Length - 1; i++)
			{
				int num = (int)(this.m_Positions[i] * (float)length);
				int num2 = (int)(this.m_Positions[i + 1] * (float)length);
				Rectangle rect = swapped ? Rectangle.FromLTRB(num, 0, num2, this.GradientWidth - 1) : Rectangle.FromLTRB(0, num, this.GradientWidth - 1, num2);
				SolidBrush solidBrush = new SolidBrush(this.m_Colors[i]);
				graphics.FillRectangle(solidBrush, rect);
				solidBrush.Dispose();
			}
			graphics.Dispose();
			return bitmap;
		}

		protected override void Draw(PaintArgs p)
		{
			base.I_Fill.Draw(p, base.BoundsAlignment);
			PlotChannelImage channel = this.Channel;
			if (channel != null)
			{
				Rectangle r = base.BoundsAlignment;
				r.Inflate(-this.m_MarginOuterPixels, -this.m_MarginOuterPixels);
				bool dockVertical;
				if (!(dockVertical = base.DockVertical))
				{
					r.Inflate(0, -this.m_EndsMargin);
				}
				else
				{
					r.Inflate(-this.m_EndsMargin, 0);
				}
				int num = 0;
				int num2 = 0;
				dockVertical = base.DockVertical;
				int left = r.Left;
				int right = r.Right;
				int top = r.Top;
				int bottom = r.Bottom;
				int width = r.Width;
				int height = r.Height;
				bool stepsEnabled = channel.IntensityGradient.StepsEnabled;
				int num3 = dockVertical ? width : height;
				Bitmap image = (!stepsEnabled) ? this.GetGradientBitmap(num3, dockVertical) : this.GetStepBitmap(num3, dockVertical);
				if (base.DockRight)
				{
					p.Graphics.DrawImage(image, left, top);
				}
				else if (base.DockLeft)
				{
					p.Graphics.DrawImage(image, right - this.GradientWidth, top);
				}
				else if (base.DockTop)
				{
					p.Graphics.DrawImage(image, left, bottom - this.GradientWidth);
				}
				else if (base.DockBottom)
				{
					p.Graphics.DrawImage(image, left, top);
				}
				if (this.TicksVisible)
				{
					if (base.DockRight)
					{
						num = left + this.GradientWidth + this.TicksMargin;
					}
					else if (base.DockLeft)
					{
						num = right - this.GradientWidth - this.TicksMargin;
					}
					else if (base.DockTop)
					{
						num = bottom - this.GradientWidth - this.TicksMargin;
					}
					else if (base.DockBottom)
					{
						num = top + this.GradientWidth + this.TicksMargin;
					}
					if (base.DockRight)
					{
						num2 = num + this.TicksLength + this.m_TicksLabelMarginPixels;
					}
					else if (base.DockLeft)
					{
						num2 = num - this.TicksLength - this.m_TicksLabelMarginPixels;
					}
					else if (base.DockTop)
					{
						num2 = num - this.TicksLength - this.m_TicksLabelMarginPixels;
					}
					else if (base.DockBottom)
					{
						num2 = num + this.TicksLength + this.m_TicksLabelMarginPixels;
					}
					Size maxSizeTickLabels = this.m_MaxSizeTickLabels;
					DrawStringFormat genericTypographic = DrawStringFormat.GenericTypographic;
					genericTypographic.LineAlignment = StringAlignment.Center;
					genericTypographic.Alignment = StringAlignment.Far;
					Pen pen = p.Graphics.Pen(base.ForeColor);
					for (int i = 0; i < this.m_Positions.Length; i++)
					{
						string s = (string)this.m_Ticks[i];
						int num4 = dockVertical ? (left + (int)(this.m_Positions[i] * (float)num3)) : (top + (int)(this.m_Positions[i] * (float)num3));
						if (base.DockRight)
						{
							p.Graphics.DrawLine(pen, num, num4, num + this.TicksLength, num4);
						}
						else if (base.DockLeft)
						{
							p.Graphics.DrawLine(pen, num, num4, num - this.TicksLength, num4);
						}
						else if (base.DockTop)
						{
							p.Graphics.DrawLine(pen, num4, num, num4, num - this.TicksLength);
						}
						else if (base.DockBottom)
						{
							p.Graphics.DrawLine(pen, num4, num, num4, num + this.TicksLength);
						}
						if (base.DockRight)
						{
							r = new Rectangle(num2, num4 - maxSizeTickLabels.Height / 2, maxSizeTickLabels.Width, maxSizeTickLabels.Height);
						}
						else if (base.DockLeft)
						{
							r = new Rectangle(num2 - maxSizeTickLabels.Width, num4 - maxSizeTickLabels.Height / 2, maxSizeTickLabels.Width, maxSizeTickLabels.Height);
						}
						else if (base.DockTop)
						{
							r = new Rectangle(num4 - maxSizeTickLabels.Height / 2, num2 - maxSizeTickLabels.Width, maxSizeTickLabels.Height, maxSizeTickLabels.Width);
						}
						else if (base.DockBottom)
						{
							r = new Rectangle(num4 - maxSizeTickLabels.Height / 2, num2, maxSizeTickLabels.Height, maxSizeTickLabels.Width);
						}
						if (base.DockRight)
						{
							p.Graphics.DrawRotatedText(s, base.Font, base.ForeColor, r, TextRotation.X000, genericTypographic);
						}
						else if (base.DockLeft)
						{
							p.Graphics.DrawRotatedText(s, base.Font, base.ForeColor, r, TextRotation.X000, genericTypographic);
						}
						else if (base.DockTop)
						{
							p.Graphics.DrawRotatedText(s, base.Font, base.ForeColor, r, TextRotation.X090, genericTypographic);
						}
						else if (base.DockBottom)
						{
							p.Graphics.DrawRotatedText(s, base.Font, base.ForeColor, r, TextRotation.X090, genericTypographic);
						}
						if (this.TicksShowFirstAndLastOnly && i == 0)
						{
							i = this.m_Positions.Length - 2;
						}
					}
				}
			}
		}
	}
}
