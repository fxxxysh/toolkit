using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Iocomp.Classes
{
	[Description("Contains the properties that control the appearance for the indicator.")]
	public abstract class IndicatorText : Indicator
	{
		private string m_Text;

		private Color m_TextColorActive;

		private Color m_TextColorInactive;

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the text displayed on the indicator.")]
		public string Text
		{
			get
			{
				return this.m_Text;
			}
			set
			{
				base.PropertyUpdateDefault("Text", value);
				if (this.Text != value)
				{
					this.m_Text = value;
					base.DoPropertyChange(this, "Text");
				}
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Editor("System.Windows.Forms.Design.StringArrayEditor,System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		public string[] TextLines
		{
			get
			{
				return this.Text.Split('\n');
			}
			set
			{
				StringBuilder stringBuilder = new StringBuilder(value.Length);
				for (int i = 0; i < value.Length; i++)
				{
					if (i < value.Length - 1)
					{
						stringBuilder.Append(value[i] + "\n");
					}
					else
					{
						stringBuilder.Append(value[i]);
					}
				}
				this.Text = stringBuilder.ToString();
			}
		}

		[Description("Specifies the color of the text displayed on the indicator when it is active.")]
		[RefreshProperties(RefreshProperties.All)]
		public Color TextColorActive
		{
			get
			{
				return this.m_TextColorActive;
			}
			set
			{
				base.PropertyUpdateDefault("TextColorActive", value);
				if (this.TextColorActive != value)
				{
					this.m_TextColorActive = value;
					base.DoPropertyChange(this, "TextColorActive");
				}
			}
		}

		[RefreshProperties(RefreshProperties.All)]
		[Description("Specifies the color of the text displayed on the indicator when it is inactive.")]
		public Color TextColorInactive
		{
			get
			{
				return this.m_TextColorInactive;
			}
			set
			{
				base.PropertyUpdateDefault("TextColorInactive", value);
				if (this.TextColorInactive != value)
				{
					this.m_TextColorInactive = value;
					base.DoPropertyChange(this, "TextColorInactive");
				}
			}
		}

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}

		private bool ShouldSerializeTextLines()
		{
			return base.PropertyShouldSerialize("TextLines");
		}

		private void ResetTextLines()
		{
			base.PropertyReset("TextLines");
		}

		private bool ShouldSerializeTextColorActive()
		{
			return base.PropertyShouldSerialize("TextColorActive");
		}

		private void ResetTextColorActive()
		{
			base.PropertyReset("TextColorActive");
		}

		private bool ShouldSerializeTextColorInactive()
		{
			return base.PropertyShouldSerialize("TextColorInactive");
		}

		private void ResetTextColorInactive()
		{
			base.PropertyReset("TextColorInactive");
		}
	}
}
