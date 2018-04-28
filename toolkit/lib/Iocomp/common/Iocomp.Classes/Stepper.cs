using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Timers;

namespace Iocomp.Classes
{
	[Description("Contains the properties that control the stepper.")]
	public sealed class Stepper : SubClassBase, IStepper
	{
		private ValueDouble m_Value;

		private Timer m_Timer;

		private int m_RepeaterInterval;

		private int m_RepeaterInitialDelay;

		private bool m_Reversed;

		private double m_StepSize;

		private bool m_RepeaterEnabled;

		private DirectionState m_StepState;

		[RefreshProperties(RefreshProperties.All)]
		[Description("Indicates the value to be stepped up or down.")]
		public ValueDouble Value
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value.AsDouble = value.AsDouble;
			}
		}

		[Description("Specifies the time interval for the auto repeat.")]
		[RefreshProperties(RefreshProperties.All)]
		public int RepeaterInterval
		{
			get
			{
				return this.m_RepeaterInterval;
			}
			set
			{
				base.PropertyUpdateDefault("RepeaterInterval", value);
				if (this.RepeaterInterval != value)
				{
					this.m_RepeaterInterval = value;
					base.DoPropertyChange(this, "RepeaterInterval");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the initial delay time before the value is stepped during the auto repeat mode.")]
		public int RepeaterInitialDelay
		{
			get
			{
				return this.m_RepeaterInitialDelay;
			}
			set
			{
				base.PropertyUpdateDefault("RepeaterInitialDelay", value);
				if (this.RepeaterInitialDelay != value)
				{
					this.m_RepeaterInitialDelay = value;
					base.DoPropertyChange(this, "RepeaterInitialDelay");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Indicates the direction of the stepper.")]
		public bool Reversed
		{
			get
			{
				return this.m_Reversed;
			}
			set
			{
				base.PropertyUpdateDefault("Reversed", value);
				if (this.Reversed != value)
				{
					this.m_Reversed = value;
					base.DoPropertyChange(this, "Reversed");
				}
			}
		}

		[Description("Specifies the amount to increment or decrement the value.")]
		[RefreshProperties(RefreshProperties.All)]
		public double StepSize
		{
			get
			{
				return this.m_StepSize;
			}
			set
			{
				base.PropertyUpdateDefault("StepSize", value);
				if (this.StepSize != value)
				{
					this.m_StepSize = value;
					base.DoPropertyChange(this, "StepSize");
				}
			}
		}

		[Description("Indicates if the auto reaper is on or off.")]
		[RefreshProperties(RefreshProperties.All)]
		public bool RepeaterEnabled
		{
			get
			{
				return this.m_RepeaterEnabled;
			}
			set
			{
				base.PropertyUpdateDefault("RepeaterEnabled", value);
				if (this.RepeaterEnabled != value)
				{
					this.m_RepeaterEnabled = value;
					base.DoPropertyChange(this, "RepeaterEnabled");
				}
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Stepper";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.StepperEditorPlugIn";
		}

		void IStepper.StopStep(DirectionState stepState)
		{
			this.StopStep(stepState);
		}

		void IStepper.StartStep(DirectionState stepState)
		{
			this.StartStep(stepState);
		}

		public Stepper()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Value = new ValueDouble();
			base.AddSubClass(this.Value);
			this.m_Timer = new Timer();
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
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

		private bool ShouldSerializeValue()
		{
			return ((ISubClassBase)this.Value).ShouldSerialize();
		}

		private void ResetValue()
		{
			((ISubClassBase)this.Value).ResetToDefault();
		}

		private bool ShouldSerializeRepeaterInterval()
		{
			return base.PropertyShouldSerialize("RepeaterInterval");
		}

		private void ResetRepeaterInterval()
		{
			base.PropertyReset("RepeaterInterval");
		}

		private bool ShouldSerializeRepeaterInitialDelay()
		{
			return base.PropertyShouldSerialize("RepeaterInitialDelay");
		}

		private void ResetRepeaterInitialDelay()
		{
			base.PropertyReset("RepeaterInitialDelay");
		}

		private bool ShouldSerializeReversed()
		{
			return base.PropertyShouldSerialize("Reversed");
		}

		private void ResetReversed()
		{
			base.PropertyReset("Reversed");
		}

		private bool ShouldSerializeStepSize()
		{
			return base.PropertyShouldSerialize("StepSize");
		}

		private void ResetStepSize()
		{
			base.PropertyReset("StepSize");
		}

		private bool ShouldSerializeRepeaterEnabled()
		{
			return base.PropertyShouldSerialize("RepeaterEnabled");
		}

		private void ResetRepeaterEnabled()
		{
			base.PropertyReset("RepeaterEnabled");
		}

		private void StartStep(DirectionState stepState)
		{
			this.m_StepState = stepState;
			if (stepState != 0 && this.RepeaterEnabled)
			{
				this.m_Timer.Interval = (double)this.RepeaterInitialDelay;
				this.m_Timer.Enabled = true;
			}
		}

		private void StopStep(DirectionState stepState)
		{
			if (stepState == this.m_StepState)
			{
				this.StepIt();
			}
			if (this.RepeaterEnabled)
			{
				this.m_Timer.Enabled = false;
			}
		}

		private void TimerElapsed(object sender, ElapsedEventArgs e)
		{
			this.m_Timer.Interval = (double)this.RepeaterInterval;
			this.StepIt();
		}

		private void StepIt()
		{
			this.Value.BeginUserUpdate();
			if (this.Reversed)
			{
				if (this.m_StepState == DirectionState.Increment)
				{
					this.Value.AsDouble = this.Value.AsDouble - this.m_StepSize;
				}
				else if (this.m_StepState == DirectionState.Decrement)
				{
					this.Value.AsDouble = this.Value.AsDouble + this.m_StepSize;
				}
			}
			else if (this.m_StepState == DirectionState.Increment)
			{
				this.Value.AsDouble = this.Value.AsDouble + this.m_StepSize;
			}
			else if (this.m_StepState == DirectionState.Decrement)
			{
				this.Value.AsDouble = this.Value.AsDouble - this.m_StepSize;
			}
			this.Value.EndUserUpdate();
		}
	}
}
