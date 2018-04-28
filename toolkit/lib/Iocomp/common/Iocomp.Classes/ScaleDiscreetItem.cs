using Iocomp.Design;
using System.ComponentModel;
using System.Drawing;

namespace Iocomp.Classes
{
	[TypeConverter(typeof(CollectionItemConverter))]
	public sealed class ScaleDiscreetItem : SubClassBase
	{
		private string m_Text;

		private Rectangle m_TextRectangle;

		private Point m_MarkerPoint;

		private Point m_LinePoint1;

		private Point m_LinePoint2;

		private Point m_LinePoint3;

		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
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
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[Browsable(false)]
		public Rectangle TextRectangle
		{
			get
			{
				return this.m_TextRectangle;
			}
			set
			{
				this.m_TextRectangle = value;
			}
		}

		[Browsable(false)]
		[Description("")]
		[RefreshProperties(RefreshProperties.All)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Point MarkerPoint
		{
			get
			{
				return this.m_MarkerPoint;
			}
			set
			{
				this.m_MarkerPoint = value;
			}
		}

		[Browsable(false)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Point LinePoint1
		{
			get
			{
				return this.m_LinePoint1;
			}
			set
			{
				this.m_LinePoint1 = value;
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[RefreshProperties(RefreshProperties.All)]
		[Description("")]
		public Point LinePoint2
		{
			get
			{
				return this.m_LinePoint2;
			}
			set
			{
				this.m_LinePoint2 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Description("")]
		public Point LinePoint3
		{
			get
			{
				return this.m_LinePoint3;
			}
			set
			{
				this.m_LinePoint3 = value;
			}
		}

		protected override string GetPlugInTitle()
		{
			return "Scale Item";
		}

		protected override string GetPlugInClassName()
		{
			return "Iocomp.Design.ScaleDiscreetItemEditorPlugIn";
		}

		public ScaleDiscreetItem()
		{
			base.DoCreate();
		}

		public ScaleDiscreetItem(string text)
		{
			base.DoCreate();
			this.Text = text;
		}

		protected override void SetDefaults()
		{
			base.SetDefaults();
			this.Text = "Untitled";
		}

		public override string ToString()
		{
			return this.Text;
		}

		private bool ShouldSerializeText()
		{
			return base.PropertyShouldSerialize("Text");
		}

		private void ResetText()
		{
			base.PropertyReset("Text");
		}
	}
}
