using Iocomp.Interfaces;
using Iocomp.Types;
using System;
using System.ComponentModel;
using System.Timers;

namespace Iocomp.Classes
{
	[Description("Contains the properties that control the animation.")]
	public sealed class Animation : SubClassBase, IAnimation
	{
		private Timer m_Timer;

		private bool m_On;

		private int m_FrameNumber;

		private int m_FrameCount;

		private FrameDirection m_Direction;

		int IAnimation.FrameCount
		{
			get
			{
				return this.FrameCount;
			}
			set
			{
				this.FrameCount = value;
			}
		}

		int IAnimation.FrameNumber
		{
			get
			{
				return this.FrameNumber;
			}
			set
			{
				this.FrameNumber = value;
			}
		}

		[Description("Specifies the time interval for the animation.")]
		[RefreshProperties(RefreshProperties.All)]
		public double Interval
		{
			get
			{
				return this.m_Timer.Interval;
			}
			set
			{
				base.PropertyUpdateDefault("Interval", value);
				if (this.m_Timer.Interval != (double)(int)value)
				{
					this.m_Timer.Interval = (double)(int)value;
					base.DoPropertyChange(this, "Interval");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies direction for the animation.")]
		public FrameDirection Direction
		{
			get
			{
				return this.m_Direction;
			}
			set
			{
				base.PropertyUpdateDefault("Direction", value);
				if (this.Direction != value)
				{
					this.m_Direction = value;
					base.DoPropertyChange(this, "Direction");
				}
			}
		}

		[Description("Specifies if the animation is on or off.")]
		[RefreshProperties(RefreshProperties.All)]
		public bool On
		{
			get
			{
				return this.m_On;
			}
			set
			{
				base.PropertyUpdateDefault("On", value);
				if (this.On != value)
				{
					this.m_On = value;
					if (!base.Designing)
					{
						this.m_Timer.Enabled = value;
					}
					base.DoPropertyChange(this, "On");
				}
			}
		}

		private int FrameNumber
		{
			get
			{
				return this.m_FrameNumber;
			}
			set
			{
				if (value > this.FrameCount - 1)
				{
					value = 0;
				}
				if (value < 0)
				{
					value = this.FrameCount - 1;
				}
				if (this.FrameCount == 0)
				{
					value = -1;
				}
				if (this.FrameNumber != value)
				{
					this.m_FrameNumber = value;
					this.OnFrameChanged();
					base.DoPropertyChange(this, "FrameNumber");
				}
			}
		}

		private int FrameCount
		{
			get
			{
				return this.m_FrameCount;
			}
			set
			{
				if (this.FrameCount != value)
				{
					this.m_FrameCount = value;
					((IAnimation)this).FrameNumber = ((IAnimation)this).FrameNumber;
					base.DoPropertyChange(this, "FrameCount");
				}
			}
		}

		[Browsable(false)]
		public event EventHandler FrameChanged;

		protected override string GetPlugInTitle()
		{
			return "Animation";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.AnimationEditorPlugIn";
		}

		public Animation()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Timer = new Timer();
			this.m_Timer.Elapsed += this.TimerElapsed;
			this.m_Timer.Enabled = false;
		}

		public void Dispose()
		{
			if (this.m_Timer != null)
			{
				this.m_Timer.Enabled = false;
				this.m_Timer.Dispose();
				this.m_Timer = null;
			}
		}

		private bool ShouldSerializeInterval()
		{
			return base.PropertyShouldSerialize("Interval");
		}

		private void ResetInterval()
		{
			base.PropertyReset("Interval");
		}

		private bool ShouldSerializeDirection()
		{
			return base.PropertyShouldSerialize("Direction");
		}

		private void ResetDirection()
		{
			base.PropertyReset("Direction");
		}

		private bool ShouldSerializeOn()
		{
			return base.PropertyShouldSerialize("On");
		}

		private void ResetOn()
		{
			base.PropertyReset("On");
		}

		private void TimerElapsed(object sender, ElapsedEventArgs e)
		{
			if (((IAnimation)this).Direction == FrameDirection.Forward)
			{
				((IAnimation)this).FrameNumber++;
			}
			else
			{
				((IAnimation)this).FrameNumber--;
			}
		}

		private void OnFrameChanged()
		{
			if (this.FrameChanged != null)
			{
				this.FrameChanged(this, EventArgs.Empty);
			}
		}

		public void GoFirst()
		{
			if (this.Direction == FrameDirection.Forward)
			{
				this.FrameNumber = 0;
			}
			else
			{
				this.FrameNumber = this.FrameCount - 1;
			}
		}

		public void GoLast()
		{
			if (this.Direction == FrameDirection.Forward)
			{
				this.FrameNumber = this.FrameCount - 1;
			}
			else
			{
				this.FrameNumber = 0;
			}
		}
	}
}
