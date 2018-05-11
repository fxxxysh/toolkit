using Iocomp.Design;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(CollectionItemConverter))]
	public class ColorSection : SubClassBase
	{
		private double m_Start;

		private double m_Stop;

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Start
		{
			get
			{
				return this.m_Start;
			}
			set
			{
				base.PropertyUpdateDefault("Start", value);
				if (this.Start != value)
				{
					this.m_Start = value;
					base.DoPropertyChange(this, "Start");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public double Stop
		{
			get
			{
				return this.m_Stop;
			}
			set
			{
				base.PropertyUpdateDefault("Stop", value);
				if (this.Stop != value)
				{
					this.m_Stop = value;
					base.DoPropertyChange(this, "Stop");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public new Color Color
		{
			get
			{
				return base.Color;
			}
			set
			{
				base.Color = value;
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

		protected override string GetPlugInTitle()
		{
			return "Color Section";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ColorSectionEditorPlugIn";
		}

		public ColorSection()
		{
			base.DoCreate();
		}

		public ColorSection(Color color, double start, double stop)
		{
			base.DoCreate();
			this.Color = color;
			this.Start = start;
			this.Stop = stop;
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.Start = 0.0;
			this.Stop = 50.0;
			this.Color = Color.Red;
			this.Visible = true;
		}

		private bool ShouldSerializeStart()
		{
			return base.PropertyShouldSerialize("Start");
		}

		private void ResetStart()
		{
			base.PropertyReset("Start");
		}

		private bool ShouldSerializeStop()
		{
			return base.PropertyShouldSerialize("Stop");
		}

		private void ResetStop()
		{
			base.PropertyReset("Stop");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private bool ShouldSerializeVisible()
		{
			return base.PropertyShouldSerialize("Visible");
		}

		private void ResetVisible()
		{
			base.PropertyReset("Visible");
		}

		public override string ToString()
		{
			return "Section-" + this.Color.ToString();
		}
	}
}
