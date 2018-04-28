using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Plot Data Cursor Channel Base.")]
	public abstract class PlotDataCursorChannelBase : PlotDataCursorMultipleBase
	{
		private string m_ChannelName;

		private PlotChannelBase m_CachedChannel;

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
					if (this.m_CachedChannel != null)
					{
						base.XAxisName = this.m_CachedChannel.XAxisName;
						base.YAxisName = this.m_CachedChannel.YAxisName;
						base.Color = this.m_CachedChannel.Color;
					}
					this.SetupPointers();
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

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.ChannelName = "Channel 1";
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
			if (value is PlotChannelBase && value.Name == this.m_ChannelName)
			{
				this.m_CachedChannel = (value as PlotChannelBase);
			}
		}

		protected override void DrawSetup(PaintArgs p)
		{
			base.DrawSetup(p);
			PlotChannelBase channel = this.Channel;
			if (channel != null)
			{
				base.XAxisName = channel.XAxisName;
				base.YAxisName = channel.YAxisName;
			}
		}
	}
}
