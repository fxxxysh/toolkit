using Iocomp.Types;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Table Channel.")]
	public class PlotTableChannel : PlotTableBase
	{
		private string m_ChannelName;

		private int m_DataPointCount;

		private int m_DataPointStartIndex;

		private PlotTableDataPointRangeStyle m_DataPointRangeStyle;

		private PlotChannelBase m_CachedChannel;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public int DataPointCount
		{
			get
			{
				return this.m_DataPointCount;
			}
			set
			{
				base.PropertyUpdateDefault("DataPointCount", value);
				if (this.DataPointCount != value)
				{
					this.m_DataPointCount = value;
					base.DoPropertyChange(this, "DataPointCount");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public int DataPointStartIndex
		{
			get
			{
				return this.m_DataPointStartIndex;
			}
			set
			{
				base.PropertyUpdateDefault("DataPointStartIndex", value);
				if (this.DataPointStartIndex != value)
				{
					this.m_DataPointStartIndex = value;
					base.DoPropertyChange(this, "DataPointStartIndex");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public PlotTableDataPointRangeStyle DataPointRangeStyle
		{
			get
			{
				return this.m_DataPointRangeStyle;
			}
			set
			{
				base.PropertyUpdateDefault("DataPointRangeStyle", value);
				if (this.DataPointRangeStyle != value)
				{
					this.m_DataPointRangeStyle = value;
					base.DoPropertyChange(this, "DataPointRangeStyle");
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

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public PlotChannelBase Channel
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
				this.m_CachedChannel = base.Plot.Channels[this.ChannelName];
				return this.m_CachedChannel;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Table Channel";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PlotTableChannelEditorPlugIn";
		}

		public PlotTableChannel()
		{
			base.DoCreate();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			base.NameShort = "Channel";
			this.ChannelName = "Channel 1";
			base.DataColCount = 2;
			base.DataRowCount = 10;
			this.DataPointCount = 10;
			this.DataPointRangeStyle = PlotTableDataPointRangeStyle.Ending;
		}

		private bool ShouldSerializeDataPointCount()
		{
			return base.PropertyShouldSerialize("DataPointCount");
		}

		private void ResetDataPointCount()
		{
			base.PropertyReset("DataPointCount");
		}

		private bool ShouldSerializeDataPointStartIndex()
		{
			return base.PropertyShouldSerialize("DataPointStartIndex");
		}

		private void ResetDataPointStartIndex()
		{
			base.PropertyReset("DataPointStartIndex");
		}

		private bool ShouldSerializeDataPointRangeStyle()
		{
			return base.PropertyShouldSerialize("DataPointRangeStyle");
		}

		private void ResetDataPointRangeStyle()
		{
			base.PropertyReset("DataPointRangeStyle");
		}

		private bool ShouldSerializeLegendName()
		{
			return base.PropertyShouldSerialize("ChannelName");
		}

		private void ResetLegendName()
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
			if (value is PlotChannelBase && value.Name == this.m_ChannelName)
			{
				this.m_CachedChannel = (value as PlotChannelBase);
			}
		}

		private void SetupForError(string value)
		{
		}

		protected override void CalculateDepthPixels(PaintArgs p)
		{
			base.FreezePropertyChange = true;
			base.IgnoreCellChanges = true;
			if (base.DockVertical)
			{
				base.ColTitlesVisible = false;
				base.RowTitlesVisible = true;
				base.DataRowCount = 2;
				base.DataColCount = this.DataPointCount;
				base[0, 1].Text = "X";
				base[0, 2].Text = "Y";
			}
			else
			{
				base.ColTitlesVisible = true;
				base.RowTitlesVisible = false;
				base.DataColCount = 2;
				base.DataRowCount = this.DataPointCount;
				base[1, 0].Text = "X";
				base[2, 0].Text = "Y";
			}
			PlotChannelBase channel = this.Channel;
			if (channel == null)
			{
				this.SetupForError("Channel Not Assigend");
			}
			else if (channel.XAxis == null)
			{
				this.SetupForError("Channel X-Axis not Assigend");
			}
			else if (channel.YAxis == null)
			{
				this.SetupForError("Channel Y-Axis not Assigend");
			}
			else
			{
				int num = (this.DataPointRangeStyle != 0) ? ((this.DataPointRangeStyle != PlotTableDataPointRangeStyle.Ending) ? ((this.DataPointRangeStyle == PlotTableDataPointRangeStyle.FromStartIndex) ? this.DataPointStartIndex : 0) : (channel.Count - this.DataPointCount)) : 0;
				for (int i = 0; i < this.DataPointCount; i++)
				{
					int num2 = i + 1;
					int num3 = num + i;
					PlotTableCell plotTableCell;
					PlotTableCell plotTableCell2;
					if (base.DockVertical)
					{
						plotTableCell = base[num2, 1];
						plotTableCell2 = base[num2, 2];
					}
					else
					{
						plotTableCell = base[1, num2];
						plotTableCell2 = base[2, num2];
					}
					if (channel.Count != 0 && num3 >= 0 && num3 <= channel.IndexLast)
					{
						plotTableCell.Text = channel.XAxis.TextFormatting.GetText(channel.GetX(num3));
						plotTableCell2.Text = channel.YAxis.TextFormatting.GetText(channel.GetY(num3));
					}
					else
					{
						plotTableCell.Text = Const.EmptyString;
						plotTableCell2.Text = Const.EmptyString;
					}
				}
				base.FreezePropertyChange = false;
				base.IgnoreCellChanges = false;
				base.CalculateDepthPixels(p);
			}
		}
	}
}
