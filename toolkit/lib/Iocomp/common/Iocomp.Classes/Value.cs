using Iocomp.Types;
using System.ComponentModel;

namespace Iocomp.Classes
{
	[Description("Ancestor to all Value type objects.")]
	public abstract class Value : SubClassBase
	{
		private bool m_EventsEnabled;

		protected EventSource EventSource
		{
			get
			{
				if (this.ControlBase != null)
				{
					return this.ControlBase.EventSource;
				}
				return EventSource.Code;
			}
		}

		protected bool ShouldTriggerEvents
		{
			get
			{
				if (this.ComponentBase != null && this.ComponentBase.Creating)
				{
					return false;
				}
				if (this.ComponentBase != null && this.ComponentBase.Loading)
				{
					return false;
				}
				if (!this.EventsEnabled)
				{
					return false;
				}
				return true;
			}
		}

		[Description("Determines if events are triggered when the value is chaged")]
		[RefreshProperties(RefreshProperties.All)]
		public bool EventsEnabled
		{
			get
			{
				return this.m_EventsEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("EventsEnabled", value);
				if (this.EventsEnabled != value)
				{
					this.m_EventsEnabled = value;
					base.DoPropertyChange(this, "EventsEnabled");
				}
			}
		}

		public virtual string AsString
		{
			get
			{
				return "";
			}
			set
			{
			}
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.EventsEnabled = true;
		}

		private bool ShouldSerializeEventsEnabled()
		{
			return base.PropertyShouldSerialize("EventsEnabled");
		}

		private void ResetEventsEnabled()
		{
			base.PropertyReset("EventsEnabled");
		}
	}
}
