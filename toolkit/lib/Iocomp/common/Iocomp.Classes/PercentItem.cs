using Iocomp.Delegates;
using Iocomp.Design;
using Iocomp.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(CollectionItemConverter))]
	public sealed class PercentItem : SubClassBase
	{
		private ValueDouble m_Value;

		private string m_Title;

		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[RefreshProperties(RefreshProperties.All)]
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

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string Title
		{
			get
			{
				return this.m_Title;
			}
			set
			{
				base.PropertyUpdateDefault("Title", value);
				if (this.Title != value)
				{
					this.m_Title = value;
					base.DoPropertyChange(this, "Title");
				}
			}
		}

		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
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

		[Category("Iocomp")]
		public event ValueDoubleEventHandler ValueChanged;

		[Category("Iocomp")]
		public event ValueDoubleEventHandler ValueBeforeChange;

		protected override string GetPlugInTitle()
		{
			return "Percent Item";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.PercentItemEditorPlugIn";
		}

		public PercentItem()
		{
			base.DoCreate();
		}

		protected override void CreateObjects()
		{
			base.CreateObjects();
			this.m_Value = new ValueDouble();
			base.AddSubClass(this.Value);
			this.Value.Changing += this.OnValueBeforeChange;
			this.Value.Changed += this.OnValueChanged;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Value.AsDouble = 100.0;
			this.Title = "Untitled";
			this.Color = Color.Red;
		}

		private bool ShouldSerializeValue()
		{
			return ((ISubClassBase)this.Value).ShouldSerialize();
		}

		private void ResetValue()
		{
			((ISubClassBase)this.Value).ResetToDefault();
		}

		private bool ShouldSerializeTitle()
		{
			return base.PropertyShouldSerialize("Title");
		}

		private void ResetTitle()
		{
			base.PropertyReset("Title");
		}

		private bool ShouldSerializeColor()
		{
			return base.PropertyShouldSerialize("Color");
		}

		private void ResetColor()
		{
			base.PropertyReset("Color");
		}

		private void OnValueChanged(object sender, ValueDoubleEventArgs e)
		{
			if (this.ValueChanged != null)
			{
				this.ValueChanged(this, e);
			}
		}

		private void OnValueBeforeChange(object sender, ValueDoubleEventArgs e)
		{
			if (this.ValueBeforeChange != null)
			{
				this.ValueBeforeChange(this, e);
			}
		}

		public override string ToString()
		{
			return this.Title;
		}
	}
}
