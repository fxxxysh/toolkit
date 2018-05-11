using Iocomp.Interfaces;
using Iocomp.Types;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[DesignerCategory("code")]
	public abstract class SevenSegmentBase : ControlBase, ISevenSegmentBase
	{
		private Segment7 m_Segment;

		private int m_DigitSpacing;

		private Outline m_Outline;

		ISegment7 ISevenSegmentBase.Segment
		{
			get
			{
				return this.Segment;
			}
		}

		IOutline ISevenSegmentBase.Outline
		{
			get
			{
				return this.Outline;
			}
		}

		protected override int SpecialOffset => this.Outline.Thickness;

		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Seven Segment properties")]
		public Segment7 Segment
		{
			get
			{
				return this.m_Segment;
			}
		}

		[Category("Iocomp")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Description("Outline properties")]
		public Outline Outline
		{
			get
			{
				return this.m_Outline;
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[Category("Iocomp")]
		public int DigitSpacing
		{
			get
			{
				return this.m_DigitSpacing;
			}
			set
			{
				base.PropertyUpdateDefault("DigitSpacing", value);
				if (this.DigitSpacing != value)
				{
					this.m_DigitSpacing = value;
					base.DoPropertyChange(this, "DigitSpacing");
				}
			}
		}

		protected override void CreateObjects()
		{
			this.m_Segment = new Segment7();
			base.AddSubClass(this.Segment);
			this.m_Outline = new Outline();
			base.AddSubClass(this.Outline);
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.DigitSpacing = 6;
			base.Border.Style = BorderStyleControl.Raised;
			base.Border.ThicknessDesired = 3;
			this.Segment.ColorOffAuto = true;
			this.Segment.ColorOn = Color.Lime;
			this.Segment.ColorOff = iColors.ToOffColor(Color.Lime);
			this.Segment.Size = 1;
			this.Segment.Separation = 1;
			this.Segment.ShowOffSegments = true;
			this.Outline.Thickness = 3;
			this.Outline.Color = Color.Black;
		}

		private bool ShouldSerializeSegment()
		{
			return ((ISubClassBase)this.Segment).ShouldSerialize();
		}

		private void ResetSegment()
		{
			((ISubClassBase)this.Segment).ResetToDefault();
		}

		private bool ShouldSerializeOutline()
		{
			return ((ISubClassBase)this.Outline).ShouldSerialize();
		}

		private void ResetOutline()
		{
			((ISubClassBase)this.Outline).ResetToDefault();
		}

		private bool ShouldSerializeDigitSpacing()
		{
			return base.PropertyShouldSerialize("DigitSpacing");
		}

		private void ResetDigitSpacing()
		{
			base.PropertyReset("DigitSpacing");
		}
	}
}
